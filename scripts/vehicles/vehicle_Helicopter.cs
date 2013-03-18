//**************************************************************
// SHRIKE SCOUT FLIER
//**************************************************************
   $helicopter::SeekRadius = 500; 
   $helicopter::SeekTime = 0.5; 
   $helicopter::minSeekHeat = 0.6; 
   $helicopter::minTargetingDistance = 15; 
   $helicopter::useTargetAudio = false;

datablock AudioProfile(HeliturretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

datablock ParticleEmitterData(WhiteHorseHeatSeekerFireEffectEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 1.2;

   ejectionVelocity = 10.0;
   velocityVariance = 0.0;

   thetaMin         = 179.0;
   thetaMax         = 180.0;

   lifetimeMS       = 20;

   particles = "BazookaFireEffectSmoke";

};
 
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(helicopter) : ShrikeDamageProfile
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

   maxDamage = 2.0;
   destroyedLevel = 2.0;

   HDAddMassLevel = 1.6;	//if damage is above this Heavy Damage effects kick in
   HDMassImage = LflyerHDMassImage;	//this is the mass image that mounts when heavy damage kicks in

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 150;      // Afterburner and any energy weapon pool
   rechargeRate = 1.0;

   minDrag = 10;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 700;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 15;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 300;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.95;      // Dampen control input so you don't` whack out at very slow speeds

   // Maneuvering
   maxSteeringAngle = 7;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 4;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 2;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 10;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 620;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 35;     // Steering jets (how much you heel over when you turn)
   rollForce = 20;                //  was 20 Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 1;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 50;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 1250;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 1;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0.1;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 3.5;

   // Rigid body
   mass = 125;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 10;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.07;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 45;      // The speed your contrail shows up at.
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
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   minMountDist = 4;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'WhiteHorse';
   targetTypeTag = 'Assault Chopper';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   max[chaingunAmmo] = 24;
   max[MissileLauncherAmmo] = 8;
   max[PlasmaAmmo] = 12;

   numWeapons = 2;

   replaceTime = 120;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

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

datablock SeekerProjectileData(HelicopterMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.6;
   damageRadius        = 9.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 1000;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   explosion           = "MissileExplosion";
   velInheritFactor    = 0.0;

   splash              = MissileSplash;
   baseEmitter         = TankArtillerySmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 5000;
   gravityMod          = 0.4;
   muzzleVelocity      = 250.0;
   turningSpeed        = 0.0;
   
   proximityRadius     = 4;

   terrainAvoidanceSpeed = 220;
   terrainScanAhead      = 50;
   terrainHeightFail     = 50;
   terrainAvoidanceRadius = 50;

   useFlechette = true;
   flechetteDelayMs = 100;
   casingDeb = FlechetteDebris;
};

datablock SeekerProjectileData(HammerATMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 2.8;
   damageRadius        = 17.5;
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
   muzzleVelocity      = 10.0;
   maxVelocity         = 200.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 40.0;
   acceleration        = 100.0;

   proximityRadius     = 5;

   terrainAvoidanceSpeed         = 90;
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
   flechetteDelayMs = 750;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = true;
};

//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(HelicopterMissilePairImage)
{
   className = WeaponImage;
   shapeFile = "turret_missile_large.dts";
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = HelicopterMissile;
   projectileType = SeekerProjectile;
   mountPoint = 10;
   offset = "1.0 1 0.5";

   projectileSpread = 1.0 / 1000.0;

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 1;
   fireEnergy = 1;
   fireTimeout = 125;
   emap = true;


   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";
   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";
   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "AmmoLoading";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";
   //--------------------------------------
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";
   //--------------------------------------
   stateName[4]             = "Fire";
   stateSpinThread[4]       = FullSpeed;
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateSound[4]            = ShrikeBlasterFire;
   stateTimeoutValue[4]          = 0.15;
   stateTransitionOnTimeout[4]   = "checkState";
   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5]            = 0.01;
   stateWaitForTimeout[5]          = false;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";
   //--------------------------------------
   stateName[6]       = "EmptySpindown";
//   stateSound[6]      = ChaingunSpindownSound;
   stateSpinThread[6] = SpinDown;
   stateTransitionOnAmmo[6]   = "Ready";
   stateTimeoutValue[6]        = 0.01;
   stateTransitionOnTimeout[6] = "NoAmmo";
   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ShrikeBlasterDryFireSound;
   stateTransitionOnTriggerUp[7] = "NoAmmo";
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "NoAmmo";

   stateName[8] = "checkState";
   stateTransitionOnTriggerUp[8] = "Spindown";
   stateTransitionOnNoAmmo[8]    = "EmptySpindown";
   stateTimeoutValue[8]          = 0.01;
   stateTransitionOnTimeout[8]   = "ready";

   stateName[9]                     = "AmmoLoading";
   stateSound[9] 			 	= MissileReloadSound;
   stateTimeoutValue[9]             = 0.1;
   stateAllowImageChange[9]         = false;
   stateTransitionOnTimeout[9]      = "Ready";
};

