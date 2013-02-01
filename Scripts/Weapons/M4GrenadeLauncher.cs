//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// M79 Grenade Launcher - Made by Blnukem
// NOTICE: I realized shortly after making this gun that the M4 is a rifle...
// And I was too lazy to change the datablock names...
//------------------------------------------------------------------------------
// Projectile Data
//------------------------------------------------------------------------------

datablock GrenadeProjectileData(M4_RPGrenade)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.8;
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
   muzzleVelocity    = 100.0;
   drag              = 0.2;
   sound	     = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Ammo
//------------------------------------------------------------------------------

datablock ItemData(M4Ammo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some M79 RPG ammo";

   computeCRC = true;
   emap = true;
};

//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Weapon Data
//------------------------------------------------------------------------------

datablock ItemData(M4)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_grenade_launcher.dts";
   image = M4Image;
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "a M79 RPG Launcher";

   computeCRC = true;

};

datablock ShapeBaseImageData(M4Image)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = M4;
   ammo = M4Ammo;
   offset = "0 0 0";
   emap = true;

   minRankPoints = 1250;

   projectile = M4_RPGrenade;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = BasicSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.4;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = GrenadeFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = GenericSwitchSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

datablock ShapeBaseImageData(M4Revolver) : M4Image
{
   offset = "0.0 0.5 -0.1";
   rotation = "1 0 0 90";
   shapeFile = "ammo_disc.dts";
};

function M4Image::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(M4Revolver, 1);

   if (%obj.inv[M4Ammo] == 0)
      %obj.M4checkclip = schedule(10, 0, "M4Checkforclip", %obj);
}

function M4Image::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(1);

   if (%obj.clipReloading != false)
   {
	Cancel(%obj.RifleClippAdd);
	%obj.clipReloading = false;
   }
}

function M4Image::onFire(%data,%obj,%slot)
{
   %obj.decInventory(%data.ammo,1);

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)()
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

    %obj.applyKick(-75);

   if (%obj.inv[M4Ammo] == 0)
      %obj.M4checkclip = schedule(10, 0, "M4Checkforclip", %obj);
}

function M4Checkforclip(%obj)
{
   if (%obj.inv[RifleClip] > 0)
   {
	%obj.clipReloading = true;
      %obj.unmountImage(1);
      %obj.RifleClipAdd = schedule(2500, 0, "M4ReloadClip", %obj);
   }
}

function M4ReloadClip(%obj)
{
   %obj.clipReloading = false;
   %obj.decInventory(RifleClip, 1);
   %obj.mountImage(M4Revolver, 1);
   %obj.setInventory(M4Ammo, 4);
}
