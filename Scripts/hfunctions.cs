function LightningStrike(%client,%delay) {
	if (%client.player)
		%pos = %client.player.getTransform();
	%one = getword(%pos, 0) SPC getword(%pos, 1) SPC getword(%pos, 2);
	%player = %client.player;
	%b = new StaticShape() {
		position = %pos;
		datablock = "LightningTarget";
	};
	schedule(%delay, 0, "actualstrike", %b);
}

function actualstrike(%obj) {
	%posr = %obj.getTransform();
	%pos = VectorAdd(%posr, "0 0 -20");
	%pos2 = VectorAdd(%posr, "0 0 -20");
	for (%i=0;%i<10;%i++) {
		%pos = VectorAdd(%pos, "0 0 20");
		%p[%i] = new Lightning() {
			scale = "1 1 1";
			position = %pos;
			rotation = "1 0 0 0";
			dataBlock = "DefaultStorm";
			strikesPerMinute = "120";
			strikeWidth = "1.0";
			chanceToHitTarget = "1.0";
			strikeRadius = "1";
			boltStartRadius = "10";
			color = "1.000000 1.000000 1.000000 1.000000";
			fadeColor = "0.300000 0.300000 1.000000 1.000000";
			useFog = "1";
		};
		%p[%i].schedule(1500, "delete");
	%p[%i].strikeObject(%player);
	}
	schedule(1000, 0, "LightningApplyDamage", %p, %pos, %pos2);
	if (%obj)
		%obj.schedule(1500, "delete");
}

function LightningWeaponImage::onFire(%data, %obj, %slot) {
	%range = 1000;
	%rot = getWords(%obj.getTransform(), 3, 6);
	%muzzlePos = %obj.getMuzzlePoint(%slot);
	%muzzleVec = %obj.getMuzzleVector(%slot);
	%endPos    = VectorAdd(%muzzlePos, VectorScale(%muzzleVec, %range));
	%damageMasks = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType |
			$TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType |
			$TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType |
			$TypeMasks::TerrainObjectType; //|$TypeMasks::InteriorObjectType;
	%hit = ContainerRayCast(%muzzlePos, %endPos, %damageMasks, %obj);
	if (%hit) {
		%posr = getWords(%hit, 1, 3);
		%pos = VectorAdd(%posr, "0 0 300");
		%pos2 = VectorAdd(%posr, "0 0 -20");
		%b = new StaticShape() {
			position = %pos2;
			datablock = "LightningTarget";
		};
		%p = new Lightning() {
			scale = "1 1 1";
			position = %pos;
			rotation = "1 0 0 0";
			dataBlock = "DefaultStorm";
			strikesPerMinute = "120";
			strikeWidth = "10.0";
			chanceToHitTarget = "1";
			strikeRadius = "10";
			boltStartRadius = "15";
			color = "1.000000 1.000000 1.000000 1.000000";
			fadeColor = "0.300000 0.300000 1.000000 1.000000";
			useFog = "1";
			sourceObject     = %obj;
			sourceSlot       = %slot;
			vehicleObject    = 0;
		};
		%p.strikeObject(%b);
		schedule(1000, 0, "LightningApplyDamage", %p, %pos, %pos2);
		%p.schedule(1500, "delete");
		%b.schedule(1500, "delete");
	}
}

function LightningApplyDamage(%p, %pos, %pos2) {
	%damageMasks = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType;
	%hit = ContainerRayCast(%pos, %pos2, %damageMasks, 1);
	if (%hit)
		%pos2 = getWords(%hit, 1, 3);
	%xy = getWords(%pos, 0, 1);
	%z1 = getWord(%pos, 2) - 5;
	%z2 = getWord(%pos2, 2) + 5;
	while (%z1 > %z2) {
		%pos = %xy SPC %z1;
		RadiusExplosion(%p, %pos, 40, 0.4, 0, %p.sourceObject, $DamageType::Lightning);
		%z1 -= 19;
	}
	%pos = %xy SPC %z1;
	RadiusExplosion(%p, %pos, 40, 0.4, 0, %p.sourceObject, $DamageType::Lightning);
}

datablock StaticShapeData(LightningTarget) {
	shapeFile = "turret_muzzlepoint.dts";
	targetNameTag = 'beacon';
	isInvincible = true;
	dynamicType = $TypeMasks::StaticObjectType;
};
