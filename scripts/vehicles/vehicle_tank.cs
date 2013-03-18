//**************************************************************
// BEOWULF ASSAULT VEHICLE
//**************************************************************

datablock AudioProfile(MobileBaseStationDeploySound)
{
   filename    = "fx/vehicles/MPB_deploy_station.wav";
   description = AudioClose3d;
   preload = true;
};

datablock ParticleData(ACCGSmoke)
{
   dragCoeffiecient     = 0.05;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 150;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -25.0;
   spinRandomMax =  25.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.3 0.3 0.3 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.5 0.5 0.5 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};
datablock ParticleEmitterData(ACCGSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.1;

   ejectionVelocity = 4.0;
   velocityVariance = 3.5;

   thetaMin         = 85.0;
   thetaMax         = 90.0;

   lifetimeMS       = 100;

   particles = "ACCGSmoke";

};
datablock ParticleEmitterData(ACCGSmokeEmitter2)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 0.1;

   ejectionVelocity = 5.5;
   velocityVariance = 5.5;

   thetaMin         = 0.0;
   thetaMax         = 15.0;

   lifetimeMS       = 150;

   particles = "ACCGSmoke";

};
datablock ExplosionData(ACCGSubExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 2.0;
   sizes[0] = "0.1 0.1 0.1";
   sizes[1] = "0.1 0.1 0.1";
   times[0] = 0.0;
   times[1] = 1.0;

};
datablock ExplosionData(ACCGExplosion)
{
   soundProfile   = plasmaExpSound;
   subExplosion[0] = ACCGSubExplosion;
   emitter[0] = ACCGSmokeEmitter;
   emitter[1] = ACCGSmokeEmitter2;
   shakeCamera = false;
};

