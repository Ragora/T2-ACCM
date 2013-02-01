//**************************************************************
// THUNDERSWORD BOMBER
//**************************************************************
//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(BomberFlyerEngineEffect)
{
   effectname = "vehicles/bomber_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberFlyerThrustEffect)
{
   effectname = "vehicles/bomber_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberTurretFireEffect)
{
   effectname = "weapons/missile_fire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberTurretActivateEffect)
{
   effectname = "vehicles/bomber_turret_activate";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberTurretReloadEffect)
{
   effectname = "vehicles/bomber_turret_reload";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberTurretDryFireEffect)
{
   effectname = "weapons/missile_launcher_dryfire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberBombReloadEffect)
{
   effectname = "vehicles/bomber_bomb_reload";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberBombDryFireEffect)
{
   effectname = "vehicles/bomber_bomb_dryfire";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(BomberBombFireEffect)
{
   effectname = "weapons/generic_throw";
   minDistance = 10.0;
   maxDistance = 20.0;
};

datablock AudioProfile(BomberFlyerEngineSound)
{
   filename    = "fx/vehicles/bomber_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = BomberFlyerEngineEffect;
};

datablock AudioProfile(BomberFlyerThrustSound)
{
   filename    = "fx/vehicles/bomber_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = BomberFlyerThrustEffect;
};

datablock AudioProfile(FusionExpSound)
// Sound played when mortar impacts on target
{
   filename    = "fx/powered/turret_mortar_explode.wav";
   description = "AudioBIGExplosion3d";
   preload = true;
};

datablock AudioProfile(BomberTurretFireSound)
{
   filename    = "fx/weapons/missile_fire.WAV";
   description = AudioClose3d;
   preload = true;
   effect = BomberTurretFireEffect;
};

datablock AudioProfile(BomberTurretActivateSound)
{
   filename    = "fx/vehicles/bomber_turret_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberTurretActivateEffect;
};

datablock AudioProfile(BomberTurretReloadSound)
{
   filename    = "fx/weapons/weapon.missilereload.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberTurretReloadEffect;
};

datablock AudioProfile(BomberTurretIdleSound)
{
   filename    = "fx/misc/diagnostic_on.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(BomberTurretDryFireSound)
{
   filename    = "fx/weapons/missile_launcher_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberTurretDryFireEffect;
};

datablock AudioProfile(BomberBombReloadSound)
{
   filename    = "fx/vehicles/bomber_bomb_reload.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberBombReloadEffect;
};

datablock AudioProfile(BomberBombProjectileSound)
{
   filename    = "fx/vehicles/bomber_bomb_projectile.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = BomberBombFireEffect;
};

datablock AudioProfile(BomberBombDryFireSound)
{
   filename    = "fx/vehicles/bomber_bomb_dryfire.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberBombDryFireEffect;
};

datablock AudioProfile(BomberBombFireSound)
{
   filename    = "fx/vehicles/bomber_bomb_reload.wav";
   description = AudioClose3d;
   preload = true;
   effect = BomberBombFireEffect;
};

datablock AudioProfile(BomberBombIdleSound)
{
   filename    = "fx/misc/diagnostic_on.wav";
   description = ClosestLooping3d;
   preload = true;
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(BomberFlyer) : BomberDamageProfile
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
   maneuveringForce = 5000;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 800;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 2500;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 4;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 110;  // speed in which forward thrust force is no longer applied (meters/second)

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
   targetNameTag = 'B-34';
   targetTypeTag = 'Bomber';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 7.1895;
   observeParameters = "1 10 10";
   shieldEffectScale = "0.75 0.975 0.375";
   showPilotInfo = 1;

   replaceTime = 75;
};

//**************************************************************
// WEAPONS
//**************************************************************

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(sidewinder_MarkII)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.75;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 500;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 15000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 75.0;
   maxVelocity         = 210.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 64.0;
   acceleration        = 100.0;

   proximityRadius     = 3;

   terrainAvoidanceSpeed         = 180;
   terrainScanAhead              = 25;
   terrainHeightFail             = 12;
   terrainAvoidanceRadius        = 100;  
   
   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 100;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

//-------------------------------------
// BOMBER BELLY TURRET CHARACTERISTICS
//-------------------------------------

datablock TurretData(BomberTurret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_belly_base.dts";
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";
   targetNameTag = 'Thundersword';
   targetTypeTag = 'Bomberturret';

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = BomberFlyer.maxDamage;
   destroyedLevel          = BomberFlyer.destroyedLevel;

   thetaMin                = 90;
   thetaMax                = 180;

   // capacitor
   maxCapacitorEnergy      = 1000;
   capacitorRechargeRate   = 1.2;

   inheritEnergyFromMount  = true;
   firstPersonOnly         = true;
   useEyePoint             = true;
   numWeapons              = 3;

   targetNameTag           = 'Thundersword Belly';
   targetTypeTag           = 'Turret';

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 45; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;
};

datablock TurretImageData(BomberTurretBarrel)
{
   shapeFile                        = "stackable1s.dts";
   rotation					= "0 0 1 90";
   offset			    		= "0.4 -0.4 -0.4";
   mountPoint                       = 0;

   projectile                       = sidewinder_MarkII;
   projectileType                   = SeekerProjectile;

   usesEnergy                       = true;
   useCapacitor                     = true;
   useMountEnergy                   = true;
   fireEnergy                       = 60.0;
   minEnergy                        = 60.0;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 45; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   // Turret parameters
   activationMS                     = 1000;
   deactivateDelayMS                = 1500;
   thinkTimeMS                      = 200;
   degPerSecTheta                   = 360;
   degPerSecPhi                     = 360;

   attackRadius                     = 300;

   // State transitions
   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";
   stateSound[0]                    = BomberTurretActivateSound;

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 2.0;
   stateFire[2]                     = true;
   stateRecoil[2]                   = LightRecoil;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = BomberTurretFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 0.75;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "Reload1";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateSequence[4]                 = "NoAmmo";
   stateSequence[4] = "NoAmmo1";

   stateTransitionOnTriggerDown[4]  = "DryFire1";

   stateName[5]                     = "DryFire1";
   stateSound[5]                    = BomberTurretDryFireSound;
   stateTimeoutValue[5]             = 0.75;
   stateTransitionOnTimeout[5]      = "NoAmmo1";

   stateName[6]                     = "WaitFire2";
   stateTransitionOnTriggerDown[6]  = "Fire2";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateTransitionOnNoAmmo[6]       = "NoAmmo";
   stateTransitionOnNoAmmo[6] = "NoAmmo2";

   stateName[7]                     = "Fire2";
   stateTransitionOnTimeout[7]      = "Reload2";
   stateTimeoutValue[7]             = 0.75;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 0.75;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "Reload2";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateSequence[9]                 = "NoAmmo";
   stateSequence[9] = "NoAmmo2";

   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberTurretDryFireSound;
   stateTimeoutValue[10]             = 0.75;
   stateTransitionOnTimeout[10]      = "NoAmmo2";

};

datablock TurretImageData(BomberTurretBarrelPair)
{
   shapeFile                = "stackable1s.dts";
   rotation			    = "0 0 1 90";
   offset			    = "-0.4 -0.4 -0.4";
   mountPoint               = 1;

   projectile                       = sidewinder_MarkII;
   projectileType                   = SeekerProjectile;

   usesEnergy                       = true;
   useCapacitor                     = true;
   useMountEnergy                   = true;
   fireEnergy                       = 60.0;
   minEnergy                        = 60.0;

   // Turret parameters
   activationMS                     = 1000;
   deactivateDelayMS                = 1500;
   thinkTimeMS                      = 200;
   degPerSecTheta                   = 360;
   degPerSecPhi                     = 360;

   attackRadius                     = 300;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 0.13;
   stateFire[1]                     = true;
   stateRecoil[1]                   = LightRecoil;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberTurretFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.1;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
};

datablock TurretImageData(AIAimingTurretBarrel)
{
   shapeFile            = "turret_muzzlepoint.dts";
   mountPoint           = 3;

   projectile           = sidewinder_MarkII;

   // Turret parameters
   activationMS         = 1000;
   deactivateDelayMS    = 1500;
   thinkTimeMS          = 200;
   degPerSecTheta       = 500;
   degPerSecPhi         = 800;
   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 45; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   attackRadius         = 300;
};

datablock ShapeBaseImageData(BomberBellyTurretParam) 
{ 
   mountPoint 		= 2; 
   shapeFile 		= "turret_muzzlepoint.dts"; 

   Projectile 		= sidewinder_MarkII;
   ProjectileType 	= SeekerProjectile;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 45; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;
};

//-------------------------------------
// BOMBER BOMB PROJECTILE
//-------------------------------------

datablock BombProjectileData(BomberBomb)
{
   projectileShapeName  = "bomb.dts";
   emitterDelay         = -1;
   directDamage         = 0.0;
   hasDamageRadius      = true;
   indirectDamage       = 4.0;
   damageRadius         = 30;
   radiusDamageType     = $DamageType::BomberBombs;
   kickBackStrength     = 2500;

   explosion            = "VehicleBombExplosion";
   velInheritFactor     = 1.0;

   grenadeElasticity    = 0.25;
   grenadeFriction      = 0.4;
   armingDelayMS        = 2000;
   muzzleVelocity       = 0.1;
   drag                 = 0.3;

   minRotSpeed          = "60.0 0.0 0.0";
   maxRotSpeed          = "80.0 0.0 0.0";
   scale                = "1.0 1.0 1.0";

   sound                = BomberBombProjectileSound;
};

//-------------------------------------
// BOMBER BOMB CHARACTERISTICS
//-------------------------------------

datablock ItemData(BombAmmo)
{
   className         = Ammo;
   catagory          = "Ammo";
   shapeFile         = "repair_kit.dts";
   mass              = 1;
   elasticity        = 0.2;
   friction          = 0.6;
   pickupRadius      = 1;
   computeCRC        = true;
};

datablock StaticShapeData(DropBombs)
{
   catagory             = "Turrets";
   shapeFile            = "bombers_eye.dts";
   maxDamage            = 1.0;
   disabledLevel        = 0.6;
   destroyedLevel       = 0.8;
};

datablock TurretImageData(BomberBombImage)
{
   shapeFile                        = "turret_muzzlepoint.dts";
   offset                           = "2 -4 -0.5";
   mountPoint                       = 10;

   projectile                       = BomberBomb;
   projectileType                   = BombProjectile;
   usesEnergy                       = true;
   useMountEnergy                   = true;
   useCapacitor                     = true;

   fireEnergy                       = 110.0;
   minEnergy                        = 110.0;


   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 0.32;
   stateFire[2]                     = true;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = BomberBombFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 0.1;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "Reload1";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateSequence[4]                 = "NoAmmo";
   stateSequence[4] = "NoAmmo1";

   stateTransitionOnTriggerDown[4]  = "DryFire1";

   stateName[5]                     = "DryFire1";
   stateSound[5]                    = BomberBombDryFireSound;
   stateTimeoutValue[5]             = 0.5;
   stateTransitionOnTimeout[5]      = "NoAmmo1";

   stateName[6]                     = "WaitFire2";
   stateTransitionOnTriggerDown[6]  = "Fire2";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateTransitionOnNoAmmo[6]       = "NoAmmo";
   stateTransitionOnNoAmmo[6] = "NoAmmo2";

   stateName[7]                     = "Fire2";
   stateTransitionOnTimeout[7]      = "Reload2";
   stateTimeoutValue[7]             = 0.32;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 0.1;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "Reload2";
   // ---------------------------------------------
   // z0dd - ZOD, 5/8/02. Incorrect parameter value
   //stateSequence[9]                 = "NoAmmo";
   stateSequence[9] = "NoAmmo2";

   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberBombDryFireSound;
   stateTimeoutValue[10]             = 0.5;
   stateTransitionOnTimeout[10]      = "NoAmmo2";
};

datablock TurretImageData(BomberBombPairImage)
{
   shapeFile                        = "turret_muzzlepoint.dts";
   offset                           = "-2 -4 -0.5";
   mountPoint                       = 10;

   projectile                       = BomberBomb;
   projectileType                   = BombProjectile;
   usesEnergy                       = true;
   useMountEnergy                   = true;
   useCapacitor                     = true;
   fireEnergy                       = 110.0;
   minEnergy                        = 110.0;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 0.13;
   stateFire[1]                     = true;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberBombFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.1;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";

};

//**************************************************************
// WEAPONS SPECIAL EFFECTS
//**************************************************************
datablock TracerProjectileData(BomberCGBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::ACCG;
   explosion           = MissileExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.75;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::ACCG;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 2500.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.25;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = MG42Decal1;
   decalData[1] = MG42Decal2;
   decalData[2] = MG42Decal3;
   decalData[3] = MG42Decal4;
   decalData[4] = MG42Decal5;
   decalData[5] = MG42Decal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock TurretImageData(BomberCGImage)
{
   className = WeaponImage;
   shapeFile = "turret_belly_barrell.dts";
   offset = "0.1 0 0";
   item      = Chaingun;
   projectile = BomberCGBullet;
   projectileType = TracerProjectile;
   projectileSpread = 2.0 / 1000.0;
   emap = true;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

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
   stateSound[3] = SniperFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.4;
   stateAllowImageChange[4] = false;
   stateSound[4] = ChaingunDryFireSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = MissileReloadSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function BomberTurretBarrelPair::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 

   %target = %obj.getLockedTarget(); 
   %homein = missileCheckAirTarget(%target);
   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else 
      %p.setNoTarget(); 
}

function BomberTurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 

   %target = %obj.getLockedTarget(); 
   %homein = missileCheckAirTarget(%target);
   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else 
      %p.setNoTarget(); 
}

function Bomberflyer::onEnterLiquid(%data, %obj, %coverage, %type)
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
