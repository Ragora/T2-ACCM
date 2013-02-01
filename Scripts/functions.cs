// Universal handy function library collection, release 3.5
// Created by DynaBlade
// All functions used here are made strictly by DynaBlade
// Functions made in the other attached files are made by their respective authors.

// String Table
//

$AllObjMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType | $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::ForceFieldObjectType | $TypeMasks::StaticObjectType | $TypeMasks::MoveableObjectType | $TypeMasks::DamagableItemObjectType;
$DefaultLOSMask = $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::StaticObjectType;
$CoreObjectMask = $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StationObjectType | $TypeMasks::GeneratorObjectType | $TypeMasks::SensorObjectType | $TypeMasks::TurretObjectType;
$EverythingMask = $notdone;

// Datablock Cache
//

datablock ShockLanceProjectileData(FXZap)
{
   directDamage        = 0;
   radiusDamageType    = $DamageType::Default;
   kickBackStrength    = 0;
   velInheritFactor    = 0;
   sound               = "";

   zapDuration = 1.0;
   impulse = 0;
   boltLength = 14.0;
   extension = 14.0;            // script variable indicating distance you can shock people from
   lightningFreq = 50.0;
   lightningDensity = 18.0;
   lightningAmp = 0.25;
   lightningWidth = 0.05;


   boltSpeed[0] = 2.0;
   boltSpeed[1] = -0.5;

   texWrap[0] = 1.5;
   texWrap[1] = 1.5;

   startWidth[0] = 0.3;
   endWidth[0] = 0.6;
   startWidth[1] = 0.3;
   endWidth[1] = 0.6;

   texture[0] = "special/shockLightning01";
   texture[1] = "special/shockLightning02";
   texture[2] = "special/shockLightning03";
   texture[3] = "special/ELFBeam";
};

datablock ShockLanceProjectileData(FXPulse)
{
   directDamage        = 0;
   radiusDamageType    = $DamageType::Default;
   kickBackStrength    = 0;
   velInheritFactor    = 0;
   sound               = "";

   zapDuration = 1.0;
   impulse = 0;
   boltLength = 14.0;
   extension = 14.0;            // script variable indicating distance you can shock people from
   lightningFreq = 50.0;
   lightningDensity = 18.0;
   lightningAmp = 0.25;
   lightningWidth = 0.05;


   boltSpeed[0] = 2.0;
   boltSpeed[1] = -0.5;

   texWrap[0] = 1.5;
   texWrap[1] = 1.5;

   startWidth[0] = 0.3;
   endWidth[0] = 0.6;
   startWidth[1] = 0.3;
   endWidth[1] = 0.6;

   texture[0] = "special/nonlingradient";
   texture[1] = "special/nonlingradient";
   texture[2] = "special/nonlingradient";
   texture[3] = "special/nonlingradient";
};

datablock ParticleData(TeleporterParticle)
{
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = -0.5;
   inheritedVelFactor   = 0.0;

   lifetimeMS           = 100;
   lifetimeVarianceMS   = 50;

   textureName          = "particleTest";

   useInvAlpha = false;
   spinRandomMin = -160.0;
   spinRandomMax = 160.0;

   animateTexture = true;
   framesPerSec = 15;


   animTexName[0]       = "special/Explosion/exp_0016";
   animTexName[1]       = "special/Explosion/exp_0018";
   animTexName[2]       = "special/Explosion/exp_0020";
   animTexName[3]       = "special/Explosion/exp_0022";
   animTexName[4]       = "special/Explosion/exp_0024";
   animTexName[5]       = "special/Explosion/exp_0026";
   animTexName[6]       = "special/Explosion/exp_0028";
   animTexName[7]       = "special/Explosion/exp_0030";
   animTexName[8]       = "special/Explosion/exp_0032";

   colors[0]     = "1 1 1 1";
   colors[1]     = "0.75  0.75 1.0";
   colors[2]     = "0.5 0.5 0.5 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 1;
   sizes[2]      = 2.5;
   times[0]      = 0.0;
   times[1]      = 0.7;
   times[2]      = 1.0;
};

