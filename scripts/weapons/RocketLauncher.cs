//--------------------------------------
// AA rocket launcher
//--------------------------------------          

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(AAMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 1.0;
   damageRadius        = 10.0;
   radiusDamageType    = $DamageType::Missile;
   kickBackStrength    = 2000;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 15000; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 10.0;
   maxVelocity         = 225.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 45.0;
   acceleration        = 150.0;

   proximityRadius     = 3;

   terrainAvoidanceSpeed = 50;
   terrainScanAhead      = 50;
   terrainHeightFail     = 5;
   terrainAvoidanceRadius = 1; 
   
   flareDistance = 200;
   flareAngle    = 30;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 550;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = false;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(AALauncherAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some AA rockets";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(AALauncher)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_missile.dts";
   image = AALauncherImage;
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "an AA rocket Launcher";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(AALauncherImage)
{
   className = WeaponImage;
   shapeFile = "weapon_missile.dts";
   item = AALauncher;
   ammo = AALauncherAmmo;
   offset = "0 0 0";
   armThread = lookms;
   emap = true;
   mass = 30;

   projectile = AAMissile;
   projectileType = SeekerProjectile;

   isSeeker     = true;
   seekRadius   = 400;
   maxSeekAngle = 20;
   seekTime     = 0.5;
   minSeekHeat  = 0.6;  // the heat that must be present on a target to lock it. // z0dd - ZOD, 8/22/02. Was 0.7

   // only target objects outside this range
   minTargetingDistance             = 40;
   
   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateTimeoutValue[0]             = 0.5;
   stateSequence[0]                 = "Activate";
   stateSound[0]                    = MissileSwitchSound;

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.4;
   stateFire[3]                     = true;
   stateRecoil[3]                   = mediumRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";
   stateSound[3]                    = MissileFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 4.0;
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = MissileReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = MissileDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "ActivateReady";
   
   stateName[7]                     = "CheckTarget";
   stateTransitionOnNoTarget[7]     = "DryFire";
   stateTransitionOnTarget[7]       = "Fire";
   
   stateName[8]                     = "CheckWet";
   stateTransitionOnWet[8]          = "WetFire";
   stateTransitionOnNotWet[8]       = "CheckTarget";
   
   stateName[9]                     = "WetFire";
   stateTransitionOnNoAmmo[9]       = "NoAmmo";
   stateTransitionOnTimeout[9]      = "Reload";
   stateTimeoutValue[9]             = 0.4;
   stateScript[9]                   = "onWetFire";
   stateAllowImageChange[9]         = false;
};

function AALauncherImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot);

   if (%obj.getControllingClient())
      %target = %obj.getLockedTarget();
   else
      %target = %obj.getTargetObject();

   %homein = missileCheckAirTarget(%target);
   if(%target && %homein) 
      %p.setObjectTarget(%target); 
   else if(%obj.isLocked()) 
      %p.setPositionTarget(%obj.getLockedPosition()); 
   else 
      %p.setNoTarget();  
}





