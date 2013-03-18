//--------------------------------------------------------------------------
// Sniper rifle
// 
// 
//--------------------------------------------------------------------------

datablock AudioProfile(LaserRifleFireSound)
{
   filename    = "fx/weapons/cg_hard1.wav";
   description = AudioClose3d;
   preload = true;
   effect = SniperRifleFireEffect;
};

//--------------------------------------------------------------------------
// Splash
//--------------------------------------------------------------------------
datablock ParticleData( LaserSplashParticle )
{

   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.03;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 600;
   lifetimeVarianceMS   = 300;

   textureName          = "particleTest";

   useInvAlpha =  false;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;


   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.0;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( LaserSplashEmitter )
{
   ejectionPeriodMS = 25;
   ejectionOffset = 0.2;
   periodVarianceMS = 0;
   ejectionVelocity = 2.25;
   velocityVariance = 0.50;
   thetaMin         = 0.0;
   thetaMax         = 30.0;
   lifetimeMS       = 250;

   particles = "LaserSplashParticle";
};

datablock SplashData( LaserSplash )
{
   numSegments = 5;
   ejectionFreq = 0.0001;
   ejectionAngle = 45;
   ringLifetime = 0.5;
   lifetimeMS = 400;
   velocity = 5.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = SniperSplashEmitter;

   colors[0] = "0.7 0.8 1.0 0.0";
   colors[1] = "0.7 0.8 1.0 1.0";
   colors[2] = "0.7 0.8 1.0 0.0";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

//--------------------------------------------------------------------------
// Explosion
//--------------------------------------
datablock AudioProfile(sniperExpSound)
{
   filename    = "fx/weapons/sniper_impact.WAV";
   description = AudioClosest3d;
   preload = true;
};

datablock ParticleData(LaserExplosionParticle1)
{
   dragCoefficient      = 0.65;
   gravityCoefficient   = 0.3;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 150;
   textureName          = "particleTest";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 0.0";
   sizes[0]      = 0.0625;
   sizes[1]      = 0.2;
};

datablock ParticleEmitterData(LaserExplosionEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 0.75;
   velocityVariance = 0.25;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "LaserExplosionParticle1";
};

datablock ExplosionData(LaserExplosion)
{
   explosionShape = "energy_explosion.dts";
   soundProfile   = sniperExpSound;

   particleEmitter = LaserExplosionEmitter;
   particleDensity = 150;
   particleRadius = 0.25;

   faceViewer           = false;
};


//--------------------------------------
// Projectile
//--------------------------------------
datablock SniperProjectileData(PulseLaserShot)
{
   directDamage        = 0.0;
   hasDamageRadius     = false;
   indirectDamage      = 0.0;
   damageRadius        = 0.0;
   velInheritFactor    = 1.0;
   sound 				  = LaserProjectileSound;
   explosion           = "LaserExplosion";
   splash              = LaserSplash;
   directDamageType    = $DamageType::PulseLaser;

   maxRifleRange       = 1000;
   rifleHeadMultiplier = 1.3;
   beamColor           = "1 0.1 0.1";
   fadeTime            = 1.0;

   startBeamWidth		  = 0.145;
   endBeamWidth 	     = 0.25;
   pulseBeamWidth 	  = 0.5;
   beamFlareAngle 	  = 3.0;
   minFlareSize        = 0.0;
   maxFlareSize        = 400.0;
   pulseSpeed          = 6.0;
   pulseLength         = 0.150;

   lightRadius         = 1.0;
   lightColor          = "0.3 0.0 0.0";

   textureName[0]      = "special/flare";
   textureName[1]      = "special/nonlingradient";
   textureName[2]      = "special/laserrip01";
   textureName[3]      = "special/laserrip02";
   textureName[4]      = "special/laserrip03";
   textureName[5]      = "special/laserrip04";
   textureName[6]      = "special/laserrip05";
   textureName[7]      = "special/laserrip06";
   textureName[8]      = "special/laserrip07";
   textureName[9]      = "special/laserrip08";
   textureName[10]     = "special/laserrip09";
   textureName[11]     = "special/sniper00";

};


//--------------------------------------
// Rifle and item...
//--------------------------------------
datablock ItemData(LaserRifle)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_sniper.dts";
   image        = SniperRifleImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a pulse laser rifle";

   computeCRC = true;

};

datablock ShapeBaseImageData(LaserRifleImage)
{
	className = WeaponImage;
   shapeFile = "weapon_targeting.dts";
   item = LaserRifle;
   projectile = PulseLaserShot;
   projectileType = SniperProjectile;
	armThread = looksn;

	usesEnergy = true;
	minEnergy = 6;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateSound[0]                    = GenericSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";
   stateSound[3]                    = LaserRifleFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.5;
   stateAllowImageChange[4]         = false;

   stateName[5]                     = "CheckWet";
   stateTransitionOnWet[5]          = "DryFire";
   stateTransitionOnNotWet[5]       = "Fire";
   
   stateName[6]                     = "NoAmmo";
   stateTransitionOnAmmo[6]         = "Reload";
   stateTransitionOnTriggerDown[6]  = "DryFire";
   stateSequence[6]                 = "NoAmmo";
   
   stateName[7]                     = "DryFire";
   stateSound[7]                    = SniperRifleDryFireSound;
   stateTimeoutValue[7]             = 0.5;
   stateTransitionOnTimeout[7]      = "Ready";
};

