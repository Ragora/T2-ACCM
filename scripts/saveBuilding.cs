// SaveBuilding.cs
//
// This script made possible by a joint effort of DynaBlade and JackTL
//
// Functions:
//
// saveBuilding(clientId,radius,file[$],quiet[1/0])
// saveBuildingCentered(clientId,radius,file[$],quiet[1/0],centerAtMinZ[1/0])
// delBuildingWaypoint()
// loadBuilding(file[$])
// saveBuildingTimer(time in seconds,globalEcho[1/0],file[$],useMultipleFiles[1/0]) // No limit on multiple files yet. Beware
// saveBuildingTimerOn() // <-- for restarting timed saves, does not initialize like saveBuildingTimer()
// saveBuildingTimerOff()
// delDupPieces(clientId,radius,quiet[1/0]) // NOTE: There are issues with calling this function a second time before the previous call's deconstruction has finished
//
// See functions for (some) comments

if ($SaveBuilding::SaveFolder $= "")
	$SaveBuilding::SaveFolder = "Buildings/Admin/";
if ($SaveBuilding::AutoSaveFolder $= "")
	$SaveBuilding::AutoSaveFolder = "Buildings/AutoSave/";
if ($SaveBuilding::TimerDefaultTime $= "")
	$SaveBuilding::TimerDefaultTime = 5 * 60 * 1000; // 5 minutes. Saving may cause stutter on low-end servers with high number of pieces
if ($SaveBuilding::QuickDelete $= "")
	$SaveBuilding::QuickDelete = 1;


// See if we want to save the piece
function saveBuildingCheck(%obj) {
	%save = false;
	%dataBlockName = %obj.getDatablock().getName();
	switch$ (%dataBlockName) {
		case "DeployedSpine":
			%save = true;
		case "DeployedSpine2":
			%save = true;
		case "DeployedWoodSpine":
			%save = true;
		case "DeployedMSpine":
			%save = true;
		case "DeployedMSpineRing":
			%save = true;
		case "DeployedFloor":
			%save = true;
		case "DeployedWall":
			%save = true;
		case "DeployedwWall":
			%save = true;
		case "DeployedEnergizer":
			%save = true;
		case "DeployedStationInventory":
			%save = true;
		case "DeployedJumpad":
			%save = true;
		case "DeployedEscapePod":
			%save = true;
		case "TelePadDeployedBase":
			%save = true;
		case "TelePadBeam":
			%save = true;
		case "DeployedLTarget":
			%save = true;
		case "DeployedLogoProjector":
			%save = true;
		case "DeployedSwitch":
			%save = true;
		case "DeployedPulseSensor":
			%save = true;
		case "DeployedMotionSensor":
			%save = true;
		case "TurretDeployedBase":
			%save = true;
		case "TurretDeployedSentry":
			%save = true;
		case "TurretDeployedFloorIndoor":
			%save = true;
		case "TurretDeployedWallIndoor":
			%save = true;
		case "TurretDeployedCeilingIndoor":
			%save = true;
		case "TurretDeployedOutdoor":
			%save = true;
		case "LaserDeployed":
			%save = true;
		case "MissileRackTurretDeployed":
			%save = true;
		case "DiscTurretDeployed":
			%save = true;
		case "TurretDeployedCamera":
			%save = true;
		case "DeployedLightBase":
			%save = true;
		case "DeployedTripwire":
			%save = true;
		case "DeployedDoor":
			%save = true;
		case "RepairPad":
			%save = true;
		case "DeployedZSpawnBase":
			%save = true;
                case "DispenserDep":
			%save = true;
                case "AudioDep":
			%save = true;
                case "EmitterDep":
			%save = true;
		case "DeployedWaypoint":
			%save = true;
		case "SpawnPoint":
			%save = true;
	}
	if (%dataBlockName $= "StationInventory" && %obj.deployed == true)
		%save = true;
	if (%dataBlockName $= "GeneratorLarge" && %obj.deployed == true)
		%save = true;
	if (%dataBlockName $= "SolarPanel" && %obj.deployed == true)
		%save = true;
	if (%dataBlockName $= "SensorMediumPulse" && %obj.deployed == true)
		%save = true;
	if (%dataBlockName $= "SensorLargePulse" && %obj.deployed == true)
		%save = true;
	if (getSubStr(%dataBlockName,0,18) $= "DeployedForceField")
		%save = true;
	if (getSubStr(%dataBlockName,0,20) $= "DeployedGravityField")
		%save = true;
	if (getSubStr(%dataBlockName,0,12) $= "DeployedTree")
		%save = true;
	if (getSubStr(%dataBlockName,0,13) $= "DeployedCrate")
		%save = true;
	if (getSubStr(%dataBlockName,0,18) $= "DeployedDecoration")
		%save = true;
	return %save;
}

