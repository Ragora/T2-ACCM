// Ion run.
// -Object gets zapped with amout of charge.
// -Interal energy gets converted and added to charge.
// +If object is an conductor
//   -Object passes remaining charge onto enemies [High amount]
// -Object passes remaining charge onto conductors [Medium amount]
// +If object isn't a conductor
//   -Object passes remaining charge onto nearby objects [Low amount]
// +If object is an conductor
//   -Object vents remaining ion upwards if there's room.
// -Object Converts remaining charge into damage.

////////Main Ion globals/////////
$Ion::ThunderSound[0] = thunderCrash1;
$Ion::ThunderSound[1] = thunderCrash2;
$Ion::ThunderSound[2] = thunderCrash3;
$Ion::ThunderSound[3] = thunderCrash4;
$Ion::ThunderSoundCount = 4;
$Ion = 1;

$Ion::ConductorCharge = 0; // The amount of energy a conductor makes (extra)
$Ion::StopIon = 0; //Stops ion in it's tracks.
$Ion::Damage = 1;
$Ion::MaxIon = 50;

////////Ionstorm globals/////////

$IonStorm::Radius = 500; //Max distance a beam will hit from target.
$IonStorm::Height = 1000; //Height from which beams fire.
$IonStorm::PlayerSeek = 0.25; //Change a beam will target a player.

////////Main Ion Datablocks///////

datablock AudioProfile(IonFireSound) {
	filename  = "fx/misc/shield.wav";
	description = AudioClose3d;
	preload = true;
};

datablock ParticleData(PrebeamParticle) {
	dragCoefficient = 0;
	gravityCoefficient = -0.9;
	windCoefficient = 0;
	inheritedVelFactor = 0;
	constantAcceleration = 0;
	lifetimeMS = 12000;
	lifetimeVarianceMS = 6000;
	useInvAlpha = 0;
	spinRandomMin = 0;
	spinRandomMax = 0;
	textureName = "special/bluespark.PNG";
	times[0] = 0.75;
	times[1] = 2;
	colors[0] = "0.5 0.5 0.9 1";
	colors[1] = " 0 0 0 0";
	sizes[0] = 1;
	sizes[1] = 1;
};

datablock ParticleEmitterData(PrebeamEmitter) {
	ejectionPeriodMS = 45;
	periodVarianceMS = 10;
	ejectionVelocity = 2;
	velocityVariance = 2;
	ejectionOffset   = 8;
	thetaMin = 140;
	thetaMax = 160;
	phiReferenceVel = 0;
	phiVariance = 360;
	overrideAdvances = 0;
	orientParticles= 1;
	orientOnVelocity = 1;
	particles = "PrebeamParticle";
};

datablock ParticleData(ShockSparks) {
	dragCoefficient   = 1;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 0.2;
	constantAcceleration = 0.2;
	lifetimeMS      = 200;
	lifetimeVarianceMS  = 0;
	textureName     = "special/blueSpark";
	useInvAlpha = 0;

	spinRandomMin = -20;

	spinRandomMax = 20;

	colors[0]   = "0.8 0.8 1.0 1.0";
	colors[1]   = "0.8 0.8 1.0 0.5";
	colors[2]   = "0.8 0.8 1.0 0.0";
	sizes[0]   = 2.55;
	sizes[1]   = 2.65;
	sizes[2]   = 2.85;
	times[0]   = 0.0;
	times[1]   = 0.5;
	times[2]   = 1.0;

};

datablock ParticleEmitterData(ShockSparksEmitter) {
	ejectionPeriodMS = 5;
	periodVarianceMS = 0;
	ejectionVelocity = 20;
	velocityVariance = 15;
	ejectionOffset  = 1.0;
	thetaMin     = 0;
	thetaMax     = 50;
	phiReferenceVel = 0;
	phiVariance   = 360;
	overrideAdvances = false;
	orientParticles = true;
	//  lifetimeMS    = 100;
	particles = "ShockSparks";
};

datablock ParticleData(ShockFlareParticle) {
	dragCoeffiecient   = 0.0;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 0.0;

	lifetimeMS      = 500;
	lifetimeVarianceMS  = 0;

	spinRandomMin = 0.0;
	spinRandomMax = 0.0;
	windcoefficient = 0;
	textureName     = "skins/jetflare03";

	colors[0]   = "0.3 0.3 1.0 0.9";
	colors[1]   = "0.3 0.3 1.0 0.5";
	colors[2]   = "0.3 0.3 1.0 0.9";
	colors[3]   = "0.3 0.3 1.0 0.5";

	sizes[0]   = 5;
	sizes[1]   = 5;
	sizes[2]   = 5;
	sizes[3]   = 5;

	times[0]   = 0.25;
	times[1]   = 0.25;
	times[2]   = 0.25;
	times[3]   = 1;
};

