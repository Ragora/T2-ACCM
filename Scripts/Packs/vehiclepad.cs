//====================================== 
// made by dynablade 
//====================================== Deployable Vehicle Pad 
 

datablock StaticShapeData(DeployableVehicleStation) : StaticShapeDamageProfile 
{ 
className = Station; 
catagory = "Stations"; 
shapeFile = "Vehicle_pad_station.dts"; 
maxDamage = 7.5; 
destroyedLevel = 7.5; 
disabledLevel = 7.5; 
explosion = ShapeExplosion; 
expDmgRadius = 10.0; 
expDamage = 0.4; 
expImpulse = 1500.0; 
dynamicType = $TypeMasks::StationObjectType; 
isShielded = true; 
energyPerDamagePoint = 500; 
maxEnergy = 250; 
rechargeRate = 0.31; 
humSound = StationVehicleHumSound; 

cmdCategory = "Support"; 
cmdIcon = CMDVehicleStationIcon; 
cmdMiniIconName = "commander/MiniIcons/com_vehicle_pad_inventory"; 
targetTypeTag = 'Deployable Vehicle Station'; 

debrisShapeName = "debris_generic.dts"; 
debris = StationDebris; 
needsPower = true;
}; 

datablock StaticShapeData(DeployableVehiclePad) 
{ 
className = vpad; 
catagory = "Stations"; 
shapeFile = "Vehicle_pad.dts"; 
maxDamage = 7.5; 
destroyedLevel = 7.5; 
disabledLevel = 7.5; 
explosion = ShapeExplosion; 
expDmgRadius = 10.0; 
expDamage = 0.4; 
expImpulse = 1500.0; 
rechargeRate = 0.05; 
targetTypeTag = 'Deployable Vehicle Station'; 
needsPower = true;
}; 

datablock StaticShapeData(DeployableVehiclePad2)  : DeployableVehiclePad
{
className = vpad; 
shapeFile = "station_teleport.dts";
};




datablock StaticShapeData(DeployableVehiclePadBottom) : StaticShapeDamageProfile {
	className = "floor";
	shapeFile = "bmiscf.dts";

	maxDamage      = 4;
	destroyedLevel = 4;
	disabledLevel  = 3.5;

	isShielded = true;
	energyPerDamagePoint = 30;
	maxEnergy = 200;
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
	targetNameTag = 'Medium Blast floor';
	deployAmbientThread = true;
	debrisShapeName = "debris_generic_small.dts";
	debris = DeployableDebris;
	heatSignature = 0;
	needsPower = true;
};

datablock StaticShapeData(PotPipe) : DeployableVehiclePadBottom
{
shapeFile = "silver_pole.dts";
targetNameTag = 'Pot Powered';
targetTypeTag = 'Alloy forge';
};

datablock ParticleData(DVPADP)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;
   
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 0;

   spinRandomMin = 30.0;
   spinRandomMax = 30.0;
   windcoefficient = 0;
   textureName          = "skins/jetflare03";

   colors[0]     = "0.3 0.3 1.0 0.1";
   colors[1]     = "0.3 0.3 1.0 1";
   colors[2]     = "0.3 0.3 1.0 1";
   colors[3]     = "0.3 0.3 1.0 0.1";

   sizes[0]      = 5;
   sizes[1]      = 5;
   sizes[2]      = 5;
   sizes[3]      = 5;

   times[0]      = 0.25;
   times[1]      = 0.5;
   times[2]      = 0.75;
   times[3]      = 1;

};

datablock ParticleEmitterData(DVPADE)
{
   lifetimeMS        = 10;
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.01;
   velocityVariance = 0.0;
   ejectionoffset = 8;
   thetaMin         = 80.0;
   thetaMax         = 100.0;
	
   phiReferenceVel = "180";
   phiVariance = "5";
   orientParticles  = false;
   orientOnVelocity = false;

   particles = "DVPADP";
};

