//--------------------------------------------------------------------------
// Deconstruct Gun / Construction Tool
// Originally from Hammer Mod. Changed and redone for LuCiD MoD.
// Also Changed again and redone for Construction Mod.
// All changes made by LuCiD from LuCiD MoD & Mostlikely or JackTL from Construction Mod.

$ReverseDeployItem[DeployedStationInventory] = InventoryDeployable;
$ReverseDeployItem[DeployedMotionSensor] = MotionSensorDeployable;
$ReverseDeployItem[DeployedPulseSensor] = PulseSensorDeployable;
$ReverseDeployItem[TurretDeployedOutdoor] = TurretOutdoorDeployable;
$ReverseDeployItem[TurretDeployedFloorIndoor] = TurretIndoorDeployable;
$ReverseDeployItem[TurretDeployedWallIndoor] = TurretIndoorDeployable;
$ReverseDeployItem[TurretDeployedCeilingIndoor] = TurretIndoorDeployable;
$ReverseDeployItem[TurretDeployedBase] = TurretBasePack;
$ReverseDeployItem[TurretDeployedSentry] = TurretSentryPack;
$ReverseDeployItem[TurretDeployedCamera] = CameraGrenade;
$ReverseDeployItem[TelePadDeployedBase] = TelePadPack;
$ReverseDeployItem[DeployedSpine] = "poof spineDeployable";
$ReverseDeployItem[DeployedSpine2] = "poof spineDeployable";
$ReverseDeployItem[DeployedWoodSpine] = "poof spineDeployable";
$ReverseDeployItem[DeployedPad] = "poof spineDeployable";
$ReverseDeployItem[Deployedfloor] = "poof floorDeployable";
$ReverseDeployItem[Deployedwall] = "poof wallDeployable";
$ReverseDeployItem[Deployedwwall] = "poof wwallDeployable";
$ReverseDeployItem[Deployedmspine] = "poof mspineDeployable";
$ReverseDeployItem[DeployedDoor] = "poof DoorDeployable";
$ReverseDeployItem[SpawnPoint] = "SpawnPointPack";
$ReverseDeployItem[DeployedEnergizer] = EnergizerDeployable;
$ReverseDeployItem[Deployedmspinering] = "poof nothing";
$ReverseDeployItem[DiscTurretDeployed] = DiscTurretDeployable;
$ReverseDeployItem[StationInventory] = LargeInventoryDeployable;
$ReverseDeployItem[DeployedJumpad] = JumpadDeployable;
$ReverseDeployItemDeployedBeacon = Beacon;
$ReverseDeployItem[DeployedLogoProjector] = LogoProjectorDeployable;
$ReverseDeployItem[LaserDeployed] = TurretLaserDeployable;
$ReverseDeployItem[MissileRackTurretDeployed] = TurretMissileRackDeployable;
$ReverseDeployItem[SensorMediumPulse] = MediumSensorDeployable;
$ReverseDeployItem[SensorLargePulse] = LargeSensorDeployable;
$ReverseDeployItem[DeployedLightBase] = "LightDeployable";
$ReverseDeployItem[DeployedZSpawnBase] = "ZSpawnDeployable";
$ReverseDeployItem[DeployedSentinelPatrol] = "SentinelDeployable";
$ReverseDeployItem[DeployedSpySatellite] = "SpySatelliteDeployable";
$ReverseDeployItem[DeployedTripwire] = "TripwireDeployable";
$ReverseDeployItem[DeployedEscapePod] = "EscapePodDeployable";
$ReverseDeployItem[DeployedDiggerPack] = "DiggerPackDeployable";
$ReverseDeployItem[RepairPad] = "RepairPadDeployable";
$ReverseDeployItem[DronePad] = "DronePadDeployable";

//Note this can also be in "pack".cs
//[most]
$ReverseDeployItem[Mpm_Anti_TurretDeployed] = "TurretMpm_Anti_Deployable";
$ReverseDeployItem[DeployableVehiclePadBottom] = "VehiclePadPack";
$ReverseDeployItem[DeployableVehiclePad] = "VehiclePadPack";
$ReverseDeployItem[DeployableVehicleStation] = "VehiclePadPack";
$ReverseDeployItem[DeployableVehiclePad2] = "VehiclePadPack";
$ReverseDeployItem[PotPipe] = "poof";
$ReverseDeployItem[EmitterDep] = "poof EmitterDepPack";
$ReverseDeployItem[AudioDep] = "poof AudioDepPack";
$ReverseDeployItem[DispenserDep] = "poof DispenserDepPack";
$ReverseDeployItem[Mpm_Beacon_Ghost] = "poof";
$ReverseDeployItem[DetonationDep] = "DetonationDepPack";
$ReverseDeployItem[DetonationDepArm] = "DetonationDepPack";
$ReverseDeployItem[Deployedwaypoint] = "waypointDeployable";
for (%i = 0;%i < 51;%i++)
	$ReverseDeployItemDeployedForcefield[%i] = "ForceFieldDeployable";
