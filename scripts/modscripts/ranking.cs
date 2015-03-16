//--------------------------------------------------
//RANKS
//--------------------------------------------------

$Ranks::MinPoints[0] = 0;
$Ranks::NewRank[0] = "Private";
$Ranks::MinPoints[1] = 250;
$Ranks::NewRank[1] = "Private First Class";
$Ranks::MinPoints[2] = 500;
$Ranks::NewRank[2] = "Corporal";
$Ranks::MinPoints[3] = 1250;
$Ranks::NewRank[3] = "Specialist";
$Ranks::MinPoints[4] = 1800;
$Ranks::NewRank[4] = "Sergeant";
$Ranks::MinPoints[5] = 2550;
$Ranks::NewRank[5] = "Staff Sergeant";
$Ranks::MinPoints[6] = 3600;
$Ranks::NewRank[6] = "Sergeant First Class";
$Ranks::MinPoints[7] = 4800;
$Ranks::NewRank[7] = "Master Sergeant";
$Ranks::MinPoints[8] = 6000;
$Ranks::NewRank[8] = "Second Lieutenant";
$Ranks::MinPoints[9] = 8500;
$Ranks::NewRank[9] = "First Lieutenant";
$Ranks::MinPoints[10] = 9750;
$Ranks::NewRank[10] = "Captain";
$Ranks::MinPoints[11] = 11000;
$Ranks::NewRank[11] = "Major";
$Ranks::MinPoints[12] = 15500;
$Ranks::NewRank[12] = "Lieutenant Colonel";
$Ranks::MinPoints[13] = 18500;
$Ranks::NewRank[13] = "Colonel";
$Ranks::MinPoints[14] = 22500;
$Ranks::NewRank[14] = "Brigadier General";
$Ranks::MinPoints[15] = 30000;
$Ranks::NewRank[15] = "Major General";
$Ranks::MinPoints[16] = 50000;
$Ranks::NewRank[16] = "Lieutenant General";
$Ranks::MinPoints[17] = 75000;
$Ranks::NewRank[17] = "General";
$Ranks::MinPoints[18] = 90000;
$Ranks::NewRank[18] = "General Of The Army";
exec( "prefs/Ranks.cs" );
exec( "prefs/Squads.cs" );
$canRecalcTop5 = 1;

function updateRankScores(%shouldloop,%clearLS){
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++){
	if($Rank::numplayers $= "")
	   $Rank::numplayers=0;
	%cl = ClientGroup.getObject(%i);
	%name = %cl.NameBase;
	if(%cl.lastscore $= "")
	   %cl.lastscore = 0;
	if(%cl.ranknum $= ""){
	   for(%k = 0; %k < $Rank::numplayers; %k++){
		if(%name $= $Rank::Name[%k]){
		   %cl.ranknum = %k;
		   %k = $Rank::numplayers - 1;
		}
		else if(%k >= ($Rank::numplayers - 1)){
		   $Rank::Name[$Rank::numplayers] = %name;
		   $Rank::Rank[$Rank::numplayers] = "Private";
		   $Rank::Score[$Rank::numplayers] = 0;
		   $Rank::numplayers++;
		}
	   }
	   if(%k == 0 && %k == $Rank::numplayers){
		$Rank::Name[$Rank::numplayers] = %name;
		$Rank::Rank[$Rank::numplayers] = "Private";
		$Rank::Score[$Rank::numplayers] = 0;
		$Rank::numplayers++;
	   }
	}
	if($Rank::Squad[%cl.ranknum] !$= ""){
	   %squad = getWord($Rank::Squad[%cl.ranknum],1);
	   $squad::Score[%squad] = $squad::Score[%squad] + (%cl.score - %cl.lastscore);
	   %mem = 0;
	   %num = getWord($Rank::squad[%cl.ranknum],1)@%mem;
	   while($squad::member[%num] !$= ""){
		%player = $squad::member[%num];
   		for(%l = 0; %l < %count; %l++){
		   %clt = ClientGroup.getObject(%l);
		   if(%clt.ranknum == %player){
			$Rank::Squadscore[%player] = $Rank::Squadscore[%player] + ((%cl.score - %cl.lastscore) / 2);
			$Rank::Score[%player] = $Rank::Score[%player] + ((%cl.score - %cl.lastscore) / 2);
			%l = %count;
		   }
		}
		%mem++;
	      %num = %squad@%mem;
	   }
	}
	$Rank::Score[%cl.ranknum] = $Rank::Score[%cl.ranknum] + (%cl.score - %cl.lastscore);
	%stat = $Rank::Score[%cl.ranknum];
	%cl.lastscore = %cl.score;
	for(%j = 18; %j > 0; %j--){
	   if($Rank::Score[%cl.ranknum] >= $Ranks::MinPoints[%j]){
		if($Rank::Rank[%cl.ranknum] !$= $Ranks::NewRank[%j]){
		   $Rank::Rank[%cl.ranknum] = $Ranks::NewRank[%j];
		   messageAll('msgClient',"\c3"@%name@" \c2has become a\c3 "@$Ranks::NewRank[%j]@" \c2with a score of\c3 "@$Rank::Score[%cl.ranknum]@"\c2!");
		   bottomPrint(%cl, "Congratulations "@%name@" you have been promoted to the rank of: "@$Ranks::NewRank[%j]@"!", 5, 2 );
		}
		%j = 1;
	   }
	}
	if(%clearLS == 1){
	   %cl.lastscore = 0;
	   %cl.Zkills = 0;
	}
   }
   export( "$squad::*", "prefs/Squads.cs", false );
   export( "$Rank::*", "prefs/Ranks.cs", false );
   if(%shouldloop == 1)
	$RankUpdate = schedule(60000,0,"updateRankScores",1);
}

