//Dont reorder these or change the first word in them (S11 S17)... do so at your own risk.
$commsatPurchase[1] = "S11 90 S11 Aerial Recon";
$commsatPurchase[2] = "S17 60 S17 Combat Drone";

//DO NOT CHANGE THESE, i did a bad job in scripting in a universal manner :), you can add more though shouldnt be too hard.
$commsatOrder[1] = "Move";
$commsatOrder[2] = "Attack";
$commsatOrder[3] = "Guard";
$commsatOrder[4] = "Rearm";

// ------------------------------------------
// SpySatellite.cs
// ------------------------------------------

datablock TurretData(DeployedSpySatellite) : TurretDamageProfile
{
   className = DeployedTurret;  // VehicleTurret;
   shapeFile = "turret_indoor_deployc.dts";
   debrisShapeName = "debris_generic_small.dts";
   debris = TurretDebrisSmall;
   preload = true;

   canControl = false;
   canObserve = true;
   firstPersonOnly = true;
   observeParameters = "0.5 4.5 4.5";
//   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDCameraIcon;
   cmdMiniIconName = "commander/MiniIcons/com_camera_grey";
   targetNameTag = 'command';
   targetTypeTag = 'Satellite';

   mass = 0.7;
   repairRate = 0;
   maxDamage = 1.0;
   disabledLevel = 1.0;
   destroyedLevel = 1.0;
   explosion      = CameraGrenadeExplosion;
   renderWhenDestroyed = false;

   thetaMin = 60;
   thetaMax = 180;
   thetaNull = 180;
//   primaryAxis = zaxis; //revzaxis;

   isShielded = false;
   energyPerDamagePoint = 1;
   maxEnergy = 1000;
   rechargeRate = 1.0;

   sensorData = CameraSensorObject;
   sensorRadius = CameraSensorObject.detectRadius;

   heatSignature = 0.0;
   barrel = HeliTurretParam;
   numWeapons              = 5;
};

datablock TurretImageData(SpySatelliteBarrel)
{
   shapeFile = "turret_muzzlepoint.dts";
   item      = SpySatelliteBarrel;

   // Turret parameters
   activationMS      = 150;
   deactivateDelayMS = 300;
   thinkTimeMS       = 150;
   degPerSecTheta    = 580;
   degPerSecPhi      = 960;
   attackRadius      = 1;

   // State transitions
   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnTriggerDown[2]  = "Fire";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.5;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";

   stateName[4]                     = "Reload";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 0.5;
   stateAllowImageChange[4]         = false;
};

function SpySatelliteBarrel::onFire(%data,%obj,%slot)
{
   %range = 1000; //Max range It can move.
   %rot = rotFromTransform(%obj.getTransform());
   %muzzlePos = %obj.getMuzzlePoint(%slot);
   %muzzleVec = %obj.getMuzzleVector(%slot);
   %endPos    = VectorAdd(%muzzlePos, VectorScale(%muzzleVec, %range));
   %damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
                  $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
                  $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType |
                  $TypeMasks::InteriorObjectType;

   %terrain = ContainerRayCast(%muzzlePos, %endPos, $TypeMasks::TerrainObjectType, %obj);
   %message = "";
   if (%terrain)
   {
      %xy = getWords(%terrain, 1, 2);
      %z = getWord(%terrain, 3);
      %pos = %xy SPC %z + 200;
      %mask =    ($TypeMasks::VehicleObjectType     | $TypeMasks::MoveableObjectType   |
                  $TypeMasks::StaticShapeObjectType |
                  $TypeMasks::ForceFieldObjectType  | $TypeMasks::ItemObjectType       |
                  $TypeMasks::PlayerObjectType      | $TypeMasks::TurretObjectType);
      InitContainerRadiusSearch( %pos, 2, %mask );
      %test = containerSearchNext();
      if (%test)
         %message = "Can\'t reposition the satellite. Trajectory Blocked";
      else
      {
         %obj.setTransform(%pos SPC %rot);
      }
   }
   else
      %message = "Trajectory not understood. Reenter.";
   if (%message !$= "")
      messageClient(%obj.client, 'msgBlocked', %message);
}


