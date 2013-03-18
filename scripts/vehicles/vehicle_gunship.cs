//**************************************************************
// AC290 Saber Gunship
//**************************************************************
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(gunship) : BomberDamageProfile
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
   mountPose[3] = sitting;
   numMountPoints = 4;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;
   isProtectedMountPoint[2] = false;
   isProtectedMountPoint[3] = true;

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
   maneuveringForce = 6500;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 800;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 2500;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 4;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 120;  // speed in which forward thrust force is no longer applied (meters/second)

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
   mass = 300;        // Mass of the vehicle
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
   targetNameTag = 'AC-290 Saber';
   targetTypeTag = 'Gunship';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 7.1895;
   observeParameters = "1 10 10";
   shieldEffectScale = "0.75 0.975 0.375";
   showPilotInfo = 1;

   replaceTime = 40;
};

//**************************************************************
// WEAPONS
//**************************************************************

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock GrenadeProjectileData(GunshipArtillery)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 2.0;
   damageRadius        = 20.0;
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
   muzzleVelocity    = 250.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

datablock TracerProjectileData(GunshipCGBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::ACCG;
   explosion           = ACCGExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 3.0;
   radiusDamageType    = $DamageType::ACCG;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 1500.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 0.0;
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

datablock TargetProjectileData(GunshipTlProj)
{
   directDamage        	= 0.0;
   hasDamageRadius     	= false;
   indirectDamage      	= 0.0;
   damageRadius        	= 0.0;
   velInheritFactor    	= 1.0;

   maxRifleRange       	= 1500;
   beamColor           	= "0.0 0.0 0.0";
								
   startBeamWidth			= 0; //0.02
   pulseBeamWidth 	   = 0; //0.025
   beamFlareAngle 	   = 3.0;
   minFlareSize        	= 0.0;
   maxFlareSize        	= 0.0;
   pulseSpeed          	= 6.0;
   pulseLength         	= 0.150;

   textureName[0]      	= "special/nonlingradient";
   textureName[1]      	= "special/flare";
   textureName[2]      	= "special/pulse";
   textureName[3]      	= "special/expFlare";
   beacon               = true;
};

//-------------------------------------
// GUNSHIP TURRET CHARACTERISTICS
//-------------------------------------

datablock TurretData(GunshipTurret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_belly_base.dts";
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";
   targetNameTag = 'Gunship AT';
   targetTypeTag = 'Turret';

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = gunship.maxDamage;
   destroyedLevel          = gunship.destroyedLevel;

   thetaMin                = 90;
   thetaMax                = 180;

   // capacitor
   maxCapacitorEnergy      = 1000;
   capacitorRechargeRate   = 4.0;

   inheritEnergyFromMount  = true;
   firstPersonOnly         = true;
   useEyePoint             = true;
   numWeapons              = 2;
};

datablock TurretData(GunshipTurret2) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Gunship AA';
   targetTypeTag = 'Turret';

   mass           = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = gunship.maxDamage;
   destroyedLevel          = gunship.destroyedLevel;

   thetaMin = 20;
   thetaMax = 110;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 2;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;
};

//*************************
// Turret Images
//*************************

datablock TurretImageData(GunshipTurretBarrel)
{
   shapeFile                        = "turret_missile_large.dts";
   mountPoint                       = 0;
   offset = "-0.9 0 0.0";
   rotation = "0 1 0 90";

   projectile                       = HammerATMissile;
   projectileType                   = SeekerProjectile;

   usesEnergy                       = true;
   useCapacitor                     = true;
   useMountEnergy                   = true;
   fireEnergy                       = 250.0;
   minEnergy                        = 250.0;

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
   stateTimeoutValue[2]             = 1.0;
   stateFire[2]                     = true;
   stateRecoil[2]                   = LightRecoil;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = BomberTurretFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 3.0;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "Reload1";
   stateSequence[4] = "NoAmmo1";

   stateTransitionOnTriggerDown[4]  = "DryFire1";

   stateName[5]                     = "DryFire1";
   stateSound[5]                    = BomberTurretDryFireSound;
   stateTimeoutValue[5]             = 0.75;
   stateTransitionOnTimeout[5]      = "NoAmmo1";

   stateName[6]                     = "WaitFire2";
   stateTransitionOnTriggerDown[6]  = "Fire2";
   stateTransitionOnNoAmmo[6] = "NoAmmo2";

   stateName[7]                     = "Fire2";
   stateTransitionOnTimeout[7]      = "Reload2";
   stateTimeoutValue[7]             = 1.0;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 3.0;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "Reload2";
   stateSequence[9] = "NoAmmo2";

   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberTurretDryFireSound;
   stateTimeoutValue[10]             = 0.75;
   stateTransitionOnTimeout[10]      = "NoAmmo2";
};

