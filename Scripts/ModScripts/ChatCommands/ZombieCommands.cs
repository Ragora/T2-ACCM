//------------------------------------------------------------------------------
// Zombie Commands:
//------------------------------------------------------------------------------

if($Host::KeepersGetMakerAbility $= "")
   $Host::KeepersGetMakerAbility = 1;

if($Host::AllowKeeperPlayerVotes $= "")
   $Host::AllowKeeperPlayerVotes = 1;

// CCM Dev Team
function ccBuyZPack(%sender,%args)
{
   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2Zombies are prohibited in Construction.");
      return;
   }

   if((%sender.isAdmin || %sender.isSuperAdmin || %sender.isZombieKeeper) && isObject(%sender.player))
   {
      if(%sender.player.getMountedImage($Backpackslot) !$= "")
         %sender.getControlObject().throwPack();
      %sender.player.setinventory(ZSpawnDeployable, 1, true);
      messageClient(%sender, "", "\c2Be sure to only make a few zombie spawns, not a million.");
   }
}

// Eolk
function ccInfect(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot infect someone in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target.player))
   {
      messageClient(%sender, 'MsgYes', "\c2Target player does not exist.");
      return;
   }

   if (%target==%sender)
   {
      %target.player.Infected = 1;
      %target.player.InfectedLoop = schedule(10, %target.player, "InfectLoop", %target.player);
      messageClient(%sender, 'MsgYes', "\c2You have Infected yourself with the Zombie virus!");
      logEcho(%sender.nameBase@" ("@%sender@") remotely infected self");
      return;
   }

   %target.player.Infected = 1;
   %target.player.InfectedLoop = schedule(10, %target.player, "InfectLoop", %target.player);
   messageClient(%target, 'MsgYes', "\c2You've been injected with the zombie infection!");
   messageClient(%sender, 'MsgYes', "\c2You've infected: \c3"@%target.nameBase@" \c2with the zombie virus.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely infected "@%target.nameBase@" ("@%target@")");
}

// Eolk
function ccMakeZombie(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot make a person a Zombie in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%target == %sender)
   {
      makePersonZombie(%target.player.getTransform(), %target, 0);
      messageClient(%sender, "MsgAdminForce", "\c2You made yourself into a Zombie.");
      logEcho(%sender.nameBase@" ("@%sender@") remotely made self a zombie");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target.player))
   {
      messageClient(%sender, 'MsgYes', "\c2Target player does not exist.");
      return;
   }

   MakePersonZombie(%target.player.getTransform(), %target, 0);
   messageClient(%sender, "MsgAdminForce", "\c2You made\c3 "@%target.nameBase@" \c2a Zombie.");
   messageClient(%target, "MsgAdminForce", "\c3"@%sender.nameBase@" \c2has made you a Zombie.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely made "@%target.nameBase@" ("@%target@") a zombie");
}

// Eolk
function ccMakeZLord(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot make a person a Zombie Lord in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%target == %sender)
   {
      makePersonZombie(%target.player.getTransform(), %target, 1);
      messageClient(%sender, "MsgAdminForce", "\c2You made yourself into a Zombie Lord.");
      logEcho(%sender.nameBase@" ("@%sender@") remotely made self a zombie lord");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target.player))
   {
      messageClient(%sender, 'MsgYes', '\c2Target player does not exist.');
      return;
   }
   if(%target.player.getMountedImage($Weaponslot) !$= "")
      %target.getControlObject().throwWeapon();
   makePersonZombie(%target.player.getTransform(), %target, 1);
   messageClient(%sender, "MsgAdminForce", "\c2You made\c3 "@%target.nameBase@" \c2a Zombie Lord.");
   messageClient(%target, "MsgAdminForce", "\c3"@%sender.nameBase@" \c2has made you a Zombie Lord.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely made "@%target.nameBase@" ("@%target@") a zombie lord");
}

