// deployable objects script
//
// remote pulse sensor, remote motion sensor, remote turrets (indoor
// and outdoor), remote inventory station, remote ammo station
// Note: cameras are treated as grenades, not "regular" deployables

$Host::CRCTextures = 0;
$TurretIndoorSpaceRadius  = 1;  // deployed turrets must be this many meters apart
$InventorySpaceRadius  = 1;  // deployed inventory must be this many meters apart
$TurretIndoorSphereRadius = 1;  // radius for turret frequency check
$TurretIndoorMaxPerSphere = 1;   // # of turrets allowed in above radius

$TurretOutdoorSpaceRadius  = 25;  // deployed turrets must be this many meters apart
$TurretOutdoorSphereRadius = 60;  // radius for turret frequency check
$TurretOutdoorMaxPerSphere = 4;   // # of turrets allowed in above radius

$TeamDeployableMax[InventoryDeployable]      = 10;
$TeamDeployableMax[TurretIndoorDeployable]   = 10;
$TeamDeployableMax[TurretOutdoorDeployable]  = 10;
$TeamDeployableMax[PulseSensorDeployable]    = 25;
$TeamDeployableMax[MotionSensorDeployable]   = 25;

$TeamDeployableMax[LargeInventoryDeployable] = 1000;
$TeamDeployableMax[GeneratorDeployable] = 500;
$TeamDeployableMax[SolarPanelDeployable] = 1500;
$TeamDeployableMax[SwitchDeployable] = 1000;
$TeamDeployableMax[MediumSensorDeployable] = 1000;
$TeamDeployableMax[LargeSensorDeployable] = 1000;
$TeamDeployableMax[WallDeployable] = 1000;
$TeamDeployableMax[FloorDeployable] = 1000;
$TeamDeployableMax[wWallDeployable] = 1000;
$TeamDeployableMax[SpineDeployable] = 5000;
$TeamDeployableMax[mSpineDeployable] = 1000;
$TeamDeployableMax[JumpadDeployable] = 5000;
$TeamDeployableMax[EnergizerDeployable] = 1000;
$TeamDeployableMax[TreeDeployable] = 5000;
$TeamDeployableMax[CrateDeployable] = 2500;
$TeamDeployableMax[DecorationDeployable] = 10000;
$TeamDeployableMax[LogoProjectorDeployable] = 1000;
$TeamDeployableMax[LightDeployable] = 5000;
$TeamDeployableMax[TripwireDeployable] = 5000;
$TeamDeployableMax[ForceFieldDeployable] = 1000;
$TeamDeployableMax[GravityFieldDeployable] = 50;
$TeamDeployableMax[TelePadPack] = 5000;
$TeamDeployableMax[SpySatelliteDeployable] = 1;
$TeamDeployableMax[DoorDeployable] = 1000;
$TeamDeployableMax[ZSpawnDeployable] = 1000;
$TeamDeployableMax[SentinelDeployable] = 1000;
$TeamDeployableMax[SpawnPointPack] = 10;
$TeamDeployableMax[RepairPadDeployable] = 10;
$TeamDeployableMax[DronePadDeployable] = 1;
$TeamDeployableMax[waypointDeployable]      = 50;
$TeamDeployableMax[MineDeployed]      = 100;

$TeamDeployableMax[TurretBasePack] = 25;
$TeamDeployableMax[TurretSentryPack] = 45;
$TeamDeployableMax[TurretLaserDeployable] = 1000;
$TeamDeployableMax[DiscTurretDeployable] = 3;
$TeamDeployableMax[TurretMissileRackDeployable] = 2;

//This could also be in "pack".cs but what the heck
//[most]
$TeamDeployableMax[TurretMpm_Anti_Deployable] = 400;
$TeamDeployableMax[VehiclePadPack] = 4000;
$TeamDeployableMax[EmitterDepPack] = 5000;
$TeamDeployableMax[AudioDepPack] = 5000;
$TeamDeployableMax[DispenserDepPack] = 5000;
$TeamDeployableMax[MPM_BeaconPack] = 5000;
$TeamDeployableMax[DetonationDepPack] = 500;
//noone cares
$TeamDeployableMax[MpmFuelPack] = 1;
$TeamDeployableMax[MpmAmmoPack] = 1;

//[most]

$TeamDeployableMin[TurretIndoorDeployable] = 10;
$TeamDeployableMin[TurretOutdoorDeployable] = 10;
$TeamDeployableMin[TurretBasePack] = 20;
$TeamDeployableMin[TurretLaserDeployable] = 500;
$TeamDeployableMin[DiscTurretDeployable] = 3;
$TeamDeployableMin[TurretMissileRackDeployable] = 2;

//[most]
$TeamDeployableMin[TurretMpm_Anti_Deployable] = 40;
$TeamDeployableMin[VehiclePadPack] = 40;
$TeamDeployableMin[EmitterDepPack] = 50;
$TeamDeployableMin[AudioDepPack] = 50;
$TeamDeployableMin[DispenserDepPack] = 50;
$TeamDeployableMin[MPM_BeaconPack] = 50;
$TeamDeployableMin[DetonationDepPack] = 5;
//noone cares
$TeamDeployableMin[MpmFuelPack] = 1;
$TeamDeployableMin[MpmAmmoPack] = 1;

//[most]

$NotDeployableReason::None                      =  0;
$NotDeployableReason::MaxDeployed               =  1;
$NotDeployableReason::NoSurfaceFound            =  2;
$NotDeployableReason::SlopeTooGreat             =  3;
$NotDeployableReason::SelfTooClose              =  4;
$NotDeployableReason::ObjectTooClose            =  5;
$NotDeployableReason::NoTerrainFound            =  6;
$NotDeployableReason::NoInteriorFound           =  7;
$NotDeployableReason::TurretTooClose            =  8;
$NotDeployableReason::TurretSaturation          =  9;
$NotDeployableReason::SurfaceTooNarrow          =  10;
$NotDeployableReason::InventoryTooClose         =  11;
$NotDeployableReason::PriveledgesRevoked        =  12;

$MinDeployableDistance                       =  2.5;
$MaxDeployableDistance                       =  5.0;  //meters from body

// --------------------------------------------
// effect datablocks
// --------------------------------------------

