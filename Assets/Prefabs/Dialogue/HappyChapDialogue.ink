EXTERNAL ProgressionEvent()
VAR progress = false

-> main

=== main ===
{
    - progress:
    ->continue
    
    -else:
    ->comment
}

=== comment ===
I'm so happy, I'm getting an aneurism! #speaker:B #emotion:happy
*   Isn't that just stellar #speaker:A #emotion:neutral
    ->jovial
*   No, please don't #speaker:A #emotion:neutral
    ->love
    
=== jovial  ===
It's. Fucking. Amazing
->END

=== love ===
The euphoria hits different like that
->END

=== continue ===
Wow, what a great guy, you may proceed #speaker:B #emotion:happy
~ ProgressionEvent()
-> END
