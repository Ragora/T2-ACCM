//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock SensorData(AWACSSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsActiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 1750;
};

datablock FlyingVehicleData(AWACS) : BomberDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_bomber.dts";
   multipassenger = true;
   computeCRC = true;

   weaponNode = 1;

   debrisShapeName = "vehicle_air_bomber.dts";
   debris = MeShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.2;
   density = 1.0;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 3;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;
   isProtectedMountPoint[2] = false;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   cameraMaxDist = 22;
   cameraOffset = 5;
   cameraLag = 1.0;
   explosion = MFVehicleExplosion;
	explosionDamage = 1.5;
	explosionRadius = 20.0;

   maxDamage = 5.0;     // Total health
   destroyedLevel = 5.0;   // Damage textures show up at this health level

   HDAddMassLevel = 3.5;
   HDMassImage = HFlyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 150;
   maxEnergy = 400;      // Afterburner and any energy weapon pool
   minDrag = 60;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 1800;        // Angular Drag (dampens the drift after you stop moving the mouse...also tumble drag)
   rechargeRate = 0.8;

   // Auto stabilize speed
   maxAutoSpeed = 15;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 1500;      // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 300;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.95;      // Dampen control input so you don't whack out at very slow speeds

   // Maneuvering
   maxSteeringAngle = 8;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 5;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 8;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 5500;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 800;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 4;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 130;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 5000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40.0;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 2.5;       // Energy use of the afterburners (low number is less drain...can be fractional)
   vertThrustMultiple = 3.0;

   dustEmitter = LargeVehicleLiftoffDustEmitter;
   triggerDustHeight = 4.0;
   dustHeight = 2.0;

   damageEmitter[0] = MFLightDamageSmoke;
   damageEmitter[1] = MFHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "3.0 -3.0 0.0 ";
   damageEmitterOffset[1] = "-3.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 2;

   // Rigid body
   mass = 350;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 20;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 20;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.060;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 25;
   collDamageMultiplier   = 0.020;

   //
   minTrailSpeed = 15;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = FlyerJetEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = BomberFlyerThrustSound;
   engineSound = BomberFlyerEngineSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 15.0;
   mediumSplashSoundVelocity = 20.0;
   hardSplashSoundVelocity = 30.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterHardSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterHardSound;
   waterWakeSound    = VehicleWakeHardSplashSound;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";
   targetNameTag = 'C-410';
   targetTypeTag = 'AWACS';
   sensorData = AWACSSensor;
   sensorRadius = AWACSSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 7.1895;
   observeParameters = "1 10 10";
   shieldEffectScale = "0.75 0.975 0.375";
   showPilotInfo = 1;

   max[PlasmaAmmo] = 50;

   replaceTime = 20;
};

datablock BombProjectileData(BuoyBomb)
{
   projectileShapeName  = "nexuscap.dts";
   emitterDelay         = -1;
   directDamage         = 0.0;
   hasDamageRadius      = true;
   indirectDamage       = 0.0;
   damageRadius         = 0;
   radiusDamageType     = $DamageType::BomberBombs;
   kickBackStrength     = 0;

   explosion            = "ChaingunExplosion";
   velInheritFactor     = 1.0;

   grenadeElasticity    = 0.25;
   grenadeFriction      = 0.4;
   armingDelayMS        = 2000;
   muzzleVelocity       = 0.1;
   drag                 = 0.3;

   minRotSpeed          = "0.0 0.0 0.0";
   maxRotSpeed          = "0.0 0.0 10.0";
   scale                = "1.0 1.0 1.0";

//   sound                = BomberBombProjectileSound;
};

