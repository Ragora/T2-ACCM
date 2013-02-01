//---------------------------------------------------------
// Deployable Decoration
//---------------------------------------------------------

datablock StaticShapeData(DeployedDecoration) : StaticShapeDamageProfile {
	className = "decoration";
	shapeFile = "banner_unity.dts";

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
	targetNameTag = 'Deployed Decoration';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
};

datablock StaticShapeData(DeployedDecoration0) : DeployedDecoration {
	shapeFile = "banner_unity.dts";
};

datablock StaticShapeData(DeployedDecoration1) : DeployedDecoration {
	shapeFile = "banner_strength.dts";
};

datablock StaticShapeData(DeployedDecoration2) : DeployedDecoration {
	shapeFile = "banner_honor.dts";
};

datablock StaticShapeData(DeployedDecoration3) : DeployedDecoration {
	shapeFile = "light_male_dead.dts";
};

datablock StaticShapeData(DeployedDecoration4) : DeployedDecoration {
	shapeFile = "medium_male_dead.dts";
};

datablock StaticShapeData(DeployedDecoration5) : DeployedDecoration {
	shapeFile = "heavy_male_dead.dts";
};

datablock StaticShapeData(DeployedDecoration6) : DeployedDecoration {
	shapeFile = "statue_base.dts";
};

datablock StaticShapeData(DeployedDecoration7) : DeployedDecoration {
	shapeFile = "statue_lmale.dts";
};

datablock StaticShapeData(DeployedDecoration8) : DeployedDecoration {
	shapeFile = "statue_lfemale.dts";
};

datablock StaticShapeData(DeployedDecoration9) : DeployedDecoration {
	shapeFile = "statue_hmale.dts";
};

datablock StaticShapeData(DeployedDecoration10) : DeployedDecoration {
	shapeFile = "vehicle_grav_tank_wreck.dts";
};

datablock StaticShapeData(DeployedDecoration11) : DeployedDecoration {
	shapeFile = "vehicle_air_scout_wreck.dts";
};

datablock StaticShapeData(DeployedDecoration12) : DeployedDecoration {
	shapeFile = "billboard_1.dts";
};

datablock StaticShapeData(DeployedDecoration13) : DeployedDecoration {
	shapeFile = "billboard_2.dts";
};

datablock StaticShapeData(DeployedDecoration14) : DeployedDecoration {
	shapeFile = "billboard_3.dts";
};

datablock StaticShapeData(DeployedDecoration15) : DeployedDecoration {
	shapeFile = "billboard_4.dts";
};

datablock StaticShapeData(DeployedDecoration16) : DeployedDecoration {
	shapeFile = "goal_panel.dts";
};