// Eolk
function ccMakeRapier(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot make a person a Zombie Rapier in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%target == %sender)
   {
      makePersonZombie(%target.player.getTransform(), %target, 2);
      messageClient(%sender, "MsgAdminForce", "\c2You made yourself into a Zombie Rapier.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely made self a zombie rapier");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target.player))
   {
      messageClient(%sender, 'MsgYes', '\c2Target player does not exist.');
      return;
   }

   makePersonZombie(%target.player.getTransform(), %target, 2);
   messageClient(%sender, "MsgAdminForce", "\c2You made\c3 "@%target.nameBase@" \c2a Zombie Rapier.");
   messageClient(%target, "MsgAdminForce", "\c3"@%sender.nameBase@" \c2has made you a Zombie Rapier.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely made "@%target.nameBase@" ("@%target@") a zombie rapier");
}

// Eolk
function ccMakeDemon(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot make a person a Demon in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%target == %sender)
   {
      makePersonZombie(%target.player.getTransform(), %target, 3);
      messageClient(%sender, "MsgAdminForce", "\c2You made yourself into a Demon.");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target.player))
   {
      messageClient(%sender, 'MsgYes', '\c2Target player does not exist.');
      return;
   }

   if(%target.player.getMountedImage($Weaponslot) !$= "")
      %target.getControlObject().throwWeapon();

   makePersonZombie(%target.player.getTransform(), %target, 3);
   messageClient(%sender, "MsgAdminForce", "\c2You made\c3 "@%target.nameBase@" \c2a Demon.");
   messageClient(%target, "MsgAdminForce", "\c3"@%sender.nameBase@" \c2has made you a Demon.");
}

// Eolk/Blnukem
function ccKillZombies(%sender)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   MessageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has killed all of the zombies and cured all infected people.");
   logEcho(%sender.nameBase@" ("@%sender@") killed all zombies and cured all infected people");
   %zgroup = nameToID("MissionCleanup/ZombieGroup");
   %zcount = %zgroup.getCount();
   for (%i = 0; %i < %zcount; %i++)
   {
      %zombie = %zgroup.getObject(%i);
      if (isObject(%zombie))
      {
         if (%obj.infected || strstr(%zombie.getDatablock().getName(), "Zombie") != -1)
         {
            %zombie.scriptkill($DamageType::Idiocy);
         }
      }
   }
   
   %ccount = ClientGroup.GetCount();
   for(%i = 0; %i < %ccount; %i++)
   {
      %client = ClientGroup.getObject(%i);
      if (isObject(%client))
      {
         if (%client.player.infected)
         {
            MessageClient(%Client, "Msg", "\c2You were cured of the zombie virus.");
            Cure(%client);
            logEcho(%client.nameBase@" was cured via ccKillZombies");
         }
      }
   }
}

// Eolk
function ccPlaceZombiePoint(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot place Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame" && !%sender.isMapAdmin)
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   %name = firstword(%args);
   %ztype = strlwr(getword(%args, 1));
   %time = getword(%args, 2);
   %maxzombs = getword(%args, 3);
   %limitzombs = getword(%args, 4);
   if(%name $= "")
   {
      messageClient(%sender, "MsgNo", "\c2Invalid Name. Must be lower than 25 characters.");
      return;
   }

   // I figured out we should do this after the check.
   %name = stripchars(%name, " ");
   %name = getsubstr(%name, 0, 25); // Ha, ha!

   if(%ztype !$= "regular" && %ztype !$= "ravenger" && %ztype !$= "lord" && %ztype !$= "demon" && %ztype !$= "rapier" && %ztype !$= "random") // TODO: make progressive AI.
   {
      messageClient(%sender, "MsgNo", "\c2Invalid zombie type. Types are regular, ravenger, lord, demon, rapier, and random.");
      return;
   }

   if(%time < 4 || %time > 60)
   {
      messageClient(%sender, "MsgNo", "\c2That time is invalid. Must be more than four but less than sixty.");
      return;
   }

   if(%maxzombs $= "" || %maxzombs == 0 || %maxzombs < -1)
   {
      messageClient(%sender, "MsgNo", "\c2Invalid number of zombies. Must be more than 0. Enter -1 for infinite.");
      return;
   }

   if(%limitzombs == 0 || %limitzombs < -1)
   {
      messageClient(%sender, "MsgNo", "\c2Invalid zombie limit. Must be more than 0. Enter -1 for infinite.");
      return;
   }

   %obj = new ScriptObject()
   {
      class = "ZombiePoint";
   };

   //////////////////////////////////////
   // Note: Anything added here must be /
   // considered in the save function! //
   //////////////////////////////////////
   %obj.spawnTransform = %sender.player.getTransform();
   %obj.type = %ztype;
   %obj.timeout = %time;
   %obj.label = %name;
   %obj.maximumZombies = %maxzombs;
   %obj.zombieLimit = %limitzombs;
   %obj.disabled = 1; // disabled by default. Since we don't have a global variable anymore, we have to do this...
   %obj.zombieList = "";
   addToZombiePointGroup(%obj);
   messageClient(%sender, "MsgYes", "\c2Zombie Spawn point placed successfully.");
}