datablock ShapeBaseImageData(HelicopterMissileImage) : HelicopterMissilePairImage
{
//**original**   offset = "-.73 0 0";
   offset = "-1.0 1 0.5";
   stateScript[3]           = "onTriggerDown";
   stateTimeoutValue[3]          = 0.08;
   stateScript[5]           = "onTriggerUp";
   stateScript[6]           = "onTriggerUp";
};

datablock SeekerProjectileData(Heli_heavy)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.75;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 900;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.6;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 10000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 70.0;
   maxVelocity         = 250.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 45.0;
   acceleration        = 80.0;
   
   proximityRadius     = 7;

   terrainAvoidanceSpeed = 100;
   terrainScanAhead      = 1;
   terrainHeightFail     = 1;
   terrainAvoidanceRadius = 20;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};

datablock ShapeBaseImageData(HelicopterATMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = Heli_heavy;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "1.1 -4.5 2.5";	// L/R - F/B - T/B

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 1;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 0.1;
   stateFire[2]                     = true;
   stateEmitter[2] 			= "WhiteHorseHeatSeekerFireEffectEmitter";
   stateEmitterNode[2] 			= "muzzlepoint1";
   stateEmitterTime[2] 			= 1;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = MissileFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 0.3;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "AmmoLoading1";
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
   stateTimeoutValue[7]             = 0.1;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 0.3;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "AmmoLoading2";
   stateSequence[9] = "NoAmmo2";
   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberTurretDryFireSound;
   stateTimeoutValue[10]             = 0.75;
   stateTransitionOnTimeout[10]      = "NoAmmo2";

   stateName[11]                     = "AmmoLoading1";
   stateSound[11] 			 = MissileReloadSound;
   stateTimeoutValue[11]             = 0.1;
   stateAllowImageChange[11]         = false;
   stateTransitionOnTimeout[11]      = "Reload1";

   stateName[12]                     = "AmmoLoading2";
   stateSound[12] 			 = MissileReloadSound;
   stateTimeoutValue[12]             = 0.1;
   stateAllowImageChange[12]         = false;
   stateTransitionOnTimeout[12]      = "Reload2";
};

datablock ShapeBaseImageData(HelicopterATMissileImage2)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = Heli_heavy;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "-1.1 -4.5 2.5";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 0.1;
   stateFire[1]                     = true;
   stateEmitter[1] 			= "WhiteHorseHeatSeekerFireEffectEmitter";
   stateEmitterNode[1] 			= "muzzlepoint1";
   stateEmitterTime[1] 			= 1;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberTurretFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.1;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
};

datablock ShapeBaseImageData(HelicopterMissileParam)
{
   mountPoint = 2;
   shapeFile = "turret_missile_large.dts";

   projectile = Heli_heavy;
   projectileType = SeekerProjectile;

   isSeeker = true;
   seekRadius = $Bomber::SeekRadius;
   maxSeekAngle = 45;
   seekTime = 0.5;
   minSeekHeat = 0.6;
   minTargetingDistance = 50;
   useTargetAudio = true;
}; 

