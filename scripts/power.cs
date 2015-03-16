$PowerThread = 0;
$AmbientThread = 1;
$ActivateThread = 2;
$DeployThread = 3;

$HumSound = 0;
$ActivateSound = 1;
$DeploySound = 2;
$PlaySound = 3;

//******************************************************************************
//*   Power  -Audio- Data Blocks                                               *
//******************************************************************************

datablock AudioProfile(BasePowerOn)
{
   filename    = "fx/powered/base_power_on.wav";
   description = Audio2D;
   preload = true;
};

datablock AudioProfile(BasePowerOff)
{
   filename    = "fx/powered/base_power_off.wav";
   description = Audio2D;
   preload = true;
};

datablock AudioProfile(BasePowerHum)
{
   filename    = "fx/powered/base_power_loop.wav";
   description = AudioLooping2D;
   preload = true;
};

//******************************************************************************
//*   Power  -  Functions                                                      *
//******************************************************************************

function GameBase::clearPower(%this)
{
}

function SimGroup::clearPower(%this)
{
	%this.powerCount = 0;
   for (%i = 0; %i < %this.getCount(); %i++)
   {
      %obj = %this.getObject(%i);
      if(%obj.getType() & $TypeMasks::GameBaseObjectType)
         %obj.clearPower();
   }
}

function SimObject::powerInit(%this, %powerCount)
{
	//function declared to reduce console error msg spam
}

function SimGroup::powerInit(%this, %powerCount)
{
   if(%this.providesPower)
      %powerCount++;

   %count = %this.getCount();
   for (%i = 0; %i < %count; %i++)
   {
      %obj = %this.getObject(%i);
      if(%obj.getType() & $TypeMasks::GameBaseObjectType)
      {
         if(%obj.getDatablock().isPowering(%obj))
            %powerCount++;
      }
   }
   %this.powerCount = %powerCount;
   for (%i = 0; %i < %this.getCount(); %i++)
   {
      %obj = %this.getObject(%i);
      %obj.powerInit(%powerCount);
   }
}

function GameBase::powerInit(%this, %powerCount)
{
	if(%powerCount)
	   %this.getDatablock().gainPower(%this);
	else
	   %this.getDataBlock().losePower(%this);
}

function SimObject::isPowering(%data, %obj)
{
   return false;
}

function Generator::isPowering(%data, %obj)
{
    return !%obj.isDisabled();
}

function SimObject::updatePowerCount()
{
}

function SimObject::powerCheck()
{
}


function SimGroup::updatePowerCount(%this, %value)
{
   if(%this.powerCount > 0 || %value > 0)
      %this.powerCount += %value;
   for (%i = 0; %i < %this.getCount(); %i++)
   {
      %this.getObject(%i).updatePowerCount(%value);
   }
   for (%i = 0; %i < %this.getCount(); %i++)
      %this.getObject(%i).powerCheck(%this.powerCount);
}

function GameBaseData::gainPower(%data, %obj)
{
}

function GameBaseData::losePower(%data, %obj)
{
}

function InteriorInstance::powerCheck(%this, %powerCount)
{
	if(%powerCount > 0)
		%mode = "Off";
	else
		%mode = "On";
   %this.setAlarmMode(%mode);
}

function GameBase::powerCheck(%this, %powerCount)
{
   if(%powerCount || %this.selfPower)
      %this.getDatablock().gainPower(%this);
   else
      %this.getDatablock().losePower(%this);
}

function GameBase::incPowerCount(%this) {
	%group = %this.getGroup();
	if (%group != nameToID("MissionCleanup/Deployables"))
		%group.updatePowerCount(1);
}

function GameBase::decPowerCount(%this) {
	%group = %this.getGroup();
	if (%group != nameToID("MissionCleanup/Deployables"))
		%group.updatePowerCount(-1);
}

function GameBase::setSelfPowered(%this) {
	if(!%this.isPowered()) {
		%this.selfPower = true;
		if(%this.getDatablock().deployedObject)
			%this.initDeploy = true;
		%this.getDataBlock().gainPower(%this);
	}
	else
		%this.selfPower = true;
}

function GameBase::clearSelfPowered(%this)
{
   %this.selfPower = "";
   if(!%this.isPowered())
      %this.getDataBlock().losePower(%this);
}

function GameBase::isPowered(%this) {
	return ((%this.selfPower && %this.isEnabled()) || %this.getGroup().powerCount > 0 || %this.powerCount > 0) && !%this.isSwitchedOff;
}

function buildPowerList() {
	$PowerList = "";
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj =  %group.getObject(%i);
		if (isObject(%obj)) {
			if (%obj.getDataBlock().className $= "Generator" && %obj.deployed && !%obj.isRemoved) {
				// Not using listAdd() here, for speed
				$PowerList = $PowerList SPC %obj;
			}
		}
	}
	$PowerList = trim($PowerList);
}

function globalPowerCheck() {
	buildPowerList();
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj = %group.getObject(%i);
		%obj.powerCount = "";
		if (%obj.getDataBlock().needsPower)
			%obj.getDataBlock().losePower(%obj);
		checkPowerObject(%obj);
	}
}

function checkPowerGenerator(%powerObj,%stateChange) {
	%group = nameToID("MissionCleanup/Deployables");
	if (!isObject(%group))
		return;
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj = %group.getObject(%i);
		if (%obj.getDataBlock().needsPower) {
			if (genLinkedObj(%powerObj,%obj)) {
				%obj.powerCount = %obj.powerCount + %stateChange;
				checkPowerObject(%obj);
			}
		}
	}
}