// Eolk
function ccListZombieSpawns(%sender)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   messageClient(%sender, "MsgZombie", "\c2Zombie Spawn Points:");
   %genericCount = 0;
   %count = 0;
   %grp = nameToId("MissionCleanup/ZombiePoints");
   if(!isObject(%grp))
   {
      messageClient(%sender, "MsgZombie", "\c2Currently none.");
      return;
   }

   for(%i = 0; %i < %grp.getCount(); %i++)
   {
      %obj = %grp.getObject(%i);
      %name = %obj.label;
      if(%name $= "") // there's no name...
      {
         %name = "GenericSpawnName"@%genericCount; // grab a generic one...
         %obj.label = %name;
         %genericCount++;
      }

      if((strlen(%list[%count]) + strlen(%name)) > 256) // if will be more than 256...
      {
         %count++;
         %list[%count] = %name; // add a new variable and smack the name there...
      }
      else // if it won't be more than 256...
         %list[%count] = %list[%count] SPC %name; // just smack it with the others...
   }

   // Ok, now that that is done, we output it...
   for(%x = 0; %list[%x] !$= ""; %x++)
   {
      messageClient(%sender, "MsgZombie", %list[%x]);
   }
}

// Eolk
function ccDisableSpawn(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%args $= "")
   {
      messageClient(%sender, "MsgNo", "\c2Invalid label.");
      return;
   }

   %obj = zombieSpawnByName(%args);
   if(%obj == 0)
   {
      messageClient(%sender, "MsgNo", "\c2Spawn does not exist.");
      return;
   }

   %obj.disabled = 1;
   if(isEventPending(%obj.zombieLoop))
      cancel(%obj.zombieLoop);

   %obj.zombieLoop = "";
   messageClient(%sender, "msgYes", "\c2Point\c3 "@%args@" ("@%obj@") \c2has been disabled.");
   %obj.setStatus("Disabled by user request.");
}

// Eolk
function ccDisableAllSpawns(%sender)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame" && !%sender.isMapAdmin)
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   // The old method of toggling a global variable was taken out...
   // this new way is more compatible with other functions, and a lot more flexible...
   %grp = nameToId("MissionCleanup/ZombiePoints");
   for(%i = 0; %i < %grp.getCount(); %i++)
   {
      %obj = %grp.getObject(%i);
      if(isEventPending(%obj.zombieLoop))
         cancel(%obj.zombieLoop);
      %obj.disabled = 1;
   }

   messageClient(%sender, "MsgYes", "\c2All points have been disabled.");
}

// Eolk
function ccEnableSpawn(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%args $= "")
   {
      messageClient(%sender, "MsgNo", "\c2Invalid label.");
      return;
   }

   %obj = zombieSpawnByName(%args);
   if(%obj == 0)
   {
      messageClient(%sender, "MsgNo", "\c2Spawn does not exist.");
      return;
   }

   %obj.disabled = 0;
   %obj.spawnedZombies = 0;
   %obj.StartSpawnLoop();

   messageClient(%sender, "MsgYes", "\c2Point\c3 "@%args@" ("@%obj@") \c2has been enabled.");
}

