//--------------------------------------------------------------------------
// Artillery Turret
//--------------------------------------------------------------------------

datablock ShockwaveData(artilleryShockwave)
{
   width = 6.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 50;
   acceleration = 20.0;
   lifetimeMS = 500;
   height = 3.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.6 1.0 0.2 0.50";
   colors[1] = "0.56 0.36 0.26 1.0";
   colors[2] = "0.56 0.36 0.26 0.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};


datablock ParticleData(artilleryExplosionSmoke)
{
   dragCoeffiecient     = 6.0;
   gravityCoefficient   = 0.25;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 200;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.2 0.2 0.2 0.6";
   colors[1]     = "0.25 0.25 0.25 0.4";
   colors[2]     = "0.4 0.4 0.4 0.0";
   sizes[0]      = 5.0;
   sizes[1]      = 8.0;
   sizes[2]      = 15.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleData(artilleryFallerSmoke)
{
   dragCoeffiecient     = 0.7;
   gravityCoefficient   = 2.0;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 6000;
   lifetimeVarianceMS   = 750;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "1.0 0.8 0.1 0.6";
   colors[1]     = "0.3 0.3 0.3 0.6";
   colors[2]     = "0.3 0.3 0.3 0.6";
   colors[3]     = "0.35 0.35 0.35 0.3";
   colors[4]     = "0.4 0.4 0.4 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 6.0;
   sizes[2]      = 7.0;
   sizes[3]      = 10.0;
   sizes[4]      = 15.0;
   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.25;
   times[3]      = 0.5;
   times[4]      = 0.75;
};

datablock ParticleEmitterData(artilleryExplosionSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;


   ejectionVelocity = 15.0;
   velocityVariance = 10.0;

   thetaMin         = 89.0;
   thetaMax         = 90.0;

   lifetimeMS       = 500;

   particles = "artilleryExplosionSmoke";

};

datablock ParticleEmitterData(artilleryExplosionSmokeEmitter2)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 15.0;
   velocityVariance = 15.0;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   lifetimeMS       = 350;

   particles = "artilleryFallerSmoke";

};

datablock ParticleEmitterData(artilleryExplosionSmokeEmitter3)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 12.0;


   ejectionVelocity = 20.0;
   velocityVariance = 5.0;

   thetaMin         = 0.0;
   thetaMax         = 25.0;

   lifetimeMS       = 350;

   particles = "artilleryFallerSmoke";

};

datablock ExplosionData(artillerysubExplosion1)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;

   delayMS = 0;

   offset = 0.0;

   playSpeed = 0.6;

   sizes[0] = "10.0 10.0 10.0";
   sizes[1] = "15.0 15.0 15.0";
   times[0] = 0.0;
   times[1] = 1.0;

};

datablock ExplosionData(artillerybarrelExplosion)
{
   soundProfile   = MortarExplosionSound;

   shockwave = artilleryShockwave;
   shockwaveOnTerrain = true;

   subExplosion[0] = artillerysubExplosion1;

   emitter[0] = artilleryExplosionSmokeEmitter;
   emitter[1] = artilleryExplosionSmokeEmitter2;
   emitter[2] = artilleryExplosionSmokeEmitter3;

   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 40.0;
};




datablock GrenadeProjectileData(artillerybarrelshot)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 4.25;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 3000;

   explosion           = "artillerybarrelexplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.25;
   grenadeFriction   = 0.3;
   armingDelayMS     = 500;
   gravityMod        = 0.8;
   muzzleVelocity    = 65.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

//--------------------------------------------------------------------------
// artillery explosion
//--------------------------------------------------------------------------

datablock TurretImageData(ArtilleryBarrelLarge)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   item = artilleryBarrelLargePack;

   projectile = artillerybarrelshot;
   projectileType = GrenadeProjectile;
   usesEnergy = true;
   fireEnergy = 1;
   minEnergy = 1;
   emap = true;

   // Eolk - There should be no spread.
   muzzleFlash = ChaingunTurretMuzzleFlash;

   // Turret parameters
   activationMS = 300;
   deactivateDelayMS = 600;
   thinkTimeMS = 200;
   degPerSecTheta = 580;
   degPerSecPhi = 960;
   attackRadius = 370;

   // State transitions
   stateName[0] = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0] = "ActivateReady";

   stateName[1] = "ActivateReady";
   stateSequence[1] = "Activate";
   stateSound[1] = PBLSwitchSound;
   stateTimeoutValue[1] = 1;
   stateTransitionOnTimeout[1] = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNotLoaded[2] = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2] = "NoAmmo";

   // fire off about 2 quick shots
   stateName[3] = "Fire";
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateSound[3] = AssaultMortarFireSound;
   stateScript[3] = "onFire";
   stateTimeoutValue[3] = 3.0; //0.3
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Ready";
   // stateTransitionOnTriggerUp[3] = "Reload";
   stateTransitionOnNoAmmo[3] = "NoAmmo";

   stateName[8] = "Reload";
   stateTimeoutValue[7] = 5.0;
   stateAllowImageChange[8] = false;
   stateSequence[8] = "Reload";
   stateTransitionOnTimeout[8] = "Ready";
   stateTransitionOnNotLoaded[8] = "Deactivate";
   stateTransitionOnNoAmmo[8] = "NoAmmo";

   stateName[9] = "Deactivate";
   stateSequence[9] = "Activate";
   stateDirection[9] = false;
   stateTimeoutValue[9] = 1;
   stateTransitionOnLoaded[9] = "ActivateReady";
   stateTransitionOnTimeout[9] = "Dead";

   stateName[10] = "Dead";
   stateTransitionOnLoaded[10] = "ActivateReady";

   stateName[11] = "NoAmmo";
   stateTransitionOnAmmo[11] = "Reload";
   stateSequence[11] = "NoAmmo";
};
