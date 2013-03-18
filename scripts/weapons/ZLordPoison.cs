datablock ParticleData(ZAcidBallParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.5;
   inheritedVelFactor   = 0.5;

   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 200;

   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName          = "special/bubbles";

   colors[0]     = "0.0 1.0 0.5 0.3";
   colors[1]     = "0.0 1.0 0.4 0.2";
   colors[2]     = "0.0 1.0 0.3 0.1";

   sizes[0]      = 0.6;
   sizes[1]      = 0.3;
   sizes[2]      = 0.1;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(ZAcidBallExplosionEmitter)
{
   lifetimeMS       = 200;

   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 3.0;
   velocityVariance = 0.5;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   orientParticles  = false;
   orientOnVelocity = false;

   particles = "ZAcidBallParticle";
};

datablock ExplosionData(ZAcidBallExplosion)
{
   emitter[0]   = ZAcidBallExplosionEmitter;
   soundProfile = ZlordAcidBoomSound;
};

datablock TracerProjectileData(LZombieAcidBall)
{
   doDynamicClientHits = true;

   projectileShapeName = "";
   directDamage        = 0.0;
   directDamageType    = $DamageType::ZAcid;
   hasDamageRadius     = true;
   indirectDamage      = 0.24;
   damageRadius        = 4.0;
   kickBackStrength    = 0.0;
   radiusDamageType    = $DamageType::ZAcid;
   sound          	   = BlasterProjectileSound;
   explosion           = ZAcidBallExplosion;

   dryVelocity       = 100.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 4000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = -1;

   activateDelayMS = 100;

   tracerLength    = 5;
   tracerAlpha     = false;
   tracerMinPixels = 3;
   tracerColor     = "0 1 0 1";
	tracerTex[0]  	 = "special/landSpikeBolt";
	tracerTex[1]  	 = "special/landSpikeBoltCross";
	tracerWidth     = 0.5;
   crossSize       = 0.79;
   crossViewAng    = 0.990;
   renderCross     = true;
   emap = true;
};

datablock ShapeBaseImageData(LordAcidGunImage)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = LordAcidGun;

   projectile = LZombieAcidBall;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 55;
   minEnergy = 55;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ZlordAcidBoomSound;
   
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

datablock ItemData(LordAcidGun)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy.dts";
   image = LordAcidGunImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;

   pickupRadius = 2;
   pickUpName = "a zombie lord acid ability";
};