//--------------------------------------
// AT4 Missile launcher
//--------------------------------------

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock SeekerProjectileData(LShoulderMissile)
{
   casingShapeName     = "weapon_missile_casement.dts";
   projectileShapeName = "weapon_missile_projectile.dts";
   hasDamageRadius     = true;
   indirectDamage      = 0.8;
   damageRadius        = 8.0;
   radiusDamageType    = $DamageType::AT4;
   kickBackStrength    = 3500;

   explosion           = "MissileExplosion";
   splash              = MissileSplash;
   velInheritFactor    = 1.0;    // to compensate for slow starting velocity, this value
                                 // is cranked up to full so the missile doesn't start
                                 // out behind the player when the player is moving
                                 // very quickly - bramage

   baseEmitter         = MissileSmokeEmitter;
   delayEmitter        = MissileFireEmitter;
   puffEmitter         = MissilePuffEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   bubbleEmitTime      = 1.0;

   exhaustEmitter      = MissileLauncherExhaustEmitter;
   exhaustTimeMs       = 300;
   exhaustNodeName     = "muzzlePoint1";

   lifetimeMS          = 3500; // z0dd - ZOD, 4/14/02. Was 6000
   muzzleVelocity      = 200.0;
   maxVelocity         = 350.0; // z0dd - ZOD, 4/14/02. Was 80.0
   turningSpeed        = 54.0;
   acceleration        = 50.0;

   proximityRadius     = 3;

   sound = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 3.0;
   lightColor  = "0.2 0.05 0";

   useFlechette = true;
   flechetteDelayMs = 10;
   casingDeb = FlechetteDebris;

   explodeOnWaterImpact = true;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(LMissileLauncherAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "an AT6 missile";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(LMissileLauncher)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = LMissileLauncherImage;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "an AT6";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(LMissileLauncherImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = LMissileLauncher;
   ammo = LMissileLauncherAmmo;
   offset = "0 -1 0";
   armThread = lookms;
   emap = true;

   projectile = LShoulderMissile;
   projectileType = seekerprojectile;
   projectileSpread = 1.0 / 2000.0;

   stateName[0]                     = "Activate";
   stateTransitionOnTimeout[0]      = "ActivateReady";
   stateTimeoutValue[0]             = 2.0;
   stateSequence[0]                 = "Activate";
   stateSound[0]                    = MissileSwitchSound;

   stateName[1]                     = "ActivateReady";
   stateTransitionOnLoaded[1]       = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "CheckWet";

   stateName[3]                     = "Fire";
   stateTransitionOnTimeout[3]      = "Reload";
   stateTimeoutValue[3]             = 0.4;
   stateFire[3]                     = true;
   stateRecoil[3]                   = LightRecoil;
   stateAllowImageChange[3]         = false;
   stateSequence[3]                 = "Fire";
   stateScript[3]                   = "onFire";
   stateSound[3]                    = MissileFireSound;

   stateName[4]                     = "Reload";
   stateTransitionOnNoAmmo[4]       = "NoAmmo";
   stateTransitionOnTimeout[4]      = "Ready";
   stateTimeoutValue[4]             = 4.5;
   stateAllowImageChange[4]         = false;
   stateSequence[4]                 = "Reload";
   stateSound[4]                    = MissileReloadSound;

   stateName[5]                     = "NoAmmo";
   stateTransitionOnAmmo[5]         = "Reload";
   stateSequence[5]                 = "NoAmmo";
   stateTransitionOnTriggerDown[5]  = "DryFire";

   stateName[6]                     = "DryFire";
   stateSound[6]                    = MissileDryFireSound;
   stateTimeoutValue[6]             = 1.0;
   stateTransitionOnTimeout[6]      = "ActivateReady";
   
   stateName[7]                     = "CheckTarget";
   stateTransitionOnNoTarget[7]     = "Fire";
   stateTransitionOnTarget[7]       = "Fire";
   
   stateName[8]                     = "CheckWet";
   stateTransitionOnWet[8]          = "DryFire";
   stateTransitionOnNotWet[8]       = "CheckTarget";
   
   stateName[9]                     = "WetFire";
   stateTransitionOnNoAmmo[9]       = "NoAmmo";
   stateTransitionOnTimeout[9]      = "Reload";
   stateTimeoutValue[9]             = 0.4;
   stateScript[9]                   = "onWetFire";
   stateAllowImageChange[9]         = false;
};

function LMissileLauncherImage::onFire(%data,%obj,%slot)
{
   %p = Parent::onFire(%data, %obj, %slot);
   %p.AT4lockon = schedule(875, 0, "AT4LockOnToTarget", %p);
}
function AT4LockOnToTarget(%p)
{ 
   if(!isObject(%p))
	return;
   InitContainerRadiusSearch(%p.getPosition(), 100, $TypeMasks::VehicleObjectType);
   %searchResult = containersearchnext();
   if(%searchResult)
   {
	%SearchObj = FirstWord(%SearchResult);
	%p.setObjectTarget(%searchObj);
   }
}