datablock ShapeBaseImageData(SpySatelliteDeployableImage)
{
   shapeFile = "pack_deploy_sensor_pulse.dts";
   item = SpySatelliteDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = DeployedSpySatellite;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";
   deploySound = SpySatelliteDeploySound;

   maxDepSlope = 40;
   emap = true;
   heatSignature = 0;

   minDeployDis                       =  0.1;
   maxDeployDis                       =  15.0;  //meters from body
};

datablock ItemData(SpySatelliteDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_sensor_pulse.dts";
   mass = 2.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "SpySatelliteDeployableImage";
   pickUpName = "a command satellite pack";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(DronePadDeployableImage) {
   mass = 20;
   emap = true;
   shapeFile = "stackable1s.dts";
   item = DronePadDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = StationInventory;
   heatSignature = 0;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   maxDepSlope = 360;
   deploySound = ItemPickupSound;

   minDeployDis = 0.5;
   maxDeployDis = 5.0;
};

datablock ItemData(DronePadDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "stackable1s.dts";
   mass = 5.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = true;
   image = "DronePadDeployableImage";
   joint = "4.5 4.5 4.5";
   pickUpName = "a Drone Pad pack";
   heatSignature = 0;
   emap = true;
};

datablock StaticShapeData(Dronepad) : StaticShapeDamageProfile
{
   className = Station;
   shapeFile = "station_teleport.dts";
   maxDamage = 3.5;
   destroyedLevel = 3.5;
   disabledLevel = 3.2;
   explosion      = DeployablesExplosion;
      expDmgRadius = 10.0;
      expDamage = 0.4;
      expImpulse = 1000.0;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = false;
   energyPerDamagePoint = 110;
   maxEnergy = 50;
   rechargeRate = 0.20;
   renderWhenDestroyed = false;
   doesRepair = true;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Command Satellite';
   targetTypeTag = 'Drone Pad';

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
   needspower = true;
};

datablock HoverVehicleData(commsatControlStation) : MPBDamageProfile
{ 
   spawnOffset = "0 0 0"; 
   canControl = false;
   floatingGravMag = 0; 

   catagory = "Vehicles"; 
   shapeFile = "vehicle_grav_scout.dts"; 
   computeCRC = true; 

   debrisShapeName = "vehicle_grav_scout_debris.dts";
   debris = ShapeDebris;
   renderWhenDestroyed = false;

   drag = 0.0; 
   density = 0.9; 

   mountPose[0] = sitting; 
   isProtectedMountPoint[0] = true; 
   cameraMaxDist = 5.0;
   cameraOffset = 0.7;
   cameraLag = 0.5;
   numMountPoints = 1;
   explosion = VehicleExplosion;
	explosionDamage = 0.5;
	explosionRadius = 5.0;

   // Damage Levels 
   maxDamage = 4; 
   destroyedLevel = 4; 

   cantAbandon = 1;
   cantTeamSwitch = 1;

   isShielded = false; 
   rechargeRate = 0.7;
   energyPerDamagePoint = 75;
   maxEnergy = 150;
   minJetEnergy = 15;
   jetEnergyDrain = 0.1;

   // Rigid Body 
   mass = 300; 
   bodyFriction = 0.1; 
   bodyRestitution = 0.5;  
   softImpactSpeed = 0.5;       // Play SoftImpact Sound 
   hardImpactSpeed = 1;      // Play HardImpact Sound 

   // Ground Impact Damage (uses DamageType::Ground) 
   minImpactSpeed = 55; 
   speedDamageScale = 0.007; 

   // Object Impact Damage (uses DamageType::Impact) 
   collDamageThresholdVel = 1; 
   collDamageMultiplier   = 0.02; 

   dragForce            = 25 / 45.0; 
   vertFactor           = 0.0; 
   floatingThrustFactor = 0.35; 

   mainThrustForce    = 10; 
   reverseThrustForce = 10; 
   strafeThrustForce  = 0; 
   turboFactor        = 1; 

   brakingForce = 25; 
   brakingActivationSpeed = 4; 

   stabLenMin = 2.25; 
   stabLenMax = 3.25; 
   stabSpringConstant  = 30; 
   stabDampingConstant = 12; 

   gyroDrag = 16; 
   normalForce = 30; 
   restorativeForce = 25; 
   steeringForce = 100; 
   rollForce  = 15; 
   pitchForce = 7; 

   dustEmitter = VehicleLiftoffDustEmitter;
   triggerDustHeight = 0;
   dustHeight = 1;
   dustTrailEmitter = TireEmitter;
   dustTrailOffset = "0.0 -1.0 0.5";
   triggerTrailHeight = 3.6;
   dustTrailFreqMod = 15.0;

   jetSound         = ScoutSqueelSound;
   engineSound      = ScoutEngineSound;
   floatSound       = ScoutThrustSound;
   softImpactSound  = GravSoftImpactSound;
   hardImpactSound  = HardImpactSound;

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
   targetNameTag = 'Command Satellite';
   targetTypeTag = 'Control Station';
   sensorData = PlayerSensor;

   checkRadius = 1.7785;
   observeParameters = "1 10 10";

   runningLight[0] = WildcatLight1;
   runningLight[1] = WildcatLight2;
   runningLight[2] = WildcatLight3;

   shieldEffectScale = "0.9375 1.125 0.6"; 
};

function DeployedSpySatellite::onTrigger(%data, %obj, %trigger, %state)
{
   switch (%trigger) {
      case 0:					//leftclick
	   if(%state){
		if(%obj.minedown == 1)
		   commsatCyclePurchase(%obj);
		else if(%obj.grenadedown == 1)
		   commsatPurchase(%obj);
		else if(%obj.rightdown == 1)
		   commsatAddToGroup(%obj,%obj.selectedWeapon);
		else{
		   if(%obj.selectedWeapon >= 1 && %obj.selectedWeapon <= 3)
			commsatSelectGroup(%obj,%obj.selectedWeapon);
		   else if(%obj.selectedWeapon == 4)
			commsatReleaseSelected(%obj);
		   else
			commsatSelectObj(%obj);
		}
	   }
      case 3:					//rightclick
	   if(%state){
		%obj.rightdown = 1;
		if(%obj.minedown == 1)
		   commsatCycleOrders(%obj);
		else if(%obj.grenadedown == 1)
		   commsatIssueOrders(%obj);		   
	   }
	   else
		%obj.rightdown = 0;
      case 4:					//grenade
	   if(%state)
		%obj.grenadedown = 1;
	   else
		%obj.grenadedown = 0;
      case 5:					//mine
	   if(%state)
		%obj.minedown = 1;
	   else
		%obj.minedown = 0;
   }
}

function commsatCyclePurchase(%obj){
   %num = %obj.purchasenum + 1;
   if($commsatPurchase[%num] $= "")
	%num = 1;
   %obj.purchasenum = %num;
   bottomPrint(%obj.getcontrollingclient(), getWords($commsatPurchase[%num],3,4) SPC "selected for purchase.", 5, 2 );
}

function commsatPurchase(%obj){
   %team = %obj.team;
   if(!isObject($commsatVPad[%obj.team]))
	return;
   if(getWord($commsatPurchase[%obj.purchasenum],1) <= $teamcredits[%team]){
	$teamcredits[%team] -= getWord($commsatPurchase[%obj.purchasenum],1);
	$teamUsedCredits[%team] += getWord($commsatPurchase[%obj.purchasenum],1);
	%pos = vectorAdd($commsatVpad[%team].getPosition(),"0 0 4");
	%rotation = "1 0 0 0";
	%drone = getWord($commsatPurchase[%obj.purchasenum],0);
	if(%drone $= "S11"){
	   %veh = new FlyingVehicle(){
	      dataBlock    = S11;
	      position     = %pos;
	      rotation     = %rotation;
	      team         = %team;
	   };
	} else if(%drone $= "S17"){
	   %veh = new HoverVehicle(){
	      dataBlock    = S17;
	      position     = %pos;
	      rotation     = %rotation;
	      team         = %team;
	   };
	}
      MissionCleanUp.add(%veh); 
      setTargetSensorGroup(%veh.getTarget(), %team);
	bottomPrint(%obj.getcontrollingclient(), "Drone purchased.", 5, 2 );
   }
   else
	bottomPrint(%obj.getcontrollingclient(), "Not enough credits to purchase" SPC getWords(2,4), 5, 2 );
}

function commsatAddToGroup(%obj,%num){
   %x = 0;
   %y = 0;
   while(getWord(%obj.selected,%y) !$= ""){
	%trg = getWord(%obj.selected,%y);
	if(isobject(%trg)){
	   %obj.group[%num,%x] = %trg;
	   %x++;
	}
	%y++;
   }
   bottomPrint(%obj.getcontrollingclient(), "Group created.", 5, 2 );
}

function commsatSelectGroup(%obj,%num){
   %x = 0;
   while(%obj.group[%num,%x] !$= ""){
    if(!(%obj.group[%num,%x].selected == 1)){
	if(%obj.selected $= "")
	   %obj.selected = %obj.group[%num,%x]; 
	else 
	   %obj.selected = %obj.selected SPC %obj.group[%num,%x];
	%obj.group[%num,%x].selected = 1;
	%x++;
    }
   }
   bottomPrint(%obj.getcontrollingclient(), "Group selected.", 5, 2 );
}

function commsatReleaseSelected(%obj){
   %y = 0;
   while(getWord(%obj.selected,%y) !$= ""){
	%trg = getWord(%obj.selected,%y);
	if(isobject(%trg))
	   %trg.selected = 0;
	%y++;
   }
   %obj.selected = "";
   bottomPrint(%obj.getcontrollingclient(), "All units deselected.", 5, 2 );
}

function commsatSelectObj(%obj){
   %eye = %obj.getMuzzleVector(2);
   %pos = %obj.getMuzzlePoint(2);
   %search = containerRayCast(%pos,vectorAdd(%pos,vectorScale(%eye,2000)), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TerrainObjectType, %obj);
   if(%search){
	%srcobj = firstWord(%search);
	%srcpos = posFromRaycast(%search);
	InitContainerRadiusSearch(%srcpos,10,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType);
	while ((%TObject = containerSearchNext()) != 0){
	   if(%TObject.team == %obj.team && !(%Tobject.selected == 1)){
		if(%obj.selected $= ""){
		   %obj.selected = %Tobject;
		   %Tobject.selected = 1;
		   bottomPrint(%obj.getcontrollingclient(), "Unit Selected.", 5, 2 );
		   return;
		} else {
		   %obj.selected = %obj.selected SPC %Tobject;
		   %Tobject.selected = 1;
		   bottomPrint(%obj.getcontrollingclient(), "Unit Selected.", 5, 2 );
		   return;
		}
	   }
	}
   }
}

function commsatCycleOrders(%obj){
   %num = %obj.ordernum + 1;
   if($commsatOrder[%num] $= "")
	%num = 1;
   %obj.ordernum = %num;
   bottomPrint(%obj.getcontrollingclient(), "Current orders set to" SPC $commsatOrder[%num], 5, 2 );
}

function commsatIssueOrders(%obj){
   %eye = %obj.getMuzzleVector(0);
   %pos = %obj.getMuzzlePoint(0);
   %search = containerRayCast(%pos,vectorAdd(%pos,vectorScale(%eye,2000)), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::TerrainObjectType, %obj);
   %tpos = posFromRaycast(%search);
   if(%obj.ordernum == 2){
      if(%search){
	   %srcobj = firstWord(%search);
	   %srcpos = posFromRaycast(%search);
	   InitContainerRadiusSearch(%srcpos,10,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType);
	   while ((%TObject = containerSearchNext()) != 0){
	      if(%TObject.team != %obj.team){
		   %target = %Tobject;
		   %valid = 1;
	      }
	   }
      }

      if(%valid != 1){
	   %team = %obj.team;
         %beacon = new BeaconObject(){
            datablock = SubBeacon;
	      beaconType = "enemy";
	      position = %tpos;
         };
         %beacon.team = %team;
         %beacon.owner = %obj;
         %beacon.setTarget(%team);
         MissionCleanup.add(%beacon);
         %beacon.schedule(60000,"delete");
      } else {
	   %target.CommandAttachBeacon();
	   %beacon = %target.enemybeacon;
      }
   }

   %y = 0;
   while(getWord(%obj.selected,%y) !$= ""){
	%trg = getWord(%obj.selected,%y);
	if(isobject(%trg)){
	   %datablock = %trg.getDatablock().getName();
	   if(%datablock $= "S11"){
		%trg.tasks = $S11[$commsatOrder[%obj.ordernum]];
		if(%obj.ordernum == 1)
		   %trg.specvar[MOVE] = %tpos;
		else if(%obj.ordernum == 2){
		   %trg.specvar[MOE] = %beacon;
		   %trg.specvar[FIRE] = %beacon;
		   %trg.specvar[MOVE] = %trg.getPosition();
	 	}
		else if(%obj.ordernum == 3)
		   %trg.specvar[RECON] = %tpos;
		else if(%obj.ordernum == 4){
		   %trg.specvar[MOVE] = $commsatVpad[%obj.team].getPosition();
		   %trg.specvar[MOVE,2] = %trg.getPosition();
	 	}
		S11Think(%trg);
	   }
	   else if(%datablock $= "S17"){
		%trg.task = $commsatOrder[%obj.ordernum];
		if(%obj.ordernum == 1)
		   %trg.specvar[MOVE] = %tpos;
		if(%obj.ordernum == 2)
		   %trg.specvar[ATTACK] = %beacon;
		if(%obj.ordernum == 3)
		   %trg.specvar[GUARD] = %tpos;
		if(%obj.ordernum == 4)
		   %trg.specvar[REARM] = $commsatVpad[%obj.team];
		S17Think(%trg);
	   }
	}
	%y++;
   }
}

function commsatHudUpdate(%obj){
   if(!isObject(%obj))
	return;
   %client = %obj.getControllingClient();
   if(%client){
      %message = "CREDITS:"@$teamcredits[%obj.team];
      %message = %message SPC "SELECTED: Purchase/"@getWords($commsatPurchase[%obj.purchasenum],3,4);
      %message = %message SPC "Order/"@$commsatOrder[%obj.ordernum];
      bottomPrint(%client, %message, 2, 2 );
   }
   schedule(1000, 0, "commsatHudUpdate",%obj);
}

function SimObject::CommandAttachBeacon(%obj){
   if(isObject(%obj.enemyBeacon))
	%obj.enemyBeacon.delete();
   if (%obj.team == 1)
      %team = 2;
   else
      %team = 1;

   %beacon = new BeaconObject(){
      datablock = SubBeacon;
	beaconType = "enemy";
	position = %obj.getWorldBoxCenter();
   };
   %beacon.team = %team;
   %beacon.owner = %obj;
   %beacon.setTarget(%team);
   %obj.mountObject(%beacon, 9);
   %obj.enemyBeacon = %beacon;
   MissionCleanup.add(%beacon);
   %beacon.schedule(60000,"delete");

   %wa=new Waypoint() {
	position = %obj.getWorldBoxCenter();
	rotation = "1 0 0 0";
	dataBlock = "WayPointMarker";
	team = %team;
	name = "Attack this target.";
   };
   MissionCleanup.add(%wa);
   %wa.schedule(5000,"delete");
}

function SpySatelliteDeployable::onPickup(%this, %obj, %shape, %amount){}

function SpySatelliteDeployableImage::testObjectTooClose(%item){
   %xy = getWords(%item.surfacePt, 0, 1);
   %z = getWord(%item.surfacePt, 2);
   %z += 200;
   %item.surfacePt = %xy SPC %z;
   %item.surfaceNrm = "0 0 -1";
   %mask =    ($TypeMasks::VehicleObjectType     | $TypeMasks::MoveableObjectType   |
               $TypeMasks::StaticShapeObjectType |
               $TypeMasks::ForceFieldObjectType  | $TypeMasks::ItemObjectType       |
               $TypeMasks::PlayerObjectType      | $TypeMasks::TurretObjectType);
   InitContainerRadiusSearch( %item.surfacePt, $MinDeployDistance, %mask );
   %test = containerSearchNext();
   return %test;
}

function SpySatelliteDeployableImage::onDeploy(%item, %plyr, %slot){
   %deplObj = Parent::onDeploy(%item, %plyr, %slot);
   %deplObj.setCloaked(true);
   %deplObj.setPassiveJammed(true);
   %deplObj.selectedWeapon = 1;
   %deplobj.mountImage(GST1Param, 0);
   %deplobj.mountImage(SpySatelliteBarrel, 2);
   %deplobj.purchaseNum = 1;
   %deplobj.orderNum = 1;
   $commsat[%deplobj.team] = %deplobj;
   commsatHudUpdate(%deplobj);

   %item.surfacePt = vectorAdd(%item.surfacePt,"0 0 -200");

   %pos = %item.surfacePt;
   %Drone = new HoverVehicle()
   {
      dataBlock    = commsatControlStation;
      position     = %pos;
      rotation     = %plyr.getRotation();
      team         = %plyr.team;
   };
   MissionCleanUp.add(%Drone); 

   setTargetSensorGroup(%Drone.getTarget(), %team);
   $commsatCPad[%deplobj.team] = %Drone;



   %pos = vectorAdd(%item.surfacePt,vectorScale(%plyr.getForwardvector(),1.25));
   %deplObj = new (StaticShape)() {
      dataBlock = DeployedCrate12;
	scale = "0.6 0.3 1";
   };
   %deplObj.setTransform(%pos SPC %plyr.getRotation());
   %deplObj.team = %plyr.client.Team;
   %deplObj.setOwner(%plyr);
   if (%deplObj.getTarget() != -1)
      setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);
   addToDeployGroup(%deplObj);
   addDSurface(%item.surface,%deplObj);

   if($teamcredits[1] $= ""){
      for(%i = 1;%i <= game.numteams; %i++){
	   $teamcredits[%i] = 160;
	   $teamUsedCredits[%i] = 0;
	   $teamRepCredits[%i] = 0;
	}
	commsatcreditloop();
   }
}

