$S11manuverforce = 75;
$S11flyforce = 350;
$S11forwardspeed = 120;
$S11hoverheight = 3;
$S11hoverforce = 100;
$S11reconheight = "450 550";
$S11reconradius = 700;

$S11[move] = "TAKEOFF MOVE LAND IDLE";
$S11[guard] = "TAKEOFF RECON";
$S11[attack] = "TAKEOFF MOE FIRE MOVE LAND IDLE";
$S11[rearm] = "TAKEOFF MOVE LAND REARM TAKEOFF MOVE LAND IDLE";

function S11Think(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.tasks !$= ""){
	%task = getWord(%obj.tasks,0);
	%fun = "S11"@%task;
	%obj.mode = %task;
	if(%obj.specvar[%task] !$= "")
	   schedule(10, 0, %fun, %obj, %obj.specvar[%task]);
	else
	   schedule(10, 0, %fun, %obj);
   }
   else{
	%obj.mode = "IDLE";
	S11IDLE(%obj);
   }
}

function S11IDLE(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "IDLE")
	return;

   %pos = %obj.getPosition();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,vectorScale("0 0 -1",$S11hoverheight));
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   if(%searchresult){
	%obj.applyImpulse(%pos,vectorScale("0 0 1",$S11hoverforce));
   }

   schedule(100, 0, "S11IDLE", %obj);
}

function S11TAKEOFF(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "TAKEOFF")
	return;
   %pos = %obj.getPosition();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,"0 0 -20");
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   if(%searchresult)
	%obj.applyImpulse(%pos,"0 0 200");
   else{
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }
   schedule(100, 0, "S11TAKEOFF", %obj);
}

function S11LAND(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "LAND")
	return;

   %pos = %obj.getPosition();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,"0 0" SPC (-10 - $S11hoverheight));
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   if(%searchresult){
	%dist = vectorDist(%pos,posfromraycast(%searchresult));
	if(%dist <= $S11hoverheight){
	   %obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	   S11Think(%obj);
	   return;
	}
	%speed = vectorScale("0 0 -1",%dist);
	%obj.setVelocity(%speed);
   }
   else{
	%vel = %obj.getVelocity();
	%reqvel = "0 0 -15";
	%impvec = vectorScale(vectorSub(%reqvel,%vel),%obj.getDatablock().mass);
	%obj.applyImpulse(%pos,%impvec);
   }
   schedule(100, 0, "S11LAND", %obj);
}

function S11MOVE(%obj, %movepos){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "MOVE")
	return;

   %pos = %obj.getPosition();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,"0 0 -150");
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   %vec = "0 0 0";
   %frd = %obj.getForwardVector();
   if(vectorlen(%obj.getVelocity()) <= $S11forwardspeed)
      %vec = vectorScale(%frd,$S11flyforce);
   if(%searchresult)
	%vec = vectorAdd(%vec,"0 0 150");
   %tstpos = getWords(%movepos,0,1) SPC getWord(%pos,2);
   %dist = vectorDist(%tstpos,%pos);
   if(%dist > 10){
	%aimvec = vectorSub(%tstpos,%pos);
	%tvec = vectorNormalize(vectorCross(%aimvec, %frd));
	%tvec = vectorNormalize(vectorCross(%frd, %tvec));
	%obj.applyImpulse(vectorAdd(%pos,%frd),vectorScale(%tvec,$S11manuverforce));
   }
   else{
	if(%obj.specvar["MOVE",2] !$= ""){
	   %obj.specvar["MOVE"] = %obj.specvar["MOVE",2];
	   %obj.specvar["MOVE",2] = "";
	}
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }
   %obj.applyImpulse(%pos,%vec);
   schedule(100, 0, "S11MOVE",%obj,%movepos);
}

