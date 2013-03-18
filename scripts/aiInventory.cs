//------------------------------
//AI Inventory functions

function AINeedEquipment(%equipmentList, %client)
{
   %index = 0;
   %item = getWord(%equipmentList, %index);

	//first, see if we're testing the armor class as well...
	if (%item $= "Heavy" || %item $= "Medium" || %item $= "Light" || %item $= "SpecOps")
	{
		if (%client.player.getArmorSize() !$= %item)
			return true;
		%index++;
	   %item = getWord(%equipmentList, %index);
	}

   while (%item !$= "")
   {
      if (%client.player.getInventory(%item) == 0)
			return true;
         
      //get the next item
      %index++;
      %item = getWord(%equipmentList, %index);
   }
   
	//made it through the list without needing anything
	return false;
}

function AIBuyInventory(%client, %requiredEquipment, %equipmentSets, %buyInvTime)
{
   //make sure we have a live player
	%player = %client.player;
	if (!isObject(%player))
		return "Failed";

	if (! AIClientIsAlive(%client))
		return "Failed";

	//see if we've already initialized our state machine
	if (%client.buyInvTime == %buyInvTime)
		return AIProcessBuyInventory(%client);

	//if the closest inv station is not a remote, buy the first available set...
   %result = AIFindClosestInventory(%client, false);
   %closestInv = getWord(%result, 0);
	%closestDist = getWord(%result, 1);
	if (%closestInv <= 0)
		return "Failed";

	//see if the closest inv station was a remote
	%buyingSet = false;
	%usingRemote = false;
   if (%closestInv.getDataBlock().getName() $= "DeployedStationInventory")
	{
		//see if we can buy at least the required equipment from the set
		if (%requiredEquipment !$= "")
		{
			if (! AIMustUseRegularInvStation(%requiredEquipment, %client))
				%canUseRemote = true;
			else
				%canUseRemote = false;
		}
		else
		{
			%inventorySet = AIFindSameArmorEquipSet(%equipmentSets, %client);
			if (%inventorySet !$= "")
				%canUseRemote = true;
			else
				%canUseRemote = false;
		}

		//if we can't use a remote, we need to look for a regular inv station
		if (! %canUseRemote)
		{
		   %result = AIFindClosestInventory(%client, true);
		   %closestInv = getWord(%result, 0);
			%closestDist = getWord(%result, 1);
			if (%closestInv <= 0)
				return "Failed";
		}
		else
			%usingRemote = true;
	}

	//at this point we've found the closest inv, see which set/list we need to buy
	if (!%usingRemote)
	{
		//choose the equipment first equipment set
		if (%equipmentSets !$= "")
		{
			%inventorySet = getWord(%equipmentSets, 0);
			%buyingSet = true;
		}
		else
		{
			%inventorySet = %requiredEquipment;
			%buyingSet = false;
		}
	}
	else
	{
		%inventorySet = AIFindSameArmorEquipSet(%equipmentSets, %client);
		if (%inventorySet $= "")
		{
			%inventorySet = %requiredEquipment;
			%buyingSet = false;
		}
		else
			%buyingSet = true;
	}

	//init some vars for the state machine...
	%client.buyInvTime = %buyInvTime;		//used to mark the begining of the inv buy session
	%client.invToUse = %closestInv;			//used if we need to go to an alternate inv station
	%client.invWaitTime = "";					//used to track how long we've been waiting
	%client.invBuyList = %inventorySet;		//the list/set of items we're going to buy...
	%client.buyingSet = %buyingSet;			//whether it's a list or a set...
	%client.isSeekingInv = false;
   %client.seekingInv = "";

	//now process the state machine
	return AIProcessBuyInventory(%client);
}

function AIProcessBuyInventory(%client)
{
	//get some vars
	%player = %client.player;
	if (!isObject(%player))
		return "Failed";

	%closestInv = %client.invToUse;
	%inventorySet = %client.invBuyList;
	%buyingSet = %client.buyingSet;

	//make sure it's still valid, enabled, and on our team
	if (! (%closestInv > 0 && isObject(%closestInv) &&
		(%closestInv.team <= 0 || %closestInv.team == %client.team) && %closestInv.isEnabled()))
	{
		//reset the state machine
		%client.buyInvTime = 0;
		return "InProgress";
	}

	//make sure the inventory station is not blocked
	%invLocation = %closestInv.getWorldBoxCenter();
   InitContainerRadiusSearch(%invLocation, 2, $TypeMasks::PlayerObjectType);
   %objSrch = containerSearchNext();
	if (%objSrch == %client.player)
		%objSrch = containerSearchNext();

	//the closestInv is busy...
	if (%objSrch > 0)
	{
		//have the AI range the inv
		if (%client.seekingInv $= "" || %client.seekingInv != %closestInv)
		{
			%client.invWaitTime = "";
			%client.seekingInv = %closestInv;
		   %client.stepRangeObject(%closestInv, "DefaultRepairBeam", 5, 10);
		}

		//inv is still busy - see if we're within range
		else if (%client.getStepStatus() $= "Finished")
		{
			//initialize the wait time
			if (%client.invWaitTime $= "")
				%client.invWaitTime = getSimTime() + 5000 + (getRandom() * 10000);

			//else see if we've waited long enough
			else if (getSimTime() > %client.invWaitTime)
			{
			   schedule(250, %client, "AIPlayAnimSound", %client, %objSrch.getWorldBoxCenter(), "vqk.move", -1, -1, 0);
				%client.invWaitTime = getSimTime() + 5000 + (getRandom() * 10000);
			}
		}
		else
		{
			//in case we got bumped, and are ranging the target again...
			%client.invWaitTime = "";
		}
	}

	//else if we've triggered the inv, automatically give us the equipment...
	else if (isObject(%closestInv) && isObject(%closestInv.trigger) && VectorDist(%closestInv.trigger.getWorldBoxCenter(), %player.getWorldBoxCenter()) < 1.5)
	{
		//first stop...
		%client.stop();

	   %index = 0;
		if (%buyingSet)
		{
			//first, clear the players inventory
			%player.clearInventory();
			%item = $AIEquipmentSet[%inventorySet, %index];
		}
		else
			%item = getWord(%inventorySet, %index);


		//armor must always be bought first
	   if (%item $= "Light" || %item $= "Medium" || %item $= "Heavy" || %item $= "SpecOps")
	   {
	      %player.setArmor(%item);
	      %index++;
	   }

		//set the data block after the armor had been upgraded
      %playerDataBlock = %player.getDataBlock(); 

		//next, loop through the inventory set, and buy each item
		if (%buyingSet)
			%item = $AIEquipmentSet[%inventorySet, %index];
		else
			%item = getWord(%inventorySet, %index);
		while (%item !$= "")
		{
			//set the inventory amount to the maximum quantity available
			if (%player.getInventory(AmmoPack) > 0)
				%ammoPackQuantity = AmmoPack.max[%item];
			else
				%ammoPackQuantity = 0;

         %quantity = %player.getDataBlock().max[%item] + %ammoPackQuantity;
			if ($InvBanList[$CurrentMissionType, %item])
				%quantity = 0;
         %player.setInventory(%item, %quantity);

			//get the next item
			%index++;
			if (%buyingSet)
				%item = $AIEquipmentSet[%inventorySet, %index];
			else
				%item = getWord(%inventorySet, %index);
		}

		//put a weapon in the bot's hand...
		%player.cycleWeapon();

		//return a success
		return "Finished";
	}

	//else, keep moving towards the inv station
	else
	{
		if (isObject(%closestInv) && isObject(%closestInv.trigger))
		{
			//quite possibly we may need to deal with what happens if a bot doesn't have a path to the inv...
			//the current premise is that no inventory stations are "unpathable"...
			//if (%client.isSeekingInv)
			//{
			//   %dist = %client.getPathDistance(%closestInv.trigger.getWorldBoxCenter());
			//	if (%dist < 0)
			//		error("DEBUG Tinman - still need to handle bot stuck trying to get to an inv!");
			//}
													
			%client.stepMove(%closestInv.trigger.getWorldBoxCenter(), 1.5);
			%client.isSeekingInv = true;
		}
		return "InProgress";
	}
}