function ccCheckStats(%client, %args){
   if(%args $= ""){
	if(%client.ranknum $= ""){
	   messageClient(%client, 'MsgClient', "\c2Please wait a minute for your stats to load");
	   return;
	}
	%name = %client.NameBase;
	%Rank = $Rank::Rank[%client.ranknum];
	%Stats = $Rank::Score[%client.ranknum];
	for(%i = 18; %i >= 0; %i--){
	   if($Rank::Score[%client.ranknum] >= $Ranks::MinPoints[%i]){
		%nextrank = $Ranks::NewRank[(%i + 1)];
		%nextrankscore = $Ranks::MinPoints[(%i + 1)];
		%i = 0;
	   }
	}
	messageClient(%client, 'MsgClient', "\c2Your current rank is a\c3 "@%Rank@" \c2and you have a total of\c3 "@%stats@" \c2points. Your next rank is a\c3 "@%nextrank@" \c2and you need\c3 "@(%nextrankscore - %stats)@" \c2points.");
   }
   else{
	%count = ClientGroup.getCount();
	for(%i = 0; %i < %count; %i++){
	   %cl = ClientGroup.getObject(%i);
	   if(%cl.nameBase $= %args){
		if(%cl.ranknum $= ""){
		   messageClient(%client, 'MsgClient', "\c2Please wait a minute for this persons stats to load");
		   return;
		}
		%Rank = $Rank::Rank[%cl.ranknum];
		%Stats = $Rank::Score[%cl.ranknum];
		messageClient(%client, 'MsgClient', "\c3"@%args@"\'s \c2rank is a\c3 "@%Rank@"\c2 and his total score is: \c3"@%stats@"\c2 points.");
		%i = %count;
	   }
	   else if(%i == (%count - 1))
		messageClient(%client, 'MsgClient', "\c3"@%args@" \c2is not a valid player.");
    }
    }
}

function FindTopRanks()
{
   %noabove = 1000000;
   for (%i = 1; %i <= 5; %i++)
   {
      for (%j = 0; %j < $Rank::numplayers; %j++)
      {
         if (($Rank::Score[%j] >= %highest || %highest $= "") && $Rank::Score[%j] < %noabove)
         {
            %highest = $Rank::Score[%j];
		    %player = %j;
	        }
	     }

   $Rank::Top[%i] = $Rank::Name[%player];
   $Rank::TopScore[%i] = %highest;
   %noabove = %highest;
   %highest = "";
   }
}

function ccTop5(%client,%args)
{
   if($canrecalcTop5 == 1)
   {
      FindTopRanks();
	  $canrecalcTop5 = 0;
	  schedule(30000, 0, "restorerecalc");
   }
      messageClient(%client, 'MsgClient', "\c2Top five players are:");

      if ($Rank::numplayers > 5)
      {
         %num = 5;
      } else if ($Rank::numplayers <= 5)
         %num = $Rank::numplayers;

      for(%i = 1; %i <= %num; %i++)
      {
	      messageClient(%client, 'MsgClient', "\c2"@%i@". "@$Rank::Top[%i]@" - Score: "@$Rank::TopScore[%i]@"");
   }
}

function restorerecalc(){
   $canreclacTop5 = 1;
}