//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(AssaultVehicleEngineEffect)
{
   effectname = "vehicles/tank_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultVehicleThrustEffect)
{
   effectname = "vehicles/tank_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultTurretActivateEffect)
{
   effectname = "vehicles/tank_activate";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultMortarDryFireEffect)
{
   effectname = "weapons/mortar_dryfire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultMortarFireEffect)
{
   effectname = "vehicles/tank_mortar_fire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultMortarReloadEffect)
{
   effectname = "weapons/mortar_reload";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(AssaultChaingunFireEffect)
{
   effectname = "weapons/chaingun_fire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(AssaultVehicleSkid)
{
   filename    = "fx/vehicles/tank_skid.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(AssaultVehicleEngineSound)
{
   filename    = "fx/vehicles/tank_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultVehicleEngineEffect;
};

datablock AudioProfile(AssaultVehicleThrustSound)
{
   filename    = "fx/vehicles/tank_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultVehicleThrustEffect;
};

datablock AudioProfile(AssaultChaingunFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

datablock AudioProfile(AssaultChaingunReloadSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(TankChaingunProjectile)
{
   filename    = "fx/weapons/chaingun_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
};

datablock AudioProfile(AssaultTurretActivateSound)
{
    filename    = "fx/vehicles/tank_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = AssaultTurretActivateEffect;
};

datablock AudioProfile(AssaultChaingunDryFireSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(AssaultChaingunIdleSound)
{
   filename    = "fx/misc/diagnostic_on.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(AssaultMortarDryFireSound)
{
   filename    = "fx/weapons/mortar_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = AssaultMortarDryFireEffect;
};

datablock AudioProfile(AssaultMortarFireSound)
{
   filename    = "fx/vehicles/tank_mortar_fire.wav";
   description = AudioClose3d;
   preload = true;
   effect = AssaultMortarFireEffect;
};

datablock AudioProfile(AssaultMortarReloadSound)
{
   filename    = "fx/weapons/mortar_reload.wav";
   description = AudioClose3d;
   preload = true;
   effect = AssaultMortarReloadEffect;
};

datablock AudioProfile(AssaultMortarIdleSound)
{
   filename    = "fx/misc/diagnostic_on.wav";
   description = ClosestLooping3d;
   preload = true;
};

//**************************************************************
// LIGHTS
//**************************************************************
datablock RunningLightData(TankLight1)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.2";
   nodeName = "Headlight_node01";
   direction = "0.0 1.0 0.0";
   texture = "special/headlight4";
};

datablock RunningLightData(TankLight2)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.2";
   nodeName = "Headlight_node02";
   direction = "0.0 1.0 0.0";
   texture = "special/headlight4";
};

datablock RunningLightData(TankLight3)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.2";
   nodeName = "Headlight_node03";
   direction = "0.0 1.0 0.0";
   texture = "special/headlight4";
};

datablock RunningLightData(TankLight4)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.2";
   nodeName = "Headlight_node04";
   direction = "0.0 1.0 0.0";
   texture = "special/headlight4";
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(AssaultVehicle) : TankDamageProfile
{
   spawnOffset = "0 0 4";
   canControl = false;
   floatingGravMag = 4.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_tank.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_grav_tank.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 2.0;
   explosionRadius = 30.0;

   maxSteeringAngle = 0.5;  // 20 deg.

   maxDamage = 3.0;
   destroyedLevel = 3.0;

   HDAddMassLevel = 2.1;
   HDMassImage = TankHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 135;
   maxEnergy = 400;
   minJetEnergy = 15;
   jetEnergyDrain = 2.0;

   // Rigid Body
   mass = 1500;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 20;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 18;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 30;
   speedDamageScale = 0.020;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 18;
   collDamageMultiplier   = 0.045;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.15;

   mainThrustForce    = 80;
   reverseThrustForce = 35;
   strafeThrustForce  = 0;
   turboFactor        = 1.5;

   brakingForce = 20;
   brakingActivationSpeed = 4;

   stabLenMin = 3.25;
   stabLenMax = 4;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 30;
   rollForce  = 0;
   pitchForce = 3;

   dustEmitter = TankDustEmitter;
   triggerDustHeight = 3.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = AssaultVehicleThrustSound;
   engineSound      = AssaultVehicleEngineSound;
   floatSound       = AssaultVehicleSkid;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   wheelImpactSound = WheelImpactSound;

   forwardJetEmitter = TankJetEmitter;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 15.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 7;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 3.5 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'M4A1 Wolf';
   targetTypeTag = 'Light Tank';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   replaceTime = 45;
};

//**************************************************************
// WEAPONS
//**************************************************************

//-------------------------------------
// ASSAULT CHAINGUN (projectile)
//-------------------------------------

datablock TracerProjectileData(AssaultChaingunBullet)
{
   doDynamicClientHits = true;

   projectileShapeName = "";
   directDamage        = 0.4;
   directDamageType    = $DamageType::TankChaingunH;
   hasDamageRadius     = false;
   splash			   = ChaingunSplash;

   kickbackstrength    = 0.0;
   sound          	   = TankChaingunProjectile;

   dryVelocity       = 1250.0;
   wetVelocity       = 500.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
   crossSize       = 0.25;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = MG42Decal1;
   decalData[1] = MG42Decal2;
   decalData[2] = MG42Decal3;
   decalData[3] = MG42Decal4;
   decalData[4] = MG42Decal5;
   decalData[5] = MG42Decal6;

   activateDelayMS   = 100;

   explosion = ACCGExplosion;
};

//-------------------------------------
// ASSAULT CHAINGUN CHARACTERISTICS
//-------------------------------------

datablock TurretData(AssaultPlasmaTurret) : TurretDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "Turret_tank_base.dts";
   //turret_assaulttank_plasma.dts
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'light';
   targetTypeTag = 'Assault Tank turret';
   mass           = 1.0;  // Not really relevant

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   maxEnergy               = 1;
   maxDamage               = AssaultVehicle.maxDamage;
   destroyedLevel          = AssaultVehicle.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 200;
   capacitorRechargeRate   = 0.45;

   thetaMin = 0;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 2;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'light Tank';
   targetTypeTag = 'Turret';
};

datablock TurretImageData(AssaultPlasmaTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 1;

   projectile = AssaultChaingunBullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 1.5 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 0.01;
   minEnergy = 5.0;

   // Turret parameters
   activationMS      = 4000;
   deactivateDelayMS = 500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 360;
   degPerSecPhi      = 360;
   attackRadius      = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";
   stateSound[0]                       = AssaultTurretActivateSound;

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 1;
   stateTransitionOnTimeout[1]         = "Ready";
   stateTransitionOnNotLoaded[1]       = "Deactivate";

   stateName[2]                        = "Ready";
   stateTransitionOnNotLoaded[2]       = "Deactivate";
   stateTransitionOnTriggerDown[2]     = "Fire";
   stateTransitionOnNoAmmo[2]          = "NoAmmo";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateSequenceRandomFlash[3]         = true;
   stateFire[3]                        = true;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = AssaultChaingunFireSound;
   stateScript[3]                      = "onFire";
   stateTimeoutValue[3]                = 0.14;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.2;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateSequence[5]                    = "Activate";
   stateDirection[5]                   = false;
   stateTimeoutValue[5]                = 30;
   stateTransitionOnTimeout[5]         = "ActivateReady";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultChaingunDryFireSound;
   stateTimeoutValue[7]                = 0.5;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "DryFire";

};

//-------------------------------------
// ASSAULT MORTAR (projectile)
//-------------------------------------

datablock ItemData(AssaultMortarAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "repair_kit.dts";
   mass = 1;
   elasticity = 0.5;
   friction = 0.6;
   pickupRadius = 1;

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(TankRocket)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.75;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 500;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.6;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 20000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 40.0;
   maxVelocity         = 300.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 60.0;
   acceleration        = 100.0;
   
   proximityRadius     = 7;

   terrainAvoidanceSpeed = 40;
   terrainScanAhead      = 50;
   terrainHeightFail     = 5;
   terrainAvoidanceRadius = 10;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};

//-------------------------------------
// ASSAULT MORTAR CHARACTERISTICS
//-------------------------------------

datablock TurretImageData(AssaultMortarTurretBarrel)
{
   shapeFile = "stackable2m.dts";
   rotation = "-1 0 0 90";
   offset = "0 0.7 0";
   mountPoint = 0;

   projectile = TankRocket;
   projectileType = SeekerProjectile;

   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 50.00;
   minEnergy = 50.00;
   useCapacitor = true;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   // Turret parameters
   activationMS                        = 4000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 1.0;
   stateTransitionOnTimeout[1]         = "Ready";
   stateTransitionOnNotLoaded[1]       = "Deactivate";

   stateName[2]                        = "Ready";
   stateTransitionOnNotLoaded[2]       = "Deactivate";
   stateTransitionOnNoAmmo[2]          = "NoAmmo";
   stateTransitionOnTriggerDown[2]     = "Fire";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateTransitionOnTimeout[3]         = "NextFire";
   stateTimeoutValue[3]                = 0.5;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = MissileFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "NextFire";
   stateTransitionOnNotLoaded[4]       = "Deactivate";
   stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateTransitionOnTriggerDown[4]     = "Fire";

   stateName[5]                        = "Fire2";
   stateSequence[5]                    = "Fire";
   stateTransitionOnTimeout[5]         = "NextFire2";
   stateTimeoutValue[5]                = 0.5;
   stateFire[5]                        = true;
   stateRecoil[5]                      = LightRecoil;
   stateAllowImageChange[5]            = false;
   stateSound[5]                       = MissileFireSound;
   stateScript[5]                      = "onFire";

   stateName[6]                        = "NextFire2";
   stateTransitionOnNotLoaded[6]       = "Deactivate";
   stateTransitionOnNoAmmo[6]          = "NoAmmo";
   stateTransitionOnTriggerDown[6]     = "Fire";

   stateName[7]                        = "Fire3";
   stateSequence[7]                    = "Fire";
   stateTransitionOnTimeout[7]         = "NextFire3";
   stateTimeoutValue[7]                = 0.5;
   stateFire[7]                        = true;
   stateRecoil[7]                      = LightRecoil;
   stateAllowImageChange[7]            = false;
   stateSound[7]                       = MissileFireSound;
   stateScript[7]                      = "onFire";

   stateName[8]                        = "NextFire3";
   stateTransitionOnNotLoaded[8]       = "Deactivate";
   stateTransitionOnNoAmmo[8]          = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "Fire";

   stateName[9]                        = "Fire4";
   stateSequence[9]                    = "Fire";
   stateTransitionOnTimeout[9]         = "Reload";
   stateTimeoutValue[9]                = 0.5;
   stateFire[9]                        = true;
   stateRecoil[9]                      = LightRecoil;
   stateAllowImageChange[9]            = false;
   stateSound[9]                       = MissileFireSound;
   stateScript[9]                      = "onFire";

   stateName[10]                        = "Reload";
   stateSequence[10]                    = "Reload";
   stateTimeoutValue[10]                = 8;
   stateAllowImageChange[10]            = false;
   stateTransitionOnTimeout[10]         = "ReloadSound";
   stateWaitForTimeout[10]              = true;

   stateName[11]                        = "ReloadSound";
   stateTimeoutValue[11]                = 2;
   stateAllowImageChange[11]            = false;
   stateTransitionOnTimeout[11]         = "Ready";
   stateSound[11]                       = MobileBaseStationDeploySound;
   stateWaitForTimeout[11]              = true;

   stateName[12]                        = "Deactivate";
   stateDirection[12]                   = false;
   stateSequence[12]                    = "Activate";
   stateTimeoutValue[12]                = 1.0;
   stateTransitionOnLoaded[12]          = "ActivateReady";
   stateTransitionOnTimeout[12]         = "Dead";

   stateName[13]                        = "Dead";
   stateTransitionOnLoaded[13]          = "ActivateReady";
   stateTransitionOnTriggerDown[13]     = "DryFire";

   stateName[14]                        = "DryFire";
   stateSound[14]                       = AssaultMortarDryFireSound;
   stateTimeoutValue[14]                = 1.0;
   stateTransitionOnTimeout[14]         = "NoAmmo";

   stateName[15]                        = "NoAmmo";
   stateSequence[15]                    = "NoAmmo";
   stateTransitionOnAmmo[15]            = "Reload";
   stateTransitionOnTriggerDown[15]     = "DryFire";
};

datablock TurretImageData(AssaultTurretParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";

   projectile = AssaultChaingunBullet;
   projectileType = TracerProjectile;

   useCapacitor = true;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   attackRadius      = 500;
};

function AssaultMortarTurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   MissileSet.add(%p);

   if (%obj.getControllingClient())
      %target = %obj.getLockedTarget();
   else
      %target = %obj.getTargetObject();

   %homein = missileCheckAirTarget(%target);
   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else 
      %p.setNoTarget(); 
}

function AssaultVehicle::onEnterLiquid(%data, %obj, %coverage, %type)
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
