//**************************************************************
// SHRIKE SCOUT FLIER
//**************************************************************

datablock SensorData(combatSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsActiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 500;
};

//**************************************************************
// SOUNDS
//**************************************************************
datablock EffectProfile(ScoutFlyerThrustEffect)
{
   effectname = "vehicles/shrike_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ScoutFlyerEngineEffect)
{
   effectname = "vehicles/shrike_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ShrikeBlasterFireEffect)
{
   effectname = "vehicles/shrike_blaster";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(ScoutFlyerThrustSound)
{
   filename    = "fx/vehicles/shrike_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ScoutFlyerThrustEffect;
};

datablock AudioProfile(ScoutFlyerEngineSound)
{
   filename    = "fx/vehicles/shrike_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
};

datablock AudioProfile(ShrikeBlasterFire)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefault3d;
   preload = true;
   effect = ScoutFlyerEngineEffect;
};

datablock AudioProfile(ShrikeBlasterProjectile)
{
   filename    = "fx/weapons/shrike_blaster_projectile.wav";
   description = ProjectileLooping3d;
   preload = true;
   effect = ShrikeBlasterFireEffect;
};

datablock AudioProfile(ShrikeBlasterDryFireSound)
{
   filename    = "fx/weapons/chaingun_dryfire.wav";
   description = AudioClose3d;
   preload = true;
};

//**************************************************************
// LIGHTS
//**************************************************************
datablock RunningLightData(ShrikeLight1)
{
   type        = 1;
   radius      = 2.0;
   length      = 3.0;
   color       = "1.0  1.0  1.0  1.0";
   direction   = "0.0  1.0 -1.0 ";
   offset      = "0.0  0.0 -0.5";
   texture     = "special/lightcone04";
};

datablock RunningLightData(ShrikeLight2)
{
   radius = 1.5;
   color = "1.0 1.0 1.0 0.3";
   direction = "0.0 0.0 -1.0";
   offset      = "0.0  0.8 -1.2";
   texture = "special/headlight4";
};

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(ScoutFlyer) : ShrikeDamageProfile
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
   numMountPoints = 1;
   isProtectedMountPoint[0] = false;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MeVehicleExplosion;
	explosionDamage = 1.0;
	explosionRadius = 10.0;

   maxDamage = 2.5;
   destroyedLevel = 2.5;

   HDAddMassLevel = 1.9;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 1200;      // Afterburner and any energy weapon pool
   rechargeRate = 4;

   minDrag = 22;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 50;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 1;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.8;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 5250;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 675;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2.5;        // Height off the ground at rest
   createHoverHeight = 1;  // Height off the ground when created
   maxForwardSpeed = 165;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2500;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 10;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 1.25;

   // Rigid body
   mass = 150;        // Mass of the vehicle
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
   max[MissileLauncherAmmo] = 4;
   max[MortarAmmo] = 3;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'F39 RaptorII';
   targetTypeTag = 'Interceptor';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   numWeapons = 3;

   replaceTime = 90;

   max[plasmaammo] = 15;
   flaretime = 250;
   flarelife = 750;
   flarechance = 0.5;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(Shrike_special_gun)
{
   doDynamicClientHits = true;

   directDamage        = 0.175;
   directDamageType    = $DamageType::Bullet;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.025;
   damageRadius        = 0.5;
   radiusDamageType    = $DamageType::Bullet;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 1750.0;
   wetVelocity       = 1250.0;
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
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(sidewinder)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 1.5;
   damageRadius        = 6.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 500;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 15000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 12.0;
   maxVelocity         = 225.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 50.0;
   acceleration        = 100.0;
   
   proximityRadius     = 4;

   terrainAvoidanceSpeed = 100;
   terrainScanAhead      = 50;
   terrainHeightFail     = 50;
   terrainAvoidanceRadius = 150;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};


//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(ScoutChaingunPairImage)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelchain.dts";
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = Shrike_special_gun;
   projectileType = TracerProjectile;
   mountPoint = 10;
//**original**   offset = ".73 0 0";
   offset = "1.05 0.8 0.45";

   projectileSpread = 1.0 / 1000.0;

   usesEnergy = false;
   useMountEnergy = true;
   // DAVEG -- balancing numbers below!
   minEnergy = 1;
   fireEnergy = 1;
   fireTimeout = 125;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 0.05;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";
   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";
   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
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
   // IMPORTANT! The stateTimeoutValue below has been replaced by fireTimeOut
   // above.
   stateTimeoutValue[4]          = 0.01;
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
   stateTimeoutValue[7]        = 0.25;
   stateTransitionOnTimeout[7] = "NoAmmo";

   stateName[8] = "checkState";
   stateTransitionOnTriggerUp[8] = "Spindown";
   stateTransitionOnNoAmmo[8]    = "EmptySpindown";
   stateTimeoutValue[8]          = 0.01;
   stateTransitionOnTimeout[8]   = "ready";
};

datablock ShapeBaseImageData(ScoutChaingunImage) : ScoutChaingunPairImage
{
//**original**   offset = "-.73 0 0";
   offset = "-1.05 0.8 0.45";
   stateScript[3]           = "onTriggerDown";
   stateScript[5]           = "onTriggerUp";
   stateScript[6]           = "onTriggerUp";
};

datablock ShapeBaseImageData(ShrikeMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = sidewinder;
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

datablock BombProjectileData(shrikeBomb)
{
   projectileShapeName  = "bomb.dts";
   emitterDelay         = -1;
   directDamage         = 0.0;
   hasDamageRadius      = true;
   indirectDamage       = 3.5;
   damageRadius         = 20;
   radiusDamageType     = $DamageType::BomberBombs;
   kickBackStrength     = 2500;

   explosion            = "VehicleBombExplosion";
   velInheritFactor     = 1.0;

   grenadeElasticity    = 0.25;
   grenadeFriction      = 0.4;
   armingDelayMS        = 100;
   muzzleVelocity       = 0.1;
   drag                 = 0.05;

   minRotSpeed          = "1.0 0.0 0.0";
   maxRotSpeed          = "2.0 0.0 0.0";
   scale                = "1.0 1.0 1.0";

   sound                = BomberBombProjectileSound;
};

datablock ShapeBaseImageData(ShrikeBombImage)
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

datablock ShapeBaseImageData(ScoutChaingunParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";

   projectile = sidewinder;
   projectileType = SeekerProjectile;
   isSeeker = true;
   seekRadius = $Bomber::SeekRadius;
   maxSeekAngle = 45;
   seekTime = 0.25;
   minSeekHeat = $Bomber::minSeekHeat;
   minTargetingDistance = 50;
   useTargetAudio = $Bomber::useTargetAudio;
}; 

function shrikeMissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   %mountNodeObj = %obj.getMountNodeObject(0);
   if (isObject(%mountNodeObj))
   	%mountnodeObj.decInventory(%data.ammo, 1);
   MissileSet.add(%p);

   if(%obj.isdrone == 1)
	%p.setObjectTarget(%obj.target);
   else{
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
}

function shrikebombImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
   MissileSet.add(%p); 
}

function scoutflyer::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}

