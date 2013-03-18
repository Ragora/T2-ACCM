datablock EffectProfile(IBLSwitchEffect)
{
   effectname = "powered/turret_light_activate";
   minDistance = 5.0;
   maxDistance = 5.0;
};

datablock EffectProfile(IBLFireEffect)
{
   effectname = "powered/turret_indoor_fire";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(IBLSwitchSound)
{
   filename    = "fx/powered/turret_light_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = IBLSwitchEffect;
};

datablock AudioProfile(IBLFireSound)
{
   filename    = "fx/weapons/chaingun_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = IBLFireEffect;
};

datablock SensorData(DeployedIndoorTurretSensor)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsActiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 130;
};

datablock ShockwaveData(IndoorTurretMuzzleFlash)
{
   width = 0.5;
   numSegments = 13;
   numVertSegments = 1;
   velocity = 2.0;
   acceleration = -1.0;
   lifetimeMS = 300;
   height = 0.1;
   verticalCurve = 0.5;

   mapToTerrain = false;
   renderBottom = false;
   orientToNormal = true;
   renderSquare = true;

   texture[0] = "special/blasterHit";
   texture[1] = "special/gradient";
   texWrap = 3.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "1.0 0.3 0.3 1.0";
   colors[1] = "1.0 0.3 0.3 1.0";
   colors[2] = "1.0 0.3 0.3 0.0";
};

datablock TurretData(TurretDeployedFloorIndoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployf.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.25;
      expImpulse = 500.0;
   repairRate = 0;
   heatSignature = 0.0;

	deployedObject = true;

   thetaMin = 5;
   thetaMax = 145;
   thetaNull = 90;

   primaryAxis = zaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 30;
   rechargeRate = 0.10;
   barrel = DeployableIndoorBarrel;

   canControl = false;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Emplacment';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;

   noFire = 1;
};

datablock TurretData(TurretDeployedWallIndoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployw.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.25;
      expImpulse = 500.0;
   repairRate = 0;
   heatSignature = 0.0;

   thetaMin = 5;
   thetaMax = 145;
   thetaNull = 90;

   deployedObject = true;

   primaryAxis = yaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 30;
   rechargeRate = 0.10;
   barrel = DeployableIndoorBarrel;

   canControl = false;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Emplacment';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;

   noFire = 1;
};

datablock TurretData(TurretDeployedCeilingIndoor) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_indoor_deployc.dts";

   mass = 5.0;
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.8;
   explosion      = SmallTurretExplosion;
      expDmgRadius = 5.0;
      expDamage = 0.5;
      expImpulse = 500.0;
   repairRate = 0;
   explosion = SmallTurretExplosion;

   //thetaMin = 5;
   //thetaMax = 145;
   thetaMin = 35;
   thetaMax = 175;
   thetaNull = 90;
   heatSignature = 0.0;

   deployedObject = true;

   primaryAxis = revzaxis;

   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 75;
   rechargeRate = 0.5;
   barrel = DeployableIndoorBarrel;

   canControl = false;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Implacment';
   targetTypeTag = 'Turret';
   sensorData = DeployedIndoorTurretSensor;
   sensorRadius = DeployedIndoorTurretSensor.detectRadius;
   sensorColor = "191 0 226";

   firstPersonOnly = true;
   renderWhenDestroyed = false;

   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;

   noFire = 1;
};

datablock StaticShapeData(ControlStation) : StaticShapeDamageProfile
{
   className = Station;
   shapeFile = "station_teleport.dts";
   maxDamage = 2.0;
   destroyedLevel = 2.0;
   disabledLevel = 1.5;
   explosion      = DeployablesExplosion;
      expDmgRadius = 8.0;
      expDamage = 0.35;
      expImpulse = 500.0;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = false;
   energyPerDamagePoint = 110;
   maxEnergy = 50;
   rechargeRate = 0.20;
   renderWhenDestroyed = false;

   deployedObject = true;

   cantAbandon = 1;

   cmdCategory = "DSupport";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Control';
   targetTypeTag = 'Station';

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
};

datablock TracerProjectileData(ImplacmentBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.12; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::IndoorDepTurret;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   kickBackStrength  = 1000.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 1500.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 15.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.12;
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

datablock TurretImageData(DeployableIndoorBarrel)
{
   shapeFile = "turret_tank_barrelchain.dts";
   item      = TurretIndoorDeployable; // z0dd - ZOD, 4/25/02. Was wrong: IndoorTurretBarrel
   offset = "0 -1 0"; 	// L/R - F/B - T/B
   rotation = "0 1 0 90";

   projectile = ImplacmentBullet;
   projectileType = TracerProjectile;

   usesEnergy = true;
   fireEnergy = 0.0;
   minEnergy = 0.5;
   projectileSpread = 0.5 / 1000.0;
   maxSpread = 8 / 1000.0;

   lightType = "WeaponFireLight";
   lightColor = "0.25 0.15 0.15 1.0";
   lightTime = "1000";
   lightRadius = "2";

   muzzleFlash = IndoorTurretMuzzleFlash;

   // Turret parameters
   activationMS      = 1000;
   deactivateDelayMS = 1000;
   thinkTimeMS       = 100000;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 240;

   // State transitions
   stateName[0]                  = "Activate";
   stateTransitionOnNotLoaded[0] = "Dead";
   stateTransitionOnLoaded[0]    = "ActivateReady";

   stateName[1]                  = "ActivateReady";
   stateSequence[1]              = "Activate";
   stateSound[1]                 = IBLSwitchSound;
   stateTimeoutValue[1]          = 1;
   stateTransitionOnTimeout[1]   = "Ready";
   stateTransitionOnNotLoaded[1] = "Deactivate";
   stateTransitionOnNoAmmo[1]    = "NoAmmo";

   stateName[2]                    = "Ready";
   stateTransitionOnNotLoaded[2]   = "Deactivate";
   stateTransitionOnTriggerDown[2] = "Fire";
   stateTransitionOnNoAmmo[2]      = "NoAmmo";

   stateName[3]                = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3]        = 0.01;
   stateFire[3]                = true;
   stateShockwave[3]           = true;
   stateRecoil[3]              = LightRecoil;
   stateAllowImageChange[3]    = false;
   stateSequence[3]            = "Fire";
   stateSound[3]               = IBLFireSound;
   stateScript[3]              = "onFire";

   stateName[4]                  = "Reload";
   stateTimeoutValue[4]          = 0.03;
   stateAllowImageChange[4]      = false;
   stateSequence[4]              = "Reload";
   stateTransitionOnTimeout[4]   = "Ready";
   stateTransitionOnNotLoaded[4] = "Deactivate";
   stateTransitionOnNoAmmo[4]    = "NoAmmo";

   stateName[5]                = "Deactivate";
   stateSequence[5]            = "Activate";
   stateDirection[5]           = false;
   stateTimeoutValue[5]        = 1;
   stateTransitionOnLoaded[5]  = "ActivateReady";
   stateTransitionOnTimeout[5] = "Dead";

   stateName[6]               = "Dead";
   stateTransitionOnLoaded[6] = "ActivateReady";

   stateName[7]             = "NoAmmo";
   stateTransitionOnAmmo[7] = "Reload";
   stateSequence[7]         = "NoAmmo";
};

