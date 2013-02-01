//**************************************************************
// BEOWULF ASSAULT VEHICLE
//**************************************************************
datablock EffectProfile(InboundTorpPingEffect)
{
   effectname = "weapons/spinfusor_dryfire";
   minDistance = 2.5;
   maxDistance = 2.5;
};

datablock AudioProfile(InboundTorpPing)
{
   filename    = "gui/Objective_Notification.wav";
   description = AudioClose3d;
   preload = true;
   effect = InboundTorpPingEffect;
};
//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock HoverVehicleData(Sub) : SubDamageProfile
{
   spawnOffset = "0 0 4";
   canControl = false;
   floatingGravMag = 2.0;

   catagory = "Vehicles";
   shapeFile = "vehicle_air_bomber.dts";
   multipassenger = true;
   computeCRC = true;
   renderWhenDestroyed = false;

   weaponNode = 1;

   debrisShapeName = "vehicle_air_bomber.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 0.9;

   mountPose[0] = sitting;
   mountPose[1] = sitting;
   numMountPoints = 2;
   isProtectedMountPoint[0] = true;
   isProtectedMountPoint[1] = true;

   cameraMaxDist = 20;
   cameraOffset = 3;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 1.5;
   explosionRadius = 25.0;

   maxSteeringAngle = 0.5;  // 20 deg.

   maxDamage = 5.0;
   destroyedLevel = 5.0;

   HDAddMassLevel = 3.5;
   HDMassImage = BoatHDMassImage;

   isShielded = false;
   rechargeRate = 1.0;
   energyPerDamagePoint = 135;
   maxEnergy = 1000;
   minJetEnergy = 15;
   jetEnergyDrain = 0.0;

   // Rigid Body
   mass = 1000;
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

   mainThrustForce    = 35;
   reverseThrustForce = 17;
   strafeThrustForce  = 0.0;
   turboFactor        = 1.1;

   brakingForce = 10;
   brakingActivationSpeed = 10;

   stabLenMin = 0.1;
   stabLenMax = 1.6;
   stabSpringConstant  = 0;
   stabDampingConstant = 20;

   gyroDrag = 20;
   normalForce = 20;
   restorativeForce = 10;
   steeringForce = 10;
   rollForce  = 10;
   pitchForce = 15;

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
   targetNameTag = 'Darwine IV';
   targetTypeTag = 'Submarine';
   sensorData = VehiclePulseSensor;

   checkRadius = 5.5535;
   observeParameters = "1 10 10";
   runningLight[0] = TankLight1;
   runningLight[1] = TankLight2;
   runningLight[2] = TankLight3;
   runningLight[3] = TankLight4;
   shieldEffectScale = "0.9 1.0 0.6";
   showPilotInfo = 1;

   replaceTime = 60;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(Torpedo)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 2.0;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 1250;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = GrenadeBubbleEmitter;
   delayEmitter        = LoadingE2;
   puffEmitter         = LoadingE;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 60000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 5.0;
   maxVelocity         = 25.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 35.0;
   acceleration        = 10.0;

   proximityRadius     = 10;

//   terrainAvoidanceSpeed         = 0;
//   terrainScanAhead              = 0;
//   terrainHeightFail             = 0;
//   terrainAvoidanceRadius        = 0;  
   
   flareDistance = 1;
   flareAngle    = 1;
   minSeekHeat   = 0.0;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = false;
   flechetteDelayMs = 100;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

datablock ShapeBaseImageData(SubTorpedoLauncher)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = Chaingun;
   ammo = ChaingunAmmo;
   projectile = Torpedo;
   projectileType = SeekerProjectile;
   offset = "1.68 -2.75 2.0";
   mountPoint = 10;

   usesEnergy = true;
   useMountEnergy = true;
   minEnergy = 1;
   fireEnergy = 1;
   fireTimeout = 125;

   // State transitions
   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";
   stateSound[0]                    = BomberTurretActivateSound;

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 0.75;
   stateFire[2]                     = true;
   stateRecoil[2]                   = LightRecoil;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = BomberTurretFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 0.75;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "Reload1";
   stateSequence[4] 		 	= "NoAmmo1";

   stateTransitionOnTriggerDown[4]  = "DryFire1";

   stateName[5]                     = "DryFire1";
   stateSound[5]                    = BomberTurretDryFireSound;
   stateTimeoutValue[5]             = 0.75;
   stateTransitionOnTimeout[5]      = "NoAmmo1";

   stateName[6]                     = "WaitFire2";
   stateTransitionOnTriggerDown[6]  = "Fire2";
   stateTransitionOnNoAmmo[6] 	= "NoAmmo2";

   stateName[7]                     = "Fire2";
   stateTransitionOnTimeout[7]      = "Reload2";
   stateTimeoutValue[7]             = 10.0;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 0.75;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "Reload2";
   stateSequence[9] 			= "NoAmmo2";

   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                    = "DryFire2";
   stateSound[10]                   = BomberTurretDryFireSound;
   stateTimeoutValue[10]            = 0.75;
   stateTransitionOnTimeout[10]     = "NoAmmo2";

};

