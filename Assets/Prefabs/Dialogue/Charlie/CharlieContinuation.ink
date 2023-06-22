EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false

-> main

=== main ===
{
    -progress:
    ->continue
    
    -else:
    ->introduction
}
    
=== introduction === 
    Hey, wacht nou even! #speaker:A #emotion:neutral #speaker:B #emotion:scared 
Neee! Ik heb niets gedaan! #speaker:B #emotion:scared2
(De Frups rent de ingang in) #speaker:B #emotion:empty
   Hey, wacht! Ik wil alleen maar met je praten!#speaker:A #emotion:neutral
   Hij gaat verder het bos in, ik moet hem volgen.#speaker:A #emotion:surprised
 -> END

=== continue ===
Zeg hallo daar, niet-paddestoel vriend. #speaker:B #emotion:neutral #xp:20

->END