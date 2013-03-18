datablock ShapeBaseImageData(SentryTurretDeployableImage)
{
   mass = 15;
   emap = true;

   shapeFile = "stackable1s.dts";
   item = TurretSentryPack;
   mountPoint = 1;
   offset = "0 -0.2 0";

   minDeployDis = 0.5;
   maxDeployDis = 5.0;

   deployed = TurretDeployedSentry;
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

datablock ItemData(TurretSentryPack)
{
   className = Pack;
   catagory = "Deployables";
   shapeFile = "stackable1s.dts";
   mass = 3.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 1;
   rotate = false;
   image = "SentryTurretDeployableImage";
   pickUpName = "a sentry turret pack";
   heatSignature = 0;

   computeCRC = true;
   emap = true;
};

datablock TurretData(TurretDeployedSentry) : TurretDamageProfile
{
   className = DeployedTurret;
   shapeFile = "turret_sentry.dts";

   rechargeRate = 0.40;

   selfPower = false;

   needsPower = true;
   mass = 5.0;
   maxDamage = 1.2;
   destroyedLevel = 1.2;
   disabledLevel = 0.84;
   repairRate = 0;
   explosion = ShapeExplosion;
   expDmgRadius = 5.0;
   expDamage = 0.4;
   expImpulse = 1000.0;

   deployedObject = true;

   thetaMin = 89;
   thetaMax = 175;

   isShielded = true;
   energyPerDamagePoint = 100;
   maxEnergy = 150;

   heatSignature = 1;

   canControl = true;
   cmdCategory = "DTactical";
   cmdIcon = CMDTurretIcon;
   cmdMiniIconName = "commander/MiniIcons/com_turret_grey";
   targetNameTag = 'Deployed Sentry';
   targetTypeTag = 'Turret';
   sensorData = SentryMotionSensor;
   sensorRadius = SentryMotionSensor.detectRadius;
   sensorColor = "9 136 255";

   firstPersonOnly = true;
};

function SentryTurretDeployableImage::onDeploy(%item, %plyr, %slot)
{
   %deplObj = Parent::onDeploy(%item, %plyr, %slot);

   %deplObj.mountImage(SentryTurretBarrel, 0, false);

   %playerVector = vectorNormalize(getWord(%plyr.getEyeVector(),1) SPC -1 * getWord(%plyr.getEyeVector(),0) SPC "0");

   %item.surfacenrm = VectorNormalize(%item.surfacenrm);

   if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = vectorScale(%playerVector,1);
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

   %deplObj.setTransform(%item.surfacePt SPC %rot);

   MTZAxisReverse(%plyr.client, %deplObj); // Super cheap hack. Makes things REALLY easy, though.

   %realVec = realVec(%deplObj, "0 0 1");
   %toAdd = VectorScale(%realvec, -0.6);
   %newPos = VectorAdd(posFromTransform(%deplObj.getTransform()), %toAdd);
   %deplObj.setTransform(%newPos SPC %deplObj.getRotation());

   addDSurface(%item.surface,%deplObj);
   addToDeployGroup(%deplObj);

   %deplObj.powerFreq = %plyr.powerFreq;
   %deplObj.team = %plyr.team;

   checkPowerObject(%deplObj);
}

function SentryTurretDeployableImage::onMount(%data, %obj, %node)
{
	displayPowerFreq(%obj);
}

function TurretSentryPack::onPickup(%this, %obj, %shape, %amount)
{
   // No more spam!
}
