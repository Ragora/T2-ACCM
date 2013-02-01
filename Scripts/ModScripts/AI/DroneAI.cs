//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Drone AI by Dondelium_X
// CCM v3.4
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

$Drone::DetectDist = 500;
$Drone::TurnImpulse = 123;
$Drone::FrdImpulse = 525;
//$Drone::TurnImpulse = 675 / 3;
//$Drone::FrdImpulse = 525 * 3;
$Drone::newTargetChance = "1 100";

$Drone::paths = 4;
$Drone::path[1,1] = "0 1500 1000";
$Drone::path[1,2] = "1500 0 1000";
$Drone::path[1,3] = "0 -1500 1000";
$Drone::path[1,4] = "-1500 0 1000";

$Drone::path[2,1] = "0 -1500 1000";
$Drone::path[2,2] = "-1500 0 1000";
$Drone::path[2,3] = "0 1500 1000";
$Drone::path[2,4] = "1500 0 1000";

$Drone::path[3,1] = "0 2500 750";
$Drone::path[3,2] = "0 2500 1250";
$Drone::path[3,3] = "0 -2500 1250";
$Drone::path[3,4] = "0 -2500 750";

$Drone::path[4,1] = "2500 0 750";
$Drone::path[4,2] = "2500 0 1250";
$Drone::path[4,3] = "-2500 0 1250";
$Drone::path[4,4] = "-2500 0 750";

//-----Manuver Index-----

$flightManuvers::Behind[0] = Immelman;
$flightManuvers::Behind[1] = HalfFlip;
$flightManuvers::Behind[2] = BreakRight;
$flightManuvers::Behind[3] = BreakLeft;
$flightManuvers::Behind[4] = BarrelRoll;
$flightManuvers::Behind[5] = WingWaggle;
$flightManuvers::Behind[6] = Reversal;


//-----Manuvers-----

//Immelman
$flightManuver::Points[Immelman] = 5; 			//This signifies how many points are in the manuver
$flightManuver::Point[Immelman,0] = "0 1 0 0 0 1";  	//each point represents the 3 numbers of the vector of the desired forward vector,
$flightManuver::Point[Immelman,1] = "0 0 1 0 -1 0";	//and then the 3 numbers of the vector for the desired Up vector
$flightManuver::Point[Immelman,2] = "0 -1 0 0 0 -1";
$flightManuver::Point[Immelman,3] = "0 -1 0 1 0 0";
$flightManuver::Point[Immelman,4] = "0 -1 0 0 0 1";

//halfFlip
$flightManuver::Points[HalfFlip] = 3;
$flightManuver::Point[HalfFlip,0] = "0 1 0 0 0 1";
$flightManuver::Point[HalfFlip,1] = "0 0 1 0 -1 0";
$flightManuver::Point[HalfFlip,2] = "0 -1 0 0 0 -1";

//breakRight
$flightManuver::Points[BreakRight] = 3;
$flightManuver::Point[BreakRight,0] = "0 1 0 0 0 1";
$flightManuver::Point[BreakRight,1] = "0 1 0 1 0 0";
$flightManuver::Point[BreakRight,2] = "1 0 0 0 -1 0";

//BreakLeft
$flightManuver::Points[BreakLeft] = 3;
$flightManuver::Point[BreakLeft,0] = "0 1 0 0 0 1";
$flightManuver::Point[BreakLeft,1] = "0 1 0 -1 0 0";
$flightManuver::Point[BreakLeft,2] = "-1 0 0 0 -1 0";

//BarrelRoll
$flightManuver::Points[BarrelRoll] = 5;
$flightManuver::Point[BarrelRoll,0] = "0 1 0 0 0 1";
$flightManuver::Point[BarrelRoll,1] = "0 1 0 1 0 0";
$flightManuver::Point[BarrelRoll,2] = "0 1 0 0 0 -1";
$flightManuver::Point[BarrelRoll,3] = "0 1 0 -1 0 0";
$flightManuver::Point[BarrelRoll,4] = "0 1 0 0 0 1";