//--------------------------------------------------
//SQUADS
//--------------------------------------------------

function cccreatesquad(%sender, %args){
   if(%sender.ranknum $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please wait a minute for your stats to load.');
	return;
   }
   if($Rank::Score[%sender.ranknum] < $Rank::MinPoints[4]){
	messageclient(%sender, 'MsgClient', '\c2You must have a Sergeant rank or higher to make a squad.');
	return;
   }
   if(%args $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please specify the name of new squad.');
	return;
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(getWord(%args,0) $= $squad::Name[%i]){
	   messageclient(%sender, 'MsgClient', '\c2This squad already exists.');
	   return;
	}
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%sender.namebase $= $squad::Leader[%i]){
	   messageclient(%sender, 'MsgClient', '\c2You already have a squad, you may not create a new one.');
	   return;
	}
      if($squad::Leader[%i] $= "")
	   %replacable = %i;
   }
   if($squad::numsquads $= "")
	$squad::numsquads = 0;
   if(%replacable !$= ""){
      $squad::Name[%replacable] = getWord(%args,0);
      $squad::Leader[%replacable] = %sender.namebase;
      $squad::Score[%replacable] = 0;
   } else{
	$squad::Name[$squad::numsquads] = getWord(%args,0);
	$squad::Leader[$squad::numsquads] = %sender.namebase;
	$squad::Score[$squad::numsquads] = 0;
	$squad::numsquads++;
   }
   messageclient(%sender, 'MsgClient', "\c2Squad\c3 "@getWord(%args,0)@" \c2has been created.");
   ccJoin(%sender,getWord(%args,0));
}

function ccJoin(%sender,%name){
   if(%sender.ranknum $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please wait a minute for your stats to load.');
	return;
   }
   if($Rank::Squad[%sender.ranknum] !$= ""){
	messageClient(%client, 'MsgClient', "\c2You are already in a squad.");
	return;
   }
   if(%name $= ""){
	messageclient(%sender, 'MsgClient', '\c2You have not been invited to a squad yet.');
	return;
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%name $= $squad::Name[%i]){
	   %mem = 0;
	   %num = %i@%mem;
	   while($squad::member[%num] !$= ""){
		%mem++;
	      %num = %i@%mem;
	   }
	   $squad::member[%num] = %sender.ranknum;
	   $Rank::Squad[%sender.ranknum] = %name@" "@%i;
	   $Rank::SquadScore[%sender.ranknum] = 0;
	   messageclient(%sender, 'MsgClient', "\c2You are now a part of squad\c3 "@%name@"\c2.");
	   return;
	}
   }
   messageclient(%sender, 'MsgClient', "\c2Squad\c3 "@%name@" \c2dosent exist.");
}

function ccLeaveSquad(%sender,%args){
   if(%sender.ranknum $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please wait a minute for your stats to load.');
	return;
   }
   if($Rank::Squad[%sender.ranknum] $= ""){
	messageClient(%sender, 'MsgClient', "\c2You are not currently in a squad.");
	return;
   }
   %squad = getWord($Rank::Squad[%sender.ranknum],1);
   if($squad::Leader[%squad] $= %sender.namebase){
	$squad::Leader[%squad] = "";
	$squad::Name[%squad] = "";
	$squad::Score[%squad] = "";
	%mem = 1;
	%num = %squad@%mem;
	while($squad::member[%num] !$= ""){
	   $Rank::Squad[$squad::member[%num]] = "";
	   $Rank::SquadScore[$squad::member[%num]] = "";

	   %count = ClientGroup.getCount();
	   for(%i = 0; %i < %count; %i++){
		%cl = ClientGroup.getObject(%i);
		if(%cl.ranknum == $squad::member[%num])
		   %i = %count;
	   }

	   messageClient(%cl, 'MsgClient', "\c2Your squad has disbanned.");
	   $squad::member[%num] = "";

	   %mem++;
	   %num = %squad@%mem;
	}
	$Rank::Squad[%sender.ranknum] = "";
	$Rank::SquadScore[%sender.ranknum] = "";
      $squad::member[%squad@"0"] = "";
	messageClient(%sender, 'MsgClient', "\c2You have disbanned your squad.");
   } else {
	%mem = 0;
	%num = %squad@%mem;
	while($squad::member[%num] !$= ""){
	   if(%sender.ranknum == $squad::member[%num])
		%plrnum = %num;
	   %mem++;
	   %num = %squad@%mem;
	}
	%last = %squad@(%mem - 1);
	$Rank::Squad[%sender.ranknum] = "";
	$Rank::SquadScore[%sender.ranknum] = "";
	if(%plrnum != %last){
	   $squad::member[%plrnum] = $squad::member[%last];
	   $squad::member[%last] = "";
	}
	messageClient(%sender, 'MsgClient', "\c2You have left the Squad.");
   }
}

