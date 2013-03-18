////////////////////////////////////
// AVAILABLE TEXTURES
$TextureToolLabel[1] = "Pads";
$TextureTool[1, 1] = "DeployedSpine (LSB) Light Support Beam";
$TextureTool[1, 2] = "DeployedMSpine (MSB) Medium Support Beam";
$TextureTool[1, 3] = "DeployedWWall Walk Way";
$TextureTool[1, 4] = "DeployedWall (Bwall) Shady Light Support Beam";
$TextureTool[1, 5] = "DeployedSpine2 Dark Pad";
$TextureTool[1, 6] = "DeployedDecoration16 Blue Pad";

$TextureToolLabel[2] = "Crates";
$TextureTool[2, 1] = "DeployedCrate0 (crate1) Back Pack";
$TextureTool[2, 2] = "DeployedCrate1 (crate2) small containment";
$TextureTool[2, 3] = "DeployedCrate2 (crate3) large containment";
$TextureTool[2, 4] = "DeployedCrate3 (crate4) compressor";
$TextureTool[2, 5] = "DeployedCrate4 (crate5) tubes";
$TextureTool[2, 6] = "DeployedCrate5 (crate6) quantum battery";
$TextureTool[2, 7] = "DeployedCrate6 (crate7) proton accelerator";
$TextureTool[2, 8] = "DeployedCrate7 (crate8) cargo crate";
$TextureTool[2, 9] = "DeployedCrate8 (crate9) magnetic cooler";
$TextureTool[2, 10] = "DeployedCrate9 (crate10) recycle unit";
$TextureTool[2, 11] = "DeployedCrate10 (crate11) fuel cannister";
$TextureTool[2, 12] = "DeployedCrate12 (crate12) plasma router";

$TextureToolLabel[3] = "Decorations";
$TextureTool[3, 1] = "DeployedDecoration6 (deco1) Statue Base";

$TextureToolLabel[4] = "Forcefields"; // Don't remove the "Dummy"s.
$TextureTool[4, 1] = "Dummy White, No Pass";
$TextureTool[4, 2] = "Dummy Red, No Pass";
$TextureTool[4, 3] = "Dummy Green, No Pass";
$TextureTool[4, 4] = "Dummy Blue, No Pass";
$TextureTool[4, 5] = "Dummy Cyan, No Pass";
$TextureTool[4, 6] = "Dummy Magenta, No Pass";
$TextureTool[4, 7] = "Dummy Yellow, No Pass";
$TextureTool[4, 8] = "Dummy White, Team Pass";
$TextureTool[4, 9] = "Dummy Red, Team Pass";
$TextureTool[4, 10] = "Dummy Green, Team Pass";
$TextureTool[4, 11] = "Dummy Blue, Team Pass";
$TextureTool[4, 12] = "Dummy Cyan, Team Pass";
$TextureTool[4, 13] = "Dummy Magenta, Team Pass";
$TextureTool[4, 14] = "Dummy Yellow, Team Pass";
$TextureTool[4, 15] = "Dummy White, All Pass";
$TextureTool[4, 16] = "Dummy Red, All Pass";
$TextureTool[4, 17] = "Dummy Green, All Pass";
$TextureTool[4, 18] = "Dummy Blue, All Pass";
$TextureTool[4, 19] = "Dummy Cyan, All Pass";
$TextureTool[4, 20] = "Dummy Magenta, All Pass";
$TextureTool[4, 21] = "Dummy Yellow, All Pass";
$TextureTool[4, 22] = "Dummy Lightning, Solid";
$TextureTool[4, 23] = "Dummy Scan Line, Solid";
$TextureTool[4, 24] = "Dummy Grid, Solid";
$TextureTool[4, 25] = "Dummy Fire Wall, Solid";
$TextureTool[4, 26] = "Dummy Energy Field, Solid";
$TextureTool[4, 27] = "Dummy Flashing, Solid";
$TextureTool[4, 28] = "Dummy Dirty Window, Solid";
$TextureTool[4, 29] = "Dummy Scan Line, Team Pass";
$TextureTool[4, 30] = "Dummy Grid, Team Pass";
$TextureTool[4, 31] = "Dummy Energy Field, Team Pass";
$TextureTool[4, 32] = "Dummy Flashing, Team Pass";
$TextureTool[4, 33] = "Dummy Scan Line, All Pass";
$TextureTool[4, 34] = "Dummy Grid, All Pass";
$TextureTool[4, 35] = "Dummy Energy Field, All Pass";
$TextureTool[4, 36] = "Dummy Flashing, All Pass";
$TextureTool[4, 37] = "Dummy Fire Wall, All Pass";
$TextureTool[4, 38] = "Dummy Lava, All Pass";
$TextureTool[4, 39] = "Dummy Water, All Pass";
$TextureTool[4, 40] = "Dummy Flashing Crossairs, Special";
$TextureTool[4, 41] = "Dummy Glass Tile, Special";
$TextureTool[4, 42] = "Dummy Vehicle Icons, Special";
$TextureTool[4, 43] = "Dummy Space 1, Special";
$TextureTool[4, 44] = "Dummy Clouds 1, Special";
$TextureTool[4, 45] = "Dummy Fuzzy Scanlines, Special";
$TextureTool[4, 46] = "Dummy Space 2, Special";
$TextureTool[4, 47] = "Dummy Signs, Special";
$TextureTool[4, 48] = "Dummy Clouds 2, Special";
$TextureTool[4, 49] = "Dummy Computer Screen, Special";
$TextureTool[4, 50] = "Dummy Console, Special";
$TextureTool[4, 51] = "Dummy Standard Force Field, Special";

