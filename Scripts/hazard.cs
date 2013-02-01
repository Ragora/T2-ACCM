// hazard.cs

if ($Host::Hazard::Enabled $= "")
	$Host::Hazard::Enabled = 0; // Disable as default
if ($Hazard::HazardTimer < 500)
	$Hazard::HazardTimer = 2500; // Hazard loop timer
if ($Hazard::StormTimer < 100)
	$Hazard::StormTimer = 500; // Hazard "storm" loop timer
if ($Hazard::HazardStormDurationMin $= "")
	$Hazard::HazardStormDurationMin = 45000; // Storm duration min
if ($Hazard::HazardStormDurationMax $= "")
	$Hazard::HazardStormDurationMax = 120000; // Storm duration max
if ($Hazard::StormRandom $= "")
	$Hazard::StormRandom = 120; // Storm random chance
if ($Hazard::MeteorMax < 1)
	$Hazard::MeteorMax = 1; // Max meteors per run
if ($Hazard::MeteorMin $= "" || $Hazard::MeteorMin > $Hazard::MeteorMax)
	$Hazard::MeteorMin = 0; // Min meteors per run
if ($Hazard::MeteorRad $= "")
	$Hazard::MeteorRad = 1650; // Meteor drop radius

if ($Hazard::MaxSlant < 0 || $Hazard::MaxSlant $= "")
	$Hazard::MaxSlant = 0.4;
if ($Hazard::BDropAddX $= "")
	$Hazard::BDropAddX = 0.00153;
if ($Hazard::BDropAddY $= "")
	$Hazard::BDropAddY = 0.00956;
if ($Hazard::DropAddVariation $= "")
	$Hazard::DropAddVariation = 0.0010; // divided by two = +/- 0.0005
if ($Hazard::DropAddVariationTime < 1)
	$Hazard::DropAddVariationTime = 1000 * 60 * 10; // 10 minutes

if ($Hazard::DropX $= "" || mAbs($Hazard::DropX) > 1)
	$Hazard::DropX = (getRandom() * 2) - 1;
if ($Hazard::DropY $= "" || mAbs($Hazard::DropY) > 1)
	$Hazard::DropY = 0;


function hazardOn() {
	$Host::Hazard::Enabled = 1;
	hazardThread($Hazard::HazardThread++);
}

function hazardOff() {
	$Host::Hazard::Enabled = 0;
}

function hazardThread(%thread) {
	if (%thread != $Hazard::HazardThread || $Host::Hazard::Enabled != 1 || !isObject(MissionCleanup)) {
		warn("HazardThread #" @ mAbs(%thread) @ " stopped. Last started thread: " @ $Hazard::HazardThread);
		return;
	}

	if ($Hazard::StormTime $= "") {
		%rnd = getRandom(0,$Hazard::StormRandom);
		if (%rnd == 1) {
			// With default values, warning is 10 to 40 sec prior to storm
			$Hazard::StormTime = getSimTime() + ($Hazard::HazardTimer * 4) + ($Hazard::HazardTimer * getRandom(0,12));
			$Hazard::HazardStormDuration = getRandom($Hazard::HazardStormDurationMin,$Hazard::HazardStormDurationMax);
			messageAll('msgClient','\c2Warning: Meteor storm expected in %1 seconds!~wfx/misc/warning_beep.wav',mFloor(($Hazard::StormTime - getSimTime()) / 1000));
			$Hazard::StormTime = $Hazard::StormTime - 10; // fix
		}
	}
	else {
		if ($Hazard::StormTime < getSimTime() && $Hazard::StormActive != true) {
			$Hazard::StormTime = getSimTime();
			$Hazard::StormActive = true;
			messageAll('msgClient','\c2Warning: Meteor storm imminent!~wfx/misc/red_alert.wav');
			messageAll('msgClient','~wvoice/Training/Any/ANY.prompt0%1.WAV',getRandom(1,7));
		}
		if ($Hazard::StormTime + $Hazard::HazardStormDuration < getSimTime()) {
			$Hazard::StormActive = false;
			$Hazard::StormTime = "";
			messageAll('msgClient','\c2Meteor storm passing.');
    			DropMapPulveriser();
		}
	}

	if ($Hazard::DropAddX $= "")
		$Hazard::DropAddX = $Hazard::BDropAddX;
	if ($Hazard::DropAddY $= "")
		$Hazard::DropAddY = $Hazard::BDropAddY;
	if ($Hazard::DropAddVariationLastTime $= "") // Don't randomize on first run
		$Hazard::DropAddVariationLastTime = getSimTime();

	if ($Hazard::DropAddVariationLastTime + $Hazard::DropAddVariationTime < getSimTime()) {
		$Hazard::DropAddVariationLastTime = getSimTime();
		$Hazard::DropAddX = $Hazard::BDropAddX + ((getRandom() * $Hazard::DropAddVariation) - ($Hazard::DropAddVariation / 2));
		$Hazard::DropAddY = $Hazard::BDropAddY + ((getRandom() * $Hazard::DropAddVariation) - ($Hazard::DropAddVariation / 2));
	}

	$Hazard::DropX = $Hazard::DropX + $Hazard::DropAddX;
	$Hazard::DropY = $Hazard::DropY + $Hazard::DropAddY;

	if (mAbs($Hazard::DropX) > 1) {
		$Hazard::DropX = 1 * lev($Hazard::DropX);
		$Hazard::DropAddX = -$Hazard::DropAddX;
	}

	if (mAbs($Hazard::DropY) > 1) {
		$Hazard::DropY = 1 * lev($Hazard::DropY);
		$Hazard::DropAddY = -$Hazard::DropAddY;
	}

	%x =  mCos(($Hazard::DropX * $Pi) + $Pi) * mSin(($Hazard::DropY * ($Pi / 2) + ($Pi / 2)) * $Hazard::MaxSlant);
	%y =  mSin(($Hazard::DropX * $Pi) + $Pi) * mSin(($Hazard::DropY * ($Pi / 2) + ($Pi / 2)) * $Hazard::MaxSlant);
	%z =  mCos(($Hazard::DropY * ($Pi / 2) + ($Pi / 2)) * $Hazard::MaxSlant);
	%dropVec = vectorScale(%x SPC %y SPC -%z,5);

	// Meteors
	// Players
	%count = ClientGroup.getCount();
	for(%i = 0; %i < %count; %i++) {
		%cl = ClientGroup.getObject(%i);
		if (isObject(%cl.player) && !%cl.isJailed) {
			%num = getRandom($Hazard::MeteorMin,$Hazard::MeteorMax);
			if (%num > 0)
				JTLMeteorStorm(%cl,0,$Hazard::MeteorRad,%num,400,600,0,0,0,0,0,0,vectorScale(%dropVec,0.975 + (getRandom() * 0.05)),1);
		}
	}
	// Generators
	%count = getWordCount($PowerList);
	for(%i = 0; %i < %count; %i++) {
		%obj = getWord($PowerList,%i);
		if (isObject(%obj)) {
			%num = getRandom($Hazard::MeteorMin,$Hazard::MeteorMax);
			if (%num > 0)
				JTLMeteorStorm(%obj,0,$Hazard::MeteorRad,%num,400,600,0,0,0,0,0,0,vectorScale(%dropVec,0.975 + (getRandom() * 0.05)),1);
		}
	}
	if ($Hazard::StormActive == true)
		schedule($Hazard::StormTimer,0,HazardThread,%thread);
	else
		schedule($Hazard::HazardTimer,0,HazardThread,%thread);
}
