//----------------------------------------------------------------------------

// When first mounted (assuming there is ammo):
//    SingleShot     activate -> ready
//    Spinning       activate -> idle (spin 0)
//    Sustained      activate -> ready
//    DiscLauncher   activate -> reload -> spinup -> ready
//
// Normal operation:
//    SingleShot     ready -> fire -> reload -> ready
//    Spinning       idle (spin 0) -> spinup -> ready -> fire -> spindown -> idle
//    Sustained      ready -> fire -> reload -> ready
//    DiscLauncher   ready -> fire -> reload -> spinup -> ready

// Image properties
//    emap
//    preload
//    shapeFile
//    mountPoint
//    offset
//    rotation
//    firstPerson
//    mass
//    usesEnergy
//    minEnergy
//    accuFire
//    lightType
//    lightTime
//    lightRadius
//    lightColor

// Image state variables
//    stateName
//    stateTransitionOnLoaded
//    stateTransitionOnNotLoaded
//    stateTransitionOnAmmo
//    stateTransitionOnNoAmmo
//    stateTransitionOnTriggerUp
//    stateTransitionOnTriggerDown
//    stateTransitionOnTimeout
//    stateTimeoutValue
//    stateFire
//    stateEnergyDrain
//    stateAllowImageChange
//    stateScaleAnimation
//    stateDirection
//    stateLoadedFlag
//    stateSpinThread
//    stateRecoil
//    stateSequence
//    stateSound
//    stateScript
//    stateEmitter
//    stateEmitterTime
//    stateEmitterNode

//----------------------------------------------------------------------------

$ItemRespawnTime = 30000;
$ItemPopTime = 60 * 1000;

$WeaponSlot = 0;
$AuxiliarySlot = 1;
$BackpackSlot = 2;
$FlagSlot = 3;

//----------------------------------------------------------------------------
datablock EffectProfile(ItemPickupEffect)
{
    effectname = "packs/packs.pickupPack";
    minDistance = 2.5;
};

datablock AudioProfile(ItemPickupSound)
{
   filename = "fx/packs/packs.pickuppack.wav";
   description = AudioClosest3d;
   effect = ItemPickupEffect;
   preload = true;
};

datablock EffectProfile(ItemThrowEffect)
{
   effectname = "packs/packs.throwpack";
   minDistance = 2.5;
	maxDistance = 2.5;
};

datablock AudioProfile(ItemThrowSound)
{
   filename = "fx/packs/packs.throwpack.wav";
   description = AudioClosest3d;
   effect = ItemThrowEffect;
   preload = true;
};

datablock AudioProfile(RepairPatchSound)
{
   filename    = "fx/misc/health_patch.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ItemPickupEffect;
   preload = true;
};

function ItemData::create(%block)
{
   if(%block $= "flag")
      %obj = new Item() {
         className = FlagObj;
         dataBlock = %block;
         static = false;
         rotate = false;
      };
   else
      %obj = new Item() {
         dataBlock = %block;
         static = true;
         //rotate = true;
         // don't make "placed items" rotate
         rotate = false;
      };
   return(%obj);
}

//--------------------------------------------------------------------------
function Item::schedulePop(%this)
{
   %itemFadeTime = 1000; // items will take 1 second (1000 milliseconds) to fade out
   %this.startFade(%itemFadeTime, $ItemPopTime - %itemFadeTime, true);
   %this.schedule($ItemPopTime, "delete");
}

function Item::respawn(%this)
{
   %this.startFade(0, 0, true);
   %this.schedule($ItemRespawnTime + 100, "startFade", 1000, 0, false);
   %this.hide(true);
   %this.schedule($ItemRespawnTime, "hide", false);
}

//--------------------------------------------------------------------------
function ItemData::onThrow(%data,%obj,%shape)
{
   serverPlay3D(ItemThrowSound, %obj.getTransform());
   // don't schedule a delete for satchelCharges when they're deployed
   if(!%data.noTimeout)
      %obj.schedulePop();
}

function ItemData::onInventory(%data,%shape,%value)
{
   if (!%value) {
      // If we don't have any more of these items, make sure
      // we don't have an image mounted.
      %slot = %shape.getMountSlot(%data.image);
      if (%slot != -1)
         %shape.unmountImage(%slot);
   }
}

function ItemData::onEnterLiquid(%data, %obj, %coverage, %type)
{
   if(%data.isInvincible)
      return;

   switch(%type)
   {
      case 0:
         //Water
      case 1:
         //Ocean Water
      case 2:
         //River Water
      case 3:
         //Stagnant Water
      case 4:
         //Lava
         %obj.delete();
      case 5:
         //Hot Lava
         %obj.delete();
      case 6:
         //Crusty Lava
         %obj.delete();
      case 7:
         //Quick Sand
   }
}

