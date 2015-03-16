//**************************************************************
// BEOWULF ASSAULT VEHICLE
//**************************************************************

datablock ParticleData( DepthChargeWaterSplashParticals )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 1.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   textureName          = "particleTest";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 2.5;
   sizes[2]      = 2.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleEmitterData( DepthChargeWaterSplashEmitter )
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 20;
   velocityVariance = 4;
   ejectionOffset   = 36.0;
   thetaMin         = 27;
   thetaMax         = 28;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 200;
   particles = "DepthChargeWaterSplashParticals";
};

datablock ParticleData(DepthChargeSparks)
{
   dragCoefficient      = 0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 350;
   textureName          = "special/crescent3";
   colors[0]     = "0.4 0.4 1.0 1.0";
   colors[1]     = "0.4 0.4 1.0 1.0";
   colors[2]     = "0.4 0.4 1.0 0.0";
   sizes[0]      = 5.5;
   sizes[1]      = 5.5;
   sizes[2]      = 5.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(DepthChargeSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 50;
   velocityVariance = 4;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 180;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   lifetimeMS       = 100;
   particles = "DepthChargeSparks";
};

datablock ParticleData(DepthChargeBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.25;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 600;
   useInvAlpha          = false;
   textureName          = "special/bubbles";

   spinRandomMin        = -100.0;
   spinRandomMax        =  100.0;

   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 3.0;
   sizes[1]      = 3.0;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.8;
   times[2]      = 1.0;
};
datablock ParticleEmitterData(DepthChargeBubbleEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 6.0;
   ejectionOffset   = 6.0;
   velocityVariance = 3.0;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "DepthChargeBubbleParticle";
};

datablock DebrisData( DepthChargeDebris )
{
   emitters[0] = GrenadeBubbleEmitter;

   explodeOnMaxBounce = true;

   elasticity = 0.4;
   friction = 0.2;

   lifetime = 3.0;
   lifetimeVariance = 0.7;

   numBounces = 1;
};             

datablock ExplosionData(DepthChargeSubExplosion1)
{
   explosionShape = "disc_explosion.dts";
   faceViewer = true;
   delayMS = 100;
   offset = 15.0;
   playSpeed = 1.5;

   sizes[0] = "2.75 2.75 2.75";
   sizes[1] = "3.5  3.5  3.5";
   sizes[2] = "1.75 1.75 1.75";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

};             

datablock ExplosionData(DepthChargeSubExplosion2)
{
   explosionShape = "disc_explosion.dts";
   faceViewer= true;
   delayMS = 50;
   offset = 10.0;
   playSpeed = 0.75;

   sizes[0] = "4.5 4.5 4.5";
   sizes[1] = "5.5 5.5 5.5";
   sizes[2] = "4.0 4.0 4.0";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock ExplosionData(DepthChargeSubExplosion3)
{
   explosionShape = "disc_explosion.dts";
   faceViewer = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 0.5;

   sizes[0] = "6.0 6.0 6.0";
   sizes[1] = "10.0 10.0 10.0";
   sizes[2] = "6.5 6.5 6.5";
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

};

datablock ExplosionData(DepthChargeExplosion)
{
   soundProfile   = UnderwaterMortarExplosionSound;

   subExplosion[0] = DepthChargeSubExplosion1;
   subExplosion[1] = DepthChargeSubExplosion2;
   subExplosion[2] = DepthChargeSubExplosion3;

   emitter[0] = DepthChargeBubbleEmitter;
   emitter[1] = DepthChargeSparksEmitter;
   emitter[2] = DepthChargeWaterSplashEmitter;
   
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;

   debris = DepthChargeDebris;
   debrisThetaMin = 60;
   debrisThetaMax = 120;
   debrisNum = 15;
   debrisNumVariance = 5;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 3.0;
};

datablock ExplosionData(DepthChargeExplosionShallow)
{
   soundProfile   = UnderwaterMortarExplosionSound;

   subExplosion[0] = DepthChargeSubExplosion1;
   subExplosion[1] = DepthChargeSubExplosion2;
   subExplosion[2] = DepthChargeSubExplosion3;

   emitter[0] = DepthChargeBubbleEmitter;
   emitter[1] = DepthChargeSparksEmitter;
   
   shakeCamera = true;
   camShakeFreq = "8.0 9.0 7.0";
   camShakeAmp = "100.0 100.0 100.0";
   camShakeDuration = 1.3;
   camShakeRadius = 25.0;

   debris = DepthChargeDebris;
   debrisThetaMin = 80;
   debrisThetaMax = 90;
   debrisNum = 15;
   debrisNumVariance = 5;
   debrisVelocity = 15.0;
   debrisVelocityVariance = 3.0;
};


//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(Boat) : TankDamageProfile
{
   spawnOffset = "0 0 4";
   canControl = false;
   floatingGravMag = 4.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_air_hapc.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_air_hapc.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   mountPose[2] = sitting;
   mountPose[3] = sitting;
   mountPose[4] = sitting;
   mountPose[5] = sitting;
//   mountPose[1] = sitting;
   numMountPoints = 6;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;
   isProtectedMountPoint[2] = true;
   isProtectedMountPoint[3] = true;
   isProtectedMountPoint[4] = true;
   isProtectedMountPoint[5] = true;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 3.0;
   explosionRadius = 25.0;

   maxSteeringAngle = 0.5;  // 20 deg.

   maxDamage = 10.0;
   destroyedLevel = 10.0;

   HDAddMassLevel = 7.0;
   HDMassImage = BoatHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 135;
   maxEnergy = 1000;
   minJetEnergy = 15;
   jetEnergyDrain = 0.0;

   // Rigid Body
   mass = 2500;
   bodyFriction = 1.2;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 20;
   minDrag = 10;
   softImpactSpeed = 5;       // Play SoftImpact Sound
   hardImpactSpeed = 10;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 5;
   speedDamageScale = 0.005;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 18;
   collDamageMultiplier   = 0.005;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.0;

   mainThrustForce    = 40;
   reverseThrustForce = 25;
   strafeThrustForce  = 0.0;
   turboFactor        = 1.0;

   brakingForce = 20;
   brakingActivationSpeed = 4;

   stabLenMin = 0.5;
   stabLenMax = 2.5;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 100;
   steeringForce = 12;
   rollForce  = 2;
   pitchForce = 0;

   dustEmitter = TankDustEmitter;
   triggerDustHeight = 3.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = AssaultVehicleThrustSound;
   engineSound      = AssaultVehicleEngineSound;
   floatSound       = AssaultVehicleSkid;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;
   wheelImpactSound = WheelImpactSound;

   forwardJetEmitter = TankJetEmitter;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 15.0;
   exitSplashSoundVelocity = 10.0;

   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 10;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -1.5 3.5 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Star II Heavy';
   targetTypeTag = 'GunBoat';
   sensorData = AWACSensor;
   sensorRadius = AWACSensor.detectRadius;
   sensorColor = "255 194 9";

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   replaceTime = 90;
};

datablock GrenadeProjectileData(DepthChargeCharge)
{
   projectileShapeName = "stackable1m.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 4.0;
   damageRadius        = 75.0;
   radiusDamageType    = $DamageType::DepthCharge;
   kickBackStrength    = 0;

   explosion           = "GrenadeExplosion";
   underwaterExplosion = "DepthChargeExplosionShallow";
   velInheritFactor    = 0.0;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 1.0;
   muzzleVelocity    = 0.0;
   drag              = 0.1;
   sound	     = MissileProjectileSound;

   hasLight    = false;
   hasLightUnderwaterColor = false;
};

datablock LinearProjectileData(DepthChargeDetonation) 
{ 
   projectileShapeName = "mortar_projectile.dts"; 
   emitterDelay        = -1; 
   directDamage        = 0.0; 
   hasDamageRadius     = true; 
   indirectDamage      = 4.0; 
   damageRadius        = 100; 
   radiusDamageType    = $DamageType::DepthCharge; 
   kickBackStrength    = 250; 

   sound             = mortarProjectileSound; 
   explosion           = "DepthChargeExplosion"; 
   underwaterExplosion = "DepthChargeExplosion"; 
   splash              = MissileSplash; 

   dryVelocity       = 0; 
   wetVelocity       = 10; 
   velInheritFactor  = 0.0; 
   fizzleTimeMS      = 10; 
   lifetimeMS        = 10; 
   explodeOnDeath    = true; 
   reflectOnWaterImpactAngle = 0.0; 
   explodeOnWaterImpact      = false; 
   deflectionOnWaterImpact   = 0.0; 
   fizzleUnderwaterMS        = 5000; 

   hasLight    = true; 
   lightRadius = 100; 
   lightColor  = "0.4 0.2 0.0"; 

   hasLightUnderwaterColor = true; 
   underWaterLightColor = "0.4 0.2 0.05"; 

}; 

datablock ShapeBaseImageData(DepthChargeDropper)
{
   className = WeaponImage;
   shapeFile = "stackable5l.dts";
   item = Chaingun;
   ammo = ChaingunAmmo;
   projectile = DepthChargeCharge;
   projectileType = GrenadeProjectile;
   offset = "0 -5.25 0"; // L/R - F/B - T/B
   rotation = "0 0 1 180"; // L/R - F/B - T/B
   mountPoint = 10;

   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 50.00;
   minEnergy = 50.00;
   fireTimeout = 125;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   
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
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = AssaultMortarFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 5.0;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = AssaultMortarDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function DepthChargeDropper::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.detboatdepthcharge = schedule(%obj.DCdepth, 0, "detDepthCharge", %p);
}

function detDepthCharge(%p) 
{ 
   if (!isObject(%p)) 
      return; 
   %pn = new (LinearProjectile)() { 
      dataBlock        = DepthChargeDetonation; 
      initialDirection = "0 0 -1"; 
      initialPosition  = %p.getPosition(); 
      sourceObject     = %p.sourceObject; 
      sourceSlot       = %p.sourceSlot; 
      vehicleObject    = %p.vehicleObject; 
   }; 
   MissionCleanup.add(%pn); 
   %P.delete(); 
} 

datablock TurretData(BoatTurret) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Boat Artillery';
   targetTypeTag = 'Turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1000;
   maxDamage               = boat.maxDamage;
   destroyedLevel          = boat.destroyedLevel;
   repairRate              = 0;

   thetaMin = 45;
   thetaMax = 95;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons =1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'Boat Artillery';
   targetTypeTag = 'Turret';

   explosion    = HandGrenadeExplosion;
   expDmgRadius = 5.0;
   expDamage    = 0.25;
   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   repairRate = 0.0;
};

datablock TurretData(BoatTurret2) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Boat Flak';
   targetTypeTag = 'Turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1000;
   maxDamage               = boat.maxDamage;
   destroyedLevel          = boat.destroyedLevel;
   repairRate              = 0;

   thetaMin = 10;
   thetaMax = 80;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons =1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 100.0;

   targetNameTag = 'Boat AA';
   targetTypeTag = 'Turret';

   explosion    = HandGrenadeExplosion;
   expDmgRadius = 5.0;
   expDamage    = 0.25;
   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   repairRate = 0.0;
};