datablock ParticleEmitterData(ShockFlareEmitter) {
	lifetimeMS    = 10;
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;

	ejectionVelocity = 0.1;
	velocityVariance = 0.0;
	ejectionoffset = 0;
	thetaMin     = 0.0;
	thetaMax     = 0.0;

	orientParticles = false;
	orientOnVelocity = false;

	particles = "ShockFlareParticle";
};

datablock ParticleData(ShockFlareParticle2) {
	dragCoeffiecient   = 0.0;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 1.0;

	lifetimeMS      = 500;
	lifetimeVarianceMS  = 0;

	spinRandomMin = 0.0;
	spinRandomMax = 0.0;
	windcoefficient = 0;
	textureName     = "skins/jetflare03";

	colors[0]   = "0.3 0.3 1.0 0.9";
	colors[1]   = "0.3 0.3 1.0 0.5";
	colors[2]   = "0.3 0.3 1.0 0.9";
	colors[3]   = "0.3 0.3 1.0 0.5";

	sizes[0]   = 50;
	sizes[1]   = 50;
	sizes[2]   = 50;
	sizes[3]   = 50;

	times[0]   = 0.25;
	times[1]   = 0.25;
	times[2]   = 0.25;
	times[3]   = 1;
};

datablock ParticleEmitterData(ShockFlareEmitter2) {
	lifetimeMS    = 10;
	ejectionPeriodMS = 100;
	periodVarianceMS = 0;

	ejectionVelocity = 0.1;
	velocityVariance = 0.0;
	ejectionoffset = 0;
	thetaMin     = 0.0;
	thetaMax     = 0.0;

	orientParticles = false;
	orientOnVelocity = false;

	particles = "ShockFlareParticle2";
};

datablock ParticleData(InfParticle) {
	dragCoefficient   = 0;
	WindCoefficient = 0;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 1;
	constantAcceleration = 0;
	lifetimeMS      = 2000;
	lifetimeVarianceMS  = 0;
	textureName     = "special/lightning1frame2";
	useInvAlpha = 0;

	spinRandomMin = -800;

	spinRandomMax = 800;

	spinspeed = 50;
	colors[0]   = "0.8 0.8 1.0 1.0";
	colors[1]   = "0.8 0.8 1.0 1.0";
	colors[2]   = "0.8 0.8 1.0 0.0";
	sizes[0]   = 1;
	sizes[1]   = 3;
	sizes[2]   = 2;
	times[0]   = 0.0;
	times[1]   = 0.5;
	times[2]   = 1.0;
};

datablock ParticleEmitterData(InfEmitter) {
	ejectionPeriodMS = 50;
	periodVarianceMS = 0;
	ejectionVelocity = 0.5;
	velocityVariance = 1;
	ejectionOffset  = 0.5;
	thetaMin     = 0;
	thetaMax     = 180;
	phiReferenceVel = 0;
	phiVariance   = 360;
	overrideAdvances = false;
	orientParticles = false;
	//  lifetimeMS    = 100;
	particles = "InfParticle";
};

datablock ItemData(ShockLight0) : DeployedLight {
	lightType = "PulsingLight";
	lightColor= "0.5 0.5 1";
	lightTime = "50";
	lightRadius = "4";
};

datablock ItemData(ShockLight1) : DeployedLight {
	lightType = "PulsingLight";
	lightColor= "1 1 1";
	lightTime = "50";
	lightRadius = "3";
};

datablock ItemData(ShockLight2) : DeployedLight {
	//lightType = "PulsingLight";
	lightColor= "0.5 0.5 1";
	//lightTime = "50";
	lightRadius = "2";
};

datablock ExplosionData(ShockExplosion) {
	//explosionShape = "energy_explosion.dts";
	soundProfile  = ShockLanceHitSound;

	emitter[0] = ShockFlareEmitter;
	emitter[1] = ShockSparksEmitter;
	particleDensity = 100;
	particleRadius = 2.50;
	faceViewer      = false;
};

