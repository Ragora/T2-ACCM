$missile::maxturnspeed = 220;
$missile::maxforwardspeed = 900;

datablock TracerProjectileData(CGM_exp)
{
   doDynamicClientHits = true;

   directDamage        = 0.0;
   directDamageType    = $DamageType::MissileTurret;
   explosion           = "artillerybarrelexplosion";
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 5.5;
   damageRadius        = 45.0;
   radiusDamageType    = $DamageType::MissileTurret;

   kickBackStrength  = 500;
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

datablock FlyingVehicleData(CGmissile) : ShrikeDamageProfile
{
   spawnOffset = "0 0 2";
   canControl = false;
   catagory = "Vehicles";
   shapeFile = "vehicle_grav_scout.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "vehicle_grav_scout.dts";
   debris = MeShapeDebris;
   renderWhenDestroyed = false;

   drag    = 0.15;
   density = 1.0;

   numMountPoints = 0;
   cameraMaxDist = 15;
   cameraOffset = 2.5;
   cameraLag = 0.9;
   explosion = MeVehicleExplosion;
	explosionDamage = 1.0;
	explosionRadius = 20.0;

   maxDamage = 0.5;
   destroyedLevel = 0.5;

   HDAddMassLevel = 0.4;
   HDMassImage = ShrikeHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 0;
   maxEnergy = 280;      // Afterburner and any energy weapon pool
   rechargeRate = 0.8;

   minDrag = 30;           // Linear Drag (eventually slows you down when not thrusting...constant drag)
   rotationalDrag = 900;        // Anguler Drag (dampens the drift after you stop moving the mouse...also tumble drag)

   maxAutoSpeed = 10000;       // Autostabilizer kicks in when less than this speed. (meters/second)
   autoAngularForce = 200;       // Angular stabilizer force (this force levels you out when autostabilizer kicks in)
   autoLinearForce = 0;        // Linear stabilzer force (this slows you down when autostabilizer kicks in)
   autoInputDamping = 1.0;      // Dampen control input so you don't` whack out at very slow speeds


   // Maneuvering
   maxSteeringAngle = 4.5;    // Max radiens you can rotate the wheel. Smaller number is more maneuverable.
   horizontalSurfaceForce = 6;   // Horizontal center "wing" (provides "bite" into the wind for climbing/diving and turning)
   verticalSurfaceForce = 4;     // Vertical center "wing" (controls side slip. lower numbers make MORE slide.)
   maneuveringForce = 5250;      // Horizontal jets (W,S,D,A key thrust)
   steeringForce = 600;         // Steering jets (force applied when you move the mouse)
   steeringRollForce = 3000;      // Steering jets (how much you heel over when you turn)
   rollForce = 1;                // Auto-roll (self-correction to right you after you roll/invert)
   hoverHeight = 1;        // Height off the ground at rest
   createHoverHeight = 1;  // Height off the ground when created
   maxForwardSpeed = 130;  // speed in which forward thrust force is no longer applied (meters/second)

   // Turbo Jet
   jetForce = 2500;      // Afterburner thrust (this is in addition to normal thrust)
   minJetEnergy = 28;     // Afterburner can't be used if below this threshhold.
   jetEnergyDrain = 0.1;       // Energy use of the afterburners (low number is less drain...can be fractional)                                                                                                                                                                                                                                                                                          // Auto stabilize speed
   vertThrustMultiple = 1.25;

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
   engineSound = ScoutFlyerThrustSound;
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

   damageEmitter[0] = MissileSmokeEmitter;
   damageEmitter[1] = MeHeavyDamageSmoke;
   damageEmitter[2] = MeDamageBubbles;
   damageEmitterOffset[0] = "0.0 -0.3 0.0 ";
   damageLevelTolerance[0] = 0.0;
   damageLevelTolerance[1] = 0.75;
   numDmgEmitterAreas = 1;

   minMountDist = 7;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingScoutIcon;
   cmdMiniIconName = "commander/MiniIcons/com_scout_grey";
   targetNameTag = 'TomaHawk';
   targetTypeTag = 'Cruise Missile';
   sensorData = PlayerSensor;

   checkRadius = 5.5;
   observeParameters = "1 10 10";

   runningLight[0] = ShrikeLight1;

   shieldEffectScale = "0.937 1.125 0.60";
};

datablock TurretData(CGMTurret) : TurretDamageProfile
{
   className               = VehicleTurret;
   catagory                = "Turrets";
   shapeFile               = "turret_base_large.dts";
   preload                 = true;
   canControl = false;
   cmdCategory = "Tactical";
   cmdIcon = CMDFlyingBomberIcon;
   cmdMiniIconName = "commander/MiniIcons/com_bomber_grey";

   mass                    = 1.0;  // Not really relevant
   repairRate              = 0;
   maxDamage               = CGmissile.maxDamage;
   destroyedLevel          = CGmissile.destroyedLevel;

   thetaMin                = 1;
   thetaMax                = 180;
   thetaNull		   = 90;

   // capacitor
   maxCapacitorEnergy      = 200;
   capacitorRechargeRate   = 5.0;

   inheritEnergyFromMount  = true;
   firstPersonOnly         = true;
   useEyePoint             = true;
   numWeapons              = 1;

   targetNameTag           = 'CGM';
   targetTypeTag           = 'Turret';
};

datablock TurretImageData(CGMTL)
{
   className = WeaponImage;
   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 0 0";
   mountPoint = 1;

   projectile = GunshipTlProj;
   projectileType = TargetProjectile;
   deleteLastProjectile = false;

   usesEnergy = true;
   useMountEnergy = true;
   useCapacitor = false;
   minEnergy = 0;
   fireEnergy = 1.0;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
   stateTimeoutValue[0]			= 0.1;
   stateTransitionOnTimeout[0]       = "Ready";

   stateName[1]				= "Ready";
   stateTransitionOnTriggerDown[1]	= "Fire";

   stateName[2]                     = "Fire";
   stateEnergyDrain[2]              = 0;
   stateFire[2]                     = true;
   stateScript[2]                   = "onFire";
   stateTransitionOnTriggerUp[2]	= "Deconstruct";

   stateName[3]				= "Deconstruct";
   stateScript[3]				= "onDecon";
   stateTimeoutValue[3]			= 0.1;
   stateTransitionOnTimeout[3]	= "Ready";
};

datablock StaticShapeData(TMShape) : StaticShapeDamageProfile {
   shapeFile      = "weapon_missile_projectile.dts";
   mass           = 1.0;
   repairRate     = 0;
   dynamicType    = $TypeMasks::StaticShapeObjectType;
   heatSignature  = 0;
};

function CGMTL::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.TL = %p;
   CGMfollowloop(%obj.vehicleMounted);
   schedule(1000, 0, 'CGMExplode', %obj.vehicleMounted);
}

