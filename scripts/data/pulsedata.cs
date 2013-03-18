datablock StaticShapeData(SelectionPad) : StaticShapeDamageProfile
{
className = "crate";
shapeFile = "station_inv_mpb.dts";//"vehicle_air_hapc.dts";
};

function SelectionPad::onDestroyed(%this, %obj, %prevState)
{
%obj.remTrigger();
Parent::onDestroyed(%this, %obj, %prevState);
%obj.schedule(500, "delete");
}

//Litle console spam remover.
function SelectionPad::hasDismountOverrides(%data, %obj)
{
return false;
}

function SelectionPad::playerDismounted(%data, %obj, %player)
{
%obj.setThreadDir(1,false);
}

function shockwave(%pos,%nrm,%dat)
{
if (%dat $= "")
%dat = BaseProjectile;

%p1 = new TracerProjectile()
{
dataBlock        = %dat;
initialDirection = %nrm;
initialPosition  = %pos;
};
}

//loading system
if ($mpm_AE != 1)
{
$mpm_load[$mpm_loads] = Mpm_AREP_Load;
$mpm_loads++;
$mpm_load[$mpm_loads] = Mpm_ACLK_Load;
$mpm_loads++;
$mpm_load[$mpm_loads] = Mpm_ADIS_Load;
$mpm_loads++;
$mpm_load[$mpm_loads] = Mpm_AESP_Load;
$mpm_loads++;
$mpm_load[$mpm_loads] = Mpm_AMOR_Load;
$mpm_loads++;
$mpm_AE = 1;
}


//Loads

datablock ItemData(Mpm_AREP_Load):Mpm_Base_Load
{
slot = 0;
cost = 25;
name = "[AID] Repair Pulse";
friendly = 1;
missile = Mpm_B_MIS4;

};

datablock ItemData(Mpm_ACLK_Load):Mpm_Base_Load
{
slot = 0;
cost = 30;
name = "[AID] Cloak Pulse";
friendly = 1;
missile = Mpm_B_MIS4;

};

datablock ItemData(Mpm_ADIS_Load):Mpm_Base_Load
{
slot = 0;
cost = 25;
name = "[AID] Dissasemble Pulse";
friendly = 0;
missile = Mpm_B_MIS4;

};

datablock ItemData(Mpm_AESP_Load):Mpm_Base_Load
{
slot = 0;
cost = 50;
name = "[AID] Electo Static Pulse";
friendly = 0;
missile = Mpm_B_MIS4;

};

datablock ItemData(Mpm_AMOR_Load):Mpm_Base_Load
{
slot = 0;
cost = 50;
name = "[AID] Morph Pulse";
friendly = 0;
missile = Mpm_B_MIS4;

};

function Mpm_AREP_Load::Explode(%data,%p,%pos)
{
if (IsObject(%p))
{
Aidpulse(%pos,%p.owner,0);
}
}

function Mpm_ACLK_Load::Explode(%data,%p,%pos)
{
if (IsObject(%p))
{
Aidpulse(%pos,%p.owner,1);
}
}

function Mpm_ADIS_Load::Explode(%data,%p,%pos)
{
if (IsObject(%p))
{
Aidpulse(%pos,%p.owner,2);
}
}

function Mpm_AESP_Load::Explode(%data,%p,%pos)
{
if (IsObject(%p))
{
Aidpulse(%pos,%p.owner,3);
}
}

function Mpm_AMOR_Load::Explode(%data,%p,%pos)
{
if (IsObject(%p))
{
Aidpulse(%pos,%p.owner,4);
}
}

//Shockwaves

