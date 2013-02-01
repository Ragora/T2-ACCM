$Bomber::SeekRadius = 500; 
$Bomber::SeekTime = 0.25; 
$Bomber::minSeekHeat = 0.6; 
$Bomber::minTargetingDistance = 15; 
$Bomber::useTargetAudio = true; 

//**************************************************************
// Shrikes/Apaches/Scouts
//**************************************************************

datablock ParticleData(VehicleBoomSmoke)
{
   dragCoeffiecient     = 0.2;
   gravityCoefficient   = -0.25;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 4000;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "1.0 0.7 0.5 1.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 8.0;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(VehicleBoomSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 10.0;
   velocityVariance = 0.25;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 150;

   particles = "VehicleBoomSmoke";
};

datablock ParticleData(MeDebrisFireParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.2;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 350;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha = false;
   spinRandomMin = -160.0;
   spinRandomMax = 160.0;

   animateTexture = true;
   framesPerSec = 15;


   animTexName[0]       = "special/Explosion/exp_0016";
   animTexName[1]       = "special/Explosion/exp_0018";
   animTexName[2]       = "special/Explosion/exp_0020";
   animTexName[3]       = "special/Explosion/exp_0022";
   animTexName[4]       = "special/Explosion/exp_0024";
   animTexName[5]       = "special/Explosion/exp_0026";
   animTexName[6]       = "special/Explosion/exp_0028";
   animTexName[7]       = "special/Explosion/exp_0030";
   animTexName[8]       = "special/Explosion/exp_0032";

   colors[0]     = "1.0 0.7 0.5 1.0";
   colors[1]     = "1.0 0.5 0.2 1.0";
   colors[2]     = "1.0 0.25 0.1 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1.5;
   sizes[2]      = 0.7;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MeDebrisFireEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 1;

   ejectionVelocity = 0.25;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 175.0;

   particles = "MeDebrisFireParticle";
};

datablock ParticleData( MeDebrisSmokeParticle )
{
   dragCoeffiecient     = 4.0;
   gravityCoefficient   = -0.00;   // rises slowly
   inheritedVelFactor   = 0.2;

   lifetimeMS           = 2500;  
   lifetimeVarianceMS   = 100;   // ...more or less

   textureName          = "particleTest";

   useInvAlpha =     true;

   spinRandomMin = -50.0;
   spinRandomMax = 50.0;

   colors[0]     = "0.3 0.3 0.3 0.0";
   colors[1]     = "0.2 0.2 0.2 1.0";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 2;
   sizes[1]      = 3.0;
   sizes[2]      = 4.5;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( MeDebrisSmokeEmitter )
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 2;

   ejectionVelocity = 1.0;  // A little oomph at the back end
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 15.0;

   useEmitterSizes = true;

   particles = "MeDebrisSmokeParticle";
};

datablock DebrisData( MeVehicleFireballDebris )
{
   emitters[0] = MeDebrisSmokeEmitter;
   emitters[1] = MeDebrisFireEmitter;

   explosion = DebrisExplosion;
   explodeOnMaxBounce = true;

   elasticity = 0.4;
   friction = 0.2;

   lifetime = 100.0;
   lifetimeVariance = 30.0;

   numBounces = 0;
   bounceVariance = 0;
};

datablock DebrisData( MeVSpikeDebris )
{
   emitters[0] = VSmokeSpikeEmitter;

   explodeOnMaxBounce = true;

   elasticity = 0.4;
   friction = 0.2;

   lifetime = 0.3;
   lifetimeVariance = 0.02;
};

datablock ExplosionData(MeVSpikeExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.75;
   sizes[0] = "5.0 5.0 5.0";
   sizes[1] = "5.0 5.0 5.0";
   times[0] = 0.0;
   times[1] = 1.0;

   debris = MeVSpikeDebris;
   debrisThetaMin = 10;
   debrisThetaMax = 175;
   debrisNum = 5;
   debrisNumVariance = 3;
   debrisVelocity = 30.0;
   debrisVelocityVariance = 7.0;
};

datablock ExplosionData(MeVehicleExplosion)
{
   explosionShape = "disc_explosion.dts";
   playSpeed = 1.5;
   soundProfile = VehicleExplosionSound;
   faceViewer = true;

   emitter[0] = VehicleBoomSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 90;
   debrisNum = 20;
   debrisNumVariance = 5;
   debrisVelocity = 25.0;
   debrisVelocityVariance = 2.0;

   subExplosion = MeVSpikeExplosion;

   shakeCamera = true;
   camShakeFreq = "11.0 13.0 9.0";
   camShakeAmp = "40.0 40.0 40.0";
   camShakeDuration = 0.7;
   camShakeRadius = 25.0;
};

