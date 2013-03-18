//==============================================================================
// Admin Commands
//==============================================================================

// Command by Eolk. Modified by Blnukem.
function ccset(%sender, %args)
{
   %base = strlwr(getword(%args, 0));
   %param = getword(%args, 1);
   switch$(%base)
   {
      case "canzombie":
         if(%sender.isAdmin)
         {
            if(%param != 1 && %param != 0)
            {
               messageClient(%sender, "MsgNo", "\c2Invalid parameters. Use 1 for canZombie to be on, use 0 for canZombie to be off.");
               return;
            }

            $Host::canZombie = %param;
            messageAll('MsgAdminForce', "\c1"@%sender.nameBase@" \c2changed \c5HUMAN ZOMBIES \c2to \c5"@%param@"\c2.");
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::canZombie (human zombies) changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::canZombie@" via ccSet");
         }
      case "joinpw":
         if(%sender.isSuperAdmin)
         {
            if(%param $= "")
            {
               messageClient(%sender, "MsgNo", "\c2No Changes. You did not supply a value. Use \"remove\" to remove join pw.");
               return;
            }

            if(strlwr(%param) $= "remove")
               $Host::Password = "";
            else
               $Host::Password = %param;

            messageAll('MsgAdminForce', "\c1"@%sender.nameBase@" \c2changed \c5JOIN PASSWORD\c2.");
            messageClient(%sender, "MsgYes", "\c2Join password changed to "@$Host::Password);
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::Password (server password) changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::Password@" via ccSet");
         }
      case "maxplyrs":
         if(!%sender.isSuperAdmin)
            return;

         %failed = false;
         for(%i = 0; %i < strlen(%param); %i++)
         {
            %temp = getsubstr(%param, %i, 1);
            if(%temp !$= "1" && %temp !$= "2" && %temp !$= "3" && %temp !$= "4" && %temp !$= "5" && %temp !$= "6" && %temp !$= "7" && %temp !$= "8" && %temp !$= "9" && %temp !$= "0")
            {
               %failed = true;
               break;
            }
         }

         if(%param < 0)
            %failed = true;

         if(%failed == true)
         {
            messageClient(%sender, "MsgNo", "\c2No changes. You supplied an invalid number. Must be over 0.");
            return;
         }

         $Host::MaxPlayers = %param;
         messageAll('MsgAdminForce', "\c1"@%sender.nameBase@" \c2changed \c5MAX PLAYERS\c2 to \c5"@$Host::MaxPlayers@"\c2.");
         export( "$Host::*", "prefs/ServerPrefs.cs", false );
         echo("$Host::MaxPlayers (maximum players allowed by the server) changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::MaxPlayers@" via ccSet");
      case "restrict":
         if(%sender.isAdmin)
         {
            %target = plnametocid(%param);
            if(!isObject(%target))
            {
               messageClient(%sender, "MsgNo", "\c2Unable to find target.");
               return;
            }

            if(%target.isAdmin)
            {
               messageClient(%sender, "MsgNo", "\c2Cannot do this to admins.");
               return;
            }

            if(!%target.CannotDeploy)
            {
               %target.CannotDeploy = 1;
               messageClient(%sender, "MsgYes", "\c2"@%target.nameBase@"'s ability to deploy things has been revoked.~wfx/misc/diagnostic_on.wav");
               echo(%sender.namebase@" ("@%sender@") disabled "@%target.nameBase@"'s ("@%target@") ability to deploy objects");
            }
            else
            {
               %target.CannotDeploy = 0;
               messageClient(%sender, "MsgYes", "\c2"@%target.nameBase@" is free to deploy things again.~wfx/misc/diagnostic_on.wav");
               echo(%sender.namebase@" ("@%sender@") enabled "@%target.nameBase@"'s ("@%target@") ability to deploy objects");
            }
         }
      case "noinfection":
         if(%sender.isAdmin)
         {
            if(%param != 0 && %param != 1)
            {
               messageClient(%sender, "MsgNo", "\c2No changes. You supplied an invalid type. Use 1 for on, use 0 for off.");
               return;
            }

            $Host::NoInfection = %param;
            messageAll('MsgAdminForce', "\c1"@%sender.nameBase@" \c2changed \c5NO INFECTION \c2to \c5"@%param@"\c2.");
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::NoInfection (no infection) changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::NoInfection@" via ccSet");
         }
      case "autosave":
         if(%sender.isSuperAdmin) // SA
         {
            if(%param != 1 && %param != 0)
            {
               messageClient(%sender, "MsgNo", "\c2Invalid parameters. Input 1 for start, input 0 for end.");
               return;
            }

            if(%param == 1)
               if($SaveBuilding::TimerEnabled)
               {
                  saveBuildingTimerOn(); // This resets.
                  messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has reset the autosave timer.");
                  echo(%sender.nameBase@" ("@%sender@") has reset the autosave timer via ccSet");
               }
               else
               {
                  saveBuildingTimer(0, 1, 0, 0);
                  messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has enabled the autosave timer.");
                  echo(%sender.nameBase@" ("@%sender@") has enabled the autosave timer via ccSet");
               }
            else
               if($SaveBuilding::TimerEnabled)
               {
                  saveBuildingTimerOff();
                  messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has disabled the autosave timer.");
                  echo(%sender.nameBase@" ("@%sender@") has disabled the autosave timer via ccSet");
               }
               else
                  messageClient(%sender, "", "\c2Cannot disable the autosave timer if it is already disabled!");
         }
      case "lockedteams":
         if(%sender.isAdmin)
         {
            if(%param != 1 && %param != 0)
            {
               messageClient(%sender, "MsgNo", "\c2Invalid parameters. Input 1 for lock, input 0 for unlock.");
               return;
            }

            $Host::LockedTeams = %param;
            messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" has changed locked teams to "@%param@".");
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::LockedTeams (locked, unchangeable teams) has been changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::LockedTeams@" via ccSet");
         }
      case "sapass":
         if(%sender.isSuperAdmin)
         {
            $Host::SuperAdminPassword = %param;
            messageClient(%sender, "", "\c2Super admin password changed to "@%param);
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::SuperAdminPassword (super admin password or SAD) has been changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::SuperAdminPassword@" via ccSet");
         }
      case "apass":
         if(%sender.isSuperAdmin)
         {
            $Host::AdminPassword = %param;
            messageClient(%sender, "", "\c2Admin password changed to "@%param);
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::AdminPassword (admin password or AD) has been changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::AdminPassword@" via ccSet");
         }
      case "fairteams":
         if(%sender.isAdmin)
         {
            if(%param != 1 && %param != 0)
            {
               messageClient(%sender, "MsgNo", "\c2Invalid parameters. Input 1 for enabled, input 0 for disable.");
               return;
            }

            $Host::FairTeams = %param;
            messageAll("", "\c2"@%sender.nameBase@" has changed Fair Teams to "@%param@".");
            export( "$Host::*", "prefs/ServerPrefs.cs", false );
            echo("$Host::FairTeams (unbalanced team preventer) has been changed by "@%sender.nameBase@" ("@%sender@") to "@$Host::FairTeams@" via ccSet");
         }
      default:
         messageClient(%sender, "MsgNo", "\c2Invalid command. Valid commands are canzombie, zombieteam, joinpw, maxplyrs, restrict, zturrets");
         messageClient(%sender, "MsgNo", "\c2noinfection, dir, lockedteams, sapass, apass, fairteams, and autosave");
   }
}