datablock ParticleData(SIGMAP)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.5;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 1000;

   spinRandomMin = -30.0;
   spinRandomMax = 30.0;
   windcoefficient = 0;
   textureName          = "skins/jetflare03";

   colors[0]     = "1 1 0 0"; //Wacky collors :P
   colors[1]     = "0 1 1 1";
   colors[2]     = "1 0 1 1";
   colors[3]     = "0 1 0 1";

   sizes[0]      = 5;
   sizes[1]      = 5;
   sizes[2]      = 5;
   sizes[3]      = 5;

   times[0]      = 0.5;
   times[1]      = 0.6;
   times[2]      = 0.8;
   times[3]      = 1;

};

datablock ParticleEmitterData(SIGMAE)
{
   lifetimeMS        = 10;
   ejectionPeriodMS = 50;
   periodVarianceMS = 0;

   ejectionVelocity = 1.0;
   velocityVariance = 0.5;
   ejectionoffset = 0.5;
   thetaMin         = 80.0;
   thetaMax         = 100.0;

   phiReferenceVel = "0";
   phiVariance = "360";
   orientParticles  = false;
   orientOnVelocity = false;

   particles = "SIGMAP";
};


function DeployableVehicleStation::onAdd(%this, %obj) 
{ 
   Parent::onAdd(%this, %obj); 

   %obj.setRechargeRate(%obj.getDatablock().rechargeRate); 
   %trigger = new Trigger() 
   { 
	dataBlock = stationTrigger; 
	polyhedron = "-0.75 0.75 0.0 1.5 0.0 0.0 0.0 -1.5 0.0 0.0 0.0 2.0"; 
   }; 
   MissionCleanup.add(%trigger); 
   %trigger.setTransform(%obj.getTransform()); 
   %trigger.station = %obj; 
   %obj.trigger = %trigger; 
} 

function DeployableVehicleStation::stationReady(%data, %obj) 
{ 
   // Make sure none of the other popup huds are active: 
   messageClient( %obj.triggeredBy.client, 'CloseHud', "", 'scoreScreen' ); 
   messageClient( %obj.triggeredBy.client, 'CloseHud', "", 'inventoryScreen' ); 

   //Display the Vehicle Station GUI 
   commandToClient(%obj.triggeredBy.client, 'StationVehicleShowHud'); 
} 

function DeployableVehicleStation::stationFinished(%data, %obj) 
{ 
   //Hide the Vehicle Station GUI 
   commandToClient(%obj.triggeredBy.client, 'StationVehicleHideHud'); 
} 

function DeployableVehicleStation::getSound(%data, %forward) 
{ 
   if(%forward) 
      return "StationVehicleAcitvateSound"; 
   else 
      return "StationVehicleDeactivateSound"; 
} 

function DeployableVehicleStation::setPlayersPosition(%data, %obj, %trigger, %colObj) 
{ 
   %vel = getWords(%colObj.getVelocity(), 0, 1) @ " 0"; 
   if((VectorLen(%vel) < 22) && (%obj.triggeredBy != %colObj)) 
   { 
      %posXY = getWords(%trigger.getTransform(),0 ,1); 
 	%posZ = getWord(%trigger.getTransform(), 2); 
	%rotZ = getWord(%obj.getTransform(), 5); 
	%angle = getWord(%obj.getTransform(), 6); 
	%angle += 3.141592654; 
	if(%angle > 6.283185308) 
	   %angle = %angle - 6.283185308; 
	%colObj.setvelocity("0 0 0"); 
	%colObj.setTransform(%posXY @ " " @ %posZ + 0.2 @ " " @ "0 0 " @ %rotZ @ " " @ %angle );//center player on object 
	return true; 
   } 
   return false; 
} 

function DeployableVehiclePad::onAdd(%this, %obj) 
{ 
   Parent::onAdd(%this, %obj); 

   %obj.ready = true; 
   %obj.setRechargeRate(%obj.getDatablock().rechargeRate); 
}

