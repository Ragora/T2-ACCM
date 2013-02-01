// --------------------------------------------------------------
// Outdoor Deployable Turret barrel
// --------------------------------------------------------------

// --------------------------------------------------------------
// Sound datablocks
// --------------------------------------------------------------
datablock EffectProfile(OBLSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(OBLFireEffect)
{
   effectname = "powered/turret_outdoor_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(OBLSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = OBLSwitchEffect;
};

datablock AudioProfile(OBLFireSound)
{
   filename    = "fx/powered/turret_outdoor_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = OBLFireEffect;
};

// --------------------------------------------------------------
// Projectile data
// --------------------------------------------------------------

datablock GrenadeProjectileData(AntiPersonnelMortar)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.15;
   damageRadius        = 20.0;
   radiusDamageType    = $DamageType::OutdoorDepTurret;
   kickBackStrength    = 0;
   bubbleEmitTime      = 1.0;

   sound               = GrenadeProjectileSound;
   explosion           = "GrenadeExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.85; // z0dd - ZOD, 3/30/02. Was 0.5
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.30;
   grenadeFriction   = 0.2;
   armingDelayMS     = 100;
   muzzleVelocity    = 50.0;
   gravityMod        = 1.0;
};

// --------------------------------------------------------------

datablock SensorData(DeployedOutdoorTurretSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsActiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 60;
};

datablock ShockwaveData(OutdoorTurretMuzzleFlash)
{
   width = 0.5;
   numSegments = 13;
   numVertSegments = 1;
   velocity = 2.0;
   acceleration = -1.0;
   lifetimeMS = 300;
   height = 0.1;
   verticalCurve = 0.5;

   mapToTerrain = false;
   renderBottom = false;
   orientToNormal = true;
   renderSquare = true;
   
   texture[0] = "special/blasterHit";
   texture[1] = "special/gradient";
   texWrap = 3.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "1.0 0.8 0.5 1.0";
   colors[1] = "1.0 0.8 0.5 1.0";
   colors[2] = "1.0 0.8 0.5 0.0";
};

datablock TurretData(TurretDeployedOutdoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_outdoor_deploy.dts";

   rechargeRate = 0.15;

   mass = 5.0;
   maxDamage = 1.2;
   destroyedLevel = 1.2;
   disabledLevel = 0.9;
   explosion      = HandGrenadeExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.3;
      expImpulse = 500.0;
   repairRate = 0;
	
	deployedObject = true;

   thetaMin = 0;
   thetaMax = 145;
   thetaNull = 90;

   yawVariance          = 30.0; // these will smooth out the elf tracking code.
   pitchVariance        = 30.0; // more or less just tolerances

   isShielded = false;
   energyPerDamagePoint = 110;
   maxEnergy = 60;
   renderWhenDestroyed = true;
   barrel = DeployableOutdoorBarrel;
   heatSignature = 0;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Anti-Infantry Mortar';
   targetTypeTag = 'Turret';
   sensorData = DeployedOutdoorTurretSensor;
   sensorRadius = DeployedOutdoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
};

datablock TurretImageData(DeployableOutdoorBarrel)
{
   shapeFile = "turret_muzzlepoint.dts";
   item = TurretOutdoorDeployable;

   projectileType = GrenadeProjectile;
   projectile = AntiPersonnelMortar;
   usesEnergy = true;
   fireEnergy = 0.0;
   minEnergy = 30.0;

   lightType = "WeaponFireLight";
   lightColor = "0.25 0.25 0.15 0.2";
   lightTime = "1000";
   lightRadius = "2";

   muzzleFlash = OutdoorTurretMuzzleFlash;
   projectileSpread = 3.0 / 1000.0;
   
   DontFireInsideDamageRadius = true;
   DamageRadius = 30;

   // Turret parameters
   activationMS      = 300;
   deactivateDelayMS = 600;
   thinkTimeMS       = 200;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 240;

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = OBLSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3]        = 1.5;
   stateFire[3]                = true;
   stateShockwave[3]           = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = OBLFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.8;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
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