datablock ExplosionData(ShockExplosion2) {
	explosionShape = "disc_explosion.dts";
	soundProfile  =  LightningHitSound;

	faceViewer   = true;

	sizes[0]   = "0.5 0.5 0.5";
	sizes[1]   = "0.3 0.3 0.3";
	sizes[2]   = "0.1 0.4 0.1";
	times[0]   = 0.0;
	times[1]   = 0.5;
	times[2]   = 1.0;

	emitter[0] = "InfEmitter";
	emitter[1] = ShockFlareEmitter;
	particleDensity = 500;
	particleRadius = 15;
	shakeCamera = true;
	camShakeFreq = "10.0 11.0 10.0";
	camShakeAmp = "20.0 20.0 20.0";
	camShakeDuration = 0.5;
	camShakeRadius = 20.0;
};

datablock SniperProjectileData(ShockBeam) {
	directDamage    = 0;
	hasDamageRadius   = false;
	indirectDamage   = 0.0;
	damageRadius    = 0.0;
	velInheritFactor  = 1.0;
	//sound 	    = SniperRifleProjectileSound;
	sound  = IonFireSound;
	explosion      = "ShockExplosion";
	//splash       = SniperSplash;
	//directDamageType  = $DamageType::Lightning;

	maxRifleRange    = 2000;
	rifleHeadMultiplier = 1.3;
	beamColor      = "0.4 0.4 0.9";
	fadeTime      = 1.0;

	startBeamWidth = 1.0;
	endBeamWidth	   = 0.1;
	pulseBeamWidth  = 0.1;
	beamFlareAngle 	 = 45.0;
	minFlareSize    = 10.0;
	maxFlareSize    = 500.0;
	pulseSpeed     = 5;
	pulseLength     = 0.5;
	textureName[0]   = "special/flare";
	//textureName[1]   = "skins/beampulse";
	textureName[1] = "special/laserrip04";
	textureName[2] = "special/laserrip04";
	textureName[3] = "special/laserrip04";
	textureName[4] = "special/laserrip04";
	textureName[5] = "special/laserrip04";
	textureName[6] = "special/laserrip04";
	textureName[7] = "special/laserrip04";
	textureName[8] = "special/laserrip04";
	textureName[9] = "special/laserrip04";
	textureName[10] = "special/laserrip02";
	textureName[11] = "special/Shocklance_effect02";

	lightRadius     = 20.0;
	lightColor     = "0.0 0.0 5.0";

	emitter = ELFSparksEmitter;
};

datablock SniperProjectileData(ShockBeam2) :ShockBeam {
	hasDamageRadius   = true;
	indirectDamage   = 5.0;
	damageRadius    = 20.0;
	fadeTime      = 2.0;
	startBeamWidth = 8.0;
	endBeamWidth	   = 1;
	pulseBeamWidth  = 0.1;
	beamFlareAngle 	 = 30;
	minFlareSize    = 50.0;
	maxFlareSize    = 500.0;
	pulseSpeed     = 5;
	pulseLength     = 0.05;
	textureName[0]   = "special/flare";
	//textureName[1]   = "skins/beampulse";
	textureName[1] = "special/laserrip04";
	textureName[2] = "special/laserrip04";
	textureName[3] = "special/laserrip04";
	textureName[4] = "special/laserrip04";
	textureName[5] = "special/laserrip04";
	textureName[6] = "special/laserrip04";
	textureName[7] = "special/laserrip04";
	textureName[8] = "special/laserrip04";
	textureName[9] = "special/laserrip04";
	textureName[10] = "special/laserrip02";
	textureName[11] = "special/Shocklance_effect02";

	lightRadius     = 20.0;
	lightColor     = "0.0 0.0 1.0";
	lightRadius     = 20.0;
	lightColor     = "0.0 0.0 1.0";

	beamColor      = "0.5 0.5 0.8";
	maxRifleRange    = 5000;
	explosion      = "ShockExplosion2";
};

////////Main Ion functions///////

function ShapeBase::zap(%obj,%charge) {
	zap(%obj,%charge);
}

///What happens when an object has gotten zapped
function zap(%obj,%charge,%pos) {
	if (isObject(%obj)) {
		%obj.zapSched = "";
		%pos = %obj.getWorldboxCenter();
		%Cco = 1; //All interal energy gets converted to charge.
		%energy = %obj.getEnergyLevel() * %Cco + %obj.getCharge();
		%obj.setEnergyLevel(%obj.getEnergyLevel() * (1 - %Cco));

		if (isConductor(%obj)) {
			%energy = %energy + $Ion::ConductorCharge;
			%obj.smartIon = 1;
			%conductor = 1;
		}
	}

	%charge = %charge + %energy;
	if ($Ion::StopIon || ShockGroup.getCount > $Ion::MaxIon)
		return "";
	if (%charge > 0 && %conductor)
		%charge = findPassEnemy(%charge,%obj);
	if (%charge > 0)
		%charge = findPassCond(%pos,%charge,%obj);
	if (%charge > 0 && !%conductor)
		%charge = findPassObj(%pos,%charge,%obj);
	if (%obj)
		%obj.afterPass(%charge);

//	totalcharge(%pos,100);
}

