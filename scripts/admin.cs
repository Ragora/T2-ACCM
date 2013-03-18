// These have been secured against all those wanna-be-hackers.
$VoteMessage["VoteAdminPlayer"] = "Admin Player";
$VoteMessage["VoteKickPlayer"] = "Kick Player";
$VoteMessage["BanPlayer"] = "Ban Player";
$VoteMessage["VoteChangeMission"] = "change the mission to";
$VoteMessage["VoteTeamDamage", 0] = "enable team damage";
$VoteMessage["VoteTeamDamage", 1] = "disable team damage";
$VoteMessage["VoteTournamentMode"] = "change the server to";
$VoteMessage["VoteFFAMode"] = "change the server to";
$VoteMessage["VoteChangeTimeLimit"] = "change the time limit to";
$VoteMessage["VoteMatchStart"] = "start the match";
$VoteMessage["VoteGreedMode", 0] = "enable Hoard Mode";
$VoteMessage["VoteGreedMode", 1] = "disable Hoard Mode";
$VoteMessage["VoteHoardMode", 0] = "enable Greed Mode";
$VoteMessage["VoteHoardMode", 1] = "disable Greed Mode";
$VoteMessage["VotePurebuild", 0] = "enable pure building";
$VoteMessage["VotePurebuild", 1] = "disable pure building";
$VoteMessage["VoteCascadeMode", 0] = "enable cascade mode";
$VoteMessage["VoteCascadeMode", 1] = "disable cascade mode";
$VoteMessage["VoteExpertMode", 0] = "enable expert mode";
$VoteMessage["VoteExpertMode", 1] = "disable expert mode";
$VoteMessage["VoteVehicles", 0] = "enable vehicles";
$VoteMessage["VoteVehicles", 1] = "disable vehicles";
$VoteMessage["VoteSatchelCharge", 0] = "enable satchel charges";
$VoteMessage["VoteSatchelCharge", 1] = "disable satchel charges";
$VoteMessage["VoteOnlyOwnerDeconstruct", 0] = "enable only owner deconstruct";
$VoteMessage["VoteOnlyOwnerDeconstruct", 1] = "disable only owner deconstruct";
$VoteMessage["VoteOnlyOwnerCascade", 0] = "enable only owner cascade";
$VoteMessage["VoteOnlyOwnerCascade", 1] = "disable only owner cascade";
$VoteMessage["VoteOnlyOwnerRotate", 0] = "enable only owner rotate";
$VoteMessage["VoteOnlyOwnerRotate", 1] = "disable only owner rotate";
$VoteMessage["VoteOnlyOwnerCubicReplace", 0] = "enable only owner cubic-replace";
$VoteMessage["VoteOnlyOwnerCubicReplace", 1] = "disable only owner cubic-replace";
$VoteMessage["VoteInvincibleArmors", 0] = "enable invincible armors";
$VoteMessage["VoteInvincibleArmors", 1] = "disable invincible armors";
$VoteMessage["VoteInvincibleDeployables", 0] = "enable invincible deployables";
$VoteMessage["VoteInvincibleDeployables", 1] = "disable invincible deployables";
$VoteMessage["VoteUndergroundMode", 0] = "enable underground mode";
$VoteMessage["VoteUndergroundMode", 1] = "disable underground mode";
$VoteMessage["VoteHazardMode", 0] = "enable hazard mode";
$VoteMessage["VoteHazardMode", 1] = "disable hazard mode";
$VoteMessage["VoteRemoveDeployables"] = "remove all deployables in mission";
$VoteMessage["VoteGlobalPowerCheck"] = "remove all duplicate deployables";
$VoteMessage["VoteRemoveDupDeployables"] = "remove all duplicate deployables";
$VoteMessage["VoteRemoveNonPoweredDeployables"] = "remove all deployables without power";
$VoteMessage["VoteRemoveOrphanedDeployables"] = "remove all orphaned deployables";
$VoteMessage["VotePrison", 0] = "enable prison";
$VoteMessage["VotePrison", 1] = "disable prison";
$VoteMessage["VotePrisonKilling", 0] = "enable jailing killers";
$VoteMessage["VotePrisonKilling", 1] = "disable jailing killers";
$VoteMessage["VotePrisonTeamKilling", 0] = "enable jailing team killers";
$VoteMessage["VotePrisonTeamKilling", 1] = "disable jailing team killers";
$VoteMessage["VotePrisonDeploySpam", 0] = "enable jailing deploy spammers";
$VoteMessage["VotePrisonDeploySpam", 1] = "disable jailing deploy spammers";
$VoteMessage["VoteMakeKeeper"] = "give Zombie Keeper abilities to";
$VoteMessage["VoteMakeNotKeeper"] = "remove Zombie Keeper abilities from";
$VoteMessage["VoteLoadBuilding"] = "load his";
$VoteMessage["CancelVote"] = "cancel vote";
$VoteMessage["PassVote"] = "pass vote";
// End JTL

