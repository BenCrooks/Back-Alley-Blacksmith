// Back-Alley Blacksmith: who comes into the shop, what they say and what they want.
//
// How the game uses this story
// ----------------------------
// "customers" (below) is the order people come in. Each name is a knot, played by
// the customer in the scene (a DialogueHolder under CharacterManager) whose
// "Ink Knot" field matches it:
//
//   * Each line is a speech bubble; the choices under it become the response
//     buttons (three buttons, so three choices at most).
//   * Wrap words in *stars* to make them bold and red. At the very start of a line
//     write \* instead, or ink will read the line as a choice.
//   * "-> deal" means the customer agreed to buy something. Their "= deal" line
//     says what they want, and tags on it set up the sale:
//         #wants: Iron Sword, Steel Sword   the items they'll accept
//         #must_be: Magic                   the item's adjective must include this
//         #gives: Magic Powder              items they hand over to craft with
//         #free                             they won't pay for it
//         #deal                             starts the crafting part of the visit
//     Items are the assets in Assets/SmithingScriptableObjs, by name or noun.
//   * Ending any other way ("-> DONE") means they leave without buying anything.
//   * #game_over ends the day: the customer stays and nobody else comes in.
//
// After the player hands an item over, the game plays "= correct_item" or
// "= wrong_item" from the same knot as the customer's reaction.
//
// In Unity, Tools > Dialogue > Check Dialogue plays every branch and checks the
// item names, knot names and button counts.

INCLUDE Customers/skinny_lady.ink
INCLUDE Customers/strong_man.ink
INCLUDE Customers/gubby.ink
INCLUDE Customers/frilly_man.ink
INCLUDE Customers/goop.ink
INCLUDE Customers/sexy_boi.ink
INCLUDE Customers/giant.ink
INCLUDE Customers/pirate.ink
INCLUDE Customers/wizard.ink
INCLUDE Customers/barrel_hag.ink
INCLUDE Customers/wide_lady.ink

// Press Play in Inky to try any conversation. The game never runs this part:
// it jumps straight to each customer's knot.
-> playtest

// The order customers come into the shop. The game reads the next name whenever the
// counter is free, so each condition is checked only after everyone above it has been
// served. "{pirate.correct_item: ...}" is true once the pirate got the right item.
=== customers ===
skinny_lady
strong_man_1
gubby_1
{gubby_1.correct_item: gubby_dad}
frilly_man
goop
{frilly_man.correct_item: frilly_man_return}
strong_man_2
sexy_boi
{not gubby_has_stabby(): gubby_2}
{gubby_2.correct_item: gubby_dad}
giant
strong_man_3
pirate
wizard
{not gubby_has_stabby(): gubby_3}
{gubby_3.correct_item: gubby_dad}
{pirate.correct_item: pirate_return}
{not goop.correct_item: goop}
barrel_hag
strong_man_4
{not gubby_has_stabby(): gubby_4}
{gubby_4.correct_item: gubby_dad}
wide_lady
-> DONE

=== playtest ===
Who's at the counter?
+ [Skinny Lady] -> skinny_lady
+ [Strong Man, 1st visit] -> strong_man_1
+ [Gubby, 1st visit] -> gubby_1
+ [Gubby's Dad] -> gubby_dad
+ [Frilly Man] -> frilly_man
+ [Goop] -> goop
+ [Frilly Man returns] -> frilly_man_return
+ [Strong Man, 2nd visit] -> strong_man_2
+ [Sexy Boi] -> sexy_boi
+ [Gubby, 2nd visit] -> gubby_2
+ [Giant] -> giant
+ [Strong Man, 3rd visit] -> strong_man_3
+ [Pirate] -> pirate
+ [Wizard] -> wizard
+ [Gubby, 3rd visit] -> gubby_3
+ [Pirate returns] -> pirate_return
+ [Barrel Hag] -> barrel_hag
+ [Strong Man, 4th visit] -> strong_man_4
+ [Gubby, 4th visit] -> gubby_4
+ [Wide Lady (end of game)] -> wide_lady