function DeployableVehiclePad2::onAdd(%this, %obj) 
{ 
   Parent::onAdd(%this, %obj); 

   %obj.ready = true; 
   %obj.setRechargeRate(%obj.getDatablock().rechargeRate); 
}


function GiveStation(%obj,%transform)
{
   %pos = getWords(%transform,0,2);
   %rot = getWords(%transform,3,5) SPC (getWord(%transform,6)/3.14*180);
   %sv = new StaticShape() 
   { 
	scale = "1 1 1"; 
	dataBlock = DeployableVehicleStation;
	lockCount = "0"; 
	homingCount = "0"; 
	team = %obj.team; 
	position = %pos; 
	rotation = %rot; 
   }; 

   %sv.setTransform(%transform);
   %sv.powerFreq = %obj.powerFreq;
   MissionCleanup.add(%sv); 
   //%sv.getDataBlock().gainPower(%sv); 
   //%obj.getDatablock().gainPower(%obj); 
   checkPowerObject(%obj);
   checkPowerObject(%sv);
   %sv.pad = %obj; 
   %obj.station = %sv; 
   %sv.trigger.mainObj = %obj; 
   %sv.trigger.disableObj = %sv; 
   adjustTrigger(%sv);

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Original Code in Station.cs
// Code made by Blnukem.
//------------------------------------------------------------------------------

   // Basic Restriction to Construction Vehicles in the Construction Gametype.
   if ($CurrentMissionType $= "Construction") {
      %sv.vehicle[HawkFlyer] = true;
      %sv.vehicle[Personelboat] = true;
   // Now to set the vehicle defaults for Non-Construction Gametypes.
   } else if ($CurrentMissionType !$= "Construction") {
      %sv.vehicle[boat] = true;
      %sv.vehicle[sub] = true;
      %sv.vehicle[Personelboat] = true;
      %sv.vehicle[scoutFlyer] = true;
      %sv.vehicle[AWACS] = true;
      %sv.vehicle[helicopter] = true;
      %sv.vehicle[HeavyChopper] = true;
   }
}

 function GiveStation2(%obj,%transform)
{
   %pos = getWords(%transform,0,2);
   %rot = getWords(%transform,3,5) SPC (getWord(%transform,6)/3.14*180);
   %sv = new StaticShape() 
   { 
	scale = "1 1 1"; 
	dataBlock = DeployableVehicleStation;
	lockCount = "0"; 
	homingCount = "0"; 
	team = %obj.team; 
	position = %pos; 
	rotation = %rot; 
   }; 

   %sv.setTransform(%transform);
   %sv.powerFreq = %obj.powerFreq;
   MissionCleanup.add(%sv); 
   checkPowerObject(%obj);
   checkPowerObject(%sv);
   %sv.pad = %obj; 
   %obj.station = %sv; 
   %sv.trigger.mainObj = %obj; 
   %sv.trigger.disableObj = %sv; 
   adjustTrigger(%sv);

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Original Code in Station.cs
// Code made by Blnukem.
//------------------------------------------------------------------------------

   // Basic Restriction to Construction Vehicles in the Construction Gametype.
   if ($CurrentMissionType $= "Construction") {
      %sv.vehicle[SuperScoutVehicle] = true;
      %sv.vehicle[HawkFlyer] = true;
      %sv.vehicle[mobileBasevehicle] = true;
      %sv.vehicle[hapcFlyer] = true;
      %sv.vehicle[bomberFlyer] = true;
   // Now to set the vehicle defaults for Non-Construction Gametypes.
   } else if ($CurrentMissionType !$= "Construction") {
      %sv.vehicle[mobileBasevehicle] = true;
      %sv.vehicle[scoutFlyer] = true;
      %sv.vehicle[hapcFlyer] = true;
      %sv.vehicle[CGTank] = true;
      %sv.vehicle[helicopter] = true;
      %sv.vehicle[StrikeFlyer] = true;
   }
}

