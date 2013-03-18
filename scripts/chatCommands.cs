//==============================================================================
// Chat Commands - Made by Blnukem and Eolk.
//------------------------------------------------------------------------------
// These basic chat commands were created by CCM and ACCM Dev teams.
// You may add additional commands here if you wish at the bottom of this file.
//------------------------------------------------------------------------------
// • The ACCM Chat Command database is located in another folder.
// • Make sure your new commands aren't abused or overpowered.
//==============================================================================

// This command was edited by Blnukem to work with ACCM.
function chatcommands(%sender, %message) {
   %cmd = getWord(%message,0);
   %cmd = stripChars(%cmd,"/");
   %count = getWordCount(%message);
   %args = getwords(%message,1);
   %cmd = "cc" @ %cmd;
   switch$(%cmd)
   {
      case "ccTips":
         call("ccTips", %sender, "Join", %args);
      case "ccOpen":
         call("ccOpendoor", %sender, %args);
      case "ccJoin" or "ccJoin":
         call("ccJoin", %sender, %sender.sqinv);
      case "ccDelmypieces":
         call("ccDelpieces", %sender, "");
      case "ccObjectScale" or "ccReSize" or "ccSetSize":
         call("ccSetScale", %sender, %args);
      case "ccGetSize":
         call("ccGetScale", %sender, %args);
      case "ccObjectName" or "ccSetName":
         call("ccName", %sender, %args);
      case "ccGetPos":
         call("ccPos", %sender, "G", %args);
      case "ccBasicCMDS" or "ccBasicCommands":
         call("ccHelp", %sender, "BasicCommands", %args);
      case "ccSCMDS" or "ccSentinelCommands":
         call("ccHelp", %sender, "SentinelCommands", %args);
      case "ccZCMDS" or "ccZombieCommands":
         call("ccHelp", %sender, "ZombieCommands", %args);
      case "ccDCMDS" or "ccDroneCommands":
         call("ccHelp", %sender, "DroneCommands", %args);
      case "ccBuildOptions" or "ccBuildingOptions":
         call("ccHelp", %sender, "BuildingOptions", %args);
      case "ccAdminCMDS" or "ccAdminCommands":
         call("ccHelp", %sender, "AdminCommands", %args);
      case "ccSACMDS" or "ccSACommands":
         call("ccHelp", %sender, "SACommands", %args);
      case "ccSetFreq":
         call("ccPower", %sender, %args);
      case "ccBuy":
         call("ccBf", %sender, %args);
      default:
         call(%cmd, %sender, %args);
   }
}

//==============================================================================
// The following was either made by the CCM or Construction development teams.
//==============================================================================

function VectToRot(%vec){
	%x = getWord(%vec, 0);
	%y = getWord(%vec, 1);
	%z = getWord(%vec, 2);
	%len = vectorLen(%vec);
	%rotAngleXY = mATan(%z, %len);
	%rotAngleZ = mATan(%x, %y);
	%matrix = MatrixCreateFromEuler("0 0" SPC %rotAngleZ * -1);
	%matrix2 = MatrixCreateFromEuler(%rotAngleXY SPC "0 0");
	%finalMat = MatrixMultiply(%matrix, %matrix2);
	return getWords(%finalMat, 3, 5)@" "@(getWord(%finalMat,6) * 360 / 3.14156);
}

function ccOpendoor(%sender,%args) {
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %classname;
   %cash       = %obj.amount;
   %owner      = %obj.owner;

   if(!isObject(%obj) || (!%obj.isDoor && %datablock.getName() !$= "DeployedDoor"))
   {
      messageclient(%sender, 'MsgClient', "\c2No door in range.");
      return;
   }

   %obj.issliding = 0;
   if (%obj.collisionType >= 1)
   {
      messageClient(%sender, "", "\c2This door is a collision-type door.");
      return;
   }

   if (%obj.powercontrol >= 1)
   {
      messageclient(%sender, 'MsgClient', "\c2This door is controlled by a power supply.");
      return;
   }

   if (%obj.canmove == false) //if it cant move
      return;                  //stop here

   %pass = %args;
   if (%obj.pw $= %pass) {
   	if (%obj.toggletype ==1){
         if (%obj.moving $="close" || %obj.moving $="" || %going $="opening"){
         	schedule(10,0,"open",%obj);
      }
      else if (%obj.moving $="open" || %going $="closeing"){
           schedule(10,0,"close",%obj);
      }
   }
   else
       schedule(10,0,"open",%obj);
   }
   if (%obj.pw !$= %pass)
      messageclient(%sender,'MsgClient',"\c2Password Denied.");
}

