
deleteFile("missions/mapscripts/teleporters.cs.dso");
//------------teleport code by sparky----------
//-------------------V2.0.0---------------------
//------------special effects by TseTse--------



datablock StaticShapeData(Teleporter)
{

   catagory = "Teleporters";
//   shapefile = "Nexusbase.dts";
   shapefile = "nexusbase.dts";
   mass = 10;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   targetNameTag = '';
   targetTypeTag = 'Teleporter';
//----------------------------------
   maxDamage = 1.00;
   destroyedLevel = 1.00;
   disabledLevel = 0.70;
   explosion      = ShapeExplosion;
	expDmgRadius = 8.0;
	expDamage = 0.4;
	expImpulse = 1500.0;
	// don't allow this object to be damaged in non-team-based
	// mission types (DM, Rabbit, Bounty, Hunters)
	noIndividualDamage = true;

   dynamicType = $TypeMasks::StationObjectType;
	isShielded = true;
	energyPerDamagePoint = 75;
	maxEnergy = 50;
	rechargeRate = 0.35;
   doesRepair = true;
   humSound = StationInventoryHumSound;

   cmdCategory = "Support";
   cmdIcon = CMDStationIcon;
   cmdMiniIconName = "commander/MiniIcons/com_inventory_grey";

   debrisShapeName = "debris_generic.dts";
   debris = StationDebris;
//----------------------------------------
};
datablock Staticshapedata(teledestroyed) : teleporter
{
   shapefile = "station_teleport.dts";

};


$playerreject = 6;
function Teleporter::onDestroyed(%data, %obj, %prevState)
{
   //set the animations
   %obj.playThread(1, "transition");
   %obj.setThreadDir(1, true);
    %obj.setDamageState(Destroyed);
    %obj.setDatablock(teledestroyed);
   %obj.getDataBlock().onLosePowerDisabled(%obj);
 
}
//---this is where I create the triggers and put them right over the nexus base's
function teleporter::onEnabled(%data, %obj, %prevState)
{
 echo(%obj);

  %obj.setDatablock(teleporter);
  Parent::onEnabled(%data, %obj, %prevState);
}
function teledestroyed::onEnabled(%data, %obj, %prevState)
{
 echo(%obj);
  %level = %obj.getdamagelevel();
  %obj.setDatablock(teleporter);
  %obj.setdamagelevel(%level);
if(%obj.ispowered())
   {
   %obj.playthread(1, "transition");
   %obj.setThreadDir(1, false);
   %obj.playThread(0, "ambient");
   %obj.setThreadDir(0, true);
   }
   else
        {
        %obj.playThread(0, "transition");
        %obj.setThreadDir(0, false);
        }
  Parent::onEnabled(%data, %obj, %prevState);
}

function Teleporter::gainPower(%data, %obj)
{

  %obj.setDatablock(teleporter);
   Parent::gainPower(%data, %obj);
   %obj.playthread(1, "transition");
   %obj.setThreadDir(1, false);
   %obj.playThread(0, "ambient");
   %obj.setThreadDir(0, true);
 }
function Teleporter::losePower(%data, %obj)
{
   %obj.playThread(0, "transition");
   %obj.setThreadDir(0, false);
   Parent::losePower(%data, %obj);
}
//---this is where I create the triggers and put them right over the nexus base's
function Teleporter::onAdd(%this, %obj)
{
   Parent::onAdd(%this, %obj);

                   %tp = %obj;
                   %trigger = new Trigger()
                            {
                             dataBlock = NewTeleportTrigger;
                             polyhedron = "-0.75 0.75 0.1 1.5 0.0 0.0 0.0 -1.5 0.0 0.0 0.0 2.3";
                             };

            MissionCleanup.add(%trigger);
            if(%tp.logoscale $= "")
                    %tp.logoscale = " ";
            if(%tp.noflag $= "")
                    %tp.noflag = " ";
            if(%tp.oneway $= "")
                    %tp.oneway = " ";
            if(%tp.message $= "")
                    %tp.message = " ";

            %trigger.setTransform(%tp.getTransform());
            %trigger.targetbase = $lastteleporter;
            %trigger.team = %tp.team;
	        %trigger.motherObj = %tp;     // tag relative object
	        %trigger.sourcebase = %tp;     // tag relative object
            %trigger.message = %tp.message;
            %trigger.logoscale = %tp.logoscale;
            %trigger.noflag = %tp.noflag;
            %trigger.oneway = %tp.oneway;
            %tp.trigger = %trigger;
            $lastteleporter.targetbase =  %tp.trigger;
            $lastteleporter = %tp.trigger;
            $linkflag = $linkflag + 1;
                      if($linkflag == 2)
                                   {
                                   $lastteleporter = 0;
                                   $linkflag = 0;
                                   }
 //--------------do we need power?-----------------------
            %tp.playThread(1, "ambient");
            %tp.playThread(0, "transition");
            %tp.playThread(0, "ambient");


            %newHolo = getTaggedString(game.getTeamSkin(%trigger.team)) @ "Logo";
            %teleholo1 = getTaggedString(game.getTeamSkin(1)) @ "Logo";
            %teleholo2 = getTaggedString(game.getTeamSkin(2)) @ "Logo";

            %pos = %trigger.position;

            if(%trigger.logoscale !$= " ")
                      {
                      if(%tp.team != 0)
                                  {
                                  %holo = new StaticShape()
                                      {
                                      rotation = rotfromtransform(%trigger.gettransform());
                                      position = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 1;
                                      dataBlock = %newHolo;
                                      scale = %trigger.logoscale;
                                      };


                                    MissionCleanup.add(%holo);
                                    %trigger.sourcebase.holo = %holo;

                                    }
                       }

  if(%tp.waypoint !$= "")
      {
		%wp =	new WayPoint()
            {
				scale = "1 1 1";
				nameTag = %tp.waypoint;
				dataBlock = "WayPointMarker";
				lockCount = "0";
				homingCount = "0";
				name = %tp.waypoint;
			};

            MissionCleanup.add(%wp);
            %wp.setTransform(%tp.getTransform());
         }
         if(%tp.team == 0)
                     %logostatus = schedule(1000,0,checklogostatus,%tp);
}