function CGMTL::onDecon(%data,%obj,%slot){
   %obj.TL.delete();
}

function CGmissile::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);
   if (%obj.clientControl)
       serverCmdResetControlObject(%obj.clientControl);
   %obj.schedule(5500, "playThread", $ActivateThread, "activate");

   %turret = TurretData::create(CGMTurret);
   MissionCleanup.add(%turret);
   %turret.team = %obj.teamBought;
   %turret.selectedWeapon = 1;
   %turret.setSelfPowered();
   %obj.mountObject(%turret, 10);
   %turret.mountImage(AIAimingTurretBarrel, 0);
   %turret.mountImage(CGMTL, 2);
   %turret.setImageTrigger(2, true);
   %obj.turretObject = %turret;
   %turret.vehicleMounted = %obj;
   %turret.setAutoFire(false);
   setTargetSensorGroup(%turret.getTarget(), %turret.team);
   setTargetNeverVisMask(%turret.getTarget(), 0xffffffff);
   %obj.startFade(0,10,1);
   %turret.startFade(10,20,1);

  %body = new StaticShape()
   {
       scale = "5 5 5";
       dataBlock = "TMShape";
   };
   MissionCleanup.add(%body);
   %obj.mountObject(%body, 1);
   %body.vehicleMounted = %obj;
}