function ccSetdoorpass(%sender,%args){
   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);
   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if (!%obj.isDoor && %datablock.getName !$= "DeployedDoor") {
   messageclient(%sender, 'MsgClient', '\c2No door in range.');
      return;
   }
   if (%obj.owner!=%sender && %obj.owner !$="")
	messageclient(%sender, 'MsgClient', '\c2You do not own this door.');
   if (!isobject(%obj))
	messageclient(%sender, 'MsgClient', '\c2No door in range.');
   if (%obj.Collision $= true) {
	messageclient(%sender, 'MsgClient', '\c2Collision doors can not have passwords.');
   	return;
   }
   if(isobject(%obj) && %obj.owner==%sender) {
	%pw=getword(%args,0);
	%obj.pw=%pw;
	messageclient(%sender, 'MsgClient', '\c2Password set, password is\c3 %1\c2.',%pw);
   }
}

function ccGetAmmo(%sender,%args){
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::VehicleObjectType,%sender.player);
   if(%obj != ""){
   	%obj        = getword(%obj,0);
   	%className  = %obj.getClassName();
	%Name		= %obj.getDatablock().getName();
	if(%className $= "WheeledVehicle" && %Name $= "AmmoCrateVeh"){
	   if(%obj.numReload >= 2){
		buyDeployableFavorites(%sender);
		%obj.numReload--;
	   }
	   else if(%obj.numReload == 1){
		buyDeployableFavorites(%sender);
		%obj.schedule(1000, delete);
	   }
	}
   }	
}

function ccHack(%sender, %args){
   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,10));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %classname;
   %DBname	   = %datablock.getName();
   if(%args $= "help"){
	messageClient(%sender, 'MsgClient', "\c2To hack you must guess the 4 digit binary code for each of the numbers in a randomly generated 5 digit code.");
	messageClient(%sender, 'MsgClient', "\c2EX: /hack - you have 2 ones in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 0 1 1 - you have 2 correct in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 1 0 1 - you have 2 correct in this code.");
	messageClient(%sender, 'MsgClient', "\c2... /hack 0 1 1 0 - you have got this number and you have 4 codes left to go.");
	return;
   }
   if (!isobject(%obj)) {
      messageclient(%sender, 'MsgClient', '\c2No teleport in range.');
      return;
   }
   if (%DBname !$= "TelePadDeployedBase") {
      messageclient(%sender, 'MsgClient', '\c2No teleport in range.');
      return;
   }

   if(%obj.team == %sender.team)
   {
      messageClient(%sender, "", "\c2You can't hack your own team's teleports!");
      return;
   }

   if(%obj.ishacked != 1){
	if(%args $= ""){
	   %numones = 0;
	   for(%i = 0; %i < 4; %i++){
		if(getWord(%obj.hackcode[(%obj.numhacked + 1)],%i) $= "1")
		   %numones++;
	   }
	   messageClient(%sender, 'MsgClient', "\c2There are "@ %numones @" ones in this code, and you have "@ (5 - %obj.numhacked) @" more codes to find.");
	}
	else{
	   %numsame = 0;
	   for(%i = 0; %i < 4; %i++){
		if(getWord(%obj.hackcode[(%obj.numhacked + 1)],%i) $= getWord(%args,%i))
		   %numsame++;
	   }
	   if(%numsame == 4){
		if(%obj.numhacked $= "")
		   %obj.numhacked = 0;
		%obj.numhacked++;
		if(%obj.numhacked == 5){
		   %obj.ishacked = 1;
		   messageClient(%sender, 'MsgClient', "\c2You have hacked this teleport.");
		   return;
		}
		messageClient(%sender, 'MsgClient', "\c2You have got this number you have "@(5 - %obj.numhacked)@" codes left to go.");
	   }
	   else
		messageClient(%sender, 'MsgClient', "\c2You have "@%numsame@" of the code correct.");
	}
   }
   else
      messageClient(%sender, "" ,"\c2This teleport is already hacked.");
}

function teleresethack(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.ishacked == 1 || %obj.ishacked $= ""){
	%obj.ishacked = 0;
	%obj.numhacked = 0;
	%num[0] = "0 0 0 0";
	%num[1] = "0 0 0 1";
	%num[2] = "0 0 1 0";
	%num[3] = "0 0 1 1";
	%num[4] = "0 1 0 0";
	%num[5] = "0 1 0 1";
	%num[6] = "0 1 1 0";
	%num[7] = "0 1 1 1";
	%num[8] = "1 0 0 0";
	%num[9] = "1 0 0 1";
	for(%i = 1; %i < 6; %i++){
	   %random = getRandom(0,9);
	   %obj.hackcode[%i] = %num[%random];
	}
   }
   schedule(180000, %obj, "teleresethack", %obj);
}

