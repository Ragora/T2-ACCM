//--------------------------------------
// Mobile Mg42
//--------------------------------------

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock DecalData(MG42Decal1)
{
   sizeX       = 0.15;
   sizeY       = 0.15;
   textureName = "special/bullethole1";
};
datablock DecalData(MG42Decal2) : ChaingunDecal1
{
   textureName = "special/bullethole2";
};

datablock DecalData(MG42Decal3) : ChaingunDecal1
{
   textureName = "special/bullethole3";
};
datablock DecalData(MG42Decal4) : ChaingunDecal1
{
   textureName = "special/bullethole4";
};
datablock DecalData(MG42Decal5) : ChaingunDecal1
{
   textureName = "special/bullethole5";
};
datablock DecalData(MG42Decal6) : ChaingunDecal1
{
   textureName = "special/bullethole6";
};


datablock TracerProjectileData(MG42Bullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.13;
   directDamageType    = $DamageType::MG42;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   specialCollisionStreamline = true;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;

   kickBackStrength  = 50.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 3000.0;
   wetVelocity       = 1000.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 10.0/255.0 @ " " @ 30.0/255.0 @ " " @ 240.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.2;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = MG42Decal1;
   decalData[1] = MG42Decal2;
   decalData[2] = MG42Decal3;
   decalData[3] = MG42Decal4;
   decalData[4] = MG42Decal5;
   decalData[5] = MG42Decal6;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(MG42Clip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "some 7.62mm ammo boxes";

   computeCRC = true;
};

datablock ItemData(MG42Ammo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 3;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some SAW ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(MG42Image)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = MG42;
   ammo 	 = MG42Ammo;
   projectile = MG42Bullet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 26;

   offset = "0.08 0.22 0.15"; // L/R - F/B - T/B

   casing              = ShellDebris;
   shellExitDir        = "0.5 0 1";
   shellExitOffset     = "0.0 0.75 0.0";
   shellExitVariance   = 5.0;
   shellVelocity       = 4.5;

   projectileSpread = 12.5 / 1000.0;
   maxSpread = 4.5 / 1000.0;

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
   stateSound[3]        = "";
   //
   stateTimeoutValue[3]          = 0.1;
   stateWaitForTimeout[3]        = false;
   stateTransitionOnTimeout[3]   = "Fire";
   stateTransitionOnTriggerUp[3] = "Spindown";

   //--------------------------------------
   stateName[4]             = "Fire";
   stateSequence[4]            = "Fire";
   stateSequenceRandomFlash[4] = true;
   stateSpinThread[4]       = FullSpeed;
   stateSound[4]            = ChaingunFireSound;
   stateEmitter[4] = "GunFireEffectEmitter";
   stateEmitterNode[4] = "muzzlepoint1";
   stateEmitterTime[4] = 1; 
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
   stateSound[5]      = "MortarReloadSound";
   stateSpinThread[5] = SpinDown;
   stateEmitter[5] = "GunFireEffectEmitter";
   stateEmitterNode[5] = "muzzlepoint1";
   stateEmitterTime[5] = 1; 
   //
   stateTimeoutValue[5]            = 0.1;
   stateWaitForTimeout[5]          = true;
   stateTransitionOnTimeout[5]     = "Ready";
   stateTransitionOnTriggerDown[5] = "Spinup";

   //--------------------------------------
   stateName[6]       = "EmptySpindown";
   stateSound[6]      = "MortarReloadSound";
   stateSpinThread[6] = SpinDown;
   stateEmitter[6] = "GunFireEffectEmitter";
   stateEmitterNode[6] = "muzzlepoint1";
   stateEmitterTime[6] = 10; 
   //
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   //--------------------------------------
   stateName[7]       = "DryFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 0.5;
   stateTransitionOnTimeout[7] = "NoAmmo";
};

datablock ItemData(MG42)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "turret_tank_barrelchain.dts";
   image        = MG42Image;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a SAW";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(SAWImage1) 
{ 
   className = WeaponImage;
   ammo = MG42Ammo;
   shapeFile = "weapon_missile.dts"; 
   rotation = "0 0 1 180";
   offset = "0.01 0.04 0.0"; // L/R - F/B - T/B
}; 

datablock ShapeBaseImageData(SAWButtImage) 
{ 
   className = WeaponImage;
   ammo = MG42Ammo;
   shapeFile = "ammo_mortar.dts"; 
   rotation = "0 0 1 90";
   offset = "-0.06 -0.23 0.25"; // L/R - F/B - T/B
};

datablock ShapeBaseImageData(SAWImageclip) 
{ 
   className = WeaponImage;
   ammo = MG42Ammo;
   shapeFile = "ammo_chaingun.dts"; 
   offset = "0.08 0.4 -0.13"; // L/R - F/B - T/B
   item      = MG42;
};

function MG42Image::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(SawImageclip, 4);
   %obj.mountImage(SawButtImage, 5);
   %obj.mountImage(SawImage1, 6);

   if (%obj.inv[MG42Ammo] == 0)
      %obj.MG42checkclip = schedule(10, 0, "MG42Checkforclip", %obj);
}

function MG42Image::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);

   if (%obj.clipReloading != false)
   {
	Cancel(%obj.MG42ClipAdd);
	%obj.clipReloading = false;
   }
}

// Eolk - note. Don't call parent. This is NOT streamlined.
function MG42Image::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread > %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread - (0.6 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "MG42restoreSpread", %data, %obj);
   if(%obj.spread < %data.maxspread)
	%obj.spread = %data.maxspread;

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

   if (%obj.inv[MG42Ammo] == 0)
      %obj.MG42checkclip = schedule(10, 0, "MG42Checkforclip", %obj);
}

function MG42Checkforclip(%obj)
{
   if (%obj.inv[MG42clip] > 0)
   {
	%obj.clipReloading = true;
      %obj.unmountImage(4);
      %obj.MG42ClipAdd = schedule(4000, 0, "MG42ReloadClip", %obj);
   }
}

function MG42ReloadClip(%obj) 
{ 
   %obj.clipReloading = false;
   %obj.decInventory(MG42Clip, 1);
   %obj.mountImage(SawImageclip, 4);
   %obj.setInventory(MG42Ammo, 200);
} 

function MG42restoreSpread(%data, %obj){
   %obj.spread = %obj.spread + (1 / 1000);
   if(%obj.spread >= (15 / 1000)){
	%obj.spread = (15 / 1000);
	%obj.lowSpreadLoop = "";
	return;
   }
   %obj.lowSpreadLoop = schedule(150, 0, "MG42restoreSpread", %data, %obj);
}
