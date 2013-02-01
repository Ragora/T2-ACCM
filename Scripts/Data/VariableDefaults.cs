/////////////////////////////////////////////////////////
// VARIABLE DEFAULTS . CS
/////////////////////////////////////////////////////////
// This file overrides any important variables with blank values.
// Just for people who like to drop mods in then play them
// immediately after without setting up any preferences.
// ONLY PUT VARIABLES THAT ARE INTRODUCED BY ACCM IN HERE!

/////////////////////////////////////////////////////////
// CLIENT SAVING VARIABLES
/////////////////////////////////////////////////////////
if($Host::ClientSaving $= "")
   $Host::ClientSaving = 1;

if($Host::MaxClientSaves $= "")
   $Host::MaxClientSaves = 10;

if($Host::MaxPieceVote $= "")
   $Host::MaxPieceVote = 400;
/////////////////////////////////////////////////////////
// DEPLOYABLE VARIABLES
/////////////////////////////////////////////////////////
if($Host::AntidoteStationMaxAntidotes $= "")
   $Host::AntidoteStationMaxAntidotes = 20;
/////////////////////////////////////////////////////////
// ZOMBIE VARIABLES
/////////////////////////////////////////////////////////
if($Host::MaxZombies $= "")
   $Host::MaxZombies = 35;
/////////////////////////////////////////////////////////
// CHAT VARIABLES
/////////////////////////////////////////////////////////
if($Host::ACCMChatLogging $= "")
   $Host::ACCMChatLogging = 1;

if($Host::ACCMConnectionLogging $= "")
   $Host::ACCMConnectionLogging = 1;

if($Host::ACCMEchoChat $= "")
   $Host::ACCMEchoChat = 1;

if($Host::AllowKeeperPlayerVotes $= "")
   $Host::AllowKeeperPlayerVotes = 1;

if($Host::KeepersGetMakerAbility $= "")
   $Host::KeepersGetMakerAbility = 1;

if($Host::ObserversCannotChat $= "")
   $Host::ObserversCannotChat = 1;
/////////////////////////////////////////////////////////
// MISC VARIABLES
/////////////////////////////////////////////////////////
if($Host::LockedTeams $= "")
   $Host::LockedTeams = 0;

if($Host::NoInfection $= "")
   $Host::NoInfection = 0;

if($Host::SADProtection $= "")
   $Host::SADProtection = 1;
/////////////////////////////////////////////////////////