function serverCmdStartNewVote(%client, %typeName, %arg1, %arg2, %arg3, %arg4, %playerVote)
{
   //DEMO VERSION - only voteKickPlayer is allowed
   if ((isDemo()) && %typeName !$= "VoteKickPlayer")
   {
      messageClient(%client, '', "All voting options except to kick a player are disabled in the DEMO VERSION.");
      return;
   }

   if($Host::ClientSaving)
   {
      if(%typeName $= "StartBuildingManager")
      {
         %client.BuildingManagerMode = 1;
         return;
      }
      if(%typeName $= "SavePieces")
      {
         %client.BuildingManagerMode = 2;
         %client.BuildingManagerSubMode = 1;
         return;
      }
      else if(%typeName $= "LoadPieces")
      {
         %client.BuildingManagerMode = 2;
         %client.BuildingManagerSubMode = 2;
         return;
      }
      else if(%typeName $= "RenamePieces")
      {
         %client.BuildingManagerMode = 2;
         %client.BuildingManagerSubMode = 3;
         return;
      }
      else if(%typeName $= "DeletePieces")
      {
         %client.BuildingManagerMode = 2;
         %client.BuildingManagerSubMode = 4;
         return;
      }
      else if(%typeName $= "GoBackPiece")
      {
         %client.BuildingManagerMode--;
         %client.BuildingManagerSubMode = 0;
         return;
      }
      else if(strstr(%typeName, "BSel-") == 0)
      {
         if(%client.isRenaming)
         {
            messageClient(%sender, "", "\c2You must finish renaming before continuing. ~wfx/misc/misc.error.wav");
            %client.BuildingManagerMode = 0;
            %client.BuildingManagerSubMode = 0;
            return;
         }

         if(%client.BuildingManagerSubMode == 1) // Saving.
         {
            if(%client.saveTimeout > 1)
            {
               messageClient(%client, "", "\c2Cannot save. You must wait\c3 "@%client.saveTimeout@" \c2more seconds before you are able to save again.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            %count = 0;
            %path = "Buildings/ClientSaves/"@%client.guid@"/";
            %dummy = "Buildings/ClientSaves/"@%client.guid@"/*";
            for(%i = findFirstFile(%dummy); %i !$= ""; %i = findNextFile(%dummy))
            {
               %count++;
            }

            if(%count > $Host::MaxClientSaves)
            {
               messageClient(%client, "", "\c2Too many saves. You must either delete a few saves or overwrite them.");
               return;
            }

            %name = getsubstr(%typeName, 5, 255);
            if(%name $= "(empty)")
               %name = "ClientSave"@(%count+1)@".cs";

            %grp = nameToID("MissionCleanup/Deployables");
            if(!isObject(%grp))
            {
               messageClient(%client, "", "\c2There is nothing to save.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            %buildingcount = 0;
            for(%g = 0; %g < %grp.getCount(); %g++)
            {
               %d = %grp.getObject(%g);
               if(%d.getOwner() == %client)
                  %buildingcount++;
            }

            if(%buildingcount == 0)
            {
               messageClient(%client, "", "\c2There is nothing to save.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            messageAll('MsgAdminForce', "\c3"@%client.nameBase@" \c2is saving "@(%client.sex $= "Male" ? "his" : "her")@" pieces.");
            %obj = new FileObject();
            %obj.openforwrite(%path @ %name);
            %obj.writeLine("// Saved by \"" @ getField(%client.nameBase, 0) @ "\"");
            %obj.writeLine("// Created in mission \"" @ $MissionName @ "\"");
            %obj.writeLine("// Construction " @ $ModVersion);
            %obj.writeLine("// Piece Count for this save is "@%buildingcount@" pieces");
            %obj.writeLine("");

            for(%x = 0; %x < %grp.getCount(); %x++)
            {
               %deployable = %grp.getObject(%x);
               if(%deployable.getOwner() == %client)
               {
                  %towrite = writeBuildingComponent(%deployable);
                  if(%towrite !$= "")
                     %obj.writeline(%towrite);
               }
            }

            %obj.close();
            %obj.delete();
            messageClient(%client, "", "\c2Building saved to file:\c3 "@%path @ %name@"");
            %client.saveTimeout = 60;
            %client.saveTimeoutSchedule = schedule(1000, 0, "ClearSaveTimeout", %client);
            %client.BuildingManagerMode = 0;
            %client.BuildingManagerSubMode = 0;
         return;
         }
         else if(%client.BuildingManagerSubMode == 2) // Loading.
         {
            if(%client.loadTimeout > 1)
            {
               messageClient(%client, "", "\c2Cannot load. You must wait\c3 "@%client.loadTimeout@" \c2more seconds before you are able to load again.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            // First, count up all of the pieces.
            %grp = nameToID("MissionCleanup/Deployables");
            %name = getsubstr(%typeName, 5, 255);
            %path = "Buildings/ClientSaves/"@%client.guid@"/"@%name;
            if(!isFile(%path))
            {
               messageClient(%client, "", "\c2You cannot load an empty file.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            %piececount = 0;
            %clpiececount = 0;

            %tmp = new FileObject();
            %tmp.openforread(%path);
            while(!%tmp.isEOF())
            {
               %line = %tmp.readline();
               if(strstr(%line, "// Piece Count for this save is ") != -1)
               {
                  %newstring = getsubstr(%line, 32, 255);
                  %clpiececount = getword(%newstring, 0);
                  break;
               }
            }

            %piececount = Deployables.getCount();

            if(((%clpiececount + %piececount) > $Host::MaxPieceVote) && ((ClientGroup.getCount() - $HostGameBotCount) > 1))
               serverCmdStartNewVote(%client, "VoteLoadBuilding", %clpiececount@ " \c2piece building", "leaving\c3 "@1024 - (%clpiececount + %piececount)@" \c2pieces left", %path, %client, 0);
            else
            {
               messageAll("", "\c3"@%client.nameBase@" \c2is loading "@(%client.sex $= "Male" ? "his" : "her")@"\c3 "@%clpiececount@" \c2piece building. Power has been evaluated and duplicates have been removed.");

               compile(%path);
               exec(%path);
               Game.removeDepTime = getSimTime() + delDupPieces(0,0,true) + 1000;
               globalPowerCheck();
            }

            %client.loadTimeout = 60;
            %client.loadTimeoutSchedule = schedule(1000, 0, "ClearLoadTimeout", %client);
            %client.BuildingManagerMode = 0;
            %client.BuildingManagerSubMode = 0;
            return;
         }
         else if(%client.BuildingManagerSubMode == 3) // Renaming.
         {
            if(%client.isRenaming)
            {
               messageClient(%client, "", "\c2You are already renaming another file. Type\c3 cancel \c2in order to cancel the rename.");
               %client.BuildingManagerMode = 0;
               %client.BuildingManagerSubMode = 0;
               return;
            }

            %name = getsubstr(%typeName, 5, 255);
            %path = "Buildings/ClientSaves/"@%client.guid@"/"@%name;

            if(!isFile(%path))
            {
               messageClient(%client, "", "\c2Cannot rename an empty file.");
               return;
            }

            %client.isRenaming = 1;
            %client.renameFile = %path;
            messageClient(%client, "", "\c2The next message you type will rename the file. Type\c3 cancel \c2in order to cancel the operation.");
            messageClient(%client, "", "\c2Note that you must add\c3 .cs \c2at the end of the new name in order for the save to work correctly.");
            %client.BuildingManagerMode = 0;
            %client.BuildingManagerSubMode = 0;
            return;
         }
         else if(%client.BuildingManagerSubMode == 4) // Deleting.
         {
            %name = getsubstr(%typeName, 5, 255);
            %path = "Buildings/ClientSaves/"@%client.guid@"/"@%name;
            if(!isFile(%path))
            {
               messageClient(%client, "", "\c2Cannot delete an empty file.");
               return;
            }

            deleteFile(%path);
            messageClient(%client, "", "\c2The save file\c3 "@%name@" \c2has been deleted.");
            %client.BuildingManagerMode = 0;
            %client.BuildingManagerSubMode = 0;
            return;
         }
      }
   }

   if( %typeName $= "VoteMakeKeeper" && (!$Host::AllowKeeperPlayerVotes && !%client.isSuperAdmin))
      return;

   if( (!%client.isAdmin) && (%typeName !$= "VoteKickPlayer" && %typeName !$= "VoteAdminPlayer" && %typeName !$= "VoteMakeNotKeeper" && %typeName !$= "VoteMakeKeeper" && %typeName !$= "VoteChangeMission" && %typeName !$= "VoteTeamDamage" && %typeName !$= "VoteChangeTimeLimit" && %typeName !$= "VotePurebuild" && %typeName !$= "VoteExpertMode" && %typeName !$= "VoteRemoveOrphanedDeployables" && %typeName !$= "VoteTournamentMode" && %typeName !$= "VoteFFAMode" && %typeName !$= "VoteLoadBuilding"))
   {
      messageClient(%client, "", "\c2Your vote request was rejected.");
      return;
   }

   %typePass = true;

   // if not a valid vote, turn back.
   if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteTeamDamage" )
      if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteHoardMode" )
         if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteGreedMode" )
// JTL
            if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VotePurebuild" )
              if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteCascadeMode" )
                if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteExpertMode" )
                  if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteVehicles" )
                    if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteSatchelCharge" )
                      if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteOnlyOwnerDeconstruct" )
                        if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteOnlyOwnerCascade" )
                          if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteOnlyOwnerRotate" )
                            if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteOnlyOwnerCubicReplace" )
                              if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteRemoveDeployables" )
                                if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteGlobalPowerCheck" )
                                  if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteRemoveDupDeployables" )
                                    if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteRemoveNonPoweredDeployables" )
                                      if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteRemoveOrphanedDeployables" )
                                        if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteInvincibleArmors" )
                                          if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteInvincibleDeployables" )
                                            if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteUndergroundMode" )
                                              if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteHazardMode" )
//                                                if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VoteMTCMode" )
                                                  if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VotePrison" )
                                                    if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VotePrisonKilling" )
                                                      if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VotePrisonTeamKilling" )
                                                        if( $VoteMessage[ %typeName ] $= "" && %typeName !$= "VotePrisonDeploySpam" )
                                                                  %typePass = false;
// End JTL

   if(( $VoteMessage[ %typeName, $TeamDamage ] $= "" && %typeName $= "VoteTeamDamage" ))
      %typePass = false;
// JTL
   if(( $VoteMessage[ %typeName, $Host::Purebuild ] $= "" && %typeName $= "VotePurebuild" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Cascade ] $= "" && %typeName $= "VoteCascadeMode" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::ExpertMode ] $= "" && %typeName $= "VoteExpertMode" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Vehicles ] $= "" && %typeName $= "VoteVehicles" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::SatchelChargeEnabled ] $= "" && %typeName $= "VoteSatchelCharge" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::OnlyOwnerDeconstruct ] $= "" && %typeName $= "VoteOnlyOwnerDeconstruct" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::OnlyOwnerCascade ] $= "" && %typeName $= "VoteOnlyOwnerCascade" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::OnlyOwnerRotate ] $= "" && %typeName $= "VoteOnlyOwnerRotate" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::OnlyOwnerCubicReplace ] $= "" && %typeName $= "VoteOnlyOwnerCubicReplace" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::InvincibleArmors ] $= "" && %typeName $= "VoteInvincibleArmors" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::InvincibleDeployables ] $= "" && %typeName $= "VoteInvincibleDeployables" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::AllowUnderground ] $= "" && %typeName $= "VoteUndergroundMode" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Hazard::Enabled ] $= "" && %typeName $= "VoteHazardMode" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Prison::Enabled ] $= "" && %typeName $= "VotePrison" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Prison::Kill ] $= "" && %typeName $= "VotePrisonKilling" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Prison::TeamKill ] $= "" && %typeName $= "VotePrisonTeamKilling" ))
      %typePass = false;
   if(( $VoteMessage[ %typeName, $Host::Prison::DeploySpam ] $= "" && %typeName $= "VotePrisonDeploySpam" ))
      %typePass = false;