function ItemData::onLeaveLiquid(%data, %obj, %type)
{
   // dummy
}

function ItemData::onCollision(%data,%obj,%col)
{
   // Default behavior for items is to get picked
   // by the colliding object.
   if (%col.getDataBlock().className $= Armor && %col.getState() !$= "Dead")
   {
      if (%col.isMounted())
         return;

      if (%col.pickup(%obj, 1))
      {
         if (%col.client && !%obj.dispenser)
         {
            messageClient(%col.client, 'MsgItemPickup', '\c0You picked up %1.', %data.pickUpName);
            serverPlay3D(ItemPickupSound, %col.getTransform());
         }
      //[most] Litle hook to respawn dispenser packs
      //       it's this or a schedule.. and I don't feel like that.. :P  
         %respawn = %obj.dispenser;
         if (%obj.isStatic())
            %obj.respawn();
         else
            %obj.delete();
        
      if (IsObject(%respawn))
         respawnpack(%respawn,1);      
      //[most]
      }
   }
}

//----------------------------------------------------------------------------
datablock ItemData(RepairKit)
{
   className = HandInventory;
   catagory = "Misc";
   shapeFile = "repair_kit.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2.0;
   pickUpName = "a repair kit";
   alwaysAmbient = true;

   computeCRC = true;
   emap = true;

};

function RepairKit::onUse(%data,%obj) {
	// Don't use the kit unless we're damaged
	if (%obj.getDamageLevel() != 0) {
		%obj.decInventory(%data,1);
		%obj.applyRepair(0.2);
		messageClient(%obj.client, 'MsgRepairKitUsed', '\c2Repair Kit Used.');
	}
}

//----------------------------------------------------------------------------

datablock ItemData(RepairPatch)
{
   catagory = "Misc";
   shapeFile = "repair_patch.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2.0;
   pickUpName = "a repair patch";
   alwaysAmbient = true;

   computeCRC = true;
   emap = true;

};

function RepairPatch::onCollision(%data,%obj,%col)
{
   if ( %col.getDataBlock().className $= Armor
     && %col.getDamageLevel() != 0
     && %col.getState() !$= "Dead" )
   {
      if (%col.isMounted())
         return;

      %col.playAudio(0, RepairPatchSound);
      %col.applyRepair(0.125);

      // Eolk - cure in zombieGame.
      if(%col.infected && Game.class $= "ZombieGame")
      {
         %col.infected = 0;
         cancel(%col.infectedDamage);
         %col.infectedDamage = "";
         %col.beats = 0;
         %col.canZkill = 0;
         cancel(%col.zombieAttackImpulse);
      }

      %obj.respawn();
      if (%col.client > 0)
         messageClient(%col.client, 'MsgItemPickup', '\c0You picked up %1.', %data.pickUpName);
   }
}

//----------------------------------------------------------------------------
// Flag:
//----------------------------------------------------------------------------
datablock ShapeBaseImageData(FlagImage)
{
   shapeFile = "flag.dts";
   item = Flag;
   mountPoint = 2;
   offset = "0 0 0";

   lightType = "PulsingLight";
   lightColor = "0.5 0.5 0.5 1.0";
   lightTime = "1000";
   lightRadius = "3";
   cloakable = false;
};

datablock ItemData(Flag)
{
   catagory = "Objectives";
   shapefile = "flag.dts";
   mass = 55;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 3;
   pickUpName = "a flag";
   computeCRC = true;

   lightType = "PulsingLight";
   lightColor = "0.5 0.5 0.5 1.0";
   lightTime = "1000";
   lightRadius = "3";

   isInvincible = true;
   cmdCategory = "Objectives";
   cmdIcon = CMDFlagIcon;
   cmdMiniIconName = "commander/MiniIcons/com_flag_grey";
   targetTypeTag = 'Flag';

   //used in CTF to mark the flag during a stalemate...
   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;
   hudRenderName[1] = true;
};

//----------------------------------------------------------------------------
function Flag::onThrow(%data,%obj,%src)
{
   Game.playerDroppedFlag(%src);
}

function Flag::onAdd(%this, %obj)
{
   // make sure flags play "flapping" ambient thread
   Parent::onAdd(%this, %obj);
   %obj.playThread($AmbientThread, "ambient");

   %blocker = new VehicleBlocker()
   {
      position = %obj.position;
      rotation = %obj.rotation;
      dimensions = "2 2 4";
   };
   MissionCleanup.add(%blocker);
}

