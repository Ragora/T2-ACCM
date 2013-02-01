//---------------------------------------------------------
// Deployable Crates
//---------------------------------------------------------

datablock StaticShapeData(DeployedCrate) : StaticShapeDamageProfile {
	className = "crate";
	shapeFile = "stackable3s.dts";

	maxDamage      = 4.5;
	destroyedLevel = 4.5;
	disabledLevel  = 4.0;

	explosion      = HandGrenadeExplosion;
	expDmgRadius = 1.0;
	expDamage = 0.3;
	expImpulse = 200;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Deployed Crate';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
};

datablock StaticShapeData(DeployedCrate0) : DeployedCrate {
	shapeFile = "stackable1s.dts";
};

datablock StaticShapeData(DeployedCrate1) : DeployedCrate {
	shapeFile = "stackable1m.dts";
};

datablock StaticShapeData(DeployedCrate2) : DeployedCrate {
	shapeFile = "stackable1l.dts";
};

datablock StaticShapeData(DeployedCrate3) : DeployedCrate {
	shapeFile = "stackable2s.dts";
};

datablock StaticShapeData(DeployedCrate4) : DeployedCrate {
	shapeFile = "stackable2m.dts";
};

datablock StaticShapeData(DeployedCrate5) : DeployedCrate {
	shapeFile = "stackable2l.dts";
};

datablock StaticShapeData(DeployedCrate6) : DeployedCrate {
	shapeFile = "stackable3s.dts";
};

datablock StaticShapeData(DeployedCrate7) : DeployedCrate {
	shapeFile = "stackable3m.dts";
};

datablock StaticShapeData(DeployedCrate8) : DeployedCrate {
	shapeFile = "stackable3l.dts";
};

datablock StaticShapeData(DeployedCrate9) : DeployedCrate {
	shapeFile = "stackable4m.dts";
};

datablock StaticShapeData(DeployedCrate10) : DeployedCrate {
	shapeFile = "stackable4l.dts";
};

datablock StaticShapeData(DeployedCrate11) : DeployedCrate {
	shapeFile = "stackable5m.dts";
};

datablock StaticShapeData(DeployedCrate12) : DeployedCrate {
	shapeFile = "stackable5l.dts";
};

datablock ShapeBaseImageData(CrateDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = CrateDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedCrate;
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

datablock ItemData(CrateDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "CrateDeployableImage";
	pickUpName = "a crate pack";
	heatSignature = 0;
	emap = true;
 };

function CrateDeployableImage::testObjectTooClose(%item) {
	return "";
}

function CrateDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function CrateDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function CrateDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");
	%item.surfaceNrm2 = %playerVector;
	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed @ %plyr.packSet;
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

function DeployedCrate::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, CrateDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
}

function CrateDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasCrate = true; // set for cratecheck
	%obj.packSet = 0;
}

function CrateDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasCrate = "";
	%obj.packSet = 0;
}

function DeployedCrate0::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate1::onDestroyed(%this,%obj,%prevState) {
   if (%obj.isRemoved)
	return;
   %obj.isRemoved = true;
   Parent::onDestroyed(%this,%obj,%prevState);
   $TeamDeployedCount[%obj.team, CrateDeployable]--;
   remDSurface(%obj);
   %obj.schedule(500, "delete");
   %pos = %obj.getposition();
   %rot = %obj.getrotation();
   %team = %obj.team;
   schedule(501, 0, "MakeFCrate", %pos, %rot, %team);
}

function DeployedCrate2::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate3::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate4::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate5::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate6::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate7::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate8::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate9::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate10::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate11::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function DeployedCrate12::onDestroyed(%this,%obj,%prevState) {
	DeployedCrate::onDestroyed(%this,%obj,%prevState);
}

function MakeFCrate(%pos, %rot, %team){
   %pos = vectorAdd(%pos, "0 0 0.1");
   %Fcrate = new WheeledVehicle() 
   { 
      dataBlock    = VehicleTestCrate1; 
      position     = %pos; 
      rotation     = %rot; 
      team         = %team;  
   }; 
   MissionCleanUp.add(%Fcrate); 
   %Fcrate.setTransform(%pos @ " " @ %rot); 
   %Fcrate.schedule(60000, delete);
}

