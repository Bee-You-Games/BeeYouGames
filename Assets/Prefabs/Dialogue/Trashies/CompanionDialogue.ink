EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()

-> main

=== main ===
... Ze zijn nogsteeds bezig... #speaker:A #emotion:neutral
*   Zie je die twee hamsters? #speaker:A #emotion:happy
    ->kekboi
*   Is er iets? #speaker:A #emotion:troubled
    ->nothing  
    
=== kekboi ===
Nice, I'll join you then. #speaker:B #emotion:happy #xp:30
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== nothing ===
...Ze luisteren maar niet... #speaker:B #emotion:sad
*   wat fucking kut #speaker:A #emotion:happy
-> END