datablock TurretImageData(AWACSTorp)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 0 0";
   item      = Chaingun;
   projectile = shrikeBomb;
   projectileType = BombProjectile;
   emap = true;

   mountPoint = 1;
   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = true;
   minEnergy = 5;
   fireEnergy = 5.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4;
   stateAllowImageChange[4] = false;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = MissileReloadSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock TurretImageData(AWACSBuoy)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 0 0";
   item      = Chaingun;
   projectile = BuoyBomb;
   projectileType = BombProjectile;
   emap = true;

   mountPoint = 1;
   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = true;
   minEnergy = 5;
   fireEnergy = 5.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4;
   stateAllowImageChange[4] = false;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = MissileReloadSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock StaticShapeData(SonarBuoy) : StaticShapeDamageProfile {
	className = "teleport";
	shapeFile = "nexuscap.dts";

	maxDamage = 2.00;
	destroyedLevel = 2.00;
	disabledLevel = 1.35;

	isShielded = true;
	energyPerDamagePoint = 250;
	maxEnergy = 100;
	rechargeRate = 1;

	explosion = ShapeExplosion;
	expDmgRadius = 18.0;
	expDamage = 0.3;
	expImpulse = 200.0;

	dynamicType = $TypeMasks::StationObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSwitchIcon;
	cmdMiniIconName = "commander/MiniIcons/com_switch_grey";
	targetNameTag = 'Deployed';
	targetTypeTag = 'Sonar Buoy';

	debrisShapeName = "debris_generic.dts";
	debris = DeployableDebris;

	heatSignature = 0;
	needsPower = false;

	humSound = SensorHumSound;
	pausePowerThread = true;
	sensorData = TelePadBaseSensorObj;
	sensorRadius = TelePadBaseSensorObj.detectRadius;
	sensorColor = "0 212 45";
	firstPersonOnly = true;
};


datablock ShapeBaseImageData(Rearmer)
{
   mountPoint = 7;
   className = WeaponImage;
   shapeFile = "deploy_ammo.dts";
   offset = "0 -35 -8";
   rotation = "1 0 0 -120";
   emap = true;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Deploy";
};

function AWACS::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

   %obj.setInventory(PlasmaAmmo, 50);

   %turret = TurretData::create(BomberTurret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();
   %turret.selectedWeapon = 1;
   %obj.mountObject(%turret, 10);
   %turret.mountImage(GST1Param, 0);
   %turret.mountImage(APCTurretBarrel, 2);
   %turret.mountImage(AWACSTorp, 4);
   %turret.mountImage(AWACSBuoy, 6);
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   %turret.mountobj = %obj;
   %turret.team = %obj.team;
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function AWACS::playerMounted(%data, %obj, %player, %node)
{
//[[CHANGE]]
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0)
   {
      // pilot position
      %player.setPilot(true);
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
	bottomPrint(%player.client, "Pilot Postion: nade for flares and mine for resupply arm.", 5, 2 );
   }
   else if (%node == 1)
   {
      // bombardier position
      %turret = %obj.getMountNodeObject(10);
      %player.vehicleTurret = %turret;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret);
         %player.client.setObjectActiveImage(%turret, 2);
      }
      %turret.bomber = %player;
      $bWeaponActive = 0;
      %obj.getMountNodeObject(10).selectedWeapon = 1;
      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);

	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
      %player.isBomber = true;
	centerPrint(%player.client, "WEP1: CG WEP2: Torp WEP3: sonar buoy dropper", 5, 2 );
   }
   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function AWACS::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (isObject(%turret)){
	%turret.altTrigger = 0;
	%turret.fireTrigger = 0;
	if (%client = %turret.getControllingClient())
	{
	   %client.player.setControlObject(%client.player);
	   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
	   %client.player.mountVehicle = false;

	   %client.player.bomber = false;
	   %client.player.isBomber = false;
	}
	%turret.schedule(2000, delete);
   }
}

