//--------------------------------------------------------------------------
// Chaingun barrel pack
//--------------------------------------------------------------------------

datablock ShapeBaseImageData(artilleryBarrelPackImage)
{
mass = 15;

shapeFile = "pack_barrel_fusion.dts";
item = artilleryBarrelPack;
mountPoint = 1;
offset = "0 0 0";
turretBarrel = "artilleryBarrelLarge";

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

datablock ItemData(artilleryBarrelPack)
{
className = Pack;
catagory = "Packs";
shapeFile = "pack_barrel_fusion.dts";
mass = 1;
elasticity = 0.2;
friction = 0.6;
pickupRadius = 2;
rotate = true;
image = "artilleryBarrelPackImage";
pickUpName = "a artillery barrel pack";

computeCRC = true;

};

function artilleryBarrelPackImage::onActivate(%data, %obj, %slot)
{
checkTurretMount(%data, %obj, %slot); // This cheks if there is a turret where the player is aiming.
}

function artilleryBarrelPackImage::onDeactivate(%data, %obj, %slot)
{
%obj.setImageTrigger($BackpackSlot, false);
}

function artilleryBarrelPack::onPickup(%this, %obj, %shape, %amount)
{
// created to prevent console errors
}