// Command by Eolk.
function ccA(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   for(%i = 0; %i < ClientGroup.getCount(); %i++)
   {
      %cl = ClientGroup.getObject(%i);
      if(%cl.isAdmin)
         messageClient(%cl, 'MsgYes', "\c3[A]\c2"@%sender.nameBase@": "@%args);
   }
   logEcho("[ADMIN CHAT]: "@%sender.nameBase@": "@%args);
}

// Command by Eolk (honestly, even though it looks like someone else's code).
function ccCancelVote(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(Game.ScheduleVote $= "")
   {
      messageClient(%sender, "MsgNo", "\c2There is no vote to cancel!");
      return;
   }

   cancel(Game.scheduleVote);

   Game.votingArgs = "";
   Game.scheduleVote = "";
   Game.kickClient = "";
   clearVotes();

   messageAll('closeVoteHud', "");
   if(%client.team != 0)
      clearBottomPrint(%client);

   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has cancelled the vote.");
   messageAll('MsgVoteFailed', "");
   logEcho(%sender.nameBase@" ("@%sender@") has cancelled the vote");
}

// Command by Eolk.
function ccBottomPrint(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(%args $= "")
   {
      messageClient(%sender, 'MsgNo', "\c2Must supply text to display!");
      return;
   }

   %print = %args;
   %wave = strstr(%args, "~w");

   if(%wave != -1)
      %print = getsubstr(%args, 0, %wave);

   BottomprintAll(%sender.nameBase@": "@%print, 10, 3);
   messageAll("MsgAll", "\c2"@ %sender.namebase@": \c4"@%print@"~wgui/objective_Notification.wav");
   logEcho("[BOTTOMPRINT]"@%sender.nameBase@" ("@%sender@"): "@%args);
}

