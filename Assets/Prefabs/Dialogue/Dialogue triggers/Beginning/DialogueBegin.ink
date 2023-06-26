EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false

-> main

=== main ===
{
    -progress:
    ->continue
    
    -else:
    ->begin
}
    
=== continue ===

->END
    
=== begin ===
    Wow! Wat ziet dit bos er toch magisch uit, en wat zie ik veel…paddestoelen? #speaker:A #emotion:neutral #speaker:B #emotion:empty
    Ze geven zelfs licht! Wat fantastisch #speaker:A #emotion:happy
HEY AAN DE KANT!! #speaker:B #emotion:neutral
    (springt opzij)#speaker:A #emotion:surprised #speaker:B #emotion:empty
    Wauw wat gemeen was dat zeg, hij schoof me zo aan de zijkant! #speaker:A #emotion:troubled
    Hij leek wel heel erg boos toen hij mij wegduwde, maar waarom uit je je woede op anderen? #speaker:A #emotion:troubled
    Misschien komen we hem wel opnieuw tegen, op mijn hoede blijven. #speaker:A #emotion:neutral
-> END

