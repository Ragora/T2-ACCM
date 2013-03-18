//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock ParticleData(CLSubExplosionSmoke)
{
   dragCoeffiecient     = 1.0;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -200.0;
   spinRandomMax =  200.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.5 0.5 0.5 1.0";
   colors[1]     = "0.5 0.5 0.5 0.5";
   colors[2]     = "0.6 0.6 0.6 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 2.0;
   sizes[2]      = 3.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(CLSubSmokeEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 6.0;
   velocityVariance = 6.0;

   thetaMin         = 80.0;
   thetaMax         = 90.0;

   lifetimeMS       = 750;

   particles = "CLSubExplosionSmoke";
};

datablock ParticleData(CLSubSparks)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = 0.0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 100;
   textureName          = "special/bigspark";
   colors[0]     = "0.56 0.36 0.26 1.0";
   colors[1]     = "0.56 0.36 0.26 1.0";
   colors[2]     = "1.0 0.36 0.26 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.0;
   sizes[2]      = 1.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(CLSubSparksEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 15;
   velocityVariance = 10.0;

   ejectionOffset   = 0.0;

   thetaMin         = 0;
   thetaMax         = 90;

   lifetimeMS       = 500;

   particles = "CLSubSparks";
};

//----------------------------------------------------
//  Explosion
//----------------------------------------------------
datablock ExplosionData(ClusterSubExplosion)
{
   soundProfile   = GrenadeExplosionSound;

   faceViewer           = true;
   explosionScale = "1.0 1.0 1.0";

   emitter[0] = CLSubSmokeEmitter;
   emitter[1] = CLSubSparksEmitter;

   shakeCamera = true;
   camShakeFreq = "10.0 6.0 9.0";
   camShakeAmp = "10.0 10.0 10.0";
   camShakeDuration = 1.0;
   camShakeRadius = 10.0;
};

datablock WheeledVehicleData(Artillery) : TankDamageProfile
{
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_land_mpbase.dts";
   multipassenger = true;
   computeCRC = true;

   debrisShapeName = "vehicle_land_mpbase.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 20.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = true;

   cantAbandon = 1;

   cameraMaxDist = 20;
   cameraOffset = 6;
   cameraLag = 1.5;
   explosion = HGVehicleExplosion;
   explosionDamage = 4.0;
   explosionRadius = 20.0;

   maxSteeringAngle = 0.3;  // 20 deg.

   // Rigid Body
   mass = 2000;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 25;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 30;
   speedDamageScale = 0.060;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 30;
   collDamageMultiplier   = 0.070;

   // Engine
   engineTorque = 10.0 * 745;
   breakTorque = 6.0 * 745;
   maxWheelSpeed = 15;

   // Springs
   springForce = 10000;
   springDamping = 1000;
   antiSwayForce = 7500;
   staticLoadScale = 2;

   // Tires
   tireRadius = 2.5;
   tireFriction = 50.0;
   tireRestitution = 0.5;
   tireLateralForce = 3000;
   tireLateralDamping = 400;
   tireLateralRelaxation = 1;
   tireLongitudinalForce = 10000;
   tireLongitudinalDamping = 400;
   tireLongitudinalRelaxation = 1;
   tireEmitter = TireEmitter;

   //
   maxDamage = 5.5;
   destroyedLevel = 5.5;

   HDAddMassLevel = 3.85;
   HDMassImage = APCHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 600;
   jetForce = 2800;
   minJetEnergy = 60;
   jetEnergyDrain = 0.1;
   rechargeRate = 1.0;

   jetSound = MPBThrustSound;
   engineSound = MPBEngineSound;
   squeelSound = AssaultVehicleSkid;
   softImpactSound = GravSoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 8.0;
   hardSplashSoundVelocity = 12.0;
   exitSplashSoundVelocity = 8.0;

   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterHardSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 10;

   damageEmitter[0] = LightDamageSmoke;
   damageEmitter[1] = MeHGHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "3.0 0.5 0.0 ";
   damageEmitterOffset[1] = "-3.0 0.5 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 2;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundMPBIcon;
   cmdMiniIconName = "commander/MiniIcons/com_mpb_grey";
   targetNameTag = 'Grendel';
   targetTypeTag = 'Heavy Artillery';
   sensorData = PlayerSensor;

   checkRadius = 7.5225;

   observeParameters = "1 12 12";

   runningLight[0] = MPBLight1;
   runningLight[1] = MPBLight2;

   shieldEffectScale = "0.85 1.2 0.7";

   max[MortarAmmo] = 12;

   replaceTime = 60;
};

//---------------------------------------------
//	Weapon Stuff
//---------------------------------------------

datablock TurretData(ArtilleryTurret) : TankDamageProfile
{
   className      = VehicleTurret;
   catagory       = "Turrets";
   shapeFile      = "turret_base_large.dts";
   preload        = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDGroundTankIcon;
   cmdMiniIconName = "commander/MiniIcons/com_tank_grey";
   targetNameTag = 'Artillery';
   targetTypeTag = 'Turret';
   mass           = 1.0;  // Not really relevant

   maxEnergy               = 1000;
   maxDamage               = Artillery.maxDamage;
   destroyedLevel          = Artillery.destroyedLevel;
   repairRate              = 0;

   // capacitor
   maxCapacitorEnergy      = 100;
   capacitorRechargeRate   = 1.5;

   thetaMin = 30;
   thetaMax = 100;

   inheritEnergyFromMount = true;
   firstPersonOnly = true;
   useEyePoint = true;
   numWeapons = 1;

   cameraDefaultFov = 90.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;

   targetNameTag = 'APC CG';
   targetTypeTag = 'Turret';

   max[MortarAmmo] = 12;
};

datablock GrenadeProjectileData(ArtilleryShot)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 3.5;
   damageRadius        = 25.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 4000;

   explosion           = "artillerybarrelexplosion";
   velInheritFactor    = 0.0;
   splash              = GrenadeSplash;

   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.0;
   grenadeFriction   = 0.3;
   armingDelayMS     = -1;
   gravityMod        = 1.0;
   muzzleVelocity    = 225.0;
   drag              = 0.1;

   sound			 = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 3;
   lightColor  = "0.05 0.2 0.05";
};

