//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Help Commands, by Blnukem.
// Note to other ACCM Devs, this method is best for telling clients each command
// and it is pretty clean. Although it can be a pain when adding new commands,
// but I'll be doing that, not you guys. (Since Eolk will fuck it up [Again])
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------


function ccSquadHelp(%sender, %args){
   messageClient(%sender, "", "\c3/CreateSquad [Name] \c2- Create your own squad. (Sergeant Rank Required)");
   messageClient(%sender, "", "\c3/S [Text] \c2- Privatly Chat with your squad.");
   messageClient(%sender, "", "\c3/LeaveSquad \c2- Leave the squad you are in.");
   messageClient(%sender, "", "\c3/Invite [PlayerName] \c2- Invite a person to your Squad.");
   messageClient(%sender, "", "\c3/RequestInvite [SquadName] \c2- Request an Invite to a Squad.");
   messageClient(%sender, "", "\c3/Join \c2- Use this to accept an invite to a squad.");
   messageClient(%sender, "", "\c3/SOL \c2- Spawn around your squad's leader.");
   messageClient(%sender, "", "\c3/ListSquads \c2- Lists all squads in the server.");
   messageClient(%sender, "", "\c3/Force [Join/Leave] [SquadName] [PlayerName] \c2- Force a person to leave/join a squad. (General Rank Required)");
}

function ccRankHelp(%sender, %args){
   messageClient(%sender, "", "\c3/ItemRestrictions \c2- Gives a list of the weapons/packs that are restricted to ranks.");
   messageClient(%sender, "", "\c3/Top5 \c2- Gives a list of players with the highest ranks.");
   messageClient(%sender, "", "\c3/ListRanks \c2- Lists all the ranks and the points required to get that rank.");
   messageClient(%sender, "", "\c3/CheckStats \c2- Check your current rank and score.");
   messageClient(%sender, "", "\c3/CheckStats [PlayerName] \c2- Check the current rank and score of another person.");
}

function ccItemRestrictions(%sender, %args){
   messageClient(%sender, "", "\c3M79 Grenade Launcher \c2- Points Required:\c3 1250\c2 Rank Required:\c3 Specialist\c2.");
   messageClient(%sender, "", "\c3Gauss Cannon \c2- Points Required:\c3 4800\c2 Rank Required:\c3 Master Sergeant\c2.");
   messageClient(%sender, "", "\c3Napalm Mortar \c2- Points Required:\c3 6000\c2 Rank Required:\c3 Second Lieutenant\c2.");
   messageClient(%sender, "", "\c3Jet Booster Pack \c2- Points Required:\c3 2550\c2 Rank Required:\c3 Staff Sergeant\c2.");
   messageClient(%sender, "", "\c3Flame Turret Barrel \c2- Points Required:\c3 1800\c2 Rank Required:\c3 Sergeant\c2.");
}

function ccListRanks(%sender, %args){
   messageClient(%sender, "", "\c3Private\c2 - Points Required:\c3 250\c2.");
   messageClient(%sender, "", "\c3Private First Class\c2 - Points Required:\c3 500\c2.");
   messageClient(%sender, "", "\c3Corporal\c2 - Points Required:\c3 1250\c2.");
   messageClient(%sender, "", "\c3Specialist\c2 - Points Required:\c3 1800\c2.");
   messageClient(%sender, "", "\c3Sergeant\c2 - Points Required:\c3 2550\c2.");
   messageClient(%sender, "", "\c3Staff Sergeant\c2 - Points Required:\c3 3600\c2.");
   messageClient(%sender, "", "\c3Sergeant First Class\c2 - Points Required:\c3 4800\c2.");
   messageClient(%sender, "", "\c3Master Sergeant\c2 - Points Required:\c3 6000\c2.");
   messageClient(%sender, "", "\c3Second Lieutenant\c2 - Points Required:\c3 8500\c2.");
   messageClient(%sender, "", "\c3First Lieutenant\c2 - Points Required:\c3 9750\c2.");
   messageClient(%sender, "", "\c3Captian\c2 - Points Required:\c3 9750\c2.");
   messageClient(%sender, "", "\c3Major\c2 - Points Required:\c3 11000\c2.");
   messageClient(%sender, "", "\c3Lieutenant Colonel\c2 - Points Required:\c3 15500\c2.");
   messageClient(%sender, "", "\c3Colonel\c2 - Points Required:\c3 18500\c2.");
   messageClient(%sender, "", "\c3Brigadier General\c2 - Points Required:\c3 22500\c2.");
   messageClient(%sender, "", "\c3Major General\c2 - Points Required:\c3 30000\c2.");
   messageClient(%sender, "", "\c3Lieutenant General\c2 - Points Required:\c3 50000\c2.");
   messageClient(%sender, "", "\c3General\c2 - Points Required:\c3 75000\c2.");
   messageClient(%sender, "", "\c3General Of The Army\c2 - Points Required:\c3 90000\c2.");
}

