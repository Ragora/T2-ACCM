datablock StaticShapeData(DeployedSentinelPatrol) : StaticShapeDamageProfile {
	className	= "patrolpoint";
	shapeFile	= "deploy_sensor_motion.dts";

	maxDamage	= 5.0;
	destroyedLevel	= 5.0;
	disabledLevel	= 4.21;

	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion	= HandGrenadeExplosion;
	expDmgRadius	= 1.0;
	expDamage	= 0.05;
	expImpulse	= 200;

	dynamicType		= $TypeMasks::StaticShapeObjectType;
	deployedObject		= true;

	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Sentinel';
	targetTypeTag = 'Patrol Point';
	deployAmbientThread = true;

	debrisShapeName		= "debris_generic_small.dts";
	debris			= DeployableDebris;

	heatSignature		= 0;
	needsPower 		= false;
};

datablock ShapeBaseImageData(SentinelDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = SentinelDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedSentinelPatrol;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = false;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.5;
	maxDeployDis = 50.0;
};

datablock ItemData(SentinelDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "ZSpawnDeployableImage";
	pickUpName = "a sentinel patrol point pack";
	heatSignature = 0;
	emap = true;
};

function SentinelDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	%deplObj.setScale("5 5 5");

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

	addDSurface(%item.surface,%deplObj);

	%deplObj.playThread($PowerThread,"Power");
	%deplObj.playThread($AmbientThread,"ambient");

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

	// Power object
	checkPowerObject(%deplObj);

	SentinelAI_AddPatrolPoint(%deplObj);
	return %deplObj;
}

function SentinelDeployable::onPickup(%data, %obj, %shape, %amount)
{
	// No more spam
}

function DeployedSentinelPatrol::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	SentinelAI_RemPatrolPoint(%obj);
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, SentinelDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
}

function DeployedSentinelPatrol::disassemble(%data, %plyr, %obj)
{
	SentinelAI_RemPatrolPoint(%obj);
	parent::disassemble(%data, %plyr, %obj);
}