datablock EffectProfile(TurretDeployEffect)
{
   effectname = "packs/generic_deploy";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(SensorDeployEffect)
{
   effectname = "powered/sensor_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(MotionSensorDeployEffect)
{
   effectname = "powered/motion_sensor_activate";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock EffectProfile(StationDeployEffect)
{
   effectname = "packs/inventory_deploy";
   minDistance = 2.5;
   maxDistance = 5.0;
};

// --------------------------------------------
// sound datablocks
// --------------------------------------------

datablock AudioProfile(TurretDeploySound)
{
   fileName = "fx/packs/turret_place.wav";
   description = AudioClose3d;
   preload = true;
   effect = TurretDeployEffect;
};

datablock AudioProfile(DSound)
{
   filename    = "fx/weapons/plasma_rifle_activate.wav";
   //filename    = "fx/packs/repair_use.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SensorDeploySound)
{
   fileName = "fx/powered/sensor_activate.wav";
   description = AudioClose3d;
   preload = true;
   effect = SensorDeployEffect;
   // z0dd - ZOD - Durt, 6/24/02. Eh? This shouldn't be in here.
   //effect = MotionSensorDeployEffect;
};

datablock AudioProfile(MotionSensorDeploySound)
{
   fileName = "fx/powered/motion_sensor_activate.wav";
   description = AudioClose3d;
   preload = true;
   // z0dd - ZOD - Durt, 6/24/02. This should be in here.
   effect = MotionSensorDeployEffect;
};

datablock AudioProfile(StationDeploySound)
{
   fileName = "fx/packs/inventory_deploy.wav";
   description = AudioClose3d;
   preload = true;
   effect = StationDeployEffect;
};

// --------------------------------------------
// deployable debris definition

datablock DebrisData( DeployableDebris )
{
   explodeOnMaxBounce = true;

   elasticity = 0.40;
   friction = 0.5;

   lifetime = 200.0;
   lifetimeVariance = 5.0;

   minSpinSpeed = 60;
   maxSpinSpeed = 600;

   numBounces = 10;
   bounceVariance = 1;

   staticOnMaxBounce = true;

   useRadiusMass = true;
   baseRadius = 20;

   velocity = 5.0;
   velocityVariance = 2.5;

};


// --------------------------------------------
// deployable inventory station

datablock StaticShapeData(DeployedStationInventory) : StaticShapeDamageProfile
{
   className = Station;
   shapeFile = "deploy_inventory.dts";
   maxDamage = 0.70;
   destroyedLevel = 0.70;
   disabledLevel = 0.42;
   explosion      = DeployablesExplosion;
      expDmgRadius = 8.0;
      expDamage = 0.35;
      expImpulse = 500.0;

   dynamicType = $TypeMasks::StationObjectType;
   isShielded = true;
   energyPerDamagePoint = 110;
   maxEnergy = 50;
   rechargeRate = 0.20;
   renderWhenDestroyed = false;
   doesRepair = true;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";
   targetNameTag = 'Antidote';
   targetTypeTag = 'Station';

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
};

datablock ShapeBaseImageData(InventoryDeployableImage)
{
   mass = 15;
   emap = true;

   shapeFile = "pack_deploy_inventory.dts";
   item = InventoryDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = DeployedStationInventory;
   heatSignature = 0;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   maxDepSlope = 30;
   deploySound = StationDeploySound;

   flatMinDeployDis   = 1.0;
   flatMaxDeployDis   = 5.0;

   minDeployDis       = 2.5;
   maxDeployDis       = 5.0;
};

datablock ItemData(InventoryDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_inventory.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "InventoryDeployableImage";
   pickUpName = "an Antidote Station";
   heatSignature = 0;

   computeCRC = true;
   emap = true;

};

// --------------------------------------------
// deployable motion sensor

datablock SensorData(DeployMotionSensorObj)
{
   detects = true;
   detectsUsingLOS = true;
   detectsActiveJammed = false;
   detectsPassiveJammed = true;
   detectsCloaked = true;
   detectionPings = false;
   detectMinVelocity = 2;
   detectRadius = 60;
};

datablock StaticShapeData(DeployedMotionSensor) : StaticShapeDamageProfile
{
   className = Sensor;
   shapeFile = "deploy_sensor_motion.dts";
   maxDamage = 0.6;
   destroyedLevel = 0.6;
   disabledLevel = 0.4;
   explosion = DeployablesExplosion;
   dynamicType = $TypeMasks::SensorObjectType;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDSensorIcon;
   cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
   targetNameTag = 'Motion Sensor';
   targetTypeTag = '';
   sensorData = DeployMotionSensorObj;
   sensorRadius = DeployMotionSensorObj.detectRadius;
   sensorColor = "9 136 255";
   deployAmbientThread = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
};

datablock ShapeBaseImageData(MotionSensorDeployableImage)
{
   shapeFile = "pack_deploy_sensor_motion.dts";
   item = MotionSensorDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = DeployedMotionSensor;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   maxDepSlope = 360;
   deploySound = MotionSensorDeploySound;
   emap = true;
   heatSignature = 1;

   minDeployDis                       =  0.5;
   maxDeployDis                       =  5.0;  //meters from body
};

datablock ItemData(MotionSensorDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_sensor_motion.dts";
   mass = 2.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "MotionSensorDeployableImage";
   pickUpName = "a motion sensor pack";

   computeCRC = true;
   emap = true;
   heatSignature = 0;

   //maxSensors = 3;
   maxSensors = 2;
};

// --------------------------------------------
// deployable pulse sensor

datablock SensorData(DeployPulseSensorObj)
{
   detects = true;
   detectsUsingLOS = true;
   detectsPassiveJammed = false;
   detectsCloaked = false;
   detectionPings = true;
   detectRadius = 150;
};

datablock StaticShapeData(DeployedPulseSensor) : StaticShapeDamageProfile
{
   className = Sensor;
   shapeFile = "deploy_sensor_pulse.dts";
   maxDamage = 0.6;
   destroyedLevel = 0.6;
   disabledLevel = 0.4;
   explosion = DeployablesExplosion;
   dynamicType = $TypeMasks::SensorObjectType;

   deployedObject = true;

   cmdCategory = "DSupport";
   cmdIcon = CMDSensorIcon;
   cmdMiniIconName = "commander/MiniIcons/com_deploypulsesensor";
   targetNameTag = 'Deployable';
   targetTypeTag = 'Pulse Sensor';
   sensorData = DeployPulseSensorObj;
   sensorRadius = DeployPulseSensorObj.detectRadius;
   sensorColor = "255 194 9";
   deployAmbientThread = true;

   debrisShapeName = "debris_generic_small.dts";
   debris = DeployableDebris;
   heatSignature = 0;
};

datablock ShapeBaseImageData(PulseSensorDeployableImage)
{
   shapeFile = "pack_deploy_sensor_pulse.dts";
   item = PulseSensorDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = DeployedPulseSensor;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";
   deploySound = SensorDeploySound;

   maxDepSlope = 40;
   emap = true;
   heatSignature = 0;

   minDeployDis                       =  0.5;
   maxDeployDis                       =  5.0;  //meters from body
};

datablock ItemData(PulseSensorDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_sensor_pulse.dts";
   mass = 2.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "PulseSensorDeployableImage";
   pickUpName = "a pulse sensor pack";

   computeCRC = true;
   emap = true;

   maxSensors = 2;
};

// --------------------------------------------
// deployable outdoor turret

datablock ShapeBaseImageData(TurretOutdoorDeployableImage)
{
   mass = 15;

   shapeFile = "pack_deploy_turreto.dts";
   item = TurretOutdoorDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = TurretDeployedOutdoor;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   maxDamage = 4.5;
   destroyedLevel = 4.5;
   disabledLevel = 4.0;

   isLarge = true;
   emap = true;

   maxDepSlope = 40;
   deploySound = TurretDeploySound;

   minDeployDis                       =  0.5;
   maxDeployDis                       =  5.0;  //meters from body
};

datablock ItemData(TurretOutdoorDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_turreto.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "TurretOutdoorDeployableImage";
   pickUpName = "a landspike turret pack";

   computeCRC = true;
   emap = true;

};

// --------------------------------------------
// deployable indoor turret (3 varieties -- floor, wall and ceiling)

datablock ShapeBaseImageData(TurretIndoorDeployableImage)
{
   mass = 15;

   shapeFile = "pack_deploy_turreti.dts";
   item = TurretIndoorDeployable;
   mountPoint = 1;
   offset = "0 0 0";

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   emap = true;

   maxDepSlope = 360;
   deploySound = TurretDeploySound;

   minDeployDis                       =  0.5;
   maxDeployDis                       =  5.0;  //meters from body
};

datablock ItemData(TurretIndoorDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "pack_deploy_turreti.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "TurretIndoorDeployableImage";
   pickUpName = "a spider clamp turret pack";

   computeCRC = true;
   emap = true;

};

// --------------------------------------------
// miscellaneous yet handy functions

function posFromTransform(%transform)
{
   // the first three words of an object's transform are the object's position
   %position = getWord(%transform, 0) @ " " @ getWord(%transform, 1) @ " " @ getWord(%transform, 2);
   return %position;
}

function rotFromTransform(%transform)
{
   // the last four words of an object's transform are the object's rotation
   %rotation = getWord(%transform, 3) @ " " @ getWord(%transform, 4) @ " " @ getWord(%transform, 5) @ " " @ getWord(%transform, 6);
   return %rotation;
}

function posFromRaycast(%transform)
{
   // the 2nd, 3rd, and 4th words returned from a successful raycast call are the position of the point
   %position = getWord(%transform, 1) @ " " @ getWord(%transform, 2) @ " " @ getWord(%transform, 3);
   return %position;
}

function normalFromRaycast(%transform)
{
   // the 5th, 6th and 7th words returned from a successful raycast call are the normal of the surface
   %norm = getWord(%transform, 4) @ " " @ getWord(%transform, 5) @ " " @ getWord(%transform, 6);
   return %norm;
}

function addToDeployGroup(%object)
{
   // all deployables should go into a special group for AI purposes
   %depGroup = nameToID("MissionCleanup/Deployables");
   if (%depGroup <= 0) {
      %depGroup = new SimGroup("Deployables");
      MissionCleanup.add(%depGroup);
   }
   %depGroup.add(%object);
}



function Deployables::searchView(%obj, %searchRange, %mask)
{
   // get the eye vector and eye transform of the player
   %eyeVec   = %obj.getEyeVector();
   %eyeTrans = %obj.getEyeTransform();

   // extract the position of the player's camera from the eye transform (first 3 words)
   %eyePos = posFromTransform(%eyeTrans);

   // normalize the eye vector
   %nEyeVec = VectorNormalize(%eyeVec);

   // scale (lengthen) the normalized eye vector according to the search range
   %scEyeVec = VectorScale(%nEyeVec, %searchRange);

   // add the scaled & normalized eye vector to the position of the camera
   %eyeEnd = VectorAdd(%eyePos, %scEyeVec);

//   %pack = %obj.getMountedImage($BackpackSlot);

//if (%pack.deployed.ClassName $= "mspine")
//   {
//      %mask2 = $TypeMasks::StaticObjectType;
//      %searchResult = containerRayCast(%eyePos, %eyeEnd, %mask2, 0);
//      if ((%searchResult) && (%searchResult.getType() & $TypeMasks::StaticObjectType))
//      {
//         if (%searchResult.getDataBlock().className $= "mspine")
//           return %searchResult;
//         else if (%searchResult.getDataBlock().className $= "spine")
//           return %searchResult;
//         else if (%searchResult.getDataBlock().className $= "Wall")
//           return %searchResult;
//         else if (%searchResult.getDataBlock().className $= "wWall")
//           return %searchResult;
//         else if (%searchResult.getDataBlock().className $= "item")
//           return %searchResult;
//	 else if (%searchResult.getDataBlock().className $= "floor")
//           return %searchResult;
//         %searchResult = "";
//      }
//    }

   // see if anything gets hit
	%searchResult = containerRayCast(%eyePos, %eyeEnd, %mask, 0);
	if (%searchResult)
		%pos2 = getWords(%searchResult, 1, 3);
	else
		%pos2 = %eyeEnd;
	%searchResult2 = containerRayCast(%eyePos, %pos2, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType, 0);
	if (%searchResult2) {
		if (%searchResult2.getDataBlock().className $= "wWall")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "Wall")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "spine")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "mspine")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "item")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "floor")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "tree")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "crate")
			return %searchResult2;
		else if (%searchResult2.getDataBlock().className $= "decoration") {
			if (%searchResult2.getDataBlock().getName() $= "DeployedDecoration6")
				return %searchResult2;
			else
				return; // Don't deploy on or through other decorations, since there are problems with surface normals
		}
		else if (%searchResult2.getType() & $TypeMasks::ForceFieldObjectType)
			return; // Don't deploy inside or through forcefields
	}
	return %searchResult;
}