$TextureToolLabel[5] = "Turn Pad into Door";
$TextureTool[5, 1] = "Regular Pad (not door)";
$TextureTool[5, 2] = "Normal Door";
$TextureTool[5, 3] = "Toggle Door";
$TextureTool[5, 4] = "Power Change Toggle Door (Open When Powered)";
$TextureTool[5, 5] = "Power Change Toggle Door (Closed When Powered)";
$TextureTool[5, 6] = "Collision Door (All Access)";
$TextureTool[5, 7] = "Collision Door (Permission Access)";
$TextureTool[5, 8] = "Collision Door (Owner-only Access)";
$TextureTool[5, 9] = "Collision Door (Admin-only Access)";

////////////////////////////////////
// WEAPON
datablock ItemData(TextureTool)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_targeting.dts";
   image        = TextureToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a texturing tool";

   computeCRC = true;

};

datablock ShapeBaseImageData(TextureToolImage)
{
	className = WeaponImage;
	shapeFile = "weapon_targeting.dts";
	item = TextureTool;

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
    stateSound[3]                    = MergeToolFireSound;
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

////////////////////////////////////
// SUPPORTING FUNCTIONS
function TextureToolImage::onFire(%data,%obj,%slot)
{
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
      messageClient(%obj.client, "", "\c2TT: That piece is a part of the map and cannot be modified.");
      return;
   }

   if(%piece.getOwner() != %obj.client && !%obj.client.isAdmin)
   {
      messageClient(%obj.client, "", "\c2TT: You do not own that!");
      return;
   }

   if(%obj.TTMode == 4)
      RetextureForcefield(%obj, %piece, %obj.TTSubMode - 1);
   else if(%obj.TTMode == 5)
      RetextureDoor(%obj, %piece, %obj.TTSubMode);
   else
      RetexturePad(%obj, %piece, getWord($TextureTool[%obj.TTMode, %obj.TTSubMode], 0));
}

function TextureToolImage::onMount(%data, %obj, %slot)
{
   parent::onMount(%data, %obj, %slot);

   if(%obj.TTMode $= "")
      %obj.TTMode = 1;
   if(%obj.TTSubMode $= "")
      %obj.TTSubMode = 1;

   TTMessage(%obj.client);
   %obj.usingTextureTool = 1;
}

