//---------------------------------------------------------
// Deployable Gravity Field
//---------------------------------------------------------

// Translucencies
%fieldTrans = 1.0;
%powerOffTrans = 0.25;

// RGB
%colourOn = 0.6;
%colourOff = 0.15;
%dimDiv = 3;

datablock ForceFieldBareData(DeployedGravityField) {
	className = "gravityfield";
	fadeMS = 1000;
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = "1.0 1.0 1.0";
	powerOffColor = "0.0 0.0 0.0";
	targetTypeTag = 'GravityField';
	texture[0] = "skins/forcef1";
	texture[1] = "skins/forcef2";
	texture[2] = "skins/forcef3";
	texture[3] = "skins/forcef4";
	texture[4] = "skins/forcef5";
	framesPerSec = 10;
	numFrames = 5;
	scrollSpeed = 15;
	umapping = 1.0;
	vmapping = 0.15;
	deployedFrom = GravityFieldDeployable;
	velocityMod = 1;
	gravityMod = 1;
	appliedForce = "0 0 0";
	needsPower = true;
};

// slow
datablock ForceFieldBareData(DeployedGravityField0) : DeployedGravityField {
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOff/%dimDiv SPC %colourOn/%dimDiv SPC %colourOff/%dimDiv;
	powerOffColor = "0.0 0.0 0.0";
	velocityMod = 1;
	gravityMod = 0;
};

// fast
datablock ForceFieldBareData(DeployedGravityField1) : DeployedGravityField {
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOff SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
	velocityMod = 1;
	gravityMod = 0;
};

// zero gravity
datablock ForceFieldBareData(DeployedGravityField2) : DeployedGravityField {
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
	velocityMod = 1;
	gravityMod = 0;
};

// fastfield
datablock ForceFieldBareData(DeployedGravityField3) : DeployedGravityField {
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn/%dimDiv SPC %colourOff/%dimDiv SPC %colourOn/%dimDiv;
	powerOffColor = "0.0 0.0 0.0";
	velocityMod = 1.5;
	gravityMod = 0;
};

// super fastfield
datablock ForceFieldBareData(DeployedGravityField4) : DeployedGravityField {
	baseTranslucency = %fieldTrans;
	powerOffTranslucency = %powerOffTrans;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
	velocityMod = 1.7;
	gravityMod = 0;
};

datablock ShapeBaseImageData(GravityFieldDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "ammo_chaingun.dts";
	item = GravityFieldDeployable;
	mountPoint = 1;
	offset = "-0.2 -0.125 0";
	rotation = "0 -1 0 90";
	deployed = DeployedGravityField;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.1;
	maxDeployDis = 50.0;
};

datablock ItemData(GravityFieldDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	joint = "4.75 4.75 4.75";
	rotate = true;
	image = "GravityFieldDeployableImage";
	pickUpName = "a gravity field pack";
	heatSignature = 0;
	emap = true;
};

function GravityFieldDeployableImage::testObjectTooClose(%item) {
	return;
}

function GravityFieldDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function GravityFieldDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function GravityFieldDeployableImage::onDeploy(%item, %plyr, %slot) {
	//Object
	%className = "ForceFieldBare";

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
	%scale = getWords($packSetting["gravfield",%plyr.packSet],0,2);

	%space = rayDist(%item.surfacePt SPC %item.surfaceNrm,%scale);
	%scale = getWord(%scale,0) SPC getWord(%scale,0) SPC %space;

	// Shift field position since field handle is not field center
	%mod = firstWord($packSetting["gravfield",%plyr.packSet]) / 2;
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm2),%mod));
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(vectorCross(%item.surfaceNrm,%item.surfaceNrm2)),%mod));

	// Add padding
	%padSize = 0.01;
	%scale = vectorAdd(%scale,%padSize * 2 SPC %padSize * 2 SPC %padSize * 2);
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm),%padSize));
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm2),%padSize));
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(vectorCross(%item.surfaceNrm,%item.surfaceNrm2)),%padSize));

	// Set datablock
	if (%plyr.packSet == 0)
		%dataBlock = nameToID(%item.deployed @ 0);
	else if (%plyr.packSet == 1)
		%dataBlock = nameToID(%item.deployed @ 1);
	else if (%plyr.packSet == 2)
		%dataBlock = nameToID(%item.deployed @ 0);
	else if (%plyr.packSet == 3)
		%dataBlock = nameToID(%item.deployed @ 1);
	else if (%plyr.packSet == 4)
		%dataBlock = nameToID(%item.deployed @ 2);
	else if (%plyr.packSet == 5)
		%dataBlock = nameToID(%item.deployed @ 3);
	else if (%plyr.packSet == 6)
		%dataBlock = nameToID(%item.deployed @ 4);

	%appliedForceVec = vectorNormalize(%item.surfaceNrm);

	if ($Host::ExpertMode == 1) {
		if (isCubic(%item.surface) && (%plyr.expertSet == 1 || %plyr.expertSet == 2) && %plyr.team == %item.surface.team
		&& %item.surface.getType() & $TypeMasks::StaticShapeObjectType
		&& (($Host::OnlyOwnerCubicReplace == 0) || (%plyr.client == %item.surface.getOwner()))) {
			if (%plyr.expertSet == 2)
				%appliedForceVec = vectorNormalize(realVec(%item.surface,"0 0 1"));
			%scale = vectorAdd(realSize(%item.surface),%padSize * 2 SPC %padSize * 2 SPC %padSize * 2);
			%center = realVec(%item.surface,vectorScale(getWords(%scale,0,1) SPC "0",-0.5));
			%item.surfacePt = vectorAdd(pos(%item.surface),%center);
			%rot = rot(%item.surface);
			%mod = vectorScale(matrixMulVector("0 0 0" SPC %rot ,"0 0 1"),-%padSize);
			%item.surfacePt = vectorAdd(%item.surfacePt,%mod);
			%item.surface.getDataBlock().disassemble(%plyr, %item.surface);
		}
	}

	%velocityMod = %dataBlock.velocityMod;
	%gravityMod = %dataBlock.gravityMod;
	%appliedForce = %dataBlock.appliedForce;

	%slowForce = 500;
	%fastForce = 1000;

	if (%plyr.packSet == 0)
		%appliedForce = vectorScale(%appliedForceVec,%slowForce);
	else if (%plyr.packSet == 1)
		%appliedForce = vectorScale(%appliedForceVec,%fastForce);
	else if (%plyr.packSet == 2)
		%appliedForce = vectorScale(%appliedForceVec,-%slowForce);
	else if (%plyr.packSet == 3)
		%appliedForce = vectorScale(%appliedForceVec,-%fastForce);

	%deplObj = new (%className)() {
		dataBlock = %dataBlock;
		scale = %scale;
		velocityMod = %velocityMod;
		gravityMod = %gravityMod;
		appliedForce = %appliedForce;
	};

	// Take the deployable off the player's back and out of inventory
	if ($Host::ExpertMode == 0) {
		%plyr.unMountImage(%slot);
		%plyr.decInventory(%item.item,1);
	}

////////////////////////Apply settings//////////////////////////////

	// [[Location]]:

	// exact:
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	%deplObj.pzone.setTransform(%item.surfacePt SPC %rot);

	// misc info
	addDSurface(%item.surface,%deplObj);

	// [[Settings]]:

	%deplObj.grounded = %grounded;
	%deplObj.needsFit = 1;

	// [[Normal Stuff]]:

	// set team, owner, and handle
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

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

	// Power object
	checkPowerObject(%deplObj);

	if (!%deplObj.powerCount > 0) {
		%deplObj.getDataBlock().disassemble(0,%deplObj); // Run Item Specific code.
		messageClient(%plyr.client,'MsgDeployFailed','\c2Gravity field lost - no power source found!%1','~wfx/misc/misc.error.wav');
	}

	return %deplObj;
}

/////////////////////////////////////

function GravityFieldDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasGravField = true; // set for gravfieldcheck
	%obj.packSet = 0;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function GravityFieldDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasGravField = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}

function DeployedGravityField::disassemble(%data,%plyr,%obj) {
	if (isObject(%obj.pzone))
		%obj.pzone.delete();
	disassemble(%data,%plyr,%obj);
}

function DeployedGravityField0::disassemble(%data,%plyr,%obj) {
	DeployedGravityField::disassemble(%data,%plyr,%obj);
}

function DeployedGravityField1::disassemble(%data,%plyr,%obj) {
	DeployedGravityField::disassemble(%data,%plyr,%obj);
}

function DeployedGravityField2::disassemble(%data,%plyr,%obj) {
	DeployedGravityField::disassemble(%data,%plyr,%obj);
}

function DeployedGravityField3::disassemble(%data,%plyr,%obj) {
	DeployedGravityField::disassemble(%data,%plyr,%obj);
}

function DeployedGravityField4::disassemble(%data,%plyr,%obj) {
	DeployedGravityField::disassemble(%data,%plyr,%obj);
}