function ccListSpawns(%sender){
   if(%sender.team == 0)
	return;
   %team = %sender.team;
   for(%i = 0; %i < $teamSPs[%team]; %i++){
	if($teamSP[%team,%i].name $= "")
	   $teamSP[%team,%i].name = getWords($teamSP[%team,%i].getPosition(),0,1);
	messageClient(%sender, 'MsgClient', "\c2"@(%i + 1)@". spawnpoint "@$teamSP[%team,%i].name@".");
   }
}

function ccChooseSpawn(%sender,%args){
   %team = %sender.team;
   if(%team == 0)
	return;

   if($UseForcedTeamSpawn[%team] && !%sender.isAdmin)
   {
      messageClient(%sender, 'MsgClient', '\c2Your spawnpoint was forced by an admin. You cannot switch.');
      return;
   }

   if(%args $= ""){
	if(%sender.SP !$= ""){
	   %sender.SP = "";
	   messageClient(%sender, 'MsgClient', "\c2Spawn Point Reset, you will now spawn at the normal location.");
	   return;
	}
	messageClient(%sender, 'MsgClient', "\c2Please choose a number that corresponds with a spawnpoint.");
	return;
   }
   %num = (firstWord(%args) - 1);
   if(isObject($teamSP[%team,%num])){
	if($teamSP[%team,%num].active == 1){
	   %sender.SP = $teamSP[%team,%num];
	   messageClient(%sender, 'MsgClient', "\c2Spawnpoint "@$teamSP[%team,%i].name@" choosen.");
	}
	else{
	   %sender.SP = $teamSP[%team,%num];
	   messageClient(%sender, 'MsgClient', "\c2Spawnpoint "@$teamSP[%team,%i].name@" choosen, but this point is not currently powered.");
	}
   }
   else
	messageClient(%sender, 'MsgClient', "\c2This spawnpoint dosent exist.");
}

//==============================================================================
// All of the following are the public ACCM Chat Commands.
//------------------------------------------------------------------------------
// The following functions were made by Blnukem.
//==============================================================================
function ccMenu (%sender, %args)
{
   %arg1 = getWord(%args, 0);
   if (%arg1 $= "Join")
   {
      CenterPrint(%sender, "<font:Sui Generis:14><color:ffffff><a:U>Advanced Combat Construction Mod</a> \n <font:Hey:14>ACCM Developers: <Color:888888>Blnukem, Eolk, and Dark Dragon DX. \n <Color:ffffff>Website:<Color:888888> http://www.freewebs.com/advancedccm", 10, 3);
      if ($Host::MOTD !$= "")
      {
      Schedule(5000, 0, "CenterPrint", %sender, "<font:Sui Generis:14><color:ffffff><a:U>Message of the Day.</a> \n <Font:Hey:14> <Color:888888> "@$Host::MOTD@" ", 5 , 3);
      Schedule(5000, 0, "MessageClient", %sender, "Msg", "\c2A message from "@$Host::GameName@" Administration:\n"@$Host::MOTD@"");
      }
   }
}

// Blnukem - This will tell the sender basic information on the target.

function ccInfo(%sender, %args)
{
   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Cannot find player:\c3 "@%args@"\c2.");
      return;
   }

   if(%target $= "")
   {
      messageClient(%sender, "", "\c2Please specify a person.");
      return;
   }

   %rank = $Rank::Rank[%target.ranknum];
   %score = $Rank::Score[%target.ranknum];
   %smurf = (%target.isSmurf == 1 ? "Yes" : "No");
   %keeper = (%target.isZombieKeeper == 1 ? "Yes" : "No");
   %admin = (%target.isAdmin == 1 ? "Yes" : "No");
   %superadmin = (%target.isSuperAdmin == 1 ? "Yes" : "No");
   messageClient(%sender, "", "\c2Client Name:\c3 "@%target.nameBase@"\c2 - GUID:\c3 "@%target.guid@"\c2 - Player ID:\c3 "@%target@"");
   messageClient(%sender, "", "\c2Smurf:\c3 "@%smurf@"\c2 - Zombie Keeper:\c3 "@%keeper@"\c2 - \c2Admin:\c3 "@%admin@"\c2 - Super Admin:\c3 "@%superadmin@"");
   if($Rank::Squad[%target.ranknum] $= "")
   {
      messageClient(%sender, 'MsgClient', "\c2Current Squad:\c3 None\c2 - Current Rank:\c3 "@%rank@"\c2 - Total Score:\c3 "@%score@"");
   } else for(%i = 0; %i < $squad::numsquads; %i++) {
      %squad = $Squad::Name[%i];
      messageClient(%sender, 'MsgClient', "\c2Current Squad:\c3 "@%squad@"\c2 - Current Rank:\c3 "@%rank@"\c2 - Total Score:\c3 "@%score@"");
   }
}

