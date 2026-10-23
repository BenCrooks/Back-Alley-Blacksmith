// Wizard

// ----------------------------------------------------------------------------
// Scene object: Wizzard
=== wizard ===
And he appeared in a puff of smoke!
+ [What?] -> i_am_narrating_this
+ [Who did?] -> i_am_narrating_this
+ [I didnt see any smoke...] -> i_am_narrating_this

= i_am_narrating_this
I am narrating. This is what you tell people if they ask about me... He shoots sparkels from his fingers!
+ [I still don't understand] -> if_people_come_here
+ [Why don't you just do these things, you are clearly a wizard...] -> well_because_i_am
+ [What Sparks... What?!] -> if_people_come_here

= if_people_come_here
If people come here and are like; "*WOW* you met star-sprinkler?!" thats me, you have to act like all these fantasic things happened!
+ [I am NOT going to do that!] -> ahh_ok_but_i
+ [Why don't you make these things happen if you're so great!?] -> well_because_i_am
+ [IGNORES THE CRAZY GUY] -> no_wait_i_am

= well_because_i_am
Well... Because I am not as great as it seems. *I have been stripped of my magic!*
+ [Oh no, how does that happen?] -> i_broke_the_wizzards
+ [Well I liked the magic you did when you walked in!] -> no_it_was_bad
+ [So you're just a guy in a whacky outfit?] -> yeeesss_a_disgusting_regular

= ahh_ok_but_i
Ahh, ok! but I need you to do one thing for me! *Pity me!*
+ [Way ahead of you!] -> thank_you_but_i
+ [What, why?] -> well_because_i_am
+ [I will never do that!] -> thank_you_but_i

= no_wait_i_am
\*No* wait! I am not crazy! I have just reciently *lost my magic!*
+ [Oh no, how does that happen?] -> i_broke_the_wizzards
+ [Well I liked the magic you did when you walked in!] -> no_it_was_bad
+ [So you're just a guy in a whacky outfit?] -> yeeesss_a_disgusting_regular

= i_broke_the_wizzards
I broke the wizzards code! The hypocritical oath!
+ [I don't think thats what its called...] -> i_will_never_be
+ [Oh no...] -> i_will_never_be
+ [So dramatic.] -> i_will_never_be

= no_it_was_bad
\*no* it was *bad!*
+ [Whats going on?...] -> i_broke_the_wizzards
+ [I mean it didn't even technically exist.] -> i_broke_the_wizzards
+ [It was invisible!] -> i_broke_the_wizzards

= yeeesss_a_disgusting_regular
YEEESSS! A disgusting regular human!
+ [Woah, slow down there...] -> a_disgusting_oath_breaker
+ [How did this happen?!] -> i_broke_the_wizzards
+ [That, we can agree on!] -> a_disgusting_oath_breaker

= thank_you_but_i
Thank you! But I deserve this! I broke the wizzards code! The hypocritical oath!
+ [I don't think thats what its called...] -> i_will_never_be
+ [Oh no...] -> i_will_never_be
+ [So dramatic.] -> i_will_never_be

= i_will_never_be
I will *never* be able to do magic again! What would daddy say!
+ [Its ok! Being a regular dude isn't so bad.] -> it_sucks_i_am
+ [What would daddy say?] -> he_d_say_boy
+ [Guy... Why are you here?] -> i_am_only_here

= a_disgusting_oath_breaker
A disgusting oath breaker with no magic!
+ [It seemed like you didnt deserve it!] -> i_will_never_be
+ [Stop acting like a baby!] -> i_will_never_be
+ [Can;t you get it back?] -> i_will_never_be

= it_sucks_i_am
It *SUCKS*! I am only here to pretend like I will have magic again!
+ [How does that work?] -> well_i_got_this
+ [We don't sell magic here.] -> i_know_but_i
+ [That's just sad...] -> i_know_but_i

= he_d_say_boy
He'd say: "BOY go get yourself some magic and stop complaining!". So I am here to get myself some magic...
+ [How does that work?] -> well_i_got_this
+ [We don't sell magic here.] -> i_know_but_i
+ [Your dad sucks....] -> i_know_but_i

= i_am_only_here
I am only here to pretend like I will have magic again!
+ [How does that work?] -> well_i_got_this
+ [We don't sell magic here.] -> i_know_but_i
+ [That's just sad...] -> i_know_but_i

= well_i_got_this
Well, I got this magic powder, I need you to add it to some arrows. So I can shoot magic agin! I am sure nobody will notice!
+ [Isn't that still magic?] -> kinda_but_it_isn
+ [I think people will notice] -> i_know_but_here
+ [Enough said! I am Your man!] -> deal

= i_know_but_i
I *Know*, but I got this magic powder, I need you to add it to some arrows. So I can shoot magic agin! I am sure nobody will notice!
+ [Isn't that still magic?] -> kinda_but_it_isn
+ [I think people will notice] -> i_know_but_here
+ [Enough said! I am Your man!] -> deal

= kinda_but_it_isn
Kinda... But it isn't *MY* magic! Ahh I am pathetic!
+ [Magic is magic, and you know how to use it!] -> i_am_only_here
+ [You are pretty pathetic...] -> i_know_but_here
+ [Whever you are, youre going to have some pretty sweet arrows!] -> deal

= i_know_but_here
\*I KNOW!* but here I am. Will you sell me some magic arrows?
+ [Of course!] -> deal
+ [I'm not wasting my time on some fake.]
    You're right, I guess I'll hang up the robe and become an normal man!
    -> DONE
+ [Lets get you that magic!] -> deal

= deal
#wants: Copper Arrows, Iron Arrows, Steel Arrows, Damascus Steel Arrows
#must_be: Magic
#gives: Magic Powder
One set of magic embewed arrow! #deal
-> DONE

= correct_item
Yes! I am magic again!
-> DONE

= wrong_item
This isn't what I wanted!
-> DONE