function ccInvite(%sender, %args){
   if(%args $= ""){
	messageclient(%sender, 'MsgClient', '\c2You must specify a player.');
	return;
   }
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++){
	%cl = ClientGroup.getObject(%i);
	if(%cl.nameBase $= %args)
	   %i = %count;
	else if(%i == (%count - 1)){
	   messageClient(%sender, 'MsgClient', "\c3"@%args@" \c2is not a valid player.");
	   return;
	}
   }
   if($Rank::Squad[%cl.ranknum] !$= ""){
	messageClient(%sender, 'MsgClient', "\c3"@%args@" \c2is already in a squad.");
	return;
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%sender.namebase $= $squad::Leader[%i]){
	   %cl.sqinv = $squad::Name[%i];
	   messageclient(%sender, 'MsgClient', "\c3"@%args@" \c2as been invited to your squad.");
	   messageclient(%cl, 'MsgClient', "\c2You have been invited to squad\c3 "@$squad::Name[%i]@" \c2to join, type:\c3 /Join\c2.");
	   return;
	}
   }
   messageclient(%sender, 'MsgClient', "\c2You are not a squad leader and cannot invite.");
}

function ccS(%sender, %args){
   if($squad::Name[getWord($Rank::Squad[%sender.ranknum],1)] $= ""){
	messageclient(%sender, 'MsgClient', "\c2You are not in a squad.");
	return;
   }
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++){
	%cl = ClientGroup.getObject(%i);
	%mem = 0;
	%num = getWord($Rank::Squad[%sender.ranknum],1)@%mem;
	while($squad::member[%num] !$= ""){
	   if(%cl.ranknum == $squad::member[%num] && %cl.team == %sender.team)
		messageclient(%cl, 'MsgClient', "\c0[Squad Chat] \c2"@%sender.namebase@": \c3"@%args);
	   %mem++;
	   %num = getWord($Rank::Squad[%sender.ranknum],1)@%mem;
	}
   }
}

function ccListSquads(%client, %args){
   for(%i = 0; %i < $Squad::numsquads; %i++){
	messageClient(%client, 'MsgClient', "\c2SQUAD "@(%i + 1)@": \c3"@$squad::Name[%i]@" \c2SCORE: \c3"@$squad::score[%i]@"");
	%temp = 0;
	%num = %i@%temp;
	while($squad::member[%num] !$= ""){
	   if(%temp == 0)
		%prefix = "Leader:";
	   else
		%prefix = "member"@(%temp + 1)@":";
	   messageClient(%client, 'MsgClient', "\c2"@%prefix@" \c3"@$rank::Name[$squad::member[%num]]@" \c2teamscore: \c3"@$rank::squadscore[$squad::member[%num]]@"");
	   %temp++;
	   %num = %i@%temp;
	}
	if((%i + 1) < $squad::numsquads)
	   messageClient(%client, 'MsgClient', "\c2 ");
   }
}

function ccRequestInvite(%client, %args){
   if(%client.ranknum $= ""){
	messageClient(%client, 'MsgClient', "\c2Please wait a minute for your stats to load");
	return;
   }
   if($rank::squad[%client.ranknum] !$= ""){
	messageClient(%client, 'MsgClient', "\c2You are already in a squad.");
	return;
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%args $= $squad::Name[%i]){
	   messageclient(%sender, 'MsgClient', "\c2Request was sent to squa\c3 "@%args@"\c2.");
	   for(%j = 0; %j < %count; %j++){
		%cl = ClientGroup.getObject(%j);
		if(%cl.namebase $= $squad::Leader[%i])
		   messageclient(%cl, 'MsgClient', "\c3"@%client.namebase@"\c2 has requested to join your squad.");
	   }
	   return;
	}
   }
   messageclient(%sender, 'MsgClient', "\c2Squad\c3 "@%args@" \c2dosent exist.");
}

//--------------------------------------------------
//COMMANDS
//--------------------------------------------------

