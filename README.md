!!Due to large size of the project, could not push to github. Instead, Link(s) are below:

demo Playing video:
https://www.youtube.com/watch?v=WuF4DPOqQtc&t=81s

Explanation:
I wanted to make a 2D platformer Horror game. So I tried to make some components, and was somewhat satisfied.
However, due to concept conflicts, the progression of the project got way too slow. 
Hence, I decided to leave this project for now and concentrate on other projects first.

What I worked at:
Using cc0 images I found from one of the game development sites, I made the maps, character animation and other systems in this game. However, I didnot draw/created any of the images used in this game.

!the background music is a BGM from the game called "Ender Lilies"! I do not own any rights with the music.

What I made and liked:
- Making dark atmosphere and some bright lights using light objects
- Monsters that detects the sound of the player
- the sound area that player is making changes depends on the behaviour of player - when player runs, the sound circle has larger radius and when player does not move, the sound circle has much smaller radius
- simple UI for stamina - line of below shows the current stamina of the player. When the player reaches 0 stamina, the player cannot run for a while.
- basic map design
    - I basically thought of making a horror game that player cannot resist against enemies, so was thinking of making player get damage(or die) whenever it collides with enemy objects. However, original problem I had with this map is that player cannot go around the enemy, which means there was no way to go through the enemy. Hence, after some research, I decided to make some more maps that have more than one bridges between each other, so even if player face an enemy from map A, player can proceed to the same direction by transpassing map B. 
-  Teleporter - player can go from map A to map B by interacting with this teleporter!
-  Monster movement - added inertia to their movement, so if player cross the enemy by jumping, enemy cannot turn back right away.
-  Hiding System - whenever player hides, the enemies cannot detect the player anymore. Visual Effect concept is from horror game called "Yomawari: Night Alone".

What can be improved:
- animation for enemies
- adding boss stage - boss stage(map) itself is ready, but boss object hasn't beem created yet
- more proper sound effect - when player is walking, there is a walk sound but that is only for temporary use.
- Better enemy chase algorythm - enemies are not chasing after player when player moves from a map to another map. After change, it is idle to make enemies chase the player even through the maps (except for some specific maps such as boss stage)
- more clear concept - concept of the game itself is conflicting quite a lot. I want to try making boss stage, but mostly boss stage is for fighting against boss, and I am thinking horror game is better when player cannot resist against the enemy. I need to organize the concept of the game first.
- Water effect - will add some water on map, which is a visual work.
- UI work - might will add some inventory system, and make clear that hiding spots are easily visible.
- etc.