datablock GrenadeProjectileData(ClusterSubProj)
{
   projectileShapeName = "grenade.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.5;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::Artillery;
   kickBackStrength    = 2000;

   explosion           = "ClusterSubExplosion";
   underwaterExplosion = "GrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 1.0;
   muzzleVelocity    = 225.0;
   drag              = 0.2;
   sound	     = MortarTurretProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

datablock TurretImageData(ArtilleryBarrel)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelmortar.dts";
   item = MissileLauncher;
   ammo = MortarAmmo;
   projectile = ArtilleryShot;
   projectileType = GrenadeProjectile;

   offset = "0.5 0 0";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "WaitFire1";
   stateTimeoutValue[0]             = 1;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "WaitFire1";
   stateTransitionOnTriggerDown[1]  = "Fire1";
   stateTransitionOnNoAmmo[1]       = "NoAmmo1";

   stateName[2]                     = "Fire1";
   stateTransitionOnTimeout[2]      = "Reload1";
   stateTimeoutValue[2]             = 2.0;
   stateFire[2]                     = true;
   stateEmitter[2] 			= "WhiteHorseHeatSeekerFireEffectEmitter";
   stateEmitterNode[2] 			= "muzzlepoint1";
   stateEmitterTime[2] 			= 1;
   stateAllowImageChange[2]         = false;
   stateSequence[2]                 = "Fire";
   stateScript[2]                   = "onFire";
   stateSound[2]                    = AssaultMortarFireSound;

   stateName[3]                     = "Reload1";
   stateSequence[3]                 = "Reload";
   stateTimeoutValue[3]             = 0.1;
   stateAllowImageChange[3]         = false;
   stateTransitionOnTimeout[3]      = "WaitFire2";
   stateTransitionOnNoAmmo[3]       = "NoAmmo1";

   stateName[4]                     = "NoAmmo1";
   stateTransitionOnAmmo[4]         = "AmmoLoading1";
   stateSequence[4] = "NoAmmo1";
   stateTransitionOnTriggerDown[4]  = "DryFire1";

   stateName[5]                     = "DryFire1";
   stateSound[5]                    = BomberTurretDryFireSound;
   stateTimeoutValue[5]             = 0.75;
   stateTransitionOnTimeout[5]      = "NoAmmo1";

   stateName[6]                     = "WaitFire2";
   stateTransitionOnTriggerDown[6]  = "Fire2";
   stateTransitionOnNoAmmo[6] = "NoAmmo2";

   stateName[7]                     = "Fire2";
   stateTransitionOnTimeout[7]      = "Reload2";
   stateTimeoutValue[7]             = 0.5;
   stateScript[7]                   = "FirePair";

   stateName[8]                     = "Reload2";
   stateSequence[8]                 = "Reload";
   stateTimeoutValue[8]             = 4.0;
   stateAllowImageChange[8]         = false;
   stateTransitionOnTimeout[8]      = "WaitFire1";
   stateTransitionOnNoAmmo[8]       = "NoAmmo2";

   stateName[9]                     = "NoAmmo2";
   stateTransitionOnAmmo[9]         = "AmmoLoading2";
   stateSequence[9] = "NoAmmo2";
   stateTransitionOnTriggerDown[9]  = "DryFire2";

   stateName[10]                     = "DryFire2";
   stateSound[10]                    = BomberTurretDryFireSound;
   stateTimeoutValue[10]             = 0.75;
   stateTransitionOnTimeout[10]      = "NoAmmo2";

   stateName[11]                     = "AmmoLoading1";
   stateSound[11] 			 = MissileReloadSound;
   stateTimeoutValue[11]             = 0.1;
   stateAllowImageChange[11]         = false;
   stateTransitionOnTimeout[11]      = "Reload1";

   stateName[12]                     = "AmmoLoading2";
   stateSound[12] 			 = MissileReloadSound;
   stateTimeoutValue[12]             = 0.1;
   stateAllowImageChange[12]         = false;
   stateTransitionOnTimeout[12]      = "Reload2";
};