function AWACS::onTrigger(%data, %obj, %trigger, %state)
{
   if (%trigger ==4){
      switch (%state) 
	{
      case 0:
         %obj.fireWeapon = false;
      case 1:
		if (%obj.inv[PlasmaAmmo] > 0){
               %obj.fireWeapon = true;
		   %obj.decInventory(PlasmaAmmo, 1);
		   %Upvec = %obj.getUpVector();

   		   %p = new FlareProjectile() 
   		   { 
   		      dataBlock        = FlareGrenadeProj; 
   		      initialDirection = vectorScale(%Upvec, -1); 
   		      initialPosition  = getBoxCenter(%obj.getWorldBox()); 
   		      sourceObject     = %obj; 
   		      sourceSlot       = 0; 
   		   }; 
   		   FlareSet.add(%p); 
   		   MissionCleanup.add(%p); 
   		   %p.schedule(6000, "delete");

		   %vec = vectornormalize(vectorcross(%obj.getForwardvector(),%Upvec));
   		   %p = new FlareProjectile() 
   		   { 
   		      dataBlock        = FlareGrenadeProj; 
   		      initialDirection = %vec; 
   		      initialPosition  = getBoxCenter(%obj.getWorldBox()); 
   		      sourceObject     = %obj; 
   		      sourceSlot       = 0; 
   		   }; 
   		   FlareSet.add(%p); 
   		   MissionCleanup.add(%p); 
   		   %p.schedule(6000, "delete");


   		   %p = new FlareProjectile() 
   		   { 
   		      dataBlock        = FlareGrenadeProj; 
   		      initialDirection = vectorscale(%vec,-1); 
   		      initialPosition  = getBoxCenter(%obj.getWorldBox()); 
   		      sourceObject     = %obj; 
   		      sourceSlot       = 0; 
   		   }; 
   		   FlareSet.add(%p); 
   		   MissionCleanup.add(%p); 
   		   %p.schedule(6000, "delete");

   		   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));  
   		   %obj.lastThrowTime[%data] = getSimTime(); 
   		   %obj.throwStrength = 0; 
		}
      }
   }
   else if (%trigger ==5){
      switch (%state) 
	{
      case 1:
	   if(%obj.isreping == 1){
		stopRearm(%obj);
		%obj.unmountImage(6);
	   }
	   else{
		%obj.isreping = 1;
		RearmLoop(%obj);
		%obj.mountImage(Rearmer, 6);
	   }
      }
   }
}