for (%i = 0;%i < 5;%i++)
	$ReverseDeployItemDeployedGravityField[%i] = "GravityFieldDeployable";
for (%i = 0;%i < 14;%i++)
	$ReverseDeployItemDeployedTree[%i] = "TreeDeployable";
for (%i = 0;%i < 13;%i++)
	$ReverseDeployItemDeployedCrate[%i] = "CrateDeployable";
for (%i = 0;%i < 17;%i++)
	$ReverseDeployItemDeployedDecoration[%i] = "DecorationDeployable";
// power
$ReverseDeployItem[GeneratorLarge] = GeneratorDeployable;
$ReverseDeployItem[SolarPanel] = SolarPanelDeployable;
$ReverseDeployItem[DeployedSwitch] = SwitchDeployable;
$ReverseDeployItem[DeployedvSwitch] = vSwitchDeployable;
// DeconTarget
$ReverseDeployItem[DeployedLTarget] = "poof";

//--------------------------------------------------------------------------
// Sounds

datablock EffectProfile(ConstructionToolSwitchEffect) {
	effectname = "packs/packs.repairPackOn";
	minDistance = 2.5;
	maxDistance = 2.5;
};

datablock EffectProfile(ConstructionToolFireEffect) {
	effectname = "misc/downloading";
	minDistance = 2.5;
	maxDistance = 5.0;
};

datablock AudioProfile(ConstructionToolSwitchSound) {
	filename    = "fx/packs/packs.repairPackOn.wav";
	description = AudioClosest3d;
	preload = true;
	effect = ConstructionToolSwitchEffect;
};

datablock AudioProfile(ConstructionToolFireSound) {
	filename    = "fx/misc/downloading.wav";
	description = CloseLooping3d;
	preload = true;
	effect = ConstructionToolFireEffect;
};

//--------------------------------------------------------------------------
// Projectile

datablock RepairProjectileData(ConstructionToolBeam) {
	sound = ElfFireWetSound;

	beamRange      = 100;
	beamWidth      = 0.15;
	numSegments    = 20;
	texRepeat      = 0.20;
	blurFreq       = 10.0;
	blurLifetime   = 1.0;
	cutoffAngle    = 25.0;

	textures[0]   = "special/ELFLightning";
	textures[1]   = "skins/flaregreen";
};

//-------------------------------------------------------------------------
// shapebase datablocks

datablock ItemData(ConstructionTool) {
	className = Weapon;
	catagory = "Spawn Items";
	shapeFile = "weapon_shocklance.dts";
	image = ConstructionToolImage;
	mass = 1;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 2;
	rotate = true;
	pickUpName = "a construction tool";

	lightOnlyStatic = true;
	lightType = "PulsingLight";
	lightColor = "0 0 1";
	lightTime = 1200;
	lightRadius = 4;

	//computeCRC = true;
	emap = true;
};

//--------------------------------------------------------------------------
// Construction Tool

datablock ShapeBaseImageData(ConstructionToolImage) {
	shapeFile = "weapon_shocklance.dts";
	offset = "0 0 0";

	item = ConstructionTool;
	usesEnergy = true;

	minEnergy = 1;

	cutOffEnergy = 1.1;
	emap = true;

	stateName[0] = "Activate";
	stateTransitionOnTimeout[0] = "ActivateReady";
	stateTimeoutValue[0] = 0.25;
	stateSound[0] = ConstructionToolSwitchSound;

	stateName[1] = "ActivateReady";
	stateScript[1] = "onActivateReady";
	stateSpinThread[1] = Stop;
	stateTransitionOnAmmo[1] = "Ready";
	stateTransitionOnNoAmmo[1] = "ActivateReady";

	stateName[2] = "Ready";
	stateSpinThread[2] = Stop;
	stateTransitionOnNoAmmo[2] = "Deactivate";
	stateTransitionOnTriggerDown[2] = "Validate";

	stateName[3] = "Validate";
	stateTransitionOnTimeout[3] = "Validate";
	stateTimeoutValue[3] = 0.2;
	stateEnergyDrain[3] = 0.1;
	stateSpinThread[3] = SpinUp;
	stateScript[3] = "onValidate";
	stateIgnoreLoadedForReady[3] = true;
	stateTransitionOnLoaded[3] = "PerformAction";
	stateTransitionOnNoAmmo[3] = "Deactivate";
	stateTransitionOnTriggerUp[3] = "Deactivate";

	stateName[4] = "PerformAction";
	stateSound[4] = ConstructionToolFireSound;
	stateScript[4] = "onPerformAction";
	stateSpinThread[4] = FullSpeed;
	stateAllowImageChange[4] = false;
	stateSequence[4] = "activate";
	stateFire[4] = true;
	stateEnergyDrain[4] = 0.1;
	stateTimeoutValue[4] = 0.2;
	stateTransitionOnTimeOut[4] = "PerformAction";
	stateTransitionOnNoAmmo[4] = "Deactivate";
	stateTransitionOnTriggerUp[4] = "Deactivate";
	stateTransitionOnNotLoaded[4] = "Validate";

	stateName[5] = "Deactivate";
	stateScript[5] = "onDeactivate";
	stateSpinThread[5] = SpinDown;
	stateSequence[5] = "activate";
	stateDirection[5] = false;
	stateTimeoutValue[5] = 0.2;
	stateTransitionOnTimeout[5] = "ActivateReady";
};