//WingWaggle
$flightManuver::Points[WingWaggle] = 4;
$flightManuver::Point[WingWaggle,0] = "0 1 0 0 0 1";
$flightManuver::Point[WingWaggle,1] = "-1 1 0 0 0 1";
$flightManuver::Point[WingWaggle,2] = "1 1 0 0 0 1";
$flightManuver::Point[WingWaggle,3] = "0 1 0 0 0 1";

//Reversal
$flightManuver::Points[Reversal] = 7;
$flightManuver::Point[Reversal,0] = "0 1 0 0 0 1";
$flightManuver::Point[Reversal,1] = "0 0 1 0 -1 0";
$flightManuver::Point[Reversal,2] = "0 0 1 1 0 0";
$flightManuver::Point[Reversal,3] = "1 0 0 0 0 -1";
$flightManuver::Point[Reversal,4] = "0 0 -1 -1 0 0";
$flightManuver::Point[Reversal,5] = "0 0 -1 0 1 0";
$flightManuver::Point[Reversal,6] = "0 1 0 0 0 1";

//This is a function for mass spawning
function DroneBattle(%pos, %radius, %number, %teamlow, %teamhigh, %maxskill){
   for(%i = 0; %i < %number; %i++){
	%startpos = vectorAdd(%pos,(getRandom(0, %radius) - (%radius / 2))@" "@(getRandom(0, %radius) - (%radius / 2))@" 0");
	%rotation = "0 0 1 "@getRandom(1,360);
	if(%teamlow != %teamhigh)
	   %team = getRandom(%teamlow,%teamhigh);
	else
	   %team = %teamlow;
	StartDrone(%startpos,%rotation,%team,getRandom(1,%maxskill));
   }
}

//This sets up the drone and the functions needed to start the drone.
function StartDrone(%pos, %rotation, %team, %skill){
   if(%team $= "")
	%team = 0;
   if(%pos $= "")
	%pos = "0 0 300";
   if(%rotation $= "")
	%rotation = "1 0 0 0";
   if(%skill !$= "ace"){
      if(%skill $= "" || %skill < 1)
	   %skill = 1;
      else if(%skill > 10)
	   %skill = 10;
   }
   %Drone = new FlyingVehicle()
   {
      dataBlock    = ScoutFlyer;
      position     = %pos;
      rotation     = %rotation;
      team         = %team;
   };
   MissionCleanUp.add(%Drone); 

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %drone.isdrone = 1;
   %drone.dodgeGround = 0;

   if(%skill $= "ace"){
	%skill = 10;
	%drone.isace = 1;
   }

   %drone.skill = 0.2 + (%skill / 12.5);

   schedule(100, 0, "DroneForwardImpulse", %drone);
   schedule(101, 0, "DronefindTarget", %drone);
   schedule(102, 0, "DroneScanGround", %drone);

   return %drone;
}

//This makes the drone move forward until it dies
function DroneForwardImpulse(%obj){
   if(!isObject(%obj))
	return;
   if(!%obj.isace){
      if(vectorLen(%obj.getVelocity()) < 165)
	   %obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(),$Drone::FrdImpulse));
   }
   else{
      if(vectorLen(%obj.getVelocity()) < 225)
	   %obj.applyImpulse(%obj.getPosition(),vectorScale(%obj.getForwardVector(),$Drone::FrdImpulse * 3));
   }
   schedule(100, 0, "DroneForwardImpulse", %obj);
}

function DroneScanGround(%obj){
   if(!isObject(%obj))
	return;
   %vec = %obj.getForwardVector();
   %vector = vectorAdd(%obj.getPosition(),"0 0 -500");
   %searchResult = containerRayCast(%obj.getWorldBoxCenter(), %vector, $TypeMasks::TerrainObjectType, %obj);
   if(%searchResult){
	%z = getWord(%vec,2);
      %height = vectorDist(%obj.getPosition(),posFromRaycast(%searchresult));
	if(%z < 0){
	   if(%height <= (200 + ((%z * -1) * 300))){
		%obj.dodgeground = 1;
		schedule(100, 0, "DroneDodgeGround", %obj);
		return;
	   }
	}
   }
   schedule(100, 0, "DroneScanGround", %obj);
}