function TextureToolImage::onUnmount(%data, %obj, %slot)
{
   parent::onUnmount(%data, %obj, %slot);
   %obj.usingTextureTool = 0;
}

function TTMessage(%client)
{
   if(!isObject(%client))
      return;

   if(%client.player.TTMode == 5)
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Texture Tool<<<<spop>\n<spush><font:Arial:14>Texture tool mode set to "@$TextureToolLabel[%client.player.TTMode]@"\nCurrent door swap set to "@$TextureTool[%client.player.TTMode, %client.player.TTSubMode]@".<spop>", 5, 3);
   else
      Bottomprint(%client, "<spush><font:Sui Generis:14>>>>Texture Tool<<<<spop>\n<spush><font:Arial:14>Texture category set to "@$TextureToolLabel[%client.player.TTMode]@"\nCurrent texture set to "@getWords($TextureTool[%client.player.TTMode, %client.player.TTSubMode], 1, 10)@".<spop>", 5, 3);
}

function RetextureForcefield(%player, %piece, %ff)
{
   if(%piece.getDatablock().className !$= "forcefield")
   {
      messageClient(%player.client, "", "\c2TT: Wrong type of object.");
      return;
   }

   %new = new ForceFieldBare() {
      datablock = "DeployedForceField"@%ff;
      scale = %piece.getScale();
   };

   %new.setTransform(%piece.getTransform());

   // Each time a forcefield is added, the game automatically adds a new physical zone.
   // We want to make our own, so we'll delete theirs.
   if(isObject(%new.pzone))
      %new.pzone.delete();

   // Set up all of the statistics and junk -----------------------

   // Can't forget this...
   if(%piece.noSlow)
      %new.noSlow = true;

   %new.grounded = %piece.grounded;
   %new.needsFit = %piece.needsFit;

   %new.team = %piece.team;
   %new.setOwner(%piece.getOwner().player);

   %new.powerFreq = %piece.powerFreq;

   if (%new.getTarget() != -1)
      setTargetSensorGroup(%new.getTarget(), %piece.team);

   addToDeployGroup(%new);

   AIDeployObject(%new.getOwner(), %new);

   // Don't increment the team count.

   checkPowerObject(%new);

   // Now we delete the old piece.
   if(isObject(%piece.pzone))
      %piece.pzone.delete();

   %piece.delete();
}

function RetexturePad(%player, %piece, %datablock)
{
   %classname = %piece.getDatablock().className;
   if((%classname $= "decoration" && (%piece.getDataBlock().getname() $= "DeployedDecoration6" || %piece.getDataBlock().getname() $= "DeployedDecoration16")) || %classname $= "crate" || %classname $= "floor" || %classname $= "spine" || %classname $= "mspine" || %classname $= "wall" || %classname $= "wwall" || %classname $= "Wspine" || %classname $= "Sspine" || %classname $= "floor" || %classname $= "door")
   {
//      %datablock = getword($EditorTool[5, %player.ETSubMode], 0);
      if(%piece.isdoor || %piece.getDatablock().getName() $= "Deployeddoor")
      {
         if(%piece.canMove == false)
         {
            messageClient(%player.client, "", "\c2You can only retexture moveable doors.");
            return;
         }

         if(%piece.state !$= "closed" && %piece.state !$= "")
         {
            messageClient(%player.client, "", "\c2You can only retexture fully closed doors.");
            return;
         }
      }

      %new = new StaticShape() {
         datablock = %datablock;
      };

      %new.setRealSize(%piece.getRealSize());
      %new.setTransform(%piece.getTransform());

      // Eolk - no dsurface.
      %new.grounded = %piece.grounded;
      %new.needsFit = %piece.needsFit;

      %new.team = %piece.team;

      %new.setOwner(%piece.getOwner().player);

      %new.powerFreq = %piece.powerFreq;
      %new.originalPos = %piece.originalPos;

      if (%new.getTarget() != -1)
         setTargetSensorGroup(%new.getTarget(), %piece.team);

      addToDeployGroup(%new);

      AIDeployObject(%piece.getOwner(), %new);

      // TODO: Make incrementing/decrementing possible for teamdeploycounts.

      %new.deploy();

      checkPowerObject(%new);

      if(%piece.isDoor || %piece.getDatablock().getName() $= "DeployedDoor")
      {
         %new.closedScale = %piece.getScale();
         %new.openedScale = getword(%piece.getScale(), 0) SPC getword(%piece.getScale(), 1) SPC 0.1;
         %new.isDoor = 1;
         %new.state = %piece.state;
         %new.canMove = %piece.canMove;
         %new.moving = %piece.moving;
         %new.toggleType = %piece.toggleType;
         %new.powerControl = %piece.powerControl;
         %new.toggleType = %piece.toggleType;
         %new.collisionType = %piece.collisionType;
         %new.accessLevel = %piece.accessLevel;
         %new.timeout = %piece.timeout;
      }

      %piece.delete();
   }
   else
      messageClient(%player.client, "", "\c2TT: Wrong type of object.");
}