// Eolk
function ccEnableAllSpawns(%sender)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame" && !%sender.isMapAdmin)
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   // The old method of toggling a global variable was taken out...
   // this new way is more compatible with other functions, and a lot more flexible...
   %grp = nameToId("MissionCleanup/ZombiePoints");
   for(%i = 0; %i < %grp.getCount(); %i++)
   {
      %obj = %grp.getObject(%i);
      %obj.disabled = 0;
      %obj.spawnedZombies = 0;
      %obj.StartSpawnLoop();
   }

   messageClient(%sender, "MsgYes", "\c2All points have been enabled.");
}

// Eolk
function ccRemoveSpawn(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if($CurrentMission $= "Affliction")
   {
      messageClient(%sender, "", "\c2You cannot remove zombie spawns on this map.");
      return;
   }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%args $= "")
   {
      messageClient(%sender, "MsgNo", "\c2Invalid label.");
      return;
   }

   %obj = zombieSpawnByName(%args);
   if(%obj == 0)
   {
      messageClient(%sender, "MsgNo", "\c2Spawn does not exist.");
      return;
   }

   if(isEventPending(%obj.zombieLoop))
      cancel(%obj.zombieLoop);

   for(%i = -1; %i < getwordcount(%obj.zombieList); %i++)
   {
      %zombie = getword(%obj.zombieList, %i);
      if(isObject(%zombie))
         %zombie.scriptkill(0);
   }

   %obj.schedule(500, "delete");
   messageClient(%sender, "MsgYes", "\c2Point\c3 "@%args@" ("@%obj@") \c2has been removed.");
}

// Eolk
function ccRemoveAllSpawns(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if($CurrentMission $= "Affliction")
   {
      messageClient(%sender, "", "\c2You cannot remove zombie spawns on this map.");
      return;
   }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   %group = nameToID("MissionCleanup/ZombiePoints");
   if(!isObject(%group))
   {
      messageClient(%sender, "MsgNo", "\c2There are no points to remove!");
      return;
   }

   for(%i = 0; %i < %group.getCount(); %i++)
   {
      %obj = %group.getObject(%i);
      ccRemoveSpawn(%sender, %obj.label);
   }
}

// Eolk
function ccGetStatus(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%args $= "")
   {
      messageClient(%sender, "MsgNo", "\c2Invalid label.");
      return;
   }

   %obj = zombieSpawnByName(%args);
   if(%obj == 0)
   {
      messageClient(%sender, "MsgNo", "\c2Spawn does not exist.");
      return;
   }

   messageClient(%sender, "MsgYes", "\c2Status of point\c3 "@%args@" ("@%obj@")\c2:");
   messageClient(%sender, "MsgYes", "\c2Current Status:\c3 "@%obj.status@" \c2(\c3"@(%obj.disabled == 1 ? "disabled" : "enabled")@"\c2), Zombie Spawning Position:\c3 "@posFromTransform(%obj.spawnTransform)@"\c2, Zombie Spawning Rotation:\c3 "@rotFromTransform(%obj.spawnTransform)@"\c2...");
   messageClient(%sender, "MsgYes", "\c2Zombie Type:\c3 "@%obj.type@"\c2, Maximum Zombies:\c3 "@%obj.maximumZombies@"\c2, Already Spawned Zombies:\c3 "@%obj.spawnedZombies@"\c2, Timeout Between Spawn:\c3 "@%obj.timeout@"\c2, Child Zombies:\c3 "@getwordcount(%obj.zombieList)@"\c2.");
}

