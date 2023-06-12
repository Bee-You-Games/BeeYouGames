EXTERNAL ProgressionEvent()
EXTERNAL DialogueSuccess()
VAR progress = false
VAR emotion = ""

-> main

=== main ===
{
    - progress:
    ->continue
    
    -else:
    ->comment
}

=== continue ===
DIE PADDESTOEL PAST IN DE PALM VAN MIJN HAND, WAT ABSOLUUT WONDERBAARLIJK! AAAAAAH! IK MOET HEM ZIEN!! #speaker:B #emotion:happy
*   [Zet een verdrietig gezicht op] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je verdrietig?  #speaker:A #emotion:troubled
    ~ emotion = "Verdrietig"
    ->verkeerd
*   [Vraag hem om te luisteren] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je boos? #speaker:A #emotion:caring
    ~ emotion = "Boos"
    ->verkeerd
*   [Doe alsof je de paddestoel niet hebt] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je bang? #speaker:A #emotion:surprised
    ~ emotion = "Bang"
    ->verkeerd
->END


=== comment ===
DIE PADDESTOEL PAST IN DE PALM VAN MIJN HAND, WAT ABSOLUUT WONDERBAARLIJK! AAAAAAH! IK MOET HEM ZIEN!! #speaker:B #emotion:happy
*   [Zet een verdrietig gezicht op] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je verdrietig?  #speaker:A #emotion:troubled
    ~ emotion = "Verdrietig"
    ->verkeerd
*   [Vraag hem om te luisteren] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je boos? #speaker:A #emotion:caring
    ~ emotion = "Boos"
    ->verkeerd
*   [Doe alsof je de paddestoel niet hebt] Hallo daar! Ik voel dat je een bepaalde energie krijgt van de paddestoelen hier. Maken ze je bang? #speaker:A #emotion:surprised
    ~ emotion = "Bang"
    ->verkeerd
    
=== blij ===
oof #speaker:B #emotion:happy
    Dat kan ik zien ja, de paddestoelen zien er zeker magisch uit #speaker:A #emotion:happy
-> END

=== verkeerd ===
  bowkewfew #speaker:B #emotion:happy
-> END

