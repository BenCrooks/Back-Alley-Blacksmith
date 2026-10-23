using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Object = UnityEngine.Object;

// Tools > Dialogue > Check Dialogue: plays every branch of the ink story and checks it
// against what the game needs, so mistakes show up before you find them in play mode.
public static class DialogueChecker
{
    private const string StoryPath = "Assets/Dialogue/BackAlleyBlacksmith.ink";
    private const string ScenePath = "Assets/Scenes/SampleScene.unity";
    private const int ResponseButtons = 3;

    [MenuItem("Tools/Dialogue/Check Dialogue")]
    public static void CheckFromMenu(){
        List<string> problems = Check(out string report);
        if(problems.Count == 0){
            Debug.Log(report);
        }else{
            Debug.LogError(report);
        }
        EditorUtility.DisplayDialog("Check Dialogue", problems.Count == 0 ? "No problems found." : $"{problems.Count} problem(s) found. See the Console for details.", "OK");
    }

    //Unity -batchmode -projectPath <project> -executeMethod DialogueChecker.CheckFromCommandLine
    public static void CheckFromCommandLine(){
        EditorSceneManager.OpenScene(ScenePath);
        List<string> problems = Check(out string report);
        Debug.Log(report);
        EditorApplication.Exit(problems.Count == 0 ? 0 : 1);
    }

    public static List<string> Check(out string report){
        List<string> problems = new List<string>();
        List<string> notes = new List<string>();

        InkFile inkFile = AssetDatabase.LoadAssetAtPath<InkFile>(StoryPath);
        if(inkFile == null || !inkFile.isCompiled){
            problems.Add($"{StoryPath} is missing or didn't compile.");
            if(inkFile != null){
                problems.AddRange(inkFile.errors.Select(e => "ink error: " + e.content));
            }
            report = Report(problems, notes);
            return problems;
        }
        problems.AddRange(inkFile.warnings.Select(w => "ink warning: " + w.content));
        notes.AddRange(inkFile.todos.Select(t => "TODO: " + t.content));

        DialogueManager manager = Object.FindAnyObjectByType<DialogueManager>(FindObjectsInactive.Include);
        CharacterManager characters = Object.FindAnyObjectByType<CharacterManager>(FindObjectsInactive.Include);
        if(manager == null || characters == null){
            problems.Add($"Open {ScenePath} first: the checker needs its DialogueManager and CharacterManager.");
            report = Report(problems, notes);
            return problems;
        }
        if(new SerializedObject(manager).FindProperty("inkStory").objectReferenceValue != inkFile){
            problems.Add($"DialogueManager's Ink Story field isn't set to {StoryPath}.");
        }
        CheckItemList(manager, problems);

        //customers in the scene, by knot
        Dictionary<string, string> sceneCustomers = new Dictionary<string, string>();
        foreach(Transform child in characters.transform){
            DialogueHolder holder = child.GetComponent<DialogueHolder>();
            if(holder == null || string.IsNullOrEmpty(holder.inkKnot)){
                continue;
            }
            if(sceneCustomers.ContainsKey(holder.inkKnot)){
                problems.Add($"{child.name} and {sceneCustomers[holder.inkKnot]} both use Ink Knot '{holder.inkKnot}'.");
            }else{
                sceneCustomers[holder.inkKnot] = child.name;
            }
        }

        //everyone the customers list can send in, whether or not earlier customers buy
        Story story = new Story(inkFile.storyJson);
        HashSet<string> queued = new HashSet<string>(QueueNames(inkFile, false).Concat(QueueNames(inkFile, true)));
        foreach(string knot in queued){
            if(story.KnotContainerWithName(knot) == null){
                problems.Add($"The customers list names '{knot}', but there's no knot called that.");
            }else if(!sceneCustomers.ContainsKey(knot)){
                problems.Add($"The customers list names '{knot}', but no customer under CharacterManager has that Ink Knot.");
            }
        }
        foreach(KeyValuePair<string, string> customer in sceneCustomers){
            if(story.KnotContainerWithName(customer.Key) == null){
                problems.Add($"{customer.Value}'s Ink Knot '{customer.Key}' doesn't exist in the story.");
            }else if(!queued.Contains(customer.Key)){
                notes.Add($"{customer.Value} ('{customer.Key}') isn't in the customers list, so they never come in.");
            }
        }

        int branches = 0;
        foreach(string knot in queued.Where(k => story.KnotContainerWithName(k) != null).OrderBy(k => k)){
            branches += CheckConversation(inkFile, knot, manager, problems);
        }
        notes.Insert(0, $"Played {branches} lines and choices across {queued.Count} customers.");
        report = Report(problems, notes);
        return problems;
    }

