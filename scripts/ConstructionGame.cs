// DisplayName = Construction

//--- GAME RULES BEGIN ---
// Freebuild - Build whatever you want.
// Type: /Help to access a list of useful commands.
// Scoring System Disabled.
//--- GAME RULES END ---

// Now to get rid of most of the CCM Weapons.
$InvBanList[Construction, "RailGun"] = 1;
$InvBanList[Construction, "Bazooka"] = 1;
$InvBanList[Construction, "snipergun"] = 1;
$InvBanList[Construction, "flamer"] = 1;
$InvBanList[Construction, "Shotgun"] = 1;
$InvBanList[Construction, "RShotgun"] = 1;
$InvBanList[Construction, "HRPChaingun"] = 1;
$InvBanList[Construction, "RPChaingun"] = 1;
$InvBanList[Construction, "BoosterPack"] = 1;
$InvBanList[Construction, "NapalmMortar"] = 1;
$InvBanList[Construction, "M4"] = 1;
$InvBanList[Construction, "flamerammopack"] = 1;
$InvBanList[Construction, "ELFBarrelPack"] = 1;
$InvBanList[Construction, "artillerybarrelpack"] = 1;
$InvBanList[Construction, "artilleryWeaponPack"] = 1;
$InvBanList[Construction, "InventoryDeployable"] = 1;
$InvBanList[Construction, "SpySatelliteDeployable"] = 1;

function ConstructionGame::AIInit(%game) {
	//call the default AIInit() function
	AIInit();
}

function ConstructionGame::allowsProtectedStatics(%game) {
	return true;
}

function ConstructionGame::clientMissionDropReady(%game, %client) {
	messageClient(%client, 'MsgClientReady',"", %game.class);
	messageClient(%client, 'MsgMissionDropInfo', '\c0You are in mission %1 (%2).', $MissionDisplayName, $MissionTypeDisplayName, $ServerName );
	DefaultGame::clientMissionDropReady(%game, %client);
}

function ConstructionGame::onAIRespawn(%game, %client)
{
   //add the default task
	if (! %client.defaultTasksAdded)
	{
		%client.defaultTasksAdded = true;
	   %client.addTask(AIPickupItemTask);
	   %client.addTask(AIUseInventoryTask);
	   %client.addTask(AITauntCorpseTask);
		%client.addTask(AIEngageTurretTask);
		%client.addTask(AIDetectMineTask);
		%client.addTask(AIBountyPatrolTask);
		%client.bountyTask = %client.addTask(AIBountyEngageTask);
	}

   //set the inv flag
   %client.spawnUseInv = true;
}

function ConstructionGame::updateKillScores(%game, %clVictim, %clKiller, %damageType, %implement) {
	if (%game.testKill(%clVictim, %clKiller)) { //verify victim was an enemy
		%game.awardScoreKill(%clKiller);
		%game.awardScoreDeath(%clVictim);
	}
	else if (%game.testSuicide(%clVictim, %clKiller, %damageType))  //otherwise test for suicide
		%game.awardScoreSuicide(%clVictim);
}

function ConstructionGame::timeLimitReached(%game) {
	logEcho("game over (timelimit)");
	%game.gameOver();
	cycleMissions();
}

function ConstructionGame::scoreLimitReached(%game) {
	logEcho("game over (scorelimit)");
	%game.gameOver();
	cycleMissions();
}

function ConstructionGame::gameOver(%game) {
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
	for(%i = 0; %i < ClientGroup.getCount(); %i ++) {
		%client = ClientGroup.getObject(%i);
		%game.resetScore(%client);
	}
	for(%j = 1; %j <= %game.numTeams; %j++)
		$TeamScore[%j] = 0;
}

function ConstructionGame::vehicleDestroyed(%game, %vehicle, %destroyer) {
}

