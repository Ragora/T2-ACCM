//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Deployable Waypoint - Made by Dark Dragon DX
//------------------------------------------------------------------------------

datablock StaticShapeData(DeployedWaypoint) : StaticShapeDamageProfile {
	className = "Waypoint";
	shapeFile = "camera.dts";

	maxDamage      = 5.0;
	destroyedLevel = 5.0;
	disabledLevel  = 2.5;

	isShielded = true;
	energyPerDamagePoint = 240;
	maxEnergy = 50;
	rechargeRate = 0.25;

	explosion    = HandGrenadeExplosion;
	expDmgRadius = 5.0;
	expDamage    = 0.5;
	expImpulse   = 200.0;

	dynamicType = $TypeMasks::StaticShapeObjectType;
	deployedObject = true;
	cmdCategory = "DSupport";
	cmdIcon = CMDSensorIcon;
	cmdMiniIconName = "commander/MiniIcons/com_deploymotionsensor";
	targetNameTag = 'Waypoint Pack';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock ShapeBaseImageData(WaypointDeployableImage) {
 mass = 1;
	emap = true;
 shapeFile = "stackable1s.dts";
	item = Waypointdeployable;
	mountPoint = 1;
	offset = "0 0 0";
	deployed = Deployedwaypoint;
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

datablock ItemData(WaypointDeployable) {
	className = Pack;
	catagory = "Deployables";
 shapeFile = "stackable1s.dts";
 mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	joint = "1 1 1";
	rotate = true;
	image = "WaypointDeployableImage";
	pickUpName = "a waypoint pack";
	heatSignature = 0;
	emap = true;
};

function WaypointDeployableImage::testObjectTooClose(%item) {
	return "";
}

function WaypointDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function WaypointDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function WaypointDeployableImage::onDeploy(%item, %plyr, %slot) {
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

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%scale = getWords($packSetting["mspine",%plyr.packSet],0,2);

	%mod = 0.5;
 %rndcolor = getrandom(0,5);

%deplObj = new (%className)() {
		dataBlock = DeployedWaypoint;
       team = %plyr.team;
		scale = "1 1 1";
	};
%deplObj.wp = new  (WayPoint)(){
         dataBlock        = WayPointMarker;
         name             = %plyr.client.namebase@"'s Waypoint";
         team = %plyr.team;
         scale            = "0.1 0.1 0.1";
       };
      MissionCleanup.add(%deplObj.wp);

  %mod = 0;
  %h1=vectorAdd(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm),%mod));
  %deplObj.wp.setTransform(%h1 SPC %rot);
   %deplObj.setTransform(%h1 SPC %rot);
   	%deplObj.team = %plyr.client.team;
		%deplObj.setOwner(%plyr);
  	addToDeployGroup(%deplObj);
   	AIDeployObject(%plyr.client, %deplObj);
      $TeamDeployedCount[%plyr.team, %item.item]++;
      %deplObj.deploy();
         	serverPlay3D(%item.deploySound, %deplObj.getTransform());
           %deplObj.grounded = %grounded;
           %deplObj.needsFit = 1;
            if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);
   %deplObj.deploy();
  %plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);
 return %deplObj;

}

function deployedWaypoint::onDestroyed(%this, %obj, %prevState) {
    if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this, %obj, %prevState);
	$TeamDeployedCount[%obj.team, waypointdeployable]--;
	remDSurface(%obj);
	%obj.schedule(500,"delete");
 	%obj.wp.schedule(500,"delete");
	cascade(%obj);
	fireBallExplode(%obj,1);
}

function deployedwaypoint::disassemble(%data, %plyr, %obj){
   disassemble(%data,%plyr,%obj);
   %obj.wp.schedule(500, "delete");
}
