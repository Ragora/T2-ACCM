//**************************************************************
// SUPER WILDCAT GRAV CYCLE
//**************************************************************

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(SuperScoutVehicle) : WildcatDamageProfile
{
   spawnOffset = "0 0 1";
   canControl = true;
   floatingGravMag = 3.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_scout.dts";
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout_debris.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = scoutRoot;
   cameraMaxDist = 5.0;
   cameraOffset = 0.7;
   cameraLag = 0.5;
   numMountPoints = 1;
   isProtectedMountPoint[0] = true;
   explosion = VehicleExplosion;
	explosionDamage = 0.5;
	explosionRadius = 5.0;

   lightOnly = 1;

   maxDamage = 1.60;
   destroyedLevel = 1.60;

   HDAddMassLevel = 1.3;
   HDMassImage = WCHDMassImage;

   isShielded = true;
   rechargeRate = 0.9;
   energyPerDamagePoint = 1;
   maxEnergy = 450;
   minJetEnergy = 1;
   jetEnergyDrain = 0.1;

   // Rigid Body
   mass = 400;
   bodyFriction = 0.1;
   bodyRestitution = 0.5;  
   softImpactSpeed = 120;       // Play SoftImpact Sound
   hardImpactSpeed = 128;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 129;
   speedDamageScale = 0.010;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 123;
   collDamageMultiplier   = 0.030;

   dragForce            = 45 / 45.0;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.35;

   mainThrustForce    = 90;
   reverseThrustForce = 90;
   strafeThrustForce  = 90;
   turboFactor        = 3.5;

   brakingForce = 90;
   brakingActivationSpeed = 4;

   stabLenMin = 2.25;
   stabLenMax = 3.75;
   stabSpringConstant  = 30;
   stabDampingConstant = 16;

   gyroDrag = 16;
   normalForce = 30;
   restorativeForce = 20;
   steeringForce = 30;
   rollForce  = 15;
   pitchForce = 7;

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 2.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 30.6;
   dustTrailFreqMod = 15.0;

   jetSound         = ScoutSqueelSound;
   engineSound      = ScoutEngineSound;
   floatSound       = ScoutThrustSound;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 10.0; 
   mediumSplashSoundVelocity = 20.0;   
   hardSplashSoundVelocity = 30.0;   
   exitSplashSoundVelocity = 10.0;
   
   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterSoftSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeSoftSplashSound; 

   minMountDist = 4;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = SmallHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 0.5 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;
   
   forwardJetEmitter = WildcatJetEmitter;

   cmdCategory = Tactical;
   cmdIcon = CMDHoverScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_landscout_grey";
   targetNameTag = 'Super WildCat';
   targetTypeTag = 'Grav Cycle';
   sensorData = VehiclePulseSensor;

   checkRadius = 1.7785;
   observeParameters = "1 10 10";

   runningLight[0] = WildcatLight1;
   runningLight[1] = WildcatLight2;
   runningLight[2] = WildcatLight3;

   shieldEffectScale = "0.9375 1.125 0.6";
};
