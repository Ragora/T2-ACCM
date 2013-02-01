//--------------------------------------------------------------------------
// Deployable Generator
//--------------------------------------------------------------------------

datablock ShapeBaseImageData(GeneratorDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = GeneratorDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = GeneratorLarge;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 2;
	maxDeployDis = 5;
};

datablock ItemData(GeneratorDeployable) {
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
	image = "GeneratorDeployableImage";
	pickUpName = "a generator pack";
	heatSignature = 0;
	emap = true;
};

function GeneratorDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function GeneratorDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function GeneratorDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,-1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(vectorNormalize(vectorCross(%item.surfaceNrm,%item.surfaceNrm2)),2));

	%deplObj = new (%className)() {
		dataBlock = GeneratorLarge;
		deployed = true;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;
	setTargetName(%deplObj.target,addTaggedString("Frequency" SPC %deplObj.powerFreq));

	// set power
	%deplObj.setSelfPowered();

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

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	// add to power list
	$PowerList = listAdd($PowerList,%deplObj,-1);
	
	return %deplObj;
}

function GeneratorLarge::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	if (%obj.deployed && ($Host::InvincibleDeployables != 1 || %obj.damageFailedDecon)) {
		%obj.isRemoved = true;
		%loc = findWord($PowerList,%obj);
		if (%loc !$= "")
			$PowerList = listDel($PowerList,%loc);
		$TeamDeployedCount[%obj.team,GeneratorDeployable]--;
		remDSurface(%obj);
		%obj.schedule(500,"delete");
	}
	Parent::onDestroyed(%data,%obj,%prevState);
}

function GeneratorDeployableImage::onMount(%data,%obj,%node) {
	%obj.hasGen = true; // set for gencheck
	displayPowerFreq(%obj);
}

function GeneratorDeployableImage::onUnmount(%data,%obj,%node) {
	%obj.hasGen = "";
}
