// Barrel Hag

// ----------------------------------------------------------------------------
// Scene object: BarrelHag
=== barrel_hag ===
\*Hello*
+ [wow, thats loud!] -> what
+ [h-hi?] -> what
+ [HELLO!] -> finally_somebody_who_speaks

= what
. . . *What?*
+ [nevermind...]
    TODO: This option led nowhere in the old assets (picking it froze the game). For now the customer just leaves.
    -> DONE
+ [I SAID HELLO!] -> finally_somebody_who_speaks
+ [YOU ARE LOUD!] -> no_everybody_else_is

= finally_somebody_who_speaks
\*Finally somebody who speaks at a normal volume!*
+ [COULD YOU SPEAK UP A LITTLE?] -> is_this_better_listen
+ [IF YOU CAN'T QUIETEN DOWN YOU WILL HAVE TO LEAVE!] -> what_2
+ [WHAT DO YOU NEED?!] -> i_need_a_sword

= no_everybody_else_is
\*No! Everybody else is just quiet!*
+ [COULD YOU SPEAK UP A LITTLE?] -> is_this_better_listen
+ [IF YOU CAN'T QUIETEN DOWN YOU WILL HAVE TO LEAVE!] -> what_2
+ [WHAT DO YOU NEED?!] -> i_need_a_sword

= is_this_better_listen
\*IS THIS BETTER? LISTEN I NEED A SWORD! I AM STUCK IN THIS BARREL!*
+ [AND THE SWORD WILL SMASH IT?] -> no_i_m_going
+ [WHATS THE SWORD FOR?] -> no_i_m_going
+ [ARE YOU GOING TO CUT THE BARREL UP?] -> no_i_m_going

= what_2
\*WHAT?!*
-> DONE

= i_need_a_sword
\*I need a sword, I'm stuck in this barrel*
+ [AND THE SWORD WILL SMASH IT?] -> no_i_m_going
+ [WHATS THE SWORD FOR?] -> no_i_m_going
+ [ARE YOU GOING TO CUT THE BARREL UP?] -> no_i_m_going

= no_i_m_going
\*No, I'm going to break the barrel with the sword!*
+ [OK ONE SWORD COMING UP!] -> deal
+ [THAT DOESN'T SEEM SAFE!] -> i_have_done_it
+ [WHATS WRONG WITH BEING IN A BARREL?] -> nothing_i_just_found

= i_have_done_it
\*I have done it a million times*
+ [OK ONE SWORD COMING UP!] -> deal
+ [I CAN'T LET YOU HURT YOURSELF!] -> if_i_have_to
+ [PLEASE DONT DO THIS!] -> yes_one_sword_please

= nothing_i_just_found
\*Nothing! I just found a better barrel*
+ [OK ONE SWORD COMING UP!] -> deal
+ [Uhhh... OK!] -> deal
+ [FASSION IS IMPORTANT I GUESS] -> if_i_have_to

= if_i_have_to
\*If I have to explain the perks of wearing a barrel to you, you aren't living your life right!*
+ [huh.. I GUESS I'M NOT LIVING RIGHT!] -> deal
+ [Uhhh... OK!] -> deal
+ [YOU'RE CRAZY!] -> yes_one_sword_please

= yes_one_sword_please
\*YES ONE SWORD PLEASE*
+ [ONE SWORD COMING UP!] -> deal
+ [Uhhh... OK!] -> deal
+ [NO WAYS CRAZY LADY!] -> what_2

= deal
\*SWORD!* #deal
-> DONE

= correct_item
\*AH! WHAT?! YES!*
-> DONE

= wrong_item
\*EWW! WHAT?! NO!*
-> DONE