//-----------------------//
// Deployable Procedures //
//-----------------------//

//-------------------------------------------------
function ShapeBaseImageData::testMaxDeployed(%item, %plyr) {
	if (%item.item $= TurretOutdoorDeployable
		 || %item.item $= TurretIndoorDeployable
		 || %item.item $= TurretBasePack
		 || %item.item $= TurretLaserDeployable
		 || %item.item $= TurretMissileRackDeployable
		 || %item.item $= TurretMpm_Anti_Deployable
		 || %item.item $= DiscTurretDeployable)
		%itemCount = countTurretsAllowed(%item.item);
	else
		%itemCount = $TeamDeployableMax[%item.item];

	return $TeamDeployedCount[%plyr.team, %item.item] >= %itemCount;
}

//-------------------------------------------------
function ShapeBaseImageData::testNoSurfaceInRange(%item, %plyr)
{
   return ! Deployables::searchView(%plyr, $MaxDeployDistance, $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType);
}

//-------------------------------------------------
function ShapeBaseImageData::testSlopeTooGreat(%item)
{
   if (%item.surface)
   {
      return getTerrainAngle(%item.surfaceNrm) > %item.maxDepSlope;
   }
}

//-------------------------------------------------
function ShapeBaseImageData::testSelfTooClose(%item, %plyr)
{
   InitContainerRadiusSearch(%item.surfacePt, $MinDeployDistance, $TypeMasks::PlayerObjectType);

   return containerSearchNext() == %plyr;
}

//-------------------------------------------------
function ShapeBaseImageData::testObjectTooClose(%item) {
	%mask =	($TypeMasks::VehicleObjectType		| $TypeMasks::MoveableObjectType	|
		$TypeMasks::StaticShapeObjectType	|
		$TypeMasks::ForceFieldObjectType	| $TypeMasks::ItemObjectType		|
		$TypeMasks::PlayerObjectType		| $TypeMasks::TurretObjectType);

	InitContainerRadiusSearch(%item.surfacePt,$MinDeployDistance,%mask);

	// TODO - update this
	while ((%test = containerSearchNext()) != 0) {
		%className = %test.getDataBlock().className;
		if (vectorDist(%item.surfacePt,%test.getPosition()) < $MinDeployDistance
		&& %className !$= "Wall" && %className !$= "wWall" && %className !$= "spine" && %className !$= "mspine"
		&& %className !$= "floor" && %className !$= "tree" && %className !$= "crate" && %className !$= "decoration"
		&& %className !$= "light" && %className !$= "decontarget" && %className !$= "item"
		&& %className !$= "pack" )
			return %test;
	}
	return 0;
}

//-------------------------------------------------
function TurretOutdoorDeployableImage::testNoTerrainFound(%item)
{
   return %item.surface.getClassName() !$= TerrainBlock;
}

function ShapeBaseImageData::testNoTerrainFound(%item, %surface)
{
   //don't check this for non-Landspike turret deployables
}

//-------------------------------------------------
function TurretIndoorDeployableImage::testNoInteriorFound(%item) {
	if (%item.surface.getType() & $TypeMasks::StaticShapeObjectType) {
		%className = %item.surface.getDataBlock().className;
		if (%className $= "Wall")
			return 0;
		else if (%className $= "wWall")
			return 0;
		else if (%className $= "spine")
			return 0;
		else if (%className $= "mspine")
			return 0;
		else if (%className $= "item")
			return 0;
		else if (%className $= "floor")
			return 0;
		else if (%className $= "tree")
			return 0;
		else if (%className $= "crate")
			return 0;
		else if (%className $= "decoration")
			return 0;
	}
	return %item.surface.getClassName() !$= InteriorInstance;
}

function ShapeBaseImageData::testNoInteriorFound(%item, %surface)
{
   //don't check this for non-Clasping turret deployables
}

//-------------------------------------------------
function TurretIndoorDeployableImage::testHavePurchase(%item, %xform)
{
   %footprintRadius = 0.34;
   %collMask = $TypeMasks::InteriorObjectType;
   return %item.deployed.checkDeployPurchase(%xform, %footprintRadius, %collMask);
}

function ShapeBaseImageData::testHavePurchase(%item, %xform)
{
   //don't check this for non-Clasping turret deployables
   return true;
}

//-------------------------------------------------
function ShapeBaseImageData::testInventoryTooClose(%item, %plyr)
{
   return false;
}

function InventoryDeployableImage::testInventoryTooClose(%item, %plyr)
{
   InitContainerRadiusSearch(%item.surfacePt, $InventorySpaceRadius, $TypeMasks::StaticShapeObjectType);

   // old function was only checking whether the first object found was a turret -- also wasn't checking
   // which team the object was on
   %turretInRange = false;
   while((%found = containerSearchNext()) != 0)
   {
      %foundName = %found.getDataBlock().getName();
      if ( (%foundName $= DeployedStationInventory) )
         if (%found.team == %plyr.team)
         {
            %turretInRange = true;
            break;
         }
   }
   return %turretInRange;
}


// TODO - keep this up to date
function isDeployedTurret(%obj) {
	%dataBlockName = %obj.getDataBlock().getName();
	if ((%dataBlockName $= TurretDeployedFloorIndoor)
	|| (%dataBlockName $= TurretDeployedWallIndoor)
	|| (%dataBlockName $= TurretDeployedCeilingIndoor)
	|| (%dataBlockName $= TurretDeployedOutdoor)
	|| (%dataBlockName $= TurretDeployedBase)
	|| (%dataBlockName $= LaserDeployed)
	|| (%dataBlockName $= MissileRackTurretDeployed)
	|| (%dataBlockName $= Mpm_anti_TurretDeployed)
	|| (%dataBlockName $= DiscTurretDeployed))
		return 1;
	return 0;
}

// TODO - keep this up to date
function isDeployableTurret(%item) {
	if ((%item $= TurretIndoorDeployable)
	|| (%item $= TurretOutdoorDeployable)
	|| (%item $= TurretBasePack)
	|| (%item $= TurretLaserDeployable)
	|| (%item $= TurretMissileRackDeployable)
	|| (%item $= TurretMpm_anti_Deployable)
	|| (%item $= DiscTurretDeployable))
		return 1;
	return 0;
}

