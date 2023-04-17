EXTERNAL ProgressionEvent()
VAR progress = false

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
~ ProgressionEvent()
-> END