// Eolk
function ccMarkZombieSpawns(%sender, %args)
{
   if(!%sender.isAdmin && !%sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2There shouldn\'t be any Zombie Spawn points in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   %group = nameToID("MissionCleanup/ZombieWaypoints");
   if(!$SpawnsMarked)
   {
      if(!isObject(%group))
      {
         %group = new SimGroup("ZombieWaypoints");
         MissionCleanup.add(%group);
      }

      %grp = nameToId("MissionCleanup/ZombiePoints");
      if(!isObject(%grp))
      {
         messageClient(%sender, "MsgZombie", "\c2There are no spawn points.");
         $SpawnsMarked = 0; // This is in case of error in mission cleanup. The group gets deleted.
         return;
      }

      for(%x = 0; %x < %grp.getCount(); %x++)
      {
         %point = %grp.getObject(%x);
         %o = new WayPoint() {
            position = posFromTransform(%point.spawnTransform);
            rotation = rotFromTransform(%point.spawnTransform);
            scale = "1 1 1";
            dataBlock = "WayPointMarker";
            name = %point.label;
            team = "0";
         };

         %group.add(%o);
      }

      $SpawnsMarked = 1;
      messageAll("MsgAdminForce", "\c3"@%sender.nameBase@" \c2has marked all zombie spawns.");
   }
   else
   {
      if(!isObject(%group))
      {
         messageClient(%sender, "MsgNo", "\c2Zombie waypoint group not found (probably because markers have not been placed yet). Cannot remove markers.");
         return;
      }

      for(%i = 0; %i < %group.getCount(); %i++)
      {
         %obj = %group.getObject(%i);
         %obj.schedule(500, "delete");
      }

      $SpawnsMarked = 0;
      messageAll("MsgAdminForce", "\c3"@%sender.nameBase@" \c2has removed all the zombie spawn markers.");
   }
}

// Eolk
function ccStalk(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2Stalking has been disabled in Construction.");
      return;
   }

   %target = plnametocid(getword(%args, 0));
   if(!isObject(%target))
   {
      messageClient(%sender, 'MsgNo', '\c2Unable to find specified target.');
      return;
   }

   if(isObject(%target.stalkMonitor))
   {
      %target.stalkMonitor.doneStalking();
      messageClient(%sender, 'MsgYes', '\c3%1 \c2is now no longer being stalked.', %target.nameBase);
      return;
   }

   %zombies = strlwr(getword(%args, 1));
   if(%zombies !$= "regular" && %zombies !$= "ravenger" && %zombies !$= "lord" && %zombies !$= "demon" && %zombies !$= "rapier" && %zombies !$= "random")
   {
      messageClient(%sender, 'MsgNo', '\c2Invalid zombie type. The zombie types are regular, ravenger, lord, demon, and rapier. You may also type random for a randomized zombie type upon spawn.');
      return;
   }

   %swarm = strlwr(getword(%args, 2));
   if(%swarm !$= "light" && %swarm !$= "medium" && %swarm !$= "heavy" && %swarm !$= "random" && %swarm !$= "cool")
   {
      messageClient(%sender, 'MsgNo', '\c2Invalid swarm type. The valid types are light, medium, and heavy. Random may also be used, and Cool may be used if you want the swarm to go up, then down again.');
      return;
   }

   AssignStalkMonitor(%target, %zombies, %swarm);
   %target.stalkMonitor.stalkLoop();
   messageClient(%sender, 'MsgYes', '\c3%1 \c2is now being stalked.', %target.nameBase);
   logEcho(%sender.nameBase@" ("@%sender@") is stalking "@%target.nameBase@" ("@%target@")");
}

