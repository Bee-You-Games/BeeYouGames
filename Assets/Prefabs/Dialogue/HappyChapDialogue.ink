EXTERNAL ProgressionEvent()
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
Weeee, kijk naar deze prachtige paddestoelen! Is dit niet de meest prachtige plek die je ooit hebt gezien? Het voelt als een droom die uitkomt! De kleuren, de vormen, de vreugde die het mijn kleine hamster hartje geeft! #speaker:B #emotion:happy
*   Hoe heet jij? #speaker:A #emotion:neutral
    ->vreugd
*   Hoe gaat het? #speaker:A #emotion:neutral
    ->vreugd
*   Wat ben je aan het doen? #speaker:A #emotion:neutral
    ->vreugd
    
=== vreugd  ===
Oh wat een vreugde!!! Paddestoelen en blijdschap! Blijdschap en paddestoelen! Kan jij het ook voelen? Wat een genot! Laten we draaien tot we omvallen! #speaker:B #emotion:happy
    Wow, deze hamster is enorm opgewonden zeg! Ik kan helaas niet echt een gesprek met hem aan gaan, hij is te vrolijk om mij op te merken. #speaker:A #emotion:surprised
    misschien moet ik met de andere hamster gaan praten. #speaker:A #emotion:neutral
->END


=== comment ===
Weeee, kijk naar deze prachtige paddestoelen! Is dit niet de meest prachtige plek die je ooit hebt gezien? Het voelt als een droom die uitkomt! De kleuren, de vormen, de vreugde die het mijn kleine hamster hartje geeft! #speaker:B #emotion:happy
    Laten we nadenken, welke emotie voelt de hamster? #speaker:A #emotion:neutral
*   [Blij] Ben je blij? #speaker:A #emotion:neutral
    ~ emotion = "Blij"
    ->blij
*   Ik kan zien dat je je [Verdrietig] voelt #speaker:A #emotion:neutral
    ~ emotion = "Verdrietig"
    ->verkeerd
*   Boos #speaker:A #emotion:neutral
    ~ emotion = "Boos"
    ->verkeerd
*   Bang #speaker:A #emotion:neutral
    ~ emotion = "Bang"
    ->verkeerd
    
=== blij ===
    Ahh, stimmt! #speaker:A #emotion:neutral
koom #speaker:B #emotion:happy
-> END

=== verkeerd ===
    Ik ben zuper {emotion}!
-> END

~ ProgressionEvent()