function ccZombiePointHelp(%sender, %args){
   return;
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

      messageClient(%sender, "", "\c3/PlaceZombiePoint [SpawnName] [ZType] [Time] [MaxZombies] [ZombieLimit] \c2- Places an advanced zombie point.");
      messageClient(%sender, "", "\c3/ListZombieSpawns \c2- Lists all the advanced zombie points.");
      messageClient(%sender, "", "\c3/DisableSpawn [SpawnName] \c2- Disables an advanced zombie point by label.");
      messageClient(%sender, "", "\c3/DisableAllSpawns \c2- Disables all advanced zombie points.");
      messageClient(%sender, "", "\c3/EnableSpawn [SpawnName] \c2- Enables an advanced zombie point by label.");
      messageClient(%sender, "", "\c3/EnableAllSpawns \c2- Enables all advanced zombie points.");
      messageClient(%sender, "", "\c3/RemoveSpawn [SpawnName] \c2- Removes an advanced zombie spawn.");
      messageClient(%sender, "", "\c3/RemoveAllSpawns \c2- Removes all advanced zombie spawns.");
      messageClient(%sender, "", "\c3/GetStatus [SpawnName] \c2- Get the status of a an advanced zombie spawn by label.");
      messageClient(%sender, "", "\c3/MarkZombieSpawns \c2- Mark all zombie spawns.");
      messageClient(%sender, "", "\c3/SaveSpawns [Radius] [FileName.cs] \c2- Save all of the advanced zombie spawns whithin said radius to said filename.");
      messageClient(%sender, "", "\c3/LoadSpawns [Radius] [FileName.cs] \c2- Load zombie spawns whithin said filename.");
      messageClient(%sender, "", "\c3/ReplaceSpawn Type[Single/Radius/All] [Arg2] \c2- Replaces advanced spawns with regular spawns. Which ones get replaced depends solely on your input.");
}

