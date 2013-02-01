// Scales
$EditorTool[1, 1] = "1 0 0 +X axis scale";
$EditorTool[1, 2] = "-1 0 0 -X axis scale";
$EditorTool[1, 3] = "0 1 0 +Y axis scale";
$EditorTool[1, 4] = "0 -1 0 -Y axis scale";
$EditorTool[1, 5] = "0 0 1 +Z axis scale";
$EditorTool[1, 6] = "0 0 -1 -Z axis scale";

// Moves
$EditorTool[2, 1] = "1 0 0 +X axis move";
$EditorTool[2, 2] = "-1 0 0 -X axis move";
$EditorTool[2, 3] = "0 1 0 +Y axis move";
$EditorTool[2, 4] = "0 -1 0 -Y axis move";
$EditorTool[2, 5] = "0 0 1 +Z axis move";
$EditorTool[2, 6] = "0 0 -1 -Z axis move";

// Rotates
$EditorTool[3, 1] = "1 0 0 +X axis rotate";
$EditorTool[3, 2] = "-1 0 0 -X axis rotate";
$EditorTool[3, 3] = "0 1 0 +Y axis rotate";
$EditorTool[3, 4] = "0 -1 0 -Y axis rotate";
$EditorTool[3, 5] = "0 0 1 +Z axis rotate";
$EditorTool[3, 6] = "0 0 -1 -Z axis rotate";

// Modifier Scales
$EditorTool[4, 1] = "0.1";
$EditorTool[4, 2] = "0.01";
$EditorTool[4, 3] = "0.001";
$EditorTool[4, 4] = "0.25";
$EditorTool[4, 5] = "0.5";
$EditorTool[4, 6] = "0.75";
$EditorTool[4, 7] = "1";
$EditorTool[4, 8] = "5";

function ETMessage(%client)
{
   if(!isObject(%client))
      return;

   %mod = (%client.player.scaler $= "" ? 0.25 : %client.player.scaler);
   if(%client.player.ETMode == 1)
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Editor Tool<<<<spop>\n<spush><font:Arial:14>Mode set to "@getwords($EditorTool[%client.player.ETMode, %client.player.ETSubMode], 3, 6)@" (Modifier: "@%mod@").<spop>", 5, 2);
   else if(%client.player.ETMode == 2)
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Editor Tool<<<<spop>\n<spush><font:Arial:14>Mode set to "@getwords($EditorTool[%client.player.ETMode, %client.player.ETSubMode], 3, 6)@" (Modifier: "@%mod@").<spop>", 5, 2);
   else if(%client.player.ETMode == 3)
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Editor Tool<<<<spop>\n<spush><font:Arial:14>Mode set to "@getwords($EditorTool[%client.player.ETMode, %client.player.ETSubMode], 3, 6)@" (Modifier: "@%mod@").<spop>", 5, 2);
   else if(%client.player.ETMode == 4)
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Editor Tool<<<<spop>\n<spush><font:Arial:14>Modifier scaler: "@$EditorTool[%client.player.ETMode, %client.player.ETSubMode]@".\nShoot to set modifier scaler.<spop>", 5, 3);
   else
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Editor Tool<<<<spop>\n<spush><font:Arial:14>Unknown mode.<spop>", 5, 2);
}

datablock ItemData(EditingTool)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_energy.dts";
   image        = EditingToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "an editing tool";

   computeCRC = true;

};

datablock ShapeBaseImageData(EditingToolImage)
{
	className = WeaponImage;
	shapeFile = "weapon_energy.dts";
	item = EditingTool;

	usesEnergy = true;
	minEnergy = 0;

	stateName[0]                     = "Activate";
	stateTransitionOnTimeout[0]      = "ActivateReady";
	stateSound[0]                    = BasicSwitchSound;
	stateTimeoutValue[0]             = 0.1;
	stateSequence[0]                 = "Activate";

	stateName[1]                     = "ActivateReady";
	stateTransitionOnLoaded[1]       = "Ready";
	stateTransitionOnNoAmmo[1]       = "NoAmmo";

	stateName[2]                     = "Ready";
	stateTransitionOnNoAmmo[2]       = "NoAmmo";
	stateTransitionOnTriggerDown[2]  = "CheckWet";

	stateName[3]                     = "Fire";
	stateTransitionOnTimeout[3]      = "Reload";
	stateTimeoutValue[3]             = 0.2;
	stateFire[3]                     = true;
	stateAllowImageChange[3]         = false;
	stateSequence[3]                 = "Fire";
    stateSound[3]                    = EditorToolFireSound;
	stateScript[3]                   = "onFire";

	stateName[4]                     = "Reload";
	stateTransitionOnTimeout[4]      = "Ready";
	stateTimeoutValue[4]             = 0.1;
	stateAllowImageChange[4]         = false;

	stateName[5]                     = "CheckWet";
	stateTransitionOnWet[5]          = "Fire";
	stateTransitionOnNotWet[5]       = "Fire";

	stateName[6]                     = "NoAmmo";
	stateTransitionOnAmmo[6]         = "Reload";
	stateTransitionOnTriggerDown[6]  = "DryFire";
	stateSequence[6]                 = "NoAmmo";

	stateName[7]                     = "DryFire";
	stateTimeoutValue[7]             = 0.1;
	stateTransitionOnTimeout[7]      = "Ready";
};

