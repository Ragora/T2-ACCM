//==============================================================================
// 'Purge' Shield Generator - Version 1.3
// Made by Blnukem.
//------------------------------------------------------------------------------
// NOTES TO USERS:
// • Useful for protecting an area from zombies.
// • A large number of Zombie Demons or Lords can destroy the Purge easily.
// • Heavy maintenence is required to keep the Purge active for a long period of
// time, such as repairing the Generator constantly.
// • The Purge has an automatic maintenence system that works great if you're
// only fighting anything smaller than a Zombie Demon, but disables after a
// certain amount of damage, so you need constant maintenence.
//
// When the maintenence system is near to be disabled or when it's first
// activated, the Generator will signal an alarm.
//==============================================================================
// Lets set the amount of Purge Generators per team.
   $TeamDeployableMax[ShieldDeployable]         = 2;
   
//------------------------------------------------------------------------------

datablock EffectProfile(PurgeAlarmEffect)
{
   effectname = "Bonuses/upward_perppass2_quark";
   minDistance = 25.0;
   maxDistance = 50.0;
};
//------------------------------------------------------------------------------

datablock AudioProfile(PurgeAlarmSound)
{
   filename    = "fx/Bonuses/upward_perppass2_quark";
   description = AudioClosest3d;
   preload = true;
   effect = PurgeAlarmEffect;
};

//------------------------------------------------------------------------------

datablock StaticShapeData(DeployedShield) : StaticShapeDamageProfile {
	className	         = shieldbase;
	shapeFile       	 = "sensor_pulse_medium.dts";
    scale                = "0.4 0.4 0.4";

	maxDamage       	 = 2.0;
	destroyedLevel   	 = 2.0;
	disabledLevel	     = 1.5;

    maxEnergy            = 50;
    rechargeRate         = 0.8;

	explosion	         = HandGrenadeExplosion;
	expDmgRadius	     = 1.0;
	expDamage	         = 0.05;
	expImpulse	         = 200;

	dynamicType	    	 = $TypeMasks::StaticShapeObjectType;
	deployedObject		 = true;
    humSound             = SensorHumSound;
    cmdCategory	     	 = "DSupport";
	cmdIcon		    	 = CMDSensorIcon;
	cmdMiniIconName		 = "commander/MiniIcons/com_deploymotionsensor";
    targetNameTag        = 'Purge';
	targetTypeTag        = 'Shield Generator';
	deployAmbientThread  = true;
	debrisShapeName	   	 = "debris_generic_small.dts";
	debris			     = DeployableDebris;
	heatSignature		 = 0;
	needsPower           = true;
    deploySound          = StationDeploySound;
};

//------------------------------------------------------------------------------

datablock ShapeBaseImageData(ShieldDeployableImage) {
	mass                            = 20;
	emap                            = true;
	shapeFile                       = "pack_deploy_sensor_pulse.dts";
	item                            = ShieldDeployable;
	mountPoint                      = 1;
	offset                          = "0 0 0";
	deployed                        = DeployedShield;
	heatSignature                   = 0;

	stateName[0]                    = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1]                    = "Activate";
	stateScript[1]                  = "onActivate";
	stateTransitionOnTriggerUp[1]   = "Idle";

	isLarge                         = false;
	maxDepSlope                     = 360;
	deploySound                     = ItemPickupSound;

	minDeployDis                    = 0.5;
	maxDeployDis                    = 50.0;
};

//------------------------------------------------------------------------------

datablock ItemData(ShieldDeployable) {
	className     = Pack;
	catagory      = "Deployables";
	shapeFile     = "pack_deploy_sensor_pulse.dts";
	mass          = 5.0;
	elasticity    = 0.2;
	friction      = 0.6;
	pickupRadius  = 1;
	rotate        = true;
	image         = "ShieldDeployableImage";
	pickUpName    = "a shield generator";
	heatSignature = 0;
	emap          = true;
};

//==============================================================================
// Shield Generator Functions.
//==============================================================================

function ShieldDeployableImage::testObjectTooClose(%item) {
	return "";
}

//------------------------------------------------------------------------------