datablock ShockwaveData(RepairWave) {
className = "ShockwaveData";
scale = "1 1 1";
delayMS = "0";
delayVariance = "0";
lifetimeMS = "10000";
lifetimeVariance = "0";
width = "1";
numSegments = "60";
numVertSegments = "30";
velocity = "10";
height = "20";
verticalCurve = "5";
acceleration = "1";
times[0] = "0";
times[1] = "0.25";
times[2] = "0.9";
times[3] = "1";
colors[0] = "1.000000 0.200000 0.200000 1.000000"; //1.0 0.9 0.9
colors[1] = "1.000000 0.200000 0.200000 1.000000"; //0.6 0.6 0.6
colors[2] = "1.000000 0.200000 0.200000 1.000000"; //0.6 0.6 0.6
colors[3] = "1.000000 0.200000 0.200000 0.000000";
texture[0] = "special/redbump2";
texture[1] = "special/shockwave4"; //gradient";
texWrap = "1";
is2D = "0";
mapToTerrain = "0";
orientToNormal = "1";
renderBottom = "1";
renderSquare = "0";
};

datablock ShockwaveData(CloakWave):RepairWave
{
colors[0] = "1 1 1 1";
colors[1] = "1 1 1 1";
colors[2] = "1 1 1 1";
colors[3] = "1 1 1 0";
texture[0] = "special/cloakTexture";
texture[1] = "special/shockwave4";
texWrap = "5";
};

datablock ShockwaveData(DisWave):RepairWave
{
colors[0] = "0.2 0.2 1 1";
colors[1] = "0.2 0.2 1 1";
colors[2] = "0.2 0.2 1 1";
colors[3] = "0.2 0.2 1 0";
texture[0] = "special/shockwave5";
texture[1] = "special/shockwave4";
texWrap = "1";
};

datablock ShockwaveData(EspWave):RepairWave
{
colors[0] = "0.8 0.2 1 1";
colors[1] = "0.8 0.2 1 1";
colors[2] = "0.8 0.2 1 1";
colors[3] = "0.8 0.2 1 0";
texture[0] = "special/shockwave5";
texture[1] = "special/shockwave4";
texWrap = "1";
};

datablock ShockwaveData(MORWave):RepairWave
{
colors[0] = "0.8 1 0.2 1";
colors[1] = "0.8 1 0.2 1";
colors[2] = "0.8 1 0.2 1";
colors[3] = "0.8 1 0.2 0";
texture[0] = "special/shockwave5";
texture[1] = "special/shockwave4";
texWrap = "1";
};

//Emitters

datablock ParticleData(RepairWave_P)
{
dragCoeffiecient     = 0.0;
gravityCoefficient   = 0.0;
inheritedVelFactor   = 0.0;

lifetimeMS           = 10000;
lifetimeVarianceMS   = 0;
constantAcceleration = 0.1;

spinRandomMin = -30.0;
spinRandomMax = 30.0;
windcoefficient = 0;
textureName          = "special/redflare";

colors[0] = "1 0.2 0.2 1";
colors[1] = "1 0.2 0.2 1";
colors[2] = "1 0.2 0.2 1";
colors[3] = "1 0.2 0.2 0";

sizes[0]      = 1;
sizes[1]      = 2;
sizes[2]      = 4;
sizes[3]      = 5;

times[0] = "0";
times[1] = "0.25";
times[2] = "0.9";
times[3] = "1";

};

datablock ParticleData(CloakWave_P):RepairWave_P
{
textureName          = "flarebase";
constantAcceleration = 0.1;
colors[0] = "1 1 1 1";
colors[1] = "1 1 1 1";
colors[2] = "1 1 1 1";
colors[3] = "1 1 1 0";
};

datablock ParticleData(DISWave_P):RepairWave_P
{
textureName          = "flarebase";
constantAcceleration = 0.1;
colors[0] = "0.2 0.2 1 1";
colors[1] = "0.2 0.2 1 1";
colors[2] = "0.2 0.2 1 1";
colors[3] = "0.2 0.2 1 0";
};

datablock ParticleData(ESPWave_P):RepairWave_P
{
textureName          = "flarebase";
constantAcceleration = 0.1;
colors[0] = "0.8 0.2 1 1";
colors[1] = "0.8 0.2 1 1";
colors[2] = "0.8 0.2 1 1";
colors[3] = "0.8 0.2 1 0";
};

