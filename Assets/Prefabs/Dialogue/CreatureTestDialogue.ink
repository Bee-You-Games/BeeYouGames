EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()

-> main

=== main ===
Hi, can I come with you? #speaker:B #emotion:neutral
*   Yes, sure #speaker:A #emotion:happy
    ->cool
*   No, please don't #speaker:A #emotion:troubled
    ->fool  
    
=== cool ===
Nice, I'll join you then. #speaker:B #emotion:happy #xp:30
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== fool ===
Unfortunate, see ya #speaker:B #emotion:sad
-> END
