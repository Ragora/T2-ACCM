//--------------------------------------------------------------------------
// Loadout Pack
//--------------------------------------------------------------------------

datablock ShapeBaseImageData(artilleryWeaponPackImage)
{
   mass = 15;

   shapeFile = "turret_tank_barrelmortar.dts";
   item = artilleryWeaponPack;
   mountPoint = 1;
   offset = "0 -0.3 -0.75";
   rotation = "-1 0 0 90";

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";

   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateTransitionOnTriggerUp[1] = "Deactivate";

   stateName[2] = "Deactivate";
   stateScript[2] = "onDeactivate";
   stateTransitionOnTimeOut[2] = "Idle";

   isLarge = true;
};

datablock ItemData(artilleryWeaponPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "turret_tank_barrelmortar.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "artilleryWeaponPackImage";
   pickUpName = "an artillery loadout pack";

   computeCRC = true;
};

function artilleryWeaponPackImage::onMount(%data, %obj, %node){
   %obj.hasArtWepPack = true;
}

function artilleryWeaponPackImage::onUnMount(%data, %obj, %node){
   %obj.hasArtWepPack = false;
}

function artilleryWeaponPackImage::onActivate(%data, %obj, %slot)
{
   %pos = %obj.getWorldBoxCenter();
   %vec = %obj.getEyeVector();
   %vec = vectorAdd(VectorScale(%vec,5),%pos);
   %searchResult = containerRayCast(%pos, %vec, $TypeMasks::VehicleObjectType, %obj);
   if(%searchResult){
	%searchObj = getWord(%searchResult, 0);
	if(%searchObj.getDataBlock().getName() $= "Artillery"){
	   if (%obj.packset==0){
		%searchobj.turretObject.setInventory(MortarAmmo, 12);
		%searchobj.selweapontype = 1;
		%obj.unmountImage($backpackslot);
      	%obj.decInventory(artilleryWeaponPack, 1);
	   }
	   else if (%obj.packset==1){
		%searchobj.turretObject.setInventory(MortarAmmo, 6);
		%searchobj.selweapontype = 2;
		%obj.unmountImage($backpackslot);
      	%obj.decInventory(artilleryWeaponPack, 1);
	   }
	}
   }
}

function artilleryWeaponPackImage::onDeactivate(%data, %obj, %slot)
{
   %obj.setImageTrigger($BackpackSlot, false);
}

function artilleryWeaponPack::onPickup(%this, %obj, %shape, %amount){}