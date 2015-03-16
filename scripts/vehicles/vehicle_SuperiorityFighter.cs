//**************************************************************
// AIR SUPERIORITY FIGHTER
//**************************************************************

//**************************************************************
// VEHICLE CHARACTERISTICS
//**************************************************************

datablock FlyingVehicleData(SuperiorityFighter) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_air_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_air_scout.dts";
   debris = MeShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = false;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MeVehicleExplosion;
	explosionDamage = 1.0;
	explosionRadius = 10.0;

   maxDamage = 2.5;
   destroyedLevel = 2.5;

   HDAddMassLevel = 1.9;
   HDMassImage = LflyerHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 2000;      // Afterburner and any energy weapon pool
   rechargeRate = 6;

   minDrag = 22;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 66;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 400;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 1;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 0.8;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 6250;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 750;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 2.5;        // Height off the ground at rest
   createHoverHeight = 1;  // Height off the ground when created
   maxForwardSpeed = 250;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 3250;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 40;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 18;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 0;

   // Rigid body
   mass = 150;        // Mass of the vehicle
   bodyFriction = 0;     // Don't mess with this.
   bodyRestitution = 0.5;   // When you hit the ground, how much you rebound. (between 0 and 1)
   minRollSpeed = 0;     // Don't mess with this.
   softImpactSpeed = 14;       // Sound hooks. This is the soft hit.
   hardImpactSpeed = 25;    // Sound hooks. This is the hard hit.

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 20;      // If hit ground at speed above this then it's an impact. Meters/second
   speedDamageScale = 0.06;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 23.0;
   collDamageMultiplier   = 0.02;

   //
   minTrailSpeed = 150;      // The speed your contrail shows up at.
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

   damageEmitter[0] = MeLightDamageSmoke;
   damageEmitter[1] = MeHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -3.0 0.0 ";
   damageLevelTolerance[0] = 0.4;
   damageLevelTolerance[1] = 0.75;
   numDmgEmitterAreas = 1;

   //
   max[chaingunAmmo] = 750;
   max[MissileLauncherAmmo] = 4;
   max[MortarAmmo] = 3;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'F54 Tornado';
   targetTypeTag = 'Superiority Fighter';
   sensorData = combatSensor;
   sensorRadius = combatSensor.detectRadius;
   sensorColor = "9 9 255";

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;
//   runningLight[1] = ShrikeLight2;

   shieldEffectScale = "0.937 1.125 0.60";

   numWeapons = 3;

   replaceTime = 130;

   max[plasmaammo] = 20;
   flaretime = 200;
   flarelife = 850;
   flarechance = 0.5;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(Superiority_bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.25;
   directDamageType    = $DamageType::Bullet;
   explosion           = ChaingunExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.0225;
   damageRadius        = 0.5;
   radiusDamageType    = $DamageType::Bullet;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 2250.0;
   wetVelocity       = 2000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.20;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

datablock SeekerProjectileData(LRAAM)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 2.1;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::MissileTurret;
   kickBackStrength    = 500;

   flareDistance = 200;
   flareAngle    = 30;
   minSeekHeat   = 0.0;

   explosion           = "MissileExplosion";
   velInheritFactor    = 1.0;

   splash              = MissileSplash;
   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;

   lifetimeMS          = 10000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 25.0;
   maxVelocity         = 400.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 50.0;
   acceleration        = 150.0;
   
   proximityRadius     = 6;

   terrainAvoidanceSpeed = 100;
   terrainScanAhead      = 50;
   terrainHeightFail     = 50;
   terrainAvoidanceRadius = 150;

   useFlechette = true;
   flechetteDelayMs = 225;
   casingDeb = FlechetteDebris;
};


//**************************************************************
// WEAPONS
//**************************************************************

