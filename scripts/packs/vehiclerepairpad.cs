datablock StaticShapeData(RepairPad) : StaticShapeDamageProfile
{
   className = Station;
   shapeFile = "station_teleport.dts";
   maxDamage = 5.50;
   destroyedLevel = 5.50;
   disabledLevel = 4.75;
   explosion      = DeployablesExplosion;
      expDmgRadius = 15.0;
      expDamage = 0.65;
      expImpulse = 1500.0;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = false;
   energyPerDamagePoint = 110;
   maxEnergy = 50;
   rechargeRate = 0.20;
   renderWhenDestroyed = false;
   doesRepair = true;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Vehicle';
   targetTypeTag = 'Repair Pad';

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
   needspower = true;
};

datablock ShapeBaseImageData(RepairPadImage)
{
   mass = 15;
   emap = true;

   shapeFile = "pack_deploy_inventory.dts";
   item = RepairPadDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = RepairPad;
   heatSignature = 0;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   maxDepSlope = 30;
   deploySound = StationDeploySound;

   flatMinDeployDis   = 1.0;
   flatMaxDeployDis   = 5.0;

   minDeployDis       = 2.5;
   maxDeployDis       = 5.0;
};

datablock ItemData(RepairPadDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_inventory.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "RepairPadImage";
   pickUpName = "a vehicle repair pad";
   heatSignature = 0;

   computeCRC = true;
   emap = true;

};

function RepairPadImage::onDeploy(%item, %plyr, %slot) {
	//Object
	%className = "StaticShape";

	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (%item.surfaceinher == 0) {
		if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
			%item.surfaceNrm2 = %playerVector;
		else
			%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
	}

	%item.surfaceNrm3 = vectorCross(%item.surfaceNrm,%item.surfaceNrm2);

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%dataBlock = %item.deployed;


	%deplObj = new (%className)() {
		dataBlock = %dataBlock;
		scale = "4.5 4.5 1";
	};

//////////////////////////Apply settings//////////////////////////////

	// [[Location]]:

	// exact:
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// misc info
	addDSurface(%item.surface,%deplObj);

	// [[Settings]]:

	%deplObj.grounded = %grounded;
	%deplObj.needsFit = 1;

	// [[Normal Stuff]];

	// set team, owner, and handle
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);

	// set the sensor group if it needs one
	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client, %deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team, %item.item]++;

	%deplObj.deploy();

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// Power object
	checkPowerObject(%deplObj);

   	%plyr.unmountImage(%slot); 
   	%plyr.decInventory(%item.item, 1); 

	return %deplObj;
}

function RepairPad::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
      if(%obj.isreping == 1)
	   stopVRepairLoop(%obj);
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, RepairPadDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	fireBallExplode(%obj,1);
}

function RepairPad::onGainPowerEnabled(%data,%obj) {
   if (%obj.reploop !$= "")
   	Cancel(%obj.repLoop);
   %obj.isreping = 1;
   %obj.repLoop = schedule(1000, 0, "VRepairLoop", %obj);
   Parent::onGainPowerEnabled(%data,%obj);
}

function RepairPad::onLosePowerDisabled(%data,%obj) {
   if (%obj.ZCloop !$= ""){
   	Cancel(%obj.repLoop);
	stopVRepairLoop(%obj);
   }
   Parent::onLosePowerDisabled(%data,%obj);
}

