//---------------------------------------------------------
// Deployable mspine, Code by Parousia
//---------------------------------------------------------

datablock StaticShapeData(DeployedMSpine) : StaticShapeDamageProfile {
	className = "mspine";
	shapeFile = "dmiscf.dts";

	maxDamage      = 5.0;
	destroyedLevel = 5.0;
	disabledLevel  = 2.5;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 5.0;
	expDamage    = 0.5;
	expImpulse   = 200.0;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Medium Support Beam';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock StaticShapeData(DeployedMSpinering) : DeployedMSpine {
	maxDamage      = 1.0;
	destroyedLevel = 1.0;
	disabledLevel  = 0.75;
};

datablock ShapeBaseImageData(mspineDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = mspineDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedMSpine;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.1;
	maxDeployDis = 50.0;
};

datablock ItemData(mspineDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	joint = "1 1 1";
	rotate = true;
	image = "mspineDeployableImage";
	pickUpName = "a medium support beam pack";
	heatSignature = 0;
	emap = true;
};

function mspineDeployableImage::testObjectTooClose(%item) {
	return "";
}

function mspineDeployableImage::onDeploy(%item, %plyr, %slot) {
	//Object
	%className = "StaticShape";

	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (%item.surfaceinher == 0) {
		if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
			%item.surfaceNrm2 = %playerVector;
		else
			%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
	}

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%scale = getWords($packSetting["mspine",%plyr.packSet],0,2);

	%mod = 0.5;

	if (%plyr.packSet >= 5 && %plyr.packSet < 8) {
		%space = rayDist(%item.surfacePt SPC %item.surfaceNrm,%scale,$AllObjMask);

		if (%space != getWord(%scale,1))
			%type = 1;

		%scale = getWord(%scale,0) SPC getWord(%scale,0) SPC %space;
		if (%plyr.packSet == 7)
			%mod = -0.01;
	}

	%scaler = getWords($packSetting["mspine",%plyr.packSet],3,5);

	%deplObj = new (%className)() { //Main Spine
		dataBlock = %item.deployed;
		scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);
	};

	if (%plyr.packSet != 0 && (%plyr.packSet == 6 || %plyr.packSet == 7 || %plyr.expertSet == 1)) {
		%deplObj1 = new (%className)() { //Top add
			dataBlock = "DeployedMSpinering";
			scale =  vectorMultiply(%scaler,1/4 SPC 1/3 SPC 2);
		};
		%deplObj2 = new (%className)() { //Bottom add
			dataBlock = "DeployedMSpinering";
			scale = vectorMultiply(%scaler,1/4 SPC 1/3 SPC 2);
		};

		%h1=vectorAdd(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm),%mod));
		%h2=vectorAdd(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm),GetWord(%scale,2)-%mod-0.5));

		%deplObj1.setTransform(%h1 SPC %rot);
		%deplObj2.setTransform(%h2 SPC %rot);
		addDSurface(%deplObj,%deplObj1);
		%deplObj1.grounded = %grounded;
		%deplObj1.needsFit = 1;
		addDSurface(%deplObj,%deplObj2);
		%deplObj2.grounded = %grounded;
		%deplObj2.needsFit = 1;
		%deplObj1.team = %plyr.client.team;
		%deplObj1.setOwner(%plyr);
		%deplObj2.team = %plyr.client.team;
		%deplObj2.setOwner(%plyr);
		if(%deplObj1.getTarget() != -1)
			setTargetSensorGroup(%deplObj2.getTarget(), %plyr.client.team);
		if(%deplObj2.getTarget() != -1)
			setTargetSensorGroup(%deplObj2.getTarget(), %plyr.client.team);
		addToDeployGroup(%deplObj1);
		addToDeployGroup(%deplObj2);
		AIDeployObject(%plyr.client, %deplObj1);
		AIDeployObject(%plyr.client, %deplObj2);
		%deplObj.right = %deplObj1;
		%deplObj.left = %deplObj2;
	}

//////////////////////////Apply settings//////////////////////////////

	// [[Location]]:

	// exact:
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// misc info
	addDSurface(%item.surface,%deplObj);

	// [[Settings]]:

	%deplObj.grounded = %grounded;
        %deplObj.needsFit = 1;

	// [[Normal Stuff]]:

//	if(%deplObj.getDatablock().rechargeRate)
//		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;
	%deplObj.right.powerFreq = %plyr.powerFreq;
	%deplObj.left.powerFreq = %plyr.powerFreq;

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

	// Power object
	checkPowerObject(%deplObj);
	if (isObject(%deplObj.right))
		checkPowerObject(%deplObj.right);
	if (isObject(%deplObj.left))
		checkPowerObject(%deplObj.left);

	if (!%type)
		deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"mspine");
	else
		deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"mspine1");

	return %deplObj;
}

function DeployedMSpine::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, mspineDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
	if (isObject(%obj.right))
		%obj.right.schedule(500,setDamageState,Destroyed);
	if (isObject(%obj.left))
		%obj.left.schedule(500,setDamageState,Destroyed);
}

function DeployedMSpinering::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function DeployedMSpine::disassemble(%data,%plyr,%hTgt) {
	if ($Host::Purebuild == 1) { // Remove console spam
		if (isObject(%hTgt.right))
			%hTgt.right.getDataBlock().schedule(500,disassemble,0,%hTgt.right);
		if (isObject(%hTgt.left))
			%hTgt.left.getDataBlock().schedule(500,disassemble,0,%hTgt.left);
	}
	disassemble(%data,%plyr,%hTgt);
}

function mspineDeployableImage::onMount(%data,%obj,%node) {
	%obj.hasMSpine = true; // set for mspinecheck
	%obj.packSet = 0;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function mspineDeployableImage::onUnmount(%data,%obj,%node) {
	%obj.hasMSpine = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}