datablock ShapeBaseImageData(DecorationDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "statue_lfemale.dts"; // "stackable1s.dts";
	item = DecorationDeployable;
	mountPoint = 1;
	offset = "0 -0.6 -1.9";
	rotation = "0 0.1 1 180";
	deployed = DeployedDecoration;
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

datablock ItemData(DecorationDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "DecorationDeployableImage";
	pickUpName = "a decoration pack";
	heatSignature = 0;
	emap = true;
 };

function DecorationDeployableImage::testObjectTooClose(%item) {
	return "";
}

function DecorationDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function DecorationDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function DecorationDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1") {
		if (%plyr.packSet == 3 || %plyr.packSet == 5)
			%item.surfaceNrm2 = vectorScale(%playerVector,-1);
		else
			%item.surfaceNrm2 = %playerVector;
	}
	else {
		if (%plyr.packSet < 3)
			%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
		else {
			%item.surfaceNrm2 = %playerVector;
			if (%plyr.packSet == 3 || %plyr.packSet == 5)
				%item.surfaceNrm2 = vectorScale(%item.surfaceNrm2,-1);
		}
	}
	if (%item.surface.needsFit == 1) {
		if (%plyr.packSet > 5 && %plyr.packSet < 10 && %item.surface.getDataBlock().getName() $= "DeployedDecoration6") {
			%item.surfaceNrm2 = vectorCross(%item.surfaceNrm,realVec(%item.surface,"0 -1 0"));
		}
	}
	%item.surfaceNrm3 = vectorCross(%item.surfaceNrm,%item.surfaceNrm2);


	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed @ %plyr.packSet;
	};

	if (%plyr.packSet < 3) {
		%surfacePt2 = %item.surfacePt;
		%rot2 = %rot;
		%item.surfaceNrm2 = vectorScale(%item.surfaceNrm2,-1);
		%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm3,2.80));
		%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm,0.25));
		%rot =  rotAdd(%rot,"1 0 0" SPC $Pi / 2);
		%rot =  rotAdd(%rot,"0 1 0" SPC $Pi);
		%deplObj.lTarget = new StaticShape () {
			datablock = DeployedLTarget;
			scale = 2.5/4 SPC 5/3 SPC 0.15 * 2;
		};
		%deplObj.lTarget.setTransform(%surfacePt2 SPC %rot2);
		%deplObj.lTarget.lMain = %deplObj;
	}

	if (%plyr.packSet > 2 && %plyr.packSet < 6) {
		%surfacePt2 = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm,0.2));
		%rot2 = %rot;
		if (%plyr.packSet == 3) {
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm2,-0.14));
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm3,0.51));
		}
		else if (%plyr.packSet == 4) {
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm2,0.25));
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm3,-0.4));
		}
		else if (%plyr.packSet == 5) {
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm2,0.05));
			%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm3,0.4));
			%rot =  rotAdd(%rot,"0 0 -1" SPC $Pi / 4);
		}
		%deplObj.lTarget = new StaticShape () {
			datablock = DeployedLTarget;
			scale = 0.4/4 SPC 0.5/3 SPC 0.05 * 2;
		};
		%deplObj.lTarget.setTransform(%surfacePt2 SPC %rot2);
		%deplObj.lTarget.lMain = %deplObj;
	}

	if (%plyr.packSet == 11)
		%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm,-2));

	if (%plyr.packSet > 11 && %plyr.packSet < 16) {
		%surfacePt2 = %item.surfacePt;
		%rot2 = %rot;
		%item.surfaceNrm2 = vectorScale(%item.surfaceNrm2,-1);
		%item.surfacePt = vectorAdd(%item.surfacePt,vectorScale(%item.surfaceNrm,10.9));
		%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm,34));
		%surfacePt2 = vectorAdd(%surfacePt2,vectorScale(%item.surfaceNrm3,-1));
		%rot2 =  rotAdd(%rot,"1 0 0" SPC $Pi / 2);
		%deplObj.lTarget = new StaticShape () {
			datablock = DeployedLTarget;
			scale = 74/4 SPC 49/3 SPC 4;
		};
		%deplObj.lTarget.setTransform(%surfacePt2 SPC %rot2);
		%deplObj.lTarget.lMain = %deplObj;
	}

	// set orientation
	%deplObj.setTransform(%item.surfacePt SPC %rot);

	// set the recharge rate right away
	if (%deplObj.getDatablock().rechargeRate) {
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);
		%deplObj.lTarget.setRechargeRate(%deplObj.getDatablock().rechargeRate);
	}

	// [[Settings]]:
	%deplObj.needsFit = 1;

	// set team, owner, and handle
	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	if (%deplObj.lTarget) {
		%deplObj.lTarget.team = %plyr.client.Team;
		%deplObj.lTarget.setOwner(%plyr);
	}

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);
	if (%deplObj.lTarget)
		addToDeployGroup(%deplObj.lTarget);

	//let the AI know as well...
	AIDeployObject(%plyr.client,%deplObj);
	if (%deplObj.lTarget)
		AIDeployObject(%plyr.client,%deplObj.lTarget);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);
	if (%deplObj.lTarget)
		addDSurface(%deplObj,%deplObj.lTarget);

	// take the deployable off the player's back and out of inventory
	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	return %deplObj;
}

function DeployedDecoration::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, DecorationDeployable]--;
	remDSurface(%obj);
	%obj.schedule(500, "delete");
	if (isObject(%obj.lTarget))
		%obj.lTarget.schedule(500, "delete");
	fireBallExplode(%obj,1);
}

function DecorationDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasDecoration = true; // set for decorationcheck
	%obj.packSet = 0;
}

function DecorationDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasDecoration = "";
	%obj.packSet = 0;
}

function DeployedDecoration0::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration1::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration2::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration3::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration4::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration5::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration6::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration7::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration8::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration9::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration10::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration11::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration12::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration13::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration14::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration15::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}

function DeployedDecoration16::onDestroyed(%this,%obj,%prevState) {
	DeployedDecoration::onDestroyed(%this,%obj,%prevState);
}