function TurretIndoorDeployableImage::testTurretTooClose(%item, %plyr) {
	InitContainerRadiusSearch(%item.surfacePt, $TurretIndoorSpaceRadius, $TypeMasks::StaticShapeObjectType);
	// old function was only checking whether the first object found was a turret -- also wasn't checking
	// which team the object was on
	%turretInRange = false;
	while((%found = containerSearchNext()) != 0) {
		if (isDeployedTurret(%found)) {
			if (%found.team == %plyr.team) {
				%turretInRange = true;
				break;
			}
		}
	}
	return %turretInRange;
}

function TurretOutdoorDeployableImage::testTurretTooClose(%item, %plyr) {
	InitContainerRadiusSearch(%item.surfacePt, $TurretOutdoorSpaceRadius, $TypeMasks::StaticShapeObjectType);
	// old function was only checking whether the first object found was a turret -- also wasn't checking
	// which team the object was on
	%turretInRange = false;
	while((%found = containerSearchNext()) != 0) {
		if (isDeployedTurret(%found)) {
			if (%found.team == %plyr.team) {
				%turretInRange = true;
				break;
			}
		}
	}
	return %turretInRange;
}

function TurretDeployableImage::testTurretTooClose(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretTooClose(%item, %plyr);
}

function TurretLaserDeployableImage::testTurretTooClose(%item, %plyr) {
	return TurretIndoorDeployableImage::testTurretTooClose(%item, %plyr);
}

function TurretMissileRackDeployableImage::testTurretTooClose(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretTooClose(%item, %plyr);
}


function TurretMpm_Anti_DeployableImage::testTurretTooClose(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretTooClose(%item, %plyr);
}


function DiscTurretDeployableImage::testTurretTooClose(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretTooClose(%item, %plyr);
}

function ShapeBaseImageData::testTurretTooClose(%item, %plyr)
{
   //don't check this for non-turret deployables
}

//[most]
function ShapeBaseImageData::testSurfaceTooNarrow(%item,%surface)
{
   //don't check this for non-v-pad deployables
}
//[most]

// TODO - keep this up to date

//-------------------------------------------------
function TurretIndoorDeployableImage::testTurretSaturation(%item) {
	%highestDensity = 0;
	InitContainerRadiusSearch(%item.surfacePt, $TurretIndoorSphereRadius, $TypeMasks::StaticShapeObjectType);
	%found = containerSearchNext();
	while(%found) {
		if (isDeployedTurret(%found)) {
			//found one
			%numTurretsNearby++;
			%nearbyDensity = testNearbyDensity(%found, $TurretIndoorSphereRadius);
			if (%nearbyDensity > %highestDensity)
				%highestDensity = %nearbyDensity;
		}
		%found = containerSearchNext();
	}
	if (%numTurretsNearby > %highestDensity)
		%highestDensity = %numTurretsNearby;
	return %highestDensity > $TurretIndoorMaxPerSphere;
}

function TurretOutdoorDeployableImage::testTurretSaturation(%item) {
	%highestDensity = 0;
	InitContainerRadiusSearch(%item.surfacePt, $TurretOutdoorSphereRadius, $TypeMasks::StaticShapeObjectType);
	%found = containerSearchNext();
	while(%found) {
		if (isDeployedTurret(%found)) {
			//found one
			%numTurretsNearby++;
			%nearbyDensity = testNearbyDensity(%found, $TurretOutdoorSphereRadius);
			if (%nearbyDensity > %highestDensity)
				%highestDensity = %nearbyDensity;
		}
		%found = containerSearchNext();
	}
	if (%numTurretsNearby > %highestDensity)
		%highestDensity = %numTurretsNearby;
	return %highestDensity > $TurretOutdoorMaxPerSphere;
}

function TurretDeployableImage::testTurretSaturation(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretSaturation(%item, %plyr);
}

function TurretLaserDeployableImage::testTurretSaturation(%item, %plyr) {
	return TurretIndoorDeployableImage::testTurretSaturation(%item, %plyr);
}

function TurretMissileRackDeployableImage::testTurretSaturation(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretSaturation(%item, %plyr);
}


function TurretMpm_Anti_DeployableImage::testTurretSaturation(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretSaturation(%item, %plyr);
}

function DiscTurretDeployableImage::testTurretSaturation(%item, %plyr) {
	return TurretOutdoorDeployableImage::testTurretSaturation(%item, %plyr);
}

function ShapeBaseImageData::testTurretSaturation(%item, %surfacePt)
{
   //don't check this for non-turret deployables
}

function testNearbyDensity(%item, %radius) {
	//this checks how many turrets are in adjacent spheres in case placing a new one overloads them.
	%surfacePt = posFromTransform(%item.getTransform());
	%turretCount = 0;
	InitContainerRadiusSearch(%surfacePt, %radius, $TypeMasks::StaticShapeObjectType);
	%found = containerSearchNext();
	while(%found) {
		if (isDeployedTurret(%found))
		%turretCount++;
		%found = containerSearchNext();
	}
	return %turretCount;
}

//-------------------------------------------------
//if this function, or any of the included tests are changed, those changes need to be reflected in function:
//AIODeployEquipment::weight(%this, %client, %level), found in aiObjectives.cs  --tinman

function ShapeBaseImageData::testInvalidDeployConditions(%item, %plyr, %slot) {
	cancel(%plyr.deployCheckThread);
	%disqualified = $NotDeployableReason::None;  //default
	$MaxDeployDistance = %item.maxDeployDis;
	$MinDeployDistance = %item.minDeployDis;

	%pack = %plyr.getMountedImage($BackpackSlot);

	if (%pack.deployed.className $= "decoration") {
		if (%plyr.packSet == 6)
			   $MinDeployDistance = 2;
		if (%plyr.packSet == 10)
			   $MinDeployDistance = 5;
		if (%plyr.packSet == 11)
			   $MinDeployDistance = 4;
	}

	%surface = Deployables::searchView(%plyr,
					$MaxDeployDistance,
					($TypeMasks::TerrainObjectType |
					$TypeMasks::InteriorObjectType |
					$TypeMasks::StaticShapeObjectType));
	if (%surface) {
		%surfacePt  = posFromRaycast(%surface);
		%surfaceNrm = normalFromRaycast(%surface);

		// Check that point to see if anything is obstructing it...
		%eyeTrans = %plyr.getEyeTransform();
		%eyePos   = posFromTransform(%eyeTrans);

		%searchResult = containerRayCast(%eyePos, %surfacePt, -1, %plyr);
		if (!%searchResult) {
			%item.surface = %surface;
			%item.surfacePt = %surfacePt;
			%item.surfaceNrm = %surfaceNrm;
		}
		else {
			if (checkPositions(%surfacePT, posFromRaycast(%searchResult))) {
				%item.surface = %surface;
				%item.surfacePt = %surfacePt;
				%item.surfaceNrm = %surfaceNrm;
			}
			else {
				// Deploy through water
				if (%searchResult.getType() & $TypeMasks::WaterObjectType) {
					%item.surface = %surface;
					%item.surfacePt = %surfacePt;
					%item.surfaceNrm = %surfaceNrm;
				}
				// Redundant - already checking StaticShape above now (v0.62a)
//				// Deploy on StaticShapes
//				else if (%searchResult.getType() & $TypeMasks::StaticShapeObjectType) {
//					%item.surface = %surface;
//					%item.surfacePt = %surfacePt;
//					%item.surfaceNrm = %surfaceNrm;
//				}
				// Don't set the item
// TODO - make a proper $NotDeployableReason for this
				else
					%disqualified = $NotDeployableReason::MaxDeployed;
			}
		}
		if (!getTerrainAngle(%surfaceNrm) && %item.flatMaxDeployDis !$= "") {
			$MaxDeployDistance = %item.flatMaxDeployDis;
			$MinDeployDistance = %item.flatMinDeployDis;
		}
	}

	%item.surfaceinher = 0;
	if (%item.surface.needsFit == 1) {
		%item.surfaceinher = 1;
// new code
		%mask = invFace(%item.surfaceNrm);
                %narrower = vectorMultiply(%mask,%item.surface.getRealSize());
		%subject = vectorNormalize(topVec(%narrower));
                %item.surfaceNrm2 = realVec(%item.surface,%subject);
// old code
//		if (vAbs(%item.surfaceNrm) $= "0 0 1")
//			%item.surfaceNrm2 = realVec(%item.surface,"1 0 0");
//		else
//			%item.surfaceNrm2 = realVec(%item.surface,"0 0 1");
		%item.surfaceNrm = VectorNormalize(realVec(%item.surface,%surfaceNrm));
		%item.surfaceNrm2 = VectorNormalize(%item.surfaceNrm2);
		%mCenter = "0 0 -0.5";
		%className = %item.surface.getDataBlock().className;
		if (%className !$= "tree" && %className !$= "crate" && %className !$= "vpad")
			%item.surfacePt = link(%item.surface,%surfaceNrm,%surfacePt,VectorScale(getjoint(%item),0.5),%mCenter);
		if (%className $= "decoration") {
			if (%item.surface.getDataBlock().getName() $= "DeployedDecoration6") {
				%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(realVec(%item.surface,"0 0 1"),3.3));
				%item.surfaceNrm = realVec(%item.surface,"0 0 1");
			}
		}
	}

   if (%item.testMaxDeployed(%plyr))
   {
      %disqualified = $NotDeployableReason::MaxDeployed;
   }
   else if (%item.testNoSurfaceInRange(%plyr))
   {
      %disqualified = $NotDeployableReason::NoSurfaceFound;
   }
   else if (%item.testNoTerrainFound(%surface))
   {
      %disqualified = $NotDeployableReason::NoTerrainFound;
   }
   else if (%item.testNoInteriorFound())
   {
      %disqualified = $NotDeployableReason::NoInteriorFound;
   }
   else if (%item.testSurfaceTooNarrow(%surface))
   {
      %disqualified = $NotDeployableReason::SurfaceTooNarrow;
   }
   else if (%item.testSlopeTooGreat(%surface, %surfaceNrm))
   {
      %disqualified = $NotDeployableReason::SlopeTooGreat;
   }
   else if (%item.testSelfTooClose(%plyr, %surfacePt))
   {
      %disqualified = $NotDeployableReason::SelfTooClose;
   }
   else if (%item.testObjectTooClose(%surfacePt,%plyr))
   {
      %disqualified = $NotDeployableReason::ObjectTooClose;
   }
   else if (%item.testTurretTooClose(%plyr) && $Host::Purebuild != 1)
   {
      %disqualified = $NotDeployableReason::TurretTooClose;
   }
   else if (%item.testInventoryTooClose(%plyr))
   {
      %disqualified = $NotDeployableReason::InventoryTooClose;
   }
   else if (%item.testTurretSaturation() && $Host::Purebuild != 1)
   {
      %disqualified = $NotDeployableReason::TurretSaturation;
   }
   else if (%plyr.client.CannotDeploy)
   {
      %disqualified = $NotDeployableReason::PriveledgesRevoked;
   }
   else if (%disqualified == $NotDeployableReason::None)
   {
      // Test that there are no obstructing objects that this object
      //  will intersect with
      //
      %rot = %item.getInitialRotation(%plyr);
      if (%item.deployed.className $= "DeployedTurret")
      {
         %xform = %item.deployed.getDeployTransform(%item.surfacePt, %item.surfaceNrm);
      }
      else
      {
         %xform = %surfacePt SPC %rot;
      }
   }

   if (%plyr.getMountedImage($BackpackSlot) == %item)  //player still have the item?
   {
      if (%disqualified)
         activateDeploySensorRed(%plyr);
      else
         activateDeploySensorGrn(%plyr);

	if (%plyr.client.deployPack == true) {
		%item.attemptDeploy(%plyr, %slot, %disqualified);
	}
      else
      {
         %plyr.deployCheckThread = %item.schedule(25, "testInvalidDeployConditions", %plyr, %slot); //update checks every 50 milliseconds
      }
   }
   else
       deactivateDeploySensor(%plyr);
}