///// What happens after the object spread his charge
function ShapeBase::afterPass(%obj,%chargeLeft) {
	%obj.zapped = 0;
	%objClass = %obj.getDatablock().classname;
	%maxCharge = %obj.getSizeFactor("maxCharge");

	if (isConductor(%obj) && %chargeLeft > 100) {
		%dir = realVec(%obj,"0 0 1");
		%pos = %obj.getWorldBoxCenter();

		%erres = containerRayCast(%pos,vectorAdd(%pos,vectorScale(%dir,2000)),$TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType,%obj);
		if (!%erres)
			%dist = 2000;
		else
		%dist = vectorDist(%pos,getWords(%erres,1,3));

		if (%dist>50) {
			%p = discharge2(vectorAdd(%pos,vectorScale(%dir,2)),%dir,%dist);
			if (%chargeLeft>0)
			%p.setEnergyPercentage(limit(%chargeLeft / %maxCharge,0.5,1));
			addToShock(%p);
			%p.schedule(1000,"delete");
			%dump = 300;
		}
	}
	if (!isConductor(%obj))
		%obj.smartIon = 0;

	%chargeLeft = %chargeLeft - %dump;
	%totalDamage = limit(%chargeLeft - %maxCharge,0);
	if (%totalDamage > 0) {
		if ($Ion::Damage)
			%obj.getDataBlock().schedule(500,"damageObject",%obj,0,pos(%obj),%totalDamage / 100,$DamageType::Lightning);
//		radiusExplosion(%obj,%obj.getWorldboxCenter(),(%totalDamage*%maxCharge) / 50000,(%totalDamage * %maxCharge) / 5000,3000,%obj,$DamageType::Lightning);
	}
	%obj.charge = limit(%chargeLeft - %totalDamage,0);
	%obj.chargeTime = getSimTime();
}

///Look for other objects to spread charge to
function findPassObj(%pos,%charge,%obj) {
	if (%charge > 0)
		%maxRadius = limit(%charge / 2,0,100);

	initContainerRadiusSearch(%pos,%maxRadius,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType);
	%startCharge = %charge;
	while ((%damage = containerSearchNext()) != 0 && !%nopass && %charge > %startCharge * 0.25) {
		// Pass a certain amount.
		%maxPass = %startCharge * 0.25;
		// Pass charge to suitable reciever
		%left = %damage.passCharge(%pos,%maxPass,%obj);
		%charge = %charge - (%maxPass - %left);
		if (%charge != %startCharge)
			%count = %count + 1;
		if (%count > 4) //Only pass to 4 object at a time (lag issues);
			return %charge;
	}
	return %charge;
}

///Look for enemy's to spread charge to
function findPassEnemy(%charge,%obj) {
	%pos = %obj.getWorldBoxCenter();
	%maxRadius = limit(%charge * 2,0,100);
	initContainerRadiusSearch(%pos,%maxRadius,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType);

	while ((%damage = containerSearchNext()) != 0 && !%nopass && %charge > 0) {
		if (%damage.team != %obj.team)
			%charge = %damage.passCharge(%pos,%charge,%obj);
		//Zap non owner connected objects.
		else if (%obj.getOwner().evil && (%damage.getOwner() != %obj.getOwner() && %damage.client != %obj.getOwner()))
			%charge = %damage.passCharge(%pos,%charge,%obj);
	}
	return %charge;
}

///Look for conductors to spread charge to
function findPassCond(%pos,%charge,%obj) {
	if (%charge > 0)
	%maxRadius = limit(%charge / 2,0,100);
	initContainerRadiusSearch(%pos,%maxRadius,$TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType);

	while ((%damage = containerSearchNext()) != 0 && !%nopass && %charge > 0) {
		// Pass a certain amount
		%maxPass = %charge * 0.9;
		// Pass charge to suitable reciever
		%left = %damage.passCond(%pos,%maxPass,%obj);
		%charge = %charge - (%maxPass - %left);
	}
	return %charge;
}