function ConstructionToolImage::onActivate(%this,%obj,%slot) {
}

function ConstructionToolImage::onActivateReady(%this,%obj,%slot) {
	%obj.errMsgSent = false;
}

function ConstructionToolImage::onValidate(%this,%obj,%slot) {
	switch (%obj.constructionToolMode) {
		case 0: // disassemble
			onValidateDisassemble(%this,%obj,%slot);
		case 1: // rotate
			onValidateRotate(%this,%obj,%slot);
		case 2: // advanced rotate
			onValidateAdvancedRotate(%this,%obj,%slot);
		case 3: // power management
			onValidatePowerManagement(%this,%obj,%slot);
	}
}

function ConstructionToolImage::onPerformAction(%this,%obj,%slot) {
	// this = ConstructionToolImage datablock
	// obj = player wielding the construction tool
	// slot = weapon slot

	if (%obj.getEnergyLevel() <= %this.cutOffEnergy) {
		if (%obj.performing > 0)
			stopPerforming(%obj);
		return;
	}

	// reset the flag that indicates an error message has been sent
	%obj.errMsgSent = false;

	switch (%obj.constructionToolMode) {
		case 0: // disassemble
			onPerformDisassemble(%this,%obj,%slot);
		case 1: // rotate
			onPerformRotate(%this,%obj,%slot);
		case 2: // advanced rotate
			onPerformAdvancedRotate(%this,%obj,%slot);
		case 3: // power management
			onPerformPowerManagement(%this,%obj,%slot);
	}
}

function ConstructionToolImage::onDeactivate(%this,%obj,%slot) {
	%obj.setImageTrigger(%slot, false);
	if (%obj.performing > 0) {
		stopPerforming(%obj);
		messageClient(%player.client, 'msgClient', '\c2Construction Tool stopped.');
	}
	%obj.errMsgSent = false;
}

function ConstructionToolImage::onMount(%this,%obj,%slot) {
	if (!$Host::TournamentMode) {
		%curWeap = ( %obj.getMountedImage($WeaponSlot) == 0 ) ? "" : %obj.getMountedImage($WeaponSlot).getName().item.pickUpName;
		BottomPrint(%obj.client, "Now using " @ %curWeap, 2, 1 );
	}
	%obj.errMsgSent = false;
	%obj.client.setWeaponsHudActive(%this.item);
	%obj.usingConstructionTool = true;
	if (!%obj.constructionToolMode)
		%obj.constructionToolMode = 0;
	if (!%obj.constructionToolMode2)
		%obj.constructionToolMode2 = 0;
	WeaponImage::onMount(%this,%obj,%slot);
}

function ConstructionToolImage::onUnmount(%data, %obj, %slot) {
	%obj.usingConstructionTool = false;
	%obj.setImageTrigger(%slot, false);
	if (%obj.performing > 0) {
		stopPerforming(%obj);
		messageClient(%player.client, 'msgClient', '\c2Construction Tool stopped.');
	}
	%obj.errMsgSent = false;
	Parent::deconstruct(%data, %obj, %slot);
	WeaponImage::onUnmount(%data, %obj, %slot);
}

function ConstructionTool::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

// --------------------------------------------------------------------------------
// Common functions
// --------------------------------------------------------------------------------

function startPerforming(%player) {
	// %player = the player who was using the construction tool
	%initialDirection = %player.getMuzzleVector($WeaponSlot);
	%initialPosition  = %player.getMuzzlePoint($WeaponSlot);

	//else
        %performTime=200;
        if ($host::performTime>100)
           %performTime=$host::performTime;
	%player.performTime = %performTime;
	// Temporary (hopefully) fix
	%data = %player.performing.getDataBlock();
	%dataBlockName = %data.getName();
	if (%data.className !$= "forcefield" && %data.className !$= "gravityfield") {
		%player.constructionToolProjectile = new RepairProjectile() {
			dataBlock = ConstructionToolBeam;
			initialDirection = %initialDirection;
			initialPosition  = %initialPosition;
			sourceObject     = %player;
			sourceSlot       = $WeaponSlot;
			targetObject     = %player.performing;
		};
		MissionCleanup.add(%player.constructionToolProjectile);
	}
	%hTgt = %player.performing;
	%hTgt.beingPerformed = true;
}

