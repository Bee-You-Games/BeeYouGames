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
    Jeetje, dat gemene konijn heeft de hele boom om laten vallen! #speaker:A #emotion:troubled #speaker:B #emotion:empty
Ja Pila heeft er een rotzooi van gemaakt oke. Je zal een omweg moeten vinden wil je daar doorheen moeten. #speaker:B #emotion:empty
     Pardon… Wie zij dat? #speaker:A #emotion:surprised
Hierzo voor je, verloren ziel #speaker:B #emotion:neutral
    Een...pratende paddestoel? #speaker:A #emotion:surprised
    ~ ProgressionEvent()
 -> END

=== continue ===
Zeg hallo daar, niet-paddestoel vriend. #speaker:B #emotion:neutral
*   Uhm...Hallo? #speaker:A #emotion:neutral
    ->groet
*   [Sorry voor het plukken!] Aah, sorry voor het plukken! #speaker:A #emotion:troubled
    ->schuldig 
*   Wat voor wezen ben jij? #speaker:A #emotion:neutral
    ->wezen

=== groet ===
Hey! Een nieuw gezicht zoals jij zien we niet vaak. #speaker:B #emotion:neutral
We hebben wel veel visite laatst zeg! #speaker:B #emotion:neutral
    Jij bent een levende paddestoel... #speaker:A #emotion:surprised
    hemeltje, kan elke paddestoel praten binnen dit bos?? #speaker:A #emotion:troubled
Nee, helaas niet. Wat een feest zou dat zijn. #speaker:B #emotion:neutral
Maar ik neem aan dat jij het feest aan het helpen bent bij de hamsters? #speaker:B #emotion:neutral
    Ja inderdaad, de hamsters hebben een probleem en het lijkt erop dat het met de paddestoelen te maken heeft. #speaker:A #emotion:neutral
    Ik dacht als ik een kleinere meeneem dat ik hun attentie beter kan krijgen. #speaker:A #emotion:neutral
Ik zie...In dat geval, er zijn meerdere paddestoelen zoals die verspreidt over het hele bos zoals deze naast mij. Vind ze allemaal voor me en dan heb ik iets geweldigs voor je klaarstaan. #speaker:B #emotion:neutral
   dat klinkt interessant! Dan zal ik daar werk van gaan maken!! #speaker:A #emotion:happy
    //~ ProgressionEvent()
-> END

=== schuldig ===
Geen angst nieuwe vriend. Sterker nog, je mag van mij ze plukken hoeveel je wilt! #speaker:B #emotion:neutral
Waarschijnlijk heb je ze nodig voor die hamster knakkers terug in het bos. #speaker:B #emotion:neutral
    Oh uhm, mooi! #speaker:A #emotion:surprised
    Jij weet van de hamsters af? #speaker:A #emotion:neutral
Ja natuurlijk, de meeste in het bos kennen ze nu wel. Er is iets raars aan de hand met die twee. Hun emoties zijn een beetje doorgeslagen. #speaker:B #emotion:neutral
En een heeft een vreemde liefde voor alle paddestoelen...#speaker:B #emotion:neutral
    Ja dat heb ik gemerkt... Eentje is echter juist bang voor, dus ik dacht dat deze schattige paddestoel hem kon uithelpen #speaker:A #emotion:neutral
Aha juist! Erg slim! In dat geval wil ik je vragen elke paddestoel zoals die te plukken. Pluk elke die je kan vinden en dan heb ik iets geweldigs voor je klaar staan! #speaker:B #emotion:neutral #xp:10
    Klinkt interessant, dan zal ik daar werk van gaan maken!! #speaker:A #emotion:happy

-> END

=== wezen ===
Een paddestoel zoals je kan zien, en zoals je ook kan zien ben jij géén paddestoel. #speaker:B #emotion:neutral
    Ja...Ik bedoel echt waar?? #speaker:A #emotion:surprised
Echt waar ja! En ik heb gezien hoe jij heel vrolijk een paddestoel van meneer de steen hebt getrokken. #speaker:B #emotion:neutral
    Sorry! Ik had niet door dat naast alle paddestoelen binnen dit bos er ook levende paddestoelen waren!  #speaker:A #emotion:troubled
    Ik wil een paar hamsters helpen een stukje terug en deze paddestoel kan me daarin helpen. #speaker:A #emotion:neutral
Geen probleem vriend! Sterker nog, ga er gerust mee door! Die kleine paddestoeltjes mogen wel eens opgeruimd worden van die arme stenen, ze hebben de armen niet om ze zelf weg te halen haha! #speaker:B #emotion:neutral
Nog sterker nog! Er zijn een aantal paddestoelen verspreidt over het bos. Vind ze allemaal en dan heb ik iets geweldigs voor je klaar staan! #speaker:B #emotion:neutral #xp:10
    Oh gelukkig maar, dan zal ik daar werk van gaan maken!! #speaker:A #emotion:happy
-> END
