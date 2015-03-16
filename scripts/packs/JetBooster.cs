//------------------------------------------
// Jet Booster Pack
// Made by: Blnukem.
//------------------------------------------
//------------------------------------------

datablock ShapeBaseImageData(BoosterPackImage)
{
   shapeFile = "pack_upgrade_energy.dts";
   item = BoosterPack;
   mountPoint = 1;
   offset = "0 0 0";
   rechargeRateBoost = 1.5;

   minRankPoints = 2550;

	stateName[0] = "default";
	stateSequence[0] = "activation";
};

datablock ItemData(BoosterPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "pack_upgrade_energy.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "BoosterPackImage";
   pickUpName = "a jet booster pack";

   computeCRC = true;

};

function BoosterPackImage::onMount(%data, %obj, %node)
{
   %obj.setrechargeRate(%obj.getrechargeRate() + %data.rechargeRateBoost); // Allows the charging boost
   %obj.hasBoosterPack = true;
}

function BoosterPackImage::onUnmount(%data, %obj, %node)
{
   %obj.setrechargeRate(%obj.getrechargeRate() - %data.rechargeRateBoost); // Takes away the charging boost when the pack is gone
   %obj.hasBoosterPack = "";
}

function BoosterPack::onPickup(%this, %obj, %shape, %amount)
{
// Prevents Console Errors
}