// End JTL

   if( !%typePass )
      return; // -> bye ;)

   // z0dd - ZOD, 10/03/02. This was busted, BanPlayer was never delt with.
   if( %typeName $= "BanPlayer" )
   {
      if( !%client.isSuperAdmin || %arg1.isAdmin )
      {
         return; // -> bye ;)
      }
      else
      {
         ban( %arg1, %client );
         return;
      }
   }

   if(%typeName $= "CancelVote")
   {
      if(!%client.isAdmin)
         return;

      ccCancelVote(%client);
      return;
   }

   if(%typeName $= "PassVote")
   {
      if(!%client.isAdmin)
         return;

      ccPassVote(%client);
      return;
   }

   %isAdmin = ( %client.isAdmin || %client.isSuperAdmin );

// JTL
   if(%typeName $= "VoteVehicles" && !%isAdmin)
     if(%typeName $= "VoteVehicles" && !%isAdmin)
       if(%typeName $= "VoteSatchelCharge" && !%isAdmin)
         if(%typeName $= "VoteOnlyOwnerDeconstruct" && !%isAdmin)
           if(%typeName $= "VoteOnlyOwnerCascade" && !%isAdmin)
             if(%typeName $= "VoteOnlyOwnerRotate" && !%isAdmin)
               if(%typeName $= "VoteOnlyOwnerCubicReplace" && !%isAdmin)
                 if(%typeName $= "VoteRemoveDeployables" && !%isAdmin)
                   if(%typeName $= "VoteGlobalPowerCheck" && !%isAdmin)
                     if(%typeName $= "VoteRemoveDupDeployables" && !%isAdmin)
                       if(%typeName $= "VoteRemoveNonPoweredDeployables" && !%isAdmin)
                         if(%typeName $= "VoteRemoveOrphanedDeployables" && !%isAdmin)
                           if(%typeName $= "VoteInvincibleArmors" && !%isAdmin)
                             if(%typeName $= "VoteInvincibleDeployables" && !%isAdmin)
                               if(%typeName $= "VoteUndergroundMode" && !%isAdmin)
                                 if(%typeName $= "VoteHazardMode" && !%isAdmin)