datablock TurretImageData(BoatFlakTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 0;

   projectile = AssaultChaingunBullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 1.5 / 1000.0;

   useCapacitor = false;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 3.0;
   minEnergy = 3.0;

   // Turret parameters
   activationMS      = 4000;
   deactivateDelayMS = 500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 360;
   degPerSecPhi      = 360;
   attackRadius      = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";
   stateSound[0]                       = AssaultTurretActivateSound;

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 1;
   stateTransitionOnTimeout[1]         = "Ready";
   stateTransitionOnNotLoaded[1]       = "Deactivate";

   stateName[2]                        = "Ready";
   stateTransitionOnNotLoaded[2]       = "Deactivate";
   stateTransitionOnTriggerDown[2]     = "Fire";
   stateTransitionOnNoAmmo[2]          = "NoAmmo";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateSequenceRandomFlash[3]         = true;
   stateFire[3]                        = true;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = AssaultChaingunFireSound;
   stateScript[3]                      = "onFire";
   stateTimeoutValue[3]                = 0.1;
   stateTransitionOnTimeout[3]         = "Fire";
   stateTransitionOnTriggerUp[3]       = "Reload";
   stateTransitionOnNoAmmo[3]          = "noAmmo";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 0.1;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateSequence[5]                    = "Activate";
   stateDirection[5]                   = false;
   stateTimeoutValue[5]                = 30;
   stateTransitionOnTimeout[5]         = "ActivateReady";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultChaingunDryFireSound;
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "DryFire";
};

