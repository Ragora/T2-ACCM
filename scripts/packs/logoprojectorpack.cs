//---------------------------------------------------------
// Deployable Logo Logo Projector
//---------------------------------------------------------

datablock StaticShapeData(DeployedLogoProjector) : StaticShapeDamageProfile {
	className = "logoprojector";
	shapeFile = "teamlogo_projector.dts";

	maxDamage      = 0.5;
	destroyedLevel = 0.5;
	disabledLevel  = 0.3;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion      = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage = 0.05;
	expImpulse = 200;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Deployed Logo Projector';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(LogoProjectorDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "teamlogo_projector.dts";
	item = LogoProjectorDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	rotation = "-1 0 0 90";
	deployed = DeployedLogoProjector;
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

datablock ItemData(LogoProjectorDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "LogoProjectorDeployableImage";
	pickUpName = "a logo projector pack";
	heatSignature = 0;
	emap = true;
 };

function LogoProjectorDeployableImage::testObjectTooClose(%item) {
	return "";
}

function LogoProjectorDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function LogoProjectorDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function LogoProjectorDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
	};

	if ($Host::Purebuild == 1)
		if (%plyr.packSet == 0)
			%logo = 0;
		else
			%logo = %plyr.packSet;
	else {
		%logo = 0;
	}

	switch (%logo) {
		case 1:
			%logo = "Base";
		case 2:
			%logo = "BaseB";
		case 3:
			%logo = "Swolf";
		case 4:
			%logo = "DSword";
		case 5:
			%logo = "BEagle";
		case 6:
			%logo = "COTP";
		case 7:
			%logo = "Bioderm";
		default:
			%logo = "0";
	}

	if (%logo $= "0")
		%deplObj.holoBlock = getTaggedString(Game.getTeamSkin(%plyr.client.team)) @ "Logo";
	else
		%deplObj.holoBlock = %logo @ "Logo";
		
	%deplObj.holo = new StaticShape() {
		datablock = %deplObj.holoBlock;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	adjustHolo(%deplObj);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	%deplObj.holo.team = %plyr.client.Team;
	%deplObj.holo.setOwner(%plyr);
	%deplObj.holo.projector = %deplObj;

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client,%deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	// Power object
	checkPowerObject(%deplObj);

	return %deplObj;
}

function DeployedLogoProjector::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, LogoProjectorDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	if (isObject(%obj.holo))
		%obj.holo.schedule(500, "delete");
	fireBallExplode(%obj,1);
}

function DeployedLogoProjector::disassemble(%data,%plyr,%obj) {
	if (isObject(%obj.holo))
		%obj.holo.delete();
	disassemble(%data,%plyr,%obj);
}

function DeployedLogoProjector::onGainPowerEnabled(%data,%obj) {
	if (shouldChangePowerState(%obj,true)) {
		if (isObject(%obj.holo))
			%obj.holo.delete();
		%obj.holo = new StaticShape() {
			datablock = %obj.holoBlock;
			projector = %obj;
		};
		adjustHolo(%obj);
	}
	Parent::onGainPowerEnabled(%data,%obj);
}

function DeployedLogoProjector::onLosePowerDisabled(%data,%obj) {
	if (shouldChangePowerState(%obj,false)) {
		if (isObject(%obj.holo))
			%obj.holo.delete();
	}
	Parent::onLosePowerDisabled(%data,%obj);
}

function adjustHolo(%obj) {
	%obj.holo.setTransform(vectorAdd(%obj.getPosition(),vectorScale(realVec(%obj,"0 0 1"),10)) SPC %obj.getRotation());
}

function LogoProjectorDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasProjector = true; // set for projectorcheck
	%obj.packSet = 0;
	displayPowerFreq(%obj);
}

function LogoProjectorDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasProjector = "";
	%obj.packSet = 0;
}