// This function saves a building and its position in the map
function saveBuilding(%cl,%rad,%file,%quiet,%isAutoSave) {
	if (%quiet == true) {
		$SaveBuilding::Quiet = true;
	}
	else {
		$SaveBuilding::Quiet = false; // Overwrite
	}
	%origCl = %cl;
	if (!isObject(%cl)) {
		if (isObject(nameToID(LocalClientConnection))) {
			%cl = nameToID(LocalClientConnection);
		}
		else {
			if ($CurrentClientId) {
				%cl = $CurrentClientId;
			}
		}
	}
	if (%rad < 1) {
		%rad = 100000;
	}
	%buildingCount = 0;
	if (%file $= "" || %file $= "0") {
		for(%found = true; %found; %buildingCount++ ) {
			%suffix = %buildingCount;
			while (strLen(%suffix) < 5) %suffix = "0" @ %suffix;
			if (%isAutoSave)
				%file = $SaveBuilding::AutoSaveFolder @ $MissionName @ "-" @ %suffix @ ".cs";
			else
				%file = $SaveBuilding::SaveFolder @ %cl.nameBase @ "-" @ $MissionName @ "-" @ %suffix @ ".cs";
			%found = isFile(%file);
		}
	}
	else {
		if (%isAutoSave)
			%file = $SaveBuilding::AutoSaveFolder @ %file;
		else
			%file = $SaveBuilding::SaveFolder @ %file;
	}
	if (isObject(%cl.getControlObject())) {
		%pos = %cl.getControlObject().getPosition();
	}
	if (!%pos) {
		%pos = "0 0 0";
	}
	if (%isAutoSave && (%origCl $= "" || %origCl $= "0"))
		%pos = "0 0 0";
	new fileObject("Building");
	if (!$SaveBuilding::Quiet) {
		warn("Saving to file: \"" @ %file @ "\"");
	}
	Building.openForWrite(%file);
	Building.writeLine("// CONSTRUCTION MOD SAVE FILE");
	Building.writeLine("// Saved by \"" @ getField(%cl.nameBase,0) @ "\"");
	Building.writeLine("// Created in mission \"" @ $MissionName @ "\"");
	Building.writeLine("// Construction " @ $ModVersion);
	Building.writeLine("");

	$SaveBuilding::Saved = 0;
	$SaveBuilding::Skipped = 0;
	initContainerRadiusSearch(%pos,%rad,$TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType);
	while((%obj = containerSearchNext()) != 0) {
		%cmp = writeBuildingComponent(%obj);
		if (%cmp !$= "") {
			Building.writeLine(%cmp);
		}
	}

	if (!$SaveBuilding::Quiet) {
		warn("Saved to file: \"" @ %file @ "\"");
		warn("Saved pieces: " @ $SaveBuilding::Saved);
		warn("Skipped pieces: " @ $SaveBuilding::Skipped);
	}

	$SaveBuilding::LastFile = %file;

	Building.close();
	Building.delete();
	return %file;
}