// Command by Eolk. Modified by Blnukem
function ccCenterPrint(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(%args $= "")
   {
      messageClient(%sender, 'MsgNo', "\c2Must supply text to display!");
      return;
   }

   %print = %args;
   %wave = strstr(%args, "~w");

   if(%wave != -1)
   %print = getsubstr(%args, 0, %wave);

   CenterprintAll(%sender.nameBase@": "@%print, 10, 3);
   messageAll("MsgAll", "\c2"@ %sender.namebase@": \c4"@%print@"~wgui/objective_Notification.wav");
   logEcho("[BOTTOMPRINT]"@%sender.nameBase@" ("@%sender@"): "@%args);
}

// Eolk
function ccJailPlayer(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(!$Host::Prison::Enabled)
   {
      messageClient(%sender, "MsgNo", "\c2Prison is not enabled.");
      return;
   }

   %target = plnametocid(getword(%args, 0));
   %time = getword(%args, 1);
   if(!isObject(%target))
   {
      messageClient(%sender, "MsgNo", "\c2Target does not exist.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageClient(%sender, "MsgNo", "\c2Target's player does not exist.");
      return;
   }

   if((%target.isAdmin && !%sender.isAdmin) || %target.isSuperAdmin)
   {
      messageClient(%sender, "MsgNo", "\c2You must outrank the target to jail them.");
      return;
   }

   if(%target == %sender && %target.isJailed && !%sender.isSuperAdmin)
   {
      messageClient(%sender, "MsgNo", "\c2Can only unjail yourself if you are of super admin status.");
      return;
   }

   if(%time > 600)
      %time = 600;

   %test = %target.isJailed;
   JailPlayer(%target, %target.isJailed, %time);
   if(!%test)
   {
      messageClient(%target, "MsgAdminForce", "\c2You have been sentenced to jail.");
      messageAllExcept(%target, -1, "MsgAdminForce", "\c3"@%target.nameBase@" \c2has been sentenced to jail.");
      logEcho(%target.nameBase@" ("@%target@") was sentenced to jail by "@%sender.nameBase@" ("@%sender@") for "@%time@" seconds");
   }
   else
   {
      messageClient(%target, "MsgAdminForce", "\c2You have had your jail sentence cut short.", %sender.nameBase);
      messageAllExcept(%target, -1, "MsgAdminForce", "\c3"@%target.nameBase@" \c2has had their jail sentence cut short.");
      logEcho(%target.nameBase@" ("@%target@") was released from jail by "@%sender.nameBase@" ("@%sender@")");
   }
}

// Command by Eolk.
function ccMute(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2No such person.");
      return;
   }

   if((%target.isAdmin && !%sender.isSuperAdmin) || %target.isSuperAdmin)
   {
      messageClient(%sender, "", "\c2Can't mute someone you don't outrank!");
      return;
   }

   if(!%target.isSilenced)
   {
      messageClient(%target, "", "\c2You have been muted.");
      %target.isSilenced = 1;
      messageClient(%sender, "", "\c3"@%target.nameBase@"\c2 has been muted.");
      logEcho(%sender.nameBase@" ("@%sender@") globally muted "@%target.nameBase@" ("@%target@")");
   }
   else
   {
      %target.isSilenced = 0;
      messageClient(%sender, "", "\c3"@%target.nameBase@"\c2 has been unmuted.");
      logEcho(%sender.nameBase@" ("@%sender@") globally unmuted "@%target.nameBase@" ("@%target@")");
   }
}