datablock TurretImageData(GunshipTurretBarrelPair)
{
   shapeFile                = "turret_missile_large.dts";
   mountPoint               = 0;
   offset = "-0.9 0 -0.4";
   rotation = "0 1 0 90";

   projectile                       = HammerATMissile;
   projectileType                   = SeekerProjectile;

   usesEnergy                       = true;
   useCapacitor                     = true;
   useMountEnergy                   = true;
   fireEnergy                       = 250.0;
   minEnergy                        = 250.0;

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
   stateTimeoutValue[1]             = 0.2;
   stateFire[1]                     = true;
   stateRecoil[1]                   = LightRecoil;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberTurretFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.2;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
};

datablock TurretImageData(GunshipATurretBarrel)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   mountPoint = 1;
   offset = "0.7 0 0.1";

   projectile = GunshipArtillery;
   projectileType = GrenadeProjectile;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = true;
   fireEnergy = 400.00;
   minEnergy = 400.00;

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
   stateTimeoutValue[3]                = 2.0;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = AssaultMortarFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 3.0;
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

datablock TurretImageData(GunshipCGImage)
{
   shapeFile = "turret_tank_barrelchain.dts";
   offset = "-0.3 0 0";
   mountPoint = 0;

   item      = Chaingun;
   projectile = GunshipCGBullet;
   projectileType = TracerProjectile;
   projectileSpread = 1.0 / 1000.0;
   emap = true;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = false;
   minEnergy = 0;
   fireEnergy = 1.0;

   stateName[0] = "Activate";
   stateSequence[0] = "Activate";
//   stateSound[0] = GravChaingunIdleSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0] = 0.1;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0] = "NoAmmo";

   stateName[1] = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "NoAmmo";
   stateTransitionOnAmmo[2] = "Ready";
   stateSpinThread[2] = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   stateName[3] = "Spinup";
   stateSpinThread[3] = SpinUp;
   //stateSound[3] = ChaingunSpinupSound;
   stateTimeoutValue[3] = 0.2;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = ChaingunFireSound;
   //stateRecoil[4] = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateFire[4] = true;
   stateEjectShell[4] = true;
   stateTimeoutValue[4] = 0.07;
   stateTransitionOnTimeout[4] = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4] = "EmptySpindown";

   stateName[5] = "Spindown";
   //stateSound[5] = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.05;
   stateWaitForTimeout[5] = true;
   stateTransitionOnTimeout[5] = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6] = "EmptySpindown";
   //stateSound[6] = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6] = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7] = "DryFire";
   stateSound[7] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[7] = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock TurretImageData(GunshipAAMissileImage)
{
   shapeFile = "turret_missile_large.dts";
   offset = "0.35 0 0";
   mountPoint = 0;

   item = Chaingun;
   projectile = sidewinder_MarkII;
   projectileType = SeekerProjectile;
   emap = true;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = false;
   minEnergy = 0;
   fireEnergy = 1.0;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

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
   stateTimeoutValue[3]                = 2.0;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = BomberTurretFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 3.0;
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

datablock TurretImageData(GunshipTL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   mountPoint = 3;
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

datablock TurretImageData(GST1Param)
{
   shapeFile            = "turret_muzzlepoint.dts";
   mountPoint           = 3;

   projectile           = HammerATMissile;

   // Turret parameters
   activationMS         = 1000;
   deactivateDelayMS    = 1500;
   thinkTimeMS          = 200;
   degPerSecTheta       = 500;
   degPerSecPhi         = 800;

   attackRadius         = 300;
};

datablock TurretImageData(GST2Param)
{
   shapeFile            = "turret_muzzlepoint.dts";
   mountPoint           = 0;
   offset			= "0 0.2 0";

   projectile           = sidewinder_MarkII;

   isSeeker = true; 
   seekRadius = $Bomber::SeekRadius; 
   maxSeekAngle = 30; 
   seekTime = $Bomber::SeekTime; 
   minSeekHeat = $Bomber::minSeekHeat; 
   minTargetingDistance = $Bomber::minTargetingDistance; 
   useTargetAudio = $Bomber::useTargetAudio;

   // Turret parameters
   activationMS         = 1000;
   deactivateDelayMS    = 1500;
   thinkTimeMS          = 200;
   degPerSecTheta       = 500;
   degPerSecPhi         = 800;

   attackRadius         = 300;
};

//*************************************************
//Functions
//*************************************************
//vehicle events
//-------------------------------------------------

function Gunship::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

   %turret = TurretData::create(GunshipTurret);
   %turret2 = TurretData::create(GunshipTurret2);
   MissionCleanup.add(%turret);
   MissionCleanup.add(%turret2);
   %turret.team = %obj.teamBought;
   %turret2.team = %obj.teamBought;
   %turret.setSelfPowered();
   %turret2.setSelfPowered();
   %turret.selectedWeapon = 1;
   %turret2.selectedWeapon = 1;
   %obj.mountObject(%turret, 10);
   %obj.mountObject(%turret2, 2);
   %turret.mountImage(GST1Param, 0);
   %turret.mountImage(GunshipTurretBarrel,2);
   %turret.mountImage(GunshipTurretBarrelPair,3);
   %turret.mountImage(GunshipATurretBarrel, 4);
   %turret.mountImage(gunshipTL, 5);
   %turret2.mountImage(GST2Param, 0);
   %turret2.mountImage(GunshipCGImage,2);
   %turret2.mountImage(GunshipAAMissileImage,3);
   %obj.turretObject = %turret;
   %obj.turretObject2 = %turret2;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret2.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   %turret2.setAutoFire(false);
   %turret.mountobj = %obj;
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetSensorGroup(%turret2.getTarget(), %turret2.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
   setTargetNeverVisMask(%turret2.getTarget(), 0xffffffff);
}

function Gunship::playerMounted(%data, %obj, %player, %node)
{
//[[CHANGE]]
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0)
   {
      // pilot position
      %player.setPilot(true);
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
	bottomPrint(%player.client, "Pilot Postion: your basic pilot seat jsut fly", 5, 2 );
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
	centerPrint(%player.client, "AT gunner Position: wep1-LGM's wep2-Artillery ***initiate laser for LGM's with GRENADE KEY***", 5, 2 );
   }
   else if (%node == 3)
   {
      // bombardier position
      %turret2 = %obj.getMountNodeObject(2);
      %player.vehicleTurret = %turret2;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret2);
         %player.client.setObjectActiveImage(%turret2, 2);
      }
      %turret2.bomber = %player;
      $bWeaponActive = 0;
      %obj.getMountNodeObject(2).selectedWeapon = 1;
      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);

	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
      %player.isBomber = true;
	bottomPrint(%player.client, "AA gunner Position: wep1-heavy chaingun wep2-lock on missiles", 5, 2 );
	setTargetSensorGroup(%turret2.getTarget(), %player.team);
   }
   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function Gunship::deleteAllMounted(%data, %obj)
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
	if(isObject(%turret.TL))
	   %turret.TL.delete();
   }
   %turret2 = %obj.getMountNodeObject(2);
   if (isObject(%turret2)){
	%turret2.altTrigger = 0;
	%turret2.fireTrigger = 0;
	if (%client = %turret2.getControllingClient())
	{
	   %client.player.setControlObject(%client.player);
	   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
	   %client.player.mountVehicle = false;

	   %client.player.bomber = false;
	   %client.player.isBomber = false;
	}
	%turret2.schedule(2000, delete);
   }
}

