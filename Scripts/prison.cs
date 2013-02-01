// prison.cs

// Set up defaults for nonexisting vars
if ($Host::Prison::Enabled $= "")
	$Host::Prison::Enabled = 1; // Enable prison system
if ($Host::Prison::JailMode $= "")
	$Host::Prison::JailMode = 0; // Jailing mode
				     // 0 = prison building
				     // 1 = spawnsphere
				     // 2 = players current/last position (prison only affects use of items)
if ($Host::Prison::ReleaseMode $= "")
	$Host::Prison::ReleaseMode = 1; // Release mode - same as above

// Killing
if ($Host::Prison::Kill $= "")
	$Host::Prison::Kill = 0; // Enable killing punishment
if ($Host::Prison::TeamKill $= "")
	$Host::Prison::TeamKill = 1; // Enable teamkill punishment
if ($Host::Prison::KillTime $= "")
	$Host::Prison::KillTime = 2 * 60; // Time to punish for killing/teamkilling

// Deployables spamming
if ($Host::Prison::DeploySpam $= "")
	$Host::Prison::DeploySpam = 1; // Enable deployables spam punishment
if ($Host::Prison::DeploySpamTime $= "")
	$Host::Prison::DeploySpamTime = 60; // Time to punish for deployables spamming
if ($Host::Prison::DeploySpamMultiply $= "")
	$Host::Prison::DeploySpamMultiply = 1; // Enable punishment multiplier for repeat offenders
if ($Host::Prison::DeploySpamMaxTime $= "")
	$Host::Prison::DeploySpamMaxTime = 5 * 60; // Max time, if applying multiplier, to jail a player
if ($Host::Prison::DeploySpamCheckTimeMS $= "")
	$Host::Prison::DeploySpamCheckTimeMS = 1000; // Time in MS between deploying that is considered spam
if ($Host::Prison::DeploySpamWarnings $= "")
	$Host::Prison::DeploySpamWarnings = 10; // Number of warnings before punishment
						// This is a bit misleading. It is actually the number of spams
						// allowed before punishment. Warnings will be given for the last
						// half of them
if ($Host::Prison::DeploySpamResetWarnCountTime $= "")
	$Host::Prison::DeploySpamResetWarnCountTime = 30; // Reset warn counter after this many seconds of not deploying
if ($Host::Prison::DeploySpamRemoveRecentMS $= "")
	$Host::Prison::DeploySpamRemoveRecentMS = 1000 * 15; // Remove pieces deployed by offender within the last 15 seconds

if ($Prison::RemoveSpamTimer < 10000) // Remove spam around prison every 30 seconds, 10 seconds minimum
	$Prison::RemoveSpamTimer = 30000;