function checkPositions(%pos1, %pos2)
{
   %passed = true;
   if ((mFloor(getWord(%pos1, 0)) - mFloor(getWord(%pos2,0))))
      %passed = false;
   if ((mFloor(getWord(%pos1, 1)) - mFloor(getWord(%pos2,1))))
      %passed = false;
   if ((mFloor(getWord(%pos1, 2)) - mFloor(getWord(%pos2,2))))
      %passed = false;
   return %passed;
}

function ShapeBaseImageData::attemptDeploy(%item, %plyr, %slot, %disqualified)
{
   deactivateDeploySensor(%plyr);
   Deployables::displayErrorMsg(%item, %plyr, %slot, %disqualified);
}

function activateDeploySensorRed(%pl)
{
   if (%pl.deploySensor !$= "red")
   {
      messageClient(%pl.client, 'msgDeploySensorRed', "");
      %pl.deploySensor = "red";
   }
}

function activateDeploySensorGrn(%pl)
{
   if (%pl.deploySensor !$= "green")
   {
      messageClient(%pl.client, 'msgDeploySensorGrn', "");
      %pl.deploySensor = "green";
   }
}

function deactivateDeploySensor(%pl)
{
   if (%pl.deploySensor !$= "")
   {
      messageClient(%pl.client, 'msgDeploySensorOff', "");
      %pl.deploySensor = "";
   }
}

function Deployables::displayErrorMsg(%item, %plyr, %slot, %error)
{
   deactivateDeploySensor(%plyr);

   %errorSnd = '~wfx/misc/misc.error.wav';
   switch (%error)
   {
      case $NotDeployableReason::None:
		if (isObject(%plyr.client)) {
			if (!spamCheck(%plyr.client)) {
				%deplObj = %item.onDeploy(%plyr, %slot);
				%deplObj.depTime = getSimTime();
				// TODO - temporary - remove
				if ($TimedDisCenter !$= "") {
					if (vectorLen(vectorDist($TimedDisCenter,%deplObj.getPosition())) < 150 && %plyr.client != nameToID(LocalClientConnection))
						%deplObj.timedDis = %deplObj.getDataBlock().schedule(1 * 5 * 1000,disassemble,0,%deplObj);
				}
				// ----
				messageClient(%plyr.client, 'MsgTeamDeploySuccess', "");
				return;
			}
			else if ($Host::Prison::DeploySpamRemoveRecentMS !$= "" && $Host::Prison::DeploySpamRemoveRecentMS > 0) {
				%group = nameToID("MissionCleanup/Deployables");
				%count = %group.getCount();
				for(%i=0;%i<%count;%i++) {
					%obj = %group.getObject(%i);
					if (%obj.getOwner() == %plyr.client && getSimTime() - $Host::Prison::DeploySpamRemoveRecentMS < %obj.depTime) {
						%obj.getDataBlock().schedule(50 * %disCount++,disassemble,%plyr,%obj);
					}
				}
			}
		}
		else {
			%item.onDeploy(%plyr, %slot);
			messageClient(%plyr.client, 'MsgTeamDeploySuccess', "");
			return;
		}
      case $NotDeployableReason::NoSurfaceFound:
         %msg = '\c2Item must be placed within reach.%1';

      case $NotDeployableReason::MaxDeployed:
         %msg = '\c2Your team\'s control network has reached its capacity for this item.%1';

      case $NotDeployableReason::SlopeTooGreat:
         %msg = '\c2Surface is too steep to place this item on.%1';

      case $NotDeployableReason::SelfTooClose:
         %msg = '\c2You are too close to the surface you are trying to place the item on.%1';

      case $NotDeployableReason::ObjectTooClose:
         %msg = '\c2You cannot place this item so close to another object.%1';

      case $NotDeployableReason::NoTerrainFound:
         %msg = '\c2You must place this on outdoor terrain.%1';

      case $NotDeployableReason::NoInteriorFound:
         %msg = '\c2You must place this on a solid surface.%1';

      case $NotDeployableReason::TurretTooClose:
         %msg = '\c2Interference from a nearby turret prevents placement here.%1';

      case $NotDeployableReason::TurretSaturation:
         %msg = '\c2There are too many turrets nearby.%1';

      case $NotDeployableReason::SurfaceTooNarrow:
         %msg = '\c2There is not adequate surface to clamp to here.%1';

      case $NotDeployableReason::InventoryTooClose:
         %msg = '\c2Interference from a nearby inventory prevents placement here.%1';

      case $NotDeployableReason::PriveledgesRevoked:
         %msg = '\c2An administrator has revoked your ability to deploy anything, therefore, you cannot deploy.%1';
      default:
         %msg = '\c2Deploy failed.';
   }
   messageClient(%plyr.client, 'MsgDeployFailed', %msg, %errorSnd);
}