function ccHelp(%sender, %args)
{
   %base = strlwr(getword(%args, 0));
   switch$(%base){
      case "":
         messageClient(%sender, "", "\c2Help command options:");
         messageClient(%sender, "", "\c3BasicCommands \c2- \c3BuildingOptions \c2- \c3AdminCommands \c2- \c3SACommands");
         messageClient(%sender, "", "\c3SentinelCommands \c2- \c3ZombieCommands \c2- \c3DroneCommands \c2- \c3QuickCommands");
         messageClient(%sender, "", "\c2Don't understand this command? Type:\c3 /Help Usage \c2to learn how it works.");
   }

   switch$(%base){
      case "Usage":
         messageClient(%sender, "", "\c0----------------------------------------------------------------------------------------------------------------------------------");
         messageClient(%sender, "", "\c2To use the help command simply type:\c3 /Help \c2then the option you wish to use.");
         messageClient(%sender, "", "\c2For Example, type this in global chat:\c3 /Help Test");
   }

   switch$(%base){
      case "Test":
         messageClient(%sender, "", "\c0----------------------------------------------------------------------------------------------------------------------------------");
         messageClient(%sender, "", "\c2Good, you succesfully used the\c3 /Help \c2command.");
         messageClient(%sender, "", "\c2You can also use Quick Commands if you don't feel like typing\c3 /Help \c2before each option.");
         messageClient(%sender, "", "\c2To see the list of Quick Commands, type:\c3 /Help QuickCommands");
   }
   
   switch$(%base){
      case "QuickCommands":
         messageClient(%sender, "", "\c3/BasicCMDS \c2- Basic Commands.");
         messageClient(%sender, "", "\c3/BuildOptions \c2- Building Options.");
         messageClient(%sender, "", "\c3/ZCMDS \c2- Zombie Commands.");
         messageClient(%sender, "", "\c3/SCMDS \c2- Sentinel Commands.");
         messageClient(%sender, "", "\c3/DCMDS \c2- Drone Commands.");
         messageClient(%sender, "", "\c3/AdminCMDS \c2- Admin Commands.");
         messageClient(%sender, "", "\c3/SACMDS \c2- Super Admin Commands.");
   }

   switch$(%base){
      case "BuildingOptions":
         messageClient(%sender, "", "\c2Use the building manager in the Lobby to save your pieces.");
         messageClient(%sender, "", "\c3/Delmypieces \c2- Delete all of your pieces.");
         messageClient(%sender, "", "\c3/Objectscale [X Y Z] \c2- Basic scaling function.");
         messageClient(%sender, "", "\c3/Getscale \c2- Get the scale of an object.");
         messageClient(%sender, "", "\c3/Pos [X Y Z] \c2- This will move an object in X Y Z format.");
         messageClient(%sender, "", "\c3/GetPos \c2- This gets the postition of an object.");
         messageClient(%sender, "", "\c3/RankHelp \c2- Tells you basic information on ranks.");
         messageClient(%sender, "", "\c3/SetFreq [#] \c2- Set your power frequency.");
         messageClient(%sender, "", "\c3/ObjectName [Name] \c2- Sets a name to a deployable.");
         messageClient(%sender, "", "\c3/Radius [Radius] \c2- Sets the radius for Switches/Tripwires.");
         messageClient(%sender, "", "\c3/Cloak \c2- Makes your pieces invisible.");
   }

   switch$(%base){
      case "BasicCommands":
         messageClient(%sender, "", "\c3![PlayerName] [Message] \c2- Private messaging.");
         messageClient(%sender, "", "\c3/Opendoor \c2- Point at a door and use this command to open it. (You can also use /Open)");
         messageClient(%sender, "", "\c3/Opendoor [Password] \c2- Point at a door and use this command to open it if it\'s passworded.");
         messageClient(%sender, "", "\c3/Setdoorpass [Password] \c2- Point at a door and use this to set it\'s password.");
         messageClient(%sender, "", "\c3/ChooseSpawn [#] \c2- Choose a selected spawnpoint to spawn there.");
         messageClient(%sender, "", "\c3/ListSpawns \c2- Displays all spawnpoints on your team.");
         messageClient(%sender, "", "\c3/Hack Help \c2- Tells you how to Hack enemy teleporters.");
         messageClient(%sender, "", "\c3/SquadHelp \c2- Tells you how to use squad commands.");
         messageClient(%sender, "", "\c3/RankHelp \c2- Tells you basic information on ranks.");
         messageClient(%sender, "", "\c3/Tips \c2- This will give you a random tip.");
   }

   switch$(%base){
      case "SentinelCommands":
      if (!%sender.isAdmin){
         messageClient(%sender, "", "\c2Only Admins can use this command. ~wfx/misc/misc.error.wav");
         %sender.player.scriptkill($DamageType::Idiocy);
      return;
   }
         messageClient(%sender, "", "\c2Command\'s Temporarily Disabled.");
      return;
   }

   switch$(%base){
      case "ZombieCommands":
      if ((!%sender.isAdmin) && (!%sender.isZombieKeeper)){
         messageClient(%sender, "", "\c2Only Admins or Zombie Keepers can use this command. ~wfx/misc/misc.error.wav");
         %sender.player.scriptkill($DamageType::Idiocy);
      return;
   }
         messageClient(%sender, "", "\c3/BuyZpack \c2- Buy a zombie pack.");
         messageClient(%sender, "", "\c3/MakeZLord [PlayerName] \c2- Make the person a lord zombie.");
         messageClient(%sender, "", "\c3/MakeRapier [PlayerName] \c2- Make the person a regular zombie.");
         messageClient(%sender, "", "\c3/Stalk [PlayerName] [ZType] Difficulty[Cool/Light/Medium/Heavy] \c2- Spawn zombies around a target.");
         messageClient(%sender, "", "\c3/Cure [PlayerName] \c2- Cures a person.");
         messageClient(%sender, "", "\c3/Infect [PlayerName] \c2- Infect the target with the zombie virus.");
         messageClient(%sender, "", "\c3/KillZombies \c2- Kills all zombies and infected.");
         messageClient(%sender, "", "\c3/ZDetectDist [Radius] \c2- Set how large the zombie detection distance is.");
         messageClient(%sender, "", "\c3/SemiInfect [PlayerName] \c2- Infect that person with the altrenative virus.");
//         messageClient(%sender, "", "\c3/ZombiePointHelp \c2- Displays commands fo advanced zombie spawn points.");
      return;
   }

   switch$(%base){
      case "DroneCommands":
      if (!%sender.isAdmin){
         messageClient(%sender, "", "\c2Only Admins can use this command. ~wfx/misc/misc.error.wav");
         %sender.player.scriptkill($DamageType::Idiocy);
      return;
   }
         messageClient(%sender, "", "\c3/DroneBattle [Single/Battle/Custom] \c2- Basic Command where you can spawn either single drones, full battles, or even customize battles.");
      return;
   }

   switch$(%base){
      case "AdminCommands":
      if (!%sender.isAdmin){
         messageClient(%sender, "", "\c2Only Admins can use this command. ~wfx/misc/misc.error.wav");
         %sender.player.scriptkill($DamageType::Idiocy);
      return;
   }
         messageClient(%sender, "", "\c3/JailPlayer [PlayerName] [Time] \c2- Sends a specified player to jail for a set amount of time.");
         messageClient(%sender, "", "\c3/AddTeam \c2- Add/Removes a second team.");
         messageClient(%sender, "", "\c3/Gag [PlayerName] [Time] \c2- Silences an annoying player.");
         messageClient(%sender, "", "\c3/CancelVote \c2- Cancels a vote.");
         messageClient(%sender, "", "\c3/DelPieces [PlayerName] \c2- Deletes a specified player\'s pieces.");
         messageClient(%sender, "", "\c3/Kill [PlayerName] \c2- Kill someone.");
         messageClient(%sender, "", "\c3/ChangeName [PlayerName] [NewName] \c2- Changes the target\'s name.");
         messageClient(%sender, "", "\c3/Goto [PlayerName] \c2- Go directly to a specified person.");
         messageClient(%sender, "", "\c3/Summon [PlayerName] \c2- Summon a specified person.");
         messageClient(%sender, "", "\c3/Moveto [X Y Z] \c2- Go directly to a desired location.");
         messageClient(%sender, "", "\c3/Moveme [X Y Z] \c2- Move on your X, Y or Z axis.");
         messageClient(%sender, "", "\c3/BottomPrint [Text] \c2- Send a message on the bottom of the screen.");
         messageClient(%sender, "", "\c3/CenterPrint [Text] \c2- Send a message in the center of the screen.");
         messageClient(%sender, "", "\c3/ForceTeamSpawn [TeamName] [SpawnNumber] \c2- Forces an entire team to spawn at one spawnpoint.");
         messageClient(%sender, "", "\c3/SaveBuilding [Radius] [FileName.cs] \c2- Save buildings in the server.");
         messageClient(%sender, "", "\c3/LoadBuilding [FileName.cs] \c2- Load a building file.");
         messageClient(%sender, "", "\c3/A [Message] \c2- Admin private messaging.");
         messageClient(%sender, "", "\c3/BuySCG \c2- Force a SCG into your inventory.");
         messageClient(%sender, "", "\c3/DeSmurf \c2- Remove a client\'s smurf name. And reset to their normal name.");
         messageClient(%sender, "", "\c3/Turrets \c2- Enables/disables turrets.");
      return;
   }

   switch$(%base){
      case "SACommands":
      if (!%sender.isSuperAdmin){
         messageClient(%sender, "", "\c2Only Super Admins can use this command. ~wfx/misc/misc.error.wav");
         %sender.player.scriptkill($DamageType::Idiocy);
      return;
   }
         messageClient(%sender, "", "\c3/Admin [PlayerName] \c2- Force someone to become Admin.");
         messageClient(%sender, "", "\c3/SuperAdmin [PlayerName] \c2- Force someone to become Super Admin.");
         messageClient(%sender, "", "\c3/Info [PlayerName] \c2- Get basic info on a specified player.");
         messageClient(%sender, "", "\c3/Echo [PlayerName] \c2- Silently mute someone without them knowing.");
         messageClient(%sender, "", "\c3/Shred [PlayerName] \c2- Put someone in the ACCM paper shredder.");
         messageClient(%sender, "", "\c3/SA [Message] \c2- Super Admin private messaging.");
      return;
   }
}
