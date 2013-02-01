// DisplayName = CombatCon

//--- GAME RULES BEGIN ---
// Make a base or use map bases.
// Defend your base.
// Destroy the enemy base.
// Team killing and suicide penalties.
//--- GAME RULES END ---

// CombatCon Game
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Notes are all done by Blnukem. These are to help you know what's what when
//  editing this gametype. (The notes are not completed, so don't edit anything)
//------------------------------------------------------------------------------
// NOTICE:
// This rather huge file will be cleaned and remade in a later version of ACCM.
// So for all you file moderators out there, have fun tweaking this gametype.
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Now to get rid of the overpowered weapons.
$InvBanList[CombatCon, "M4"] = 1;
$InvBanList[CombatCon, "RailGun"] = 1;
$InvBanList[CombatCon, "NapalmMortar"] = 1;
$InvBanList[CombatCon, "Flamer"] = 1;
$InvBanList[CombatCon, "FlamerAmmoPack"] = 1;
$InvBanList[CombatCon, "ELFBarrelPack"] = 1;
//------------------------------------------------------------------------------
// Easy huh? Also as another reminder, the weapons above were removed by popular
// demand of the ACCM users and the Devs. The weapons are just too ovepowered
// for PVP style gameplay.
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Lets begin the Gametype code... Shall we?
//------------------------------------------------------------------------------
// NOTICE:
// Any notes below this point were not done by Blnukem. So it's advised you
// don't try editing anything below this point. Or you'll mess the Gametype up.
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

function CombatConGame::initGameVars(%game)
{

    if(isDemo())
    {
       %game.SCORE_PER_SUICIDE = -10;
       %game.SCORE_PER_TEAMKILL = -10;
       %game.SCORE_PER_DEATH = 0;

       %game.SCORE_PER_KILL = 10;
       %game.SCORE_PER_GEN_DESTROY = 8;

       %game.SCORE_PER_TURRET_KILL = 5;
       %game.SCORE_PER_GEN_DEFEND = 5;
       %game.SCORE_PER_GEN_REPAIR = 2;

       %game.RADIUS_GEN_DEFENSE = 20;  //meters


       %game.fadeTimeMS = 2000;

       %game.notifyMineDist = 7.5;


       %game.stalemate = false;
       %game.stalemateObjsVisible = false;
       %game.stalemateTimeMS = 60000;
       %game.stalemateFreqMS = 15000;
       %game.stalemateDurationMS = 6000;
    }
    if( !isDemo() )
    {
       %game.SCORE_PER_SUICIDE                  = -10;
       %game.SCORE_PER_TEAMKILL                 = -10;
       %game.SCORE_PER_DEATH                    = 0;

       %game.SCORE_PER_KILL                     = 10;
       %game.SCORE_PER_HEADSHOT                 = 2;

       %game.SCORE_PER_TURRET_KILL              = 10;
       %game.SCORE_PER_TURRET_KILL_AUTO         = 0;
       %game.SCORE_PER_GEN_DEFEND               = 5;

       %game.SCORE_PER_DESTROY_GEN              = 10;
       %game.SCORE_PER_DESTROY_SENSOR           = 4;
       %game.SCORE_PER_DESTROY_TURRET           = 5;
       %game.SCORE_PER_DESTROY_ISTATION         = 2;
       %game.SCORE_PER_DESTROY_VSTATION         = 5;
       %game.SCORE_PER_DESTROY_SOLAR            = 5;
       %game.SCORE_PER_DESTROY_SENTRY           = 4;
       %game.SCORE_PER_DESTROY_DEP_SENSOR       = 1;
       %game.SCORE_PER_DESTROY_DEP_INV          = 2;
       %game.SCORE_PER_DESTROY_DEP_TUR          = 3;

       %game.SCORE_PER_DESTROY_SHRIKE           = 5;
       %game.SCORE_PER_DESTROY_STRIKEFIGHTER    = 5;
       %game.SCORE_PER_DESTROY_HELICOPTER       = 5;
       %game.SCORE_PER_DESTROY_AWACS            = 7;
       %game.SCORE_PER_DESTROY_BOMBER           = 7;
       %game.SCORE_PER_DESTROY_GUNSHIP          = 10;
       %game.SCORE_PER_DESTROY_HEAVYHELICOPTER  = 10;
       %game.SCORE_PER_DESTROY_TRANSPORT        = 10;
       %game.SCORE_PER_DESTROY_WILDCAT          = 2;
       %game.SCORE_PER_DESTROY_TANK             = 5;
       %game.SCORE_PER_DESTROY_HEAVYTANK        = 5;
       %game.SCORE_PER_DESTROY_CGTANK           = 5;
       %game.SCORE_PER_DESTROY_FFTRANSPORT      = 5;
       %game.SCORE_PER_DESTROY_ARTILLERY        = 10;
       %game.SCORE_PER_DESTROY_MPB              = 10;
       %game.SCORE_PER_DESTROY_TRANSBOAT        = 4;
       %game.SCORE_PER_DESTROY_SUB              = 10;
       %game.SCORE_PER_DESTROY_BOAT             = 15;
       %game.SCORE_PER_PASSENGER                = 3;

       %game.SCORE_PER_REPAIR_GEN               = 8;
       %game.SCORE_PER_REPAIR_SENSOR            = 1;
       %game.SCORE_PER_REPAIR_TURRET            = 4;
       %game.SCORE_PER_REPAIR_ISTATION          = 2;
       %game.SCORE_PER_REPAIR_VSTATION          = 4;
       %game.SCORE_PER_REPAIR_SOLAR             = 4;
       %game.SCORE_PER_REPAIR_SENTRY            = 2;
       %game.SCORE_PER_REPAIR_DEP_TUR           = 3;
       %game.SCORE_PER_REPAIR_DEP_INV           = 2;

       %game.FLAG_RETURN_DELAY = 45 * 1000;

       %game.TIME_CONSIDERED_FLAGCARRIER_THREAT = 3 * 1000;
       %game.RADIUS_GEN_DEFENSE = 20;
       %game.RADIUS_FLAG_DEFENSE = 20;

	    %game.TOUCH_DELAY_MS = 20000;

       %game.fadeTimeMS = 2000;

       %game.notifyMineDist = 7.5;


       %game.stalemate = false;
       %game.stalemateObjsVisible = false;
       %game.stalemateTimeMS = 60000;
       %game.stalemateFreqMS = 15000;
       %game.stalemateDurationMS = 6000;
    }

}

