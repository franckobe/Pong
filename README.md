# Pong

## Commandes
Pour déplacer le pad : Q pour aller à gauche, D pour aller à droite.
Pour lancer la balle appuyer sur Espace.


Pour démarrer une nouvelle partie, appuyez sur espace.

## Déroulement du jeu
Il faut déplacer le pad afin de renvoyer la balle dans le camp adverse.
Des obstacles mouvants sont placés au milieu du terrain pour ajouter une difficulté.
La vitesse de la balle augmente tous les deux coups.
Lorsque la balle entre en contact avec le mur placé derrière le joueur adverse, vous marquez un point.
Le premier joueur arrivé à 3 points a gagné la partie.

## Etats
### 1.Début de partie
Dans cet état, la partie est initialisé, les scores sont mis à 0.
### 2. Initialisation
Cet état intervient au lancement du jeu, et lorsqu'un point a été inscrit. La balle est replacée au milieu.


En appuyant sur la touche Espace, la balle est lancée et on passe à l'état 3.
### 3. Echanges
Cet état intervient lorsque la balle se déplace entre les deux joueurs. 


Lorsqu'un joueur inscrit un point, on passe à l'état 4.
### 4. Point inscrit
Cet état intervient lorsque la balle entre en contact avec le mur placé derrière un joueur. 
A ce moment là, le score du joueur ayant marqué est incrémenté, un message apparait pendant une seconde pour 
préciser quel joueur a marqué, puis le jeu repasse en l'état 2.
### 4. Fin de la partie
Cet état intervient lorqu'un joueur atteint le score maximum. Un message apparait pour signaler que la partie est terminée 
et quel joueur a gagné. 


Lorsque l'on appuie sur la touche Espace, on relance une partie, donc on repasse à l'état 1.
