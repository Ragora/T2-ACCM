//**************************************************************
// Drop Pod
//**************************************************************

datablock AudioProfile(DropPodThrustSound)
{
   filename    = "fx/vehicles/shrike_boost.wav";
   description = AudioDefault3d;
   preload = true;
   effect = ScoutFlyerThrustEffect;
};

datablock WheeledVehicleData(DropPod) : MPBDamageProfile
{
   spawnOffset = "0 0 1.0";
   renderWhenDestroyed = false;
   canControl = true;
   catagory = "Vehicles";
   shapeFile = "stackable2l.dts";
   multipassenger = false;
   computeCRC = true;

   debrisShapeName = "stackable2l.dts";
   debris = GShapeDebris;

   drag = 0.0;
   density = 20.0;

   mountPose[0] = sitting;
   numMountPoints = 1;
   isProtectedMountPoint[0] = true;

   cameraMaxDist = 20;
   cameraOffset = 6;
   cameraLag = 1.5;
   explosionDamage = 0.0;
   explosionRadius = 0.0;

   maxSteeringAngle = 0.3;  // 20 deg.

   // Used to test if the station can deploy
   stationPoints[1] = "-2.3 -7.38703 -0.65";
   stationPoints[2] = "-2.3 -11.8 -0.65";
   stationPoints[3] = "0 -7.38703 -0.65";
   stationPoints[4] = "0 -11.8 -0.65";
   stationPoints[5] = "2.3 -7.38703 -0.65";
   stationPoints[6] = "2.3 -11.8 -0.65";

   // Rigid Body
   mass = 1000;
   bodyFriction = 0.8;
   bodyRestitution = 0.5;
   minRollSpeed = 3;
   gyroForce = 400;
   gyroDamping = 0.3;
   stabilizerForce = 10;
   minDrag = 10;
   softImpactSpeed = 15;       // Play SoftImpact Sound
   hardImpactSpeed = 25;      // Play HardImpact Sound

   // Ground Impact Damage (uses DamageType::Ground)
   minImpactSpeed = 24;
   speedDamageScale = 0.025;

   // Object Impact Damage (uses DamageType::Impact)
   collDamageThresholdVel = 15;
   collDamageMultiplier   = 0.03;

   // Engine
   engineTorque = 0 * 745;
   breakTorque = 0 * 745;
   maxWheelSpeed = 10;

   // Springs
   springForce = 8000;
   springDamping = 1300;
   antiSwayForce = 6000;
   staticLoadScale = 2;

   // Tires
   tireRadius = 1.6;
   tireFriction = 10.0;
   tireRestitution = 0.5;
   tireLateralForce = 3000;
   tireLateralDamping = 400;
   tireLateralRelaxation = 1;
   tireLongitudinalForce = 12000;
   tireLongitudinalDamping = 600;
   tireLongitudinalRelaxation = 1;
   tireEmitter = TireEmitter;

   //
   maxDamage = 2.0;
   destroyedLevel = 2.0;

   HDAddMassLevel = 1.5;
   HDMassImage = WCHDMassImage;

   isShielded = false;
   energyPerDamagePoint = 125;
   maxEnergy = 600;
   jetForce = 0;
   minJetEnergy = 60;
   jetEnergyDrain = 0;
   rechargeRate = 1.0;

   jetSound = MPBThrustSound;
   engineSound = MPBEngineSound;
   squeelSound = AssaultVehicleSkid;
   softImpactSound = GravSoftImpactSound;
   hardImpactSound = HardImpactSound;
   //wheelImpactSound = WheelImpactSound;

   //
   softSplashSoundVelocity = 5.0;
   mediumSplashSoundVelocity = 8.0;
   hardSplashSoundVelocity = 12.0;
   exitSplashSoundVelocity = 8.0;

   exitingWater      = VehicleExitWaterSoftSound;
   impactWaterEasy   = VehicleImpactWaterSoftSound;
   impactWaterMedium = VehicleImpactWaterMediumSound;
   impactWaterHard   = VehicleImpactWaterHardSound;
   waterWakeSound    = VehicleWakeMediumSplashSound;

   minMountDist = 3;

   damageEmitter[0] = SmallLightDamageSmoke;
   damageEmitter[1] = SmallHeavyDamageSmoke;
   damageEmitter[2] = DamageBubbles;
   damageEmitterOffset[0] = "3.0 0.5 0.0 ";
   damageEmitterOffset[1] = "-3.0 0.5 0.0 ";
   damageLevelTolerance[0] = 0.3;
   damageLevelTolerance[1] = 0.7;
   numDmgEmitterAreas = 2;

   splashEmitter[0] = VehicleFoamDropletsEmitter;
   splashEmitter[1] = VehicleFoamEmitter;

   shieldImpact = VehicleShieldImpact;

   cmdCategory = "Tactical";
   cmdIcon = CMDGroundMPBIcon;
   cmdMiniIconName = "commander/MiniIcons/com_mpb_grey";
   targetNameTag = 'Drop';
   targetTypeTag = 'Pod';
   sensorData = VehiclePulseSensor;

   checkRadius = 7.5225;

   observeParameters = "1 12 12";

   runningLight[0] = MPBLight1;
   runningLight[1] = MPBLight2;

   shieldEffectScale = "0.85 1.2 0.7";

   replaceTime = 1;
};