function DeployedSpySatellite::onDestroyed(%this, %obj, %prevState){
	if (%obj.isRemoved)
		return;
	if ($Host::InvincibleDeployables != 1 || %obj.damageFailedDecon) {
		%obj.isRemoved = true;
		$TeamDeployedCount[%obj.team, SpySatelliteDeployable]--;
		remDSurface(%obj);
		%obj.schedule(500, delete);
		$commsatCPad[%obj.team].schedule(500, delete);
	}
	Parent::onDestroyed(%this, %obj, %prevState);
}

function commsatControlStation::onAdd(%this, %obj){
   Parent::onAdd(%this, %obj);
   %obj.selectedWeapon = 1;
   %obj.schedule(5000, "playThread", $AmbientThread, "ambient");
}

function commsatControlStation::playerMounted(%data, %obj, %player, %node) { 
   %Player.setTransform("0 0 0 0 0 1 0"); 
   %player.vehicleTurret = %turret;
   
   %Player.CanControl = true; 
   %Player.schedule(650, "CanControl = false"); 

   // If it is not a bot, then set them up controlling the turret 
   %Client = %Player.client; 
   if (%Client.isAIControlled() == false) { 
      %player.setcontrolObject($commsat[%obj.team]);
      %client.setcontrolObject($commsat[%obj.team]);
      %client.setObjectActiveImage($commsat[%obj.team], 0);
	$commsat[%obj.team].selectedWeapon = 1;
	commandToClient(%client,'SetWeaponryVehicleKeys', true);
	commandToClient(%client, 'setHudMode', 'Pilot', "bomber", %node);
	%player.incommsat = 1;
   } 
   %player.isBomber = true;
   %Player.lastWeapon = %Player.getMountedImage($WeaponSlot); 
   %Player.unmountImage($WeaponSlot); 

   if (%Client.HavocClient == true) 
      commandToClient(%obj.client,'SetPassengerVehicleKeys', true); 
} 

