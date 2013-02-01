//--------------------------------------------------------------------------
// Jumpad
//--------------------------------------------------------------------------

datablock StaticShapeData(DeployedJumpad) : StaticShapeDamageProfile {
	className = "jumpad";
	shapeFile = "nexusbase.dts"; // dmiscf.dts, alternate
	maxDamage = 2.0;
	destroyedLevel = 2.0;
	disabledLevel = 2.0;
	mass = 1.2;
	elasticity = 0.1;
	friction = 0.9;
	collideable = 1;
	pickupRadius = 1;
	sticky=false;

	impulse = 5000;

	hasLight = true;
	lightType = "PulsingLight";
	lightColor = "0.1 0.8 0.8 1.0";
	lightTime = "100";
	lightRadius = "3";

	explosion      = HandGrenadeExplosion;
	expDmgRadius = 3.0;
	expDamage = 0.1;
	expImpulse = 200.0;
	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";

	targetNameTag = 'Jump';
	targetTypeTag = 'Pad';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
};

datablock ShapeBaseImageData(JumpadDeployableImage) {
	mass = 10;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = JumpadDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedJumpad;
	heatSignature = 0;
	collideable = 1;
	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360; // 30
	deploySound = ItemPickupSound;

	minDeployDis = 0.5;
	maxDeployDis = 5.0;
};

datablock ItemData(JumpadDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "JumpadDeployableImage";
	pickUpName = "a jump pad pack";
	heatSignature = 0;
	emap = true;
};

function JumpadDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function JumpadDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

	%impulse = firstWord($packSetting["jumpad",%plyr.packSet]);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
		scale = "1 1 2";
	};

	// set impulse (jump pad strength)
	%deplObj.impulse = %impulse;

	// set orientation
	%deplObj.setDeployRotation(getWords(%item.surfacePt, 0, 1) SPC getWord(%item.surfacePt, 2) + 0.1, %item.surfaceNrm);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client, %deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);
	return %deplObj;
}

function DeployedJumpad::onCollision(%data,%obj,%col) {
	// TODO - update escape pod
	if (%col.getClassName() !$= "Player" && %col.getDataBlock().getName() !$= "EscapePodVehicle")
		return; // Only boost players
	if (%obj.team == %col.team) {
		%vel = %col.getVelocity();
		%vec = realVec(%obj,"0 0 1");
		%position = getWords(%col.getTransform(), 0, 2);
//		%impulseVec = vectorScale(%vec,1000); // Jump clear of the pad
//		%col.applyImpulse(%position, %impulseVec);
		%col.playAudio(0, MortarFireSound);
		%impulseVec = vectorScale(%vec,%obj.impulse);
//		%col.schedule(50, "applyImpulse", %position, %impulseVec);
		%col.applyImpulse(%position, %impulseVec);
	}
}

function DeployedJumpad::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, JumpadDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	fireBallExplode(%obj,1);
}

function JumpadDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasJumpad = true; // set for jumpadcheck
	%obj.packSet = 0;
}

function JumpadDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasJumpad = "";
	%obj.packSet = 0;
}
