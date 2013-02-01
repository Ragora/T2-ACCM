//==============================================================================
// Sentinel Data - Made by Blnukem
//==============================================================================
// Sentinel Sounds
//------------------------------------------------------------------------------

datablock EffectProfile(SentinelTurretSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(SentinelTurretFireEffect)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   minDistance = 2.5;
   maxDistance = 8.0;
};

datablock EffectProfile(SentinelDeactivateEffect)
{
   effectname = "powered/turret_heavy_reload";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(SentinelActivateEffect)
{
   effectname = "powered/turret_light_reload";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(SentinelIdleEffect)
{
   effectname = "powered/turret_light_idle";
   minDistance = 1;
   maxDistance = 2;
};

datablock AudioProfile(SentinelTurretSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = SentinelTurretSwitchEffect;
};

datablock AudioProfile(SentinelTurretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = SentinelTurretFireEffect;
};

datablock AudioProfile(SentinelIdleSound)
{
   filename    = "fx/powered/turret_light_idle.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = SentinelIdleEffect;
};

datablock AudioProfile(SentinelActivateSound)
{
   filename    = "fx/powered/turret_light_reload.wav";
   description = AudioClose3d;
   preload = true;
   effect = SentinelActivateEffect;
};

datablock AudioProfile(SentinelDeactivateSound)
{
   filename    = "fx/powered/turret_heavy_reload.wav";
   description = AudioClose3d;
   preload = true;
   effect = SentinelDeactivateEffect;
};

//==============================================================================
// Vehicle Data
//==============================================================================
// Standard Sentinel
//------------------------------------------------------------------------------

datablock FlyingVehicleData(SentinelVehicle) : SentinelDamageProfile
{
   spawnOffset = "0.0 0.0 0.1";

   catagory = "Sentinels";
   shapeFile = "stackable2s.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "debris_generic.dts";
   debris = TurretDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   numMountPoints = 0;

   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = TurretExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;

   maxDamage = 0.5;
   destroyedLevel = 0.5;

   isShielded = true;
   energyPerDamagePoint = 160;
   maxEnergy = 280;
   rechargeRate = 0.8;

   minDrag = 30;
   rotationalDrag = 2000;

   maxAutoSpeed = 15;
   autoAngularForce = 400;
   autoLinearForce = 300;
   autoInputDamping = 0.95;

   maxSteeringAngle = 5;
   horizontalSurfaceForce = 6;
   verticalSurfaceForce = 4;
   maneuveringForce = 5000;
   steeringForce = 3000;
   steeringRollForce = 0;
   rollForce = 10;
   hoverHeight = 10;
   createHoverHeight = 2;
   maxForwardSpeed = 15;

   jetForce = 4500;
   minJetEnergy = 0;
   jetEnergyDrain = 0;                                                                                                                                                                                                                                                                                 // Auto stabilize speed
   vertThrustMultiple = 0;

   mass = 100;
   bodyFriction = 0;
   bodyRestitution = 0.5;
   minRollSpeed = 0;
   softImpactSpeed = 14;
   hardImpactSpeed = 25;

   minImpactSpeed = 10;
   speedDamageScale = 0.06;

   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   jetSound = "";
   engineSound = SentinelIdleSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   dustEmitter = LiftoffDustEmitter;
   triggerDustHeight = 1.0;
   dustHeight = 0.1;
   canControl = false;

   minMountDist = 4;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'Standard';
   targetTypeTag = 'Sentinel';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 5 5";
   canObserve = true;

   runningLight[0] = ShrikeLight1;

   shieldEffectScale = "2.0 2.0 2.0";

};

//==============================================================================
// Sentinel Monitor Vehicle Data
//==============================================================================

datablock FlyingVehicleData(SentinelMonitor) : SentinelDamageProfile
{
   spawnOffset = "0.0 0.0 0.0";

   catagory = "Sentinels";
   shapeFile = "beacon.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "debris_generic.dts";
   debris = TurretDebris;
   renderWhenDestroyed = false;

   drag    = 4.15;
   density = 1.0;

   numMountPoints = 0;

   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = TurretExplosion;
   explosionDamage = 0.5;
   explosionRadius = 5.0;

   maxDamage = 50.00;
   destroyedLevel = 50.00;

   isShielded = true;
   rechargeRate = 2.5;
   energyPerDamagePoint = 1;
   maxEnergy = 500;
   rechargeRate = 50.0;

   minDrag = 30;
   rotationalDrag = 2000;

   maxAutoSpeed = 15;
   autoAngularForce = 400;
   autoLinearForce = 300;
   autoInputDamping = 0.95;

   maxSteeringAngle = 5;
   horizontalSurfaceForce = 6;
   verticalSurfaceForce = 4;
   maneuveringForce = 5000;
   steeringForce = 1000;
   steeringRollForce = 0;
   rollForce = 100;
   hoverHeight = 15;
   createHoverHeight = 2;
   maxForwardSpeed = 15;

   jetForce = 1500;
   minJetEnergy = 0;
   jetEnergyDrain = 0;                                                                                                                                                                                                                                                                                 // Auto stabilize speed
   vertThrustMultiple = 0;

   mass = 100;
   bodyFriction = 0;
   bodyRestitution = 0.5;
   minRollSpeed = 0;
   softImpactSpeed = 14;
   hardImpactSpeed = 25;

   minImpactSpeed = 25;
   speedDamageScale = 0.06;

   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   minTrailSpeed = 0.1;
   trailEmitter = ContrailEmitter;

   jetSound = "";
   engineSound = SentinelIdleSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;

   softSplashSoundVelocity = 10.0;
   mediumSplashSoundVelocity = 15.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   dustEmitter = LiftoffDustEmitter;
   triggerDustHeight = 2.0;
   dustHeight = 0.0;
   canControl = false;

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = LightDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 0.0 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   minMountDist = 4;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDCameraIcon;
   cmdMiniIconName = "commander/MiniIcons/com_camera_grey";
   targetNameTag = '';
   targetTypeTag = 'Monitor';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 10.5;
   observeParameters = "1 5 5";
   canObserve = true;

   runningLight[0] = ShrikeLight1;

   shieldEffectScale = "2.0 2.0 2.0";

};

//==============================================================================
// Image Data
//==============================================================================
// Standard Sentinel Image Data:
//------------------------------------------------------------------------------

datablock ShapeBaseImageData(BodyImage) : SentinelVehicle
{
   offset = "0.0 -0.2 0.3";
   rotation = "0 0 1 0";
   shapeFile = "turret_mortar_large.dts";
};

datablock ShapeBaseImageData(RightWing) : SentinelVehicle
{
   offset = "0.2 0.0 0.4";
   rotation = "0 0 -1 90";
   shapeFile = "pack_deploy_sensor_pulse.dts";
};

datablock ShapeBaseImageData(LeftWing) : SentinelVehicle
{
   offset = "-0.2 0.0 0.4";
   rotation = "0 0 1 90";
   shapeFile = "pack_deploy_sensor_pulse.dts";
};

datablock ShapeBaseImageData(Eye) : SentinelVehicle
{
   offset = "0.0 1.1 0.22";
   rotation = "1 0 0 90";
   shapeFile = "beacon.dts";
};

//==============================================================================
// Sentinel Monitor Image Data:
//==============================================================================

datablock ShapeBaseImageData(Front) : SentinelMonitor
{
   offset = "0.0 -0.02 0.0";
   rotation = "1.0 0.0 0.0 90.0";
   shapeFile = "camera.dts";
};

datablock ShapeBaseImageData(Rear) : SentinelMonitor
{
   offset = "0.0 0.02 0.0";
   rotation = "-1.0 0.0 0.0 90.0";
   shapeFile = "camera.dts";
};

//==============================================================================
// Decals and Projectiles
//==============================================================================
// Default Sentinel bullet Decal image:
//------------------------------------------------------------------------------

datablock DecalData(SentinelDecal1)
{
   sizeX       = 0.15;
   sizeY       = 0.15;
   textureName = "special/bullethole3";
};

//==============================================================================
// Standard Sentinel Bullet:
//==============================================================================

datablock TracerProjectileData(SentinelBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.15;
   directDamageType    = $DamageType::Sentinel;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;

   kickBackStrength  = 50.0;
   sound 			 = ChaingunProjectile;

   dryVelocity       = 800.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 10.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 10.0/255.0 @ " " @ 30.0/255.0 @ " " @ 240.0/255.0 @ " 0.75";
   tracerTex[0]  	 = "special/tracer00";
   tracerTex[1]  	 = "special/tracercross";
   tracerWidth     = 0.15;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = SentinelDecal1;

   hasLight    = true;
   lightRadius = 8.0;
   lightColor  = "0.5 0.5 0.175";

};

//==============================================================================
// Turret Data
//==============================================================================
// Standard Sentinel Turret:
//------------------------------------------------------------------------------

datablock TurretData(SentinelTurret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_belly_base.dts";
   preload                 = true;

   mass                    = 1.0;
   maxDamage               = 1.0;
   destroyedLevel          = 1.0;
   repairRate              = 0;
   maxDamage               = SentinelVehicle.maxDamage;
   destroyedLevel          = SentinelVehicle.destroyedLevel;
   rechargeRate            = 0.15;

   thetaMin = 90;
   thetaMax = 180;
   thetaNull = 90;

   rechargeRate = 0.15;

   isShielded = false;
   energyPerDamagePoint = 110;
   maxEnergy = 60;
   renderWhenDestroyed = true;
   barrel = SentinelTurretBarrel;
   heatSignature = 0;

   canControl = false;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Sentinel';
   targetTypeTag = 'Turret';

   firstPersonOnly = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretImageData(SentinelTurretBarrel)
{
   shapeFile         = "turret_muzzlepoint.dts";
   mountPoint        = 0;

   projectile        = SentinelBullet;
   projectileType    = TracerProjectile;

   usesEnergy        = true;
   fireEnergy        = 0.0;
   minEnergy         = 10.0;
   emap              = true;

   activationMS      = 700;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 120;
   degPerSecTheta    = 2000;
   degPerSecPhi      = 2000;
   attackRadius      = 100;

   casing            = ShellDebris;
   shellExitDir      = "0.0 -0.5 -0.5";
   shellExitOffset   = "0.0 0.0 0.0";
   shellExitVariance = 20.0;
   shellVelocity     = 5.0;

   projectileSpread  = 2.0 / 1000.0;

   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = SentinelActivateSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                    = "Fire";
   stateSequence[3]                = "Fire";
   stateSequenceRandomFlash[3]     = true;
   stateSound[3]                   = ChaingunFireSound;
   stateAllowImageChange[3]        = false;
   stateEmitter[3]                 = "GunFireEffectEmitter";
   stateEmitterNode[3]             = "muzzlepoint1";
   stateEmitterTime[3]             = 0.1;
   stateScript[3]                  = "onFire";
   stateFire[3]                    = true;
   stateEjectShell[3]              = true;
   stateTimeoutValue[3]            = 0.1;
   stateTransitionOnTimeout[3]     = "Fire";
   stateTransitionOnTriggerUp[3]   = "Reload";
   stateTransitionOnNoAmmo[3]      = "noAmmo";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.01;
   stateAllowImageChange[4]      = false;
   stateWaitForTimeout[4]        = true;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateSound[5]               = SentinelDeactivateSound;
   stateEmitter[5]             = "GunFireEffectEmitter";
   stateEmitterNode[5]         = "muzzlepoint1";
   stateEmitterTime[5]         = 0.2;
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};

//==============================================================================
// Vehicle Functions
//==============================================================================
// Sentinel Functions:
//------------------------------------------------------------------------------

function SentinelVehicle::deleteAllMounted(%data, %obj) {
   $HostGamePlayerCount = ClientGroup.GetCount();
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

   %turret.altTrigger = 0;
   %turret.fireTrigger = 0;

   if (%client = %turret.getControllingClient()) {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;

      %client.player.bomber = false;
      %client.player.isBomber = false;
   }
   %turret.schedule(0, delete);
}

function SentinelVehicle::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(BodyImage, 1);
   %obj.mountImage(RightWing, 2);
   %obj.mountImage(LeftWing, 3);
   %obj.mountImage(Eye, 4);

   %turret = TurretData::create(SentinelTurret);
   %turret.scale = "0.45 0.45 0.45";
   MissionCleanup.add(%turret);
   %turret.team = 1;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(SentinelTurretBarrel, 0);
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(true);
   %turret.mountImage(AIAimingTurretBarrel, 1);

   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

//==============================================================================
// Monitor Functions:
//==============================================================================

function SentinelMonitor::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(Front, 1);
   %obj.mountImage(Rear, 2);
}