function AIFindSameArmorEquipSet(%equipmentSets, %client)
{
	%clientArmor = %client.player.getArmorSize();
	%index = 0;
	%set = getWord(%equipmentSets, %index);
	while (%set !$= "")
	{
		if ($AIEquipmentSet[%set, 0] $= %clientArmor)
			return %set;

		//get the next equipment set in the list of sets
		%index++;
		%set = getWord(%equipmentSets, %index);
	}
	return "";
}

function AIMustUseRegularInvStation(%equipmentList, %client)
{
	%clientArmor = %client.player.getArmorSize();

	//first, see if the set contains an item not available
	%needRemoteInv = false;
	%index = 0;
   %item = getWord(%equipmentList, 0);
   while (%item !$= "")
	{
		if (%item $= "InventoryDeployable" || (%clientArmor $= "Light" && (%item $= "HRPChaingun" || %item $= "AALauncher" || %item $= "MG42" || %item $= "Bazooka" || %item $="RShotgun")) ||(%clientArmor $= "SpecOps" && (%item $= "RPChaingun" || %item $= "HRPChaingun" || %item $= "AALauncher" || %item $= "MG42" || %item $= "Bazooka" || %item $="RShotgun" || %item $= "Shotgun" || %item $= "Flamer")) ||(%clientArmor $= "Medium" && (%item $= "RPChaingun" || %item $= "LMissileLauncher" || %item $= "MG42" || %item $="RShotgun")) ||(%clientArmor $= "Heavy" && (%item $= "HRPChaingun" || %item $= "LSMG" || %item $= "snipergun" || %item $= "flamer" || %item $= "KreigRifle" || %item $= "LMissileLauncher")))
		{
			return true;
		}
		else
		{
			%index++;
	      %item = getWord(%equipmentList, %index);
		}
	}
	if (%needRemoteInv)
		return true;


	//otherwise, see if the set begins with an armor class
	%needArmor = %equipmentList[0];
	if (%needArmor !$= "Light" && %needArmor !$= "Medium" && %needArmor !$= "Heavy")
		return false;

	//also including looking for an inventory set
	if (%needArmor != %client.player.getArmorSize())
		return true;

	//we must be fine...
	return false;
}

