//--------------------------------------
// RPChaingun
//--------------------------------------             

datablock AudioProfile(SniperFireSound)
{
   filename    = "fx/vehicles/tank_mortar_fire.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(snipergunBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.6; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::Sniper;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;
   sniperrifleHeadMultiplier = 10.0;
   closeRangeMultiplier  = 0.5;

   kickBackStrength  = 50.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 5000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 4500.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 30.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.10;
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

datablock ItemData(snipergunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some sniperrifle ammo";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(snipergunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_sniper.dts";
   item      = snipergun;
   ammo 	 = snipergunAmmo;
   projectile = snipergunBullet;
   projectileType = TracerProjectile;
   emap = true;
	armThread = looksn;
   mass = 10;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   maxSpread = 10.0 / 1000.0;

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
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.0001;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = SniperFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 2.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
   
   stateName[7]       = "WetFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";
   
   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire"; 
};

datablock ItemData(snipergun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = snipergunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a snipergun";

   computeCRC = true;
   emap = true;
};

function snipergunBullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
{
	// extra damage for head shot or less for close range shots
	if(!(%targetObject.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%targetObject.getDataBlock().getClassName() $= "PlayerData"))
	{
	   %damLoc = firstWord(%targetObject.getDamageLocation(%position));
	   %dist = vectorDist(%position, %projectile.sourceObject.getPosition());
	   if(%damLoc $= "head")
	   {
		%targetObject.getOwnerClient().headShot = 1;
		%modifier *= %data.sniperrifleHeadMultiplier;
	   }
	   else if(%damLoc $= "legs")
	   {
		%modifier *= 0.2;
	   }
	   else if (%dist <= 125)
 	   {
		%modifier *= %data.closeRangeMultiplier;
	   }
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}

function snipergunImage::onFire(%data, %obj, %slot){
   %data.lightStart = getSimTime();

   %spd = vectorLen(%obj.getVelocity());
   %spread = %data.maxSpread * (%spd / %obj.getDatablock().maxForwardSpeed);
   if(%spread > %data.maxspread)
	%spread = %data.maxspread;
   %vec = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };

   %obj.lastProjectile = %p;
   %obj.deleteLastProjectile = %data.deleteLastProjectile;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;
   %obj.decInventory(%data.ammo,1);
}