function writeBuildingComponent(%obj) {
	%dataBlockName = %obj.getDatablock().getName();
	%save = false;
	%save = saveBuildingCheck(%obj);
	if (%save == true) {
		if (%dataBlockName $= "DeployedMSpineRing") // Handled by DeployedMSpine
			return;
		if (%dataBlockName $= "TelePadBeam") // Handled by TelePadDeployedBase
			return;
		if (%dataBlockName $= "DeployedLTarget") // Handled by parent object
			return;
		if (!$SaveBuilding::Quiet)
			echo("Saving: " @ %obj @ " Name: " @ %dataBlockName);
		%buildingPiece = "%building = new (" @ %obj.getClassName() @ ") () {";
		%buildingPiece = %buildingPiece @ "datablock = \"" @ %dataBlockName @ "\";";
		if (%obj.nameTag !$= "") %buildingPiece = %buildingPiece @ "nameTag = \"" @ %obj.nameTag @ "\";";
		if (%obj.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %obj.position @ "\";";
		if (%obj.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %obj.rotation @ "\";";
		if (%obj.realScale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %obj.realScale @ "\";";
		else {if (%obj.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %obj.scale @ "\";";}
		if (%obj.team !$= "") %buildingPiece = %buildingPiece @ "team = \"" @ %obj.team @ "\";";
		if (%obj.ownerGUID !$= "") %buildingPiece = %buildingPiece @ "ownerGUID = \"" @ %obj.ownerGUID @ "\";";
		if (%obj.needsFit) %buildingPiece = %buildingPiece @ "needsfit = \"" @ %obj.needsFit @ "\";";
		if (%obj.grounded) %buildingPiece = %buildingPiece @ "grounded = \"" @ %obj.grounded @ "\";";
		if (%obj.deployed !$= "") %buildingPiece = %buildingPiece @ "deployed = \"" @ %obj.deployed @ "\";";
		if (%obj.impulse !$= "") %buildingPiece = %buildingPiece @ "impulse = \"" @ %obj.impulse @ "\";";
		if (%obj.velocityMod !$= "") %buildingPiece = %buildingPiece @ "velocityMod = \"" @ %obj.velocityMod @ "\";";
		if (%obj.gravityMod !$= "") %buildingPiece = %buildingPiece @ "gravityMod = \"" @ %obj.gravityMod @ "\";";
		if (%obj.appliedForce !$= "") %buildingPiece = %buildingPiece @ "appliedForce = \"" @ %obj.appliedForce @ "\";";
		if (%obj.powerFreq !$= "") %buildingPiece = %buildingPiece @ "powerFreq = \"" @ %obj.powerFreq @ "\";";
		if (%obj.isSwitchedOff !$= "") %buildingPiece = %buildingPiece @ "isSwitchedOff = \"" @ %obj.isSwitchedOff @ "\";";
		if (%obj.switchRadius !$= "") %buildingPiece = %buildingPiece @ "switchRadius = \"" @ %obj.switchRadius @ "\";";
		if (%obj.holoBlock !$= "") %buildingPiece = %buildingPiece @ "holoBlock = \"" @ %obj.holoBlock @ "\";";
		if (%obj.noSlow !$= "") %buildingPiece = %buildingPiece @ "noSlow = \"" @ %obj.noSlow @ "\";";
		if (%obj.static !$= "") %buildingPiece = %buildingPiece @ "static = \"" @ %obj.static @ "\";";
		if (%obj.timed !$= "") %buildingPiece = %buildingPiece @ "timed = \"" @ %obj.timed @ "\";";
		if (%obj.beamRange !$= "") %buildingPiece = %buildingPiece @ "beamRange = \"" @ %obj.beamRange @ "\";";
		if (%obj.tripMode !$= "") %buildingPiece = %buildingPiece @ "tripMode = \"" @ %obj.tripMode @ "\";";
		if (%obj.fieldMode !$= "") %buildingPiece = %buildingPiece @ "fieldMode = \"" @ %obj.fieldMode @ "\";";
		if (%obj.isdoor != "") %buildingPiece = %buildingPiece @ "isdoor = \"" @ %obj.isdoor@ "\";";
		if (%dataBlockName $= "TelePadDeployedBase") {
			if (%obj.frequency !$= "") %buildingPiece = %buildingPiece @ "frequency = \"" @ %obj.frequency @ "\";";
			if (%obj.teleMode !$= "") %buildingPiece = %buildingPiece @ "teleMode = \"" @ %obj.teleMode @ "\";";
		}
		if (%dataBlockName $= "DeployedDoor" || %obj.isDoor){
			if (%obj.toggletype != "") %buildingPiece = %buildingPiece @ "toggletype = \"" @ %obj.toggletype @ "\";";
			if (%obj.collisionType != "") %buildingPiece = %buildingPiece @ "collisiontype = \"" @ %obj.collisiontype @ "\";";
			if (%obj.powercontrol != "") %buildingPiece = %buildingPiece @ "powercontrol = \"" @ %obj.powercontrol @ "\";";
			if (%obj.state !$= "") %buildingPiece = %buildingPiece @ "state = \"" @ %obj.state @ "\";";
			if (%obj.timeout != "") %buildingPiece = %buildingPiece @ "timeout = \"" @ %obj.timeout @ "\";";
			if (%obj.closedscale != "") %buildingPiece = %buildingPiece @ "closedscale = \"" @ %obj.closedscale @ "\";";
			if (%obj.openedscale != "") %buildingPiece = %buildingPiece @ "openedscale = \"" @ %obj.openedscale @ "\";";
			if (%obj.pw !$= "") %buildingPiece = %buildingPiece @ "pw = \"" @ %obj.pw @ "\";";
			if (%obj.accessLevel != "") %buildingPiece = %buildingPiece @ "accessLevel = \"" @ %obj.accessLevel @ "\";";
// Eolk - this is now a global check.
//			if (%obj.isdoor != "") %buildingPiece = %buildingPiece @ "isdoor = \"" @ %obj.isdoor@ "\";";
			%buildingPiece = %buildingPiece @ "canmove = \"" @ %obj.canmove @ "\";";
		}
		if (%dataBlockName $= "DeployedZSpawnBase"){
			if (%obj.ZType != "") %buildingPiece = %buildingPiece @ "ZType = \"" @ %obj.ZType@ "\";";
			if (%obj.spawnTypeset != "") %buildingPiece = %buildingPiece @ "spawnTypeset = \"" @ %obj.spawnTypeset@ "\";";
		}
		if (%dataBlockName $= "lightDeployable"){
			if (%obj.Lgtcolor != "") %buildingPiece = %buildingPiece @ "Lgtcolor = \"" @ %obj.Lgtcolor@ "\";";
		}
		if (%obj.getType() & $TypeMasks::TurretObjectType) {
			if (%obj.isSeeker !$= "") %buildingPiece = %buildingPiece @ "isSeeker = \"" @ %obj.isSeeker @ "\";";
			%barrel = %obj.getMountedImage(0);
			if (%barrel > 0)
				%buildingPiece = %buildingPiece @ "initialBarrel = \"" @ %barrel.getName() @ "\";";
		}
		if (%dataBlockName $= "DeployedStationInventory")
			%buildingPiece = %buildingPiece @ "antidotes = \"" @ $Host::AntidoteStationMaxAntidotes @ "\";";
		%buildingPiece = %buildingPiece @ "};";
		if (%obj.getTarget() != -1) %buildingPiece = %buildingPiece @ "setTargetSensorGroup(%building.getTarget()," @ mAbs(%obj.team) @ ");";
		%buildingPiece = %buildingPiece @ "addToDeployGroup(%building);";
		if (%obj.noSlow !$= "") %buildingPiece = %buildingPiece @ "%building.pzone.delete();%building.pzone = \"\";";
		if (%dataBlockName $= "DeployedEnergizer" || %dataBlockName $= "DeployedStationInventory" || %dataBlockName $= "StationInventory"
		|| %dataBlockName $= "TurretDeployedFloorIndoor" || %dataBlockName $= "TurretDeployedWallIndoor" || %dataBlockName $= "TurretDeployedCeilingIndoor"
		|| %dataBlockName $= "TurretDeployedOutdoor" || %dataBlockName $= "DeployedPulseSensor"
		|| %dataBlockName $= "LaserDeployed" || %dataBlockName $= "MissileRackTurretDeployed" || %dataBlockName $= "DiscTurretDeployed"
		|| %dataBlockName $= "DeployedWaypoint") {
			%buildingPiece = %buildingPiece @ "%building.deploy();";
			if (%dataBlockName $= "StationInventory")
				%buildingPiece = %buildingPiece @ "adjustTrigger(%building);";
		}
		if (%obj.getDatablock().rechargeRate > 0 && !%obj.getDatablock().needsPower) %buildingPiece = %buildingPiece @ "%building.setSelfPowered();";
		if (%obj.getType() & $TypeMasks::TurretObjectType)
			%buildingPiece = %buildingPiece @ "%building.setRechargeRate(%building.getDatablock().rechargeRate);";
		if (%obj.getDataBlock().className $= "Generator" || %obj.getDataBlock().className $= "Switch") {
			if (%obj.isSwitchedOff)
				%buildingPiece = %buildingPiece @ "setTargetName(%building.target,addTaggedString(\"Disabled Frequency\" SPC %building.powerFreq));";
			else
				%buildingPiece = %buildingPiece @ "setTargetName(%building.target,addTaggedString(\"Frequency\" SPC %building.powerFreq));";
			if (%dataBlockName $= "DeployedSwitch")
				%buildingPiece = %buildingPiece @ "setTargetSkin(%building.target,'" @ getTaggedString(getTargetSkin(%obj.target)) @ "');";
				if (!%obj.isSwitchedOff)
					%buildingPiece = %buildingPiece @ "%building.playThread($AmbientThread,\"ambient\");";
			else {
				if (%obj.isSwitchedOff)
					// nb: doubles no. of power switches done, when loading switched off gens
					%buildingPiece = %buildingPiece @ "%building.lastState = \"\";%building.getDataBlock().losePower(%building);";
			}
		}
		if (%dataBlockName $= "SpawnPoint")
			%buildingPiece = %buildingPiece @ "addTeamSpawnPoint(%building);";
		$SaveBuilding::Saved++;
// Ugly, but it works. May be cleaned up later.
		if (isObject(%obj.lTarget)) { // We assume none of the later saved sub-objects need decon targets, could make this a subroutine
			%target = %obj.lTarget;
			%targetDataBlock = %target.getDatablock().getName();
			if (!$SaveBuilding::Quiet)
				echo("Saving: " @ %target @ " Name: " @ %targetDataBlock);
			%buildingPiece = %buildingPiece @ "%target = new StaticShape() {";
			%buildingPiece = %buildingPiece @ "datablock = \"" @ %targetDataBlock @ "\";";
			if (%target.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %target.position @ "\";";
			if (%target.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %target.rotation @ "\";";
			if (%target.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %target.scale @ "\";";
			if (%target.team) %buildingPiece = %buildingPiece @ "team = \"" @ %target.team @ "\";";
			%buildingPiece = %buildingPiece @ "lMain = %building;";
			%buildingPiece = %buildingPiece @ "};";
			%buildingPiece = %buildingPiece @ "%building.lTarget = %target;";
			%buildingPiece = %buildingPiece @ "addToDeployGroup(%target);";
			if (%target.getDatablock().rechargeRate > 0 && !%target.getDatablock().needsPower) %buildingPiece = %buildingPiece @ "%building.setSelfPowered();";
		}
		if (%dataBlockName $= "DeployedMSpine") {
			%left = %obj.left;
			%right = %obj.right;
			if (isObject(%left)) {
				%leftDataBlock = %left.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %left @ " Name: " @ %leftDataBlock);
				%buildingPiece = %buildingPiece @ "%left = new StaticShape() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %leftDataBlock @ "\";";
				if (%left.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %left.position @ "\";";
				if (%left.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %left.rotation @ "\";";
				if (%left.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %left.scale @ "\";";
				if (%left.team) %buildingPiece = %buildingPiece @ "team = \"" @ %left.team @ "\";";
				if (%left.needsFit) %buildingPiece = %buildingPiece @ "needsfit = \"" @ %left.needsFit @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.left = %left;";
				%buildingPiece = %buildingPiece @ "addToDeployGroup(%left);";
				if (%left.getDatablock().rechargeRate > 0 && !%left.getDatablock().needsPower) %buildingPiece = %buildingPiece @ "%building.setSelfPowered();";
				$SaveBuilding::Saved++;
			}
			if (isObject(%right)) {
				%rightDataBlock = %right.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %right @ " Name: " @ %rightDataBlock);
				%buildingPiece = %buildingPiece @ "%right = new StaticShape() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %rightDataBlock @ "\";";
				if (%right.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %right.position @ "\";";
				if (%right.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %right.rotation @ "\";";
				if (%right.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %right.scale @ "\";";
				if (%right.team) %buildingPiece = %buildingPiece @ "team = \"" @ %right.team @ "\";";
				if (%right.needsFit) %buildingPiece = %buildingPiece @ "needsfit = \"" @ %right.needsFit @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.right = %right;";
				%buildingPiece = %buildingPiece @ "addToDeployGroup(%right);";
				if (%right.getDatablock().rechargeRate > 0 && !%right.getDatablock().needsPower) %buildingPiece = %buildingPiece @ "%building.setSelfPowered();";
				$SaveBuilding::Saved++;
			}
		}
		else if (%dataBlockName $= "TelePadDeployedBase") {
			%beam = %obj.beam;
			if (isObject(%beam)) {
				%beamDataBlock = %beam.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %beam @ " Name: " @ %beamDataBlock);
				%buildingPiece = %buildingPiece @ "%beam = new StaticShape() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %beamDataBlock @ "\";";
				if (%beam.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %beam.position @ "\";";
				if (%beam.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %beam.rotation @ "\";";
				if (%beam.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %beam.scale @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.beam = %beam;";
				%buildingPiece = %buildingPiece @ "%beam.playThread(0,\"ambient\");";
				%buildingPiece = %buildingPiece @ "%beam.setThreadDir(0,true);";
				%buildingPiece = %buildingPiece @ "%beam.flashThreadDir = true;";
				%buildingPiece = %buildingPiece @ "setTargetName(%building.target,addTaggedString(\"Frequency\" SPC %building.frequency));";
			}
		}
		else if (%dataBlockName $= "DeployedLogoProjector") {
			%holo = %obj.holo;
			if (isObject(%holo)) {
				%holoDataBlock = %holo.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %holo @ " Name: " @ %holoDataBlock);
				%buildingPiece = %buildingPiece @ "%holo = new StaticShape() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %holoDataBlock @ "\";";
				if (%holo.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %holo.position @ "\";";
				if (%holo.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %holo.rotation @ "\";";
				if (%holo.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %holo.scale @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.holo = %holo;";
				%buildingPiece = %buildingPiece @ "%holo.projector = %building;";
			}
		}
		else if (%dataBlockName $= "DeployedLightBase") {
			%light = %obj.light;
			if (isObject(%light)) {
				%lightDataBlock = %light.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %light @ " Name: " @ %lightDataBlock);
				%buildingPiece = %buildingPiece @ "%light = new Item() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %lightDataBlock @ "\";";
				%buildingPiece = %buildingPiece @ "static = true;";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.light = %light;";
				%buildingPiece = %buildingPiece @ "%light.lightBase = %building;";
				%buildingPiece = %buildingPiece @ "adjustLight(%building);";
			}
		}
		else if (%dataBlockName $= "DeployedTripwire") {
			%tripField = %obj.tripField;
			if (isObject(%tripField)) {
				%tripFieldDataBlock = %tripField.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %tripField @ " Name: " @ %tripFieldDataBlock);
				%buildingPiece = %buildingPiece @ "%tripField = new ForceFieldBare() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %tripFieldDataBlock @ "\";";
				if (%tripField.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %tripField.scale @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.tripField = %tripField;";
				%buildingPiece = %buildingPiece @ "%tripField.pzone.delete();%building.pzone = \"\";";
			}
			%tripTrigger = %obj.tripTrigger;
			if (isObject(%tripTrigger)) {
				%tripTriggerDataBlock = %tripTrigger.getDatablock().getName();
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %tripTrigger @ " Name: " @ %tripTriggerDataBlock);
				%buildingPiece = %buildingPiece @ "%tripTrigger = new Trigger() {";
				%buildingPiece = %buildingPiece @ "datablock = \"" @ %tripTriggerDataBlock @ "\";";
				if (%tripTrigger.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %tripTrigger.scale @ "\";";
				if (%tripTrigger.polyhedron !$= "") %buildingPiece = %buildingPiece @ "polyhedron = \"" @ %tripTrigger.polyhedron @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "%building.tripTrigger = %tripTrigger;";
				%buildingPiece = %buildingPiece @ "%tripTrigger.baseObj = %building;";
			}
			%buildingPiece = %buildingPiece @ "setTargetName(%building.target,addTaggedString(\"Frequency\" SPC %building.powerFreq));";
			%buildingPiece = %buildingPiece @ "%building.deploy();";
			%buildingPiece = %buildingPiece @ "adjustTripwire(%building);";
		}
		else if (%dataBlockName $= "DeployedEscapePod") {
			%buildingPiece = %buildingPiece @ "adjustEscapePod(%building);";
			%buildingPiece = %buildingPiece @ "escapePodLoop(%building);";
		}
		else if (%dataBlockName $= "DeployedWaypoint") {
			if(isObject(%obj.wp)) {
				if (!$SaveBuilding::Quiet)
					echo("Saving: " @ %obj.wp @ " Name: " @ %obj.wp.getDatablock().getName());

				%buildingPiece = %buildingPiece @ "%deplWaypoint = new Waypoint() {";
				%buildingPiece = %buildingPiece @ "datablock = \"WayPointMarker\";";
				%buildingPiece = %buildingPiece @ "position = %building.position;";
				%buildingPiece = %buildingPiece @ "rotation = %building.rotation;";
				%buildingPiece = %buildingPiece @ "scale = \"" @ %obj.wp.scale @ "\";";
				%buildingPiece = %buildingPiece @ "name = \"" @ %obj.wp.name @ "\";";
				%buildingPiece = %buildingPiece @ "team = \"" @ %obj.wp.team @ "\";";
				%buildingPiece = %buildingPiece @ "};";
				%buildingPiece = %buildingPiece @ "MissionCleanup.add(%deplWaypoint);";
				%buildingPiece = %buildingPiece @ "%building.wp = %deplWaypoint;";
			}
		}
	}
	else {
		if (!$SaveBuilding::Quiet) {
//			warn("Skipping: " @ %obj @ " Name: " @ %dataBlockName);
		}
		%buildingPiece = "";
		$SaveBuilding::Skipped++;
	}

	return %buildingPiece;
}

// This function saves a building and relocates it to the center of the 'map'
// Optional switch to put center at lowest part of building
//
// NB: Position of objects (such as support beams) is their attachment point,
// not their actual center. This may give some 'strange' results when centering
// small buildings

function saveBuildingCentered(%cl,%rad,%file,%quiet,%centerAtMinZ) {
	if (%quiet == true) {
		$SaveBuilding::Quiet = true;
	}
	else {
		$SaveBuilding::Quiet = false; // Overwrite
	}
	if (!isObject(%cl)) {
		if (isObject(nameToID(LocalClientConnection))) {
			%cl = nameToID(LocalClientConnection);
		}
		else {
			if ($CurrentClientId) {
				%cl = $CurrentClientId;
			}
		}
	}
	if (%rad < 1) {
		%rad = 100000;
	}
	%buildingCount = 0;
	if (%file $= "") {
		for(%found = true; %found; %buildingCount++ ) {
			%suffix = %buildingCount;
			while (strLen(%suffix) < 5) %suffix = "0" @ %suffix;
			%file = $SaveBuilding::SaveFolder @ %cl.nameBase @ "-" @ $MissionName @ "-" @ %suffix @ ".cs";
			%found = isFile(%file);
		}
	}
	else {
		%file = $SaveBuilding::SaveFolder @ %file;
	}

	if (isObject(%cl.getControlObject())) {
		%pos = %cl.getControlObject().getPosition();
	}
	if (!%pos) {
		%pos = "0 0 0";
	}
	new fileObject("Building");
	if (!$SaveBuilding::Quiet) {
		warn("Saving to file: \"" @ %file @ "\"");
	}
	Building.openForWrite(%file);
	Building.writeLine("// CONSTRUCTION MOD SAVE FILE");
	Building.writeLine("// This building was saved by \"" @ getField(%cl.nameBase,0) @ "\"");
	Building.writeLine("// This building was created in mission \"" @ $MissionName @ "\"");
	Building.writeLine("");

	$SaveBuilding::Saved = 0;
	$SaveBuilding::Skipped = 0;
	$SaveBuilding::MaxX = 0;
	$SaveBuilding::MaxY = 0;
	$SaveBuilding::MaxZ = 0;
	$SaveBuilding::MinX = 0;
	$SaveBuilding::MinY = 0;
	$SaveBuilding::MinZ = 0;

	%firstObj = true;
	initContainerRadiusSearch(%pos,%rad,$TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType);
	while((%obj = containerSearchNext()) != 0) {
		%compPos = checkBuildingComponentCentered(%obj);
		if (%compPos) {
			%x = getWord(%compPos,0);
			%y = getWord(%compPos,1);
			%z = getWord(%compPos,2);
			if (%x > $SaveBuilding::MaxX || %firstObj) {$SaveBuilding::MaxX = %x;}
			if (%y > $SaveBuilding::MaxY || %firstObj) {$SaveBuilding::MaxY = %y;}
			if (%z > $SaveBuilding::MaxZ || %firstObj) {$SaveBuilding::MaxZ = %z;}
			if (%x < $SaveBuilding::MinX || %firstObj) {$SaveBuilding::MinX = %x;}
			if (%y < $SaveBuilding::MinY || %firstObj) {$SaveBuilding::MinY = %y;}
			if (%z < $SaveBuilding::MinZ || %firstObj) {$SaveBuilding::MinZ = %z;}
			%firstObj = false;
		}
	}

	$SaveBuilding::SizeX = $SaveBuilding::MaxX - $SaveBuilding::MinX;
	$SaveBuilding::SizeY = $SaveBuilding::MaxY - $SaveBuilding::MinY;
	$SaveBuilding::SizeZ = $SaveBuilding::MaxZ - $SaveBuilding::MinZ;

	$SaveBuilding::CenterX = $SaveBuilding::MinX + ($SaveBuilding::SizeX / 2);
	$SaveBuilding::CenterY = $SaveBuilding::MinY + ($SaveBuilding::SizeY / 2);
	if (!%centerAtMinZ) {$SaveBuilding::CenterZ = $SaveBuilding::MinZ + ($SaveBuilding::SizeZ / 2);}
	else {$SaveBuilding::CenterZ = $SaveBuilding::MinZ;}

	if (isObject($SaveBuilding::TestWaypoint))
		$SaveBuilding::TestWaypoint.delete();
	$SaveBuilding::TestWaypoint = new WayPoint(SaveBuildingWaypoint) {
		position = $SaveBuilding::CenterX SPC $SaveBuilding::CenterY SPC $SaveBuilding::CenterZ;
		rotation = "1 0 0 0";
		scale = "1 1 1";
		dataBlock = "WayPointMarker";
		team = 0;
		name = "Saved Building Center";
	};
	MissionCleanup.add($SaveBuilding::TestWaypoint);

	initContainerRadiusSearch(%pos,%rad,$TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType);
	while((%obj = containerSearchNext()) != 0) {
		%cmp = writeBuildingComponentCentered(%obj);
		if (%cmp !$= "") {
			Building.writeLine(%cmp);
		}
	}

	if (!$SaveBuilding::Quiet) {
		warn("Saved to file: \"" @ %file @ "\"");
		warn("Saved pieces: " @ $SaveBuilding::Saved);
		warn("Skipped pieces: " @ $SaveBuilding::Skipped);
	}

	$SaveBuilding::LastFile = %file;

	Building.close();
	Building.delete();
	return %file;
}

function checkBuildingComponentCentered(%obj) {
	%save = false;
	%save = saveBuildingCheck(%obj);
	if (%save == true) {
		%pos = %obj.position;
		%x = getWord(%pos,0);
		%y = getWord(%pos,1);
		%z = getWord(%pos,2);
		%obj.saveBuilding = true;
		return %x SPC %y SPC %z;
	}
	else {
		%obj.saveBuilding = false;
		return;
	}
}

function writeBuildingComponentCentered(%obj) {
	%dataBlockName = %obj.getDatablock().getName();
	%save = false;
	%save = saveBuildingCheck(%obj);
	if (%save == true) {
		if (!$SaveBuilding::Quiet)
			echo("Saving: " @ %obj @ " Name: " @ %dataBlockName);
		%buildingPiece = "%building = new (" @ %obj.getClassName() @ ") () {";
		%buildingPiece = %buildingPiece @ "datablock = \"" @ %dataBlockName @ "\";";
		%pos = %obj.position;
		%x = getWord(%pos,0)-$SaveBuilding::CenterX;
		%y = getWord(%pos,1)-$SaveBuilding::CenterY;
		%z = getWord(%pos,2)-$SaveBuilding::CenterZ;
		%savePos = %x SPC %y SPC %z;
		if (%obj.position !$= "") %buildingPiece = %buildingPiece @ "position = \"" @ %savePos @ "\";";
		if (%obj.rotation !$= "") %buildingPiece = %buildingPiece @ "rotation = \"" @ %obj.rotation @ "\";";
		if (%obj.realScale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %obj.realScale @ "\";";
		else {if (%obj.scale !$= "") %buildingPiece = %buildingPiece @ "scale = \"" @ %obj.scale @ "\";";}
		if (%obj.impulse !$= "") %buildingPiece = %buildingPiece @ "impulse = \"" @ %obj.impulse @ "\";";
		if (%obj.frequency !$= "") %buildingPiece = %buildingPiece @ "frequency = \"" @ %obj.frequency @ "\";";
		%buildingPiece = %buildingPiece @ "};";
		$SaveBuilding::Saved++;
	}
	else {
		if (!$SaveBuilding::Quiet) {
//			warn("Skipping: " @ %obj @ " Name: " @ %dataBlockName);
		}
		%buildingPiece = "";
		$SaveBuilding::Skipped++;
	}

	return %buildingPiece;
}

function delBuildingWaypoint() {
	if (isObject($SaveBuilding::TestWaypoint))
		$SaveBuilding::TestWaypoint.delete();
}

function loadBuilding(%file) {
	compile($SaveBuilding::SaveFolder @ %file); // Just in case it bombs out
	exec($SaveBuilding::SaveFolder @ %file);
}

function saveBuildingTimer(%timeInSeconds,%globalEcho,%file,%useMultipleFiles,%isScheduled,%threadCount) {
	if (!%isScheduled) {
		$SaveBuilding::TimerCount++;
		$SaveBuilding::TimerTime = %timeInSeconds * 1000;
		if ($SaveBuilding::TimerTime < 1)
			$SaveBuilding::TimerTime = $SaveBuilding::TimerDefaultTime;
		$SaveBuilding::TimerFile = %file;
		if ($SaveBuilding::TimerFile $= "" || $SaveBuilding::TimerFile $= "0")
			$SaveBuilding::TimerFile = "SaveBuildingTimer.cs";
		if (%useMultipleFiles)
			$SaveBuilding::TimerFile = "";
		$SaveBuilding::TimerGlobalChatEcho = %globalEcho;
		$SaveBuilding::TimerEnabled = true;
		%threadCount = $SaveBuilding::TimerCount;
	}
	if ($SaveBuilding::TimerEnabled == true && $SaveBuilding::TimerCount == %threadCount && isObject("MissionCleanup/Deployables")) {
		%file = saveBuilding(0,0,$SaveBuilding::TimerFile,true,true);
		%timeToNextSave = mFloatLength($SaveBuilding::TimerTime / 60 / 1000,2);
		%timeToNextSaveMinutes = mFloor(%timeToNextSave);
		%timeToNextSaveSeconds = mFloor((%timeToNextSave - %timeToNextSaveMinutes) * 60);
		%timeToNextSave = %timeToNextSaveMinutes @ "m, " @ %timeToNextSaveSeconds @ "s";
		%filespec = "\"" @ %file @ "\"";
		if ($SaveBuilding::TimerFile $= "")
			%filespec = %filespec @ " (using multiple files)";
		warn("-SaveBuildingTimer- Saved to: " @ %filespec @ " - Timer: " @ %timeToNextSave);
		if ($SaveBuilding::TimerGlobalChatEcho)
			MessageAll('msgClient',"\c2Buildings saved. Next save in " @ %timeToNextSave);
		if ($SaveBuilding::TimerTime > 0) // Extra safety
			schedule($SaveBuilding::TimerTime,0,saveBuildingTimer,0,0,0,0,true,%threadCount);
	}
	else {
		warn("-SaveBuildingTimer- Thread " @ %threadCount @ " disabled. Last active thread: " @ $SaveBuilding::TimerCount);
	}
}

// NB: This function does not setup default parameters
function saveBuildingTimerOn() {
	if ($SaveBuilding::TimerTime < 1) {
		$SaveBuilding::TimerTime = $SaveBuilding::TimerDefaultTime;
	}
	$SaveBuilding::TimerCount++;
	$SaveBuilding::TimerEnabled = true;
	saveBuildingTimer(0,0,0,0,true,$SaveBuilding::TimerCount);
}

function saveBuildingTimerOff() {
	$SaveBuilding::TimerEnabled = false;
}

function delDupPieces(%cl,%rad,%quiet) {
	%randomTime = 10000;
	if (%quiet == true) {
		$SaveBuilding::Quiet = true;
	}
	else {
		$SaveBuilding::Quiet = false; // Overwrite
	}
	if (!isObject(%cl)) {
		if (isObject(nameToID(LocalClientConnection))) {
			%cl = nameToID(LocalClientConnection);
		}
		else {
			if ($CurrentClientId) {
				%cl = $CurrentClientId;
			}
		}
	}
	if (%rad < 1) {
		%rad = 100000;
	}
	if (isObject(%cl.getControlObject())) {
		%pos = %cl.getControlObject().getPosition();
	}
	if (!%pos) {
		%pos = "0 0 0";
	}
	%oldChk = "";
	initContainerRadiusSearch(%pos,%rad,$TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType);
	while((%obj = containerSearchNext()) != 0) {
		%dataBlockName = %obj.getDatablock().getName();
		%save = saveBuildingCheck(%obj);
		if (%save) {
			// Round down a bit
			%objPos = mFloatLength(getWord(%obj.getPosition(),0),2) SPC mFloatLength(getWord(%obj.getPosition(),1),2) SPC mFloatLength(getWord(%obj.getPosition(),2),2);
			%objRot = mFloatLength(getWord(%obj.rotation,0),2) SPC mFloatLength(getWord(%obj.rotation,1),2) SPC mFloatLength(getWord(%obj.rotation,2),2) SPC mFloatLength(getWord(%obj.rotation,3),2);
			if (%obj.realScale)
				%objScale = %obj.realScale;
			else
				%objScale = %obj.scale;
			if (%dataBlockName $= "DeployedFloor" || %dataBlockName $= "DeployedwWall")
				// This doesn't handle all wWalls, but it helps
				%chk = %dataBlockName SPC %objPos SPC %objScale;
			else
				%chk = %dataBlockName SPC %objPos SPC %objRot SPC %objScale;
			if (%chk $= %oldChk) {
				%deleted++;
				if (!$SaveBuilding::Quiet && %dataBlockName !$= "DeployedMSpineRing")
					warn("Deleting: " @ %oldObj @ " Name: " @ %dataBlockName);
				// from inventoryHud.cs, modified
				%random = getRandom() * %randomTime;
				// Not the best way of doing this..
				if ($SaveBuilding::QuickDelete == true) {
					// Handle special cases
					if (%dataBlockName $= "DeployedMSpine") {
						if (isObject(%oldObj.left)) {
							if (!$SaveBuilding::Quiet)
								warn("Deleting: " @ %oldObj.left @ " Name: " @ %oldObj.left.getDatablock().getName());
							%deleted++;
							remDSurface(%oldObj.left);
							%oldObj.left.delete();
						}
						if (isObject(%oldObj.right)) {
							if (!$SaveBuilding::Quiet)
								warn("Deleting: " @ %oldObj.right @ " Name: " @ %oldObj.right.getDatablock().getName());
							%deleted++;
							remDSurface(%oldObj.right);
							%oldObj.right.delete();
						}
						remDSurface(%oldObj);
						%oldObj.delete();
					}
					else if (%dataBlockName $= "DeployedEscapePod") {
						if (isObject(%oldObj.lTarget)) {
							if (!$SaveBuilding::Quiet)
								warn("Deleting: " @ %oldObj.lTarget @ " Name: " @ %oldObj.lTarget.getDatablock().getName());
							%deleted++;
							remDSurface(%oldObj.lTarget);
							%oldObj.lTarget.delete();
						}
						if (isObject(%oldObj.podVehicle)) {
							if (!$SaveBuilding::Quiet)
								warn("Deleting: " @ %oldObj.podVehicle @ " Name: " @ %oldObj.podVehicle.getDatablock().getName());
							%deleted++;
							%oldObj.podVehicle.delete();
						}
						%oldObj.delete();
					}
					else if (%dataBlockName $= "DeployedMSpineRing") {
						// Nil. Handled by DeployedMSpine
						%deleted--;
					}
					else if (%dataBlockName $= "TelePadBeam") {
						// Nil. Handled by TelePadDeployedBase
						%deleted--;
					}
					else if (%dataBlockName $= "DeployedLTarget") {
						// Nil. Handled by parent object
						%deleted--;
					}
					else {
						if (%oldObj.beam)
							%oldObj.beam.delete();
						if (%oldObj.pzone)
							%oldObj.pzone.delete();
						if (%oldObj.trigger)
							%oldObj.trigger.delete();
						if (%oldObj.lTarget)
							%oldObj.lTarget.delete();
						if (%oldObj.holo)
							%oldObj.holo.delete();
						if (%oldObj.light)
							%oldObj.light.delete();
						if (%oldObj.tripField)
							%oldObj.tripField.delete();
						if (%oldObj.tripTrigger)
							%oldObj.tripTrigger.delete();
						remDSurface(%oldObj);
						%oldObj.delete();
					}
				}
				else {
					// Handle special cases
					if (%dataBlockName $= "DeployedMSpineRing") {
							// Nil. Handled by DeployedMSpine
					}
					else if (%dataBlockName $= "TelePadBeam") {
						// Nil. Handled by TelePadDeployedBase
					}
					else if (%dataBlockName $= "DeployedLTarget") {
						// Nil. Handled by parent object
					}
					else {
						%oldObj.getDataBlock().schedule(%random,"disassemble",0, %oldObj); // Run Item Specific code.
					}
				}
			}
			else {
				%checked++;
//				if (!$SaveBuilding::Quiet)
//					echo("Checking: " @ %obj @ " Name: " @ %dataBlockName);
			}
			%oldChk = %chk;
			%oldObj = %obj;
		}
		else {
			%skipped++;
//			if (!$SaveBuilding::Quiet)
//				warn("Skipping: " @ %obj @ " Name: " @ %dataBlockName);
		}
	}

	if (!$SaveBuilding::Quiet) {
		warn("Checked pieces: " @ %checked);
		warn("Skipped pieces: " @ %skipped);
		warn("Deleted pieces: " @ %deleted);
	}
	return %randomTime;
}

function updateDeployedCount() {
	Game.clearDeployableMaxes();
	%group = nameToID("MissionCleanup/Deployables");
	%count = %group.getCount();
	for(%i=0;%i<%count;%i++) {
		%obj = %group.getObject(%i);
		%revItem = $ReverseDeployItem[%obj.getDataBlock().getName()];
		if (getWord(%revItem,0) $= "poof")
			%revItem = getWord(%revItem,1);
		if (%revItem !$= "")
			$TeamDeployedCount[%obj.team,%revItem]++;
	}
}