function jailPlayer(%cl,%release,%prisonTimeInSeconds,%jailThread) {
	%cl.jailThread++;
	if (!isObject(%cl)) {
		warn("-jailPlayer- no client: " @ %cl @ " (" @ (%release ? "release" : "jail") @ ")");
		return;
	}
	if (%release) {
		if (%jailThread == 0 || %cl.jailThread - 1 == %jailThread) {
			%cl.isJailed = false;
			if (($Host::Prison::ReleaseMode $= "0" || $Host::Prison::ReleaseMode $= "")
			    && $Prison::ReleasePos !$= "0" && $Prison::ReleasePos !$= "") {
				%cl.player.setVelocity("0 0 0");
				if ($Prison::ReleaseRad > 0) {
					%pi = 3.1415926535897932384626433832795; // Whoa..
					%vec = getRandom() * %pi * 2;
					%rad = getRandom() * $Prison::ReleaseRad;
					%x = %x + (mSin(%vec) * %rad);
					%y = %y + (mCos(%vec) * %rad);
					%cl.player.setPosition(VectorAdd(%x SPC %y SPC 0,$Prison::ReleasePos));
				}
				else
					%cl.player.setPosition($Prison::ReleasePos);
			}
			else if ($Host::Prison::ReleaseMode == 1) {
				%cl.player.setVelocity("0 0 0");
				%cl.player.setPosition(Game.pickPlayerSpawn(%cl,false));
			}
			else {
				// Make sure they still get released from prison building
				if (($Host::Prison::JailMode $= "0" || $Host::Prison::JailMode $= "")
				    && $Prison::JailPos !$= "0" && $Prison::JailPos !$= "") { // This could be handled nicer..
					%cl.player.setVelocity("0 0 0");
					%cl.player.setPosition(%cl.preJailPos);
//					%cl.player.setVelocity(%cl.preJailVel);
				}
				// Else, do nothing. Leave player at current position.
			}
			buyFavorites(%cl);
			if (%cl.player.weaponCount > 0)
				%cl.player.selectWeaponSlot(0);
			if (%jailThread) // Only show for timed releases
				messageAll('msgClient','\c2%1 has been released from jail.',%cl.name);
		}
		return;
	}
	if ($Host::Prison::Enabled != true) {
		warn("-jailPlayer- prison system is disabled.");
		return;
	}
	%cl.isJailed = true;
	%cl.jailTime = %prisonTimeInSeconds;
	if (isObject(%cl.player)) {
		if (%cl.player.getState() !$="Dead") {
			if(%cl.player.isMounted()) {
				if(%cl.player.vehicleTurret)
					%cl.player.vehicleTurret.getDataBlock().playerDismount(%cl.player.vehicleTurret);
				else {
					%cl.player.getDataBlock().doDismount(%cl.player,true);
					%cl.player.mountVehicle = false;
				}
			}
			serverCmdResetControlObject(%cl);
			%cl.player.setInventory(EnergyPack,1,1); // Fix Satchel Charge
			%cl.player.clearInventory();
			%cl.setWeaponsHudClearAll();
			%cl.player.setArmor("Light");
			Game.dropFlag(%cl.player);
			%cl.preJailVel = %cl.player.getVelocity();
			%cl.preJailPos = %cl.player.getPosition();
			// If we have no prison to put them in, we'll let them run around without any weapons..
			if (($Host::Prison::JailMode $= "0" || $Host::Prison::JailMode $= "")
			    && $Prison::JailPos !$= "0" && $Prison::JailPos !$= "") {
				%cl.player.setVelocity("0 0 0");
				if ($Prison::JailRad > 0) {
					%pi = 3.1415926535897932384626433832795; // Whoa..
					%vec = getRandom() * %pi * 2;
					%rad = getRandom() * $Prison::JailRad;
					%x = %x + (mSin(%vec) * %rad);
					%y = %y + (mCos(%vec) * %rad);
					%cl.player.setPosition(VectorAdd(%x SPC %y SPC 0,$Prison::JailPos));
				}
				else
					%cl.player.setPosition($Prison::JailPos);
			}
			else if ($Host::Prison::JailMode == 1) {
				%cl.player.setVelocity("0 0 0");
				%cl.player.setPosition(Game.pickPlayerSpawn(%cl,false));
			}
			else {
				// Do nothing, leave player's current position
			}
			cancel(%cl.prisonReleaseSched);
			if (%prisonTimeInSeconds > 0)
				%cl.prisonReleaseSched = schedule(%prisonTimeInSeconds * 1000,0,jailPlayer,%cl,true,0,%cl.jailThread);
		}
	}
}

function prisonCreate() {
	%prisonBasePos = "0 0 -10000";
	if (isObject(nameToID(PrisonGroup)))
		 // Note, this does not handle removal of the PhysicalZones
		PrisonGroup.delete();
	%group = nameToID(MissionCleanup);
	if(%group == -1)
		return;
	%p = new SimGroup(PrisonGroup) {
		providesPower = true;
		new InteriorInstance(PrisonMain) {
			position = %prisonBasePos;
			rotation = "-1 0 0 90";
			scale = "1 1 1";
			interiorFile = "btowra.dif";
		};
		new ForceFieldBare(PrisonFF1) {
			position = VectorAdd("-6.3 -22.5 -2.25",%prisonBasePos);
			rotation = "1 0 0 0";
			scale = "12.9 0.18 8.5";
			dataBlock = "defaultSolidFieldBare";
		};
		new ForceFieldBare(PrisonFF2) {
			position = VectorAdd("-2.25 -2.25 6.2",%prisonBasePos);
			rotation = "1 0 0 0";
			scale = "4.5 4.5 0.18";
			dataBlock = "defaultSolidFieldBare";
		};
	};
	%group.add(%p);
	PrisonGroup.powerInit(0);
	addPrisonCamera(VectorAdd("0 2 0.5",%prisonBasePos),getWords(MatrixCreateFromEuler(mDegToRad(90)) SPC "0 0",3,6),0);
	addPrisonCamera(VectorAdd("1 2 0.5",%prisonBasePos),getWords(MatrixCreateFromEuler(mDegToRad(90)) SPC "0 0",3,6),1);
	addPrisonCamera(VectorAdd("-1 2 0.5",%prisonBasePos),getWords(MatrixCreateFromEuler(mDegToRad(90)) SPC "0 0",3,6),2);
	$Prison::JailRad = 3;
	$Prison::JailPos = VectorAdd("0 -8.5 0",%prisonBasePos);
	$Prison::ReleaseRad = 4;
	$Prison::ReleasePos = VectorAdd("0 -14.25 6.75",%prisonBasePos); // Release player on top of prison
	$Prison::NoBuildRadius = 50;
}