function DroneDodgeGround(%obj){
   if(!isObject(%obj))
	return;
   %vec = %obj.getForwardVector();
   %z = getWord(%vec,2);
   if(%z > 0){
	%obj.dodgeground = 0;
	schedule(100, 0, "DronefindTarget", %obj);
	schedule(101, 0, "DroneScanGround", %obj);
	return;
   }
   %pos = vectorAdd(%obj.getPosition(),%vec);
   %obj.applyImpulse(%pos,vectorScale("0 0 1",$Drone::TurnImpulse * %obj.skill));
   schedule(100, 0, "DroneDodgeGround", %obj);
}

//This function checks the area around it for any targets.
function DronefindTarget(%obj){
   if(!isObject(%obj))
	return;
   %pos = %obj.getposition();
   InitContainerRadiusSearch(%pos, $drone::detectdist + (800 + (600 * %obj.skill)), $TypeMasks::VehicleObjectType);
   while ((%searchResult = containerSearchNext()) != 0){
	%objtarget = firstWord(%searchResult);
	if(isObject(%objtarget) && %objTarget !$= %obj){
	   %trgtype = %objtarget.getClassName();
	   if(%trgtype $= "FlyingVehicle" && %objtarget.team != %obj.team){
	      %testPos = %objtarget.getWorldBoxCenter();
	      %distance = vectorDist(%objtarget.getPosition(),%pos);
	      if (%distance > 0){
		   %target = %objtarget;
		   DroneDetermineManuver(%obj, %target);
		   return;
	      }
         }
      }
   }
   schedule(100, 0, "DronePatrol", %obj);
}

function DronePatrol(%obj){
   if(!isObject(%obj))
	return;
   if($Drone::paths > 0){
	if(%obj.path $= ""){
	   %obj.path = getRandom(1,$Drone::paths);
	   %obj.point = 0;
	}
	%obj.point++;
	if($Drone::path[%obj.path,%obj.point] $= ""){
	   schedule(100, 0, "DronefindTarget", %obj);
	   %obj.path = "";
	   %obj.point = "";
	}
	else
	   schedule(100,0,"dronemovetopoint",%obj,$Drone::path[%obj.path,%obj.point]);
   }
   else
	schedule(500, 0, "DronefindTarget", %obj);
}

function DroneMoveToPoint(%obj,%Tpos){
   if(!isObject(%obj))
	return;
   if(%obj.dodgeground == 1)
	return;
   %pos = %obj.getPosition();
   %objfrd = %obj.getForwardVector();
   %objup = %obj.getUpVector();

   %dist = vectorDist(%pos,%Tpos);
   %aimvec = vectorNormalize(vectorSub(%Tpos,%pos));

   %vec = vectorSub(%aimvec , %objfrd);
   %vec = vectorCross(%vec, %objfrd);
   %vec = vectorNormalize(vectorCross(%objfrd, %vec));
   if(vectorDist(%objfrd,vectorNormalize(%aimvec)) < 0.1)
	%obj.applyImpulse(vectorAdd(%obj.getPosition(),vectorScale(%objfrd,($Drone::TurnImpulse / 2))),%vec);
   else if(vectorDist(%objup, %vec) > 0.1){
	%vec = vectorSub(%vec, %objup);
	%vec = vectorCross(%vec, %objup);
	%vec = vectorNormalize(vectorCross(%objup, %vec));
	%pos = vectorAdd(%obj.getPosition(),vectorScale(%objup,$Drone::TurnImpulse * 3 * %obj.skill));
	%obj.applyImpulse(%pos,%vec);
   }
   else
	%obj.applyImpulse(vectorAdd(%obj.getPosition(),%objfrd),vectorScale(%vec,$Drone::TurnImpulse * %obj.skill));
   if(getRandom(0,getWord($Drone::newTargetChance,1)) <= (getWord($Drone::newTargetChance,0) * 10))
	schedule(100, 0, "DronefindTarget", %obj, %target);
   else if(%dist < 25)
	schedule(100, 0, "DronePatrol", %obj);
   else
      schedule(100, 0, "DroneMoveToPoint", %obj, %tpos);
}