function DeployableVehiclePad::onEndSequence(%data, %obj, %thread) 
{ 
   if(%thread == $ActivateThread) 
   { 
	%obj.ready = true; 
	%obj.stopThread($ActivateThread); 
   } 
   Parent::onEndSequence(%data, %obj, %thread); 
} 

function DeployableVehiclePad2::onEndSequence(%data, %obj, %thread) 
{ 
   if(%thread == $ActivateThread) 
   { 
	%obj.ready = true; 
	%obj.stopThread($ActivateThread); 
   } 
   Parent::onEndSequence(%data, %obj, %thread); 
}

function DeployableVehiclePad::gainPower(%data, %obj) 
{ 
   if (isObject(%obj.station))
    	%obj.station.setSelfPowered(); 
   Parent::gainPower(%data, %obj); 
} 

function DeployableVehiclePad2::gainPower(%data, %obj) 
{ 
   if (isObject(%obj.station))
	%obj.station.setSelfPowered(); 
   Parent::gainPower(%data, %obj); 
}

function DeployableVehiclePad::losePower(%data, %obj) 
{ 
   if (isObject(%obj.station))
	%obj.station.clearSelfPowered(); 
   Parent::losePower(%data, %obj); 
} 

function DeployableVehiclePad2::losePower(%data, %obj) 
{ 
   if (isObject(%obj.station))
	%obj.station.clearSelfPowered(); 
   Parent::losePower(%data, %obj); 
}

function DeployableVehiclePad::onDestroyed(%this, %obj, %prevState) 
{ 
   if (isObject(%obj))	
   	disassembleVehilcepad(%obj,%plyr);
   Parent::onDestroyed(%this, %obj, %prevState); 
   $TeamDeployedCount[%obj.team, VehiclePadPack]--; 
   %obj.schedule(500, "delete"); 
   %obj.station.schedule(500, "delete"); 
   %obj.back.schedule(500,"delete");
} 

function DeployableVehiclePad2::onDestroyed(%this, %obj, %prevState) 
{ 
   if (isObject(%obj))	
   	disassembleVehilcepad(%obj,%plyr);
   Parent::onDestroyed(%this, %obj, %prevState); 
   $TeamDeployedCount[%obj.team, VehiclePadPack]--; 
   %obj.schedule(500, "delete"); 
   %obj.station.schedule(500, "delete"); 
   %obj.back.schedule(500,"delete");
}



function DeployableVehicleStation::onDestroyed(%this, %obj, %prevState) 
{ 
   if (isObject(%obj.pad))	
   	disassembleVehilcepad(%obj.pad,%plyr);
   Parent::onDestroyed(%this, %obj, %prevState); 
   $TeamDeployedCount[%obj.team, VehiclePadPack]--; 
   %obj.schedule(500, "delete"); 
   %obj.station.schedule(500, "delete"); 
   %obj.back.schedule(500,"delete");
} 

function DeployableVehiclePadBottom::onDestroyed(%this, %obj, %prevState) 
{ 
   if (isObject(%obj.station))	
   	disassembleVehilcepad(%obj.station,%plyr);
   Parent::onDestroyed(%this, %obj, %prevState); 
   $TeamDeployedCount[%obj.team, VehiclePadPack]--; 
   %obj.schedule(500, "delete"); 
   %obj.station.schedule(500, "delete"); 
   %obj.back.schedule(500,"delete");
} 




datablock ShapeBaseImageData(VehiclePadPackImage)
{ 
   mass = 10; 
   emap = true; 

   shapeFile = "pack_deploy_inventory.dts"; 
   item = VehiclePadPack; 
   mountPoint = 1; 
   offset = "0 0 0"; 
   heatSignature = 0; 
   deployed = DeployableVehiclePad; 

   stateName[0] = "Idle"; 
   stateTransitionOnTriggerDown[0] = "Activate"; 

   stateName[1] = "Activate"; 
   stateScript[1] = "onActivate"; 
   stateTransitionOnTriggerUp[1] = "Idle"; 

   maxDepSlope = 360; 
   deploySound = StationDeploySound; 

   minDeployDis = 0; 
   maxDeployDis = 50.0; //meters from body 
}; 