// Prevent spam in prison. If called outside prisonCreate(), needs to be passed $Prison::RemoveSpamThread++ as arg
function prisonRemoveSpamThread(%thread) {
	// Re-evaluate here, in case user has set it to an "illegal" value
	if ($Prison::RemoveSpamTimer < 10000) // 10 seconds
		$Prison::RemoveSpamTimer = 10000;
	// Thread cancels if prison is re-created, if PrisonGroup ceases to exist, or if prison system is disabled
	if (%thread != $Prison::RemoveSpamThread || !isObject(nameToID(PrisonGroup)) || $Host::Prison::Enabled != 1) {
		warn("prisonRemoveSpamThread #" @ mAbs(%thread) @ " stopped. Last started thread: " @ $Prison::RemoveSpamThread);
		return;
	}
	InitContainerRadiusSearch($Prison::JailPos,$Prison::NoBuildRadius,$TypeMasks::StaticShapeObjectType | $TypeMasks::ItemObjectType | $TypeMasks::ForceFieldObjectType);
	while((%obj = ContainerSearchNext()) != 0) {
		// Extra safety
		if (VectorDist($Prison::JailPos,%obj.getPosition()) < $Prison::NoBuildRadius) {
			%dataBlockName = %obj.getDataBlock().getName();
			if (saveBuildingCheck(%obj)) { // If it's handled by saveBuilding(), it must be a deployable
				%random = getRandom() * $Prison::RemoveSpamTimer-2000; // prevent duplicate disassemblies
				%obj.getDataBlock().schedule(%random,"disassemble",0,%obj); // Run Item Specific code.
			}
		}
	}
	schedule($Prison::RemoveSpamTimer,0,prisonRemoveSpamThread,%thread);
}

function prisonEnable() {
	$Host::Prison::Enabled = 1;
	%pgroup = nameToID(PrisonGroup);
	if(isObject(%pgroup)) {
		%pgroup.providesPower = true;
		%pgroup.powerInit(0);
	}
	else
		prisonCreate();
	prisonRemoveSpamThread($Prison::RemoveSpamThread++);
}

function prisonDisable() {
	$Host::Prison::Enabled = 0;
	%pgroup = nameToID(PrisonGroup);
	if(isObject(%pgroup)) {
		%pgroup.providesPower = false;
		%pgroup.powerInit(0);
	}
	// Release jailed players
	%count = ClientGroup.getCount();
	for(%i = 0; %i < %count; %i++) {
		%cl = ClientGroup.getObject(%i);
		if (%cl.isJailed)
			jailPlayer(%cl,true);
	}
}

datablock SensorData(PrisonCameraSensorObject) {
	detects = false;
};

datablock TurretData(TurretPrisonCamera) {
	className = PrisonCameraTurret;
	shapeFile = "camera.dts";

	thetaMin = 50;
	thetaMax = 130;
//	thetaNull = 90;

	cameraDefaultFov = 120;
	cameraMinFov = 120;
	cameraMaxFov = 120;

	neverUpdateControl = false;

	canControl = true;
	canObserve = true;
	observeThroughObject = true;
	cmdCategory = "Support";
	cmdIcon = CMDCameraIcon;
	cmdMiniIconName = "commander/MiniIcons/com_camera_grey";
	targetNameTag = 'Prison';
	targetTypeTag = 'Camera';
	sensorData = PrisonCameraSensorObject;
	sensorRadius = PrisonCameraSensorObject.detectRadius;

	firstPersonOnly = true;
	observeParameters = "0.5 4.5 4.5";
};

datablock TurretImageData(PrisonCameraBarrel) {
	shapeFile = "turret_muzzlepoint.dts";
	usesEnergy = false;

	// Turret parameters
	activationMS      = 100;
	deactivateDelayMS = 100;
	thinkTimeMS       = 100;
	degPerSecTheta    = 180;
	degPerSecPhi      = 360;
};

function addPrisonCamera(%pos,%rot,%team) {
	%group = nameToID(PrisonGroup);
	if (!isObject(%group))
		return;
	%pCam = new Turret(PrisonCamera) {
		dataBlock = "TurretPrisonCamera";
		position = %pos;
		rotation = %rot;
		team = %team;
		needsNoPower = true;
	};
	%pCam.setRotation(%rot); // Gah!
	%group.add(%pCam);

	if(%pCam.getTarget() != -1)
		setTargetSensorGroup(%pCam.getTarget(),%team);
	%pCam.deploy();
}

function TurretPrisonCamera::damageObject(%data,%targetObject,%sourceObject,%position,%amount,%damageType,%momVec,%mineSC) {
	// Do nothing
}

function TurretPrisonCamera::onAdd(%this, %obj) {
	Parent::onAdd(%this, %obj);
	%obj.mountImage(PrisonCameraBarrel, 0, true);
		%obj.setRechargeRate(%this.rechargeRate);
	%obj.setAutoFire(false); // z0ddm0d: Server crash fix related to controlable cameras
}
