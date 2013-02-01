// grenade (thrown by hand) script
// ------------------------------------------------------------------------
datablock EffectProfile(FlashGrenadeExplosionEffect)
{
   effectname = "explosions/grenade_flash_explode";
   minDistance = 10;
   maxDistance = 30;
};

datablock AudioProfile(FlashGrenadeExplosionSound)
{
   filename = "fx/explosions/grenade_flash_explode.wav";
   description = AudioExplosion3d;
   preload = true;
   effect = FlashGrenadeExplosionEffect;
};

datablock ExplosionData(FlashGrenadeExplosion)
{
   explosionShape = "disc_explosion.dts";
   soundProfile   = FlashGrenadeExplosionSound;

   faceViewer     = true;
};

datablock ItemData(FlashGrenadeThrown)
{
   shapeFile = "grenade.dts";
   mass = 0.7;
   elasticity = 0.2;
   friction = 1;
   pickupRadius = 2;
   maxDamage = 0.4;
   explosion = FlashGrenadeExplosion;
   indirectDamage      = 0.2;
   damageRadius        = 12.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 1000;

   computeCRC = true;

    maxWhiteout = 1.7;
};

datablock ItemData(FlashGrenade)
{
   className = HandInventory;
   catagory = "Handheld";
   shapeFile = "grenade.dts";
   mass = 0.7;
   elasticity = 0.2;
   friction = 1;
   pickupRadius = 2;
   thrownItem = FlashGrenadeThrown;
	pickUpName = "some flash grenades";
	isGrenade = true;

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Functions:
//--------------------------------------------------------------------------
function FlashGrenadeThrown::onCollision( %data, %obj, %col )
{
   // Do nothing...
}

