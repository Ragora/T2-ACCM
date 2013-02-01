
// Tribes 2 Arena [Rev2] 1.0 Final
// Written By Teribaen (teribaen@planettribes.com)
// http://www.planettribes.com/t2arena/

$Arena::AI::Version = 1.0;


// ========================================================================== //
// |                                                                        | //
// |  AI TASKS                                                              | //
// |                                                                        | //
// ========================================================================== //

// ------------------------------------------------------------------ //
// ArenaGame::onAIRespawn()
// Gives the bots their objectives

function ArenaGame::onAIRespawn( %game, %client )
{
  // Setup AI tasks
  if ( !%client.defaultTasksAdded )
  {
    %client.defaultTasksAdded = true;
    %client.addTask(AIEngageTask);
    %client.addTask(AIPickupItemTask);
//  %client.addTask(AITauntCorpseTask);    // Heh, this makes the bots sitting ducks while they taunt
    %client.addTask(AIUseInventoryTask);
//  %client.addtask(AIEngageTurretTask);
    %client.addtask(AIDetectMineTask);
    %client.addTask(AIPatrolTask);
  }

  // Use an inv whenever we spawn?
  %client.spawnUseInv = true;

  // Mark the bot as alive (they just spawned)
  arenaSetClientAlive( %client );
}


// ========================================================================== //
// |                                                                        | //
// |  AI CALLBACK HANDLERS                                                  | //
// |                                                                        | //
// ========================================================================== //

function ArenaGame::AIInit( %game )
{
  // Call the default AIInit() function
  AIInit();
}

function ArenaGame::onAIDamaged(%game, %clVictim, %clAttacker, %damageType, %implement )
{
  if ( %clAttacker && %clAttacker != %clVictim && %clAttacker.team == %clVictim.team )
  {
    // Clear the "lastDamageClient" tag so we don't turn on teammates
    %clVictim.lastDamageClient = -1;
  }
}

function ArenaGame::onAIKilledClient(%game, %clVictim, %clAttacker, %damageType, %implement)
{
  if ( %clVictim.team != %clAttacker.team )
    DefaultGame::onAIKilledClient( %game, %clVictim, %clAttacker, %damageType, %implement );
}

function ArenaGame::onAIFriendlyFire(%game, %clVictim, %clAttacker, %damageType, %implement)
{
//  if ( %clAttacker && %clAttacker.team == %clVictim.team && %clAttacker != %clVictim )
//    AIMessageThread("ChatSorry", %clAttacker, %clVictim);
}


