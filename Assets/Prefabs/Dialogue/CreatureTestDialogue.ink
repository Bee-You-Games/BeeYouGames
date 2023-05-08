EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()

-> main

=== main ===
Hi, can I come with you?
*   [yes, sure]
    ->cool
*   [no, please don't]
    ->fool  
    
=== cool ===
Nice, I'll join you then. 
~ ProgressionEvent()
~ DialogueSuccess()

-> END

=== fool ===
Unfortunate, see ya
-> END