//This function figures out what the drone should do from where the target is.
function DroneDetermineManuver(%obj, %target){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	DronefindTarget(%obj);
	return;
   }
   %pos = %obj.getPosition();
   %Tpos = %Target.getPosition();
   %objfrd = %obj.getForwardVector();
   %trgfrd = %target.getForwardVector();
   %vec = vectorSub(%Tpos,%pos);
   %dirdist = vectorDist(%objfrd,vectorNormalize(%vec));
   %vecdist = vectorDist(%objfrd,%trgfrd);
   if(%dirdist > 1.41){
	if(%vecdist < 1.41 && vectorDist(%pos,%Tpos) < 2000){
	   UnderFireManuver(%obj, $flightManuvers::Behind[getRandom(0,6)], "");
	}
	else
	   TurnToFire(%obj, %target);
   }
   else
	TurnToFire(%obj, %target);
   %obj.target = %target;
}

function TurnToFire(%obj, %target){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	DronefindTarget(%obj);
	return;
   }
   if(%obj.dodgeground == 1)
	return;

   %pos = %obj.getPosition();
   %Tpos = %target.getPosition();
   %objfrd = %obj.getForwardVector();
   %trgfrd = %target.getForwardVector();
   %objup = %obj.getUpVector();
   %Tvel = %target.getVelocity();

   %dist = vectorDist(%pos,%Tpos);
   %aimPos = vectorAdd(%Tpos, vectorScale(%Tvel,(%dist / 1750)));
   %aimvec = vectorNormalize(vectorSub(%aimPos,%pos));

   if(vectorDist(%objfrd,%aimvec) < 0.1 && %dist <= 1000){
	if((vectorDist(%objfrd,%trgfrd) < 0.2 || vectorDist(%objfrd,%trgfrd) > 1.8) && %obj.missiling != 1){
	   %obj.setImageTrigger(4, true);
	   %obj.missiling = 1;
	}
	else if(%obj.missiling == 1){
	   %obj.setImageTrigger(4, false);
	   %obj.missiling = 0;
	}
//	if (%obj.firing != 1){
	   %obj.setImageTrigger(2, true);
	   %obj.setImageTrigger(3, true);
	   %obj.firing = 1;
//	}
   }
   else{
	if(%obj.firing == 1){
	   %obj.setImageTrigger(2, false);
	   %obj.setImageTrigger(3, false);
	   %obj.firing = 0;
	}
	if(%obj.missiling == 1){
	   %obj.setImageTrigger(4, false);
	   %obj.missiling = 0;
	}
   }
   %vec = vectorSub(%aimvec , %objfrd);
   %vec = vectorCross(%vec, %objfrd);
   %vec = vectorNormalize(vectorCross(%objfrd, %vec));
   if(vectorDist(%objfrd,%trgfrd) > 1.8 && %dist <= 120){
	%vec = vectorScale(%vec, -1);
      if(vectorDist(%objfrd,vectorNormalize(%aimvec)) > 1.8)
	   %obj.applyImpulse(vectorAdd(%obj.getPosition(),vectorScale(%objfrd,($Drone::TurnImpulse / 2))),%vec);
      else if(vectorDist(%objup, %vec) > 0.1){
	   %vec = vectorSub(%vec, %objup);
	   %vec = vectorCross(%vec, %objup);
	   %vec = vectorNormalize(vectorCross(%objup, %vec));
	   %pos = vectorAdd(%obj.getPosition(),vectorScale(%objup,$Drone::TurnImpulse * 3 * %obj.skill));
	   %obj.applyImpulse(%pos,%vec);
      }
      else
	   %obj.applyImpulse(vectorAdd(%obj.getPosition(),%objfrd),vectorScale(%vec,$Drone::TurnImpulse * %obj.skill));
   }
   else if(vectorDist(%objfrd,vectorNormalize(%aimvec)) < 0.1)
	%obj.applyImpulse(vectorAdd(%obj.getPosition(),vectorScale(%objfrd,($Drone::TurnImpulse / 2))),%vec);
   else if(vectorDist(%objup, %vec) > 0.1){
	%vec = vectorSub(%vec, %objup);
	%vec = vectorCross(%vec, %objup);
	%vec = vectorNormalize(vectorCross(%objup, %vec));
	%pos = vectorAdd(%obj.getPosition(),vectorScale(%objup,$Drone::TurnImpulse * 3 * %obj.skill));
	%obj.applyImpulse(%pos,%vec);
   }
   else
	%obj.applyImpulse(vectorAdd(%obj.getPosition(),%objfrd),vectorScale(%vec,$Drone::TurnImpulse * %obj.skill));
   if(getRandom(0,getWord($Drone::newTargetChance,1)) <= getWord($Drone::newTargetChance,0))
	schedule(100, 0, "DronefindTarget", %obj, %target);
   else
      schedule(100, 0, "TurnToFire", %obj, %target);
}