datablock ItemData(VehiclePadPack) 
{ 
   className = Pack; 
   catagory = "Deployables"; 
   shapeFile = "pack_deploy_inventory.dts"; 
   mass = 3.0; 
   elasticity = 0.2; 
   friction = 0.6; 
   pickupRadius = 1; 
   rotate = false; 
   image = "VehiclePadPackImage"; 
   pickUpName = "a deployable vehicle pad"; 
   heatSignature = 0; 

   emap = true; 
}; 

function VehiclePadPackImage::onMount(%this, %obj, %slot)
{
   %this.imagemount = %obj;
   %obj.hasVehiclepad = 1;
}

function VehiclePadPackImage::onUnmount(%data,%obj,%node) 
{
   %obj.hasVehiclepad = "";
}

function VehiclePadPack::onPickup(%this, %pack, %player, %amount)
{
   %player.packcharge = %pack.charge;
   %player.lastvpad = %pack.vpad;
}


function VehiclePadPack::onThrow(%this,%pack,%player)
{
   %this.charge = %player.packcharge;
   %this.vpad = %player.lastvpad;
   %player.packcharge = "";
   %player.lastvpad = "";
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}



function VehiclePadPackImage::onDeploy(%item, %plyr, %slot)
{ 
   if (IsObject(%plyr.lastvpad) && IsObject(%plyr.lastvpad.station))
   	%plyr.packcharge = 0;
   if (IsObject(%plyr.lastvpad) && !IsObject(%plyr.lastvpad.station))
   	%plyr.packcharge = 1;
   if (!IsObject(%plyr.lastvpad))
   	%plyr.packcharge = 0;
  

   // take the deployable off the player's back and out of inventory 
   if (%plyr.packcharge == 1)
   {
   	%plyr.unmountImage(%slot); 
   	%plyr.decInventory(%item.item, 1); 
   	$TeamDeployedCount[%plyr.team, %item.item]++; 
   	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");
   	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
	   %item.surfaceNrm2 = vectorScale(%playerVector,1);
   	else
	   %item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

   	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
   	%vpad = %plyr.lastvpad;
   	if (%plyr.packset == 1)
   	   %deplObj = GiveStation(%vpad,%item.surfacePt SPC %rot);
   	else
   	   %deplObj = GiveStation2(%vpad,%item.surfacePt SPC %rot);
   	%deplObj.deploy(); 
   	addDSurface(%item.surface,%deplObj);
   	%deplObj.setOwner(%plyr);
   	%plyr.packcharge = "";
   	%plyr.lastvpad = "";
   	%vpad.isRemoved = 0;
   	%vpad.back.isRemoved = 0;
   	if (%vpad.style ==2)
      {
         %deplObj.emitter = CreateEmitter(%item.surfacePt,SIGMAE);
         %deplObj.emitter.setRotation(%deplObj.getRotation());
      }
   }
   else
   {
   	%dist = VectorSub(%item.surfacept,%plyr.getTransform());
   	%nrm = VirVec(%item.surface,%item.surfacenrm);
   	%img = VirVec(%item.surface,VectorNormalize(VectorCross(VectorCross(%item.surfacenrm,%dist),%item.surfacenrm)));   
   	%item.surfacenrm2 = realvec(%item.surface,VectorCross(%nrm,topvec(%img)));
   	// create the actual deployable 
   	%rot = %item.getInitialRotation(%plyr); 

   	if (%plyr.packset == 1)
         %block = DeployableVehiclePad2;
   	else
         %block = DeployableVehiclePad; 

   	%deplObj = new StaticShape() 
	{ 
	   dataBlock = %block;
	}; 
   	%back = new StaticShape() 
	{ 
	   dataBlock = DeployableVehiclePadBottom; 
	};         
      %back.needsfit = 1;
      %deplObj.needsfit = 1;
      %deplObj.style = %plyr.packset;
	%pos = getWords(%item.surface.getEdge(%nrm),0,2);
	%deplObj.setTransform(%pos SPC fullrot(%item.surfacenrm,%item.surfacenrm2)); 
      if (VectorDot(vAbs(VectorNormalize(topvec(%img))),%item.surface.getRealSize())== %item.surfacesizex)
      {
         %x= %item.surfacesizex;
         %y= %item.surfacesizey;
         %item.surfacesizex = %y;
         %item.surfacesizey = %x;
      }
	%deplObj.setRealSize(%item.surfacesizex SPC %item.surfacesizey SPC "1.5");
	%back.setTransform(%pos SPC fullrot(%item.surfacenrm,%item.surfacenrm2)); 
	%back.setRealSize(VectorMultiply(%deplObj.getRealSize(),"1 1 0.1"));
	if (%plyr.packset == 2)
      {
         %back.potpipes();
      }
	// %deplObj.setTransform(modifyTransform(%pos SPC %rot, "0 0 -1 0 0 0 0")); 
	%deplObj.back = %back;
	%back.station = %deplObj;
	// set the recharge rate right away 
	if(%deplObj.getDatablock().rechargeRate) 
	   %deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate); 

	// set team, owner, and handle 
	%deplObj.team = %plyr.client.Team; 
	%back.team = %plyr.client.Team; 
	%deplObj.setOwner(%plyr);
      %back.setOwner(%plyr);
	
	// set the sensor group if it needs one 
	if(%deplObj.getTarget() != -1) 
	   setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team); 

	// place the deployable in the MissionCleanup/Deployables group (AI reasons) 
	addToDeployGroup(%deplObj); 
      addToDeployGroup(%deplObj.back); 

	//let the AI know as well... 
	AIDeployObject(%plyr.client, %deplObj); 

	// play the deploy sound 
	serverPlay3D(%item.deploySound, %deplObj.getTransform()); 

	// increment the team count for this deployed object 
	%deplObj.getDatablock().onAdd(%deplObj); 	
	%deplObj.deploy(); 
	//%deplObj.setSelfPowered(); 
      %plyr.packcharge++;
      %plyr.lastvpad = %deplObj;        
      %deplObj.powerFreq = %plyr.powerFreq;
      %back.powerFreq = %plyr.powerFreq;
      checkPowerObject(%deplobj);
      checkPowerObject(%back);
      %deplObj.isRemoved = 1;
      %back.isRemoved = 1;
      schedule(6000,0,"FadePad",%deplObj,%plyr);
      addDSurface(%item.surface,%deplObj);
      addDSurface(%item.surface,%back);
   }
} 