function GameBase::isEnemy(%obj,%target) {
	//echo("isenemy");
	if (!isObject(%obj) || !isObject(%target))
		return "";
	if (%obj.team != %target.team) ///Other teams default to enemy.
		return 1;
	if (%obj.getOwner().evil) {
		if (%obj.getOwner() != %target.client && %obj.getOwner() != %target.getOwner())
			return 1;
	}
	return "";
}

///Pass charge to non conductors
function GameBase::passCharge(%obj,%pos,%charge,%emit) {
	// console spam fix
	if (isObject(%emit))
		%emitIsEnemy = %emit.isEnemy(%obj);
	else
		%emitIsEnemy = 0;
	if (((getSimtime() - %obj.zapTime < 5000) || %obj.getEnergyPct() < 0.25 || GetRandom() * 10 < 1) && !%emitIsEnemy)
		return %charge;

	if (((GetSimtime() - %obj.zapTime < 500)) && %emitIsEnemy)
	return %charge;

	if (%obj.zapSched || %obj == %emit)
		return %charge;

	//If I was just zapped by an evil object don't zap it's allies back.. >:)
	if (%emit.lastDamagedBy.getOwner().evil && (%emit.lastDamagedBy.getOwner() == %obj.getOwner() || %emit.lastDamagedBy.getOwner() == %obj.client))
		return %charge;

	if (isConductor(%emit))
		%maxRange = %charge * 2;
	else {
		if (%obj.team != %emit.team && %emit.smartIon) //Only pass to team members
			return %charge;
		if (%charge > 0) {
			%maxRange = %charge / 2;
			%miss = mPow(%basicDist,0.5) + %charge / 500;
		}
	}
	%basicDist = vectorDist(%pos,%obj.getWorldBoxCenter());

	if (!(%result = zapLos(%pos,%obj,%miss,%emit)))
		return %charge;

	%firePos = getWords(%result,1,3);
	%hitPos = getWords(%result,4,6);

	%dist = vectorDist(%firePos,%hitPos);
	%dir = vectorNormalize(vectorSub(%hitPos,%firePos));

	if ((%dist > %maxRange || getWord(%return,0) == 1)) {
		%passCharge = 0;
		%loss = limit(mPow(%dist,3),0,50);
	}
	else {
		%passCharge = limit(%charge - mPow(%dist,2),1,%charge);
		%loss = 0; // mPow(%dist,2);
	}

	%passCharge = limit(%passCharge,0,%charge);
	%charge = limit(%charge - (%passCharge + %loss),0);

	if (%dist > %maxRange) {
		%vis = 1;
		%p = discharge2(%firePos,%dir,%dist);
	}
	else {
		%vis = limit(mPow(%passCharge,1 / 3) / 10,0,1);
		%p = discharge(%firePos,%dir);
		createLifeLight(%hitPos,1,1000);

		if (%passCharge) {
			%obj.lastDamagedBy = %emit;
			%obj.smartIon = %emit.smartIon; //Ion remains smart
			%obj.setZap(%passCharge,%hitPos);
		}
	}
	// TODO - 100% always, is this right?
	%vis = 1;
	%p.setEnergyPercentage(%vis);
	addToShock(%p);
	%p.schedule(1000,"delete");

	return %charge;
}

///Passes the charge to the given conductor
function GameBase::passCond(%obj,%pos,%charge,%emit) {
	if (%emit)
		%emitClass = %obj.getDatablock().classname;
	if (!isConductor(%obj))
		return %charge;
	if (%obj.zapSched && getRandom() * 10 > 2)
		return %charge;
	if ((getSimTime() - %obj.zapTime < 1000 && isConductor(%emit)) || %obj == %emit)
		return %charge;
	// Absorb team ion only
	if (isObject(%emit) && %obj.team != %emit.team)
		return %charge;
	//  Don't absorb charge from non allied stuff.
	if (%obj.getOwner().evil && (%obj.getOwner() != %emit.getOwner() && %emit.client != %obj.getOwner()))
		return %charge;

	%basicDist = vectorDist(%pos,%obj.getWorldBoxCenter());

	%miss = mPow(%basicDist,0.5) + %totalCharge / 100;

	if (!(%result = zapLos(%pos,%obj,%miss,%emit)))
		return %charge;

	%firePos = getWords(%result,1,3);
	%hitPos = getWords(%result,4,6);

	%dist = vectorDist(%firePos,%hitPos);
	%dir = vectorNormalize(vectorSub(%hitPos,%firePos));

	if (%dist > 200 && %charge > 1000) {
		%passCharge = 0;
		%loss = mPow(%dist,3);
	}
	else {
		%passCharge = limit(%charge - %dist,0,%charge);
		%loss = mPow(%dist,2);
	}

	%passCharge = limit(%passCharge,0,%charge);
	%charge = limit(%charge - (%passCharge + %loss),0);

	if (%dist > 200 && %charge > 1000) {
		%vis = 1;
		%p = discharge2(%firePos,%dir,%dist);
	}
	else {
		%vis = limit(mPow(%passCharge,1 / 3) / 10,0,1);
		%p = discharge(%firePos,%dir);
		createLifeLight(%hitPos,1,1000);

		if (%passCharge) {
			%obj.lastDamagedBy = %emit;
			%obj.setZap(%passCharge,%hitPos);
		}
	}
	// TODO - 100% always, is this right?
	%vis = 1;
	%p.setEnergyPercentage(%vis);
	addToShock(%p);
	%p.schedule(1000,"delete");

	return %charge;
}

