$sent::patrolwaittime = 10; // 10 secs
$sent::patrolsaturation = 2; // 2 sentinel patrolling one point at a time

// 1 = Normal Sentinel
// 2 = Sentinel Monitor

//==============================================================================
// CreateSentinel
//------------------------------------------------------------------------------
// %pos = position
// %team = team
// %quantity = how many sentinels to spawn
// %type = the type of sentinel to spawn [regular/monitor]
//------------------------------------------------------------------------------
// It creates a sentinel.
//==============================================================================
function CreateSentinel(%pos, %quantity, %type)
{
	if(%quantity < 1)
		return;

	while(%quantity)
	{
		%data = (%type == 2 ? "SentinelMonitor" : "SentinelVehicle");
		%sent = new FlyingVehicle() {
			datablock = %data;
		};

		%sent.setTransform(%pos SPC "0 0 1 0");
		%sent.team = 1;

		MissionCleanup.add(%sent);

		setTargetSensorGroup(%sent.getTarget(), 1);

		$ignoreNextBotConnection = true;
		%ai = aiConnect("_AISent");
		ChangeName(%ai, "Sentinel"@%ai);

		%ai.isSentinel = true;
		%ai.sentVehicle = %sent;
		%ai.sentinelType = %type;

		%ai.setControlObject(%sent);

//		SentinelAI_PatrolArea(%ai);
		warn("Sentinel created: "@%ai@", VEHID"@%sent);
		%quantity--;
	}
}

function DropSentinel(%id)
{
	if(!isObject(%id) || %id.isSentinel != true)
		return;

	if(isObject(%id.sentVehicle) && %id.sentVehicle.getDamageState() !$= "Destroyed")
		%id.sentVehicle.setDamageState(Destroyed);

	%id.drop();
}

function AIConnection::Sentinel_MoveTo(%client, %coords)
{
	%client.clearStep();

	%client.setPilotAim(%coords);
	%client.setPilotDestination(%coords);
}

function AIConnection::Sentinel_Damaged