function ccO(%sender,%args){
   if(%sender.ranknum $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please wait a minute for your stats to load.');
	return;
   }
   if($Rank::Score[%sender.ranknum] < $Ranks::MinPoints[12]){
	messageclient(%sender, 'MsgClient', '\c2You must have a General or Commander rank to give orders.');
	return;
   }
   if(%args $= "" || getWord(%args,1) $= ""){
	messageclient(%sender, 'MsgClient', '\c2You must specify the order and then the target squad.');
	return;
   }
   if(getWord(%args,0) !$= "attack" && getWord(%args,0) !$= "defend"){
	messageclient(%sender, 'MsgClient', '\c2Order must be either "attack" or "defend".');
	return;
   }
   %order = getWord(%args,0);
   %name = getWord(%args,1);
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%name $= $squad::Name[%i]){
	   %check = 1;
	   %j = %i;
	}
   }
   if(%check != 1){
	messageclient(%sender, 'MsgClient', "\c2Squad\c3 "@%name@" \c2dosent exist.");
	return;
   }
   %obj = %sender.getControlObject();
   %eyeTrans = %obj.getEyeTransform();
   %eyePos = posFromTransform(%eyeTrans);
   %eyeVec = vectorScale(%obj.getEyeVector(),1000);
   %searchResult = containerRayCast(%eyePos, vectorAdd(%eyeVec,%eyePos), $TypeMasks::TerrainObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::VehicleObjectType, %obj);
   if(%searchResult){
	%mem = 0;
	%num = %j@%mem;
	while($squad::member[%num] !$= ""){
	   %count = ClientGroup.getCount();
	   for(%i = 0; %i < %count; %i++){
		%cl = ClientGroup.getObject(%i);
		if(%cl.ranknum == $squad::member[%num] && %cl.team == %sender.team)
		   messageclient(%cl, 'MsgClient', "\c2A general has ordered your squad to\c3 "@%order@" \c2this location.");
	   }
	   %mem++;
	   %num = %j@%mem;
	}

	%pos = posFromRaycast(%searchResult);
	%wa=new Waypoint() {
	   position = %pos;
	   rotation = "1 0 0 0";
	   dataBlock = "WayPointMarker";
	   team = %sender.team;
	   name = %name@" "@%order@" this position";
	};
	MissionCleanup.add(%wa);

	%nveh = 0;
	%nplr = 0;
	%nTrt = 0;
	%ndep = 0;
	InitContainerRadiusSearch(%pos, 100, $TypeMasks::PlayerObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::TurretObjectType | $TypeMasks::VehicleObjectType);
	while ((%targetObject = containerSearchNext()) != 0){
	   %target = getWord(%targetObject,0);
	   if(%order $= "attack" && %target.team != %sender.team){
		if(%target.getType() & $TypeMasks::PlayerObjectType)
		   %nplr++;
		if(%target.getType() & $TypeMasks::StaticShapeObjectType){
		   %Ttype = %target.getDataBlock().className ;
		   if(!(%Ttype $= "wall" || %Ttype $= "wWall" || %Ttype $= "spine" || %Ttype $= "mSpine" || %Ttype $= "floor" || %Ttype$= "forcefield"))
		      %ndep++;
		}
		if(%target.getType() & $TypeMasks::TurretObjectType)
		   %ntrt++;
		if(%target.getType() & $TypeMasks::VehicleObjectType)
		   %nveh++;
	   }
	   else if(%order $= "defend" && %target.team == %sender.team){
		if(%target.getType() & $TypeMasks::PlayerObjectType)
		   %nplr++;
		if(%target.getType() & $TypeMasks::StaticShapeObjectType){
		   %Ttype = %target.getDataBlock().className ;
		   if(!(%Ttype $= "wall" || %Ttype $= "wWall" || %Ttype $= "spine" || %Ttype $= "mSpine" || %Ttype $= "floor" || %Ttype$= "forcefield"))
		      %ndep++;
		}
		if(%target.getType() & $TypeMasks::TurretObjectType)
		   %ntrt++;
		if(%target.getType() & $TypeMasks::VehicleObjectType)
		   %nveh++;
	   }
	}
	%numtrg = %ntrt@" "@%nplr@" "@%nveh@" "@%ndep;
	%numtrgs = %ntrt + %nplr + %nveh + %ndep;
	if(%numtrgs >= 3){
	   schedule(%numtrgs * 20000, 0, "completeCommand", %order, %name, %numtrg, %pos, %sender);
	   schedule(10000, 0, "commandCheckupLoop", %name, %pos, %sender, (%numtrgs * 2) - 1);
	   %wa.schedule(%numtrgs * 20000, "delete");
	}
	else{
	   messageclient(%sender, 'MsgClient', "\c2Please specify a location with more targets.");
	   %wa.schedule(100, "delete");
	}
   }
   else
	messageclient(%sender, 'MsgClient', "\c2Please specify a valid target position.");
}