///Put the charge on the target
function GameBase::setZap(%obj,%charge,%hitPos) {
	%group = nameToID(ShockGroup);
	if (!%obj.zapSched && !(%group > 0 && %group.getCount() > 50)) {
		%lagTime = ShockGroup.getCount() * 1000 + (getRandom() + 1);
		%energyTime = %charge * 100 + (getRandom() + 1);
		%otherTime = getRandom()* 0.5 + 1;
		%condTime = 1 + isConductor(%obj) * 5 + isPlayer(%obj) * 50;
		%time = limit(((%lagtime + %energyTime) * %otherTime) / %condTime,0);
		%objClass = %obj.getDatablock().getName();

		if (%obj.client)
			%obj.emp(getSimTime() + limit(%time - 500,0,240000));
		else if ($MTC_Loaded == true) {
			if (%obj.isMTC()) {
				%obj.base.emp(limit(%time * 10,6000));
				%wasMTC = true;
			}
		}
		if (!%wasMTC && !%obj.client) {
			if ((getRandom()* ShockGroup.getCount()) < 50)
				createLifeEmitter(%hitPos,InfEmitter,limit(%time - 500,0,240000));
//				createLifeLight(%hitPos,"0",limit(%time - 500,0,240000));
		}
		%obj.zapTime = getSimTime() + %time;
		%obj.zapSched = %obj.schedule(%time,"zap",0);
	}
	%obj.playShieldEffect("0 0 1");
	%obj.charge = %obj.getCharge() + %passCharge;
	%obj.chargeTime = getSimTime();
}

function createLifeLight(%pos,%type,%time) {
	%light = new Item() {
		datablock = ShockLight @ %type;
		static = true;
		position = %pos;
	};
	%light.schedule(%time,"delete");
}

///Checks to see if there's back and forth contact between the two
function zapLos(%pos,%target,%miss,%obj) {
	%vec = getRandom() * 2 - 1 SPC GetRandom() * 2 - 1 SPC GetRandom() * 2 - 1;
	%dest = %target.getEdge(%vec);
	%res = containerRayCast(%dest,%pos,$TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType | $TypeMasks::VehicleObjectType,%target);

	if (%res != %obj && %obj)
		return "";
	else if (!%res)
		%firePos = %pos;
	else
		%firePos = getWords(%res,1,3);

	%dir = vectorMiss(vectorNormalize(vectorSub(%dest,%firepos)),%miss);
	%res2 = containerRayCast(%firePos,vectorAdd(%firePos,vectorScale(%dir,2000)),$TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticObjectType,%obj);

	if (!%res2)
		%hitPos = vectorAdd(%firePos,vectorScale(%dir,2000));
	else
		%hitPos = getWords(%res2,1,3);

	if (%res2 != %target)
		return 1 SPC %firePos SPC %hitPos;
	else
		return 2 SPC %firePos SPC %hitPos;
}

///Returns the current charge
function ShapeBase::getCharge(%obj) {
	%oldCharge = %obj.charge;
	%halfTime = 5 * 60 * 1000; //5 minutes before the charges halves
	%timePassed = limit((getSimTime() - %obj.chargeTime),100) / %halfTime;
	return %oldCharge * mPow(0.5,%timePassed);
}

///Returns the totalCharge at an radius around an location
function totalCharge(%pos,%radius) {
	initContainerRadiusSearch(%pos,%radius,$TypeMasks::PlayerObjectType | $TypeMasks::StaticShapeObjectType);
	while ((%damage = containerSearchNext()) != 0)
		%total = %total + %damage.getCharge();
	return %total;
}

