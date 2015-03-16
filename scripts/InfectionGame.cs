// DisplayName = Infection

//--- GAME RULES BEGIN ---
// Build a Base or use Map bases.
// Defend your territory from the horde of undead.
// Either contain or destroy the Zombie infection.
// -25 points per team kill.
// -10 points per death or suicide.
//--- GAME RULES END ---

// Get Rid of those Underpowered weapons.
$InvBanList[Infection, "KriegRifle"] = 1;
$InvBanList[Infection, "PBC"] = 1;

// Infection Game
function InfectionGame::initGameVars(%game)
{
   %game.SCORE_PER_SUICIDE                  = -10;
   %game.SCORE_PER_TEAMKILL                 = -25;
   %game.SCORE_PER_DEATH                    = -10;

   %game.SCORE_PER_KILL                     = 0;
}

package InfectionGame {

function InfectionGame::timeLimitReached(%game)
{
   logEcho("game over (timelimit)");
   %game.gameOver();
   cycleMissions();
}

function InfectionGame::scoreLimitReached(%game)
{
   logEcho("game over (scorelimit)");
   %game.gameOver();
   cycleMissions();
}

function InfectionGame::gameOver(%game)
{
   DefaultGame::gameOver(%game);

   messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );

   cancel(%game.timeThread);
   messageAll('MsgClearObjHud', "");
   for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
      %client = ClientGroup.getObject(%i);
      %game.resetScore(%client);
   }
}

function InfectionGame::clientMissionDropReady(%game, %client)
{
   messageClient(%client, 'MsgClientReady',"", %game.class);
   %game.resetScore(%client);
   for(%i = 1; %i <= %game.numTeams; %i++)
   {
      $Teams[%i].score = 0;
      messageClient(%client, 'MsgInfectionAddTeam', "", %i, %game.getTeamName(%i), $flagStatus[%i], $TeamScore[%i]);
   }

   messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2).', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );

   DefaultGame::clientMissionDropReady(%game, %client);
}

function InfectionGame::assignClientTeam(%game, %client, %respawn)
{
   DefaultGame::assignClientTeam(%game, %client, %respawn);
   messageClient(%client, 'MsgCheckTeamLines', "", %client.team);
}

function InfectionGame::recalcScore(%game, %cl)
{
   %killValue = %cl.kills * %game.SCORE_PER_KILL;
   %deathValue = %cl.deaths * %game.SCORE_PER_DEATH;

   if (%killValue - %deathValue == 0)
      %killPoints = 0;
   else
      %killPoints = (%killValue * %killValue) / (%killValue - %deathValue);

   if(!isDemo())
   {
        %cl.offenseScore = %killPoints +
                        %cl.suicides            * %game.SCORE_PER_SUICIDE +
                        %cl.teamKills           * %game.SCORE_PER_TEAMKILL +
                        %cl.vehicleScore + %cl.vehicleBonus;

        %cl.defenseScore = %cl.genRepairs          * %game.SCORE_PER_REPAIR_GEN             +
                        %cl.returnPts;
        }

   %cl.score = mFloor(%cl.offenseScore + %cl.defenseScore + (%cl.zkills * $zombie::killpoints));

   %game.recalcTeamRanks(%cl);
   }

function InfectionGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement)
{
   if( isObject( %implement ) )
   {
      if( %implement.getDataBlock().getName() $= "AssaultPlasmaTurret" ||  %implement.getDataBlock().getName() $= "BomberTurret" ) // gunner
           %clKiller = %implement.vehicleMounted.getMountNodeObject(1).client;
      else if(%implement.getDataBlock().catagory $= "Vehicles") // pilot
           %clKiller = %implement.getMountNodeObject(0).client;
   }

   if(%game.testTurretKill(%implement))
      %game.awardScoreTurretKill(%clVictim, %implement);
   else if (%game.testKill(%clVictim, %clKiller))
   {
      %value = %game.awardScoreKill(%clKiller);
      %game.shareScore(%clKiller, %value);
      %game.awardScoreDeath(%clVictim);

      if (%game.testEscortAssist(%clVictim, %clKiller))
         %game.awardScoreEscortAssist(%clKiller);
   }
   else
   {
      if (%game.testSuicide(%clVictim, %clKiller, %damageType))
      {
         %game.awardScoreSuicide(%clVictim);
      }
      else
      {
      if (%game.testTeamKill(%clVictim, %clKiller))
         %game.awardScoreTeamKill(%clVictim, %clKiller);
   }
   }
}

function InfectionGame::resetDontScoreTimer(%game, %team)
{
   $dontScoreTimer[%team] = false;
}

function InfectionGame::resetScore(%game, %client)
{
   %client.offenseScore = 0;
   %client.kills = 0;
   %client.deaths = 0;
   %client.suicides = 0;
   %client.teamKills = 0;
   %client.vehicleScore = 0;
   %client.vehicleBonus = 0;

   %client.defenseScore = 0;
   %client.genRepairs = 0;
   %client.returnPts = 0;
   %client.score = 0;
}

function InfectionGame::objectRepaired(%game, %obj, %objName)
{
   %item = %obj.getDataBlock().getName();
   switch$ (%item)
   {
      case generatorLarge :
         %game.genOnRepaired(%obj, %objName);
      case sensorMediumPulse :
   }
   %obj.wasDisabled = false;
}

function InfectionGame::genOnRepaired(%game, %obj, %objName)
{

   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      %game.awardScoreGenRepair(%obj.repairedBy);
   }
}

function InfectionGame::awardScoreGenRepair(%game, %cl)
{
   %cl.genRepairs++;
   if (%game.SCORE_PER_REPAIR_GEN != 0)
   {
      messageClient(%cl, 'msgGenRep', '\c0You received a %1 point bonus for repairing a generator.', %game.SCORE_PER_REPAIR_GEN);
   }
   %game.recalcScore(%cl);
}

function InfectionGame::enterMissionArea(%game, %playerData, %player)
{
   if(%player.getState() $= "Dead")
      return;
   %player.client.outOfBounds = false;
   messageClient(%player.client, 'EnterMissionArea', '\c1You are back in the mission area.');
}

function InfectionGame::leaveMissionArea(%game, %playerData, %player)
{
   if(%player.getState() $= "Dead")
      return;
   %player.client.outOfBounds = true;

   messageClient(%player.client, 'MsgLeaveMissionArea', '\c1You have left the mission area.~wfx/misc/warning_beep.wav');
   logEcho(%player.client.nameBase@" (pl "@%player@"/cl "@%player.client@") left mission area");
}

function InfectionGame::testKill(%game, %victimID, %killerID)
{
   return ((%killerID !=0) && (%victimID.team != %killerID.team));
}

function InfectionGame::awardScoreKill(%game, %killerID)
{
   %killerID.kills++;
   %game.recalcScore(%killerID);
    return %game.SCORE_PER_KILL;
}
};