function stopPerforming(%player) {
	// %player = the player who was using the construction tool
	if (%player.performing > 0) {
		if (isObject(%player.constructionToolProjectile))
			%player.constructionToolProjectile.delete();
	}
	%hTgt.beingPerformed = false;
	%player.constructionToolProjectile = 0;
	%player.performing = 0;
	%player.performTime = 0;
	%player.errMsgSent = true;
	%player.setImageTrigger($WeaponSlot, false);
	%player.setImageLoaded($WeaponSlot, false);
	%client = %player.client;
	if (%client.CampingThread)
		cancel(%client.campingThread);
	return;
}

// --------------------------------------------------------------------------------
// Disassemble functions
// --------------------------------------------------------------------------------
function onValidateDisassemble(%this,%obj,%slot) {
	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be dissed? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only deconstruct deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's disassembleable
			if (%hTgt != %obj.performing) {
				if (isObject(%obj.performing))
					stopPerforming(%obj);
				%obj.performing = %hTgt;
				startPerforming(%obj);
			}
			// setting imageLoaded to true sends us to deconstruct state (function onPerformAction)
			%obj.setImageLoaded(%slot, true);
		}
		else {
			// there is a target in range, but it's not disable
			if (!%obj.errMsgSent) {
				messageClient(%obj.client, 'msgClient', '\c2You can\'t deconstruct that.');
				%obj.errMsgSent = true;
			}
			// if player was Disassembling something, stop the disassembling -- we're done
			if (%obj.performing > 0)
				stopPerforming(%obj);
		}
	}
	else {
		// there is no target in range
		if (!%obj.errMsgSent) {
			// send an error message only once
			messageClient(%obj.client, 'msgClient', '\c2No target to deconstruct.');
			%obj.errMsgSent = true;
		}
	}
}

function onPerformDisassemble(%this,%obj,%slot) {
	%target = %obj.performing;
	if (!%target) {
		// no target -- whoops! never mind
		stopPerforming(%obj);
		return;
	}
	if (%obj.constructionToolMode2 == 0)
		%cascade = 0;
	else
		%cascade = 1;
	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
        if (%hTgt.isobjective==1 || %hTgt.isobjective==2){
           messageClient(%obj.client, 'msgClient', "\c2Deconstruction failed! can't decon objectives!~wfx/powered/nexus_deny.wav");
		   stopPerforming(%obj);
           return;
           }
		// can it be dissed? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only deconstruct deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's disassembleable
			if (%hTgt != %obj.performing) { // its not what we were originally dising
				if (isObject(%obj.performing)) {
					stopPerforming(%obj);
					%obj.performing = %hTgt;
					startPerforming(%obj);
				}
			}
			else { // continue dising
				%obj.performTime = %obj.performTime - 120;
				if (%obj.performTime < 0) { // we have a dis!
                                if (%dataBlockName $= "DeployedWarpgatePack")
                      $warpgateArray[%hTgt.myNumber] = "";
                      if (%dataBlockName $= "DeployedSpinner" && %hTgt.las != "")
                      %hTgt.las.delete();
                          if (%dataBlockName $= "DeployedSpotlightProjector")
                      %hTgt.laser.delete();
					if (%hTgt.isRemoved)
						return; // Avoid duplicate disassemblies
					if (%hTgt.team != %obj.team && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Deconstruction failed! Wrong team!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					if ($Host::OnlyOwnerDeconstruct == 1 && %hTgt.getOwner() != %obj.client && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						if (isObject(%hTgt.getOwner()))
							messageClient(%obj.client, 'msgClient', '\c2Deconstruction failed! This belongs to %1!~wfx/powered/nexus_deny.wav', %hTgt.getOwner().nameBase);
						else
							messageClient(%obj.client, 'msgClient', '\c2Deconstruction failed! Not your stuff!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					stopPerforming(%obj);
					if (%cascade && $Host::OnlyOwnerCascade == 1 && %hTgt.getOwner() != %obj.client && !(%obj.client.isAdmin || %obj.client.isSuperAdmin))
						messageClient(%obj.client, 'msgClient', '\c2Cascade failed! Not your stuff!~wfx/powered/nexus_deny.wav');
					else {
						if ((%hTgt.getType() & $TypeMasks::StaticShapeObjectType) && %hTgt.getDamageLeftPct() < (0.25 + ((getRandom() * 0.2) - 0.1))) {
							if ($Host::InvincibleDeployables == 1 && %hTgt.getDamageLeftPct() <= 0) {
//								%hTgt.setDamageLevel(%hTgt.getDataBlock().maxDamage - 0.01);
								%hTgt.setDamageLevel(0); // Make sure we can blow it up..
							}
							%hTgt.damageFailedDecon = true;
							%hTgt.schedule(100,setDamageState,Destroyed);
							messageClient(%obj.client, 'msgClient', '\c2Deconstruction failed!~wfx/powered/nexus_deny.wav');
						}
						else {
							%hTgt.getDataBlock().disassemble(%obj, %hTgt); // Run Item Specific code.
							if (%cascade)
								cascade(%hTgt,true);
							if (%hTgt.getDataBlock().getName() $= "DeployedLTarget" && isObject(%hTgt.lMain))
								%revItem = %hTgt.lMain.getDataBlock().getName();
							else
								%revItem = %hTgt.getDataBlock().getName();
							%newPack = $ReverseDeployItem[%revItem];
							if (getWord(%newPack,0) !$= "poof") {
                               %npack = new Item() {
									dataBlock = %newPack;
								};
								MissionCleanup.add(%npack);
								%npack.schedulePop();
								if (%newPack $= "ForceFieldDeployable" || %newPack $= "GravityFieldDeployable" || %newPack $= "DecorationDeployable" || %newPack $= "DecorationSDeployable")
									%pos = %hTgt.getWorldBoxCenter();
								else
									%pos = %hTgt.getPosition();
								%npack.setTransform(getWords(%scanTarg,1,3) SPC "0 0 1" SPC (getRandom() * ($Pi * 2)));
							}
						}
					}
				}
			}
		}
	}
	else
		stopPerforming(%obj);
}

// --------------------------------------------------------------------------------
// Rotate functions
// --------------------------------------------------------------------------------

function onValidateRotate(%this,%obj,%slot) {
	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be rotated? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only rotate deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's rotatable
			if (%hTgt != %obj.performing) {
				if (isObject(%obj.performing))
					stopPerforming(%obj);
				%obj.performing = %hTgt;
				startPerforming(%obj);
			}
			// setting imageLoaded to true sends us to rotate state (function onPerformAction)
			%obj.setImageLoaded(%slot, true);
		}
		else {
			// there is a target in range, but it's not rotatable
			if (!%obj.errMsgSent) {
				messageClient(%obj.client, 'msgClient', '\c2You can\'t rotate that.');
				%obj.errMsgSent = true;
			}
			// if player was rotating something, stop the rotating -- we're done
			if (%obj.performing > 0)
				stopPerforming(%obj);
		}
	}
	else {
		// there is no target in range
		if (!%obj.errMsgSent) {
			// send an error message only once
			messageClient(%obj.client, 'msgClient', '\c2No target to rotate.');
			%obj.errMsgSent = true;
		}
	}
}

