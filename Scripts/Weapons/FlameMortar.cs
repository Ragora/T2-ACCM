//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Napalm Mortar
// Made by: Blnukem
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Sound Data
//------------------------------------------------------------------------------

datablock EffectProfile(MortarFireEffect)
{
   effectname = "weapons/mortar_fire";
   minDistance = 2.5;
   maxDistance = 5.5;
};

datablock AudioProfile(MortarFireSound)
{
   filename    = "fx/weapons/mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = MortarFireEffect;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Explosion Data
//------------------------------------------------------------------------------

datablock ParticleData(NapalmMortarInitExpFlameParticle)
{
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -1.1;
   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 0;
   textureName          = "special/Explosion/exp_0016";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 7;
   sizes[1]      = 8;
};

datablock ParticleEmitterData(NapalmMortarInitExpFlameEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionOffset = 2.0;
   ejectionVelocity = 20.0;
   velocityVariance = 10.0;
   thetaMin         = 0.0;
   thetaMax         = 90.0;
   lifetimeMS       = 250;

   particles = "NapalmMortarInitExpFlameParticle";
};

datablock ParticleData(NapalmMortarExpGroundBurnParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = -0.4;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   textureName          = "special/cloudflash3.png";
   colors[0]     = "1 0.18 0.03 0.6";
   colors[1]     = "1 0.18 0.03 0.0";
   sizes[0]      = 6;
   sizes[1]      = 6.75;
};

datablock ParticleEmitterData(NapalmMortarExpGroundBurnEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionOffset = 0.0;
   ejectionVelocity = 10.0;
   velocityVariance = 10.0;
   thetaMin         = 87.0;
   thetaMax         = 88.0;
   lifetimeMS       = 10000;

   particles = "NapalmMortarExpGroundBurnParticle";
};

datablock ParticleData(NapalmMortarExpGroundBurnSmokeParticle)
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

datablock ParticleEmitterData(NapalmMortarExpGroundBurnSmokeEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionOffset = 7.0;
   ejectionVelocity = 10.0;
   velocityVariance = 10.0;
   thetaMin         = 0.0;
   thetaMax         = 60.0;
   lifetimeMS       = 10000;

   particles = "NapalmMortarExpGroundBurnSmokeParticle";
};

datablock ExplosionData(NapalmMortarExplosion)
{
   soundProfile   = MortarExplosionSound;
   emitter[0] = NapalmMortarInitExpFlameEmitter;
   emitter[1] = NapalmMortarExpGroundBurnEmitter;
   emitter[2] = NapalmMortarExpGroundBurnSmokeEmitter;

   explosionShape = "effect_plasma_explosion.dts";
   faceViewer = true;
   lifetimeMS = 10000;
   playSpeed = 0.7;

   sizes[0] = "7.0 7.0 7.0";
   sizes[1] = "7.0 7.0 7.0";
   times[0] = 0.0;
   times[1] = 1.0;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Particle Data
//------------------------------------------------------------------------------

datablock ParticleData(NapalamMortarParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.1;
   inheritedVelFactor   = 0.1;

   lifetimeMS           = 500;
   lifetimeVarianceMS   = 50;

   textureName          = "particleTest";

   spinRandomMin = -10.0;
   spinRandomMax = 10.0;

   colors[0]     = "1 0.18 0.03 0.4";
   colors[1]     = "1 0.18 0.03 0.3";
   colors[2]     = "1 0.18 0.03 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 0.5;
   sizes[2]      = 0.08;
   times[0]      = 0.0;
   times[1]      = 0.6;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(NapalamMortarEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;

   ejectionOffset = 0.2;
   ejectionVelocity = 10.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   particles = "NapalamMortarParticle";
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Projectile
//------------------------------------------------------------------------------

datablock GrenadeProjectileData(NapalmMortarShot)
{
   projectileShapeName = "mortar_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 5.0;
   damageRadius        = 20.0;
   radiusDamageType    = $DamageType::Plasma;
   kickBackStrength    = 2500;

   explosion           = NapalmMortarExplosion;
   velInheritFactor    = 0.5;
   splash              = MortarSplash;
   depthTolerance      = 10.0;
   
   baseEmitter         = NapalamMortarEmitter;
   
   grenadeElasticity = 0.15;
   grenadeFriction   = 0.4;
   armingDelayMS     = 2000;
   muzzleVelocity    = 63.7;
   drag              = 0.1;

   sound			 = MortarProjectileSound;

   hasLight    = true;
   lightRadius = 10;
   lightColor  = "0.94 0.03 0.12";

};
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Napalm Ammo
//------------------------------------------------------------------------------

datablock ItemData(NapalmAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a container of napalm";
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Weapon Data
//------------------------------------------------------------------------------

datablock ItemData(NapalmMortar)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_mortar.dts";
   image = NapalmMortarImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a napalm mortar";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(NapalmMortarImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = NapalmMortar;
   ammo = NapalmAmmo;
   offset = "0 0 0";
   emap = true;
   
   minRankPoints = 6000;

   projectile = NapalmMortarShot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MortarSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateSequence[3] = "Recoil";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.8;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateSound[3] = MortarFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 5.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MortarReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = MortarDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};
