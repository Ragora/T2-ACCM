//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// M4 Grenade Launcher - Made by Blnukem
//------------------------------------------------------------------------------
// Ammo Data
//------------------------------------------------------------------------------

datablock GrenadeProjectileData(M4_RPGrenade)
{
   projectileShapeName = "grenade_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 0.40;
   damageRadius        = 15.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 1500;
   bubbleEmitTime      = 1.0;

   sound               = GrenadeProjectileSound;
   explosion           = "GrenadeExplosion";
   underwaterExplosion = "UnderwaterGrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = GrenadeSplash;

   baseEmitter         = GrenadeSmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;

   grenadeElasticity = 0.35;
   grenadeFriction   = 0.2;
   armingDelayMS     = 1000;
   muzzleVelocity    = 47.00;
   drag = 0.1;
};


//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(M4Ammo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some grenade launcher ammo";

   computeCRC = true;
   emap = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
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
	pickUpName = "a grenade launcher";

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

   projectile = M4_RPGrenade;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
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
   stateSound[4] = GrenadeReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = GrenadeDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
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
	Cancel(%obj.M4ClipAdd);
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
   if (%obj.inv[M4clip] > 0)
   {
	%obj.clipReloading = true;
      %obj.unmountImage(1);
      %obj.M4ClipAdd = schedule(2500, 0, "M4ReloadClip", %obj);
   }
}

function M4ReloadClip(%obj)
{
   %obj.clipReloading = false;
   %obj.decInventory(MG42Clip, 1);
   %obj.mountImage(M4Revolver, 1);
   %obj.setInventory(M4Ammo, 5);
}
