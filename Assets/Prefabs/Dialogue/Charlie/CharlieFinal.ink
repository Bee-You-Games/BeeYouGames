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
    Oke, we kunnen de fret-rup eindelijk aanspreken #speaker:A #emotion:neutral #speaker:B #emotion:empty
    Hoe zullen we hem benaderen? #speaker:A #emotion:neutral
*   [open en rustig]Hey daar meneer de Fret-rups. Mag ik je naam vragen van je? #speaker:A #emotion:caring
    ->rustig
*   [Schaamtelijk en onzeker]Um, hallo…Ik…Ik heb gemerkt hoe bang je voor mij was eerder. Het spijt me als ik je zo heb laten voelen. Het was niet mijn bedoeling om je te intimideren… #speaker:A #emotion:troubled
    ->schaamte
*   [Alert en zelfverzekerd] Hey daar! Ik heb gemerkt dat je er een beetje angstig uit ziet, is alles oke? #speaker:A #emotion:neutral
    ->alert
*   [Bot en agressief] Hey, jij daar! Waarom doe je zo angstig? Heb je een probleem? #speaker:A #emotion:neutral
    ->bot

=== rustig ===
oh, umm… Mijn naam is Charlie…#speaker:B #emotion:scared2
    Ik merkte op dat je wat gespannen bent, is alles oke?#speaker:A #emotion:caring
    #speaker:B #emotion:scared
Uh..ja..ik voel me nogal ongerust. Ik was gescheiden van mijn vrienden Jani en Gus door de omgevallen boom en nu weet ik niet waar ze zijn.#speaker:B #emotion:scared2
    Ooh nu begrijp ik het. Dat kan je zeker beangstigend maken! #speaker:A #emotion:surprised
    Maar geen zorgen, ik heb je vrienden eerder gezien. Ik heb een weg open gemaakt, dus je kan weer naar ze toe als je wilt! #speaker:A #emotion:neutral
Charlie: Echt waar? Oh dank je! Ik was er zo ongerust over! #speaker:B #emotion:neutral
…Sorry dat ik voor je wegrende, ik had het idee dat ik dat je me pijn ging doen om een of andere reden… #speaker:B #emotion:neutral
Maar ik kan nu zien hoe vriendelijk jij bent!
#speaker:B #emotion:scared2
    Het is volkomen begrijpelijk om zo bang en onzeker te zijn wanneer je gescheiden bent van je vrienden. #speaker:A #emotion:neutral
    Ik ben blij dat wij je hebben kunnen helpen! #speaker:A #emotion:happy
->END

=== schaamte ===
    Mag ik je vragen om je naam? #speaker:A #emotion:caring
Uh..het is okay, Ik…voel me nogal ongerust. Ik was gescheiden van mijn vrienden Jani en Gus door de omgevallen boom en nu weet ik niet waar ze zijn. #speaker:B #emotion:scared2
Ik heet Charlie trouwens #speaker:B #emotion:neutral
    Oh..um… dat klinkt…erg vervelend inderdaad. Ik kan ze misschien gezien hebben…Ze zijn verder terug het bos in. Ik heb een gat gemaakt in de omgevallen boom, dus je kan weer terug naar je vrienden. #speaker:A #emotion:troubled
Oh, echt waar? Dankjewel! Ik was zo bezorgd om hun. #speaker:B #emotion:neutral
Sorry dat ik eerder van je wegrende, je bent uiteindelijk best vriendelijk! #speaker:B #emotion:neutral
    Geen probleem hoor, het is volkomen begrijpelijk om zo bang en onzeker te zijn wanneer je gescheiden bent van je vrienden. #speaker:A #emotion:caring
    Ik ben blij dat wij je hebben kunnen helpen! #speaker:A #emotion:happy
->END

=== alert ===
Uh..ja ik ben okay, Ik…voel me nogal ongerust. Ik was gescheiden van mijn vrienden Jani en Gus door de omgevallen boom en nu weet ik niet waar ze zijn. #speaker:B #emotion:scared2
    Geen probleem rupsman, ik weet waar ze zijn! Je kan langs de omgevallen boom lopen en dan vind je ze!#speaker:A #emotion:happy
Oh…uhm, echt waar? Dankjewel! Ik was zo bezorgd om hun. Ik ben blij dat je me kon helpen! #speaker:B #emotion:scared2
    Geen probleem makker! Als ik jou was dan zou ik je vrienden bezoeken! #speaker:A #emotion:happy
Ja inderdaad…zal ik doen! Dankje voor je hulp. #speaker:B #emotion:neutral
->END

=== bot ===
Uh…Ik…Ik…ben van mijn vrienden gescheiden…Jani en Gus…en ik kan ze niet meer… #speaker:B #emotion:scared2
    Wat balletjes zeg! Goh dat is nog eens pech hebben!#speaker:A #emotion:neutral
Ja…ja dat…klopt zeker… #speaker:B #emotion:scared2
Ik…ik kan…sorry ik moet ervandoor. #speaker:B #emotion:scared
    Huh, Wacht heel even! #speaker:A #emotion:surprised #speaker:B #emotion:empty
    (Oh nee volgens mij heb ik iets verkeerd gedaan)#speaker:A #emotion:troubled
    (Volgens mij heb ik de Frups niet juist benaderd, hij is alleen maar banger geworden van me… Ik moet mijn aanpak misschien veranderen) #speaker:A #emotion:troubled
->introduction

=== continue ===

->END