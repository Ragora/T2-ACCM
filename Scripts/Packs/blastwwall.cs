//---------------------------------------------------------
// Deployable wall, Code by Parousia
//---------------------------------------------------------

datablock StaticShapeData(DeployedwWall) : StaticShapeDamageProfile {
	className = "wwall";
	shapeFile = "smiscf.dts";

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
	targetNameTag = 'Light Walk Way';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(wWallDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = wwallDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedwWall;
	heatSignature = 0;
	
	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";
	
	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";
	
	isLarge = false;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;
	
	minDeployDis = 0;
	maxDeployDis = 50.0;
};

datablock ItemData(wwallDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "wWallDeployableImage";
	pickUpName = "a light walkway pack";
	heatSignature = 0;
	emap = true;
};

function wWallDeployableImage::testObjectTooClose(%item) {
	return "";
}

function wWallDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function wwallDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function wWallDeployableImage::onDeploy(%item, %plyr, %slot) {
  	//Object
	%className = "StaticShape";

	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	%rot = intRot("1 0 0 0",%playerVector);

	%scale ="5 5 0.5";

	if ($Host::ExpertMode == 1) {
		if (%plyr.expertSet == 2)
			%scale = getWord(%scale,0) * 2 SPC getWords(%scale,1,2);
		if (%plyr.expertSet == 3)
			%scale = getWord(%scale,0) SPC getWord(%scale,1) * 2 SPC getWord(%scale,2);
	}

	%surfaceAdjust = 1;
	// Do we link with another shape?
	if (%item.surface.getClassName() $= "StaticShape") {
		%surfaceAdjust = 0;
		// [[Most]] Get the relative x y location from the "pure" informtation.
		%link = sidelink(%item.surface,%item.surfaceNrm,%item.surfacePt,%scale,"0 0 -0.5");
		%location = getWords(%link,0,2);
		%side = getWords(%link,3,5);
		%dirside = getWords(%link,6,8);
		// [[Most]] Set the rotation to match the surfaceNrm and match the side.
		// The power of the full rotation system.. ;)
		%rot = fullRot(%item.surfaceNrm,%dirside);
		// [[Most]] Adjust the location to match the scale.
		%adjust = vectorScale(%item.surfaceNrm,getWord(%scale,2));
		%item.surfacePt = vectorSub(%location, %adjust);
	}

	// If we do not link with another shape
	if(%surfaceAdjust) {
		%item.surfacePt = vectorSub(%item.surfacePt,"0 0" SPC getWord(%scale,2) - 1); // Rise 1 meter above surface
	}

	%scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
		scale = %scale;
	};

	%deplObj.setTransform(%item.surfacePt SPC %rot);

	%axis = vectorCross(virvec(%item.surface,%item.surfaceNrm),virvec(%item.surface,%side));
	%axis = vectorScale(%axis,-1);
	%vec1 = vectorScale(virvec(%item.surface,%side),0.5);
	%vec2 = vectorAdd(vectorScale(virvec(%item.surface,%item.surfaceNrm),-0.5),"0 0 -0.5");
	
	deployEffect(%deplObj,%location,%side,"walk");
	%angle = getWord($packSetting["walk",%plyr.packSet],0)/180*$Pi;
	%deplObj.setTransform(remoterotate(%deplObj,%axis SPC %angle,%item.surface,vectorAdd(%vec2,%vec1)));

	if ($Host::ExpertMode == 1 && %plyr.expertSet == 1) {
	        %v = getRandom()*0.02 SPC getRandom()*0.02 SPC getRandom()*0.02;
	        %deplObj.setTransform(vectorAdd(pos(%deplObj),%v) SPC rot(%deplObj));
	}

//////////////////////////Apply settings//////////////////////////////

	// [[Location]]:

	// exact:

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

function DeployedwWall::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, wwallDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function wWallDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasWalk = true; // set for wwallcheck
	%obj.packSet = 0;
	displayPowerFreq(%obj);
}

function wWallDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.packSet = 0;
	%obj.hasWalk = "";
}