// Eolk
function ccSemiInfect(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot infect someone in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame")
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   if(%args $= "")
      %args = %sender.nameBase;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "MsgNo", "\c2Unable to find target.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageClient(%sender, "MsgNo", "\c2Target has no player object.");
      return;
   }

   if(%target.isJailed)
   {
      messageClient(%sender, "MsgNo", "\c2Target is jailed.");
      return;
   }

   if(%target.infected)
   {
      messageClient(%sender, "MsgNo", "\c2Cannot perform upon infected people.");
      return;
   }

   if(%target.player.isZombie)
   {
      messageClient(%sender, "MsgNo", "\c2Cannot perform upon zombies.");
      return;
   }

   %target.player.canZKill = 1;
   ZombieBloodLust(%target.player, 0);
   messageClient(%target, "MsgYes", "\c2You caught the alternative virus. You still look human, but you can infect others.");
   messageClient(%sender, "MsgYes", "\c2Infecting\c3 "@%target.nameBase@" \c2with the alternative zombie virus.");
   logEcho(%sender.nameBase@" ("@%sender@") remotely semi-infected "@%target.nameBase@" ("@%target@")");
}

// Eolk/Blnukem
function ccCure(%sender, %args)
{
   if(!%sender.isAdmin)
      if((%sender.isZombieKeeper && !$Host::KeepersGetMakerAbility) || !%sender.isZombieKeeper)
      {
         messageClient(%sender, "", "\c2This option has been disabled for keepers.");
         return;
      }

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2Curing has been disabled since there should be no Zombies in Construction.");
      return;
   }

   if(Game.class $= "ZombieGame" && !%sender.isMapAdmin)
   {
      messageClient(%sender, "", "\c2A game is currently in progress.");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Cannot find target.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageClient(%sender, "", "\c2Target has no player object.");
      return;
   }

   if(!%target.player.infected)
   {
      messageClient(%sender, "", "\c2Target is not infected.");
      return;
   }

   Cure(%target);
   messageClient(%sender, "", "\c3"@%target.nameBase@" \c2has been cured.");
   messageClient(%target, "", "\c2You were cured of the zombie virus!");
   logEcho(%sender.nameBase@" ("@%sender@") remotely infected "@%target.nameBase@" ("@%target@")");
}

// Eolk
function ccSaveSpawns(%sender, %args)
{
   return;
   if(!%sender.isAdmin && %sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot Save Zombie Spawns in Construction.");
      return;
   }

   %radius = getword(%args, 0);
   %filename = getword(%args, 1);

   if(%radius < 1)
      %radius = 1000000;
   if(%filename $= "")
   {
      messageClient(%sender, "", "\c2You need to specify a filename!");
      return;
   }

   if(!isObject(%sender.player))
      if(isObject(%sender.camera))
         %transform = %sender.camera.getTransform();
      else
      {
         messageClient(%sender, "", "\c2You have to have a camera or a player to do this.");
         return;
      }
   else
      %transform = %sender.player.getTransform();

   %dir = "ZombieSpawns/"@%filename;
   %obj = new FileObject();
   if(%obj.openforwrite(%dir))
   {
      %obj.writeLine("// ZOMBIE POINT SAVE FILE");
      %obj.writeLine("// Saved in "@$ACCMVersion@".");
      %obj.writeLine("// Saved by "@%sender.nameBase@" (GUID: "@%sender.guid@")"); // Prone to mistakes.
      %obj.writeLine("// Code begins below:");

      %pos = posFromTransform(%transform);
      %grp = nameToId("MissionCleanup/ZombiePoints");
      for(%i = 0; %i < %grp.getCount(); %i++)
      {
         %point = %grp.getObject(%i);
         if(VectorDist(%pos, posFromTransform(%point.spawnTransform)) < %radius)
         {
            %spawnT = %point.spawnTransform;
            %type = %point.type;
            %time = %point.timeout;
            %label = %point.label;
            %maxZombs = %point.maximumZombies;
            %limZombs = %point.zombieLimit;

            // Maybe I should just use .save();
            %obj.writeline("%n = new ScriptObject() {");
            %obj.writeline("   class = \"ZombiePoint\";");
            %obj.writeline("};");
            %obj.writeline("%n.spawnTransform = \""@%spawnT@"\";");
            %obj.writeline("%n.type = \""@%type@"\";");
            %obj.writeline("%n.timeout = \""@%time@"\";");
            %obj.writeline("%n.label = \""@%label@"\";");
            %obj.writeline("%n.maximumZombies = \""@%maxZombs@"\";");
            %obj.writeline("%n.zombieLimit = \""@%limZombs@"\";");
            %obj.writeline("%n.disabled = \"1\";"); // Automatically disabled.
            %obj.writeline("addToZombiePointGroup(%n);");
         }
      }
   }
   else
      messageClient(%sender, "", "\c2Error opening file.");
   %obj.close();
   %obj.delete();
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2is saving a zombie spawnpoint file.");
}

