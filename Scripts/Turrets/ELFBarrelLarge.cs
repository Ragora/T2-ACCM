//--------------------------------------------------------------------------
// Gauss Cannon Turret
//--------------------------------------------------------------------------

//--------------------------------------------------------------------------
// Sounds
//--------------------------------------------------------------------------
datablock EffectProfile(EBLSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(EBLSwitchSound)
{
   filename    = "fx/powered/turret_heavy_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = EBLSwitchEffect;
};

datablock EffectProfile(FlameTurretFireEffect)
{
   effectname = "Bonuses/Nouns/snake";
   minDistance = 2.5;
   maxDistance = 8.0;
};

datablock AudioProfile(FlameTurretFireSound)
{
   filename    = "fx/Bonuses/Nouns/snake.wav";
   description = AudioClose3d;
   preload = true;
   effect = FlameTurretFireEffect;
};

datablock LinearFlareProjectileData(FlameTurretBolt)
{
   projectileShapeName = "turret_muzzlepoint.dts";
   scale               = "1.0 1.0 1.0";
   faceViewer          = true;
   directDamage        = 0.08;
   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 4.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::Plasma;

   explosion           = "flameBoltExplosion";
   splash              = PlasmaSplash;

   baseEmitter        = FlameEmitter;

   dryVelocity       = 80.0; // z0dd - ZOD, 7/20/02. Faster plasma projectile. was 55
   wetVelocity       = -1;
   velInheritFactor  = 2.0;
   fizzleTimeMS      = 250;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   //activateDelayMS = 100;
   activateDelayMS = -1;

   size[0]           = 0.2;
   size[1]           = 0.5;
   size[2]           = 0.1;


   numFlares         = 35;
   flareColor        = "1 0.18 0.03";
   flareModTexture   = "flaremod";
   flareBaseTexture  = "flarebase";

	sound        = PlasmaProjectileSound;
   fireSound    = PlasmaFireSound;
   wetFireSound = PlasmaFireWetSound;

   hasLight    = true;
   lightRadius = 10.0;
   lightColor  = "0.94 0.03 0.12";
};

datablock TurretImageData(ELFBarrelLarge)
{
   shapeFile = "turret_elf_large.dts";
   item      = ELFBarrelPack;

   projectile = FlameTurretBolt;
   projectileType = LinearFlareProjectile;
   usesEnergy = true;
   fireEnergy = 0.01;
   minEnergy = 0.01;
   emap = true;

   minRankPoints = 1800;

   projectileSpread = 0.5 / 1000.0;

   // Turret parameters
   activationMS      = 700;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 120;
   degPerSecTheta    = 300;
   degPerSecPhi      = 500;
   attackRadius      = 80;
   
   // State transiltions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = EBLSwitchSound;
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
   stateTimeoutValue[3]        = 0.05;
   stateFire[3]                = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateScript[3]              = "onFire";
   stateSound[3]               = FlameTurretFireSound;

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.05;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";
   stateSound[4]                 = PlasmaReloadSound;

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