function VRepairLoop(%obj){ 
   if(isObject(%obj)){
	if(%obj.isreping == 0)
	   return;
	
	%targets = %obj.reptargets;
	%pos = %obj.getWorldBoxCenter();
	if(%targets !$= ""){
	   %numtrgs = getNumberOfWords(%targets);
	   for(%i = 0; %i < %numtrgs; %i++){
		%target = getWord(%targets, %i);
		if(vectorDist(%pos, %target.getWorldBoxCenter()) <= 20 && %target.getDamageLevel() > 0.0){
		   if(%target.reping != 1){
			%target.reping = 1;
			%target.setRepairRate(%target.getRepairRate() + 0.01);
			if(%target.affected && %target.getDamagelevel() < %target.getDatablock().HDAddMassLevel)   {
      		   if (%target.lastPilot.isPilot() == true)
      		      messageClient(%target.lastPilot.client, '', 'Vehicle Repaired, and Manuverability restored!');
      		   %target.unmountImage(7);
      		   %target.Affected = 0;
			   if(%target.getClassName() $= "FlyingVehicle")
			      Cancel(%target.dmgStallLoop);
      		   if(%target.getdatablock().getname() $= "scoutFlyer" || %target.getdatablock().getname() $= "strikeFlyer")
			      checkStallLoop(%obj);
			}
		   }
		}
		else{
		   if(%target.reping == 1){
			%target.reping = 0;
			%target.setRepairRate(%target.getRepairRate() - 0.01);
		   }
		}
		%datablock = %target.getDatablock();
		if(%datablock.max[chaingunAmmo] !$= "" && %target.inv[chaingunAmmo] < %datablock.max[chaingunAmmo]){
		   if(%datablock.max[chaingunAmmo] < 100)
			%CGamount = 10;
		   else
			%CGamount = 100;
		   %target.incInventory(chaingunAmmo, %CGamount);
		   %reloaded = 1;
		}
		else if(%datablock.max[MissileLauncherAmmo] !$= "" && %target.inv[MissileLauncherAmmo] < %datablock.max[MissileLauncherAmmo]){
		   %target.incInventory(MissileLauncherAmmo, 1);
		   %reloaded = 1;
		}
		else if(%datablock.max[MortarAmmo] !$= "" && %target.inv[MortarAmmo] < %datablock.max[MortarAmmo]){
		   %target.incInventory(MortarAmmo, 1);
		   %reloaded = 1;
		}
		else if(%datablock.max[PlasmaAmmo] !$= "" && %target.inv[PlasmaAmmo] < %datablock.max[PlasmaAmmo]){
		   %target.incInventory(PlasmaAmmo, 4);
		   %reloaded = 1;
		}
		if(%reloaded == 1){
		   %reloaded = 0;
		   serverPlay3d("MissileReloadSound",%target.getWorldBoxCenter()); 
		}
	
		if(isObject(%target.turretObject)){
		   %datablock = %target.turretObject.getDatablock();
		   if(%datablock.max[chaingunAmmo] !$= "" && %target.turretObject.inv[chaingunAmmo] < %datablock.max[chaingunAmmo]){
		      %target.turretObject.incInventory(chaingunAmmo, 100);
		      %reloaded = 1;
		   }
		   else if(%datablock.max[MissileLauncherAmmo] !$= "" && %target.turretObject.inv[MissileLauncherAmmo] < %datablock.max[MissileLauncherAmmo]){
		      %target.turretObject.incInventory(MissileLauncherAmmo, 1);
		      %reloaded = 1;
		   }
		   else if(%datablock.max[MortarAmmo] !$= "" && %target.turretObject.inv[MortarAmmo] < %datablock.max[MortarAmmo]){
		      %target.turretObject.incInventory(MortarAmmo, 1);
		      %reloaded = 1;
		   }
		   if(%reloaded == 1)
		      serverPlay3d("MissileReloadSound",%target.getWorldBoxCenter()); 
		}
	   }
	}
	%obj.reptargets = "";
	InitContainerRadiusSearch(%pos, 15, $TypeMasks::VehicleObjectType);
	while ((%targetObject = containerSearchNext()) != 0){
	   %obj.reptargets = %obj.reptargets @ %targetObject @" ";
	}
	if(%obj.isreping == 1)
	   %obj.reploop = schedule(500, 0, "VRepairLoop", %obj);
   }
}

function stopVRepairLoop(%obj){
   %obj.isreping = 0;
   if(%obj.reptargets !$= ""){
      %numtrgs = getNumberOfWords(%obj.reptargets);
      for(%i = 0; %i < %numtrgs; %i++){
	   %target = getWord(%obj.reptargets, %i);
	   if(%target.reping == 1){
		%target.reping = 0;
		%target.setRepairRate(%target.getRepairRate() - 0.01);
	   }
      }
   }
}
