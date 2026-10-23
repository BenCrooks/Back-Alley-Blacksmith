// Pirate (two visits)

// ----------------------------------------------------------------------------
// Scene object: Pirate
=== pirate ===
Arrreee ye open?
+ [Duh...] -> aye_will_ye_give
+ [Whats wrong with your voice?] -> i_be_dropped_on
+ [Yes I am!] -> aaye_and_i_need

= aye_will_ye_give
Aye, will ye give me one of them small daggers? I will pay thee back later, once the dagger pries out sum teeth
+ [Sure, you seem like a trustworthy person!] -> deal
+ [Aren't you a pirate?] -> then_i_be_not
+ [And youll come back and pay me later?] -> i_pay_thee_hansomly

= i_be_dropped_on
I be dropped on the face as babe. I don't talk like this b'cus I be a pirate!
+ [Are you a pirate?] -> what_be_wrong_with
+ [Is that why you have the eye patch?] -> nay_i_have_this
+ [Oh yes I can see the damage...] -> that_be_rude

= aaye_and_i_need
Aaye! And I need a daggaarr. I will pay ye back!
+ [Sure you seem like a trustworthy person!] -> deal
+ [How much will you pay?] -> a_mouthful
+ [There is no way I am giving you anything!] -> ya_filthy_land_lover

= then_i_be_not
Then I be *not* a pirate! I be a normal land faring folk!
+ [Shuuuurree... Are you going to pay?] -> i_pay_thee_hansomly
+ [Then why do you have that accent?] -> i_be_dropped_on
+ [Sure, that seems legit!] -> aaye_and_i_need

= i_pay_thee_hansomly
I pay thee hansomly upon me return. That dagger need do me work before I pay thee in teeth?
+ [Are you just going to kill somebody?] -> it_be_pretty_obvious
+ [What are you going to use the dagger for exactly?] -> it_be_pretty_obvious
+ [I don't trust you to come back and pay me.] -> ya_filthy_land_lover

= what_be_wrong_with
What be wrong with being a pirate?
+ [Pirates aren't trustworthy.] -> then_i_be_not
+ [Well shouldn't you already have a dagger?] -> naye_i_lost_my
+ [N-nothing. Please dont rob me.] -> i_wont_rob_ye

= nay_i_have_this
Nay, I have this eye patch because I be a pir-. I mean I be a regualaarr folk
+ [Are you a pirate?] -> what_be_wrong_with
+ [I'm a regular man, I dont have an eye patch] -> nayyee_naahhheee_ok_i
+ [What?] -> aaye_and_i_need

= that_be_rude
That be rude!
+ [Well I am only rude to liars] -> why_ye_not_trust
+ [Oh! were you born like that?] -> ya_filthy_land_lover
+ [Sorry, What would you like?] -> aye_will_ye_give

= a_mouthful
\*A mouthful!*
+ [Wow! Thats alot of cavities! Its a deal!] -> deal
+ [I still don't trust you. Get outa here!] -> ya_filthy_land_lover
+ [Sure, one dagger coming up!] -> deal

= ya_filthy_land_lover
Ya filthy *land lover*, I be back once I find a blade!
-> DONE

= it_be_pretty_obvious
It be pretty obvious. What be a dagger for?
+ [I'm not comfortable with you murdering!] -> well_why_ye_make
+ [Yeah I guess thats what daggers are for...] -> so_ye_give_me
+ [Opening letters?] -> what_be_a_letter

= naye_i_lost_my
Naye I lost my dear blade bessy when I stabbed a man and he ran off.
+ [Well you don't seem very good at killing people.] -> i_would_a_caught
+ [I'm sorry, where you and bessy close?] -> as_close_as_a
+ [Why didn't you chase hime?] -> why_ye_not_trust

= i_wont_rob_ye
I wont rob ye! Ye have a dagger and aye don't... And where would I get weapons if I robbed ye?
+ [So if I game you a dagger you would rob me?] -> naye_think_of_it
+ [Well if you robbed me, you would have a weapon...]
    Well... er, no wait... I... I need some time to ponder this...
    -> DONE
+ [Sure... Makes sense...] -> so_ye_give_me

= nayyee_naahhheee_ok_i
Nayyee, naahhheee... Ok I am a pirate... Don't sae anything though.
+ [Sorry I don't do business with pirates, and thieves!] -> ya_filthy_land_lover
+ [I appreciate your honesty!] -> so_ye_give_me
+ [How can I trust a pirate?] -> well_why_ye_make

= why_ye_not_trust
Why ye not trust me? A pir-ahh... A *man* is only as good as his word.
+ [Were you going to say pirate?] -> nay_ey_just_had
+ [Would you describe yourself as a good person then?] -> aye_i_be_good
+ [Thats true, lets get you that dagger!] -> deal

= well_why_ye_make
Well why ye make weapons then!? *Skallywag*!
-> DONE

= so_ye_give_me
So ye give me a dagger?
+ [Yeah sure!] -> deal
+ [I guess so!] -> deal
+ [Aint no way!] -> ya_filthy_land_lover

= what_be_a_letter
What be a letter? Aaare you giving me a dagger or no?
+ [A letter? Like a map with words on.] -> ahh_and_this_let
+ [No, I don't trust you to pay me back!] -> why_ye_not_trust
+ [Yeah sure, I need to learn to trust people more!] -> deal

= i_would_a_caught
I would'a caught him if it werent for the ol' peg leg!
+ [You have a peg leg?] -> eye_have_two_but
+ [Sure. How do you plan to kill the next one?] -> with_a_dagger_be
+ [Are you sure youre not a pirate?] -> why_ye_not_trust

= as_close_as_a
As close as a pirate can be with a dagger...
+ [So you are a pirate!?] -> nayyee_naahhheee_ok_i
+ [I knew it! We dont serve Pirates here!] -> ya_filthy_land_lover
+ [Well lets get you a new one!... Matey] -> deal

= naye_think_of_it
Naye, think of it as client - pirate privilege.
+ [So you are a pirate!?] -> nayyee_naahhheee_ok_i
+ [Am.. I the client in this scenario?] -> aye_client_of_not
+ [I think I will skip on the "privilege" then] -> ya_filthy_land_lover

= nay_ey_just_had
Nay, ey just had a hiccup that be all!
+ [Listen I will give you a dagger if you admit you are a pirate!] -> nayyee_naahhheee_ok_i
+ [Do you want me to give you a fright?] -> why_would_eye_want
+ [Sure...] -> so_ye_give_me

= aye_i_be_good
Aye, I be good! And good at killi'n
+ [That's like an oxymoron?]
    Who ye calli'n a *Moron!*
    -> DONE
+ [Then I'll get you a dagger and you can pay me back later!] -> deal
+ [But you're lying!] -> so_ye_give_me

= ahh_and_this_let
Ahh, and this let-ter takes ye to treasure? I be using daggers this whole time te get treasure!
+ [Well whatever works I suppose.] -> so_ye_give_me
+ [A letter doesn't get you treasure.] -> what_be_the_point
+ [So you DO have a dagger!?] -> naye_i_lost_my

= eye_have_two_but
Eye have two! But it be the old one that held me up!
+ [How do your even walk?] -> with_me_peg_legs
+ [How do you plan on killing the next person?!] -> with_a_dagger_be
+ [Wow, you really are a pirate...] -> nayyee_naahhheee_ok_i

= with_a_dagger_be
With a dagger. Be ye listening?!
+ [Umm, sure...] -> so_ye_give_me
+ [You just sound like a bad investment all round.] -> ya_filthy_land_lover
+ [Fine, I give in. I'll get you a dagger!] -> deal

= aye_client_of_not
Aye, client of not being robbed! So hows about that dagger on loan.
+ [I will give it to you, but you must promise not to rob me!] -> i_cross_me_aarrt
+ [Yeah sure... on "loan"] -> deal
+ [If I don't get my money, I'm sending a hitman after you!] -> so_ye_give_me

= why_would_eye_want
Why would eye want that?
+ [Yeah its a dumb idea...] -> so_ye_give_me
+ [Frights cure hicc- BOO!] -> ya_filthy_land_lover
+ [I thought pirates likes scarey things.] -> we_do_not

= what_be_the_point
What be the point then! Keep ye letters and give me a daggarrr!
+ [Ain't no way!] -> ya_filthy_land_lover
+ [Are you sure you arent a pirate?] -> why_ye_not_trust
+ [Sure, one dagger coming up!] -> deal

= with_me_peg_legs
With me peg legs! Be ye listening!
+ [You just sound like a bad investment all round.] -> ya_filthy_land_lover
+ [That doesnt sound like "walking" to me] -> ya_filthy_land_lover
+ [It sound like you need a break...] -> so_ye_give_me

= i_cross_me_aarrt
I cross me aarrt!
+ [Ok heres your dagger.] -> deal
+ [Not good enough!] -> ya_filthy_land_lover
+ [Ok, I will expect you to return soon!] -> deal

= we_do_not
We do not!
+ [So you are a pirate!?] -> nayyee_naahhheee_ok_i
+ [Who is we? pirates?] -> nayyee_naahhheee_ok_i
+ [Yeah I dont like it either.] -> so_ye_give_me

= deal
#wants: Copper Dagger, Iron Dagger, Steel Dagger, Damascus Steel Dagger
#free
// No line here yet: the old setup left this customer's goal blank.
#deal
-> DONE

= correct_item
Ye arreee the best!
-> DONE

= wrong_item
Arree you crazy? I cant use this!
-> DONE

// ----------------------------------------------------------------------------
// Scene object: Pirate Return
=== pirate_return ===
\*Daggarr for sale!* Daggarr! Oh hi! Daggarr for sale?
+ [What! I just gave you that dagger!?] -> aye_you_gave_it
+ [How much is it?] -> it_be_20_teeth
+ [Pirate! Thief!] -> aye_you_gave_it

= aye_you_gave_it
Aye you gave it ter me, I believe dis mi prop-arrr-ty now!
+ [You said you would pay me back?] -> what_it_look_like
+ [I thought you were going to kill somebody with it?] -> i_try_ter_kill
+ [Where are my teeth!?] -> what_it_look_like

= it_be_20_teeth
It be 20 teeth
+ [20!? I gave it to you for free!] -> ye_be_bad_at
+ [Why would I pay 20 teeth, when I can make it here.] -> support_yer_local_businesses
+ [Where is MY cut?!] -> ye_cut_is_that

= what_it_look_like
What it look like I be doing? I be selling it to get ye yer money.
+ [But you're stealing my business!] -> i_did_not_steal
+ [I thought you were going to murder with it.] -> i_try_ter_kill
+ [But I wont buy it!] -> support_yer_local_businesses

= i_try_ter_kill
I try ter kill me but eye got two peg legs. I couldn't catch em!
+ [I knew this would happen!] -> if_ye_could_tell
+ [Just give the knife back!] -> naye_this_be_my
+ [Why did you want the dagger then?!] -> i_like_daggarrrs_what

= ye_be_bad_at
Ye be bad at business. Buy if for 20 or I stab ye!
+ [No Please! Don't!] -> aye_i_wont_stab
+ [I guess thats a good reason to buy it...] -> it_be_30_teeth
+ [No! Get outa here!] -> if_eye_could_get

= support_yer_local_businesses
Support yer local businesses. I be selling this here fine dagger, it be better than anything made in all these here lands.
+ [I made that!] -> it_not_be_from
+ [I am the local business. Get Outa here!] -> if_eye_could_get
+ [Where is it from then?] -> it_not_be_from

= ye_cut_is_that
Ye cut is that I will cut ye if you don't buy it!
+ [No Please! Don't!] -> aye_i_wont_stab
+ [I guess thats a good reason to buy it...] -> it_be_30_teeth
+ [No! Get outa here!] -> if_eye_could_get

= i_did_not_steal
I *Did not* steal *nothing*! You take that back! You gave me this dagger!
+ [It's my job to sell daggers!] -> ye_don_t_sell
+ [Stealing the people who buy the daggers!] -> i_ain_t_no
+ [Just give the dagger back!] -> naye_this_be_my

= if_ye_could_tell
If ye could tell the futarrre, why ye give me the knife?!
+ [I like trusting people.] -> it_not_be_from
+ [Uhhh... good point...] -> it_be_20_teeth
+ [Just give it back!] -> naye_this_be_my

= naye_this_be_my
Naye this be my daggarr! If ye try take it, *I'll stab ye!*
-> DONE

= i_like_daggarrrs_what
I like daggarrrs. What be wrong with that!?
+ [But youre selling it now?] -> it_be_20_teeth
+ [Nothing... Will I still get my cut?] -> ye_cut_is_that
+ [But thats my Dagger!] -> naye_this_be_my

= aye_i_wont_stab
Aye I wont stab ye. I wont stab a cowARRrd, ye be a cowARRd at fightin and a cowARRrd at sellin!
-> DONE

= it_be_30_teeth
It be *30* teeth now. Ehhh naye, *100*. Nay, mi dagger: Bessy 2! I will never sell thee!
-> DONE

= if_eye_could_get
If eye could get over this countarr ye'd be *dead!*
-> DONE

= it_not_be_from
It not be from here, *SHUT UP*
-> DONE

= ye_don_t_sell
Ye don't sell daggers very well... Eye got this one for free!
+ [You still need to pay!] -> support_yer_local_businesses
+ [Just give it back!] -> naye_this_be_my
+ [Y-yeah... I guess thats true...] -> it_be_20_teeth

= i_ain_t_no
I ain't no slaver! *I'll kill ye if you say that again!*
+ [Slaver.] -> if_eye_could_get
+ [Nevermind...] -> it_be_20_teeth
+ [Give the knife back!] -> naye_this_be_my
