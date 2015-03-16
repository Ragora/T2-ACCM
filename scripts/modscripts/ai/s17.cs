$S17moveforce = 500;

function S17Think(%obj){
   if(!isObject(%obj))
	return;
   if(%obj.task !$= ""){
	%task = %obj.task;
	%fun = "S17"@%task;
	%obj.mode = %task;
	cancel(%obj.loop);cancel(%obj.loop);cancel(%obj.loop);
	if(%obj.specvar[%task] !$= "")
	   %obj.loop = schedule(10, 0, %fun, %obj, %obj.specvar[%task]);
	else
	   %obj.loop = schedule(10, 0, %fun, %obj);
   }
}

function S17GUARD(%obj,%pos){
   if(!isObject(%obj))
	return;
   %obj.mode = "MOVE";
   S17MOVE(%obj,%pos);
}

function S17MOVE(%obj,%pos){
   if(!isObject(%obj))
	return;
   if(%obj.mode !$= "MOVE")
	return;

   %objpos = %obj.getPosition();
   %dist = vectorDist(%pos,%objpos);
   if(%dist > 10){
      %vec = vectorNormalize(vectorSub(%pos,%objpos));
      %vec = vectorScale(%vec,$S17moveforce);
      %obj.applyImpulse(%objpos,%vec);
   }
   else 
	return;
   %obj.loop = schedule(100, 0, "S17MOVE",%obj,%pos);
}

function S17ATTACK(%obj,%target){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%obj.val = "";
	return;
   }
   if(%obj.mode !$= "ATTACK"){
	%obj.val = "";
	return;
   }

   %objpos = %obj.getPosition();
   %trgpos = %target.getPosition();
   %dist = vectorDist(%trgpos,%objpos);
   if(%dist > 100){
      %vec = vectorNormalize(vectorSub(%pos,%objpos));
      %vec = vectorScale(%vec,$S17moveforce);
      %obj.applyImpulse(%objpos,%vec);
   }
   else {
      %vec = vectorSub(%trgpos,%objpos);
	%random = getRandom(1,2);
	if(%obj.val $= ""){
	   if(%random == 1)
	      %obj.val = "0 0 -1";
	   else
	      %obj.val = "0 0 1";
	}
	%vec = vectorNormalize(vectorCross(%vec,%val));
      %vec = vectorScale(%vec,$S17moveforce);
      %obj.applyImpulse(%objpos,%vec);
   }
   %obj.loop = schedule(100, 0, "S17ATTACK",%obj,%target);
}

function S17REARM(%obj,%target){
   if(!isObject(%obj))
	return;
   if(!isObject(%target)){
	%target.setRepairRate(0);
	return;
   }
   if(%obj.mode !$= "REARM"){
	%target.setRepairRate(0);
	return;
   }

   %objpos = %obj.getPosition();
   %trgpos = %target.getPosition();
   %dist = vectorDist(%trgpos,%objpos);
   %DamageLevel = %targetObject.getDamageLevel();
   if(%dist > 6){
	%vec = vectorNormalize(vectorCross(%vec,%val));
      %vec = vectorScale(%vec,$S17moveforce);
      %obj.applyImpulse(%objpos,%vec);
   }
   else if(%DamageLevel > 0)
	%obj.setRepairRate(0.01);
   else {
	%obj.setRepairRate(0);
	return;
   }
   %obj.loop = schedule(100, 0, "S17ATTACK",%obj,%target);
}