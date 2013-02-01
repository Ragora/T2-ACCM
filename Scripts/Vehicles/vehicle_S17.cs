//**************************************************************
// S17
//**************************************************************

datablock HoverVehicleData(S17) : ShrikeDamageProfile
{
   spawnOffset = "0 0 1";
   canControl = false;
   floatingGravMag = 3.5;

   catagory = "Vehicles";
   shapeFile = "nexuscap.dts";
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout_debris.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag = 0.0;
   density = 0.9;

   cameraMaxDist = 5.0;
   cameraOffset = 0.7;
   cameraLag = 0.5;
   numMountPoints = 0;
   explosion = VehicleExplosion;
	explosionDamage = 0.5;
	explosionRadius = 5.0;

   maxDamage = 1.5;
   destroyedLevel = 1.5;

   HDAddMassLevel = 1.2;
   HDMassImage = WCHDMassImage;

   isShielded = false;
   rechargeRate = 0.7;
   energyPerDamagePoint = 75;
   maxEnergy = 150;
   minJetEnergy = 15;
   jetEnergyDrain = 0.1;

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

   dragForce            = 25 / 45.0;
   vertFactor           = 0.0;
   floatingThrustFactor = 0.35;

   mainThrustForce    = 25;
   reverseThrustForce = 15;
   strafeThrustForce  = 0;
   turboFactor        = 1.35;

   brakingForce = 15;
   brakingActivationSpeed = 3;

   stabLenMin = 2.25;
   stabLenMax = 3.75;
   stabSpringConstant  = 30;
   stabDampingConstant = 16;

   gyroDrag = 16;
   normalForce = 30;
   restorativeForce = 20;
   steeringForce = 35;
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
   damageLevelTolerance[1] = 0.8;
   numDmgEmitterAreas = 1;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   forwardJetEmitter = WildcatJetEmitter;

   cmdCategory = Tactical;
   cmdIcon = CMDHoverScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_landscout_grey";
   targetNameTag = 'S17';
   targetTypeTag = 'Combat Drone';
   sensorData = PlayerSensor;

   checkRadius = 1.7785;
   observeParameters = "1 10 10";

   runningLight[0] = WildcatLight1;
   runningLight[1] = WildcatLight2;
   runningLight[2] = WildcatLight3;

   shieldEffectScale = "0.9375 1.125 0.6";

   replaceTime = 20;
};

datablock StaticShapeData(S17switch) : StaticShapeDamageProfile {
   shapeFile      = "switch.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

//**************************************************************
// WEAPONS
//**************************************************************

//-------------------------------------
// CHOPPER BELLY TURRET CHARACTERISTICS
//-------------------------------------

datablock TurretData(S17Turret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_base_large.dts";
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";
   targetNameTag = 'S17';
   targetTypeTag = 'Turret';

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = S17.maxDamage;
   destroyedLevel          = S17.destroyedLevel;
   maxEnergy               = 1;

   thetaMin                = 60;
   thetaMax                = 150;
   thetaNull		   = 90;

   // capacitor
   maxCapacitorEnergy      = 200;
   capacitorRechargeRate   = 5.0;

   inheritEnergyFromMount  = true;
   firstPersonOnly         = true;
   useEyePoint             = true;
   numWeapons              = 1;

   targetNameTag           = 'Wildcat Chaingun';
   targetTypeTag           = 'Turret';
};

datablock TurretImageData(S17ChaingunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_chaingun.dts";
//   mountPoint = 1;

   projectile = RPChaingunBullet;
   projectileType = TracerProjectile;
   projectileSpread = 1.2 / 1000.0;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 5.0;
   shellVelocity       = 0.0;

   usesEnergy = true;
   useCapacitor = true;
   useMountEnergy = true;
   minEnergy = 1;
   fireEnergy = 0.1;

   // Turret parameters
   activationMS                        = 4000;
   deactivateDelayMS                   = 1500;
   thinkTimeMS                         = 200;
   degPerSecTheta                      = 360;
   degPerSecPhi                        = 360;
   attackRadius                        = 75;

   stateName[0] = "Activate";
   stateSequence[0] = "deploy";
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
   stateSpinThread[3] = SpinUp;
   stateTimeoutValue[3] = 0.01;
   stateWaitForTimeout[3] = false;
   stateTransitionOnTimeout[3] = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   stateName[4] = "Fire";
   stateSequence[4] = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4] = FullSpeed;
   stateSound[4] = ChaingunFireSound;
   stateAllowImageChange[4] = false;
   stateScript[4] = "onFire";
   stateFire[4] = true;
   stateEjectShell[4] = true;
   stateTimeoutValue[4] = 0.15;
   stateTransitionOnTimeout[4] = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4] = "EmptySpindown";

   stateName[5] = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateTimeoutValue[5] = 0.1;
   stateWaitForTimeout[5] = true;
   stateTransitionOnTimeout[5] = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   stateName[6] = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6] = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7] = "DryFire";
   stateSound[7] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[7] = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock TurretImageData(S17Param) 
{ 
   mountPoint 		= 2; 
   shapeFile 		= "turret_muzzlepoint.dts"; 
   offset = "0.0 0.0 3.0";

   Projectile 		= RPChaingunBullet;
   ProjectileType 	= TracerProjectile;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1500;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 75;
};

function S17::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(S17Turret);
   %turret.scale = "0.5 0.5 1";
   MissionCleanup.add(%turret);
   %turret.team = %obj.team;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(S17Param, 0);
   %turret.mountImage(S17chaingunimage, 2);
   %obj.turret = %turret;
   %obj.turretObject = %turret;
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);

   %sensor = new StaticShape()
   {
       scale = "1.3 1.3 0.1";
       dataBlock = "S17switch";
   };
   MissionCleanup.add(%sensor);
   %obj.mountObject(%sensor, 2);
   %sensor.vehicleMounted = %obj;
   %sensor.playThread($AmbientThread,"ambient");

   schedule(5000, 0, "S17TurretAttackCheck",%obj);
}

function S17::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (!%turret)
      return;
   %turret.schedule(2000, delete);

   %body = %obj.getMountNodeObject(2);
   if (isObject(%body))
	%body.schedule(1000, delete);
   $teamRepCredits[%obj.team] += getWord($commsatPurchase[2],1);
   $teamUsedCredits[%obj.team] -= getWord($commsatPurchase[2],1);
}

function S17turret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function S17turret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function S17::onEnterLiquid(%data, %obj, %coverage, %type)
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

function S17TurretAttackCheck(%obj){
   if(!isObject(%obj))
	return;

	%valid = 0;
      %TargetSearchMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TurretObjectType;
      InitContainerRadiusSearch(%obj.getPosition(),400,%TargetSearchMask);
      while ((%potentialTarget = ContainerSearchNext()) != 0) {
	   if (%potentialtarget && %valid != 1) {
		%PTT = %potentialtarget.team;
		if(%PTT $= "")
		   %PTT = %obj.team;
		if(!(%PTT == %obj.team) && %PTT != 0){
		   %valid = 1;
		   %target = %potentialtarget;
		}
	   }
	}
	if(%valid == 1){
	   if(!%obj.firing){
	      %obj.firing = 1;
	      %obj.turretobject.setTargetObject(%target);
	      %obj.turretobject.aquireTime = getSimTime();
	      %obj.turretobject.setImageTrigger(2,true);
	   }
	}
	else{
	   if(%obj.firing){
	      %obj.firing = 0;
	      %obj.turretobject.setImageTrigger(2,false);
		%obj.turretObject.clearTarget();
	   }
	}
   schedule(250, 0, "S17TurretAttackCheck",%obj);
}