datablock GrenadeProjectileData(BoatArtillery)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 3.25;
   damageRadius        = 30.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 3500;

   explosion           = "artillerybarrelexplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.3;
   armingDelayMS     = -1;
   gravityMod        = 1.0;
   muzzleVelocity    = 200.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

//-------------------------------------
// ASSAULT MORTAR CHARACTERISTICS
//-------------------------------------

datablock TurretImageData(BoatATurretBarrel)
{
   shapeFile = "turret_tank_barrelmortar.dts";
   mountPoint = 0;

   projectile = BoatArtillery;
   projectileType = GrenadeProjectile;

   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 250.00;
   minEnergy = 250.00;
   useCapacitor = false;

   // Turret parameters
   activationMS                        = 4000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 1.0;
   stateTransitionOnTimeout[1]         = "Ready";
   stateTransitionOnNotLoaded[1]       = "Deactivate";

   stateName[2]                        = "Ready";
   stateTransitionOnNotLoaded[2]       = "Deactivate";
   stateTransitionOnNoAmmo[2]          = "NoAmmo";
   stateTransitionOnTriggerDown[2]     = "Fire";

   stateName[3]                        = "Fire";
   stateSequence[3]                    = "Fire";
   stateTransitionOnTimeout[3]         = "Reload";
   stateTimeoutValue[3]                = 2.5;
   stateFire[3]                        = true;
   stateRecoil[3]                      = LightRecoil;
   stateAllowImageChange[3]            = false;
   stateSound[3]                       = AssaultMortarFireSound;
   stateScript[3]                      = "onFire";

   stateName[4]                        = "Reload";
   stateSequence[4]                    = "Reload";
   stateTimeoutValue[4]                = 3.0;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   //stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateDirection[5]                   = false;
   stateSequence[5]                    = "Activate";
   stateTimeoutValue[5]                = 1.0;
   stateTransitionOnLoaded[5]          = "ActivateReady";
   stateTransitionOnTimeout[5]         = "Dead";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultMortarDryFireSound;
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateTransitionOnTriggerDown[8]     = "DryFire";
};

