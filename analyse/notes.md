# But de l'application

A partir d'un fichier JSON contenant les données extraites d'un script d'épisode de série quelconque,
ce logiciel simule les attractions/répulsions des différents personnages. Pour réaliser cela il se base
sur les propriétés physiques que l'on peut attribuer normalement à des êtres vivants comme le poids, le
déplacement, ...etc.

Ces propriétés vont donc être utiliser pour simuler les interactions au fil du temps entre les différents
protagonistes du script. Le traitement par les agents de ces informations résultera en plusieurs données de sorties
qui seront transmise en utilisant des socket à une autre application qui sera chargé de réaliser par exemple
un rendu.

Cette application fait partie du projet de TO52 réalisé au semestre d'automne 2018 par Nicolas Vincent et Thomas Gredin
sous la tutelle de Franck Gechter.

# Découpage de l'application

l'application se consstitue de trois parties distinctes ayant chacune une fonction précise :

+ Etape 1 : Ouverture et lecture des données JSON.
+ Etape 2 : Traitement des données par les agents au fil du temps pour simuler les différentes propriétés physiques suivant les 
    données sur les acteurs provennant du fichier d'entré (étape 1).
+ Etape 3 : Envoie des données de sortie des agents par socket à une application externe.

# Analyse : Etape 1

Librairie utilisé :
+ Json.hpp : expose une API suivant les standard de la STL pour manipuler des structures de données Json comme des conteneurs 
  de la STL.

Cette Etape consiste à récupérer les données généré par le logiciel de compréhension de scripts d'épisodes de série. Un épisode
est représenté par un fichier Json qui contient toutes les données nécessaires pour retracer toutes les interactions entre les
différents personnages de l'histoire.

A l'issue de cette étape nous aurons une structure de donnée refletant le traitement effectué pour obtenir le fichier Json et
permettant aux agents de commencer leurs simulations en fonctions des actions réalisés.

La structure de données prend la forme suivante :