function AICouldUseItem(%client, %item)
{
   if(!AIClientIsAlive(%client))
      return false;
      
	%player = %client.player;
	if (!isObject(%player))
		return false;

	%playerDataBlock = %client.player.getDataBlock();
	%armor = %player.getArmorSize();
	%type = %item.getDataBlock().getName();

	//check packs first
	if (%type $= "RepairPack" || %type $= "AmmoPack")
	{
		if (%client.player.getMountedImage($BackpackSlot) <= 0)
			return true;
		else
			return false;
	}

   //if the item is acutally, a corpse, check the corpse inventory...
   if (%item.isCorpse)
   {
      %corpse = %item;
      if (%corpse.getInventory("MGClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[MGClip])
         return true;
      if (%corpse.getInventory("LSMGClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[LSMGClip])
         return true;
      if (%corpse.getInventory("snipergunAmmo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[snipergunAmmo])
         return true;
      if (%corpse.getInventory("bazookaAmmo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[bazookaAmmo])
         return true;
      if (%corpse.getInventory("MG42Ammo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[MG42Ammo])
         return true;
      if (%corpse.getInventory("PistolClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[PistolClip])
         return true;
      if (%corpse.getInventory("AALauncherAmmo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[AALauncherAmmo])
         return true;
      if (%corpse.getInventory("RifleClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[RifleClip])
         return true;
      if (%corpse.getInventory("ShotgunClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[ShotgunClip])
         return true;
      if (%corpse.getInventory("RShotgunClip") > 0 && %player.getInventory(%type) < %playerDataBlock.max[RShotgunClip])
         return true;
      if (%corpse.getInventory("RPGAmmo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[RPGAmmo])
         return true;
      if (%corpse.getInventory("LMissileLauncherAmmo") > 0 && %player.getInventory(%type) < %playerDataBlock.max[LMissileLauncherAmmo])
         return true;
   }
   else
   {
	   //check ammo
	   %quantity = mFloor(%playerDataBlock.max[%type]);
	   if (%player.getInventory(%type) < %quantity)
	   {
		   if (%type $= "MGClip")
			   return true;
		   if (%type $= "LSMGClip")
			   return true;
		   if (%type $= "snipergunAmmo")
			   return true;
		   if (%type $= "bazookaAmmo")
			   return true;
		   if (%type $= "MG42Ammo")
			   return true;
		   if (%type $= "PistolClip")
			   return true;
		   if (%type $= "AALauncherAmmo")
			   return true;
		   if (%type $= "RifleClip")
			   return true;
		   if (%type $= "ShotgunClip")
			   return true;
		   if (%type $= "RShotgunClip")
			   return true;
		   if (%type $= "RPGAmmo")
			   return true;
		   if (%type $= "LMissileLauncherAmmo")
			   return true;

		   //check mines and grenades as well
		   if (%type $= "Grenade" || %type $= "FlashGrenade" || %type $= "ConcussionGrenade")
			   return true;
	   }

	   //see if we can carry another weapon...
	   if (AICanPickupWeapon(%client, %type))
		   return true;
   }

	//guess we didn't find anything useful...  (should still check for mines and grenades)
   return false;
}

function AIEngageOutofAmmo(%client)
{
	//this function only cares about weapons used in engagement...
	//no mortars, or missiles
   %player = %client.player;
	if (!isObject(%player))
		return false;

   %ammoWeapons = 0;
   %energyWeapons = 0;
   
   //get our inventory
   %hasMG = (%player.getInventory("RPChaingun") > 0);
   %hasLMG = (%player.getInventory("LSMG") > 0);
   %hasHMG = (%player.getInventory("HRPChaingun") > 0);
   %hasMG42 = (%player.getInventory("MG42") > 0);
   %hasSniper = (%player.getInventory("snipergun") > 0);
   %hasRifle = (%player.getInventory("KriegRifle") > 0);
   %hasAT6 = (%player.getInventory("LMissileLauncher") > 0);
   %hasPistol = (%player.getInventory("Pistol") > 0);
   %hasSPistol = (%player.getInventory("SPistol") > 0);
   %hasBazooka = (%player.getInventory("Bazooka") > 0);
   %hasFlamer = (%player.getInventory("flamer") > 0);
   %hasAAMissile = (%player.getInventory("AALauncher") > 0);
   %hasShotgun = (%player.getInventory("Shotgun") > 0);
   %hasRShotgun = (%player.getInventory("RShotgun") > 0);

   if(%hasMG && (%player.getInventory("RPChaingunAmmo") > 0) && (%player.getInventory("MGClip") > 0))
      return false;
   else if(%hasHMG && (%player.getInventory("RPChaingunAmmo") > 0) && (%player.getInventory("MGClip") > 0))
      return false; 
   else if(%hasLMG && (%player.getInventory("LSMGAmmo") > 0) && (%player.getInventory("LSMGClip") > 0))
      return false; 
   else if(%hasRifle && (%player.getInventory("KreigAmmo") > 0) && (%player.getInventory("RifleClip") > 0))
      return false; 
   else if(%hasPistol && (%player.getInventory("PistolAmmo") > 0) && (%player.getInventory("PistolClip") > 0))
      return false; 
   else if(%hasSPistol && (%player.getInventory("PistolAmmo") > 0) && (%player.getInventory("PistolClip") > 0))
      return false; 
   else if(%hasShotgun && (%player.getInventory("ShotgunAmmo") > 0) && (%player.getInventory("ShotgunClip") > 0))
      return false; 
   else if(%hasRShotgun && (%player.getInventory("RShotgunAmmo") > 0) && (%player.getInventory("RShotgunClip") > 0))
      return false; 
   else if(%hasMG42 && (%player.getInventory("MG42Ammo") > 0))
      return false;
   else if(%hasSniper && (%player.getInventory("snipergunAmmo") > 0))
      return false;
   else if(%hasBazooka && (%player.getInventory("BazookaAmmo") > 0))
      return false;
   else if(%hasFlamer && (%player.getInventory("FlamerAmmo") > 0))
      return false;
   else if(%hasAAMissile && (%player.getInventory("AALauncherAmmo") > 0))
      return false;
   else if(%hasAT6 && (%player.getInventory("LMissileLauncherAmmo") > 0))
      return false;
   return true; // were out!
}

function AICanPickupWeapon(%client, %weapon)
{
	//first, make sure it's not a weapon we already have...
	%player = %client.player;
	if (!isObject(%player))
		return false;

	%armor = %player.getArmorSize();
	if (%player.getInventory(%weapon) > 0)
		return false;

	//make sure the %weapon given is a weapon they can use for engagement
	if (%weapon !$= "RPChaingun" && %weapon !$= "HRPChaingun" && %weapon !$= "Bazooka" && %weapon !$= "Snipergun" && %weapon !$= "Shotgun" && %weapon !$= "RShotgun" && %weapon !$= "KreigRifle" && %weapon !$= "AALauncher"&& %weapon !$= "LMissileLauncher" && %weapon !$= "LSMG" && %weapon !$= "MG42" && %weapon !$= "Flamer" )
	{
		return false;
	}

	%weaponCount = 0;
	if (%player.getInventory("RPChaingun") > 0)
		%weaponCount++;
	if (%player.getInventory("HRPChaingun") > 0)
		%weaponCount++;
	if (%player.getInventory("Bazooka") > 0)
		%weaponCount++;
	if (%player.getInventory("Snipergun") > 0)
		%weaponCount++;
	if (%player.getInventory("Shotgun") > 0)
		%weaponCount++;
	if (%player.getInventory("RShotgun") > 0)
		%weaponCount++;
	if (%player.getInventory("KreigRifle") > 0)
		%weaponCount++;
	if (%player.getInventory("AALauncher") > 0)
		%weaponCount++;
	if (%player.getInventory("LMissileLauncher") > 0)
		%weaponCount++;
	if (%player.getInventory("LSMG") > 0)
		%weaponCount++;
	if (%player.getInventory("MG42") > 0)
		%weaponCount++;
	if (%player.getInventory("Flamer") > 0)
		%weaponCount++;

	if ((%armor $= "Light" && %weaponCount < 1) || (%armor $= "Medium" && %weaponCount < 2) || (%armor $= "Heavy" && %weaponCount < 3) || (%armor $= "SpecOps" && %weaponCount <2))
	{
		if ((%type $= "RShotgun" && %armor !$= "Heavy") || (%type $= "RPChaingun" && (%armor $= "Medium" || %armor $= "SpecOps")) ||(%type $= "HRPChaingun" && %armor !$= "Medium") || (%type $= "LSMG" && %armor $= "Heavy") || (%type $= "Flamer" && (%armor !$= "Light" && %armor !$= "Medium")) || (%type $= "MG42" && %armor !$= "Heavy") || (%type $= "Bazooka" && (%armor $= "Light" || %armor $= "SpecOps")) || (%type $= "AALauncher" && (%armor $= "Light" || %armor $= "SpecOps")) || (%type $= "Shotgun" && (%armor $= "Heavy" || %armor $= "SpecOps")) || (%type $= "LMissileLauncher" && (%armor $= "Heavy" || %armor $= "Medium")) || (%type $= "KreigRifle" && %armor $= "Heavy") || (%type $= "SniperGun" && %armor $= "Heavy") )
			return false;
		else
			return true;
	}

	//else we're full of weapons already...
	return false;
}

function AIEngageWeaponRating(%client)
{
   %player = %client.player;
	if (!isObject(%player))
		return;

	%playerDataBlock = %client.player.getDataBlock();
   
   //get our inventory
   %hasMG = (%player.getInventory("RPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1))); 
   %hasHMG = (%player.getInventory("HRPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1)));
   %hasKreig = (%player.getInventory("KreigRifle") > 0 && ((%player.getInventory("KreigAmmo") >= 1 && %player.getInventory("RifleClip") >= 1) || (%player.getInventory("KreigAmmo") >= 1 || %player.getInventory("RifleClip") >= 1)));
   %hasLMG = (%player.getInventory("LSMG") > 0 && ((%player.getInventory("LSMGAmmo") >= 1 && %player.getInventory("LSMGClip") >= 1) || (%player.getInventory("LSMGAmmo") >= 1 || %player.getInventory("LSMGClip") >= 1)));
   %hasShotgun = (%player.getInventory("Shotgun") > 0 && ((%player.getInventory("ShotgunAmmo") >= 1 && %player.getInventory("ShotgunClip") >= 1) || (%player.getInventory("ShotgunAmmo") >= 1 || %player.getInventory("ShotgunClip") >= 1)));
   %hasRShotgun = (%player.getInventory("RShotgun") > 0 && ((%player.getInventory("RShotgunAmmo") >= 1 && %player.getInventory("RShotgunClip") >= 1) || (%player.getInventory("RShotgunAmmo") >= 1 || %player.getInventory("RShotgunClip") >= 1)));
   %hasPistol = (%player.getInventory("Pistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)));
   %hasSPistol = (%player.getInventory("SPistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)));
   %hasFlamer = (%player.getInventory("Flamer") > 0 && %player.getInventory("FlamerAmmo") >= 1);
   %hasSniper = (%player.getInventory("Snipergun") > 0 && %player.getInventory("SnipergunAmmo") >= 1);
   %hasBazooka = (%player.getInventory("Bazooka") > 0 && %player.getInventory("BazookaAmmo") >= 1);
   %hasAALauncher = (%player.getInventory("AALauncher") > 0 && %player.getInventory("AALauncherAmmo") >= 1);
   %hasLMissileLauncher = (%player.getInventory("LMissileLauncher") > 0 && %player.getInventory("LMissileLauncherAmmo") >= 1);
   %hasMG42 = (%player.getInventory("MG42") > 0 && %player.getInventory("MG42Ammo") >= 1);

	//check ammo
	%quantity = mFloor(%playerDataBlock.max[%type] * 0.7);

	%rating = 0;

	if (%hasMG)
	{
		%quantity = (%player.getInventory("RPChaingunAmmo") + (%player.getInventory("MGClip") * 30) / (%playerDataBlock.max["RPChaingunAmmo"] * %playerDatablock.max["MGClip"]));
		%rating += 20 + (20 * %quantity);
	}
	if (%hasHMG)
	{
		%quantity = (%player.getInventory("RPChaingunAmmo") + (%player.getInventory("MGClip") * 30) / (%playerDataBlock.max["RPChaingunAmmo"] * %playerDatablock.max["MGClip"]));
		%rating += 20 + (20 * %quantity);
	}
	if (%hasKreig)
	{
		%quantity = (%player.getInventory("KreigAmmo") + (%player.getInventory("RifleClip") * 10) / (%playerDataBlock.max["KreigAmmo"] * %playerDatablock.max["RifleClip"]));
		%rating += 15 + (15 * %quantity);
	}
	if (%hasLMG)
	{
		%quantity = (%player.getInventory("LSMGAmmo") + (%player.getInventory("LSMGClip") * 30) / (%playerDataBlock.max["LSMGAmmo"] * %playerDatablock.max["LSMGClip"]));
		%rating += 15 + (15 * %quantity);
	}
	if (%hasShotgun)
	{
		%quantity = (%player.getInventory("ShotgunAmmo") + (%player.getInventory("ShotgunClip") * 5) / (%playerDataBlock.max["ShotgunAmmo"] * %playerDatablock.max["ShotgunClip"]));
		%rating += 15 + (15 * %quantity);
	}
	if (%hasRShotgun)
	{
		%quantity = (%player.getInventory("RShotgunAmmo") + (%player.getInventory("RShotgunClip") * 25) / (%playerDataBlock.max["RShotgunAmmo"] * %playerDatablock.max["RShotgunClip"]));
		%rating += 19 + (30 * %quantity);
	}
	if (%hasPistol)
	{
		%quantity = (%player.getInventory("PistolAmmo") + (%player.getInventory("PistolClip") * 10) / (%playerDataBlock.max["PistolAmmo"] * %playerDatablock.max["PistolClip"]));
		%rating += 5 + (5 * %quantity);
	}
	if (%hasSPistol)
	{
		%quantity = (%player.getInventory("SPistolAmmo") + (%player.getInventory("SPistolClip") * 10) / (%playerDataBlock.max["SPistolAmmo"] * %playerDatablock.max["SPistolClip"]));
		%rating += 7 + (7 * %quantity);
	}
	if (%hassniper)
	{
		%quantity = %player.getInventory("snipergunAmmo") / %playerDataBlock.max["snipergunammo"];
		%rating += 15 + (15 * %quantity);
	}
	if (%hasBazooka)
	{
		%quantity = %player.getInventory("BazookaAmmo") / %playerDataBlock.max["Bazookaammo"];
		%rating += 19 + (30 * %quantity);
	}
	if (%hasAALauncher)
	{
		%quantity = %player.getInventory("AALauncherAmmo") / %playerDataBlock.max["AALauncherammo"];
		%rating += 19 + (20 * %quantity);
	}
	if (%hasLMissileLauncher)
	{
		%quantity = %player.getInventory("LMissileLauncherAmmo") / %playerDataBlock.max["LMissileLauncherammo"];
		%rating += 15 + (15 * %quantity);
	}
	if (%hasMG42)
	{
		%quantity = %player.getInventory("MG42Ammo") / %playerDataBlock.max["MG42ammo"];
		%rating += 19 + (30 * %quantity);
	}

	return %rating;
}

function AIFindSafeItem(%client, %needType)
{
	%player = %client.player;
	if (!isObject(%player))
		return -1;

	%closestItem = -1;
	%closestDist = 32767;

	%itemCount = $AIItemSet.getCount();
	for (%i = 0; %i < %itemCount; %i++)
	{
		%item = $AIItemSet.getObject(%i);
		if (%item.isHidden())
			continue;

		%type = %item.getDataBlock().getName();
		if ((%needType $= "Health" && (%type $= "RepairKit" || %type $= "RepairPatch") && %player.getDamagePercent() > 0) ||
			(%needType $= "Ammo" && (%type $= "MGClip" || %type $= "RifleClip" || %type $= "ShotgunClip" || %type $= "RShotgunClip" || %type $= "LSMClip" || %type $= "PistolClip" || %type $= "SnipergunAmmo" || %type $= "MG42Ammo" || %type $= "LMissileLauncherAmmo" || %type $= "AALauncherAmmo") && AICouldUseItem(%client, %item)) ||
			(%needType $= "Ammo" && AICanPickupWeapon(%type)) ||
			((%needType $= "" || %needType $= "Any") && AICouldUseItem(%client, %item)))
		{
			//first, see if it's close to us...
         		%distance = %client.getPathDistance(%item.getTransform());
			if (%distance > 0 && %distance < %closestDist)
			{
				//now see if it's got bad enemies near it...
				%clientCount = ClientGroup.getCount();
				for (%j = 0; %j < %clientCount; %j++)
				{
					%cl = ClientGroup.getObject(%j);
					if (%cl == %client || %cl.team == %client.team || !AIClientIsAlive(%cl))
						continue;

					//if the enemy is stronger, see if they're close to the item
					if (AIEngageWhoWillWin(%client, %cl) == %cl)
					{
						%tempDist = %client.getPathDistance(%item.getWorldBoxCenter());
						if (%tempDist > 0 && %tempDist < %distance + 50)
							continue;
					}

					//either no enemy, or a weaker one...
					%closestItem = %item;
					%closestDist = %distance;
				}
			}
		}
	}

	return %closestItem;
}

function AIChooseObjectWeapon(%client, %targetObject, %distToTarg, %mode, %canUseEnergyStr, %environmentStr)
{
   //get our inventory
   %player = %client.player;
	if (!isObject(%player))
		return;

	if (!isObject(%targetObject))
		return;

	%canUseEnergy = (%canUseEnergyStr $= "true");
	%inWater = (%environmentStr $= "water");
   %hasMG = (%player.getInventory("RPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1))); 
   %hasHMG = (%player.getInventory("HRPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1)));
   %hasKreig = (%player.getInventory("KreigRifle") > 0 && ((%player.getInventory("KreigAmmo") >= 1 && %player.getInventory("RifleClip") >= 1) || (%player.getInventory("KreigAmmo") >= 1 || %player.getInventory("RifleClip") >= 1)) && !%inwater);
   %hasLMG = (%player.getInventory("LSMG") > 0 && ((%player.getInventory("LSMGAmmo") >= 1 && %player.getInventory("LSMGClip") >= 1) || (%player.getInventory("LSMGAmmo") >= 1 || %player.getInventory("LSMGClip") >= 1)));
   %hasShotgun = (%player.getInventory("Shotgun") > 0 && ((%player.getInventory("ShotgunAmmo") >= 1 && %player.getInventory("ShotgunClip") >= 1) || (%player.getInventory("ShotgunAmmo") >= 1 || %player.getInventory("ShotgunClip") >= 1)) && !%inwater);
   %hasRShotgun = (%player.getInventory("RShotgun") > 0 && ((%player.getInventory("RShotgunAmmo") >= 1 && %player.getInventory("RShotgunClip") >= 1) || (%player.getInventory("RShotgunAmmo") >= 1 || %player.getInventory("RShotgunClip") >= 1)) && !%inwater);
   %hasPistol = (%player.getInventory("Pistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)) && !%inwater);
   %hasSPistol = (%player.getInventory("SPistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)) && !%inwater);
   %hasFlamer = (%player.getInventory("Flamer") > 0 && %player.getInventory("FlamerAmmo") >= 1 && !%inwater);
   %hasSniper = (%player.getInventory("Snipergun") > 0 && %player.getInventory("SnipergunAmmo") >= 1 && !%inwater);
   %hasBazooka = (%player.getInventory("Bazooka") > 0 && %player.getInventory("BazookaAmmo") >= 1);
   %hasAALauncher = (%player.getInventory("AALauncher") > 0 && %player.getInventory("AALauncherAmmo") >= 1 && !%inwater);
   %hasLMissileLauncher = (%player.getInventory("LMissileLauncher") > 0 && %player.getInventory("LMissileLauncherAmmo") >= 1 && !%inwater);
   %hasMG42 = (%player.getInventory("MG42") > 0 && %player.getInventory("MG42Ammo") >= 1);
   %hasTargetingLaser = (%player.getInventory("TargetingLaser") > 0);
   %hasRepairPack = (%player.getInventory("RepairPack") > 0) && %canUseEnergy;
   
   //see if we're destroying the object
   if (%mode $= "Destroy")
   {
		if ((%targetObject.getDataBlock().getClassName() $= "TurretData" ||
			  %targetObject.getDataBlock().getName() $= "MineDeployed") && %distToTarg < 50)
		{
         if (%hasFlamer)
            %useWeapon = "Flamer";
         else if (%hasBazooka)
            %useWeapon = "Bazooka";
         else if (%hasLMissileLauncher)
            %useWeapon = "LMissileLauncher";
         else
            %useWeapon = "NoAmmo";
		}
      else if (%distToTarg < 50)
      {
         if (%hasFlamer)
            %useWeapon = "Flamer";
         else if (%hasBazooka)
            %useWeapon = "Bazooka";
         else if (%hasMG)
            %useWeapon = "RPChaingun";
         else if (%hasHMG)
            %useWeapon = "HRPChaingun";
         else if (%hasLMG)
            %useWeapon = "LSMG";
         else if (%hasMG42)
            %useWeapon = "MG42";
         else if (%hasRShotgun)
            %useWeapon = "RShotgun";
         else
            %useWeapon = "NoAmmo";
      }
      else
         %useWeapon = "NoAmmo";
   }
   
   //else See if we're repairing the object
   else if (%mode $= "Repair")
   {
      if (%hasRepairPack)
         %useWeapon = "RepairPack";
      else
         %useWeapon = "NoAmmo";
   }
   
   //else see if we're lazing the object
   else if (%mode $= "Laze")
   {
      if (%hasTargetingLaser)
         %useWeapon = "TargetingLaser";
      else
         %useWeapon = "NoAmmo";
   }
   
   //else see if we're mortaring the object
   else if (%mode $= "Mortar")
   {
      if (%hasBazooka)
         %useWeapon = "Bazooka";
      else
         %useWeapon = "NoAmmo";
   }
   
   //else see if we're rocketing the object
   else if (%mode $= "Missile" || %mode $= "MissileNoLock")
   {
      if (%hasAALauncher)
         %useWeapon = "AALauncher";
      else if (%hasLMissileLauncher)
         %useWeapon = "LMissileLauncher";
      else
         %useWeapon = "NoAmmo";
   }
   
   //now select the weapon
   switch$ (%useWeapon)
   {
      case "RPChaingun":
         %client.player.use("RPChaingun");
         %client.setWeaponInfo("RPChaingunBullet",1,100,30);
      case "HRPChaingun":
         %client.player.use("HRPChaingun");
         %client.setWeaponInfo("RPChaingunBullet",1,100,30);
      case "Bazooka":
         %client.player.use("Bazooka");
         %client.setWeaponInfo("Bazookashot",10,1000);
      case "AALauncher":
         %client.player.use("AALauncher");
         %client.setWeaponInfo("AAMissile",15,750);
      case "LMissileLauncher":
         %client.player.use("LMissileLauncher");
         %client.setWeaponInfo("LShoulderMissile",10,300);
      case "LSMG":
         %client.player.use("LSMG");
         %client.setWeaponInfo("LSMGBullet",1,30,30);
      case "MG42":
         %client.player.use("MG42");
         %client.setWeaponInfo("MG42Bullet",1,30,200);
      case "RShotgun":
         %client.player.use("RShotgun");
         %client.setWeaponInfo("ShotgunPellet",1,25);
      case "Flamer":
         %client.player.use("Flamer");
         %client.setWeaponInfo("FlameboltMain",1,30);
      case "TargetingLaser":
         %client.player.use("TargetingLaser");
         %client.setWeaponInfo("BasicTargeter",1,1000);
      case "HRPChaingun":
         %client.player.use("RepairPack");
         %client.setWeaponInfo("DefaultRepairBeam",1,100);
      case "NoAmmo":
         %client.setWeaponInfo("NoAmmo", 30, 75);
   }
}

function AIChooseEngageWeapon(%client, %targetClient, %distToTarg, %canUseEnergyStr, %environmentStr)
{
	//get some status
   %player = %client.player;
	if (!isObject(%player))
		return;

   %enemy = %targetClient.player;
	if (!isObject(%enemy))
		return;
	
	%canUseEnergy = (%canUseEnergyStr $= "true");
	%inWater = (%environmentStr $= "water");
	%outdoors = (%environmentStr $= "outdoors");
	%targVelocity = %targetClient.player.getVelocity();
	%targEnergy = %targetClient.player.getEnergyPercent();
	%targDamage = %targetClient.player.getDamagePercent();
	%myEnergy = %player.getEnergyPercent();
	%myDamage = %player.getDamagePercent();

   //get our inventory
   %hasMG = (%player.getInventory("RPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1))); 
   %hasHMG = (%player.getInventory("HRPChaingun") > 0 && ((%player.getInventory("RPChaingunAmmo") >= 1 && %player.getInventory("MGClip") >= 1) || (%player.getInventory("RPChaingunAmmo") >= 1 || %player.getInventory("MGClip") >= 1)));
   %hasKreig = (%player.getInventory("KreigRifle") > 0 && ((%player.getInventory("KreigAmmo") >= 1 && %player.getInventory("RifleClip") >= 1) || (%player.getInventory("KreigAmmo") >= 1 || %player.getInventory("RifleClip") >= 1)) && !%inwater);
   %hasLMG = (%player.getInventory("LSMG") > 0 && ((%player.getInventory("LSMGAmmo") >= 1 && %player.getInventory("LSMGClip") >= 1) || (%player.getInventory("LSMGAmmo") >= 1 || %player.getInventory("LSMGClip") >= 1)));
   %hasShotgun = (%player.getInventory("Shotgun") > 0 && ((%player.getInventory("ShotgunAmmo") >= 1 && %player.getInventory("ShotgunClip") >= 1) || (%player.getInventory("ShotgunAmmo") >= 1 || %player.getInventory("ShotgunClip") >= 1)) && !%inwater);
   %hasRShotgun = (%player.getInventory("RShotgun") > 0 && ((%player.getInventory("RShotgunAmmo") >= 1 && %player.getInventory("RShotgunClip") >= 1) || (%player.getInventory("RShotgunAmmo") >= 1 || %player.getInventory("RShotgunClip") >= 1)) && !%inwater);
   %hasPistol = (%player.getInventory("Pistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)) && !%inwater);
   %hasSPistol = (%player.getInventory("SPistol") > 0 && ((%player.getInventory("PistolAmmo") >= 1 && %player.getInventory("PistolClip") >= 1) || (%player.getInventory("PistolAmmo") >= 1 || %player.getInventory("PistolClip") >= 1)) && !%inwater);
   %hasFlamer = (%player.getInventory("Flamer") > 0 && %player.getInventory("FlamerAmmo") >= 1 && !%inwater);
   %hasSniper = (%player.getInventory("Snipergun") > 0 && %player.getInventory("SnipergunAmmo") >= 1 && !%inwater);
   %hasBazooka = (%player.getInventory("Bazooka") > 0 && %player.getInventory("BazookaAmmo") >= 1);
   %hasAALauncher = (%player.getInventory("AALauncher") > 0 && %player.getInventory("AALauncherAmmo") >= 1 && !%inwater);
   %hasLMissileLauncher = (%player.getInventory("LMissileLauncher") > 0 && %player.getInventory("LMissileLauncherAmmo") >= 1 && !%inwater);
   %hasMG42 = (%player.getInventory("MG42") > 0 && %player.getInventory("MG42Ammo") >= 1);
   
   //choose the weapon
   %useWeapon = "NoAmmo";

   //first, see if it's a pilot we're shooting
   if (%dist > 50 && %enemy.isMounted())
   {
	if(%hasAALauncher)
		%useWeapon = "AALauncher";
	else if(%hasBazooka)
		%useWeapon = "Bazooka";
	else if(%hasLMissileLauncher)
		%useWeapon = "LMissileLauncher";
	else if(%hasMG42)
		%useWeapon = "MG42";
	else if(%hasMG)
		%useWeapon = "RPChaingun";
	else if(%hasHMG)
		%useWeapon = "HRPChaingun";
   }
   else if (%distToTarg < 30)
   {
      if (%hasRShotgun)
         	%useWeapon = "RShotgun";
      else if (%hasShotgun)
         	%useWeapon = "Shotgun";
	else if (%hasFlamer)
		%useWeapon = "Flamer";
	else if (%hasMG42)
		%useWeapon = "MG42";
	else if (%hasLSMG)
		%useWeapon = "LSMG";
      else if (%hasMG)
         	%useWeapon = "RPChaingun";
	else if (%hasHMG)
		%useWeapon = "HRPChaingun";
      else if (%hasSPistol)
         	%useWeapon = "SPistol";
      else if (%hasPistol)
         	%useWeapon = "Pistol";
   }
   else if (%distToTarg < 80)
   {
	if (%hasMG42)
		%useWeapon = "MG42";
	else if (%hasLSMG)
		%useWeapon = "LSMG";
      else if (%hasRShotgun)
         	%useWeapon = "RShotgun";
	else if (%hasFlamer)
		%useWeapon = "Flamer";
      else if (%hasShotgun)
         	%useWeapon = "Shotgun";
      else if (%hasMG)
         	%useWeapon = "RPChaingun";
	else if (%hasHMG)
		%useWeapon = "HRPChaingun";
      else if (%hasSPistol)
         	%useWeapon = "SPistol";
      else if (%hasPistol)
         	%useWeapon = "Pistol";
      else if (%hasKreig)
         	%useWeapon = "KreigRifle";
   }
   else if (%distToTarg < 150)
   {
      if (%hasMG)
         	%useWeapon = "RPChaingun";
	else if (%hasHMG)
		%useWeapon = "HRPChaingun";
      else if (%hasKreig)
         	%useWeapon = "KreigRifle";
	else if (%hasMG42)
		%useWeapon = "MG42";
	else if (%hasLSMG)
		%useWeapon = "LSMG";
	else if (%hasSniper)
		%useWeapon = "Snipergun";
      else if (%hasSPistol)
         	%useWeapon = "SPistol";
   }
   else if (%distToTarg < 200)
   {
      if (%hasKreig)
         	%useWeapon = "KreigRifle";
	else if (%hasSniper)
		%useWeapon = "Snipergun";
      else if (%hasMG)
         	%useWeapon = "RPChaingun";
	else if (%hasHMG)
		%useWeapon = "HRPChaingun";

   }
   else if (%distToTarg < 250)
   {
	if (%hasSniper)
		%useWeapon = "Snipergun";
      else if (%hasKreig)
         	%useWeapon = "KreigRifle";
   }
   else
   {
   	if (%hasSniper)
	   %useWeapon = "Snipergun";
   }

	//now make sure we actually selected something
   if (%useWeapon $= "NoAmmo")
   {
      if (%hasMG)
         	%useWeapon = "RPChaingun";
	else if (%hasHMG)
		%useWeapon = "HRPChaingun";
      else if (%hasKreig)
         	%useWeapon = "KreigRifle";
	else if (%hasMG42)
		%useWeapon = "MG42";
	else if (%hasLSMG)
		%useWeapon = "LSMG";
	else if (%hasSniper)
		%useWeapon = "Snipergun";
	else if (%hasFlamer)
		%useWeapon = "Flamer";
      else if (%hasSPistol)
         	%useWeapon = "SPistol";
      else if (%hasPistol)
         	%useWeapon = "Pistol";
      else if (%hasShotgun)
         	%useWeapon = "Shotgun";
      else if (%hasRShotgun)
         	%useWeapon = "RShotgun";
	else if(%hasBazooka)
		%useWeapon = "Bazooka";
	else if(%hasLMissileLauncher)
		%useWeapon = "LMissileLauncher";
	else if(%hasAALauncher)
		%useWeapon = "AALauncher";
   }

   //now select the weapon
   switch$ (%useWeapon)
   {
      case "RPChaingun":
         %client.player.use("RPChaingun");
         %client.setWeaponInfo("RPChaingunBullet",5,200,30);
      case "HRPChaingun":
         %client.player.use("HRPChaingun");
         %client.setWeaponInfo("RPChaingunBullet",5,200,30);
      case "LSMG":
         %client.player.use("LSMG");
         %client.setWeaponInfo("LSMGBullet",5,120,30);
      case "KreigRifle":
         %client.player.use("KreigRifle");
         %client.setWeaponInfo("KreigBullet",15,400);
      case "Snipergun":
         %client.player.use("Snipergun");
         %client.setWeaponInfo("SnipergunBullet",150,2000);
      case "MG42":
         %client.player.use("MG42");
         %client.setWeaponInfo("MG42Bullet",1,120,200);
      case "Pistol":
         %client.player.use("Pistol");
         %client.setWeaponInfo("coltBullet",3,100);
      case "SPistol":
         %client.player.use("SPistol");
         %client.setWeaponInfo("coltBullet",3,100);
      case "Shotgun":
         %client.player.use("Shotgun");
         %client.setWeaponInfo("ShotgunPellet",1,30);
      case "RShotgun":
         %client.player.use("RShotgun");
         %client.setWeaponInfo("ShotgunPellet",1,30);
      case "Bazooka":
         %client.player.use("Bazooka");
         %client.setWeaponInfo("Bazookashot",20,1000);
      case "AALauncher":
         %client.player.use("AALauncher");
         %client.setWeaponInfo("AAMissile",15,750);
      case "LMissileLauncher":
         %client.player.use("LMissileLauncher");
         %client.setWeaponInfo("LShoulderMissile",10,300);
      case "Flamer":
         %client.player.use("Flamer");
         %client.setWeaponInfo("FlameboltMain",5,60);
      case "NoAmmo":
         %client.setWeaponInfo("NoAmmo", 30, 75);
   }
}

//function is called once per frame, to handle packs, healthkits, grenades, etc...
function AIProcessEngagement(%client, %target, %type, %projectile)
{
   //make sure we're still alive
	if (! AIClientIsAlive(%client))
		return;

	//clear the pressFire
	%client.pressFire(-1);

	//see if we have to use a repairkit
	%player = %client.player;
	if (!isObject(%player))
		return;

	if (%client.getSkillLevel() > 0.1 && %player.getDamagePercent() > 0.3 && %player.getInventory("RepairKit") > 0)
	{
		//add in a "skill" value to delay the using of the repair kit for up to 10 seconds...
		%elapsedTime = getSimTime() - %client.lastDamageTime;
		%skillValue = (1.0 - %client.getSkillLevel()) * (1.0 - %client.getSkillLevel());
		if (%elapsedTime > (%skillValue * 20000))
	      %player.use("RepairKit");
	}

	//see if we've been blinded
	if (%player.getWhiteOut() > 0.6)
		%client.setBlinded(2000);

	//else see if there's a grenade in the vicinity...
	else
	{
		%count = $AIGrenadeSet.getCount();
		for (%i = 0; %i < %count; %i++)
		{
			%grenade = $AIGrenadeSet.getObject(%i);

			//make sure the grenade isn't ours
			if (%grenade.sourceObject.client != %client)
			{
				//see if it's within 15 m
				if (VectorDist(%grenade.position, %client.player.position) < 15)
				{
					%client.setDangerLocation(%grenade.position, 20);
					break;
				}
			}
		}
	}

	//if we're being hunted by a seeker projectile, throw a flare grenade
	if (%player.getInventory("FlareGrenade") > 0)
	{
		%missileCount = MissileSet.getCount();
		for (%i = 0; %i < %missileCount; %i++)
		{
			%missile = MissileSet.getObject(%i);
			if (%missile.getTargetObject() == %player)
			{
				//see if the missile is within range
				if (VectorDist(%missile.getTransform(), %player.getTransform()) < 50)
				{
					%player.throwStrength = 1.5;
					%player.use("FlareGrenade");
					break;
				}
			}
		}
	}

	//see what we're fighting
	switch$ (%type)
	{
		case "player":
			//make sure the target is alive
			if (AIClientIsAlive(%target))
			{
				//if the target is in range, and within 10-40 m, and heading in this direction, toss a grenade
				if (!$AIDisableGrenades && %client.getSkillLevel() >= 0.3)
				{
					if (%player.getInventory("Grenade") > 0)
						%grenadeType = "Grenade";
					else if (%player.getInventory("FlashGrenade") > 0)
						%grenadeType = "FlashGrenade";
					else if (%player.getInventory("ConcussionGrenade") > 0)
						%grenadeType = "ConcussionGrenade";
					else %grenadeType = "";
					if (%grenadeType !$= "" && %client.targetInSight())
					{
						//see if the predicted location of the target is within 10m 
						%targPos = %target.player.getWorldBoxCenter();
						%clientPos = %player.getWorldBoxCenter();

						//make sure we're not *way* above the target
						if (getWord(%clientPos, 2) - getWord(%targPos, 2) < 3)
						{
							%dist = VectorDist(%targPos, %clientPos);
							%direction = VectorDot(VectorSub(%clientPos, %targPos), %target.player.getVelocity());  
							%facing = VectorDot(VectorSub(%client.getAimLocation(), %clientPos), VectorSub(%targPos, %clientPos));
							if (%dist > 20 && %dist < 45 && (%direction > 0.9 || %direction < -0.9) && (%facing > 0.9))
							{
								%player.throwStrength = 1.0;
								%player.use(%grenadeType);
							}
						}
					}
				}

				//see if we have a shield pack that we need to use
				if (%player.getInventory("ShieldPack") > 0)
				{
					if (%projectile > 0 && %player.getImageState($BackpackSlot) $= "Idle")
					{
						%player.use("Backpack");
					}
					else if (%projectile <= 0 && %player.getImageState($BackpackSlot) $= "activate")
					{
						%player.use("Backpack");
					}
				}
			}

		case "object":
				%hasGrenade = %player.getInventory("Grenade");
				if (%hasGrenade && %client.targetInRange())
				{
					%targPos = %target.getWorldBoxCenter();
					%myPos = %player.getWorldBoxCenter();
					%dist = VectorDist(%targPos, %myPos);
					if (%dist > 5 && %dist < 20)
					{
						%player.throwStrength = 1.0;
						%player.use("Grenade");
					}
				}

		case "none":
			//use the repair pack if we have one
			if (%player.getDamagePercent() > 0 && %player.getInventory(RepairPack) > 0)
			{
				if (%player.getImageState($BackpackSlot) $= "Idle")
		         %client.player.use("RepairPack");
				else
					//sustain the fire for 30 frames - this callback is timesliced...
					%client.pressFire(30);
			}
	}
}

function AIFindClosestInventory(%client, %armorChange)
{
	%closestInv = -1;
	%closestDist = 32767;
   
   %depCount = 0;
   %depGroup = nameToID("MissionCleanup/Deployables");
   if (%depGroup > 0)
      %depCount = %depGroup.getCount();
	
   // there exists a deployed station, lets find it
   if(!%armorChange && %depCount > 0)
   {
      for(%i = 0; %i < %depCount; %i++)
      {
         %obj = %depGroup.getObject(%i);
         
         if(%obj.getDataBlock().getName() $= "DeployedStationInventory" && %obj.team == %client.team && %obj.isEnabled())
         {
            %distance = %client.getPathDistance(%obj.getTransform());
            if (%distance > 0 && %distance < %closestDist)
            {   
               %closestInv = %obj;
               %closestDist = %distance;              
            }
         }   
      }
   }
   
   // still check if there is one that is closer
   %invCount = $AIInvStationSet.getCount();
	for (%i = 0; %i < %invCount; %i++)
	{
		%invStation = $AIInvStationSet.getObject(%i);
		if (%invStation.team <= 0 || %invStation.team == %client.team)
		{
			//error("DEBUG: found an inventory station: " @ %invStation @ "  status: " @ %invStation.isPowered());
			//make sure the station is powered
			if (!%invStation.isDisabled() && %invStation.isPowered())
			{
				%dist = %client.getPathDistance(%invStation.getTransform());
				if (%dist > 0 && %dist < %closestDist)
				{
					%closestInv = %invStation;
					%closestDist = %dist;
				}
			}
		}
	}

	return %closestInv @ " " @ %closestDist;
}

//------------------------------
//find the closest inventories for the objective weight functions
function AIFindClosestInventories(%client)
{
	%closestInv = -1;
	%closestDist = 32767;
	%closestRemoteInv = -1;
	%closestRemoteDist = 32767;
   
   %depCount = 0;
   %depGroup = nameToID("MissionCleanup/Deployables");
	
	//first, search for the nearest deployable inventory station
	if (isObject(%depGroup))
	{
	   %depCount = %depGroup.getCount();
	   for (%i = 0; %i < %depCount; %i++)
	   {
	      %obj = %depGroup.getObject(%i);
	      
	      if (%obj.getDataBlock().getName() $= "DeployedStationInventory" && %obj.team == %client.team && %obj.isEnabled())
	      {
	         %distance = %client.getPathDistance(%obj.getTransform());
	         if (%distance > 0 && %distance < %closestRemoteDist)
	         {   
	            %closestRemoteInv = %obj;
	            %closestRemoteDist = %distance;              
	         }
	      }   
	   }
	}
   
   // now find the closest regular inventory station
   %invCount = $AIInvStationSet.getCount();
	for (%i = 0; %i < %invCount; %i++)
	{
		%invStation = $AIInvStationSet.getObject(%i);
		if (%invStation.team <= 0 || %invStation.team == %client.team)
		{
			//make sure the station is powered
			if (!%invStation.isDisabled() && %invStation.isPowered())
			{
				%dist = %client.getPathDistance(%invStation.getTransform());
				if (%dist > 0 && %dist < %closestDist)
				{
					%closestInv = %invStation;
					%closestDist = %dist;
				}
			}
		}
	}

	//if the regular inv station is closer than the deployed, don't bother with the remote
	if (%closestDist < %closestRemoteDist)
		%returnStr = %closestInv SPC %closestDist;
	else
		%returnStr = %closestInv SPC %closestDist SPC %closestRemoteInv SPC %closestRemoteDist;

	return %returnStr;
}

//------------------------------
//AI Equipment Configs
$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyAmmoSet, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyShieldSet, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyEnergySet, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyRepairSet, $EquipConfigIndex++] = "BeaconSmokeGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyIndoorTurretSet, $EquipConfigIndex++] = "BeaconSmokeGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "Heavy";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "MG42";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "Mg42Ammo";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "RShotgun";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "RShotgunAmmo";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "RShotgunClip";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[HeavyInventorySet, $EquipConfigIndex++] = "BeaconSmokeGrenade";

//------------------------------

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "RepairPack";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "HRPChaingun";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "RPGAmmo";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "Shotgun";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "ShotgunAmmo";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "ShotgunClip";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "BeaconSmokeGrenade";
$AIEquipmentSet[MediumRepairSet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "InventoryDeployable";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "HRPChaingun";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "RPGAmmo";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "FlareGrenade";
$AIEquipmentSet[MediumInventorySet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "SatchelCharge";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "HRPChaingun";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "RPGAmmo";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "Bazooka";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "BazookaAmmo";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "Grenade";
$AIEquipmentSet[MediumShieldSet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "HRPChaingun";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "RPGAmmo";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "AALauncher";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "AALauncherAmmo";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "Grenade";
$AIEquipmentSet[MediumMissileSet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Shotgun";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "ShotgunAmmo";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "ShotgunClip";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Snipergun";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "SnipergunAmmo";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Grenade";
$AIEquipmentSet[MediumEnergySet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "HRPChaingun";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "RPGAmmo";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "Bazooka";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "BazookaAmmo";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "Grenade";
$AIEquipmentSet[MediumOutdoorTurretSet, $EquipConfigIndex++] = "Mine";

$EquipConfigIndex = -1;
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "Medium";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "KreigRifle";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "KreigAmmo";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "RifleClip";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "Grenade";
$AIEquipmentSet[MediumIndoorTurretSet, $EquipConfigIndex++] = "Mine";

//------------------------------

$EquipConfigIndex = -1;
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "RPChaingun";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "RPChaingunAmmo";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "MGClip";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightEnergyDefault, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "Shotgun";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "ShotgunAmmo";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "ShotgunClip";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightShieldSet, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "RepairPack";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightRepairSet, $EquipConfigIndex++] = "smokebeaconGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "RepairPack";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "snipergun";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "snipergunAmmo";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightEnergySniper, $EquipConfigIndex++] = "SmokeGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "SatchelCharge";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightCloakSet, $EquipConfigIndex++] = "SmokeGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "Light";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "FlamerAmmoPack";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "Flamer";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "FlamerAmmo";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "Pistol";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "melee";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightEnergyELF, $EquipConfigIndex++] = "Grenade";

//---------------------------

$EquipConfigIndex = -1;
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "SpecOps";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "KreigRifle";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "KreigAmmo";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "RifleClip";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "SPistol";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "SOmelee";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[LightSniperChain, $EquipConfigIndex++] = "FlashGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "SpecOps";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "Snipergun";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "SnipergunAmmo";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "SPistol";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "SOmelee";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[SpecOpsSet2, $EquipConfigIndex++] = "SmokeGrenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "SpecOps";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "AmmoPack";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "LMissileLauncher";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "LMissileLauncherAmmo";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "SPistol";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "SOmelee";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[SpecOpsSet3, $EquipConfigIndex++] = "Grenade";

$EquipConfigIndex = -1;
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "SpecOps";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "SatchelCharge";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "LSMG";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "LSMGAmmo";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "LSMGClip";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "KreigRifle";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "KreigAmmo";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "RifleClip";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "SPistol";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "PistolAmmo";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "PistolClip";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "SOmelee";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "TargetingLaser";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "RepairKit";
$AIEquipmentSet[SpecOpsSet4, $EquipConfigIndex++] = "Grenade";

