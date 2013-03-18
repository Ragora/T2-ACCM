//--------------------------------------------------------------------------
// Plasma Beam Cannon
//--------------------------------------------------------------------------

datablock ShockwaveData(PBCShockwave)
{
   width = 1.0;
   numSegments = 32;
   numVertSegments = 6;
   velocity = 20;
   acceleration = 0.0;
   lifetimeMS = 1000;
   height = 4.0;
   verticalCurve = 0.5;
   is2D = false;

   texture[0] = "special/shockwave4";
   texture[1] = "special/gradient";
   texWrap = 6.0;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;

   colors[0] = "0.1 1.0 0.1 0.50";
   colors[1] = "0.8 0.8 1.0 1.0";
   colors[2] = "0.8 0.8 1.0 1.0";

   mapToTerrain = true;
   orientToNormal = false;
   renderBottom = false;
};

datablock ParticleData(PBCParticle) {
	dragCoefficient = 0.5;
	WindCoefficient = 0;
	gravityCoefficient  = 0.0;
	inheritedVelFactor  = 1;
	constantAcceleration = 0;
	lifetimeMS      = 3000;
	lifetimeVarianceMS  = 0;
	textureName     = "special/lightning1frame2";
	useInvAlpha = 0;

	spinRandomMin = -800;
	spinRandomMax = 800;

	spinspeed = 50;
	colors[0]   = "0.1 1.0 0.1 1.0";
	colors[1]   = "0.6 0.9 0.6 1.0";
	colors[2]   = "0.8 0.8 1.0 1.0";
	colors[3]   = "0.8 0.8 1.0 0.0";
	sizes[0]   = 0.5;
	sizes[1]   = 1;
	sizes[2]   = 1.5;
	sizes[3]   = 1.5;
	times[0]   = 0.0;
	times[1]   = 0.1;
	times[2]   = 0.3;
	times[3]   = 1.0;
};

datablock ParticleEmitterData(PBCExpEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionVelocity = 2.5;
   velocityVariance = 2.5;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 200;

   particles = "PBCParticle";
};

datablock ParticleEmitterData(PBCExpEmitter2)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionVelocity = 10.0;
   velocityVariance = 10.0;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 200;

   particles = "PBCParticle";
};

datablock ExplosionData(PBCsubExplosion)
{
   explosionShape = "disc_explosion.dts";
   faceViewer           = true;

   emitter[0] = PBCExpEmitter2;

   delayMS = 100;

   offset = 2.0;

   playSpeed = 1.25;

   sizes[0] = "0.3 0.3 0.3";
   sizes[1] = "0.3 0.3 0.3";
   times[0] = 0.0;
   times[1] = 1.0;

};

datablock ExplosionData(PBCexplosion)
{
   soundProfile   = sniperExpSound;

   shockwave = PBCShockwave;
   shockwaveOnTerrain = true;

   explosionShape = "disc_explosion.dts";
   faceViewer           = true;
   playSpeed = 1.5;

   sizes[0] = "1.0 1.0 1.0";
   sizes[1] = "1.0 1.0 1.0";
   times[0] = 0.0;
   times[1] = 1.0;

   emitter[0] = PBCExpEmitter;

   subExplosion[0] = PBCsubExplosion;

   shakeCamera = true;
   camShakeFreq = "10.0 11.0 10.0";
   camShakeAmp = "20.0 20.0 20.0";
   camShakeDuration = 0.5;
   camShakeRadius = 10.0;
};

//----------------------
//    Firing Effects
//----------------------

datablock ParticleData(PBCChargeSmoke)
{
   dragCoeffiecient = 0;
   WindCoefficient = 0;
   gravityCoefficient   = 0;   // rises slowly
   inheritedVelFactor   = 0.025;
   constantAcceleration = -12;

   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 0;

   useInvAlpha = 0;

   spinRandomMin = -800;
   spinRandomMax = 800;

   spinspeed = 50;

   textureName = "special/lightning1frame2";

   colors[0]     = "0.5 1.0 0.5 1.0";
   colors[1]     = "0.5 1.0 0.5 1.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.1;
   times[0]      = 0.0;
   times[1]      = 1.0;

};

datablock ParticleEmitterData(PBCChargeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.5;

   ejectionVelocity = 0.05;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   lifetimeMS       = 10;

   particles = "PBCChargeSmoke";
};

