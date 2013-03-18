//**************************************************************
// SHRIKE SCOUT FLIER
//**************************************************************
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(HawkFlyer) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";

   catagory = "Vehicles";
   shapeFile = "vehicle_air_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_air_scout_debris.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = true;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = VehicleExplosion;
	explosionDamage = 0.5;
	explosionRadius = 5.0;

   maxDamage = 1.40;
   destroyedLevel = 1.40;

   isShielded = true;
   energyPerDamagePoint = 160;
   maxEnergy = 280;      // Afterburner and any energy weapon pool
   rechargeRate = 0.8;

   minDrag = 30;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 15;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 300;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.95;      // Dampen control input so you don't` whack out at very slow speeds

   // Maneuvering
   maxSteeringAngle = 5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 3000;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 1200;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 400;      // Steering jets (how much you heel over when you turn)
   rollForce = 4;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 5;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 100;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 28;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0.0;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 3.0;

   // Rigid body
   mass = 150;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 10;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.06;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 15;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;
   forwardJetEmitter = FlyerJetEmitter;
   downJetEmitter = FlyerJetEmitter;

   //
   jetSound = ScoutFlyerThrustSound;
   engineSound = ScoutFlyerEngineSound;
   softImpactSound = SoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;
   
   //
   softSplashSoundVelocity = 10.0; 
   mediumSplashSoundVelocity = 15.0;   
   hardSplashSoundVelocity = 20.0;   
   exitSplashSoundVelocity = 10.0;
   
   exitingWater      = VehicleExitWaterMediumSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterMediumSound;
   waterWakeSound    = VehicleWakeMediumSplashSound; 
    
   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 4.0;
   dustHeight = 1.0;

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = HeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   //
   max[chaingunAmmo] = 1000;

   minMountDist = 4;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'Hawk';
   targetTypeTag = 'Interceptor';
   sensorData = AWACPulseSensor;
   sensorRadius = AWACPulseSensor.detectRadius;
   sensorColor = "255 194 9";
   
   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

};


//**************************************************************
// WEAPONS
//**************************************************************

datablock TracerProjectileData(HawkChaingunBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.1;
   directDamageType    = $DamageType::Bullet;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 0.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 425.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 10.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock ShapeBaseImageData(HawkChaingunPairImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
   projectile = HawkChaingunBullet;
   projectileType = TracerProjectile;
   mountPoint = 10;
   offset = "0.84 -0.52 1.8";
   rotation = "1 0 0 0";

   usesEnergy = true;
   useMountEnergy = true;
   minEnergy = 3;
   fireEnergy = 1;
   fireTimeout = 125;

   
   casing              = ShellDebris;
   shellExitDir        = "0 -0.5 1.0";
   shellExitOffset     = "0 -0.56 -0.11";
   shellExitVariance   = 15.0;
   shellVelocity       = 5.0;

   projectileSpread = 6.0 / 1000.0;

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
//   stateSound[3]        = ChaingunSpinupSound;
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
   stateTimeoutValue[4]          = 0.09;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
//   stateSound[5]      = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.05;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
//   stateSound[6]      = ChaingunSpinDownSound;
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

datablock ShapeBaseImageData(HawkChaingunImage) : HawkChaingunPairImage
{
//*wingtips**   offset = "-2.04 -0.52 -0.05";
   offset = "-1.04 -0.52 1.8";
   rotation = "1 0 0 0";
   stateScript[3]           = "onTriggerDown";
   stateScript[5]           = "onTriggerUp";
   stateScript[6]           = "onTriggerUp";
};

datablock ShapeBaseImageData(HawkChaingunParam)
{
   mountPoint = 2;
   shapeFile = "weapon_chaingun.dts";

   projectile = HawkChaingunBullet;
   projectileType = TracerProjectile;
}; 

//********* FUNCTIONS ***********

function HawkFlyer::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.mountImage(HawkChaingunParam, 0);
   %obj.mountImage(HawkChaingunImage, 2);
   %obj.mountImage(HawkChaingunPairImage, 3);
   %obj.nextWeaponFire = 2;
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");
}

function HawkFlyer::playerMounted(%data, %obj, %player, %node)
{
   // AdminFighter flyer == SUV (single-user vehicle)
   commandToClient(%player.client, 'setHudMode', 'Pilot', "Shrike", %node);
   $numVWeapons = 1;

   // update observers who are following this guy...
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function HawkFlyer::onTrigger(%data, %obj, %trigger, %state)
{
   // data = AdminFighterFlyer datablock
   // obj = AdminFighterFlyer object number
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

function HawkFlyer::playerDismounted(%data, %obj, %player)
{
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);

   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function HawkChaingunImage::onFire(%data,%obj,%slot)
{
   // obj = AdminFighterFlyer object number
   // slot = 2

   Parent::onFire(%data,%obj,%slot);
//   %obj.nextWeaponFire = 3;
//   schedule(%data.fireTimeout, 0, "fireNextGun", %obj);
}

function HawkChaingunPairImage::onFire(%data,%obj,%slot)
{
   // obj = ScoutFlyer object number
   // slot = 3

   Parent::onFire(%data,%obj,%slot);
//   %obj.nextWeaponFire = 2;
//   schedule(%data.fireTimeout, 0, "fireNextGun", %obj);
}
function HawkChaingunImage::onTriggerDown(%this, %obj, %slot)
{
}

function HawkChaingunImage::onTriggerUp(%this, %obj, %slot)
{
}

function HawkChaingunImage::onMount(%this, %obj, %slot)
{
//   %obj.setImageAmmo(%slot,true);
}

function HawkChaingunPairImage::onMount(%this, %obj, %slot)
{
//   %obj.setImageAmmo(%slot,true);
}

function HawkChaingunImage::onUnmount(%this,%obj,%slot)
{
}

function HawkChaingunPairImage::onUnmount(%this,%obj,%slot)
{
}