package CombatConGame {

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Now Seriously... STOP EDITING!!!
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

function ShapeBaseData::onDestroyed(%data, %obj)
{
    %scorer = %obj.lastDamagedBy;
    if(!isObject(%scorer))
       return;

    if( (%scorer.getType() & $TypeMasks::GameBaseObjectType) &&
       %scorer.getDataBlock().catagory $= "Vehicles" )
    {
        // ---------------------------------------------
        // z0dd - ZOD, 6/18/02. %name was never defined.
        %name = %scorer.getDatablock().getName();
        if(%name $= "BomberFlyer" || %name $= "AssaultVehicle")
            %gunnerNode = 1;
        else
            %gunnerNode = 0;

        if(%scorer.getMountNodeObject(%gunnerNode))
        {
            %destroyer = %scorer.getMountNodeObject(%gunnerNode).client;
            %scorer = %destroyer;
            %damagingTeam = %scorer.team;
        }
    }
    else if(%scorer.getClassName() $= "Turret")
    {
        if(%scorer.getControllingClient())
        {
            //manned turret
            %destroyer = %scorer.getControllingClient();
            %scorer = %destroyer;
            %damagingTeam = %scorer.team;
        }
        else return;  //unmanned turret
    }

    if(!%damagingTeam)
        %damagingTeam = %scorer.team;

    if(%damagingTeam == %obj.team)
    {
        //error("team objects dont score");
        return;
    }

    if(%obj.soiledByEnemyRepair)
    {
        //error(%obj SPC "was once repiared by an enemy.  No destruction points.");
        return;
    }

    %objType = %obj.getDataBlock().getName();
    if(%objType $= "GeneratorLarge")
    {
        %score = game.awardScoreGenDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "SensorLargePulse" || %objType $= "SensorMediumPulse")
    {
        %score = game.awardScoreSensorDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "TurretBaseLarge")
    {
        %score = game.awardScoreTurretDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "StationInventory")
    {
        %score = game.awardScoreInvDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "StationVehicle")
    {
        %score = game.awardScoreVehicleStationDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "SolarPanel")
    {
        %score = game.awardScoreSolarDestroy(%scorer);
        game.shareScore(%score, %score);
    }
    else if(%objType $= "SentryTurret")
    {
        %score = game.awardScoreSentryDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "DeployedMotionSensor" || %objType $= "DeployedPulseSensor")
    {
        %score = game.awardScoreDepSensorDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "TurretDeployedWallIndoor" || %objType $= "TurretDeployedFloorIndoor" ||
        %objType $= "TurretDeployedCeilingIndoor" || %objType $= "TurretDeployedOutdoor")
    {
        %score = game.awardScoreDepTurretDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }
    else if(%objType $= "DeployedStationInventory")
    {
        %score = game.awardScoreDepStationDestroy(%scorer);
        game.shareScore(%scorer, %score);
    }

}

function ShapeBaseData::onDisabled(%data, %obj)
{
    %obj.wasDisabled = true;
    Parent::onDisabled(%data, %obj);
}

function RepairGunImage::onRepair(%this, %obj, %slot)
{
    Parent::onRepair(%this, %obj, %slot);
    %target = %obj.repairing;
    if(%target && %target.team != %obj.team)
    {
        //error("Enemy stuff("@%obj@") is being repaired (by "@%target@")");
        %target.soiledByEnemyRepair = true;
    }
}

function CombatConGame::timeLimitReached(%game)
{
   logEcho("game over (timelimit)");
   %game.gameOver();
   cycleMissions();
}

function CombatConGame::scoreLimitReached(%game)
{
   logEcho("game over (scorelimit)");
   %game.gameOver();
   cycleMissions();
}

function CombatConGame::gameOver(%game)
{
   //call the default
   DefaultGame::gameOver(%game);

   //send the winner message
   %winner = "";
   if ($teamScore[1] > $teamScore[2])
      %winner = %game.getTeamName(1);
   else if ($teamScore[2] > $teamScore[1])
      %winner = %game.getTeamName(2);

   if (%winner $= 'Storm')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.stowins.wav" );
   else if (%winner $= 'Inferno')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.infwins.wav" );
   else if (%winner $= 'Starwolf')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.swwin.wav" );
   else if (%winner $= 'Blood Eagle')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.bewin.wav" );
   else if (%winner $= 'Diamond Sword')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.dswin.wav" );
   else if (%winner $= 'Phoenix')
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.pxwin.wav" );
   else
      messageAll('MsgGameOver', "Match has ended.~wvoice/announcer/ann.gameover.wav" );

   messageAll('MsgClearObjHud', "");
   for(%i = 0; %i < ClientGroup.getCount(); %i ++)
   {
      %client = ClientGroup.getObject(%i);
      %game.resetScore(%client);
   }
   for(%j = 1; %j <= %game.numTeams; %j++)
      $TeamScore[%j] = 0;
}

function CombatConGame::onClientDamaged(%game, %clVictim, %clAttacker, %damageType, %implement, %damageLoc)
{
   if(%clVictim.headshot && %damageType == $DamageType::Laser && %clVictim.team != %clAttacker.team)
   {
        %clAttacker.scoreHeadshot++;
       if (%game.SCORE_PER_HEADSHOT != 0)
      {
         messageClient(%clAttacker, 'msgHeadshot', '\c0You received a %1 point bonus for a successful headshot.', %game.SCORE_PER_HEADSHOT);
      }
      %game.recalcScore(%clAttacker);
   }

   //the DefaultGame will set some vars
   DefaultGame::onClientDamaged(%game, %clVictim, %clAttacker, %damageType, %implement, %damageLoc);


   //if victim is carrying a flag and is not on the attackers team, mark the attacker as a threat for x seconds(for scoring purposes)
   if ((%clVictim.holdingFlag !$= "") && (%clVictim.team != %clAttacker.team))
   {
      %clAttacker.dmgdFlagCarrier = true;
      cancel(%clAttacker.threatTimer);  //restart timer
      %clAttacker.threatTimer = schedule(%game.TIME_CONSIDERED_FLAGCARRIER_THREAT, %clAttacker.dmgdFlagCarrier = false);
   }


}

////////////////////////////////////////////////////////////////////////////////////////
function CombatConGame::clientMissionDropReady(%game, %client)
{
   messageClient(%client, 'MsgClientReady',"", %game.class);
   %game.resetScore(%client);
   for(%i = 1; %i <= %game.numTeams; %i++)
   {
      $Teams[%i].score = 0;
      messageClient(%client, 'MsgCombatConAddTeam', "", %i, %game.getTeamName(%i), $flagStatus[%i], $TeamScore[%i]);
   }
   //%game.populateTeamRankArray(%client);

   //messageClient(%client, 'MsgYourRankIs', "", -1);

   messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2).', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );

   DefaultGame::clientMissionDropReady(%game, %client);
}