function scKillPilot(%player, %source)
{
   if(isObject(%player) && %player.getState() !$= "Dead")
      %player.damage(%source, %player.position, %player.getDatablock().maxDamage, $DamageType::ShotDown);
}

function scoutflyer::onEnterLiquid(%data, %obj, %coverage, %type)
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

function fighterdropflares(%obj,%time,%life,%chance){
   if(%obj.flaring != 1)
	return;
   if(%obj.inv[plasmaAmmo] <= 0){
	%obj.flaring = 0;
	return;
   }
   %up = %obj.getUpVector();
   %frd = %obj.getForwardVector();
   %vec = vectorAdd(%frd,vectorscale(%up,-1));
   %vec = vectorNormalize(%vec);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.3;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.3;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.3;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %vector = MatrixMulVector(%mat, %vec);

   %obj.decInventory(PlasmaAmmo, 1);
   %p = new FlareProjectile() 
   { 
   	dataBlock        = FlareGrenadeProj; 
   	initialDirection = %vector; 
   	initialPosition  = getBoxCenter(%obj.getWorldBox()); 
   	sourceObject     = %obj; 
   	sourceSlot       = 0; 
   }; 

   %rnd = getRandom()*(1/%chance);
   if(%rnd >= 1)
      FlareSet.add(%p); 
   MissionCleanup.add(%p); 
   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox())); 
   %p.schedule(%life, "delete");
   schedule(%time,0,"FighterDropFlares",%obj,%time,%life,%chance);
}