function S11RECON(%obj,%reconPos){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "RECON")
	return;

   %pos = %obj.getPosition();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,"0 0 -1000");
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   if(%searchresult){
	%frd = %obj.getForwardVector();
	%vec = "0 0 0";
	if(vectorlen(%obj.getVelocity()) <= $S11forwardspeed)
	   %vec = vectorScale(%frd,$S11flyforce);
	%dist = vectorDist(%pos,posfromraycast(%searchresult));
	if(%dist < getWord($S11reconheight,0))
	   %vec = vectorAdd(%vec,"0 0 450");
	if(%dist > getWord($S11reconheight,1))
	   %vec = vectorAdd(%vec,"0 0 -450");

	%tstpos = getWords(%reconPos,0,1) SPC getWord(%pos,2);
	%dist = vectorDist(%tstpos,%pos);
	if(%dist > $S11reconradius){
	   %aimvec = vectorSub(%tstpos,%pos);
	   %tvec = vectorNormalize(vectorCross(%aimvec, %frd));
	   %tvec = vectorNormalize(vectorCross(%frd, %tvec));
	   %obj.applyImpulse(vectorAdd(%pos,%frd),vectorScale(%tvec,$S11manuverforce));
	}
	%obj.applyImpulse(%pos,%vec);
   }
   else{
	%vel = %obj.getVelocity();
	%reqvel = "0 0 -50";
	%impvec = vectorScale(vectorSub(%reqvel,%vel),%obj.getDatablock().mass);
	%obj.applyImpulse(%pos,%impvec);
   }
   schedule(100, 0, "S11RECON",%obj,%reconpos);
}

function S11MOE(%obj,%target){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "MOE")
	return;
   if(!isObject(%target)){
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }

   %pos = %obj.getPosition();
   %frd = %obj.getForwardVector();
   %mask = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::TerrainObjectType;
   %vector = vectorAdd(%pos,vectorScale(%frd,100));
   %searchResult = containerRayCast(%pos, %vector, %mask, %obj);
   if(!%searchResult){
	%tstvec = vectorAdd(%vector,"0 0 -50");
	%searchResult2 = containerRayCast(%vector, %tstvec, %mask, %obj);
	if(%searchResult2)
	   %dir = "1";
	else
	   %dir = "-1";
   }
   else
	%dir = "2";

   %impvec = vectorScale(%obj.getUpVector(),$S11manuverforce * %dir);

   %Tpos = %target.getPosition();
   %tstpos = getWords(%TPos,0,1) SPC getWord(%pos,2);
   %aimvec = VectorNormalize(vectorSub(%tstpos,%pos));
   %dist = vectorDist(%frd,%aimvec);
   if(%dist > 0.1){
	%aimvec = vectorSub(%tstpos,%pos);
	%tvec = vectorNormalize(vectorCross(%aimvec, %frd));
	%tvec = vectorNormalize(vectorCross(%frd, %tvec));
	%impvec = vectorAdd(%impvec,vectorScale(%tvec,$S11manuverforce));
   }
   if(vectorDist(%pos, %Tpos) < 500){
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }

   %obj.applyImpulse(vectorAdd(%pos,%frd),%impvec);
   if(vectorlen(%obj.getVelocity()) <= $S11forwardspeed)
   	%obj.applyImpulse(%pos,vectorScale(%obj.getForwardVector(),$S11flyforce));

   schedule(100, 0, "S11MOE", %obj,%target);
}

function S11REARM(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "REARM")
	return;

   %obj.setVelocity("0 0 0");

   if (%obj.turret.inv[AALauncherAmmo] < 1)
	%obj.turret.setInventory(AALauncherAmmo, 1);
   else if(%DamageLevel > 0)
	%obj.setRepairRate(0.01);
   else {
	%obj.setRepairRate(0);
	S11Think(%obj);
	return;
   }

   schedule(100, 0, "S11REARM", %obj, %target);
}

function S11FIRE(%obj,%target){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "FIRE")
	return;
   if(!isObject(%target)){
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }
   %turret = %obj.turret;
   if(%turret.inv[AALauncherAmmo] >= 1){
	%turret.target = %target;
	if(%obj.aiming != 1){
	   %obj.aiming = 1;
	   %turret.setTargetObject(%target);
	   %turret.aquireTime = getSimTime();
	   %turret.setImageTrigger(2,true);
	}
	else if(isObject(%turret.TLB)){
	   %turret.setImageTrigger(3,true);
	}
   }
   else{
	%obj.aiming = 0;
	%turret.setImageTrigger(2,false);
	%turret.setImageTrigger(3,false);
	%obj.tasks = getWords(%obj.tasks,1,(getNumberOfWords(%obj.tasks) - 1));
	S11Think(%obj);
	return;
   }
   %frd = %obj.getForwardVector();
   %impvec = vectorAdd(vectorScale(%frd,$S11flyforce),"0 0 150");
   if(vectorlen(%obj.getVelocity()) <= $S11forwardspeed)
      %obj.applyImpulse(%obj.getPosition(),%impvec);
   schedule(100, 0, "S11FIRE", %obj, %target);
}