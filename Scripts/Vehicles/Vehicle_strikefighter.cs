//********************************************************
//				Strike Fighter
//********************************************************
//Contains:
//-1 forward heavy Chain Gun
//-2 Missiles 
//-3 Napalm bombs
//********************************************************

//----------------------------------------
//effects
//----------------------------------------
datablock ParticleData(NapalmInitExpFlameParticle)
{
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.1;
   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 7;
   sizes[1]      = 8;
};

datablock ParticleEmitterData(NapalmInitExpFlameEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionOffset = 2.0;
   ejectionVelocity = 30.0;
   velocityVariance = 10.0;
   thetaMin         = 0.0;
   thetaMax         = 90.0;
   lifetimeMS       = 250;

   particles = "NapalmInitExpFlameParticle";
};

datablock ParticleData(NapalmExpGroundBurnParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = -0.4;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 6;
   sizes[1]      = 6.75;
};

datablock ParticleEmitterData(NapalmExpGroundBurnEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionOffset = 0.0;
   ejectionVelocity = 10.0;
   velocityVariance = 10.0;
   thetaMin         = 87.0;
   thetaMax         = 88.0;
   lifetimeMS       = 10000;

   particles = "NapalmExpGroundBurnParticle";
};

datablock ParticleData(NapalmExpGroundBurnSmokeParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = -0.4;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "particleTest";
   colors[0]     = "0.3 0.3 0.3 0.6";
   colors[1]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 3;
   sizes[1]      = 8;
};

datablock ParticleEmitterData(NapalmExpGroundBurnSmokeEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionOffset = 7.0;
   ejectionVelocity = 10.0;
   velocityVariance = 10.0;
   thetaMin         = 0.0;
   thetaMax         = 60.0;
   lifetimeMS       = 10000;

   particles = "NapalmExpGroundBurnSmokeParticle";
};

datablock ExplosionData(NapalmExplosion)
{
//   soundProfile   = BombExplosionSound;
   soundProfile   = MortarExplosionSound;
   emitter[0] = NapalmInitExpFlameEmitter;
   emitter[1] = NapalmExpGroundBurnEmitter;
   emitter[2] = NapalmExpGroundBurnSmokeEmitter;

   explosionShape = "effect_plasma_explosion.dts";
   faceViewer = true;
   lifetimeMS = 10000;
   playSpeed = 0.7;

   sizes[0] = "7.0 7.0 7.0";
   sizes[1] = "7.0 7.0 7.0";
   times[0] = 0.0;
   times[1] = 1.0;
};


datablock FlyingVehicleData(StrikeFlyer) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_air_scout.dts";
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

   maxDamage = 3.5;
   destroyedLevel = 3.5;

   HDAddMassLevel = 2.625;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 500;      // Afterburner and any energy weapon pool
   rechargeRate = 4;

   minDrag = 25;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 38;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 1;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.8;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 7.0;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 4750;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 625;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2.5;        // Height off the ground at rest
   createHoverHeight = 1;  // Height off the ground when created
   maxForwardSpeed = 150;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 12;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 0.0;

   // Rigid body
   mass = 180;        // Mass of the vehicle
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
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.75;
   numDmgEmitterAreas = 1;

   //
   max[chaingunAmmo] = 1500;
   max[MissileLauncherAmmo] = 2;
   max[MortarAmmo] = 2;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'F41 Awring Strike';
   targetTypeTag = 'Fighter';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   numWeapons = 3;

   replaceTime = 110;

   max[plasmaammo] = 50;
   flaretime = 100;
   flarelife = 850;
   flarechance = 0.35;
};

//----------------------------------------------
//Projectiles
//----------------------------------------------

