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
    Hey daar kleine! Wat is jouw naam? #speaker:A #emotion:happy #speaker:B #emotion:scared 
AAH! #speaker:B #emotion:scared2
(het gekke beestje sprint weg) #speaker:B #emotion:empty
    Heh, waarom rende die eh...fret-rups... zo gehaast weg? Hij keek alsof ik hem iets aan ging doen.#speaker:A #emotion:surprised
    Hey, wacht! Ik wil alleen maar met je praten!#speaker:A #emotion:neutral
 -> END

=== continue ===
Zeg hallo daar, niet-paddestoel vriend. #speaker:B #emotion:neutral #xp:20

->END