datablock TurretImageData(ArtilleryBarrel2)
{
   className = WeaponImage;
   shapeFile = "turret_tank_barrelmortar.dts";
   item = MissileLauncher;
   ammo = MortarAmmo;
   projectile = ArtilleryShot;
   projectileType = GrenadeProjectile;

   offset = "-0.5 0 0";

   usesEnergy                       = false;
   useMountEnergy                   = true;
   fireEnergy                       = 0.0;
   minEnergy                        = 0.0;

   stateName[0]                     = "WaitFire";
   stateTransitionOnTriggerDown[0]  = "Fire";

   stateName[1]                     = "Fire";
   stateTransitionOnTimeout[1]      = "StopFire";
   stateTimeoutValue[1]             = 2.0;
   stateFire[1]                     = true;
   stateEmitter[1] 			= "WhiteHorseHeatSeekerFireEffectEmitter";
   stateEmitterNode[1] 			= "muzzlepoint1";
   stateEmitterTime[1] 			= 1;
   stateAllowImageChange[1]         = false;
   stateSequence[1]                 = "Fire";
   stateScript[1]                   = "onFire";
   stateSound[1]                    = AssaultMortarFireSound;

   stateName[2]                     = "StopFire";
   stateTimeoutValue[2]             = 0.1;
   stateTransitionOnTimeout[2]      = "WaitFire";
   stateScript[2]                   = "stopFire";
};

datablock TurretImageData(ArtilleryParam)
{
   mountPoint = 0;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0.0 1.0 0.0";

   projectile = ArtilleryShot;
   projectileType = GrenadeProjectile;

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

//---------------------------------------------
//	Vehicle.cs stuff
//---------------------------------------------

function Artillery::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   %obj.schedule(6000, "playThread", $ActivateThread, "activate");
   %obj.selweapontype = 1;
   %obj.firing = 0;

   %turret = TurretData::create(ArtilleryTurret);

   %turret.selectedWeapon = 1;
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.setSelfPowered();

   %obj.mountObject(%turret, 1);
   %turret.mountImage(ArtilleryParam, 0);
   %turret.mountImage(ArtilleryBarrel, 2);
   %turret.mountImage(ArtilleryBarrel2, 3);
   %turret.setCapacitorRechargeRate( %turret.getDataBlock().capacitorRechargeRate );

   %obj.turretObject = %turret;
   %turret.setAutoFire(false);

   %turret.setInventory(MortarAmmo, 10);
   %turret.mountedto = %obj;

   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
}