function checkPowerObject(%obj) {
	if (%obj.getDataBlock().needsPower) {
		%powerCount = %obj.powerCount;
		if (%powerCount $= "") {
			%count = getWordCount($PowerList);
			%powerCount = 0;
			for(%i=0;%i<%count;%i++) {
				%powerObj = getWord($PowerList,%i);
				if (genPoweringObj(%powerObj,%obj))
					%powerCount++;
			}
		}
		%obj.powerCount = %powerCount;
		doObjectPower(%obj);
	}
}

function genPoweringObj(%powerObj,%obj) {
	%isPowering = false;
        if (isObject(%powerObj)){                
	if (%powerObj.isEnabled() && %powerObj.isPowered()) {
		if (genLinkedObj(%powerObj,%obj))
			%isPowering = true;
        }
	}
	return %isPowering;
}

function genLinkedObj(%powerObj,%obj) {
	if (%obj.powerFreq == %powerObj.powerFreq) {
		if (vectorDist(%obj.getPosition(),%powerObj.getPosition()) < %powerObj.getDataBlock().powerRadius
			&& (%obj.team == %powerObj.team || %powerObj.team == 0)
			&& !%obj.isRemoved && !%powerObj.isRemoved) {
			%lsLinked = true;
		}
	}
	return %lsLinked;
}

function doObjectPower(%obj) {
	if (%obj.powerCount > 0)
		%obj.getDataBlock().gainPower(%obj);
	else
		%obj.getDataBlock().losePower(%obj);
}

function delNonPoweredPieces(%quiet) {
	%randomTime = 10000;
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj =  %group.getObject(%i);
		if (%obj.getDataBlock().className !$= "Generator") {
			%hasPower = "";
			%count2 = getWordCount($PowerList);
			for(%i2=0;%i2<%count2;%i2++) {
				%powerObj = getWord($PowerList,%i2);
				if (vectorDist(%obj.getPosition(),%powerObj.getPosition()) < %powerObj.getDataBlock().powerRadius) {
						%hasPower = true;
						break;
				}

			}
			if (!%hasPower) {
				if (!%quiet)
					warn("Deleting: " @ %obj @ " Name: " @ %obj.getDataBlock().getName());
				%random = getRandom() * %randomTime;
				%obj.getDataBlock().schedule(%random,"disassemble",%plyr,%obj); // Run Item Specific code.
				%deleted++;
			}
			else
				%checked++;
		}
	}
	if (!%quiet) {
		warn("Checked pieces: " @ %checked);
		warn("Deleted pieces: " @ %deleted);
	}
	return %randomTime;
}

function displayPowerFreq(%obj) {
	%powerFreq = %obj.powerFreq;
	if (%powerFreq < 1 || %powerFreq > upperPowerFreq(%obj) || !%powerFreq)
		%powerFreq = 1;
	%obj.powerFreq = %powerFreq;
	bottomPrint(%obj.client,"Your power frequency is set to: " @ %obj.powerFreq,2,1);
}

function toggleGenerator(%obj,%state) {
	if (!isObject(%obj))
		return -1;
	%dataBlockName = %obj.getDataBlock().getName();
	if (%dataBlockName $= "GeneratorLarge") {
		%switchDelay = 5000;
		%displayName = "Generator";
		%powerOnSound = BasePowerOn;
		%powerOffSound = BasePowerOff;
	}
	else if (%dataBlockName $= "SolarPanel" || %dataBlockName $= "SpawnPoint") {
		%switchDelay = 1000;
		if(%dataBlockName $= "SolarPanel")
			%displayName = "Solar Panel";
		else
			%displayName = "Spawn Point";
		%powerOnSound = PlasmaSwitchSound;
		%powerOffSound = PlasmaReloadSound;
	}
	%taggedDisplayName = addTaggedString(%displayName);
	if (!%obj.isEnabled())
		return -2 SPC %taggedDisplayName;
	if (!(%obj.switchTime + %switchDelay < getSimTime()))
		return -3 SPC %taggedDisplayName SPC %obj.switchTime + %switchDelay - getSimTime();
	if (%obj.isSwitchedOff && (%state != false || %state $= "")) {
		%obj.isSwitchedOff = "";
		%obj.getDataBlock().gainPower(%obj);
		%obj.play3D(%powerOnSound);
		if (%obj.name !$= "")
		{
			%name = "[" @ %obj.name @ "] Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		else
		{
			%name = "Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		%obj.switchTime = getSimTime();
		return 2 SPC %taggedDisplayName;
	}
	else if (!%obj.isSwitchedOff && (%state != true || %state $= "")) {
		%obj.getDataBlock().losePower(%obj);
		%obj.isSwitchedOff = 1;
		%obj.play3D(%powerOffSound);
		if (%obj.name !$= "")
		{
			%name = "[" @ %obj.name @ "] Disabled Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		else
		{
			%name = "Disabled Frequency" SPC %obj.powerFreq;
			setTargetName(%obj.target,addTaggedString(%name));
			%obj.nameTag = %name;
		}
		%obj.switchTime = getSimTime();
		return 1 SPC %taggedDisplayName;
	}
	return 0;
}

function upperPowerFreq(%plyr) {
	if (%plyr.client.isAdmin || %plyr.client.isSuperAdmin)
		return 150;
	else
		return 100;
}
