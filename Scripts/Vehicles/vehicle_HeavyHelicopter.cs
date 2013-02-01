//**************************************************************
// Chopper
//**************************************************************
 
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(heavychopper) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_bomber.dts";
   multipassenger = true;
   computeCRC = true;

   debrisShapeName = "vehicle_air_bomber.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.3;
   density = 1.0;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   mountPose[3] = sitting;
   mountPose[4] = sitting;
   mountPose[5] = sitting;
   numMountPoints = 6;
   isProtectedMountPoint[0] = false;
   isProtectedMountPoint[1] = false;
   isProtectedMountPoint[2] = false;
   isProtectedMountPoint[3] = true;
   isProtectedMountPoint[4] = true;
   isProtectedMountPoint[5] = true;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MFVehicleExplosion;
	explosionDamage = 1.5;
	explosionRadius = 10.0;

   maxDamage = 5.0;
   destroyedLevel = 5.0;

   HDAddMassLevel = 3.5;
   HDMassImage = HHeliHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 150;      // Afterburner and any energy weapon pool
   rechargeRate = 1.0;

   minDrag = 20;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 15;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 550;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 150;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 1.0;      // Dampen control input so you don't` whack out at very slow speeds

   // Maneuvering
   maxSteeringAngle = 7;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 2;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 0;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 425;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 30;     // Steering jets (how much you heel over when you turn)
   rollForce = 6;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 3;        // Height off the ground at rest
   createHoverHeight = 3;  // Height off the ground when created
   maxForwardSpeed = 30;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 1000;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 1;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0.1;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 3.5;

   // Rigid body
   mass = 250;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 15;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.08;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 100;      // The speed your contrail shows up at.
   trailEmitter = ContrailEmitter;

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

   damageEmitter[0] = MFLightDamageSmoke;
   damageEmitter[1] = MFHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 1;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'Eagle VII';
   targetTypeTag = 'Transport Chopper';
   sensorData = PlayerSensor;

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   max[chaingunAmmo] = 1000;
   max[PlasmaAmmo] = 20;

   replaceTime = 50;
};

//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(ChopperCGPairImage)
{
   className = WeaponImage;
   shapeFile = "turret_missile_large.dts";
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = Heli_CG_Bullet;
   projectileType = TracerProjectile;
   mountPoint = 10;
   offset = "4.93 -4.52 0.044"; // L/R - F/B - T/B

   projectileSpread = 1.0 / 1000.0;

   usesEnergy = false;
   emap = true;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.1;
   stateSequence[0] = "Activate";
   
   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.05;
   stateFire[3] = true;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateSound[3] = ShrikeBlasterFire;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.05;
   stateAllowImageChange[4] = false;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(ChopperCGImage) : ChopperCGPairImage
{
   offset = "-4.93 -4.52 0.044";
};

datablock TracerProjectileData(HheliT_bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.2; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::Bullet;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 2000.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 3000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 2500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 2500;
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
	tracerWidth     = 0.06;
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

datablock ShapeBaseImageData(HHeliChaingunImage)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelchain.dts";
   item      = Chaingun;
   ammo 	 = ChaingunAmmo;
   projectile = HheliT_bullet;
   projectileType = TracerProjectile;
   projectileSpread = 1.0 / 1000.0;
   emap = true;
   offset = "0.37 -0.4 -0.5";

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

   mountPoint = 1;
   usesEnergy = true;
   useCapacitor = true;
   useMountEnergy = true;
   minEnergy = 8;
   fireEnergy = 8;

   stateName[0] = "Activate";
   stateSequence[0] = "Activate";
//   stateSound[0] = GravChaingunIdleSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0] = 0.1;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0] = "NoAmmo";

   stateName[1] = "Ready";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "NoAmmo";
   stateTransitionOnAmmo[2] = "Ready";
   stateSpinThread[2] = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   stateName[3] = "Spinup";
   stateScript[3] = "onSpinup";
   stateSpinThread[3] = SpinUp;
   stateSound[3] = ChaingunSpinupSound;
   stateTimeoutValue[3] = 0.5;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4] = "EmptySpindown";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = HeliturretFireSound;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateFire[4] = true;
   stateEjectShell[4] = true;
   stateTimeoutValue[4] = 0.05;
   stateTransitionOnTimeout[4] = "Fire";

   stateName[5] = "Spindown";
   stateScript[5] = "onSpindown";
   stateSound[5] = ChaingunSpinDownSound;
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.5;
   stateWaitForTimeout[5] = true;
   stateTransitionOnTimeout[5] = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6] = "EmptySpindown";
   stateScript[6] = "onSpindown";
   stateSound[6] = ChaingunSpinDownSound;
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6] = 2.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7] = "DryFire";
   stateSound[7] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[7] = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(HHeliChaingunImage2) : HHeliChaingunImage
{
   offset = "-0.23 -0.4 -0.5";
};

datablock ShapeBaseImageData(ChopperParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 5 0"; // L/R - F/B - T/B

   projectile = BigBullet;
   projectileType = TracerProjectile;
}; 

function HeavyChopper::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}

datablock ShapeBaseImageData(DummyslotImg)
{
   shapeFile = "grenade.dts";
   emap = false;
};