function DeployableIndoorBarrel::onFire(%data, %obj, %slot){
   %data.lightStart = getSimTime();

   if(%obj.spread $= "")
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (4 / 10000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "lowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

   %vec = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };
   %obj.lastProjectile = %p;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;
}

function lowerSpread(%data, %obj){
   %obj.spread = %obj.spread - (4 / 10000);
   if(%obj.spread < %data.projectileSpread){
	%obj.spread = %data.projectileSpread;
	%obj.lowSpreadLoop = "";
	return;
   }
   %obj.lowSpreadLoop = schedule(120, 0, "lowerSpread", %data, %obj);
}

function TurretIndoorDeployableImage::onDeploy(%item, %plyr, %slot)
{
   if(!isObject(%plyr.depTurret)){
      %plyr.deplStation = "";
	%plyr.depTurret = "";
   }
   if(%plyr.deplStation != 1){
      %rot = %item.getInitialRotation(%plyr);
      %className = "Turret";
      %deplObj = new (%className)() {
         dataBlock = %item.deployed;
      };
      %deplObj.setDeployRotation(%item.surfacePt, %item.surfaceNrm);
      if (%deplObj.getDatablock().rechargeRate)
         %deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

      %deplObj.team = %plyr.client.Team;
      %deplObj.setOwner(%plyr);
      if (%deplObj.getTarget() != -1)
         setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

      addToDeployGroup(%deplObj);
      AIDeployObject(%plyr.client, %deplObj);

      serverPlay3D(%item.deploySound, %deplObj.getTransform());
      $TeamDeployedCount[%plyr.team, %item.item]++;

      if (%classname !$= "Item")
         %deplObj.deploy();
      addDSurface(%item.surface,%deplObj);

      %plyr.deplStation = 1;
	%plyr.depTurret = %deplObj;

      return %deplObj;
   }
   else {
      %rot = %item.getInitialRotation(%plyr);
      %className = "StaticShape";

      %deplObj = new (%className)() {
         dataBlock = "ControlStation";
	   scale = "0.3 0.3 1";
      };

	%rot = %plyr.getRotation();

      %deplObj.setTransform(VectorAdd(%item.surfacePt, %plac) SPC %rot);

      if (%deplObj.getDatablock().rechargeRate)
         %deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

      if (%deplObj.getTarget() != -1)
         setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

      addToDeployGroup(%deplObj);

      AIDeployObject(%plyr.client, %deplObj);
      serverPlay3D(%item.deploySound, %deplObj.getTransform());

      %deplObj.deploy();

	%deplObj.Turret = %plyr.depTurret;
	%deplObj.Turret.Base = %deplObj;

	%startvec = vectorAdd(%deplObj.getPosition(), "0 0 2.5");
	%endvec = %deplObj.Turret.getWorldBoxCenter();
	if(vectorLen(vectorSub(%plyr.depTurret.getPosition(), %startvec)) >= 4){
	   %deplObj.schedule(10, "delete");
	   messageclient(%plyr.client, 'MsgClient', "Control position must be close to turret.");
	   return;
	}

	%search = containerRayCast(%startvec, %endvec, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TurretObjectType);
	if(%search){
	   if(getWord(%search,0) $= %deplObj){
		echo(%deplObj.Turret@" "@getWord(%search,0));
	      %deplObj.schedule(10, "delete");
	      messageclient(%plyr.client, 'MsgClient', "Must be able to grasp turret from control position.");
	      return;
	   }
	}

      %plyr.unmountImage(%slot);
      %plyr.decInventory(%item.item, 1);

      %plyr.deplStation = "";
	%plyr.depTurret = "";

	addDSurface(%item.surface,%deplObj);
      return %deplObj;
   }
}

function ControlStation::onCollision(%data,%obj,%col) {
   if(%col.getDatablock().className !$= "Armor")
	return;
   if(%obj.getMountNodeObject(0) == 0 && %col.mountVehicle){
      %obj.mountObject(%col,0);
      %col.setControlObject(%obj.Turret);
      %col.client.setObjectActiveImage(%obj.Turret, 0);
   }
}