function ShieldDeployableImage::testNoTerrainFound(%item) {
}

//------------------------------------------------------------------------------

function ShieldDeployable::onPickup(%this, %obj, %shape, %amount) {
}

//------------------------------------------------------------------------------

function ShieldDeployableImage::onDeploy(%item, %plyr, %slot) {
	%className = "StaticShape";

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
		%item.surfaceNrm2 = %playerVector;
	else
		%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 -1"));

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);

	%deplObj = new (%className)() {
		dataBlock = %item.deployed;
	};

    // Scale it.
    %deplobj.setscale(%deplobj.getdatablock().scale);

	%deplObj.setTransform(%item.surfacePt SPC %rot);

	if (%deplObj.getDatablock().rechargeRate)
		%deplObj.setRechargeRate(%deplObj.getDatablock().rechargeRate);

	%deplObj.team = %plyr.client.Team;
	%deplObj.setOwner(%plyr);
	%deplObj.shieldbase = %deplObj;

	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

	addToDeployGroup(%deplObj);

	AIDeployObject(%plyr.client, %deplObj);

	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	$TeamDeployedCount[%plyr.team, %item.item]++;

	addDSurface(%item.surface,%deplObj);

	%deplObj.playThread($PowerThread,"Power");
	%deplObj.playThread($AmbientThread,"ambient");

	%plyr.unmountImage(%slot);
	%plyr.decInventory(%item.item, 1);

	%deplObj.powerFreq = %plyr.powerFreq;

	checkPowerObject(%deplObj);

    // Start the loops.
    DeployedShieldLoop(%deplobj);
    RepairLoop(%deplobj);

	return %deplObj;
}

//------------------------------------------------------------------------------

function DeployedShield::onDestroyed(%this,%obj,%prevState) {
	if (%obj.isRemoved)
		return;
	%obj.isRemoved = true;
	Parent::onDestroyed(%this,%obj,%prevState);
	$TeamDeployedCount[%obj.team, ShieldDeployable]--;
	remDSurface(%obj);
    %obj.shield.delete();
    %obj.emission.delete();
    %obj.schedule(800, "delete");
}

//------------------------------------------------------------------------------

function DeployedShield::disassemble(%data,%plyr,%obj)
{
   disassemble(%data,%plyr,%obj);
   Parent::onDestroyed(%this,%obj,%prevState);

   %obj.shield.delete();
   %obj.emission.delete();
}

//------------------------------------------------------------------------------
// By Blnukem:

function RepairLoop(%obj)
{  // Lets initiate self-maintenence when we reach a certain amount of damage.
   if (!IsObject(%obj))
      return;

   if (%obj.getDamageLevel() == 1.5 || %obj.getDamageLevel() > 1.5)
   {  // Initiate alarm - Generator is disabled.
      %obj.setRepairRate(0.0);
      serverPlay3d("PurgeAlarmSound", %obj.getWorldBoxCenter());
      Schedule(800,0,"RepairLoop",%obj);
      return;
   }

   if (%obj.getDamageLevel() < 0.01)
   {  // Stop repairing.
      %obj.setRepairRate(0.0);
   } else if (%obj.getDamageLevel() > 1.0)
   {  // Lets start repairing.
      %obj.setRepairRate(0.0025);
   }
   Schedule(800,0,"RepairLoop",%obj);
}

//------------------------------------------------------------------------------
// By Blnukem:

