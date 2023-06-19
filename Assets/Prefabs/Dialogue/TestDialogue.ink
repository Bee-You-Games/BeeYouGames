EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false

-> main

=== main ===
{
    -progress:
    ->continue
    
    -else:
    ->mushroom
}
    
=== mushroom === 
...#speaker:B #emotion:idle  
    Zeg vader a niffo #speaker:A #emotion:neutral
    ~ DialogueSuccess()
 -> END

=== continue ===
Zeg hallo daar, niet-paddestoel vriend. #speaker:B #emotion:neutral #xp:20
    ~ DialogueSuccess()
->END