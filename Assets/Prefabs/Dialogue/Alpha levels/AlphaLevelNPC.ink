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
I have no dialogue to share as I'm an alpha NPC, void of knowledge to share about the splendor of this world. In other words the dialogue still needs to be written #speaker:B #emotion:empty 
    what #speaker:A #emotion:neutral
 -> END

=== continue ===
Zeg hallo, a niffo. #speaker:B #emotion:neutral #xp:20
->END