// Strong Man (four visits)

// ----------------------------------------------------------------------------
// Scene object: StrongMan 1
=== strong_man_1 ===
Hey I need your cheepest sword... Copper I think
+ [Yup its copper, Coming up!] -> deal
+ [Sure, one copper sword!] -> deal
+ [No, I don't want to make that... Sorry]
    Ah! Bummer!
    -> DONE

= deal
#wants: Copper Sword
One Copper sword please #deal
-> DONE

= correct_item
Sweet, Can't wait to hit some things!
-> DONE

= wrong_item
Uhh, this isnt a copper sword...
-> DONE

// ----------------------------------------------------------------------------
// Scene object: StrongMan 2
=== strong_man_2 ===
Hey I broke that copper sword, I need another...
+ [You broke it?] -> yeah_i_hit_the
+ [Do you want another copper sword?] -> yeah_i_hit_the
+ [Yeah I guess copper isn't too strong a metal.] -> yeah_i_hit_the

= yeah_i_hit_the
Yeah, I hit the ground on accident, and it just snapped... Could I get the second cheepest sword?
+ [No, I am not selling weapons to people who abuse them!]
    Ah! Bummer!
    -> DONE
+ [Alright, lets get you an iron sword!] -> deal
+ [Iron sword coming up!] -> deal

= deal
#wants: Iron Sword
One Iron sword please #deal
-> DONE

= correct_item
Going to SMACK some stuff with this!
-> DONE

= wrong_item
Uhh, this isnt a iron sword...
-> DONE

// ----------------------------------------------------------------------------
// Scene object: StrongMan 3
=== strong_man_3 ===
Uhhh... I broke another sword...
+ [What are we on now? Steel?] -> yeah_it_was_an
+ [What? How?] -> yeah_it_was_an
+ [One steel sword coming up!] -> deal

= yeah_it_was_an
Yeah, It was an accident, I swung it and it hit a house...
+ [Alright, lets get you that steel sword...] -> deal
+ [This is the last one alright?] -> deal
+ [No I'm not making that for you!]
    Ah! Bummer!
    -> DONE

= deal
#wants: Steel Sword
One Steel sword please #deal
-> DONE

= correct_item
Ohh yeah, looks good.
-> DONE

= wrong_item
Uhh, this isnt a Steel sword...
-> DONE

// ----------------------------------------------------------------------------
// Scene object: StrongMan 4
=== strong_man_4 ===
Listen, just give me your strongest sword...
+ [Damascus steel sword coming up!] -> deal
+ [Wow youre really going through these swords...] -> yeah_i_think_its
+ [I'm not giving you ANOTHER sword!] -> ah_bummer

= yeah_i_think_its
Yeah, I think its because I am strong? Or maybe just a bad sword man... Lets pretend strong!
+ [Well Damascus should do you well!] -> deal
+ [Im not letting such a poor swordsman have such an incredible sword!] -> ah_bummer
+ [Yeah... One last sword!] -> deal

= ah_bummer
Ah! Bummer!
-> DONE

= deal
#wants: Damascus Steel Sword
One Damscus sword please #deal
-> DONE

= correct_item
YES! Just like in that Anime!
-> DONE

= wrong_item
Uhh, this isnt a Damascus sword...
-> DONE
