//==============================================================================
// ACCM Message Database - By Blnukem.
//------------------------------------------------------------------------------
// This is  the message database for Sentinels and other miscellaneous functions
// The following will be addressed in each message cluster on what can or cannot
// be used in those messages.
//
// This was made for the pleasure of ACCM users to customize Sentinel responses
// and a few other messages.
//------------------------------------------------------------------------------
// %1 = Sentinel's Name.
// %2 = Sender's Name.
// %3 = Sender/Target's Gender. (He/She)
// %4 = Sender/Target's Present Tense Gender. (Him/Her)
// %5 = Sender/Target's Possesive Gender. (His/Her)
// %6 = Target's Name. (Only if there is a target defined)
//==============================================================================
// No Target Client for this cluster exists:

$SentinelDenyFollowCount = 5;
$SentinelDenyFollow[0] = '\c2%1 ::\c0 %2, I am already occupied with a task, I cannot follow you.';
$SentinelDenyFollow[1] = '\c2%1 ::\c0 I\'m already engaged in a task, %2.';
$SentinelDenyFollow[2] = '\c2%1 ::\c0 I am occupied at the moment, %2. Sorry, but I cannot follow you.';
$SentinelDenyFollow[3] = '\c2%1 ::\c0 %2, I\'m busy doing something. I cannot follow you.';
$SentinelDenyFollow[4] = '\c2%1 ::\c0 I\'m already doing something, %2.';

//------------------------------------------------------------------------------
// Sender and Target Clients for this cluster exist:

$SentinelDenyAttackCount = 5;
$SentinelDenyAttack[0] = '\c2%1 ::\c0 I\'m already doing something, %2';
$SentinelDenyAttack[1] = '\c2%1 ::\c0 %2, I\'m busy doing something. I cannot engage %6.';
$SentinelDenyAttack[2] = '\c2%1 ::\c0 I am occupied at the moment, %2. Sorry, but I cannot do what you ask.';
$SentinelDenyAttack[3] = '\c2%1 ::\c0 %2, I am already occupied with a task, I cannot attack %6.';
$SentinelDenyAttack[4] = '\c2%1 ::\c0 I\'m already engaged in a task, %2.';

//------------------------------------------------------------------------------
// Sender and Target Clients for this cluster exist:

$SentinelAcceptAttackCount = 4;
$SentinelAcceptAttack[0] = '\c2%1 ::\c0 I\'m now engaging %6.';
$SentinelAcceptAttack[1] = '\c2%1 ::\c0 Command confirmed, I will now hunt down %6.';
$SentinelAcceptAttack[2] = '\c2%1 ::\c0 Attack protocol engaged, I will now hunt down %6.';
$SentinelAcceptAttack[3] = '\c2%1 ::\c0 Command confirmed %2, I will now attack %6.';

//------------------------------------------------------------------------------
// Sender and Target Clients for this cluster exist:

$SentinelAttackAlreadyDeadTargetCount = 1;
$SentinelAttackAlreadyDeadTarget[0] = '\c2%1 ::\c0 %6 is already dead.';

//------------------------------------------------------------------------------
// Sender and Target Clients for this cluster exist:

$SentinelTargetTooFarCount = 1;
$SentinelTargetTooFar[0] = '\c2%1 ::\c0 Command declined. %6 is out of range.';

//------------------------------------------------------------------------------
// No Target Client for this cluster exists:

$SentinelAttackSenderCount = 1;
$SentinelAttackSender[0] = '\c2%1 ::\c0 Command declined %2, I cannot kill the person giving me an order.';

//------------------------------------------------------------------------------
// No Target Client for this cluster exists:

$SentinelAttackSenderNotAdminCount = 1;
$SentinelAttackSenderNotAdmin[0] = '\c2%1 ::\c0 %2, you must be an admin to set an attack order.';

//------------------------------------------------------------------------------
// No Sender Client for this cluster exists:

$SentinelAnnoyedCount = 3;
$SentinelAnnoyed[0] = '\c2%1 ::\c0 %2, now you will learn not to fly around sentinels.';
$SentinelAnnoyed[1] = '\c2%1 ::\c0 Target Designated. %2, you were warned not to fly around Sentinels.';
$SentinelAnnoyed[2] = '\c2%1 ::\c0 %2, you need to learn to not fly around Sentinels.';

//------------------------------------------------------------------------------
// No Sender Client for this cluster exists:

$SentinelWarnCount = 4;
$SentinelWarn[0] = '\c2%1 ::\c0 Please stop flying around me, %2.';
$SentinelWarn[1] = '\c2%1 ::\c0 Quit flying around me %2.';
$SentinelWarn[2] = '\c2%1 ::\c0 Do not fly around me, %2.';
$SentinelWarn[3] = '\c2%1 ::\c0 %2, if you do not stop flying around me, you will be killed.';

//------------------------------------------------------------------------------

$ACCMTipCount = 10;
$ACCMTip[0] = "Random Tip:<font:Broadway Bt:14>\nRemember, type /help for a list of useful commands.";
$ACCMTip[1] = "Sentinel Network:<font:Broadway Bt:14>\nSentinels are your allies and will not attack you, unless you provoke them to do so.";
$ACCMTip[2] = "Central Command Intel Report:<font:Broadway Bt:14>\nYou can launch drop pods from Golem heavy transports by pressing your mine key while you're piloting.";
$ACCMTip[3] = "Random Tip:<font:Broadway Bt:14>\nThe easiest way to kill a Zombie or anyone for that matter, is to aim for the head.";
$ACCMTip[4] = "Central Command Intel Report:<font:Broadway Bt:14>\nThe medic pack has an antidote option for infected players, useable by pressing the right mouse button.";
$ACCMTip[5] = "Central Command Intel Report:<font:Broadway Bt:14>\nThe Flame turret barrel is the most effective turret barrel to kill Zombies, followed by the Chaingun turret barrel. The least effective is the Flak barrel.";
$ACCMTip[6] = "Sentinel Network:<font:Broadway Bt:14>\nSentinels are intended for Zombie containment and control, and will not attack humans unless provoked to do so.";
$ACCMTip[7] = "Central Command Intel Report:<font:Broadway Bt:14>\nThe Purge Field Generator is made to defend an area against Zombies, it's particle field will electrocute any Zombies within the field, but requires heavy maintenece.";
$ACCMTip[8] = "Random Tip:<font:Broadway Bt:14>\nUse /CheckStats to check out your current rank and how many points you need for your next rank.";
$ACCMTip[9] = "Random Tip:<font:Broadway Bt:14>\nThe Vehicle Repair Pad, Deployable Sentry Turret and the Purge Field Generator require power to operate, be sure to give them a power source when using them!";
