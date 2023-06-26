EXTERNAL BossDamage(pDamage)
EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR emotion = ""

-> main

=== main ===
    Hey! Ik ben gekomen om met je te praten grote man. #speaker:A #emotion:neutral
De naam is Pila! #speaker:B #emotion:intense
Wat wil je van me, kleine? Laat me met rust! Ik heb geen interesse om te praten!#speaker:B #emotion:intense
->keuze

=== keuze ===
    Hmm, hoe zou Pila zich voelen? #speaker:A #emotion:neutral
*   [Blij] Ik weet wel hoe je je voelt, Pila. Stiekem ben je bijna aant het barsten van blijheid! Maar ik kan je helpen met die emoties!  #speaker:A #emotion:happy 
    ~ emotion = "Blij"
    ->verkeerd
*   [Verdrietig] Ik heb het gevoel dat je stiekem heel verdrietig bent, Pila. Maar ik kan je helpen met die emoties!  #speaker:A #emotion:caring
    ~ emotion = "Verdrietig"
    ->verkeerd
*   [Boos] Ik kan zien dat je boos bent, maar ik geloof dat er een betere manier is om met je emoties om te gaan dan je woede je te laten controleren. Je veroorzaakt chaos en angst in het hele bos! #speaker:A #emotion:neutral
    ~ emotion = "Boos"
    ->boos
*   [Bang] Ik heb het gevoel dat je stiekem heel bang bent vanbinnen, Pila. Maar ik kan je helpen met die emoties! #speaker:A #emotion:caring
    ~ emotion = "Bang"
    ->verkeerd
->END

=== verkeerd ===
Wat?! Je hebt geen idee hoe ik me voel! Weg met jou! #speaker:B #emotion:neutral
    Oei, dat was niet de goede keuze. Laten we opnieuw nadenken. #speaker:A #emotion:troubled
->keuze

=== boos ===
EN DUS dat je weet hoe ik me voel. Ik kan je nog veeeel meer chaos laten zien als dat is wat je wilt! #speaker:B #emotion:intense
->goedemotie

=== goedemotie ===
    (Oke, hij is aan het praten. We moeten tot hem doordringen met gezichtsuitdrukkingen) #speaker:A #emotion:neutral
->facechoice

=== facechoice ===
*   [Trek een zorgzaam gezicht] Pila, ik begrijp dat je boos bent, maar er moet een reden achter zitten. Laten we een manier vinden om je woede aan te pakken en een vredige oplossing te zoeken. #speaker:A #emotion:caring
    ->zorggezicht
*   [Trek een boos gezicht] Jij denkt dat je boosheid je macht geeft? Nou, ik laat je niet anderen pijn lijden omdat ermee. Het is tijd om de consequenties onder ogen te zien!#speaker:A #emotion:neutral
    ->verkeerdgezicht
*   [Trek een angstig gezicht] Jouw woede is beangstigend, Pila. Kan je de angst niet zien in anderen die je veroorzaakt. Er moet een manier zijn om rust te vinden zonder anderen pijn te doen en bang te maken. #speaker:A #emotion:troubled
    ->banggezicht
*   [Trek een gespannen gezicht] Luister Pila, je kan niet je agressie uiten op anderen, het heeft ook een effect op hun… Het maakt mij zelf ook gespannen, en ik kan ook zien dat het jou ook stiekem niet blij maakt. #speaker:A #emotion:neutral
    ->spangezicht

=== zorggezicht ===
Wat… Wat bedoel je? Niemand heeft me ooit vriendelijkheid vertoond... #speaker:B #emotion:neutral
->goedgezicht

=== banggezicht ===
Angst…H-het is niet alsof ik ze probeerde bang te maken. Tssh, dat… Dat was nooit mijn bedoeling. #speaker:B #emotion:neutral
->goedgezicht

=== spangezicht ===
W-wat… Wat bedoel je? Ben ik… Ik had niet door wat voor effect mijn emoties hadden op anderen. #speaker:B #emotion:neutral
->goedgezicht

=== verkeerdgezicht ===
Wie ben jij om mij uit te dagen? Denk je dat jouw boosheid tegen die van mij opkan? Probeer het!# speaker:B #emotion:intense
    Oef, ik heb hem alleen maar opgejaagd daarmee. Boos met boos bestrijden was niet een goed idee… #speaker:A #emotion:troubled
->facechoice

=== goedgezicht ===
    (Dat is progressie! Als we lichaamstaal gebruiken zijn we door hem heen!) #speaker:A #emotion:neutral
->bodychoice

=== bodychoice ===
*   [Gespannen houding] Luister Pila, je kan niet je agressie uiten op anderen, het heeft ook een effect op hun… Het maakt mij zelf ook gespannen, en ik kan ook zien dat het jou ook stiekem niet blij maakt. #speaker:A #emotion:troubled
->goedehouding
*   [Agressieve houding]  Als je denkt dat jouw woede mij kan intimideren, dan heb je het goed fout! Ik zal niet voor je zwichten! #speaker:A #emotion:neutral
->slechtehouding
->END

=== goedehouding ===
W-wat… Wat bedoel je? Ben ik… Ik had niet door wat voor effect mijn emoties hadden op anderen.#speaker:B #emotion:neutral
    (Ik dring tot hem door! tijd om het af te sluiten.) #speaker:A #emotion:neutral
->nearconclusion

=== slechtehouding ===
Is dat je tactiek? Je probeert je woede met die van mij te wegen? Niemand is nog zo tegen mij op durven te stappen! KOM MAAR OP.#speaker:B #emotion:intense
    (Neee, dit gaat de verkeerde kant op! Kan ik hem nu nog van gedachte laten veranderen?) #speaker:A #emotion:troubled
->nearconclusion

=== nearconclusion ===
Tijd om dit af te sluiten. #speaker:A #emotion:neutral
*   [Relax en toon empathie] Luister Pila, je kan niet je agressie uiten op anderen, het heeft ook een effect op hun… Het maakt mij zelf ook gespannen, en ik kan ook zien dat het jou ook stiekem niet blij maakt. #speaker:A #emotion:troubled
->conclusie
*   [Behoud je agressieve houding]  Als je denkt dat jouw woede mij kan intimideren, dan heb je het goed fout! Ik zal niet voor je zwichten! #speaker:A #emotion:neutral
->yikes

=== conclusie ===
Misschien heb je gelijk. Ik had geen idee hoe mijn emoties anderen konden beïnvloeden. Het spijt me voor mijn agressieve gedrag. Ik voel me een stuk beter nu! #speaker:B #emotion:neutral 
    Het is gelukt, we hebben het hele bos geholpen! Wat zijn we toch goed! #speaker:A #emotion:happy
->END

=== yikes ===
Wie ben jij om mij de les te leren?! Ik hoef niet naar jouw onzin te luisteren #speaker:B #emotion:intense
    Oh nee, dat was niet de goede optie... We moeten een stap terug zetten en het opnieuw proberen #speaker:A #emotion:troubled
->END
    
/*=== Damage ===
I am the boss and you will listen to me! #speaker:B #emotion:neutral
* Be nice bitch
    ->Damage
* You're a cunt
    ->Damage

I'm doing damage to you #speaker:A #emotion:neutral #xp:30
~BossDamage(20)
->END 
*/