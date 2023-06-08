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
Ze maken me... zo droevig...*snuif* Ik begrijp het gewoon niet...  #speaker:B #emotion:sad
*   Hoe heet jij? #speaker:A #emotion:caring
    ->sadness
*   is er iets aan de hand? #speaker:A #emotion:caring
    ->gloom
    
=== sadness  ===
G-grote padde-s-stoellen *snuif*, wat...zullen ze doen? #speaker:B #emotion:sad
    Deze hamster heeft overduidelijk een probleem, maar ik kan moeilijk voor nu met hem praten als hij zo bedoefd is. #speaker:A #emotion:troubled
    Als beide hamsters niet met mij kunnen praten, moet ik misschien wat hulp inschakelen... #speaker:A #emotion:neutral
->END

=== gloom ===
D-de paddestoelen. Waarom zijn ze zo speciaal? Ik kan het niet zien...#speaker:B #emotion:sad
    Kan ik je daarmee helpen? # #speaker:A #emotion:caring
M-misschien zijn ze z-zelfs gevaarlijk... #speaker:B #emotion:sad
    Deze hamster heeft overduidelijk een probleem, maar ik kan moeilijk voor nu met hem praten als hij zo bedoefd is. # #speaker:A #emotion:troubled
    Als beide hamsters niet met mij kunnen praten, moet ik misschien wat hulp inschakelen... #speaker:A #emotion:neutral
->END

=== continue ===
Wow, what a great guy, you may proceed #speaker:B #emotion:happy
~ ProgressionEvent()
-> END
