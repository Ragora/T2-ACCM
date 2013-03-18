//--------------------------------------
// bazooka
//--------------------------------------

datablock ParticleData(BazookaFireEffectSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.25;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 500;
   lifetimeVarianceMS   = 50;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -40.0;
   spinRandomMax =  40.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "1.0 0.5 0.0 0.3";
   colors[1]     = "0.6 0.6 0.0 0.2";
   colors[2]     = "0.4 0.4 0.4 0.1";
   colors[3]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;
   sizes[3]      = 2.5;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(BazookaFireEffectEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 3.0;

   ejectionVelocity = 12.0;
   velocityVariance = 0.0;

   thetaMin         = 178.0;
   thetaMax         = 180.0;

   lifetimeMS       = 20;

   particles = "BazookaFireEffectSmoke";

};


//--------------------------------------------------------------------------
// Projectile
//--------------------------------------
datablock GrenadeProjectileData(Bazookashot)
{
   projectileShapeName = "weapon_missile_projectile.dts";
   emitterDelay        = -1;
   directDamage        = 0.0;
   hasDamageRadius     = true;
   indirectDamage      = 1.5;
   damageRadius        = 8.5;
   radiusDamageType    = $DamageType::Bazooka;
   kickBackStrength    = 1000;

   explosion           = "MissileExplosion";
   underwaterExplosion = "MissileExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = MissileFireEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 0.37;
   muzzleVelocity    = 150.0;
   drag              = 0.1;
   sound	     = MissileProjectileSound;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";

};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(BazookaAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some missiles";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ItemData(Bazooka)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_missile.dts";
   image = BazookaImage;
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Bazooka MK III";

   computeCRC = true;
   emap = true;
};

datablock ShapeBaseImageData(BazookaImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item = Bazooka;
   ammo = BazookaAmmo;
   offset = "0 -0.5 0";
   armThread = lookms;
   emap = true;
   mass = 30;

   projectile = Bazookashot;
   projectileType = GrenadeProjectile;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = MissileSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "BazookaFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = HeavyRecoil;
   stateAllowImageChange[3] = false;
   stateSequence[3] = "Fire";
   stateScript[3] = "onFire";
   stateSound[3] = MissileFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 4.0;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = MissileDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";

   stateName[7]               = "CheckWet";
   stateTransitionOnWet[7]    = "WetFire";
   stateTransitionOnNotWet[7] = "Fire"; 

   stateName[8]       = "WetFire";
   stateSound[8]      = MissileDryFireSound;
   stateTimeoutValue[8]        = 1.0;
   stateTransitionOnTimeout[8] = "Ready";
};

datablock ShapeBaseImageData(BazookaMiddleImage)
{
   armThread = lookms;
   className = WeaponImage;
   shapeFile = "weapon_Mortar.dts";
   offset = "-0.1 -1.25 0.1"; 	// L/R - F/B - T/B
   rotation = "0 0 0 0"; 		// L/R - F/B - T/B
   emap = true;
};

datablock ShapeBaseImageData(BazookaBackImage)
{
   armThread = lookms;
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   offset = "0 -0.75 0"; 	// L/R - F/B - T/B
   rotation = "0 0 1 180"; 		// L/R - F/B - T/B
   emap = true;
   ammo = BazookaAmmo;
};

function BazookaImage::onFire(%data,%obj,%slot) 
{ 
   %p = Parent::onFire(%data, %obj, %slot); 
   %velocity = vectorlen(%obj.getVelocity());
   if (%velocity < 1) 
      %obj.applyKick(-750); 
   else if (%velocity > 1 && %Velocity < (%obj.maxForwardSpeed - 1)) 
      %obj.applyKick(-1750); 
   else 
      %obj.applyKick(-3250); 
}

function BazookaImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(BazookaMiddleImage, 5);
   %obj.mountImage(BazookaBackImage, 6);
}

function BazookaImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
}