function EditingToolImage::onFire(%data,%obj,%slot)
{
   %mode = %obj.ETMode;
   if(%mode == 4)
   {
      %obj.scaler = $EditorTool[%obj.ETMode, %obj.ETSubMode];
      messageClient(%obj.client, "", "\c2ET: Modifier scaler set to "@%obj.scaler@".");
      return;
   }

   %pos = %obj.getMuzzlePoint($WeaponSlot);
   %vec = %obj.getMuzzleVector($WeaponSlot);
   %targetpos = VectorAdd(%pos, VectorScale(%vec, 200));
   %piece = containerRaycast(%pos, %targetpos, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType, %obj);
   %piece = getWord(%piece, 0);

   if(!isObject(%piece))
      return;

   // Order reversed to eliminate console spam.
   if(!isObject(Deployables) || !Deployables.isMember(%piece))
   {
      messageClient(%obj.client, "", "\c2ET: That piece is a part of the map and cannot be modified.");
      return;
   }

   if(%piece.getOwner() != %obj.client && !%obj.client.isAdmin)
   {
      messageClient(%obj.client, "", "\c2ET: You do not own that!");
      return;
   }

   if(%mode == 1)
      EditorScale(%obj, %piece);
   else if(%mode == 2)
      EditorMove(%obj, %piece);
   else if(%mode == 3)
      EditorRotate(%obj, %piece);
   else
      messageClient(%obj.client, "", "\c2ET: An error has occured: Invalid Mode. You should not see this error.");
}

function EditingToolImage::onMount(%this, %obj, %slot)
{
   parent::onMount(%this, %obj, %slot);
   if(%obj.ETmode $= "")
      %obj.ETmode = 1;
   if(%obj.ETSubMode $= "")
      %obj.ETSubMode = 1;

   ETMessage(%obj.client);
   %obj.usingEditorTool = 1;
}

function EditingToolImage::onUnmount(%this, %obj, %slot)
{
   parent::onUnmount(%this, %obj, %slot);
   %obj.usingEditorTool = 0;
}

function EditorMove(%player, %piece)
{
   if(%player.scaler $= "")
      %player.scaler = 0.25; // default to this.

   if(%piece.isDoor)
   {
      if(!%piece.canMove)
      {
         messageClient(%player.client, "", "\c2ET: You can only move stationary doors.");
         return;
      }

      if(%piece.state !$= "closed")
      {
         messageClient(%player.client, "", "\c2ET: You can only move fully closed doors.");
         return;
      }
   }

   %next = VectorScale(realvec(%piece, getWords($EditorTool[2, %player.ETSubMode], 0, 2)), %player.scaler);
   %newPos = VectorAdd(%piece.getPosition(), %next);
   %oldRot = rotFromTransform(%piece.getTransform());
   %piece.setTransform(%newPos SPC %oldRot);
   checkAfterRot(%piece);
}