function commandCheckupLoop(%name, %pos, %issuer, %LCount){
   if(%LCount < 1)
	return;
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%name $= $squad::Name[%i]){
	   %j = %i;
	}
   }
   %mem = 0;
   %num = %j@%mem;
   while($squad::member[%num] !$= ""){
      %count = ClientGroup.getCount();
	%player = $squad::member[%num];
      for(%i = 0; %i < %count; %i++){
	   %cl = ClientGroup.getObject(%i);
	   if(%cl.ranknum == %player && %cl.team == %issuer.team){
	      %clpos = %cl.player.getPosition();
		if(vectorDist(%clpos,%pos) <= 100){
		   bottomPrint(%cl, "\c2"@(%LCount * 10)@" seconds remain until objective is complete.", 5);
		   if(%cl.objectivecount $= "")
			%cl.objectivecount = 0;
		   %cl.objectivecount++;
		}
		else
		   bottomPrint(%cl, "\c2You are to far away from the objective zone, you have "@(%LCount * 10)@" seconds left.", 5);
	   }
      }
      %mem++;
      %num = %j@%mem;
   }
   %LCount--;
   schedule(10000, 0, "commandCheckupLoop", %name, %pos, %issuer, %LCount);
}

function completeCommand(%order, %name, %numtrg, %pos, %issuer){
   %oTrt = getWord(%numtrg,0);
   %oplr = getWord(%numtrg,1);
   %oveh = getWord(%numtrg,2);
   %odep = getWord(%numtrg,3);
   %nTrt = 0;
   %nplr = 0;
   %nveh = 0;
   %ndep = 0;
   InitContainerRadiusSearch(%pos, 100, $TypeMasks::PlayerObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::TurretObjectType | $TypeMasks::VehicleObjectType);
   while ((%targetObject = containerSearchNext()) != 0){
	%target = getWord(%targetObject,0);
	if(%order $= "attack" && %target.team != %issuer.team){
	   if(%target.getType() & $TypeMasks::PlayerObjectType)
		%nplr++;
	   if(%target.getType() & $TypeMasks::StaticShapeObjectType){
		%Ttype = %target.getDataBlock().className ;
		if(!(%Ttype $= "wall" || %Ttype $= "wWall" || %Ttype $= "spine" || %Ttype $= "mSpine" || %Ttype $= "floor" || %Ttype$= "forcefield"))
		   %ndep++;
	   }
	   if(%target.getType() & $TypeMasks::TurretObjectType)
		%ntrt++;
	   if(%target.getType() & $TypeMasks::VehicleObjectType)
		%nveh++;
	}
	else if(%order $= "defend" && %target.team == %issuer.team){
	   if(%target.getType() & $TypeMasks::PlayerObjectType)
		%nplr++;
	   if(%target.getType() & $TypeMasks::StaticShapeObjectType){
		%Ttype = %target.getDataBlock().className ;
		if(!(%Ttype $= "wall" || %Ttype $= "wWall" || %Ttype $= "spine" || %Ttype $= "mSpine" || %Ttype $= "floor" || %Ttype$= "forcefield"))
		   %ndep++;
	   }
	   if(%target.getType() & $TypeMasks::TurretObjectType)
		%ntrt++;
	   if(%target.getType() & $TypeMasks::VehicleObjectType)
		%nveh++;
	}
   }
   %numtrg = %ntrt@" "@%nplr@" "@%nveh@" "@%ndep;
   %numtrgs = %otrt + %oplr + %oveh + %odep;
   %points = ((%otrt - %ntrt) * 4) +
		((%oplr - %nplr) * 3) +
		((%oveh - %nveh) * 2) +
		((%odep - %ndep) * 2);
   if(%order $= "defend"){
	%startpoints = (%otrt * 8) + (%oplr * 6) + (%oveh * 4) + (%odep * 4);
	%points = %startpoints - %points;
	%percentRemaining = ((%ntrt + %nplr + %nveh + %ndep) / (%otrt + %oplr + %oveh + %odep)) * 100;
	if(%percentRemaining >= 75){
	   %status = "success";
	   %points = %points + (15 * (%percentRemaining / 100) * %numtrgs);
	   %recomend = "keep up the good work!";
	}
	else{
	   %status = "failure";
	   %points = %points - (7.5 * ((100 - %percentRemaining) / 100) * %numtrgs);
	   %recomend = "try harder next time.";
	}
   }
   else{
	%percentRemaining = ((%ntrt + %nplr + %nveh + %ndep) / (%otrt + %oplr + %oveh + %odep)) * 100;
	if(%percentRemaining <= 50){
	   %status = "success";
	   %points = %points + (20 * ((100 - %percentRemaining) / 100) * %numtrgs);
	   %recomend = "keep up the good work!";
	}
	else{
	   %status = "failure";
	   %points = %points - (10 * (%percentRemaining / 100) * %numtrgs);
	   %recomend = "try harder next time.";
	}
   }
   for(%i = 0; %i < $squad::numsquads; %i++){
	if(%name $= $squad::Name[%i]){
	   %j = %i;
	}
   }
   %mem = 0;
   %num = %j@%mem;
   while($squad::member[%num] !$= ""){
      %count = ClientGroup.getCount();
	%player = $squad::member[%num];
      for(%i = 0; %i < %count; %i++){
	   %cl = ClientGroup.getObject(%i);
	   if(%cl.ranknum == %player && %cl.team == %issuer.team){
	      %clpos = %cl.player.getPosition();
		if((vectorDist(%clpos,%pos) <= 50 && %order $= "attack") || %cl.objectivecount >= (%numtrgs - 1) * 1.5){
		   messageclient(%cl, 'MsgClient', "\c2Your Objective was deemed a "@%status@" and you were given "@%points@" for this objective. You should "@%recomend);
		   $Rank::Squadscore[%player] = $Rank::Squadscore[%player] + %points;
		   $Rank::Score[%player] = $Rank::Score[%player] + %points;
		}
		else{
		   messageclient(%cl, 'MsgClient', "\c2You were to far away from the objective marker. "@(3 * %numtrgs)@" points were deducted from your score.");
		   $Rank::Squadscore[%player] = $Rank::Squadscore[%player] - (4 * %numtrgs);
		   $Rank::Score[%player] = $Rank::Score[%player] - (3 * %numtrgs);
		}
		%cl.objectivecount = 0;
	   }
      }
      %mem++;
      %num = %j@%mem;
   }
}