datablock TriggerData(NewTeleportTrigger)
{
   tickPeriodMS = 30;
};
//--------------teleporter code here------------------



function setPlayersPosition2(%data, %obj, %trigger, %colObj)
{
   %vel = getWords(%colObj.getVelocity(), 0, 1) @ " 0";
   if((VectorLen(%vel) < 22) && (%obj.triggeredBy != %colObj))
   {
      %pos = %trigger.position;
      %colObj.setvelocity("0 0 0");
      %rot = getWords(%colObj.getTransform(),3, 6);
      %colObj.setTransform(getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 0.8 @ " " @ %rot);  //center player on object  
      %colObj.setMoveState(true);
      return true;
   }
   return false;
}

function NewTeleportTrigger::onEnterTrigger(%data, %trigger, %player)
{
         %colObj = %player;
         %client = %player.client;


  if(%player.transported $= "1")  // if this player was just transported
   {
   %player.transported = "0";
   %colObj.setMoveState(false);
   %player.llamathread = schedule(3000,0,"playerdamage",%player, true);
   return; // then get out or it will never stop
   }
//--------------do we have power?-----------------------
                      if(%trigger.sourcebase.ispowered() == 0)
                         {
                         messageClient(%Player.client, 'MsgClient', "\c0Teleporter is not powered.");
                         return;
                         }


//----------------------disabled?-----------------------
if(%trigger.sourcebase.isDisabled())
      {
         messageClient(%colObj.client, 'msgStationDisabled', '\c2Teleporter is disabled.');
         return;
      }


//--------------are we on the right team?-----------------------
              if(%player.team != %trigger.sourcebase.team)
                   {
                     if(%trigger.sourcebase.team != 0)
                       {
                        %playervelocity = vectorscale(vectornormalize(%player.getvelocity()), 0.5);
                        %xv = getword(%playervelocity, 0);
		                %yv = getword(%playervelocity, 1);
                        %zv = getword(%playervelocity, 2);

                            if(getSubStr(%xv,0,1) !$= "-")
                            %xv = "-" @ %xv + $playerreject;
                            else
                               %xv = getsubstr(%xv,1,strlen(%xv - 1)) + $playerreject;

                            if(getSubStr(%yv,0,1) !$= "-")
                            %yv = "-" @ %yv + $playerreject;
                            else
                               %yv = getsubstr(%yv,1,strlen(%yv - 1)) + $playerreject;

                            if(getSubStr(%zv,0,1) !$= "-")
                            %zv = "-" @ %zv + $playerreject;
                            else
                               %zv = getsubstr(%zv,1,strlen(%zv - 1)) + $playerreject;

                       %player.setVelocity(%xv SPC %yv SPC %zv );
                        messageClient(%Player.client, 'MsgClient', "\c0Wrong team.");
                        %player.llamathread = schedule(1000,0,"playerdamage",%player, true);
                        return;
                        }
                    }


//------------are we teleporting?-----------------------
 if(%trigger.teleporting == "1")
                         {
                        %playervelocity = vectorscale(vectornormalize(%player.getvelocity()), 0.5);
                        %xv = getword(%playervelocity, 0);
		                %yv = getword(%playervelocity, 1);
                        %zv = getword(%playervelocity, 2);

                            if(getSubStr(%xv,0,1) !$= "-")
                            %xv = "-" @ %xv + $playerreject;
                            else
                               %xv = getsubstr(%xv,1,strlen(%xv - 1)) + $playerreject;

                            if(getSubStr(%yv,0,1) !$= "-")
                            %yv = "-" @ %yv + $playerreject;
                            else
                               %yv = getsubstr(%yv,1,strlen(%yv - 1)) + $playerreject;

                           if(getSubStr(%zv,0,1) !$= "-")
                            %zv = "-" @ %zv + $playerreject;
                            else
                               %zv = getsubstr(%zv,1,strlen(%zv - 1)) + $playerreject;


                       %player.setVelocity(%xv SPC %yv SPC %zv );

                       messageClient(%Player.client, 'MsgClient', "\c0Teleporter in use.");
    return;
    }
//-------------is this a oneway teleporter?------------------------
 if(%trigger.oneway == "1")
    {
                        %playervelocity = vectorscale(vectornormalize(%player.getvelocity()), 0.5);
                        %xv = getword(%playervelocity, 0);
		                %yv = getword(%playervelocity, 1);
                        %zv = getword(%playervelocity, 2);

                            if(getSubStr(%xv,0,1) !$= "-")
                            %xv = "-" @ %xv + $playerreject;
                            else
                               %xv = getsubstr(%xv,1,strlen(%xv - 1)) + $playerreject;

                            if(getSubStr(%yv,0,1) !$= "-")
                            %yv = "-" @ %yv + $playerreject;
                            else
                               %yv = getsubstr(%yv,1,strlen(%yv - 1)) + $playerreject;

                           if(getSubStr(%zv,0,1) !$= "-")
                            %zv = "-" @ %zv + $playerreject;
                            else
                               %zv = getsubstr(%zv,1,strlen(%zv - 1)) + $playerreject;


                       %player.setVelocity(%xv SPC %yv SPC %zv );

      messageClient(%player.client, 'MsgLeaveMissionArea', '\c1This teleporter is oneway only.~wfx/misc/warning_beep.wav');
    return;
    }

//-------------are we teleporting with flag?----------------------------------------

     %flag = %player.holdingflag;

        if(%player.holdingFlag > 0)
          {
          if(%trigger.noflag $= "1")
             {
   if(%flag.team == 1)
      %otherTeam = 2;
   else
      %otherTeam = 1;
            game.flagReset(%player.holdingflag);
      messageTeam(%otherTeam, 'MsgCTFFlagReturned', '\c2 %1 tried to teleport with the %2 flag.~wfx/misc/flag_return.wav', %client.name, $teamName[%flag.team], %flag.team);
      messageTeam(%flag.team, 'MsgCTFFlagReturned', '\c2Your flag was returned.~wfx/misc/flag_return.wav', 0, 0, %flag.team);
      messageTeam(0, 'MsgCTFFlagReturned', '\c2The %2 flag was returned to base.~wfx/misc/flag_return.wav', 0, $teamName[%flag.team], %flag.team);
            }
          }

        setPlayersPosition2(%data, %obj, %trigger, %colObj);






           %player.transported = "1";

           if(%trigger.message !$= " ")
      	           messageClient(%Player.client, 'MsgClient', "\c0 " @ %trigger.message);



           %rot = rotFromTransform( %player.getTransform() );
           %player.startfade(500,0,true);
           teleporteffect(posfromtransform(%player.gettransform()));
           %pos = posFromTransform(%trigger.targetbase.getTransform() );

		%x = getword(%pos, 0); 			// left of center
		%y = getword(%pos, 1);			// "forward" adjustment
		%z = getword(%pos, 2) + 0.5; 		// VERTICLE
		%exitpos = %x SPC %y SPC %z;		// new position
           teleporteffect(%exitpos);
           %trigger.teleporting = "1";
           %player.sourcetrigger = %trigger;
           %player.desttrigger =  %trigger.targetbase;
           %player.desttrigger.teleporting = "1";
           %player.schedule(500, "settransform", %exitpos @ " " @ %rot);
           %player.schedule(500, "startfade", 500, 0, false);
           %colObj.schedule(500, "setmovestate", false);
                     if(%trigger.sourcebase == %trigger.targetbase)
                                            {
                                             NewTeleportTrigger::onleaveTrigger(%data, %trigger, %player);
                                             NewTeleportTrigger::onEnterTrigger(%data, %trigger, %player);
                                             }


//-----hope this works?!?!?--------------------------------------------------


}

