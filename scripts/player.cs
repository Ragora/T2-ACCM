//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

$InvincibleTime = 3;

// Load dts shapes and merge animations
exec("scripts/light_male.cs");
exec("scripts/medium_male.cs");
exec("scripts/heavy_male.cs");
exec("scripts/light_female.cs");
exec("scripts/medium_female.cs");
exec("scripts/bioderm_light.cs");
exec("scripts/bioderm_medium.cs");
exec("scripts/bioderm_heavy.cs");
exec("scripts/TR2medium_male.cs");

$CorpseTimeoutValue = 22 * 1000;

//Damage Rate for entering Liquid
$DamageLava       = 0.0325;
$DamageHotLava    = 0.0325;
$DamageCrustyLava = 0.0325;

$PlayerDeathAnim::TorsoFrontFallForward = 1;
$PlayerDeathAnim::TorsoFrontFallBack = 2;
$PlayerDeathAnim::TorsoBackFallForward = 3;
$PlayerDeathAnim::TorsoLeftSpinDeath = 4;
$PlayerDeathAnim::TorsoRightSpinDeath = 5;
$PlayerDeathAnim::LegsLeftGimp = 6;
$PlayerDeathAnim::LegsRightGimp = 7;
$PlayerDeathAnim::TorsoBackFallForward = 8;
$PlayerDeathAnim::HeadFrontDirect = 9;
$PlayerDeathAnim::HeadBackFallForward = 10;
$PlayerDeathAnim::ExplosionBlowBack = 11;

//$Zombie::TurningSpeed = 100;
$Zombie::ForwardSpeed = 750; 
$Zombie::FForwardSpeed = 1500; 
$Zombie::LForwardSpeed = 4000; 
$Zombie::DForwardSpeed = 1200; 
$Zombie::RForwardSpeed = 1500;

datablock SensorData(PlayerSensor)
{
   detects = false;
};

//----------------------------------------------------------------------------

