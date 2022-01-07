# ProjectHornetNestDetection

Using Unity in C# scripts, a map is generated with a nest in the trees. A swarm patrol to find it and destroy it.

## Description du scenario

Il était une fois, une belle forêt avec des arbres polygonaux très jolis. Parmi ces plantes majestueuses se trouvait un vilain nid de frelon asiatique qui était très difficile à détecter.
Or par un beau jour, un joueur appuya sur le bouton play. Un essaim de drone patrouilleurs se réveilla et débuta son périple visant à détecter le fameux nid.
Durant leur quadrillage, un des drones déclencha un trigger avec la hitbox céleste du logis des frelons ! D'un seul coup, un drone tueur apparut. Il s'éleva de la plateforme de son spawn pour voler en direction des coordonnées transmises par le drone patrouilleur, ce héros qui avait survolé la cible.

Une fois au dessus de la demeure des frelons asiatiques, le drone kamikaze se laissa tomber enclenchant un décompte d'une bombe meurtrière.
Le drone emporta alors dans le souffle de son explosion, le nid de frelons asiatique tant redouté.

Fin.  

## Explication d'au moins un concept de Unity

Le concept que je tenais à expliquer était celui de la génération de terrain dite procédural.
Triangles, vertices, lacunarity
Pour avoir un terrain, il faut de nombreux carrés. Pour faire un carré, il faut 2 triangles. Les sommets des triangles sont appelés vertices.
Avec des hauteurs variantes sur les vertices on arrive à obtenir du volume sur le terrain. 

## Description projet (cf projet boids)

- Une petite explication sur ce qu'est la détection de drone et en quoi ça nous intéresse
    La détection de drone passe par le quadrillage d'une zone, les drones peuvent être à une altitude constante mais dans le cadre de mon projet,
    j'ai fais  en sorte qu'ils soient à une distance limite et si ils se trouvent être en dessous de cette distance, ils prennent alors de l'altitude et ceux individuellement. Avec cette méthode, le terrain se doit d'être rectangulaire pour que les drones puissent faire chacun une zone équivalente afin d'avoir un parcours optimisé de la zone.
    Ce méthode est intéressante car dans le cadre de la détection, il y a de nombreuses applications comme par exemple, la détection de failles dans une cuve par exemple où il faut alors quadriller les parois.

- Résumé / Description de ce que vous avez retenu sur ce projet
    Mesh Generation, ui, poo en c#, pitch yaw roll forces, input system, colliders, raycasting, shaders, gizmos, physics de unity

- une description du projet : qu'est ce qu'il se passe dans ce projet
    Un terrain est dabord instantié selon des paramètres de lacunarité et de scale. Des arbres sont instanciés avec un offset aléatoire aux vertices du mesh du terrain. Une capsule étant la ruche dans la simulation spawn dans un arbre aléatoirement, cet arbre devient un object TreeWithNest pour que ce soit plus facile à manipuler. Dans le menu des paramètres on peut modifier la carte à la volée mais aussi en relancant le jeu
    Pour ce qui est des drones, en fait on parle que de un prefabs qui est multiplié par la suite. Il y a une carte d'input action sur le prefab de drone avec des box colliders sur chaque moteurs. Une rotation est appliqué selon les inputs que l'on envoie au drone. Ce qui fait que pour donner un chemin à suivre à un drone, dans le fichier [Path Controller](Assets/Scripts/Drones/Path/PathController.cs) il y a toute les méthodes utilisant des inputs factices pour pouvoir diriger un drone à un point particulier. Les méthodes sont je l'avoue un peu bidouiller car ce n'est pas précis pour atteindre un point (modèle MGI houleux). Néanmoins la méthode de rotation utilisée pour faire des demi tour à droite ou à gauche est assez précise et nette.
    Le prefab du drone patrouilleur contient un script de quadrillage suivant ce shéma :
    5 étapes :
      - étape 0 : le drone s'élève du sol pour l'étape du début
      - étape 1 : le drone va tout droit jusqu'au bout de la map avec ajustement de hauteur par rapport au raycasting du drone à la forêt
      - étape 2 : il fait demi-tour sur la droite, ce qui lui suffisamment d'impulsion pour se décaler en x.
      - étape 3 : il va tout droit jusqu'au début de la map
      - étape 4 : il fait un demi-tour sur la gauche et pareil, il n'a pas besoin de se déplacer en x. A la fin de cette étape on revient à la 1.
    Ce préfab de drone patrouilleur est donc instantié n fois le nombre de drone voulu à spawn.
    Pour ce qui est du drone tueur, il est activé avec un `goTo(nest.coordinates)` pour ainsi dire dès lors que la hitBox de la ruche qui est élévée vers le ciel est trigger. Et pour ce drone à l'étape 2, il descend et au bout de 3 secondes une explosion a lieu, causant un destroy du drone et de la capsule jaune.

