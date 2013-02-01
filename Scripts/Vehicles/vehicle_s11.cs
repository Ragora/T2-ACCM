//**************************************************************
// S11 Recon Drone
//**************************************************************
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(S11) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "nexuscap.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = MeShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = false;
   isProtectedMountPoint[1] = false;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MeVehicleExplosion;
	explosionDamage = 1.0;
	explosionRadius = 10.0;

   maxDamage = 1.2;
   destroyedLevel = 1.2;

   HDAddMassLevel = 1.0;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 1200;      // Afterburner and any energy weapon pool
   rechargeRate = 4;

   minDrag = 22;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 100;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 0;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 3500;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 300;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 2000;      // Steering jets (how much you heel over when you turn)
   rollForce = 7;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2.5;        // Height off the ground at rest
   createHoverHeight = 2;  // Height off the ground when created
   maxForwardSpeed = 120;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2500;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 7;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 1.25;

   // Rigid body
   mass = 90;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 20;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.06;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 150;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = FlyerJetEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = ScoutFlyerThrustSound;
   engineSound = ScoutFlyerEngineSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 4.0;
   dustHeight = 1.0;

   damageEmitter[0] = MeLightDamageSmoke;
   damageEmitter[1] = MeHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.65;
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'S11';
   targetTypeTag = 'Recon Drone';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;

   shieldEffectScale = "0.937 1.125 0.60";

   replaceTime = 90;

   max[AALauncherAmmo] = 1;
};

datablock StaticShapeData(S11wing) : StaticShapeDamageProfile {
   shapeFile      = "deploy_inventory.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

datablock StaticShapeData(S11sensor) : StaticShapeDamageProfile {
   shapeFile      = "deploy_sensor_pulse.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

//-------------------------------------
// CHOPPER BELLY TURRET CHARACTERISTICS
//-------------------------------------

datablock TurretData(S11Turret) : ShrikeDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_belly_base.dts";   //turret_sentry.dts
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = S11.maxDamage;
   destroyedLevel          = S11.destroyedLevel;

   thetaMin                = 90;
   thetaMax                = 180;

   heatSignature 		   = 0.0;

   // capacitor
   maxCapacitorEnergy      = 500;
   capacitorRechargeRate   = 5.0;

   inheritEnergyFromMount  = true;
   firstPersonOnly         = true;
   useEyePoint             = true;
   numWeapons              = 2;

   targetNameTag           = 'S11';
   targetTypeTag           = 'Turret';

   max[AALauncherAmmo] = 1;
};

datablock TurretImageData(S11TL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   mountPoint = 0;
   offset = "0 0 0";

   projectile = GunshipTlProj;
   projectileType = TargetProjectile;
   deleteLastProjectile = false;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = false;
   minEnergy = 0;
   fireEnergy = 1.0;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
   stateTimeoutValue[0]			= 0.1;
   stateTransitionOnTimeout[0]       = "Ready";

   stateName[1]				= "Ready";
   stateTransitionOnTriggerDown[1]	= "Fire";

   stateName[2]                     = "Fire";
   stateEnergyDrain[2]              = 0;
   stateFire[2]                     = true;
   stateScript[2]                   = "onFire";
   stateTransitionOnTriggerUp[2]	= "Deconstruct";

   stateName[3]				= "Deconstruct";
   stateScript[3]				= "onDecon";
   stateTimeoutValue[3]			= 0.1;
   stateTransitionOnTimeout[3]	= "Ready";
};

datablock TurretImageData(S11MissileImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = MissileLauncher;
   ammo = AALauncherAmmo;
   projectile = HammerATMissile;
   projectileType = SeekerProjectile;

   mountPoint = 1;

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

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
   stateSound[3] = MissileFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 5.0;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock TurretImageData(S11TurretParam) 
{ 
   mountPoint 		= 3; 
   shapeFile 		= "turret_muzzlepoint.dts"; 
   offset = "0.0 0.0 -1.5";

   projectile = snipergunBullet;
   projectileType = TracerProjectile;

   activationMS         = 10;
   deactivateDelayMS    = 15;
   thinkTimeMS          = 20;
   degPerSecTheta       = 50;
   degPerSecPhi         = 80;
   attackRadius         = 1200;
};

function S11::onAdd(%this, %obj){
   Parent::onAdd(%this, %obj);

   %turret = TurretData::create(S11Turret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.team;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(S11TurretParam, 0);
   %turret.mountImage(S11TL, 2);
   %turret.mountImage(S11MissileImage, 3);
   %turret.setInventory(AALauncherAmmo, 1);
   %obj.turret = %turret;
   %obj.turretobject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   %turret.mountobj = %obj;
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);

   %obj.startFade(0,10,1);

   %wing = new StaticShape()
   {
       scale = "2.5 4 0.12";
       dataBlock = "S11wing";
   };
   MissionCleanup.add(%wing);
   %obj.mountObject(%wing, 1);
   %wing.vehicleMounted = %obj;
   %wing.deploy();

   %sensor = new StaticShape()
   {
       scale = "1.5 1.5 0.5";
       dataBlock = "S11sensor";
   };
   MissionCleanup.add(%sensor);
   %obj.mountObject(%sensor, 2);
   %sensor.vehicleMounted = %obj;
   %sensor.deploy();

   schedule(5000, 0, "S11TurretAttackCheck",%obj);
}

function S11::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;

      %client.player.bomber = false;
      %client.player.isBomber = false;
   }
   %turret.schedule(500, delete);

   %body = %obj.getMountNodeObject(2);
   if (isObject(%body))
	%body.schedule(1000, delete);

   %wing = %obj.getMountNodeObject(1);
   if (isObject(%wing))
	%wing.schedule(2000, delete);
   $teamRepCredits[%obj.team] += getWord($commsatPurchase[1],1);
   $teamUsedCredits[%obj.team] -= getWord($commsatPurchase[1],1);
}