//This function preforms the manuver choosen in Determine Maunver function.
function UnderFireManuver(%obj, %manuver, %point, %count){
   if(!isObject(%obj))
	return;
   if(%obj.dodgeground == 1)
	return;
   if(%count $= "")
	%count = 0;
   if(%point $= ""){
	%point = 0;
	SetPointVectors(%obj, %manuver);
   }
   if(%count >= 30){
	schedule(100, 0, "DroneDetermineManuver", %obj, %obj.target);
	return;
   }
   %frdvec = %obj.getForwardVector();
   %upvec = %obj.getUpVector();
   if(vectorDist(%frdvec, %obj.pointvecfront[%point]) < 0.15 && vectorDist(%upvec, %obj.pointvectop[%point]) < 0.15){
	%point++;
	if(%point < $flightManuver::Points[%manuver])
	   schedule(100, 0, "UnderFireManuver", %obj, %manuver, %point, 0);
	else
	   schedule(100, 0, "DroneDetermineManuver", %obj, %obj.target);
	return;
   }
   if(vectorDist(%frdvec, %obj.pointvecfront[%point]) > 0.1){
	%vec = vectorSub(%obj.pointvecfront[%point], %frdvec);
	%vec = vectorCross(%vec, %frdvec);
	%vec = vectorCross(%frdvec, %vec);
	%obj.applyImpulse(vectorAdd(%obj.getPosition(),vectorScale(%frdvec,$Drone::TurnImpulse * %obj.skill)),%vec);
   }
   if(vectorDist(%upvec, %obj.pointvectop[%point]) > 0.1){
	%vec = vectorSub(%obj.pointvectop[%point], %upvec);
	%vec = vectorCross(%vec, %upvec);
	%vec = vectorCross(%upvec, %vec);
	%pos = vectorAdd(%obj.getPosition(),vectorScale(%upvec,$Drone::TurnImpulse * 3 * %obj.skill));
	%obj.applyImpulse(%pos,%vec);
   }
   %count++;
   schedule(100, 0, "UnderFireManuver", %obj, %manuver, %point, %count);
}

//This function finds what vectors each point in the manuver is compaired to the drone.
function SetPointVectors(%obj, %manuver){
   %up = %obj.getUpVector();
   %forward = %obj.getForwardVector();
   %right = vectorNormalize(vectorSub(%obj.getEdge("1 0 0"),%obj.getEdge("-1 0 0")));
   for(%i = 0; %i < $flightManuver::Points[%manuver]; %i++){
	%pointdir = $flightManuver::Point[%manuver, %i];
	%topvec = "0 0 0";
	%frontvec = "0 0 0";
	if(getWord(%pointdir, 0) > 0)
	   %frontvec = vectorAdd(%frontvec, %right);
	else if(getWord(%pointdir, 0) < 0)
	   %frontvec = vectorAdd(%frontvec, vectorScale(%right, -1));
	if(getWord(%pointdir, 1) > 0)
	   %frontvec = vectorAdd(%frontvec, %forward);
	else if(getWord(%pointdir, 1) < 0)
	   %frontvec = vectorAdd(%frontvec, vectorScale(%forward, -1));
	if(getWord(%pointdir, 2) > 0)
	   %frontvec = vectorAdd(%frontvec, %up);
	else if(getWord(%pointdir, 2) < 0)
	   %frontvec = vectorAdd(%frontvec, vectorScale(%up, -1));

	if(getWord(%pointdir, 3) > 0)
	   %topvec = vectorAdd(%topvec, %right);
	else if(getWord(%pointdir, 3) < 0)
	   %topvec = vectorAdd(%topvec, vectorScale(%right, -1));
	if(getWord(%pointdir, 4) > 0)
	   %topvec = vectorAdd(%topvec, %forward);
	else if(getWord(%pointdir, 4) < 0)
	   %topvec = vectorAdd(%topvec, vectorScale(%forward, -1));
	if(getWord(%pointdir, 5) > 0)
	   %topvec = vectorAdd(%topvec, %up);
	else if(getWord(%pointdir, 5) < 0)
	   %topvec = vectorAdd(%topvec, vectorScale(%up, -1));

	%obj.pointvecfront[%i] = vectorNormalize(%frontvec);
	%obj.pointvectop[%i] = vectorNormalize(%topvec);
   }
}

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Tank AI by Dondelium_X
// CCM v3.4
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
$DTank::ForwardForce = 7000;
$DTank::BackForce = 3000;
$DTank::TurnForce = 2500;