function ShapeBaseImageData::onActivate(%data, %obj, %slot)
{
   if (%obj.getMountedImage($BackpackSlot).item $= "InventoryDeployable")
   {
      %pos = %obj.getMuzzlePoint($WeaponSlot);
      %vec = %obj.getMuzzleVector($WeaponSlot);
      %targetpos = vectoradd(%pos, vectorscale(%vec, $MaxDeployableDistance));
      %stuff = containerraycast(%pos, %targetpos, $typemasks::staticshapeobjecttype, %sender.player);
      %stuff = getword(%stuff, 0);
      if(isObject(%stuff))
      {
         if(%stuff.getDatablock().getName() $= "DeployedStationInventory")
         {
            if(%stuff.antidotes < $Host::AntidoteStationMaxAntidotes)
            {
               %stuff.antidotes = $Host::AntidoteStationMaxAntidotes;
               messageClient(%obj.client, "", "\c2Antidote station refilled.");
               serverPlay3d(ChaingunDryFire, %stuff.getTransform());
            }
            else
               messageClient(%obj.client, "", "\c2Antidote station is already at max antidotes.~wfx/misc/misc.error.wav");
            return;
         }
      }
   }

   //Tinman - apparently, anything that uses the generic onActivate() method is a deployable.
   //repair packs, cloak packs, shield, etc...  all overload this method...
   %data.testInvalidDeployConditions(%obj, %slot);

   //whether the test passed or not, reset the image trigger (deployables don't have an on/off toggleable state)
   %obj.setImageTrigger(%slot, false);
}




function ShapeBaseImageData::onDeploy(%item, %plyr, %slot)
{
   if (%item.item $= "MotionSensorDeployable" || %item.item $= "PulseSensorDeployable")
   {
      %plyr.deploySensors--;
      %plyr.client.updateSensorPackText(%plyr.deploySensors);
      if (%plyr.deploySensors <= 0)
      {
         // take the deployable off the player's back and out of inventory
         %plyr.unmountImage(%slot);
         %plyr.decInventory(%item.item, 1);
      }
   }
   else
   {
      // take the deployable off the player's back and out of inventory
      %plyr.unmountImage(%slot);
      %plyr.decInventory(%item.item, 1);
   }

   // create the actual deployable !!!!!!!!!!!!!!!!STOP AND LOOK AT ME!!!!!!!!!!!!!!!!! ???????WHY??????
   %rot = %item.getInitialRotation(%plyr);
   if (%item.deployed.className $= "DeployedTurret")
      %className = "Turret";
   else
      %className = "StaticShape";

         %deplObj = new (%className)() {
            dataBlock = %item.deployed;
         };

            if(%item.deployed $= "DeployedStationInventory")
      %deplObj.antidotes = $Host::AntidoteStationMaxAntidotes;



   // set orientation
   if (%className $= "Turret")
      %deplObj.setDeployRotation(%item.surfacePt, %item.surfaceNrm);
    else
      %deplObj.setTransform(VectorAdd(%item.surfacePt, %plac) SPC %rot);


   // set the recharge rate right away
   if (%deplObj.getDatablock().rechargeRate)
      %deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

   // set the sensor group if it needs one
   if (%deplObj.getTarget() != -1)
      setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

   // place the deployable in the MissionCleanup/Deployables group (AI reasons)
   addToDeployGroup(%deplObj);

   //let the AI know as well...
   AIDeployObject(%plyr.client, %deplObj);

   // play the deploy sound
   serverPlay3D(%item.deploySound, %deplObj.getTransform());

   // increment the team count for this deployed object

   $TeamDeployedCount[%plyr.team, %item.item]++;

 if (%classname !$= "Item")
      %deplObj.deploy();

	addDSurface(%item.surface,%deplObj);
   return %deplObj;
}

function ShapeBaseImageData::getInitialRotation(%item, %plyr)
{
   return rotFromTransform(%plyr.getTransform());
}

function MotionSensorDeployableImage::getInitialRotation(%item, %plyr)
{
   %rotAxis = vectorNormalize(vectorCross(%item.surfaceNrm, "0 0 1"));
   if (getWord(%item.surfaceNrm, 2) == 1 || getWord(%item.surfaceNrm, 2) == -1)
      %rotAxis = vectorNormalize(vectorCross(%item.surfaceNrm, "0 1 0"));
   return %rotAxis SPC mACos(vectorDot(%item.surfaceNrm, "0 0 1"));
}

function MotionSensorDeployable::onPickup(%this, %pack, %player, %amount)
{
   // %this = Sensor pack datablock
   // %pack = Sensor pack object number
   // %player = player
   // %amount = amount picked up (1)

   if (%pack.sensors $= "")
   {
      // assume that this is a pack that has been placed in a mission
      // this case was handled in ::onInventory below (max sensors);
   }
   else
   {
      // find out how many sensor were in the pack
      %player.deploySensors = %pack.sensors;
      %player.client.updateSensorPackText(%player.deploySensors);
   }
}

