//--------------------------------------
// Light SMG
//--------------------------------------             

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(LSMGBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.07;
   directDamageType    = $DamageType::MP5;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   specialCollisionStreamline = true;
   HeadMultiplier      = 1.25;
   LegsMultiplier      = 0.75;

   kickBackStrength  = 15.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 1750.0; 
   wetVelocity       = 1500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 12.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.05;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(LSMGAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some MP12 ammo";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(LSMGImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item      = LSMG;
   ammo 	 = LSMGAmmo;
   clip = LSMGClip;
   projectile = LSMGBullet;
   projectileType = TracerProjectile;
   emap = true;
   offset = "0 0.5 0";  // L/R - F/B - T/B
   rotation = "0 1 0 180";
   mass = 11;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   decayingSpread = 1;
   usesClips = 1;
   projectileSpread = 1 / 1000.0;
   maxSpread = 3 / 1000;
   spreadIncreaseRate = 1.5 / 1000;
   clipTimeout = 1500;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = BasicSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
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
   //
   stateTimeoutValue[3]          = 0.01;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateRecoil[4]           = LightRecoil;
   stateAllowImageChange[4] = false;
   stateScript[4]           = "onFire";
   stateFire[4]             = true;
   stateEjectShell[4]       = true;
   stateTimeoutValue[4]          = 0.05;
   stateTransitionOnTimeout[4]   = "Fire";
   stateTransitionOnTriggerUp[4] = "Spindown";
   stateTransitionOnNoAmmo[4]    = "EmptySpindown";

   //--------------------------------------
   stateName[5]       = "Spindown";
   stateSpinThread[5] = SpinDown;
   //
   stateTimeoutValue[5]            = 0.1;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSpinThread[6] = SpinDown;
   //
   stateTimeoutValue[6]        = 0.5;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ItemData(LSMG)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_energy_vehicle.dts";
   image        = LSMGImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a MP12 SMG";

   computeCRC = true;
   emap = true;
};

datablock ItemData(LSMGClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some 6mm clips";

   computeCRC = true;
};

datablock ShapeBaseImageData(LSMGmain)
{
   ammo = LSMGAmmo;
   shapeFile = "weapon_targeting.dts";
   offset = "0.0 0.0 0.0";
   emap = true;
};

datablock ShapeBaseImageData(LSMGClipImage)
{
   shapeFile = "grenade.dts";
   ammo = LSMGAmmo;
   offset = "0.0 0.64 -0.2";
   emap = true;
};

function LSMGImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(LSMGClipImage, 5);
   %obj.mountImage(LSMGmain, 6);
   %obj.clipReloading = false;
   if (%obj.inv[LSMGAmmo] == 0)
      %this.CheckForClip(%obj, %slot);
}

function LSMGImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.clipReloading = false;
}

function LSMGImage::MountClipEffects(%data, %obj, %slot)
{
   %obj.mountImage(LSMGClipImage, 5);
}

function LSMGImage::UnmountClipEffects(%data, %obj, %slot)
{
   %obj.unmountImage(5);
}