// Eolk
function ccLoadSpawns(%sender, %args)
{
   return;
   if(!%sender.isAdmin && %sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot load Zombie Spawns in Construction.");
      return;
   }

   %dir = "ZombieSpawns/"@%args;
   if(isFile(%dir))
   {
      compile(%dir);
      exec(%dir);
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2is attempting to load a zombie spawnpoint file.");
   }
   else
      messageClient(%sender, "", "\c2Invalid file.");
}

// Eolk
function ccReplaceSpawn(%sender, %args)
{
   if(!%sender.isAdmin && %sender.isZombieKeeper)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot replace Zombie Spawns in Construction.");
      return;
   }

   %type = strlwr(getword(%args, 0));
   if(%type !$= "single" && %type !$= "Radius" && %type !$= "all")
   {
      messageClient(%sender, "", "\c2Invalid type. Must be either\c3 Single \c2[For one point]), \c3radius \c2[For points whithin a radius around you], or\c3 All \c2[For all points].");
      return;
   }

   if(%type $= "single")
   {
      %arg2 = zombieSpawnByName(getword(%args, 1));
      if(!%arg2)
      {
         messageClient(%sender, "", "\c2Spawn doesn't exist.");
         return;
      }
   }
   else if(%type $= "radius" && %arg2 < 1)
   {
      messageClient(%sender, "", "\c2Invalid radius.");
      return;
   }

   // Unification. Will waste resources for singles, but, it's easier for me to program.
   for(%i = 0; %i < ZombiePoints.getCount(); %i++)
   {
      %doit = 0;
      %spawn = ZombiePoints.getObject(%i);

      // Eolk - brackets must be used here.
      if(%type $= "single")
      {
         if(%spawn.label $= %spawn)
            %doit = 1;
      }
      else if(%type $= "radius")
      {
         if(VectorDist(posFromTransform(%spawn.spawnTransform), posFromTransform(%sender.player.getTransform())) < %arg2)
            %doit = 1;
      }
      else if(%type $= "all")
         %doit = 1;

      if(%doit == 1)
      {
         %deplObj = new StaticShape() {
            datablock = "DeployedZSpawnBase";
         };

         %deplObj.setTransform(%spawn.spawnTransform); // I couldn't believe that worked.

         // set the recharge rate right away
         if (%deplObj.getDatablock().rechargeRate)
            %deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

         // set team, owner, and handle
         %deplObj.team = %sender.team;
         %deplObj.setOwner(%sender.player);
         %deplObj.light.lightBase = %deplObj;

         // set the sensor group if it needs one
         if (%deplObj.getTarget() != -1)
            setTargetSensorGroup(%deplObj.getTarget(), %sender.team);

         // place the deployable in the MissionCleanup/Deployables group (AI reasons)
         addToDeployGroup(%deplObj);

         //let the AI know as well...
         AIDeployObject(%plyr.client, %deplObj);

         // Eolk - DON'T play the sound.

         // increment the team count for this deployed object
         $TeamDeployedCount[%sender.team, %item.item]++;

         addDSurface(%item.surface,%deplObj);

         %deplObj.playThread($PowerThread,"Power");
         %deplObj.playThread($AmbientThread,"ambient");

         // set power frequency
         %deplObj.powerFreq = %plyr.powerFreq;

         // Power object
         checkPowerObject(%deplObj);

         if(%spawn.ztype $= "regular" || %spawn.ztype $= "random") // I took the easy way out.
            %deplObj.ZType = 1;
         else if(%spawn.ztype $= "ravenger")
            %deplObj.ZType = 2;
         else if(%spawn.ztype $= "lord")
            %deplObj.zType = 3;
         else if(%spawn.ztype $= "demon")
            %deplObj.zType = 4;
         else if(%spawn.ztype $= "rapier")
            %deplObj.zType = 5;
         %deplObj.numZ = %spawn.zombieLimit; // Note: It isn't maximum zombies. Trust me.
         if(%spawn.maximumZombies <= 1)
            %deplObj.spawnTypeSet = 1;
         else
            %deplObj.spawnTypeSet = 0;

         %label = %spawn.label;
         ccRemoveSpawn(%sender, %spawn.label);
         if(%type $= "single")
         {
            messageClient(%sender, "", "\c3"@%label@" \c2has been replaced with a regular zombie spawn.");
            break;
         }
      }
   }

   if(%type $= "radius")
      messageClient(%sender, "", "\c2All spawns whithin\c3 "@%arg2@" \c2meters have been replaced with regular zombie spawns.");
   else if(%type $= "all")
      messageClient(%sender, "", "\c2All advanced zombie spawns have been replaced with regular zombie spawns.");
}

