// Deploy effects

datablock AudioProfile(DrillLinkSound)
{
   filename    = "fx/misc/mine.deploy.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SingeLinkSound)
{
   filename    = "fx/weapons/chaingun_off.wav"; // "fx/weapons/grenade_camera_activate.wav";
   description = AudioClose3d;
   preload = true;
};


datablock AudioProfile(BoltLinkSound)
{
   filename    = "fx/misc/health_patch.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(ClickLinkSound)
{
   filename    = "fx/misc/health_patch.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(SingeSound)
{
   filename    = "fx/weapons/ElF_hit.wav";
   description = AudioClose3d;
   preload = true;
};

datablock AudioProfile(LargeLinkeSound)
{
   filename    = "fx/weapons/grenade_explode_UW.wav";
   description = AudioClose3d;
   preload = true;
};


datablock LinearProjectileData(FastSingeProjectile) {
	className = "LinearProjectileData";
	projectileShapeName = "turret_muzzlepoint.dts";
	emitterDelay = "-1";
	velInheritFactor = "0";
	directDamage = "0";
	hasDamageRadius = "0";
	indirectDamage = "0";
	damageRadius = "0";
	radiusDamageType = "0";
	kickBackStrength = "0";
	baseEmitter = "ELFSparksEmitter";
	hasLight = "0";
	lightRadius = "20";
	lightColor = "1.000000 1.000000 1.000000 1.000000";
	hasLightUnderwaterColor = "0";
	underWaterLightColor = "1.000000 1.000000 1.000000 1.000000";
	explodeOnWaterImpact = "0";
	depthTolerance = "5";
	bubbleEmitTime = "0.5";
	faceViewer = "0";
	scale = "1 1 1";
	dryVelocity = "5";
	wetVelocity = "5";
	fizzleTimeMS = "60000";
	lifetimeMS = "60000";
	explodeOnDeath = "0";
	reflectOnWaterImpactAngle = "0";
	deflectionOnWaterImpact = "0";
	fizzleUnderwaterMS = "-1";
	activateDelayMS = "-1";
	doDynamicClientHits = "0";
        sound = "ELFHitTargetSound";
	explosion = "BlasterExplosion";
};

datablock LinearProjectileData(SlowSingeProjectile) {
	className = "LinearProjectileData";
	projectileShapeName = "turret_muzzlepoint.dts";
	emitterDelay = "-1";
	velInheritFactor = "0";
	directDamage = "0";
	hasDamageRadius = "0";
	indirectDamage = "0";
	damageRadius = "0";
	radiusDamageType = "0";
	kickBackStrength = "0";
	baseEmitter = "ElfSparksEmitter";
	hasLight = "0";
	lightRadius = "20";
	lightColor = "1.000000 1.000000 1.000000 1.000000";
	hasLightUnderwaterColor = "0";
	underWaterLightColor = "1.000000 1.000000 1.000000 1.000000";
	explodeOnWaterImpact = "0";
	depthTolerance = "5";
	bubbleEmitTime = "0.5";
	faceViewer = "0";
	scale = "1 1 1";
	dryVelocity = "1";
	wetVelocity = "1";
	fizzleTimeMS = "60000";
	lifetimeMS = "60000";
	explodeOnDeath = "0";
	reflectOnWaterImpactAngle = "0";
	deflectionOnWaterImpact = "0";
	fizzleUnderwaterMS = "-1";
	activateDelayMS = "-1";
	doDynamicClientHits = "0";
        sound = "ELFHitTargetSound";
	explosion = "BlasterExplosion";
};


function singe(%pos,%dir,%size,%type) {
  %p = new LinearProjectile() {
      dataBlock        = %type @"SingeProjectile";
      initialDirection = %dir;
      initialPosition  = %pos;
   };

if (%type $= "fast")
    %p.schedule((%size/5)*1000,"delete");
else
    %p.schedule((%size)*1000,"delete");
}

function edgesinge(%obj)
{
%objsize = VectorSub(getWords(%obj.getObjectBox(),3,5),getWords(%obj.getObjectBox(),0,2));
%realsize = VectorMultiply(VectorMultiply(%objsize,%obj.getScale()),"1 1 0");
//echo(%obj.getObjectBox());
//echo(%objsize);
//echo(%realsize);
%offset = VectorScale(Realvec(%obj,%realsize),0.49);
%offset2 = VectorScale(VectorCross(VectorNormalize(%offset),realvec(%obj,"0 0 1")),VectorLen(%offset));
%pos1 = VectorAdd(%obj.getWorldBoxCenter(),%offset);
%pos2 = VectorAdd(%obj.getWorldBoxCenter(),VectorScale(%offset,-1));
singe(%pos1,Realvec(%obj,"-1 0 0"),GetWord(%realsize,0),"fast");
singe(%pos1,Realvec(%obj,"0 -1 0"),GetWord(%realsize,1),"fast");
singe(%pos2,Realvec(%obj,"1 0 0"),GetWord(%realsize,0),"fast");
singe(%pos2,Realvec(%obj,"0 1 0"),GetWord(%realsize,1),"fast");
}

function linksinge(%obj,%pt,%nrm)
{
if (%nrm !$= "")
{
%nrm = VectorNormalize(%nrm);
%dir = VectorNormalize(VectorCross(%nrm,Realvec(%obj,"0 0 1")));
%objsize = VectorSub(getWords(%obj.getObjectBox(),3,5),getWords(%obj.getObjectBox(),0,2));
%realsize = VectorScale(VectorMultiply(%objsize,%obj.getScale()),0.49);
%side = VirVec(%obj,%nrm);
%oside = VectorCross("0 0 1",%side);

%forward = Realvec(%obj,VectorMultiply(%realsize,%side));
%left = Realvec(%obj,VectorMultiply(%realsize,%oside));
%len = Vectorlen(%left);
%pos1 = VectorAdd(%obj.getWorldBoxCenter(),VectorAdd(%forward,%left));
%pos2 = VectorAdd(%obj.getWorldBoxCenter(),VectorAdd(%forward,VectorScale(%left,-1)));
singe(%pos1,%dir,%len,"fast");
singe(%pos2,VectorScale(%dir,-1),%len,"fast");
}
}

function floordrill(%obj)
{
%objsize = VectorSub(getWords(%obj.getObjectBox(),3,5),getWords(%obj.getObjectBox(),0,2));
%realsize = VectorMultiply(VectorMultiply(%objsize,%obj.getScale()),"0.5 0.5 0.5");
%forward = VectorScale(realvec(%obj,"1 0 0"),GetWord(%realsize,0));
%left = VectorScale(realvec(%obj,"0 1 0"),GetWord(%realsize,1));
%up = VectorScale(realvec(%obj,"0 0 1"),GetWord(%realsize,2));
%p1 = VectorAdd(VectorAdd(%forward,%left),%up);
%p2 = VectorAdd(VectorAdd(VectorScale(%forward,-1),%left),%up);
%p3 = VectorAdd(VectorAdd(%forward,VectorScale(%left,-1)),%up);
%p4 = VectorAdd(VectorAdd(VectorScale(%forward,-1),VectorScale(%left,-1)),%up);
schedule(0,%obj,"llink",VectorAdd(%p1,%obj.getWorldBoxCenter()));
schedule(500,%obj,"llink",VectorAdd(%p2,%obj.getWorldBoxCenter()));
schedule(1000,%obj,"llink",VectorAdd(%p4,%obj.getWorldBoxCenter()));
schedule(1500,%obj,"llink",VectorAdd(%p3,%obj.getWorldBoxCenter()));
}

function MSinge(%obj)
{
%objsize = VectorSub(getWords(%obj.getObjectBox(),3,5),getWords(%obj.getObjectBox(),0,2));
%realsize = VectorMultiply(VectorMultiply(%objsize,%obj.getScale()),"0.5 0.5 0.5");
%forward = VectorScale(realvec(%obj,"1 0 0"),GetWord(%realsize,0));
%left = VectorScale(realvec(%obj,"0 1 0"),GetWord(%realsize,1));
%up = VectorScale(realvec(%obj,"0 0 -1"),GetWord(%realsize,2));
%p1 = VectorAdd(VectorAdd(%forward,%left),%up);
%p2 = VectorAdd(VectorAdd(VectorScale(%forward,-1),%left),%up);
%p3 = VectorAdd(VectorAdd(%forward,VectorScale(%left,-1)),%up);
%p4 = VectorAdd(VectorAdd(VectorScale(%forward,-1),VectorScale(%left,-1)),%up);
schedule(0,%obj,"mlink",VectorAdd(%p1,%obj.getWorldBoxCenter()));
schedule(250,%obj,"mlink",VectorAdd(%p2,%obj.getWorldBoxCenter()));
schedule(500,%obj,"mlink",VectorAdd(%p4,%obj.getWorldBoxCenter()));
schedule(750,%obj,"mlink",VectorAdd(%p3,%obj.getWorldBoxCenter()));
}

function MSinge2(%obj)
{
%objsize = VectorSub(getWords(%obj.getObjectBox(),3,5),getWords(%obj.getObjectBox(),0,2));
%realsize = VectorMultiply(VectorMultiply(%objsize,%obj.getScale()),"0.5 0.5 0.5");
%forward = VectorScale(realvec(%obj,"1 0 0"),GetWord(%realsize,0));
%left = VectorScale(realvec(%obj,"0 1 0"),GetWord(%realsize,1));
%up = VectorScale(realvec(%obj,"0 0 1"),GetWord(%realsize,2));
%p1 = VectorAdd(VectorAdd(%forward,%left),%up);
%p2 = VectorAdd(VectorAdd(VectorScale(%forward,-1),%left),%up);
%p3 = VectorAdd(VectorAdd(%forward,VectorScale(%left,-1)),%up);
%p4 = VectorAdd(VectorAdd(VectorScale(%forward,-1),VectorScale(%left,-1)),%up);
schedule(0,%obj,"mlink",VectorAdd(%p1,%obj.getWorldBoxCenter()));
schedule(250,%obj,"mlink",VectorAdd(%p2,%obj.getWorldBoxCenter()));
schedule(500,%obj,"mlink",VectorAdd(%p4,%obj.getWorldBoxCenter()));
schedule(750,%obj,"mlink",VectorAdd(%p3,%obj.getWorldBoxCenter()));
}


function floorlink(%obj,%pt,%nrm) {
%fstat = aboveground(%obj.getworldboxcenter(),1,%obj);
%stat = GetWord(%fstat,0);
//warn(%stat);
if(%stat $= "open" || %stat $= "roof" || %stat $= "shadow") 
   linksinge(%obj,%pt,%nrm);
else
   floordrill(%obj);
}

function slink(%pt)
{
createLifeEmitter(%pt, ELFSparksEmitter, 200);   
Serverplay3D(SingeLinkSound,%pt);
}

function mlink(%pt)
{
createLifeEmitter(%pt, ELFSparksEmitter, 200);   
Serverplay3D(SingeLinkSound,%pt);
}

function llink(%pt)
{
createLifeEmitter(%pt, SmallLightDamageSmoke, 500);   
Serverplay3D(LargeLinkeSound,%pt);
}

function deployEffect(%obj,%pt,%nrm,%type)
{
if ($Host::NoDeployEffects)
   return "";
if (%type $= "pad")
   {
   edgesinge(%obj);
   }
else if (%type $= "walk")
   {
   linksinge(%obj,%pt,%nrm);
   }
else if (%type $= "spine")
   {
   slink(%pt);
   }
else if (%type $= "spine1")
   {
   slink(%pt);
   %p2 = VectorAdd( pos( %obj ),realvec( %obj,VectorMultiply("0 0 0.5",%obj.getScale()) ) );
   schedule(500,%obj,"slink",%p2);
   }
else if (%type $= "mspine")
   {
   msinge(%obj);
   }
else if (%type $= "mspine1")
   {
   msinge(%obj);
   schedule(1000,%obj,"msinge2",%obj);
   }
else if (%type $= "floor")
   {
   floorlink(%obj,%pt,%nrm);
   }
}