function onPerformRotate(%this,%obj,%slot) {
	%target = %obj.performing;
	if (!%target) {
		// no target -- whoops! never mind
		stopPerforming(%obj);
		return;
	}
	if (%obj.constructionToolMode2 == 0)
		%rotVal = 1;
	else
		%rotVal = -1;
	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be rotated? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only rotate deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's rotatable
			if (%hTgt != %obj.performing) { // its not what we were originally rotating
				if (isObject(%obj.performing)) {
					stopPerforming(%obj);
					%obj.performing = %hTgt;
					startPerforming(%obj);
				}
			}
			else { // continue rotating
				%obj.performTime = %obj.performTime - 120;
				if (%obj.performTime < 0) { // we have a rot!
					if (%hTgt.team != %obj.team && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Rotate failed! Wrong team!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					if ($Host::OnlyOwnerRotate == 1 && %hTgt.getOwner() != %obj.client && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Rotate failed! Not your stuff!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					stopPerforming(%obj);
					%obj = firstWord(%scanTarg);
					%vec1 = posFromRaycast(%scanTarg);
					%vec2 = normalFromRaycast(%scanTarg);
					pullObject(%obj,%vec1,%vec2,$Pi/8*%rotVal,"0 0 0");
				}
			}
		}
	}
	else
		stopPerforming(%obj);
}

// --------------------------------------------------------------------------------
// Advanced rotate functions
// --------------------------------------------------------------------------------

function onValidateAdvancedRotate(%this,%obj,%slot) {
	%m2 = %obj.constructionToolMode2;
	if (%m2 == 2 || %m2 == 3 || %m2 == 4 || %m2 == 5) {
		%obj.setImageLoaded(%slot, true);
		return;
	}

	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be selected? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only select deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (!$Host::AllowUnderground) {
			if (%dataBlockName $= "TelePadDeployedBase")
					%canPerform = false;
		}
		if (%canPerform == true) {
			// yes, it's selectable
			if (%hTgt != %obj.performing) {
				if (isObject(%obj.performing))
					stopPerforming(%obj);
				%obj.performing = %hTgt;
				startPerforming(%obj);
			}
			// setting imageLoaded to true sends us to select state (function onPerformAction)
			%obj.setImageLoaded(%slot, true);
		}
		else {
			// there is a target in range, but it's not selectable
			if (!%obj.errMsgSent) {
				messageClient(%obj.client, 'msgClient', '\c2You can\'t select/rotate that.');
				%obj.errMsgSent = true;
			}
			// if player was selecting something, stop the selecting -- we're done
			if (%obj.performing > 0)
				stopPerforming(%obj);
		}
	}
	else {
		// there is no target in range
		if (!%obj.errMsgSent) {
			// send an error message only once
			messageClient(%obj.client, 'msgClient', '\c2No target to select/rotate.');
			%obj.errMsgSent = true;
		}
	}
}

