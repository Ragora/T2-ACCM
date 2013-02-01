//---------------------------------------------------------
// Deployable wall, Code by Parousia
//---------------------------------------------------------

datablock StaticShapeData(DeployedWall) : StaticShapeDamageProfile {
	className = "wall";
	shapeFile = "Bmiscf.dts"; // dmiscf.dts, alternate

	maxDamage      = 2;
	destroyedLevel = 2;
	disabledLevel  = 1.5;

	isShielded = true;
	energyPerDamagePoint = 60;
	maxEnergy = 100;
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
	targetNameTag = 'Light Blast Wall';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(WallDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "stackable1s.dts";
	item = WallDeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = DeployedWall;
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

datablock ItemData(WallDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "WallDeployableImage";
	pickUpName = "a light blast wall pack";
	heatSignature = 0;
	emap = true;
};

function WallDeployableImage::testObjectTooClose(%item) {
	return "";
}

function WallDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function WallDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function WallDeployableImage::onDeploy(%item, %plyr, %slot) {
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

	%scale = "0.5 8 40"; // Search range for total blast wall size.

	%mCenter = "0 0 -0.5";
	%pad = pad(%item.surfacePt SPC %item.surfaceNrm SPC %item.surfaceNrm2,%scale,%mCenter);
	%scale = getWords(%pad,0,2);

	%item.surfacePt = getWords(%pad,3,5);
	%rot = getWords(%pad,6,9);
	%offset = %plyr.packSet - 1;
	if (%plyr.packSet == 3) {
		%double = 1;
		%offset = 1;
	}

	%scale = vectorAdd(%scale,vectorScale("1.01 1.01" SPC %double,mAbs(%offset)));

	%pup = mCeil(getWord(%scale,0)/4); //4 = Avarage blast wall height.
	%pside = mCeil(getWord(%scale,1)/4); //4 = Avarage blast wall width.
	%upiece = getWord(%scale,0)/%pup;
	%spiece = getWord(%scale,1)/%pside;

	%scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);
	%dir = VectorNormalize(vectorSub(%item.surfacePt,%plyr.getposition()));
	%adjust = vectorNormalize(vectorProject(%dir,vectorCross(%item.surfaceNrm,%item.surfaceNrm2)));
//	%adjust = vectorNormalize(vectorCross(%item.surfaceNrm,%item.surfaceNrm2));

	if (%plyr.packSet == 3)
		%offset = Lev(vectorCouple(%dir,vectorCross(%item.surfaceNrm,%item.surfaceNrm2)));

	%adjust = vectorScale(%adjust,-0.5 * %offset);

	if ($Host::ExpertMode == 1 && %plyr.expertSet == 1) {
		for (%x = 0;%x < %pup;%x++){
			for (%y = 0;%y < %pside;%y++){
				%scale = %upiece SPC %spiece SPC 0.5 + %double;
				%scale = vectorMultiply(%scale,1/4 SPC 1/3 SPC 2);
				%deplObj = new (%className)() {
					dataBlock = %item.deployed;
					scale = %scale;
				};
				%up = vectorScale(%item.surfaceNrm,%upiece * (%x - (%pup / 2) + 0.5));
				%side = vectorScale(%item.surfaceNrm2,%spiece * (%y - (%pside / 2) + 0.5));
				%tadjust = vectorAdd(%up,vectorAdd(%side,%adjust));
				%deplObj.setTransform(vectorAdd(%item.surfacePt,%tadjust) SPC %rot);

				// [[Settings]]:

				%deplObj.grounded = %grounded;
				%deplObj.Needsfit = 1;
				addDSurface(%item.surface,%deplObj);

				// [Normal Stuff]]:

//				if(%deplObj.getDatablock().rechargeRate)
//					%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

				// set team, owner, and handle
				%deplObj.team = %plyr.client.Team;
				%deplObj.setOwner(%plyr);

				// set power frequency
				%deplObj.powerFreq = %plyr.powerFreq;

				// set the sensor group if it needs one
				if(%deplObj.getTarget() != -1)
					setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

				// place the deployable in the MissionCleanup/Deployables group (AI reasons)
				addToDeployGroup(%deplObj);

				// let the AI know as well...
				AIDeployObject(%plyr.client, %deplObj);

				// play the deploy sound
				serverPlay3D(%item.deploySound, %deplObj.getTransform());

				// increment the team count for this deployed object
				$TeamDeployedCount[%plyr.team, %item.item]++;

				%deplObj.deploy();
			}
		}
	}
	else {
		%deplObj = new (%className)() {
			dataBlock = %item.deployed;
			scale = %scale;
		};

		%deplObj.setTransform(vectorAdd(%item.surfacePt,%adjust) SPC %rot);

		// [[Settings]]:

		%deplObj.grounded = %grounded;
		%deplObj.Needsfit = 1;
		addDSurface(%item.surface,%deplObj);

		// [Normal Stuff]]:

//		if(%deplObj.getDatablock().rechargeRate)
//			%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

		// set team, owner, and handle
		%deplObj.team = %plyr.client.Team;
		%deplObj.setOwner(%plyr);

		// set power frequency
		%deplObj.powerFreq = %plyr.powerFreq;

		// set the sensor group if it needs one
		if(%deplObj.getTarget() != -1)
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
	}

	// Power object
	checkPowerObject(%deplObj);

	deployEffect(%deplObj,%item.surfacePt,%item.surfaceNrm,"pad");

	return %deplObj;
}

function DeployedWall::onDestroyed(%this, %obj, %prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, WallDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function WallDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasBlast = true; // set for blastcheck
	%obj.packSet = 0;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function WallDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasBlast = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}

function doorfunction(%player,%door)
{
%vec = VectorSub(%door,%player);
%dir = VectorNormalize(%vec);
%nrm = topVec(VirVec(%door,%dir));
}
