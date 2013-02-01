$Host::teamskin[0] = "base";
$Host::teamskin[1] = "basebbot";
$Host::teamskin[2] = "basebot";
$Host::teamskin[3] = "beagle";
$Host::teamskin[4] = "dsword";
$Host::teamskin[5] = "cotp";
$Host::teamskin[6] = "swolf";

$Host::teamname[0] = "Outcasts";
$Host::teamname[1] = "Constructors";
$Host::teamname[2] = "Builders";
$Host::teamname[3] = "Admins";
$Host::teamname[4] = "Rebels";
$Host::teamname[5] = "Rouges";
$Host::teamname[6] = "Zombies";

$Host::holoName[0] = "";
$Host::holoName[1] = "Storm";
$Host::holoName[2] = "Inferno";
$Host::holoName[3] = "Starwolf";
$Host::holoName[4] = "DSword";
$Host::holoName[5] = "BloodEagle";
$Host::holoName[6] = "Harbinger";

// Demo-specific preferences:
if ( isDemo() )
{
   $Host::GameName = "Tribes 2 Demo Server";
   $Host::Info = "This is a Tribes 2 Demo Server.";
   $Host::Map = "SlapDash";
   $Host::MaxPlayers = 32;
}
else
{
   $Host::GameName = "ACCM Server";
   $Host::Info = "<Color:ffffff>This is an ACCM server.";
   $Host::Map = "Lost World";
   $Host::MaxPlayers = 20;
}
                  
$Host::AdminList = "";
$Host::SuperAdminList = "";
$Host::BindAddress = "";
$Host::Port = 28000;
$Host::Password = "";
$Host::AdminPassword = "";
$Host::PureServer = 1;
$Host::Dedicated = 0;
$Host::MissionType = "Infection";
$Host::TimeLimit = 30;
$Host::BotCount = 2;
$Host::BotsEnabled = 0;
$Host::MinBotDifficulty = 0.5;
$Host::MaxBotDifficulty = 0.75;
$Host::NoSmurfs = 0;
$Host::VoteTime = 30;               // amount of time before votes are calculated
$Host::VotePassPercent = 60;        // percent needed to pass a vote
$Host::KickBanTime = 60;           // specified in seconds
$Host::BanTime = 1800;              // specified in seconds
$Host::PlayerRespawnTimeout = 60;   // time before a dead player is forced into observer mode
$Host::warmupTime = 20;
$Host::TournamentMode = 0;
$Host::allowAdminPlayerVotes = 0;
$Host::FloodProtectionEnabled = 0;
$Host::MaxMessageLen = 120;
$Host::VoteSpread = 20;
$Host::TeamDamageOn = 0;
$Host::Siege::Halftime = 20000;
$Host::CRCTextures = 0;

// Construction-specific defaults.
$Host::ACCMChatLogging = 1;
$Host::ACCMEchoChat = 1;
$Host::AdminOnlyFadeObject = 0;
$Host::AllowKeeperPlayerVotes = 1;
$Host::AntidoteStationMaxAntidotes = 20;
$Host::Cascade = 0;
$Host::ExpertMode = 1;
$Host::Hazard::Enabled = 0;
$Host::InvincibleArmors = 0;
$Host::InvincibleDeployables = 1;
$Host::KeepersGetMakerAbility = 1;
$Host::LockedTeams = "0";
$Host::NoAnnoyingVoiceChatSpam = 0;
$Host::NoInfection = 0;
$Host::NoPulseSCG = 0;
$Host::ObserversCannotChat = 1;
$Host::OnlyOwnerCascade = 1;
$Host::OnlyOwnerCubicReplace = 1;
$Host::OnlyOwnerDeconstruct = 1;
$Host::OnlyOwnerRotate = 1;
$Host::Prison::DeploySpam = 0;
$Host::Prison::DeploySpamCheckTimeMS = 1000;
$Host::Prison::DeploySpamMaxTime = 300;
$Host::Prison::DeploySpamMultiply = 1;
$Host::Prison::DeploySpamRemoveRecentMS = 15000;
$Host::Prison::DeploySpamResetWarnCountTime = 30;
$Host::Prison::DeploySpamTime = 60;
$Host::Prison::DeploySpamWarnings = 10;
$Host::Prison::Enabled = 0;
$Host::Prison::JailMode = 0;
$Host::Prison::Kill = 0;
$Host::Prison::KillTime = 120;
$Host::Prison::ReleaseMode = 1;
$Host::Prison::TeamKill = 0;
$Host::Purebuild = 0;
$Host::SADProtection = 1;
$Host::StationHoldTime = 1600; // Specified in seconds.
$Host::SuperAdminPassword = "";
$Host::Vehicles = 1;

// 0: .v12 (1.2 kbits/sec), 1: .v24 (2.4 kbits/sec), 2: .v29 (2.9kbits/sec)
// 3:  GSM (6.6 kbits/sec)
$Audio::maxEncodingLevel = 3;
$Audio::maxVoiceChannels = 2;

