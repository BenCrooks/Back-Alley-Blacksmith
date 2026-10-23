// Skinny Lady

// ----------------------------------------------------------------------------
// Scene object: SkinnyLady
=== skinny_lady ===
Behold me in all my radience, the *Brave*, the *Bold*, the *Buff* Betty Brutus, heroin of Scum city!
+ [Ah wow! Amazing to meet you in person!] -> yes_i_am_radient
+ [Where is scum city?] -> this_is_scum_city
+ [You don't look like a heroin...] -> do_you_not_recognise

= yes_i_am_radient
Yes, I AM *Radient*! Do you like my armour?
+ [Yes it's huge!] -> i_know_magnificent_ahh
+ [It doesn't quite fit you...] -> ahh_who_am_i
+ [When you defeated that dragon! AHH!] -> i_know_magnificent_ahh

= this_is_scum_city
\*This* is scum city! You don't know where you live?
+ [Why is it called that?] -> i_suppose_the_scum
+ [Who called it that?] -> i_suppose_the_scum
+ [I don't really leave this shop.] -> oh_well_lucky_you

= do_you_not_recognise
Do you not recognise me!?... Well I have perhaps lost a little wieght these last couple months...
+ [Uhh, yeah I can see!] -> ass_but_you_are
+ [Losing some wieght is nice...] -> not_when_you_are
+ [No I have no idea who you are.] -> i_m_betty_brutus

= i_know_magnificent_ahh
I know... Magnificent... *Ahh* who am I kidding! I am *wasting away!*
+ [I wasn't going to say anything.] -> you_re_sweet_but
+ [You do look a little skinny...] -> ass_but_you_are
+ [Sometimes losing some wieght is nice...] -> not_when_you_are

= ahh_who_am_i
\*Ahh* who am I kidding! I am *wasting away!*
+ [I wasn't going to say anything.] -> you_re_sweet_but
+ [You do look a little skinny...] -> ass_but_you_are
+ [Sometimes losing some wieght is nice...] -> not_when_you_are

= i_suppose_the_scum
I suppose the *SCUM* of the city called it that! But that *SCUM* will soon be cleared out! Now that I am in town again... *AHH* who am I kidding! I am *Wasting away!*
+ [I wasn't going to say anything.] -> you_re_sweet_but
+ [You do look a little skinny...] -> ass_but_you_are
+ [Sometimes losing some wieght is nice...] -> not_when_you_are

= oh_well_lucky_you
Oh! well lucky you. There are some dangerous characters out there!
+ [And who are you again?] -> i_m_betty_brutus
+ [Aren't you supposed to protect us?] -> you_re_sweet_but
+ [How do I know you aren't a dangerous character?] -> i_m_betty_brutus

= ass_but_you_are
\*ASS!* But you are right! How am I supposed to fight crime like this!? I can't even lift a sword!
+ [Do YOU have to protect the city?] -> well_who_else_is
+ [Well you don't need a sword!] -> w_what_do_you
+ [Why don't you use another weapon?] -> w_what_do_you

= not_when_you_are
Not when you are *Betty Brutis*! I am supposed to be BUFF! Now I can't even swing a sword! How will *I* protect this city now?
+ [Why don't you use another weapon?] -> w_what_do_you
+ [Do YOU have to protect the city?] -> well_who_else_is
+ [Well you don't need a sword!] -> w_what_do_you

= i_m_betty_brutus
I'm Betty Brutus... heroin of Scum city...? I did the whole intro. You have never heard of me? *Ahh* who am I kidding! I am *wasting away!*
+ [You do look a little skinny...] -> ass_but_you_are
+ [Uhh, o-oh yeah I think you sound fammiliar?...] -> yes_i_am_radient
+ [It doesn't matter who you are. What do you need?] -> w_what_do_you

= you_re_sweet_but
You're sweet, but; How am I supposed to fight crime like this!? I can't even lift a sword!
+ [Do YOU have to protect the city?] -> well_who_else_is
+ [Well you don't need a sword!] -> w_what_do_you
+ [Why don't you use another weapon?] -> w_what_do_you

= well_who_else_is
Well *who else* is going to?! *No!* you can do this Betty! I am going to need a new weapon! Somthing lighter than a sword!
+ [I could make you a dagger.] -> a_dagger_brilliant_idea
+ [I could make you some arrows.] -> hmm_no_a_dagger
+ [I could make you a sword with a lighter metal?] -> hmm_no_a_dagger

= w_what_do_you
W-What do you mean? I need *Something* to fight with!
+ [Why don't you use a dagger?] -> a_dagger_brilliant_idea
+ [I could make you a sword with some lighter material.] -> hmm_no_a_dagger
+ [I could make you some arrows.] -> hmm_no_a_dagger

= a_dagger_brilliant_idea
A dagger! Brilliant idea! I'll need to be the best though! Here, I have some damascus steel, smelt it and make me a dagger!
+ [One damascus dagger coming up!] -> deal
+ [We will have you out there fighting crime in no time!] -> deal
+ [A dagger suits you!] -> deal

= hmm_no_a_dagger
Hmm, no... A dagger! Yes! I'll need to be the best though! Here, I have some damascus steel, smelt it and make me a dagger!
+ [One damascus dagger coming up!] -> deal
+ [We will have you out there fighting crime in no time!] -> deal
+ [A dagger suits you!] -> deal

= deal
#wants: Damascus Steel Dagger
#gives: Damascus Steel Ingot
A damascus dagger! Nothing but the best! #deal
-> DONE

= correct_item
Marvelous! Those scum wont stand a chance!
-> DONE

= wrong_item
No! Not this. I couldn't possibly use THIS to fight!
-> DONE
