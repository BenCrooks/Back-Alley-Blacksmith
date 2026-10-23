// Back-Alley Blacksmith: what the customers say.
//
// How the game uses this story
// ----------------------------
// Each customer in the scene (a DialogueHolder under CharacterManager) names a knot
// in its "Ink Knot" field. When they reach the counter the game jumps to that knot:
//
//   * Each line is a speech bubble; the choices under it become the response
//     buttons (three buttons, so three choices at most).
//   * Wrap words in *stars* to make them bold and red. At the very start of a line
//     write \* instead, or ink will read the line as a choice.
//   * "-> deal" means the customer got what they asked for. Their "= deal" stitch
//     says what they want; its #deal tag hands over the starting items and opens
//     the crafting part of the visit.
//   * Ending any other way ("-> DONE") means they leave without buying anything.
//   * #game_over stops the customer queue (used by the very last customer).
//
// After the player hands an item over, the game plays "= correct_item" or
// "= wrong_item" from the same knot as the customer's reaction.
//
// Which items each customer accepts, whether they pay, and who visits in what
// order (and who comes back) are still set on the customers in the scene.

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