datablock ParticleData(MORWave_P):RepairWave_P
{
textureName          = "flarebase";
constantAcceleration = 0.1;
colors[0] = "0.8 1 0.2 1";
colors[1] = "0.8 1 0.2 1";
colors[2] = "0.8 1 0.2 1";
colors[3] = "0.8 1 0.2 0";
};

datablock ParticleEmitterData(RepairWave_E)
{
lifetimeMS        = 1000;
ejectionPeriodMS = 1;
periodVarianceMS = 0;

ejectionVelocity = 10;
velocityVariance = 0;
ejectionoffset   = 5;
thetaMin         = 0.0;
thetaMax         = 180.0;

phiReferenceVel = "0";
phiVariance = "360";
orientParticles  = false;
orientOnVelocity = false;

particles = "RepairWave_P";
};

datablock ParticleEmitterData(CLOAKWave_E):RepairWave_E
{
lifetimeMS        = 1000;
ejectionPeriodMS = 1;
ejectionVelocity = 10;
ejectionoffset   = 5;
velocityVariance = 0;
particles = "CloakWave_P";
thetaMin         = 0.0;
thetaMax         = 180.0;

phiReferenceVel = "0";
phiVariance = "360";
};

datablock ParticleEmitterData(DISWave_E):RepairWave_E
{
lifetimeMS        = 1000;
ejectionPeriodMS = 1;
ejectionVelocity = 10;
ejectionoffset   = 5;
velocityVariance = 0;
particles = "DISWave_P";
thetaMin         = 0.0;
thetaMax         = 180.0;

phiReferenceVel = "0";
phiVariance = "360";
};


datablock ParticleEmitterData(ESPWave_E):RepairWave_E
{
lifetimeMS        = 1000;
ejectionPeriodMS = 1;
ejectionVelocity = 10;
velocityVariance = 0;
ejectionoffset   = 5;
particles = "ESPWave_P";
thetaMin         = 0.0;
thetaMax         = 180.0;

phiReferenceVel = "0";
phiVariance = "360";
};


datablock ParticleEmitterData(MORWave_E):RepairWave_E
{
lifetimeMS        = 1000;
ejectionPeriodMS = 1;
ejectionVelocity = 10;
velocityVariance = 0;
ejectionoffset   = 5;
particles = "MORWave_P";
thetaMin         = 0.0;
thetaMax         = 180.0;

phiReferenceVel = "0";
phiVariance = "360";
};


datablock ExplosionData(RepairPulseExplosion):BaseExplosion //From blast.cs
{
emitter[0] = "RepairWave_E";
Shockwave = "RepairWave";
};


datablock ExplosionData(CloakPulseExplosion):BaseExplosion //From blast.cs
{
emitter[0] = "CloakWave_E";
Shockwave = "CloakWave";
};

datablock ExplosionData(DisPulseExplosion):BaseExplosion //From blast.cs
{
emitter[0] = "DISWave_E";
Shockwave = "DisWave";
};

datablock ExplosionData(ESPPulseExplosion):BaseExplosion //From blast.cs
{
emitter[0] = "ESPWave_E";
Shockwave = "ESPWave";
};


datablock ExplosionData(MORPulseExplosion):BaseExplosion //From blast.cs
{
emitter[0] = "MORWave_E";
Shockwave = "MORWave";
};

datablock TracerProjectileData(RepairPulseProjectile):BaseProjectile
{
Explosion = "RepairPulseExplosion";
};

datablock TracerProjectileData(CloakPulseProjectile):BaseProjectile
{
Explosion = "CloakPulseExplosion";
};

datablock TracerProjectileData(DisPulseProjectile):BaseProjectile
{
Explosion = "DisPulseExplosion";
};

datablock TracerProjectileData(ESPPulseProjectile):BaseProjectile
{
Explosion = "ESPPulseExplosion";
};


