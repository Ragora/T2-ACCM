//--------------------------------------
// RPChaingun
//--------------------------------------             

datablock ParticleData(GunFireEffectSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.04;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 500;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -40.0;
   spinRandomMax =  40.0;

   colors[0]     = "0.4 0.4 0.4 0.18";
   colors[1]     = "0.5 0.5 0.5 0.14";
   colors[2]     = "0.5 0.5 0.5 0.07";
   colors[3]     = "0.6 0.6 0.6 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.75;
   sizes[2]      = 1.0;
   sizes[3]      = 1.25;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(GunFireEffectEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 3;
   velocityVariance = 2;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   lifetimeMS       = 10;

   particles = "GunFireEffectSmoke";

};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(RPChaingunBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.24;
   directDamageType    = $DamageType::MG;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   specialCollisionStreamline = true;
   HeadMultiplier      = 1.8;
   LegsMultiplier      = 0.75;

   kickBackStrength  = 100.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 2000.0; 
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 10.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
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

datablock ItemData(RPChaingunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some M32 ammo";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(RPChaingunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = RPChaingun;
   ammo 	 = RPChaingunAmmo;
   clip = MGClip;
   projectile = RPChaingunBullet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 14;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   decayingSpread = 1;
   usesClips = 1;
   muzzleFlash = OutdoorTurretMuzzleFlash;
   projectileSpread = 5 / 1000.0;
   maxSpread = 0.5 / 1000.0;
   spreadIncreaseRate = 1.5 / 1000;
   clipTimeout = 2250;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = GenericSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "CheckWet";
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
   stateTimeoutValue[3]          = 0.001;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]                  = "Fire";
   stateSequence[4]              = "Fire";
   stateSequenceRandomFlash[4]   = true;
   stateFire[4]                  = true;
   stateAllowImageChange[4]      = false;
   stateSound[4]                 = ChaingunFireSound;
   stateScript[4]                = "onFire";
   stateFire[4]                  = true;
   stateEjectShell[4]            = true;
   stateEmitter[4]               = "GunFireEffectEmitter";
   stateEmitterNode[4]           = "muzzlepoint1";
   stateEmitterTime[4]           = 0.5;
   stateRecoil[4]                = LightRecoil;
   stateTimeoutValue[4]          = 0.15;
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

   stateName[8]       = "WetFire";
   stateSound[8]      = ChaingunDryFireSound;
   stateTimeoutValue[8]        = 1.0;
   stateTransitionOnTimeout[8] = "Ready";

   stateName[9]               = "CheckWet";
   stateTransitionOnWet[9]    = "WetFire";
   stateTransitionOnNotWet[9] = "Spinup";
};

datablock ItemData(RPChaingun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = RPChaingunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "A M32 Fully Automatic Rifle";

   computeCRC = true;
   emap = true;
};

datablock ItemData(MGClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "5.56mm clips";

   computeCRC = true;
};

datablock ShapeBaseImageData(MGClipImage)
{
   shapeFile = "grenade.dts";
   ammo = RPChaingunAmmo;
   offset = "0.0 0.2 -0.2";
   emap = true;
};

function RPChaingunImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(MGClipImage, 6);
   %obj.clipReloading = false;
   if (%obj.inv[RPChaingunAmmo] == 0)
      %this.CheckForClip(%obj, %slot);
}

function RPChaingunImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(6);
   %obj.clipReloading = false;
}

function RPChaingunImage::MountClipEffects(%data, %obj, %slot)
{
   %obj.mountImage(MGClipImage, 6);
}

function RPChaingunImage::UnmountClipEffects(%data, %obj, %slot)
{
   %obj.unmountImage(6);
}

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(HRPChaingunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = HRPChaingun;
   ammo 	 = RPChaingunAmmo;
   clip = MGClip;
   projectile = RPChaingunBullet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 20;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   decayingSpread = 1;
   usesClips = 1;
   muzzleFlash = OutdoorTurretMuzzleFlash;
   projectileSpread = 1 / 1000.0; // z0dd - ZOD, 8/6/02. Was: 8.0 / 1000.0
   maxSpread = 5 / 1000.0;
   spreadIncreaseRate = 1.5 / 1000;
   clipTimeout = 2250;

    //--------------------------------------
   stateName[0]             = "Activate";
   stateSequence[0]         = "Activate";
   stateSound[0]            = GenericSwitchSound;
   stateAllowImageChange[0] = false;
   //
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
   stateSpinThread[1] = Stop;
   //
   stateTransitionOnTriggerDown[1] = "CheckWet";
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
   stateTimeoutValue[3]          = 0.001;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]                  = "Fire";
   stateSequence[4]              = "Fire";
   stateSequenceRandomFlash[4]   = true;
   stateFire[4]                  = true;
   stateAllowImageChange[4]      = false;
   stateSound[4]                 = ChaingunFireSound;
   stateScript[4]                = "onFire";
   stateFire[4]                  = true;
   stateEjectShell[4]            = true;
   stateEmitter[4]               = "GunFireEffectEmitter";
   stateEmitterNode[4]           = "muzzlepoint1";
   stateEmitterTime[4]           = 0.5;
   stateRecoil[4]                = LightRecoil;
   stateTimeoutValue[4]          = 0.15;
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

   stateName[8]       = "WetFire";
   stateSound[8]      = ChaingunDryFireSound;
   stateTimeoutValue[8]        = 1.0;
   stateTransitionOnTimeout[8] = "Ready";

   stateName[9]               = "CheckWet";
   stateTransitionOnWet[9]    = "WetFire";
   stateTransitionOnNotWet[9] = "Spinup";
};

datablock ItemData(HRPChaingun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = HRPChaingunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a M32 With a RPG Launcher";

   computeCRC = true;
   emap = true;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock GrenadeProjectileData(RPGshot)
{
   projectileShapeName = "grenade.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.4;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::RPG;
   kickBackStrength    = 3500;

   explosion           = "GrenadeExplosion";
   underwaterExplosion = "GrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 1.3;
   muzzleVelocity    = 50.0;
   drag              = 0.2;
   sound	     = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

datablock ItemData(RPGAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some M32 RPG ammo";

   computeCRC = true;
};

datablock ShapeBaseImageData(RPGLauncherImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item      = HRPChaingun;
   ammo = RPGAmmo;
   offset = "0.0 0.7 0.02"; // L/R - F/B - T/B
   emap = true;

   projectile = RPGshot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 1.0;
   stateSequence[0] = "Activate";
   stateSound[0] = GrenadeSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = GrenadeFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 4.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ItemData(RPGItem)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_energy_vehicle.dts";
   image        = RPGLauncherImage;
   mass         = 3.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "RPG Launcher";

   computeCRC = true;
   emap = true;
};

function HRPChaingunImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(RPGLauncherImage, 5);
   %obj.mountImage(MGClipImage, 6);
   %obj.clipReloading = false;
   if (%obj.inv[RPChaingunAmmo] == 0)
      %this.CheckForClip(%obj, %slot);
}

function HRPChaingunImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   %obj.clipReloading = false;
}

function HRPChaingunImage::MountClipEffects(%data, %obj, %slot)
{
   %obj.mountImage(MGClipImage, 6);
}

function HRPChaingunImage::UnmountClipEffects(%data, %obj, %slot)
{
   %obj.unmountImage(6);
}