//-------------------------------------------------
//Turret Events
//-------------------------------------------------
function GunshipTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function GunshipTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function GunshipTurret2::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function GunshipTurret2::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function GunshipTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %obj.setImageTrigger(5, false);
   %client = %obj.getControllingClient();
   %client.player.isBomber = false;
   %client.player.mountVehicle = false;
   if(%client.player.getState() !$= "Dead")
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function GunshipTurret2::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %client = %obj.getControllingClient();
   %client.player.isBomber = false;
   %client.player.mountVehicle = false;
   if(%client.player.getState() !$= "Dead")
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}
function GunshipTurret::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
         if(%obj.selectedWeapon == 1)
         {
            %obj.setImageTrigger(4, false);
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
         }
         else
         {
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(3, false);
            if(%state)
               %obj.setImageTrigger(4, true);
            else
               %obj.setImageTrigger(4, false);
         } 

      case 2:
         if(%state)
         {
            %obj.getDataBlock().playerDismount(%obj);
         }
   }
   if(%trigger == 4)
   {
      switch (%state) {
         case 0:
		if(isObject(%obj.TL))
               %obj.setImageTrigger(5, false);
		else
		   %obj.setImageTrigger(5, true);
	}
   }
}

function GunshipTurret2::onTrigger(%data, %obj, %trigger, %state)
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