function DeployedShieldLoop(%obj)
{
   if (!IsObject(%obj))
      return;

   if (%obj.getDamageLevel() == 1.5 || %obj.getDamageLevel() > 1.5)
   {
      schedule(100, 0, "DeployedShieldLoop", %obj);
      return;
   }

   if (!%obj.PowerCount)
   {
      schedule(100, 0, "DeployedShieldLoop", %obj);
      return;
   }

   %Type = $TypeMasks::ProjectileObjectType | $TypeMasks::PlayerObjectType;
   InitContainerRadiusSearch(%obj.getPosition(), 25, %Type);
   while ((%target = ContainerSearchNext()) != 0)
   {
      if ((%target !$= %obj) && (strstr(%target.getDatablock().getName(), "Zombie") != -1))
      {  // Lets kill any Zombies in contact with the shield.
         %target.zapObject(1);
         %target.scriptkill($DamageType::Idiocy);
         serverPlay3d("ShockLanceHitSound",%target.getWorldBoxCenter());
         %obj.applydamage(0.1); // Damage the Purge Generator.
         %obj.playShieldEffect("1 1 1");
      } else if ((%target !$= %obj) && (%target.getDatablock().getName() $= "DemonFireball") || (%target.getDatablock().getName() $= "LZombieAcidBall"))
      {  // Lets delete any Zombie projectiles in contact with the shield.
         %obj.applydamage(0.05); // Damage the Purge Generator.
         %obj.playShieldEffect("1 1 1");
         %target.delete();
      }
   }
   schedule(100,0,"DeployedShieldLoop",%obj);
}

//------------------------------------------------------------------------------

function ShieldDeployableImage::onMount(%data, %obj, %node) {
   return %data SPC %obj SPC %node;
}

//------------------------------------------------------------------------------

function ShieldDeployableImage::onUnmount(%data, %obj, %node) {
   return %data SPC %obj SPC %node;
}

//------------------------------------------------------------------------------

function DeployedShield::onGainPowerEnabled(%data,%obj) {
   Parent::onGainPowerEnabled(%data,%obj);

   if (!IsObject(%obj.shield))
   %obj.shield = createemitter(%obj.getposition(),ShieldBarrierSM,"0 0 0 0");
   if (!IsObject(%obj.emission))
   %obj.emission = createemitter(%obj.getposition(),ShieldEmission,"0 0 0 0");
}

//------------------------------------------------------------------------------

function DeployedShield::onLosePowerDisabled(%data,%obj) {
   Parent::onLosePowerDisabled(%data,%obj);

   if (IsObject(%obj.shield))
   %obj.shield.delete();
   if (IsObject(%obj.emission))
   %obj.emission.delete();
}

//==============================================================================
// Shield Particles.
//==============================================================================
// Made by Sloik:

datablock ParticleData(ShieldBarrierParticles)
{
   dragCoefficient      = 0.0;
   windCoefficient      = 0;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -200.0;
   spinRandomMax        = 200.0;
   textureName          = "special/blasterHit";
   colors[0]            = "0.01 0.01 0.01 1.0";
   colors[1]            = "0.5 1.0 1.0 1.0";
   colors[2]            = "0.01 0.01 0.01 0.0";
   sizes[0]             = 0.05;
   sizes[1]             = 0.2;
   sizes[2]             = 0.05;
   times[0]             = 0.0;
   times[1]             = 0.7;
   times[2]             = 1.0;
};

//------------------------------------------------------------------------------
// Made by Sloik:

datablock ParticleEmitterData(ShieldBarrierSM)
{
   ejectionPeriodMS     = 1;
   ejectionOffset       = 25;
   periodVarianceMS     = 0;
   ejectionVelocity     = 0.0;
   velocityVariance     = 0.0;
   thetaMin             = 5;
   thetaMax             = 175;
   phiReferenceVel      = 0;
   phiVariance          = 360;
   overrideAdvances     = false;
   particles            = "ShieldBarrierParticles";
};

//------------------------------------------------------------------------------

datablock ParticleData(ShieldEmissionParticle)
{
   dragCoefficient      = 2;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 1500;
   lifetimeVarianceMS   = 800;
   textureName          = "special/crescent3";
   colors[0]            = "0.01 0.01 0.01 1.0";
   colors[1]            = "0.5 1.0 1.0 1.0";
   colors[2]            = "0.01 0.01 0.01 0.0";
   sizes[0]             = 0.5;
   sizes[1]             = 0.8;
   sizes[2]             = 0.5;
   times[0]             = 0.0;
   times[1]             = 0.5;
   times[2]             = 1.0;
};

//------------------------------------------------------------------------------

datablock ParticleEmitterData(ShieldEmission)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 40;
   velocityVariance = 5.0;
   ejectionOffset   = 4.0;
   thetaMin         = 5;
   thetaMax         = 175;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   particles = "ShieldEmissionParticle";
};
