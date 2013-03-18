//---------------------------------------------------------
// Deployable Spine, Code by Mostlikely, Prettied by JackTL
//---------------------------------------------------------

datablock StaticShapeData(DeployedSpine) : StaticShapeDamageProfile {
	className = "spine";
	shapeFile = "Pmiscf.dts";

	maxDamage      = 0.5;
	destroyedLevel = 0.5;
	disabledLevel  = 0.3;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 3.0;
	expDamage    = 0.1;
	expImpulse   = 200.0;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Light Support Beam';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};
datablock StaticShapeData(DeployedSpine2) : StaticShapeDamageProfile {
	className = "spine";
	shapeFile = "Xmiscf.dts";

	maxDamage      = 25.0;
	destroyedLevel = 25.0;
	disabledLevel  = 24.0;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 3.0;
	expDamage    = 0.1;
	expImpulse   = 200.0;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Light Support Beam';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};
datablock StaticShapeData(DeployedWoodSpine) : StaticShapeDamageProfile {
	className = "spine";
	shapeFile = "stackable5m.dts";

	maxDamage      = 0.5;
	destroyedLevel = 0.5;
	disabledLevel  = 0.3;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 3.0;
	expDamage    = 0.1;
	expImpulse   = 200.0;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Light Support Beam';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(spineDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "ammo_plasma.dts";
	item = spineDeployable;
	mountPoint = 1;
	offset = "0 -0.2 -0.55";
	deployed = DeployedSpine;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = false;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.1;
	maxDeployDis = 50.0;
};

datablock ItemData(spineDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "spineDeployableImage";
	pickUpName = "a light support beam pack";
	heatSignature = 0;
	emap = true;
};

function spineDeployableImage::testObjectTooClose(%item) {
	return "";
}

function spineDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function spineDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function spineDeployableImage::onDeploy(%item, %plyr, %slot) {
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

	%item.surfaceNrm3 = vectorCross(%item.surfaceNrm,%item.surfaceNrm2);

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%scale = getWords($packSetting["spine",%plyr.packSet],0,2);
	%dataBlock = %item.deployed;

	if (%plyr.packSet == 5) {
		%space = rayDist(%item.surfacePt SPC %item.surfaceNrm,%scale);
		if (%space != getWord(%scale,1))
			%type  = true;
		%scale = getWord(%scale,0) SPC getWord(%scale,0) SPC %space;
	}
	else if (%plyr.packSet == 6 || %plyr.packSet == 7) {
		%mCenter = "0 0 -0.5";
		%pad = pad(%item.surfacePt SPC %item.surfaceNrm SPC %item.surfaceNrm2,%scale,%mCenter);
		%scale = getWords(%pad,0,2);
		%item.surfacePt = getWords(%pad,3,5);
		%rot = getWords(%pad,6,9);
		if (%plyr.packSet == 7) {
			%scale = vectorMultiply(%scale,1.845 SPC 2 SPC 1.744); // Update dfunctions.cs if changed!
			%scaleIsSet = 1;
			%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm3,0.5));
			%rot = rotAdd(%rot,"1 0 0" SPC $Pi);
			%dataBlock = "DeployedWoodSpine";
		}
	}

	if (!%scaleIsSet)
		%scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);

	%deplObj = new (%className)() {
		dataBlock = %dataBlock;
		scale = %scale;
	};

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

	if (%pad)
		deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"pad");
	else if (%type)
		deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"spine1");
	else
		deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"spine");

	return %deplObj;
}

/////////////////////////////////////

function DeployedSpine::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, spineDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function DeployedSpine2::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, spineDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function DeployedWoodSpine::onDestroyed(%this, %obj, %prevState) {
	DeployedSpine::onDestroyed(%this, %obj, %prevState);
}

function spineDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasSpine = true; // set for spinecheck
	%obj.packSet = 0;
	displayPowerFreq(%obj);
}

function spineDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasSpine = "";
	%obj.packSet = 0;
}