//------------------------------------------------------------------------------
// Blnukem - Very basic command. I made this due to popular demand.
// This command just gives the target an armor variant.
// There is probably a better way to do this, but I got lazy... So deal with it.

function ccGiveArmor(%sender,%args)
{
   %armor = strlwr(getword(%args, 0));
   %target = plnametocid(getword(%args, 1));
   if(!%sender.isAdmin)
      return;

   // TODO - Make this function check if the target exists and the gametype.
   switch$(%armor)
   {
   case "Recon":
      if(Game.class !$= "ConstructionGame")
      {
         %target.player.clearInventory();
         %target.setWeaponsHudClearAll();
         %target.player.setArmor(SpecOps);
         %target.player.setInventory(Snipergun,1,true);
         %target.player.setInventory(LSMG,1,true);
         %target.player.setInventory(AmmoPack,1,true);
         %target.player.setInventory(SnipergunAmmo,30,true);
         %target.player.setInventory(LSMGAmmo,60,true);
         %target.player.setInventory(LSMGClip,5,true);
         }
   case "Commando":
      if(Game.class !$= "ConstructionGame")
      {
         %target.player.clearInventory();
         %target.setWeaponsHudClearAll();
         %target.player.setArmor(Medium);
         %target.player.setInventory(HRPChaingun,1,true);
         %target.player.setInventory(Shotgun,1,true);
         %target.player.setInventory(AmmoPack,1,true);
         %target.player.setInventory(RPChaingunAmmo,30,true);
         %target.player.setInventory(MGClip,4,true);
         %target.player.setInventory(RPGAmmo,3,true);
         %target.player.setInventory(ShotgunAmmo,8,true);
         %target.player.setInventory(ShotgunClip,1,true);
         }
   case "Powered":
      if(Game.class !$= "ConstructionGame")
      {
         %target.player.clearInventory();
         %target.setWeaponsHudClearAll();
         %target.player.setArmor(Heavy);
         %target.player.setInventory(MG42,1,true);
         %target.player.setInventory(RShotgun,1,true);
         %target.player.setInventory(RailGun,1,true);
         %target.player.setInventory(BoosterPack,1,true);
         %target.player.setInventory(MG42Ammo,200,true);
         %target.player.setInventory(MG42Clip,5,true);
         %target.player.setInventory(RShotgunAmmo,25,true);
         %target.player.setInventory(RShotgunClip,2,true);
         %target.player.setInventory(RailGunAmmo,8,true);
         }
   default: // Just a check on the valid armors.
   MessageClient(%sender, "Msg", "\c2Invalid armor. Valid armors are Recon, Commando and Powered.");
   return;
   }
   // Lets set the basic items and stuff throughout each armor variant.
   %target.player.startFade(2000, 0, false); // Just a cheap effect.
   %target.player.setInventory(Grenade,5,true);
   %target.player.setInventory(Mine,2,true);
   %target.player.setInventory(Beacon,3,true);
   %target.player.setInventory(RepairKit,2,true);
   BottomPrint(%target, "<Color:ffffff>You now have "@%armor@" armor.", 5, 1);
   MessageClient(%target, "Msg", "\c2You were given "@%armor@" armor by\c3 "@%sender.nameBase@"\c2.");
   MessageClient(%sender, "Msg", "\c2You gave\c3 "@%target.nameBase@" \c2"@%armor@" armor.");
}

//------------------------------------------------------------------------------
// Blnukem - I modified this command so it has cheat protection for those who
// want to be jackasses with pure off, and also so it can work with Technicians.

function ccBf(%sender,%args)
{
   if (!isObject(%sender.player))
   {  // No player object? Bitch, you can't use this command.
      MessageClient(%sender, "Msg", "\c2You you have a player object in order to buy your inventory. ~wfx/misc/misc.error.wav");
      return;
   }

   if (%sender.BasicTimer > 0)
   {  // Hello cheat protection!
      MessageClient(%sender, "", "\c3CHEAT PROTECTION:\c0 You must wait "@%sender.BasicTimer@" more seconds until you can use /bf again.");
      return;
   }

   if (($Host::Purebuild == 0) && (%sender.armor $= "Light") || ($Host::Purebuild == 0) && (%sender.armor $= "Pure"))
   {  // This allows Technicians to use /bf with purebuild off.
      buyFavorites(%sender);
      %sender.BasicTimer = 10; // Cheat protection time in seconds.
      ClearBasicTimer(%sender);
   }  else if (($Host::Purebuild == 1) || (%sender.armor $= "Pure"))
   {  // No cheat protection, just good ole' /bf with some inventory buying fun.
      buyFavorites(%sender);
   }
}

//------------------------------------------------------------------------------

function ccMe(%sender,%args)
{
   messageall("", '\c0%1 %2', %sender.name, %args);
}

//------------------------------------------------------------------------------

