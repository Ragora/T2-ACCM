// ------------------------------------------------------------------
// PARACHUTE PACK
//

datablock ShapeBaseImageData(ParachutePackImage)
{
   shapeFile = "pack_upgrade_ammo.dts";
   item = ParachutePack;
   mountPoint = 1;
   offset = "0 0 0";
   mass = 10;

   usesEnergy = true;
   minEnergy = 3;

   stateName[0] = "Idle";
   stateTransitionOnTriggerDown[0] = "Activate";
   
   stateName[1] = "Activate";
   stateScript[1] = "onActivate";
   stateSequence[1] = "fire";
   stateSound[1] = CloakingPackActivateSound;
   stateEnergyDrain[1] = 1;
   stateTransitionOnTriggerUp[1] = "Deactivate";
   stateTransitionOnNoAmmo[1] = "Deactivate";

   stateName[2] = "Deactivate";
   stateScript[2] = "onDeactivate";
   stateTransitionOnTimeout[2] = "Idle";
};

datablock ItemData(ParachutePack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "pack_upgrade_ammo.dts";
   mass = 5.0;
   elasticity = 0.5;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "ParachutePackImage";
   pickUpName = "a Parachute pack";

   computeCRC = true;
};

datablock ShapeBaseImageData(parachuteImage) 
{ 
shapeFile = "Pmiscf.dts"; 
mountPoint = 1;

offset = "0.0 0.0 2.0"; // L/R - F/B - T/B
rotation = "0 0 0 0"; // L/R - F/B - T/B
}; 

function ParachutePackImage::onUnmount(%data, %obj, %node)
{
   if (%obj.getState() !$= "dead"){
	Cancel(%obj.ParaLoop);
	%obj.unmountImage(4);
   }
}

function ParachutePackImage::onActivate(%data, %obj, %slot)
{
   if(%obj.getArmorSize() $= "Light")
   {
      messageClient(%obj.client, "", "\c2Can't use this with Technician.");
      return;
   }

   messageClient(%obj.client, 'MsgParachuteOpened', '\c2Parachute opened.');
   %newspeed = vectorscale(%obj.getvelocity(),0.5);
   %obj.setvelocity(%newspeed);
   %obj.paraLoop = schedule(1000, 0, "parachuteLoop", %obj);
   %obj.mountImage(ParachuteImage, 4);
}

function ParachutePackImage::onDeactivate(%data, %obj, %slot)
{
   if(%obj.getArmorSize() $= "Light")
   {
      messageClient(%obj.client, "", "\c2Can't use this with Technician.");
      return;
   }
  
   messageClient(%obj.client, 'MsgParachuteClosed', '\c2Parachute Closed.');
   Cancel(%obj.ParaLoop);
   %obj.unmountImage(4);
}

function parachuteLoop(%obj) 
{ 
   if(isObject(%obj))
   {
	%vec = vectornormalize(%obj.getMuzzleVector($WeaponSlot));
	%move = vectorscale(%vec,10);
	%x = getword(%move,0);
	%y = getword(%move,1);
	%z = (getword(%move,2) - 15);
   	%obj.setvelocity(%x@" "@%y@" "@%z);
   	%obj.paraLoop = schedule(100, 0, "parachuteLoop", %obj); 
   }
} 
