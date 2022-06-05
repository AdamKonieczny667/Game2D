# Game2D
Platformowa gra 2D


1. Temat projektu i nazwa aplikacji

Tematem projektu jest platformowa gra 2D zbudowana w środowisku Unity. Aplikacja 
nazywa się „Gra2D”. 

2. Cel projektu 
Celem projektu jest stworzenie gry platformowej 2D przypominającą przez swoją grafikę i sposób 
sterowania wczesne gry na konsole NES takie jak „Mario Bros”, „Castlevania” czy „Metroid”. Gra 
składa się z dwóch plansz i celem każdej z nich, jest dotarcie do końca mapy gdzie znajduję się skrzynia 
ze skarbem. 

2.1. Cele szczegółowe
• Zaprojektowanie systemu zdrowia postaci gracza o Gdy zdrowie spadnie do 0, gra się kończy 
o Gdy zdrowie jest niepełne, postać gracza może uleczyć się zbierająć „serduszka” z planszy 
o Gdy zdrowie jest pełne, postać nie może korzystać z zbieranych „serduszek” 
• Zaprojektowanie systemu walki o Gracz może wykonywać ataki żeby zadawać obrażenia 
przeciwnikom o Przeciwnicy mogą patrolować wyznaczony obszar mapy i gdy na ich drodze 
stanie postać gracza wykonują atak, zadając obrażenia 
• Zaprojektowanie sterowania 
• Zaprojektowanie i przygotowanie plansz 
• Zmiana planszy po skończeniu pierwszego poziomu 
• Zaprojktowanie przeciwników o Nieporuszające się pułapki które zadają obrażenia gdy 
postać gracza zderzy się z nimi o Przeciwnicy którzy patrolują teren i atakują gracza 
o Przeciwnicy którzy stoją w miejscu i zadają obrażenia gdy gracz będzie dostatecznie 
blisko 

3. Funkcjonalności aplikacji 
• System zdrowia gracza 
• Sterowanie postacią (poruszanie się w na płaszczyźnie 2D) 
• Możliwość atakowania 
• Zbieranie „serduszek” które przywracają życie postaci gracza 
• Atakowanie i zadawanie obrażeń przeciwnikom 
• Pułapki zadające obrażenia postaci gracza 
• Przeciwnicy poruszający się po wytyczonych ścieżkach i zadawaniu obrażeń postaci gracza 

4. Technologie 
Unity, C#

5. Interesariusze aplikacji 
Fani platformowych gier, fani gier w stylu „retro” 

6. Projekt GUI  
Menu gry: 

<>

Widok planszy gry: 

<>

W lewym górnym rogu znajdują się serca które reprezentują ilość życia postaci gracza. 
U dołu ekranu znajdują się klawisze odpowiedzialne za: skok, atak i poruszanie się.

Menu pokazujące się po utracie żyć: 

<>

Widok po skończeniu pierwszego poziomu: 

<>

7. Struktura programu 

<>

7.1. Dane wykorzystywane przez program 
Program nie korzysta z danych użytkownika. 

7.2. Opis plików zewnętrznych
Plikami zewnętrznymi są wszelkie tekstury, assety, sprite’y, ikonki zapisane w formacie PNG. Pliki graficzne pochodzą ze strony 
assetstore.unity.com. 

7.3. Podział na moduły, komunikacja między modułami
Klasa PlayerMovement: 
- Jump() – skok postaci 
- isGrounded() – sprawdzenie czy postać dotyka obiektu typu „ground” 
- canAttack() – sprawdzenie czy postać może wykonać atak 
- Replay() – załadowanie panelu przegranej gry 
- MoveLeft() – ruch w lewo 
- MoveRight() – ruch w prawo 
- StopMoving() – zatrzymanie postaci 
- Awake() – przypisanie zmiennym konkretnych komponentów z unity np RigidBody2d, Box Collider2D 
lub Animator 
Klasa PlayerAttack: 
- Attack() – atak postaci z włączeniem odpowiedniej animiacji 
- EnemyInSight() – sprawdzenie czy przeciwnik jest w zasięgu 
- OnDrawGizmos() – rysowanie pola odpowiadającego za zasięg ataku 
- DamageEnemy() – zadanie przeciwnikowi obrażeń 
Klasa CameraController: 
- Update() – ruch kamery z postacią gracza 
Klasa SoundManager: 
- PlaySound() – aktywowanie odpowiednich efektów dźwiękowych 
Klasa Enemy_trap: 
- OnTriggerEnter2D(Collider2D collision) – zadanie obrażeń graczowi przy kolizji z obiektem typu 
„trap” 
Klasa Enemy_Patrol: 
- DirectionChange() – zmiana kierunku ruchu przeciwnika po dodarciu do „punktu patrolu” 
-MoveInDirection() – poruszanie się przeciwnika w stronę „punktu patrolu” 
- OnDisable() – wyłączenie ruchu w przypadku śmierci 
Klasa Melee_Enemy: 
- Attack() – atak przeciwnika z włączeniem odpowiedniej animiacji 
- PlayerInSight() – sprawdzenie czy gracz jest w zasięgu 
- OnDrawGizmos() – rysowanie pola odpowiadającego za zasięg ataku 
- DamagePlayer() – zadanie graczowi obrażeń Klasa BadEnding: 
- PlayGame() – załadowanie sceny „Level1” 
- QuitGame() – wyjście z programu 
Klasa Ending: 
- OnTriggerEnter2D(Collider2D collision) – załadowanie sceny “End” po kolizji z obiektem typu 
“treasure” 
Klasa EndingMenu: 
- PlayGame() – załadowanie sceny „Level1” 
- PlayLevel2() – załadowanie sceny „Level2” 
- QuitGame() – wyjście z programu 
Klasa EndLevel2: 
- OnTriggerEnter2D(Collider2D collision) – załadowanie sceny “Level1End” po kolizji z obiektem typu
“treasure” 
Klasa Health: 
- TakeDamage(float _damage) – zabieranie serduszek z paska zdrowia, sprawdzanie czy postać gracza 
nie ma mniej niż 0 obecnego zdrowia 
-AddHealth() – dodawanie zdrowia po kolizji z odpowiednim obiektem 
Klasa HealthBar: 
- Start() – ustawienie początkowej maksymalnej ilości zdrowia na pasku zdrowia 
- Update() – odejmowanie ilości zdrowia z pasku zdrowia 
Klasa HealthCollectible: 
- OnTriggerEnter2D(Collider2D collision) – dodanie zdrowia postaci gracza po kolizji z odpowiednim 
obiektem i usunięcie obiektu z planszy. 

8. Diagramy UML 

8.1. Diagram przypadków użycia

<>

8.2. Diagram czynności / aktywności
Diagram aktywności przedstawiający system podnoszenia przez gracza obiektów HealthCollectible:

<>

Diagram aktywności przedstawiający system walki w grze: 

<>


9. Literatura 
Dokumentacja dla twórców aplikacji na system operacyjny Android 
https://developer.android.com/docs


