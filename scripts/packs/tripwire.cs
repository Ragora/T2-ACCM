// Tripwire

datablock ForceFieldBareData(TripField) : DeployedForceField {
	baseTranslucency = 0.1;
	powerOffTranslucency = 0.0;
	teamPermiable = true;
	otherPermiable = true;
	color         = "1 0 0";
	powerOffColor = "0.0 0.0 0.0";
	deployedFrom = "";
	needsPower = false;
};

datablock AudioProfile(TripwireSound) {
	filename = "fx/misc/rolechange.wav";
	description = AudioClosest3d;
	preload = true;
};

datablock TriggerData(TripTrigger) {
	// TODO - check this
	tickPeriodMS = 200;
};

function TripTrigger::onEnterTrigger(%data, %obj, %colObj)   {
// TODO - keep trip FF scaled down until trip is triggered - vehicle fix?
	%baseObj = %obj.baseObj;
	%baseObj.triggerCount++;
	if (%baseObj.triggerCount > 1)
		return;
	%baseObj.play3D(TripwireSound);
	if (isObject(%baseObj.tripField)) {
		cancel(%baseObj.tripField.hideSched);
		%baseObj.tripField.getDataBlock().gainPower(%baseObj.tripField);
	}
	%tripMode = %baseObj.tripMode;
	while (%tripMode > 1 && %tripMode > -1 && %tripMode !$= "")
		%tripMode = %tripMode - 2;
	%count = getWordCount($PowerList);
	for(%i=0;%i<%count;%i++) {
		%powerObj = getWord($PowerList,%i);
		if (vectorDist(%baseObj.getPosition(),%powerObj.getPosition()) < %baseObj.switchRadius
		&& !%powerObj.isRemoved && %baseObj.powerFreq == %powerObj.powerFreq
		&& %baseObj.team == %powerObj.team) {
			%r = toggleGenerator(%powerObj,!%tripMode);
			%r1 = firstWord(%r);
			%r2 = getTaggedString(getWord(%r,1));
			%r3 = getWord(%r,2);
			if (%r1 == -3) {
				cancel(%powerObj.toggleSched);
				%powerObj.toggleSched = schedule(%r3 + 100,0,toggleGenerator,%powerObj,!%tripMode);
			}
		}
	}
}

function TripTrigger::onLeaveTrigger(%data, %obj, %colObj) {
	%baseObj = %obj.baseObj;
	%baseObj.triggerCount--;
	if (%baseObj.triggerCount > 0)
		return;
	%baseObj.play3D(TripwireSound);
	if (isObject(%baseObj.tripField)) {
		cancel(%baseObj.tripField.hideSched);
		%baseObj.tripField.hideSched = %baseObj.tripField.getDataBlock().schedule(2000,losePower,%baseObj.tripField);
	}
	%tripMode = %baseObj.tripMode;
	if (%tripMode == 2 || %tripMode == 3)
		return;
	if (%tripMode == 4 || %tripMode == 5)
		%timed = true;
	while (%tripMode > 1 && %tripMode > -1 && %tripMode !$= "")
		%tripMode = %tripMode - 2;
	%count = getWordCount($PowerList);
	for(%i=0;%i<%count;%i++) {
		%powerObj = getWord($PowerList,%i);
		if (vectorDist(%baseObj.getPosition(),%powerObj.getPosition()) < %baseObj.switchRadius
		&& !%powerObj.isRemoved && %baseObj.powerFreq == %powerObj.powerFreq
		&& %baseObj.team == %powerObj.team) {
			if (%timed) {
				cancel(%powerObj.toggleSched);
				%powerObj.toggleSched = schedule(5000,0,delayedToggleGenerator,%powerObj,%tripMode);
			}
			else {
				%r = toggleGenerator(%powerObj,%tripMode);
				%r1 = firstWord(%r);
				%r2 = getTaggedString(getWord(%r,1));
				%r3 = getWord(%r,2);
				if (%r1 == -3) {
					cancel(%powerObj.toggleSched);
					%powerObj.toggleSched = schedule(%r3 + 100,0,toggleGenerator,%powerObj,%tripMode);
				}
			}
		}
	}
}

function delayedToggleGenerator(%powerObj,%tripMode) {
	%r = toggleGenerator(%powerObj,%tripMode);
	%r1 = firstWord(%r);
	%r2 = getTaggedString(getWord(%r,1));
	%r3 = getWord(%r,2);
	if (%r1 == -3) {
		cancel(%powerObj.toggleSched);
		%powerObj.toggleSched = schedule(%r3 + 100,0,toggleGenerator,%powerObj,%tripMode);
	}
}