function CombatConGame::assignClientTeam(%game, %client, %respawn)
{
   DefaultGame::assignClientTeam(%game, %client, %respawn);
   // if player's team is not on top of objective hud, switch lines
   messageClient(%client, 'MsgCheckTeamLines', "", %client.team);
}

function CombatConGame::recalcScore(%game, %cl)
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
                        %cl.escortAssists       * %game.SCORE_PER_ESCORT_ASSIST +
                        %cl.teamKills           * %game.SCORE_PER_TEAMKILL +
                        %cl.scoreHeadshot           * %game.SCORE_PER_HEADSHOT +
                        %cl.flagCaps            * %game.SCORE_PER_PLYR_FLAG_CAP       +
                        %cl.flagGrabs           * %game.SCORE_PER_PLYR_FLAG_TOUCH       +
                        %cl.genDestroys         * %game.SCORE_PER_DESTROY_GEN         +
                        %cl.sensorDestroys     * %game.SCORE_PER_DESTROY_SENSOR      +
                        %cl.turretDestroys     * %game.SCORE_PER_DESTROY_TURRET      +
                        %cl.iStationDestroys   * %game.SCORE_PER_DESTROY_ISTATION    +
                        %cl.vstationDestroys   * %game.SCORE_PER_DESTROY_VSTATION    +
                        %cl.solarDestroys      * %game.SCORE_PER_DESTROY_SOLAR       +
                        %cl.sentryDestroys     * %game.SCORE_PER_DESTROY_SENTRY      +
                        %cl.depSensorDestroys  * %game.SCORE_PER_DESTROY_DEP_SENSOR  +
                        %cl.depTurretDestroys  * %game.SCORE_PER_DESTROY_DEP_TUR     +
                        %cl.depStationDestroys * %game.SCORE_PER_DESTROY_DEP_INV     +
                        %cl.vehicleScore + %cl.vehicleBonus;

        %cl.defenseScore =   %cl.genDefends          * %game.SCORE_PER_GEN_DEFEND +
                        %cl.flagDefends         * %game.SCORE_PER_FLAG_DEFEND +
                        %cl.carrierKills        * %game.SCORE_PER_CARRIER_KILL +
                        %cl.escortAssists       * %game.SCORE_PER_ESCORT_ASSIST +
                        %cl.turretKills         * %game.SCORE_PER_TURRET_KILL_AUTO +
                        %cl.mannedturretKills   * %game.SCORE_PER_TURRET_KILL +
                        %cl.genRepairs          * %game.SCORE_PER_REPAIR_GEN             +
                        %cl.SensorRepairs       * %game.SCORE_PER_REPAIR_SENSOR          +
                        %cl.TurretRepairs       * %game.SCORE_PER_REPAIR_TURRET          +
                        %cl.StationRepairs      * %game.SCORE_PER_REPAIR_ISTATION        +
                        %cl.VStationRepairs     * %game.SCORE_PER_REPAIR_VSTATION        +
                        %cl.solarRepairs        * %game.SCORE_PER_REPAIR_SOLAR           +
                        %cl.sentryRepairs       * %game.SCORE_PER_REPAIR_SENTRY          +
                        %cl.depInvRepairs       * %game.SCORE_PER_REPAIR_DEP_INV         +
                        %cl.depTurretRepairs    * %game.SCORE_PER_REPAIR_DEP_TUR  +
                        %cl.returnPts;
        }

    if( isDemo() )
    {
        %cl.offenseScore = %killPoints +
                            %cl.flagDefends         * %game.SCORE_PER_FLAG_DEFEND +
                            %cl.suicides * %game.SCORE_PER_SUICIDE + //-1
                            %cl.escortAssists * %game.SCORE_PER_ESCORT_ASSIST + // 1
                            %cl.teamKills * %game.SCORE_PER_TEAMKILL + // -1
                            %cl.flagCaps * %game.SCORE_PER_PLYR_FLAG_CAP + // 3
                            %cl.genDestroys * %game.SCORE_PER_GEN_DESTROY; // 2

        %cl.defenseScore =   %cl.genDefends * %game.SCORE_PER_GEN_DEFEND +   // 1
                            %cl.carrierKills * %game.SCORE_PER_CARRIER_KILL +  // 1
                            %cl.escortAssists * %game.SCORE_PER_ESCORT_ASSIST + // 1
                            %cl.turretKills * %game.SCORE_PER_TURRET_KILL +  // 1
                            %cl.flagReturns * %game.SCORE_PER_FLAG_RETURN +  // 1
                            %cl.genRepairs * %game.SCORE_PER_GEN_REPAIR;  // 1
    }

   %cl.score = mFloor(%cl.offenseScore + %cl.defenseScore + (%cl.zkills * $zombie::killpoints));

   %game.recalcTeamRanks(%cl);
}

function CombatConGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement)
{
// is this a vehicle kill rather than a player kill

   // console error message suppression
   if( isObject( %implement ) )
   {
      if( %implement.getDataBlock().getName() $= "AssaultPlasmaTurret" ||  %implement.getDataBlock().getName() $= "BomberTurret" ) // gunner
           %clKiller = %implement.vehicleMounted.getMountNodeObject(1).client;
      else if(%implement.getDataBlock().catagory $= "Vehicles") // pilot
           %clKiller = %implement.getMountNodeObject(0).client;
   }

   if(%game.testTurretKill(%implement))   //check for turretkill before awarded a non client points for a kill
      %game.awardScoreTurretKill(%clVictim, %implement);
   else if (%game.testKill(%clVictim, %clKiller)) //verify victim was an enemy
   {
      %value = %game.awardScoreKill(%clKiller);
      %game.shareScore(%clKiller, %value);
      %game.awardScoreDeath(%clVictim);

      if (%game.testGenDefend(%clVictim, %clKiller))
         %game.awardScoreGenDefend(%clKiller);

      if(%game.testCarrierKill(%clVictim, %clKiller))
         %game.awardScoreCarrierKill(%clKiller);
      else
      {
         if (%game.testFlagDefend(%clVictim, %clKiller))
            %game.awardScoreFlagDefend(%clKiller);
      }
      if (%game.testEscortAssist(%clVictim, %clKiller))
         %game.awardScoreEscortAssist(%clKiller);
   }
   else
   {
      if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
      {
         %game.awardScoreSuicide(%clVictim);
      }
      else
      {
         if (%game.testTeamKill(%clVictim, %clKiller)) //otherwise test for a teamkill
            %game.awardScoreTeamKill(%clVictim, %clKiller);
      }
   }
}

function CombatConGame::testGenDefend(%game, %victimID, %killerID)
{
   InitContainerRadiusSearch(%victimID.plyrPointOfDeath, %game.RADIUS_GEN_DEFENSE, $TypeMasks::StaticShapeObjectType);
   %objID = containerSearchNext();
   while(%objID != 0)
   {
      %objType = %objID.getDataBlock().ClassName;
     if ((%objType $= "generator") && (%objID.team == %killerID.team))
        return true;  //found a killer's generator within required radius of victim's death
     else
        %objID = containerSearchNext();
   }
   return false;  //didn't find a qualifying gen within required radius of victim's point of death
}

function CombatConGame::testCarrierKill(%game, %victimID, %killerID)
{
   %flag = %victimID.plyrDiedHoldingFlag;
   return ((%flag !$= "") && (%flag.team == %killerID.team));
}

function CombatConGame::testEscortAssist(%game, %victimID, %killerID)
{
   return (%victimID.dmgdFlagCarrier);
}

function CombatConGame::testValidRepair(%game, %obj)
{
    if(!%obj.wasDisabled)
    {
        //error(%obj SPC "was never disabled");
        return false;
    }
    else if(%obj.lastDamagedByTeam == %obj.team)
    {
        //error(%obj SPC "was last damaged by a friendly");
        return false;
    }
    else if(%obj.team != %obj.repairedBy.team)
    {
        //error(%obj SPC "was repaired by an enemy");
        return false;
    }
    else
    {
        if(%obj.soiledByEnemyRepair)
            %obj.soiledByEnemyRepair = false;
        return true;
    }
}

function CombatConGame::resetDontScoreTimer(%game, %team)
{
   $dontScoreTimer[%team] = false;
}