function onPerformAdvancedRotate(%this,%obj,%slot) {
	// Account for lag, and make gun a bit less trigger happy
	%m2 = %obj.constructionToolMode2;
	if (%m2 == 2 || %m2 == 3 || %m2 == 4 || %m2 == 5) {
		if (getSimTime() < (%obj.constructionToolTime + 500))
			return;
	}
	else {
		if (getSimTime() < (%obj.constructionToolTime + 500) && %obj.performTime < 0)
			return;
	}
	%obj.constructionToolTime = getSimTime();

	// Load rotation list
	%list = %obj.rotList;

	// Validate list
	%size = getWordCount(%list);
	for(%id = 0; %id < %size; %id++) {
		if (!isObject(getWord(%list,%id)))
		%badIDs = %badIDs SPC %id;
	}
	%list = listDel(%list,trim(%badIDs));

	if (!%list) // Is there a rotation list?
		%list = %obj; // Set player as center.

	// Save list
	%obj.rotList = %list;

	if (%obj.rotSpeed == 0) // So players can rotate without specifically setting rotSpeed
		%obj.rotSpeed = 1;

	if (%obj.constructionToolMode2 == 2) {
		%obj.rotSpeed++;
		if (%obj.rotSpeed > 3)
			%obj.rotSpeed = -3;
		if (%obj.rotSpeed == 0)
			%obj.rotSpeed = 1;
		%mod = lev(%obj.rotSpeed) * 5 * mPow(3,mAbs(%obj.rotSpeed) -1);
		bottomPrint(%obj.client,"Rotation speed set to:" SPC %mod SPC " degrees per tick",2,1);
		return;
	}
	else if(%obj.constructionToolMode2 == 3) {
		%angle =lev(%obj.rotSpeed) * 5 * mPow(3,mAbs(%obj.rotSpeed) -1) / 180 * $Pi;
		%mod = lev(%obj.rotSpeed) * 5 * mPow(3,mAbs(%obj.rotSpeed) -1);
		rotateSection(getWord(%list,0),%list,"0 0 1" SPC %angle);
		%obj.constructionToolTime = %obj.constructionToolTime + (getWordCount(%list) * 100);
		bottomPrint(%obj.client,getWordCount(%list) SPC "objects rotated" SPC %mod SPC " degrees (wait " @ mFloor((%obj.constructionToolTime - getSimTime()) / 1000) @ " seconds)",2,1);
		return;
	}
	else if(%obj.constructionToolMode2 == 4) {
        moveSelection(getWord(%list,1).getPosition(),getWord(%list,0).getPosition(),VectorSub(%p2,%p1),%list);
		%obj.constructionToolTime = %obj.constructionToolTime + (getWordCount(%list) * 100);
		bottomPrint(%obj.client,getWordCount(%list) SPC "objects moved wait " @ mFloor((%obj.constructionToolTime - getSimTime()) / 1000) @ " seconds)",2,1);
		return;
	}
	else if(%obj.constructionToolMode2 == 5) {
		for(%id = 0; %id < getWordCount(%list); %id++) {
			%obj = getWord(%list,%id);
			%obj.startFade(400,%id * 100,0);
			if (isObject(%obj.lMain))
				%obj.lMain.startFade(400,%id * 100,0);
		}
		bottomPrint(%obj.client,getWordCount(%list) SPC "objects selected including the rotation center",2,1);
		return;
	}
	else if(%obj.constructionToolMode2 == 6) {
		%list = "";
		%obj.rotList = %list;
		bottomPrint(%obj.client,"All objects removed from rotation list - player set as rotation center",2,1);
		return;
	}

	%target = %obj.performing;
	if (!%target) {
		// no target -- whoops! never mind
		stopPerforming(%obj);
		return;
	}
	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be selected? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only select deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (!$Host::AllowUnderground) {
			if (%dataBlockName $= "TelePadDeployedBase")
					%canPerform = false;
		}
		if (%canPerform == true) {
			// yes, it's selectable
			if (%hTgt != %obj.performing) { // its not what we were originally selecting
				if (isObject(%obj.performing)) {
					stopPerforming(%obj);
					%obj.performing = %hTgt;
					startPerforming(%obj);
				}
			}
			else { // continue selecting
				%obj.performTime = %obj.performTime - 100;
				if (%obj.performTime < 0) { // we have a select!
					if (%hTgt.team != %obj.team && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Select failed! Wrong team!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					if ($Host::OnlyOwnerRotate == 1 && %hTgt.getOwner() != %obj.client && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Select failed! Not your stuff!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					if (%obj.constructionToolMode2 == 0) {
						if (%hTgt ==  getWord(%list,0)) { // Is it already the center?
							%list = listReplace(%list,%obj,0); // Replace player as center
							bottomPrint(%obj.client,"Object deselected as center",2,1);
						}
						else {
							// Remove it from the list if it was in the list to start with.
							%loc = findWord(%list,%hTgt);
							if (%loc !$= "")
								%list = listDel(%list,%loc);
							%list = listReplace(%list,%hTgt,0); // Replace player as center
							bottomPrint(%obj.client,"Object selected as center",2,1);
						}
						%hTgt.startFade(400,%id * 100,0);
						if (isObject(%hTgt.lMain))
							%hTgt.lMain.startFade(400,%id * 100,0);
					}
					else if (%obj.constructionToolMode2 == 1) {
						if (%hTgt ==  getWord(%list,0))
							bottomPrint(%obj.client,"Object is already center of rotation",2,1);
						else {
							%loc = findWord(%list,%hTgt);
							if (%loc !$= "") { // Is it already in the list?
								%list = listDel(%list,%loc);
								bottomPrint(%obj.client,"Object deselected",2,1);
							}
							else {
								%tempList = %list;
								%list = %tempList SPC %hTgt;
								bottomPrint(%obj.client,"Object Selected",2,1);
							}
						}
						%hTgt.startFade(400,%id * 100,0);
						if (isObject(%hTgt.lMain))
							%hTgt.lMain.startFade(400,%id * 100,0);
					}
				}
			}
		}
	}
	else
		stopPerforming(%obj);
	%obj.rotList = %list;
}

// --------------------------------------------------------------------------------
// Power management functions
// --------------------------------------------------------------------------------

function onValidatePowerManagement(%this,%obj,%slot) {

	%m2 = %obj.constructionToolMode2;
	if (%m2 == 1 || %m2 == 2) {
		%obj.setImageLoaded(%slot, true);
		return;
	}

	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be used? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only use deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's usable
			if (%hTgt != %obj.performing) {
				if (isObject(%obj.performing))
					stopPerforming(%obj);
				%obj.performing = %hTgt;
				startPerforming(%obj);
			}
			// setting imageLoaded to true sends us to use state (function onPerformAction)
			%obj.setImageLoaded(%slot, true);
		}
		else {
			// there is a target in range, but it's not usable
			if (!%obj.errMsgSent) {
				messageClient(%obj.client, 'msgClient', '\c2You can\'t use that.');
				%obj.errMsgSent = true;
			}
			// if player was using something, stop it -- we're done
			if (%obj.performing > 0)
				stopPerforming(%obj);
		}
	}
	else {
		// there is no target in range
		if (!%obj.errMsgSent) {
			// send an error message only once
			messageClient(%obj.client, 'msgClient', '\c2No target to use.');
			%obj.errMsgSent = true;
		}
	}
}