datablock EffectProfile(ArmorJetEffect)
{
   effectname = "armor/thrust";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ImpactSoftEffect)
{
   effectname = "armor/light_land_soft";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ImpactHardEffect)
{
   effectname = "armor/light_land_hard";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ImpactMetalEffect)
{
   effectname = "armor/light_land_metal";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ImpactSnowEffect)
{
   effectname = "armor/light_land_snow";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(CorpseLootingEffect)
{
   effectname = "weapons/generic_switch";
   minDistance = 2.5;
	maxDistance = 2.5;
};

datablock EffectProfile(MountVehicleEffect)
{
   effectname = "vehicles/mount_dis";
   minDistance = 5;
   maxDistance = 20;
};

datablock EffectProfile(UnmountVehicleEffect)
{
   effectname = "weapons/generic_switch";
   minDistance = 5;
   maxDistance = 20;
};

datablock EffectProfile(GenericPainEffect)
{
   effectname = "misc/generic_pain";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(GenericDeathEffect)
{
   effectname = "misc/generic_death";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock EffectProfile(ImpactHeavyWaterEasyEffect)
{
   effectname = "armor/general_water_smallsplash";
   minDistance = 5;
   maxDistance = 15;
};

datablock EffectProfile(ImpactHeavyMediumWaterEffect)
{
   effectname = "armor/general_water_medsplash";
   minDistance = 5;
   maxDistance = 15;
};

datablock EffectProfile(ImpactHeavyWaterHardEffect)
{
   effectname = "armor/general_water_bigsplash";
   minDistance = 5;
   maxDistance = 15;
};

//----------------------------------------------------------------------------
//datablock AudioProfile( DeathCrySound )
//{
//   fileName = "";
//   description = AudioClose3d;
//   preload = true;
//};
//
//datablock AudioProfile( PainCrySound )
//{
//   fileName = "";
//   description = AudioClose3d;
//   preload = true;
//};

datablock AudioProfile(ArmorJetSound)
{
   filename    = "fx/armor/thrust.wav";
   description = CloseLooping3d;
   preload = true;
   effect = ArmorJetEffect;
};

datablock AudioProfile(ArmorWetJetSound)
{
   filename    = "fx/armor/thrust_uw.wav";
   description = CloseLooping3d;
   preload = true;
   effect = ArmorJetEffect;
};

datablock AudioProfile(MountVehicleSound)
{
   filename    = "fx/vehicles/mount_dis.wav";
   description = AudioClose3d;
   preload = true;
   effect = MountVehicleEffect;
};

datablock AudioProfile(UnmountVehicleSound)
{
   filename    = "fx/vehicles/mount.wav";
   description = AudioClose3d;
   preload = true;
   effect = UnmountVehicleEffect;
};

datablock AudioProfile(CorpseLootingSound)
{
   fileName = "fx/weapons/generic_switch.wav";
   description = AudioClosest3d;
   preload = true;
   effect = CorpseLootingEffect;
};

datablock AudioProfile(ArmorMoveBubblesSound)
{
   filename    = "fx/armor/bubbletrail2.wav";
   description = CloseLooping3d;
   preload = true;
};

datablock AudioProfile(WaterBreathMaleSound)
{
   filename    = "fx/armor/breath_uw.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(WaterBreathFemaleSound)
{
   filename    = "fx/armor/breath_fem_uw.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(waterBreathBiodermSound)
{
   filename    = "fx/armor/breath_bio_uw.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(SkiAllSoftSound)
{
   filename    = "fx/armor/ski_soft.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SkiAllHardSound)
{
   filename    = "fx/armor/ski_soft.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SkiAllMetalSound)
{
   filename    = "fx/armor/ski_soft.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SkiAllSnowSound)
{
   filename    = "fx/armor/ski_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

//SOUNDS ----- LIGHT ARMOR--------
datablock AudioProfile(LFootLightSoftSound)
{
   filename    = "fx/armor/light_LF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootLightSoftSound)
{
   filename    = "fx/armor/light_RF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootLightHardSound)
{
   filename    = "fx/armor/light_LF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootLightHardSound)
{
   filename    = "fx/armor/light_RF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootLightMetalSound)
{
   filename    = "fx/armor/light_LF_metal.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootLightMetalSound)
{
   filename    = "fx/armor/light_RF_metal.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(LFootLightSnowSound)
{
   filename    = "fx/armor/light_LF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootLightSnowSound)
{
   filename    = "fx/armor/light_RF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootLightShallowSplashSound)
{
   filename    = "fx/armor/light_LF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootLightShallowSplashSound)
{
   filename    = "fx/armor/light_RF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootLightWadingSound)
{
   filename    = "fx/armor/light_LF_wade.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootLightWadingSound)
{
   filename    = "fx/armor/light_RF_wade.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootLightUnderwaterSound)
{
   filename    = "fx/armor/light_LF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootLightUnderwaterSound)
{
   filename    = "fx/armor/light_RF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootLightBubblesSound)
{
   filename    = "fx/armor/light_LF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootLightBubblesSound)
{
   filename    = "fx/armor/light_RF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactLightSoftSound)
{
   filename    = "fx/armor/light_land_soft.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactSoftEffect;
};

datablock AudioProfile(ImpactLightHardSound)
{
   filename    = "fx/armor/light_land_hard.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactHardEffect;
};

datablock AudioProfile(ImpactLightMetalSound)
{
   filename    = "fx/armor/light_land_metal.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactMetalEffect;
};

datablock AudioProfile(ImpactLightSnowSound)
{
   filename    = "fx/armor/light_land_snow.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ImpactSnowEffect;
};

datablock AudioProfile(ImpactLightWaterEasySound)
{
   filename    = "fx/armor/general_water_smallsplash2.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactLightWaterMediumSound)
{
   filename    = "fx/armor/general_water_medsplash.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactLightWaterHardSound)
{
   filename    = "fx/armor/general_water_bigsplash.wav";
   description = AudioDefault3d;
   preload = true;
};

datablock AudioProfile(ExitingWaterLightSound)
{
   filename    = "fx/armor/general_water_exit2.wav";
   description = AudioClose3d;
   preload = true;
};

//SOUNDS ----- Medium ARMOR--------
datablock AudioProfile(LFootMediumSoftSound)
{
   filename    = "fx/armor/med_LF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootMediumSoftSound)
{
   filename    = "fx/armor/med_RF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootMediumHardSound)
{
   filename    = "fx/armor/med_LF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootMediumHardSound)
{
   filename    = "fx/armor/med_RF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootMediumMetalSound)
{
   filename    = "fx/armor/med_LF_metal.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootMediumMetalSound)
{
   filename    = "fx/armor/med_RF_metal.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(LFootMediumSnowSound)
{
   filename    = "fx/armor/med_LF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootMediumSnowSound)
{
   filename    = "fx/armor/med_RF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootMediumShallowSplashSound)
{
   filename    = "fx/armor/med_LF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootMediumShallowSplashSound)
{
   filename    = "fx/armor/med_RF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootMediumWadingSound)
{
   filename    = "fx/armor/med_LF_uw.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootMediumWadingSound)
{
   filename    = "fx/armor/med_RF_uw.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootMediumUnderwaterSound)
{
   filename    = "fx/armor/med_LF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootMediumUnderwaterSound)
{
   filename    = "fx/armor/med_RF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootMediumBubblesSound)
{
   filename    = "fx/armor/light_LF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootMediumBubblesSound)
{
   filename    = "fx/armor/light_RF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(ImpactMediumSoftSound)
{
   filename    = "fx/armor/med_land_soft.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ImpactSoftEffect;
};

datablock AudioProfile(ImpactMediumHardSound)
{
   filename    = "fx/armor/med_land_hard.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactHardEffect;
};

datablock AudioProfile(ImpactMediumMetalSound)
{
   filename    = "fx/armor/med_land_metal.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactMetalEffect;
};

datablock AudioProfile(ImpactMediumSnowSound)
{
   filename    = "fx/armor/med_land_snow.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ImpactSnowEffect;
};

datablock AudioProfile(ImpactMediumWaterEasySound)
{
   filename    = "fx/armor/general_water_smallsplash.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactMediumWaterMediumSound)
{
   filename    = "fx/armor/general_water_medsplash.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactMediumWaterHardSound)
{
   filename    = "fx/armor/general_water_bigsplash.wav";
   description = AudioDefault3d;
   preload = true;
};

datablock AudioProfile(ExitingWaterMediumSound)
{
   filename    = "fx/armor/general_water_exit.wav";
   description = AudioClose3d;
   preload = true;
};

//SOUNDS ----- HEAVY ARMOR--------
datablock AudioProfile(LFootHeavySoftSound)
{
   filename    = "fx/armor/heavy_LF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootHeavySoftSound)
{
   filename    = "fx/armor/heavy_RF_soft.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyHardSound)
{
   filename    = "fx/armor/heavy_LF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyHardSound)
{
   filename    = "fx/armor/heavy_RF_hard.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyMetalSound)
{
   filename    = "fx/armor/heavy_LF_metal.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyMetalSound)
{
   filename    = "fx/armor/heavy_RF_metal.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(LFootHeavySnowSound)
{
   filename    = "fx/armor/heavy_LF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootHeavySnowSound)
{
   filename    = "fx/armor/heavy_RF_snow.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyShallowSplashSound)
{
   filename    = "fx/armor/heavy_LF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyShallowSplashSound)
{
   filename    = "fx/armor/heavy_RF_water.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyWadingSound)
{
   filename    = "fx/armor/heavy_LF_uw.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyWadingSound)
{
   filename    = "fx/armor/heavy_RF_uw.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyUnderwaterSound)
{
   filename    = "fx/armor/heavy_LF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyUnderwaterSound)
{
   filename    = "fx/armor/heavy_RF_uw.wav";
   description = AudioClosest3d;
   preload = true;
};

datablock AudioProfile(LFootHeavyBubblesSound)
{
   filename    = "fx/armor/light_LF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(RFootHeavyBubblesSound)
{
   filename    = "fx/armor/light_RF_bubbles.wav";
   description = AudioClose3d;
   preload = true;
};
datablock AudioProfile(ImpactHeavySoftSound)
{
   filename    = "fx/armor/heavy_land_soft.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactSoftEffect;
};

datablock AudioProfile(ImpactHeavyHardSound)
{
   filename    = "fx/armor/heavy_land_hard.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactHardEffect;
};

datablock AudioProfile(ImpactHeavyMetalSound)
{
   filename    = "fx/armor/heavy_land_metal.wav";
   description = AudioClose3d;
   preload = true;
   effect = ImpactMetalEffect;
};

datablock AudioProfile(ImpactHeavySnowSound)
{
   filename    = "fx/armor/heavy_land_snow.wav";
   description = AudioClosest3d;
   preload = true;
   effect = ImpactSnowEffect;
};

datablock AudioProfile(ImpactHeavyWaterEasySound)
{
   filename    = "fx/armor/general_water_smallsplash.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactHeavyWaterMediumSound)
{
   filename    = "fx/armor/general_water_medsplash.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ImpactHeavyWaterHardSound)
{
   filename    = "fx/armor/general_water_bigsplash.wav";
   description = AudioDefault3d;
   preload = true;
};

datablock AudioProfile(ExitingWaterHeavySound)
{
   filename    = "fx/armor/general_water_exit2.wav";
   description = AudioClose3d;
   preload = true;
};

//----------------------------------------------------------------------------
// Splash
//----------------------------------------------------------------------------

datablock ParticleData(PlayerSplashMist)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.8;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(PlayerSplashMistEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0;
   velocityVariance = 2.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 85;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   lifetimeMS       = 250;
   particles = "PlayerSplashMist";
};


datablock ParticleData(PlayerBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.50;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   textureName          = "special/bubbles";
   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.3;
   sizes[2]      = 0.3;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(PlayerBubbleEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 2.0;
   ejectionOffset   = 0.5;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "PlayerBubbleParticle";
};

datablock ParticleData(PlayerFoamParticle)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "particleTest";
   colors[0]     = "0.7 0.8 1.0 0.20";
   colors[1]     = "0.7 0.8 1.0 0.20";
   colors[2]     = "0.7 0.8 1.0 0.00";
   sizes[0]      = 0.2;
   sizes[1]      = 0.4;
   sizes[2]      = 1.6;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(PlayerFoamEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 85;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "PlayerFoamParticle";
};


datablock ParticleData( PlayerFoamDropletsParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.8;
   sizes[1]      = 0.3;
   sizes[2]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( PlayerFoamDropletsEmitter )
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 2;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 60;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   particles = "PlayerFoamDropletsParticle";
};



datablock ParticleData( PlayerSplashParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 0;
   textureName          = "special/droplet";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( PlayerSplashEmitter )
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 60;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "PlayerSplashParticle";
};

datablock SplashData(PlayerSplash)
{
   numSegments = 15;
   ejectionFreq = 15;
   ejectionAngle = 40;
   ringLifetime = 0.5;
   lifetimeMS = 300;
   velocity = 4.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "special/water2";

   emitter[0] = PlayerSplashEmitter;
   emitter[1] = PlayerSplashMistEmitter;

   colors[0] = "0.7 0.8 1.0 0.0";
   colors[1] = "0.7 0.8 1.0 0.3";
   colors[2] = "0.7 0.8 1.0 0.7";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

//----------------------------------------------------------------------------
// Jet data
//----------------------------------------------------------------------------
datablock ParticleData(HumanArmorJetParticle)
{
   dragCoefficient      = 1.5;  //Was 0.0, original game shiped as 1.5
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 100;  //Was a watered down 100, Original game was 150
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.32 0.47 0.47 1.0";
   colors[1]     = "0.32 0.47 0.47 0";
   sizes[0]      = 0.40;
   sizes[1]      = 0.15;
};

datablock ParticleEmitterData(HumanArmorJetEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 2.9;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 5;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "HumanArmorJetParticle";
};

datablock JetEffectData(HumanArmorJetEffect)
{
   texture        = "special/jetExhaust02";
   coolColor      = "0.0 0.0 1.0 1.0";
   hotColor       = "0.2 0.4 0.7 1.0";
   activateTime   = 0.2;
   deactivateTime = 0.05;
   length         = 0.75;
   width          = 0.2;
   speed          = -15;
   stretch        = 2.0;
   yOffset        = 0.2;
};

datablock JetEffectData(HumanMediumArmorJetEffect)
{
   texture        = "special/jetExhaust02";
   coolColor      = "0.0 0.0 1.0 1.0";
   hotColor       = "0.2 0.4 0.7 1.0";
   activateTime   = 0.2;
   deactivateTime = 0.05;
   length         = 0.75;
   width          = 0.2;
   speed          = -15;
   stretch        = 2.0;
   yOffset        = 0.4;
};

datablock JetEffectData(HumanLightFemaleArmorJetEffect)
{
   texture        = "special/jetExhaust02";
   coolColor      = "0.0 0.0 1.0 1.0";
   hotColor       = "0.2 0.4 0.7 1.0";
   activateTime   = 0.2;
   deactivateTime = 0.05;
   length         = 0.75;
   width          = 0.2;
   speed          = -15;
   stretch        = 2.0;
   yOffset        = 0.2;
};

datablock JetEffectData(BiodermArmorJetEffect)
{
   texture        = "special/jetExhaust02";
   coolColor      = "0.0 0.0 1.0 1.0";
   hotColor       = "0.8 0.6 0.2 1.0";
   activateTime   = 0.2;
   deactivateTime = 0.05;
   length         = 0.75;
   width          = 0.2;
   speed          = -15;
   stretch        = 2.0;
   yOffset        = 0.0;
};

//----------------------------------------------------------------------------
// Foot puffs
//----------------------------------------------------------------------------
datablock ParticleData(LightPuff)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -35.0;
   spinRandomMax        = 35.0;
   textureName          = "particleTest";
   colors[0]     = "0.46 0.36 0.26 0.4";
   colors[1]     = "0.46 0.46 0.36 0.0";
   sizes[0]      = 0.4;
   sizes[1]      = 1.0;
};

datablock ParticleEmitterData(LightPuffEmitter)
{
   ejectionPeriodMS = 35;
   periodVarianceMS = 10;
   ejectionVelocity = 0.1;
   velocityVariance = 0.05;
   ejectionOffset   = 0.0;
   thetaMin         = 5;
   thetaMax         = 20;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   useEmitterColors = true;
   particles = "LightPuff";
};

datablock ParticleData(SOLightPuff)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -35.0;
   spinRandomMax        = 35.0;
   textureName          = "particleTest";
   colors[0]     = "0.46 0.36 0.26 0.4";
   colors[1]     = "0.46 0.46 0.36 0.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.2;
};

datablock ParticleEmitterData(SOLightPuffEmitter)
{
   ejectionPeriodMS = 1500;
   periodVarianceMS = 0;
   ejectionVelocity = 0.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 5;
   thetaMax         = 20;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   useEmitterColors = true;
   particles = "SOLightPuff";
};

//----------------------------------------------------------------------------
// Liftoff dust
//----------------------------------------------------------------------------
datablock ParticleData(LiftoffDust)
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
   colors[0]     = "0.46 0.36 0.26 0.0";
   colors[1]     = "0.46 0.46 0.36 0.4";
   colors[2]     = "0.46 0.46 0.36 0.0";
   sizes[0]      = 0.2;
   sizes[1]      = 0.6;
   sizes[2]      = 1.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(LiftoffDustEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 2.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 90;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   useEmitterColors = true;
   particles = "LiftoffDust";
};

//----------------------------------------------------------------------------

datablock ParticleData(BiodermArmorJetParticle) : HumanArmorJetParticle
{
   colors[0]     = "0.50 0.48 0.36 1.0";
   colors[1]     = "0.50 0.48 0.36 0";
};

datablock ParticleEmitterData(BiodermArmorJetEmitter) : HumanArmorJetEmitter
{
   particles = "BiodermArmorJetParticle";
};


//----------------------------------------------------------------------------
datablock DecalData(LightMaleFootprint)
{
   sizeX       = 0.125;
   sizeY       = 0.25;
   textureName = "special/footprints/L_male";
};

datablock DebrisData( PlayerDebris )
{
   explodeOnMaxBounce = false;

   elasticity = 0.35;
   friction = 0.5;

   lifetime = 4.0;
   lifetimeVariance = 0.0;

   minSpinSpeed = 60;
   maxSpinSpeed = 600;

   numBounces = 5;
   bounceVariance = 0;

   staticOnMaxBounce = true;
   gravModifier = 1.0;

   useRadiusMass = true;
   baseRadius = 1;

   velocity = 18.0;
   velocityVariance = 12.0;
};

datablock PlayerData(LightMaleHumanArmor) : LightPlayerDamageProfile
{
   emap = true;

   className = Armor;
   shapeFile = "light_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   debrisShapeName = "debris_player.dts";
   debris = playerDebris;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 90;
   drag = 0.275;
   maxdrag = 0.4;
   density = 10;
   maxDamage = 0.66;
   maxEnergy =  60;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.256;
   jetForce = 26.21 * 120;
   underwaterJetForce = 26.21 * 50 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain =  0.8;
   underwaterJetEnergyDrain = 0.0;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 55.20 * 90;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 13;
   maxSideSpeed = 13;

   maxUnderwaterForwardSpeed = 11;
   maxUnderwaterBackwardSpeed = 10;
   maxUnderwaterSideSpeed = 10;


   jumpForce = 8.3 * 90;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpDelay = 0;


   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   minImpactSpeed = 50;
   speedDamageScale = 0.015;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorJetSound;
   jetEmitter = HumanArmorJetEmitter;
   jetEffect = HumanArmorJetEffect;

   boundingBox = "1.2 1.2 2.3";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = LightMaleFootprint;
   decalOffset = 0.25;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 70;

   minJumpSpeed = 20;
   maxJumpSpeed = 30;

   horizMaxSpeed = 68;
   horizResistSpeed = 33;
   horizResistFactor = 0.35;
   maxJetForwardSpeed = 30;

   upMaxSpeed = 80;
   upResistSpeed = 25;
   upResistFactor = 0.3;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 4.0;
   heatIncreasePerSec   = 1.0 / 10.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootLightSoftSound;
   RFootSoftSound       = RFootLightSoftSound;
   LFootHardSound       = LFootLightHardSound;
   RFootHardSound       = RFootLightHardSound;
   LFootMetalSound      = LFootLightMetalSound;
   RFootMetalSound      = RFootLightMetalSound;
   LFootSnowSound       = LFootLightSnowSound;
   RFootSnowSound       = RFootLightSnowSound;
   LFootShallowSound    = LFootLightShallowSplashSound;
   RFootShallowSound    = RFootLightShallowSplashSound;
   LFootWadingSound     = LFootLightWadingSound;
   RFootWadingSound     = RFootLightWadingSound;
   LFootUnderwaterSound = LFootLightUnderwaterSound;
   RFootUnderwaterSound = RFootLightUnderwaterSound;
   LFootBubblesSound    = LFootLightBubblesSound;
   RFootBubblesSound    = RFootLightBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactLightSoftSound;
   impactHardSound      = ImpactLightHardSound;
   impactMetalSound     = ImpactLightMetalSound;
   impactSnowSound      = ImpactLightSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactLightWaterEasySound;
   impactWaterMedium    = ImpactLightWaterMediumSound;
   impactWaterHard      = ImpactLightWaterHardSound;

   groundImpactMinSpeed    = 25.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterLightSound;

   maxWeapons = 4;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 0;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 2;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 2;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 2;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 2;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 1000;
	max[RepairGun]			= 1;
	max[RepairPadDeployable]		= 1;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 1;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 1;
	max[MissileBarrelPack]		= 1;
	max[AABarrelPack]		= 1;
	max[PlasmaBarrelPack]		= 1;
	max[ELFBarrelPack]		= 1;
	max[artillerybarrelpack]	= 1;
	max[InventoryDeployable]	= 1;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 1;
	max[TurretIndoorDeployable]	= 1;
	max[FlashGrenade]		= 3;
	max[ConcussionGrenade]		= 5;
	max[FlareGrenade]		= 5;
	max[TargetingLaser]		= 1;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 2;
	max[Beacon]			= 3;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 1;
	//Guns
	max[ConstructionTool]		= 1;
	max[MergeTool]			= 1;
	max[EditingTool]		= 1;
	max[TextureTool]		= 1;
    max[LordAcidGun] = 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[PBC]				= 0;
	max[PBCAmmo]			= 0;
	//Building parts
	max[spineDeployable]		= 1;
	max[mspineDeployable]		= 1;
	max[wWallDeployable]		= 1;
	max[floorDeployable]		= 1;
	max[WallDeployable]		= 1;
      max[DoorDeployable]           = 1;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 1;
	max[DiscTurretDeployable]	= 1;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 1;
	max[CrateDeployable]		= 1;
	max[DecorationDeployable]	= 1;
	max[LogoProjectorDeployable]	= 1;
	max[LightDeployable]		= 1;
	max[TripwireDeployable]		= 1;
	max[TelePadPack]		= 1;
	max[TurretBasePack]		= 1;
	max[TurretSentryPack]		= 1;
	max[LargeInventoryDeployable]	= 1;
	max[GeneratorDeployable]	= 1;
	max[SolarPanelDeployable]	= 1;
	max[SwitchDeployable]		= 1;
	max[MediumSensorDeployable]	= 1;
	max[LargeSensorDeployable]	= 1;
	max[SpySatelliteDeployable]	= 1;
	max[artilleryWeaponPack]	= 1;
	max[spawnpointpack]		= 1;
    max[waypointDeployable]   = 1;
	//Misc
	max[JumpadDeployable]		= 1;
	max[ForceFieldDeployable]	= 1;
	max[GravityFieldDeployable]	= 1;
      max[VehiclePadPack]		= 1;
	max[DronePadDeployable]		= 1;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};


//----------------------------------------------------------------------------

datablock DecalData(MediumMaleFootprint)
{
   sizeX       = 0.125;
   sizeY       = 0.25;
   textureName = "special/footprints/M_male";
};

datablock PlayerData(MediumMaleHumanArmor) : MediumPlayerDamageProfile
{
   emap = true;

   className = Armor;
   shapeFile = "medium_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = playerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   // z0dd - ZOD, 10/06/02. Was missing these parameters.
   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 130;
   drag = 0.3;
   maxdrag = 0.5;
   density = 10;
   maxDamage = 1.1;
   maxEnergy =  100;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.55;
   jetForce = 12;
   underwaterJetForce = 25.22 * 170 * 1.5;
   underwaterVertJetFactor = 535.5;
   jetEnergyDrain =  0;
   underwaterJetEnergyDrain =  0.1;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 46 * 130;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 12;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;

   maxUnderwaterForwardSpeed = 8.5;
   maxUnderwaterBackwardSpeed = 7.5;
   maxUnderwaterSideSpeed = 7.5;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 4.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 10.0; // takes 3.0 seconds of constant jet to get full heat sig.

   jumpForce = 8.3 * 130;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpSurfaceAngle = 75;
   jumpDelay = 0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 70;

   minJumpSpeed = 15;
   maxJumpSpeed = 25;

   horizMaxSpeed = 60;
   horizResistSpeed = 28;
   horizResistFactor = 0.32;
   maxJetForwardSpeed = 22;

   upMaxSpeed = 70;
   upResistSpeed = 30;
   upResistFactor = 0.23;

   minImpactSpeed = 30;
   speedDamageScale = 0.015;

   jetSound = "";
   wetJetSound = ArmorWetJetSound;

   jetEmitter = "";
   jetEffect = "";

   boundingBox = "1.45 1.45 2.4";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = MediumMaleFootprint;
   decalOffset = 0.35;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootMediumSoftSound;
   RFootSoftSound       = RFootMediumSoftSound;
   LFootHardSound       = LFootMediumHardSound;
   RFootHardSound       = RFootMediumHardSound;
   LFootMetalSound      = LFootMediumMetalSound;
   RFootMetalSound      = RFootMediumMetalSound;
   LFootSnowSound       = LFootMediumSnowSound;
   RFootSnowSound       = RFootMediumSnowSound;
   LFootShallowSound    = LFootMediumShallowSplashSound;
   RFootShallowSound    = RFootMediumShallowSplashSound;
   LFootWadingSound     = LFootMediumWadingSound;
   RFootWadingSound     = RFootMediumWadingSound;
   LFootUnderwaterSound = LFootMediumUnderwaterSound;
   RFootUnderwaterSound = RFootMediumUnderwaterSound;
   LFootBubblesSound    = LFootMediumBubblesSound;
   RFootBubblesSound    = RFootMediumBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactMediumSoftSound;
   impactHardSound      = ImpactMediumHardSound;
   impactMetalSound     = ImpactMediumMetalSound;
   impactSnowSound      = ImpactMediumSnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactMediumWaterEasySound;
   impactWaterMedium    = ImpactMediumWaterMediumSound;
   impactWaterHard      = ImpactMediumWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterMediumSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			= 3;
	max[Grenade]			= 3;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 2;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 4;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 4;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 1500;
	max[RepairGun]			= 1;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 1;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 1;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 1;
	max[InventoryDeployable]	= 1;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 1;
	max[TurretOutdoorDeployable]	= 1;
	max[TurretIndoorDeployable]	= 1;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 6;
	max[FlareGrenade]		= 4;
    max[TargetingLaser]		= 1;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 3;
	max[flamerAmmoPack]		= 1;
	max[ParachutePack]		= 1;
	max[MedPack]			= 1;
	//Guns
	max[ConstructionTool] 	 	= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun] 	 		= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 30;
	max[MGClip]				= 5;
	max[LSMG]				= 1;
	max[LSMGAmmo]			= 60;
	max[LSMGClip]			= 10;
	max[HRPChaingun]			= 1;
	max[RPGAmmo]			= 1;
	max[RPGItem]			= 0;
	max[snipergun]			= 1;
	max[snipergunAmmo]		= 20;
	max[Bazooka]			= 1;
	max[BazookaAmmo]			= 3;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
    max[MG42Clip]           = 1;
	max[flamer]				= 1;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 1;
	max[AALauncherAmmo]		= 1;
	max[KriegRifle]			= 1;
	max[KriegAmmo]			= 10;
	max[Rifleclip]			= 3;
	max[Shotgun]			= 1;
    max[M4]                 = 1;
    max[M4Ammo]             = 4;
	max[ShotgunAmmo]			= 8;
	max[ShotgunClip]			= 4;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[PBC]				= 0;
	max[PBCAmmo]			= 0;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[artilleryWeaponPack]	= 1;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};


//----------------------------------------------------------------------------
datablock DecalData(HeavyMaleFootprint)
{
   sizeX       = 0.25;
   sizeY       = 0.5;
   textureName = "special/footprints/H_male";
};

datablock PlayerData(HeavyMaleHumanArmor) : HeavyPlayerDamageProfile
{
   emap = true;

   className = Armor;
   shapeFile = "heavy_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   debrisShapeName = "debris_player.dts";
   debris = playerDebris;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   // z0dd - ZOD, 10/06/02. Was missing these parameters.
   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 200;
   drag = 0.33;
   maxdrag = 0.6;
   density = 10;
   maxDamage = 1.32;
   maxEnergy =  110;
   repairRate = 0.0033;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.55;
   jetForce = 6250;
   underwaterJetForce = 300.47 * 180 * 1.5;
   underwaterVertJetFactor = 2.0;
   jetEnergyDrain =  5.5;
   underwaterJetEnergyDrain =  1.5;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 40.25 * 180;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 7;
   maxBackwardSpeed = 5;
   maxSideSpeed = 5;

   maxUnderwaterForwardSpeed = 4.5;
   maxUnderwaterBackwardSpeed = 3;
   maxUnderwaterSideSpeed = 3;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   jumpForce = 8.3 * 180;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpDelay = 0;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 6.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 4.0; // takes 3.0 seconds of constant jet to get full heat sig.

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 70;

   minJumpSpeed = 20;
   maxJumpSpeed = 30;

   horizMaxSpeed = 52;
   horizResistSpeed = 23;
   horizResistFactor = 0.29;
   maxJetForwardSpeed = 16;

   upMaxSpeed = 60;
   upResistSpeed = 35;
   upResistFactor = 0.18;

   minImpactSpeed = 40;
   speedDamageScale = 0.018;

   jetSound = ArmorJetSound;
   wetJetSound = ArmorJetSound;
   jetEmitter = HumanArmorJetEmitter;

   boundingBox = "1.63 1.63 2.6";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = HeavyMaleFootprint;
   decalOffset = 0.4;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootSoftSound       = LFootHeavySoftSound;
   RFootSoftSound       = RFootHeavySoftSound;
   LFootHardSound       = LFootHeavyHardSound;
   RFootHardSound       = RFootHeavyHardSound;
   LFootMetalSound      = LFootHeavyMetalSound;
   RFootMetalSound      = RFootHeavyMetalSound;
   LFootSnowSound       = LFootHeavySnowSound;
   RFootSnowSound       = RFootHeavySnowSound;
   LFootShallowSound    = LFootHeavyShallowSplashSound;
   RFootShallowSound    = RFootHeavyShallowSplashSound;
   LFootWadingSound     = LFootHeavyWadingSound;
   RFootWadingSound     = RFootHeavyWadingSound;
   LFootUnderwaterSound = LFootHeavyUnderwaterSound;
   RFootUnderwaterSound = RFootHeavyUnderwaterSound;
   LFootBubblesSound    = LFootHeavyBubblesSound;
   RFootBubblesSound    = RFootHeavyBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactHeavySoftSound;
   impactHardSound      = ImpactHeavyHardSound;
   impactMetalSound     = ImpactHeavyMetalSound;
   impactSnowSound      = ImpactHeavySnowSound;

   skiSoftSound         = SkiAllSoftSound;
   skiHardSound         = SkiAllHardSound;
   skiMetalSound        = SkiAllMetalSound;
   skiSnowSound         = SkiAllSnowSound;

   impactWaterEasy      = ImpactHeavyWaterEasySound;
   impactWaterMedium    = ImpactHeavyWaterMediumSound;
   impactWaterHard      = ImpactHeavyWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterHeavySound;

   maxWeapons = 3;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 0;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 2;
	max[Mine]			= 3;
	max[Grenade]			= 5;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 2;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 1;
	max[InventoryDeployable]	= 1;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 1;
	max[TurretIndoorDeployable]	= 1;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 8;
	max[FlareGrenade]		= 5;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 3;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
    max[BoosterPack]        = 1;
	//Guns
	max[ConstructionTool] 		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun] 			= 0;
	max[DZShot]			= 0;
	max[SuperChaingun] 		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 1;
	max[BazookaAmmo]			= 5;
	max[MG42]				= 1;
	max[MG42Ammo]			= 200;
	max[MG42Clip]			= 5;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
    max[NapalmAmmo]         = 5;
	max[AALauncher]			= 1;
	max[AALauncherAmmo]		= 1;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 2;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 1;
	max[RShotgunAmmo]			= 25;
	max[RShotgunClip]			= 2;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[PBC]				= 1;
	max[PBCAmmo]			= 4;
    max[RailGun]            = 1;
    max[RailGunAmmo]        = 10;
    max[NapalmMortar]       = 1;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 1;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 1;
	max[SwitchDeployable]		= 1;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[artilleryWeaponPack]	= 1;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};


//----------------------------------------------------------------------------
datablock PlayerData(LightFemaleHumanArmor) : LightMaleHumanArmor
{
   shapeFile = "light_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanMediumArmorJetEffect;
};

//----------------------------------------------------------------------------
datablock PlayerData(MediumFemaleHumanArmor) : MediumMaleHumanArmor
{
   shapeFile = "medium_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanArmorJetEffect;
};

//----------------------------------------------------------------------------
datablock PlayerData(HeavyFemaleHumanArmor) : HeavyMaleHumanArmor
{
   shapeFile = "heavy_male.dts";
   waterBreathSound = WaterBreathFemaleSound;
};

//----------------------------------------------------------------------------
datablock DecalData(LightBiodermFootprint)
{
   sizeX       = 0.25;
   sizeY       = 0.25;
   textureName = "special/footprints/L_bioderm";
};

datablock PlayerData(LightMaleBiodermArmor) : LightMaleHumanArmor
{
   shapeFile = "bioderm_light.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;


   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;
};

//----------------------------------------------------------------------------
datablock DecalData(MediumBiodermFootprint)
{
   sizeX       = 0.25;
   sizeY       = 0.25;
   textureName = "special/footprints/M_bioderm";
};

datablock PlayerData(MediumMaleBiodermArmor) : MediumMaleHumanArmor
{
   shapeFile = "bioderm_medium.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = MediumBiodermFootprint;
   decalOffset = 0.35;

   waterBreathSound = WaterBreathBiodermSound;
};

//----------------------------------------------------------------------------
datablock DecalData(HeavyBiodermFootprint)
{
   sizeX       = 0.25;
   sizeY       = 0.5;
   textureName = "special/footprints/H_bioderm";
};

datablock PlayerData(HeavyMaleBiodermArmor) : HeavyMaleHumanArmor
{
   emap = false;

   shapeFile = "bioderm_heavy.dts";
   jetEmitter = "";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData    = HeavyBiodermFootprint;
   decalOffset  = 0.4;

   waterBreathSound = WaterBreathBiodermSound;
};


datablock PlayerData(SpecOpsMaleHumanArmor) : LightPlayerDamageProfile
{
   emap = true;

   className = Armor;
   shapeFile = "light_male.dts";
   cameraMaxDist = 3;
   computeCRC = true;

   canObserve = true;
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   hudImageNameFriendly[0] = "gui/hud_playertriangle";
   hudImageNameEnemy[0] = "gui/hud_playertriangle_enemy";
   hudRenderModulated[0] = true;

   hudImageNameFriendly[1] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[1] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[1] = true;
   hudRenderAlways[1] = true;
   hudRenderCenter[1] = true;
   hudRenderDistance[1] = true;

   hudImageNameFriendly[2] = "commander/MiniIcons/com_flag_grey";
   hudImageNameEnemy[2] = "commander/MiniIcons/com_flag_grey";
   hudRenderModulated[2] = true;
   hudRenderAlways[2] = true;
   hudRenderCenter[2] = true;
   hudRenderDistance[2] = true;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   debrisShapeName = "debris_player.dts";
   debris = playerDebris;

   aiAvoidThis = true;

   minLookAngle = -1.5;
   maxLookAngle = 1.5;
   maxFreelookAngle = 3.0;

   mass = 90;
   drag = 0.275;
   maxdrag = 0.4;
   density = 10;
   maxDamage = 0.8;
   maxEnergy =  60;
   repairRate = 0.01;
   energyPerDamagePoint = 75.0; // shield energy required to block one point of damage

   rechargeRate = 0.55;
   jetForce = 12;
   underwaterJetForce = 25.22 * 170 * 1.5;
   underwaterVertJetFactor = 535.5;
   jetEnergyDrain =  0;
   underwaterJetEnergyDrain =  0.1;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 0.8;

   runForce = 60.20 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 17;
   maxBackwardSpeed = 14;
   maxSideSpeed = 14;

   maxUnderwaterForwardSpeed = 15;
   maxUnderwaterBackwardSpeed = 12;
   maxUnderwaterSideSpeed = 12;

   jumpForce = 10.0 * 90;
   jumpEnergyDrain = 0;
   minJumpEnergy = 12;
   jumpDelay = 0;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   minImpactSpeed = 40;
   speedDamageScale = 0.015;

   jetSound = "";
   wetJetSound = ArmorJetSound;
   jetEmitter = "";
   jetEffect = "";

   boundingBox = "1.2 1.2 2.3";
   pickupRadius = 0.75;

   // damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   //Foot Prints
   decalData   = LightMaleFootprint;
   decalOffset = 0.25;

   footPuffEmitter = SOLightPuffEmitter;
   footPuffNumParts = 15;
   footPuffRadius = 0.25;

   splash = PlayerSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = PlayerFoamDropletsEmitter;
   splashEmitter[1] = PlayerFoamEmitter;
   splashEmitter[2] = PlayerBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   minJumpSpeed = 20;
   maxJumpSpeed = 30;

   horizMaxSpeed = 68;
   horizResistSpeed = 33;
   horizResistFactor = 0.35;
   maxJetForwardSpeed = 30;

   upMaxSpeed = 80;
   upResistSpeed = 25;
   upResistFactor = 0.3;

   // heat inc'ers and dec'ers
   heatDecayPerSec      = 1.0 / 3.0; // takes 4 seconds to clear heat sig.
   heatIncreasePerSec   = 1.0 / 20.0; // takes 3.0 seconds of constant jet to get full heat sig.

   footstepSplashHeight = 0.35;
   //Footstep Sounds
   LFootShallowSound    = LFootLightShallowSplashSound;
   RFootShallowSound    = RFootLightShallowSplashSound;
   LFootWadingSound     = LFootLightWadingSound;
   RFootWadingSound     = RFootLightWadingSound;
   LFootBubblesSound    = LFootLightBubblesSound;
   RFootBubblesSound    = RFootLightBubblesSound;
   movingBubblesSound   = ArmorMoveBubblesSound;
   waterBreathSound     = WaterBreathMaleSound;

   impactSoftSound      = ImpactLightSoftSound;
   impactHardSound      = ImpactLightHardSound;
   impactMetalSound     = ImpactLightMetalSound;
   impactSnowSound      = ImpactLightSnowSound;

   impactWaterEasy      = ImpactLightWaterEasySound;
   impactWaterMedium    = ImpactLightWaterMediumSound;
   impactWaterHard      = ImpactLightWaterHardSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   exitingWater         = ExitingWaterLightSound;

   maxWeapons = 2;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 1;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			= 1;
	max[Grenade]			= 3;
	max[SmokeGrenade]			= 2;
	max[BeaconSmokeGrenade]		= 2;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 1;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 1;
	max[SatchelCharge]		= 1;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 3;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 1;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 3;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 1;
	max[MedPack]			= 1;
	//Guns
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun]			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 1;
	max[RPChaingunAmmo]		= 30;
	max[MGClip]				= 5;
	max[LSMG]				= 1;
	max[LSMGAmmo]			= 60;
	max[LSMGClip]			= 5;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[snipergun]			= 1;
	max[snipergunAmmo]		= 20;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 1;
	max[KriegAmmo]			= 10;
	max[Rifleclip]			= 2;
	max[Shotgun]			= 1;
	max[ShotgunAmmo]			= 8;
	max[ShotgunClip]			= 2;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 1;
	max[LMissileLauncherAmmo]	= 1;
	max[PBC]				= 0;
	max[PBCAmmo]			= 0;
	max[SRifleSG]			= 1;
	max[SRifleGL]			= 1;
	max[SRifleAmmo]			= 30;
	max[SRifleSGAmmo]			= 4;
	max[SRifleGLAmmo]			= 1;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 1;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[artilleryWeaponPack]	= 1;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
    max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};

datablock PlayerData(SpecOpsFemaleHumanArmor) : SpecOpsMaleHumanArmor
{
   shapeFile = "light_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanMediumArmorJetEffect;
};

datablock PlayerData(SpecOpsMaleBiodermArmor) : SpecOpsMaleHumanArmor
{
   shapeFile = "bioderm_light.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;


   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;
};


// --------------------------------------------------------------------------
// True Build Armors
// --------------------------------------------------------------------------

datablock PlayerData(PureMaleHumanArmor) : LightMaleHumanArmor
{
   jetForce = 26.21 * 120; // 26.21 * 90
   underwaterJetForce = 26.21 * 120 * 1.5; // 26.21 * 90 * 1.5
   underwaterVertJetFactor = 1.5;

   maxEnergy =  100;
   jetEnergyDrain =  0;
   underwaterJetEnergyDrain = 0.05;
   rechargeRate = 0.55;
   dustEmitter = LiftoffDustEmitter;

   minImpactSpeed = 450;
   speedDamageScale = 0.0004;

   maxWeapons = 4;            // Max number of different weapons the player can have
   maxGrenades = 1;           // Max number of different grenades the player can have
   maxMines = 0;              // Max number of different mines the player can have

	// Inventory restrictions
	max[RepairKit]			= 1;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 2;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 4;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 1500;
    max[RepairPadDeployable]		= 1;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 1;
	max[ShieldPack]			= 1;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 1;
	max[MortarBarrelPack]		= 1;
	max[MissileBarrelPack]		= 1;
	max[AABarrelPack]		= 1;
	max[PlasmaBarrelPack]		= 1;
	max[ELFBarrelPack]		= 1;
	max[artillerybarrelpack]	= 1;
	max[InventoryDeployable]	= 1;
	max[MotionSensorDeployable]	= 1;
	max[PulseSensorDeployable]	= 1;
	max[TurretOutdoorDeployable]	= 1;
	max[TurretIndoorDeployable]	= 1;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 8;
	max[TargetingLaser]		= 1;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 2;
	max[Beacon]			= 5;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 1;
	//Guns
	max[ConstructionTool]		= 1;
	max[MergeTool]			= 1;
	max[EditingTool]		= 1;
	max[TextureTool]		= 1;
	max[hookertool]			= 1;
	max[LordAcidGun] 			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun] 	 	= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[PBC]				= 0;
	max[PBCAmmo]			= 0;
	//Building parts
	max[spineDeployable]		= 1;
	max[mspineDeployable]		= 1;
	max[wWallDeployable]		= 1;
	max[floorDeployable]		= 1;
	max[WallDeployable]		= 1;
      max[DoorDeployable]           = 1;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 1;
	max[DiscTurretDeployable]	= 1;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 1;
	max[CrateDeployable]		= 1;
	max[DecorationDeployable]	= 1;
	max[LogoProjectorDeployable]	= 1;
	max[LightDeployable]		= 1;
	max[ZSpawnDeployable]		= 1;
	max[TripwireDeployable]		= 1;
    max[waypointDeployable]       = 1;
	max[TelePadPack]		= 1;
	max[TurretBasePack]		= 1;
	max[TurretSentryPack]		= 1;
	max[LargeInventoryDeployable]	= 1;
	max[GeneratorDeployable]	= 1;
	max[SolarPanelDeployable]	= 1;
	max[SwitchDeployable]		= 1;
	max[MediumSensorDeployable]	= 1;
	max[LargeSensorDeployable]	= 1;
	max[SpySatelliteDeployable]	= 1;
	max[artilleryWeaponPack]	= 1;
	//Misc
	max[JumpadDeployable]		= 1;
	max[ForceFieldDeployable]	= 1;
	max[GravityFieldDeployable]	= 1;
	max[spawnpointpack]	     	= 1;
 	max[waypointDeployable]		= 1;

        //Some small additions
        //Note all that keeps us from full plugin compability is this code.
        max[TractorGun]			= 1;
        max[VehiclePadPack]		= 1;
	max[DronePadDeployable]		= 1;
        max[mpm_beaconpack]		= 1;
	max[TurretMpm_Anti_Deployable]  = 1;
        max[EmitterDepPack]		= 1;
        max[AudioDepPack]		= 1;
        max[DispenserDepPack]		= 1;
        max[DetonationDepPack]	= 1;
        max[TransDepPack]		= 1;
        max[MpmFuelPack]		= 1;
	max[MpmAmmoPack]		= 1;

	observeParameters = "0.5 4.5 4.5";
	shieldEffectScale = "0.7 0.7 1.0";
};


//----------------------------------------------------------------------------
datablock PlayerData(PureFemaleHumanArmor) : PureMaleHumanArmor
{
   shapeFile = "light_female.dts";
   waterBreathSound = WaterBreathFemaleSound;
   jetEffect =  HumanMediumArmorJetEffect;
};

datablock PlayerData(PureMaleBiodermArmor) : PureMaleHumanArmor
{
   shapeFile = "bioderm_light.dts";
   jetEmitter = BiodermArmorJetEmitter;
   jetEffect =  BiodermArmorJetEffect;


   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;
};

// --------------------------------------------------------------------------
// End True Build Armors
// --------------------------------------------------------------------------

// Zombie Armor - Edited by: Blnukem
datablock PlayerData(ZombieArmor) : LightMaleHumanArmor
{
   cmdCategory = "Clients";
   cmdIcon = CMDPlayerIcon;
   cmdMiniIconName = "commander/MiniIcons/com_player_grey";

   runForce = 80 * 90;
   runEnergyDrain = 0.0;
   minRunEnergy = 10;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 7;
   maxSideSpeed = 7;

   jetForce = 0;
   jumpForce = 20 * 90;

   maxDamage = 2.8;
   minImpactSpeed = 35;
   shapeFile = "bioderm_medium.dts";
   jetEmitter = "";
   jetEffect =  "";
   jetSound = "";
   dustEmitter = "";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = LightBiodermFootprint;
   decalOffset = 0.3;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::shotgun] = 3.0; 
   damageScale[$DamageType::bazooka] = 3.0;
   damageScale[$DamageType::PBC] = 0.25;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
	//Guns
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun]			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;

};

datablock PlayerData(FZombieArmor) : LightMaleBiodermArmor
{
   maxDamage = 1.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;

   damageScale[$DamageType::shotgun] = 2.0; 
   damageScale[$DamageType::bazooka] = 3.0;
   damageScale[$DamageType::PBC] = 0.25;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
	//Guns
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun]			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;
};

datablock AudioProfile(ZLordFootSound)
{
   filename    = "fx/weapons/grenade_explode_UW.wav";
   description = AudioBomb3d;
   preload = true;
};

datablock AudioProfile(HZLordFootSound)
{
   filename    = "fx/weapons/SpinFusor_explode_UW.wav";
   description = AudioBomb3d;
   preload = true;
};

// Lord Zombie
datablock PlayerData(LordZombieArmor) : HeavyMaleBiodermArmor
{
   shapefile = "TR2medium_male.dts";
   mass = 500;
   maxDamage = 18.0;
   minImpactSpeed = 50;
   speedDamageScale = 0.015;
   boundingBox = "2.9 2.9 4.8";

   underwaterJetForce = 10;

   LFootSoftSound       = ZLordFootSound;
   RFootSoftSound       = ZLordFootSound;
   LFootHardSound       = HZLordFootSound;
   RFootHardSound       = HZLordFootSound;
   LFootMetalSound      = ZLordFootSound;
   RFootMetalSound      = ZLordFootSound;
   LFootSnowSound       = ZLordFootSound;
   RFootSnowSound       = ZLordFootSound;

   damageScale[$DamageType::shotgun] = 1.5; 
   damageScale[$DamageType::bazooka] = 2.0;

	max[RepairKit]			= 0;
	max[Mine]			= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]			= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]			= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]		= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]			= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]		= 0;
	max[RepairGun]			= 0;
    max[RepairPadDeployable]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]		= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]		= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]		= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]			= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]			= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[MedPack]			= 0;
	//Guns
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun]			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[PBC]				= 0;
	max[PBCAmmo]			= 0;
	//Building parts
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	//Turrets
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	//Largepacks
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]		= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	//Misc
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;
};

// Controlable ZLord Armor
datablock PlayerData(ControlLordZombieArmor) : LordZombieArmor
{
   runForce = 40.25 * 500;
   jumpForce = 20.3 * 500;

   maxForwardSpeed = 25;
   maxBackwardSpeed = 23;
   maxSideSpeed = 23;

   maxUnderwaterForwardSpeed = 23;
   maxUnderwaterBackwardSpeed = 23;
   maxUnderwaterSideSpeed = 23;

   underwaterJetForce = 10;

   max[LordAcidGun] = 1;
};

datablock PlayerData(DemonZombieArmor) : LightMaleHumanArmor
{
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 4.0;
   minImpactSpeed = 35;
   shapeFile = "bioderm_heavy.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::shotgun] = 1.0; 
   damageScale[$DamageType::bazooka] = 1.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]				= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]				= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]			= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]				= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]			= 0;
	max[RepairGun]			= 0;
    max[RepairPad]		= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]			= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[MedPack]			= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]			= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]			= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]				= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]				= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[EditingTool]		= 0;
	max[TextureTool]		= 0;
	max[LordAcidGun]			= 0;
	max[DZShot]			= 0;
    max[EditorTool]                = 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]			= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;
};

datablock PlayerData(ControlDemonZombieArmor) : DemonZombieArmor
{
   boundingBox = "1.63 1.63 2.6";
   maxDamage = 4.0;
   minImpactSpeed = 35;
   shapeFile = "bioderm_heavy.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   maxForwardSpeed = 18;
   maxBackwardSpeed = 16;
   maxSideSpeed = 18;

   jetForce = 0;
   jetEmitter = "";
   jetEffect =  "";
   jetSound = "";
   dustEmitter = "";

   jumpForce = 12 * 90;
   rechargeRate = 0.627;

   max[DZShot] = 1;
};

datablock PlayerData(RapierZombieArmor) : FZombieArmor
{
   minImpactSpeed = 75;
   maxDamage = 1.0;

   boundingBox = "2.0 2.0 1.2";
};

datablock PlayerData(ControlRapierZombieArmor) : RapierZombieArmor
{
   jumpForce = 11.5 * 90;

   rechargeRate = 0.256;
   jetForce = 35.26 * 120;
   underwaterJetForce = 35.26 * 50 * 1.5;
   underwaterVertJetFactor = 1.5;
   jetEnergyDrain = 0;
   underwaterJetEnergyDrain = 0;
   minJetEnergy = 1;
   maxJetHorizontalPercentage = 1;

   jetSound = "";
   wetJetSound = "";
   jetEmitter = "";
   jetEffect = "";

   horizMaxSpeed = 68;
   horizResistSpeed = 33;
   horizResistFactor = 0.35;
   maxJetForwardSpeed = 30;

   upMaxSpeed = 120;
   upResistSpeed = 20;
   upResistFactor = 0.27;

   // heat inc'ers and dec'ers
   heatDecayPerSec = 1.0 / 4.0;
   heatIncreasePerSec = 0;
};

datablock PlayerData(DemonMotherZombieArmor) : LightMaleHumanArmor
{
   boundingBox = "1.5 1.5 2.6";
   maxDamage = 9.0;
   minImpactSpeed = 35;
   shapeFile = "medium_female.dts";

   debrisShapeName = "bio_player_debris.dts";

   //Foot Prints
   decalData   = HeavyBiodermFootprint;
   decalOffset = 0.4;

   waterBreathSound = WaterBreathBiodermSound;

   damageScale[$DamageType::shotgun] = 1.0;
   damageScale[$DamageType::bazooka] = 1.0;

	max[RepairKit]			= 0;
	max[Mine]				= 0;
	max[Grenade]			= 0;
	max[SmokeGrenade]			= 0;
	max[BeaconSmokeGrenade]		= 0;
	max[Blaster]			= 0;
	max[Plasma]				= 0;
	max[PlasmaAmmo]			= 0;
	max[Disc]				= 0;
	max[DiscAmmo]			= 0;
	max[SniperRifle]			= 0;
	max[GrenadeLauncher]		= 0;
	max[GrenadeLauncherAmmo]	= 0;
	max[Mortar]				= 0;
	max[MortarAmmo]			= 0;
	max[MissileLauncher]		= 0;
	max[MissileLauncherAmmo]	= 0;
	max[Chaingun]			= 0;
	max[ChaingunAmmo]			= 0;
	max[RepairGun]			= 0;
	max[CloakingPack]			= 0;
	max[SensorJammerPack]		= 0;
	max[EnergyPack]			= 0;
	max[RepairPack]			= 0;
	max[ShieldPack]			= 0;
	max[AmmoPack]			= 0;
	max[SatchelCharge]		= 0;
	max[MortarBarrelPack]		= 0;
	max[MissileBarrelPack]		= 0;
	max[AABarrelPack]			= 0;
	max[PlasmaBarrelPack]		= 0;
	max[ELFBarrelPack]		= 0;
	max[artillerybarrelpack]	= 0;
	max[MedPack]			= 0;
	max[InventoryDeployable]	= 0;
	max[MotionSensorDeployable]	= 0;
	max[PulseSensorDeployable]	= 0;
	max[TurretOutdoorDeployable]	= 0;
	max[TurretIndoorDeployable]	= 0;
	max[FlashGrenade]			= 0;
	max[ConcussionGrenade]		= 0;
	max[FlareGrenade]			= 0;
	max[TargetingLaser]		= 0;
	max[ELFGun]				= 0;
	max[ShockLance]			= 0;
	max[CameraGrenade]		= 0;
	max[Beacon]				= 0;
	max[flamerAmmoPack]		= 0;
	max[ParachutePack]		= 0;
	max[ConstructionTool]		= 0;
	max[MergeTool]			= 0;
	max[NerfGun]			= 0;
	max[NerfBallLauncher]		= 0;
	max[NerfBallLauncherAmmo]	= 0;
	max[SuperChaingun]		= 0;
	max[SuperChaingunAmmo]		= 0;
	max[RPChaingun]			= 0;
	max[RPChaingunAmmo]		= 0;
	max[MGClip]				= 0;
	max[LSMG]				= 0;
	max[LSMGAmmo]			= 0;
	max[LSMGClip]			= 0;
	max[snipergun]			= 0;
	max[snipergunAmmo]		= 0;
	max[Bazooka]			= 0;
	max[BazookaAmmo]			= 0;
	max[nukeme]				= 0;
	max[nukemeAmmo]			= 0;
	max[MG42]				= 0;
	max[MG42Ammo]			= 0;
	max[flamer]				= 0;
	max[flamerAmmo]			= 0;
	max[AALauncher]			= 0;
	max[AALauncherAmmo]		= 0;
	max[melee]				= 0;
	max[SOmelee]			= 0;
	max[KriegRifle]			= 0;
	max[KriegAmmo]			= 0;
	max[Rifleclip]			= 0;
	max[Shotgun]			= 0;
	max[ShotgunAmmo]			= 0;
	max[ShotgunClip]			= 0;
	max[RShotgun]			= 0;
	max[RShotgunAmmo]			= 0;
	max[RShotgunClip]			= 0;
	max[LMissileLauncher]		= 0;
	max[LMissileLauncherAmmo]	= 0;
	max[HRPChaingun]			= 0;
	max[RPGAmmo]			= 0;
	max[RPGItem]			= 0;
	max[spineDeployable]		= 0;
	max[mspineDeployable]		= 0;
	max[wWallDeployable]		= 0;
	max[floorDeployable]		= 0;
	max[WallDeployable]		= 0;
      max[DoorDeployable]           = 0;
	max[TurretLaserDeployable]	= 0;
	max[TurretMissileRackDeployable]= 0;
	max[DiscTurretDeployable]	= 0;
	max[EnergizerDeployable]	= 0;
	max[TreeDeployable]		= 0;
	max[CrateDeployable]		= 0;
	max[DecorationDeployable]	= 0;
	max[LogoProjectorDeployable]	= 0;
	max[LightDeployable]		= 0;
	max[TripwireDeployable]		= 0;
	max[TelePadPack]			= 0;
	max[TurretBasePack]		= 0;
	max[TurretSentryPack]		= 0;
	max[LargeInventoryDeployable]	= 0;
	max[GeneratorDeployable]	= 0;
	max[SolarPanelDeployable]	= 0;
	max[SwitchDeployable]		= 0;
	max[MediumSensorDeployable]	= 0;
	max[LargeSensorDeployable]	= 0;
	max[SpySatelliteDeployable]	= 0;
	max[JumpadDeployable]		= 0;
	max[ForceFieldDeployable]	= 0;
	max[GravityFieldDeployable]	= 0;
      max[VehiclePadPack]		= 0;
	max[DronePadDeployable]		= 0;
};


//----------------------------------------------------------------------------

function Armor::onAdd(%data,%obj)
{
   Parent::onAdd(%data, %obj);
   // Vehicle timeout
   %obj.mountVehicle = true;

   // Default dynamic armor stats
   %obj.setRechargeRate(%data.rechargeRate);
   %obj.setRepairRate(0);

   %obj.setSelfPowered();
}

function Armor::onRemove(%this, %obj)
{
   Cancel(%obj.ParaLoop);
   if (%obj.client.player == %obj)
      %obj.client.player = 0;

   // Nukem - Shitty method, but it it works, why change it?
   if(%obj.getdatablock().getname() $= "ZombieArmor"
   || %obj.getdatablock().getname() $= "FZombieArmor"
   || %obj.getdatablock().getname() $= "LordZombieArmor"
   || %obj.getdatablock().getname() $= "DemonZombieArmor"
   || %obj.getdatablock().getname() $= "RapierZombieArmor")
      RemoveFromZombieGroup(%obj);
}

function Armor::onNewDataBlock(%this,%obj)
{
}

function Armor::onDisabled(%this,%obj,%state)
{
   %obj.revived = 0;
   if(%obj.Infected == 1){
	schedule(14000, %obj, "CreateZombie", %obj);
	%obj.schedule(15000, "delete");
   }
   else
   {
      %fadeTime = 1000;
	%obj.revcheck = schedule(($CorpseTimeoutValue) - %fadeTime, %obj, "checkIfRevived", %obj);
   }
   if(%obj.getdatablock().getname() $= "ZombieArmor" || %obj.getdatablock().getname() $= "FZombieArmor" || %obj.getdatablock().getname() $= "LordZombieArmor" || %obj.getdatablock().getname() $= "DemonZombieArmor" || %obj.getdatablock().getname() $= "ControlDemonZombieArmor" || %obj.getdatablock().getname() $= "RapierZombieArmor" || %obj.getdatablock().getname() $= "ControlRapierZombieArmor" || %obj.getdatablock().getname() $= "DemonMotherZombieArmor"){
	%dodeath = (getrandom() * 3);
	if(%dodeath <= 1)
         %obj.setActionThread("Death" @ $PlayerDeathAnim::HeadFrontDirect);
	else if(%dodeath <=2)
         %obj.setActionThread("Death" @ $PlayerDeathAnim::HeadBackFallForward);
	else
         %obj.setActionThread("Death" @ $PlayerDeathAnim::TorsoBackFallForward);
	if(%obj.hasCP == 1){
	   if(isObject(%obj.cp))
		%obj.CP.numZ = (%obj.CP.numZ - 1);
	}
	if(%obj.randspawnerstarted == 1)
	   $numspawnedzombies--;
   }
}

function checkIfRevived(%obj){
   if(%obj.revived != 1){
      %fadeTime = 1000;
      %obj.startFade( %fadeTime, 1, true );
   	%obj.schedule(%fadeTime, "delete");
   }
   else
	%obj.revived = 0;
}

function Armor::shouldApplyImpulse(%data, %obj)
{
   return true;
}

$wasFirstPerson = true;

function Armor::onMount(%this,%obj,%vehicle,%node)
{
//[most]
if (%vehicle.base.leftpad == %vehicle || %vehicle.base.rightpad == %vehicle)
   {
   %node = 1;
   %obj.mvehicle = %vehicle;
   }
//[most]

   if (%node == 0)
   {
      // Node 0 is the pilot's pos.
      %obj.setTransform("0 0 0 0 0 1 0");
      %obj.setActionThread(%vehicle.getDatablock().mountPose[%node],true,true);

      if(!%obj.inStation)
         %obj.lastWeapon = (%obj.getMountedImage($WeaponSlot) == 0 ) ? "" : %obj.getMountedImage($WeaponSlot).getName().item;

       %obj.unmountImage($WeaponSlot);

      if(!%obj.client.isAIControlled())
      {
         %obj.setControlObject(%vehicle);
         %obj.client.setObjectActiveImage(%vehicle, 2);
      }

      //E3 respawn...

      if(%obj == %obj.lastVehicle.lastPilot && %obj.lastVehicle != %vehicle)
      {
         schedule(240000, %obj.lastVehicle,"vehicleAbandonTimeOut", %obj.lastVehicle);
          %obj.lastVehicle.lastPilot = "";
      }
      if(%vehicle.lastPilot !$= "" && %vehicle == %vehicle.lastPilot.lastVehicle)
            %vehicle.lastPilot.lastVehicle = "";

      %vehicle.abandon = false;
      %vehicle.lastPilot = %obj;
      %obj.lastVehicle = %vehicle;

      // update the vehicle's team
      if((%vehicle.getTarget() != -1) && %vehicle.getDatablock().cantTeamSwitch $= "")
      {
         setTargetSensorGroup(%vehicle.getTarget(), %obj.client.getSensorGroup());
         if( %vehicle.turretObject > 0 )
            setTargetSensorGroup(%vehicle.turretObject.getTarget(), %obj.client.getSensorGroup());
      }

      // Send a message to the client so they can decide if they want to change view or not:
      commandToClient( %obj.client, 'VehicleMount' );

   }
   else
   {
      // tailgunner/passenger positions
      if(%vehicle.getDataBlock().mountPose[%node] !$= "")
         %obj.setActionThread(%vehicle.getDatablock().mountPose[%node]);
      else
         %obj.setActionThread("root", true);
   }
   // -------------------------------------------------------------------------
   // z0dd - ZOD, 10/06/02. announce to any other passengers that you've boarded
   if(%vehicle.getDatablock().numMountPoints > 1)
   {
      %nodeName = findNodeName(%vehicle, %node); // function in vehicle.cs
      for(%i = 0; %i < %vehicle.getDatablock().numMountPoints; %i++)
      {
         if (%vehicle.getMountNodeObject(%i) > 0)
         {
            if(%vehicle.getMountNodeObject(%i).client != %obj.client)
            {
               %team = (%obj.team == %vehicle.getMountNodeObject(%i).client.team ? 'Teammate' : 'Enemy');
               messageClient( %vehicle.getMountNodeObject(%i).client, 'MsgShowPassenger', '\c2%3: \c3%1\c2 has boarded in the \c3%2\c2 position.', %obj.client.name, %nodeName, %team );
            }
            commandToClient( %vehicle.getMountNodeObject(%i).client, 'showPassenger', %node, true);
         }
      }
   }
   //make sure they don't have any packs active
//    if ( %obj.getImageState( $BackpackSlot ) $= "activate")
//       %obj.use("Backpack");
   if ( %obj.getImageTrigger( $BackpackSlot ) )
      %obj.setImageTrigger( $BackpackSlot, false );

   //AI hooks
   %obj.client.vehicleMounted = %vehicle;
   AIVehicleMounted(%vehicle);
   if(%obj.client.isAIControlled())
      %this.AIonMount(%obj, %vehicle, %node);
}


function Armor::onUnmount( %this, %obj, %vehicle, %node )
{
   %obj.mountedtoV = 0;
   %obj.Vmountedto = "";
   if ( %node == 0 )
   {
      commandToClient( %obj.client, 'VehicleDismount' );
      commandToClient(%obj.client, 'removeReticle');

      if(%obj.inv[%obj.lastWeapon])
         %obj.use(%obj.lastWeapon);

      if(%obj.getMountedImage($WeaponSlot) == 0)
         %obj.selectWeaponSlot( 0 );

      //Inform gunner position when pilot leaves...
      //if(%vehicle.getDataBlock().showPilotInfo !$= "")
      //   if((%gunner = %vehicle.getMountNodeObject(1)) != 0)
      //      commandToClient(%gunner.client, 'PilotInfo', "PILOT EJECTED", 6, 1);
   }
   // ----------------------------------------------------------------------
   // z0dd - ZOD, 10/06/02. announce to any other passengers that you've left
   if(%vehicle.getDatablock().numMountPoints > 1)
   {
      %nodeName = findNodeName(%vehicle, %node); // function in vehicle.cs
      for(%i = 0; %i < %vehicle.getDatablock().numMountPoints; %i++)
      {
         if (%vehicle.getMountNodeObject(%i) > 0)
         {
            if(%vehicle.getMountNodeObject(%i).client != %obj.client)
            {
               %team = (%obj.team == %vehicle.getMountNodeObject(%i).client.team ? 'Teammate' : 'Enemy');
               messageClient( %vehicle.getMountNodeObject(%i).client, 'MsgShowPassenger', '\c2%3: \c3%1\c2 has ejected from the \c3%2\c2 position.', %obj.client.name, %nodeName, %team );
            }
            commandToClient( %vehicle.getMountNodeObject(%i).client, 'showPassenger', %node, false);
         }
      }
   }
   //AI hooks
   %obj.client.vehicleMounted = "";
   if(%obj.client.isAIControlled())
      %this.AIonUnMount(%obj, %vehicle, %node);
}

$ammoType[0] = "PlasmaAmmo";
$ammoType[1] = "DiscAmmo";
$ammoType[2] = "GrenadeLauncherAmmo";
$ammoType[3] = "MortarAmmo";
$ammoType[4] = "MissileLauncherAmmo";
$ammoType[5] = "ChaingunAmmo";
$ammoType[6] = "TR2DiscAmmo";
$ammoType[7] = "TR2GrenadeLauncherAmmo";
$ammoType[8] = "TR2ChaingunAmmo";
$ammoType[9] = "TR2MortarAmmo";
$ammoType[10] = "NerfBallLauncherAmmo";
$ammoType[11] = "SuperChaingunAmmo";
$ammoType[12] = "snipergunAmmo";
$ammoType[13] = "BazookaAmmo";
$ammoType[14] = "nukemeAmmo";
$ammoType[15] = "MG42Ammo";
$ammoType[16] = "flamerammo";
$ammoType[17] = "AALauncherAmmo";
$ammoType[18] = "Rifleclip";
$ammoType[19] = "MGclip";
$ammoType[20] = "Shotgunclip";
$ammoType[21] = "RShotgunclip";
$ammoType[22] = "LMissileLauncherAmmo";
$ammoType[23] = "RPGAmmo";
$ammoType[24] = "LSMGclip";
$ammoType[25] = "PBCAmmo";
$ammoType[26] = "SRifleSGAmmo";
$ammoType[27] = "SRifleGLAmmo";

function Armor::onCollision(%this,%obj,%col,%forceVehicleNode)
{
   if (%obj.getState() $= "Dead")
      return;

   %dataBlock = %col.getDataBlock();
   %colarmortype = %Datablock.getname();
   %className = %dataBlock.className;
   %objarmortype = %obj.getdatablock().getname();
   %client = %obj.client;
   // player collided with a vehicle
   %node = -1;
   if ((%objarmortype $= "ZombieArmor" || %objarmortype $= "FZombieArmor" || %objarmortype $= "LordZombieArmor " || %objarmortype $= "ControlLordZombieArmor") && %classname $= "WheeledVehicleData"){
	if(%colarmortype $= "VehicleTestCrate1"){
	   %spd = %obj.getvelocity();
	   %vec = %obj.getEyeVector();
	   %vector = vectorScale(vectorNormalize(%vec),(1000 + (vectorlen(%spd)*90)));
	   %x = getword(%vector,0);
	   %y = getword(%vector,1);
	   %upvec = 500;
	   %vector = %x@" "@%y@" "@%upvec;
	   %col.applyimpulse(%col.getposition(), %Vector);
	}
   }
   if (%forceVehicleNode !$= "" || (%className $= WheeledVehicleData || %className $= FlyingVehicleData || %className $= HoverVehicleData) &&
         %obj.mountVehicle && %obj.getState() $= "Move" && %col.mountable && !%obj.inStation && %col.getDamageState() !$= "Destroyed") {

      //if the player is an AI, he should snap to the mount points in node order,
      //to ensure they mount the turret before the passenger seat, regardless of where they collide...
      if (isObject(%obj.client) && %obj.client.isAIControlled()) // Eolk - console spam fix.
      {
         %transform = %col.getTransform();

         //either the AI is *required* to pilot, or they'll pick the first available passenger seat
         if (%client.pilotVehicle)
         {
            //make sure the bot is in light armor
            if (%client.player.getArmorSize() $= "Light")
            {
               //make sure the pilot seat is empty
               if (!%col.getMountNodeObject(0))
                  %node = 0;
            }
         }
         else
            %node = findAIEmptySeat(%col, %obj);
      }
      else
         %node = findEmptySeat(%col, %obj, %forceVehicleNode);

      //now mount the player in the vehicle
      if(%node >= 0)
      {
	   %obj.mountedtoV = 1;
	   %obj.Vmountedto = %col;
         // players can't be pilots, bombardiers or turreteers if they have
         // "large" packs -- stations, turrets, turret barrels
         if(hasLargePack(%obj)) {
            // check to see if attempting to enter a "sitting" node
            if(nodeIsSitting(%datablock, %node)) {
               // send the player a message -- can't sit here with large pack
               if(!%obj.noSitMessage)
               {
                  %obj.noSitMessage = true;
                  %obj.schedule(2000, "resetSitMessage");
                  messageClient(%obj.client, 'MsgCantSitHere', '\c2Pack too large, can\'t occupy this seat.~wfx/misc/misc.error.wav');
               }
               return;
            }
         }
         if(%col.noEnemyControl && %obj.team != %col.team)
            return;

         commandToClient(%obj.client,'SetDefaultVehicleKeys', true);
         //If pilot or passenger then bind a few extra keys
         if(%node == 0)
            commandToClient(%obj.client,'SetPilotVehicleKeys', true);
         else
            commandToClient(%obj.client,'SetPassengerVehicleKeys', true);

         if(!%obj.inStation)
            %col.lastWeapon = ( %col.getMountedImage($WeaponSlot) == 0 ) ? "" : %col.getMountedImage($WeaponSlot).getName().item;
         else
            %col.lastWeapon = %obj.lastWeapon;

	%obj.preVehicleMountPos = %obj.getPosition();

         %col.mountObject(%obj,%node);
         %col.playAudio(0, MountVehicleSound);
         %obj.mVehicle = %col;

			// if player is repairing something, stop it
			if(%obj.repairing)
				stopRepairing(%obj);

         //this will setup the huds as well...
         %dataBlock.playerMounted(%col,%obj, %node);
      }
   }
   else if (%classname $= "energizer")
      {
	// only detonate on contact in non-purebuild mode
	if ($Host::Purebuild == 0) {
		%col.damage(%col, 0, 10, $DamageType::Ground);
		%obj.damage(%col, 0, 10, $DamageType::Ground);
	}
      }
	// TODO - keep these up to date
	else if (%className $= "wall" || %className $= "wwall" || %className $= "spine" || %className $= "mspine" || %className $= "floor") {
		%obj.playAudio(0,(GetRandom()*2 >1) ? LFootMediumMetalSound : RFootMediumMetalSound);
		%obj.lastDepCol = %col;
		%obj.lastDepColPos = %obj.getPosition();
                if (%className $= "wall")
	            doorfunction(%obj,%col);
	}
   else if (%className $= "Armor") {
      // player has collided with another player
 if(%objarmortype $= "ZombieArmor" || %objarmortype $= "FZombieArmor" || %objarmortype $= "LordZombieArmor" || %objarmortype $= "DemonZombieArmor" || %objarmortype $= "ControlDemonZombieArmor" || %objarmortype $= "RapierZombieArmor" || %objarmortype $= "ControlRapierZombieArmor" || %objarmortype $= "ControlLordZombieArmor" || %objarmortype $= "DemonMotherZombieArmor")
	   %objiszomb = 1;
	else
	   %objiszomb = 0;
	if(%col.onfire == 1 && %obj.onfire != 1){
	   %obj.maxfirecount = (%col.maxfirecount - %col.firecount);
	   %obj.onfire = 1;
	   schedule(10, %obj, "burnloop", %obj);
	}
      if(%col.getState() $= "Dead") {
	   %obj.lasttouchedcorpse = %col;
	   if(%objarmortype !$= "ZombieArmor" || %objarmortype !$= "FZombieArmor"){
         %gotSomething = false;
         // it's corpse-looting time!
         // weapons -- don't pick up more than you are allowed to carry!
         for(%i = 0; ( %obj.weaponCount < %obj.getDatablock().maxWeapons ) && $InvWeapon[%i] !$= ""; %i++)
         {
            %weap = $NameToInv[$InvWeapon[%i]];
            if ( %col.hasInventory( %weap ) )
            {
               if ( %obj.incInventory(%weap, 1) > 0 )
               {
                  %col.decInventory(%weap, 1);
                  %gotSomething = true;
                  messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', %weap.pickUpName);
               }
            }
         }
         // targeting laser:
         if ( %col.hasInventory( "TargetingLaser" ) )
         {
            if ( %obj.incInventory( "TargetingLaser", 1 ) > 0 )
            {
               %col.decInventory( "TargetingLaser", 1 );
               %gotSomething = true;
               messageClient( %obj.client, 'MsgItemPickup', '\c0You picked up a targeting laser.' );
            }
         }
         // ammo
         for(%j = 0; $ammoType[%j] !$= ""; %j++)
         {
            %ammoAmt = %col.inv[$ammoType[%j]];
            if(%ammoAmt)
            {
               // incInventory returns the amount of stuff successfully grabbed
               %grabAmt = %obj.incInventory($ammoType[%j], %ammoAmt);
               if(%grabAmt > 0)
               {
                  %col.decInventory($ammoType[%j], %grabAmt);
                  %gotSomething = true;
                  messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', $ammoType[%j].pickUpName);
                  %obj.client.setWeaponsHudAmmo($ammoType[%j], %obj.getInventory($ammoType[%j]));
               }
            }
         }
         // figure out what type, if any, grenades the (live) player has
         %playerGrenType = "None";
         for(%x = 0; $InvGrenade[%x] !$= ""; %x++) {
            %gren = $NameToInv[$InvGrenade[%x]];
            %playerGrenAmt = %obj.inv[%gren];
            if(%playerGrenAmt > 0)
            {
               %playerGrenType = %gren;
               break;
            }
         }
         // grenades
         for(%k = 0; $InvGrenade[%k] !$= ""; %k++)
         {
            %gren = $NameToInv[$InvGrenade[%k]];
            %corpseGrenAmt = %col.inv[%gren];
            // does the corpse hold any of this grenade type?
            if(%corpseGrenAmt)
            {
               // can the player pick up this grenade type?
               if((%playerGrenType $= "None") || (%playerGrenType $= %gren))
               {
                  %taken = %obj.incInventory(%gren, %corpseGrenAmt);
                  if(%taken > 0)
                  {
                     %col.decInventory(%gren, %taken);
                     %gotSomething = true;
                     messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', %gren.pickUpName);
                     %obj.client.setInventoryHudAmount(%gren, %obj.getInventory(%gren));
                  }
               }
               break;
            }
         }
         // figure out what type, if any, mines the (live) player has
         %playerMineType = "None";
         for(%y = 0; $InvMine[%y] !$= ""; %y++)
         {
            %mType = $NameToInv[$InvMine[%y]];
            %playerMineAmt = %obj.inv[%mType];
            if(%playerMineAmt > 0)
            {
               %playerMineType = %mType;
               break;
            }
         }
         // mines
         for(%l = 0; $InvMine[%l] !$= ""; %l++)
         {
            %mine = $NameToInv[$InvMine[%l]];
            %mineAmt = %col.inv[%mine];
            if(%mineAmt) {
               if((%playerMineType $= "None") || (%playerMineType $= %mine))
               {
                  %grabbed = %obj.incInventory(%mine, %mineAmt);
                  if(%grabbed > 0)
                  {
                     %col.decInventory(%mine, %grabbed);
                     %gotSomething = true;
                     messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', %mine.pickUpName);
                     %obj.client.setInventoryHudAmount(%mine, %obj.getInventory(%mine));
                  }
               }
               break;
            }
         }
         // beacons
         %beacAmt = %col.inv[Beacon];
         if(%beacAmt)
         {
            %bTaken = %obj.incInventory(Beacon, %beacAmt);
            if(%bTaken > 0)
            {
               %col.decInventory(Beacon, %bTaken);
               %gotSomething = true;
               messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', Beacon.pickUpName);
               %obj.client.setInventoryHudAmount(Beacon, %obj.getInventory(Beacon));
            }
         }
         // repair kit
         %rkAmt = %col.inv[RepairKit];
         if(%rkAmt)
         {
            %rkTaken = %obj.incInventory(RepairKit, %rkAmt);
            if(%rkTaken > 0)
            {
               %col.decInventory(RepairKit, %rkTaken);
               %gotSomething = true;
               messageClient(%obj.client, 'MsgItemPickup', '\c0You picked up %1.', RepairKit.pickUpName);
               %obj.client.setInventoryHudAmount(RepairKit, %obj.getInventory(RepairKit));
            }
         }
	   }
      }
 else if((%colarmortype $= "ZombieArmor" || %col.canZkill == 1) && %obj.Infected != 1 && %objiszomb != 1){
	   %Vector = vectorscale(%col.getvelocity(), 100);
	   %obj.applyimpulse(%obj.getposition(), %Vector);
	   %obj.Infected = 1;
	   %obj.InfectedLoop = schedule(10, %obj, "InfectLoop", %obj);
	   %obj.damage(0, %obj.position, 0.2, $DamageType::Zombie);
	}
	else if(%colarmortype $= "FZombieArmor" && %obj.Infected != 1 && %objiszomb != 1){
	   if(%obj.hit == ""){
		%obj.hit = 1;
		%obj.setWhiteOut("0.5");
		playPain(%obj);
	   }
	   else if(%obj.hit == 1){
	   	%obj.Infected = 1;
	   	%obj.InfectedLoop = schedule(10, %obj, "InfectLoop", %obj);
	   }
	   %Vector = vectorscale(%col.getvelocity(), 100);
	   %obj.applyimpulse(%obj.getposition(), %Vector);
	   %obj.damage(0, %obj.position, 0.2, $DamageType::Zombie);
	}
	else if((%colarmortype $= "DemonZombieArmor" || %colarmortype $= "ControlDemonZombieArmor") && %obj.Infected != 1 && %objiszomb != 1){
	   %Vector = vectorscale(%col.getvelocity(), 100);
	   %obj.applyimpulse(%obj.getposition(), %Vector);
	   %obj.Infected = 1;
	   %obj.InfectedLoop = schedule(10, %obj, "InfectLoop", %obj);
	   %obj.damage(0, %obj.position, 0.4, $DamageType::Zombie);
	}
	else if((%colarmortype $= "RapierZombieArmor" || %colarmortype $= "ControlRapierZombieArmor") && %obj.grabbed != 1 && %objiszomb != 1){
	   %chance = getRandom(1,3);
	   if(%chance == 3 && %obj.Infected != 1){
		%obj.damage(0, %obj.position, 0.4, $DamageType::Zombie);
		%obj.Infected = 1;
		%obj.InfectedLoop = schedule(10, %obj, "InfectLoop", %obj);
	   } else {
		%col.iscarrying = 1;
		%obj.grabbed = 1;
		%obj.damage(0, %obj.position, 0.2, $DamageType::Zombie);
		%col.killingPlayer = schedule(10, 0, "RkillLoop", %col, %obj, 0);
	   }
	}
	else if((%colarmortype $= "ZombieArmor" || %col.canZkill == 1) && %objiszomb != 1)
	   %obj.damage(0, %obj.position, 0.2, $DamageType::Zombie);
	else if(%colarmortype $= "FZombieArmor" && %objiszomb != 1)
	   %obj.damage(0, %obj.position, 0.4, $DamageType::Zombie);
	else if((%colarmortype $= "DemonZombieArmor" || %colarmortype $= "ControlDemonZombieArmor") && %objiszomb != 1)
	   %obj.damage(0, %obj.position, 0.4, $DamageType::Zombie);
	else if(%colarmortype $= "DemonMotherZombieArmor" && %objiszomb != 1){
	   if(%obj.Infected != 1){
		%obj.Infected = 1;
		%obj.damage(0, %obj.position, 0.8, $DamageType::Zombie);
		%obj.InfectedLoop = schedule(10, %obj, "InfectLoop", %obj);
	   } else 
		%obj.damage(0, %obj.position, 1.2, $DamageType::Zombie);
	}
	else if ($PlayerSnapTo == true) {
		if (!isObject(%col.getMountedObject(0))) {
			if (!isObject(%obj.getMountedObject(0)) || %obj.getMountedObject(0) != %col) {
				%col.mountObject(%obj,$BackPackSlot);
				%gotSomething = true;
			}
		}
	}
	else if ($NaughtyMode == true) {
		playPain(%obj);
		playPain(%col);
	}
	else if ($AngstMode == true) {
		playDeathCry(%obj);
		playDeathCry(%col);
	}
	if ($JumpyMode == true) {
		%obj.applyImpulse(%obj.getPosition(),"0 0 500");
		%col.applyImpulse(%col.getPosition(),"0 0 500");
	}
	if (%obj.client.race $= "Human" && $SexChangeMode == true) {
		if (%obj.client.oldSex $= "")
			%obj.client.oldSex = %obj.client.sex;
		if (%obj.client.oldVoice $= "")
			%obj.client.oldVoice = %obj.client.voice;
		%voice = getTaggedString(getTargetVoice(%obj.client.target));
		%voiceNum = getSubStr(%voice,strLen(%voice)-1,1);
		if (%obj.client.sex $= "Male") {
			%obj.client.sex = "Female";
			%obj.client.voiceTag =  addTaggedString("Fem" @ %voiceNum);
			setTargetVoice(%obj.client.target,%obj.client.voiceTag);
		}
		else {
			%obj.client.sex = "Male";
			%obj.client.voiceTag =  addTaggedString("Male" @ %voiceNum);
			setTargetVoice(%obj.client.target,%obj.client.voiceTag);
		}
		%obj.setArmor(%client.armor);
	}
	if(%gotSomething)
		%col.playAudio(0, CorpseLootingSound);
   }
}

function Player::resetSitMessage(%obj)
{
   %obj.noSitMessage = false;
}

function Player::setInvincible(%this, %val)
{
   %this.invincible = %val;
}

function Player::causedRecentDamage(%this, %val)
{
   %this.causedRecentDamage = %val;
}

function hasLargePack(%player)
{
   %pack = %player.getMountedImage($BackpackSlot);
   if(%pack.isLarge)
      return true;
   else
      return false;
}

function nodeIsSitting(%vehDBlock, %node)
{
   // pilot == always a "sitting" node
   if(%node == 0)
      return true;
   else {
      switch$ (%vehDBlock.getName())
      {
         // note: for assault tank -- both nodes are sitting
         // for any single-user vehicle -- pilot node is sitting
         case "BomberFlyer":
            // bombardier == sitting; tailgunner == not sitting
            if(%node == 1)
               return true;
            else
               return false;
         case "HAPCFlyer":
            // only the pilot node is sitting
            return false;
         case "SuperHAPCFlyer":
            // only the pilot node is sitting
            return false;
         default:
            return true;
      }
   }
}

//----------------------------------------------------------------------------
function Player::setMountVehicle(%this, %val)
{
   %this.mountVehicle = %val;
}

function Armor::doDismount(%this, %obj, %forced,%eject) {
   // This function is called by player.cc when the jump trigger
   // is true while mounted
   if (!%obj.isMounted())
      return;
   //[most] emp hook
   if (%obj.isemped)
      return;
   //[most]

	%obj.mountedtoV = 0;
	%obj.Vmountedto = "";

	%vehicle = %obj.getObjectMount();
	%vehicleData = %vehicle.getDataBlock();

   if(isObject(%obj.getObjectMount().shield))
      %obj.getObjectMount().shield.delete();

   commandToClient(%obj.client,'SetDefaultVehicleKeys', false);

 if (%Eject)
      %push = 30;
   else
      %push = 5;


   // Position above dismount point

   %pos    = getWords(%obj.getTransform(), 0, 2);
   %oldPos = %pos;
   %vec[0] = " 0  0  1";
   %vec[1] = " 0  0  1";
   %vec[2] = " 0  0 -1";
   %vec[3] = " 1  0  0";
   %vec[4] = "-1  0  0";
   %numAttempts = 5;
   %success     = -1;
   %impulseVec  = "0 0 0";
   if (%obj.getObjectMount().getDatablock().hasDismountOverrides() == true)
   {
      %vec[0] = %obj.getObjectMount().getDatablock().getDismountOverride(%obj.getObjectMount(), %obj);
      %vec[0] = MatrixMulVector(%obj.getObjectMount().getTransform(), %vec[0]);
   }
   else
   {
      %vec[0] = MatrixMulVector( %obj.getTransform(), %vec[0]);
   }

   %pos = "0 0 0";
   for (%i = 0; %i < %numAttempts; %i++)
   {
      %pos = VectorAdd(%oldPos, VectorScale(%vec[%i], 3));
      if (%obj.checkDismountPoint(%oldPos, %pos))
      {
         %success = %i;
         %impulseVec = %vec[%i];
         break;
      }
   }
   if (%forced && %success == -1)
   {
      %pos = %oldPos;
   }

   // hide the dashboard HUD and delete elements based on node
   commandToClient(%obj.client, 'setHudMode', 'Standard', "", 0);
   // Unmount and control body
   if(%obj.vehicleTurret)
      %obj.vehicleTurret.getDataBlock().playerDismount(%obj.vehicleTurret);
   %obj.unmount();
   if(%obj.mVehicle)
      %obj.mVehicle.getDataBlock().playerDismounted(%obj.mVehicle, %obj);

   // bots don't change their control objects when in vehicles
   if(!%obj.client.isAIControlled())
   {
      %vehicle = %obj.getControlObject();
      %obj.setControlObject(0);
   }

   %obj.mountVehicle = false;
   %obj.schedule(4000, "setMountVehicle", true);

   // Position above dismount point
   %obj.setTransform(%pos);
   %obj.playAudio(0, UnmountVehicleSound);
   %obj.applyImpulse(%pos, VectorScale(%impulseVec, %obj.getDataBlock().mass * 3 * %push));
   %obj.setPilot(false);
   %obj.vehicleTurret = "";
}

function resetObserveFollow( %client, %dismount )
{
   if( %dismount )
   {
      if( !isObject( %client.player ) )
         return;

      for( %i = 0; %i < %client.observeCount; %i++ )
      {
      if (isObject(%client.observers[%i].camera))
         %client.observers[%i].camera.setOrbitMode( %client.player, %client.player.getTransform(), 0.5, 4.5, 4.5);
      }
   }
   else
   {
      if( !%client.player.isMounted() )
         return;

      // grab the vehicle...
      %mount = %client.player.getObjectMount();
      if( %mount.getDataBlock().observeParameters $= "" )
         %params = %client.player.getTransform();
      else
         %params = %mount.getDataBlock().observeParameters;

      for( %i = 0; %i < %client.observeCount; %i++ )
      {
      if (isObject(%client.observers[%i].camera))
         %client.observers[%i].camera.setOrbitMode(%mount, %mount.getTransform(), getWord( %params, 0 ), getWord( %params, 1 ), getWord( %params, 2 ));
      }
   }
}


//----------------------------------------------------------------------------

function Player::scriptKill(%player, %damageType)
{
   %player.scriptKilled = 1;
   %player.setInvincible(false);
   %player.damage(0, %player.getPosition(), 10000, %damageType);
}

function Armor::damageObject(%data, %targetObject, %sourceObject, %position, %amount, %damageType, %momVec, %mineSC) {
//	error("Armor::damageObject( "@%data@", "@%targetObject@", "@%sourceObject@", "@%position@", "@%amount@", "@%damageType@", "@%momVec@" )");
	if (%targetObject.invincible || %targetObject.getState() $= "Dead"
	|| ((%targetObject.client.isJailed || %targetObject.client.permInvincible) && !%targetObject.scriptKilled))
	return;


   //----------------------------------------------------------------
   // z0dd - ZOD, 6/09/02. Check to see if this vehcile is destroyed,
   // if it is do no damage. Fixes vehicle ghosting bug. We do not
   // check for isObject here, destroyed objects fail it even though
   // they exist as objects, go figure.
   if(%damageType == $DamageType::Impact)
      if(%sourceObject.getDamageState() $= "Destroyed")
         return;
   %armortype = %targetobject.getdatablock().getname();
   if (%damageType == $DamageType::ZAcid && %armortype !$= "ZombieArmor" && %armortype !$= "FZombieArmor" && %armortype !$= "ControlFZombieArmor" && %armortype !$= "LordZombieArmor" && %armortype !$= "ControlLordZombieArmor" && %armortype !$= "DemonZombieArmor" && %armortype !$= "ControlDemonZombieArmor" && %armortype !$= "DemonMotherZombieArmor" && %armortype !$= "RapierZombieArmor" && %armortype !$= "ControlRapierZombieArmor" && %targetobject.infected != 1) {
	   %targetObject.Infected = 1;
	   %targetObject.InfectedLoop = schedule(10, %targetObject, "InfectLoop", %targetObject);
   }
   if (%targetObject.isMounted() && %targetObject.scriptKilled $= "")
   {
      %mount = %targetObject.getObjectMount();
      if(%mount.team == %targetObject.team)
      {
         %found = -1;
         for (%i = 0; %i < %mount.getDataBlock().numMountPoints; %i++)
         {
            if (%mount.getMountNodeObject(%i) == %targetObject)
            {
               %found = %i;
               break;
            }
         }

         if (%found != -1)
         {
            if (%mount.getDataBlock().isProtectedMountPoint[%found])
            {
               %mount.getDataBlock().damageObject(%mount, %sourceObject, %position, %amount, %damageType);
               return;
            }
         }
      }
   }

   %targetClient = %targetObject.getOwnerClient();
   if(isObject(%mineSC))
      %sourceClient = %mineSC;
   else
      %sourceClient = isObject(%sourceObject) ? %sourceObject.getOwnerClient() : 0;

   %targetTeam = %targetClient.team;

   //if the source object is a player object, player's don't have sensor groups
   // if it's a turret, get the sensor group of the target
   // if its a vehicle (of any type) use the sensor group
   if (%sourceClient)
      %sourceTeam = %sourceClient.getSensorGroup();
   else if(%damageType == $DamageType::Suicide)
      %sourceTeam = 0;

   //--------------------------------------------------------------------------------------------------------------------
   // z0dd - ZOD, 5/8/02. Check to see if this turret has a valid owner, if not clear the owner varible.
   //else if(isObject(%sourceObject) && %sourceObject.getClassName() $= "Turret")
   //   %sourceTeam = getTargetSensorGroup(%sourceObject.getTarget());
   else if(isObject(%sourceObject) && %sourceObject.getClassName() $= "Turret")
   {
      %sourceTeam = getTargetSensorGroup(%sourceObject.getTarget());
      if(%sourceObject.getOwner() !$="" && (%sourceObject.getOwner().team != %sourceObject.team || !isObject(%sourceObject.getOwner())))
         %sourceObject.setOwner();
   }
   // End z0dd - ZOD
   //--------------------------------------------------------------------------------------------------------------------
   else if( isObject(%sourceObject) &&
   	( %sourceObject.getClassName() $= "FlyingVehicle" || %sourceObject.getClassName() $= "WheeledVehicle" || %sourceObject.getClassName() $= "HoverVehicle"))
      %sourceTeam = getTargetSensorGroup(%sourceObject.getTarget());
   else
   {
      if (isObject(%sourceObject) && %sourceObject.getTarget() >= 0 )
      {
         %sourceTeam = getTargetSensorGroup(%sourceObject.getTarget());
      }
      else
      {
         %sourceTeam = -1;
      }
   }

   // if teamdamage is off, and both parties are on the same team
   // (but are not the same person), apply no damage
   if(!$teamDamage && (%targetClient != %sourceClient) && (%targetTeam == %sourceTeam))
      return;

   if(%targetObject.isShielded && %damageType != $DamageType::Blaster)
      %amount = %data.checkShields(%targetObject, %position, %amount, %damageType);

   if(%amount == 0)
      return;

   if (%damageType == $DamageType::Plasma){
	   if(%targetObject.maxfirecount $= "")
		%targetObject.maxfirecount = 0;
	   %targetObject.maxfirecount = %targetObject.maxfirecount + (30 * (%amount / 0.2));
	   if(%targetObject.onfire == 0 || %targetObject.onfire $= ""){
		%targetObject.onfire = 1;
		schedule(10, %targetObject, "burnloop", %targetObject);
	   }
   }

   // Set the damage flash
   %damageScale = %data.damageScale[%damageType];
   if(%damageScale !$= "")
      %amount *= %damageScale;

   %flash = %targetObject.getDamageFlash() + (%amount * 2);
   if (%flash > 0.75)
      %flash = 0.75;

   %previousDamage = %targetObject.getDamagePercent();
   %targetObject.setDamageFlash(%flash);

	if ($Host::InvincibleArmors == 1 && !%targetObject.scriptKilled) {
		if ((%sourceObject.team != %targetObject.team) || Game.numTeams == 1) {
			%wp = new WayPoint() {
				position = %targetObject.getWorldBoxCenter();
				dataBlock = "WayPointMarker";
				team = (%sourceObject.team == %targetObject.team) ? 0 : %sourceObject.team;
				name = mFloatLength((100 / %data.maxDamage) * %amount,0) @ "%";
			};
			MissionCleanup.add(%wp);
			%wp.schedule(1500,delete);
		}
	}
	else
		%targetObject.applyDamage(%amount);

   Game.onClientDamaged(%targetClient, %sourceClient, %damageType, %sourceObject);

   %targetClient.lastDamagedBy = %damagingClient;
   %targetClient.lastDamaged = getSimTime();

   //now call the "onKilled" function if the client was... you know...
   if(%targetObject.getState() $= "Dead")
   {
      if(%targetObject.overwatcher > 0)
         if((%temporary = findword(%targetObject.overwatcher.zombieList, %targetObject)) !$= "")
            %targetObject.overwatcher.zombieList = listDel(%targetObject.overwatcher.zombieList, %temporary);

	if(isObject(%targetObject.beacon))
         %targetObject.beacon.schedule(50, delete);
      // where did this guy get it?
      %damLoc = %targetObject.getDamageLocation(%position);

      // should this guy be blown apart?
      if( %damageType == $DamageType::Explosion ||
          %damageType == $DamageType::TankMortar ||
          %damageType == $DamageType::Mortar ||
          %damageType == $DamageType::MortarTurret ||
          %damageType == $DamageType::BomberBombs ||
          %damageType == $DamageType::SatchelCharge ||
          %damageType == $DamageType::Bazooka ||
          %damageType == $DamageType::Laser ||
          %damageType == $DamageType::Artillery ||
          %damageType == $DamageType::SuperChaingun ||
          %damageType == $DamageType::ZombieL ||
          %damageType == $DamageType::OutdoorDepTurret ||
          %damageType == $DamageType::Missile )
      {
         if( %previousDamage >= 0.35 ) // only if <= 35 percent damage remaining
         {
            %targetObject.setMomentumVector(%momVec);
            %targetObject.blowup();
		%targetObject.kibbled = 1;
         }
      }

      // this should be funny...
      if( %damageType == $DamageType::VehicleSpawn )
      {
         %targetObject.setMomentumVector("0 0 1");
         %targetObject.blowup();
      }

      // If we were killed, max out the flash
      %targetObject.setDamageFlash(0.75);

      %damLoc = %targetObject.getDamageLocation(%position);
      Game.onClientKilled(%targetClient, %sourceClient, %damageType, %sourceObject, %damLoc);
   }
   else if ( %amount > 0.1 )
   {
      if( %targetObject.station $= "" && %targetObject.isCloaked() )
      {
         %targetObject.setCloaked( false );
         %targetObject.reCloak = %targetObject.schedule( 500, "setCloaked", true );
      }

      playPain( %targetObject );
   }
}

function Armor::onImpact(%data, %playerObject, %collidedObject, %vec, %vecLen) {
	%data.damageObject(%playerObject, 0, VectorAdd(%playerObject.getPosition(),%vec),
	%vecLen * %data.speedDamageScale , $DamageType::Ground);
//	if (%collidedObject & $TypeMasks::PlayerObjectType) {
//		if (%collidedObject.getState() !$= "Dead") {
//			%data.damageObject(%collidedObject, 0, VectorAdd(%playerObject.getPosition(),%vec),
//			%vecLen * %data.speedDamageScale , $DamageType::Ground);
//		}
//	}
}

function Armor::applyConcussion( %this, %dist, %radius, %sourceObject, %targetObject )
{
   %percentage = 1 - ( %dist / %radius );
   %random = getRandom();

   if( %sourceObject == %targetObject )
   {
      %flagChance = 1.0;
      %itemChance = 1.0;
   }
   else
   {
      %flagChance = 0.7;
      %itemChance = 0.7;
   }

   %probabilityFlag = %flagChance * %percentage;
   %probabilityItem = %itemChance * %percentage;

   if( %random <= %probabilityFlag )
   {
      Game.applyConcussion( %targetObject );
   }

   if( %random <= %probabilityItem )
   {
      // Eolk - why do all the complicated stuff when you can just do this?
      %targetObject.throwPack();
      %targetObject.throwWeapon();
   }
}

//----------------------------------------------------------------------------

$DeathCry[1] = 'avo.deathCry_01';
$DeathCry[2] = 'avo.deathCry_02';
$PainCry[1] = 'avo.grunt';
$PainCry[2] = 'avo.pain';

function playDeathCry( %obj )
{
   if(%obj.grabbed == 1)
	return;
   %client = %obj.client;
   %random = getRandom(1) + 1;
   %desc = AudioClosest3d;

   playTargetAudio( %client.target, $DeathCry[%random], %desc, false );
}

function playPain( %obj )
{
   if(%obj.grabbed == 1)
	return;
   %client = %obj.client;
   if(%client $= "")
	return;
   %random = getRandom(1) + 1;
   %desc = AudioClosest3d;

   playTargetAudio( %client.target, $PainCry[%random], %desc, false);
}

//----------------------------------------------------------------------------

//$DefaultPlayerArmor = LightMaleHumanArmor;
$DefaultPlayerArmor = Light;

function Player::setArmor(%this,%size)
{
   // Takes size as "Light","Medium", "Heavy"
   %client = %this.client;
   if (%client.race $= "Bioderm")
      // Only have male bioderms.
      %armor = %size @ "Male" @ %client.race @ Armor;
   else
      %armor = %size @ %client.sex @ %client.race @ Armor;
   //echo("Player::armor: " @ %armor);
   %this.setDataBlock(%armor);
   %client.armor = %size;
}

function getDamagePercent(%maxDmg, %dmgLvl)
{
   return (%dmgLvl / %maxDmg);
}

function Player::getArmorSize(%this)
{
   // return size as "Light","Medium", "Heavy"
   %dataBlock = %this.getDataBlock().getName();
   if (getSubStr(%dataBlock, 0, 5) $= "Light")
      return "Light";
   else if (getSubStr(%dataBlock, 0, 6) $= "Medium")
      return "Medium";
   else if (getSubStr(%dataBlock, 0, 5) $= "Heavy")
      return "Heavy";
   else if (getSubStr(%dataBlock, 0, 5) $= "SpecOps")
      return "SpecOps";
   else if (getSubStr(%dataBlock, 0, 4) $= "Pure")
      return "Pure";
   else if (getSubStr(%dataBlock, 0, 8) $= "TR2Light")
      return "TR2Light";
   else if (getSubStr(%dataBlock, 0, 9) $= "TR2Medium")
      return "TR2Medium";
   else if (getSubStr(%dataBlock, 0, 8) $= "TR2Heavy")
      return "TR2Heavy";
   else
      return "Unknown";
}

function Player::pickup(%this,%obj,%amount)
{
	if (%this.client.isJailed)
		return 0;
   %data = %obj.getDataBlock();
   // Don't pick up a pack if we already have one mounted
   if (%data.className $= Pack &&
         %this.getMountedImage($BackpackSlot) != 0)
      return 0;
	// don't pick up a weapon (other than targeting laser) if player's at maxWeapons
   else if(%data.className $= Weapon
     && %data.getName() !$= "TargetingLaser"  // Special case
     && %this.weaponCount >= %this.getDatablock().maxWeapons)
      return 0;
	// don't allow players to throw large packs at pilots (thanks Wizard)
   else if(%data.className $= Pack && %data.image.isLarge && %this.isPilot())
		return 0;
   return ShapeBase::pickup(%this,%obj,%amount);
}

function Player::use( %this,%data )
{
   // If player is in a station then he can't use any items
   if(%this.station !$= "")
      return false;

   // Convert the word "Backpack" to whatever is in the backpack slot.
   if ( %data $= "Backpack" )
   {
      if ( %this.inStation )
         return false;

      if ( %this.isPilot() )
      {
	%vehicle = %this.getObjectMount();
	if (%vehicle.getDataBlock().getName() $= "MobileBaseVehicle" && $Host::Purebuild == 1) {
		%vehicle.applyImpulse(%vehicle.getPosition(),"0 0 8000");
		return( false );
	}
        //[most]
        else if (%vehicle.base.leftpad == %vehicle)
             {
             PressButton(%vehicle,%this,0,0);
             }
        else if (%vehicle.base.rightpad == %vehicle)
             {
             PressButton(%vehicle,%this,1,0);
             }
        //[most]
	else {
		messageClient( %this.client, 'MsgCantUsePack', '\c2You can\'t use your pack while piloting.~wfx/misc/misc.error.wav' );
		return( false );
	}
      }
      else if ( %this.isWeaponOperator() )
      {
         messageClient( %this.client, 'MsgCantUsePack', '\c2You can\'t use your pack while in a weaponry position.~wfx/misc/misc.error.wav' );
         return( false );
      }

      %image = %this.getMountedImage( $BackpackSlot );
      if ( %image )
         %data = %image.item;
   }

   // Can't use some items when piloting or your a weapon operator
   if ( %this.isPilot() || %this.isWeaponOperator() )
      if (isObject(%data) && %data.getName() !$= "RepairKit" )
         return false;
  // Convert the word "Backpack" to whatever is in the backpack slot.
  //[most]
   if (isObject(%data) && %data.getName() $= "RepairKit" )
   {     
      if ( %this.isPilot() )
      {       
	%vehicle = %this.getObjectMount();
        if (%vehicle.base.leftpad == %vehicle)
             {
             PressButton(%vehicle,%this,0,1);
             }
        else if (%vehicle.base.rightpad == %vehicle)
             {
             PressButton(%vehicle,%this,1,1);
             }
       
      }
   }
   //[most]

   return ShapeBase::use( %this, %data );
}

function Player::maxInventory(%this,%data)
{
   %max = ShapeBase::maxInventory(%this,%data);
   if (%this.getInventory(AmmoPack))
      %max += AmmoPack.max[%data.getName()];
   else if (%this.getInventory(flamerAmmoPack))
      %max += flamerAmmoPack.max[%data.getName()];
   return %max;
}

function Player::isPilot(%this)
{
   %vehicle = %this.getObjectMount();
   // There are two "if" statements to avoid a script warning.
   if (%vehicle)
      if (%vehicle.getMountNodeObject(0) == %this)
         return true;
   return false;
}

function Player::isWeaponOperator(%this)
{
   %vehicle = %this.getObjectMount();
   if ( %vehicle )
   {
      %weaponNode = %vehicle.getDatablock().weaponNode;
      if ( %weaponNode > 0 && %vehicle.getMountNodeObject( %weaponNode ) == %this )
         return( true );
   }

   return( false );
}

function Player::liquidDamage(%obj, %data, %damageAmount, %damageType)
{
   if(%obj.getState() !$= "Dead")
   {
      %data.damageObject(%obj, 0, "0 0 0", %damageAmount, %damageType);
      %obj.lDamageSchedule = %obj.schedule(50, "liquidDamage", %data, %damageAmount, %damageType);
   }
   else
      %obj.lDamageSchedule = "";
}

function Armor::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
       if(Game.class $= "ConstructionGame") {
          return;
       }
       if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       } else if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       }
      case 1:
         //Ocean Water
       if(Game.class $= "ConstructionGame") {
          return;
       }
       if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       } else if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       }
      case 2:
         //River Water
       if(Game.class $= "ConstructionGame") {
          return;
       }
       if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       } else if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       }
      case 3:
         //Stagnant Water
       if(Game.class $= "ConstructionGame") {
          return;
       }
       if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj); 
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       } else if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
   	   	%obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj);
   	   	%obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj);
		%obj.Drowning = 1;
       }
      case 4:
         //Lava
         %obj.liquidDamage(%data, $DamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $DamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $DamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}

function Armor::onLeaveLiquid(%data, %obj, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         Cancel(%obj.DrownLoop);
         Cancel(%obj.CheckDLoop);
	   %obj.Drowning = 0;
      case 1:
         //Ocean Water
         Cancel(%obj.DrownLoop);
         Cancel(%obj.CheckDLoop);
	   %obj.Drowning = 0;
      case 2:
         //River Water
         Cancel(%obj.DrownLoop);
         Cancel(%obj.CheckDLoop);
	   %obj.Drowning = 0;
      case 3:
         //Stagnant Water
         Cancel(%obj.DrownLoop);
         Cancel(%obj.CheckDLoop);
	   %obj.Drowning = 0;
      case 4:
         //Lava
      case 5:
         //Hot Lava
      case 6:
         //Crusty Lava
      case 7:
         //Quick Sand
   }

   if(%obj.lDamageSchedule !$= "")
   {
      cancel(%obj.lDamageSchedule);
      %obj.lDamageSchedule = "";
   }
}

function DrowningLoop(%obj) 
{ 
   if(isObject(%obj))
   {
      %obj.damage(0, %obj.getPosition(), 0.05, $DamageType::Drown);
   	%obj.DrownLoop = schedule(250, 0, "DrowningLoop", %obj); 
   }
}

function checkforwater(%obj){
   if(isObject(%obj)){
   %eyeVec   = %obj.getEyeVector();
   %eyeTrans = %obj.getEyeTransform();
   %eyePos = posFromTransform(%eyeTrans);
   %vector = vectorAdd("0 0 -4", %eyepos);
   %searchresult = containerRayCast(%eyePos, %vector, $TypeMasks::WaterObjectType);
   if(%searchresult){
	if(%obj.Drowning == 1){
         Cancel(%obj.DrownLoop);
	   %obj.Drowning = 0;
	}
   }
   else if(%obj.Drowning == 0){
   	if (!( %obj.isPilot() || %obj.isWeaponOperator() )){
	   %obj.DrownLoop = schedule(15000, 0, "DrowningLoop", %obj); 
	   %obj.Drowning = 1;
	}
   } 
   %obj.CheckDLoop = schedule(500, 0, "checkforwater", %obj); 
   }
}

function Armor::onTrigger(%data, %player, %triggerNum, %val)
{
   if (%triggerNum == 4)
   {
      // Eolk - cleaned this area up a tad. Made it more "readable."
      %currentWeap = %player.getMountedImage($weaponSlot).getName().item;
      if (%currentWeap  $= HRPChaingun)
      {
         if ( !(%val == 1) )
            %player.setImageTrigger(5, false);

         if (%player.inv[RPGAmmo] > 0)
         {
            if (%val == 1)
               %player.setImageTrigger(5, true);
            else
               %player.setImageTrigger(5, false);
         }
         else
         {
            // Throw grenade
            if (%val == 1)
            {
               %player.grenTimer = 1;
            }
            else
            {
               if (%player.grenTimer == 0)
               {
                  // Bad throw for some reason
               }
               else
               {
                  %player.use(Grenade);
                  %player.grenTimer = 0;
               }
            }
         }
      }
      else
      {
         // Throw grenade
         if (%val == 1)
         {
            %player.grenTimer = 1;
         }
         else
         {
            if (%player.grenTimer == 0)
            {
               // Bad throw for some reason
            }
            else
            {
               %player.use(Grenade);
               %player.grenTimer = 0;
            }
         }
      } 
   }
   else if (%triggerNum == 5)
   {
      // Throw mine
      if (%val == 1)
      {
         %player.mineTimer = 1;
      }
      else
      {
         if (%player.mineTimer == 0)
         {
            // Bad throw for some reason
         }
         else
         {
            %player.use(Mine);
            %player.mineTimer = 0;
         }
      }
   }
   else if (%triggerNum == 3)
   {
      if(%player.getMountedImage($weaponslot))
      {
         if(%player.getMountedImage($WeaponSlot).getName() $= "MedPackGunImage" && %val == 1)
         {
            if(%player.reviveMode == 1)
               checkrevive(%player);
            else
               checkcure(%player);
         }
         // Eolk - Removed SRifle stuff. Was irrelevant now that the weapon is gone.
         // Eolk - put it back, we might be using it soon...
         else if (%player.getMountedImage($WeaponSlot).getName() $= "SRifleImage")
         {
            if ( !(%val == 1) )
               %player.setImageTrigger(7, false);   
            if (%player.inv[SRifleSGAmmo] > 0 || %player.inv[SRifleGLAmmo] > 0)
            {
               if (%val == 1)
                  %player.setImageTrigger(7, true);
               else
                  %player.setImageTrigger(7, false);
            }
         }
      }
      else
      {
         if(%val == 1)
            %player.isJetting = true;
         else
            %player.isJetting = false;
      }
   }
}

function Player::setMoveState(%obj, %move)
{
   %obj.disableMove(%move);
}

function Armor::onLeaveMissionArea(%data, %obj)
{
   Game.leaveMissionArea(%data, %obj);
}

function Armor::onEnterMissionArea(%data, %obj)
{
   Game.enterMissionArea(%data, %obj);
}

function Armor::animationDone(%data, %obj)
{
   if(%obj.animResetWeapon !$= "")
   {
      if(%obj.getMountedImage($WeaponSlot) == 0)
         if(%obj.inv[%obj.lastWeapon])
            %obj.use(%obj.lastWeapon);
      %obj.animSetWeapon = "";
   }
}

function playDeathAnimation(%player, %damageLocation, %type)
{
   %vertPos = firstWord(%damageLocation);
   %quadrant = getWord(%damageLocation, 1);

   //echo("vert Pos: " @ %vertPos);
   //echo("quad: " @ %quadrant);

   if( %type == $DamageType::Explosion || %type == $DamageType::Mortar || %type == $DamageType::Grenade)
   {
      if(%quadrant $= "front_left" || %quadrant $= "front_right")
         %curDie = $PlayerDeathAnim::ExplosionBlowBack;
      else
         %curDie = $PlayerDeathAnim::TorsoBackFallForward;
   }
   else if(%vertPos $= "head")
   {
      if(%quadrant $= "front_left" ||  %quadrant $= "front_right" )
         %curDie = $PlayerDeathAnim::HeadFrontDirect;
      else
         %curDie = $PlayerDeathAnim::HeadBackFallForward;
   }
   else if(%vertPos $= "torso")
   {
      if(%quadrant $= "front_left" )
         %curDie = $PlayerDeathAnim::TorsoLeftSpinDeath;
      else if(%quadrant $= "front_right")
         %curDie = $PlayerDeathAnim::TorsoRightSpinDeath;
      else if(%quadrant $= "back_left" )
         %curDie = $PlayerDeathAnim::TorsoBackFallForward;
      else if(%quadrant $= "back_right")
         %curDie = $PlayerDeathAnim::TorsoBackFallForward;
   }
   else if (%vertPos $= "legs")
   {
      if(%quadrant $= "front_left" ||  %quadrant $= "back_left")
         %curDie = $PlayerDeathAnim::LegsLeftGimp;
      if(%quadrant $= "front_right" || %quadrant $= "back_right")
         %curDie = $PlayerDeathAnim::LegsRightGimp;
   }

   if(%curDie $= "" || %curDie < 1 || %curDie > 11)
      %curDie = 1;

   %player.setActionThread("Death" @ %curDie);
}

function Armor::onDamage(%data, %obj)
{
   if(%obj.station !$= "" && %obj.getDamageLevel() == 0)
      %obj.station.getDataBlock().endRepairing(%obj.station);
}

datablock TargetProjectileData(FlashLightTargeter)
{
   directDamage        	= 0.0;
   hasDamageRadius     	= false;
   indirectDamage      	= 0.0;
   damageRadius        	= 0.0;
   velInheritFactor    	= 1.0;

   maxRifleRange       	= 100;
   beamColor           	= "1.0 1.0 1.0";
								
   startBeamWidth			= 0.0; 
   pulseBeamWidth 	   = 0.0; 
   beamFlareAngle 	   = 10.0;
   minFlareSize        	= 0.0;
   maxFlareSize        	= 600.0;
   pulseSpeed          	= 6.0;
   pulseLength         	= 0.150;

   hasLight    = true;
   lightRadius = 10.0;
   lightColor  = "1.0 1.0 1.0 0.3";

   textureName[0]      	= "special/nonlingradient";
   textureName[1]      	= "special/flare";
   textureName[2]      	= "special/pulse";
   textureName[3]      	= "special/expFlare";
   beacon               = false;
};

datablock ShapeBaseImageData(FlashLightImage)
{
   className = WeaponImage;

   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 0 0";

   projectile = FlashLightTargeter;
   projectileType = TargetProjectile;
   deleteLastProjectile = false;

   usesEnergy = true;
   minEnergy = 1;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
	stateSound[0]                    = TargetingLaserSwitchSound;
   stateTimeoutValue[0]             = 0.15;
   stateTransitionOnTimeout[0]      = "Fire";

   stateName[3]                     = "Fire";
   stateEnergyDrain[3]              = 1;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFire";
   stateTransitionOnNoAmmo[3]       = "Deconstruction";

   stateName[5]                     = "Deconstruction";
   stateScript[5]                   = "deconstruct";
   stateTransitionOnTimeout[5]      = "Ready";
};

function FlashLightImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.LP = %p;
}

function FlashLightImage::deconstruct(%data, %obj, %slot)
{
   Parent::deconstruct(%data, %obj, %slot);
   %obj.client.NVActivated = 0;
   %obj.unmountImage(7);
   messageClient(%obj.client, 'MsgNVNP', '\c2Flash Light out of power, holstiering.');
}
function FlashLightImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.LP.delete();
}