datablock ParticleEmitterData(TeleporterEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;
   ejectionVelocity = 6;
   velocityVariance = 2.9;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 5;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   particles = "TeleporterParticle";
};

datablock StaticShapeData(SlotExtension)
{
   shapeFile = "turret_muzzlepoint.dts";
};

// ShapeBase/Parent calls
//

function SimObject::getRotation(%obj)
{
     getRotation(%obj);
}

function SimObject::getSlotRotation(%obj, %slot)
{
     getSlotRotation(%obj, %slot);
}

function SimObject::getSlotPosition(%obj, %slot)
{
     getSlotPosition(%obj, %slot);
}

function SimObject::isVehicle(%obj)
{
     isVehicle(%obj);
}

function SimObject::isPlayer(%obj)
{
     isPlayer(%obj);
}

function ShapeBase::zapObject(%obj)
{
     zapObject(%obj);
}

function ShapeBase::zap2Object(%obj)
{
     zap2Object(%obj);
}

function ShapeBase::stopZap(%obj)
{
     stopZap(%obj);
}

function ShapeBase::applyKick(%obj, %force)
{
     applyKick(%obj, %force);
}

function ShapeBase::useEnergy(%obj, %amount)
{
     useEnergy(%obj, %amount);
}

function SimObject::setPosition(%obj, %pos)
{
     setPosition(%obj, %pos);
}

function SimObject::setRotation(%obj, %rot)
{
     setRotation(%obj, %rot);
}

function SimObject::play3D(%obj, %sound)
{
     play3D(%obj, %sound);
}

function ShapeBase::teleportStartFX(%obj)
{
     teleportStartFX(%obj);
}

function ShapeBase::teleportEndFX(%obj)
{
     teleportEndFX(%obj);
}

function ShapeBase::getEyePoint(%obj)
{
     getEyePoint(%obj);
}

function ShapeBase::getMuzzleRaycastPt(%obj, %slot, %dist)
{
     getMuzzleRaycastPt(%obj, %slot, %dist);
}

function ShapeBase::getEyeRaycastPt(%obj, %dist)
{
     getEyeRaycastPt(%obj, %dist);
}

function ShapeBase::getForwardRaycastPt(%obj, %dist)
{
     getForwardRaycastPt(%obj, %dist);
}

function ShapeBase::getMass(%obj)
{
     getMass(%obj);
}

function ShapeBase::getAccel(%obj)
{
     getAccel(%obj);
}

function ShapeBase::getMaxEnergy(%obj)
{
     getMaxEnergy(%obj);
}

function ShapeBase::getMaxDamage(%obj)
{
     getMaxDamage(%obj);
}

function ShapeBase::getDamageLeft(%obj)
{
     getDamageLeft(%obj);
}

function ShapeBase::getDamageLeftPct(%obj)
{
     getDamageLeftPct(%obj);
}

function ShapeBase::getVelToForce(%obj)
{
     getVelToForce(%obj);
}

function ShapeBase::getEnergyPct(%obj)
{
     getEnergyPct(%obj);
}

function ShapeBase::getDamagePct(%obj)
{
     getDamagePct(%obj);
}

function ShapeBase::getTransformAngle(%trans)
{
     getTransformAngle(%trans);
}

function ShapeBase::createSlotExtension(%obj, %slot)
{
     createSlotExtension(%obj, %slot);
}

function ShapeBase::deleteSlotExtension(%obj, %slot)
{
     deleteSlotExtension(%obj, %slot);
}

// Function library
//

function createSlotExtension(%obj, %slot)
{
    %ext = new StaticShape()
    {
        scale = "1 1 1";
        dataBlock = "SlotExtension";
    };
    %ext.isExtension = true;

    %obj.mountObject(%ext, %slot);
    %obj.slotExtension[%slot] = %ext;
    %obj.slotExtension[%slot].srcObj = %obj;
}

