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
    Hij is nog verder gelopen... Waarom rent hij toch steeds van me weg?#speaker:A #emotion:neutral #speaker:B #emotion:creature
Ik moet zeggen dat je de fret-rups een beetje heftig benaderd. #speaker:B #emotion:creature
Het kan zijn dat hij zich geïntimideerd voelt door jou, je bent uiteindelijk wel een kop groter dan de kleine jongen. #speaker:B #emotion:creature
    Oh nee! Ik bedoelde het niet om hem bang te maken... Nu voel ik me schuldig. #speaker:A #emotion:troubled
   Maar hoe kan ik hem aanspreken zonder hem bang te maken? #speaker:A #emotion:neutral
Het is belangrijk om bewust te zijn over je lichaamstaal en houding, voornamelijk het effect dat het op anderen kan hebben. #speaker:B #emotion:creature
In het geval van de fret-rups, jouw lengte en houding kunnen ervoor gezorgd hebben dat hij zich niet veilig om je heen voelde. #speaker:B #emotion:creature
Misschien moeten we kijken naar onze manier van aanpak zodat we minder intimiderend overkomen. #speaker:B #emotion:creature
    ->keuze
    
=== keuze ===
    Aha! dus ik moet mezelf:
*   [Klein en minder bedreigend]Als ik mezelf nou kleiner maak en hem rustiger benader, zou dat werken? #speaker:A #emotion:neutral
    ->klein
*   [Klein en onzeker]Als ik mezelf nou kleiner maak en mezelf meer onzeker maak, zou dat werken? #speaker:A #emotion:neutral
    ->onzeker
*   [Groot en open armen]Als ik mezelf nou groter maak en hem met open armen ontvang, zou dat werken? #speaker:A #emotion:neutral
    ->groot
*   [Mijn houding is prima]Ik zie helemaal niets mis met mijn houding, waar heb je het over makker? #speaker:A #emotion:neutral
    ->niks
 
 === klein ===
Inderdaad! Laat zien dat je juist meer teder bent dan dat je je aan hem voorstelt! #speaker:B #emotion:creature
 -> END
 
  === onzeker ===
Als je jezelf kleiner maakt, dan kijk je op ooghoogte van de fret-rups waardoor hij zich meer prettig zal voelen. Hem met onzekerheid benaderen kan werken, maar je hoeft jezelf niet te kleineren om hem meer comfortabel te maken. #speaker:B #emotion:creature
 -> END
 
  === groot ===
Je maakt hem juist onzeker omdat je je groot opstelt. Hij wordt daar waarschijnlijk alleen maar meer geïntimideerd door. Laten we een andere aanpak proberen. #speaker:B #emotion:creature
 -> keuze
 
  === niks ===
Daar ben ik het niet mee eens, jouw houding is juist hetgeen dat de fret-rups beangstigend maakt! #speaker:B #emotion:creature
 -> keuze

=== continue ===
Zeg hallo daar, niet-paddestoel vriend. #speaker:B #emotion:neutral #xp:20

->END