function TripTrigger::onTickTrigger(%data, %obj) {
}

function TripTrigger::onTrigger(%this, %triggerId, %on) {
}

datablock StaticShapeData(DeployedTripwire) : StaticShapeDamageProfile {
	className = "tripwire";
	shapeFile = "camera.dts";

	maxDamage      = 0.2;
	destroyedLevel = 0.2;
	disabledLevel  = 0.2;

	isShielded = false;
	energyPerDamagePoint = 40;
	maxEnergy = 30;
	rechargeRate = 0.05;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage    = 0.3;
	expImpulse   = 500;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Deployed';
	targetTypeTag = 'Tripwire';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	emap = true;
};

datablock ShapeBaseImageData(TripwireDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "camera.dts";
	item = TripwireDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	rotation = "-1 0 0 90";
	deployed = DeployedTripwire;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = false;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.25;
	maxDeployDis = 5;
};

datablock ItemData(TripwireDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 3;
	rotate = true;
	image = "TripwireDeployableImage";
	pickUpName = "a tripwire pack";
	heatSignature = 0;
	emap = true;
};

function TripwireDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function TripwireDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function TripwireDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (%item.surfaceinher == 0) {
		if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
			%item.surfaceNrm2 = %playerVector;
		else
			%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
	}

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = DeployedTripwire;
	};

	%deplObj.switchRadius = getWord($packSetting[TripwireDeployableImage, %plyr.packSet[0]], 0);
	%deplObj.fieldMode = %plyr.packSet[2];
	%deplObj.tripMode = %plyr.packSet[1];
	if (%deplObj.fieldMode == 1)
		%deplObj.beamRange = 160;
	else
		%deplObj.beamRange = 30;

	if(!%plyr.packSet[3])
	{
		%deplObj.tripField = new ForceFieldBare() {
			dataBlock = TripField;
			scale = "0.05 0.05 0.1";
		};

		%deplObj.tripField.pzone.delete();
	}

	%deplObj.tripTrigger = new Trigger() {
		dataBlock = TripTrigger;
		polyhedron = "0 1 0 1 0 0 0 -1 0 0 0 1";
		scale = "0.05 0.05 0.1";
	};

	%deplObj.tripTrigger.baseObj = %deplObj;

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	adjustTripwire(%deplObj);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;
	setTargetName(%deplObj.target,addTaggedString("Frequency" SPC %deplObj.powerFreq));

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

	%deplObj.deploy();

	addDSurface(%item.surface,%deplObj);

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	return %deplObj;
}

function DeployedTripwire::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, TripwireDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	if (isObject(%obj.tripField))
		%obj.tripField.schedule(500, "delete");
	if (isObject(%obj.tripTrigger))
		%obj.tripTrigger.schedule(500, "delete");
}

function DeployedTripwire::disassemble(%data,%plyr,%obj) {
	if (isObject(%obj.tripField))
		%obj.tripField.delete();
	if (isObject(%obj.tripTrigger))
		%obj.tripTrigger.delete();
	disassemble(%data,%plyr,%obj);
}