//                                   if(%typeName $= "VoteMTCMode" && !%isAdmin)
                                     if(%typeName $= "VotePrison" && !%isAdmin)
                                       if(%typeName $= "VotePrisonKilling" && !%isAdmin)
                                         if(%typeName $= "VotePrisonTeamKilling" && !%isAdmin)
                                           if(%typeName $= "VotePrisonDeploySpam" && !%isAdmin)
                                                     %typePass = false;

   if( !%typePass )
      return; // -> bye ;)
// End JTL

   // keep these under the server's control. I win.
   if( !%playerVote )
      %actionMsg = $VoteMessage[ %typeName ];
   else if( %typeName $= "VoteTeamDamage" || %typeName $= "VoteGreedMode" || %typeName $= "VoteHoardMode" )
      %actionMsg = $VoteMessage[ %typeName, $TeamDamage ];
// JTL
   else if( %typeName $= "VotePurebuild"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Purebuild ];
   else if( %typeName $= "VoteCascadeMode"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Cascade ];
   else if( %typeName $= "VoteExpertMode"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::ExpertMode ];
   else if( %typeName $= "VoteVehicles"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Vehicles ];
   else if( %typeName $= "VoteSatchelCharge"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::SatchelChargeEnabled ];
   else if( %typeName $= "VoteOnlyOwnerDeconstruct"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::OnlyOwnerDeconstruct ];
   else if( %typeName $= "VoteOnlyOwnerCascade"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::OnlyOwnerCascade ];
   else if( %typeName $= "VoteOnlyOwnerRotate"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::OnlyOwnerRotate ];
   else if( %typeName $= "VoteOnlyOwnerCubicReplace"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::OnlyOwnerCubicReplace ];
   else if( %typeName $= "VoteInvincibleArmors"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::InvincibleArmors ];
   else if( %typeName $= "VoteInvincibleDeployables"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::InvincibleDeployables ];
   else if( %typeName $= "VoteUndergroundMode"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::AllowUnderground ];
   else if( %typeName $= "VoteHazardMode"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Hazard::Enabled ];
   else if( %typeName $= "VotePrison"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Prison::Enabled ];
   else if( %typeName $= "VotePrisonKilling"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Prison::Kill ];
   else if( %typeName $= "VotePrisonTeamKilling"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Prison::TeamKill ];
   else if( %typeName $= "VotePrisonDeploySpam"  )
      %actionMsg = $VoteMessage[ %typeName, $Host::Prison::DeploySpam ];
