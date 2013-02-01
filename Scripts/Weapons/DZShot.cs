datablock ParticleData(DemonFBSmokeParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 2500;  
   lifetimeVarianceMS   = 500;

   textureName          = "particleTest";

   useInvAlpha =     true;

   spinRandomMin = -60.0;
   spinRandomMax = 60.0;

   colors[0]     = "0.5 0.5 0.5 0.5";
   colors[1]     = "0.4 0.4 0.4 0.2";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.75;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(DemonFBSmokeEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;

   ejectionVelocity = 0.75;  // A little oomph at the back end
   velocityVariance = 0.2;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   particles = "DemonFBSmokeParticle";
};

datablock GrenadeProjectileData(DemonFireball)
{
   projectileShapeName = "plasmabolt.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.4;
   damageRadius        = 5.0; // z0dd - ZOD, 8/13/02. Was 20.0
   radiusDamageType    = $DamageType::zombie;
   kickBackStrength    = 1500;

   explosion           = "PlasmaBoltExplosion";
   underwaterExplosion = "PlasmaBoltExplosion";
   velInheritFactor    = 0;
   splash              = PlasmaSplash;
   depthTolerance      = 100.0;
   
   baseEmitter         = DemonFBSmokeEmitter;
   bubbleEmitter       = DemonFBSmokeEmitter;
   
   grenadeElasticity = 0;
   grenadeFriction   = 0.4;
   armingDelayMS     = -1; // z0dd - ZOD, 4/14/02. Was 2000

   gravityMod        = 0.4;  // z0dd - ZOD, 5/18/02. Make mortar projectile heavier, less floaty
   muzzleVelocity    = 50.0; // z0dd - ZOD, 8/13/02. More velocity to compensate for higher gravity. Was 63.7
   drag              = 0;
   sound	     = PlasmaProjectileSound;

   hasLight    = true;
   lightRadius = 10;
   lightColor  = "1 0.75 0.25";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "1 0.75 0.25";
};

datablock ShapeBaseImageData(DZShotImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = DZShot;

   projectile = DemonFireball;
   projectileType = GrenadeProjectile;

   usesEnergy = true;
   fireEnergy = 40;
   minEnergy = 40;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ChaingunSwitchSound;

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
   stateRecoil[3] = NoRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = PlasmaProjectileSound;
   stateScript[3] = "onFire";

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateTimeoutValue[6] = 0.1;
   stateTransitionOnTimeout[6] = "Ready";
};

datablock ItemData(DZShot)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = DZShotImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a Demon Zombie Fireball Ability";
};
