EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false

-> main

=== main ===
{
    -progress:
    ->continue
    
    -else:
    ->problem
}
    
=== continue ===
aren't you just really fucking cool #speaker:B #emotion:neutral
    I know right #speaker:B #emotion:sad
->END
    
=== problem ===
You can eat it little kid #speaker:B #emotion:intense
*   thank you   #speaker:A #emotion:happy #xp:5
    ->eat
*   fuck off #speaker:A #emotion:caring #xp:5
    ->fuck
-> END

=== eat ===
eat it #speaker:A #emotion:neutral
~ ProgressionEvent()
~ DialogueSuccess()
->END

=== fuck ===
no #speaker:A #emotion:neutral
~ ProgressionEvent()
~ DialogueSuccess()
->END



//Hey speler, ik ben zelf erg goed in emoties zien binnen anderen. Als jij met de hamsters weer kan praten, dan help ik je erdoorheen! #speaker:B #emotion:happy