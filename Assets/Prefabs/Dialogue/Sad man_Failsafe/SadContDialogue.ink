EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false
VAR emotion = ""

-> main

=== main ===
{
    - progress:
    //->continue
    
    -else:
    ->comment
}

=== comment ===
//~ DialogueSuccess()
Ik wil niet meer, niks zal mijn gedachte veranderen. #speaker:B #emotion:sad
*   [Laat de paddestoel zien] Hey, kijk hier eens naar! De paddestoelen zijn volledig ongevaarlijk, moet je deze kleine eens bekijken! #speaker:A #emotion:happy #xp:10
    ->paddoboys
*   [Gaat het goed?] Gaat alles nog goed met je? #speaker:A #emotion:caring
    ->nee
    
=== paddoboys  ===
Wauw, die is inderdaad heel klein. Ik wist niet eens dat dat mogelijk was! Waauw. #speaker:B #emotion:sad
    Zo zie je dat je niet bedroefd over de paddestoelen hoeft te zijn, ze zijn ongevaarlijk! #speaker:A #emotion:happy
Dat zie ik nu inderdaad! Om heel eerlijk te zijn, de paddestoelen zijn ook niet hetgene waar ik echt verdrietig om ben. Kijk... het is...#speaker:B #emotion:sad
    Jani: IS DAT EEN KLEINE PADDESTOEL?!?!? #speaker:A #emotion:surprised
...Daar gaat hij weer...#speaker:B #emotion:sad
    ~ ProgressionEvent()
->END

=== nee ===
Mmhmhm, de paddestoelen zijn overal, ze blijven eindeloos door het bos groeien...#speaker:B #emotion:sad
    Kan ik je daarmee helpen? # #speaker:A #emotion:caring
Wat als ze gevaarlijk zijn, dan zitten we in grote problemen... #speaker:B #emotion:sad
    Hij luistert nog steeds niet... Ik heb net een kleine paddestoel geplukt, misschien kan ik zijn attentie krijgen als ik die aan hem laat zien. # #speaker:A #emotion:neutral
    //~ ProgressionEvent()
->END

/* === continue ===
Ik wil niet meer, niks zal mijn gedachte veranderen #speaker:B #emotion:sad
    Deze hamster lijkt niet zo vrolijk als zijn vriend, wat voor gevoelens zou hij aan vasthouden? #speaker:A #emotion:neutral
    Laten we nadenken, welke emotie voelt de hamster? #speaker:A #emotion:neutral
*   [Blij] Hallo daar! Voel je je ook niet fantastisch tusssen al deze paddestoelen? #speaker:A #emotion:happy
    ~ emotion = "Blij"
    ->verkeerd
*   [Verdrietig] Hallo daar. Ik merk dat jij je niet zo goed voelt als je vriend, kan het zijn dat jij je verdrietig voelt?  #speaker:A #emotion:caring #xp:10
    ~ emotion = "Verdrietig"
    ->verdrietig
*   [Boos] Hallo daar! Is er iets aan de hand? Voel jij je misschien boos? #speaker:A #emotion:troubled
    ~ emotion = "Boos"
    ->verkeerd
*   [Bang] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je bang? #speaker:A #emotion:caring
    ~ emotion = "Bang"
    ->verkeerd
    
=== verkeerd ===
   
-> END

=== verdrietig ===
   Ik...Ja je hebt gelijk, ik voel me inderdaad {emotion}. Deze rot paddestoelen betreuren mij tot geen eind. En mijn vriend weigert ook maar een seconde erover op te houden... #speaker:B #emotion:sad
    Oh wat vervelend, is er iets dat we voor je kunnen doen? #speaker:A #emotion:troubled
    Nou, je kan... Nee het is oke sorry... #speaker:B #emotion:sad
    (Hmm dat is niet pluis, de hamster heeft overduidelijk een probleem maar heeft moeite met het te vertellen. Misschien kunnen we de hamsters even alleen laten en in de omgeving kijken voor een idee.) #speaker:A #emotion:neutral
-> END */

