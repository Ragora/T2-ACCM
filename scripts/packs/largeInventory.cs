//--------------------------------------------------------------------------
// Large Inventory Station
//
//
//--------------------------------------------------------------------------

datablock ShapeBaseImageData(LargeInventoryDeployableImage) {
   mass = 20;
   emap = true;
   shapeFile = "stackable1s.dts";
   item = LargeInventoryDeployable;
   mountPoint = 1;
   offset = "0 0 0";
   deployed = StationInventory;
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
   maxDeployDis = 5.0;
};

datablock ItemData(LargeInventoryDeployable)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "stackable1s.dts";
   mass = 5.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = true;
   image = "LargeInventoryDeployableImage";
   joint = "4.5 4.5 4.5";
   pickUpName = "a large inventory station pack";
   heatSignature = 0;
   emap = true;
};

function LargeInventoryDeployable::onPickup(%this, %obj, %shape, %amount)
{
   // created to prevent console errors
}

function LargeInventoryDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";
	%plyr.unMountImage(%slot);
	%plyr.decInventory(%item.item,1);
	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,-1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

   %deplObj = new (%className)()  //Inventory Station
   {
	dataBlock = StationInventory;
	position = %surfacePt;
	rotation = %rot;
	deployed = true;
   };
   %deplObj.setTransform(%item.surfacePt SPC %rot);

	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	addDSurface(%item.surface,%deplObj);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;

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

	// Adjust the trigger object
	adjustTrigger(%deplObj);

	// Power object
	checkPowerObject(%deplObj);

   return %deplObj;
}

function LargeInventoryDeployableImage::testNoTerrainFound(%item)
{
//return %item.surface.getClassName() !$= TerrainBlock;
}

function LargeInventoryDeployableImage::onMount(%data, %obj, %node) {
	displayPowerFreq(%obj);
}