function EditorScale(%player, %piece)
{
   if(%player.scaler $= "")
      %player.scaler = 0.25; // default to this.

   if(%piece.isDoor)
   {
      if(!%piece.canMove)
      {
         messageClient(%player.client, "", "\c2ET: You can only scale stationary doors.");
         return;
      }

      if(%piece.state !$= "closed")
      {
         messageClient(%player.client, "", "\c2ET: You can only scale fully closed doors.");
         return;
      }
   }

   %axis = VectorScale(getWords($EditorTool[2, %player.ETSubMode], 0, 2), %player.scaler);
   if(%piece.getDatablock().className $= "spine" || %piece.getDatablock().className $= "mspine" || %piece.getDatablock().className $= "spine2" || %piece.getDatablock().className $= "floor" || %piece.getDatablock().className $= "wall" || %piece.getDatablock().className $= "wwall" || %piece.getDatablock().className $= "floor" || %piece.getDatablock().className $= "door")
   {
      %axis = VectorScale(%axis, "0.125 0.166666 1");
      %scale = VectorAdd(%piece.getScale(), %axis);
      %check = EditorCheckScale(%scale);
      if(%check == 1)
      {
         messageClient(%player.client, "", "\c2ET: Cannot shrink any further. Piece is too small.");
         return;
      }
      else if(%check == 2)
      {
         messageClient(%player.client, "", "\c2ET: Cannot expand any further. Piece is too big.");
         return;
      }
      else if(%check != 0 && %check != 1 && %check != 2)
      {
         messageClient(%player.client, "", "\c2ET: Scale failed. You should not see this error.");
         return;
      }

      %piece.setScale(%scale);
      return;
   }

   if(%piece.getDatablock().getName() $= "DeployedLTarget")
   {
      %scale = VectorAdd(%piece.lMain.getScale(), %axis);
      %check = EditorCheckScale(%scale);
      if(%check == 1)
      {
         messageClient(%player.client, "", "\c2ET: Cannot shrink any further. Piece is too small.");
         return;
      }
      else if(%check == 2)
      {
         messageClient(%player.client, "", "\c2ET: Cannot expand any further. Piece is too big.");
         return;
      }
      else if(%check != 0 && %check != 1 && %check != 2)
      {
         messageClient(%player.client, "", "\c2ET: Scale failed. You should not see this error.");
         return;
      }

      %piece.lMain.setScale(%scale);
      adjustLMain(%piece);
      return;
   }

   if(%piece.getDatablock().getName() $= "DeployedLogoProjector")
   {
      %scale = VectorAdd(%piece.getScale(), %axis);
      %check = EditorCheckScale(%scale);
      if(%check == 1)
      {
         messageClient(%player.client, "", "\c2ET: Cannot shrink any further. Piece is too small.");
         return;
      }
      else if(%check == 2)
      {
         messageClient(%player.client, "", "\c2ET: Cannot expand any further. Piece is too big.");
         return;
      }
      else if(%check != 0 && %check != 1 && %check != 2)
      {
         messageClient(%player.client, "", "\c2ET: Scale failed. You should not see this error.");
         return;
      }

      %piece.setScale(%scale);
      if(isObject(%piece.holo))
      {
         %piece.holo.setScale(%scale);
         adjustHolo(%piece);
      }

      return;
   }

   %scale = VectorAdd(%piece.getScale(), %axis);
   %check = EditorCheckScale(%scale);
   if(%check == 1)
   {
      messageClient(%player.client, "", "\c2ET: Cannot shrink any further. Piece is too small.");
      return;
   }
   else if(%check == 2)
   {
      messageClient(%player.client, "", "\c2ET: Cannot expand any further. Piece is too big.");
      return;
   }
   else if(%check != 0 && %check != 1 && %check != 2)
   {
      messageClient(%player.client, "", "\c2ET: Scale failed. You should not see this error.");
      return;
   }

   %piece.setScale(%scale);
}

function EditorRotate(%player, %piece)
{
   if(%player.scaler $= "")
      %player.scaler = 0.25; // default to this.

   if(%piece.isDoor)
   {
      if(!%piece.canMove)
      {
         messageClient(%player.client, "", "\c2ET: You can only scale stationary doors.");
         return;
      }

      if(%piece.state !$= "closed")
      {
         messageClient(%player.client, "", "\c2ET: You can only scale fully closed doors.");
         return;
      }
   }

   %test = %piece.getEdge("0 0 0");
   %rottoadd = getWords($EditorTool[3, %player.ETSubMode], 0, 2) SPC %player.scaler;
   %oldrot = rotFromTransform(%piece.getTransform());
   %oldpos = posFromTransform(%piece.getTransform());
   %newrot = rotAdd(%oldrot, %rottoadd);
   %piece.setTransform(%oldpos SPC %newrot);
   %piece.setEdge(%test, "0 0 0");
   checkAfterRot(%piece);
}

function EditorCheckScale(%scale)
{
   if(getwordcount(%scale) < 3)
      return -1;

   %x = getword(%scale, 0);
   %y = getword(%scale, 1);
   %z = getword(%scale, 2);
   if(%x < 0.001 || %y < 0.001 || %z < 0.001)
      return 1;
   if(%x > 300 || %y > 300 || %z > 300)
      return 2;
   return 0;
}