function FadePad(%obj,%plyr)
{
   if (!Isobject(%obj.station))
   {
   	schedule(100,%obj,"disassembleVehilcepad",%obj,%plyr);
   }
}

function GameBase::PotPipes(%obj)
{
   %obj.pipe1 = new StaticShape()
   {
	dataBlock = PotPipe;
        scale = "0.5 0.5 0.5";
   };
   %obj.pipe2 = new StaticShape()
   {
	dataBlock = PotPipe;
        scale = "0.5 0.5 0.5";
   };
   %obj.pipe3 = new StaticShape()
   {
	dataBlock = PotPipe;
        scale = "0.5 0.5 0.5";
   };
   %obj.pipe4 = new StaticShape()
   {
	dataBlock = PotPipe;
        scale = "0.5 0.5 0.5";
   };
   %obj.pipe1.setTransform(%obj.getEdge("0.9 0.9 1") SPC %obj.getRotation());
   %obj.pipe2.setTransform(%obj.getEdge("0.9 -0.9 1")SPC %obj.getRotation());
   %obj.pipe3.setTransform(%obj.getEdge("-0.9 -0.9 1")SPC %obj.getRotation());
   %obj.pipe4.setTransform(%obj.getEdge("-0.9 0.9 1")SPC %obj.getRotation());
   %obj.pipe1.emitter = CreateEmitter(%obj.pipe1.getEdge("0 0 1"),HeavyDamageSmoke);
   %obj.pipe2.emitter = CreateEmitter(%obj.pipe2.getEdge("0 0 1"),HeavyDamageSmoke);
   %obj.pipe3.emitter = CreateEmitter(%obj.pipe3.getEdge("0 0 1"),HeavyDamageSmoke);
   %obj.pipe4.emitter = CreateEmitter(%obj.pipe4.getEdge("0 0 1"),HeavyDamageSmoke);
   addToDeployGroup(%obj.pipe1);
   addToDeployGroup(%obj.pipe2);
   addToDeployGroup(%obj.pipe3);
   addToDeployGroup(%obj.pipe4);
}