// End JTL
   else
      %actionMsg = $VoteMessage[ %typeName ];

   if( !%client.canVote && !%isAdmin )
      return;
   if ( ( !%isAdmin || ( %arg1.isAdmin && ( %client != %arg1 ) ) ) &&     // z0dd - ToS 4/2/02: Allow SuperAdmins to kick Admins
        !( ( %typeName $= "VoteKickPlayer" ) && %client.isSuperAdmin ) )  // z0dd - ToS 4/2/02: Allow SuperAdmins to kick Admins
   {
      %teamSpecific = false;
           %gender = (%client.sex $= "Male" ? 'he' : 'she');
      if ( Game.scheduleVote $= "" )
      {
         %clientsVoting = 0;

                        //send a message to everyone about the vote...
         if ( %playerVote )
              {
            %teamSpecific = ( %typeName $= "VoteKickPlayer" ) && ( Game.numTeams > 1 );
            %kickerIsObs = %client.team == 0;
            %kickeeIsObs = %arg1.team == 0;
            %sameTeam = %client.team == %arg1.team;

            if( %kickeeIsObs )
            {
               %teamSpecific = false;
               %sameTeam = false;
            }

            if(( !%sameTeam && %teamSpecific) && %typeName !$= "VoteAdminPlayer" && %typeName !$= "VoteMakeKeeper" && %typeName !$= "VoteMakeNotKeeper")
            {
               messageClient(%client, "", "\c2Player votes must be team based.");
               return;
            }

            // kicking is team specific
            if( %typeName $= "VoteKickPlayer" )
            {
               if(%arg1.isSuperAdmin)
               {
                  messageClient(%client, '', '\c2You can not %1 %2, %3 is a Super Admin!', %actionMsg, %arg1.name, %gender);
                  return;
               }

               Game.kickClient = %arg1;
               Game.kickClientName = %arg1.name;
               Game.kickGuid = %arg1.guid;
               Game.kickTeam = %arg1.team;

               if(%teamSpecific)
               {
                  for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
                  {
                     %cl = ClientGroup.getObject( %idx );

                     if (%cl.team == %client.team && !%cl.isAIControlled())
                     {
                        messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 \c3%3\c2.', %client.name, %actionMsg, %arg1.name);
                        %clientsVoting++;
                     }
                  }
               }
               else
               {
                  for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
                  {
                     %cl = ClientGroup.getObject( %idx );
                     if ( !%cl.isAIControlled() )
                     {
                        messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 \c3%3\c2.', %client.name, %actionMsg, %arg1.name);
                        %clientsVoting++;
                     }
                  }
               }
            }
            else
            {
               for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
               {
                  %cl = ClientGroup.getObject( %idx );
                  if ( !%cl.isAIControlled() )
                  {
                     messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 \c3%3\c2.', %client.name, %actionMsg, %arg1.name);
                     %clientsVoting++;
                  }
               }
            }
         }
         else if ( %typeName $= "VoteChangeMission" )
         {
            for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
            {
               %cl = ClientGroup.getObject( %idx );
               if ( !%cl.isAIControlled() )
               {
                  messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 \c3%3\c2 (%4)', %client.name, %actionMsg, %arg1, %arg2 );
                  %clientsVoting++;
               }
            }
         }
         else if ( %typeName $= "VoteLoadBuilding" )
         {
            for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
            {
               %cl = ClientGroup.getObject( %idx );
               if ( !%cl.isAIControlled() )
               {
                  messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 \c3%3\c2, %4.', %client.name, %actionMsg, %arg1, %arg2 );
                  %clientsVoting++;
               }
            }
         }
         else if (%arg1 !$= 0)
         {
                                if (%arg2 !$= 0)
                      {
               if(%typeName $= "VoteTournamentMode")
               {
                  %admin = getAdmin();
                  if(%admin > 0)
                  {
                     for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
                     {
                        %cl = ClientGroup.getObject( %idx );
                        if ( !%cl.isAIControlled() )
                        {
                           messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 Tournament Mode (%3).', %client.name, %actionMsg, %arg1);
                           %clientsVoting++;
                        }
                     }
                  }
                  else
                  {
                     messageClient( %client, 'clientMsg', 'There must be a server admin to play in Tournament Mode.');
                     return;
                  }
               }
               else
               {
                  for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
                  {
                     %cl = ClientGroup.getObject( %idx );
                     if ( !%cl.isAIControlled() )
                     {
                        messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to %2 %3 %4.', %client.name, %actionMsg, %arg1, %arg2);
                        %clientsVoting++;
                     }
                  }
                                   }
            }
            else
            {
               for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
               {
                  %cl = ClientGroup.getObject( %idx );
                  if ( !%cl.isAIControlled() )
                  {
                               messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to\c3 %2 \c2%3.', %client.name, %actionMsg, %arg1);
                     %clientsVoting++;
                  }
               }
            }
         }
                        else
         {
            for ( %idx = 0; %idx < ClientGroup.getCount(); %idx++ )
            {
               %cl = ClientGroup.getObject( %idx );
               if ( !%cl.isAIControlled() )
               {
                       messageClient( %cl, 'VoteStarted', '\c3%1 \c2initiated a vote to\c3 %2\c2.', %client.name, %actionMsg);
                  %clientsVoting++;
               }
            }
         }

         // open the vote hud for all clients that will participate in this vote
         if(%teamSpecific)
         {
            for ( %clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++ )
            {
               %cl = ClientGroup.getObject( %clientIndex );

               if(%cl.team == %client.team && !%cl.isAIControlled())
                  messageClient(%cl, 'openVoteHud', "", %clientsVoting, ($Host::VotePassPercent / 100));
            }
         }
         else
         {
            for ( %clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++ )
            {
               %cl = ClientGroup.getObject( %clientIndex );
               if ( !%cl.isAIControlled() )
                  messageClient(%cl, 'openVoteHud', "", %clientsVoting, ($Host::VotePassPercent / 100));
            }
         }

         clearVotes();
         Game.voteType = %typeName;
         Game.scheduleVote = schedule( ($Host::VoteTime * 1000), 0, "calcVotes", %typeName, %arg1, %arg2, %arg3, %arg4 );

         Game.votingArguments[0] = %typeName;
         Game.votingArguments[1] = %arg1;
         Game.votingArguments[2] = %arg2;
         Game.votingArguments[3] = %arg3;
         Game.votingArguments[4] = %arg4;

         %client.vote = true;
         messageAll('addYesVote', "");

         if(!%client.team == 0)
            clearBottomPrint(%client);
         logEcho(%client.nameBase@" ("@%client@") initiated a "@%typeName@" vote (arg1: "@%arg1@", arg2: "@%arg2@", arg3: "@%arg3@", arg4: "@%arg4@")");
      }
      else
         messageClient( %client, 'voteAlreadyRunning', '\c2A vote is already in progress.' );
   }
   else
   {
      if ( Game.scheduleVote !$= "" && Game.voteType $= %typeName )
      {
         messageAll('closeVoteHud', "");
         cancel(Game.scheduleVote);
         Game.scheduleVote = "";
      }

      // if this is a superAdmin, don't kick or ban
      if(%arg1 != %client)
      {
         if(!%arg1.isSuperAdmin)
         {
            // Set up kick/ban values:
            if ( %typeName $= "VoteBanPlayer" || %typeName $= "VoteKickPlayer" )
            {
               Game.kickClient = %arg1;
               Game.kickClientName = %arg1.name;
               Game.kickGuid = %arg1.guid;
               Game.kickTeam = %arg1.team;
            }

 //Tinman - PURE servers can't call "eval"
            //Mark - True, but neither SHOULD a normal server
            //     - thanks Ian Hardingham
            Game.evalVote(%typeName, %client, %arg1, %arg2, %arg3, %arg4);
         }
         else
            messageClient(%client, '', '\c2You can not %1 %2, %3 is a Super Admin!', %actionMsg, %arg1.name, %gender);
      }
   }

   %client.canVote = false;
   %client.rescheduleVote = schedule( ($Host::voteSpread * 1000) + ($Host::voteTime * 1000) , 0, "resetVotePrivs", %client );
}