datablock BombProjectileData(NapalmBomb)
{
   projectileShapeName  = "bomb.dts";
   emitterDelay         = -1;
   directDamage         = 0.0;
   hasDamageRadius      = true;
   indirectDamage       = 1.0;
   damageRadius         = 30;
   radiusDamageType     = $DamageType::Plasma;
   kickBackStrength     = 2000;

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

datablock TracerProjectileData(napalmSubExplosion)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::Plasma;
   explosion           = NapalmExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 20;
   radiusDamageType    = $DamageType::Plasma;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 30.0;
   wetVelocity       = 30.0;
   velInheritFactor  = 0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 1.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.20;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 1.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock SeekerProjectileData(sidewinder_MarkIII)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 750;

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

   lifetimeMS          = 20000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 12.0;
   maxVelocity         = 215.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 60.0;
   acceleration        = 100.0;

   proximityRadius     = 5;

   terrainAvoidanceSpeed         = 100;
   terrainScanAhead              = 25;
   terrainHeightFail             = 12;
   terrainAvoidanceRadius        = 30;  
   
   flareDistance = 100;
   flareAngle    = 25;
   minSeekHeat   = 0.5;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 100;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

//--------------------------------------------------
//weaponImages
//--------------------------------------------------

datablock ShapeBaseImageData(StrikeChaingunImage)
{
   className = WeaponImage;
   shapeFile = "turret_missile_large.dts"; //was turret_tank_barrelchain.dts
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = Heli_CG_Bullet;
   projectileType = TracerProjectile;
   mountPoint = 10;
   offset = "0 1.5 -0.2"; // L/R - F/B - T/B was "0 3.25 0.75"
   rotation = "0 1 0 180";

   projectileSpread = 1.0 / 1000.0;

   usesEnergy = false;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.1;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateFire[3] = true;
   stateScript[3] = "onFire";
   stateSound[3] = ShrikeBlasterFire;
   stateTimeoutValue[3] = 0.01; 
   stateTransitionOnTimeout[3] = "Reload";
   stateAllowImageChange[3] = false;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.01;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(StrikeMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = sidewinder_MarkIII;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
   fireTimeout = 125;

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
   stateTimeoutValue[4] = 0.1;
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

datablock ShapeBaseImageData(StrikeBombImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Mortar;
   ammo = MortarAmmo;
   projectile = NapalmBomb;
   projectileType = BombProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
   fireTimeout = 125;

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
   stateSound[3] = BomberBombFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = BomberBombDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

//--------------------------------------
// STRIKE FIGHTER TURRET CHARACTERISTICS
//--------------------------------------

datablock TurretData(StrikeTurret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_belly_base.dts";
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = StrikeFlyer.maxDamage;
   destroyedLevel          = StrikeFlyer.destroyedLevel;

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

   targetNameTag           = 'Strike Fighter';
   targetTypeTag           = 'Turret';

   max[ChaingunAmmo] = 4;
   max[MortarAmmo] = 1;
};

datablock TurretImageData(StrikeTATMissileImage)
{
   className = WeaponImage;
   item = MissileLauncher;
   ammo = ChaingunAmmo;
   projectile = HammerATMissile;
   projectileType = SeekerProjectile;


   shapeFile                        = "turret_missile_large.dts";
   mountPoint                       = 0;
   offset = "-0.45 0 0.0";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

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
   stateTransitionOnTimeout[3]         = "Reload";
   stateTimeoutValue[3]                = 0.1;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = BomberTurretFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.1;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   //stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateDirection[5]                   = false;
   stateSequence[5]                    = "Activate";
   stateTimeoutValue[5]                = 1.0;
   stateTransitionOnLoaded[5]          = "ActivateReady";
   stateTransitionOnTimeout[5]         = "Dead";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultMortarDryFireSound;
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateTransitionOnTriggerDown[8]     = "DryFire";
}; 

datablock TurretImageData(StrikeTBombImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Mortar;
   ammo = MortarAmmo;
   projectile = shrikeBomb;
   projectileType = BombProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
   fireTimeout = 125;

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
   stateSound[3] = BomberBombFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = BomberBombDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock TurretImageData(StrikeTL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   mountPoint = 1;
   offset = "0 0 0";

   projectile = GunshipTlProj;
   projectileType = TargetProjectile;
   deleteLastProjectile = true;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = true;
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
   stateScript[2]				= "onFire";
   stateTimeoutValue[2]			= 0.1;
   stateTransitionOnTimeout[2]	= "Deconstruct";

   stateName[3]				= "Deconstruct";
   stateScript[3]				= "onDecon";
   stateTimeoutValue[3]			= 0.1;
   stateTransitionOnTimeout[3]	= "Ready";
};

function StrikeTL::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.lastprojectile = %p;
}

function StrikeTL::onDecon(%data, %obj, %slot)
{
   %pos = %obj.lastProjectile.getTargetPoint();
   
   if(%obj.beacon)
      %obj.beacon.delete();
   %obj.beacon = new BeaconObject() {
      dataBlock = "TargeterBeacon";
      beaconType = "vehicle";
      position = %pos;
   };

   %obj.beacon.playThread($AmbientThread, "ambient");
   %obj.beacon.team = %obj.team;
   %obj.beacon.sourceObject = %obj;

   // give it a team target
   %obj.beacon.setTarget(%obj.team);                  
   MissionCleanup.add(%obj.beacon);

   %obj.posLaze = 0;
   Parent::deconstruct(%data, %obj, %slot);
}

function StrikeTATMissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.beacon))
	%p.setObjectTarget(%obj.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
}

function StrikeTBombImage::onFire(%data,%obj,%slot){ 
   %obj.decInventory(%data.ammo, 1);
   %data = "LGB";
   %pn = %data.create(0);
   %vec = vectorScale(%obj.vehicleMounted.getUpVector(),-4);
   %pos = vectorAdd(%obj.getPosition(),%vec);
   %rot = getWords(%obj.vehicleMounted.getTransform(),3,6);
   %pn.setTransform(%pos SPC %rot); 
   %pn.LGBsourceObject     = %obj; 
   %pn.LGBsourceSlot       = %slot;
   %pn.applyImpulse(%pn.getPosition(),vectorScale(%obj.vehicleMounted.getVelocity(),%data.mass));
   MissionCleanup.add(%pn);

   if(isObject(%obj.beacon))
	LGBhomein(%pn,%obj.beacon);
}

function StrikeTurret::onTrigger(%data, %obj, %trigger, %state)
{
   //error("onTrigger: trigger = " @ %trigger @ ", state = " @ %state);
   //error("obj = " @ %obj @ ", class " @ %obj.getClassName());
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
      case 4:
		if(%state)
                   %obj.setImageTrigger(4, true);
		else
		   %obj.setImageTrigger(4, false);

   }
}

function strikeTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %client = %obj.getControllingClient();
   %client.player.setInventory(ChaingunAmmo, 0);
   %client.player.setInventory(MortarAmmo, 0);
   %client.player.isBomber = false;
   %client.player.mountVehicle = false;
   if(%client.player.getState() !$= "Dead")
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

//------------------------------------------------------
//Vehicle Functions
//------------------------------------------------------

function StrikeFlyer::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(ScoutChaingunParam, 0);
   %obj.mountImage(StrikeMissileImage, 2);
   %obj.mountImage(StrikeBombImage, 3);
   %obj.mountImage(StrikeChaingunImage, 4);
   %obj.selectedWeapon = 1;
   %obj.nextWeaponFire = 2;
   %obj.setInventory(chaingunammo, 1500);
   %obj.setInventory(MissileLauncherAmmo, 2);
   %obj.setInventory(MortarAmmo, 2);
   %obj.setInventory(plasmaAmmo, 50);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(StrikeTurret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(AIAimingTurretBarrel, 0);
   %turret.mountImage(StrikeTATMissileImage, 2);
   %turret.mountImage(StrikeTbombImage, 3);
   %turret.mountImage(StrikeTL, 4);
   %turret.setInventory(MortarAmmo, 1);
   %turret.setInventory(ChaingunAmmo, 4);
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function strikeFlyer::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

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
   if(isObject(%turret.beacon))
	%turret.beacon.delete();
}

function StrikeFlyer::playerMounted(%data, %obj, %player, %node){
   if (%node == 0)
   {
      $numVWeapons = 3;
      %ammoAmt = %player.inv[MissileLauncherAmmo];
      if(%ammoAmt)
         %obj.setInventory(MissileLauncherAmmo, 2);
      %ammoAmt = %player.inv[MortarAmmo];
      if(%ammoAmt)
         %obj.setInventory(MortarAmmo, 3);
      %ammoAmt = %player.inv[chaingunAmmo];
      if(%ammoAmt)
         %obj.incInventory(chaingunAmmo, %ammoAmt);
      if(%ammoAmt)
         %obj.incInventory(plasmaAmmo, 50);
      bottomPrint(%player.client, "Strike Fighter: wep1 CG, wep2 missile, wep3 Napalm bombs", 5, 2 );
      commandToClient(%player.client, 'setHudMode', 'Pilot', "Shrike2", %node);
      %obj.selectedWeapon = 1;
      commandToClient(%player.client, 'SetWeaponryVehicleKeys', true);
   }
   else if (%node == 1)
   {
     $numVWeapons = 2;
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

	   commandToClient(%player.client, 'setHudMode', 'Pilot', "bomber", %node);
      %player.isBomber = true;
      %ammoAmt = %player.inv[MortarAmmo];
      if(%ammoAmt)
        %obj.turretobject.setInventory(MortarAmmo, 1);

      %ammoAmt = %player.inv[chaingunAmmo];
      if(%ammoAmt)
        %obj.turretobject.setInventory(chaingunAmmo, 4);
	setTargetSensorGroup(%turret.getTarget(), %player.team);
      bottomPrint(%player.client, "Strike Fighter: wep1 LGM Wep2 LG bunker buster bomb", 5, 2 );
   }
   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function StrikeFlyer::playerDismounted(%data, %obj, %player)
{
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %obj.setImageTrigger(5, false);
   %obj.setImageTrigger(6, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function strikeTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function strikeTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function StrikeFlyer::onTrigger(%data, %obj, %trigger, %state)
{
   // data = ScoutFlyer datablock
   // obj = ScoutFlyer object number
   // trigger = 0 for "fire", 1 for "jump", 3 for "thrust"
   // state = 1 for firing, 0 for not firing
   if(%trigger == 0)
   {
      switch (%state) {
         case 0:
            %obj.fireWeapon = false;
		%obj.setImageTrigger(2, false);
		%obj.setImageTrigger(3, false);
		%obj.setImageTrigger(4, false);
         case 1:
            %obj.fireWeapon = true;
		if(%obj.selectedWeapon == 1)
            {
		   %obj.setImageTrigger(2, false);
		   %obj.setImageTrigger(3, false);
		   %obj.setImageTrigger(4, true);
		}
            else if(%obj.selectedWeapon == 2)
            {
		   %obj.setImageTrigger(2, true);
		   %obj.setImageTrigger(3, false);
		   %obj.setImageTrigger(4, false);
            }
		else
		{
		   %obj.setImageTrigger(2, false);
		   %obj.setImageTrigger(3, true);
		   %obj.setImageTrigger(4, false);
		}
      }
   }
   else if (%trigger ==4){
      switch (%state) 
	{
         case 0:
            %obj.flaring = 0;
         case 1:
		%obj.flaring = 1;
		schedule(%data.flaretime, 0, "fighterdropflares",%obj,%data.flaretime,%data.flarelife,%data.flarechance);
       }
   }
}

function strikeflyer::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}

//------------------------------------------------------
//Weapon Functions
//------------------------------------------------------

function StrikeMissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
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

function StrikeBombImage::onFire(%data,%obj,%slot){
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
   %p.spdvec = %obj.getVelocity();
}

function NapalmBomb::onExplode(%data, %proj, %pos, %mod)
{
   %vec = %proj.spdvec;
   %vec = getword(%vec, 0) SPC getword(%vec, 1)@" 0";
   %maxupward = vectorLen(%vec) / 10;
   %vec = vectorScale(vectorNormalize(%vec),(%maxupward * 2));
   %Tpos = vectoradd(%pos,%vec);
   %result = containerRayCast(vectoradd(%tpos,"0 0" SPC %maxupward), vectoradd(%tpos,"0 0 -50"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
   if(!%result)
	%Tpos = NapalmFindNewDir(%pos,%vec);
   else 
	%Tpos = posFromRaycast(%result);

   %Tpos = vectorAdd(%Tpos,"0 0 5");

   %result = containerRayCast(vectorAdd(%pos,"0 0 10"), %Tpos, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
   if(%result){
	%Tpos = NapalmFindNewDir(%pos,%vec);
	%Tpos = vectorAdd(%pos,"0 0 5");
   }

   for(%i = 0; %i < 3; %i++){
	%rndvec = (getRandom(1, 15) - 7.5)@" "@(getRandom(1, 15) - 7.5)@" "@((getRandom() * 5) + 5);
	%newpos = vectoradd(%Tpos,%rndvec);
	%p = new TracerProjectile() 
	{ 
	   dataBlock        = napalmSubExplosion; 
	   initialDirection = "0 0 -1"; 
	   initialPosition  = %newpos; 
	   sourceObject     = %proj.sourceobject;
   	   sourceSlot       = 5; 
	};
	%p.sourceobject = %proj.sourceobject;
	%p.vector = %vec;
	%p.count = 1;
   }
   if (%data.hasDamageRadius)
      RadiusExplosion(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType);
}

function napalmSubExplosion::onExplode(%data, %proj, %pos, %mod)
{
   if(%proj.count < 5){
      %vec = %proj.vector;
      %Tpos = vectoradd(%pos,%vec);
      %maxupward = vectorLen(%vec) / 2;
      %result = containerRayCast(vectoradd(%tpos,"0 0" SPC %maxupward), vectoradd(%tpos,"0 0 -50"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
      if(!%result)
	   %Tpos = NapalmFindNewDir(%pos,%vec);
      else
	   %Tpos = posFromRaycast(%result);

      %Tpos = vectorAdd(%Tpos,"0 0 5");

      %result = containerRayCast(vectorAdd(%pos,"0 0 10"), %Tpos, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
      if(%result){
	   %Tpos = NapalmFindNewDir(%pos,%vec);
	   %Tpos = vectorAdd(%pos,"0 0 5");
      }

	%rndvec = (getRandom(1, 10) - 5)@" "@(getRandom(1, 10) - 5)@" "@((getRandom() * 5) + 5);
	%newpos = vectoradd(%Tpos,%rndvec);
	%p = new TracerProjectile() 
	{ 
	   dataBlock        = napalmSubExplosion; 
	   initialDirection = "0 0 -1"; 
	   initialPosition  = %newpos; 
	   sourceObject     = %proj.sourceobject;
   	   sourceSlot       = 5; 
	};
	%p.sourceobject = %proj.sourceobject;
	%p.vector = %vec;
	%p.count = %proj.count + 1;
   }

   if (%data.hasDamageRadius)
      RadiusExplosion(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType);
}

function NapalmFindNewDir(%pos, %vec){
   echo("new dir called");
   %maxupward = vectorLen(%vec) / 2;
   %count = 0;
   while((!%result || %chksearch) && %count < 10){
	if(%count == 3 || %count == 8)
	   %vec = VectorScale(%vec,0.5);
	else if(%count == 5)
	   %vec = VectorScale(%vec,-2);
	%rndvec = getRandom(-10,10) SPC getRandom(-10,10) SPC "0";
	%vec = vectoradd(%vec,%rndvec);
      %Tpos = vectoradd(%pos,%vec);
      %result = containerRayCast(vectoradd(%tpos,"0 0" SPC %maxupward), vectoradd(%tpos,"0 0 -50"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
	%Tpos = vectorAdd(posFromRaycast(%result),"0 0 10");
      %chkresult = containerRayCast(vectorAdd(%pos,"0 0 10"), %Tpos, $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %proj);
	%count++;
   }
   %Tpos = posFromRaycast(%result);
   return %Tpos;
}

function Strikeflyer::onEnterLiquid(%data, %obj, %coverage, %type)
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

//----------------------------------------------------------
//LGB
//----------------------------------------------------------

$LGBhomeForce = 1000;
$LGBDetDepth = 2.5;

datablock TracerProjectileData(LGBDet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::BomberBombs;
   explosion           = "artillerybarrelexplosion";
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 1.2;
   damageRadius        = 5.0;
   radiusDamageType    = $DamageType::BomberBombs;

   kickBackStrength  = 500;
   sound             = ChaingunProjectile;

   dryVelocity               = 15.0;
   wetVelocity               = 15.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 200;
   lifetimeMS                = 250;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 1.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.35;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock TracerProjectileData(LGBUnderDet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::BomberBombs;
   explosion           = "VehicleBombExplosion";
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 5.0;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::BomberBombs;

   kickBackStrength  = 500;
   sound             = ChaingunProjectile;

   dryVelocity               = 1.0;
   wetVelocity               = 1.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 32;
   lifetimeMS                = 33;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 1.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.35;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock WheeledVehicleData(LGB) : MPBDamageProfile
{
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;
   canControl = true;
   catagory = "Vehicles";
   shapeFile = "vehicle_grav_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 20.0;

   numMountPoints = 0;

   cantAbandon = 1;
   cantTeamSwitch = 1;

   cameraMaxDist = 20;
   cameraOffset = 6;
   cameraLag = 1.5;
   explosion = VehicleExplosion;
   explosionDamage = 0.25;
   explosionRadius = 3.0;

   maxSteeringAngle = 0.3;  // 20 deg.

   // Used to test if the station can deploy
   stationPoints[1] = "-2.3 -7.38703 -0.65";
   stationPoints[2] = "-2.3 -11.8 -0.65";
   stationPoints[3] = "0 -7.38703 -0.65";
   stationPoints[4] = "0 -11.8 -0.65";
   stationPoints[5] = "2.3 -7.38703 -0.65";
   stationPoints[6] = "2.3 -11.8 -0.65";

   // Rigid Body
   mass = 400;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 10;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 25;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 1;
   speedDamageScale = 0.05;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 5;
   collDamageMultiplier   = 0.03;

   // Engine
   engineTorque = 7.0 * 745;
   breakTorque = 7.0 * 745;
   maxWheelSpeed = 20;

   // Springs
   springForce = 8000;
   springDamping = 1300;
   antiSwayForce = 6000;
   staticLoadScale = 2;

   // Tires
   tireRadius = 1.6;
   tireFriction = 10.0;
   tireRestitution = 0.5;
   tireLateralForce = 3000;
   tireLateralDamping = 400;
   tireLateralRelaxation = 1;
   tireLongitudinalForce = 12000;
   tireLongitudinalDamping = 600;
   tireLongitudinalRelaxation = 1;
   tireEmitter = TireEmitter;

   //
   maxDamage = 0.5;
   destroyedLevel = 0.5;

   HDAddMassLevel = 0.4;
   HDMassImage = APCHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 125;
   maxEnergy = 600;
   jetForce = 2800;
   minJetEnergy = 60;
   jetEnergyDrain = 2.75;
   rechargeRate = 1.0;

   jetSound = MPBThrustSound;
   engineSound = MPBEngineSound;
   squeelSound = AssaultVehicleSkid;
   softImpactSound = GravSoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 8.0;
   hardSplashSoundVelocity = 12.0;
   exitSplashSoundVelocity = 8.0;

   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterHardSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 3;

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "3.0 0.5 0.0 ";
   damageEmitterOffset[1] = "-3.0 0.5 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 2;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundMPBIcon;
   cmdMiniIconName = "commander/MiniIcons/com_mpb_grey";
   targetNameTag = 'Laser Guided';
   targetTypeTag = 'Bomb';
   sensorData = VehiclePulseSensor;

   checkRadius = 7.5225;

   observeParameters = "1 12 12";

   runningLight[0] = MPBLight1;
   runningLight[1] = MPBLight2;

   shieldEffectScale = "0.85 1.2 0.7";
};

datablock StaticShapeData(LGBShape) : StaticShapeDamageProfile {
   shapeFile      = "bomb.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

function LGB::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %obj.startFade(0,10,1);
   %body = new StaticShape()
   {
       scale = "2 2 2";
       dataBlock = "LGBShape";
   };
   MissionCleanup.add(%body);
   %obj.mountObject(%body, 1);
   %body.vehicleMounted = %obj;
}

function LGBhomeIn(%obj,%trg){
   if(!isObject(%obj))
	return;
   if(!isObject(%trg))
	return;

   %pos = %obj.getPosition();
   %vel = %obj.getVelocity();
   %tpos = %trg.getPosition();
   %lvel = getWords(%vel,0,1) SPC "0";

   %DDis = getWord(%pos,2) - getWord(%tpos,2);
   if(%DDis <= 0)
	return;
   %Dtime = %DDis / (getWord(%vel,2) * -1);
   %predTrg = vectorScale(%lvel,%Dtime);
   %predTrg = getWords(vectorAdd(%pos,%predtrg),0,1) SPC getWord(%tpos,2);

   %vec = vectorNormalize(vectorSub(%tpos,%predTrg));
   %obj.applyImpulse(%pos,vectorScale(%vec,$LGBhomeForce));
   %obj.lastpos = %pos;
   schedule(250, 0, "LGBhomeIn", %obj, %trg);
}

function LGB::deleteAllMounted(%data, %obj){
   %body = %obj.getMountNodeObject(1);
   if (isObject(%body))
	%body.schedule(2000, delete);

   %pn = new (TracerProjectile)() { 
	dataBlock        = LGBDet; 
	initialDirection = vectorNormalize(vectorSub(%obj.getposition(),%obj.lastpos)); 
	initialPosition  = %obj.getWorldBoxCenter(); 
	sourceObject     = %obj.LGBsourceObject; 
	sourceSlot       = %obj.LGBsourceSlot; 
   }; 
   %pn.detvec = vectorNormalize(vectorSub(%obj.getposition(),%obj.lastpos));
   MissionCleanup.add(%pn); 
}

function LGBDet::onExplode(%data, %proj, %pos, %mod)
{
   %newpos = vectoradd(%pos,vectorScale(%proj.detvec,$LGBDetDepth));
   %p = new TracerProjectile() 
   { 
	dataBlock        = LGBUnderDet; 
	initialDirection = %proj.detvec; 
	initialPosition  = %newpos; 
	sourceObject     = %proj.sourceobject;
   	sourceSlot       = %proj.sourceSlot; 
   };
   %p.vector = %vec;
   %p.count = 1;
   if (%data.hasDamageRadius)
      RadiusExplosion(%proj, %pos, %data.damageRadius, %data.indirectDamage, %data.kickBackStrength, %proj.sourceObject, %data.radiusDamageType);
}