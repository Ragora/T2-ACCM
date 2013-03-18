//==============================================================================
// Mod Functions
//==============================================================================
//------------------------------------------------------------------------------
// Made by Blnukem.

function AutoBan(%client)
{
   MessageAll('MsgAdminForce', '\c3%1 \c2was automatically banned by the server.', %client.name);
   %client.player.scriptKill(0);
   %client.setDisconnectReason( "You have been automatically banned by the server." );
   %client.schedule(0, "delete");
   BanList::add(%client.guid, %client.getAddress(), $Host::BanTime);
}

//------------------------------------------------------------------------------
// Made by Blnukem and Dark Dragon DX.

function applyskin(%obj,%skin,%name)
{
   %obj.target = createTarget(%obj, %name, %skin, "Male1", '', 0, PlayerSensor);
   setTargetDataBlock(%obj.target, %obj.getDatablock());
   setTargetSensorData(%obj.target, PlayerSensor);
   setTargetSensorGroup(%obj.target, 6);
   setTargetSkin(%obj.target, %skin);
   setTargetName(%obj.target, addtaggedstring(%name));
}

//------------------------------------------------------------------------------
// Made by Blnukem.

function LoadDefaultSettings() {
   $Host::Cascade = 0;
   Call("EnableVehicles");
}

//------------------------------------------------------------------------------
// Made by Blnukem.

function ClearBasicTimer(%obj)
{
   if(isObject(%obj))
   {
      if(%obj.BasicTimer > 0)
      {
         %obj.BasicTimer -= 1;
         %obj.BasicTimerSchedule = Schedule(1000, 0, "ClearBasicTimer", %obj);
      }
   }
}

//------------------------------------------------------------------------------
// Originally by Eolk, revised by Blnukem.

function Cure(%args)
{
   %args.player.infected = 0;
   cancel(%args.player.infectedDamage);
   %args.player.infectedDamage = "";
   %args.player.beats = 0;
   %args.player.canZkill = 0;
   %args.player.hit = 0;
   cancel(%args.player.zombieAttackImpulse);
}

//------------------------------------------------------------------------------
// Unknown Author

function plnametocid(%name)
{
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %obj = ClientGroup.getObject(%i);
      %nametest = strlwr(%obj.namebase);
      %name = strlwr(%name);
      if(strstr(%nametest, %name) != -1)
         return %obj;
   }
   return 0;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function addToZombiePointGroup(%obj)
{
   %grp = nameToId("MissionCleanup/ZombiePoints");
   if(!isObject(%grp))
   {
      %grp = new SimGroup("ZombiePoints");
      MissionCleanup.add(%grp);
   }

   %grp.add(%obj);
}

//------------------------------------------------------------------------------
// Made by Eolk... Just supposed to make things pretty

function ZombiePoint::setStatus(%this, %status)
{
   %this.status = %status;
}

//------------------------------------------------------------------------------
// Made by Eolk... Long, isn't it?