function resetVotePrivs( %client )
{
   //messageClient( %client, '', 'You may now start a new vote.');
   %client.canVote = true;
   %client.rescheduleVote = "";
}

function serverCmdSetPlayerVote(%client, %vote)
{
   %tf = %client.transferFrom;
   if(isObject(%client.transferTo) && %vote == 0)
   {
      messageClient(%client, "", "\c2Piece transaction cancelled.");
      messageClient(%client.transferTo, "", "\c3"@%client.nameBase@" \c2has cancelled the piece transaction.");

      %client.transferTo.transferFrom = "";
      %client.transferTo = "";
      return;
   }

   if(isObject(%client.transferFrom))
   {
      if(%vote == 1)
      {
         messageAll('MsgAdminForce', "\c3"@%tf.nameBase@"\c2 is transferring "@(%tf.sex $= "Male" ? "his" : "her")@" pieces to \c3"@%client.nameBase@"\c2.");
         GivePieces(%client.transferFrom, %client);

         %tf.transferTo = "";
         %client.transferFrom = "";
      }
      else
      {
         messageClient(%client, "", "\c2Piece transaction declined.");
         messageClient(%tf, "", "\c3"@%client.nameBase@" \c2has declined the piece transaction.");

         %tf.transferTo = "";
         %client.transferFrom = "";
      }

      return;
   }

   // players can only vote once
   if( %client.vote $= "" )
   {
      %client.vote = %vote;
      if(%client.vote == 1)
         messageAll('addYesVote', "");
      else
         messageAll('addNoVote', "");

      commandToClient(%client, 'voteSubmitted', %vote);
   }
}