datablock ParticleData(DropPodParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.02;
   inheritedVelFactor   = 1.0;

   lifetimeMS           = 4000;
   lifetimeVarianceMS   = 500;

   textureName          = "special/Smoke/bigSmoke";
   useInvAlpha = true;
   spinRandomMin = -90.0;
   spinRandomMax = 90.0;

   colors[0]     = "0.8 0.4 0.1 0.5";
   colors[1]     = "0.6 0.2 0.2 0.4";
   colors[2]     = "0.4 0.4 0.4 0.0";
   colors[3]     = "0.4 0.4 0.4 0.3";
   colors[4]     = "0.5 0.5 0.5 0.3";
   colors[5]     = "0.6 0.6 0.6 0.0";
   sizes[0]      = 1;
   sizes[1]      = 1.75;
   sizes[2]      = 0;
   sizes[3]      = 5;
   sizes[4]      = 6;
   sizes[5]      = 8;
   times[0]      = 0.0;
   times[1]      = 0.05;
   times[2]      = 0.1;
   times[3]      = 0.15;
   times[4]      = 0.7;
   times[5]      = 1.0;
};

datablock ParticleEmitterData(DropPodEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 35;
   velocityVariance = 10;

   thetaMin         = 175.0;
   thetaMax         = 180.0;  

   particles = "DropPodParticle";
};

function MakeDropPod(%pos, %team){
   %pod = new WheeledVehicle() 
   { 
      dataBlock    = DropPod; 
      position     = %pos; 
      rotation     = "0 0 1 0"; 
      team         = %team;  
   }; 
   MissionCleanUp.add(%pod);
   return %pod;
}

function DropPod::playerMounted(%data, %obj, %player, %node)
{
   centerPrint(%player.client, "<font:Impact:20><color:ffffff>WARNING: Do not eject out of the drop pod while it is in flight. \n<font:Hey:15>Use /SetCoord and /LaunchPod to launch the Drop Pod to a desired location.", 9, 3 );
   if( %player.client.observeCount > 0 )
      resetObserveFollow( %player.client, false );
}

function DropPod::deleteAllMounted(%data, %obj)
{
   if(%veh.beacon){
	%veh.beacon.delete();
	%veh.beacon = "";
   }
}

function ccSetCoord(%sender, %args){
   if(!isObject(%sender.player))
	return;
   %plyr = %sender.player;
   if(%args $= ""){
   messageclient(%sender, 'MsgClient', "\c2Coordinates must be specified.");
   }
   if(%plyr.mountedToV){
	%veh = %plyr.VmountedTo;
	if(%veh.getDataBlock().getName() $= "DropPod"){
	   %veh.DPcoord = getWord(%args, 0)@" "@getWord(%args, 1);
	   messageclient(%sender, 'MsgClient', "\c2Drop Pod coordinates set to\c3 "@%veh.DPcoord@"");


	   %search = containerRayCast(%veh.DPcoord@" 10000",%veh.DPcoord@" -100",$TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, %veh);
	   %pos = getWords(%search,1,3);
	   echo(%pos);
         if(%veh.beacon)
         {
            %veh.beacon.delete();
            %veh.beacon = "";
         }
         %veh.beacon = new BeaconObject() {
             dataBlock = "TargeterBeacon";
             beaconType = "vehicle";
             position = %pos;
         };

         %veh.beacon.playThread($AmbientThread, "ambient");
         %veh.beacon.team = %plyr.team;
         %veh.beacon.sourceObject = %veh;

         // give it a team target
         %veh.beacon.setTarget(%plyr.team);                  
         MissionCleanup.add(%veh.beacon);

	   %sender.camera.setOrbitMode(%veh.beacon, %pos, 0.5, 10, 10);
	   %sender.camera.targetObj = %veh.beacon;
	   %sender.setControlObject( %sender.camera );
	   %sender.schedule(4000, "setControlObject", %plyr);
	}
      else
	   messageclient(%sender, 'MsgClient', '\c2You are not in a Drop Pod.');
   }
   else
	messageclient(%sender, 'MsgClient', '\c2You are not in a Drop Pod.');
}

function ccLaunchPod(%sender, %args){
   if(!isObject(%sender.player))
	return;
   %plyr = %sender.player;
   if(%plyr.mountedToV){
	%veh = %plyr.VmountedTo;
	if(%veh.getDataBlock().getName() $= "DropPod"){
	   if(%veh.DPcoord !$= "")
	      launchDropPod(%veh);
	   else
		messageclient(%sender, 'MsgClient', '\c2Please set the coordinates at which you wish to land with\c3 /SetCoord\c2.');
	}
      else
	   messageclient(%sender, 'MsgClient', '\c2You are not in a Drop Pod.');
   }
   else
	messageclient(%sender, 'MsgClient', '\c2You are not in a Drop Pod.');
}

