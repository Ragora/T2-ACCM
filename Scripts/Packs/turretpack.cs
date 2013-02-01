// turretpack.cs - turret pack
//

datablock ShapeBaseImageData(TurretDeployableImage)
{
   mass = 15;
   emap = true;

   shapeFile = "stackable1s.dts";
   item = TurretBasePack;
   mountPoint = 1;
   offset = "0 -0.2 0";

   minDeployDis = 0.5;
   maxDeployDis = 5.0;

   deployed = TurretDeployedBase;
   heatSignature = 0;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Idle";

   isLarge = true;
   maxDepSlope = 360;
   deploySound = StationDeploySound;
};

datablock ItemData(TurretBasePack)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "stackable1s.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "TurretDeployableImage";
   pickUpName = "a base turret pack";
   heatSignature = 0;

   computeCRC = true;
   emap = true;
};

datablock TurretData(TurretDeployedBase) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_base_large.dts";

   rechargeRate = 0.31;

   selfPower = true;

   needsPower = true;
   mass = 5.0;
   maxDamage = 2.25;
   destroyedLevel = 2.25;
   disabledLevel = 1.35;
   repairRate = 0;
   explosion = TurretExplosion;
   expDmgRadius = 15.0;
   expDamage = 0.7;
   expImpulse = 2000.0;

   deployedObject = true;

   thetaMin = 15;
   thetaMax = 140;
   //thetaNull = 90;

   isShielded = false;
   energyPerDamagePoint = 50;
   maxEnergy = 150;

   humSound = SensorHumSound;
   heatSignature = 1;
   pausePowerThread = true;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Deployed Base';
   targetTypeTag = 'Turret';
   sensorData = TurretBaseSensorObj;
   sensorRadius = TurretBaseSensorObj.detectRadius;
   sensorColor = "0 212 45";

   firstPersonOnly = true;

   debrisShapeName = "debris_generic.dts";
   debris = TurretDebris;
};

function TurretDeployableImage::onDeploy(%item, %plyr, %slot)
{
%deplObj = Parent::onDeploy(%item, %plyr, %slot);
%origBarrel = %item.item.origBarrel;
if(%origBarrel !$= "")
{
%deplObj.mountImage(%origBarrel, 0, false);
%item.item.origBarrel = "";
}
%playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");

%item.surfacenrm = VectorNormalize(%item.surfacenrm);
//echo(%playervector);
if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

%deplObj.setTransform(%item.surfacePt SPC %rot);
//%deplObj.setSelfPowered();
//%deplObj.playThread($PowerThread,"Power");

addDSurface(%item.surface,%deplObj);
addToDeployGroup(%deplObj);
%deplObj.powerFreq = %plyr.powerFreq;
%deplObj.team = %plyr.team;
checkPowerObject(%deplObj);
}

function TurretDeployableImage::onMount(%data, %obj, %node) {
	displayPowerFreq(%obj);
}

function TurretBasePack::onPickup(%this, %obj, %shape, %amount)
{
   // This is here to prevent console spam
}
