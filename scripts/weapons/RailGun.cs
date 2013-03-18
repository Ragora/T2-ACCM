//--------------------------------------
// ACCM Gauss Cannon - Made by: Blnukem
//--------------------------------------
//--------------------------------------
// RailGun Sounds
//--------------------------------------

datablock EffectProfile(RailGunFireEffect)
{
   filename    = "fx/misc/launcher.wav";
   minDistance = 2.5;
   maxDistance = 10.0;
};

datablock EffectProfile(RailGunLoadEffect)
{
   filename    = "fx/misc/cannonstart.wav";
   minDistance = 2.5;
   maxDistance = 5.0;
};

datablock AudioProfile(RailGunFireSound)
{
   filename    = "fx/misc/launcher.wav";
   description = AudioDefault3d;
   preload = true;
   effect = RailGunFireEffect;
};

datablock AudioProfile(RailGunLoadSound)
{
   filename    = "fx/misc/cannonstart.wav";
   description = AudioDefault3d;
   preload = true;
   effect = RailGunLoadEffect;
};

//--------------------------------------
// RailGun Projectile
//--------------------------------------
datablock TracerProjectileData(RailGunProjectile)
{
   doDynamicClientHits = true;

   directDamage        = 10.0 * 10;
   directDamageType    = $DamageType::Laser;
   explosion           = MissileExplosion;
   splash              = ChaingunSplash;

   hasDamageRadius     = true;
   indirectDamage      = 5.0;
   damageradius        = 8;
   radiusDamageType    = $DamageType::Laser;

   kickBackStrength  = 1000;
   sound             = ChaingunProjectile;

   dryVelocity       = 1500.0;
   wetVelocity       = 500.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 2000;
   lifetimeMS        = 2000;
   explodeOnDeath    = true;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 1000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
   tracerTex[0]  	 = "special/tracer00";
   tracerTex[1]  	 = "special/tracercross";
   tracerWidth     = 0.5;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;
   
   decalData[0] = RailGunDecal;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

//--------------------------------------
// RailGun Ammo
//--------------------------------------
datablock ItemData(RailGunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 3;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a pair of 250mm Gauss shells";

   computeCRC = true;

};

//--------------------------------------
// RailGun Data
//--------------------------------------
datablock ShapeBaseImageData(RailGunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   rotation = "0 1 0 180";
   offset = "0.1 0.0 0.18";
   item      = RailGun;
   ammo 	 = RailGunAmmo;
   projectile = RailGunProjectile;
   projectileType = TracerProjectile;
   emap = true;
   
   minRankPoints = 4800;

   //--------------------------------------
   stateName[0]             = "Activate";
   stateSound[0]            = BasicSwitchSound;
   stateAllowImageChange[0] = false;
   stateTimeoutValue[0]        = 0.5;
   stateTransitionOnTimeout[0] = "Ready";
   stateTransitionOnNoAmmo[0]  = "NoAmmo";

   //--------------------------------------
   stateName[1]       = "Ready";
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
   stateScript[3]       = "onSpinup";
   stateSpinThread[3]   = SpinUp;
   stateSound[3]        = RailGunLoadSound;
   stateTimeoutValue[3]          = 0.5;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4] = "Fire";
   stateFire[4] = true;
   stateScript[4] = "onFire";
   stateSound[4] = RailGunFireSound;
   stateRecoil[4] = LightRecoil;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 0.8;
   stateTimeoutValue[4] = 1.0;
   stateTransitionOnTimeout[4] = "Reload";
   stateAllowImageChange[4] = false;

   //--------------------------------------
   stateName[5] = "Reload";
   stateTransitionOnNoAmmo[5] = "NoAmmo";
   stateTransitionOnTimeout[5] = "Ready";
   stateTimeoutValue[5] = 1.0;
   stateAllowImageChange[5] = false;
   stateSound[5] = MissileReloadSound;

   //--------------------------------------
   stateName[6]       = "Spindown";
   stateScript[6]     = "onSpindown";
   stateSound[6]      = MissileReloadSound;
   stateSpinThread[6] = SpinDown;
   stateTimeoutValue[6]            = 3.0;
   stateWaitForTimeout[6]          = true;
   stateTransitionOnTimeout[6]     = "Ready";
   stateTransitionOnTriggerDown[6] = "Spinup";
   stateEmitter[6] = "GunFireEffectEmitter";
   stateEmitterNode[6] = "muzzlepoint1";
   stateEmitterTime[6] = 0.5;

   //--------------------------------------
   stateName[7]       = "EmptySpindown";
   stateSound[7]      = MissileDryFireSound;
   stateSpinThread[7] = SpinDown;
   stateScript[7]     = "onSpindown";
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
   stateEmitter[7] = "GunFireEffectEmitter";
   stateEmitterNode[7] = "muzzlepoint1";
   stateEmitterTime[7] = 0.5;

   //--------------------------------------
   stateName[8]       = "DryFire";
   stateSound[8]      = MortarDryFireSound;
   stateTimeoutValue[8]        = 0.5;
   stateTransitionOnTimeout[8] = "NoAmmo";
};

//--------------------------------------
// RailGun Attachments
//--------------------------------------
datablock ShapeBaseImageData(RailGunPrimaryImage) : RailGunImage
{
   offset = "0.01 0.04 0.0";
   rotation = "0 0 1 180";
   shapeFile = "weapon_missile.dts";
};

datablock ShapeBaseImageData(RailGunSecondaryImage) : RailGunImage
{
   offset = "-0.06 -0.23 0.25";
   rotation = "0 0 1 90";
   shapeFile = "ammo_mortar.dts";
};

datablock ShapeBaseImageData(RailGunTertiaryImage) : RailGunImage
{
   offset = "0.08 0.45 0.05";
   rotation = "0 1 0 0";
   shapeFile = "weapon_ELF.dts";
};

//--------------------------------------
// RailGun Item Data
//--------------------------------------
datablock ItemData(RailGun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_missile.dts";
   image        = RailGunImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a Heavy Gauss Cannon";

   emap = true;
};

//--------------------------------------
// RailGun Functions
//--------------------------------------
function RailGunImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(RailGunPrimaryImage, 4);
   %obj.mountImage(RailGunSecondaryImage, 5);
   %obj.mountImage(RailGunTertiaryImage, 6);
}

function RailGunImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
}