function Artillery::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(1);
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

function Artillery::playerMounted(%data, %obj, %player, %node)
{
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);
   if(%obj.firing == 1){
	%turret = %obj.getMountNodeObject(1);
	if (!%player.client.isAIControlled())
      {
	   %player.setControlObject(%turret);
	   %player.client.setObjectActiveImage(%turret, 2);
      }
   }
   commandToClient(%player.client, 'setHudMode', 'Pilot', "MPB", %node);
   bottomPrint(%player.client, "Press Grenade button to switch to firing mode.", 5, 2 );
   if ( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

//---------------------------------------------
//	Weapon Stuff
//---------------------------------------------

function Artillery::onTrigger(%data, %obj, %trigger, %state)
{
   %player = %obj.getMountNodeObject(0);
   if(%trigger == 4)
   {
      switch (%state) 
	{
         case 1:
		%turret = %obj.getMountNodeObject(1);
		if (!%player.client.isAIControlled())
      	{
		   %player.setControlObject(%turret);
		   %player.client.setObjectActiveImage(%turret, 2);
		   commandToClient(%player.client, 'setHudMode', 'Pilot', "Assault", 1);
      	}
		%obj.firing = 1;
		bottomPrint(%player.client, "Will need to be reloaded with Artillery Reloader Pack.", 5, 2 );
      }
   }
}

function ArtilleryTurret::onTrigger(%data, %obj, %trigger, %state)
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
            %obj.getDataBlock().playerDismount(%obj);
	case 4:
         if(%state){
		%client = %obj.getControllingClient();
	      if (!%client.isAIControlled())
		   %client.player.unmount();
	      %obj.mountedto.firing = 0;
         }
   }
}

function ArtilleryBarrel::firePair(%this, %obj, %slot){
   %obj.setImageTrigger( 3, true);
}

function ArtilleryBarrel2::stopFire(%this, %obj, %slot){
   %obj.setImageTrigger( 3, false);
}

function ArtilleryBarrel::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   if(%obj.mountedto.selweapontype == 2)
	%p.cluster = schedule(1000, %p, "ARTdocluster", %p, %slot, %obj, 0);	
}

function ArtilleryBarrel2::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   if(%obj.mountedto.selweapontype == 2)
	%p.cluster = schedule(1000, %p, "ARTdocluster", %p, %slot, %obj, 0);
}

function ArtilleryTurret::playerDismount(%data, %obj)
{
   //Passenger Exiting
   %obj.fireTrigger = 0;
   %obj.setImageTrigger(2, false);
   %obj.setImageTrigger(3, false);
   %client = %obj.getControllingClient();
   %client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
   %client.player.mountVehicle = false;
   setTargetSensorGroup(%obj.getTarget(), 0);
   setTargetNeverVisMask(%obj.getTarget(), 0xffffffff);
}

function ARTdocluster(%proj,%slot,%obj,%pos2){
   %pos = %proj.getPosition();
   if(%pos2 != 0){
	%vec = vectorNormalize(vectorSub(%pos,%pos2));
	%newvec = vectorscale(%vec, 380);
	%newvec = vectoradd(%pos,%newvec);
	%mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType;
	%searchresult = containerRayCast(%pos, %newvec, %mask);
	if(%searchresult){
	   for (%i=0; %i < 45; %i++)
	   {
		%x = (getRandom() - 0.5) * 2 * 3.1415926 * 0.025;
		%y = (getRandom() - 0.5) * 2 * 3.1415926 * 0.013;
		%z = (getRandom() - 0.5) * 2 * 3.1415926 * 0.03;
		%mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
		%newvector = MatrixMulVector(%mat, %vec);
		%newvector = vectorScale(%newvector, (getRandom() + 0.5));

		%p = new GrenadeProjectile() 
		{
               dataBlock        = ClusterSubProj;
               initialDirection = %newvector;
               initialPosition  = %pos;
               sourceObject     = %obj;
		   damageFactor	 = 1;
               sourceSlot       = %slot;
      	};
	   }
	   %proj.delete();
	   return;
	}
   }
   %pos2 = %pos;
   %proj.cluster = schedule(100, %proj, "ARTdocluster", %proj, %slot, %obj, %pos2);
}