function Flag::onCollision(%data,%obj,%col)
{
   if (%col.getDataBlock().className $= Armor && !%col.client.isJailed)
   {
      if (%col.isMounted())
         return;

      // a player hit the flag
      Game.playerTouchFlag(%col, %obj);
   }
}

//----------------------------------------------------------------------------
// HuntersFlag:
//----------------------------------------------------------------------------
datablock ShapeBaseImageData(HuntersFlagImage)
{
   shapeFile = "Huntersflag.dts";
   item = Flag;
   mountPoint = 2;
   offset = "0 0 0";

   lightType = "PulsingLight";
   lightColor = "0.5 0.5 0.5 1.0";
   lightTime = "1000";
   lightRadius = "3";
};

// 1: red
// 2: blue
// 4: yellow
// 8: green
datablock ItemData(HuntersFlag1)
{
   className = HuntersFlag;

   shapefile = "Huntersflag.dts";
   mass = 75;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 3;
   isInvincible = true;
   pickUpName = "a flag";
   computeCRC = true;

   lightType = "PulsingLight";
   lightColor = "0.8 0.2 0.2 1.0";
   lightTime = "1000";
   lightRadius = "3";
};

datablock ItemData(HuntersFlag2) : HuntersFlag1
{
   lightColor = "0.2 0.2 0.8 1.0";
};

datablock ItemData(HuntersFlag4) : HuntersFlag1
{
   lightColor = "0.8 0.8 0.2 1.0";
};

datablock ItemData(HuntersFlag8) : HuntersFlag1
{
   lightColor = "0.2 0.8 0.2 1.0";
};

function HuntersFlag::onRemove(%data, %obj)
{
   // dont want target removed...
}

function HuntersFlag::onThrow(%data,%obj,%src)
{
   Game.playerDroppedFlag(%src);
}

function HuntersFlag::onCollision(%data,%obj,%col)
{
   if (%col.getDataBlock().className $= Armor && !%col.client.isJailed)
   {
      if (%col.isMounted())
         return;

      // a player hit the flag
      Game.playerTouchFlag(%col, %obj);
   }
}

//----------------------------------------------------------------------------
// Nexus:
//----------------------------------------------------------------------------
datablock ItemData(Nexus)
{
   catagory = "Objectives";
   shapefile = "nexus_effect.dts";
   mass = 10;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   icon = "CMDNexusIcon";
   targetTypeTag = 'Nexus';

   computeCRC = true;

};

datablock ParticleData(NexusParticleDenied)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 3.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 400;

   textureName          = "particleTest";

   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   colors[0]     = "0.3 0.0 0.0 1.0";
   colors[1]     = "0.5 0.0 0.0 0.5";
   colors[2]     = "0.7 0.0 0.0 0.0";
   sizes[0]      = 0.2;
   sizes[1]      = 0.1;
   sizes[2]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(NexusParticleDeniedEmitter)
{
   ejectionPeriodMS = 2;
   ejectionOffset = 0.2;
   periodVarianceMS = 0.5;
   ejectionVelocity = 10.0;
   velocityVariance = 4.0;
   thetaMin         = 0.0;
   thetaMax         = 30.0;
   lifetimeMS       = 0;

   particles = "NexusParticleDenied";
};

datablock ParticleData(NexusParticleCap)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 3.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 1200;
   lifetimeVarianceMS   = 400;

   textureName          = "particleTest";

   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   colors[0]     = "0.5 0.8 0.2 1.0";
   colors[1]     = "0.6 0.9 0.3 1.0";
   colors[2]     = "0.7 1.0 0.4 1.0";
   sizes[0]      = 0.2;
   sizes[1]      = 0.1;
   sizes[2]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(NexusParticleCapEmitter)
{
   ejectionPeriodMS = 2;
   ejectionOffset = 0.5;
   periodVarianceMS = 0.5;
   ejectionVelocity = 10.0;
   velocityVariance = 4.0;
   thetaMin         = 0.0;
   thetaMax         = 30.0;
   lifetimeMS       = 0;

   particles = "NexusParticleCap";
};

//----------------------------------------------------------------------------

function getVector(%string, %num)
{
   %start = %num * 3;
   return getWords(%string,%start, %start + 2);
}

// --------------------------------------------
// explosion datablock
// --------------------------------------------

