//--------------------------------------------------------------------------
// Force fields:
//
//  accept the following commands:
//    open()
//    close()
//
//--------------------------------------------------------------------------


datablock ForceFieldBareData(defaultForceFieldBare)
{
   fadeMS           = 1000;
   baseTranslucency = 0.30;
   powerOffTranslucency = 0.0;
   teamPermiable    = false;
   otherPermiable   = false;
   color            = "0.0 0.55 0.99";
   powerOffColor    = "0.0 0.0 0.0";
   targetNameTag    = 'Force Field';
   targetTypeTag    = 'ForceField';

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};


datablock ForceFieldBareData(defaultTeamSlowFieldBare)
{
   fadeMS           = 1000;
   baseTranslucency = 0.3;
   powerOffTranslucency = 0.0;
   teamPermiable    = true;
   otherPermiable   = false;
   color            = "0.28 0.89 0.31";
   powerOffColor    = "0.0 0.0 0.0";
   targetTypeTag    = 'ForceField';

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};

datablock ForceFieldBareData(defaultAllSlowFieldBare)
{
   fadeMS           = 1000;
   baseTranslucency = 0.30;
   powerOffTranslucency = 0.0;
   teamPermiable    = true;
   otherPermiable   = true;
   color            = "1.0 0.4 0.0";
   powerOffColor    = "0.0 0.0 0.0";
   targetTypeTag    = 'ForceField';

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};

datablock ForceFieldBareData(defaultNoTeamSlowFieldBare)
{
   fadeMS           = 1000;
   baseTranslucency = 0.30;
   powerOffTranslucency = 0.0;
   teamPermiable    = false;
   otherPermiable   = true;
   color            = "1.0 0.0 0.0";
   powerOffColor    = "0.0 0.0 0.0";
   targetTypeTag    = 'ForceField';

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};

datablock ForceFieldBareData(defaultSolidFieldBare)
{
   fadeMS           = 1000;
   baseTranslucency = 0.30;
   powerOffTranslucency = 0.0;
   teamPermiable    = false;
   otherPermiable   = false;
   color            = "1.0 0.0 0.0";
   powerOffColor    = "0.0 0.0 0.0";
   targetTypeTag    = 'ForceField';

   texture[0] = "skins/forcef1";
   texture[1] = "skins/forcef2";
   texture[2] = "skins/forcef3";
   texture[3] = "skins/forcef4";
   texture[4] = "skins/forcef5";

   framesPerSec = 10;
   numFrames = 5;
   scrollSpeed = 15;
   umapping = 1.0;
   vmapping = 0.15;
};


function ForceFieldBare::onTrigger(%this, %triggerId, %on)
{
   // Default behavior for a field:
   //  if triggered:   go to open state (last waypoint)
   //  if untriggered: go to closed state (first waypoint)

   if (%on == 1) {
      %this.triggerCount++;
   } else {
      if (%this.triggerCount > 0)
         %this.triggerCount--;
   }

   if (%this.triggerCount > 0) {
      %this.open();
   } else {
      %this.close();
   }
}

function ForceFieldBareData::gainPower(%data, %obj) {
	Parent::gainPower(%data, %obj);
	if (!shouldChangePowerState(%obj,true))
		return;
	%obj.lastState = true;
	if (%obj.realScale) {
		%obj.setScale(%obj.realScale);
		%obj.realScale = "";
		if (isObject(%obj.pzone))
			%obj.pzone.setTransform(%obj.getTransform());
	}
	%obj.close();
	// activate the field's physical zone
	if (isObject(%obj.pzone))
		%obj.pzone.activate();
//	%pzGroup = nameToID("MissionCleanup/PZones");
//	if(%pzGroup > 0) {
//		%ffp = -1;
//		for(%i = 0; %i < %pzGroup.getCount(); %i++) {
//			%pz = %pzGroup.getObject(%i);
//			if(%pz.ffield == %obj) {
//				%ffp = %pz;
//				break;
//			}
//		}
//		if(%ffp > 0) {
//			%ffp.activate();
		if( %data.getName() $= "defaultForceFieldBare" )
			killAllPlayersWithinZone( %data, %obj );
		else if( %data.getName() $= "defaultTeamSlowFieldBare" ) {
			%team = %obj.team;
			killAllPlayersWithinZone( %data, %obj, %team );
		}
		else if (getSubStr(%data.getName(),0,18) $= "DeployedForceField") {
			if (!%obj.notFirstPwr) {
				%obj.notFirstPwr = true;
				return;
			}
			else {
				%team = %obj.team;
				killAllPlayersWithinZone( %data, %obj, %team );
			}
		}
//	}
	//else
	//	error("No PZones group to search!");
}