//******************************************************
// vehicle.cs and weapturretcode.cs functions
//******************************************************

//----------------------------
// Helicopter FLIER
//----------------------------

function HeavyChopper::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(ChopperParam, 0);
   %obj.mountImage(ChopperCGImage, 2);
   %obj.mountImage(ChopperCGPairImage, 3);
   %obj.mountImage(DummySlotImg, 4);
   %obj.selectedWeapon = 1;
   %obj.nextWeaponFire = 2;
   %obj.setInventory(chaingunammo, 1000);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(HeliTurret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(heliTurretParam, 0);
   %turret.mountImage(Hhelichaingunimage, 2);
   %turret.mountImage(Hhelichaingunimage2, 3);
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   %turret.mountImage(AIAimingTurretBarrel, 0);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
   %obj.canSwitchP = 1;
}

function HeavyChopper::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

   %turret.altTrigger = 0;
   %turret.fireTrigger = 0;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;

      %client.player.bomber = false;
      %client.player.isBomber = false;
   }
   %turret.schedule(1000, delete);
}

function HeavyChopper::playerMounted(%data, %obj, %player, %node)
{
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   bottomPrint(%player.client, "Transport Chopper: carrys 6 peeps has 2 forward mounted cg's controlled by pilot and cg turret on bottom", 5, 2 );

   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0)
   {
      %player.setPilot(true);
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
   }
   else if (%node == 1)
   {
      %turret = %obj.getMountNodeObject(10);
      %player.vehicleTurret = %turret;
      %player.setTransform("0 0 0 0 0 1 0");
      %player.lastWeapon = %player.getMountedImage($WeaponSlot);
      %player.unmountImage($WeaponSlot);
      if (!%player.client.isAIControlled())
      {
         %player.setControlObject(%turret);
         %player.client.setObjectActiveImage(%turret, 2);
      }
      %turret.bomber = %player;
      $bWeaponActive = 0;
      %obj.getMountNodeObject(10).selectedWeapon = 1;
//      commandToClient(%player.client,'SetWeaponryVehicleKeys', true);

	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Bomber", %node);
      %player.isBomber = true;
   }
   else 
   {
      // all others
	   commandToClient(%player.client, 'setHudMode', 'Passenger', "HAPC", %node);
   }
   // build a space-separated string representing passengers
   // 0 = no passenger; 1 = passenger (e.g. "1 0 0 ")
   %passString = buildPassengerString(%obj);
	// send the string of passengers to all mounted players
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);

   // update observers who are following this guy...
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function HeavyChopper::onTrigger(%data, %obj, %trigger, %state)
{
   // data = ScoutFlyer datablock
   // obj = ScoutFlyer object number
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
            %obj.fireWeapon = true;
		if(%obj.selectedWeapon == 1)
            {
               if(%obj.nextWeaponFire == 2) 
		   {
                  %obj.setImageTrigger(2, true);
                  %obj.setImageTrigger(3, true);
               }
//               else 
//		   {
//                  %obj.setImageTrigger(2, false);
//                  %obj.setImageTrigger(3, true);
//               }
		}
            else 
            {
               %obj.setImageTrigger(2, false);
               %obj.setImageTrigger(3, false);
            }
      }
   }
   else if (%trigger ==4)    // Throw flare 
   {
      switch (%state) 
	{
      case 0:
         %obj.fireWeapon = false;
         %obj.setImageTrigger(5, false);
      case 1:
	   if (%obj.inv[PlasmaAmmo] > 0)
	   {
            %obj.fireWeapon = true;
            %obj.setImageTrigger(5, true);
		%obj.decInventory(PlasmaAmmo, 1);
   		%p = new FlareProjectile() 
   		{ 
   		   dataBlock        = FlareGrenadeProj; 
   		   initialDirection = "0 0 -1"; 
   		   initialPosition  = getBoxCenter(%obj.getWorldBox()); 
   		   sourceObject     = %obj; 
   		   sourceSlot       = 0; 
   		}; 

   		FlareSet.add(%p); 
   		MissionCleanup.add(%p); 
   		   serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox())); 
   		   %p.schedule(6000, "delete"); 
   		   // miscellaneous grenade-throwing cleanup stuff 
   		   %obj.lastThrowTime[%data] = getSimTime(); 
   		%obj.throwStrength = 0; 
	   }
      }
   }
}

function HeavyChopper::playerDismounted(%data, %obj, %player)
{
   %obj.fireWeapon = false;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   setTargetSensorGroup(%obj.getTarget(), %obj.team);

   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function ChopperCGImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
}

function ChopperCGPairImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.getMountNodeObject(0).decInventory(%data.ammo, 1);
}

function HHeliChaingunImage::OnSpinup(%data,%obj,%slot){
   %obj.setImageTrigger(3,true);
}
function HHeliChaingunImage::OnSpindown(%data,%obj,%slot){
   %obj.setImageTrigger(3,false);
}

function heavychopper::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 1:
         //Ocean Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 2:
         //River Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
      case 3:
         //Stagnant Water
         %obj.setHeat(0.0);
         %obj.liquidDamage(%data, 0.1, $DamageType::Crash);
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