datablock ShapeBaseImageData(HATDummy)
{
   shapeFile = "stackable2m.dts";
   mountPoint = 10;
   offset = "1.1 -5 2.5";
   rotation = "1 0 0 90";
   mass = 20;
   emap = true;
};

datablock ShapeBaseImageData(HATDummy2)
{
   shapeFile = "stackable2m.dts";
   mountPoint = 10;
   offset = "-1.1 -5 2.5";
   rotation = "1 0 0 90";
   mass = 20;
   emap = true;
};

function HelicopterATMissileImage::onFire(%data,%obj,%slot) 
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

function HelicopterATMissileImage2::onFire(%data,%obj,%slot) 
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

function HelicopterATMissileImage::firePair(%this, %obj, %slot){
   %obj.setImageTrigger( 5, true);
}

function HelicopterATMissileImage2::stopFire(%this, %obj, %slot){
   %obj.setImageTrigger( 5, false);
}

function Helicopter::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);
   if(%obj.lastBomber.lastVehicle == %obj)
      if(%obj.getMountNodeObject(1) == %obj.lastBomber)
         schedule(200, %obj.lastBomber, "scKillPilot", %obj.lastBomber, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}


//-------------------------------------
// CHOPPER BELLY TURRET CHARACTERISTICS
//-------------------------------------

datablock TurretData(HeliTurret) : TurretDamageProfile
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
   maxDamage               = helicopter.maxDamage;
   destroyedLevel          = helicopter.destroyedLevel;

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

   targetNameTag           = 'Chopper Chaingun';
   targetTypeTag           = 'Turret';

   max[ChaingunAmmo] = 400;
   max[MortarAmmo] = 8;
};

datablock TracerProjectileData(Heli_CG_Bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.1;
   directDamageType    = $DamageType::ACCG;
   explosion           = ACCGExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.3;
   damageRadius        = 2.0;
   radiusDamageType    = $DamageType::ACCG;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 2500.0;
   wetVelocity       = 100.0;
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

datablock ShapeBaseImageData(HeliChaingunImage)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelchain.dts";
   item      = Chaingun;
   ammo 	 = ChaingunAmmo;
   projectile = Heli_CG_Bullet;
   projectileType = TracerProjectile;
   projectileSpread = 1.0 / 1000.0;
   emap = true;
   offset = "0.07 -0.4 -0.5";

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

   velpredict = 0;

   mountPoint = 1;
   usesEnergy = false;
//   useCapacitor = true;
//   useMountEnergy = true;
//   minEnergy = 1;
//   fireEnergy = 0.1;

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
   stateSound[3] = ChaingunSpinupSound;
   stateTimeoutValue[3] = 0.5;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = HeliturretFireSound;
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
   stateSound[5] = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.5;
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

datablock ShapeBaseImageData(HelicopterTATMissileImage)
{
   className = WeaponImage;
   shapeFile = "stackable2m.dts";
   item = MissileLauncher;
   ammo = MortarAmmo;
   projectile = HammerATMissile;
   projectileType = SeekerProjectile;

   mountPoint = 1;
   offset = "-0.9 -0.1 -0.3";
   rotation = "1 0 0 90";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 1;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 0.5;
   stateFire[2]                     = true;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = MissileFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 2.0;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "AmmoLoading1";
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
   stateTimeoutValue[7]             = 0.5;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 4.5;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "AmmoLoading2";
   stateSequence[9] = "NoAmmo2";
   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberTurretDryFireSound;
   stateTimeoutValue[10]             = 0.75;
   stateTransitionOnTimeout[10]      = "NoAmmo2";

   stateName[11]                     = "AmmoLoading1";
   stateSound[11] 			 = MissileReloadSound;
   stateTimeoutValue[11]             = 0.1;
   stateAllowImageChange[11]         = false;
   stateTransitionOnTimeout[11]      = "Reload1";

   stateName[12]                     = "AmmoLoading2";
   stateSound[12] 			 = MissileReloadSound;
   stateTimeoutValue[12]             = 0.1;
   stateAllowImageChange[12]         = false;
   stateTransitionOnTimeout[12]      = "Reload2";
};

datablock ShapeBaseImageData(HelicopterTATMissileImage2)
{
   className = WeaponImage;
   shapeFile = "stackable2m.dts";
   item = MissileLauncher;
   ammo = MortarAmmo;
   projectile = HammerATMissile;
   projectileType = SeekerProjectile;

   mountPoint = 1;
   offset = "0.9 -0.1 -0.3";
   rotation = "1 0 0 90";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 0.1;
   stateFire[1]                     = true;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberTurretFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 2.0;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
}; 

datablock TurretImageData(HeliTurretParam) 
{ 
   mountPoint 		= 1; 
   shapeFile 		= "turret_muzzlepoint.dts"; 

   Projectile 		= Shrike_special_gun;
   ProjectileType 	= TracerProjectile;
};

datablock TurretImageData(GunshipTL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   mountPoint = 1;
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

function HelicopterTATMissileImage::firePair(%this, %obj, %slot){
   %obj.setImageTrigger( 4, true);
}

function HelicopterTATMissileImage2::stopFire(%this, %obj, %slot){
   %obj.setImageTrigger( 4, false);
}

function HelicopterTATMissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TL))
	%p.setObjectTarget(%obj.TL.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
//   %p.CGMing = schedule(500, 0, "startCGM", %p);
}

