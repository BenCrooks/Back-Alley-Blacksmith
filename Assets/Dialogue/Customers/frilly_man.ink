// Frilly Man (two visits)

// ----------------------------------------------------------------------------
// Scene object: FrillyMan
// in the scene, a successful sale turns on FrillyMan (1).
=== frilly_man ===
Good morrow good sir!
+ [Ah... The morrow is verry nice! yes...] -> oh_are_you_quite
+ [I'm not a sir...] -> yes_a_simple_term
+ [Yes indeed my good sir, how fair thee?] -> yes_well_you_see

= oh_are_you_quite
Oh? Are you quite alright? You seem to be a little turned around?
+ [I am alright, and you?] -> yes_well_you_see
+ [I'm not going to spin for you. If thats what youre asking?] -> my_dear_boy_i
+ [Ugh I'm fine! What do you need?] -> i_need_an_arrow

= yes_a_simple_term
Yes! A simple term of endearment is all I meant. I know you are not a knight or a lord!
+ [I'm not a dear either!] -> no_no_you_misunderstood
+ [I just meant I don't like being called sir.] -> no_no_you_misunderstood
+ [Wait how did you know I was not a knight or a lord?] -> umm_its_because_of

= yes_well_you_see
Yes well you see I am not well. Which is why I am here... I have infact been stabbed!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= my_dear_boy_i
My dear boy I hope your arrows are sharper than you are.
+ [Whats that supposed to mean?!]
    Hmm, wll I suppose if you don't understand the question youre really not smart enough!
    -> DONE
+ [I'm just teasing, sorry.] -> ah_a_jest_very
+ [They certainly are! lets get you some arrows!] -> yes_thank_you_i

= i_need_an_arrow
I need an arrow for my love potion. To shoot my loved one as cupid does!
+ [That is the cutest thing I have ever heard!] -> yes_thank_you_i
+ [Is that safe?] -> where_is_your_passion
+ [Why don't you just make her drink the potion?] -> oh_how_cliche_have

= no_no_you_misunderstood
No! No! you misunderstood! What I meant was... umm... Whatsaaaap?...
+ [Yo uhh, whatsup?] -> i_am_just_spendid
+ [Are you making fun of me?] -> on_the_contrary_i
+ [Nothing much, whats up with you?] -> yes_well_you_see

= umm_its_because_of
Umm... Its because of the blacksmith outfit... Not the dirt, or accent, or... smell.
+ [Well how would you know what a knight smelled?] -> i_have_smelled_many
+ [Oh so the outfit?] -> yes_its_clear_as
+ [You don't smell like you belong here!] -> why_thank_you_look

= oh_no_what_i
Oh no, what I mean is that I have been stabbed... By the arrow of cupid! I am in love you see!
+ [Hmm, I can't help with that either.] -> that_s_where_you
+ [Oh no. I'm afraid I am in a relationship.] -> what_no_i_have
+ [Thats lovely, with who?] -> with_whom

= ah_a_jest_very
Ah a jest! Very, urm... whitty!
+ [Yes! Sharp whit! Like arrows!] -> yes_thank_you_i
+ [Why did the chicken cross the road.] -> did_you_just_call
+ [Yeah... Lets get started on those arrows!] -> yes_thank_you_i

= yes_thank_you_i
Yes! Thank you! I have no idea why the castle blacksmith would not do it for me!... Anyways, heres the love potion!
+ [Wait, what did the castle blacksmith say?] -> oh_some_hub_bub
+ [Thanks! Ill get started right away!] -> deal
+ [Some love arrows coming up!] -> deal

= where_is_your_passion
Where is your passion for romace? Is loving not dangerous!? Risking it all for passion! The chase of the hunt!
+ [Comparing it to hunting makes me feel uncomfortable.] -> on_no_not_you
+ [YES YOU'RE RIGHT! FOR LOVE!] -> yes_thank_you_i
+ [You are certainly passionate!] -> my_dear_lad_nobody

= oh_how_cliche_have
Oh how *cliche*! Have you ever heard of a meet-cute? Where are the theatrics!?
+ [It just seems a little dangerous!] -> where_is_your_passion
+ [No I have never met cute. Who's that?] -> my_dear_boy_i
+ [We could make some flaming arrows! That would be theatrical!] -> yes_theatrical_but_perhaps

= i_am_just_spendid
I am just *Spendid!*... no, I meant was I am cool, ya know
+ [Uhh, I think so? What can I help you with?] -> yes_well_you_see
+ [You're super cool...] -> ah_smashing_look_here
+ [Why are you talking like that, I don't talk like that!] -> yes_my_accent_was

= on_the_contrary_i
On the contrary, I was trying to bond! Stooping to your language level!
+ [What? Stooping? You think youre better than me?] -> well_better_is_an
+ [Uhhh, thanks? What do you need?] -> ah_smashing_look_here
+ [Well, I don't talk like that?] -> yes_my_accent_was

= i_have_smelled_many
I have smelled many knights! Thank you very much. I consider it a privaledge!
+ [Thats gross!] -> the_only_thing_that
+ [And what did they smell like?] -> the_smell_of_battle
+ [ugh, Why are you here?] -> yes_well_you_see

= yes_its_clear_as
Yes its clear as day! The outfit is what did it! Look here, I was wondering if you could help me with a pickle I'm stuck in... You see I appear to have been *stabbed*!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= why_thank_you_look
Why thank you! Look here, I was wondering if you could help me with a pickle I'm stuck in... You see I appear to have been *stabbed*!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= that_s_where_you
That's where you are mistaken my dear friend! Becuase I have come to your workshop in the name of love!
+ [We don't sell love!] -> well_i_bring_the
+ [You want to stab the person you love?] -> no_well_yes_but
+ [You want to stab your competition?] -> no_the_competition_is

= what_no_i_have
\*WHAT?* no... I have come to your workshop in the name of love!
+ [We don't sell love!] -> well_i_bring_the
+ [You want to stab the person you love?] -> no_well_yes_but
+ [You want to stab your competition?] -> no_the_competition_is

= with_whom
...With *whom*...
+ [Who is "whom"?] -> my_dear_boy_i
+ [I am still not sure you have come to the correct place...] -> that_s_where_you
+ [Ughh. Whith whom-eth?] -> thats_between_cupid_and

= did_you_just_call
\*DID YOU JUST CALL ME A CHICKEN?!*
+ [What No!] -> well_i_never_so
+ [Its a joke!] -> well_it_wasn_t
+ [Uh, yeah?...] -> well_i_never_so

= oh_some_hub_bub
Oh some hub-bub of the moral implications of shooting somebody and drugging them. Really, where has the romance gone?
+ [I will make you these arrows, for love!] -> deal
+ [Hmm, I guess he has a point...] -> well_i_hope_the
+ [Those damn castle-livers thinking they are better than us!] -> erm_i_live_in

= on_no_not_you
On no... Not you too! First the castle blacksmith now you!
+ [Wait, what did the castle blacksmith say?] -> oh_some_hub_bub
+ [I literally make things for killing, why would I have a moral dilemma about this?] -> deal
+ [I have a moral dilemma about this?] -> what_why_please_do

= my_dear_lad_nobody
My dear lad, nobody has ever been more correct! Now will you help me persue this love!
+ [Yeah, So lets get started on these arrows then!] -> yes_thank_you_i
+ [Lets Do It for love!] -> yes_thank_you_i
+ [Nah... you're creepy] -> well_i_never_so

= yes_theatrical_but_perhaps
Yes... Theatrical but perhaps a little obnoxious? Lets stick to the regular love potion arrows!
+ [Sure lets get started!] -> yes_thank_you_i
+ [No fire, no arrows...]
    What? I will not submit to your ridiculous requests! You've lost yourself a client!
    -> DONE
+ [Love arrows would certainly be less dangerous...] -> yes_thank_you_i

= ah_smashing_look_here
Ah Smashing! Look here, I was wondering if you could help me with a pickle I'm stuck in... You see I appear to have been *stabbed*!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= yes_my_accent_was
Yes, my accent was a little off... Listen, could you help me. I have been *stabbed*!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= well_better_is_an
Well better is an objective term you see. Uh, and while you, um may be a filthy pesant and *I* a beautiful lord. There is really no difference beteen us, in um... the *eyes of god*... and thats what really matters, not that I think I am better than you!
+ [You DO think you're better than me!] -> well_clearly_not_at
+ [Just leave...] -> well_i_didn_t
+ [Don't act all high brow after coming here and asking for drugged arrows!] -> well_i_never_so

= the_only_thing_that
The only thing that is gross, is the smell coming from this shop!
+ [If you dont like it, then why are you here!?] -> well_i_didn_t
+ [Well are you here to buy something smelly, or just insult me?] -> uhh_yes_i_suppose
+ [You're gross!] -> well_i_never_so

= the_smell_of_battle
The smell of battle, a musk of bravery and steel!
+ [Doesn't is smell like steel in here?] -> yes_burning_steel_and
+ [That... Kind of sounds lovely.] -> ah_smashing_look_here
+ [But why are you smelling them?] -> because_i_like_the

= well_i_bring_the
Well, I bring the love what I need is an arrow! To prick my loved one with loves arrow as cupid has pricked me!
+ [You want to shoot the person you love?] -> no_well_yes_but
+ [Who is cupid? Is this some love triangle?] -> cupid_the_god_of
+ [So you want some arrows?] -> yes_thank_you_i

= no_well_yes_but
No!... Well yes. But I need you to smith some arrows with a love potion you see. So that when she is shot, she will fall in love with me! Its fool proof!
+ [That is the cutest thing I have ever heard!] -> yes_thank_you_i
+ [Is that safe?] -> where_is_your_passion
+ [Why don't you just make her drink the potion?] -> oh_how_cliche_have

= no_the_competition_is
\*No*! The competition is that she doesn't love me! I need you to smith some arrows with a love potion you see. So that when she is shot, she will fall in love with me! Its fool proof!
+ [That is the cutest thing I have ever heard!] -> yes_thank_you_i
+ [Is that safe?] -> where_is_your_passion
+ [Why don't you just make her drink the potion?] -> oh_how_cliche_have

= thats_between_cupid_and
Thats between cupid and I, I am afraid. But could you help me here at your smithing store?
+ [Uh, Sure, what do you need?] -> well_i_bring_the
+ [I am still not sure you have come to the correct place...] -> that_s_where_you
+ [Whats a cupid?] -> cupid_the_god_of

= well_i_never_so
\*Well I never!* So crude!
-> DONE

= well_it_wasn_t
Well it wasn't a very good joke.
+ [Y-yeah it was a, a bad joke...] -> my_dear_lad_nobody
+ [No the joke isn't finished!] -> ok_finish_the_joke
+ [I change my mind, you are the chicken.] -> well_i_never_so

= well_i_hope_the
Well I hope the *point* is a love arrow that you will sell me?
+ [Yeah sure!] -> deal
+ [I literally make things for killing, why would I have a moral dilemma about this?] -> deal
+ [I have a moral dilemma about this.] -> what_why_please_do

= erm_i_live_in
Erm, *I* live in the castle.
+ [Do you think you are better than me?] -> well_better_is_an
+ [I meant those OTHER castle-livers...] -> yeah_like_gubby
+ [WE DON't SERVE YOUR KIND HERE!] -> well_i_didn_t

= what_why_please_do
What! Why! Please! Do it for love!
+ [Oh ok... Why not!] -> deal
+ [No my moral compass says its wrong!] -> well_i_didn_t
+ [This isn't love, get out of my shop!] -> well_i_didn_t

= well_clearly_not_at
Well clearly not at smithing!
+ [Just leave...] -> well_i_didn_t
+ [Well now youre going to have to find another blacksmith!] -> well_i_didn_t
+ [But in every other way?] -> you_re_much_better

= well_i_didn_t
Well *I* didn't want *your* business anywho! Good morrow good sir!
-> DONE

= uhh_yes_i_suppose
Uhh, yes I suppose I am here to buy something... You see I am not well. Which is why I am here... I have in fact been stabbed!
+ [What! Go to a doctor I can't help!] -> oh_no_what_i
+ [I am afraid I help people get stabbed, not un-stabbed...] -> oh_no_what_i
+ [You don't seem stabbed?...] -> oh_no_what_i

= yes_burning_steel_and
Yes... burning steel... and burning hair...
+ [So are you buying a stinky sword or what?] -> uhh_yes_i_suppose
+ [Well somebody has to do the hard work in this world!] -> umm_yes_thank_you
+ [Psh! You stink! Get Out-a my shop!] -> well_i_didn_t

= because_i_like_the
Because I like the smell?... Is that a trick question?
+ [Thats so creepy...] -> well_i_never_so
+ [Y-yeah ok that makes sense...] -> yes_well_you_see
+ [Listem man, are you going to buy something or just fetishize knights?] -> uhh_yes_i_suppose

= cupid_the_god_of
Cupid?! The god of love! The most important being to our civilization!
+ [That seems like a little of an exaduation...] -> i_will_not_stand
+ [Oh yeah, c-cu-bit love that guy!] -> well_love_is_the
+ [So you want some arrows?] -> yes_thank_you_i

= ok_finish_the_joke
Ok finish the joke then! Why *did* the chicken cross the road?
+ [To get to the other side.] -> my_dear_lad_nobody
+ [Nevermind, its a bad joke.] -> so_are_you_going
+ [To buy some love arrows] -> well_i_never_so

= yeah_like_gubby
Yeah like... *Gubby*
+ [You know Gubby?!] -> umm_no_i_souldn
+ [Gubby Lives in the Castle!?] -> umm_no_i_souldn
+ [Who's Gubby?] -> umm_no_i_souldn

= you_re_much_better
You're much better at, um, being dirty... and... giving me dirty looks
+ [Just leave...] -> well_i_didn_t
+ [At leaast I dont act dirty!] -> well_i_never_so
+ [Isn't that how everybody looks at you?] -> well_i_never_so

= umm_yes_thank_you
Umm, yes thank you for your... Noble sacrifice.
+ [You see! I am a noble!] -> uhh_yes_i_suppose
+ [Youre welcome, what can I help you with!] -> yes_well_you_see
+ [You should act nobally and leave.] -> well_i_didn_t

= i_will_not_stand
I will not stand idly by and have my god and mentor slandered!
-> DONE

= well_love_is_the
Well love is the basic idea, so I suppose you *do* understand.
+ [Yeah, So lets get started on these arrows then!] -> yes_thank_you_i
+ [Na I think love is dumb! Cupid Sucks!] -> i_will_not_stand
+ [Nothing is greater than love!] -> my_dear_lad_nobody

= so_are_you_going
So? Are you going to take my order?
+ [What did you want again?] -> i_need_an_arrow
+ [Lets Do It for love!] -> yes_thank_you_i
+ [Nah... you're creepy] -> well_i_never_so

= umm_no_i_souldn
Umm, no. I souldn't speak of gubby here!... Lets talk about my arrows! Yes My Love Arrows!
+ [Um, sure... Lets get started on the arrows.] -> deal
+ [TELL ME ABOUT GUBBY]
    Hahaha! Oh no... um... would you look at the sun dial. I should be getting back home to um... home! Bye!
    -> DONE
+ [Yeah I'm not sure I'm going to make you those...] -> what_why_please_do

= deal
Some love arrows if you please! #deal
-> DONE

= correct_item
Superb, I will return with news of my feats!
-> DONE

= wrong_item
Oh no, this will not do! This is not made with Love!
-> DONE

// ----------------------------------------------------------------------------
// Scene object: FrillyMan (1)
=== frilly_man_return ===
That did not work... *Sob*. Love is *dead*!
+ [What happened?] -> i_can_t_talk
+ [What do you mean DEAD?!] -> i_can_t_talk
+ [I told you...] -> i_can_t_talk

= i_can_t_talk
I can't talk, *let me mourn!*
-> DONE
