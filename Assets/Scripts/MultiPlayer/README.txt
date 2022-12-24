


========Project changes==========
1 => I firstly added layers 4 layers of player and enemy and player shooting and enemy shooting
2 => changed the collsion detection in the physics manager 
3 => and minimised window option in built
4 => added lancher scene and gamescene
5 => seperated all the multiplayer files

=======Launcher scene==========
6 => added the launch scene and game scene to the build
7 => launcher.cs controlls all the actions in the laucher scene attached to canvas
8 => playerlistitem and roomlistitem for canvas intiating the list prefabs as per required

=========Game scene==========
9  => Multiplayer game scene will start only if room creator presses start not the joined one
10 => Room manager will take care of player spawning points and it only intiantes once scene loaded 
		it will generate the player manager
11 => Player Manager will spawn controll the player controller which are the 3 ships and this control health and score
12 => Player controller will take care of movements and shooting 
13 => Made a single (PlayerControllMultiplayer) script removing the controlls maker and player controller2
14 => Removed the controller1 script in playerControllMultiplayer
15 => Shooting Mutiplayer enables the player to shoot 
16 => Objects must kept resources folder if they want to intiate in the photon network
17 => So I kept the knob in the prefabs
18 => Photon views enables us to synchronise the movements along the network
19 => and Photon transform classic View is observed component by photon view of the gameObject
20 => Photon Network.destroy enabales to destroy the gameObject
21 => added 3 tags for ships
=========================
Things to do:
1 => calling damage RPC according to the ship tag
2 => player disconnects handling
3 => score system
4 => Instantiating the ships with props if required
5 => game finishing score table