// Chat command by Eolk (special thanks to Krash for bug fixes!)
// <3
function ccaddteam(%sender)
{
   if(!%sender.isAdmin)
      return;

   if(Game.numTeams >= 2 && $AddedMoreTeams != 1)
   {
      messageClient(%sender, 'MsgNo', "\c2There are already enough teams.");
      return;
   }

   if(!$AddedMoreTeams)
   {
      Game.numTeams++;
      setSensorGroupCount(Game.numTeams);
//      clearVehicleCount(Game.numTeams + 1); // Not sure about this...
      $AddedMoreTeams = 1;
      $NewTeam = Game.numTeams;
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has added another team.");
      warn(%sender.nameBase@" ("@%sender@") has added another team");
   }
   else
   {
      for(%i = 0; %i < ClientGroup.getCount(); %i++)
      {
         %obj = ClientGroup.getObject(%i);
         if(%obj.team == $NewTeam)
         {
            Game.forceObserver(%obj, "AdminForce");
            messageClient(%obj, 'MsgYes', "\c2You have been forced into observer due to being on the deleted team.");
         }
      }

      Game.numTeams--;
      setSensorGroupCount(Game.numTeams);
      $AddedMoreTeams = 0;
      $NewTeam = "";
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has deleted the new team. All people have been forced into observer.");
      warn(%sender.nameBase@" ("@%sender@") has deleted the new team");
   }
}

// Eolk
function ccSummon(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(%sender.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2You cannot do this command while in jail!");
      return;
   }

   if(!isObject(%sender.player))
   {
      messageclient(%sender, "MsgNo", "\c2You must have a player object in order to do this.");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageclient(%sender, "MsgNo", "\c2Target does not exist.");
      return;
   }

   if(%target.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2Target is jailed.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageclient(%sender, "MsgNo", "\c2Your target has to have a player object in order to do this.");
      return;
   }

   %x = getword(%sender.player.position, 0);
   %y = getword(%sender.player.position, 1);
   %z = getword(%sender.player.position, 2) + 2.5;
   %newpos = %x SPC %y SPC %z;

   %target.player.setPosition(%newpos);
   %target.player.setVelocity("0 0 0");

   messageClient(%target, "MsgYes", "\c2You have been summoned by\c3 "@%sender.namebase@"\c2.");
   messageClient(%sender, "MsgYes", "\c2You have summoned \c3"@%target.namebase@"\c2.");
}

// Blnukem/Eolk
function ccDesmurf(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Cannot find target.");
      return;
   }

   if(!%target.isSmurf)
      messageClient(%sender, "", "\c2No smurf name detected.");
   else
      getRealName(%target, %sender);
   logEcho(%sender.nameBase@" ("@%sender@") requested non-smurf name of "@%target.nameBase@" ("@%target@")");
}

// Eolk
function ccGoto(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(%sender.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2You cannot do this command while in jail!");
      return;
   }

   if(!isObject(%sender.player))
   {
      messageclient(%sender, "MsgNo", "\c2You must have a player object in order to do this.");
      return;
   }

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageclient(%sender, "MsgNo", "\c2Target does not exist.");
      return;
   }

   if(%target.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2Target is jailed.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageclient(%sender, "MsgNo", "\c2Your target has to have a player object in order to do this.");
      return;
   }

   %x = getword(%target.player.position, 0);
   %y = getword(%target.player.position, 1);
   %z = getword(%target.player.position, 2) + 2.5;
   %newpos = %x SPC %y SPC %z;

   %sender.player.setPosition(%newpos);
   %sender.player.setVelocity("0 0 0");

   messageClient(%sender, "MsgYes", "\c2You have gone to\c3 "@%target.namebase@"'s \c2location.");
   if(%sender.isAdmin)
      messageClient(%target, "MsgYes", "\c3"@%sender.nameBase@" \c2has come to you.");
}