function ccName(%sender,%args, %special)
{
   %pos          = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec          = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos    = vectoradd(%pos,vectorscale(%vec,100));
   %obj          = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj          = getword(%obj,0);
   %dataBlock    = %obj.getDataBlock();
   %className    = %dataBlock.className;

   if (%obj==0){
      messageclient(%sender, 'MsgClient', "\c2No object to label.");
      return;
   }
   if(!deployables.ismember(%obj)){
      messageClient(%sender, "MsgClient", "\c2You can\'t rename map objects!");
      return;
   }

   if(%obj.getowner() != %sender){
      messageclient(%sender, 'MsgClient', "\c2You do not own that object.");
      return;
   }
   if (%classname $= "waypoint"){
      %obj.wp.schedule(10, "delete");
      %wp = new  waypoint(){
         dataBlock        = WayPointMarker;
         position         = %obj.getPosition();
         name             = %args;
         scale            = "0.1 0.1 0.1";
         team             = %sender.team;
   };

      messageclient(%sender, 'MsgClient', "\c2Object name set to \c3"@%args@"");
      %obj.wp = %wp;
      MissionCleanup.add(%wp);
         return;
   }
      messageclient(%sender, 'MsgClient', "\c2Object name set to \c3"@%args@"");
      %obj.nametag = %args;
      setTargetName(%obj.target,addTaggedString("\c6"@%args@""));
         return;
}

//------------------------------------------------------------------------------

function ccRadius(%sender,%args, %special)
{
   %pos          = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec          = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos    = vectoradd(%pos,vectorscale(%vec,100));
   %obj          = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj          = getword(%obj,0);
   %dataBlock    = %obj.getDataBlock();
   %className    = %dataBlock.className;

   if (%args < 10 || %args > 10000)
   {
      messageclient(%sender, "", "\c2Invalid Range, must be between\c3 0 \c2and\c3 10000\c2.");
      return;
   }

   if (%obj == 0)
   {
      messageclient(%sender, "", "\c2No object in range.");
      return;
   }

   if(!deployables.ismember(%obj))
   {
      messageClient(%sender, "", "\c2You can\'t change the radius of map objects.");
      return;
   }

   if(%obj.owner != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2You do not own that object.");
      return;
   }

   if (%classname $= "Switch" || %classname $= "Tripwire")
   {
         messageClient(%sender, "", "\c2Radius set to:\c3 "@%args@" \c2meters.");
         %obj.switchradius = %args;
      return;
   } else if (%classname !$= "Switch" || %classname !$= "Tripwire")
   {
      messageClient(%sender, "", "\c2Invaild object, you can only change the radius of Tripwires and Switches.");
   return;
   }
}

//------------------------------------------------------------------------------

function ccCloak(%sender,%args, %special)
{
   %pos          = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec          = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos    = vectoradd(%pos,vectorscale(%vec,100));
   %obj          = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj          = getword(%obj,0);
   %dataBlock    = %obj.getDataBlock().getName();
   %className    = %dataBlock.className;

   if (%obj == 0)
   {
      messageclient(%sender, "", "\c2No valid objects in range.");
      return;
   }

   if(!deployables.ismember(%obj) && (%sender.isAdmin !=1))
   {
      messageClient(%sender, "", "\c2You can\'t cloak map objects.");
      return;
   }

   if(%obj.owner != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2You do not own that object.");
      return;
   }

   if (!%obj.cloak)
   {
      %obj.setCloaked(true);
      %obj.cloak = true;
      messageclient(%sender, "", "\c2Object cloaked.");
      return;
   } else {
      %obj.setCloaked(false);
      %obj.cloak = false;
      messageclient(%sender, "", "\c2Object un-cloaked.");
   return;
   }
}

//------------------------------------------------------------------------------

function ccMOTD(%sender, %args)
{
   if(!%sender.isSuperAdmin)
      return;

   %target = plnametocid(%args);
   if (%args $= "Remove" || %args $= "remove")
   {
      $Host::MOTD = "";
      MessageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has removed the message of the day.");
   } else {
      $Host::MOTD = %args;
      MessageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has changed the message of the day to: \c3"@%args@"");
   }
}

//------------------------------------------------------------------------------

function ccZAvoid(%sender,%args) // Makes Zombies avoid you.
{
   if(!%sender.isSuperAdmin)
      return;

   if(Game.class $= "ConstructionGame")
   {
      messageClient(%sender, "", "\c2This command is disabled in the Construction Gametype. ~wfx/misc/misc.error.wav");
      return;
   }

   if (%sender.player.isZombie == false){
      %sender.player.isZombie = true;
      messageClient(%sender, 'MsgAdminForce', "\c2Action Completed, zombies will now avoid you.");
   return;
   }

   if (%sender.player.isZombie == true){
      %sender.player.isZombie = false;
      messageClient(%sender, 'MsgAdminForce', "\c2Action Completed, zombies will now attack you.");
   return;
   }
}

