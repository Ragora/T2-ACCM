datablock AudioProfile(MedPackCureSound)
{
   filename = "fx/packs/shield_hit.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock ShapeBaseImageData(MedPackImage)
{
   shapeFile = "pack_upgrade_ammo.dts";
   item = MedPack;
   mountPoint = 1;
   offset = "0 0 0";
   emap = true;

   gun = MedPackGunImage;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateSequence[1] = "fire";
   stateSound[1] = RepairPackActivateSound;
   stateTransitionOnTriggerUp[1] = "Deactivate";

   stateName[2] = "Deactivate";
   stateScript[2] = "onDeactivate";
   stateTransitionOnTimeout[2] = "Idle";   
};

datablock ItemData(MedPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "pack_upgrade_ammo.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "MedPackImage";
   pickUpName = "a Med pack";

   lightOnlyStatic = true;
   lightType = "PulsingLight";
   lightColor = "1 0 0 1";
   lightTime = 1200;
   lightRadius = 4;

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(MedpackImg1)
{
   shapeFile = "pack_upgrade_repair.dts";
   mountPoint = 1;
   offset = "0 -0.05 0";
   emap = true;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";
	
   stateName[1] = "Activate";
   stateSequence[1] = "fire";
   stateTransitionOnTriggerUp[1] = "Idle";
};

datablock ShapeBaseImageData(MedpackImg2)
{
   shapeFile = "repair_kit.dts";
   mountPoint = 1;
   offset = "0 -0.2 -0.18";
   emap = true;
};

datablock ShapeBaseImageData(MedpackImg2b)
{
   shapeFile = "repair_kit.dts";
   mountPoint = 1;
   offset = "0 -0.2 0.15";
   emap = true;
};

//--------------------------------------------------------------------------
// Repair Gun

datablock ShockLanceProjectileData(ReviveProj)
{
   directDamage        = 0;
   radiusDamageType    = $DamageType::ShockLance;
   kickBackStrength    = 0; // z0dd - ZOD, 3/30/02. More lance kick. was 2500
   velInheritFactor    = 0;
   sound               = "";

   zapDuration = 1.0;
   impulse = 1800;
   boltLength = 16.0;
   extension = 16.0;
   lightningFreq = 25.0;
   lightningDensity = 3.0;
   lightningAmp = 0.25;
   lightningWidth = 0.05;

   shockwave = ShocklanceHit;
   							 
   boltSpeed[0] = 2.0;
   boltSpeed[1] = -0.5;

   texWrap[0] = 1.5;
   texWrap[1] = 1.5;

   startWidth[0] = 0.3;
   endWidth[0] = 0.6;
   startWidth[1] = 0.3;
   endWidth[1] = 0.6;
   
   texture[0] = "special/shockLightning01";
   texture[1] = "special/shockLightning02";
   texture[2] = "special/shockLightning03";
   texture[3] = "special/ELFBeam";

   emitter[0] = ShockParticleEmitter;
};

datablock ShapeBaseImageData(MedPackGunImage)
{
   shapeFile = "pack_upgrade_repair.dts";
   offset = "0 0.15 0";
   rotation = "1 0 0 90";

   usesEnergy = true;
   minEnergy = 3;
   cutOffEnergy = 3.1;
   emap = true;

   repairFactorPlayer = 0.005;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.25;

   stateName[1] = "ActivateReady";
   stateScript[1] = "onActivateReady";
   stateSpinThread[1] = Stop;
   stateTransitionOnAmmo[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "ActivateReady";

   stateName[2] = "Ready";
   stateSpinThread[2] = Stop;
   stateTransitionOnNoAmmo[2] = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Repair";

   stateName[4] = "Repair";
   stateSound[4] = RepairPackFireSound;
   stateScript[4] = "onRepair";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "fire";
   stateFire[4] = true;
   stateEnergyDrain[4] = 32;
   stateTransitionOnNoAmmo[4] = "Deactivate";
   stateTransitionOnTriggerUp[4] = "Deactivate";
   stateTransitionOnNotLoaded[4] = "Validate";

   stateName[5] = "Deactivate";
   stateScript[5] = "onDeactivate";
   stateSpinThread[5] = SpinDown;
   stateSequence[5] = "activate";
   stateDirection[5] = false;
   stateTimeoutValue[5] = 0.2;
   stateTransitionOnTimeout[5] = "ActivateReady";
};

//---------------------------
//PACK STUFF
//---------------------------

function MedPackImage::onMount(%data, %obj, %node){
   %obj.mountImage(MedpackImg1, 4);
   %obj.mountImage(MedpackImg2, 7);
}

function MedPackImage::onUnmount(%data, %obj, %node)
{
   if(%obj.getMountedImage($WeaponSlot))
      if(%obj.getMountedImage($WeaponSlot).getName() $= "MedPackGunImage")
         %obj.unmountImage($WeaponSlot);
   %obj.unmountImage(4);
   %obj.unmountImage(7);
}

function MedPackImage::onActivate(%data, %obj, %slot)
{
   %obj.setImageTrigger(4, true);
   %obj.mountImage(MedpackImg2b, 7);
   messageClient( %obj.triggeredBy.client, 'CloseHud', "", 'scoreScreen' );
   messageClient( %obj.triggeredBy.client, 'CloseHud', "", 'inventoryScreen' );
   commandToClient(%obj.triggeredBy.client, 'StationVehicleShowHud');

   if(%obj.isPilot())
   {
      %obj.setImageTrigger(%slot, false);
      return;
   }

   if(%obj.getMountedImage($WeaponSlot).getName() !$= "MedPackGunImage")
   {
      messageClient(%obj.client, 'MsgRepairPackOn', '\c2Repair pack activated.');

      %obj.setArmThread(look);

      %obj.mountImage(MedPackGunImage, $WeaponSlot);
      commandToClient(%obj.client, 'setRepairReticle');
   }
}

function MedPackImage::onDeactivate(%data, %obj, %slot)
{
   %obj.setImageTrigger(4, false);
   %obj.setImageTrigger(%slot, false);
   if(%obj.getMountedImage($WeaponSlot).getName() $= "MedpackGunImage")
      %obj.unmountImage($WeaponSlot);
   %obj.mountImage(MedpackImg2, 7);
}

//---------------------------
//GUN STUFF
//---------------------------

function MedPackGunImage::onMount(%this,%obj,%slot)
{
   %obj.setImageAmmo(%slot,true);
   if ( !isDemo() )
      commandToClient( %obj.client, 'setRepairPackIconOn' );
   %obj.usingMedGun = 1;
   Bottomprint(%obj.client, "Med Gun: Fire to repair whithin a radius, jet to revive someone.\nIf on mode 2 (use mine key to toggle), you will cure an infected person.", 5, 2);
}

function MedPackGunImage::onUnmount(%this,%obj,%slot)
{
   if(%obj.isreping == 1)
      MedstopRepair(%obj);

   %obj.setImageTrigger(%slot, false);
   %obj.setImageTrigger($BackpackSlot, false);
   if ( !isDemo() )
      commandToClient( %obj.client, 'setRepairPackIconOff' );
   %obj.usingMedGun = 0;
}

function MedPackGunImage::onRepair(%this,%obj,%slot){
   %obj.isreping = 1;
   %pos = %obj.getWorldBoxCenter();
   %obj.reptargets = "";
   InitContainerRadiusSearch(%pos, 10, $TypeMasks::PlayerObjectType);
   while ((%targetObject = containerSearchNext()) != 0){
	if(%targetObject.getDamageLevel() > 0.0 && %targetObject.getState() !$= "dead")
	   %obj.reptargets = %obj.reptargets @ %targetObject @" ";
   }
   if(%obj.reptargets $= ""){
	messageclient(%obj.client, 'MsgClient', '\c2No targets to repair.');
   }
   Medrepair(%obj, %obj.reptargets);
}

function MedPackGunImage::onDeactivate(%this,%obj,%slot)
{
   MedstopRepair(%obj);
}

function Medrepair(%obj, %targets){
   if(%obj.isreping == 0)
	return;
  if(%targets !$= ""){
   %numtrgs = getNumberOfWords(%targets);
   for(%i = 0; %i < %numtrgs; %i++){
	%target = getWord(%targets, %i);
	if(vectorDist(%obj.getWorldBoxCenter(), %target.getWorldBoxCenter()) <= 10 && %target.getDamageLevel() > 0.0){
	   if(%target.reping != 1){
		%target.reping = 1;
		%target.setRepairRate(%target.getRepairRate() + MedPackGunImage.repairFactorPlayer);
	   }
	}
	else{
	   if(%target.reping == 1){
		%target.reping = 0;
		%target.setRepairRate(%target.getRepairRate() - MedPackGunImage.repairFactorPlayer);
	   }
	}
   }
  }

   %pos = %obj.getWorldBoxCenter();
   %obj.reptargets = "";
   InitContainerRadiusSearch(%pos, 10, $TypeMasks::PlayerObjectType);
   while ((%targetObject = containerSearchNext()) != 0){
	if(%targetObject.getDamageLevel() > 0.0 && %targetObject.getState() !$= "dead")
	   %obj.reptargets = %obj.reptargets @ %targetObject @" ";
   }
   if(%obj.isreping == 1)
      %obj.reploop = schedule(500, 0, "Medrepair", %obj, %obj.reptargets);
}

function MedstopRepair(%obj){
   %obj.isreping = 0;
   if(%obj.reptargets !$= ""){
      %numtrgs = getNumberOfWords(%obj.reptargets);
      for(%i = 0; %i < %numtrgs; %i++){
	   %target = getWord(%obj.reptargets, %i);
	   if(%target.reping == 1){
		%target.reping = 0;
		%target.setRepairRate(%target.getRepairRate() - MedPackGunImage.repairFactorPlayer);
	   }
      }
   }
}

//---------------------------
//REVIVE
//---------------------------

function checkcure(%player)
{
   %pos        = %player.getMuzzlePoint($WeaponSlot);
   %vec        = %player.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
   %obj        = containerraycast(%pos, %targetpos, $TypeMasks::PlayerObjectType, %player);
   %obj        = getword(%obj, 0);

   if(!isObject(%obj))
      %obj = %player;

   if(!isObject(%obj.client))
   {
      messageClient(%player.client, "", "\c2Either you're trying to cure a zombie or that is the wrong type of object.");
      return;
   }

   if(%obj.client.team != %player.client.team)
   {
      messageClient(%player.client, "", "\c2You cannot cure the other team!");
      return;
   }

   if(!%obj.infected)
   {
      if(%obj != %player)
         messageClient(%player.client, "", "\c2That person isn't infected.");
      else
         messageClient(%player.client, "", "\c2You aren't infected.");
      return;
   }

   %obj.infected = 0;
   cancel(%obj.infectedDamage);
   %obj.infectedDamage = "";
   %obj.beats = 0;
   %obj.canZkill = 0;
   %obj.hit = 0; // Ravenger bite count.
   cancel(%obj.zombieAttackImpulse);
   serverPlay3d(MedPackCureSound, %obj.getTransform());
   if(%obj != %player)
   {
      messageClient(%obj.client, "", "\c2"@%player.client.nameBase@" has cured you.");
      messageClient(%player.client, "", "\c2You just cured "@%obj.client.nameBase@"!");
   }
   else
      messageClient(%obj.client, "", "\c2You have cured yourself.");

   if(getRandom() > 0.9)
   {
      %quarter = %obj.getDatablock().maxDamage / 4;
      %obj.setDamageLevel(%obj.getDamageLevel() + %quarter);
      %obj.setDamageFlash(0.5);
      playPain(%obj);

      // Eolk - this is just a safety.
      if(%obj.getDamageLevel() >= %obj.getDatablock().maxDamage)
         Game.onClientKilled(%obj.client, %player.client, $DamageType::MedPackVaccine);

      messageClient(%obj.client, "", "\c2You have been overdosed on the antidote vaccine!");
      if(%obj != %player)
         messageClient(%player.client, "", "\c2You overdosed the target with vaccine!");
   }
}

function checkrevive(%obj){
   if(isObject(%obj.lasttouchedcorpse)){
	%Tobj = %obj.lasttouchedcorpse;
	if(%Tobj.infected == 1 || %Tobj.kibbled == 1){
	   messageclient(%obj.client, 'MsgClient', "\c2This body is destroyed or ... changing.");
	   return;
	}
	if(vectorDist(%obj.getPosition(),%Tobj.getPosition()) > 3){
	   messageclient(%obj.client, 'MsgClient', "\c2Must be in contact with a body to revive it.");
	   return;
	}
	%eyevec = %obj.getEyeVector();
	%eyepos = posFromTransform(%obj.getEyeTransform());
	%Tvec = vectorNormalize(vectorSub(%Tobj.getPosition(),%eyepos));
	if(vectorDist(%eyevec, %Tvec) > 0.5){
	   messageclient(%obj.client, 'MsgClient', "\c2Must be looking at body.");
	   return;
	}
	if(%Tobj.getState() !$= "dead"){
	   messageclient(%obj.client, 'MsgClient', "\c2Cannot revive, target isnt dead.");
	   return;
	}
	if(%Tobj.team != %obj.team){
	   messageclient(%obj.client, 'MsgClient', "\c2Revive target should be the same team as you.");
	   return;
	}
      if((%obj.getEnergyLevel() / %obj.getDataBlock().maxEnergy) >= 0.9){
	   %obj.setEnergyLevel(0);
	   revive(%obj, %tobj);
      }
	else
	   messageclient(%obj.client, 'MsgClient', "\c2Must have more energy to initiate reviver.");
   }
   else
	messageclient(%obj.client, 'MsgClient', "\c2Must be in contact with a body to revive it.");
}

function revive(%obj, %target){
   if(%target.client.getControlObject() !$= %target.client.player){
	//necessitys
	%target.setDamageLevel(%target.getdatablock().maxDamage - 0.1);
      %target.client.setControlObject(%target);
	%target.revived = 1;
	Cancel(%target.ParaLoop);
	Cancel(%target.revcheck);
	%target.client.player = %target;

	//points and message
	%obj.client.revivecount++;
	messageclient(%target.client, 'MsgClient', "\c2You were revived by "@%obj.client.namebase@".");
	messageclient(%obj.client, 'MsgClient', "\c2You revived "@%target.client.namebase@".");

	//effects
	%target.setDamageFlash(1);
	%target.setMoveState(true);
	playDeathCry(%target);
	revivestand(%target, 0);
	for(%i =0; %i<$InventoryHudCount; %i++)
	   %target.client.setInventoryHudItem($InventoryHudData[%i, itemDataName], 0, 1);
	%target.client.clearBackpackIcon();

	%obj.playAudio(0, ShockLanceHitSound);
      %p = new ShockLanceProjectile() {
         dataBlock        = ReviveProj;
         initialDirection = vectorNormalize(vectorSub(%target.getPosition(),%obj.getMuzzlePoint($WeaponSlot)));
         initialPosition  = %obj.getMuzzlePoint($WeaponSlot);
         sourceObject     = %obj;
         sourceSlot       = %obj.getMuzzlePoint($WeaponSlot);
         targetId         = %target;
      };
      MissionCleanup.add(%p);
   }
   else
	messageclient(%obj.client, 'MsgClient', "\c2Target already has another clone in use.");
}

function revivestand(%obj, %count){
   if(%obj.getstate() $= "dead")
	return;
   if(%count <= 2){
	%obj.setActionThread("scoutRoot",true);
	%obj.setDamageFlash(0.7);
   }
   else if(%count <= 5){
	%obj.setActionThread("sitting",true);
	%obj.setDamageFlash(0.4);
   }
   else if(%count >= 6){
	%obj.setActionThread("ski",true);
	%obj.setMoveState(false);
	return;
   }
   %count++;
   schedule(500, 0, "revivestand", %obj, %count);	
}