// Eolk
function ccMoveme(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(getwordcount(%args) != 3)
   {
      messageClient(%sender, "MsgNo", "\c2Your movement was not specified in X Y Z format.");
      return;
   }

   if(%sender.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2You cannot do this command while in jail!");
      return;
   }

   %newpos = VectorAdd(%sender.player.position, %args);
   %sender.player.setPosition(%newpos);
}

// Eolk
function ccmoveto(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   if(getwordcount(%args) != 3)
   {
      messageClient(%sender, "MsgNo", "\c2Your movement was not specified in X Y Z format.");
      return;
   }

   if(%sender.isJailed)
   {
      messageclient(%sender, "MsgNo", "\c2You cannot do this command while in jail!");
      return;
   }

   %sender.player.setPosition(%args);
}

// Blnukem/Eolk
function ccKill(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(%args);
   if(%target == %sender)
   {
      messageClient(%sender, "", "\c2You cannot kill yourself.");
      return;
   }

   if(%target.isSuperAdmin)
   {
      messageClient(%sender, "", "\c2You cannot kill Super Admins.");
      return;
   }

   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Cannot find target.");
      return;
   }

   if(!isObject(%target.player))
   {
      messageClient(%sender, "", "\c2Cannot find target.");
      return;
   }

   %target.player.scriptkill($DamageType::Idiocy);
   messageAll("", "~wfx/misc/bounty_completed.wav");
   warn(%sender.nameBase@" ("@%sender@") killed "@%target.nameBase@" ("@%target@") using admin force");
}

// Eolk
function ccForceTeamSpawn(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %team = getword(%args, 0);
   %sp = getword(%args, 1);
   if(%sp !$= "")
      %sp = %sp - 1; // Subtract one to have things make a little more sense.

   if(%team $= "")
   {
      messageClient(%sender, "MsgNo", "\c2A team must be specified.");
      return;
   }

   if(%sp $= "")
   {
      $UseForcedTeamSpawn[%team] = 0;
      $ForcedSpawn[%team] = "";
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has released the forced spawn for team \c3"@%team@"\c2. If you wish to not spawn at the point anymore, use /choosespawn to reset.");
      return;
   }

   if(!isObject($teamSP[%team, %sp]))
   {
      messageClient(%sender, "MsgNo", "\c2The spawnpoint specified doesn't exist.");
      return;
   }

   if(!$teamSP[%team, %sp].active)
   {
      messageClient(%sender, "MsgNo", "\c2The spawnpoint specified is not powered.");
      return;
   }

   $UseForcedTeamSpawn[%team] = 1;
   $ForcedSpawn[%team] = $teamSP[%team, %sp];

   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has forced team\c3 "@%team@"\c2 to spawn at spawnpoint \c3"@%sp+1@"\c2.");
   warn(%sender.nameBase@" ("@%sender@") forced team"@%team@" to spawn at spawn"@%sp);
}

// By Eolk
function ccSaveBuilding(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %rad = getword(%args, 0);
   %file = getword(%args, 1);
   SaveBuilding(%sender, %rad, %file, 1, 0);
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 is saving the buildings with a radius of \c3"@%rad@"\c2.");
   messageClient(%sender, "", "\c2Building saved to\c3 "@$SaveBuilding::LastFile@"\c2.");
   warn(%sender.nameBase@" ("@%sender@", GUID: "@%sender.guid@") attempted save buildings within a radius of "@%radius@" to file "@%file);
}