function S11Turret::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
         if(%obj.selectedWeapon == 1)
         {
            %obj.setImageTrigger(3, false);
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
         }
         else
         {
            %obj.setImageTrigger(2, false);
            if(%state)
               %obj.setImageTrigger(3, true);
            else
               %obj.setImageTrigger(3, false);
         } 

      case 2:
         if(%state)
         {
            %obj.getDataBlock().playerDismount(%obj);
         }
   }
}

function S11MissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TLB)){
	%p.setObjectTarget(%obj.TLB);
	%obj.TLB.setPosition(%obj.target.getPosition());
   }
   %obj.lastmissile = %p;
}

function S11TL::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   schedule(400,0,"S11TLmakebeacon",%obj,%p);
}

function S11TLmakebeacon(%obj,%p){
   %p.setTarget(%obj.team);
   %p.beacon = new BeaconObject() {
      dataBlock = "SubBeacon";
      beaconType = "vehicle";
      position = %p.getTargetPoint();
   };
   %beacon.team = %obj.team;
   %beacon.setTarget(%obj.team);
   %obj.TLB = %p.beacon;
   %obj.TL = %p;
   %p.turret = %obj;
}

function S11TL::onDecon(%data,%obj,%slot){
   %obj.TL.delete();
   removeTLBcheck(%obj.TLB,%obj.lastmissile);
}

function removeTLBcheck(%TLB,%p){
   if(!isObject(%TLB))
	return;
   if(!isObject(%p)){
	%TLB.delete();
	return;
   }
   schedule(500, 0, "removeTLBcheck", %TLB, %p);
}

function S11TurretAttackCheck(%obj){
   if(!isObject(%obj))
	return;

   if(%obj.mode $= "RECON"){
	%valid = 0;
      %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType | $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
      InitContainerRadiusSearch(%obj.getPosition(),1200,%TargetSearchMask);
      while ((%potentialTarget = ContainerSearchNext()) != 0) {
	   if (%potentialtarget && %valid != 1) {
		%PTT = %potentialtarget.team;
		if(%PTT $= "")
		   %PTT = %obj.team;
		if(!(%PTT == %obj.team)){
		   %valid = 1;
		   %target = %potentialtarget;
		}
	   }
	}
	if(%valid == 1){
	      %obj.turretobject.setTargetObject(%target);
	      %obj.turretobject.aquireTime = getSimTime();
	      %obj.turretobject.setImageTrigger(2,true);
	}
	else{
	      %obj.turretobject.setImageTrigger(2,false);
		%obj.turretObject.clearTarget();
	}
   }
   schedule(250, 0, "S11TurretAttackCheck",%obj);
}