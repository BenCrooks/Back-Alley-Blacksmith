Unity project (6000.4) for a back-alley smithy: customers come up to the counter, you talk them into a deal, then craft what they asked for and hand it over.

It used to have just about the worst narrative system ever coded (100000000 scriptable objs RIP). The dialogue is now written in [ink](https://www.inklestudios.com/ink/), using inkle's [Unity integration](https://github.com/inkle/ink-unity-integration).

## Dialogue

- `Assets/Dialogue/BackAlleyBlacksmith.ink` is the main story. Its header explains how the game uses it, and its `customers` list decides who comes in and in what order, including return visits.
- `Assets/Dialogue/Customers/` has one file per character.
- Each customer's `= deal` stitch sets up the sale with tags: `#wants`, `#must_be`, `#gives` and `#free`.
- Open the main story in [Inky](https://github.com/inkle/inky) and press Play to try any customer's conversation.
- In Unity, **Tools > Dialogue > Check Dialogue** plays every branch and checks item names, knot names and button counts.