    //walks every choice in a customer's conversation from a fresh story
    private static int CheckConversation(InkFile inkFile, string knot, DialogueManager manager, List<string> problems){
        Story story = new Story(inkFile.storyJson);
        story.ChoosePathString(knot);
        Queue<string> pending = new Queue<string>();
        HashSet<string> seen = new HashSet<string>();
        pending.Enqueue(story.state.ToJson());
        int steps = 0;
        bool anyDeal = false;
        while(pending.Count > 0 && steps < 5000){
            story.state.LoadJson(pending.Dequeue());
            List<string> tags = new List<string>();
            try{
                while(story.canContinue){
                    story.Continue();
                    tags.AddRange(story.currentTags);
                }
            }catch(StoryException e){
                problems.Add($"{knot}: {e.Message}");
                continue;
            }
            steps++;
            if(tags.Contains("deal")){
                anyDeal = true;
                CheckDealTags(knot, tags, manager, problems);
            }
            if(story.currentChoices.Count > ResponseButtons){
                problems.Add($"{knot}: a line offers {story.currentChoices.Count} choices, but there are only {ResponseButtons} response buttons ({string.Join(" / ", story.currentChoices.Select(c => c.text))}).");
            }
            //choosing changes the state, so read the choices before trying each one
            string here = story.state.ToJson();
            List<string> targets = story.currentChoices.Select(c => c.targetPath.ToString()).ToList();
            for(int i=0; i<targets.Count; i++){
                if(seen.Add(targets[i])){
                    story.state.LoadJson(here);
                    story.ChooseChoiceIndex(i);
                    pending.Enqueue(story.state.ToJson());
                }
            }
        }
        if(anyDeal){
            foreach(string stitch in new[]{"correct_item", "wrong_item"}){
                if(!HasStitch(story, knot, stitch)){
                    problems.Add($"{knot} can make a deal but has no '= {stitch}' stitch for the reaction.");
                }
            }
        }
        return steps;
    }

    private static void CheckDealTags(string knot, List<string> tags, DialogueManager manager, List<string> problems){
        bool wantsSomething = false;
        foreach(string tag in tags){
            int colon = tag.IndexOf(':');
            if(colon < 0){
                continue;
            }
            string key = tag.Substring(0, colon).Trim().ToLowerInvariant();
            if(key != "wants" && key != "gives"){
                continue;
            }
            foreach(string name in tag.Substring(colon+1).Split(',').Select(s => s.Trim()).Where(s => s.Length > 0)){
                wantsSomething |= key == "wants";
                if(manager.FindItem(name) == null){
                    AddOnce(problems, $"{knot}: #{key} names '{name}', which isn't an item in DialogueManager's item list.");
                }
            }
        }
        if(!wantsSomething){
            AddOnce(problems, $"{knot}: a deal has no #wants tag, so no item can satisfy them.");
        }
    }

    //several routes can lead to the same deal, so only report each problem once
    private static void AddOnce(List<string> problems, string problem){
        if(!problems.Contains(problem)){
            problems.Add(problem);
        }
    }

    private static void CheckItemList(DialogueManager manager, List<string> problems){
        List<SmithingScriptableObj> listed = new List<SmithingScriptableObj>();
        SerializedProperty items = new SerializedObject(manager).FindProperty("items");
        for(int i=0; i<items.arraySize; i++){
            listed.Add(items.GetArrayElementAtIndex(i).objectReferenceValue as SmithingScriptableObj);
        }
        int missing = AssetDatabase.FindAssets("t:SmithingScriptableObj")
            .Select(guid => AssetDatabase.LoadAssetAtPath<SmithingScriptableObj>(AssetDatabase.GUIDToAssetPath(guid)))
            .Count(item => !listed.Contains(item));
        if(missing > 0){
            problems.Add($"DialogueManager's item list is missing {missing} item(s). Right-click the DialogueManager component > Find All Items.");
        }
    }

    //the knots the customers list sends in if everybody (or nobody) buys, read the same
    //way DialogueManager does: the list in its own flow, each sale in the default flow
    private static IEnumerable<string> QueueNames(InkFile inkFile, bool everyoneBuys){
        Story story = new Story(inkFile.storyJson);
        story.SwitchFlow("queue");
        story.ChoosePathString("customers");
        List<string> names = new List<string>();
        while(story.canContinue){
            string name = story.Continue().Trim();
            if(name.Length == 0){
                continue;
            }
            names.Add(name);
            if(everyoneBuys && HasStitch(story, name, "correct_item")){
                story.SwitchToDefaultFlow();
                story.ChoosePathString(name + ".correct_item");
                while(story.canContinue){
                    story.Continue();
                }
                story.SwitchFlow("queue");
            }
        }
        return names;
    }

    private static bool HasStitch(Story story, string knot, string stitch){
        Container container = story.KnotContainerWithName(knot);
        return container != null && container.namedContent.ContainsKey(stitch);
    }

    private static string Report(List<string> problems, List<string> notes){
        string header = problems.Count == 0 ? "Check Dialogue: no problems." : $"Check Dialogue: {problems.Count} problem(s).";
        return header + "\n" + string.Join("\n", problems.Select(p => "  PROBLEM  " + p).Concat(notes.Select(n => "  note     " + n)));
    }
}