//--------------------------------------
// Projectile
//--------------------------------------

datablock TargetProjectileData(PBCTlProj)
{
   directDamage        	= 0.0;
   hasDamageRadius     	= false;
   indirectDamage      	= 0.0;
   damageRadius        	= 0.0;
   velInheritFactor    	= 1.0;

   maxRifleRange       	= 1000;
   beamColor           	= "0.1 1.0 0.1";
								
   startBeamWidth			= 0.3; //0.02
   pulseBeamWidth 	   = 0.7; //0.025
   beamFlareAngle 	   = 3.0;
   minFlareSize        	= 0.0;
   maxFlareSize        	= 400.0;
   pulseSpeed          	= 6.0;
   pulseLength         	= 0.150;

   textureName[0]      	= "special/nonlingradient";
   textureName[1]      	= "special/flare";
   textureName[2]      	= "special/pulse";
   textureName[3]      	= "special/expFlare";
   beacon               = true;
};

datablock TracerProjectileData(PBCMainProj)
{
   doDynamicClientHits = true;

   directDamage        = 1.0;
   explosion           = "PBCexplosion";
   splash              = ChaingunSplash;

   directDamageType    = $DamageType::PBC;
   kickBackStrength  = 0.0;

   sound = ShrikeBlasterProjectileSound;

   dryVelocity       = 5000.0;
   wetVelocity       = 0.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 200;
   lifetimeMS        = 200;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = true;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 45.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = "0.1 1.0 0.1 1.0";
	tracerTex[0]  	 = "special/shrikeBolt";
	tracerTex[1]  	 = "special/shrikeBoltCross";
	tracerWidth     = 4.4;
   crossSize       = 0.99;
   crossViewAng    = 0.990;
   renderCross     = true;
};

datablock DebrisData( PBCCellDebris )
{
   shapeName = "ammo_plasma.dts";

   lifetime = 5.0;

   minSpinSpeed = 0.0;
   maxSpinSpeed = 1.0;

   elasticity = 0.5;
   friction = 0.2;

   numBounces = 3;

   fade = true;
   staticOnMaxBounce = true;
   snapOnMaxBounce = true;
};

//--------------------------------------
// Rifle and item...
//--------------------------------------
datablock ItemData(PBC)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_sniper.dts";
   image        = PBCImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a Plasma Beam Cannon";

   computeCRC = true;

};

datablock ItemData(PBCAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_plasma.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "A Plasma Beam Cannon power cell";

   computeCRC = true;

};