function deleteSlotExtension(%obj, %slot)
{
   %ext = %obj.getMountNodeObject(%slot);
   if(!%ext)
      return;

   if(%ext.isExtension)
      %ext.delete();

   %obj.slotExtension[%slot] = "";
}


function combineVars(%a, %b, %c)
{
   return %a SPC %b SPC %c;
}

function posFrRaycast(%transform)
{
   %position = getWord(%transform, 1) @ " " @ getWord(%transform, 2) @ " " @ getWord(%transform, 3);
   return %position;
}

function normalFrRaycast(%transform)
{
   %norm = getWord(%transform, 4) @ " " @ getWord(%transform, 5) @ " " @ getWord(%transform, 6);
   return %norm;
}

function getEyePoint(%obj)
{
     %eyePt = getWords(%obj.getEyeTransform(), 0, 2);
     return %eyePt;
}

function play3D(%obj, %sound)
{
     serverPlay3D(%sound, %obj.getTransform());
}

function killit(%k)
{
     %k.delete();
}

function scanArea(%pos, %radius, %mask)
{
   InitContainerRadiusSearch(%pos, %radius, %mask);
   while((%int = ContainerSearchNext()) != 0)
   {
      if(%int)
         return true;
   }

   return false;
}

function testPosition(%obj)
{
     InitContainerRadiusSearch(%obj.getWorldBoxCenter(), 0.5, $DefaultLOSMask);

     while ((%test = ContainerSearchNext()) != 0)
     {
          if(%test)
               return false;
          else
               return true;
     }
}

function createEmitter(%pos, %emitter, %rot)
{
    %dummy = new ParticleEmissionDummy()
    {
          position = %pos;
          rotation = %rot;
          scale = "1 1 1";
          dataBlock = defaultEmissionDummy;
          emitter = %emitter;
          velocity = "1";
    };
    MissionCleanup.add(%dummy);
    %dummy.setRotation(%rot);

    if(isObject(%dummy))
       return %dummy;
}

function createLifeEmitter(%pos, %emitter, %lifeMS, %rot)
{
    %dummy = createEmitter(%pos, %emitter, %rot);
    schedule(%lifeMS, %dummy, "killit", %dummy);
    return %dummy;
}

function sqr(%num)
{
     return %num*%num;
}

function cube(%num)
{
     return %num*%num*%num;
}

function useEnergy(%obj, %amount)
{
   if(isObject(%obj))
   {
      %energy = %obj.getEnergyLevel() - %amount;
      %obj.setEnergyLevel(%energy);
   }
}

function modifyTransform(%trans1, %trans2)
{
     %tpx1 = getWord(%trans1, 0);
     %tpy1 = getWord(%trans1, 1);
     %tpz1 = getWord(%trans1, 2);
     %tpa1 = getWord(%trans1, 3);
     %tpb1 = getWord(%trans1, 4);
     %tpc1 = getWord(%trans1, 5);
     %tpd1 = getWord(%trans1, 6);

     %tpx2 = getWord(%trans2, 0);
     %tpy2 = getWord(%trans2, 1);
     %tpz2 = getWord(%trans2, 2);
     %tpa2 = getWord(%trans2, 3);
     %tpb2 = getWord(%trans2, 4);
     %tpc2 = getWord(%trans2, 5);
     %tpd2 = getWord(%trans2, 6);

     %trans = (%tpx1+%tpx2)@" "@(%tpy1+%tpy2)@" "@(%tpz1+%tpz2)@" "@(%tpa1+%tpa2)@" "@(%tpb1+%tpb2)@" "@(%tpc1+%tpc2)@" "@(%tpd1+%tpd2);
     return %trans;
}

