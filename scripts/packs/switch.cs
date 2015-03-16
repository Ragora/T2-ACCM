//--------------------------------------------------------------------------
// Deployable Switch
//--------------------------------------------------------------------------

datablock StaticShapeData(DeployedSwitch) : StaticShapeDamageProfile {
	className = "switch";
	shapeFile = "switch.dts";

	maxDamage      = 1.00;
	destroyedLevel = 1.00;
	disabledLevel  = 0.75;

	isShielded = true;
	energyPerDamagePoint = 30;
	maxEnergy = 100;
	rechargeRate = 0.05;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage    = 0.3;
	expImpulse   = 500;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_switch_grey";
	targetNameTag = 'Deployed';
	targetTypeTag = 'Switch';
//	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	emap = true;
};

datablock ShapeBaseImageData(SwitchDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = SwitchDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedSwitch;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	flatMinDeployDis = 0.25;
	flatMaxDeployDis = 5.0;

	minDeployDis = 2;
	maxDeployDis = 5;
};

datablock ItemData(SwitchDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;

	hasLight = true;
	lightType = "PulsingLight";
	lightColor = "0.1 0.8 0.8 1.0";
	lightTime = "1000";
	lightRadius = "3";

	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 3;
	rotate = true;
	image = "SwitchDeployableImage";
	pickUpName = "a switch pack";
	heatSignature = 0;
	emap = true;
};

datablock AudioProfile(SwitchToggledSound) {
	filename = "fx/misc/flipflop_taken.wav";
	description = AudioClosest3d;
	preload = true;
};

function SwitchDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function SwitchDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function SwitchDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");
	%item.surfaceNrm2 = %playerVector;

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		scale = "0.5 0.5 0.5";
		dataBlock = DeployedSwitch;
		deployed = true;
	};

	%deplObj.switchRadius = $packSetting["switch",%plyr.packSet];

	// TODO - handle normal state on deploy
	if ($Host::ExpertMode == 1) {
		if (%plyr.expertSet == 1)
			%deplObj.timed = 1;
		else if (%plyr.expertSet == 2)
			%deplObj.timed = 2;
	}

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// set skin
	setTargetSkin(%deplObj.target,Game.getTeamSkin(%plyr.client.team));

	// set power
	%deplObj.setSelfPowered();
	%name = "Frequency" SPC %deplObj.powerFreq;
	setTargetName(%deplObj.target,addTaggedString(%name));
	%deplObj.nameTag = %name;

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

	addDSurface(%item.surface,%deplObj);

	%deplObj.playThread($PowerThread,"Power");
	%deplObj.playThread($AmbientThread,"ambient");

	if (%deplObj.timed == 2) {
		%deplObj.stopThread($AmbientThread);
		%name = "Disabled Frequency" SPC %deplObj.powerFreq;
		setTargetName(%deplObj.target,addTaggedString(%name));
		%deplObj.nametag = %deplObj.name;
		%deplObj.isSwitchedOff = true;
	}

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	return %deplObj;
}

function DeployedSwitch::onCollision(%data,%obj,%col) {
	toggleSwitch(%obj,-1,%col);
}

function toggleSwitch(%obj,%state,%col,%delayed) {
	if (%obj.isRemoved)
		return;
	// TODO - prevent switching while waiting for timed delay / cancel timed delay if switch is hit?
	%switchDelay = 1000;
	%switchTimedDelay = 5000;
	if (%state $= "")
		%state = -1;
	if (%col == 0 || %col $= "")
		%force = true;
	if (!%force) {
		if (%col.getClassName() !$= "Player")
			return;
		if (%col.getState() $= "Dead" || %col.FFZapped == true)
			return;
		if (%obj.team != %col.team && %obj.team != 0)
			return;
		if (!(%obj.switchTime < getSimTime())) {
			messageClient(%col.client, 'msgClient', '\c2Must wait %1 seconds between switching states.',mCeil((%obj.switchTime - getSimTime())/1000));
			return;
		}
	}
	if ((%obj.isSwitchedOff || (%force == true && %state == true)) && !(%force == true && %state == false)) {
		%state = true;
		%obj.isSwitchedOff = "";
	}
	else {
		%state = false;
		%obj.isSwitchedOff = true;
	}
	%switchCount = 0;
	%count = getWordCount($PowerList);
	// TODO - report number of successes and failures
	for(%i=0;%i<%count;%i++) {
		%powerObj = getWord($PowerList,%i);
		if (vectorDist(%obj.getPosition(),%powerObj.getPosition()) < %obj.switchRadius
		&& !%powerObj.isRemoved && %obj.powerFreq == %powerObj.powerFreq
		&& %obj.team == %powerObj.team) {
			toggleGenerator(%powerObj,%state);
			%switchCount++;
		}
	}
	if (%state == true) {
		%obj.play3D(SwitchToggledSound);
		%obj.playThread($AmbientThread,"ambient");
		if (%obj.name !$= "")
		{
			%name = "[" @ %obj.name @ "] Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		else
		{
			%name = "Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		if (!%force)
			messageClient(%col.client, 'msgClient', '\c2%1 objects attempted switched on.',%switchCount);
	}
	else {
		%obj.play3D(SwitchToggledSound);
		%obj.stopThread($AmbientThread);
		if (%obj.name !$= "")
		{
			%name = "[" @ %obj.name @ "] Disabled Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		else
		{
			%name = "Disabled Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}

		if (!%force)
			messageClient(%col.client, 'msgClient', '\c2%1 objects attempted switched off.',%switchCount);
	}
	%obj.switchTime = getSimTime() + %switchDelay;
	cancel(%obj.timedSched);
	if (%obj.timed > 0 && !%delayed) {
		if (%obj.timed == 1)
			%obj.timedSched = schedule(%switchTimedDelay,0,toggleSwitch,%obj,1,0,true);
		else if (%obj.timed == 2)
			%obj.timedSched = schedule(%switchTimedDelay,0,toggleSwitch,%obj,0,0,true);
		%obj.switchTime = getSimTime() + %switchDelay + %switchTimedDelay;
	}
}

function DeployedSwitch::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, SwitchDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
}

function SwitchDeployableImage::onMount(%data,%obj,%node) {
	%obj.hasSwitch = true; // set for switchcheck
	%obj.packSet = 2;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function SwitchDeployableImage::onUnmount(%data,%obj,%node) {
	%obj.hasSwitch = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}
