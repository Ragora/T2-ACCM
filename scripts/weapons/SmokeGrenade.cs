//--------------------------------------------------------------------------
// Smoke Grenade
//--------------------------------------------------------------------------

datablock ParticleData(SmokeGrenadeSmoke)
{
   dragCoeffiecient     = 0.1;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.0;

   constantAcceleration = -0.0;
   
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -100.0;
   spinRandomMax =  100.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.3 0.3 0.3 1.0";
   colors[1]     = "0.3 0.3 0.3 0.5";
   colors[2]     = "0.3 0.3 0.3 0.0";
   sizes[0]      = 0.75;
   sizes[1]      = 6.0;
   sizes[2]      = 10.0;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(SmokeGrenadeSmokeEmitter)
{
   ejectionPeriodMS = 3;
   periodVarianceMS = 0;

   ejectionVelocity = 2.5;
   velocityVariance = 2.5;
   ejectionOffset = 3.5;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   particles = "SmokeGrenadeSmoke";
};

datablock ExplosionData(smokegrenadeExplosion)
{
   emitter[0] = SmokeGrenadeSmokeEmitter;
   shakeCamera = false;
};

//--------------------------------------------------------------------------
// Projectile - Smoke Grenade
//--------------------------------------

datablock GrenadeProjectileData(SmokeGrenadeProj)
{
   projectileShapeName = "grenade.dts";
   directDamage        = 0.0;
   directDamageType    = $DamageType::RPG;
   hasDamageRadius     = false;

   explosion           = "smokegrenadeExplosion";
   underwaterExplosion = "smokegrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   emitterDelay        = 3000;
   baseEmitter         = SmokeGrenadeSmokeEmitter;
   bubbleEmitter       = SmokeGrenadeSmokeEmitter;
   
   grenadeElasticity = 0.3;
   grenadeFriction   = 1.0;
   armingDelayMS     = 21000;

   gravityMod        = 1.0;
   muzzleVelocity    = 25.0;
   drag              = 0.0;
   sound	     = MissileProjectileSound;

   hasLight    = false;
   hasLightUnderwaterColor = false;
};


datablock ItemData(SmokeGrenadeThrown)
{
	className = Weapon;
	shapeFile = "grenade.dts";
	mass = 0.4;
	elasticity = 0.3;
   friction = 1;
   pickupRadius = 2;
   maxDamage = 0.5;
	explosion = smokegrenadeExplosion;
	underwaterExplosion = smokegrenadeExplosion;
   indirectDamage      = 0.0;
   damageRadius        = 0.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 0;
   baseEmitter         = SmokeGrenadeSmokeEmitter;

   computeCRC = true;

};

datablock ItemData(SmokeGrenade)
{
	className = HandInventory;
	catagory = "Handheld";
	shapeFile = "grenade.dts";
	mass = 1;
	elasticity = 0.5;
   friction = 1;
   pickupRadius = 2;
   thrownItem = SmokeGrenadeThrown;
	pickUpName = "some smoke grenades";
	isGrenade = true;

   computeCRC = true;

};

function SmokeGrenade::onUse(%this, %obj)
{
   if(Game.handInvOnUse(%data, %obj)) 
   {
      %obj.decInventory(%this, 1);
      %p = new GrenadeProjectile() {
         dataBlock        = SmokeGrenadeProj;
         initialDirection = %obj.getEyeVector();
         initialPosition  = getBoxCenter(%obj.getWorldBox());
         sourceObject     = %obj;
         sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));
      %p.schedule(20000, "delete");
      %obj.lastThrowTime[%data] = getSimTime();
      %obj.throwStrength = 0;
   }
}

function SmokeGrenade::onCollision( %data, %obj, %col )
{
   // Do nothing...
}



//--------------------------------------------------------------------------
// Beacon Smoke Grenade
//--------------------------------------------------------------------------

datablock ParticleData(BeaconSmokeGrenadeSmoke)
{
   dragCoeffiecient     = 0.1;
   gravityCoefficient   = -0.6;
   inheritedVelFactor   = 0.4;

   constantAcceleration = -0.0;
   
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 250;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -150.0;
   spinRandomMax =  150.0;

   textureName = "special/Smoke/smoke_001";

   colors[0]     = "0.5 0.5 0.5 1.0";
   colors[1]     = "0.6 0.2 0.2 0.75";
   colors[2]     = "0.4 0.1 0.1 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 3.0;
   sizes[2]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.2;
   times[2]      = 1.0;

};

datablock ParticleEmitterData(BeaconSmokeGrenadeSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 1.0;
   velocityVariance = 0.5;

   thetaMin         = 0.0;
   thetaMax         = 180.0;

   particles = "BeaconSmokeGrenadeSmoke";
};

//--------------------------------------------------------------------------
// Projectile - Smoke Grenade
//--------------------------------------

datablock GrenadeProjectileData(BeaconSmokeGrenadeProj)
{
   projectileShapeName = "grenade.dts";
   directDamage        = 0.0;
   directDamageType    = $DamageType::RPG;
   hasDamageRadius     = false;

   explosion           = "smokegrenadeExplosion";
   underwaterExplosion = "smokegrenadeExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   emitterDelay        = 3000;
   baseEmitter         = BeaconSmokeGrenadeSmokeEmitter;
   bubbleEmitter       = BeaconSmokeGrenadeSmokeEmitter;
   
   grenadeElasticity = 0.3;
   grenadeFriction   = 1.0;
   armingDelayMS     = 61000;

   gravityMod        = 1.0;
   muzzleVelocity    = 25.0;
   drag              = 0.0;
   sound	     = MissileProjectileSound;

   hasLight    = false;
   hasLightUnderwaterColor = false;
};


datablock ItemData(BeaconSmokeGrenadeThrown)
{
	className = Weapon;
	shapeFile = "grenade.dts";
	mass = 0.4;
	elasticity = 0.3;
   friction = 1;
   pickupRadius = 2;
   maxDamage = 0.5;
	explosion = smokegrenadeExplosion;
	underwaterExplosion = smokegrenadeExplosion;
   indirectDamage      = 0.0;
   damageRadius        = 0.0;
   radiusDamageType    = $DamageType::Grenade;
   kickBackStrength    = 0;

   computeCRC = true;

};

datablock ItemData(BeaconSmokeGrenade)
{
	className = HandInventory;
	catagory = "Handheld";
	shapeFile = "grenade.dts";
	mass = 1;
	elasticity = 0.5;
   friction = 1;
   pickupRadius = 2;
   thrownItem = BeaconSmokeGrenadeThrown;
	pickUpName = "some beacon grenades";
	isGrenade = true;

   computeCRC = true;

};

function BeaconSmokeGrenade::onUse(%this, %obj)
{
   if(Game.handInvOnUse(%data, %obj)) 
   {
      %obj.decInventory(%this, 1);
      %p = new GrenadeProjectile() {
         dataBlock        = BeaconSmokeGrenadeProj;
         initialDirection = %obj.getEyeVector();
         initialPosition  = getBoxCenter(%obj.getWorldBox());
         sourceObject     = %obj;
         sourceSlot       = 0;
      };
      MissionCleanup.add(%p);
      serverPlay3D(GrenadeThrowSound, getBoxCenter(%obj.getWorldBox()));
      %p.schedule(60000, "delete");
      %obj.lastThrowTime[%data] = getSimTime();
      %obj.throwStrength = 0;
   }
}

function BeaconSmokeGrenade::onCollision( %data, %obj, %col )
{
   // Do nothing...
}