function RearmLoop(%obj){ 
   if(isObject(%obj)){
	if(%obj.isreping == 0)
	   return;
	
	%targets = %obj.reptargets;
	%vec = vectorAdd(vectorscale(%obj.getForwardVector(),-35),vectorscale(%obj.getUpVector(),-8));
	%pos = vectorAdd(%obj.getWorldBoxCenter(),%vec);
	if(%targets !$= ""){
	   %numtrgs = getNumberOfWords(%targets);
	   for(%i = 0; %i < %numtrgs; %i++){
		%target = getWord(%targets, %i);
		if(vectorDist(%pos, %target.getWorldBoxCenter()) <= 20 && %target.getDamageLevel() > 0.0){
		   if(%target.reping != 1){
			%target.reping = 1;
			%target.setRepairRate(%target.getRepairRate() + 0.01);
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
		if(%datablock.max[MissileLauncherAmmo] !$= "" && %target.inv[MissileLauncherAmmo] < %datablock.max[MissileLauncherAmmo]){
		   %target.incInventory(MissileLauncherAmmo, 1);
		   %reloaded = 1;
		}
		if(%datablock.max[MortarAmmo] !$= "" && %target.inv[MortarAmmo] < %datablock.max[MortarAmmo]){
		   %target.incInventory(MortarAmmo, 1);
		   %reloaded = 1;
		}
		if(%datablock.max[PlasmaAmmo] !$= "" && %target.inv[PlasmaAmmo] < %datablock.max[PlasmaAmmo]){
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
		   if(%datablock.max[MissileLauncherAmmo] !$= "" && %target.turretObject.inv[MissileLauncherAmmo] < %datablock.max[MissileLauncherAmmo]){
		      %target.turretObject.incInventory(MissileLauncherAmmo, 1);
		      %reloaded = 1;
		   }
		   if(%datablock.max[MortarAmmo] !$= "" && %target.turretObject.inv[MortarAmmo] < %datablock.max[MortarAmmo]){
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
//	   if(%targetObject.getClassName() $= "FlyingVehicle")
		%obj.reptargets = %obj.reptargets @ %targetObject @" ";
	}
	if(%obj.isreping == 1)
	   %obj.reploop = schedule(500, 0, "RearmLoop", %obj);
   }
}

function stopRearm(%obj){
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


function AWACSTorp::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   %p.initVel = vectorNormalize(%obj.mountobj.getVelocity());
   %z = getWord(%p.initVel,2);
   if(%z > 0)
	%p.initVel = vectorNormalize(getWord(%p.initVel,0)@" "@getWord(%p.initVel,1)@" 0");
   schedule(500, 0, "changethebomb", %p, "Torp");
}

function AWACSBuoy::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   schedule(500, 0, "changethebomb", %p, "Buoy");
}

function changethebomb(%obj, %type){
   if(!isObject(%obj))
	return;
   %vec = "0 0 100";
   %pos = %obj.getPosition();
   %search = containerRayCast(%pos, vectorAdd(%pos,%vec), $TypeMasks::WaterObjectType, %obj);
   if(%search){
	if(%type $= "Torp"){
	   %p = new SeekerProjectile()
	   {
	      dataBlock        = Torpedo;
	      initialDirection = %obj.initVel;
	      initialPosition  = %pos;
	      sourceObject     = %obj.sourceobject;
   	      sourceSlot       = 3;
	   };
	   %p.sourceobject = %obj.sourceobject;
	   %p.vector = %vec;
	   %p.count = 1;
	   TorpedoSeekLoop(%p);
	   %obj.schedule(10, "delete");
	   return;
	}
	else{
	   %pos = getWord(%search,1)@" "@getWord(%search,2)@" "@getWord(%search,3);
	   if($TeamDeployedCount[%obj.sourceObject.team, SonarBuoy] < 5){
	      %deplObj = new (StaticShape)() {
	         dataBlock = "SonarBuoy";
		   position = %pos;
		   rotation = "0 0 0 0";
		   scale = "1 1 1";
		   team = %obj.sourceObject.team;
		   deployed = "1";
	      };

	      %deplObj.setOwner(%obj.sourceObject.getControllingClient().player);
	      setTargetSensorGroup(%deplObj.getTarget(), %obj.sourceObject.team);
	      addToDeployGroup(%deplObj);
	      $TeamDeployedCount[%obj.sourceObject.team, SonarBuoy]++;
	      %deplObj.deploy();
	      SonarPingLoop(%deplObj);

		%sensor = new (StaticShape) () {
		   datablock = "DeployedPulseSensor";
		   position = vectorAdd(%pos, "0 0 0.5");
		   rotation = "0 0 0 0";
		   scale = "1 1 1";
		   team = %obj.sourceObject.team;
		   deployed = "1";
		   powerFreq = "0";
		};
	      %sensor.setOwner(%obj.sourceObject.getControllingClient().player);
		setTargetSensorGroup(%sensor.getTarget(), %obj.sourceObject.team);
		addToDeployGroup(%sensor);

		%deplObj.sensor = %sensor;
	   }
	   else
	      BottomPrint(%obj.sourceObject.getControllingClient(), "Your team has reached the max of 5 Sonar Buoys.", 5);
	   %obj.schedule(10, "delete");
	   return;
	}
   }
   schedule(100, 0, "changethebomb", %obj, %type);
}

function sonarPingLoop(%obj){ 
   if(!isObject(%obj))
	return;
   InitContainerRadiusSearch(%obj.getPosition(), 300, $TypeMasks::VehicleObjectType);
   while ((%SearchResult = containerSearchNext()) != 0){
	%SearchObj = FirstWord(%SearchResult);
	if(%searchObj.getDataBlock().getName() $= "Sub" || %searchObj.getDataBlock().getName() $= "Boat"){
   	   if(isObject(%SearchObj.SnrBeacon[%obj.team]))
      	%SearchObj.SnrBeacon[%obj.team].setPosition(%searchObj.getWorldBoxCenter());
   	   else{ 
	      %SearchObj.SnrBeacon[%obj.team] = new BeaconObject() {
      	   dataBlock = "SubBeacon";
      	   beaconType = "vehicle";
      	   position = %SearchObj.getWorldBoxCenter();
   	      };
   	      %SearchObj.SnrBeacon[%obj.team].playThread($AmbientThread, "ambient");
   	      %SearchObj.SnrBeacon[%obj.team].team = %obj.team;
   	      %SearchObj.SnrBeacon[%obj.team].sourceObject = %SearchObj;

   	      %SearchObj.SnrBeacon[%obj.team].setTarget(%obj.team);
   	      MissionCleanup.add(%SearchObj.SnrBeacon[%obj.team]);
		%SearchObj.SnrBeacon[%obj.team].schedule(9500, "delete");
	   }
         serverPlay3d("InboundTorpPing",%SearchObj.getWorldBoxCenter()); 
	}
   }
   %obj.sonarloop = schedule(2000, 0, "sonarPingLoop", %obj);
}

function AWACS::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 1:
         //Ocean Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 2:
         //River Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 3:
         //Stagnant Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 4:
         //Lava
         %obj.liquidDamage(%data, $VehicleDamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $VehicleDamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $VehicleDamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}

function SonarBuoy::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, SonarBuoy]--;
//	remDSurface(%obj);
	%obj.schedule(500, "delete");
	%obj.sensor.schedule(500, "delete");
	fireBallExplode(%obj,1);
}
