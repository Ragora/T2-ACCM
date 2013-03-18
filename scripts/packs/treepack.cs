//---------------------------------------------------------
// Deployable Tree, original code by Parousia
//---------------------------------------------------------

datablock StaticShapeData(DeployedTree) : StaticShapeDamageProfile {
	className = "tree";
	shapeFile = "borg19.dts";

	maxDamage      = 0.5;
	destroyedLevel = 0.5;
	disabledLevel  = 0.3;

	explosion      = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage = 0.05;
	expImpulse = 200;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Deployed Tree';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
};

datablock StaticShapeData(DeployedTree0) : DeployedTree {
	shapeFile = "borg16.dts";
};

datablock StaticShapeData(DeployedTree1) : DeployedTree {
	shapeFile = "borg17.dts";
};

datablock StaticShapeData(DeployedTree2) : DeployedTree {
	shapeFile = "borg18.dts";
};

datablock StaticShapeData(DeployedTree3) : DeployedTree {
	shapeFile = "borg19.dts";
};

datablock StaticShapeData(DeployedTree4) : DeployedTree {
	shapeFile = "dorg15.dts";
};

datablock StaticShapeData(DeployedTree5) : DeployedTree {
	shapeFile = "dorg16.dts";
};

datablock StaticShapeData(DeployedTree6) : DeployedTree {
	shapeFile = "dorg17.dts";
};

datablock StaticShapeData(DeployedTree7) : DeployedTree {
	shapeFile = "dorg18.dts";
};

datablock StaticShapeData(DeployedTree8) : DeployedTree {
	shapeFile = "dorg19.dts";
};

datablock StaticShapeData(DeployedTree9) : DeployedTree {
	shapeFile = "porg3.dts";
};

datablock StaticShapeData(DeployedTree10) : DeployedTree {
	shapeFile = "porg6.dts";
};

datablock StaticShapeData(DeployedTree11) : DeployedTree {
	shapeFile = "sorg20.dts";
};

datablock StaticShapeData(DeployedTree12) : DeployedTree {
	shapeFile = "sorg22.dts";
};

datablock StaticShapeData(DeployedTree13) : DeployedTree {
	shapeFile = "xorg3.dts";
};

datablock ShapeBaseImageData(TreeDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = TreeDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedTree;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	isLarge = true;
	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.5;
	maxDeployDis = 50.0;
};

datablock ItemData(TreeDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "TreeDeployableImage";
	pickUpName = "a tree pack";
	heatSignature = 0;
	emap = true;
 };

function TreeDeployableImage::testObjectTooClose(%item) {
	return "";
}

function TreeDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function TreeDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function TreeDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");
	%item.surfaceNrm2 = %playerVector;
	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed @ %plyr.packSet;
		scale = vectorScale("1 1 1",$expertSetting["tree",%plyr.expertSet]);
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

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
	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	return %deplObj;
}

function DeployedTree::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, TreeDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
}

function TreeDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasTree = true; // set for treecheck
	%obj.packSet = 0;
	%obj.expertSet = 5;
}

function TreeDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasTree = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}

function DeployedTree0::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree1::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree2::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree3::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree4::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree5::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree6::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree7::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree8::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree9::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree10::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree11::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree12::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}

function DeployedTree13::onDestroyed(%this,%obj,%prevState) {
	DeployedTree::onDestroyed(%this,%obj,%prevState);
}