function NewTeleportTrigger::onleaveTrigger(%data, %trigger, %player)
{
if(%player.team !$= %trigger.team)
   cancel(%player.llamaThread);

if(%player.desttrigger == %trigger)
     {
   cancel(%player.llamaThread);
           %player.sourcetrigger.teleporting = "0";
           %player.desttrigger.teleporting = "0";
           %player.sourcetrigger = "0";
           %player.desttrigger = "0";
      }

      
      
      
}

function NewTeleportTrigger::onTickTrigger(%data, %obj)
{
   Game.onTickTrigger(%obj.name, %data, %obj);
}

function teleporteffect(%position)
{
           %pos = %position;

	%effect1 = new ParticleEmissionDummy()
            {
		       position = %pos;
		       rotation = "1 0 0 0";
         		scale = "1 1 1";
         		dataBlock = "doubleTimeEmissionDummy";
         		lockCount = "0";
         		homingCount = "0";
         		emitter = "AABulletExplosionEmitter2";
         		velocity = "1";
         	};
	%effect2 = new ParticleEmissionDummy()
            {
		       position = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 0.5;
		       rotation = "1 0 0 0";
         		scale = "1 1 1";
         		dataBlock = "doubleTimeEmissionDummy";
         		lockCount = "0";
         		homingCount = "0";
         		emitter = "AABulletExplosionEmitter2";
         		velocity = "1";
         	};

	%effect3 = new ParticleEmissionDummy()
            {
		       position = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 1;
		       rotation = "1 0 0 0";
         		scale = "1 1 1";
         		dataBlock = "doubleTimeEmissionDummy";
         		lockCount = "0";
         		homingCount = "0";
         		emitter = "AABulletExplosionEmitter2";
         		velocity = "1";
         	};
	%effect4 = new ParticleEmissionDummy()
            {
		       position = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 1.5;
		       rotation = "1 0 0 0";
         		scale = "1 1 1";
         		dataBlock = "doubleTimeEmissionDummy";
         		lockCount = "0";
         		homingCount = "0";
         		emitter = "AABulletExplosionEmitter2";
         		velocity = "1";
         	};
            MissionCleanup.add(%effect1);
            MissionCleanup.add(%effect2);
            MissionCleanup.add(%effect3);
            MissionCleanup.add(%effect4);
            %effect1.schedule(2000, "delete");
            %effect2.schedule(2000, "delete");
            %effect3.schedule(2000, "delete");
            %effect4.schedule(2000, "delete");

}
function playerdamage(%this, %firstWarning)
{
%player = %this;

   if (!isObject(%player) || %player.getState() $= "Dead")
         {
         messageClient(%player.client, 'MsgClient', "\c0Camping on a teleporter is not cool.");
         return;
         }

      if(%firstwarning)
            {
            messageClient(%player.client, 'MsgLeaveMissionArea', '\c1Move off the teleporter or take damage.~wfx/misc/warning_beep.wav');
            %player.llamathread = schedule(3000,0,"playerdamage",%this, false);
             return;

            }
            

      %this.setdamageflash(0.3);

      %this.damage(0, %player.position, 0.04, $DamageType::radiation);


%player.llamathread = schedule(1000,0,"playerdamage",%this, false);


}

