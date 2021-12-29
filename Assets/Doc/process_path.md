# Process path


## TODO

+ reprendre l'ui avec le nouveau input system
+ remplacement
+ désynchronisation
+ balayage
+ killer group
+ leaver
+ detection de nid
+ communication
+ minimap

## Done

+ survol
+ drones
+ drone
+ menu
+ ruche
+ arbres
+ Terrain


## Terrain

<https://www.youtube.com/watch?v=cLs3CGNV120&t=141>

MeshGeneratorProcedural map
vertices / triangles for MeshFilter.

Universal Rendering Processing
Shader Graph

Gradient applying to terrain

## Spawn tree

<https://www.youtube.com/watch?v=604lmtHhcQs&t=46s>

Random Rotation et adaptation aux changements du sol.

## Ruche

Separation dans une autre classe TreeWithNest permettant de créer une ruche (capsule).

## Menu

<https://github.com/jessynlbe/MenuUnity/blob/master/Assets/Scripts/Menu.cs>
Reprise du Projet de Jessy et Lucas comme source d'inspiration

Pause Menu
<https://www.youtube.com/watch?v=JivuXdrIHK0&t=648s>

Menu Scene
Loading to Simulation Menu

Settings menu
modification des paramèetres en live avec le toggle et la touche i

## drone

<https://www.youtube.com/watch?v=bqmH8lOZsWs&list=PL5V9qxkY_RnLyWVtxIbWY0ihiyOaAYoRr&index=6>
Prefab repris et generation light reflection

ctrl+shift+f : set la caméra sur la vue de la scene

credit inpie pixel

drone controller with input

-> with direction and directives.

- drone tueur qui va directement à des coordonnées
revoir le modèle mgi pour le déplacement goToXYZ
- drone patrouilleur qui va en ligne droite et qui vole à une certaine distance du sol