function ZombiePoint::StartSpawnLoop(%this)
{
   if(%this.disabled)
      return;

   if(%this.maximumZombies != -1)
      %this.spawnedZombies++;

   if(%this.maximumZombies != -1 && (%this.spawnedZombies >= %this.maximumZombies))
   {
      %this.disabled = 1;
      return;
   }

   if(%this.zombieLimit != -1 && (getwordcount(%this.zombieList) >= %this.zombieLimit))
   {
      %this.zombieLoop = %this.schedule(%this.timeout * 1000, "StartSpawnLoop");
      return;
   }

   if(ZombieGroup.getCount() >= $Host::MaxZombies && $Host::MaxZombies != -1)
   {
      %this.zombieLoop = %this.schedule(%this.timeout * 1000, "StartSpawnLoop");
      return;
   }

   %test = %this.type;
   if(%this.type $= "random")
   {
      %num = getRandom(1, 5);
      if(%num == 2)
         %test = "ravenger";
      else if(%num == 3)
         %test = "lord";
      else if(%num == 4)
         %test = "demon";
      else if(%num == 5)
         %test = "rapier";
      else
         %test = "regular";
   }

   switch$(%test)
   {
      case "regular":
         %zombie = new Player() {
            datablock = "ZombieArmor";
         };
         applyskin(%zombie,'Zombie',"Zombie");

	 %type = 1;
      case "ravenger":
         %zombie = new Player() {
            datablock = "FZombieArmor";
         };
         applyskin(%zombie,'Zombie',"Ravenger Zombie");

	 %type = 2;
      case "lord":
         %zombie = new player(){
	    datablock = "LordZombieArmor";
   	 };
     applyskin(%zombie,'ZLord',"Zombie Lord");

	 %zombie.client = $zombie::Lclient;
	 %zombie.mountImage(ZHead, 3);
	 %zombie.mountImage(ZBack, 4);
	 %zombie.mountImage(ZDummyslotImg, 5);
	 %zombie.mountImage(ZDummyslotImg2, 6);
	 %zombie.firstFired = 0;
	 %zombie.canmove = 1;
	 %type = 3;

      case "demon":
         %zombie = new player(){
	    datablock = "DemonZombieArmor";
	 };
     applyskin(%zombie,'Zombie',"Demon Zombie");

	 %zombie.mountImage(ZdummyslotImg, 4);
	 %type = 4;

      case "rapier":
         %zombie = new player(){
	    datablock = "RapierZombieArmor";
	 };
     applyskin(%zombie,'Zombie',"Rapier Zombie");

	 %zombie.mountImage(ZWingImage, 3);
	 %zombie.mountImage(ZWingImage2, 4);
	 %zombie.setActionThread("scoutRoot",true);
	 %type = 5;
   }

   %zombie.type = %type;
   %zombie.setTransform(%this.spawnTransform);
   %zombie.team = 0;
   %zombie.canJump = 1;
   %zombie.hasTarget = 0;
   %zombie.isCompZomb = 1;
   if(%this.zombieLimit != -1)
   {
      %zombie.overwatcher = %this;
      %this.zombieList = listAdd(%this.zombieList, %zombie, -1);
   }

   AddToZombieGroup(%zombie);
   schedule(1000, %zombie, "ZSetRandomMove", %zombie);
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);

   %this.zombieLoop = %this.schedule(%this.timeout * 1000, "StartSpawnLoop");
   %this.setStatus("Spawning zombies.");
}

//------------------------------------------------------------------------------
// Made by Eolk.