datablock ShapeBaseImageData(PBCImage)
{
   className = WeaponImage;
   shapeFile = "weapon_mortar.dts";
   item = PBC;
   projectile = PBCMainProj;
   projectileType = TracerProjectile;
   ammo 	 = PBCAmmo;
   armThread = looksn;

   usesEnergy = false;

   casing              = PBCCellDebris;
   shellExitDir        = "0.0 0.0 -1.0"; // L/R - F/B - T/B
   shellExitOffset     = "0.0 0.0 -0.4";
   shellExitVariance   = 0.0;
   shellVelocity       = 1.0;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = ChaingunSwitchSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 1.0;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateScript[1]	    = "onReady";
   stateSpinThread[1] = Stop;
   stateTransitionOnTriggerDown[1] = "Spinup";
   stateTransitionOnNoAmmo[1]      = "NoAmmo";

   //--------------------------------------
   stateName[2]               = "NoAmmo";
   stateTransitionOnAmmo[2]   = "Ready";
   stateSpinThread[2]         = Stop;
   stateTransitionOnTriggerDown[2] = "DryFire";

   //--------------------------------------
   stateName[3]         = "Spinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = ChaingunSpinupSound;
   stateScript[3]           = "onSpinup";
   stateTimeoutValue[3]          = 2;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSpinThread[4]       = FullSpeed;

   stateEmitter[4] 	    = "PBCShootEmitter";
   stateEmitterNode[4]      = "muzzlepoint1";
   stateEmitterTime[4]      = 0.1; 
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;

   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 1.0;
   stateTransitionOnTimeout[4]   = "Spindown";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   stateScript[5]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   stateScript[6]           = "onSpindown";
   stateTimeoutValue[5]            = 1.5;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[6] = "NoAmmo";
   
   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ShapeBaseImageData(PBCTLImage)
{
   className = WeaponImage;

   shapeFile = "turret_muzzlepoint.dts";
   offset = "0 0 0";

   projectile = PBCTlProj;
   projectileType = TargetProjectile;
   deleteLastProjectile = false;

   offset = "0.1 0.75 0.0"; // L/R - F/B - T/B

   usesEnergy = true;
   minEnergy = 0;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
	stateSound[0]                    = TargetingLaserSwitchSound;
   stateTimeoutValue[0]             = 0.15;
   stateTransitionOnTimeout[0]      = "Fire";

   stateName[3]                     = "Fire";
   stateEnergyDrain[3]              = 0;
   stateFire[3]                     = true;
   stateScript[3]                   = "onFire";
};

datablock ShapeBaseImageData(PBCPowerCellImage) 
{ 
   className = WeaponImage;
   ammo = PBCAmmo;
   shapeFile = "ammo_plasma.dts"; 
   rotation = "-1 0 0 90";
   offset = "0.08 0.9 -0.3"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(PBCDummy1) 
{ 
   className = WeaponImage;
   ammo = PBCAmmo;
   shapeFile = "pack_upgrade_satchel.dts"; 
   rotation = "1 0 0 90";
   offset = "0.08 0.45 0.0"; // L/R - F/B - T/B

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";
	
   stateName[1] = "Activate";
   stateSequence[1] = "fire";
   stateTransitionOnTriggerUp[1] = "Idle";
};
datablock ShapeBaseImageData(PBCDummy2) 
{ 
   className = WeaponImage;
   ammo = PBCAmmo;
   shapeFile = "pack_upgrade_shield.dts"; 
   rotation = "0 0 1 90";
   offset = "0.05 0.55 0"; // L/R - F/B - T/B

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";
	
   stateName[1] = "Activate";
   stateSequence[1] = "fire";
   stateTransitionOnTriggerUp[1] = "Idle";
};
datablock ShapeBaseImageData(PBCDummy3) 
{ 
   className = WeaponImage;
   ammo = PBCAmmo;
   shapeFile = "pack_upgrade_shield.dts"; 
   rotation = "0 0 -1 90";
   offset = "0.12 0.55 0"; // L/R - F/B - T/B

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";
	
   stateName[1] = "Activate";
   stateSequence[1] = "fire";
   stateTransitionOnTriggerUp[1] = "Idle";
};

function PBCImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(PBCDummy1, 3);
   %obj.mountImage(PBCDummy2, 4);
   %obj.mountImage(PBCDummy3, 5);
}

function PBCImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(3);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
}
function PBCImage::onSpinup(%data,%obj,%slot){
   %obj.mountImage(PBCTLImage, 7);
   PBCCharge(%obj, 0);
   %obj.setImageTrigger(3, true);
   %obj.setImageTrigger(4, true);
   %obj.setImageTrigger(5, true);
}

function PBCImage::onSpindown(%data,%obj,%slot){
   %obj.unmountImage(7);
   %obj.setImageTrigger(3, false);
   %obj.setImageTrigger(4, false);
   %obj.setImageTrigger(5, false);
}

function PBCImage::onReady(%data,%obj,%slot)
{
   %obj.mountImage(PBCPowerCellImage, 6);
}

function PBCImage::onFire(%data,%obj,%slot){
   serverPlay3d("SniperFireSound",%obj.getmuzzlepoint(0)); 
   %p = Parent::onFire(%data, %obj, %slot);
   %obj.unmountImage(6);
}

function PBCTLImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.setTarget(%obj.team);
   %obj.PBCLP = %p;
   %p.schedule(10000, "delete");
}

function PBCTLImage::onUnmount(%this,%obj,%slot)
{
   %obj.PBCLP.delete();
   Parent::onUnmount(%this, %obj, %slot);
}

function PBCCharge(%obj,%count){
   if(!isobject(%obj))
	return;
   if(%count <= 9){
   	%charge = new ParticleEmissionDummy() 
   	{ 
   	   position = %obj.getMuzzlePoint(0);
   	   dataBlock = "defaultEmissionDummy"; 
   	   emitter = "PBCChargeEmitter"; 
      }; 
	MissionCleanup.add(%charge);
	%charge.schedule(100, "delete");
	%count++;
	%obj.PBCCharging = schedule(100, %obj, "PBCCharge", %obj, %count);
   }
}