// Eolk
function ccLoadBuilding(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   LoadBuilding(%args);
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@" \c2has loaded a building.");
   warn(%sender.nameBase@" ("@%sender@", GUID: "@%sender.guid@") loaded file "@%args);
}

// Blnukem
function ccTurrets(%sender) {
if (!%sender.isAdmin)
   return;
  if ($TurretEnableOverride) {
    $TurretEnableOverride = 0;
    messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has disabled turrets.");
  }
  else {
    $TurretEnableOverride = 1;
    messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has enabled turrets.");
  }
  logEcho("$TurretEnableOverride (turrets work in purebuild) changed to "@$TurretEnableOverride@" by "@%sender.nameBase@" ("@%sender@") using ccTurrets");
}

// Blnukem
function ccBuySCG(%sender) {
   if (!%sender.isAdmin)
      return;

   if(!isObject(%sender.player))
   {
      messageClient(%sender, "", "\c2You must be playing in order to get a Super Chaingun.");
      return;
   }

   messageClient(%sender, "", "\c2A Super Chaingun has been added to your inventory.");
   %sender.player.setInventory(SuperChaingun, 1, true);
}

// Eolk
function ccChangeName(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(getword(%args, 0));
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Invalid Target.");
      return;
   }

   %name = getwords(%args, 1, getWordCount(%args) - 1);
   if(%name $= "")
   {
      messageClient(%sender, 'MsgNo', "\c2Need to supply a name!");
      return;
   }

   if(%name $= "reset")
   {
      ChangeName(%target, "reset");
      messageClient(%target, "", "\c2Your name has been reset.");
      warn(%sender.nameBase@" ("@%sender@") has reset "@%target.nameBase@"'s ("@%target@") name");
      return;
   }

   ChangeName(%target, %name);
   messageClient(%target, "", "\c2Your new name is \c3"@%name@"\c2.");
   warn(%sender.nameBase@" ("@%sender@") changed "@%target.nameBase@"'s ("@%target@") name to "@%name);
}

// Eolk
function ccSavePlayer(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(getword(%args, 0));
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Invalid target.");
      return;
   }

   %name = getword(%args, 1);
   if(%name $= "")
   {
      messageClient(%sender, "", "\c2Invalid name.");
      return;
   }

   %folder = $SaveBuilding::SaveFolder @ %name; // I really don't know if we should check for invalid characters
   new FileObject("Building");                  // or not. I think Tribes 2 does that automatically.

   Building.openforwrite(%folder);
   Building.writeLine("// Saved by \"" @ getField(%sender.nameBase,0) @ "\"");
   Building.writeLine("// Created in mission \"" @ $MissionName @ "\"");
   Building.writeLine("// Construction " @ $ModVersion);
   Building.writeLine("");

   %group = nameToID("MissionCleanup/Deployables"); // We should really check isObject here... and we will!
   if(!isObject(%group))
   {
      messageClient(%sender, "", "\c2There are no deployables!");
      return;
   }

   for(%i = 0; %i < %group.getCount(); %i++)
   {
      %depl = %group.getObject(%i);
      if(isObject(%depl) && %depl.getOwner() == %target)
      {
         %towrite = writeBuildingComponent(%depl); // This will return null if invalid.
         if(%towrite !$= "")
            Building.writeline(%towrite);
      }
   }

   Building.close();
   Building.delete();

   messageAll('MsgAdminForce', "\c2"@%sender.nameBase@" is saving "@%target.nameBase@"'s buildings.");
   messageClient(%sender, "", "\c2Building saved to "@%folder@".");
   logEcho(%sender.nameBase@" ("@%sender@") saved "@%target.nameBase@"'s pieces to file "@%name);
}