function calcVotes(%typeName, %arg1, %arg2, %arg3, %arg4)
{
   if(%typeName $= "voteMatchStart")
      if($MatchStarted || $countdownStarted)
         return;

   for ( %clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++ )
   {
      %cl = ClientGroup.getObject( %clientIndex );
      messageClient(%cl, 'closeVoteHud', "");

      if ( %cl.vote !$= "" )
      {
         if ( %cl.vote )
         {
            Game.votesFor[%cl.team]++;
            Game.totalVotesFor++;
         }
         else
         {
            Game.votesAgainst[%cl.team]++;
            Game.totalVotesAgainst++;
         }
      }
      else
      {
         Game.votesNone[%cl.team]++;
         Game.totalVotesNone++;
      }
   }
   //Tinman - PURE servers can't call "eval"
   //Mark - True, but neither SHOULD a normal server
   //     - thanks Ian Hardingham
   Game.evalVote(%typeName, false, %arg1, %arg2, %arg3, %arg4);
   Game.scheduleVote = "";
   Game.kickClient = "";

   Game.votingArguments = "";

   clearVotes();
}

function clearVotes()
{
   for(%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
   {
      %client = ClientGroup.getObject(%clientIndex);
      %client.vote = "";
      messageClient(%client, 'clearVoteHud', "");
   }

   for(%team = 1; %team < 5; %team++)
   {
      Game.votesFor[%team] = 0;
      Game.votesAgainst[%team] = 0;
      Game.votesNone[%team] = 0;
      Game.totalVotesFor = 0;
      Game.totalVotesAgainst = 0;
      Game.totalVotesNone = 0;
   }
}

// Tournament mode Stuff-----------------------------------

function setModeFFA( %mission, %missionType )
{
   if( $Host::TournamentMode )
   {
      $Host::TournamentMode = false;

      if( isObject( Game ) )
         Game.gameOver();

      loadMission(%mission, %missionType, false);
   }
}

//------------------------------------------------------------------

function setModeTournament( %mission, %missionType )
{
   if( !$Host::TournamentMode )
   {
      $Host::TournamentMode = true;

      if( isObject( Game ) )
         Game.gameOver();

      loadMission(%mission, %missionType, false);
   }
}