function GameBase::RemPotPipes(%obj)
{
   if (IsObject(%obj.pipe1))
   {
	%obj.pipe1.emitter.delete();
	%obj.pipe1.delete();
   }
   if (IsObject(%obj.pipe2))
   {
	%obj.pipe2.emitter.delete();
	%obj.pipe2.delete();
   }
   if (IsObject(%obj.pipe3))
   {
	%obj.pipe3.emitter.delete();
	%obj.pipe3.delete();
   }
   if (IsObject(%obj.pipe4))
   {
	%obj.pipe4.emitter.delete();
	%obj.pipe4.delete();
   }
}

function VehiclePadPackImage::testSurfaceTooNarrow(%item,%surface)
{
   %nrm = getWords(%item.surface,4,6);
   %mask = invFace(%nrm);
   %narrower = vectorMultiply(%mask,%item.surface.getRealSize());
   %fx = vectorNormalize(topVec(%narrower));
   %fy = VectorCross(%nrm,%fx);
   %sx = VectorLen(VectorMultiply(%fx,%item.surface.getRealSize()));
   %sy = VectorLen(VectorMultiply(%fy,%item.surface.getRealSize()));

   if (%sx < 17 || %sy < 17 || %sx < %sy*0.5 || %sy < %sx*0.5)
   {  
   	return !%item.imagemount.packcharge;
   }
   else
   {
   	%item.surfacesizex = %sx;
   	%item.surfacesizey = %sy;
   	return false; 
   }
}

function VehiclePadPackImage::testNoInteriorFound(%item,%surface)
{
   return !IsCubic(%item.surface) && !%item.imagemount.packcharge;
}

function DeployableVehiclePad::disassemble(%data,%plyr,%obj) 
{
   if (isObject(%obj))	
   	disassembleVehilcepad(%obj,%plyr);
   disassemble(%data,%plyr,%obj);
}

function DeployableVehiclePad2::disassemble(%data,%plyr,%obj) 
{
   if (isObject(%obj))	
   	disassembleVehilcepad(%obj,%plyr);
   disassemble(%data,%plyr,%obj);
}

function DeployableVehicleStation::disassemble(%data,%plyr,%obj) 
{
   if (isObject(%obj.pad))	
   	disassembleVehilcepad(%obj.pad,%plyr);
   disassemble(%data,%plyr,%obj);
}

function DeployableVehiclePadBottom::disassemble(%data,%plyr,%obj) 
{
   if (isObject(%obj.station))	
   	disassembleVehilcepad(%obj.station,%plyr);
   disassemble(%data,%plyr,%obj);
}

function PotPipe::disassemble(%data,%plyr,%obj)
{
   if (%obj.emitter)
    	%obj.emitter.delete();
   disassemble(%data,%plyr,%obj);
}

function disassembleVehilcepad(%station,%plyr)
{
   %station.back.rempotpipes();
   if (%station.station.emitter)
    	%station.station.emitter.delete();
   if (isObject(%station.station))
	disassemble("",%plyr,%station.station);

   if (isObject(%station.back))
	disassemble("",%plyr,%station.back);
   disassemble("",%plyr,%station);
}