// Command made by Eolk.
function ccForceGivePieces(%sender, %args)
{
   if(!%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2This is the admin give pieces. Regular clients have to use /givepieces target.");
      return;
   }

   %from = (getWord(%args, 0) !$= "orphan" ? plnametocid(getWord(%args, 0)) : "orphan");
   %to = plnametocid(getWord(%args, 1));

   if(%from !$= "orphan" && !isObject(%from))
   {
      messageClient(%sender, "", "\c2First argument - player doesn't exist.");
      return;
   }

   if(!isObject(%to))
   {
      messageClient(%sender, "", "\c2Second argument - player doesn't exist.");
      return;
   }

   GivePieces(%from, %to);
   if(%from !$= "orphan")
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has forced \c3"@%from.nameBase@"\c2 to transfer "@(%from.sex $= "Male" ? "his" : "her")@" pieces to \c3"@%to.nameBase@"\c2.");
   else
      messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has given all orphans to \c3"@%to.nameBase@"\c2.");
   logEcho(%sender.nameBase@" ("@%sender@") gave "@(%from == "orphan" ? "all orphaned" : %from.nameBase@"'s ("@%from@")")@" pieces to "@%to.nameBase@" ("@%to@")");
}

// Eolk
function ccGiveClientPieces(%sender, %args)
{
   if(!%sender.isAdmin)
   {
      messageClient(%sender, "", "\c2This command is for admins only.");
      return;
   }

   %from = getword(%args, 0);
   %to = plnametocid(getWord(%args, 1));

   if(!isObject(%to))
   {
      messageClient(%sender, "", "\c2The receiving client doesn't exist.");
      return;
   }

   GivePieces(%from, %to);
   messageAll('MsgAdminForce', "\c3"@%sender.nameBase@"\c2 has given all the pieces of client \c3"@%from@"\c2 to \c3"@%to.nameBase@".");
   logEcho(%sender.nameBase@" ("@%sender@") gave all pieces owned by client "@%from@" to "@%to.nameBase@" ("@%to@")");
}

// Blnukem
function ccTest (%sender,%args)
{
   if(!%sender.isAdmin){
      return;
   }

   %x = getword(%sender.player.position, 0);
   %y = getword(%sender.player.position, 1);
   %z = getTerrainHeight(%x SPC %y) + 5;
   %rot = "0 0 1 "@getRandom(1,360);
   %newpos = %x SPC %y SPC %z;
   if(%args $= "Raptor")
   {
      %type = ScoutFlyer;
   } else if(%args $= "Airwing")
   {
      %type = StrikeFlyer;
   } else if(%args $= "Superior")
   {
      %type = SuperiorityFighter;
   }

   if(%args $= "")
   {
      MessageClient(%sender, "Msg", "\c2Please specifiy the vehicle type.");
   } else if(%args !$= "Raptor" && %args !$= "Airwing" && %args !$= "Superior")
   {
      MessageClient(%sender, "Msg", "\c3"@%args@"\c2 is not a valid vehicle.");
   }

   %veh = new FlyingVehicle()
   {
      dataBlock    = ""@%type@"";
      position     = ""@%newpos@"";
      rotation     = ""@%rot@"";
      team         = %sender.team;
   };

   MissionCleanUp.add(%veh);
   setTargetSensorGroup(%veh.getTarget(), %sender.team);
   commandToClient(%sender,'SetDefaultVehicleKeys', true);
   commandToClient(%sender,'SetPilotVehicleKeys', true);
   %veh.mountObject(%sender.player,0);
   %veh.playAudio(0, MountVehicleSound);
   %sender.player.mVehicle = %col;
   %datablock = %type;
   %datablock.playerMounted(%veh,%sender.player, 0);
}

// Eolk
function ccNoVote(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Target does not exist.");
      return;
   }

   if(%target.isAdmin)
   {
      messageClient(%sender, "", "\c2This command does not affect admins.");
      return;
   }

   if(Game.scheduleVote !$= "")
   {
      messageClient(%sender, "", "\c2Cannot do this while a vote is in progress.");
      return;
   }

   if(%target.canVote)
   {
      messageClient(%sender, "", "\c3"@%target.nameBase@"'s \c2ability to vote has been taken away.");
      %target.canVote = false;
   }
   else
   {
      messageClient(%sender, "", "\c3"@%target.nameBase@"'s \c2ability to vote has been given back.");
      %target.canVote = true;
   }
}
