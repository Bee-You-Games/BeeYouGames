EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()

-> main

=== main ===
Hi, can I come with you? #speaker:B #emotion:happy
*   [yes, sure]
    ->cool
*   [no, please don't]
    ->fool  
    
=== cool ===
Nice, I'll join you then. #speaker:B #emotion:happy
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== fool ===
Unfortunate, see ya #speaker:B #emotion:sad
-> END