function RetextureDoor(%player, %piece, %mode)
{
   %classname = %piece.getDatablock().className;
   if((%classname $= "decoration" && %piece.getDataBlock().getname() $= "DeployedDecoration6") || %classname $= "crate" || %classname $= "floor" || %classname $= "spine" || %classname $= "mspine" || %classname $= "wall" || %classname $= "wwall" || %classname $= "Wspine" || %classname $= "Sspine" || %classname $= "floor" || %classname $= "door")
   {
      if(%piece.isDoor || %piece.getDatablock.className $= "door")
      {
         if(!%piece.canMove)
         {
            messageClient(%player.client, "", "\c2TT: You can only texture moveable doors.");
            return;
         }

         if(%piece.state !$= "closed" && %piece.state !$= "")
         {
            messageClient(%player.client, "", "\c2TT: You can only texture fully closed doors.");
            return;
         }
      }

      %timeout = (%piece.timeout $= "" ? 1 : %piece.timeout);
      if(%mode == 1)
      {
         %piece.isDoor = 0;
         if(%piece.getDatablock().getName() $= "DeployedDoor")
            %piece.setDatablock(DeployedSpine); // Risky...?

         %piece.state = "";
         %piece.canMove = "";
         %piece.moving = "";
         %piece.toggleType = "";
         %piece.collisionType = "";
         %piece.accessLevel = "";
         %piece.closedScale = "";
         %piece.openedScale = "";
         %piece.powerControl = "";
      }
      else if(%mode == 2)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 0;
         %piece.toggleType = 0;
         %piece.powerControl = 0;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
      else if(%mode == 3)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 0;
         %piece.toggleType = 1;
         %piece.powerControl = 0;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
      else if(%mode == 4)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 0;
         %piece.toggleType = 1;
         %piece.powerControl = 1;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
         checkPowerObject(%piece);
      }
      else if(%mode == 5)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 0;
         %piece.toggleType = 1;
         %piece.powerControl = 2;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
         checkPowerObject(%piece);
      }
      else if(%mode == 6)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 1;
         %piece.toggleType = 0;
         %piece.powerControl = 0;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
      else if(%mode == 7)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 2;
         %piece.toggleType = 0;
         %piece.powerControl = 0;
         %piece.accessLevel = 1;
         messageClient(%player.client, "", "\c2Use \c3/setAccess [level] \c2- to set the access level needed for this door, use \c3/setPAccess [name] [level] \c2- to set someone's access level over your pieces.");

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
      else if(%mode == 8)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 3;
         %piece.toggleType = 0;
         %piece.powerControl = 0;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
      else if(%mode == 9)
      {
         %piece.isDoor = 1;
         %piece.collisionType = 4;
         %piece.toggleType = 0;
         %piece.powerControl = 0;

         %piece.timeout = %timeout;
         %piece.canMove = true;
         %piece.state = "closed";
      }
   }
   else
      messageClient(%player.client, "", "\c2TT: Wrong type of object.");
}