function zombieSpawnByName(%name)
{
   %name = strlwr(%name);
   %grp = nameToId("MissionCleanup/ZombiePoints");
   if(!isObject(%grp))
      return 0;
   for(%i = 0; %i < %grp.getCount(); %i++)
   {
      %obj = %grp.getObject(%i);
      %objname = strlwr(%obj.label);
      if(%name $= %objname)
         return %obj;
   }
   return 0;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function AssignStalkMonitor(%target, %ztype, %stype)
{
   if(isObject(%target.stalkMonitor))
      return;

   %s = new ScriptObject()
   {
      class = StalkMonitor;
   };

   MissionCleanup.add(%s); // this kills any lingering ones at the mission end.

   // assign the necessary flags.
   %s.target = %target;
   // note: these are already strlwr()ed.
   %s.ztype = %ztype;
   %s.stype = %stype;

   // this is here mainly for a reminder...
//   %s.lastztype = "";
//   %s.laststype = "";
   %s.coolvar = "light";
   %s.coolcount = 0;
   %s.coolup = 1;

   // tag 'em.
   %target.stalkMonitor = %s;
}

// This is for easy time adjusting.
$SwarmLoopTime["heavy"] = 1000; // 1 second.
$SwarmLoopTime["medium"] = 5000; // 5 seconds.
$SwarmLoopTime["light"] = 10000; // 10 seconds.

//------------------------------------------------------------------------------
// Made by Eolk.

function StalkMonitor::StalkLoop(%this)
{
   if(!%this)
      return;

   %target = %this.target;
   if(!isObject(%target))
   {
      // Let's pack our bags and go. Our work is done here.
      %this.doneStalking();
      return;
   }

   if(!isObject(%target.player))
   {
      if(%this.stype !$= "cool")
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.stype], "StalkLoop");
      else // don't update. They were in observer.
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.coolvar], "StalkLoop");
      return;
   }

   if(ZombieGroup.getCount() >= $Host::MaxZombies && $Host::MaxZombies != -1)
   {
      if(%this.stype !$= "cool")
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.stype], "StalkLoop");
      else // don't update. There isn't an available zombie spot.
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.coolvar], "StalkLoop");
      return;
   }

   %monitor = %target.stalkMonitor;
   %test = %monitor.ztype;
   if(%test $= "random")
   {
      %num = getRandom(1, 5);
      if(%num == 2)
         %test = "ravenger";
      else if(%num == 3)
         %test = "lord";
      else if(%num == 4)
         %test = "demon";
      else if(%num == 5)
         %test = "rapier";
      else
         %test = "regular";
   }

   switch$(%test)
   {
      case "regular":
         %zombie = new Player() {
         datablock = "ZombieArmor";
         };
         applyskin(%zombie,'Zombie',"Zombie");

	 %type = 1;
      case "ravenger":
         %zombie = new Player() {
            datablock = "FZombieArmor";
         };
         applyskin(%zombie,'Zombie',"Ravenger Zombie");

	 %type = 2;
      case "lord":
         %zombie = new player(){
	    datablock = "LordZombieArmor";
   	 };
     applyskin(%zombie,'ZLord',"Zombie Lord");

	 %zombie.client = $zombie::Lclient;
	 %zombie.mountImage(ZHead, 3);
	 %zombie.mountImage(ZBack, 4);
	 %zombie.mountImage(ZDummyslotImg, 5);
	 %zombie.mountImage(ZDummyslotImg2, 6);
	 %zombie.firstFired = 0;
	 %zombie.canmove = 1;
	 %type = 3;

      case "demon":
         %zombie = new player(){
	    datablock = "DemonZombieArmor";
	 };
     applyskin(%zombie,'Zombie',"Demon Zombie");

	 %zombie.mountImage(ZdummyslotImg, 4);
	 %type = 4;

      case "rapier":
         %zombie = new player(){
	    datablock = "RapierZombieArmor";
	 };
     applyskin(%zombie,'Zombie',"Rapier Zombie");

	 %zombie.mountImage(ZWingImage, 3);
	 %zombie.mountImage(ZWingImage2, 4);
	 %zombie.setActionThread("scoutRoot",true);
	 %type = 5;
   }

   %zombie.type = %type;
   %pos = %target.player.position;
   // cheezy randomness. Should work.
   // TODO: Add a check for interior, etc. Look at alternateSpawn.
   %rand = getRandomB();
   if(%rand)
      %x = getword(%pos, 0) + getRandom(25, 100);
   else
      %x = getword(%pos, 0) - getRandom(25, 100);

   %rand = getRandomB();
   if(%rand)
      %y = getword(%pos, 1) + getRandom(25, 100);
   else
      %y = getword(%pos, 1) - getRandom(25, 100);
   %z = getTerrainHeight(%x SPC %y);

   %dapos = %x SPC %y SPC %z;
   %typeMasks = $TypeMasks::VehicleObjectType | $TypeMasks::MoveableObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::TurretObjectType;
   InitContainerRadiusSearch(%dapos, 2, %typeMasks);
   if(ContainerSearchNext != 0)
   {
      // This position isn't valid, let's not spawn this round.
      if(%this.stype !$= "cool")
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.stype], "StalkLoop");
      else // don't update. They were in observer.
         %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.coolvar], "StalkLoop");
      return;
   }

   %zombie.setTransform(%dapos SPC "1 0 0 0");
   %zombie.team = 0;
   %zombie.canJump = 1;
   %zombie.hasTarget = 0;
   %zombie.isCompZomb = 1;

   AddToZombieGroup(%zombie);
   schedule(1000, %zombie, "ZSetRandomMove", %zombie);
   schedule(1000, %zombie, "ZombieLookforTarget", %zombie);

   if(%this.stype !$= "cool")
      %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.stype], "StalkLoop");
   else
   {
      %this.UpdateCoolVariables();
      %this.stalkSchedule = %this.schedule($SwarmLoopTime[%this.coolvar], "StalkLoop");
   }
}

$StalkCoolTime["light"] = 10; // 100 seconds of boredom. :P
$StalkCoolTime["medium"] = 15; // 75 seconds of balanced zombie invasions.
$StalkCoolTime["heavy"] = 30; // 30 seconds of pure heck. :)

//------------------------------------------------------------------------------
// Made by Eolk.

