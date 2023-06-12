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

=== comment ===
Ze maken me... zo droevig...*snuif* Ik begrijp het gewoon niet...  #speaker:B #emotion:sad
   //~ DialogueSuccess()
De paddestoelen kunnen gevaarlijk zijn, vertrouw ze niet... #speaker:B #emotion:crying
*   Hoe heet jij? #speaker:A #emotion:caring
    ->sadness
*   is er iets aan de hand? #speaker:A #emotion:caring
    ->gloom
    
=== sadness  ===
M-mijn naam... ehh...Gus #speaker:B #emotion:sad
G-grote padde-s-stoellen *snuif*, wat...zullen ze doen? #speaker:B #emotion:crying
    Deze hamster heeft overduidelijk een probleem, maar ik kan moeilijk voor nu met hem praten als hij zo bedoefd is. #speaker:A #emotion:troubled
    Als beide hamsters niet met mij kunnen praten, moet ik een manier zoeken om hun aandacht te trekken #speaker:A #emotion:neutral
    ~ ProgressionEvent()
->END

=== gloom ===
D-de paddestoelen. Waarom zijn ze zo speciaal? Ik kan het niet zien...#speaker:B #emotion:sad
    Kan ik je daarmee helpen? # #speaker:A #emotion:caring
M-misschien zijn ze z-zelfs gevaarlijk... #speaker:B #emotion:crying
    Deze hamster heeft overduidelijk een probleem, maar ik kan moeilijk voor nu met hem praten als hij zo bedoefd is. # #speaker:A #emotion:surprised
    hmm, beide hamsters zijn te druk bezig met hun emoties. #speaker:A #emotion:troubled
    Wat als ik me eerst probeer in te leven in hun schoenen en nadenk over hun emoties? #speaker:A #emotion:neutral
    ~ ProgressionEvent()
->END

=== continue ===
Wat maakt het nou uit...*snuif*. Waarom zijn ze zo speciaal? #speaker:B #emotion:crying
    Deze hamster lijkt niet zo vrolijk als zijn vriend, wat voor gevoelens zou hij aan vasthouden? #speaker:A #emotion:troubled
    Hmm, welke emotie voelt de hamster? #speaker:A #emotion:neutral
    //~ DialogueSuccess()
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
    Oh, eh, sorry maar nee...Ik voel me niet {emotion}. Ik heb wel andere problemen, maar... ach vergeet het. #speaker:B #emotion:sad
-> END

=== verdrietig ===
   Ik...Ja je hebt gelijk, ik voel me inderdaad {emotion}. Deze rot paddestoelen betreuren mij tot geen eind. En mijn vriend weigert ook maar een seconde zijn mond erover op te houden... #speaker:B #emotion:sad
    Oh wat vervelend, is er iets dat we voor je kunnen doen? #speaker:A #emotion:troubled
    Nou, je kan... Nee het is oke sorry... #speaker:B #emotion:sad
    (Hmm dat is niet pluis, de hamster heeft overduidelijk een probleem maar heeft moeite met het te vertellen. Misschien kunnen we de hamsters even alleen laten en in de omgeving kijken voor een idee.) #speaker:A #emotion:neutral
        (Wacht eens even, ik heb eerder een kleine paddestoel geplukt! Zou dat niet werken om hem op te vrolijken?) #speaker:A #emotion:surprised
    Zal ik de paddestoel laten zien? #speaker:A #emotion:neutral
*   [Gaat het goed?] Gaat alles nog goed met je? #speaker:A #emotion:caring
    ->nee
*   [Laat de paddestoel zien] Hey, kijk hier eens naar! De paddestoelen zijn volledig ongevaarlijk, moet je deze kleine eens bekijken! #speaker:A #emotion:happy #xp:10
    ->paddoboys

    
 === paddoboys ===  
Wauw, die is inderdaad heel klein. En je kan hem vasthouden! Ik wist niet eens dat dat mogelijk was! Waauw. #speaker:B #emotion:relieved
    Zo zie je dat je niet bedroefd over de paddestoelen hoeft te zijn, ze zijn ongevaarlijk! #speaker:A #emotion:happy
Dat zie ik nu inderdaad! Om heel eerlijk te zijn, de paddestoelen zijn ook niet hetgene waar ik echt verdrietig om ben. Kijk... het is...#speaker:B #emotion:relieved
    Jani: IS DAT EEN KLEINE PADDESTOEL?!?!? #speaker:A #emotion:surprised
...Daar gaat hij weer...#speaker:B #emotion:sad
Hij geeft alleen maar iets om die stomme paddestoelen...Hij luistert nooit...#speaker:B #emotion:crying
    Oh nee, Gus was nooit verdrietig over de paddestoelen, hij is verdrietig over zijn vriend die niet wilt luisteren... #speaker:A #emotion:troubled
    Ik moet met de blije hamster praten en hem op laten merken dat zijn vriend verdrietig is! #speaker:A #emotion:neutral
    ~ DialogueSuccess()
    ->END

=== nee ===
Mmhmhm, de paddestoelen zijn overal, ze blijven eindeloos door het bos groeien...#speaker:B #emotion:sad
    Kan ik je daarmee helpen? # #speaker:A #emotion:caring
Wat als ze gevaarlijk zijn, dan zitten we in grote problemen... #speaker:B #emotion:crying
    Hij luistert nog steeds niet... Ik heb net een kleine paddestoel geplukt, misschien kan ik zijn attentie krijgen als ik die aan hem laat zien. # #speaker:A #emotion:neutral
    //~ ProgressionEvent()
    ->END