datablock TracerProjectileData(MORPulseProjectile):BaseProjectile
{
Explosion = "MORPulseExplosion";
};

function Aidpulse(%pos,%owner,%type,%nrm)
{
schedule(200,0,"Serverplay3D",FlashGrenadeExplosionSound,%pos);
%types = "RepairPulseProjectile CloakPulseProjectile DisPulseProjectile ESPPulseProjectile MORPulseProjectile";
%proj = GetWord(%types,%type);
%nrm = !%nrm ? "0 0 -1" : %nrm;
shockwave(%pos,%nrm,%proj);
%waveblock = %proj.explosion.shockwave;
%accel = %waveblock.acceleration;    //accel of wave
%speed = %waveblock.velocity;        //speed of wave
%mtime = %waveblock.lifetimeMS/1000; //time the wave lasts
%lastdist = 0;
%checks = %mtime/2; //2 per second
AidPulseWaved(%pos,%mtime,%speed,%accel,%waveblock,%owner);
Cancel(%owner.resetmorphsch);
%owner.resetmorphsch = Schedule(%mtime*1000+5000,%owner,"resetmorphsize",%owner);
for (%i = 1;%i<20;%i++)
{
%time = %i/2;
%dist = %time*%speed+1/2 * mPow(%time,2)*%accel+10;
schedule(%time*1000,0,"AidpulseWaver",%pos,%dist,%lastdist-2,%waveblock,%owner);
%lastdist = %dist;
}
}



function solveadist(%accel,%speed,%dist)
{
%awn = mSolveQuadratic(%accel/2,%speed,-1*%dist);
if (getWord(%awn,0) <0 || getWord(%awn,1) > 0)
return 0;
else
return -1*getWord(%awn,1);
}

function AidPulseWaved(%pos,%time,%speed,%accel,%wave,%owner)
{
%area =  %time*%speed+1/2 * mPow(%time,2)*%accel+10;

InitContainerRadiusSearch(%pos, %area, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType );


while ((%targetObject = containerSearchNext()) != 0)
{
%dist = containerSearchCurrRadDamageDist();
%ttime = solveadist(%accel,%speed,%dist-10);
if (%ttime != 0 || %ttime < %time)
%wave.schedule(%ttime*1000,"AidEffect",%targetobject,%owner,%pos);
}
}

function AidpulseWaver(%pos,%area,%lastar,%wave,%owner)
{

InitContainerRadiusSearch(%pos, %area, $TypeMasks::VehicleObjectType | $TypeMasks::PlayerObjectType |$TypeMasks::ItemObjectType | $TypeMasks::CorpseObjectType );


while ((%targetObject = containerSearchNext()) != 0)
{
%dist = containerSearchCurrRadDamageDist();

if (%dist > %area || %dist < %lastar)
continue;

%wave.AidEffect(%targetobject,%owner,%pos);
}

}

function RepairWave::AidEffect(%block,%obj,%owner,%pos)
{
if (!isObject(%obj) || %obj.isforceField())
return "";
%obj.playShieldEffect("1 1 1");
%obj.setDamageLevel(0);
}

function CloakWave::AidEffect(%block,%obj,%owner,%pos)
{
if (!isObject(%obj) || %obj.isforceField())
return "";
Cancel(%obj.uncloaksch);
%obj.setCloaked(True);
%obj.uncloaksch = %obj.schedule(60000,"setCloaked",False);
}

function DisWave::AidEffect(%block,%obj,%owner,%Pos)
{

if (%obj.isRemoved || !isObject(%owner) || !isObject(%obj))
return;
%dataBlockName = %obj.getDataBlock().getName();
if (%dataBlockName $= "StationInventory" ||
%dataBlockName $= "GeneratorLarge" ||
%dataBlockName $= "SolarPanel" ||
%dataBlockName $= "SensorMediumPulse" ||
%dataBlockName $= "SensorLargePulse")
if (%obj.deployed != true)
return;
if ($reverseDeployItem[%obj.getDataBlock().getName()] $= "")
return;
if (%obj.team != %owner.team &&
!(%owner.isAdmin || %owner.isSuperAdmin))
return;
if ($Host::OnlyOwnerCascade == 1 &&
%obj.getOwner() != %owner &&
!(%owner.isAdmin || %owner.isSuperAdmin))
return;

%obj.getDataBlock().disassemble(%owner, %obj); // Run Item Specific code.

}