function startCGM(%p){
   if(!isObject(%p))
	return;
   %data = "CGmissile";
   %pn = %data.create(0);
   %pn.setTransform(%p.getPosition() SPC "1 0 0 -90"); 
   %pn.CGMsourceObject     = %p.sourceObject; 
   %pn.CGMsourceSlot       = %p.sourceSlot;
   %pn.applyImpulse(%pn.getPosition(),vectorScale(%p.sourceObject.vehicleObject.getVelocity(),%data.mass));
   MissionCleanup.add(%pn);
   %client = %p.sourceObject.getControllingClient();
   if (!%client.isAIControlled())
   {
      %client.player.setControlObject(%pn.turretObject);
      %client.player.client.setObjectActiveImage(%pn.turretObject, 2);
   }
   %p.delete(); 
}

function CGMfollowloop(%obj){
   if(!isObject(%obj))
	return;
   if(!isObject(%obj.turretObject.TL))
	return;
   %pos = %obj.getPosition();
   %targetpos = %obj.turretObject.TL.getTargetPoint();
   if(%targetpos $= "0 0 0 -1"){
	%Tpos = %obj.turretObject.getPosition();
	%Tvec = vectorScale(%obj.turretObject.getMuzzleVector(2),1500);
	%targetpos = vectorAdd(%Tpos,%Tvec);
   }
   %frontvec = %obj.getForwardVector();
   %vector = vectorNormalize(vectorSub(%targetpos,%pos));
   %obj.applyImpulse(vectorAdd(%pos,%frontvec),vectorScale(%vector,$missile::maxturnspeed));	//make it turn toward Target
   %obj.applyImpulse(%pos,vectorScale(%frontvec,$missile::maxforwardspeed));				//make it go forward
   %obj.following = schedule(100, 0, "CGMfollowloop", %obj);
}

function CGMExplode(%obj){ 
   if(!isObject(%obj))
	return;
   InitContainerRadiusSearch(%obj.getWorldBoxCenter(), 15, $TypeMasks::VehicleObjectType);
   while ((%SearchResult = containerSearchNext()) != 0)
   {
	if(%searchObj !$= %obj){
	   %pn = new (TracerProjectile)() { 
		dataBlock        = CGM_exp; 
		initialDirection = vectorNormalize(%obj.getVelocity()); 
		initialPosition  = %obj.getWorldBoxCenter(); 
		sourceObject     = %obj.CGMsourceObject; 
		sourceSlot       = %obj.CGMsourceSlot; 
	   }; 
	   MissionCleanup.add(%pn); 
	   return;
	}
   }
   %obj.doexplodecheck = schedule(30, 0, "CGMExplode", %obj);
}

function CGmissile::deleteAllMounted(%data, %obj)
{
   %turret = %obj.getMountNodeObject(10);
   if (isObject(%turret)){
	%turret.altTrigger = 0;
	%turret.fireTrigger = 0;
	if (%client = %turret.getControllingClient())
	{
	   if(isObject(%obj.CGMSourceObject)){
		%client.player.setControlObject(%obj.CGMSourceObject);
      	%obj.CGMSourceObject.selectedWeapon = 1;
      	commandToClient(%client,'SetWeaponryVehicleKeys', true);
		commandToClient(%client, 'setHudMode', 'Pilot', "bomber", %node);
	   } else {
      	%client.player.setControlObject(%client.player);
      	%client.player.mountImage(%client.player.lastWeapon, $WeaponSlot);
      	%client.player.mountVehicle = false;

      	%client.player.bomber = false;
      	%client.player.isBomber = false;
	   }
	}
	%turret.schedule(2000, delete);
	if(isObject(%turret.TL))
	   %turret.TL.delete();
	
   }
   %body = %obj.getMountNodeObject(1);
   if (isObject(%body))
	%body.schedule(2000, delete);

   %pn = new (TracerProjectile)() { 
	dataBlock        = CGM_exp; 
	initialDirection = "0 0 1"; 
	initialPosition  = %obj.getWorldBoxCenter(); 
	sourceObject     = %obj.CGMsourceObject; 
	sourceSlot       = %obj.CGMsourceSlot; 
   }; 
   MissionCleanup.add(%pn); 
}

function CGmissile::onEnterLiquid(%data, %obj, %coverage, %type)
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