datablock ShapeBaseImageData(SuperiorityChaingunImage)
{
   className = WeaponImage;
   shapeFile = "turret_missile_large.dts"; //was turret_tank_barrelchain.dts
   item      = Chaingun;
   ammo   = ChaingunAmmo;
   projectile = Superiority_bullet;
   projectileType = TracerProjectile;
   mountPoint = 10;
   offset = "0 2.1 -0.2"; // L/R - F/B - T/B was "0 3.25 0.75"
   rotation = "0 1 0 180";

   projectileSpread = 1.0 / 1000.0;

   velpredict = 0;

   usesEnergy = false;

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
   stateFire[3] = true;
   stateScript[3] = "onFire";
   stateSound[3] = ShrikeBlasterFire;
   stateTimeoutValue[3] = 0.01; 
   stateTransitionOnTimeout[3] = "Reload";
   stateAllowImageChange[3] = false;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.01;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(SuperiorityMissileImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = MissileLauncher;
   ammo = MissileLauncherAmmo;
   projectile = sidewinder;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
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
   stateSound[3] = MissileFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 1.0;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = ShrikeBlasterDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(LRAAMImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = Mortar;
   ammo = MortarAmmo;
   projectile = LRAAM;
   projectileType = SeekerProjectile;

   mountPoint = 10;
   offset = "0 -0 -0.15"; // L/R - F/B - T/B

   usesEnergy = false;
   useMountEnergy = true;
   minEnergy = 100;
   fireEnergy = 100;
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
   stateSound[3] = BomberBombFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6] = "DryFire";
   stateSound[6] = BomberBombDryFireSound;
   stateTimeoutValue[6] = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function SuperiorityFighter::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);

   %obj.mountImage(ScoutChaingunParam, 0);
   %obj.mountImage(SuperiorityChaingunImage, 2);
   %obj.mountImage(superiorityMissileImage, 4);
   %obj.mountImage(LRAAMImage, 5);
   %obj.selectedWeapon = 1;
   %obj.nextWeaponFire = 2;
   %obj.setInventory(MissileLauncherAmmo, 4);
   %obj.setInventory(MortarAmmo, 3);
   %obj.setInventory(chaingunammo, 750);
   %obj.setInventory(plasmaAmmo,25);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");
   schedule(2500, 0, "supersonicloop", %obj);
}

function SuperiorityFighter::playerMounted(%data, %obj, %player, %node)
{
   %ammoAmt = %player.inv[MissileLauncherAmmo];
   if(%ammoAmt)
     %obj.incInventory(MissileLauncherAmmo, %ammoAmt);

   %ammoAmt = %player.inv[MortarAmmo];
   if(%ammoAmt)
     %obj.incInventory(MortarAmmo, %ammoAmt);

   %ammoAmt = %player.inv[chaingunAmmo];
   if(%ammoAmt)
     %obj.incInventory(chaingunAmmo, %ammoAmt);

   bottomPrint(%player.client, "Tornado: wep1 CG, wep2 sidewinders, wep3 LRAAMS", 5, 2 );


   commandToClient(%player.client, 'setHudMode', 'Pilot', "Shrike2", %node);
   %obj.selectedWeapon = 1;
   $numVWeapons = 3;
   commandToClient(%player.client, 'SetWeaponryVehicleKeys', true);
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function SuperiorityFighter::onTrigger(%data, %obj, %trigger, %state)
{
   %player = %obj.getMountNodeObject(0);
   if(%trigger == 0)
   {
      switch (%state) 
	{
         case 0:
            %obj.fireWeapon = false;
            %obj.setImageTrigger(2, false);
            %obj.setImageTrigger(4, false);
            %obj.setImageTrigger(5, false);
         case 1:
            %obj.fireWeapon = true;
            if(%obj.selectedWeapon == 1){
               %obj.setImageTrigger(2, true);
               %obj.setImageTrigger(4, false);
               %obj.setImageTrigger(5, false);
            }
            else if(%obj.selectedWeapon == 2) {
               %obj.setImageTrigger(2, false);
               %obj.setImageTrigger(4, true);
               %obj.setImageTrigger(5, false);
            }
            else {
               %obj.setImageTrigger(2, false);
               %obj.setImageTrigger(4, false);
               %obj.setImageTrigger(5, true);
            }
      }
   }
   else if (%trigger ==4){
      switch (%state) 
	{
         case 0:
            %obj.flaring = 0;
         case 1:
		%obj.flaring = 1;
		schedule(%data.flaretime, 0, "fighterdropflares",%obj,%data.flaretime,%data.flarelife,%data.flarechance);
       }
   }	
}

function SuperiorityChaingunImage::onFire(%data,%obj,%slot){
   %data.lightStart = getSimTime();

   %vec = %obj.getMuzzleVector(%slot);

   if(%data.velpredict == 1){
	%target = %obj.getLockedTarget();
	if(%target){
	   %Tpos = %target.getWorldBoxCenter();
	   %Opos = %obj.getMuzzlepoint(%slot);
	   %dist = vectorDist(%Tpos,%Opos);
	   %pos = vectorAdd(%Tpos, vectorScale(%target.getVelocity(),(%dist / 1750) ));

	   %dist = vectorDist(%pos,%Opos);
	   %pos = vectorAdd(%Tpos, vectorScale(%target.getVelocity(),(%dist / 1750) ));

	   %Tvec = vectorNormalize(vectorSub(%pos,%Opos));
	   %Fvec = %obj.getMuzzleVector(%slot);
	   if(vectorDist(%Tvec,%Fvec) <= 0.1)
		%vec = vectorNormalize(vectorSub(%Tpos,%obj.getMuzzlePoint(%slot)));
	} 
   }

   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
      vehicleObject    = %vehicle;
   };
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;

   %obj.decInventory(%data.ammo,1);
   return %p;
}

function superiorityMissileImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   MissileSet.add(%p);

   if (%obj.getControllingClient())
      %target = %obj.getLockedTarget();
   else
     %target = %obj.getTargetObject();

   %homein = missileCheckAirTarget(%target);
   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else 
      %p.setNoTarget(); 
}

function LRAAMImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);
   MissileSet.add(%p); 

   if (%obj.getControllingClient())
      %target = %obj.getLockedTarget();
   else 
     %target = %obj.getTargetObject();

   if(isobject(%target))
	%homein = missileCheckAirTarget(%target);

   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else {
	%p.dir = %obj.getForwardVector();
      schedule(500, 0, "LRAAMFindTarget", %p);
   }
}

function LRAAMFindTarget(%p){
   if(!isObject(%p))
	return;
   %vec = vectorScale(vectorNormalize(%p.dir),600);
   %pos = %p.getPosition();
   %tpos = vectorAdd(%vec,%pos);
   InitContainerRadiusSearch(%tpos, 500, $TypeMasks::VehicleObjectType);
   while ((%searchResult = containerSearchNext()) != 0){
	echo(%searchresult);
	if(%searchResult.getClassName() $= "Flyingvehicle"){
	   %p.setObjectTarget(%searchResult);
	   return;
	}
   }
   schedule(250, 0, "LRAAMFindTarget",%p);
}

function superiorityfighter::onDestroyed(%data, %obj, %prevState)
{
   if(%obj.lastPilot.lastVehicle == %obj)
      if(%obj.getMountNodeObject(0) == %obj.lastPilot)
         schedule(200, %obj.lastPilot, "scKillPilot", %obj.lastPilot, %obj.lastDamagedBy);

   Parent::onDestroyed(%data, %obj, %prevState);
}

function supersonicloop(%obj){
   if(!isObject(%obj))
	return;
   %vec = %obj.getVelocity();
   %vel = vectorlen(%vec);
   if(%vel > 200){
	%vec = vectorNormalize(%vec);
	%vec = vectorScale(%vec,-75);

      %pn = new (TracerProjectile)() { 
	   dataBlock        = SuperSonicDet; 
	   initialDirection = "0 0 1"; 
	   initialPosition  = vectoradd(%obj.getPosition(),%vec);
	   sourceObject     = %obj; 
	   sourceSlot       = 1; 
      }; 
   }
   schedule(350, 0, "supersonicloop", %obj);
}

datablock TracerProjectileData(SuperSonicDet)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::BomberBombs;
   explosion           = "";
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 0.1;
   damageRadius        = 50.0;
   radiusDamageType    = $DamageType::default;

   kickBackStrength  = 5000;
   sound             = ChaingunProjectile;

   dryVelocity               = 1.0;
   wetVelocity               = 1.0;
   velInheritFactor          = 1.0;
   fizzleTimeMS              = 32;
   lifetimeMS                = 33;
   explodeOnDeath            = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1;

   tracerLength    = 1.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.35;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

function superiorityfighter::onEnterLiquid(%data, %obj, %coverage, %type)
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