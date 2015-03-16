// ------------------------------------------------------------------
// Flamer Ammo Pack

datablock ShapeBaseImageData(FlamerAmmoPackImage)
{
   shapeFile = "ammo_plasma.dts";
   item = FlamerAmmoPack;
   mountPoint = 1;
   offset = "0 0 -0.4";
   mass = 32;
};

datablock ItemData(FlamerAmmoPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "ammo_plasma.dts";
   offset = "0 -0.2 -0.55";
   mass = 18.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "FlamerAmmoPackImage";
	pickUpName = "an flamer ammo pack";

   computeCRC = true;


//   lightType = "PulsingLight";
//   lightColor = "0.2 0.4 0.0 1.0";
//   lightTime = "1200";
//   lightRadius = "1.0";

	max[ChaingunAmmo] = 0;
	max[MortarAmmo] = 0;
	max[MissileLauncherAmmo] = 0;
	max[mgclip] = 0;
	max[SniperGunAmmo] = 0;
	max[BazookaAmmo] = 0;
	max[MG42Clip] = 0;
	max[Pistolclip] = 0;
	max[FlamerAmmo] = 150;
	max[AALauncherAmmo] = 0;
	max[RifleClip] = 0;
	max[ShotgunClip] = 0;
	max[RShotgunClip] = 0;
	max[LMissileLauncherAmmo] = 0;
	max[RPGAmmo] = 0;
	max[PBCAmmo] = 0;
};

function FlamerAmmoPack::onPickup(%this,%pack,%player,%amount)
{
	// %this = AmmoPack datablock
	// %pack = AmmoPack object number
	// %player = player
	// %amount = 1

	for (%idx = 0; %idx < $numAmmoItems; %idx++)
	{
		%ammo = $AmmoItem[%idx];
      	if (%pack.inv[%ammo] > 0)
      	{
      	   %amount = %pack.getInventory(%ammo);
      	   %player.incInventory(%ammo,%amount);
      	   %pack.setInventory(%ammo,0);
      	}
			else if(%pack.inv[%ammo] == -1)
			{
				// this particular type of ammo has already been exhausted for this pack;
				// don't give the player any
			}
      	else
      	{
      	   // Assume it's full if no inventory has been assigned
      	   %player.incInventory(%ammo,%this.max[%ammo]);
		}
  	}
}

function FlamerAmmoPack::onThrow(%this,%pack,%player)
{
	// %this = AmmoPack datablock
	// %pack = AmmoPack object number
	// %player = player

	%player.throwflamerAmmoPack = 1;
	dropFlamerAmmoPack(%pack, %player);
	// do the normal ItemData::onThrow stuff -- sound and schedule deletion
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function FlamerAmmoPack::onInventory(%this,%player,%value)
{
	// %this = AmmoPack
	// %player = player
	// %value = 1 if gaining a pack, 0 if losing a pack

	// the below test is necessary because this function is called everytime the ammo
	// pack gains or loses an item
	if(%player.getClassName() $= "Player")
	{
		if(!%value)
			if(%player.throwflamerAmmoPack == 1)
			{
				%player.throwflamerAmmoPack = 0;
			}
			else
			{
				dropflamerAmmoPack(-1, %player);
			}
	}
   Pack::onInventory(%this,%player,%value);
}

function dropFlamerAmmoPack(%packObj, %player)
{
	// %packObj = Ammo Pack object number if pack is being thrown, -1 if sold at inv station
	// %player = player object

	for(%i = 0; %i < $numAmmoItems; %i++)
	{
		%ammo = $AmmoItem[%i];
		%pAmmo = %player.getInventory(%ammo);
		%pMax = %player.getDatablock().max[%ammo];
		if(%pAmmo > %pMax)
		{
			if(%packObj > 0)
			{
				%packObj.setInventory(%ammo, %pAmmo - %pMax);
			}
			%player.setInventory(%ammo, %pMax);
		}
		else
		{
			if(%packObj > 0)
			{
				%packObj.inv[%ammo] = -1;
			}
		}
	}
}