datablock ParticleData(MeHeavyDamageSmokeParticle)
{
   dragCoefficient      = 0.4;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 200;
   useInvAlpha          = true;
   spinRandomMin        = -60.0;
   spinRandomMax        = 60.0;
   textureName          = "particleTest";
   colors[0]     = "1.0 0.4 0.2 1.0";
   colors[1]     = "1.0 0.8 0.2 0.8";
   colors[2]     = "0.1 0.1 0.1 0.3";
   colors[3]     = "0.2 0.2 0.2 0.15";
   colors[4]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 3.0;
   sizes[2]      = 4.5;
   sizes[3]      = 5.0;
   sizes[4]      = 8.0;
   times[0]      = 0.0;
   times[1]      = 0.05;
   times[2]      = 0.15;
   times[3]      = 0.4;
   times[4]      = 1.0;
};

datablock ParticleEmitterData(MeHeavyDamageSmoke)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 2;
   ejectionVelocity = 3.0;
   velocityVariance = 0.5;
   ejectionOffset   = 1.5;
   thetaMin         = 0;
   thetaMax         = 180;
   overrideAdvances = false;
   particles = "MeHeavyDamageSmokeParticle";
};

datablock ParticleData(MeLightDamageSmokeParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 4000;
   lifetimeVarianceMS   = 200;
   useInvAlpha          = true;
   spinRandomMin        = -45.0;
   spinRandomMax        = 45.0;
   textureName          = "particleTest";
   colors[0]     = "0.1 0.1 0.1 0.5";
   colors[1]     = "0.2 0.2 0.2 0.7";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 1.5;
   sizes[1]      = 3.0;
   sizes[2]      = 4.0;
   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MeLightDamageSmoke)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 6;
   ejectionVelocity = 4.0;
   velocityVariance = 0.5;
   ejectionOffset   = 1.5;
   thetaMin         = 0;
   thetaMax         = 180;
   overrideAdvances = false;
   particles = "MeLightDamageSmokeParticle";
};

datablock ParticleData(MeDamageBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.04;
   inheritedVelFactor   = 0.5;
   constantAcceleration = 0.0;
   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 200;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   textureName          = "special/bubbles";
   colors[0]     = "0.7 0.7 0.7 0.0";
   colors[1]     = "0.3 0.3 0.3 1.0";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 0.4;
   sizes[1]      = 1.6;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(MeDamageBubbles)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 35;
   overrideAdvances = false;
   particles = "MeDamageBubbleParticle";
};

datablock DebrisData( MeShapeDebris )
{
   explodeOnMaxBounce = false;

   elasticity = 0.1;
   friction = 0.5;

   lifetime = 25.0;
   lifetimeVariance = 0.0;

   minSpinSpeed = 0;
   maxSpinSpeed = 25;

   numBounces = 10;
   bounceVariance = 0;

   staticOnMaxBounce = true;

   useRadiusMass = true;
   baseRadius = 1.0;

   velocity = 17.0;
   velocityVariance = 7.0;  
};

datablock DebrisData( GShapeDebris )
{
   explodeOnMaxBounce = false;

   elasticity = 0.0;
   friction = 0.5;

   lifetime = 25.0;
   lifetimeVariance = 0.0;

   minSpinSpeed = 0;
   maxSpinSpeed = 5;

   numBounces = 10;
   bounceVariance = 0;

   staticOnMaxBounce = true;

   useRadiusMass = true;
   baseRadius = 1.0;

   velocity = 0.0;
   velocityVariance = 0.0;  
};

//**************************************************************
// Bombers/Havocs/Blackhawks
//**************************************************************

datablock ExplosionData(MFVSubExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.65;
   sizes[0] = "8.0 8.0 8.0";
   sizes[1] = "8.0 8.0 8.0";
   times[0] = 0.0;
   times[1] = 1.0;

   debris = MeVSpikeDebris;
   debrisThetaMin = 10;
   debrisThetaMax = 175;
   debrisNum = 5;
   debrisNumVariance = 3;
   debrisVelocity = 30.0;
   debrisVelocityVariance = 7.0;
};

datablock ExplosionData(MFVehicleExplosion)
{
   explosionShape = "disc_explosion.dts";
   playSpeed = 1.5;
   soundProfile = VehicleExplosionSound;
   faceViewer = true;

   emitter[0] = VehicleBoomSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 35;
   debrisThetaMax = 95;
   debrisNum = 25;
   debrisNumVariance = 5;
   debrisVelocity = 20.0;
   debrisVelocityVariance = 5.0;

   subExplosion = MFVSubExplosion;

   shakeCamera = true;
   camShakeFreq = "11.0 13.0 9.0";
   camShakeAmp = "40.0 40.0 40.0";
   camShakeDuration = 0.7;
   camShakeRadius = 35.0;
};

