//**************************************************************
// HAVOC HEAVY TRANSPORT FLIER
//**************************************************************
//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(HAPCFlyerEngineEffect)
{
   effectname = "vehicles/htransport_thrust";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(HAPCFlyerThrustEffect)
{
   effectname = "vehicles/htransport_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(HAPCFlyerEngineSound)
{
   filename    = "fx/vehicles/htransport_thrust.wav";
   description = AudioDefaultLooping3d;
   effect = HAPCFlyerEngineEffect;
};

datablock AudioProfile(HAPCFlyerThrustSound)
{
   filename    = "fx/vehicles/htransport_boost.wav";
   description = AudioDefaultLooping3d;
   effect = HAPCFlyerThrustEffect;
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(HAPCFlyer) : HavocDamageProfile
{
   spawnOffset = "0 0 6";
   renderWhenDestroyed = false;

   catagory = "Vehicles";
   shapeFile = "vehicle_air_hapc.dts";
   multipassenger = true;
   computeCRC = true;


   debrisShapeName = "vehicle_air_hapc.dts";
   debris = ShapeDebris;

   drag = 0.2;
   density = 1.0;

   mountPose[0] = sitting;
//   mountPose[1] = sitting;
   numMountPoints = 6;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = false;
   isProtectedMountPoint[2] = false;
   isProtectedMountPoint[3] = false;
   isProtectedMountPoint[4] = false;
   isProtectedMountPoint[5] = false;
   canControl = true;
   cameraMaxDist = 17;
   cameraOffset = 2;
   cameraLag = 8.5;
   explosion = MFVehicleExplosion;
	explosionDamage = 1.5;
	explosionRadius = 20.0;

   maxDamage = 8.0;
   destroyedLevel = 8.0;

   HDAddMassLevel = 5.6;
   HDMassImage = HFlyerHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 175;
   maxEnergy = 550;
   minDrag = 100;                // Linear Drag
   rotationalDrag = 2700;        // Anguler Drag

   // Auto stabilize speed
   maxAutoSpeed = 10;
   autoAngularForce = 3000;      // Angular stabilizer force
   autoLinearForce = 450;        // Linear stabilzer force
   autoInputDamping = 0.95;      //

   // Maneuvering
   maxSteeringAngle = 8;
   horizontalSurfaceForce = 10;  // Horizontal center "wing"
   verticalSurfaceForce = 10;    // Vertical center "wing"
   maneuveringForce = 6000;      // Horizontal jets
   steeringForce = 1000;          // Steering jets
   steeringRollForce = 2500;      // Steering jets
   rollForce = 12;               // Auto-roll
   hoverHeight = 6;         // Height off the ground at rest
   createHoverHeight = 6;   // Height off the ground when created
   maxForwardSpeed = 90;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 5000;
   minJetEnergy = 55;
   jetEnergyDrain = 3.0;
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
   mass = 450;
   bodyFriction = 0;
   bodyRestitution = 0.3;
   minRollSpeed = 0;
   softImpactSpeed = 12;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 15;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 25;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.060;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 28;
   collDamageMultiplier   = 0.020;

   //
   minTrailSpeed = 15;
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = FlyerJetEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = HAPCFlyerThrustSound;
   engineSound = HAPCFlyerEngineSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 8.0;
   hardSplashSoundVelocity = 12.0;
   exitSplashSoundVelocity = 8.0;

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
   cmdIcon = CMDFlyingHAPCIcon;
   cmdMiniIconName = "commander/MiniIcons/com_hapc_grey";
   targetNameTag = 'HVC Golem';
   targetTypeTag = 'Heavy Transport';
   sensorData = PlayerSensor;

   checkRadius = 7.8115;
   observeParameters = "1 15 15";

   stuckTimerTicks = 32;   // If the hapc spends more than 1 sec in contact with something
   stuckTimerAngle = 80;   //  with a > 80 deg. pitch, BOOM!

   shieldEffectScale = "1.0 0.9375 0.45";

   max[PlasmaAmmo] = 20;

   replaceTime = 40;
};

function HAPCFlyer::hasDismountOverrides(%data, %obj)
{
   return true;
}

function HAPCFlyer::getDismountOverride(%data, %obj, %mounted)
{
   %node = -1;
   for (%i = 0; %i < %data.numMountPoints; %i++)
   {
      if (%obj.getMountNodeObject(%i) == %mounted)
      {
         %node = %i;
         break;
      }
   }
   if (%node == -1)
   {
      warning("Couldn't find object mount point");
      return "0 0 1";
   }

   if (%node == 3 || %node == 2)
   {
      return "-1 0 1";
   }
   else if (%node == 5 || %node == 4)
   {
      return "1 0 1";
   }
   else
   {
      return "0 0 1";
   }
}

//**************************************************************
// Vehicle pickup
//**************************************************************

datablock ShapeBaseImageData(FFTmountImage)
{
   className = "WeaponImage";
   shapeFile = "vehicle_land_mpbase.dts";
   item = Disc;
   offset = "0 0 -6";
   emap = true;
   mass = 500;
};

datablock ShapeBaseImageData(PanzermountImage)
{
   className = "WeaponImage";
   shapeFile = "vehicle_grav_tank.dts";
   item = Disc;
   offset = "0 0 -6";
   emap = true;
   mass = 325;
};

datablock ShapeBaseImageData(WC1Image)
{
   className = "WeaponImage";
   shapeFile = "vehicle_grav_scout.dts";
   item = Disc;
   offset = "0 0 -5"; // L/R - F/B - T/B
   emap = true;
   mass = 50;
};

datablock ShapeBaseImageData(WC2Image)
{
   className = "WeaponImage";
   shapeFile = "vehicle_grav_scout.dts";
   item = Disc;
   offset = "0 4 -5"; // L/R - F/B - T/B
   emap = true;
   mass = 50;
};

function HAPCflyer::onTrigger(%data, %obj, %trigger, %state)
{
   if(!%obj.hasVEH && %state == 1 && %trigger == 0)
   {
	%mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType;
	%dir = %obj.getTransform();
	%dir = getWord(%dir, 5);
	if(%dir > 0)
	   %dir *= -1;
	if(vectorDot("0 0 -10", "0 0 "@ %dir) < 9)
	   return;
	%vector = vectorAdd(%obj.getWorldBoxCenter(), "0 0 -10");
   	%searchResult = containerRayCast(%obj.getWorldBoxCenter(), %vector, %mask, %obj);
	if(%searchResult)
	{
	   %searchObj = GetWord(%searchResult, 0);
	   if(%searchObj.getClassName() $= "wheeledVehicle"){
		%searchObj.setTransform(vectorAdd(%searchObj.getPosition(), "0 0 10000"));
		%searchObj.setCloaked(true);
		%obj.mountImage(FFTmountImage, 6);
		%searchObj.setFrozenState(true);
		%obj.hasVEH = true;
		%obj.VEHmounted = %searchObj;
	   }

	   else if(%searchObj.getClassName() $= "HoverVehicle"){
		%searchObj.setTransform(vectorAdd(%searchObj.getPosition(), "0 0 10000"));
		%searchObj.setCloaked(true);
		%searchObj.setFrozenState(true);
		%obj.hasVEH = true;
		%obj.VEHmounted = %searchObj;
		if(%searchObj.getDataBlock().getName() $= "ScoutVehicle")
		   %obj.mountImage(WC1Image, 6);
		else
		   %obj.mountImage(PanzermountImage, 6);
	   }
	}
   }
   else if(%obj.hasVEH && %state == 1 && %trigger == 0)
   {
	%dir = %obj.getTransform();
	%dir = getWord(%dir, 5);
	if(%dir > 0)
	   %dir *= -1;
	//echo(vectorDot("0 0 -10", "0 0 "@ %dir));
	if(vectorDot("0 0 -10", "0 0 "@ %dir) < 9)
	   return;
	%mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TerrainObjectType;
	%vector = vectorAdd(%obj.getWorldBoxCenter(), "0 0 -15");
   	%searchResult = containerRayCast(%obj.getWorldBoxCenter(), %vector, %mask, %obj);
   	%vec = %Obj.getvelocity();
	if(%searchResult)
	{
	   return;
	}
	if (%obj.VEHmounted !$= "")
	{
	   %obj.VEHmounted.setFrozenState(false);
	   %obj.VEHmounted.setTransform(%obj.getTransform());
	   %vector = vectorAdd("0 0 -13", %obj.getWorldBoxCenter());
	   %obj.VEHmounted.setTransform(%vector);
	   %obj.VEHmounted.applyImpulse(%obj.VEHmounted.getPosition(),vectorScale(%vec,%obj.VEHmounted.getDataBlock().mass));
	   %obj.VEHmounted.setCloaked(false);
	   %obj.unMountImage(6);
	   %obj.unMountObject(%obj.MPBstaticMount);
	   %obj.hasVEH = false;
	   %obj.VEHmounted = "";
	   %obj.canpickupWC = false;
	}
   }
   else if (%trigger ==4)    // Throw flare
   {
      switch (%state)
	{
      case 0:
         %obj.fireWeapon = false;
         %obj.setImageTrigger(5, false);
      case 1:
	   if (%obj.inv[PlasmaAmmo] > 0)
	   {
            %obj.fireWeapon = true;
            %obj.setImageTrigger(5, true);
		%obj.decInventory(PlasmaAmmo, 1);
   		%p = new FlareProjectile()
   		{
   		   dataBlock        = FlareGrenadeProj;
   		   initialDirection = "0 0 -1";
   		   initialPosition  = getBoxCenter(%obj.getWorldBox());
   		   sourceObject     = %obj;
   		   sourceSlot       = 0;
   		};

   		FlareSet.add(%p);
   		MissionCleanup.add(%p);
   		   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));
   		   %p.schedule(6000, "delete");
   		   // miscellaneous grenade-throwing cleanup stuff
   		   %obj.lastThrowTime[%data] = getSimTime();
   		%obj.throwStrength = 0;
	   }
      }
   }
   %up = %obj.getUpVector();
   if(%state == 1 && %trigger == 5 && vectorDist(%up,"0 0 1") <= 0.3){
	%frd = %obj.getForwardVector();
	%right = vectorNormalize(vectorSub(%obj.getEdge("1 0 0"),%obj.getEdge("-1 0 0")));
	for(%i = 2; %i < 6; %i++){
	   if(%obj.getMountNodeObject(%i)){
		%plyr = %obj.getMountNodeObject(%i);
		%plyr.unmount();
		%plyr.setPosition("0 0 1000");
		%vec = vectorAdd(vectorScale(%right,getWord($PodPos[%i],0)),vectorScale(%frd,getWord($PodPos[%i],1)));
		%pos = vectorAdd(%obj.getPosition(),%vec);
		%pod = MakeDropPod(vectorAdd(%pos,"0 0 -15"),%obj.team);
		slowDropPod(%pod);
		// Eolk - was wrong. Didn't mount right.
//		%pod.schedule(10, "mountObject", %plyr, 0);
		%plyr.getDatablock().schedule(10, "onCollision", %plyr, %pod, 0);
		commandToClient(%plyr.client, 'setHudMode', 'Standard', "", 0);
	   }
	}
   }
}

$PodPos[2] = "-3 7";
$PodPos[3] = "-3 3";
$PodPos[4] = "3 3";
$PodPos[5] = "3 7";

function HAPCflyer::onDestroyed(%data, %obj, %prevState){
   %vec = %Obj.getvelocity();
   if (%obj.VEHmounted !$= "")
   {
	%obj.VEHmounted.setFrozenState(false);
	%obj.VEHmounted.setTransform(%obj.getTransform());
	%vector = vectorAdd("0 0 -13", %obj.getWorldBoxCenter());
	%obj.VEHmounted.setTransform(%vector);
	%obj.VEHmounted.applyImpulse(%obj.VEHmounted.getPosition(),vectorScale(%vec,%obj.VEHmounted.getDataBlock().mass));
	%obj.VEHmounted.setCloaked(false);
	%obj.unMountImage(6);
	%obj.unMountObject(%obj.MPBstaticMount);
	%obj.hasVEH = false;
	%obj.VEHmounted = "";
	%obj.canpickupWC = false;
	if(%obj.hasWC){
	   %obj.WCmounted.setFrozenState(false);
	   %obj.WCmounted.setTransform(%obj.getTransform());
	   %vector = vectorAdd("0 6 -13", %obj.getWorldBoxCenter());
	   %obj.WCmounted.setTransform(%vector);
	   %obj.WCmounted.applyImpulse(%obj.MPBmounted.getPosition(), vectorScale(%vec,ScoutVehicle.mass));
	   %obj.WCmounted.setCloaked(false);
	   %obj.unMountImage(7);
	   %obj.unMountObject(%obj.MPBstaticMount);
	   %obj.hasWC = false;
	   %obj.WCmounted = "";
	}
   }
   Parent::onDestroyed(%data, %obj, %prevState);
}

function HAPCflyer::onEnterLiquid(%data, %obj, %coverage, %type)
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