function commsatControlStation::playerDismounted(%data, %Seat, %Player) { 
   %Seat.fireWeapon = false; 
   %Seat.setImageTrigger(0, false); 

   %Player.MCSturret = ""; 
   %Player.CanControl = ""; 
   %player.incommsat = 0;
   if (%Player.lastVehicle == %Seat) 
      %Player.lastVehicle = ""; 

   %Seat.lastPilot = ""; 
} 

function commsatControlStation::deleteAllMounted(%data, %obj){
	$commsat[%obj.team].damage(0, $commsat[%obj.team].getPosition(), 1000, $DamageType::Default);
}

function commsatControlStation::playerDismounted(%data, %obj, %player){
   setTargetSensorGroup(%obj.getTarget(), %obj.team);
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, true );
}

function DeployedSpySatelliteMOVE( %this,%data ){
	%this.setImageTrigger(2, true);
	schedule(100, 0, "DeployedSpySatelliteNOMOVE", %this);
}

function DeployedSpySatelliteNOMOVE(%obj){
   %obj.setImageTrigger(2,false);
}

function DronePadDeployable::onPickup(%this, %obj, %shape, %amount){}

function DronePadDeployableImage::onDeploy(%item, %plyr, %slot){
   %pos = %item.surfacePt;
   %deplObj = new (StaticShape)() {
      dataBlock = Dronepad;
	scale = "2.5 2.5 1";
   };
   %deplObj.setTransform(%pos SPC %plyr.getRotation());
   %deplObj.team = %plyr.client.Team;
   %deplObj.setOwner(%plyr);
   if (%deplObj.getTarget() != -1)
      setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);
   addToDeployGroup(%deplObj);
   addDSurface(%item.surface,%deplObj);
   $commsatVPad[%deplobj.team] = %deplobj;
}

