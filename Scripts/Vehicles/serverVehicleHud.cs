//------------------------------------------------------------------------------
datablock EffectProfile(VehicleAppearEffect)
{
   effectname = "vehicles/inventory_pad_appear";
   minDistance = 5;
   maxDistance = 10;
};

datablock EffectProfile(ActivateVehiclePadEffect)
{
   effectname = "powered/vehicle_pad_on";
   minDistance = 20;
   maxDistance = 30;
};

datablock AudioProfile(VehicleAppearSound)
{
   filename    = "fx/vehicles/inventory_pad_appear.wav";
   description = AudioClosest3d;
   preload = true;
   effect = VehicleAppearEffect;
};

datablock AudioProfile(ActivateVehiclePadSound)
{
   filename = 	"fx/powered/vehicle_pad_on.wav";
   description = AudioClose3d;
   preload = true;
   effect = ActivateVehiclePadEffect;
};

datablock StationFXVehicleData( VehicleInvFX )
{
   lifetime = 6.0;

   glowTopHeight = 1.5;
   glowBottomHeight = 0.1;
   glowTopRadius = 12.5;
   glowBottomRadius = 12.0;
   numGlowSegments = 26;
   glowFadeTime = 3.25;

   armLightDelay = 2.3;
   armLightLifetime = 3.0;
   armLightFadeTime = 1.5;
   numArcSegments = 10.0;

   sphereColor = "0.1 0.1 0.5";
   spherePhiSegments = 13;
   sphereThetaSegments = 8;
   sphereRadius = 12.0;
   sphereScale = "1.05 1.05 0.85";

   glowNodeName = "GLOWFX";

   leftNodeName[0]   = "LFX1";
   leftNodeName[1]   = "LFX2";
   leftNodeName[2]   = "LFX3";
   leftNodeName[3]   = "LFX4";

   rightNodeName[0]  = "RFX1";
   rightNodeName[1]  = "RFX2";
   rightNodeName[2]  = "RFX3";
   rightNodeName[3]  = "RFX4";


   texture[0] = "special/stationGlow";
   texture[1] = "special/stationLight2";
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
function serverCmdBuyVehicle(%client, %blockName)
{
   %team = %client.getSensorGroup();
   if(vehicleCheck(%blockName, %team))
   {
      %station = %client.player.station.pad;
      if( (%station.ready) && (%station.station.vehicle[%blockName]) )
      {
         %trans = %station.getTransform();
         %pos = getWords(%trans, 0, 2);
         %matrix = VectorOrthoBasis(getWords(%trans, 3, 6));
         %yrot = getWords(%matrix, 3, 5);
         %p = vectorAdd(%pos,vectorScale(%yrot, -3));

         //%adjust = vectorMultiply(realVec(%station,"0 0 4"),"1 1 3");
	 //%adjustUp = getWord(%adjust,2);
	 //%adjust = getWords(%adjust,0,1) SPC ((%adjustUp * 0.5) + (mAbs(%adjustUp) * -0.5));
         %p =  VectorAdd(%p,RealVec(%station,"0 0 7"));

//         error(%blockName);
//         error(%blockName.spawnOffset);


         ///[Most]
         ///Updated Build code for rotatable vehicle pad.
         %p = vectorAdd(%p, RealVec(%station,VectorAdd(%blockName.spawnOffset,"0 0 1")));
         %forward = VectorCross(VectorCross("0 0 1",realvec(%station,"1 0 0")),"0 0 1");

         %rot = FullRot("0 0 1",%forward);
         %rrot = RotAdd(%rot,"0 0 1 3.14");
         //%rrot= %rot;
         %rot = getWords(%rrot, 0,2);
         %angle = getWord(%rrot, 3);
         //[Most]
         %mask = $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |
                 $TypeMasks::StationObjectType | $TypeMasks::TurretObjectType;
	      InitContainerRadiusSearch(%p, %blockName.checkRadius, %mask);

	      %clear = 1;
         for (%x = 0; (%obj = containerSearchNext()) != 0; %x++)
         {
            if((%obj.getType() & $TypeMasks::VehicleObjectType) && (%obj.getDataBlock().checkIfPlayersMounted(%obj)))
            {
               %clear = 0;
               break;
            }
            else
               if (%obj !=%station.station)
               %removeObjects[%x] = %obj;
         }
         if(%clear)
         {
            %fadeTime = 0;
            for(%i = 0; %i < %x; %i++)
            {
               if(%removeObjects[%i].getType() & $TypeMasks::PlayerObjectType)
               {
                  %pData = %removeObjects[%i].getDataBlock();
                  %pData.damageObject(%removeObjects[%i], 0, "0 0 0", 1000, $DamageType::VehicleSpawn);
               }
               else
               {
                  %removeObjects[%i].mountable = 0;
                  %removeObjects[%i].startFade( 1000, 0, true );
                  %removeObjects[%i].schedule(1001, "delete");
                  %fadeTime = 1500;
               }
            }
            schedule(%fadeTime, 0, "createVehicle", %client, %station, %blockName, %team , %p, %rot, %angle);
         }
         else
            MessageClient(%client, "", 'Can\'t create vehicle. A player is on the creation pad.');
      }
   }
}

function createVehicle(%client, %station, %blockName, %team , %pos, %rot, %angle)
{
   %obj = %blockName.create(%team);
   if(%obj)
   {
      %station.ready = false;
      %obj.team = %team;
      %obj.useCreateHeight(true);
      %obj.schedule(5500, "useCreateHeight", false);
      %obj.getDataBlock().isMountable(%obj, false);
      %obj.getDataBlock().schedule(6500, "isMountable", %obj, true);
      vehicleListAdd(%blockName, %obj);
      MissionCleanup.add(%obj);

      %turret = %obj.getMountNodeObject(10);
      if(%turret > 0)
      {
         %turret.setCloaked(true);
         %turret.schedule(4800, "setCloaked", false);
      }

      %obj.setCloaked(true);
      %obj.setTransform(%pos @ " " @ %rot @ " " @ %angle);

      %obj.schedule(3700, "playAudio", 0, VehicleAppearSound);
      %obj.schedule(4800, "setCloaked", false);

      if(%client.player.lastVehicle)
      {
         %client.player.lastVehicle.lastPilot = "";
         vehicleAbandonTimeOut(%client.player.lastVehicle);
         %client.player.lastVehicle = "";
      }
      %client.player.lastVehicle = %obj;
      %obj.lastPilot = %client.player;
      %station.playAudio($ActivateSound, ActivateVehiclePadSound);
      %ppos = VectorAdd(%station.getTransform(),RealVec(%station,"0 0 2"));
      if (%station.getDatablock().getName() $= "DeployableVehiclePad")
         {
         %station.playThread($ActivateThread,"activate2");
         %up = realvec(%station,"0 0 1");
         %forward = realvec(%station,"1 0 0");
         %p1 = CreateEmitter(%ppos,DVPADE);
         %p2 = CreateEmitter(%ppos,DVPADE);
         %p1.setRotation(FullRot(%up,%forward));
         %p2.setRotation(FullRot(VectorScale(%up,-1),%forward));
         %p1.schedule(5000,"delete");
         %p2.schedule(5000,"delete");
         }
      else if (%station.getDatablock().getName() $= "DeployableVehiclePad2")
         {
         %station.playThread($ActivateThread,"activate");
         %up = realvec(%station,"0 0 1");
         %forward = realvec(%station,"1 0 0");
         %p1 = CreateEmitter(%ppos,DVPADE);
         %p2 = CreateEmitter(%ppos,DVPADE);
         %p1.setRotation(FullRot(%up,%forward));
         %p2.setRotation(FullRot(VectorScale(%up,-1),%forward));
         %p1.schedule(5000,"delete");
         %p2.schedule(5000,"delete");
         }
      else
         {
         %station.playThread($ActivateThread,"activate2");
      // play the FX
      %fx = new StationFXVehicle()
      {
         dataBlock = VehicleInvFX;
         stationObject = %station;
      };
         }
//[[CHANGE]]!! If player is telebuying.. put him incontrol...
      if ( (%client.isVehicleTeleportEnabled()) && (!%client.telebuy))
         %obj.getDataBlock().schedule(5000, "mountDriver", %obj, %client.player);
      else
         {
         if(%obj.getDataBlock().canControl)
           {
           //serverCmdResetControlObject(%client);
           %client.setControlObject(%obj);
           commandToClient(%client, 'ControlObjectResponse', true, getControlObjectType(%obj,%client.player));
           %obj.clientControl = %client;
           }
         }
//[[End CHANGE]]
   }
   if(%obj.getTarget() != -1)
      setTargetSensorGroup(%obj.getTarget(), %client.getSensorGroup());
   // We are now closing the vehicle hud when you buy a vehicle, making the following call
   // unnecessary (and it breaks stuff, too!)
   //VehicleHud.updateHud(%client, 'vehicleHud');
}

//------------------------------------------------------------------------------
function VehicleData::mountDriver(%data, %obj, %player)
{
   if(isObject(%obj) && %obj.getDamageState() !$= "Destroyed")
   {
      %player.startFade(1000, 0, true);
      schedule(1000, 0, "testVehicleForMount", %player, %obj);
      %player.schedule(1500,"startFade",1000, 0, false);
   }
}

function testVehicleForMount(%player, %obj)
{
   if(isObject(%obj) && %obj.getDamageState() !$= "Destroyed")
      %player.getDataBlock().onCollision(%player, %obj, 0);
}


//------------------------------------------------------------------------------
function VehicleData::checkIfPlayersMounted(%data, %obj)
{
   for(%i = 0; %i < %obj.getDatablock().numMountPoints; %i++)
      if (%obj.getMountNodeObject(%i))
         return true;
   return false;
}

//------------------------------------------------------------------------------
function VehicleData::isMountable(%data, %obj, %val)
{
   %obj.mountable = %val;
}

//------------------------------------------------------------------------------
function vehicleCheck(%blockName, %team)
{
   if(($VehicleMax[%blockName] - $VehicleTotalCount[%team, %blockName]) > 0)
      return true;
//   else
//   {
//      for(%i = 0; %i < $VehicleMax[%blockName]; %i++)
//      {
//         %obj = $VehicleInField[%blockName, %i];
//         if(%obj.abandon)
//         {
//            vehicleListRemove(%blockName, %obj);
//            %obj.delete();
//            return true;
//         }
//      }
//   }
   return false;
}

//------------------------------------------------------------------------------
function VehicleHud::updateHud( %obj, %client, %tag ) {
	%client.vehInvTag = %tag;
	%client.vehInvPage = "";
 if (%client.usedVehHud != 1) {
		bottomPrint(%client, "Cycle weapons to view more vehicles.", 5, 1);
		%client.usedVehHud = 1;
	}
	cycleVehicleHud(%obj, %client);
}

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------

function cycleVehicleHud(%obj, %client,%data) {
	%tag = %client.vehInvTag;
	%page = %client.vehInvPage;
	if (%page $= "")
		%page = 0;
	else {
		if (%data $= "prev")
			%page--;
		else
			%page++;
	}
	%count = %client.player.station.lastCount;
	VehicleHud::clearHud( %obj, %client, %tag, %count );
	%station = %client.player.station;
	%team = %client.getSensorGroup();
	%count = 0;
	%i = 0;

	if ( %station.vehicle[AWACS] ) {
		%vehicleSet[AWACS] = %i;
		%i++;
	}
    if ( %station.vehicle[HawkFlyer] ) {
		%vehicleSet[HawkFlyer] = %i;
		%i++;
	}
    if ( %station.vehicle[scoutFlyer] )  {
		%vehicleSet[scoutFlyer] = %i;
		%i++;
	}
	if ( %station.vehicle[StrikeFlyer] ) {
		%vehicleSet[StrikeFlyer] = %i;
		%i++;
	}
	if ( %station.vehicle[SuperiorityFighter] ) {
		%vehicleSet[SuperiorityFighter] = %i;
		%i++;
	}
	if ( %station.vehicle[helicopter] ) {
		%vehicleSet[helicopter] = %i;
		%i++;
	}
	if ( %station.vehicle[bomberFlyer] ) {
		%vehicleSet[bomberFlyer] = %i;
		%i++;
	}
	if ( %station.vehicle[HeavyTank] ) {
		%vehicleSet[HeavyTank] = %i;
		%i++;
	}
	if ( %station.vehicle[Personelboat] ) {
		%vehicleSet[Personelboat] = %i;
		%i++;
	}
	if ( %station.vehicle[boat] ) {
		%vehicleSet[boat] = %i;
		%i++;
	}
	if ( %station.vehicle[Sub] ) {
		%vehicleSet[Sub] = %i;
		%i++;
	}
	if ( %station.vehicle[scoutVehicle] ) {
		%vehicleSet[scoutVehicle] = %i;
		%i++;
	}
	if ( %station.vehicle[hapcFlyer] ) {
		%vehicleSet[hapcFlyer] = %i;
		%i++;
	}
	if ( %station.vehicle[gunship] ) {
		%vehicleSet[gunship] = %i;
		%i++;
	}
	if ( %station.vehicle[HeavyChopper] ) {
		%vehicleSet[HeavyChopper] = %i;
		%i++;
	}
	if ( %station.vehicle[CGTank] ) {
		%vehicleSet[CGTank] = %i;
		%i++;
	}
	if ( %station.vehicle[AssaultVehicle] ) {
		%vehicleSet[AssaultVehicle] = %i;
		%i++;
	}
	if ( %station.vehicle[mobileBaseVehicle] ) {
		%vehicleSet[mobileBaseVehicle] = %i;
		%i++;
	}
	if ( %station.vehicle[SuperScoutVehicle] && $Host::Purebuild == 1) {
		%vehicleSet[SuperScoutVehicle] = %i;
		%i++;
	}
	if ( %station.vehicle[SuperHAPCFlyer] && $Host::Purebuild == 1) {
		%vehicleSet[SuperHAPCFlyer] = %i;
		%i++;
	}
	if ( %station.vehicle[Artillery] ) {
		%vehicleSet[Artillery] = %i;
		%i++;
	}

	%totalPages = mCeil(%i / 6) - 1;
	if (%page < 0)
		%page = %totalPages;
	if (%page > %totalPages)
		%page = 0;
	%initPos = (%page * 6);
	%endPos =  %initPos + 5;

    if ( checkVehSet(%vehicleSet[AWACS], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "AWACS", "", AWACS, $VehicleMax[AWACS] - $VehicleTotalCount[%team, AWACS] );
    %count++;
	}
    if ( checkVehSet(%vehicleSet[HawkFlyer], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "FC-13 Hawk Interceptor", "", HawkFlyer, $VehicleMax[HawkFlyer] - $VehicleTotalCount[%team, HawkFlyer] );
		%count++;
	}
    if ( checkVehSet(%vehicleSet[SuperScoutVehicle], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Super Grav Cycle", "", SuperScoutVehicle, $VehicleMax[SuperScoutVehicle] - $VehicleTotalCount[%team,SuperScoutVehicle] );
		%count++;
	}
	
	if ( checkVehSet(%vehicleSet[Superiorityfighter], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Tornado Superiority Fighter", "", Superiorityfighter, $VehicleMax[Superiorityfighter] - $VehicleTotalCount[%team, Superiorityfighter] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[scoutFlyer], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "F39 Raptor II Interceptor", "", ScoutFlyer, $VehicleMax[ScoutFlyer] - $VehicleTotalCount[%team, ScoutFlyer] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[StrikeFlyer], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "F41 Airwing Strike Fighter", "", StrikeFlyer, $VehicleMax[StrikeFlyer] - $VehicleTotalCount[%team, StrikeFlyer] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[helicopter], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "WhiteHorse Assault Chopper", "", helicopter, $VehicleMax[helicopter] - $VehicleTotalCount[%team, helicopter] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[bomberFlyer], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "B-34 Bomber", "", BomberFlyer, $VehicleMax[BomberFlyer] - $VehicleTotalCount[%team, BomberFlyer] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[HeavyTank], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "M3A2 Faustes Assualt Tank", "", HeavyTank, $VehicleMax[HeavyTank] - $VehicleTotalCount[%team, HeavyTank] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[Personelboat], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Grandens Transport Boat", "", Personelboat, $VehicleMax[Personelboat] - $VehicleTotalCount[%team, Personelboat] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[boat], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Star II Heavy GunBoat", "", boat, $VehicleMax[boat] - $VehicleTotalCount[%team, boat] );
  %count++;
	}
	if ( checkVehSet(%vehicleSet[sub], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Darwine IV Submarine", "", sub, $VehicleMax[sub] - $VehicleTotalCount[%team, sub] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[scoutVehicle], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "MK II WildCat Grav Cycle", "", scoutVehicle, $VehicleMax[scoutVehicle] - $VehicleTotalCount[%team,scoutVehicle] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[hapcFlyer], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "HVC Golem Heavy Transport", "", HAPCFlyer, $VehicleMax[HAPCFlyer] - $VehicleTotalCount[%team, HAPCFlyer] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[gunship], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "AC-290 Saber Gunship", "", gunship, $VehicleMax[gunship] - $VehicleTotalCount[%team, gunship] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[HeavyChopper], %initPos)) {
  messageClient( %client, 'SetLineHud', "", %tag, %count, "Eagle VII Transport Chopper", "", HeavyChopper, $VehicleMax[HeavyChopper] - $VehicleTotalCount[%team, HeavyChopper] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[CGTank], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Banshee 50mm Chaingun Tank", "", CGTank, $VehicleMax[CGTank] - $VehicleTotalCount[%team, CGTank] );
  %count++;
	}
	if ( checkVehSet(%vehicleSet[AssaultVehicle], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "M4A1 Wolf Light Tank", "", AssaultVehicle, $VehicleMax[AssaultVehicle] - $VehicleTotalCount[%team, AssaultVehicle] );
		%count++;
	}
	if ( checkVehSet(%vehicleSet[mobileBaseVehicle], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Jericho MPB", "", MobileBaseVehicle, $VehicleMax[MobileBaseVehicle] - $VehicleTotalCount[%team, MobileBaseVehicle] );
  %count++;
	}
	if ( checkVehSet(%vehicleSet[Artillery], %initPos)) {
		messageClient( %client, 'SetLineHud', "", %tag, %count, "Grendel Heavy Artillery", "", Artillery, $VehicleMax[Artillery] - $VehicleTotalCount[%team, Artillery] );
		%count++;
	}

	%station.lastCount = %count;
	%client.vehInvPage = %page;
}

//------------------------------------------------------------------------------
function VehicleHud::clearHud( %obj, %client, %tag, %count ) {
	for ( %i = 0; %i < %count; %i++ )
		messageClient( %client, 'RemoveLineHud', "", %tag, %i );
}

//------------------------------------------------------------------------------
function checkVehSet(%obj, %initpos) {
	if ((%obj !$= "") && (%obj >= %initpos) && (%obj <= (%initpos + 5)))
		return true;
	else
		return false;
}

//------------------------------------------------------------------------------
function serverCmdEnableVehicleTeleport( %client, %enabled )
{
   %client.setVehicleTeleportEnabled( %enabled );
}
