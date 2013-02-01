//--------------------------------------------------------------------------
// Chaingun Turret - Created by Dondelium_X, Greatly Modified by Blnukem
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------
datablock EffectProfile(HeavyCGTurretSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};
datablock AudioProfile(HeavyCGTurretSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = HeavyCGTurretSwitchEffect;
};

datablock EffectProfile(HeavyCGTurretFireEffect)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   minDistance = 2.5;
   maxDistance = 8.0;
};

datablock AudioProfile(HeavyCGTurretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = HeavyCGTurretFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------------------------------------------

datablock TracerProjectileData(HVCGTurretBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.13;
   directDamageType    = $DamageType::PlasmaTurret;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;

   kickBackStrength  = 50.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 3000.0;
   wetVelocity       = 1000.0;
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
   tracerColor     = 10.0/255.0 @ " " @ 30.0/255.0 @ " " @ 240.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.2;
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
   lightRadius = 4.0;
   lightColor  = "0.5 0.5 0.175";

};

//--------------------------------------------------------------------------
// Chaingun Turret Image
//--------------------------------------------------------------------------

datablock TurretImageData(PlasmaBarrelLarge)
{
   shapeFile = "turret_tank_barrelchain.dts";
   item      = ChaingunBarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: ChaingunBarrelLargePack
   mountPoint = 0;

   projectile = HVCGTurretBullet;
   projectileType = TracerProjectile;
   
   casing              = ShellDebris;
   shellExitDir        = "0.0 -10.0 10.0";
   shellExitOffset     = "0.0 0.0 1.0";
   shellExitVariance   = 10.0;
   shellVelocity       = 3.5;
   
   usesEnergy = true;
   fireEnergy = 0;
   minEnergy = 1;
   emap = true;

   projectileSpread = 6.0 / 1000.0;

   // Turret parameters
   activationMS      = 700; // z0dd - ZOD, 3/27/02. Was 1000. Amount of time it takes turret to unfold
   deactivateDelayMS = 1500;
   thinkTimeMS       = 120; // z0dd - ZOD, 3/27/02. Was 200. Amount of time before turret starts to unfold (activate)
   degPerSecTheta    = 300;
   degPerSecPhi      = 500;
   attackRadius      = 200; // z0dd - ZOD, 3/27/02. Was 120

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = HeavyCGTurretSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateSequenceRandomFlash[3]         = true;
   stateFire[3]                        = true;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = HeavyCGTurretFireSound;
   stateScript[3]                      = "onFire";
   stateFire[3]                        = true;
   stateEjectShell[3]                  = true;
   stateTimeoutValue[3]                = 0.1;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

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