function modifyTri(%trans1, %trans2)
{
     %tpx1 = getWord(%trans1, 0);
     %tpy1 = getWord(%trans1, 1);
     %tpz1 = getWord(%trans1, 2);

     %tpx2 = getWord(%trans2, 0);
     %tpy2 = getWord(%trans2, 1);
     %tpz2 = getWord(%trans2, 2);

     %tri = (%tpx1+%tpx2)@" "@(%tpy1+%tpy2)@" "@(%tpz1+%tpz2);
     return %tri;
}

function modifyQuad(%trans1, %trans2) // assuming for transform rotation
{
     %tpa1 = getWord(%trans1, 3);
     %tpb1 = getWord(%trans1, 4);
     %tpc1 = getWord(%trans1, 5);
     %tpd1 = getWord(%trans1, 6);

     %tpa2 = getWord(%trans2, 3);
     %tpb2 = getWord(%trans2, 4);
     %tpc2 = getWord(%trans2, 5);
     %tpd2 = getWord(%trans2, 6);

     %quad = (%tpa1+%tpa2)@" "@(%tpb1+%tpb2)@" "@(%tpc1+%tpc2)@" "@(%tpd1+%tpd2);
     return %quad;
}

function getTransformAngle(%trans)
{
     return getWord(%trans, 6);
}

function setPosition(%obj, %pos)
{
    %rot = getWords(%obj.getTransform(), 3, 6);
    %trans = %pos@" "@%rot;
    %obj.setTransform(%trans);
}

function setRotation(%obj, %rot)
{
    %pos = getWords(%obj.getTransform(), 0, 2);
    %trans = %pos@" "@%rot;
    %obj.setTransform(%trans);
}

function getSlotPosition(%obj, %slot)
{
    return getWords(%obj.getSlotTransform(%slot), 0, 2);
}

function getSlotRotation(%obj, %slot)
{
    return getWords(%obj.getSlotTransform(%slot), 3, 6);
}

function getRotation(%obj)
{
    return getWords(%obj.getTransform(), 3, 6);
}

function getRandomN(%max, %min) // negative getrandom
{
   if(%max !$= "" && %min !$= "")
      return getRandom(%max, %min) * -1;
   else if(%max !$= "")
      return getRandom(%max) * -1;
   else
      return getRandom() * -1;
}

function getRandomB() // boolean getRandom
{
   if(getRandom(1))
      return true;
   else
      return false;
}

function getRandomT(%max, %min)
{
   if(%max !$= "" && %min !$= "")
      return getRandomB() ? getRandom(%max, %min) : getRandomN(%max, %min);
   else if(%max !$= "")
      return getRandomB() ? getRandom(%max) : getRandomN(%max);
   else
      return getRandomB() ? getRandom() : getRandomN();
}

function shutdownServer(%time, %msg, %lines)
{
     %left = %time*1000;
     centerPrintAll(%msg, %left, %lines);
     schedule(%left, 0, "quit");
}

function velToSingle(%vel, %bool) // this function is also vectorLength :)
{
	%x = getWord(%vel, 0);
	%y = getWord(%vel, 1);
	%z = getWord(%vel, 2);

    if(%bool)
        return mSqrt((%x*%x)+(%y*%y)+(%z*%z));
    else
        return mFloor(mSqrt((%x*%x)+(%y*%y)+(%z*%z)));
}

function MStoKPH(%vel, %bool) // for more accurate conversions
{
    if(%bool)
        return %vel * 3.6;
    else
        return mFloor(%vel * 3.6);
}

function KPHtoMPH(%vel, %bool)
{
    if(%bool)
        return %vel * 0.6214;
    else
        return mFloor(%vel * 0.6214);
}

function vectorNeg(%vec)
{
     %v1 = getWord(%vec, 0) * -1;
     %v2 = getWord(%vec, 1) * -1;
     %v3 = getWord(%vec, 2) * -1;
     return %v1@" "@%v2@" "@%v3; 
}

function vectorRandom()
{
   return getRandomT()@" "@getRandomT()@" "@getRandomT();
}

function vectorClear(%vec) // for you lazy types
{
     return "0 0 0";
}

