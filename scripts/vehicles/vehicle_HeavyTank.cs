//**************************************************************
// JERICHO FORWARD BASE (Mobile Point Base)
//**************************************************************

datablock ParticleData(FlakDust)
{
   dragCoefficient      = 1.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.3 0.3 0.3 0.5";
   colors[1]     = "0.3 0.3 0.3 0.5";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 6.6;
   sizes[1]      = 10.8;
   sizes[2]      = 12.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(FlakDustEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 20.0;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 88;
   thetaMax         = 92;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "FlakDust";
};


datablock ParticleData(FlakExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.7 0.7 0.7 1.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 13.0;
   sizes[2]      = 4.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FExplosionSmokeEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 6.25;
   velocityVariance = 0.25;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 200;

   particles = "FlakExplosionSmoke";
};

datablock ParticleData(FlakSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 650;
   textureName          = "special/bigspark";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 3.0;
   sizes[2]      = 4.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FlakSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 15;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "FlakSparks";
};

datablock ParticleData(FlakFlashSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 250;
   lifetimeVarianceMS   = 650;
   textureName          = "special/bigspark";
   colors[0]     = "1.0 0.2 0.2 1.0";
   colors[1]     = "0.7 0.7 0.2 1.0";
   colors[2]     = "0.5 0.5 0.1 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 5.0;
   sizes[2]      = 6.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FlakFlashSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 25;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "FlakFlashSparks";
};

//----------------------------------------------------
//  Explosion
//----------------------------------------------------
datablock ExplosionData(FlakExplosion)
{
   soundProfile   = GrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "1.0 1.0 1.0";

   emitter[0] = FlakDustEmitter;
   emitter[1] = FExplosionSmokeEmitter;
   emitter[2] = FlakSparksEmitter;
   emitter[3] = FlakFlashSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(HeavyTank) : TankDamageProfile
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
   explosionRadius = 25.0;

   maxSteeringAngle = 0.35;  // 20 deg.

   maxDamage = 4.0;
   destroyedLevel = 4.0;

   HDAddMassLevel = 3.2;
   HDMassImage = TankHDMassImage;

   isShielded = false;
   rechargeRate = 1.5;
   energyPerDamagePoint = 0;
   maxEnergy = 1000;
   minJetEnergy = 60;
   jetEnergyDrain = 2.75;

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
   minImpactSpeed = 35;
   speedDamageScale = 0.017;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 20;
   collDamageMultiplier   = 0.030;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.15;

   mainThrustForce    = 70;
   reverseThrustForce = 30;
   strafeThrustForce  = 5;
   turboFactor        = 1.25;

   brakingForce = 30;
   brakingActivationSpeed = 4;

   stabLenMin = 3.25;
   stabLenMax = 4;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 25;
   rollForce  = 7;
   pitchForce = 3;

   dustEmitter = TankDustEmitter;
   triggerDustHeight = 3.5;
   dustHeight = 1.5;
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
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'M3A2 Faustes';
   targetTypeTag = 'Assault Tank';
   sensorData = PlayerSensor;

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   max[PlasmaAmmo] = 4;

   replaceTime = 60;
};

//**************************************************************
// WEAPONS
//**************************************************************

//-------------------------------------
// ASSAULT CHAINGUN CHARACTERISTICS
//-------------------------------------

datablock TurretData(TankTurret) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "Turret_tank_base.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Panzer';
   targetTypeTag = 'Tank turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1;
   maxDamage               = 1.5;
   destroyedLevel          = 1.5;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 5000;
   capacitorRechargeRate   = 1.5;

   thetaMin = 0;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 2;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'Panzer';
   targetTypeTag = 'tank Turret';

   explosion    = HandGrenadeExplosion;
   expDmgRadius = 5.0;
   expDamage    = 0.25;
   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   repairRate = 0.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(TankFlak_Bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.2;
   directDamageType    = $DamageType::TankChaingun;
   explosion           = FlakExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Flak;

   kickBackStrength  = 15;
   sound             = ChaingunProjectile;

   dryVelocity               = 600.0;
   wetVelocity               = 200.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 3000;
   lifetimeMS                = 1000;
   explodeOnDeath            = true;
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

datablock TracerProjectileData(TankFlak_Bullet_exp)
{
   doDynamicClientHits = true;

   directDamage        = 0.2;
   directDamageType    = $DamageType::TankChaingun;
   explosion           = FlakExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Flak;

   kickBackStrength  = 150;
   sound             = ChaingunProjectile;

   dryVelocity               = 0.0;
   wetVelocity               = 0.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 3000;
   lifetimeMS                = 10;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 0.0;
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

datablock TurretImageData(TankMGTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 1;

   projectile = TankFlak_Bullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 1.0 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 10.0;
   minEnergy = 10.0;

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
   stateTimeoutValue[3]                = 0.75;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.45;
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
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "DryFire";

};

datablock ParticleEmitterData( TankArtillerySmokeEmitter )
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 3;

   ejectionVelocity = 1.0;  // A little oomph at the back end
   velocityVariance = 0.2;

   thetaMin         = 0.0;
   thetaMax         = 40.0;

   particles = "GDebrisSmokeParticle";
};


datablock GrenadeProjectileData(TankArtillery)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 2.0;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 3000;

   explosion           = "artillerybarrelexplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.3;
   armingDelayMS     = -1;
   gravityMod        = 1.0;
   muzzleVelocity    = 175.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

datablock GrenadeProjectileData(TankATShell)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 4.0;
   damageRadius        = 4.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 3000;

   explosion           = "MissileExplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = MissileFireEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.3;
   armingDelayMS     = -1;
   gravityMod        = 1.0;
   muzzleVelocity    = 400.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

//-------------------------------------
// ASSAULT MORTAR CHARACTERISTICS
//-------------------------------------

datablock TurretImageData(TankATurretBarrel)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   mountPoint = 0;

//   ammo = AssaultMortarAmmo;
   projectile = TankArtillery;
   projectile2 = TankATShell;
   projectileType = GrenadeProjectile;

   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 100.00;
   minEnergy = 100.00;
   useCapacitor = true;

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
   stateTransitionOnTimeout[3]         = "Reload";
   stateTimeoutValue[3]                = 2.5;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = AssaultMortarFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 2.5;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   stateSound[4]                       = MobileBaseStationDeploySound;
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

datablock TracerProjectileData(Coax_bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.3;
   directDamageType    = $DamageType::MG;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = false;

   kickBackStrength  = 0;
   sound             = ChaingunProjectile;

   dryVelocity               = 5000.0;
   wetVelocity               = 3000.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 3000;
   lifetimeMS                = 3000;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 0.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.15;
   crossSize       = 0.3;
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

datablock TurretImageData(TankCoaxBarrel)
{
   shapeFile = "weapon_chaingun.dts";
   mountPoint = 1;
   offset = "0.4 -0.2 0";

   projectile = Coax_bullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 2.0 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 1.0;
   minEnergy = 1.0;

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
   stateSound[3]                       = ChaingunFireSound;
   stateScript[3]                      = "onFire";
   stateTimeoutValue[3]                = 0.07;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.1;
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

datablock TurretImageData(TankTurretParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 3.0";

   projectile = ImplacmentBullet;
   projectileType = TracerProjectile;

   useCapacitor = true;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 75;
};

function TankMGTurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   %p.doexplodecheck = schedule(250, 0, "FlakExplode", %p);
}

function HeavyTank::onTrigger(%data, %obj, %trigger, %state)
{
   if (%trigger ==4){
      switch (%state){
         case 0:
            %obj.fireWeapon = false;
         case 1:
		if (%obj.inv[PlasmaAmmo] > 0){
		   %frd = %obj.getForwardVector();
		   %bck = vectorScale(%frd, -0.85);
		   %lft = vectorNormalize(vectorCross(%frd,"0 0 1"));
		   %rgt = vectorScale(%lft, -0.9);
		   %obj.decInventory(PlasmaAmmo, 4);
      	   %p = new GrenadeProjectile() {
         		dataBlock        = SmokeGrenadeProj;
         		initialDirection = vectorScale(%frd,0.85);
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p);
      	   %p = new GrenadeProjectile() {
         		dataBlock        = SmokeGrenadeProj;
         		initialDirection = %bck;
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p);
      	   %p = new GrenadeProjectile() {
         		dataBlock        = SmokeGrenadeProj;
         		initialDirection = vectorScale(%lft,0.9);
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p);
      	   %p = new GrenadeProjectile() {
         		dataBlock        = SmokeGrenadeProj;
         		initialDirection = %rgt;
         		initialPosition  = getBoxCenter(%obj.getWorldBox());
         		sourceObject     = %obj;
         		sourceSlot       = 0;
      	   };
      	   MissionCleanup.add(%p);
   		   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));  
		   %obj.schedule(30000, "setInventory", PlasmaAmmo, 4);
		}
      }
   }
}

function TankATurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %data.lightStart = getSimTime();

   %vehicle = 0;
   %useEnergyObj = %obj.getObjectMount();
   if(!%useEnergyObj)
      %useEnergyObj = %obj;
   %energy = %useEnergyObj.getEnergyLevel();
   %vehicle = %useEnergyObj;

   if( %useEnergyObj.turretObject.getCapacitorLevel() < %data.minEnergy )
   {
      return;
   }
   %vector = %obj.getMuzzleVector(%slot);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %datablock = %data.projectile;
   if(%obj.firetype == 2){
	%datablock = %data.projectile2;
   }

   %p = new (%data.projectileType)() {
      dataBlock        = %datablock;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = %vehicle;
   };

   %obj.lastProjectile = %p;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;

   %vehicle.turretObject.setCapacitorLevel( %vehicle.turretObject.getCapacitorLevel() - %data.fireEnergy );
   %vec = vectornormalize(%obj.getMuzzleVector(4));
   %obj.mountobj.applyimpulse(%obj.getMuzzlePoint(4),vectorscale(%vec,"-1500"));
}

function FlakExplode(%p){ 
   if(!isObject(%p))
	return;
   InitContainerRadiusSearch(%p.getPosition(), 20, $TypeMasks::VehicleObjectType);
   while ((%SearchResult = containerSearchNext()) != 0)
   {
	%pn = new (TracerProjectile)() { 
	   dataBlock        = TankFlak_Bullet_exp; 
	   initialDirection = vectorNormalize(%p.getVelocity()); 
	   initialPosition  = %p.getPosition(); 
	   sourceObject     = %p.sourceObject; 
	   sourceSlot       = %p.sourceSlot; 
	   vehicleObject    = %p.vehicleObject; 
	}; 
	MissionCleanup.add(%pn); 
	%p.delete(); 
	return;
   }
   %p.doexplodecheck = schedule(30, 0, "FlakExplode", %p);
}

function HeavyTank::onEnterLiquid(%data, %obj, %coverage, %type)
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