//-------------------------------------------------
//Weapon Events
//-------------------------------------------------

function GunshipTurretBarrel::firePair(%this, %obj, %slot){
   %obj.setImageTrigger( 3, true);
}
function GunshipTurretBarrelPair::stopFire(%this, %obj, %slot){
   %obj.setImageTrigger( 3, false);
}
function GunshipTurretBarrelPair::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TL))
	%p.setObjectTarget(%obj.TL.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
}

function GunshipTurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TL))
	%p.setObjectTarget(%obj.TL.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
}

function HammerATlockon(%p)
{ 
   if(!isObject(%p))
	return;
   InitContainerRadiusSearch(%p.getPosition(), 100, $TypeMasks::VehicleObjectType);
   while ((%SearchResult = containerSearchNext()) != 0)
   {
	%SearchObj = FirstWord(%SearchResult);
	if(%SearchObj.getClassName() $= "WheeledVehicle" || %SearchObj.getClassName() $= "HoverVehicle"){
	   %p.setObjectTarget(%searchObj);
	   return;
	}
   }
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
}

function GunshipAAMissileImage::onFire(%data,%obj,%slot) 
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

function GunshipATurretBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   %vec = vectornormalize(%obj.getMuzzleVector(4));
   %obj.mountobj.applyimpulse(%obj.getMuzzlePoint(4),vectorscale(%vec,"-100"));
}

function GunshipTL::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.TL = %p;
   %p.beacon = new BeaconObject() {
      dataBlock = "SubBeacon";
      beaconType = "vehicle";
      position = %p.getTargetPoint();
   };
   %p.turret = %obj;
   %p.beaconupdate = schedule(100, 0, "GunshipBeaconLoop", %p);
}

function GunshipTL::onDecon(%data,%obj,%slot){
   %obj.TL.beacon.delete();
   %obj.TL.delete();
}

function GunshipBeaconLoop(%p){
   if(!isObject(%P))
	return;
   %pos = %p.getTargetPoint();
   if(%pos $= "0 0 0 -1"){
      %Tpos = %p.turret.getPosition();
	%Tvec = vectorScale(%p.turret.getMuzzleVector(5),1500);
	%pos = vectorAdd(%Tpos,%Tvec);
   }
   %p.beacon.setPosition(%pos);
   %p.beaconupdate = schedule(100, 0, "GunshipBeaconLoop", %p);
}

//-------------------------------------------------
//Misc
//-------------------------------------------------

function gunship::onEnterLiquid(%data, %obj, %coverage, %type)
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