function HelicopterTATMissileImage2::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   MissileSet.add(%p); 
   if(isObject(%obj.TL))
	%p.setObjectTarget(%obj.TL.beacon);
   %p.HATlockon = schedule(500, 0, "HammerATlockon", %p);
//   %p.CGMing = schedule(500, 0, "startCGM", %p);
}

//******************************************************
// vehicle.cs and weapturretcode.cs functions
//******************************************************


//----------------------------
// Helicopter FLIER
//----------------------------

function helicopter::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(HelicopterMissileParam, 0);
   %obj.mountImage(HelicopterMissileImage, 2);
   %obj.mountImage(HelicopterMissilePairImage, 3);
   %obj.mountImage(HelicopterATMissileImage, 4);
   %obj.mountImage(HelicopterATMissileImage2, 5);
   %obj.mountImage(HATDummy, 6);
   %obj.mountImage(HATDummy2, 7);
   %obj.selectedWeapon = 1;
   %obj.nextWeaponFire = 2;
   %obj.setInventory(chaingunammo, 24);
   %obj.setInventory(MissileLauncherAmmo, 8);
   %obj.setInventory(PlasmaAmmo, 12);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(HeliTurret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(AIAimingTurretBarrel, 0);
   %turret.mountImage(helichaingunimage, 2);
   %turret.mountImage(HelicopterTATMissileImage, 3);
   %turret.mountImage(HelicopterTATMissileImage2, 4);
   %turret.mountImage(gunshipTL,5);
   %turret.setInventory(MortarAmmo, 8);
   %turret.setInventory(ChaingunAmmo, 400);
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function helicopter::deleteAllMounted(%data, %obj)
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
   if(isObject(%turret.TL))
	%turret.TL.delete();
}