//------------------------------------------------------------------------------

function ccSwitch(%sender,%args)
{
   if(!%sender.isSuperAdmin)
      return;

   %nametotest=getword(%args,0);
   %target=plnametocid(%nametotest);

   if (%target==%sender) {
      messageClient(%sender, 'MsgClient', "\c2You can\'t control yourself.");
      return;
    }

   if(%args $= ""){
      messageClient(%sender, 'MsgClient', "\c2No target specified.");
      return;
   }

   %sender.setcontrolobject(%target.player);
   %target.setcontrolobject(%sender.player);
   messageClient(%sender, "MsgClient", "\c2You are now controlling: \c3"@%target.namebase@".");
   messageClient(%target, "MsgClient", "\c2You and \c3"@%target.namebase@" \c2have switched Bodies!");
      return;
}

//==============================================================================
// The following functions were made by Eolk.
//==============================================================================

function ccDelPieces(%sender, %args)
{
   if(!%sender.isAdmin || %args $= "")
   {
      if(!isObject(%sender.player))
      {
         messageClient(%sender, 'MsgClient', "\c2You must be playing in order to remove your pieces.");
         return;
      }

      %group = nameToID("MissionCleanup/Deployables");
      for(%i = 0; %i < %group.getCount(); %i++)
      {
         %obj = %group.getObject(%i);
         if(%obj.getOwner() == %sender && isObject(%obj))
            %obj.getDatablock().schedule(getRandom() * 10000, disassemble, %sender.player, %obj);
      }

      messageClient(%sender, 'MsgYes', "\c2All of your pieces have been removed.");
   }
   else
   {
      %target = plnametocid(%args);
      if(!isObject(%target))
      {
         messageClient(%sender, 'MsgClient', "\c2That person's player object does not exist.");
         return;
      }

      if((!%sender.isSuperAdmin && %target.isAdmin) || %target.isSuperAdmin)
      {
         messageClient(%sender, 'MsgClient', "\c2You must outrank that target in order to remove their pieces.");
         return;
      }

      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has forced\c3 "@%target.nameBase@" \c2to delete all of their pieces.");
      ccDelPieces(%target, "");
   }
}

//------------------------------------------------------------------------------

function ccPower(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You have to be playing in order to do this.");
      return;
   }

   %sender.player.powerFreq = %args;
   displayPowerFreq(%sender.player);
}

//------------------------------------------------------------------------------

function ccSetScale(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You must be spawned in order to do this!");
      return;
   }

   %pos = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos = vectoradd(%pos,vectorscale(%vec,100));
   %obj = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj = getword(%obj,0);

   if(!isObject(%obj))
   {
      messageClient(%sender, "", "\c2There is nothing in range.");
      return;
   }

   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;
   if(%obj.owner != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2That piece isn't yours.");
      return;
   }

   %test = nameToID("MissionCleanup/Deployables");
   if(!isObject(%test) || !%test.isMember(%obj))
   {
      messageClient(%sender, "", "\c2That is part of the map.");
      return;
   }

   if(getwordcount(%args) < 3)
   {
      messageClient(%sender, "", "\c2You must specify all paramenters: X, Y, and Z.");
      return;
   }

   if(getwordcount(%args) > 3)
   {
      messageClient(%sender, "", "\c2Too many parameters. They should be X, Y, and Z.");
      return;
   }

   if(%classname $= "spine" || %classname $= "mspine" || %classname $= "spine2" || %classname $= "floor" || %classname $= "wall" || %classname $= "wwall" || %classname $= "floor" || %classname $= "door")
   {
      %or = %args;
      %args = VectorMultiply(%args, "0.250 0.333333 2");
      %check = EditorCheckScale(%args);
      if(%check == 1)
      {
         messageClient(%sender, "", "\c2Scale is too small.");
         return;
      }

      if(%check == 2)
      {
         messageClient(%sender, "", "\c2Scale is too big.");
         return;
      }

      %obj.setScale(%args);
      messageClient(%sender, "", "\c2Object scale set to:\c3 "@%or@"");
      return;
   }

   %check = EditorCheckScale(%args);
   if(%check == 1)
   {
      messageClient(%sender, "", "\c2Scale is too small.");
      return;
   }

   if(%check == 2)
   {
      messageClient(%sender, "", "\c2Scale is too big.");
      return;
   }

   if(%dataBlock $= "DeployedLTarget")
   {
      %obj.lMain.setScale(%args);
      adjustLMain(%obj);
      messageClient(%sender, "", "\c2Object scale set to:\c3 "@%args@"");
      return;
   }

   if(%dataBlock $= "DeployedLogoProjector")
   {
      %obj.setScale(%args);
      if(isObject(%obj.holo))
      {
         %obj.holo.setScale(%args);
         adjustHolo(%obj);
         messageClient(%sender, "", "\c2Object scale set to:\c3 "@%args@"");
      }

      return;
   }

   %obj.setScale(%args);
   messageClient(%sender, "", "\c2Object scale set to:\c3 "@%args@"");
}