datablock ExplosionData(DeployablesExplosion)
{
   soundProfile = DeployablesExplosionSound;
   faceViewer = true;

   explosionShape = "effect_plasma_explosion.dts";
   sizes[0] = "0.2 0.2 0.2";
   sizes[1] = "0.3 0.3 0.3";
};

$TeamDeployableMax[TargetBeacon] = 10;
$TeamDeployableMax[MarkerBeacon] = 20;

datablock ItemData(Beacon)
{
   className = HandInventory;
   catagory = "Misc";
   shapeFile = "beacon.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.8;
   pickupRadius = 1;
   pickUpName = "a deployable beacon";
   hasLight = true;
   //lightType = "PulsingLight";
   lightColor = "0.5 0.5 0.5 1.0";
   //lightTime = "100";
   lightRadius = "3";


   computeCRC = true;

};

datablock StaticShapeData(DeployedBeacon) : StaticShapeDamageProfile
{
   shapeFile = "beacon.dts";
   explosion = DeployablesExplosion;
   maxDamage = 0.45;
   disabledLevel = 0.45;
   destroyedLevel = 0.45;
   targetNameTag = 'beacon';
   hasLight = true;
   lightType = "PulsingLight";
   lightColor = "0.5 0.5 0.5 1.0";
   lightTime = "100";
   lightRadius = "3";

   deployedObject = true;

   dynamicType = $TypeMasks::SensorObjectType;

   debrisShapeName = "debris_generic_small.dts";
   debris = SmallShapeDebris;
};

function DeployedBeacon::onDestroyed(%data, %obj, %prevState)
{
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
   if(%obj.getBeaconType() $= "friend")
      %bType = "MarkerBeacon";
   else
      %bType = "TargetBeacon";
   $TeamDeployedCount[%obj.team, %bType]--;
	remDSurface(%obj);
   %obj.schedule(500, delete);
}