// Asset Destruction scoring
function CombatConGame::awardScoreGenDestroy(%game,%cl)
{
   %cl.genDestroys++;
   if (%game.SCORE_PER_DESTROY_GEN != 0)
      {
         messageClient(%cl, 'msgGenDes', '\c0You received a %1 point bonus for destroying an enemy generator.', %game.SCORE_PER_DESTROY_GEN);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_GEN;
}

function CombatConGame::awardScoreSensorDestroy(%game,%cl)
{
   %cl.sensorDestroys++;
   if (%game.SCORE_PER_DESTROY_SENSOR != 0)
      {
         messageClient(%cl, 'msgSensorDes', '\c0You received a %1 point bonus for destroying an enemy sensor.', %game.SCORE_PER_DESTROY_SENSOR);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_SENSOR;
}

function CombatConGame::awardScoreTurretDestroy(%game,%cl)
{
   %cl.turretDestroys++;
   if (%game.SCORE_PER_DESTROY_TURRET != 0)
      {
         messageClient(%cl, 'msgTurretDes', '\c0You received a %1 point bonus for destroying an enemy turret.', %game.SCORE_PER_DESTROY_TURRET);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_TURRET;
}

function CombatConGame::awardScoreInvDestroy(%game,%cl)
{
   %cl.IStationDestroys++;
   if (%game.SCORE_PER_DESTROY_ISTATION != 0)
      {
         messageClient(%cl, 'msgInvDes', '\c0You received a %1 point bonus for destroying an enemy inventory station.', %game.SCORE_PER_DESTROY_ISTATION);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_ISTATION;
}

function CombatConGame::awardScoreVehicleStationDestroy(%game,%cl)
{
   %cl.VStationDestroys++;
   if (%game.SCORE_PER_DESTROY_VSTATION != 0)
      {
         messageClient(%cl, 'msgVSDes', '\c0You received a %1 point bonus for destroying an enemy vehicle station.', %game.SCORE_PER_DESTROY_VSTATION);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_VSTATION;
}

function CombatConGame::awardScoreSolarDestroy(%game,%cl)
{
   %cl.SolarDestroys++;
   if (%game.SCORE_PER_DESTROY_SOLAR != 0)
      {
         messageClient(%cl, 'msgSolarDes', '\c0You received a %1 point bonus for destroying an enemy solar panel.', %game.SCORE_PER_DESTROY_SOLAR);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_SOLAR;
}

function CombatConGame::awardScoreSentryDestroy(%game,%cl)
{
   %cl.sentryDestroys++;
   if (%game.SCORE_PER_DESTROY_SENTRY != 0)
      {
         messageClient(%cl, 'msgSentryDes', '\c0You received a %1 point bonus for destroying an enemy sentry turret.', %game.SCORE_PER_DESTROY_SENTRY);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_SENTRY;
}

function CombatConGame::awardScoreDepSensorDestroy(%game,%cl)
{
   %cl.depSensorDestroys++;
   if (%game.SCORE_PER_DESTROY_DEP_SENSOR != 0)
      {
         messageClient(%cl, 'msgDepSensorDes', '\c0You received a %1 point bonus for destroying an enemy deployable.', %game.SCORE_PER_DESTROY_DEP_SENSOR);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_DEP_SENSOR;
}

function CombatConGame::awardScoreDepTurretDestroy(%game,%cl)
{
   %cl.depTurretDestroys++;
   if (%game.SCORE_PER_DESTROY_DEP_TUR != 0)
      {
         messageClient(%cl, 'msgDepTurDes', '\c0You received a %1 point bonus for destroying an enemy deployed turret.', %game.SCORE_PER_DESTROY_DEP_TUR);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_DEP_TUR;
}

function CombatConGame::awardScoreDepStationDestroy(%game,%cl)
{
   %cl.depStationDestroys++;
   if (%game.SCORE_PER_DESTROY_DEP_INV != 0)
      {
         messageClient(%cl, 'msgDepInvDes', '\c0You received a %1 point bonus for destroying an enemy deployed station.', %game.SCORE_PER_DESTROY_DEP_INV);
         //messageTeamExcept(%cl, 'msgGenDes', '\c0Teammate %1 received a %2 point bonus for destroying an enemy generator.', %cl.name, %game.SCORE_PER_GEN_DESTROY);
      }
      %game.recalcScore(%cl);
    return %game.SCORE_PER_DESTROY_DEP_INV;
}

function CombatConGame::awardScoreGenDefend(%game, %killerID)
{
   %killerID.genDefends++;
   if (%game.SCORE_PER_GEN_DEFEND != 0)
   {
      messageClient(%killerID, 'msgGenDef', '\c0You received a %1 point bonus for defending a generator.', %game.SCORE_PER_GEN_DEFEND);
      //messageTeamExcept(%killerID, 'msgGenDef', '\c0Teammate %1 received a %2 point bonus for defending a generator.', %killerID.name, %game.SCORE_PER_GEN_DEFEND);
   }
   %game.recalcScore(%cl);
    return %game.SCORE_PER_GEN_DEFEND;
}

function CombatConGame::awardScoreCarrierKill(%game, %killerID)
{
   %killerID.carrierKills++;
   if (%game.SCORE_PER_CARRIER_KILL != 0)
   {
      messageClient(%killerID, 'msgCarKill', '\c0You received a %1 point bonus for stopping the enemy flag carrier!', %game.SCORE_PER_CARRIER_KILL);
      //messageTeamExcept(%killerID, 'msgCarKill', '\c0Teammate %1 received a %2 point bonus for stopping the enemy flag carrier!', %killerID.name, %game.SCORE_PER_CARRIER_KILL);
   }
   %game.recalcScore(%killerID);
    return %game.SCORE_PER_CARRIER_KILL;
}

function CombatConGame::awardScoreFlagDefend(%game, %killerID)
{
   %killerID.flagDefends++;
   if (%game.SCORE_PER_FLAG_DEFEND != 0)
   {
      messageClient(%killerID, 'msgFlagDef', '\c0You received a %1 point bonus for defending your flag!', %game.SCORE_PER_FLAG_DEFEND);
      //messageTeamExcept(%killerID, 'msgFlagDef', '\c0Teammate %1 received a %2 point bonus for defending your flag!', %killerID.name, %game.SCORE_PER_FLAG_DEFEND);
   }
   %game.recalcScore(%killerID);
    return %game.SCORE_PER_FLAG_DEFEND;
}

function CombatConGame::awardScoreEscortAssist(%game, %killerID)
{
   %killerID.escortAssists++;
   if (%game.SCORE_PER_ESCORT_ASSIST != 0)
   {
      messageClient(%killerID, 'msgEscAsst', '\c0You received a %1 point bonus for protecting the flag carrier!', %game.SCORE_PER_ESCORT_ASSIST);
      //messageTeamExcept(%killerID, 'msgEscAsst', '\c0Teammate %1 received a %2 point bonus for protecting the flag carrier!', %killerID.name, %game.SCORE_PER_ESCORT_ASSIST);
   }
   %game.recalcScore(%killerID);
    return %game.SCORE_PER_ESCORT_ASSIST;
}

function CombatConGame::resetScore(%game, %client)
{
   %client.offenseScore = 0;
   %client.kills = 0;
   %client.deaths = 0;
   %client.suicides = 0;
   %client.escortAssists = 0;
   %client.teamKills = 0;
   %client.flagCaps = 0;
   %client.flagGrabs = 0;
   %client.genDestroys = 0;
   %client.sensorDestroys = 0;
   %client.turretDestroys = 0;
   %client.iStationDestroys = 0;
   %client.vstationDestroys = 0;
   %client.solarDestroys = 0;
   %client.sentryDestroys = 0;
   %client.depSensorDestroys = 0;
   %client.depTurretDestroys = 0;
   %client.depStationDestroys = 0;
   %client.vehicleScore = 0;
   %client.vehicleBonus = 0;

    %client.flagDefends = 0;
   %client.defenseScore = 0;
   %client.genDefends = 0;
   %client.carrierKills = 0;
   %client.escortAssists = 0;
   %client.turretKills = 0;
   %client.mannedTurretKills = 0;
   %client.flagReturns = 0;
   %client.genRepairs = 0;
    %client.SensorRepairs   =0;
    %client.TurretRepairs   =0;
    %client.StationRepairs  =0;
    %client.VStationRepairs =0;
    %client.solarRepairs    =0;
    %client.sentryRepairs   =0;
    %client.depInvRepairs   =0;
    %client.depTurretRepairs=0;
    %client.returnPts = 0;
   %client.score = 0;
}

function CombatConGame::objectRepaired(%game, %obj, %objName)
{
   %item = %obj.getDataBlock().getName();
   switch$ (%item)
   {
      case generatorLarge :
         %game.genOnRepaired(%obj, %objName);
      case sensorMediumPulse :
         %game.sensorOnRepaired(%obj, %objName);
      case sensorLargePulse :
         %game.sensorOnRepaired(%obj, %objName);
      case stationInventory :
         %game.stationOnRepaired(%obj, %objName);
      case turretBaseLarge :
         %game.turretOnRepaired(%obj, %objName);
      case stationVehicle :
        %game.vStationOnRepaired(%obj, %objName);
      case solarPanel :
        %game.solarPanelOnRepaired(%obj, %objName);
      case sentryTurret :
        %game.sentryTurretOnRepaired(%obj, %objName);
      case TurretDeployedWallIndoor:
        %game.depTurretOnRepaired(%obj, %objName);
      case TurretDeployedFloorIndoor:
        %game.depTurretOnRepaired(%obj, %objName);
      case TurretDeployedCeilingIndoor:
        %game.depTurretOnRepaired(%obj, %objName);
      case TurretDeployedOutdoor:
        %game.depTurretOnRepaired(%obj, %objName);
   }
   %obj.wasDisabled = false;
}

function CombatConGame::genOnRepaired(%game, %obj, %objName)
{

   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgGenRepaired', '\c0%1 repaired the %2 Generator!', %repairman.name, %obj.nameTag);
      %game.awardScoreGenRepair(%obj.repairedBy);
   }
}

function CombatConGame::stationOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgStationRepaired', '\c0%1 repaired the %2 Inventory Station!', %repairman.name, %obj.nameTag);
      %game.awardScoreStationRepair(%obj.repairedBy);
   }
}

function CombatConGame::sensorOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgSensorRepaired', '\c0%1 repaired the %2 Pulse Sensor!', %repairman.name, %obj.nameTag);
      %game.awardScoreSensorRepair(%obj.repairedBy);
   }
}

function CombatConGame::turretOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgTurretRepaired', '\c0%1 repaired the %2 Turret!', %repairman.name, %obj.nameTag);
      %game.awardScoreTurretRepair(%obj.repairedBy);
   }
}

function CombatConGame::vStationOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgvstationRepaired', '\c0%1 repaired the Vehicle Station!', %repairman.name);
      %game.awardScoreVStationRepair(%obj.repairedBy);
   }
}