function ESPWave::AidEffect(%block,%obj,%owner,%pos)
{
if (!isObject(%obj))
return "";
%hadsch = %obj.uncloacksch ? 1 : 0;
Cancel(%obj.uncloaksch);
if (!%obj.isforcefield())
%obj.setCloaked(FALSE);
Cancel(%obj.unemplockschd);
if (%obj.isVehicle())
vehemplock(%obj);
else if (%obj.isPlayer())
PlayerEmpLock(%obj);
else if (%obj.getDatablock().maxEnergy !$= "")
{
if (%obj.getDataBlock().className $= "Generator" && %obj.lastState)
{
if (!%hadsch)
toggleGenerator(%obj,0);
%obj.unemplockschd = schedule(30000,%obj," toggleGenerator",%obj,0);
}
%obj.setEnergyLevel(0);
}
}

function MORWave::AidEffect(%block,%obj,%owner,%pos)
{
if (%obj.isRemoved ||
!isObject(%owner) ||
!isObject(%obj) ||
%obj.isPLayer() ||
%obj.isVehicle())
return;
if (!(deployables.isMember(%obj)))
return;
%dataBlockName = %obj.getDataBlock().getName();
if (%dataBlockName $= "StationInventory" ||
%dataBlockName $= "GeneratorLarge" ||
%dataBlockName $= "SolarPanel" ||
%dataBlockName $= "SensorMediumPulse" ||
%dataBlockName $= "SensorLargePulse")
if (%obj.deployed != true)
return;

if (%obj.team != %owner.team &&
!(%owner.isAdmin || %owner.isSuperAdmin))
return;
if ($Host::OnlyOwnerCascade == 1 &&
%obj.getOwner() != %owner &&
!(%owner.isAdmin || %owner.isSuperAdmin))
return;

Cancel(%obj.unmorphsch);
%obj.unmorphsch = Schedule(30000,%obj,"ResetMorphObject",%obj);
if (%obj.morphed)
return;

%obj.oldcenter = %obj.getEdge("0 0 0");
%obj.oldrealsize = %obj.getrealSize();
%obj.morphed = 1;

%size = %owner.morphpulsesize ? %owner.morphpulsesize : 0.1;
%scale = VectorScale("1 1 1",%size);
%offset = VectorMultiply(VectorSub(%obj.getEdge("0 0 0"),%pos),%scale);
%obj.setRealSize(VectorMultiply(%obj.getRealSize(),%scale));
%obj.setEdge(VectorAdd(%pos,%offset),"0 0 0");
if (!%obj.isforcefield())
%obj.startfade(500,0,0);
if (isObject(%obj.pzone))
{
%obj.pzone.setScale(%Obj.getScale);
%obj.pzone.setTransform(%obj.getTransform());
}
if (isObject(%obj.emitter))
{
%obj.emitter.oldsize = %obj.getScale();
%obj.emitter.setScale(VectorScale(%obj.emitter.getScale(),%size));
%obj.emitter.setTransform(%obj.getTransform());
}
if (isObject(%obj.trigger))
{
%obj.trigger.oldsize = %obj.getScale();
%obj.trigger.setScale(VectorScale(%obj.trigger.getScale(),%size));
%obj.trigger.setTransform(%obj.getTransform());
}
}

//ESP functions

