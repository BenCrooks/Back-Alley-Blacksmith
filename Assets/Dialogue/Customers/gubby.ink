// Gubby (four visits) and Gubby's Dad

// True once one of Gubby's visits ended with him getting his stabby. The customers
// list uses it so Gubby stops coming back and his dad turns up instead.
=== function gubby_has_stabby() ===
~ return gubby_1.correct_item or gubby_2.correct_item or gubby_3.correct_item or gubby_4.correct_item

// ----------------------------------------------------------------------------
// Scene object: GUBBY (1)
=== gubby_1 ===
Gubby want *stabby*!
+ [What's a gubby?] -> me_gubby_gubby_need
+ [Ewww, youre drooling on the counter...] -> ptooey
+ [Just give you a stabby? You wont pay?] -> no_pay_only_stabby

= me_gubby_gubby_need
Me Gubby. Gubby Need *stabby*!
+ [Gubby. Me Blacksmith.] -> no_bla_bla_only
+ [Gubby pay?] -> no_pay_only_stabby
+ [What kind of stabby?] -> free_stabby

= ptooey
ptooey
+ [NO! Gubby thats a Bad Gubby!] -> hhhhssstt
+ [Now Gubby gets no stabby.] -> hhhhssstt
+ [Well... At least I don't need to wax the counter any more...] -> me_gubby_gubby_need

= no_pay_only_stabby
No Pay! Only *stabby*!
+ [No Pay, no stabby.] -> no_you_no
+ [Sure, what do you want Gubby?] -> gubby_want_stabby
+ [Get outa here Gubby!] -> hhhhssstt

= no_bla_bla_only
\*no bla bla*! Only stabby!
+ [No bla bla, no stabby.] -> bla
+ [Blablablabla] -> bla
+ [...] -> free_stabby

= free_stabby
Free Stabby!
+ [What? No.] -> no_you_no
+ [Gubby pay.] -> no_pay_only_stabby
+ [Uh sure... A free stabby coming up] -> deal

= hhhhssstt
\*Hhhhssstt!*
-> DONE

= no_you_no
No! You No!
-> DONE

= gubby_want_stabby
Gubby want *stabby*!
+ [One free Stabby coming up!] -> deal
+ [No can do Gubby...] -> hhhhssstt
+ [Gubby give me money!] -> hhhhssstt

= bla
Bla!
-> DONE

= deal
#wants: Copper Dagger, Iron Dagger, Steel Dagger, Damascus Steel Dagger, Copper Sword, Iron Sword, Steel Sword, Damascus Steel Sword
#free
Gubby want Stabby! #deal
-> DONE

= correct_item
wa! WOO! Ya! Gubby!
-> DONE

= wrong_item
BLA! This no stabbey!
-> DONE

// Unused: nothing in the old assets linked to these lines, so they never played.
//   "Gubby good!"
//     [NO! Gubby BAD!]  [Sure... Gubby good.]  [Go away Gubby!]
//   "WAAA! Gubby good!"
//   "Yay! Now Stabby!"
//     [Are you going to Pay?]  [Not this time Gubby...]  [Yeah sure. One free stabby coming up!]

// ----------------------------------------------------------------------------
// Scene object: GUBBY Dad
=== gubby_dad ===
Good day. Hello.
+ [Umm? Gubby?] -> oh_yes_gerald_gubby
+ [Wait? You can talk properly?] -> ummm_yes_that_is
+ [G-Good day.] -> i_was_just_wondering

= oh_yes_gerald_gubby
Oh yes! Gerald Gubby. How did you know my name?
+ [Gerald? You have always just introduced yourself as Gubby!] -> hmmm_you_may_be
+ [Are you not Gubby?] -> hmmm_you_may_be
+ [What? Why can you talk now?] -> hmmm_you_may_be

= ummm_yes_that_is
Ummm, Yes. That is aufully rude to presume I cannot? What made you think otherwise?
+ [You have been here before.] -> hmmm_you_may_be
+ [Yes my mistake, what can I help you with?] -> i_was_just_wondering
+ [I just GAVE YOU a KNIFE!] -> what_no_i_have

= i_was_just_wondering
I was just wondering if you have seen my son, he is wondering around the town with me. He just tured 3, I am so proud of him. He and I look very simmilar. What did you two talk about?
+ [He doesn't really talk] -> oh_yes_thats_my
+ [He wanted a "stabby"] -> what_you_gave_my
+ [Oh, nothing!] -> you_gave_him_a

= hmmm_you_may_be
Hmmm, you may be thinking of my son, he is wondering around the town with me. He just tured 3, I am so proud of him. He and I look very simmilar. What did you two talk about?
+ [He doesn't really talk] -> oh_yes_thats_my
+ [He wanted a "stabby"] -> what_you_gave_my
+ [Oh, nothing!] -> you_gave_him_a

= what_no_i_have
What? No I have never been here before... *WAIT*. Are you talking about my son? Gubby jr.! He and I look *very* simmilar. *DID YOU GIVE HIM A KNIFE?*
+ [No, I gave him a sword.] -> what_you_gave_my
+ [Well he ASKED for a STABBY!] -> what_you_gave_my
+ [No I am thinking of another dude that looked just like you.] -> what_you_gave_my

= oh_yes_thats_my
Oh yes thats my Gubby jr.! What did he want though? You clearly thought I was him.
+ [Umm... nothing?...] -> you_gave_him_a
+ [I gave him a "stabby"] -> what_you_gave_my
+ [He wanted something for free...] -> you_gave_him_a

= what_you_gave_my
\*WHAT?!* You gave my son a *SWORD*? He's 3! he could get himself hurt! What were you thinking giving a sword to a child?!
+ [I didn't know he was a child!] -> i_can_not_believe
+ [He asked for a STABBY!] -> i_can_not_believe
+ [I'm a blacksmith, its what I do...] -> i_can_not_believe

= you_gave_him_a
\*You gave him a weapon! Didnt you?!* You gave my son a *SWORD*? He's 3! he could get himself hurt! What were you thinking giving a sword to a child?!
+ [I didn't know he was a child!] -> i_can_not_believe
+ [He asked for a STABBY!] -> i_can_not_believe
+ [I'm a blacksmith, its what I do...] -> i_can_not_believe

= i_can_not_believe
I can not believe this, ahh! *GUBBY JR.* Where are you?! *Gubby?!*
-> DONE

// Unused: nothing in the old assets linked to these lines, so they never played.
//   "Nothing? What do you sell here? *WEAPONS?!" You didn't give my son a weapon did you?!"
//     [Uhh... no?...]  [Just a small one]  [he asked for a "Stabby"]

// ----------------------------------------------------------------------------
// Scene object: GUBBY (2)
=== gubby_2 ===
Gubby back!
+ [I suppose you want a free knife?] -> gubby_want_stabby
+ [Nooo... Ugghhh Gubby!] -> ahh_you_ahh_give
+ [WHAT DO YOU WANT!?] -> gubby_want_stabby

= gubby_want_stabby
\*GUBBY WANT STABBY*
+ [Will you pay?] -> no_no_pay
+ [No GUBBY!] -> no_where_stabby
+ [FINE! I GIVE UP!] -> deal

= ahh_you_ahh_give
\*Ahh* you *ahh*, give gubby *STABBY*
+ [Will you pay?] -> no_no_pay
+ [No GUBBY!] -> no_where_stabby
+ [FINE! I GIVE UP!] -> deal

= no_no_pay
\*NO*! NO PAY!
+ [No PAY no STABBY!] -> nooooo
+ [Fine, I'll make you a free "stabby"...] -> deal
+ [Leave me alone!] -> gubby_go_but_gubby

= no_where_stabby
\*No!* where stabby?!
+ [NO!] -> nooooo
+ [Stabby no here! Leave!] -> gubby_go_but_gubby
+ [here stabby... let me make you something...] -> deal

= nooooo
\*NOOOOO!*
-> DONE

= gubby_go_but_gubby
Gubby go, but gubby *BE BACK*!
-> DONE

= deal
#wants: Copper Dagger, Iron Dagger, Steel Dagger, Damascus Steel Dagger, Copper Sword, Iron Sword, Steel Sword, Damascus Steel Sword
#free
Gubby want Stabby! #deal
-> DONE

= correct_item
YES! STABBY!
-> DONE

= wrong_item
What this? Gubby want STABBY! No this!
-> DONE

// ----------------------------------------------------------------------------
// Scene object: GUBBY (3)
=== gubby_3 ===
Stabby?
+ [sure... I give up...] -> deal
+ [nope.] -> gubby_will_get_stabby
+ [I'll stab you!] -> yes_you_give_gubby

= gubby_will_get_stabby
Gubby *WILL* get stabby!
-> DONE

= yes_you_give_gubby
Yes! You give gubby stabby!
+ [sure... I give up...] -> deal
+ [NO! THATS NOT WHAT I SAID!] -> gubby_will_get_stabby
+ [NEVER!] -> gubby_will_get_stabby

= deal
#wants: Copper Dagger, Iron Dagger, Steel Dagger, Damascus Steel Dagger, Copper Sword, Iron Sword, Steel Sword, Damascus Steel Sword
#free
Gubby want Stabby! #deal
-> DONE

= correct_item
wa! WOO! Ya! Gubby!
-> DONE

= wrong_item
BLA! This no stabbey!
-> DONE

// ----------------------------------------------------------------------------
// Scene object: GUBBY (4)
=== gubby_4 ===
\*GIVE!*
+ [Give what?] -> stabby
+ [No Gubby!] -> yes_gubby_give_gubby
+ [Will you pay?!] -> free_stabby

= stabby
\*STABBY!*
+ [FINE!] -> deal
+ [What stabby?] -> gubby_4
+ [Say please.] -> plez_now_give_gubby

= yes_gubby_give_gubby
\*Yes* Gubby! Give Gubby stabby!
+ [LEAVE!] -> hsssshhhh_gubby_never_come
+ [Yup ok! I'm broken, you broke me!] -> deal
+ [Sure, I'll give Gubby "Stabby"] -> deal

= free_stabby
\*FREE* Stabby!
+ [Fine...] -> deal
+ [Never!] -> yes_gubby_give_gubby
+ [Give Up Gubby!] -> hsssshhhh_gubby_never_come

= plez_now_give_gubby
\*Plez!* Now give Gubby Stabby!
+ [Thats not what I meant.] -> yes_gubby_give_gubby
+ [Super heartfelt, you deserve a stabby!] -> deal
+ [Yeah... sure] -> deal

= hsssshhhh_gubby_never_come
\*HSSSSHHHH* Gubby NEVER come back!
-> DONE

= deal
#wants: Copper Dagger, Iron Dagger, Steel Dagger, Damascus Steel Dagger, Copper Sword, Iron Sword, Steel Sword, Damascus Steel Sword
#free
Gubby want Stabby! #deal
-> DONE

= correct_item
AH! AHHH! YES! GUBBY YES! STABBY!
-> DONE

= wrong_item
BLA! This no stabbey!
-> DONE