function CombatConGame::solarPanelOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgsolarRepaired', '\c0%1 repaired the %2 Solar Panel!', %repairman.name, %obj.nameTag);
      %game.awardScoreSolarRepair(%obj.repairedBy);
   }
}

function CombatConGame::sentryTurretOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      teamRepairMessage(%repairman, 'msgsentryTurretRepaired', '\c0%1 repaired the %2 Sentry Turret!', %repairman.name, %obj.nameTag);
      %game.awardScoreSentryRepair(%obj.repairedBy);
   }
}

function CombatConGame::depTurretOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      %game.awardScoreDepTurretRepair(%obj.repairedBy);
   }
}

function CombatConGame::depInvOnRepaired(%game, %obj, %objName)
{
   if (%game.testValidRepair(%obj))
   {
      %repairman = %obj.repairedBy;
      %game.awardScoreDepInvRepair(%obj.repairedBy);
   }
}

function CombatConGame::awardScoreGenRepair(%game, %cl)
{
   %cl.genRepairs++;
   if (%game.SCORE_PER_REPAIR_GEN != 0)
   {
      messageClient(%cl, 'msgGenRep', '\c0You received a %1 point bonus for repairing a generator.', %game.SCORE_PER_REPAIR_GEN);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreStationRepair(%game, %cl)
{
   %cl.stationRepairs++;
   if (%game.SCORE_PER_REPAIR_ISTATION != 0)
   {
      messageClient(%cl, 'msgIStationRep', '\c0You received a %1 point bonus for repairing a inventory station.', %game.SCORE_PER_REPAIR_ISTATION);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreSensorRepair(%game, %cl)
{
   %cl.sensorRepairs++;
   if (%game.SCORE_PER_REPAIR_SENSOR != 0)
   {
      messageClient(%cl, 'msgSensorRep', '\c0You received a %1 point bonus for repairing a sensor.', %game.SCORE_PER_REPAIR_SENSOR);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreTurretRepair(%game, %cl)
{
   %cl.TurretRepairs++;
   if (%game.SCORE_PER_REPAIR_TURRET != 0)
   {
      messageClient(%cl, 'msgTurretRep', '\c0You received a %1 point bonus for repairing a base turret.', %game.SCORE_PER_REPAIR_TURRET);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreVStationRepair(%game, %cl)
{
   %cl.VStationRepairs++;
   if (%game.SCORE_PER_REPAIR_VSTATION != 0)
   {
      messageClient(%cl, 'msgVStationRep', '\c0You received a %1 point bonus for repairing a vehicle station.', %game.SCORE_PER_REPAIR_VSTATION);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreSolarRepair(%game, %cl)
{
   %cl.solarRepairs++;
   if (%game.SCORE_PER_REPAIR_SOLAR != 0)
   {
      messageClient(%cl, 'msgsolarRep', '\c0You received a %1 point bonus for repairing a solar panel.', %game.SCORE_PER_REPAIR_SOLAR);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreSentryRepair(%game, %cl)
{
   %cl.sentryRepairs++;
   if (%game.SCORE_PER_REPAIR_SENTRY != 0)
   {
      messageClient(%cl, 'msgSentryRep', '\c0You received a %1 point bonus for repairing a sentry turret.', %game.SCORE_PER_REPAIR_SENTRY);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreDepTurretRepair(%game, %cl)
{
   %cl.depTurretRepairs++;
   if (%game.SCORE_PER_REPAIR_DEP_TUR != 0)
   {
      messageClient(%cl, 'msgDepTurretRep', '\c0You received a %1 point bonus for repairing a deployed turret.', %game.SCORE_PER_REPAIR_DEP_TUR);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::awardScoreDepInvRepair(%game, %cl)
{
   %cl.depInvRepairs++;
   if (%game.SCORE_PER_REPAIR_DEP_INV != 0)
   {
      messageClient(%cl, 'msgDepInvRep', '\c0You received a %1 point bonus for repairing a deployed station.', %game.SCORE_PER_REPAIR_DEP_INV);
   }
   %game.recalcScore(%cl);
}

function CombatConGame::enterMissionArea(%game, %playerData, %player)
{
   %player.client.outOfBounds = false;
   messageClient(%player.client, 'EnterMissionArea', '\c1You are back in the mission area. ~wvoice/Announcer/ANN.ib.wav');
   cancel(%player.alertThread);
}

function CombatConGame::leaveMissionArea(%game, %playerData, %player)
{
   if(%player.getState() $= "Dead")
      return;

   %player.client.outOfBounds = true;
   messageClient(%player.client, 'LeaveMissionArea', '\c1You have left the mission area. Return or be killed. ~wvoice/Announcer/ANN.oob.wav');
   %player.alertThread = %game.schedule(10, "DMAlertPlayer", 3, %player);
}

function CombatConGame::DMAlertPlayer(%game, %count, %player)
{
   if(%count > 1)
      %player.alertThread = %game.schedule(1000, "DMAlertPlayer", %count - 1, %player);
   else
      %player.alertThread = %game.schedule(5000, "MissionAreaDamage", %player);
}

function CombatConGame::MissionAreaDamage(%game, %player)
{
   if(%player.getState() !$= "Dead") {
      %player.setDamageFlash(1.5);
      %prevHurt = %player.getDamageLevel();
      %player.scriptkill($DamageType::OutOfBounds);
      %player.alertThread = %game.schedule(1000, "MissionAreaDamage", %player);
   }
}

function CombatConGame::vehicleDestroyed(%game, %vehicle, %destroyer){
    %data = %vehicle.getDataBlock();
    %vehicleType = getTaggedString(%data.targetTypeTag);
    if(%vehicleType !$= "MPB")
        %vehicleType = strlwr(%vehicleType);

    %enemyTeam = ( %destroyer.team == 1 ) ? 2 : 1;

    %scorer = 0;
    %multiplier = 3;
    %shouldshare = 0;

    %passengers = 0;
    for(%i = 0; %i < %data.numMountPoints; %i++)
        if(%vehicle.getMountNodeObject(%i))
            %passengers++;

    if(%destroyer.client){
        %destroyer = %destroyer.client;
        %scorer = %destroyer;

        if(%vehicle.lastDamageType == $DamageType::Mine)
            %multiplier = 1;
    }
    else if(%destroyer.getClassName() $= "Turret"){
        if(%destroyer.getControllingClient()){
            %destroyer = %destroyer.getControllingClient();
            %scorer = %destroyer;
		if(%destroyer.vehicleMounted){
		   if(%destroyer.vehicleMounted.getMountNodeObject(0)){
			%driver = %destroyer.vehicleMounted.getMountNodeObject(0);
			%sharer = %driver.client;
			%shouldshare = 1;
		   }
		   %multiplier = 2;
		}
        }
        else{
            %destroyerName = "A turret";
            %multiplier = 0;
        }
    }
    else if(%destroyer.getDataBlock().catagory $= "Vehicles"){
        if(%destroyer.getMountNodeObject(0)){
            %destroyer = %destroyer.getMountNodeObject(0).client;
            %scorer = %destroyer;
        }
        %multiplier = 2;
    }
    else
        return;


    if(%destroyerName $= "")
        %destroyerName = %destroyer.name;

    if(%vehicle.team == %destroyer.team){
        %pref = (%vehicleType $= "Assault Tank") ? "an" : "a";
        messageAll( 'msgVehicleTeamDestroy', '\c0%1 TEAMKILLED %3 %2!', %destroyerName, %vehicleType, %pref);
    }
    else{
        messageTeamExcept(%destroyer, 'msgVehicleDestroy', '\c0%1 destroyed an enemy %2.', %destroyerName, %vehicleType);
        messageTeam(%enemyTeam, 'msgVehicleDestroy', '\c0%1 destroyed your team\'s %2.', %destroyerName, %vehicleType);

        if(%scorer){
            %value = %game.awardScoreVehicleDestroyed(%scorer, %vehicleType, %multiplier, %passengers);
		if(%shouldshare == 1)
		   %game.awardScoreVehicleDestroyed(%sharer, %vehicleType, (%multiplier / 2), %passengers);
            %game.shareScore(%value);
        }
    }
}

function CombatConGame::awardScoreVehicleDestroyed(%game, %client, %vehicleType, %mult, %passengers)
{
    if(isDemo())
        return 0;

    if(%vehicleType $= "Interceptor")
        %base = %game.SCORE_PER_DESTROY_SHRIKE;

    else if(%vehicleType $= "Fighter")
        %base = %game.SCORE_PER_DESTROY_STRIKEFIGHTER;

    else if(%vehicleType $= "Assault Chopper")
        %base = %game.SCORE_PER_DESTROY_HELICOPTER;

    else if(%vehicleType $= "AWACS")
        %base = %game.SCORE_PER_DESTROY_AWACS;

    else if(%vehicleType $= "Bomber")
        %base = %game.SCORE_PER_DESTROY_BOMBER;

    else if(%vehicleType $= "Gunship")
        %base = %game.SCORE_PER_DESTROY_GUNSHIP;

    else if(%vehicleType $= "Transport Chopper")
        %base = %game.SCORE_PER_DESTROY_HEAVYHELICOPTER;

    else if(%vehicleType $= "Heavy Transport")
        %base = %game.SCORE_PER_DESTROY_TRANSPORT;

    else if(%vehicleType $= "Grav Cycle")
        %base = %game.SCORE_PER_DESTROY_WILDCAT;

    else if(%vehicleType $= "Light Tank")
        %base = %game.SCORE_PER_DESTROY_TANK;

    else if(%vehicleType $= "Assault Tank")
        %base = %game.SCORE_PER_DESTROY_HEAVYTANK;

    else if(%vehicleType $= "chaingun tank")
        %base = %game.SCORE_PER_DESTROY_CGTANK;

    else if(%vehicleType $= "APC")
        %base = %game.SCORE_PER_DESTROY_FFTRANSPORT;

    else if(%vehicleType $= "Heavy Artillery")
        %base = %game.SCORE_PER_DESTROY_ARTILLERY;

    else if(%vehicleType $= "MPB")
        %base = %game.SCORE_PER_DESTROY_MPB;

    else if(%vehicleType $= "Boat")
        %base = %game.SCORE_PER_DESTROY_TRANSBOAT;

    else if(%vehicleType $= "Submarine")
        %base = %game.SCORE_PER_DESTROY_SUB;

    else if(%vehicleType $= "GunBoat")
        %base = %game.SCORE_PER_DESTROY_BOAT;


    %total = ( %base * %mult ) + ( %passengers * %game.SCORE_PER_PASSENGER );

    %client.vehicleScore += %total;

     messageClient(%client, 'msgVehicleScore', '\c0You received a %1 point bonus for destroying an enemy %2.', %total, %vehicleType);
   %game.recalcScore(%client);
    return %total;
}

function CombatConGame::shareScore(%game, %client, %amount)
{
    if(isDemo())
        return 0;

    //error("share score of"SPC %amount SPC "from client:" SPC %client);
    // all of the player in the bomber and tank share the points
    // gained from any of the others
    %vehicle = %client.vehicleMounted;
    if(!%vehicle)
        return 0;
    %vehicleType = getTaggedString(%vehicle.getDataBlock().targetTypeTag);
    if(%vehicleType $= "Bomber" || %vehicleType $= "Assault Tank")
    {
        for(%i = 0; %i < %vehicle.getDataBlock().numMountPoints; %i++)
        {
            %occupant = %vehicle.getMountNodeObject(%i);
            if(%occupant)
            {
                %occCl = %occupant.client;
                if(%occCl != %client && %occCl.team == %client.team)
                {
                    // the vehicle has a valid teammate at this node
                    // share the score with them
                    %occCl.vehicleBonus += %amount;
                    %game.recalcScore(%occCl);
                }
            }
        }

    }
}

function CombatConGame::awardScoreTurretKill(%game, %victimID, %implement)
{
    if ((%killer = %implement.getControllingClient()) != 0) //award whoever might be controlling the turret
    {
        if (%killer == %victimID)
            %game.awardScoreSuicide(%victimID);
        else if (%killer.team == %victimID.team) //player controlling a turret killed a teammate
        {
            %killer.teamKills++;
            %game.awardScoreTurretTeamKill(%victimID, %killer);
            %game.awardScoreDeath(%victimID);
        }
        else
        {
            %killer.mannedturretKills++;
            %game.recalcScore(%killer);
            %game.awardScoreDeath(%victimID);
        }
    }
    else if ((%killer = %implement.owner) != 0) //if it isn't controlled, award score to whoever deployed it
    {
        if (%killer.team == %victimID.team)
        {
            %game.awardScoreDeath(%victimID);
        }
        else
        {
            %killer.turretKills++;
            %game.recalcScore(%killer);
            %game.awardScoreDeath(%victimID);
        }
    }
    //default is, no one was controlling it, no one owned it.  No score given.
}

function CombatConGame::testKill(%game, %victimID, %killerID)
{
   return ((%killerID !=0) && (%victimID.team != %killerID.team));
}

function CombatConGame::awardScoreKill(%game, %killerID)
{
   %killerID.kills++;
   %game.recalcScore(%killerID);
    return %game.SCORE_PER_KILL;
}
};
