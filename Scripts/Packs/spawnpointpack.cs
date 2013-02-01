//---------------------------------------------------------
// Deployable Telepad
//---------------------------------------------------------
// Thanks to Krash for the idea to make spawn points power things within a small radius

datablock ShapeBaseImageData(SpawnPointImage) {
	mass = 15;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = SpawnPointPack;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = SpawnPoint;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = StationDeploySound;

	minDeployDis = 0.5;
	maxDeployDis = 5.0;
};

datablock ItemData(SpawnPointPack) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 3.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = false;
	image = "SpawnPointImage";
	pickUpName = "a SpawnPoint pack";
	heatSignature = 0;
        joint = "2 2 2";
	computeCRC = true;
	emap = true;
};

datablock StaticShapeData(SpawnPoint) : StaticShapeDamageProfile {
	className = "Generator";
	shapeFile = "station_teleport.dts";

	maxDamage = 5.00;
	destroyedLevel = 5.00;
	disabledLevel = 4.0;

	isShielded = true;
	energyPerDamagePoint = 150;
	maxEnergy = 150;
	rechargeRate = 1;

	explosion = ShapeExplosion; // DeployablesExplosion;
	expDmgRadius = 18.0;
	expDamage = 0.1;
	expImpulse = 200.0;

	dynamicType = $TypeMasks::StationObjectType;
	deployedObject = true;
	cmdCategory = "Support";
	cmdIcon = CMDSwitchIcon;
	cmdMiniIconName = "commander/MiniIcons/com_switch_grey";
	targetNameTag = 'Deployed';
	targetTypeTag = 'Spawn Point';

	debrisShapeName = "debris_generic.dts";
	debris = DeployableDebris;

	heatSignature = 0;
//	needsPower = true;

//	humSound = SensorHumSound;
//	pausePowerThread = true;
	sensorData = TelePadBaseSensorObj;
	sensorRadius = TelePadBaseSensorObj.detectRadius;
	sensorColor = "0 212 45";
	firstPersonOnly = true;

	lightType = "PulsingLight";
	lightColor = "0 1 0 1";
	lightTime = 1200;
	lightRadius = 6;
		powerRadius = 25;
};

function SpawnPoint::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
//	checkEndTCCMGame(%obj.team);
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team,SpawnPoint]--;
	%obj.isRemoved = true;
	remDSurface(%obj);
	%obj.active = 0;
	
	remTeamSpawnPoint(%obj);
	
	if(!$Host::InvincibleDeployables)
		%obj.schedule(500,"delete");
}

function SpawnPoint::disassemble(%data,%plyr,%obj) {
//	checkEndTCCMGame(%obj.team);
	remTeamSpawnPoint(%obj);
	parent::disassemble(%data, %plyr, %obj);
}

function SpawnPointPack::onPickup(%this, %obj, %shape, %amount)
{
   // Thou shalt not spam.
}

function SpawnPoint::onGainPowerEnabled(%data,%obj) {
	%obj.active = 1;
	parent::onGainPowerEnabled(%data, %obj); // Eolk - call parent
}

function SpawnPoint::onLosePowerDisabled(%data,%obj) {
	%obj.active = 0;
	parent::onLosePowerDisabled(%data, %obj); // Eolk - call parent
}

function SpawnPointImage::onDeploy(%item,%plyr,%slot) {
	%className = "StaticShape";
	%playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");
	%item.surfaceNrm2 = %playerVector;
	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,-1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%deplObj = new (%className)() {
		dataBlock = SpawnPoint;
		scale = "1 1 1";
		deployed = true;
	};
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);
	%deplObj.powerFreq = %plyr.powerFreq;
	setTargetName(%deplObj.target, addTaggedString("Frequency" SPC %deplObj.powerFreq));
	%deplObj.setSelfPowered();
	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(),%plyr.client.team);
	addToDeployGroup(%deplObj);
	AIDeployObject(%plyr.client,%deplObj);
	addDSurface(%item.surface,%deplObj);
	serverPlay3D(%item.deploySound,%deplObj.getTransform());
	$TeamDeployedCount[%plyr.team,%item.item]++;
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item,1);

	addTeamSpawnPoint(%deplObj);

	if(%plyr.client.SPname $= "")
	   %piece.name = getWords(%position,0,1);
	else
	   %piece.name = %plyr.client.SPname;
	%piece.active = 0;

	setTargetName(%deplObj.target,addTaggedString(%deplObj.name));

	$PowerList = listAdd($PowerList, %deplObj, -1);
	return %deplObj;
}

function SpawnPointImage::onMount(%data,%obj,%node) {
	%obj.hasGen = true;
	displayPowerFreq(%obj);
}

function SpawnPointImage::onUnmount(%data,%obj,%node) {
	%obj.hasGen = "";
}

function addTeamSpawnPoint(%obj)
{
	if(%obj.getDatablock().getName() !$= "SpawnPoint")
		return;

	if($teamSPs[%obj.team] $= "")
		$TeamSPs[%obj.team] = 0;
	$teamSP[%obj.team,$teamSPs[%obj.team]] = %obj;
	$teamSPs[%obj.team]++;
}

function remTeamSpawnPoint(%obj)
{
	if(%obj.getDatablock().getName() !$= "SpawnPoint")
		return;

	for(%i = 0; %i < $teamSPs[%obj.team]; %i++){
		if($teamSP[%obj.team,%i] $= %obj)
		%spawn = %i;
	}

	if(%spawn < ($teamSPs[%obj.team] - 1)){
		$teamSP[%obj.team,%spawn] = $teamSP[%obj.team,($teamSPs[%obj.team] - 1)];
		$teamSP[%obj.team,($teamSPs[%obj.team] - 1)] = "";
	}

	$teamSPs[%obj.team]--;
}
