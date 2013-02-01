//**************************************************************
// Long Range Artillery
//**************************************************************

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(CGTank) : TankDamageProfile
{
   spawnOffset = "0 0 4";

   floatingGravMag = 4.5;

   catagory = "Vehicles";
   shapeFile = "vehicle_grav_tank.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_grav_tank.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = false;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 1.5;
   explosionRadius = 25.0;

   maxSteeringAngle = 0.5;  // 20 deg.

   maxDamage = 3.2;
   destroyedLevel = 3.2;

   HDAddMassLevel = 2.24;
   HDMassImage = TankHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 300;
   maxEnergy = 400;
   minJetEnergy = 15;
   jetEnergyDrain = 2.0;

   // Rigid Body
   mass = 4000;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 20;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 18;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 17;
   speedDamageScale = 0.060;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 18;
   collDamageMultiplier   = 0.045;

   dragForce            = 40 / 20;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.15;

   mainThrustForce    = 40;
   reverseThrustForce = 25;
   strafeThrustForce  = 25;
   turboFactor        = 1.7;

   brakingForce = 25;
   brakingActivationSpeed = 4;

   stabLenMin = 3.25;
   stabLenMax = 4;
   stabSpringConstant  = 50;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 15;
   rollForce  = 5;
   pitchForce = 3;

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

   minMountDist = 7;

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
   targetNameTag = 'Bannshe 50mm';
   targetTypeTag = 'chaingun tank';
   sensorData = PlayerSensor;

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   replaceTime = 30;
};

//**************************************************************
// WEAPONS
//**************************************************************

datablock TracerProjectileData(BigBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.4;
   directDamageType    = $DamageType::TankChaingun;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 2000.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 4000.0; // z0dd - ZOD, 8-12-02. Was 1000.0
   wetVelocity       = 1600.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.25;
   crossSize       = 0.25;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = MG42Decal1;
   decalData[1] = MG42Decal2;
   decalData[2] = MG42Decal3;
   decalData[3] = MG42Decal4;
   decalData[4] = MG42Decal5;
   decalData[5] = MG42Decal6;
};

//-------------------------------------
// Artillery CHAINGUN CHARACTERISTICS
//-------------------------------------

datablock TurretImageData(CGTurretParam)
{
   mountPoint = 2;
   shapeFile = "turret_muzzlepoint.dts";

   projectile = BigBullet;
   projectileType = TracerProjectile;

   useCapacitor = true;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 750;
};

datablock TurretData(CGTurret) : TurretDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "Turret_tank_base.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Bannshe';
   targetTypeTag = '50mm chaingun turret';
   mass           = 1.0;

   maxEnergy               = 1;
   maxDamage               = CGTank.maxDamage;
   destroyedLevel          = CGTank.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 1000;
   capacitorRechargeRate   = 10.0;

   thetaMin = 0;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = '50mm chaingun';
   targetTypeTag = 'Turret';
};

datablock TurretImageData(CGTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 1;

   projectile = BigBullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 1.5 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 0.75;
   minEnergy = 1.0;

   // Turret parameters
   activationMS                        = 2000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   // State transitions
   stateName[0]                        = "Activate";
   stateTransitionOnNotLoaded[0]       = "Dead";
   stateTransitionOnLoaded[0]          = "ActivateReady";
   stateSound[0]                       = AssaultTurretActivateSound;

   stateName[1]                        = "ActivateReady";
   stateSequence[1]                    = "Activate";
   stateSound[1]                       = AssaultTurretActivateSound;
   stateTimeoutValue[1]                = 0.1;
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
   stateTimeoutValue[4]                = 0.5;
   stateAllowImageChange[4]            = false;
   stateTransitionOnTimeout[4]         = "Ready";
   stateTransitionOnNoAmmo[4]          = "NoAmmo";
   stateWaitForTimeout[4]              = true;

   stateName[5]                        = "Deactivate";
   stateSequence[5]                    = "Activate";
   stateDirection[5]                   = false;
   stateTimeoutValue[5]                = 0.1;
   stateTransitionOnTimeout[5]         = "ActivateReady";

   stateName[6]                        = "Dead";
   stateTransitionOnLoaded[6]          = "ActivateReady";
   stateTransitionOnTriggerDown[6]     = "DryFire";

   stateName[7]                        = "DryFire";
   stateSound[7]                       = AssaultChaingunFireSound;
   stateTimeoutValue[7]                = 1.0;
   stateTransitionOnTimeout[7]         = "NoAmmo";

   stateName[8]                        = "NoAmmo";
   stateTransitionOnAmmo[8]            = "Reload";
   stateSequence[8]                    = "NoAmmo";
   stateTransitionOnTriggerDown[8]     = "DryFire";
};

datablock TurretImageData(CGTurretBarrel2) : CGTurretBarrel
{
   mountPoint = 0;
};

function CGTank::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

   %turret = TurretData::create(CGTurret);
   %turret.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(CGTurretBarrel, 2);
   %turret.mountImage(CGTurretBarrel2, 3);
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %obj.turretObject = %turret;

   //vehicle turrets should not auto fire at targets
   %turret.setAutoFire(false);

   //Needed so we can set the turret parameters..
   %turret.mountImage(CGTurretParam, 0);
   %obj.schedule(6000, "playThread", $ActivateThread, "activate");

   // set the turret's target info
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function CGTank::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;

   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   %turret.schedule(2000, delete);
}

function CGTank::playerMounted(%data, %obj, %player, %node)
{
   if (%node == 0) 
   {
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
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
      %turret.turreteer = %player;
      $aWeaponActive = 0;
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }

   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );

   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);
}


function CGTurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function CGTurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{                                           
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function CGTurret::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger)
   {
      case 0:
         %obj.fireTrigger = %state;
         if(%state)
         {
            %obj.setImageTrigger(2, true);
            %obj.setImageTrigger(3, true);
         }
         else
         {
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(3, false);
         }
      case 2:
         if(%state)
            %obj.getDataBlock().playerDismount(%obj);
   }
}

function CGTurret::playerDismount(%data, %obj)
{
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function CGTank::onEnterLiquid(%data, %obj, %coverage, %type)
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