function onPerformPowerManagement(%this,%obj,%slot) {
	// Account for lag, and make gun a bit less trigger happy
	%m2 = %obj.constructionToolMode2;
	if (%m2 == 1 || %m2 == 2) {
		if (getSimTime() < (%obj.constructionToolTime + 500))
			return;
	}
	else {
		if (getSimTime() < (%obj.constructionToolTime + 500) && %obj.performTime < 0)
			return;
	}
	%obj.constructionToolTime = getSimTime();

	if (%obj.constructionToolMode2 == 1) {
		%obj.powerFreq++;
		if (%obj.powerFreq > upperPowerFreq(%obj))
			%obj.powerFreq = 1;
		displayPowerFreq(%obj);
		return;
	}
	else if (%obj.constructionToolMode2 == 2) {
		%obj.powerFreq--;
		if (%obj.powerFreq < 1)
			%obj.powerFreq = upperPowerFreq(%obj);
		displayPowerFreq(%obj);
		return;
	}

	%target = %obj.performing;
	if (!%target) {
		// no target -- whoops! never mind
		stopPerforming(%obj);
		return;
	}

	%hGun = %obj.getMountedImage(%slot);
	// muzVec is the vector coming from the construction tool's "muzzle"
	%muzVec = %obj.getMuzzleVector(%slot);
	// muzNVec = normalized muzVec
	%muzNVec = VectorNormalize(%muzVec);
	%beamRange = ConstructionToolBeam.beamRange;
	// scale muzNVec to the range the repair beam can reach
	%muzScaled = VectorScale(%muzNVec, %beamRange);
	// muzPoint = the actual point of the gun's "muzzle"
	%muzPoint = %obj.getMuzzlePoint(%slot);
	// rangeEnd = muzzle point + length of beam
	%rangeEnd = VectorAdd(%muzPoint, %muzScaled);
	// search for just about anything that can be damaged as well as interiors
	%searchMasks = $TypeMasks::InteriorObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::ItemObjectType;
	// search for objects within the beam's range that fit the masks above
	%scanTarg = ContainerRayCast(%muzPoint, %rangeEnd, %searchMasks, %obj);
	// screen out interiors
	if (%scanTarg && !(%scanTarg.getType() & $TypeMasks::InteriorObjectType)) {
		// a target in range was found
		%hTgt = firstWord(%scanTarg);
		// can it be used? is it already being tooled?
		if ($ReverseDeployItem[%hTgt.getDataBlock().getName()] !$= "" && !%hTht.beingPerformed)
			%canPerform = true;
		// Only use deployed items, not base ones
		%dataBlockName = %hTgt.getDataBlock().getName();
		if (%dataBlockName $= "DeployedLTarget" && !isObject(%hTgt.lMain))
			%canPerform = false;
		if (%canPerform == true && (
			%dataBlockName $= "StationInventory" ||
			%dataBlockName $= "GeneratorLarge" ||
			%dataBlockName $= "SolarPanel" ||
			%dataBlockName $= "SensorMediumPulse" ||
			%dataBlockName $= "SensorLargePulse"
			))
			if (%hTgt.deployed != true)
				%canPerform = false;
		if (%canPerform == true) {
			// yes, it's usable
			if (%hTgt != %obj.performing) { // its not what we were originally using
				if (isObject(%obj.performing)) {
					stopPerforming(%obj);
					%obj.performing = %hTgt;
					startPerforming(%obj);
				}
			}
			else { // continue using
				%obj.performTime = %obj.performTime - 100;
				if (%obj.performTime < 0) { // we have a use!
					if (%hTgt.team != %obj.team && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Use failed! Wrong team!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
                    if (%obj.constructionToolMode2 != 3 && %hTgt.getOwner() != %obj.client && !(%obj.client.isAdmin || %obj.client.isSuperAdmin)) {
						messageClient(%obj.client, 'msgClient', '\c2Use failed! Not your stuff!~wfx/powered/nexus_deny.wav');
						stopPerforming(%obj);
						return;
					}
					if (%obj.constructionToolMode2 == 0) {
						if (%hTgt.getDataBlock().className !$= "Generator") {
							messageClient(%obj.client, 'msgClient', '\c2Use failed! Not a generator!~wfx/powered/nexus_deny.wav');
							stopPerforming(%obj);
							return;
						}
						else {
							%r = toggleGenerator(%hTgt);
							%r1 = firstWord(%r);
							%r2 = getTaggedString(getWord(%r,1));
							%r3 = getWord(%r,2);
							if (%r1 == -2)
								messageClient(%obj.client, 'msgClient', '\c2Use failed! %1 is damaged!~wfx/powered/nexus_deny.wav',%r2);
							else if (%r1 == -3)
								messageClient(%obj.client, 'msgClient', '\c2Must wait %1 seconds before toggling power state.',mCeil(%r3/1000));
							else if (%r1 == 1)
								messageClient(%obj.client, 'msgClient', '\c2%1 switched off.',%r2);
							else if (%r1 == 2)
								messageClient(%obj.client, 'msgClient', '\c2%1 switched on.',%r2);
							stopPerforming(%obj);
							return;
						}
					}
					if (%obj.constructionToolMode2 == 3) {
//						if (%hTgt.powerFreq !$= "" || %hTgt.getDataBlock().needsPower) {
							%numLines = 1;
							if (%hTgt.powerFreq !$= "")
								%msg = "Power frequency is " @ %hTgt.powerFreq @ ", power is " @ (%hTgt.isPowered() ? ((%hTgt.powerCount > 0) ? (%hTgt.powerCount) : "On") : "OFF");
							else
								%msg = "Item does not have power frequency set";
							if (%hTgt.getOwner().nameBase !$= "") {
								%numLines++;
								%msg = %msg @ "\nThis belongs to " @ %hTgt.getOwner().nameBase;
                                                        }
                                                        if (%obj.client.isAdmin || %obj.client.isSuperAdmin) {
                                                                %numLines++;
                                                                if (%hTgt.getOwner() <1 || %hTgt.getOwner() $="")
                                                                   %Owner=%hTgt.owner;
                                                                else
                                                                    %Owner=%hTgt.getOwner();
                                                                %msg = %msg @ "\n [Owner Clientid]:" SPC %Owner SPC "[Object id]:" SPC %htgt;
							}
							bottomPrint(%obj.client,%msg,2,%numLines);
							stopPerforming(%obj);
//						}
					}
				}
			}
		}
	}
	else
		stopPerforming(%obj);
	%obj.rotList = %list;
}

//tring out stuf
function moveSelection(%p1,%p2,%movement,%list,%obj2)
{
%movement = VectorSub(%p2,%p1);


%obj2 = 1;
while (isObject(%obj=getWord(%list,%obj2)))
{
%obj.setTransform(VectorAdd(%obj.getPosition(),%movement) SPC "");
%obj2++;
}
}