function MotionSensorDeployable::onThrow(%this,%pack,%player)
{
   // %this = Sensor pack datablock
   // %pack = Sensor pack object number
   // %player = player

   %player.throwSensorPack = 1;
   %pack.sensors = %player.deploySensors;
   %player.deploySensors = 0;
   %player.client.updateSensorPackText(%player.deploySensors);
   // do the normal ItemData::onThrow stuff -- sound and schedule deletion
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function MotionSensorDeployable::onInventory(%this,%player,%value)
{
   // %this = Sensor pack datablock
   // %player = player
   // %value = 1 if gaining a pack, 0 if losing a pack

   if (%player.getClassName() $= "Player")
   {
      if (%value)
      {
         // player picked up or bought a motion sensor pack
         %player.deploySensors = %this.maxSensors;
         %player.client.updateSensorPackText(%player.deploySensors);
      }
      else
      {
         // player dropped or sold a motion sensor pack
         if (%player.throwSensorPack)
         {
            // player threw the pack
            %player.throwSensorPack = 0;
            // everything handled in ::onThrow above
         }
         else
         {
            //the pack was sold at an inventory station, or unmounted because the player
            // used all the sensors
            %player.deploySensors = 0;
            %player.client.updateSensorPackText(%player.deploySensors);
         }
      }
   }
   Pack::onInventory(%this,%player,%value);
}

function PulseSensorDeployable::onPickup(%this, %pack, %player, %amount)
{
   // %this = Sensor pack datablock
   // %pack = Sensor pack object number
   // %player = player
   // %amount = amount picked up (1)

   if (%pack.sensors $= "")
   {
      // assume that this is a pack that has been placed in a mission
      // this case was handled in ::onInventory below (max sensors);
   }
   else
   {
      // find out how many sensor were in the pack
      %player.deploySensors = %pack.sensors;
      %player.client.updateSensorPackText(%player.deploySensors);
   }
}

function PulseSensorDeployable::onThrow(%this,%pack,%player)
{
   // %this = Sensor pack datablock
   // %pack = Sensor pack object number
   // %player = player

   %player.throwSensorPack = 1;
   %pack.sensors = %player.deploySensors;
   %player.deploySensors = 0;
   %player.client.updateSensorPackText(%player.deploySensors);
   // do the normal ItemData::onThrow stuff -- sound and schedule deletion
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function PulseSensorDeployable::onInventory(%this,%player,%value)
{
   // %this = Sensor pack datablock
   // %player = player
   // %value = 1 if gaining a pack, 0 if losing a pack

   if (%player.getClassName() $= "Player")
   {
      if (%value)
      {
         // player picked up or bought a motion sensor pack
         %player.deploySensors = %this.maxSensors;
         %player.client.updateSensorPackText(%player.deploySensors);
      }
      else
      {
         // player dropped or sold a motion sensor pack
         if (%player.throwSensorPack)
         {
            // player threw the pack
            %player.throwSensorPack = 0;
            // everything handled in ::onThrow above
         }
         else
         {
            //the pack was sold at an inventory station, or unmounted because the player
            // used all the sensors
            %player.deploySensors = 0;
            %player.client.updateSensorPackText(%player.deploySensors);
         }
      }
   }
   Pack::onInventory(%this,%player,%value);
}

function TurretIndoorDeployableImage::getInitialRotation(%item, %plyr)
{
   %surfaceAngle = getTerrainAngle(%item.surfaceNrm);
   if (%surfaceAngle > 155)
      %item.deployed = TurretDeployedCeilingIndoor;
   else if (%surfaceAngle > 45)
      %item.deployed = TurretDeployedWallIndoor;
   else
      %item.deployed = TurretDeployedFloorIndoor;
}

function TurretIndoorDeployable::onPickup(%this, %obj, %shape, %amount)
{
   // created to prevent console errors
}

function TurretOutdoorDeployable::onPickup(%this, %obj, %shape, %amount)
{
   // created to prevent console errors
}

function InventoryDeployable::onPickup(%this, %obj, %shape, %amount)
{
   // created to prevent console errors
}

// ---------------------------------------------------------------------------------------
// deployed station functions
function DeployedStationInventory::onEndSequence(%data, %obj, %thread)
{
   Parent::onEndSequence(%data, %obj, %thread);
   if (%thread == $DeployThread)
   {
      %trigger = new Trigger()
      {
         dataBlock = stationTrigger;
         polyhedron = "-0.125 0.0 0.1 0.25 0.0 0.0 0.0 -0.7 0.0 0.0 0.0 1.0";
      };
      MissionCleanup.add(%trigger);

      %trans = %obj.getTransform();
      %vSPos = getWords(%trans,0,2);
      %vRot =  getWords(%trans,3,5);
      %vAngle = getWord(%trans,6);
      %matrix = VectorOrthoBasis(%vRot @ " " @ %vAngle + 0.0);
      %yRot = getWords(%matrix, 3, 5);
      %pos = vectorAdd(%vSPos, vectorScale(%yRot, -0.1));

      %trigger.setTransform(%pos @ " " @ %vRot @ " " @ %vAngle);

      // associate the trigger with the station
      %trigger.station = %obj;
      %trigger.mainObj = %obj;
      %trigger.disableObj = %obj;
      %obj.trigger = %trigger;
   }
}

//--------------------------------------------------------------------------
//DeployedMotionSensor:
//--------------------------------------------------------------------------

function DeployedMotionSensor::onDestroyed(%this, %obj, %prevState)
{
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
   //%obj.hide(true);
   Parent::onDestroyed(%this, %obj, %prevState);
   $TeamDeployedCount[%obj.team, MotionSensorDeployable]--;
	remDSurface(%obj);
   %obj.schedule(500, "delete");
}

//--------------------------------------------------------------------------
//DeployedPulseSensor:
//--------------------------------------------------------------------------
function PulseSensorDeployableImage::onActivate(%data, %obj, %slot)
{
   Parent::onActivate( %data, %obj, %slot );
   //%data.testInvalidDeployConditions(%obj, %slot);
}

function DeployedPulseSensor::onDestroyed(%this, %obj, %prevState)
{
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
   Parent::onDestroyed(%this, %obj, %prevState);
   $TeamDeployedCount[%obj.team, PulseSensorDeployable]--;
	remDSurface(%obj);
   %obj.schedule(300, "delete");
}

// ---------------------------------------------------------------------------------------
// deployed turret functions

function DeployedTurret::onAdd(%data, %obj)
{
   Parent::onAdd(%data, %obj);
   // auto-mount the barrel
   %obj.mountImage(%data.barrel, 0, false);
}

function DeployedTurret::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	if ($Host::InvincibleDeployables != 1 || %obj.damageFailedDecon || $DestroyableTurrets == 1) {
		%obj.isRemoved = true;
		%turType = %this.getName();
		// either it'll be an outdoor turret, or one of the three types of indoor turret
		// (floor, ceiling, wall)
		if (%turType $= "TurretDeployedOutdoor")
			%turType = "TurretOutdoorDeployable";
		else if (%turType $= "TurretDeployedBase")
			%turType = "TurretBasePack";
		else
			%turType = "TurretIndoorDeployable";
		// decrement team count
		$TeamDeployedCount[%obj.team, %turType]--;
		remDSurface(%obj);

		if (%obj.getDataBlock().barrel $= "DeployableIndoorBarrel") {
	    	   %obj.Base.schedule(10, "delete");
		}

		%obj.schedule(700, "delete");
	}
	Parent::onDestroyed(%this, %obj, %prevState);
}

function countTurretsAllowed(%type)
{
   for(%j = 1; %j < Game.numTeams; %j++)
      %teamPlayerCount[%j] = 0;
   %numClients = ClientGroup.getCount();
   for(%i = 0; %i < %numClients; %i++)
   {
      %cl = ClientGroup.getObject(%i);
      if (%cl.team > 0)
         %teamPlayerCount[%cl.team]++;
   }
   // the bigger team determines the number of turrets allowed
   %maxPlayers = %teamPlayerCount[1] > %teamPlayerCount[2] ? %teamPlayerCount[1] : %teamPlayerCount[2];
   // each team can have 1 turret of each type (indoor/outdoor) for every 2 players
   // minimum and maximums are defined in deployables.cs
   %teamTurretMax = mFloor(%maxPlayers / 2);
   if (%teamTurretMax < $TeamDeployableMin[%type])
      %teamTurretMax = $TeamDeployableMin[%type];
   else if (%teamTurretMax > $TeamDeployableMax[%type])
      %teamTurretMax = $TeamDeployableMax[%type];

   return %teamTurretMax;
}

function spamCheck(%cl) {
	if ($Host::Prison::Enabled != true || $Host::Prison::DeploySpam != true || %cl.isAdmin || %cl.isSuperAdmin)
		return false;
	%simTime = getSimTime();
	if (%simTime - %cl.lastDeployTime > $Host::Prison::DeploySpamResetWarnCountTime * 1000)
		%cl.spamCount = 0; // Reset spam count
	if (%simTime - %cl.lastDeployTime < $Host::Prison::DeploySpamCheckTimeMS) {
		%cl.spamCount++;
		if (%cl.spamCount > $Host::Prison::DeploySpamWarnings) {
			%cl.spamPunishCount++;
			%cl.spamCount = 0;
			%cl.lastDeployTime = 0;
			%punishTime = $Host::Prison::DeploySpamTime;
			%kills = 3;
			if (%cl.spamPunishCount > %kills) {
				if ($Host::Prison::DeploySpamMultiply > 0) {
					%punishTime = (%cl.spamPunishCount - %kills) * $Host::Prison::DeploySpamTime;
					if (%punishTime > $Host::Prison::DeploySpamMaxTime)
						%punishTime = $Host::Prison::DeploySpamMaxTime;
				}
				// TODO - should really use some better formatting method...
				if (%punishTime > 0) {
					if (%punishTime >= 60) {
						if (%punishTime > 60) {
							%minutes = mFloor(%punishTime / 60);
							messageClient(%cl,'msgClient','\c2You will do %1 minutes in jail for spamming deployables.',%minutes);
							messageAllExcept(%cl,-1,'msgClient','\c2%1 will do %2 minutes in jail for spamming deployables.',%cl.name,%minutes);
						}
						else {
							messageClient(%cl,'msgClient','\c2You will do 1 minute in jail for spamming deployables.');
							messageAllExcept(%cl,-1,'msgClient','\c2%1 will do 1 minute in jail for spamming deployables.',%cl.name);
						}
					}
					else {
						messageClient(%cl,'msgClient','\c2You will do %1 seconds in jail spamming.',%punishTime);
						messageAllExcept(%cl,-1,'msgClient','\c2%1 will do %2 seconds in jail for spamming deployables.',%cl.name,%punishTime);
					}
				}
				else {
					messageClient(%cl,'msgClient','\c2You were put in jail for spamming deployables.');
					messageAllExcept(%cl,-1,'msgClient','\c2%1 was put in jail for spamming deployables.',%cl.name);
				}
				jailPlayer(%cl,false,%punishTime);
			}
			else {
				%cl.player.scriptKill(99);
				messageClient(%cl,'msgClient','\c2You were killed for spamming deployables.');
				messageAllExcept(%cl,-1,'msgClient','\c2%1 was killed for spamming deployables.',%cl.name);
			}
			return true;
		}
		// Warn player only if they've used up over half their warnings, to prevent message hud spam
		else if (%cl.spamCount > mFloor(($Host::Prison::DeploySpamWarnings + 1) / 2)) {
			centerPrint(%cl,"Do not spam, or face the consequences",2,1);
			messageClient(%cl,'msgClient',"~wfx/misc/misc.error.wav");
			return true;
		}
	}
	%cl.lastDeployTime = %simTime;
	return false;
}

//------------------------------
// Deployable extra explosions
//------------------------------

datablock GrenadeProjectileData(DeployableFireball) {
	projectileShapeName = "weapon_chaingun_ammocasing.dts";
	emitterDelay        = -1;
	directDamage        = 0.0;
	hasDamageRadius     = true;
	indirectDamage      = 0.10;
	damageRadius        = 10.0;
	radiusDamageType    = $DamageType::Debris;
	kickBackStrength    = 1000;
	bubbleEmitTime      = 1.0;

	explosion           = "PlasmaBoltExplosion";
	splash              = PlasmaSplash;
	explodeOnMaxBounce = true;

	velInheritFactor    = 0.5;

	baseEmitter         = DebrisFireEmitter;
	smokeEmitter         = DebrisSmokeEmitter;

	grenadeElasticity = 0.4;
	grenadeFriction   = 0.2;
	armingDelayMS     = 400;
	muzzleVelocity    = 20.00;
	drag = 0.1;

	hasLight    = true;
	lightRadius = 3.0;
	lightColor  = "1 0.75 0.25";
};

datablock StaticShapeData(DeployedLTarget) : StaticShapeDamageProfile {
	className = "decontarget";
	shapeFile = "xmiscf.dts";

	maxDamage      = 0.5;
	destroyedLevel = 0.5;
	disabledLevel  = 0.3;

	explosion      = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage = 0.05;
	expImpulse = 200;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Deployed DeconTarget';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
};

function DeployedLTarget::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	if (isObject(%obj.lMain)) {
		%obj.lMain.setDamageState(Destroyed);
	}
}