function Beacon::onUse(%data, %obj)
{
   %armortype = %obj.getdatablock().getname();
   if(%armortype $= "ControlLordZombieArmor")
   {
      %pos        = %obj.getMuzzlePoint($WeaponSlot);
      %vec        = %obj.getMuzzleVector($WeaponSlot);
      %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
      // Eolk - add new masks to keep people from grabbing through walls, etc.
      %masks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $Typemasks::PlayerObjectType;
      %Tobj       = containerraycast(%pos, %targetpos, %masks, %obj);
      %Tobj       = getword(%Tobj,0);
      if(isObject(%Tobj) && %Tobj.getType() & $TypeMasks::PlayerObjectType && strstr(%Tobj.getDatablock().getName(), "Zombie") == -1)
      {
         %temp = %obj.getForwardVector();
         %temp2 = %Tobj.getForwardVector();
         if(vectorDist(%temp,%temp2) > 5)
            return;

         Llifttarget(%obj, %Tobj, 0);
         %obj.setMoveState(true);
         %obj.schedule(150 * 13, "setMoveState", false);
         return;
      }
   }

   // look for 3 meters along player's viewpoint for interior or terrain
   %searchRange = 3.0;
   %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType;
   // get the eye vector and eye transform of the player
   %eyeVec = %obj.getEyeVector();
   %eyeTrans = %obj.getEyeTransform();
   // extract the position of the player's camera from the eye transform (first 3 words)
   %eyePos = posFromTransform(%eyeTrans);
   // normalize the eye vector
   %nEyeVec = VectorNormalize(%eyeVec);
   // scale (lengthen) the normalized eye vector according to the search range
   %scEyeVec = VectorScale(%nEyeVec, %searchRange);
   // add the scaled & normalized eye vector to the position of the camera
   %eyeEnd = VectorAdd(%eyePos, %scEyeVec);
   // see if anything gets hit
   %searchResult = containerRayCast(%eyePos, %eyeEnd, %mask, 0);
   if(!%searchResult) 
   {
        // Eolk - streamlining.
        // Special case weapons come first.
	%currentWeap = %obj.getMountedImage($weaponslot).item.getName();
	%currentWeapImage = %obj.getMountedImage($weaponslot);
	if (%currentWeap $= Shotgun)
	{
   	   if (%obj.inv[ShotgunAmmo] <= 4)
	   {
   	      if (%obj.inv[ShotgunAmmo] >= 1)
	      {
   	         SGCheckforclip(%obj); 
   		   if (%obj.inv[ShotgunClip] > 0)
   		      %obj.setInventory(ShotgunAmmo, 0);
	      }
	   }
	}
	else if (%currentWeap $= RShotgun)
	{
   	   if (%obj.inv[RShotgunAmmo] <= 24)
	   {
   	      if (%obj.inv[RShotgunAmmo] >= 1)
	      {
   	         RSGCheckforclip(%obj); 
   		   if (%obj.inv[RShotgunClip] > 0)
   		      %obj.setInventory(RShotgunAmmo, 0);
	      }
	   }
	}
	else if (%currentWeap $= MG42)
	{
   	   if (%obj.inv[MG42Ammo] <= 100)
	   {
   	      if (%obj.inv[MG42Ammo] >= 1)
	      {
   	         MG42Checkforclip(%obj); 
   		   if (%obj.inv[MG42clip] > 0)
   		      %obj.setInventory(MG42Ammo, 0);
	      }
	   }
	}
	else
	{
	   if(%currentWeapImage $= "KriegRifleImage" || %currentWeapImage $= "LSMGImage" || %currentWeapImage $= "PistolImage" || %currentWeapImage $= "HRPChaingunImage" || %currentWeapImage $= "RPChaingunImage")
	   {
	      // Make it so you can't waste clips.
   	      if (%obj.getInventory(%currentWeapImage.ammo) < %obj.maxInventory(%currentWeapImage.ammo))
	      {
	         // Make it so you can't waste clips while reloading.
   	         if (%obj.getInventory(%currentWeapImage.ammo) > 0)
	         {
     	            %obj.getMountedImage($weaponslot).checkForClip(%obj);
	            %obj.setInventory(%currentWeapImage.ammo, 0);
	         }
	      }
	   }
	   else
	   {
	      %changed = cyclePackSetting(%obj,1);
 	      if (!%changed) 
	      {
	         if(%obj.inv[%data.getName()] > 0)
	            messageClient(%plyr.client, 'MsgBeaconNoSurface', '\c2Cannot place beacon. Too far from surface.');
	      }

	      return %changed;
	   }
	}
	return 0;
   }
   else
   {
      %searchObj = getWord(%searchResult, 0);
      if(%searchObj.getType() & ($TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType) )
      {
         // if there's already a beacon where player is aiming, switch its type
         // otherwise, player can't deploy a beacon there
         if(%searchObj.getDataBlock().getName() $= DeployedBeacon)
            switchBeaconType(%searchObj);
         else
            messageClient(%obj.client, 'MsgBeaconNoSurface', '\c2Cannot place beacon. Not a valid surface.');
         return 0;
      }
      else if(%obj.inv[%data.getName()] <= 0)
         return 0;
   }
   // newly deployed beacons default to "target" type
   if($TeamDeployedCount[%obj.team, TargetBeacon] >= $TeamDeployableMax[TargetBeacon])
   {
      messageClient(%obj.client, 'MsgDeployFailed', '\c2Your team\'s control network has reached its capacity for this item.~wfx/misc/misc.error.wav');
      return 0;
   }
   %terrPt = posFromRaycast(%searchResult);
   %terrNrm = normalFromRaycast(%searchResult);

   %intAngle = getTerrainAngle(%terrNrm);  // getTerrainAngle() function found in staticShape.cs
   %rotAxis = vectorNormalize(vectorCross(%terrNrm, "0 0 1"));
   if (getWord(%terrNrm, 2) == 1 || getWord(%terrNrm, 2) == -1)
      %rotAxis = vectorNormalize(vectorCross(%terrNrm, "0 1 0"));
   %rotation = %rotAxis @ " " @ %intAngle;

   %obj.decInventory(%data, 1);
   %depBeac = new BeaconObject() {
      dataBlock = "DeployedBeacon";
      position = VectorAdd(%terrPt, VectorScale(%terrNrm, 0.05));
      rotation = %rotation;
   };
   $TeamDeployedCount[%obj.team, TargetBeacon]++;

	%depBeac.playThread($AmbientThread, "ambient");
	%depBeac.team = %obj.team;
	%depBeac.setOwner(%obj);
	%depBeac.sourceObject = %obj;
	addDSurface(%searchObj,%depBeac);

   // give it a team target
   %depBeac.setTarget(%depBeac.team);
   Deployables.add(%depBeac);
}