function killAllPlayersWithinZone( %data, %obj, %team ) {
	%count = ClientGroup.getCount();
	for( %c = 0; %c < %count; %c++ ) {
		%client = ClientGroup.getObject(%c);
		if( isObject( %client.player ) ) {
			if( %forceField = %client.player.isInForceField() ) { // isInForceField() will return the id of the ff or zero
				if( %forceField == %obj ) {
					%client.player.FFZapped = true;
					%client.player.disableMove(true);
					for( %i = 0; %i < 10; %i++ ) {
						%client.player.schedule(%i * 200,play3d,ShockLanceHitSound);
						schedule(%i * 200,0,playPain,%client.player);
						%client.player.schedule(%i * 200,setActionThread,"Death" @ getRandom(10)+1);
					}
					%client.player.schedule(2000,blowup); // chunkOrama!
					%client.player.schedule(2000,scriptkill,$DamageType::ForceFieldPowerup);
				}
			}
		}
	}
}

function ForceFieldBareData::losePower(%data, %obj) {
	Parent::losePower(%data, %obj);
	if (!shouldChangePowerState(%obj,false))
		return;
	%obj.lastState = false;
	if (!%obj.realScale) {
		%obj.realScale = %obj.getScale();
		%obj.setScale("0.01 0.01 0.01");
		if (isObject(%obj.pzone))
			%obj.pzone.setTransform(%obj.getTransform());
	}
	%obj.open();
	// deactivate the field's physical zone
	if (isObject(%obj.pzone))
		%obj.pzone.deactivate();
//	%pzGroup = nameToID("MissionCleanup/PZones");
//	if(%pzGroup > 0) {
//		%ffp = -1;
//		for(%i = 0; %i < %pzGroup.getCount(); %i++) {
//			%pz = %pzGroup.getObject(%i);
//			if(%pz.ffield == %obj) {
//				%ffp = %pz;
//				break;
//			}
//		}
//		if(%ffp > 0) {
//			%ffp.deactivate();
//		}
//	}
	//else
	//	error("<No PZones group to search!>");
}

function ForceFieldBareData::onAdd(%data, %obj) {
	Parent::onAdd(%data, %obj);

	%velocityMod  = 0.1;
	%gravityMod   = 1.0;
	%appliedForce = "0 0 0";

	if (%obj.velocityMod !$= "")
		%velocityMod = %obj.velocityMod;
	if (%obj.gravityMod !$= "")
		%gravityMod = %obj.gravityMod;
	if (%obj.appliedForce !$= "")
		%appliedForce = %obj.appliedForce;

	%pz = new PhysicalZone() {
		position = %obj.position;
		rotation = %obj.rotation;
		scale    = %obj.scale;
		polyhedron = "0.000000 1.0000000 0.0000000 1.0000000 0.0000000 0.0000000 0.0000000 -1.0000000 0.0000000 0.0000000 0.0000000 1.0000000";
		velocityMod  = %velocityMod;
		gravityMod   = %gravityMod;
		appliedForce = %appliedForce;
		ffield = %obj;
	};

	%obj.pzone = %pz;

	%pzGroup = nameToID("MissionCleanup/PZones");
	if(%pzGroup <= 0) {
		%pzGroup = new SimGroup("PZones");
		MissionCleanup.add(%pzGroup);
	}
	%pzGroup.add(%pz);
}