- Liste des tâches / fonctionnalités dans le projet
  - Terrain
  - ruche
  - menu pause, settings, principal, bac à sable
  - drone
  - drones
  - minimap : pas le temps
  - balayage
  - drone tueur

- Liste des scripts et affectation à quel GameObject
  - [MapGenerator.cs](Assets/Scripts/MapGenerator.cs) associé à un EmptyGameObject, fait spawn les arbres, le mesh et créé la ruche avec son arbre
  - [Settings.cs](Assets/Scripts/Settings.cs) associé à l'antenne, sert de base de donnée dans l'architecture
  - [MainMenu.cs](Assets/Scripts/Menus/MainMenu.cs) associé au menu principal pour les boutons de `sandbox` et `simulation`
  - [SimulationMenu.cs](Assets/Scripts/Menus/SimulationMenu.cs) associé au menu de pause de la simulation, redirige vers le menu principal, celui des reglages, fait reprendre la simulation ou bien quitte le jeu
  - [SandBoxMenu.cs](Assets/Scripts/Menus/SandBoxMenu.cs) associé au menu du bac à sable permettant de rejoindre le menu principal et de reprendre la manipulation du drone
  - [SettingsMenu.cs](Assets/Scripts/Menus/SettingsMenu.cs) associé au menu des paramètres et permet de retourner au menu précédant, le reload n'étant pas au point.
  - [Dossier Sliders](Assets/Scripts/Sliders) associés aux sliders dans le menu de paramètres
  - [DroneSpawner.cs](Assets/Scripts/Drones/DroneSpawner.cs) associé à la platerforme de spawn des drones, et d'après un nombre de drones défini par l'utilisateur, fait spawn ce nombre
  - [PathController.cs](Assets/Scripts/Drones/Path/PathController.cs)
  - [DronePatrol.cs](Assets/Scripts/Drones/Path/DronePatrol.cs)
  - [DroneKiller.cs](Assets/Scripts/Drones/Path/DroneKiller.cs)
  - [DroneInputs.cs](Assets/Scripts/Drones/Controller/DroneInputs.cs)
  - [DroneController.cs](Assets/Scripts/Drones/Controller/DroneController.cs)
  
- comment une entité répond à la "rencontre" d'une autre entité (tir ? (quelle portée ? qu'est ce qui est détruit ? qui tire (toutes les entités d'un groupe ou uniquement celles qui ne détectent pas une entité amie devant elle) fuite ? séparation du groupe ? certaines entités tirent et les autres se tirent ? (désolée pour le mauvais jeu de mot) combinaison de tout ça ? récupération d'entités adverses ?) 


- la façon de les spawn dans l'environnement
  

- la façon de gérer les collisions :
  Mesh collider sur les arbres et la map
  Sphere et box collider sur les drones donc il y a des collisions physiques entre tout les objets physiques
  Sauf entre la hitbox de la ruche qui est une sphere collider avec isTrigger activé.s


- Liste de ce que vous vous êtes amusés à faire en plus et que vous voulez valoriser 
  amélioration de la visualisation de la scène etc, je sais que vous êtes créatifs :-)

- liens vers les ressources