datablock ParticleEmitterData(MFHeavyDamageSmoke)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 2;
   ejectionVelocity = 5.0;
   velocityVariance = 1.0;
   ejectionOffset   = 2.5;
   thetaMin         = 0;
   thetaMax         = 180;
   overrideAdvances = false;
   particles = "MeHeavyDamageSmokeParticle";
};

datablock ParticleEmitterData(MFLightDamageSmoke)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 6;
   ejectionVelocity = 5.0;
   velocityVariance = 1.0;
   ejectionOffset   = 2.0;
   thetaMin         = 0;
   thetaMax         = 180;
   overrideAdvances = false;
   particles = "MeLightDamageSmokeParticle";
};

//**************************************************************
// Tanks/APC/MPB
//**************************************************************

datablock ParticleEmitterData(MeHGHeavyDamageSmoke)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 2;
   ejectionVelocity = 3.0;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 135;
   overrideAdvances = false;
   particles = "MeLightDamageSmokeParticle";
};

datablock ParticleData(HGVExplosionSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = 0.0;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 2000;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "1.0 0.7 0.0 1.0";
   colors[1]     = "0.2 0.2 0.2 0.5";
   colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = 5.0;
   sizes[1]      = 10.0;
   sizes[2]      = 12.0;
   times[0]      = 0.0;
   times[1]      = 0.4;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(HGVExplosionSmokeEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionVelocity = 20.0;
   velocityVariance = 4.0;

   thetaMin         = 70.0;
   thetaMax         = 110.0;

   lifetimeMS       = 150;

   particles = "HGVExplosionSmoke";
};

datablock ExplosionData(HGVSubExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   lifetimeMS = 3000;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.5;

   sizes[0] = "8.0 8.0 8.0";
   sizes[1] = "8.0 8.0 8.0";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = VehicleBoomSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 90;
   debrisNum = 10;
   debrisNumVariance = 5;
   debrisVelocity = 10.0;
   debrisVelocityVariance = 9.0;
};

datablock ExplosionData(HGVSubExplosion2)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   lifetimeMS = 3000;
   delayMS = 200;
   offset = 8.0;
   playSpeed = 0.75;

   sizes[0] = "4.0 4.0 4.0";
   sizes[1] = "4.0 4.0 4.0";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = HGVExplosionSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 120;
   debrisNum = 5;
   debrisNumVariance = 2;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 5.0;
};

datablock ExplosionData(HGVSubExplosion3)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   lifetimeMS = 3000;
   delayMS = 400;
   offset = 12.0;
   playSpeed = 0.8;

   sizes[0] = "3.5 3.5 3.5";
   sizes[1] = "3.5 3.5 3.5";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = HGVExplosionSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 120;
   debrisNum = 5;
   debrisNumVariance = 2;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 5.0;
};

datablock ExplosionData(HGVSubExplosion4)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   lifetimeMS = 3000;
   delayMS = 600;
   offset = 15.0;
   playSpeed = 0.8;

   sizes[0] = "3.0 3.0 3.0";
   sizes[1] = "3.0 3.0 3.0";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = HGVExplosionSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 120;
   debrisNum = 5;
   debrisNumVariance = 2;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 5.0;
};

datablock ExplosionData(HGVSubExplosion5)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer           = true;
   lifetimeMS = 3000;
   delayMS = 900;
   offset = 20.0;
   playSpeed = 0.4;

   sizes[0] = "5.0 5.0 5.0";
   sizes[1] = "5.0 5.0 5.0";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = VehicleBoomSmokeEmitter;

   debris = MeVehicleFireballDebris;
   debrisThetaMin = 0;
   debrisThetaMax = 90;
   debrisNum = 10;
   debrisNumVariance = 0;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 5.0;
};

datablock ExplosionData(HGVehicleExplosion)
{
   soundProfile = VehicleExplosionSound;

   subExplosion[0] = HGVSubExplosion;
   subExplosion[1] = HGVSubExplosion2;
   subExplosion[2] = HGVSubExplosion3;
   subExplosion[3] = HGVSubExplosion4;
   subExplosion[4] = HGVSubExplosion5;

   shakeCamera = true;
   camShakeFreq = "11.0 13.0 9.0";
   camShakeAmp = "40.0 40.0 40.0";
   camShakeDuration = 1.0;
   camShakeRadius = 40.0;
};