function launchDropPod(%obj){
   if(!isObject(%obj))
	return;
   %vel = %obj.getVelocity();
   if(vectorLen(%vel) < 200){
	%obj.applyImpulse(%obj.getPosition(),vectorScale("0 0 1",(3.5 * %obj.getDatablock().mass)));
   	%charge = new ParticleEmissionDummy() 
   	{ 
   	   position = %obj.getPosition();
	   rotation = %obj.getRotation();
   	   dataBlock = "defaultEmissionDummy"; 
   	   emitter = "DropPodEmitter"; 
      }; 
	MissionCleanup.add(%charge);
	%charge.schedule(100, "delete");
	serverPlay3d("DropPodThrustSound",%obj.getPosition()); 
   }
   %z = getWord(%obj.getPosition(),2);
   if(%z >= 10000){
	%dist = vectorDist(%obj.DPcoord@" "@%z,%obj.getPosition());
	%obj.setTransform(%obj.DPcoord@" "@%z@" 0 0 1 0");
	%obj.setFrozenState(true);
	%obj.schedule((%dist / 100) * 500,"setFrozenState",false);
	schedule((%dist / 100) * 500, 0, "slowDropPod", %obj);
	return;
   }
   if(vectorDist(%obj.getUpVector(),"0 0 1") >= 0.1){
	%upvec = %obj.getUpVector();
	%vec = vectorSub("0 0 1",%upvec);
	%vec = vectorCross(%vec,%upvec);
	%vec = vectorNormalize(vectorCross(%upvec,%vec));
	%pos = vectorAdd(%obj.getPosition(),vectorScale(%upvec,(0.1 * %obj.getDatablock().mass)));
	%obj.applyImpulse(%pos,%vec);
   }
   schedule(100, 0, "launchDropPod", %obj);
}

function slowDropPod(%obj){
   if(!isObject(%obj))
	return;
   %vel = %obj.getVelocity();
   if(%obj.slwspeed $= ""){
	%Aresult = containerRayCast(%obj.getPosition(), vectorAdd(%obj.getPosition(),"0 0 -10000"), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, 0);
	%Avec = vectorSub(getWord(%Aresult,1)@" "@getWord(%Aresult,2)@" "@getWord(%Aresult,3),%obj.getPosition());
	%obj.slwspeed = 3.0 + (mSqrt(vectorLen(%Avec)) / 18);
   }
   if(%obj.slowingdown != 1){
      %result = containerRayCast(%obj.getPosition(), vectorAdd(%obj.getPosition(),vectorScale(%vel,3)), $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType, 0);
      if(%result)
	   %obj.slowingdown = 1;
   }
   if(%obj.slowingdown == 1){
	if(vectorLen(%vel) > 20){
	   %obj.applyImpulse(%obj.getPosition(),vectorScale("0 0 1",(%obj.slwspeed * %obj.getDatablock().mass)));
   	   %charge = new ParticleEmissionDummy() 
   	   { 
   	      position = %obj.getPosition();
	      rotation = %obj.getRotation();
   	      dataBlock = "defaultEmissionDummy"; 
   	      emitter = "DropPodEmitter"; 
         }; 
	   MissionCleanup.add(%charge);
	   %charge.schedule(100, "delete");
	   serverPlay3d("DropPodThrustSound",%obj.getPosition()); 
	}
	else if(getWord(%vel,2) > -5){
	   DropPodDismount(%obj);
	   return;
	}
   }
   if(vectorDist(%obj.getUpVector(),"0 0 1") >= 0.1){
	%upvec = %obj.getUpVector();
	%vec = vectorSub("0 0 1",%upvec);
	%vec = vectorCross(%vec,%upvec);
	%vec = vectorNormalize(vectorCross(%upvec,%vec));
	%pos = vectorAdd(%obj.getPosition(),vectorScale(%upvec,(0.1 * %obj.getDatablock().mass)));
	%obj.applyImpulse(%pos,%vec);
   }
   schedule(100, 0, "slowDropPod", %obj);
}

function DropPodDismount(%obj){
   if(!isObject(%obj))
	return;
   if(isObject(%obj.getMountNodeObject(0))){
	%passenger = %obj.getMountNodeObject(0);
	%passenger.unmount();
      %pos = %obj.getPosition();
      for(%i = 0; %i < 3; %i++){
         %x = getWord(%pos, 0) + getRandom(3,8);
         %y = getWord(%pos, 1) + getRandom(3,8);
         %z = getWord(%pos, 2) + 10;
         %startpos = %x@" "@%y@" "@%z; 
         %mask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType;
         %searchResult = containerRayCast(%startpos, vectorAdd(%startpos, "0 0 -20"), %mask, %leader.player);
	   if(%searchResult){
	      %trns = getWord(%searchResult, 1)@" "@getWord(%searchResult, 2)@" "@getWord(%searchResult, 3);
	      %i = 3;
	   }
      }
	if(%trns $= "")
	   %trns = %pos;
	%passenger.setPosition(%trns);
//	commandToClient(%passenger.client, 'setHudMode', 'Standard', "", 0);
	schedule(100, 0, "commandToClient", %passenger.client, 'setHudMode', 'Standard', "", 0);
   }
   %obj.schedule(1000,"delete");
}