function adjustTripwire(%obj) {
	if (!isObject(%obj))
		return;
	cancel(%obj.adjustSched);
	%pos = %obj.getPosition();
	%nrm = realVec(%obj,"0 0 1");
	%nrm2 = realVec(%obj,"1 0 0");
	%nrm3 = realVec(%obj,"0 1 0");

	// TODO - temporary - remove
	if ($TripWireFlareMode == true) {
		%pos = vectorAdd(%obj.getPosition(),vectorScale(%nrm,0.35));
		%vec = vectorScale(%nrm,0.7);
		%p = new FlareProjectile() {
			dataBlock        = FlareGrenadeProj;
			initialDirection = %vec;
			initialPosition  = %pos;
			sourceObject     = %obj;
			sourceSlot       = 0;
		};
		FlareSet.add(%p);
		MissionCleanup.add(%p);
		%p.schedule(6000,"delete");
	}

	// save ourselves re-doing some calculations
	%mask = $TypeMasks::VehicleObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType | $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType | $TypeMasks::MoveableObjectType | $TypeMasks::DamagableItemObjectType;
	if (%obj.fieldMode == 1) {
		// new pad data can be done here for both field and trigger
		// "normal" (no hit) beamRange limited to 0.5m - 8m
		// max beamRange limited to 0.5m - 160m
		%pad = pad(%obj.getPosition() SPC realVec(%obj,"0 0 1") SPC realVec(%obj,"1 0 0"),0.5 SPC limit(%obj.beamRange,0.5,8) SPC limit(%obj.beamRange,0.5,160),"-0.5 -0.5 -0.5",%mask,%obj.tripField);
		%newScale = getWords(%pad,0,2);
		%newPos = getWords(%pad,3,5);
		%newRot = getWords(%pad,6,9);
	}
	else {
		// beam
		%dist = rayDist(vectorAdd(%pos,vectorScale(%nrm,0.1)) SPC %nrm,1 SPC %obj.beamRange SPC %obj.beamRange,%mask,%obj.tripField);
	}

	if (isObject(%obj.tripField)) {
		%obj2 = %obj.tripField;
		if (%obj.fieldMode == 0) {
			%scale = %obj2.getScale();
			%newPos = vectorAdd(%pos,vectorAdd(vectorScale(%nrm2,-(getWord(%scale,0) / 2)),vectorScale(%nrm3,-(getWord(%scale,1) / 2))));
			%newRot = %obj.getRotation();
			%newScale = getWords(%scale,0,1) SPC %dist;
		}
		%oldData = %obj2.oldData;
		%newData = %newPos SPC %newRot SPC %newScale;
		if (%oldData !$= %newData && %obj.triggerCount == 0) {
			// call gainPower() before modifying forcefield!
			%obj2.getDataBlock().gainPower(%obj2);
			%obj2.setTransform(%newPos SPC %newRot);
			%obj2.setScale(%newScale);
			%obj2.oldData = %newData;
			cancel(%obj2.hideSched);
			%obj2.hideSched = %obj2.getDataBlock().schedule(2000,losePower,%obj2);
		}
	}
	if (isObject(%obj.tripTrigger)) {
		%obj2 = %obj.tripTrigger;
		if (%obj.fieldMode == 0) {
			%scale = %obj2.getScale();
			%newPos = vectorAdd(%pos,vectorAdd(vectorScale(%nrm2,-(getWord(%scale,0) / 2)),vectorScale(%nrm3,-(getWord(%scale,1) / 2))));
			%newRot = %obj.getRotation();
			%newScale = getWords(%scale,0,1) SPC %dist;
		}
		%oldData = %obj2.oldData;
		%newData = %newPos SPC %newRot SPC %newScale;
		if (%oldData !$= %newData && %obj.triggerCount == 0) {
			%obj2.setTransform(%newPos SPC %newRot);
			%obj2.setScale(%newScale);
			%obj2.oldData = %newData;
		}
	}
	%obj.adjustSched = schedule(1000,0,adjustTripwire,%obj);
}

function TripwireDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasTripwire = true; // set for tripcheck
	%obj.packSet = 0;
	%obj.packSet[0] = 0;
	%obj.packSet[1] = 0;
	%obj.packSet[2] = 0;
	%obj.packSet[3] = 0;
	displayPowerFreq(%obj);
}

function TripwireDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.packSet = 0;
	%obj.packSet[0] = 0;
	%obj.packSet[1] = 0;
	%obj.packSet[2] = 0;
	%obj.packSet[3] = 0;
	%obj.hasTripwire = "";
}

function TripwireDeployableImage::ChangeMode(%data,%plyr,%val,%level)
{
	if (%level == 0)
	{
		%set = %plyr.expertSet;
		if(%set $= "")
			%set = 0;
		%image = %data.getName();
		%settings = $packSettings[%image,%set];

		%plyr.packSet[%set] = %plyr.packSet[%set] + %val;
		if (%plyr.packSet[%set] > getWord(%settings,0))
			%plyr.packSet[%set] = 0;
		if (%plyr.packSet[%set] < 0)
			%plyr.packSet[%set] = getWord(%settings,0);

		%packname = GetWords(%settings,2,getWordCount(%settings));
		%curset = $PackSetting[%image,%plyr.packSet[%set],%set];
		if (getWord(%settings,1) == -1)
			%line = GetWords(%curset,0,getWordCount(%curset));
		else
			%line = GetWords(%curset,0,getWord(%settings,1));
		bottomPrint(%plyr.client,%packname SPC "set to"SPC %line,2,1);
	}
	else
	{
		Parent::ChangeMode(%data,%plyr,%val,%level);
	}
}