//--------------------------------------
//Force Capabilitys
//--------------------------------------

function ccforce(%sender, %args){
   if(%sender.ranknum $= ""){
	messageclient(%sender, 'MsgClient', '\c2Please wait a minute for your stats to load.');
	return;
   }
   if($Rank::Score[%sender.ranknum] < $Ranks::MinPoints[8]){
	messageclient(%sender, 'MsgClient', '\c2You are not high enough rank to force players.');
	return;
   }
   if(%args $= ""){
	messageclient(%sender, 'MsgClient', '\c2You must specify what you are forcing, "join" or "leave".');
	return;
   }
   %cmd = getWord(%args, 0);
   if(%cmd $= "join"){
	%squad = getWord(%args, 1);
	%target = getWords(%args, 2, 1 + getNumberOfWords(%args));
	if(%squad $= "" || %target $= ""){
	   messageclient(%sender, 'MsgClient', '\c2You must specify the squad name and then player name for this to work.');
	   return;
	}
	%count = ClientGroup.getCount();
	for(%i = 0; %i < %count; %i++){
	   %cl = ClientGroup.getObject(%i);
	   if(%cl.namebase $= %target)
		%i = %count;
	   else if(%i == (%count - 1)){
		messageClient(%sender, 'MsgClient', "\c2"@%target@" is not a valid player.");
		return;
	   }
	}
	if($Rank::Score[%cl.ranknum] >= $Ranks::MinPoints[8] && !($Rank::Score[%cl.ranknum] < $Ranks::MinPoints[14] && $Rank::Score[%sender.ranknum] >= $Ranks::MinPoints[14])){
	   messageclient(%sender, 'MsgClient', '\c2You may not force this player, he has too high of a rank.');
	   return;
	}
      for(%i = 0; %i < $squad::numsquads; %i++){
	   if(%squad $= $squad::Name[%i]){
		if($Rank::Squad[%cl.ranknum] !$= ""){
		   messageclient(%cl, 'MsgClient', '\c2Higher Rank forced:');
		   ccLeaveSquad(%cl,"");
		   messageclient(%cl, 'MsgClient', '\c2 ');
		}
		messageclient(%sender, 'MsgClient', "\c3"@%target@" \c2has joined squad\c3 "@%squad@"\c2.");
		messageclient(%cl, 'MsgClient', '\c2Higher Rank forced:');
		ccJoin(%cl, %squad);
	      return;
	   }
         if($squad::Leader[%i] $= "")
	      %replacable = %i;
      }

	if($squad::numsquads $= "")
	   $squad::numsquads = 0;
	if(%replacable !$= ""){
         $squad::Name[%replacable] = %squad;
         $squad::Leader[%replacable] = %cl.namebase;
         $squad::Score[%replacable] = 0;
	} else{
	   $squad::Name[$squad::numsquads] = %squad;
	   $squad::Leader[$squad::numsquads] = %cl.namebase;
	   $squad::Score[$squad::numsquads] = 0;
	   $squad::numsquads++;
	}
	messageclient(%sender, 'MsgClient', "\c2Squad\c3 "@%squad@" \c2has been created with\c3 "@%target@" \c2as leader.");
	if($Rank::Squad[%cl.ranknum] !$= ""){
	   messageclient(%cl, 'MsgClient', '\c2Higher Rank forced:');
	   ccLeaveSquad(%cl,"");
	   messageclient(%cl, 'MsgClient', '\c2 ');
	}
	messageclient(%cl, 'MsgClient', '\c2Higher Rank forced:');
	ccJoin(%cl, %squad);

   }
   else if(%cmd $= "leave"){
	%target = getWords(%args, 1, getNumberOfWords(%args) - 1);
	echo(getNumberOfWords(%args));
	echo(%target);
	if(%target $= ""){
	   messageclient(%sender, 'MsgClient', '\c2You must specify the person you are forcing.');
	   return;
	}
	%count = ClientGroup.getCount();
	for(%i = 0; %i < %count; %i++){
	   %cl = ClientGroup.getObject(%i);
	   if(%cl.namebase $= %target)
		%i = %count;
	   else if(%i == (%count - 1)){
		messageClient(%client, 'MsgClient', "\c3"@%target@" \c2is not a valid player.");
		return;
	   }
	}
	if($Rank::Score[%cl.ranknum] >= $Ranks::MinPoints[8] && !($Rank::Score[%cl.ranknum] < $Ranks::MinPoints[14] && $Rank::Score[%sender.ranknum] >= $Ranks::MinPoints[14])){
	   messageclient(%sender, 'MsgClient', '\c2You may not force this player, he has too high of a rank.');
	   return;
	}
	if($Rank::Squad[%cl.ranknum] !$= ""){
	   messageclient(%cl, 'MsgClient', '\c2Higher Rank forced:');
	   ccLeaveSquad(%cl,"");
	   messageclient(%sender, 'MsgClient', '\c3'@%target@' \c2has been forced out of his squad.');
	}
	else
	   messageclient(%sender, 'MsgClient', '\c2This person does not have a squad to leave.');
   }
   else
	messageclient(%sender, 'MsgClient', '\c2Please use "Join" or "leave" as command.');
}

