$NightVisionValue = 0.2;

function NightVisionLoop(%client){
   if(!isObject(%client.player))
	return;
   %client.player.setWhiteOut($NightVisionValue);
   %client.player.nightvision = schedule(50, 0, "NightVisionLoop", %client);
}

function serverCmdDoGrab(%client){
   %obj 	   = %client.player;
   if(!isObject(%obj))
	return;
  if(%obj.grabbing != 1){
   %pos        = %obj.getMuzzlePoint($WeaponSlot);
   %vec        = %obj.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
   %Tobj        = containerraycast(%pos, %targetpos, $typemasks::PlayerObjectType | $typemasks::CorpseObjectType, %obj);
   %Tobj        = getword(%Tobj,0);
   if(%Tobj.client.team == %client.team && !$TeamDamage)
      return; // Can't pickup teammates now.
   if(isObject(%Tobj)){
	if(vectorDist(%obj.getForwardVector(),%Tobj.getForwardVector()) > 1.6)
	   return;
	%armortype = %obj.getdatablock().getname();
	if(!(%armortype $= "SpecOpsMaleHumanArmor" || %armortype $= "SpecOpsFemaleHumanArmor" || %armortype $= "SpecOpsMaleBiodermArmor"))
	   return;
      if(%Tobj.grabbing == 1)
	   %Tobj.grabbing = 0;
	if(%Tobj.grabbed == 1)
	   return;
	%dataBlock  = %Tobj.getDataBlock();
	%mass  = %dataBlock.mass;
	if(%mass >= 150){
	   return;
	}
	%Tobj.grabbed = 1;
	%Tobj.setMoveState(true);
	%obj.grabbing = 1;
	schedule(100, 0, "GrabLoop", %obj, %Tobj);
   }
  }
  else
   %obj.grabbing = 0;
}

function GrabLoop(%obj, %Tobj){
   if(!(isObject(%obj) && isObject(%Tobj)))
	return;
   if(%obj.getstate() $= "dead"){
	%Tobj.setMoveState(false);
	%Tobj.grabbed = 0;
	return;
   }
   if(%obj.grabbing != 1){
	%Tobj.setMoveState(false);
	%Tobj.grabbed = 1;
	if(%Tobj.getState() !$= "Dead")
	   %Tobj.getDataBlock().damageObject(%Tobj, %obj, %Tobj.getPosition(), 10, $DamageType::blah, "0 0 1", %obj.getControllingClient(), %obj);
	return;
   }
   if(%Tobj.getMountedImage($weaponslot) !$= "")
   	%Tobj.throwWeapon();
   if(%Tobj.getMountedImage($Backpackslot) !$= "")
   	%Tobj.throwPack();
   if(%obj.getMountedImage($weaponslot) !$= "")
   	%obj.unmountImage($weaponslot);

   %pos = %obj.getPosition();
   %rot = %obj.getRotation();
   %vel = vectoradd(%obj.getvelocity(), "0 0 1");
   %vec = vectorScale(%obj.getForwardVector(),3);
   %vec = vectorAdd(%vec, "0 0 0.5");
   %Tobj.setTransform(vectorAdd(%pos, %vec)@" "@%rot);
   %Tobj.setvelocity(%vel);
   schedule(100, 0, "GrabLoop", %obj, %Tobj);
}