$Host::MapPlayerLimits["Abominable", "CnH"] = "-1 -1";
$Host::MapPlayerLimits["AgentsOfFortune", "TeamHunters"] = "-1 32";
$Host::MapPlayerLimits["Alcatraz", "Siege"] = "-1 48";
$Host::MapPlayerLimits["Archipelago", "CTF"] = "16 -1";
$Host::MapPlayerLimits["AshesToAshes", "CnH"] = "16 -1";
$Host::MapPlayerLimits["BeggarsRun", "CTF"] = "-1 32";
$Host::MapPlayerLimits["Caldera", "Siege"] = "-1 48";
$Host::MapPlayerLimits["CasernCavite", "Hunters"] = "-1 32";
$Host::MapPlayerLimits["CasernCavite", "DM"] = "-1 32";
$Host::MapPlayerLimits["CasernCavite", "Bounty"] = "-1 32";
$Host::MapPlayerLimits["Damnation", "CTF"] = "-1 32";
$Host::MapPlayerLimits["DeathBirdsFly", "CTF"] = "8 -1";
$Host::MapPlayerLimits["Desiccator", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["DustToDust", "CTF"] = "-1 32";
$Host::MapPlayerLimits["DustToDust", "Hunters"] = "-1 32";
$Host::MapPlayerLimits["DustToDust", "TeamHunters"] = "-1 32";
$Host::MapPlayerLimits["Equinox", "CnH"] = "-1 -1";
$Host::MapPlayerLimits["Equinox", "DM"] = "-1 32";
$Host::MapPlayerLimits["Escalade", "Hunters"] = "8 -1";
$Host::MapPlayerLimits["Escalade", "TeamHunters"] = "8 -1";
$Host::MapPlayerLimits["Escalade", "DM"] = "16 -1";
$Host::MapPlayerLimits["Escalade", "Bounty"] = "16 32";
$Host::MapPlayerLimits["Escalade", "Rabbit"] = "16 -1";
$Host::MapPlayerLimits["Firestorm", "CTF"] = "-1 24";
$Host::MapPlayerLimits["Firestorm", "CnH"] = "-1 24";
$Host::MapPlayerLimits["Flashpoint", "CnH"] = "-1 -1";
$Host::MapPlayerLimits["Gauntlet", "Siege"] = "-1 32";
$Host::MapPlayerLimits["Gehenna", "Hunters"] = "-1 -1";
$Host::MapPlayerLimits["Gehenna", "TeamHunters"] = "-1 -1";
$Host::MapPlayerLimits["Icebound", "Siege"] = "-1 -1";
$Host::MapPlayerLimits["Insalubria", "CnH"] = "-1 32";
$Host::MapPlayerLimits["JacobsLadder", "CnH"] = "-1 -1";
$Host::MapPlayerLimits["Katabatic", "CTF"] = "-1 48";
$Host::MapPlayerLimits["Masada", "Siege"] = "-1 32";
$Host::MapPlayerLimits["Minotaur", "CTF"] = "-1 32";
$Host::MapPlayerLimits["Myrkwood", "Hunters"] = "-1 32";
$Host::MapPlayerLimits["Myrkwood", "DM"] = "-1 32";
$Host::MapPlayerLimits["Myrkwood", "Rabbit"] = "-1 32";
$Host::MapPlayerLimits["Oasis", "DM"] = "-1 32";
$Host::MapPlayerLimits["Overreach", "CnH"] = "8 -1";
$Host::MapPlayerLimits["Quagmire", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["Rasp", "TeamHunters"] = "-1 32";
$Host::MapPlayerLimits["Rasp", "Bounty"] = "-1 32";
$Host::MapPlayerLimits["Recalescence", "CTF"] = "16 -1";
$Host::MapPlayerLimits["Respite", "Siege"] = "-1 32";
$Host::MapPlayerLimits["Reversion", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["Rimehold", "Hunters"] = "8 -1";
$Host::MapPlayerLimits["Rimehold", "Hunters"] = "8 -1";
$Host::MapPlayerLimits["Riverdance", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["Sanctuary", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["Sirocco", "CnH"] = "8 -1";
$Host::MapPlayerLimits["Slapdash", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["SunDried", "DM"] = "8 -1";
$Host::MapPlayerLimits["SunDried", "Bounty"] = "8 -1";
$Host::MapPlayerLimits["Talus", "Bounty"] = "-1 32";
$Host::MapPlayerLimits["ThinIce", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["Tombstone", "CTF"] = "-1 -1";
$Host::MapPlayerLimits["UltimaThule", "Siege"] = "8 -1";
$Host::MapPlayerLimits["Underhill", "DM"] = "-1 -1";
$Host::MapPlayerLimits["Underhill", "Bounty"] = "-1 32";
$Host::MapPlayerLimits["Whiteout", "DM"] = "8 -1";
$Host::MapPlayerLimits["Whiteout", "Bounty"] = "8 -1";
