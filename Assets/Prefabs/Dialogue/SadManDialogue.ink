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
I feel such a relentless and agonizing level of sadness from the green and blue vegetation of the fungi flora around me.  #speaker:B #emotion:sad
*   Great! #speaker:A #emotion:neutral
    ->sadness
*   don't you worry child #speaker:A #emotion:happy
    ->gloom
    
=== sadness  ===
My pain knows no bounds as I'm forced to endure such a horrible ordeal that can challenge even the infernal pits of hell itself. #speaker:B #emotion:sad
->END

=== gloom ===
How can I stop my consideration over this threatening happenstance I've found myself in, I barely cling onto my last pieces of vigor as the light is drifting away further and further.#speaker:B #emotion:sad
->END

=== continue ===
Wow, what a great guy, you may proceed #speaker:B #emotion:happy
~ ProgressionEvent()
-> END
