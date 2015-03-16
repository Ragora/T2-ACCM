//--------------------------------------
// Flak Turret - Created by Dondelium_X, Greatly Modified by Blnukem
//--------------------------------------

//--------------------------------------------------------------------------
// Sounds and feedback effects
//--------------------------------------

datablock EffectProfile(AASwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(AAFireEffect)
{
   effectname = "weapons/chaingun_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(AASwitchSound)
{
   filename    = "fx/powered/turret_aa_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = AASwitchEffect;
};

datablock AudioProfile(AAFireSound)
{
   filename    = "fx/weapons/plasma_rifle_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AAFireEffect;
};

//--------------------------------------------------------------------------
// Particle effects
//--------------------------------------
datablock ParticleData(FlakDust)
{
   dragCoefficient      = 1.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.3 0.3 0.3 0.5";
   colors[1]     = "0.3 0.3 0.3 0.5";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 6.6;
   sizes[1]      = 10.8;
   sizes[2]      = 12.0;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(FlakDustEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 20.0;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 88;
   thetaMax         = 92;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "FlakDust";
};


datablock ParticleData(FlakExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.7 0.7 0.7 1.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.1 0.1 0.1 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 13.0;
   sizes[2]      = 4.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FExplosionSmokeEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 6.25;
   velocityVariance = 0.25;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 200;

   particles = "FlakExplosionSmoke";
};

datablock ParticleData(FlakSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 650;
   textureName          = "special/bigspark";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 3.0;
   sizes[2]      = 4.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FlakSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 15;
   velocityVariance = 5.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "FlakSparks";
};

datablock ParticleData(FlakFlashSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 250;
   lifetimeVarianceMS   = 650;
   textureName          = "special/bigspark";
   colors[0]     = "1.0 0.2 0.2 1.0";
   colors[1]     = "0.7 0.7 0.2 1.0";
   colors[2]     = "0.5 0.5 0.1 0.0";
   sizes[0]      = 4.0;
   sizes[1]      = 5.0;
   sizes[2]      = 6.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(FlakFlashSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 25;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "FlakFlashSparks";
};

//----------------------------------------------------
//  Explosion
//----------------------------------------------------
datablock ExplosionData(FlakExplosion)
{
   soundProfile   = GrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "1.0 1.0 1.0";

   emitter[0] = FlakDustEmitter;
   emitter[1] = FExplosionSmokeEmitter;
   emitter[2] = FlakSparksEmitter;
   emitter[3] = FlakFlashSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 20.0;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(Flak_Bullet)
{
    doDynamicClientHits = true;

   directDamage        = 0.3;
   directDamageType    = $DamageType::AATurret;
   explosion           = FlakExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.15;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Flak;

   kickBackStrength  = 15;
   sound             = ChaingunProjectile;

   dryVelocity               = 600.0;
   wetVelocity               = 200.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 3000;
   lifetimeMS                = 2000;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.35;
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

datablock TracerProjectileData(Flak_Bullet_exp)
{
   doDynamicClientHits = true;

   directDamage        = 0.3;
   directDamageType    = $DamageType::AATurret;
   explosion           = FlakExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.15;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Flak;

   kickBackStrength  = 150;
   sound             = ChaingunProjectile;

   dryVelocity               = 0.0;
   wetVelocity               = 0.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 3000;
   lifetimeMS                = 10;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 0.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.35;
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
// Weapon
//--------------------------------------
datablock TurretImageData(AABarrelLarge)
{
   shapeFile = "turret_aa_large.dts";
   item      = AABarrelPack; // z0dd - ZOD, 4/25/02. Was wrong: AABarrelLargePack

   projectileType = TracerProjectile;
   projectile = Flak_Bullet;
   projectileSpread = 25.0 / 1000.0;
   usesEnergy = true;
   fireEnergy = 1.0;
   minEnergy = 1.0;
   emap = true;
   isSeeker = true;
   seekRadius   = 300;
   maxSeekAngle = 6;
   seekTime     = 1.0;
   minSeekHeat  = 0.6;
   useTargetAudio = false;

   // Turret parameters
   activationMS         = 175; // z0dd - ZOD, 3/27/02. Was 250. Amount of time it takes turret to unfold
   deactivateDelayMS    = 500;
   thinkTimeMS          = 140; // z0dd - ZOD, 3/27/02. Was 200. Amount of time before turret starts to unfold (activate)
   degPerSecTheta       = 600;
   degPerSecPhi         = 1080;
   attackRadius         = 1000;

   // State transitions
   stateName[0]                     = "Activate";
   stateTransitionOnNotLoaded[0]    = "Dead";
   stateTransitionOnLoaded[0]       = "ActivateReady";

   stateName[1]                     = "ActivateReady";
   stateSequence[1]                 = "Activate";
   stateSound[1]                    = AASwitchSound;
   stateTimeoutValue[1]             = 1.0;
   stateTransitionOnTimeout[1]      = "Ready";
   stateTransitionOnNotLoaded[1]    = "Deactivate";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";
   stateScript[1]                   = "AAActivateReady";

   stateName[2]                     = "Ready";
   stateTransitionOnNotLoaded[2]    = "Deactivate";
   stateTransitionOnTriggerDown[2]  = "Fire1";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateScript[2]                   = "AAReady";

   stateName[3]                     = "Fire1";
   stateTransitionOnTimeout[3]      = "Reload1";
   stateTimeoutValue[3]             = 1.00;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire1";
   stateSound[3]                    = AAFireSound;
   stateScript[3]                   = "onFire";

   stateName[4]                     = "Reload1";
   stateTimeoutValue[4]             = 0.08;
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateTransitionOnTimeout[4]      = "Fire2";
   stateTransitionOnNotLoaded[4]    = "Deactivate";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";

   stateName[5]                     = "Fire2";
   stateTransitionOnTimeout[5]      = "Reload2";
   stateTimeoutValue[5]             = 1.00;
   stateFire[5]                     = true;
   stateRecoil[5]                   = LightRecoil;
   stateAllowImageChange[5]         = false;
   stateSequence[5]                 = "Fire2";
   stateSound[5]                    = AAFireSound;
   stateScript[5]                   = "onFire";

   stateName[6]                     = "Reload2";
   stateTimeoutValue[6]             = 0.08;
   stateAllowImageChange[6]         = false;
   stateSequence[6]                 = "Reload";
   stateTransitionOnTimeout[6]      = "Ready";
   stateTransitionOnNotLoaded[6]    = "Deactivate";
   stateTransitionOnNoAmmo[6]       = "NoAmmo";

   stateName[7]                     = "Deactivate";
   stateSequence[7]                 = "Activate";
   stateDirection[7]                = false;
   stateTimeoutValue[7]             = 1.0;
   stateTransitionOnLoaded[7]       = "ActivateReady";
   stateTransitionOnTimeout[7]      = "Dead";

   stateName[8]                    = "Dead";
   stateTransitionOnLoaded[8]      = "ActivateReady";

   stateName[9]                    = "NoAmmo";
   stateTransitionOnAmmo[9]        = "Reload2";
   stateSequence[9]                = "NoAmmo";
};

function AABarrelLarge::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.doexplodecheck = schedule(250, 0, "TurretFlakExplode", %p);
}

function TurretFlakExplode(%p){
   if(!isObject(%p))
	return;
   InitContainerRadiusSearch(%p.getPosition(), 25, $TypeMasks::VehicleObjectType);
   while ((%SearchResult = containerSearchNext()) != 0)
   {
	%pn = new (TracerProjectile)() {
	   dataBlock        = Flak_Bullet_exp;
	   initialPosition  = %p.getPosition();
	   sourceObject     = %p.sourceObject;
	   sourceSlot       = %p.sourceSlot;
	   vehicleObject    = %p.vehicleObject;
	};
	MissionCleanup.add(%pn);
	%p.delete();
	return;
   }
   %p.doexplodecheck = schedule(30, 0, "TurretFlakExplode", %p);
}