function checklogostatus(%logostat)
{

   if(!isObject(%logostat))
      return;
 if(%logostat.logoscale $= " ")
                        return;
                        

     %status = schedule(1000,0,checklogostatus,%logostat);
             %tp = %logostat;

                if(%tp.team != %tp.lastteam)
                {
                      %tp.lastteam = %tp.team;
                      if(%tp.holo > 0)
                          %tp.holo.delete();

                      if(%tp.targetbase1 !$= "")
                                   {
                                           if(%tp.team $= "1")
                                               {
                                               %tp.trigger.targetbase = %tp.targetbase1;
                                                }
                                               if(%tp.team $= "2")
                                                   {
                                                           %tp.trigger.targetbase = %tp.targetbase2;
                                                    }
                                    }

                      %newHolo = getTaggedString(game.getTeamSkin(%tp.team)) @ "Logo";
                                              %pos = %tp.trigger.position;

                                  %holo = new StaticShape()
                                           {
                                            rotation = rotfromtransform(%tp.gettransform());
                                            position = getWord(%pos,0) @ " " @ getWord(%pos,1) @ " " @ getWord(%pos,2) + 1;
                                            dataBlock = %newHolo;
                                            scale = %tp.logoscale;
                                            };
// dump the hologram into MissionCleanup
                                            MissionCleanup.add(%holo);
// associate the holo with the teleporter
                                            %tp.holo = %holo;


                   }


                  

           
}

//Teleport code ends here----------------------------------------