function DronePadDeployableImage::testNoTerrainFound(%item){}

function DronePadDeployableImage::onMount(%data, %obj, %node) {}

function DronePad::onDestroyed(%this, %obj, %prevState){
	if (%obj.isRemoved)
		return;
	if ($Host::InvincibleDeployables != 1 || %obj.damageFailedDecon) {
		remDSurface(%obj);
		$TeamDeployedCount[%obj.team, DronePadDeployable]--;
		%obj.schedule(500, delete);
	}
	Parent::onDestroyed(%this, %obj, %prevState);
}

function commsatcreditloop(){
   %count = ClientGroup.getCount();
   %amount = %count * 30 + 50;
   if(%amount < 160)
	%amount = 160;
   for(%i = 1;%i <= game.numteams; %i++){
	%currentmax = $teamRepCredits[%i] + $teamcredits[%i] + $teamUsedCredits[%i];
	if(%currentmax > %amount){
	   %dif = %amount - %currentmax;
	   if(%dif <= $teamRepCredits[%i])
		$teamRepCredits[%i] -= %dif;
	   else{
		$teamcredits[%i] -= (%dif - $teamRepCredits[%i]);
		$teamRepCredits[%i] = 0;
	   }
	}
	else if(%currentmax < %amount)
	   $teamRepCredits[%i] += %amount - %currentmax;
	if($teamRepCredits[%i] > 0){
	   %RepAmt = (5 + %count); 
	   if(%RepAmt > $teamRepCredits[%i])
		%RepAmt = $teamRepCredits[%i];
	   $teamcredits[%i] += %RepAmt;
	   $teamRepCredits -= %RepAmt;
	}
   }
   schedule(20000, 0, "commsatcreditloop");
}