datablock ShapeBaseImageData(SubTorpedoLauncherPair)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   item = Chaingun;
   ammo = ChaingunAmmo;
   projectile = Torpedo;
   projectileType = SeekerProjectile;
   offset = "-1.68 -2.75 2.0";
   mountPoint = 10;

   usesEnergy = true;
   useMountEnergy = true;
   minEnergy = 1;
   fireEnergy = 1;
   fireTimeout = 125;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 0.13;
   stateFire[1]                     = true;
   stateRecoil[1]                   = LightRecoil;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = BomberTurretFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.1;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
};

datablock ShapeBaseImageData(SubAIAiming)
{
   shapeFile            = "turret_muzzlepoint.dts";
   mountPoint           = 2;

   projectile           = Torpedo;
   projectileType = SeekerProjectile;
   isSeeker = false; 
};

datablock TurretData(SubAATurret) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Boat CG';
   targetTypeTag = 'Turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1000;
   maxDamage               = sub.maxDamage;
   destroyedLevel          = sub.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 100;
   capacitorRechargeRate   = 1.5;

   thetaMin = 20;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'Sub Anti Aircraft';
   targetTypeTag = 'Turret';

   explosion    = HandGrenadeExplosion;
   expDmgRadius = 5.0;
   expDamage    = 0.25;
   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   repairRate = 0.0;

   max[plasmaammo] = 4;
};

datablock TurretImageData(Sub50MMTurretBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   mountPoint = 0;

   projectile = APCT_bullet;
   projectileType = TracerProjectile;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 6.0 / 1000.0;

   useCapacitor = true;
   usesEnergy = true;
   useMountEnergy = true;
   fireEnergy = 1.0;
   minEnergy = 5.0;

   // Turret parameters
   activationMS      = 500;
   deactivateDelayMS = 550;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;
   attackRadius      = 225;

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
   stateTransitionOnTriggerDown[2]     = "CheckWet";
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

   stateName[9]       			   = "WetFire";
   stateSound[9]      			   = ChaingunDryFireSound;
   stateTimeoutValue[9]        	   = 1.0;
   stateTransitionOnTimeout[9] 	   = "Ready";
   
   stateName[10]               	   = "CheckWet";
   stateTransitionOnWet[10]    	   = "WetFire";
   stateTransitionOnNotWet[10] 	   = "Fire"; 
};

datablock TurretImageData(SubTurretParam)
{
   mountPoint = 0;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 0.0 3.0";

   projectile = APCT_bullet;
   projectileType = TracerProjectile;

   useCapacitor = false;
   usesEnergy = true;

   // Turret parameters
   activationMS      = 500;
   deactivateDelayMS = 550;
   thinkTimeMS       = 200;
   degPerSecTheta    = 500;
   degPerSecPhi      = 500;

   attackRadius      = 225;
};

//******************************************************
// sub main functions
//******************************************************

function sub::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(SubAIAiming, 0);
   %obj.mountImage(SubTorpedoLauncher, 2);
   %obj.mountImage(SubTorpedoLauncherPair, 3);
   %obj.selectedWeapon = 1;
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(SubAATurret);
   %turret.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 2);
   %turret.mountImage(Sub50MMTurretBarrel, 2);
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );
   %obj.turretObject = %turret;
   %turret.setAutoFire(false);
   %turret.mountImage(SubTurretParam, 0);
   %turret.setInventory(PlasmaAmmo, 4);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function sub::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(2);
   if (!%turret)
      return;
   if (%client = %turret.getControllingClient())
   {
      %client.player.setControlObject(%client.player);
      %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      %client.player.mountVehicle = false;
   }
   %turret.schedule(1000, delete);
   if(isObject(%obj.beacon))
      %obj.beacon.schedule(50, delete);
}

function sub::playerMounted(%data, %obj, %player, %node)
{
   Cancel(%player.DrownLoop);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   if (%node == 0) {
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }
   else if (%node == 1)
   {
      %turret = %obj.getMountNodeObject(2);
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
      %obj.getMountNodeObject(10).selectedWeapon = 1;
	   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", %node);
   }
   else 
   {
	   commandToClient(%player.client, 'setHudMode', 'Passenger', "HAPC", %node);
   }
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );

   bottomPrint(%player.client, "ONLY use on water will not move well on land", 5, 2 );

   %passString = buildPassengerString(%obj);
	for(%i = 0; %i < %data.numMountPoints; %i++)
		if (%obj.getMountNodeObject(%i) > 0)
		   commandToClient(%obj.getMountNodeObject(%i).client, 'checkPassengers', %passString);
}

