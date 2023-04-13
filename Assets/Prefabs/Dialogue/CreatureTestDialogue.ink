EXTERNAL ProgressionEvent(id)
EXTERNAL DialogueSuccess()
VAR senderID = 0

-> main

=== main ===
yo, what's up. are you cool?
*   [yea, i'm cool]
    ->cool
*   [no, i am a fool]
    ->fool  
    
=== cool ===
nice, i'll join you then since you are cool 
~ ProgressionEvent(senderID)
~ DialogueSuccess()

-> END

=== fool ===
unfortunate, see ya
-> END