///Returns the physical statistics of an object
function ShapeBase::getSizeFactor(%obj,%type) {
	%objClass = %obj.getDatablock().classname;
	//[[Physical factors]]
	%factor1 = mPow(%obj.getVolume(),1 / 3) / 2; // Normalized to players
	%factor2 = %obj.getMaxDamage(); //Object Density
	%factor3 = VectorDot(%obj.getSurface(),"2 2 2"); //Object's total surface
	//[[Energy factors]]
	%factor3 = %obj.getMaxEnergy() / 100; //Energy Capacity
	%factor4 = %obj.getDatablock().rechargeRate; //Energy management
	//[[Object specific]]
	%factor5 = isConductor(%obj); //Sensor absorbtion
	%factor6 = %objClass $= "armor"; //Player living tissue.
	%factor7 = %obj.powerRadius / 100; //Energy production

	if (%type $= "maxCharge")
		return (%factor1 * %factor2) * 100 + (%factor3 * %factor4) * 100 + %factor5 * 2000 - %factor6 * 100 + %factor7 * 100;
}

///Retuns objects who will absorb charge (conductors) and return it to enemies.
	function isConductor(%obj) {
	if (isObject(%obj)) {
		if (%obj.getDataBlock().className $= "sensor")
			return 1;
		else if (%obj.getDataBlock().className $= "energizer")
			return 1;
	}
	return "";
	}

////////////////////////////////////////////

/// Standard ion beam
function discharge(%pos,%vec) {
	%p = new SniperProjectile() {
		dataBlock = ShockBeam;
		initialDirection = %vec;
		initialPosition = %pos;
	};
	serverPlay3D(%pos,"IonFireSound");
	createLifeLight(%pos,2,500);
	createLifeEmitter(%pos,ShockFlareEmitter,450);
	return %p;
}

/// Large ion beam
function discharge2(%pos,%vec,%dist,%obj) {
	if (!%dist) {
		%res = containerRayCast(%pos,vectorAdd(%pos,vectorScale(%vec,2000)),$TypeMasks::PlayerObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType,%obj);
		if (%res)
			%hitloc = vectorAdd(getWords(%res,1,3),vectorScale(%dir,-1));
		else
			%hitLoc = vectorAdd(%pos,vectorScale(%vec,2000));
	}
	else
		%hitLoc = vectorAdd(%pos,vectorScale(%vec,%dist));

	zap(0,200,%hitLoc);

	if (getRandom()* 10 < 10 )
		schedule(1000,0,"Serverplay3D",$Ion::ThunderSound[mFloor(getRandom() * $Ion::ThunderSoundCount)],%hitLoc);

//	radiusExplosion(0,vectorAdd(%hitLoc,vectorScale(%vec,-2)),5,0.25,5000,0,$DamageType::Lightning);

	%p = new SniperProjectile() {
		dataBlock = ShockBeam2;
		initialDirection = %vec;
		initialPosition = %pos;
	};
	createLifeLight(%pos,1,500);
	createLifeEmitter(%pos,ShockFlareEmitter2,750);
	Serverplay3D(LightningHitSound,%pos);
	return %p;
}

///Failed Elf beam experiment
function discharge3(%pos,%vec,%target) {
	%pos = vectorAdd(%pos,"0 0 4");
	%vec = vectorMiss(vectorNormalize(vectorSub(pos(%target),%pos)),100);
	%up = vectorCross(%vec,vectorCross("0 0 1",%vec));
	%left = vectorCross(%vec,%up);

	%rot = "0 0 1 3.14";

	%emitter = new StaticShape() {
		position = %pos;
		rotation = %rot;
		datablock = "LightningTarget";
	};

//	echo(%target);

	//ElfProjectile()
	%p = new ElfProjectile() {
		dataBlock = BasicElf;
		initialDirection = %vec;
		initialPosition = %pos;
		sourceObject = %emitter;
		damageFactor = 1;
		sourceSlot = 0;
		targetObject= %target;
	};
//	%p.setEnergyLevel(1);
	%emitter.setRotation(fullRot(%up,%left));
	%emitter.schedule(5000,"delete");
	%p.schedule(5000,"delete");
	return discharge(%pos,%vec);
}

///Adds the beams to the ShockGroup for lag issues.
function addToShock(%obj) {
	%group = nameToID("MissionCleanup/ShockGroup");
	if (%group <= 0) {
		%group = new SimGroup("ShockGroup");
		MissionCleanup.add(%group);
	}
	%group.add(%obj);
}