//******************************************************
// sub fireing functions
//******************************************************
function sub::onTrigger(%data, %obj, %trigger, %state)
{
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

function SubTorpedoLauncher::firePair(%this, %obj, %slot)
{
   %obj.setImageTrigger( 3, true);
}
function SubTorpedoLauncherPair::stopFire(%this, %obj, %slot)
{
   %obj.setImageTrigger( 3, false);
}

function SubTorpedoLauncher::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.torpseekloop = schedule(5500, 0, "TorpedoSeekLoop", %p);
}
function SubTorpedoLauncherPair::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.torpseekloop = schedule(5500, 0, "TorpedoSeekLoop", %p);
}

datablock StaticShapeData(SubBeacon)
{
   shapeFile = "turret_muzzlepoint.dts";
   targetNameTag = 'beacon';
   isInvincible = true;
   
   dynamicType = $TypeMasks::SensorObjectType;
};

function TorpedoSeekLoop(%p)
{ 
   if(!isObject(%p))
	return;
   InitContainerRadiusSearch(%p.getPosition(), 100, $TypeMasks::VehicleObjectType);
   %searchResult = containersearchnext();
   if(%searchResult)
   {
	%SearchObj = FirstWord(%SearchResult);
	if(%searchObj.getDataBlock().getName() $= "Sub" || %searchObj.getDataBlock().getName() $= "Boat")
	{
   	   if(%SearchObj.beacon)
   	   {
		%SearchObj.beacon.setPosition(%SearchObj.getWorldBoxCenter());
   	   }
	   else{
   	   	%SearchObj.beacon = new BeaconObject() {
      	   dataBlock = "SubBeacon";
      	   beaconType = "vehicle";
      	   position = %SearchObj.getWorldBoxCenter();
   	   	};

   	   	%SearchObj.beacon.playThread($AmbientThread, "ambient");
   	   	%SearchObj.beacon.team = %p.team;
   	   	%SearchObj.beacon.sourceObject = %SearchObj;

   	      // give it a team target
   	      %SearchObj.beacon.setTarget(0);                  
   	      MissionCleanup.add(%SearchObj.beacon);
	   }

	   %p.setObjectTarget(%searchObj.beacon);

         serverPlay3d("InboundTorpPing",%SearchObj.getWorldBoxCenter()); 
	}
   }
   %p.torpseekloop = schedule(500, 0, "TorpedoSeekLoop", %p);
}

//******************************************************
// turret functions
//******************************************************

function SubAATurret::onDamage(%data, %obj)
{
   %newDamageVal = %obj.getDamageLevel();
   if(%obj.lastDamageVal !$= "")
      if(isObject(%obj.getObjectMount()) && %obj.lastDamageVal > %newDamageVal)   
         %obj.getObjectMount().setDamageLevel(%newDamageVal);
   %obj.lastDamageVal = %newDamageVal;
}

function SubAATurret::damageObject(%this, %targetObject, %sourceObject, %position, %amount, %damageType ,%vec, %client, %projectile)
{
   //If vehicle turret is hit then apply damage to the vehicle
   %vehicle = %targetObject.getObjectMount();
   if(%vehicle)
      %vehicle.getDataBlock().damageObject(%vehicle, %sourceObject, %position, %amount, %damageType, %vec, %client, %projectile);
}

function SubAATurret::onTrigger(%data, %obj, %trigger, %state)
{
   %Pos = posFromTransform(%obj.getPosition());
   %vector = vectorAdd("0 0 -10", %pos);
   %searchresult = containerRayCast(%Pos, %vector, $TypeMasks::WaterObjectType);
   if(%searchresult){
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
   if(%trigger == 4){
	if(%state){
	   if (%obj.inv[PlasmaAmmo] > 0){
    		%mp = %obj.getMuzzlePoint(2);

      	%p = new (seekerprojectile)() 
	   	{
               dataBlock        = Torpedo;
               initialDirection = "0 0 1";
               initialPosition  = %mp;
               sourceObject     = %obj;
		   damageFactor	 = 1;
               sourceSlot       = 2;
         	};
		%obj.decInventory(PlasmaAmmo, 1);

		schedule(3000, 0, "startCGM", %p);
	   }
	}
   }
}

function SubAATurret::playerDismount(%data, %obj)
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

function Sub::onEnterLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(1.0);
      case 1:
         //Ocean Water
         %obj.setHeat(1.0);
      case 2:
         //River Water
         %obj.setHeat(1.0);
      case 3:
         //Stagnant Water
         %obj.setHeat(1.0);
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

function Sub::onLeaveLiquid(%data, %obj, %coverage, %type)
{
   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(1.0);
      case 1:
         //Ocean Water
         %obj.setHeat(1.0);
      case 2:
         //River Water
         %obj.setHeat(1.0);
      case 3:
         //Stagnant Water
         %obj.setHeat(1.0);
      case 4:
         //Lava
      case 5:
         //Hot Lava
      case 6:
         //Crusty Lava
      case 7:
         //Quick Sand
   }
}