function switchBeaconType(%beacon)
{
   if(%beacon.getBeaconType() $= "friend")
   {
      // switch from marker beacon to target beacon
      if($TeamDeployedCount[%beacon.team, TargetBeacon] >= $TeamDeployableMax[TargetBeacon])
      {
         messageClient(%beacon.sourceObject.client, 'MsgDeployFailed', '\c2Your team\'s control network has reached its capacity for this item.~wfx/misc/misc.error.wav');
         return 0;
      }
      %beacon.setBeaconType(enemy);
      $TeamDeployedCount[%beacon.team, MarkerBeacon]--;
      $TeamDeployedCount[%beacon.team, TargetBeacon]++;
   }
   else
   {
      // switch from target beacon to marker beacon
      if($TeamDeployedCount[%beacon.team, MarkerBeacon] >= $TeamDeployableMax[MarkerBeacon])
      {
         messageClient(%beacon.sourceObject.client, 'MsgDeployFailed', '\c2Your team\'s control network has reached its capacity for this item.~wfx/misc/misc.error.wav');
         return 0;
      }
      %beacon.setBeaconType(friend);
      $TeamDeployedCount[%beacon.team, TargetBeacon]--;
      $TeamDeployedCount[%beacon.team, MarkerBeacon]++;
   }
}