function helicopter::playerMounted(%data, %obj, %player, %node)
{
   bottomPrint(%player.client, "Helicopter: WEPS 1.mini anti ground dumbfire rockets 2.Seeking Missiles turreter.EXP Shell chaingun ***flare grenade on grenade key thanks to cracktrooper***", 5, 2 );
   $numVWeapons = 2;

   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0)
   {
      %player.setPilot(true);
	commandToClient(%player.client, 'setHudMode', 'Pilot', "apache", %node);
      commandToClient(%player.client, 'SetWeaponryVehicleKeys', true);
      %obj.selectedWeapon = 1;

      %ammoAmt = %player.inv[MissileLauncherAmmo];
      if(%ammoAmt)
        %obj.setInventory(MissileLauncherAmmo, 8);

      %ammoAmt = %player.inv[chaingunAmmo];
      if(%ammoAmt)
        %obj.incInventory(chaingunAmmo, %ammoAmt);

      %ammoAmt = %player.inv[chaingunAmmo];
      if(%ammoAmt)
        %obj.incInventory(PlasmaAmmo, 12);
   }
   else if (%node == 1)
   {
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
        %obj.turretobject.setInventory(MortarAmmo, 8);

      %ammoAmt = %player.inv[chaingunAmmo];
      if(%ammoAmt)
        %obj.turretobject.setInventory(chaingunAmmo, 400);
	setTargetSensorGroup(%turret.getTarget(), %player.team);
   }
   // build a space-separated string representing passengers
   // 0 = no passenger; 1 = passenger (e.g. "1 0 0 ")
   %passString = buildPassengerString(%obj);
	// send the string of passengers to all mounted players
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   // update observers who are following this guy...
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function helicopter::onTrigger(%data, %obj, %trigger, %state)
{
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
			if(%obj.nextWeaponFire == 2) 
			{
               	   %obj.setImageTrigger(2, true);
               	   %obj.setImageTrigger(3, true);
            	}
		}
            else 
            {
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(3, false);
            %obj.setImageTrigger(4, true);
            }
      }
   }
   	else if (%trigger ==4)    // Throw flare 
   	{
         switch (%state) 
	   {
         case 0:
            %obj.fireWeapon = false;
         case 1:
		if (%obj.inv[PlasmaAmmo] > 0)
		{
               %obj.fireWeapon = true;
		   %obj.decInventory(PlasmaAmmo, 2);
		   %vec = vectornormalize(vectorcross(%obj.getForwardvector(),%obj.getUpVector()));
   		   %p = new FlareProjectile() 
   		   { 
   		      dataBlock        = VFlareGrenadeProj; 
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
   		      dataBlock        = VFlareGrenadeProj; 
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
}

function helicopter::playerDismounted(%data, %obj, %player)
{
   %player.setInventory(ChaingunAmmo, 0);
   %player.setInventory(MissileLauncherAmmo, 0);
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %obj.setImageTrigger(5, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);

   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function HelicopterMissileImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
   MissileSet.add(%p);
}

function HelicopterMissilePairImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
   MissileSet.add(%p);
}

function heliTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function heliTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function heliTurret::onTrigger(%data, %obj, %trigger, %state)
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
            %obj.setImageTrigger(4, false);
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

function heliTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %player.setInventory(ChaingunAmmo, 0);
   %player.setInventory(MortarAmmo, 0);
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

function HeliChaingunImage::onFire(%data,%obj,%slot)
{
   %data.lightStart = getSimTime();

   %vec = %obj.getMuzzleVector(%slot);

   if(%data.velpredict == 1){
	%target = %obj.getLockedTarget();
	if(%target){
	   %Tpos = %target.getWorldBoxCenter();
	   %Opos = %obj.getMuzzlepoint(%slot);
	   %dist = vectorDist(%Tpos,%Opos);
	   %pos = vectorAdd(%Tpos, vectorScale(%target.getVelocity(),(%dist / 2500) ));

	   %dist = vectorDist(%pos,%Opos);
	   %pos = vectorAdd(%Tpos, vectorScale(%target.getVelocity(),(%dist / 2500) ));

	   %Tvec = vectorNormalize(vectorSub(%pos,%Opos));
	   %Fvec = %obj.getMuzzleVector(%slot);
	   if(vectorDist(%Tvec,%Fvec) <= 0.1)
		%vec = vectorNormalize(vectorSub(%Tpos,%obj.getMuzzlePoint(%slot)));
	} 
   }

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = %vehicle;
   };
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;

   %obj.decInventory(%data.ammo,1);
   return %p;
}

function helicopter::onEnterLiquid(%data, %obj, %coverage, %type)
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