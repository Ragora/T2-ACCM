//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock EffectProfile(ScoutEngineEffect)
{
   effectname = "vehicles/outrider_engine";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock EffectProfile(ScoutThrustEffect)
{
   effectname = "vehicles/outrider_boost";
   minDistance = 5.0;
   maxDistance = 10.0;
};

datablock AudioProfile(ScoutSqueelSound)
{
   filename    = "fx/vehicles/outrider_skid.wav";
   description = ClosestLooping3d;
   preload = true;
};

datablock AudioProfile(ScoutEngineSound)
{
   filename    = "fx/vehicles/outrider_engine.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ScoutEngineEffect;
};

datablock AudioProfile(ScoutThrustSound)
{
   filename    = "fx/vehicles/outrider_boost.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = ScoutThrustEffect;
};

datablock AudioProfile(ScoutturretFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefaultLooping3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

datablock HoverVehicleData(scoutVehicle) : WildcatDamageProfile
{
   spawnOffset = "0 0 1";

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

   maxDamage = 0.80;
   destroyedLevel = 0.80;

   isShielded = false;
   rechargeRate = 0.7;
   energyPerDamagePoint = 50;
   maxEnergy = 150;
   minJetEnergy = 15;
   jetEnergyDrain = 1.5;

   // Rigid Body
   mass = 400;
   bodyFriction = 0.1;
   bodyRestitution = 0.5;
   softImpactSpeed = 20;       // Play SoftImpact Sound
   hardImpactSpeed = 28;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 29;
   speedDamageScale = 0.010;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23;
   collDamageMultiplier   = 0.030;

   dragForce            = 28 / 45.0;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.35;

   mainThrustForce    = 25;
   reverseThrustForce = 15;
   strafeThrustForce  = 15;
   turboFactor        = 1.5;

   brakingForce = 25;
   brakingActivationSpeed = 4;

   stabLenMin = 2.25;
   stabLenMax = 3.75;
   stabSpringConstant  = 30;
   stabDampingConstant = 16;

   gyroDrag = 16;
   normalForce = 30;
   restorativeForce = 20;
   steeringForce = 25;
   rollForce  = 15;
   pitchForce = 7;

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 2.5;
   dustHeight = 1.0;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
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
   targetNameTag = 'MK II WildCat';
   targetTypeTag = 'Grav Cycle';
   sensorData = VehiclePulseSensor;

   checkRadius = 1.7785;
   observeParameters = "1 10 10";

   runningLight[0] = WildcatLight1;
   runningLight[1] = WildcatLight2;
   runningLight[2] = WildcatLight3;

   shieldEffectScale = "0.9375 1.125 0.6";
};

//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(hornetChaingunPairImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   projectile = MG42Bullet;
   projectileType = TracerProjectile;
   mountPoint = 3;
//*wintips*   offset = "1.84 -0.52 -0.05";
   offset = "0.3 0.9 0.4";
   rotation = "1 0 0 0";

   usesEnergy = true;
   useMountEnergy = true;
   minEnergy = 5;
   fireEnergy = 0;
   fireTimeout = 125;


   casing              = ShellDebris;
   shellExitDir        = "0 -0.5 1.0";
   shellExitOffset     = "0 -0.56 -0.11";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 3.0 / 1000.0;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.3;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   //--------------------------------------
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = ChaingunSpinupSound;
   //
   stateTimeoutValue[3]          = 0.05;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   //stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   //
   stateTimeoutValue[4]          = 0.05;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.05;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.3;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(hornetChaingunImage) : hornetChaingunPairImage
{
   offset = "-0.45 0.9 0.4";
   rotation = "1 0 0 0";
   stateScript[3]           = "onTriggerDown";
   stateScript[5]           = "onTriggerUp";
   stateScript[6]           = "onTriggerUp";
};

datablock ShapeBaseImageData(hornetChaingunParam)
{
   mountPoint = 2;
   shapeFile = "weapon_chaingun.dts";

   projectile = MG42Bullet;
   projectileType = TracerProjectile;
};

//********* FUNCTIONS ***********

function scoutVehicle::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.mountImage(hornetChaingunParam, 0);
   %obj.mountImage(hornetChaingunImage, 2);
   %obj.mountImage(hornetChaingunPairImage, 3);
   %obj.nextWeaponFire = 2;
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");
}

function scoutVehicle::playerMounted(%data, %obj, %player, %node)
{
   // scout == SUV (single-user vehicle)
   commandToClient(%player.client, 'setHudMode', 'Pilot', "Hoverbike", %node);
   $numVWeapons = 1;

   // update observers who are following this guy...
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function scoutVehicle::onTrigger(%data, %obj, %trigger, %state)
{
   // data = scout datablock
   // obj = scout object number
   // trigger = 0 for "fire", 1 for "jump", 3 for "thrust"
   // state = 1 for firing, 0 for not firing
   if(%trigger == 0)
   {
      switch (%state) {
         case 0:
            %obj.fireWeapon = false;
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(3, false);
         case 1:
            %obj.setImageTrigger(2, true);
            %obj.setImageTrigger(3, true);
      }
   }
}

function scoutVehicle::playerDismounted(%data, %obj, %player)
{
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);

   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function hornetChaingunImage::onFire(%data,%obj,%slot)
{
   // obj = AdminFighterFlyer object number
   // slot = 2

   Parent::onFire(%data,%obj,%slot);
//   %obj.nextWeaponFire = 3;
//   schedule(%data.fireTimeout, 0, "fireNextGun", %obj);
}

function hornetChaingunPairImage::onFire(%data,%obj,%slot)
{
   // obj = ScoutFlyer object number
   // slot = 3

   Parent::onFire(%data,%obj,%slot);
//   %obj.nextWeaponFire = 2;
//   schedule(%data.fireTimeout, 0, "fireNextGun", %obj);
}
function hornetChaingunImage::onTriggerDown(%this, %obj, %slot)
{
}

function hornetChaingunImage::onTriggerUp(%this, %obj, %slot)
{
}

function hornetChaingunImage::onMount(%this, %obj, %slot)
{
//   %obj.setImageAmmo(%slot,true);
}

function hornetChaingunPairImage::onMount(%this, %obj, %slot)
{
//   %obj.setImageAmmo(%slot,true);
}

function hornetChaingunImage::onUnmount(%this,%obj,%slot)
{
}

function hornetChaingunPairImage::onUnmount(%this,%obj,%slot)
{
}


