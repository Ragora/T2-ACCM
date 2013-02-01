//---------------------------------------------------------
// Deployable Light
//---------------------------------------------------------

%colourOn = 0.5;
%colourOff = 0.1;

%strobeColourOn = 1.0;
%strobeColourOff = 0.0;

datablock StaticShapeData(DeployedLightBase) : StaticShapeDamageProfile {
	className	= "lightbase";
	shapeFile	= "pack_deploy_sensor_motion.dts";

	maxDamage	= 0.5;
	destroyedLevel	= 0.5;
	disabledLevel	= 0.3;

	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion	= HandGrenadeExplosion;
	expDmgRadius	= 1.0;
	expDamage	= 0.05;
	expImpulse	= 200;

	dynamicType		= $TypeMasks::StaticShapeObjectType;
	deployedObject		= true;
	cmdCategory		= "DSupport";
	cmdIcon			= CMDSensorIcon;
	cmdMiniIconName		= "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag		= 'Deployed Light';
	deployAmbientThread	= true;
	debrisShapeName		= "debris_generic_small.dts";
	debris			= DeployableDebris;
	heatSignature		= 0;
	needsPower = true;
};

datablock ItemData(DeployedLight) {
	shapeFile	= "turret_muzzlepoint.dts";
	hasLight	= true;
	lightType	= "ConstantLight";
	lightColor	= "1.0 1.0 1.0 1.0";
	lightTime	= "1000";
	lightRadius	= "15";
};

// Constant

datablock ItemData(DeployedLight0) : DeployedLight {
	lightColor = %colourOn SPC %colourOn SPC %colourOn;
};

datablock ItemData(DeployedLight1) : DeployedLight {
	lightColor = %colourOn SPC %colourOff SPC %colourOff;
};

datablock ItemData(DeployedLight2) : DeployedLight {
	lightColor = %colourOff SPC %colourOn SPC %colourOff;
};

datablock ItemData(DeployedLight3) : DeployedLight {
	lightColor = %colourOff SPC %colourOff SPC %colourOn;
};

datablock ItemData(DeployedLight4) : DeployedLight {
	lightColor = %colourOff SPC %colourOn SPC %colourOn;
};

datablock ItemData(DeployedLight5) : DeployedLight {
	lightColor = %colourOn SPC %colourOff SPC %colourOn;
};

datablock ItemData(DeployedLight6) : DeployedLight {
	lightColor = %colourOn SPC %colourOn SPC %colourOff;
};

// Strobe

datablock ItemData(DeployedLight7) : DeployedLight {
	lightColor = %strobeColourOn SPC %strobeColourOn SPC %strobeColourOn;
	lightType = "PulsingLight";
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight8) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOn SPC %strobeColourOff SPC %strobeColourOff;
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight9) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOff SPC %strobeColourOn SPC %strobeColourOff;
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight10) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOff SPC %strobeColourOff SPC %strobeColourOn;
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight11) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOff SPC %strobeColourOn SPC %strobeColourOn;
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight12) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOn SPC %strobeColourOff SPC %strobeColourOn;
	lightTime = "50";
	lightRadius = "10";
};

datablock ItemData(DeployedLight13) : DeployedLight {
	lightType = "PulsingLight";
	lightColor = %strobeColourOn SPC %strobeColourOn SPC %strobeColourOff;
	lightTime = "50";
	lightRadius = "10";
};

datablock ShapeBaseImageData(LightDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = LightDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedLightBase;
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

datablock ItemData(LightDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "LightDeployableImage";
	pickUpName = "a light pack";
	heatSignature = 0;
	emap = true;
};

function LightDeployableImage::testObjectTooClose(%item) {
	return "";
}

function LightDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function LightDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function LightDeployableImage::onDeploy(%item, %plyr, %slot) {
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

	%deplObj.LgtColor = %plyr.packset;

	%deplObj.light = new Item() {
		datablock = DeployedLight @ %plyr.packSet;
		static = true;
	};

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	adjustLight(%deplObj);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	%deplObj.light.lightBase = %deplObj;
	%deplObj.lightPowerMode = %plyr.expertSet;

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

	return %deplObj;
}

function DeployedLightBase::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, LightDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	if (isObject(%obj.light))
		%obj.light.schedule(500, "delete");
}

function DeployedLightBase::disassemble(%data,%plyr,%obj) {
	if (isObject(%obj.light))
		%obj.light.delete();
	disassemble(%data,%plyr,%obj);
}

function adjustLight(%obj) {
	%obj.light.setTransform(vectorAdd(%obj.getPosition(),vectorScale(realVec(%obj,"0 0 1"),1)) SPC %obj.getRotation());
}

function LightDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasLight = true; // set for lightcheck
	%obj.packSet = 0;
}

function LightDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasLight = "";
	%obj.packSet = 0;
}

function DeployedLightBase::onGainPowerEnabled(%data,%obj) {
   if (%obj.lightPowerMode)
   {
      if(isObject(%obj.light))
         %obj.light.delete();
   } // have to put brackets here or `else` will be confused
   else
   {
      if (isObject(%obj.light))
         %obj.light.delete();
      %Obj.light = new Item() {
         datablock = DeployedLight @ %Obj.LgtColor;
         static = true;
      };
      // set orientation
      adjustLight(%Obj);
   }

   Parent::onGainPowerEnabled(%data,%obj);
}

function DeployedLightBase::onLosePowerDisabled(%data,%obj) {
   if (!%obj.lightPowerMode)
   {
      if(isObject(%obj.light))
         %obj.light.delete();
   } // have to put brackets here or `else` will be confused
   else
   {
      if (isObject(%obj.light))
         %obj.light.delete();
      %Obj.light = new Item() {
         datablock = DeployedLight @ %Obj.LgtColor;
         static = true;
      };
      // set orientation
      adjustLight(%Obj);
   }

   Parent::onLosePowerDisabled(%data,%obj);
}