function StalkMonitor::UpdateCoolVariables(%this)
{
   %this.coolcount++;
   if(%this.coolcount >= ($StalkCoolTime[%this.coolvar] + 1)) // Add an extra to it so that the amount of times actually gets done.
   {
      %this.coolcount = 0;
      if(%this.coolvar $= "light")
      {
         %this.coolvar = "medium";
         %this.coolup = 1;
      }
      else if(%this.coolvar $= "medium")
      {
         if(%this.coolup == 1)
            %this.coolvar = "heavy";
         else
            %this.coolvar = "light";
      }
      else if(%this.coolvar $= "heavy")
      {
         %this.coolvar = "medium";
         %this.coolup = 0;
      }
      else
         error(%this @": Cannot update cooldown count. Unknown coolvar.");
   }
}

//------------------------------------------------------------------------------
// Made by Eolk.

function StalkMonitor::doneStalking(%this)
{
//   echo(%this @": Done stalking. Terminating...");
   cancel(%this.stalkSchedule);
   %this.stalkSchedule = "";
   %this.target.stalkMonitor = "";

   %this.schedule(500, "delete");
}

//------------------------------------------------------------------------------
// Made by Eolk.

function opposite(%num)
{
   return %num * -1;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function SimObject::isTSStaticObject(%obj)
{
   // If it doesn't have a shape name, then it definately ain't.
   if(%obj.shapeName $= "")
      return 0;

   for(%i = 0; %i < $NumStaticTSObjects; %i++)
   {
      if(getword($StaticTSObjects[%i], 2) $= %obj.shapeName)
         return 1;
   }

   return 0;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ZombieGetRandom()
{
   %rand = getRandom();
   if(%rand > 0.9)
      return 1; // Lord Zombie
   else if(%rand <= 0.8 && %rand >= 0.7)
      return 2; // Rapier
   else
      return 0; // Regular
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ClearSaveTimeout(%cl)
{
   if(isObject(%cl))
   {
      if(%cl.saveTimeout > 0)
      {
         %cl.saveTimeout -= 1;
         %cl.saveTimeoutSchedule = schedule(1000, 0, "ClearSaveTimeout", %cl);
      }
   }
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ClearLoadTimeout(%cl)
{
   if(isObject(%cl))
   {
      if(%cl.loadTimeout > 0)
      {
         %cl.loadTimeout -= 1;
         %cl.loadTimeoutSchedule = schedule(1000, 0, "ClearLoadTimeout", %cl);
      }
   }
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ReverseGetRot(%rot, %mult)
{
   %x = getword(%rot, 0) / %mult;
   %y = getword(%rot, 1) / %mult;
   %z = getword(%rot, 2) / %mult;
   return %x SPC %y SPC %z SPC %mult;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ACCMChatLog(%client, %msg, %type, %target)
{
   if($Host::ACCMChatLogging != 1 && $Host::ACCMEchoChat != 1)
      return;

   %msg = stripChars(%msg, "\c0\c1\c2\c3\c4\c5\c6\c7\c8\c9\x10\x11");
   switch$(%type)
   {
      case 0:
         %t = "[GLOBAL]";
      case 1:
         %t = "[TEAM]";
      case 2:
         %t = "[PRIVATE]";
   }

   %logdate = formattimestring("m-d-y");
   %dir = "ServerLogs/Chat/Log of "@%logdate@".log";
   if($Host::ACCMChatLogging == 1)
   {
      %temp = new FileObject();
      %temp.openforappend(%dir);
      %temp.writeline(%t @" ("@formattimestring("D m/d/y hh:nn a")@") "@%client.nameBase @""@ (%t $= "[PRIVATE]" ? " (to "@%target.nameBase@")" : "")@": "@%msg);
      %temp.close();
      %temp.delete();
   }

   if($Host::ACCMEchoChat == 1)
      echo(%t @" ("@formattimestring("D m/d/y hh:nn a")@") "@%client.nameBase @""@ (%t $= "[PRIVATE]" ? " (to "@%target.nameBase@")" : "")@": "@%msg);
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ACCMConnectionLog(%client, %type, %reason)
{
   if($Host::ACCMConnectionLogging != 1)
      return;

   if(%client.nameBase $= "Sentinel" || %client.nameBase $= "Monitor")
      return;

   if(%reason $= "")
      %reason = "Successful manual disconnect.";

   switch$(%type)
   {
      case "connect":
         %t = "joined the server";
      case "disconnect":
         %t = "disconnected from the server (reason: "@%reason@")";
      default:
         error("ACCMConnectionLog: %type turned up unknown value. Report this!");
         return;
   }

   %logdate = formattimestring("m-d-y");
   %dir = "ServerLogs/Connections/Log of "@%logdate@".log";
   %authInfo = %client.getAuthInfo();
   if($playingonline)
      %str = "[ONLINE] "@formattimestring("D m/d/y hh:nn a")@" (GUID: "@%client.guid@", REAL NAME: "@getField(%authInfo, 0)@", SMURF: "@%client.isSmurf@", "@%client.getAddress()@") "@%client.nameBase@" "@%t@".";
   else
      %str = "[OFFLINE] "@formattimestring("D m/d/y hh:nn a")@" ("@%client.getAddress()@") "@%client.nameBase@" "@%t@".";
   %temp = new FileObject();
   %temp.openforappend(%dir);
   %temp.writeline(%str);
   %temp.close();
   %temp.delete();
   logEcho(%str);
}

//------------------------------------------------------------------------------
// Made by Eolk.

function VectorCheck(%vec)
{
   if(getword(%vec, 0) > 0)
      %x = 1;
   else if(getword(%vec, 0) < 0)
      %x = -1;
   else
      %x = 0;
   if(getword(%vec, 1) > 0)
      %y = 1;
   else if(getword(%vec, 1) < 0)
      %y = -1;
   else
      %y = 0;
   if(getword(%vec, 2) > 0)
      %z = 1;
   else if(getword(%vec, 2) < 0)
      %z = -1;
   else
      %z = 0;
   return %x SPC %y SPC %z;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function VectorPositive(%vec)
{
   if(getword(%vec, 0) < 0)
      %x = opposite(getword(%vec, 0));
   else
      %x = getword(%vec, 0);
   if(getword(%vec, 1) < 0)
      %y = opposite(getword(%vec, 1));
   else
      %y = getword(%vec, 1);
   if(getword(%vec, 2) < 0)
      %z = opposite(getword(%vec, 2));
   else
      %z = getword(%vec, 2);
   return %x SPC %y SPC %z;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function VectorAdd2(%vec, %adder)
{
   if(getword(%vec, 0) != 0)
      %new1 = getword(%vec, 0) + %adder;
   else
      %new1 = 0;
   if(getword(%vec, 1) != 0)
      %new2 = getword(%vec, 1) + %adder;
   else
      %new2 = 0;
   if(getword(%vec, 2) != 0)
      %new3 = getword(%vec, 2) + %adder;
   else
      %new3 = 0;
   return %new1 SPC %new2 SPC %new3;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function CheckGUID(%client)
{
   if(!$playingonline)
   {
      error("CheckGUID: This does not work offline!");
      return;
   }

   %authinfo = %client.getAuthInfo();
   %guid = getField(%authinfo, 3);
   return %guid;
}

//------------------------------------------------------------------------------
// Made by Eolk.

function CreateWaypoint(%pos, %name)
{
	%w = new WayPoint() {
		datablock = WayPointMarker;
		name = %name;
	};

	%w.setTransform(%pos SPC "0 0 1 0");
	%w.team = 0;

	MissionCleanup.add(%w);
	%w.schedule(10000, "delete");
}

//------------------------------------------------------------------------------
// Made by Eolk.

function ChangeName(%client, %name)
{
	if(%name $= "reset")
	{
		if(%client.oldName !$= "")
		{
			removeTaggedString(%client.name);
			%client.name = "";
			%client.name = addTaggedString(%client.oldname);

			setTargetName(%client.target, addTaggedString(%client.oldName));
			messageAll('MsgClientNameChanged', "", "", %client.name, %client);
			%client.oldname = "";
			return;
		}
	}

	if(%client.oldName $= "")
		%client.oldName = getTaggedString(%client.name);

	removeTaggedString(%client.name);
	%client.name = "";
	%realname = "\x10\c6"@%name@"\x11";
	%client.name = addTaggedString(%realname);

	setTargetName(%client.target, addTaggedString(%realname));
	messageAll('MsgClientNameChanged', "", %client.oldname, %client.name, %client);
}
