EXTERNAL ProgressionEvent(id)
VAR progress = false
VAR senderID = 0
VAR receiverID = 0

-> main

=== main ===
{
    - progress:
    ->continue
    
    -else:
    ->question
}

=== question ===
you see that little guy over there on the left? can you get him over here for me?
-> END


=== continue ===
wow that's a cool little guy you got there, you may proceed
~ ProgressionEvent(senderID)
-> END