//--------------------------------------
//Misc
//--------------------------------------

function cleanRanks(){
   for(%i = 0; %i < $Rank::numplayers; %i++){
	if($Rank::Score[%i] <= 10){
	   $Rank::Score[%i] = "";
	   $Rank::Name[%i] = "";
	   $Rank::Rank[%i] = "";
	}
   }
   for(%i = 0; %i < $Rank::numplayers; %i++){
	if($Rank::Score[%i] $= ""){
	   %replacenum = $Rank::numplayers;
	   while($Rank::Score[%replacenum] $= ""){
		%replacenum--;
	   }
	   if(%i > %replacenum){
		$Rank::numplayers = %i;
		return;
	   }
	   $Rank::Score[%i] = $Rank::Score[%replacenum];
	   $Rank::Name[%i] = $Rank::Name[%replacenum];
	   $Rank::Rank[%i] = $Rank::Rank[%replacenum];
	   $Rank::Score[%replacenum] = "";
	   $Rank::Name[%replacenum] = "";
	   $Rank::Rank[%replacenum] = "";
	}
   }
}

function ccSOL(%sender, %args){
   if(%sender.spawnOnLead $= "" || %sender.spawnOnLead == 0){
	%sender.spawnOnLead = 1;
	messageclient(%sender, 'MsgClient', '\c2You will now spawn on your squad leader.');
   } else {
	%sender.spawnOnLead = 0;
	messageclient(%sender, 'MsgClient', '\c2You will no longer spawn on your squad leader.');
   }
}

function getNumberOfWords(%path){
   %number = 0;
   for(%i = 0; %i < 1000; %i++){
	if(getWord(%path,%i) !$= "")
	   %number++;
	else
	   return %number;
   }
}