function StartDTank(%pos,%team,%skill){
   if(%team $= "")
	%team = 0;
   if(%pos $= "")
	%pos = "0 0 300";
   if(%skill $= "" || %skill < 1)
	%skill = 1;
   else if(%skill > 10)
	%skill = 10;

   %Drone = new HoverVehicle()
   {
      dataBlock    = HeavyTank;
      position     = %pos;
      rotation     = "0 0 1 0";
      team         = %team;
   };
   MissionCleanUp.add(%Drone); 

   setTargetSensorGroup(%Drone.getTarget(), %team);

   %drone.skill = 0.6 + (%skill / 25);

   schedule(100, 0, "DTankScanTargets",%drone);
}

function DTankScanTargets(%obj){
   if(!isObject(%obj))
	return;
   %pos = %obj.getposition();
   %closestClient = -1;
   %closestDistance = 32767;
   %scandist = 2000 * %obj.skill;
   %airtrgs = "";
   %groundtrgs = "";
   %inftrgs = "";
   InitContainerRadiusSearch(%pos, %scanDist, $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType);
   while ((%searchResult = containerSearchNext()) != 0){
	%objtarget = firstWord(%searchResult);
	if(isObject(%objtarget) && %objTarget !$= %obj && %objtarget.team != %obj.team){
	   %trgtype = %objtarget.getClassName();
	   if(%trgtype $= "FlyingVehicle")
		%airtrgs = %airtrgs SPC %objtarget;
	   else if(%trgtype $= "HoverVehicle")
		%groundtrgs = %groundtrgs SPC %objtarget;
	   else if(%trgtype $= "Player")
		%inftrgs = %inftrgs SPC %objtarget;
      }
   }
   if(%groundtrgs){
	%target = firstWord(%groundtrgs);
	%groundtrgs = getWords(%groundtrgs,1,4);
	DTankGroundCombat(%obj, %target,%groundtrgs);
   }
   else if(%inftrgs){
	%target = firstWord(%inftrgs);
	%inftrgs = getWords(%inftrgs,1,4);
	DTankInfCombat(%obj, %target,%inftrgs);
   }
   else if(%airtrgs){
	%target = firstWord(%airtrgs);
	%airtrgs = getWords(%airtrgs,1,4);
	DTankAACombat(%obj, %target,%airtrgs);
   }
   else{
	schedule(3000, 0, "DTankScanTargets", %obj);
   }
}

function DTankGroundCombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%obj.turretobject.setImageTrigger(4,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   %frdvec = vectorNormalize(getWords(%obj.getForwardVector(),0,1) SPC "0");
   %chkvec = vectorSub(%tpos,%pos);
   %chkvec = vectorNormalize(getWords(%chkvec,0,1) SPC "0");
   %turnvec = vectorsub(%chkvec,%frdvec);
   %vecdif = vectorlen(%turnvec);
   if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turret.setImageTrigger(4,false);
	}
	%target = "";
   }
   else if(vectorDist(%pos,%tpos) > 500){
	if(%vecdif >= "0.1"){
	   %vec = vectorCross(%turnvec, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   else{
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.firetype = 3;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(4,true);
	}
	if(%vecdif < "1.2" || %vecdif >= "1.6"){
	   %Tvec1 = vectorNormalize(vectorcross(%chkvec,"0 0 1"));
	   %Tvec2 = vectorScale(%Tvec1,-1);
	   if(vectordist(%frdvec,%Tvec1) < vectorDist(%frdvec,%Tvec2))
		%tovec = vectorSub(%Tvec1,%frdvec);
	   else
		%tovec = vectorSub(%Tvec2,%frdvec);
	   %vec = vectorCross(%Tvec2, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   %obj.applyImpulse(%pos,vectorScale(%obj.getForwardVector(),$DTank::ForwardForce));
   schedule(100, 0, "DTankGroundCombat",%obj,%target,%Trglist);
}

function DTankAACombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%obj.turretobject.setImageTrigger(2,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   if(vectorDist(%pos,%tpos) < 750){
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(2,true);
	}
   }
   else if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turretobject.setImageTrigger(2,false);
	}
	%target = "";
   }
   schedule(100, 0, "DTankAACombat",%obj,%target,%Trglist);
}

function DTankInfCombat(%obj, %target, %Trglist){
   if(!isObject(%obj))
	return;
   if(!isObject(%target) || %target.getState() $= "dead"){
	%obj.turretobject.setImageTrigger(3,false);
	%obj.firing = "";
	if(%TrgList){
	   %target = firstWord(%Trglist);
	   %trglist = getWords(%trglist,1,4);
	}
	else{
	   DTankScanTargets(%obj);
	   return;
	}
   }
   %pos = %obj.getPosition();
   %tpos = %target.getPosition();
   %frdvec = vectorNormalize(getWords(%obj.getForwardVector(),0,1) SPC "0");
   %chkvec = vectorSub(%tpos,%pos);
   %chkvec = vectorNormalize(getWords(%chkvec,0,1) SPC "0");
   %turnvec = vectorsub(%chkvec,%frdvec);
   %vecdif = vectorlen(%turnvec);
   if(vectorDist(%pos,%tpos) > 2000){
	if(%obj.firing){
	   %obj.firing = "";
	   %obj.turret.setImageTrigger(3,false);
	}
	%target = "";
   }
   else if(vectorDist(%pos,%tpos) > 300){
	if(%vecdif >= "0.1"){
	   %vec = vectorCross(%turnvec, %frdvec);
	   %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	   %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	   %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	}
   }
   else{
	if(!%obj.firing){
	   %obj.firing = 1;
	   %obj.turretobject.firetype = 1;
	   %obj.turretobject.setTargetObject(%Target);
	   %obj.turretobject.aquireTime = getSimTime();
	   %obj.turretobject.setImageTrigger(3,true);
	}
	if(vectorDist(%pos,%tpos) < 100){
	   if(%vecdif <= "1.6"){
	      %vec = vectorCross(%turnvec, %frdvec);
	      %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	      %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	      %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill * "-1"));
	   }
	}
	else {
	   if(%vecdif < "1.2" || %vecdif >= "1.6"){
	      %Tvec1 = vectorNormalize(vectorcross(%chkvec,"0 0 1"));
	      %Tvec2 = vectorScale(%Tvec1,-1);
	      if(vectordist(%frdvec,%Tvec1) < vectorDist(%frdvec,%Tvec2))
		   %tovec = vectorSub(%Tvec1,%frdvec);
	      else
		   %tovec = vectorSub(%Tvec2,%frdvec);
	      %vec = vectorCross(%Tvec2, %frdvec);
	      %vec = vectorNormalize(vectorCross(%obj.getForwardVector(), %vec));
	      %Imppos = vectorAdd(%pos,%obj.getForwardVector());
	      %obj.applyImpulse(%Imppos,vectorScale(%vec,$DTank::TurnForce * %obj.skill));
	   }
	}
   }
   %obj.applyImpulse(%pos,vectorScale(%obj.getForwardVector(),$DTank::ForwardForce));
   schedule(100, 0, "DTankInfCombat",%obj,%target,%Trglist);
}