// Eolk
function cczombieteam(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2You cannot make a Zombie Team in Construction.");
      return;
   }

   if(%args != 1 && %args != 2 && %args != 0)
   {
      messageClient(%sender, "MsgNo", "\c2Invalid Parameters. Must be either team 1 or team 2. Enter 0 for reset.");
      return;
   }

   if(%param == 0)
   {
      %temp = (%param == 0 ? 'none' : %param);
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2changed \c3ZOMBIE TEAM \c2to \c3"@%temp@"\c2.");
      $ZombieTeam = 0;
      cckillzombies(%sender);
      logEcho(%sender.nameBase@" ("@%sender@") changed zombie team to "@(%param == 0 ? "non" : %param)@" and killed all the zombies");
      return;
   }

   if(Game.numTeams < 2)
   {
      messageClient(%sender, "MsgNo", "\c2There must be at least two teams. You may use /addteam to make another team.");
      return;
   }

   $ZombieTeam = %args;
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %cl = ClientGroup.getObject(%i);
      if(isObject(%cl.player) && !%cl.isAIControlled())
         game.ForceObserver(%cl, "AdminForce");
   }

   %temp = (%param == 0 ? 'none' : %param);
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has changed the zombie team to\c3 "@(%param == 0 ? 'none' : %param)@"\c2.");
   logEcho(%sender.nameBase@" ("@%sender@") changed the zombie team to "@(%param == 0 ? "none" : %param));
}

// Blnukem
function ccZDetectDist(%sender, %args){
   if(!%sender.isAdmin)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2This cannot be changed in Construction.");
      return;
   }

   if(%args > 10000 || %args < 0){
      messageClient(%sender, 'MsgNo', '\c2Invalid detect distance. Must be 10000 or less or 0 or More.');
      return;
   }

   if(strlwr(%args) $= "get"){
      messageClient(%sender, 'MsgNo', '\c2Current Detection Distance:\c3 %1\c2.', $zombie::detectDist);
      return;
   }

   %old = $zombie::detectDist;
   %rad = %args;
   if(strlwr(%args) $= "infinite")
   %rad = 10000;
   if(strlwr(%args) $= "none")
   %rad = 0;

   if(%rad == %old){
      messageClient(%sender, 'MsgNo', '\c2The Zombie Detect Distance is Currently the Specified Argument:\c3 %1\c2.', %old);
      return;
   }

   $zombie::detectDist = %rad;
      messageAll('MsgAdminForce', '\c2The Zombie Detection Distance has been Changed from: \c3%1 \c2to \c3%2.', %old, %rad);
   logEcho(%sender.nameBase@" ("@%sender@") changed the zombie detection distance to "@$zombie::detectDist);
   }

//------------------------------------------------------------------------------
