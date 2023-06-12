EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false
VAR emotion = ""

-> main

=== main ===
{
    - progress:
    ->continue
    
    -else:
    ->comment
}

=== continue ===
/* DIE PADDESTOEL PAST IN DE PALM VAN MIJN HAND, WAT ABSOLUUT WONDERBAARLIJK! AAAAAAH! IK MOET HEM ZIEN!! #speaker:B #emotion:happy
*   [Zet een verdrietig gezicht op] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je verdrietig?  #speaker:A #emotion:troubled
    ~ emotion = "Verdrietig"
    ->verkeerd
*   [Vraag hem om te luisteren] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je boos? #speaker:A #emotion:caring
    ~ emotion = "Boos"
    ->verkeerd
*   [Doe alsof je de paddestoel niet hebt] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je bang? #speaker:A #emotion:surprised
    ~ emotion = "Bang"
    ->verkeerd */
->END


=== comment ===
DIE PADDESTOEL PAST IN DE PALM VAN MIJN HAND, WAT ABSOLUUT WONDERBAARLIJK! AAAAAAH! IK MOET HEM ZIEN!! #speaker:B #emotion:euphoric
    Wat naar...Hij zit volledig zijn vriend zijn emoties te negeren... Als ik aan hem duidelijk kan maken dat Gus verdrietig is...
    ->keuze
    
 === keuze ===   
    Hoe kan ik Jani de hamster benaderen?
*   [Zet een boos gezicht op]Jani! Let toch eens op hoe je vriend je voelt! Kijk hoe verdrietig hij is! #speaker:A #emotion:neutral #xp:20 
    ->boos
*   [Zet een verdrietig gezicht op] Jani, fijn dat je je zo vrolijk voelt, maar je vriend voelt zich echter helemaal niet blij...  #speaker:A #emotion:neutral #xp:20
    ->verdriet
*   [Vraag hem om te luisteren] Jani, luister alsjeblieft eens. Je vriend over daar voelt zich... #speaker:A #emotion:caring
    ->vragen
*   [Doe alsof je de paddestoel niet hebt] Waaat? Welke paddestoel bedoel je? Die grote hier, of daar? #speaker:A #emotion:surprised
    ->liegen
    
=== boos ===
AAH, waarom ben je ineens boos? Heb ik iets verkeerd gedaan? #speaker:B #emotion:concerned
Ik was alleen maar geïnteresseerd in jouw paddestoel... #speaker:B #emotion:concerned
    Sorry Jani, ik wilde niet aggressief overkomen. #speaker:A #emotion:surprised
    Maar nu ik je aandacht heb, is het je opgevallen dat Gus zich verdrietig voelt over jouw gedrag? #speaker:A #emotion:neutral
->verdriet  
    
=== verdriet ===
Heh, wat bedoel je? Gus voelt zich verdrietig? Volgens mij ben je in de war.#speaker:B #emotion:happy
    Nee dat ben ik niet Jani, luister... #speaker:A #emotion:caring
*   [Kijk naar zijn houding] Kijk even goed naar de houding van Gus. Hij lijkt het niet erg naar zijn zin te hebben hier. Hij lijkt echter erg verdrietig.#speaker:A #emotion:caring   
    ->sorry
*   [Gus ziet er verdrietig uit] Kijk even goed naar het gezicht van Gus. Zijn gezicht zegt niet dat hij erg vrolijk zelf is of wel? Hij lijkt meer verdrietig denk je niet? #speaker:A #emotion:caring
    ->sorry
    
=== sorry ===  
Oh nee, je hebt gelijk...ik was zo blij en verbaasd door de paddestoelen dat ik helemaal niet op zat te letten hoe Gus zich erover voelde... #speaker:B #emotion:concerned
    Inderdaad, Gus heeft zich al een tijdje niet fijn gevoelt. #speaker:A #emotion:neutral
    Maar nu je weet hoe hij zich voelt kan je het met hem uitpraten. Ik denk dat hij dat erg fijn zal vinden. #speaker:A #emotion:caring
Ja, je hebt gelijk. Ik had ook naar hem moeten luisteren in plaats van alleen naar mezelf. #speaker:B #emotion:concerned
Ik ga het recht met hem zetten! #speaker:B #emotion:happy
    Tof! Dan kunnen we weer het gezellig met elkaar hebben! #speaker:A #emotion:happy
->END

=== vragen ===
Laat mij die kleine paddestoel eens zien!! #speaker:B #emotion:happy
Alsjeblieft alsjeblieft alsjeblieft!!! #speaker:B #emotion:euphoric
    Ehh... Hij luistert echt niet naar woorden... Misschien kan ik mezelf duidelijker maken door mijn gezicht te gebruiken.#speaker:A #emotion:troubled
->keuze

=== liegen ===
Ik heb de paddestoel wel gezien hoor! Kom op laat mij kijken!!! #speaker:B #emotion:happy
    Liegen helpt me ook niet verder, had ik moeten weten...Ik moet maar direct Jani aanspreken en mijn gevoelens uitten aan hem. #speaker:A #emotion:troubled
->keuze