//Should be the effect that happens to moving objects when zapped.
function GameBase::zapLight(%obj,%time) {
	return "";
	// Aparently only 1 light can be mounted to an object at a time.. odd.
	if (%obj.turret && %disabled) {
		%obj.turret.mountImage("zapLight2",3,false);
		%obj.turret.schedule(%time,"unmountImage",3);
	}
	else if (%obj.client) {
		%obj.mountImage("zapLight2",3,false);
		%obj.schedule(%time,"unmountImage",3);
//		%deplObj.playThread($PowerThread,"Power");
	}
}

function Player::emp(%obj,%time) {
	cancel(%obj.empSched);

	if (isObject(%obj.zap))
		%obj.zap.setTransform(%obj.getTransform());
	else
		%obj.zapObject();
	%obj.setEnergylevel(0);
	if (%time > getSimTime() && (getSimTime() - %time < 240000))
		%obj.empSched = %obj.schedule(510,"emp",%time);
	else {
		%obj.stopZap();
		%obj.zap2Object();
		%obj.schedule(500,"stopZap");
	}
}

///////////////// IonStorm Functions //////////////////

///Creates ionstorm with a beam every %repeat time period for %times times.
function ionStorm(%times,%repeat) {
	cancel($IonStorm);
	ionStormBlast();
	if (%repeat < 1000)
		%repeat = 1000;
	%times = %times - 1;
	if (%times > 0)
		$IonStorm = schedule(%repeat,0,"Ionstorm",%times,%repeat);
}

///A large beam from the air.
function ionStormBlast(%target,%radius) {
//	echo("ionStormBlast");
	if (isObject(%target.player))
		%pos = pos(%target.player);
	else if (isObject(%target))
		%pos = pos(%target);
	else {
		if (getRandom() < $IonStorm::PlayerSeek)
			%pos = pos(randomPlayer());
		else
			%pos = pos(randomDeployable());
	}

	if (%radius)
		%dist = getRandom() * %radius;
	else
		%dist = getRandom() * $IonStorm::Radius;

	%angle = getRandom() * 2 * $Pi;
	%loc = getTerrainHeight2(vectorAdd(mCos(%angle) * %dist SPC mSin(%angle) * %dist SPC "0",%pos));
	createLifeEmitter(%loc,PrebeamEmitter,5000);
	schedule(5000,0,"ionStormBeam",vectorAdd(%loc,"0 0" SPC $IonStorm::Height));
}

///The actual beam
function ionStormBeam(%loc) {
	%p = discharge2(%loc,"0 0 -1");
	%p.setEnergyPercentage(1);
	addToShock(%p);
	%p.schedule(1000,"delete");
}

/////////////////////////////////////////////
////////////////IONMISSILE///////////////////
/////////////////////////////////////////////

datablock ParticleData(IonJetParticle) {
	dragCoefficient      = 0.0;
	gravityCoefficient   = 0;
	inheritedVelFactor   = 0.2;
	constantAcceleration = 0.0;
	lifetimeMS           = 500;
	lifetimeVarianceMS   = 0;
	textureName          = "particleTest";
	colors[0]     = "0.4 0.4 0.9 1.0";
	colors[1]     = "0.5 0.65 1 1";
	sizes[0]      = 1.40;
	sizes[1]      = 1.15;
};

datablock ParticleEmitterData(IonJetEmitter) {
	ejectionPeriodMS = 3;
	periodVarianceMS = 0;
	ejectionVelocity = 6.0;
	velocityVariance = 5.0;
	ejectionOffset   = 0.0;
	overrideAdvances = false;
	thetaMin         = 110;
	thetaMax         = 180;
	phiReferenceVel  = 0;
	phiVariance      = 360;
	particles = "IonJetParticle";
};

datablock SeekerProjectileData(IonMissile):ShoulderMissile {
	hasDamageRadius     = true;
	indirectDamage      = 0.1;
	damageRadius        = 1.0;
	radiusDamageType    = $DamageType::Missile;
	kickBackStrength    = 5;
	explosion           = "ShockExplosion2";
	baseEmitter         = IonJetEmitter;
	delayEmitter        = ELFSparksEmitter;

	lifetimeMS          = 120000;
	muzzleVelocity      = 10.0;
	maxVelocity         = 30.0;
	turningSpeed        = 110.0;
	acceleration        = 20.0;

	hasLight    = true;
	lightRadius = 5.0;
	lightColor  = "0.5 0.5 1";
};

function IonMissile::onExplode(%data,%proj,%pos,%mod) {
	zap(0,200,%pos);
	Parent::onExplode(%data,%proj,%pos,%mod);
}