function cyclePackSetting(%plyr,%val) {
	%changed = false;
	if (%plyr.hasSpine) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["spine"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["spine"];
		%line = $packSetting["spine",%plyr.packSet];
		bottomPrint(%plyr.client,"Beam set to" SPC getWords(%line,3,getWordCount(%line)),2,1);
		%changed = true;
	}
        else if (%plyr.hasMSpine) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["mspine"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["mspine"];
		%line = $packSetting["mspine",%plyr.packSet];
		bottomPrint(%plyr.client,"Beam set to" SPC getWords(%line,6,getWordCount(%line)),2,1);
		%changed = true;
	}
        else if (%plyr.hasWalk) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["walk"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["walk"];
		%line = $packSetting["walk",%plyr.packSet];
		bottomPrint(%plyr.client,"Walkway set to" SPC getWords(%line,1,getWordCount(%line)),2,1);
		%changed = true;
	}
	else if (%plyr.hasFloor) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["floor"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["floor"];
		%line = $packSetting["floor",%plyr.packSet];
		bottomPrint(%plyr.client,"Floor set" SPC getWords(%line,6,getWordCount(%line)),2,1);
		%changed = true;
	}
        else if (%plyr.hasBlast) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["blast"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["blast"];
		%line = $packSetting["blast",%plyr.packSet];
		bottomPrint(%plyr.client,"Blastwall set to" SPC getWords(%line,0,getWordCount(%line)),2,1);
		%changed = true;
	}
        //[most] //Refers to the more flexible more universal item switch code.
                 //Read reference below.
        else if(%plyr.getMountedImage(2) && GetWord($packSettings[%plyr.getMountedImage(2).getName()],0)) {
               %changed = %plyr.getMountedImage(2).ChangeMode(%plyr,%val,0);
        }
        //[most]        
        else if (%plyr.hasJumpad) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["jumpad"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["jumpad"];
		%line = $packSetting["jumpad",%plyr.packSet];
		bottomPrint(%plyr.client,"Jump Pad set to" SPC restWords(%line),2,1);
		%changed = true;
	}
	else if (%plyr.hasForceField) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["forcefield"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["forcefield"];
		%line = $packSetting["forcefield",%plyr.packSet];
		bottomPrint(%plyr.client,getWords(%line,3,getWordCount(%line)),2,1);
		%changed = true;
	}
        else if (%plyr.hasGravField) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["gravfield"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["gravfield"];
		%line = $packSetting["gravfield",%plyr.packSet];
		bottomPrint(%plyr.client,"Gravity field set to" SPC getWords(%line,3,getWordCount(%line)),2,1);
		%changed = true;
	}
        else if (%plyr.hasTree) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["tree"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["tree"];
		%line = $packSetting["tree",%plyr.packSet];
		bottomPrint(%plyr.client,"Tree set to" SPC %line,2,1);
		%changed = true;
	}
        else if (%plyr.hasCrate) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["crate"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["crate"];
		%line = $packSetting["crate",%plyr.packSet];
		bottomPrint(%plyr.client,"Crate set to" SPC %line,2,1);
		%changed = true;
	}
        else if (%plyr.hasDecoration) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["decoration"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["decoration"];
		%line = $packSetting["decoration",%plyr.packSet];
		bottomPrint(%plyr.client,"Decoration set to" SPC %line,2,1);
		%changed = true;
	}
        else if (%plyr.hasProjector) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["logoprojector"] || $Host::Purebuild == 0)
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["logoprojector"];
		%line = $packSetting["logoprojector",%plyr.packSet];
		bottomPrint(%plyr.client,"Logo projector set to" SPC %line,2,1);
		%changed = true;
	}
        else if (%plyr.hasVehiclepad) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["vehiclepadpack"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["vehiclepadpack"];
		%line = $packSetting["vehiclepadpack",%plyr.packSet];
		bottomPrint(%plyr.client,"Vehicle pad set to" SPC %line,2,1);
		%changed = true;
	}
        else if (%plyr.hasLight) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["light"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["light"];
		%line = $packSetting["light",%plyr.packSet];
		bottomPrint(%plyr.client,"Light set to" SPC %line,2,1);
		%changed = true;
	}
	else if (%plyr.hasSwitch) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["switch"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["switch"];
		%line = $packSetting["switch",%plyr.packSet];
		bottomPrint(%plyr.client,"Switch range set to" SPC %line SPC "meters.",2,1);
		%changed = true;
	}
	else if (%plyr.hasTele) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > 40)
			%plyr.packSet = 1;
		if (%plyr.packSet < 1)
			%plyr.packSet = 40;
		bottomPrint(%plyr.client,"Telepad frequency set to: " @ %plyr.packSet,2,1);
		%changed = true;
	}
	else if (%plyr.hasGen) {
		%plyr.powerFreq = %plyr.powerFreq + %val;
		if (%plyr.powerFreq > upperPowerFreq(%plyr))
			%plyr.powerFreq = 1;
		if (%plyr.powerFreq < 1)
			%plyr.powerFreq = upperPowerFreq(%plyr);
		displayPowerFreq(%plyr);
		%changed = true;
	}
	else if (%plyr.hasTripwire) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["tripwire"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["tripwire"];
		%line = $packSetting["tripwire",%plyr.packSet];
		bottomPrint(%plyr.client,"Tripwire range set to " @ getWord(%line,0) @ " meters, " @ (getWord(%line,1) ? "field" : "beam") @ " mode.",2,1);
		%changed = true;
	}
        else if (%plyr.hasEscapePod) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["escapepod"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["escapepod"];
		displayEscapePodBoostPower(%plyr);
		%changed = true;
	}
        else if (%plyr.hasMissileRack) {
		%plyr.packSet = %plyr.packSet + %val;
		if (%plyr.packSet > $packSettings["missilerack"])
			%plyr.packSet = 0;
		if (%plyr.packSet < 0)
			%plyr.packSet = $packSettings["missilerack"];
		%line = $packSetting["missilerack",%plyr.packSet];
		bottomPrint(%plyr.client,"Missile Rack set to " @ %line ,2,1);
		%changed = true;
	}
      else if (%plyr.hasDoor) {
	   %plyr.packSet = %plyr.packSet + %val;
	   if (%plyr.packSet > $packSettings["Door"])
		%plyr.packSet = 0;
	   if (%plyr.packSet < 0)
		%plyr.packSet = $packSettings["Door"];
	   %line = $packSetting["Door",%plyr.packSet];
	   bottomPrint(%plyr.client,"Door set to" SPC %line,2,1);
	   %changed = true;
	}
      else if (%plyr.hasZspawn) {
	   %plyr.packSet = %plyr.packSet + %val;
	   if (%plyr.packSet > $packSettings["ZSpawn"])
		%plyr.packSet = 0;
	   if (%plyr.packSet < 0)
		%plyr.packSet = $packSettings["ZSpawn"];
	   %line = $packSetting["ZSpawn",%plyr.packSet];
	   bottomPrint(%plyr.client,"Spawn set to" SPC %line,2,1);
	   %changed = true;
	}
      else if (%plyr.hasArtWepPack) {
	   %plyr.packSet = %plyr.packSet + %val;
	   if (%plyr.packSet > $packSettings["ArtPack"])
		%plyr.packSet = 0;
	   if (%plyr.packSet < 0)
		%plyr.packSet = $packSettings["ArtPack"];
	   %line = $packSetting["ArtPack",%plyr.packSet];
	   bottomPrint(%plyr.client,"Loadout set to" SPC %line,2,1);
	   %changed = true;
	}
	return %changed;
}


//This function can be used by all "normal" packswitching packs.
//normal in a sense all modes are given in globals with the design 
//given inside effectpacks.cs which is very simular to our current standarts
//The idea is the globals define all the variables and are linked by their pack image.
//This way all "plugin" data can be in the "pack".cs 
//Alternative modes like the telleport freq change or nested modes like the effects pack,
//can easly be made by an alternative "::Changemode" function which again can be located
//inside "pack".cs file creating full plugin compability.

