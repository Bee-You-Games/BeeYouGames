EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false

-> main

=== main ===
{
    -progress:
    ->continue
    
    -else:
    ->nothing
}
    
=== continue ===
Wat is er aan de hand met ze? #speaker:B #emotion:sad 
*   Zou je mij kunnen helpen?   #speaker:A #emotion:caring #xp:20
    ->helpen
*   Je lijkt een probleem te hebben? #speaker:A #emotion:caring #xp:20
    ->probleem
    
=== helpen ===
Sorry, maar ik heb het nogal druk. Zie je die twee hamsters daar staan. Er is iets aan de hand met hun emoties en ik moet er achter komen wat het is.#speaker:B #emotion:neutral
Wat als wij gaan samenwerken met elkaar? Dan kunnen we zeker een beter gesprek met ze aan gaan! #speaker:A #emotion:neutral
Dat klinkt tof!! Ik ben erg goed in emoties te kunnen zien! Als jij met de hamsters weer kan praten, dan zal ik je helpen op welke manier ik ook kan! #speaker:B #emotion:happy
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== probleem ===
Ja dat kan je wel zeggen, iedereen binnen dit bos blijkt hun emoties niet te controlleren. ik heb geprobeerd met ze te praten maar ze lusiteren maar niet ...#speaker:B #emotion:sad
Wat als wij gaan samenwerken met elkaar? Dan kunnen we zeker een beter gesprek met ze aan gaan! #speaker:A #emotion:neutral
Dat klinkt tof!! Ik ben erg goed in emoties te kunnen zien! Als jij met de hamsters weer kan praten, dan zal ik je helpen op welke manier ik ook kan! #speaker:B #emotion:happy
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== nothing ===
... Ze zijn nogsteeds bezig... #speaker:B #emotion:sad
*   Zie je die twee hamsters? #speaker:A #emotion:neutral
    ->hamsters
*   Is er iets? #speaker:A #emotion:troubled
    ->luisteren  

=== hamsters ===
Maar...OH ja die zie ik... Sorry ik ben bezig #speaker:B #emotion:neutral
    Hij is druk... Ik laat hem voor nu wel met rust #speaker:A #emotion:neutral
-> END

=== luisteren ===
...Ze luisteren maar niet... #speaker:B #emotion:sad
    Uhm hallo? #speaker:A #emotion:suprised
... #speaker:B #emotion:neutral
    Hij luistert niet blijkbaar niet, misschien moet ik later terug komen #speaker:A #emotion:neutral
-> END


//Hey speler, ik ben zelf erg goed in emoties zien binnen anderen. Als jij met de hamsters weer kan praten, dan help ik je erdoorheen! #speaker:B #emotion:happy