function vehemplock(%vehicle)
{
Cancel(%vehicle.unemplockschd);
Cancel(%vehicle.lockff.unemplockschd);
%vehicle.setFrozenState(true);
%vehicle.zapObject();
forceFieldLock(%vehicle);
%vehicle.unemplockschd = Schedule(30000,%vehicle,"vehUnEmpLock",%vehicle);
%vehicle.lockff.unemplockschd = %vehicle.lockff.Schedule(30000,"delete");
}

function vehUnEmpLock(%vehicle)
{
Cancel(%vehicle.unemplockschd);
Cancel(%vehicle.lockff.unemplockschd);
%vehicle.lockff.delete();
%vehicle.setFrozenState(false);
}

function PlayerEmpLock(%player)
{
Cancel(%player.unemplockschd);
Cancel(%player.lockff.unemplockschd);
Cancel(%player.lock.unemplockschd);
if (!%player.isemped)
{
%lock = new StaticShape()
{
dataBlock = SelectionPad;
scale = "0.01 0.01 0.01";
};
%lock.startFade(0,0,1);
%vec = VectorNormalize(%player.getVelocity());
%vec = (VectorLen(%vec)>0.1) ? %vec : "0 0 1";
%center = %player.getEdge("0 0 0");
%rot = fullrot(%vec,VectorCross(%player.getEyeVector(),%vec));
%player.setTransform(%player.getEdge("0 0 -1") SPC %rot);
%player.setEdge(%center,"0 0 0");
%lock.setTransform(getWords(%player.getTransform(),0,2) SPC %rot);
%lock.mountObject(%player,0);
%lock.player = %player;
%player.emplock = %lock;
%player.isemped = 1;
%player.zapObject();
forceFieldLock(%player);
}
%player.unemplockschd = Schedule(30000,%player,"PlayerUnEmpLock",%player);
if (isObject(%player.lock))
%player.lock.unemplockschd = %player.lock.Schedule(30000,"delete");
if (isObject(%player.lockff))
%player.lockff.unemplockschd = %player.lockff.Schedule(30000,"delete");
}

function PlayerUnEmpLock(%player)
{
%player.isemped = 0;
Cancel(%player.unemplockschd);
Cancel(%player.lockff.unemplockschd);
Cancel(%player.lock.unemplockschd);
%player.lockff.delete();
%player.unMount();
if (isObject(%player.emplock))
%player.emplock.delete();
}

function forceFieldLock(%obj)
{
if (!isObject(%obj.lockff))
{
%ff     = new ForceFieldBare() {
dataBlock = DeployedForceField5;
scale = "1 1 1";
};
%ff.noSlow = true;
// Eolk - needed a fix here to prevent console spam...
if(isObject(%ff.pzone))
%ff.pzone.delete();

%ff.pzone = "";
%obj.lockff = %ff;
%ff.obj = %obj;
%ff.setScale(%obj.getRealSize());
%ff.setTransform(%obj.getEdge("-1 -1 -1") SPC %Obj.getRotation());
}
}

//Morph functions

function ResetMorphObject(%obj)
{
Cancel(%obj.unmorphsch);
if (!%obj.isforcefield())
%obj.startfade(500,0,0);
%obj.setRealSize(%obj.oldrealsize);
%obj.setEdge(%obj.oldcenter,"0 0 0");
if (isObject(%obj.pzone))
{
%obj.pzone.setScale(%Obj.getScale);
%obj.pzone.setTransform(%obj.getTransform());
}
if (isObject(%obj.emitter))
{
%obj.emitter.setTransform(%obj.getTransform());
%obj.emitter.setScale(%obj.trigger.oldsize);
}
if (isObject(%obj.trigger))
{
%obj.trigger.setTransform(%obj.getTransform());
%obj.trigger.setScale(%obj.trigger.oldsize);
}
%obj.oldrealsize = "";
%obj.oldcenter = "";
%obj.morphed = "";
}

function resetmorphsize(%owner)
{
%size = (getRandom()*0.9+0.1);
%dir = (Getrandom()*2 > 1);
%owner.morphpulsesize = %dir ? %size : 1+%size+getRandom()*3;
}