function fireBallExplode(%obj,%numFb) {
      
	%source = %obj;
	for (%i=0;%i<%numFb;%i++) {
		%x = (getRandom() * 0.4) - 0.2;
		%y = (getRandom() * 0.4) - 0.2;
		%z = getRandom() / 2;
		%vec = %x SPC %y SPC %z;
		%pos = vectorAdd(posFromTransform(%obj.getTransform()),vectorScale(%vec,3));
		%p = new (GrenadeProjectile)() {
			dataBlock		= DeployableFireball;
			initialDirection	= %vec;
			initialPosition		= %pos;
			sourceObject		= %source;
			sourceSlot		= 1;
			vehicleObject		= %obj;
		};
		MissionCleanup.add(%p);
	}
}

function cascade(%obj,%cascade) {
	if (%obj.cascade)
		%cascade = true;
	if ($Host::Cascade == false && !%cascade)
		return;
	%list = %obj.dObj;
	%count = getWordCount(%list);
	for(%i=0;%i<%count;%i++) {
		%obj2 = getWord(%list,%i);
		if ($Host::Cascade == false) {
			%obj2.cascade = true;
			%random = getRandom() * 1000;
			%obj2.getDataBlock().schedule(%random,disassemble,0,%obj2);
		}
		else {
			%random = getRandom() * 1000;
			%obj2.schedule(%random,setDamageState,Destroyed);
		}
	}
	%obj.cascaded = true;
}

// TODO - handle dup disassemblies? only allow every n seconds?

function disassemble(%data,%plyr,%obj) {
	if (!isObject(%obj))
		return;
	if (%obj.lMain) {
		if (isObject(%obj.lMain)) {
			%obj.lMain.getDataBlock().disassemble(%plyr,%obj.lMain);
			return;
		}
		else {
			serverPlay3D(DSound,%obj.getTransform());
			%obj.schedule(500,"delete");
			remDSurface(%obj);
			return;
		}
	}
	else if (isObject(%obj.lTarget)) {
		%obj.lTarget.startFade(250,0,1);
		%obj.lTarget.schedule(500,"delete");
	}
	%obj.isRemoved = 1;
	serverPlay3D(DSound,%obj.getTransform());
	if (%obj.getType() & $TypeMasks::StaticShapeObjectType
	|| %obj.getType() & $TypeMasks::ItemObjectType)
		%obj.startFade(500,0,1);
        if (isObject(%obj.trigger))
		%obj.trigger.delete();
        if (isObject(%obj.emitter))
                %obj.emitter.delete();
	%obj.schedule(500,"delete");	
	%revItem = %obj.getDataBlock().getName();
	%newPack = $ReverseDeployItem[%revItem];
	if (getWord(%newPack,0) $= "poof")
		$TeamDeployedCount[%obj.team,getWord(%newPack,1)]--;
	else
		$TeamDeployedCount[%obj.team,%newPack]--;
	cascade(%obj,false);
	remDSurface(%obj);
}

function StaticShapeData::disassemble(%data,%plyr,%obj) {
	if (!isObject(%obj))
		return;
	if (%obj.getDataBlock().classname $= "Generator") {
		%obj.getDataBlock().losePower(%obj);
		%loc = findWord($PowerList,%obj);
		if (%loc !$= "")
			$PowerList = listDel($PowerList,%loc);
		%obj.isRemoved = true;
	}
	if (%obj.getDataBlock().barrel $= "DeployableIndoorBarrel") {
	    %obj.Base.schedule(10, "delete");
	}
	disassemble(%data,%plyr,%obj);
}

function expertModeOn() {
	exec("scripts/expertLibraries.cs");
	$Host::ExpertMode = 1;
}

function expertModeOff() {
	exec("scripts/libraries.cs");
	$Host::ExpertMode = 0;

	// Bring pack settings down from orbit
	%count = ClientGroup.getCount();
	for (%i=0;%i<%count;%i++) {
		%client = ClientGroup.getObject(%i);
		%player = %client.player;
		if (isObject(%player)) {
			%player.packSet = 0;
			%player.expertSet = 0;
		}
	}
}

function delUndergroundDeployables(%quiet) {
	%randomTime = 10000;
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj = %group.getObject(%i);
		if (%obj) {
			%terrain = getTerrainHeight2(%obj.getPosition(),0,%obj);
			if (getWord(vectorAdd(%obj.getPosition(),"0 0 0.25"),2) < getWord(%terrain,2) || %terrain $= "") {
					warn("Deleting: " @ %obj @ " Name: " @ %obj.getDataBlock().getName());
					%random = getRandom() * %randomTime;
					%obj.getDataBlock().schedule(%random,"disassemble",%plyr, %obj); // Run Item Specific code.
					%deleted++;
			}
				else
					%checked++;

		}
	}
	if (!%quiet) {
		warn("Checked pieces: " @ %checked);
		warn("Deleted pieces: " @ %deleted);
	}
	return %randomTime;
}

function delOrphanedPieces(%quiet) {
	%randomTime = 10000;
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj =  %group.getObject(%i);
		if (!isObject(%obj.getOwner())) {
			if (!%quiet)
				warn("Deleting: " @ %obj @ " Name: " @ %obj.getDataBlock().getName());
			%random = getRandom() * %randomTime;
			%obj.getDataBlock().schedule(%random,"disassemble",%plyr,%obj); // Run Item Specific code.
			%deleted++;
		}
		else
			%checked++;
	}
	if (!%quiet) {
		warn("Checked pieces: " @ %checked);
		warn("Deleted pieces: " @ %deleted);
	}
	return %randomTime;
}

function addDSurface(%surface,%obj) {
	%surface = firstWord(%surface);
	%list = %surface.dObj;
	%obj.dSurface = firstWord(%surface);
	%list = listAdd(%list,%obj,-1);
//	warn("Added obj " @ %obj @ " to surface " @ %surface);

// For debugging
//	%count = getWordCount(%list);
//	for(%i=0;%i<%count;%i++) {
//		%obj2 = getWord(%list,%i);
//		if (!isObject(%obj2)) {
//			error("surface: " @ %surface @ " - obj does not exist: " @ %obj2);
//			%badIDs = %badIDs SPC %i;
//		}
//	}
//	%list = listDel(%list,trim(%badIDs));
//warn(%surface @ " - " @ %list);
	%surface.dObj = %list;
}

// TODO - verify
function remDSurface(%obj) {
	%surface = %obj.dSurface;
	if (isObject(%surface)) {
		%list = %surface.dObj;
		%loc = findWord(%list,%obj);
		if (%loc !$= "") {
			%list = listDel(%list,%loc);
//			warn("Removed obj " @ %obj @ " from surface " @ %surface);
		}
	}
	%surface.dObj = %list;

	%list = %obj.dObj;
	%count = getWordCount(%list);
	for(%i=0;%i<%count;%i++) {
		%obj2 = getWord(%list,%i);
		if (isObject(%obj2)) {
			%obj2.dSurface = "";
//			warn("Removed surface " @ %obj @ " from obj " @ %obj2);
		}
	}
}

function GameBase::setOwner(%obj,%plyr,%client,%guid) {
	if (!%client)
		%client = %plyr.client;
	if (!%guid)
		%guid = %client.guid;
	%obj.owner = %client;
	%obj.ownerGUID = %guid;
}

function GameBase::getOwner(%obj) {
	if (isObject(%obj.owner))
		return %obj.owner;
	%guid = %obj.ownerGUID;
	if (!%guid)
		%guid = %obj.lTarget.ownerGUID;
	if (!%guid)
		%guid = %obj.lMain.ownerGUID;
	if (%guid) {
		%count = ClientGroup.getCount();
		for (%i=0;%i<%count;%i++) {
			%client = ClientGroup.getObject(%i);
			if (%client.guid == %guid)
				return %client;
			}
	}
	return "";
}
