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
    HEY!!#speaker:B #emotion:euphoric
    ~ DialogueSuccess()
    OH WAUW!!!!
-> END

=== keuze ===
Weeee, kijk naar deze prachtige paddestoelen! Ik voel alsof ik het hele bos kan vullen met geluk en de liefde met iedereen kan delen!! Spring, geniet en dans! #speaker:B #emotion:euphoric
    
    Hmm, welke emotie voelt de hamster? #speaker:A #emotion:neutral
*   [Blij] Hallo daar! Ik voel dat de paddestoelen jou enorm veel blijdschap geven en ik moet zeggen, ik voel het ook helemaal! Zijn deze paddestoelen magisch?  #speaker:A #emotion:happy #xp:10
    ~ emotion = "Blij"
    ->blij
*   [Verdrietig] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je verdrietig?  #speaker:A #emotion:caring
    ~ emotion = "Verdrietig"
    ->verkeerd
*   [Boos] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je boos? #speaker:A #emotion:troubled
    ~ emotion = "Boos"
    ->verkeerd
*   [Bang] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je bang? #speaker:A #emotion:caring
    ~ emotion = "Bang"
    ->verkeerd
    
=== blij ===
Oh mijn vrolijke vriend, mijn paddestoel kameraad, jij voelt het nu ook! Deze paddestoelen... Ze vullen mijn hart met bodemloze blijdschap en genot. Ik voel alsof ik deze vrolijkheid met iedereen moet delen! #speaker:B #emotion:happy
    Dat kan ik zien ja, de paddestoelen zien er zeker magisch uit #speaker:A #emotion:happy
    ~DialogueSuccess()
-> END

=== verkeerd ===
 Oh hemeltje, je bent een beetje in de war volgens mij vriend! Deze paddestoelen maken mij niet {emotion}! Deze paddestoelen geven mij onwijze vrolijkheid!! #speaker:B #emotion:happy
   (Dat was blijkbaar niet het goede antwoord, hij lijkt inderdaad meer gelukkig dan {emotion}) #speaker:A #emotion:neutral
-> END

=== comment ===
Weeee, kijk naar deze prachtige paddestoelen! Is dit niet de meest prachtige plek die je ooit hebt gezien? Het voelt als een droom die uitkomt! De kleuren, de vormen, de vreugde die het mijn kleine hamster hartje geeft! #speaker:B #emotion:euphoric
    //~ DialogueSuccess()
Kom, laten we samen ons geluk delen. #speaker:B #emotion:happy
*   Hoe heet jij? #speaker:A #emotion:neutral
    ->vreugdnaam
*   Hoe gaat het? #speaker:A #emotion:neutral
    ->vreugd
*   Wat ben je aan het doen? #speaker:A #emotion:neutral
    ->vreugd
    
=== vreugdnaam  ===   
Ik heet Jani! Oh, jij bent hier ook om van de paddestoel hemel te genieten! Wat een vreugd, wat een plezier! Mijn buik ontploft van de pret en de paddestoelen!!! #speaker:B #emotion:euphoric
 Wow, deze hamster is enorm opgewonden zeg! Ik kan helaas niet echt een gesprek met hem aan gaan, hij is te vrolijk om mij op te merken. #speaker:A #emotion:surprised
    (Hmm, Empati had het over het begrijpen van emoties van anderen. Laten we proberen zijn emoties te achterhalen.) #speaker:A #emotion:neutral
    
->keuze

=== vreugd  ===
Oh wat een vreugde!!! Paddestoelen en blijdschap! Blijdschap en paddestoelen! Kan jij het ook voelen? Wat een genot! Laten we draaien tot we omvallen! #speaker:B #emotion:euphoric
    Wow, deze hamster is enorm opgewonden zeg! Ik kan helaas niet echt een gesprek met hem aan gaan, hij is te vrolijk om mij op te merken. #speaker:A #emotion:surprised
    misschien moet ik met de andere hamster gaan praten. #speaker:A #emotion:neutral
  //~ ProgressionEvent()
->END