//------------------------------------------------------------------------------

function ccGetScale(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You must be spawned in order to do this.");
      return;
   }

   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);

   if(!isObject(%obj))
   {
      messageClient(%sender, "", "\c2There is nothing in range.");
      return;
   }

   %dataBlock = %obj.getDataBlock();
   %className = %dataBlock.className;

   %test = nameToID("MissionCleanup/Deployables");
   if(!isObject(%test) || !%test.isMember(%obj))
   {
      messageClient(%sender, "", "\c2That is part of the map.");
      return;
   }

   %scale = %obj.getScale();
   if(%classname $= "spine" || %classname $= "mspine" || %classname $= "spine2" || %classname $= "floor" || %classname $= "wall" || %classname $= "wwall" || %classname $= "floor" || %classname $= "door")
      %scale = getword(%scale, 0) / 0.250 SPC getword(%scale, 1) / 0.333333 SPC getword(%scale, 2) / 2;
   if(%dataBlock $= "DeployedLTarget")
      %scale = %obj.lMain.getScale();
   messageClient(%sender, "", "\c2The scale of that object is:\c3 "@%scale@"");
}

//------------------------------------------------------------------------------
// Idea from Insane Turkey
function ccPos(%sender, %args)
{
   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You have to be playing in order to do this.");
      return;
   }

   %pos=%sender.player.getMuzzlePoint($WeaponSlot);
   %vec = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos=vectoradd(%pos,vectorscale(%vec,100));
   %obj=containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj=getword(%obj,0);

   if(!isObject(%obj))
   {
      messageClient(%sender, "", "\c2There is nothing in range.");
      return;
   }

   if(%obj.getOwner() != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2That piece is not yours.");
      return;
   }

   %test = nameToID("MissionCleanup/Deployables");
   if(!isObject(%test) || !%test.isMember(%obj))
   {
      messageClient(%sender, "", "\c2That is part of the map.");
      return;
   }

   if(getwordcount(%args) == 4 || getword(%args, 0) $= "g")
   {
      %option = getword(%args, 0);
      if(%option $= "s")
      {
         %pos = getwords(%args, 1, 3);
      }
      else if(%option $= "g")
      {
         messageClient(%sender, "", "\c2Object's position is:\c3 "@%obj.getPosition()@"");
         return;
      }
      else if(%option $= "m")
      {
         %xyz = getwords(%args, 1, 3);
         %positive = VectorPositive(%xyz);
         %start = VectorCheck(%xyz);

         %x = getword(%start, 0) SPC 0 SPC 0;
         %realx = realvec(%obj, %x);
         %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realx, getword(%positive, 0))));

         %y = 0 SPC getword(%start, 1) SPC 0;
         %realy = realvec(%obj, %y);
         %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realy, getword(%positive, 1))));

         %z = 0 SPC 0 SPC getword(%start, 2);
         %realz = realvec(%obj, %z);
         %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realz, getword(%positive, 2))));
      }
      else
      {
         messageClient(%sender, "", "\c2Unknown mode for /Pos:\c3 "@%option@"\c2.");
         messageClient(%sender, "", "\c2Use:\c3 /Pos X Y Z");
         return;
      }
   }
   else if(getwordcount(%args) == 3)
   {
      %xyz = getwords(%args, 0, 2);
      %positive = VectorPositive(%xyz);
      %start = VectorCheck(%xyz);

      %x = getword(%start, 0) SPC 0 SPC 0;
      %realx = realvec(%obj, %x);
      %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realx, getword(%positive, 0))));

      %y = 0 SPC getword(%start, 1) SPC 0;
      %realy = realvec(%obj, %y);
      %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realy, getword(%positive, 1))));

      %z = 0 SPC 0 SPC getword(%start, 2);
      %realz = realvec(%obj, %z);
      %obj.setPosition(VectorAdd(%obj.getPosition(), VectorScale(%realz, getword(%positive, 2))));
   }
   else
   {
      messageClient(%sender, "", "\c2Wrong number of arguments for\c3 /Pos\c2.");
      messageClient(%sender, "", "\c2Use:\c3 /Pos X Y Z");
      return;
   }

   %pos = %obj.getPosition();
   messageClient(%sender, "", "\c2Object's position modified to:\c3 "@%pos@"");
}

//------------------------------------------------------------------------------