function vectorCopy(%veca, %vecb) // also for you lazy types
{
     %vecb = getWords(%veca, 0, 2);
     return;
}

function vectorCompare(%va, %vb)
{
   %v1[0] = getWord(%va, 0);
   %v1[1] = getWord(%va, 1);
   %v1[2] = getWord(%va, 2);

   %v2[0] = getWord(%vb, 0);
   %v2[1] = getWord(%vb, 1);
   %v2[2] = getWord(%vb, 2);

   if(%v1[0] != %v2[0] || %v1[1] != %v2[1] || %v1[2] != %v2[2])
      return 0;

   return 1;
}

function vectorToRotZ(%vec) // only for Z rotations
{
   %radian = mAcos(getWord(%vec, 1));
	%angle = (%radian / 0.0175);
	%newrot = " 0 0 1 " @ (270 - %angle);
   return %newrot;
}

function getLOSOffset(%obj, %vec, %dist)
{
   %pos = %obj.getPosition();
   %dir = vectorNormalize(%vec);
   %nvec = vectorScale(%dir, %dist);
   return vectorAdd(%pos, %nvec);
}

function S_vectorNormalize(%vec) // Source code on vectorNormalize
{
	%length = 0;
   %ilength = 0;
   %v[0] = getWord(%vec, 0);
   %v[1] = getWord(%vec, 1);
   %v[2] = getWord(%vec, 2);

	%length = mSqrt((%v[0]*%v[0]) + (%v[1]*%v[1]) + (%v[2]*%v[2]));

	if(%length) // no division by 0 thx :)
	{
		%ilength = 1/%length;
		%v[0] *= %ilength;
		%v[1] *= %ilength;
		%v[2] *= %ilength;
	}

   %nVec = combineVars(%v[0], %v[1], %v[2]);
	return %nVec;
}

function getDistance2D(%a, %b)
{
     %x1 = getWord(%a, 0);
     %y1 = getWord(%b, 0);
     %x2 = getWord(%a, 1);
     %y2 = getWord(%b, 1);
     
     %dist = mSqrt(sqr(%x2 - %x1) + sqr(%y2 - %y1));
     return %dist;
}

function getObjectDistance(%obj1, %obj2)
{
     %obj1b = %obj1.getWorldBoxCenter();
     %obj2b = %obj2.getWorldBoxCenter();

     %tpx1 = getWord(%obj1b, 0);
     %tpy1 = getWord(%obj1b, 1);
     %tpz1 = getWord(%obj1b, 2);

     %tpx2 = getWord(%obj2b, 0);
     %tpy2 = getWord(%obj2b, 1);
     %tpz2 = getWord(%obj2b, 2);

     %dist = mSqrt(sqr(%tpx2 - %tpx1) + sqr(%tpy2 - %tpy1) + sqr(%tpz2 - %tpz1));
     return %dist;
}

function getVectorFromPoints(%pt1, %pt2)
{
     return VectorNormalize(VectorSub(%pt2, %pt1));
}

function getVectorFromObjects(%obj1, %obj2)
{
     %obj1b = %obj1.getWorldBoxCenter();
     %obj2b = %obj2.getWorldBoxCenter();

     return VectorNormalize(VectorSub(%obj2b, %obj1b));
}

function isWithinVariance(%va, %vb, %variance) // vector 1, vector 2, variant percentage out of 100% ex (0.9*360 / 360)
{
   %dot = vectorDot(vectorNormalize(%va), vectorNormalize(%vb));
   if(%dot >= %variance/360)
      return true;
   else
      return false;
}

function getDistance3D(%ptA, %ptB)
{
     %tpx1 = getWord(%ptA, 0);
     %tpy1 = getWord(%ptA, 1);
     %tpz1 = getWord(%ptA, 2);

     %tpx2 = getWord(%ptB, 0);
     %tpy2 = getWord(%ptB, 1);
     %tpz2 = getWord(%ptB, 2);

     %dist = mSqrt(sqr(%tpx2 - %tpx1) + sqr(%tpy2 - %tpy1) + sqr(%tpz2 - %tpz1));
     return %dist;
}

