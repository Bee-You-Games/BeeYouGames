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
You see that little guy over there on the left? Can you eat him over there for me? #speaker:B #emotion:neutral
-> END


=== continue ===
Wow, what a great guy, you may proceed #speaker:B #emotion:happy
~ ProgressionEvent()
-> END