datablock TurretImageData(BoatTurretParam)
{
   mountPoint = 0;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 3.0";

   projectile = BoatFlak_Bullet;
   projectileType = TracerProjectile;

   useCapacitor = false;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 75;
};

datablock TurretImageData(BoatATurretParam)
{
   mountPoint = 0;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 3.0";

   projectile = BoatArtillery;
   projectileType = GrenadeProjectile;

   useCapacitor = false;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 75;
};

datablock TurretImageData(BoatParam)
{
   mountPoint = 10;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 0.0";

   projectile = DepthChargeCharge;
   projectileType = GrenadeProjectile;

   usesEnergy = true;
};


function Boat::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.DCdepth = 5000;
   %obj.mountImage(BoatParam, 0);
   %obj.mountImage(DepthChargeDropper, 2);
   %obj.selectedWeapon = 1;
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(BoatTurret);
   %turret2 = TurretData::create(BoatTurret2);
   %turret3 = TurretData::create(BoatTurret2);
   %turret.selectedWeapon = 1;
   %turret2.selectedWeapon = 1;
   %turret3.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   MissionCleanup.add(%turret2);
   MissionCleanup.add(%turret3);
   %turret.team = %obj.teamBought;
   %turret2.team = %obj.teamBought;
   %turret3.team = %obj.teamBought;
   %turret.setSelfPowered();
   %turret2.setSelfPowered();
   %turret3.setSelfPowered();
   %obj.mountObject(%turret, 9);
   %obj.mountObject(%turret2, 2);
   %obj.mountObject(%turret3, 5);
   %turret.mountImage(BoatATurretBarrel, 2);
   %turret2.mountImage(BoatFlakTurretBarrel, 2);
   %turret3.mountImage(BoatFlakTurretBarrel, 2);
   %obj.turretObject = %turret;
   %obj.turretObject = %turret2;
   %obj.turretObject = %turret3;

   %turret.setAutoFire(false);
   %turret2.setAutoFire(false);
   %turret3.setAutoFire(false);

   %turret.mountImage(BoatATurretParam, 0);
   %turret2.mountImage(BoatTurretParam, 0);
   %turret3.mountImage(BoatTurretParam, 0);
   %obj.schedule(6000, "playThread", $ActivateThread, "activate");

   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
   setTargetSensorGroup(%turret2.getTarget(), %turret2.team);
   setTargetNeverVisMask(%turret2.getTarget(), 0xffffffff);
   setTargetSensorGroup(%turret3.getTarget(), %turret3.team);
   setTargetNeverVisMask(%turret3.getTarget(), 0xffffffff);
}

function Boat::onTrigger(%data, %obj, %trigger, %state)
{
   %player = %obj.getMountNodeObject(0);
   if(%trigger == 0)
   {
      switch (%state) 
	{
         case 0:
            %obj.fireWeapon = false;
            %obj.setImageTrigger(2, false);
         case 1:
            %obj.fireWeapon = true;
               %obj.setImageTrigger(2, true);
      }
   }
   else if(%trigger == 5)
   {
	switch (%state){
	 case 1:
	   %obj.DCdepth = %obj.DCdepth + 1000;
	   if(%obj.DCdepth >= 10001)
		%obj.DCdepth = 5000;
   	   bottomPrint(%obj.pilot.client, "Depth Charge fuse set to "@(%obj.DCdepth / 1000)@" seconds", 5, 2 );
	}
   }
}