function zapObject(%obj)
{
     %obj.zap = new ShockLanceProjectile()
     {
          dataBlock        = "fxzap"; 
          initialDirection = "0 0 0";
          initialPosition  = %obj.getWorldBoxCenter();
          sourceObject     = %obj;
          sourceSlot       = 0;
          targetId         = %obj;
     };
     MissionCleanup.add(%obj.zap);
}

function zap2Object(%obj)
{
     %obj.zap = new ShockLanceProjectile()
     {
          dataBlock        = "fxpulse";
          initialDirection = "0 0 0";
          initialPosition  = %obj.getWorldBoxCenter();
          sourceObject     = %obj;
          sourceSlot       = 0;
          targetId         = %obj;
     };
     MissionCleanup.add(%obj.zap);
}

function stopZap(%obj)
{
     if(isObject(%obj))
     {
          if(isObject(%obj.zap))
               %obj.zap.delete();
     }
}

function teleportStartFX(%obj)
{
     if(%obj.holdingFlag)
     {
          %client = %obj.client;
          %flag = %obj.holdingFlag;
          %flag.setVelocity("0 0 0");
          %flag.setTransform(%obj.getWorldBoxCenter());
          %flag.setCollisionTimeout(%obj);
          %obj.throwObject(%flag);
          messageClient(%obj.client, 'MsgNoTeleFlag', '\c1You cannot teleport with the flag.');
     }

     %obj.playShieldEffect("0 0 1");
     %obj.setCloaked(true);
     %obj.startFade( 1000, 0, true );
     %obj.play3D(TeleportSound);

     %particles = createEmitter(%obj.getPosition(), "TeleporterEmitter");
     schedule(2500, 0, "killit", %particles);
}

function teleportEndFX(%obj)
{
     %obj.setCloaked(false);
     %obj.playShieldEffect("0 0 1");
     %obj.startFade(1000, 0, false );
     %obj.play3D(UnTeleportSound);
	if (isObject(%obj.particleFX))
	     %obj.particleFX.delete();

     %particles = createEmitter(%obj.getPosition(), "TeleporterEmitter");
     schedule(2500, 0, "killit", %particles);
}

function getMuzzleRaycastPt(%obj, %slot, %dist)
{
     %vec = %obj.getMuzzleVector(%slot);
     %pos = %obj.getMuzzlePoint(%slot);
     %nVec = VectorNormalize(%vec);
     %scVec = VectorScale(%nVec, %dist);
     %end = VectorAdd(%pos, %scVec);
     %searchResult = containerRayCast(%pos, %end, $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::TurretObjectType | $TypeMasks::ItemObjectType, 0);
     %raycastPt = posFrRaycast(%searchResult);
     %raycastPt.raycast = %searchResult;
     
     return %raycastPt;
}

function getEyeRaycastPt(%obj, %dist)
{
     %vec = %obj.getEyeVector();
     %pos = %obj.getEyePoint();
     %nVec = VectorNormalize(%vec);
     %scVec = VectorScale(%nVec, %dist);
     %end = VectorAdd(%pos, %scVec);
     %searchResult = containerRayCast(%pos, %end, $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::TurretObjectType | $TypeMasks::ItemObjectType, 0);
     %raycastPt = posFrRaycast(%searchResult);
     %raycastPt.raycast = %searchResult;
     
     return %raycastPt;
}

function getForwardRaycastPt(%obj, %dist)
{
     %vec = %obj.getForwardVector();
     %pos = %obj.getWorldBoxCenter();
     %nVec = VectorNormalize(%vec);
     %scVec = VectorScale(%nVec, %dist);
     %end = VectorAdd(%pos, %scVec);
     %searchResult = containerRayCast(%pos, %end, $TypeMasks::TerrainObjectType | $TypeMasks::InteriorObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType | $TypeMasks::StaticShapeObjectType | $TypeMasks::TurretObjectType | $TypeMasks::ItemObjectType, 0);
     %raycastPt = posFrRaycast(%searchResult);
     %raycastPt.raycast = %searchResult;
     
     return %raycastPt;
}

