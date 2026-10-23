// Sexy Boi

// ----------------------------------------------------------------------------
// Scene object: SexyBoi
=== sexy_boi ===
Ughmmm, I'um lookn fur something...like...sexy...
+ [I don't think you are at the right shop...] -> oh_hahaha_you_uggree
+ [A sexy weapon?] -> uhhh_yeah_like_sexy
+ [Please don't talk about me that way...] -> listen_se_xy

= oh_hahaha_you_uggree
Oh hahaha, you'uggree like funny. No I need a sexy weapon...
+ [I still don't think you are at the right shop...] -> no_i_am_here
+ [A sexy weapon?] -> uhhh_yeah_like_sexy
+ [Well I can get you my best weapon] -> listen_se_xy_ugghhh

= uhhh_yeah_like_sexy
Uhhh, yeah like sexy. When people look at me I want them to think... like... Uugghhhh... you know?
+ [Yeah sure! So like the best weapon?] -> listen_se_xy_ugghhh
+ [Ugh?] -> don_t_ugghh_at
+ [Something pretty?] -> listen_se_xy_ugghhh

= listen_se_xy
Listen! Se-xy!
+ [Uh ok a sexy weapon coming up!] -> deal
+ [Copper is pretty sexy?] -> copper_is_not_sexy
+ [Im not listening to you, get out-ugh-here!] -> um_dont_tell_me

= no_i_am_here
No I am here. Ugghh
+ [So like a stong weapon?] -> listen_se_xy_ugghhh
+ [So like a shiny weapon?] -> listen_se_xy_ugghhh
+ [Ugh! You Ugh!] -> um_dont_tell_me

= listen_se_xy_ugghhh
Listen! Se-xy-Ugghhh
+ [Uh ok a sexy weapon!] -> damn_right_give_me
+ [Copper is pretty sexy?] -> listen_se_xy
+ [Im not listening to you, get out-ugh-here!] -> um_dont_tell_me

= don_t_ugghh_at
Don't Ugghh at me, you're making it un-sexy!
+ [UGGHHHH!] -> um_dont_tell_me
+ [Sorry. What did you want me to make?] -> ugghh_i_need_a
+ [Am I not sexy?] -> don_t_make_me

= copper_is_not_sexy
Copper is not sexy! Eww-ugghh. Give me the layer-ugghh-ed one
+ [Sure one sexy weapon coming up!] -> deal
+ [You mean Damascus?] -> dont_name_it_that
+ [Any weapon?] -> yeea_ugghh_like_whatever

= um_dont_tell_me
Um! Dont tell me whats *Ugh*, I'm outa here! *Ugh*
-> DONE

= damn_right_give_me
Damn right! give me-ugghh one of those layered metal guys! That's so sexy!
+ [Sure one sexy weapon coming up!] -> deal
+ [You mean Damascus?] -> dont_name_it_that
+ [Any weapon?] -> yeea_ugghh_like_whatever

= ugghh_i_need_a
Ugghh, I need a sexy weapon...
+ [Oh and that isss...?] -> listen_se_xy_ugghhh
+ [Well I can get you my best weapon] -> listen_se_xy_ugghhh
+ [Something pretty?] -> listen_se_xy_ugghhh

= don_t_make_me
Don't make me say-ugghhh.
+ [Am I ugly?] -> ughhh_dont_cry_thats
+ [Well I think you're not sexy!] -> um_dont_tell_me
+ [Im ok with being ugly...] -> ughhh_dont_cry_thats

= dont_name_it_that
Dont name it! That's uggghh, so ugghhh...
+ [So you want a damascus weapon!]
    Uggh! I said don't name it! whatevuuggghh. I'm so getting lost!
    -> DONE
+ [Thats its name though...] -> yeea_ugghh_like_whatever
+ [Any weapon?] -> yeea_ugghh_like_whatever

= yeea_ugghh_like_whatever
Yeea-Ugghh, like whatever. Hurry Ugghhh-P
+ [I dont like being talked to this way!] -> um_dont_tell_me
+ [I'll go my fastest!] -> deal
+ [One sexy weapon coming up!] -> deal

= ughhh_dont_cry_thats
Ughhh... dont cry... thats so... uggghhh
-> DONE

= deal
// No line here yet: the old setup left this customer's goal blank.
#deal
-> DONE

= correct_item
Uggghhh, yeeeeaauugghhh!
-> DONE

= wrong_item
Uggghhh, Nooouugghhh!
-> DONE