function Boat::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(9);
   %turret2 = %obj.getMountNodeObject(2);
   %turret3 = %obj.getMountNodeObject(5);
   if (!%turret)
      return;
   if (!%turret2)
      return;
   if (!%turret3)
      return;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   if (%client = %turret2.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   if (%client = %turret3.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   %turret.schedule(1000, delete);
   %turret2.schedule(1050, delete);
   %turret3.schedule(1100, delete);
}

//----------------------------
// Boat
//----------------------------

function boat::playerMounted(%data, %obj, %player, %node)
{
   Cancel(%player.DrownLoop);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0) {
	commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
	%obj.pilot = %player;
   }
   else if (%node == 1)
   {
      %turret = %obj.getMountNodeObject(9);
      %player.vehicleTurret = %turret;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret);
         %player.client.setObjectActiveImage(%turret, 2);
      }
      %turret.turreteer = %player;

      $aWeaponActive = 0;
      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);
      %obj.getMountNodeObject(10).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }

   else if (%node == 3)
   {
      %turret2 = %obj.getMountNodeObject(2);
      %player.vehicleTurret = %turret2;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret2);
         %player.client.setObjectActiveImage(%turret2, 2);
      }
      %turret.turreteer = %player;

      $aWeaponActive = 0;
      %obj.getMountNodeObject(2).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Passenger', "HAPC", %node);
   }

   else if (%node == 4)
   {
      %turret3 = %obj.getMountNodeObject(5);
      %player.vehicleTurret = %turret3;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret3);
         %player.client.setObjectActiveImage(%turret3, 2);
      }
      %turret.turreteer = %player;

      $aWeaponActive = 0;
      %obj.getMountNodeObject(5).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Passenger', "HAPC", %node);
   }


   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );

   bottomPrint(%player.client, "ONLY use on water will not move well on land", 5, 2 );

   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   if(%player.team != %obj.team)
	%player.damage(%obj, %player.getPosition(), 10, $DamageType::Idiocy);
}

function BoatTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function BoatTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function BoatTurret::onTrigger(%data, %obj, %trigger, %state)
{
   //error("onTrigger: trigger = " @ %trigger @ ", state = " @ %state);
   //error("obj = " @ %obj @ ", class " @ %obj.getClassName());
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
      case 2:
         if(%state)
         {
            %obj.getDataBlock().playerDismount(%obj);
         }
   }
}

function BoatTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function BoatTurret2::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function BoatTurret2::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function BoatTurret2::onTrigger(%data, %obj, %trigger, %state)
{
   //error("onTrigger: trigger = " @ %trigger @ ", state = " @ %state);
   //error("obj = " @ %obj @ ", class " @ %obj.getClassName());
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
            if(%state)
               %obj.setImageTrigger(2, true);
            else
               %obj.setImageTrigger(2, false);
      case 2:
         if(%state)
         {
            %obj.getDataBlock().playerDismount(%obj);
         }
   }
}

function BoatTurret2::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function BoatATurretBarrel::onMount(%this, %obj, %slot) { }
function BoatATurretBarrel::onUnmount(%this, %obj, %slot) { }
function BoatATurretBarrel::onMount(%this, %obj, %slot) { }
function BoatATurretBarrel::onUnmount(%this, %obj, %slot) { }
function BoatFlakTurretBarrel::onMount(%this, %obj, %slot) { }
function BoatFlakTurretBarrel::onUnmount(%this, %obj, %slot) { }

function Boat::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
      case 1:
         //Ocean Water
      case 2:
         //River Water
      case 3:
         //Stagnant Water
      case 4:
         //Lava
         %obj.liquidDamage(%data, $VehicleDamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $VehicleDamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $VehicleDamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}

function boat::onLeaveLiquid(%data, %obj, %type)
{
   switch(%type)
   {
      case 0:
         //Water
      case 1:
         //Ocean Water
      case 2:
         //River Water
      case 3:
         //Stagnant Water
      case 4:
         //Lava
      case 5:
         //Hot Lava
      case 6:
         //Crusty Lava
      case 7:
         //Quick Sand
   }

   if (%obj.lDamageSchedule !$= "")
   {
      cancel(%obj.lDamageSchedule);
      %obj.lDamageSchedule = "";
   }
}