function GivePieces(%from, %to)
{
   if(!isObject(Deployables))
      return;

   for(%i = 0; %i < Deployables.getCount(); %i++)
   {
      %piece = Deployables.getObject(%i);
      if(%from !$= "orphan")
      {
         %owner = %piece.getOwner();
         if(%owner !$= "") // Regular giving
         {
            if(%owner == %from)
               %piece.setOwner(%to.player);
         }
         else // For giving by clientID.
         {
            if(%piece.owner == %from)
               %piece.setOwner(%to.player);
         }
      }
      else // Give orphans.
      {
         if(!isObject(%piece.getOwner()))
            %piece.setOwner(%to.player);
      }
   }

   logEcho("Pieces given to "@%to.nameBase@" ("@%to@") from "@%from.nameBase@" ("@%from@")");
}

function ccGivePieces(%sender, %args)
{
   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2You can't give your pieces to a non-existant person!");
      return;
   }

   if(%target == %sender)
   {
      messageClient(%sender, "", "\c2You can't give your pieces to yourself!");
      return;
   }

   if(isObject(%target.transferTo) || isObject(%target.transferFrom))
   {
      messageClient(%sender, "", "\c3"@%target.nameBase@"\c2 is already in a transaction. Please wait a moment for it to complete.");
      return;
   }

   if(isObject(%sender.transferTo))
   {
      messageClient(%sender, "", "\c2You are already transferring to someone! You must first cancel the first transaction.");
      return;
   }

   if(!%sender.isAdmin)
   {
      %sender.transferTo = %target;
      %target.transferFrom = %sender;

      messageClient(%sender, "", "\c2You are pending piece transfer to \c3"@%target.nameBase@"\c2. If you wish to cancel the transaction, press the \"vote no\" key (delete).");
      messageClient(%target, "", "\c3"@%sender.nameBase@"\c2 is pending transfer to you. Press the \"vote yes\" key (insert) to accept, and the \"vote no\" key (delete) to decline.~wfx/misc/diagnostic_beep.wav");
   }
   else
   {
// Eolk - This isn't possible with the above checks.
//      if(getWordCount(%args) > 1) // Super accident protection.
//      {
//         messageClient(%sender, "", "\c2Admins should use /ForceGivePieces to give pieces from one person to the other. Use /givePieces target to give your OWN pieces to the target.");
//         return;
//      }

      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 is transferring "@(%sender.sex $= "Male" ? "his" : "her")@" pieces to \c3"@%target.nameBase@"\c2.");
      GivePieces(%sender, %target);
   }
}

function ccSetAccess(%sender, %args)
{
   if(!isObject(%sender.player))
      return;

   %pos        = %sender.player.getMuzzlePoint($WeaponSlot);
   %vec        = %sender.player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,100));
   %obj        = containerraycast(%pos,%targetpos,$typemasks::staticshapeobjecttype,%sender.player);
   %obj        = getword(%obj,0);
   %dataBlock  = %obj.getDataBlock();
   %className  = %classname;
   %owner      = %obj.owner;

   if(!isObject(%obj))
      return;

   if(!%obj.isDoor || %obj.collisionType != 2)
   {
      messageClient(%sender, "", "\c2Object is either not a door, or is not the right type of door.");
      return;
   }

   if(%obj.getOwner() != %sender && !%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2You do not own that.");
      return;
   }

   %args = getWord(%args, 0);
   if(%args < 1)
   {
      messageClient(%sender, "", "\c2Invalid access level.");
      return;
   }

   %obj.accessLevel = %args;
   messageClient(%sender, "", "\c2Door's access level set to \c3"@%args@".");
}

function ccSetPAccess(%sender, %args)
{
   %target = plnametocid(getword(%args, 0));
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Target doesn't exist.");
      return;
   }

   %level = getWord(%args, 1);
   if(%level < 0)
   {
      messageClient(%sender, "", "\c2Invalid access level to give.");
      return;
   }

   %formerLevel = %target.givenAccess[%sender];
   if(%formerLevel == %level)
   {
      messageClient(%sender, "", "\c2That person's access level is already \c3"@%level@"\c2!");
      return;
   }

   %target.givenAccess[%sender] = %level;
   messageClient(%target, "", "\c3"@%sender.nameBase@"\c2 has \c3"@(%formerLevel < %level ? "increased" : "decreased")@"\c2 your access level to \c3"@%level@"\c2.");
   messageClient(%sender, "", "\c2You have \c3"@(%formerLevel < %level ? "increased" : "decreased") SPC %target.nameBase@"'s\c2 access level to \c3"@%level@"\c2.");
}

//==============================================================================
// Below is where you may add custom chat commands, to keep things organized.
//------------------------------------------------------------------------------
// Custom Chat Commands:
//==============================================================================
