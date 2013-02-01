//---------------------------------------------------------
// Deployable floor
//---------------------------------------------------------

datablock StaticShapeData(DeployedFloor) : StaticShapeDamageProfile {
	className = "floor";
	shapeFile = "smiscf.dts";

	maxDamage      = 4;
	destroyedLevel = 4;
	disabledLevel  = 3.5;

	isShielded = true;
	energyPerDamagePoint = 30;
	maxEnergy = 200;
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
	targetNameTag = 'Medium Blast floor';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(FloorDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = FloorDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedFloor;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = false;
	maxDepSlope = 360; // also see FloorDeployableImage::testSlopeTooGreat()
	deploySound = ItemPickupSound;

	minDeployDis = 0.1;
	maxDeployDis = 50.0;
};

datablock ItemData(FloorDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "FloorDeployableImage";
	pickUpName = "a medium floor pack";
	heatSignature = 0;
	emap = true;
};

function FloorDeployableImage::testSlopeTooGreat(%item) {
	if (%item.surface) {
		// Do we link with another Medium Floor?
		if (%item.surface.getClassName() $= "StaticShape") {
			if (%item.surface.getDataBlock().className $= "floor") {
				%floor = 1;
			}
		}
		if (%floor) {
			if ($Host::Purebuild == true && $Host::Hazard::Enabled != true)
				return getTerrainAngle(%item.surfaceNrm) > %item.maxDepSlope;
			else
				return getTerrainAngle(%item.surfaceNrm) > 1;
		}
		else
			return getTerrainAngle(%item.surfaceNrm) > %item.maxDepSlope;
	}
}

function FloorDeployableImage::testObjectTooClose(%item) {
	if ($Host::Purebuild == true && $Host::Hazard::Enabled != true)
		return "";
	else {
		%terrain = %item.surface.getClassName() $= "TerrainBlock";
		%interior = %item.surface.getClassName() $= "InteriorInstance";
		if (%item.surface.getClassName() $= "StaticShape") {
			if (%item.surface.getDataBlock().className $= "floor") {
				%floor = 1;
			}
		}
		return !(%terrain || %interior || %floor);
	}
}

function FloorDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function FloorDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function FloorDeployableImage::onDeploy(%item, %plyr, %slot) {
	//Object
	%className = "StaticShape";

	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	%rot = intRot("1 0 0 0",%playerVector);

	%scale = getWords($packSetting["floor",%plyr.packSet],0,2);

	if ($Host::ExpertMode == 1)
		%scale = getWords(%scale,0,1) SPC firstWord($expertSetting["floor",%plyr.expertSet]);

	%surfaceAdjust = 1;
	// Do we link with another Medium Floor?
	if (%item.surface.getClassName() $= "StaticShape") {
		if (%item.surface.getDataBlock().className $= "floor") {
			%surfaceAdjust = 0;
			// [[Most]] Get the relative x y location from the "pure" information.
			%link = sidelink(%item.surface,%item.surfaceNrm,%item.surfacePt,getWords($packSetting["floor",%plyr.packSet],3,5),"0 0 -0.5");
			%location = getWords(%link,0,2);
			%side = getWords(%link,3,5);
			%dirside = getWords(%link,6,8);
			// [[Most]] Set the rotation to match the surfaceNrm and match the side.
			// The power of the full rotation system.. ;)
			%rot = fullRot(%item.surfaceNrm,vectorScale(%dirside,-1));
			// [[Most]] Adjust the location to match the scale.
			%adjust = vectorScale(%item.surfaceNrm,GetWord(%scale,2));
			%item.surfacePt = vectorSub(%location, %adjust);
		}
	}

	// If we do not link with another Medium Floor
	if(%surfaceAdjust) {
		%item.surfacePt = vectorSub(%item.surfacePt,"0 0" SPC getWord(%scale,2) - 1); // Rise 1 meter above surface
	}

	%scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
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

	return %deplObj;
}

function DeployedFloor::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, FloorDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function FloorDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasFloor = true; // set for floorcheck
	%obj.packSet = 0;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function FloorDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasFloor = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}