function applyKick(%obj, %force)
{
    %vec = VectorScale(%obj.getMuzzleVector(0), %force);
    %obj.applyImpulse(%obj.getTransform(), %vec);
}

function getMass(%obj)
{
    return %obj.getDatablock().mass;
}

function getMaxEnergy(%obj)
{
    return %obj.getDatablock().maxEnergy;
}

function getMaxDamage(%obj)
{
    return %obj.getDatablock().maxDamage;
}

function getEnergyPct(%obj)
{
   return %obj.getEnergyLevel() / %obj.getMaxEnergy();
}

function getDamagePct(%obj)
{
   return %obj.getDamageLevel() / %obj.getMaxDamage();
}

function getDamageLeft(%obj)
{
   return %obj.getMaxDamage() - %obj.getDamageLevel();
}

function getDamageLeftPct(%obj)
{
   return %obj.getDamageLeft() / %obj.getMaxDamage();
}

function getAccel(%obj)
{
    %vel = vectorScale(%obj.getVelocity(), 0.01);
    schedule(1, 0, "returnAccel", %obj, %vel);
}

function returnAccel(%obj, %vel1)
{
    %vel = vectorScale(%obj.getVelocity(), 0.01);
    return vectorScale(vectorSub(%vel, %vel1), 0.01); // a = dv/dt
}

function getVelToForce(%obj)
{
    %accel = %obj.getAccel();
    %mass = %obj.getMass();
    return vectorScale(%accel, %mass);
}

function getTowForce(%obj, %target)
{
    %accel = %obj.getAccel();
    %mass = %target.getMass();
    return vectorScale(%accel, %mass);
}

function setFlightCeiling(%val)
{
    %missionArea = nameToID("MissionGroup/MissionArea");

    if(%missionArea != -1)
        %missionArea.FlightCeiling = %val;
}

function reload(%script)
{
	compile(%script); // Added by JackTL - Duh!!
    exec(%script);
    %count = ClientGroup.getCount();

    for(%i = 0; %i < %count; %i++)
    {
        %cl = ClientGroup.getObject(%i);

        if(!%cl.isAIControlled()) // no sending bots datablocks.. LOL
            %cl.transmitDataBlocks(0); // all clients on server
    }
}

function isVehicle(%obj)
{
    if(isObject(%obj))
    {
        %data = %obj.getDataBlock();
        %className = %data.className;

        if(%className $= WheeledVehicleData || %className $= FlyingVehicleData || %className $= HoverVehicleData)
            return true;
        else
            return false;
    }
}

function isPlayer(%obj)
{
    if(isObject(%obj))
    {
        %data = %obj.getDataBlock();
        %className = %data.className;

        if(%className $= Armor)
            return true;
        else
            return false;
    }
}

function changeServerHostname(%name)
{
   $Host::GameName = %name;
}

function changeServerAllowAliases(%bool)
{
   $Host::NoSmurfs = %bool;
}

function changeServerPlayerCount(%num)
{
   $Host::MaxPlayers = %num;
}

function changeAdminPassword(%pass)
{
   if(%pass)
      $Host::AdminPassword = %pass;
   else
      $Host::AdminPassword = "";
}

function changeServerPassword(%pass)
{
   if(%pass)
      $Host::Password = %pass;
   else
      $Host::Password = "";
}

function setServerPrefs(%name, %aliases, %admin, %password, %num)
{
   $Host::CRCTextures = 0;
   if(%name !$= "")
      changeServerHostname(%name);
   if(%aliases !$= "")
      changeServerAllowAliases(%aliases);
   if(%num !$= "")
      changeServerPlayerCount(%num);

   changeAdminPassword(%admin);
   changeServerPassword(%password);
}