function ShapeBaseImageData::ChangeMode(%data,%plyr,%val,%level)
{
if (%level == 0) //regular pack settings
   {
   %image = %data.getName();

   %settings = $packSettings[%image];
  
   %plyr.packSet = %plyr.packSet + %val;
   if (%plyr.packSet > getWord(%settings,0))
 	%plyr.packSet = 0;
   if (%plyr.packSet < 0)
	%plyr.packSet = getWord(%settings,0);
   %packname = GetWords(%settings,2,getWordCount(%settings));

   %curset = $PackSetting[%image,%plyr.packSet];
   if (getWord(%settings,1) == -1)
	   %line = GetWords(%curset,0,getWordCount(%curset));
   else
	   %line = GetWords(%curset,0,getWord(%settings,1));
  
   bottomPrint(%plyr.client,%packname SPC "Set to"SPC %line,2,1);
   return true;
   }
else if (%level == 1) //expert settings
   {

   %image = %data.getName();

   %settings = $expertSettings[%image];
  
   %plyr.expertSet = %plyr.expertSet + %val;
   if (%plyr.expertSet > getWord(%settings,0))
 	%plyr.expertSet = 0;
   if (%plyr.expertSet < 0)
	%plyr.expertSet = getWord(%settings,0);

   %packname = GetWords(%settings,2,getWordCount(%settings));
   %curset = $expertSetting[%image,%plyr.expertSet];
   if (getWord(%settings,1) == -1)
	   %line = GetWords(%curset,0,getWordCount(%curset));
   else
	   %line = GetWords(%curset,0,getWord(%settings,1));

   bottomPrint(%plyr.client,%packname SPC "Set to"SPC %line,2,1);
   return true;
   }
else if (%level == 2) //Weapon settings 1
   {
   %image = %data.getName();

   %settings = $weaponSettings1[%image];
  
   %plyr.weaponSet1 = %plyr.weaponSet1 + %val;
   if (%plyr.weaponSet1 > getWord(%settings,0))
 	%plyr.weaponSet1 = 0;
   if (%plyr.weaponSet1 < 0)
	%plyr.weaponSet1 = getWord(%settings,0);

   %weaponname = GetWords(%settings,2,getWordCount(%settings));
   %curset = $weaponSetting1[%image,%plyr.weaponSet1];
   if (getWord(%settings,1) == -1)
	   %line = GetWords(%curset,0,getWordCount(%curset));
   else
	   %line = GetWords(%curset,0,getWord(%settings,1));

   bottomPrint(%plyr.client,%weaponname SPC "Set to"SPC %line,2,1);
   return true;
   }
else if (%level == 3) //Weapon settings 2 !!no nesting!!
   {
   %image = %data.getName();

   %settings = $weaponSettings2[%image];
  
   %plyr.weaponSet2 = %plyr.weaponSet2 + %val;
   if (%plyr.weaponSet2 > getWord(%settings,0))
 	%plyr.weaponSet2 = 0;
   if (%plyr.weaponSet2 < 0)
	%plyr.weaponSet2 = getWord(%settings,0);

   %weaponname = GetWords(%settings,2,getWordCount(%settings));
   %curset = $weaponSetting2[%image,%plyr.weaponSet2];
   if (getWord(%settings,1) == -1)
	   %line = GetWords(%curset,0,getWordCount(%curset));
   else
	   %line = GetWords(%curset,0,getWord(%settings,1));

   bottomPrint(%plyr.client,%weaponname SPC "Set to"SPC %line,2,1);
   return true;
   }
}

//Neat lil settings mode fixer.
//It's optional.. but hey.. what the heck.
//Simply sees if the current setting is among the options.. if not .. set to option 1.

//More usefull thought for specialized packs ;) ;)

function ShapeBaseImageData::FixMode(%data,%plyr,%level)
{
%image = %data.getName();
if (%level == 0) //regular pack settings
   {    
   %settings = $packSettings[%image];
   if (%plyr.packSet > getWord(%settings,0) || %plyr.packSet < 0)
 	%plyr.packSet = 0;
   }
else if (%level == 1) //regular pack settings
   {    
   %settings = $expertSettings[%image];
   if (%plyr.expertSet > getWord(%settings,0) || %plyr.expertSet < 0)
 	%plyr.expertSet = 0;
   }
else if (%level == 2) //regular pack settings
   {    
   %settings = $weaponSettings1[%image];
   if (%plyr.weaponSet1 > getWord(%settings,0) || %plyr.weaponSet1 < 0)
 	%plyr.weaponSet1 = 0;
   }
else if (%level == 3) //regular pack settings
   {    
   %settings = $weaponSettings2[%image];
   if (%plyr.weaponSet2 > getWord(%settings,0) || %plyr.weaponSet2 < 0)
 	%plyr.weaponSet2 = 0;
   }
}
