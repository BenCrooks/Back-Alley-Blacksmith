// Goop

// ----------------------------------------------------------------------------
// Scene objects: Goop, Goop (1)
// Goop: in the scene, a visit without a sale turns on Goop (1).
=== goop ===
...
+ [Can I help you?] -> silence
+ [What can I get you?] -> silence
+ [...] -> silence

= silence
...
+ [Uhh... please leave...]
    ...
    -> DONE
+ [I'm sure we have something you'll like!] -> deal
+ [Let me just pick something for you!] -> deal

= deal
? #deal
-> DONE

= correct_item
...! <3
-> DONE

= wrong_item
. . . :( . . .
-> DONE
