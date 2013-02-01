// Merge Tool v006
// Coded by Electricutioner
// Last modified: 6:22 PM 5/21/2006
// Idea by the T2 Construction Community

//Variables:
$ElecMod::MergeTool::Tolerance = 0.05; //how many meters of tolerance do we give the pieces that we merge.
$ElecMod::MergeTool::HighTolerance = 0.25; //used for "high tolerance" mode on stubborn pieces
$ElecMod::MergeTool::Timeout = 2; //how many seconds until a selection times out when using the tool

//split portion
$ElecMod::MergeTool::MinimumPieceVolume = 0.125; //50 cm cube is smallest, consider revising this to 16

//Functions:

//this function rotates and rescales pieces to create the stretch effect
function MTIsometric(%client, %piece)
{
	if (!isObject(%piece))
		return;

	if (!%client.isAdmin)
	{
		if (%client.guid != %piece.ownerguid)
		{
			messageClient(%client, 'MsgClient', "\c2IT: That piece isn't yours.");
			return;
		}
	}

	if (!%piece.isForcefield())
	{
		%piece.setCloaked(true);
		%piece.schedule(290, "setCloaked", false);
	}

	%center = %piece.getEdge("0 0 0");
	%currentSize = %piece.getRealSize();

	//this used to be one operation, but it ceased to work properly (?)
	%piece.setTransform(remoteRotate(%piece,"0 1 0 1.570796", %piece,"0 0 0"));
	%piece.setRealSize(getWord(%currentSize, 2) SPC getWord(%currentSize, 1) SPC getWord(%currentSize, 0));
	%piece.setEdge(%center, "0 0 0");
	%currentSize = %piece.getRealSize();

	%piece.setTransform(remoteRotate(%piece,"0 0 1 1.570796", %piece,"0 0 0"));
	%piece.setRealSize(getWord(%currentSize, 1) SPC getWord(%currentSize, 0) SPC getWord(%currentSize, 2));
	%piece.setEdge(%center, "0 0 0");

}

// Function by Eolk
function MTZAxisReverse(%client, %piece)
{
	if (!isObject(%piece))
		return;

	if (!%client.isAdmin)
	{
		if (%client.guid != %piece.ownerguid)
		{
			messageClient(%client, 'MsgClient', "\c2IT: That piece isn't yours.");
			return;
		}
	}

	if (!%piece.isForcefield())
	{
		%piece.setCloaked(true);
		%piece.schedule(290, "setCloaked", false);
	}

	%center = %piece.getEdge("0 0 0");
	%piece.setTransform(remoteRotate(%piece,"1 0 0 3.141593", %piece,"0 0 0"));
	%piece.setEdge(%center, "0 0 0");
}

//This is the basic initiator function. If the piece called are compatable, nothing further needs to be called.
function MTMerge(%client, %piece1, %piece2, %hiTol)
{
	if (!MTCheckCompatability(%client, %piece1, %piece2, %hiTol))
	{
		%piece1.setCloaked(false);
		%piece2.setCloaked(false);
		MTClearClientSelection();
		return;
	}
	if (!%piece1.isForcefield())
		%piece1.setCloaked(true);
	if (!%piece2.isForcefield())
		%piece2.setCloaked(true);
	schedule(100, 0, "MTScaleShiftMerge", %piece1, %piece2);

	if (isEventPending(%client.mergeschedule))
	{
		cancel(%client.mergeschedule);
		MTClearClientSelection();
	}
}

//This function checks if 4 corners of the objects are compatable. If an error is encountered it returns a 0 and
//terminates the merge. Otherwise, it returns a 1, and continues the merge process.
function MTCheckCompatability(%client, %piece1, %piece2, %hiTol)
{
	//do the pieces exist?
	if (!isObject(%piece1) || !isObject(%piece2))
	{
		messageClient(%client, 'MsgClient', "\c2MT: A piece appears to be missing.");
		return;
	}
	//check if the owners are the same
	if (%piece1.owner != %client || %piece2.owner != %client)
	{
		//with an exemption of admins
		if (!%client.isAdmin)
		{
			//fix for when players leave the server and come back
			if (%piece1.ownerGUID != %client.guid || %piece2.ownerGUID != %client.guid)
			{
				messageClient(%client, 'MsgClient', "\c2MT: One or more of those pieces do not belong to you.");
				return;
			}
		}
	}

	//now we need to determine if at least 4 of the pieces axies match
	//get all the 8 points of both pieces
	%pos1[0] = %piece1.getEdge("1 1 -1");
	%pos1[1] = %piece1.getEdge("-1 1 -1");
	%pos1[2] = %piece1.getEdge("1 -1 -1");
	%pos1[3] = %piece1.getEdge("-1 -1 -1");
	%pos1[4] = %piece1.getEdge("1 1 1");
	%pos1[5] = %piece1.getEdge("-1 1 1");
	%pos1[6] = %piece1.getEdge("1 -1 1");
	%pos1[7] = %piece1.getEdge("-1 -1 1");

	%pos2[0] = %piece2.getEdge("1 1 -1");
	%pos2[1] = %piece2.getEdge("-1 1 -1");
	%pos2[2] = %piece2.getEdge("1 -1 -1");
	%pos2[3] = %piece2.getEdge("-1 -1 -1");
	%pos2[4] = %piece2.getEdge("1 1 1");
	%pos2[5] = %piece2.getEdge("-1 1 1");
	%pos2[6] = %piece2.getEdge("1 -1 1");
	%pos2[7] = %piece2.getEdge("-1 -1 1");
	//then we compare them to see which ones match
	%k = 0;
	for (%i = 0; %i < 8; %i++)
	{
		for (%j = 0; %j < 8; %j++)
		{
			if (!%hiTol && $ElecMod::MergeTool::Tolerance >= vectorDist(%pos1[%i], %pos2[%j]))
			{
				%k++;
			}
			else if (%hiTol && $ElecMod::MergeTool::HighTolerance >= vectorDist(%pos1[%i], %pos2[%j]))
			{
				%k++;
			}
		}
	}
	//if less then 4 match, they can't be compatable (if more then 4 match... something odd is going on)
	if (%k < 4)
	{
		if (%k == 0)
			messageClient(%client, 'MsgClient', "\c2MT: None of the corners are shared on those objects. Cannot merge.");
		else
			messageClient(%client, 'MsgClient', "\c2MT: Only " @ %k @ " corners of the required 4 are shared. Cannot merge.");

		return;
	}
	else if (%k > 4)
	{
		messageClient(%client, 'MsgClient', "\c2MT: Warning: Detected match of over 4 corners (" @ %k @ "). Merging may fail to produce desired results.");
	}
	//if the check survived that, we continue...
	return 1;
}

//this function, after the pieces are confirmed, checks to see which of the 6 sides is in contact, refers to another
//function to find the alter side, determines distance between them to find a new "real" scale, and determines the
//new world box center for the object. Piece 1 is resized and moved, piece 2 is deconstructed.
function MTScaleShiftMerge(%piece1, %piece2)
{
	//find which axis is touching for a "this is the side we scale" discovery
	//table:
	//0: X
	//1: -X
	//2: Y
	//3: -Y
	//4: Z
	//5: -Z

	%p1S[0] = %piece1.getEdge("1 0 0");
	%p1S[1] = %piece1.getEdge("-1 0 0");
	%p1S[2] = %piece1.getEdge("0 1 0");
	%p1S[3] = %piece1.getEdge("0 -1 0");
	%p1S[4] = %piece1.getEdge("0 0 1");
	%p1S[5] = %piece1.getEdge("0 0 -1");

	%p2S[0] = %piece2.getEdge("1 0 0");
	%p2S[1] = %piece2.getEdge("-1 0 0");
	%p2S[2] = %piece2.getEdge("0 1 0");
	%p2S[3] = %piece2.getEdge("0 -1 0");
	%p2S[4] = %piece2.getEdge("0 0 1");
	%p2S[5] = %piece2.getEdge("0 0 -1");

	for (%i = 0; %i < 6; %i++)
	{
		for (%j = 0; %j < 8; %j++)
		{
			if ($ElecMod::MergeTool::Tolerance >= vectorDist(%p1S[%i], %p2S[%j]))
			{
				%side1 = %i;
				%side2 = %j;
			}
		}
	}
	//echo("Sides:" SPC %i SPC %j);
	//at this point %side1/2 will contain one of the numbers in the table above
	//we get the non-shared side at this point
	%ops1 = MTFindOpSide(%side1);
	%ops2 = MTFindOpSide(%side2);

	//this variable contains the new axis length that we are scaling on...
	%newaxis = VectorDist(%p1S[%ops1], %p2S[%ops2]);
	%currsize = %piece1.getRealSize();

	if (%side1 == 0 || %side1 == 1)
		%axis = "x";
	if (%side1 == 2 || %side1 == 3)
		%axis = "y";
	if (%side1 == 4 || %side1 == 5)
		%axis = "z";

	//echo("Axis:" SPC %axis);
	if (%axis $= "x")
	{
		%piece1.setRealSize(%newaxis SPC getWords(%currsize, 1, 2));
		if (isObject(%piece1.pzone))
			%piece1.pzone.setScale(%newaxis SPC getWords(%currsize, 1, 2));
	}
	if (%axis $= "y")
	{
		%piece1.setRealSize(getWord(%currsize, 0) SPC %newaxis SPC getWord(%currsize, 2));
		if (isObject(%piece1.pzone))
			%piece1.pzone.setScale(getWord(%currsize, 0) SPC %newaxis SPC getWord(%currsize, 2));
	}
	if (%axis $= "z")
	{
		%piece1.setRealSize(getWords(%currsize, 0, 1) SPC %newaxis);
		if (isObject(%piece1.pzone))
			%piece1.pzone.setScale(getWords(%currsize, 0, 1) SPC %newaxis);
	}
	if (%axis !$= "x" && %axis !$= "y" && %axis !$= "z")
	{
		error("MT: A scaling error has occured.");
		return;
	}
	%newpos = VectorScale(VectorAdd(%p1S[%ops1], %p2S[%ops2]), 0.5);
	%piece1.SetWorldBoxCenter(%newpos);

	if (isObject(%piece1.pzone))
		%piece1.pzone.setPosition(%piece1.getPosition());

	if (!%piece1.isForcefield())
		%piece1.setCloaked(false);
	if (!%piece2.isForcefield())
		%piece2.setCloaked(false);

	//%piece2.delete(); //deleting is bad
	//%piece2.getDataBlock().disassemble(0, %piece2.owner, %piece2); //disassemble is cleaner
	//fixed disassemble to use object specific disassemble functions
	//disassemble(0, %piece2.owner, %piece2);
	%piece2.getDatablock().disassemble(0, %piece2);
}

//this function does something very simple, it finds whether a number is even or odd, and then adds or subracts
//and returns the initial input with that modification. I can't imagine where else this could be useful.
function MTFindOpSide(%side)
{
	%evencheck = %side / 2;
	if (%evencheck == mFloor(%evencheck))
		%even = 1;
	else
		%even = 0;

	if (%even)
		return (%side + 1);
	else
		return (%side - 1);
}

//simply clears a client variable... woohoo...
function MTClearClientSelection(%client)
{
	%client.mergePiece1 = "";
	return;
}


//"weapon" datablocks and such
datablock ItemData(MergeTool)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_sniper.dts";
   image        = MergeToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a MIST, by Electricutioner.";

   computeCRC = true;

};

datablock ShapeBaseImageData(MergeToolImage)
{
	className = WeaponImage;
	shapeFile = "weapon_sniper.dts";
	item = MergeTool;

	usesEnergy = true;
	minEnergy = 0;

	stateName[0]                     = "Activate";
	stateTransitionOnTimeout[0]      = "ActivateReady";
	stateSound[0]                    = GenericSwitchSound;
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
	stateTimeoutValue[3]             = 0.2; //reload timeout here
	stateFire[3]                     = true;
	stateAllowImageChange[3]         = false;
	stateSequence[3]                 = "Fire";
	stateScript[3]                   = "onFire";
    stateSound[3]                    = "MergeToolFireSound";

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
	stateSound[7]                    = SniperRifleDryFireSound;
	stateTimeoutValue[7]             = 0.1;
	stateTransitionOnTimeout[7]      = "Ready";
};

function MergeToolImage::onFire(%data,%obj,%slot)
{
	serverPlay3D(SniperRifleFireSound, %obj.getTransform());
	%client = %obj.client;

	%pos = getWords(%obj.getEyeTransform(), 0, 2);
	%vec = %obj.getEyeVector();
	%targetpos = VectorAdd(%pos, VectorScale(%vec, 2000));
	%piece = containerRaycast(%pos, %targetpos, $TypeMasks::StaticShapeObjectType | $TypeMasks::ForceFieldObjectType, %obj);
	%cast = %piece;
	%piece = getWord(%piece, 0);

	if (!isObject(%piece))
		return;

	if (!Deployables.isMember(%piece))
	{
		messageClient(%client, 'MsgClient', "\c2MIST: That piece is part of the map and cannot be manipulated.");
		return;
	}

	if (!%client.isAdmin)
	{
		if (%piece.ownerGUID != %client.guid)
		{
			messageClient(%client, 'MsgClient', "\c2MIST: That piece isn't yours.");
			return;
		}
	}

	if (%client.MTMode == 0)
	{
		if (!isObject(%client.mergePiece1))
		{
			%client.mergePiece1 = %piece;

			if (!%piece.isForcefield())
			{
				%piece.setCloaked(true);
				%piece.schedule(290, "setCloaked", false);
			}

			%client.mergeschedule = schedule($ElecMod::MergeTool::Timeout * 1000, 0, "MTClearClientSelection", %client);
		}
		else
		{
			if (%piece != %client.mergePiece1)
			{
				if (%client.MTSubMode == 1)
				{
					MTMerge(%client, %client.mergePiece1, %piece, 1);
					%client.MTSubMode = 0;
					MTShowStatus(%client);
				}
				else
				{
					MTMerge(%client, %client.mergePiece1, %piece, 0);
				}
				MTClearClientSelection(%client);
			}
			else
			{
				messageClient(%client, 'MsgClient', "\c2MT: You cannot merge a piece with itself.");
				return;
			}
		}
	}
	if (%client.MTMode == 1)
	{
		if (%client.MTSubMode == 1)
			MTZAxisReverse(%client, %piece);
		else
			MTIsometric(%client, %piece);
	}
	if (%client.MTMode == 2)
	{
		if (%client.MTSubMode > 4 || %client.MTSubMode == 1)
		{
			%client.MTSplitMode = 1; //crosshair split
		}
		else
		{
			%client.MTSplitMode = 0; //half split
		}
		if (%client.MTSubMode == 0)
			%axis = "a";
		if (%client.MTSubMode == 1)
			%axis = "a";
		if (%client.MTSubMode == 2)
			%axis = "x";
		if (%client.MTSubMode == 3)
			%axis = "y";
		if (%client.MTSubMode == 4)
			%axis = "z";
		if (%client.MTSubMode == 5)
			%axis = "x";
		if (%client.MTSubMode == 6)
			%axis = "y";
		if (%client.MTSubMode == 7)
			%axis = "z";

		MTSplit(%client, %cast, %axis);
	}
}

function MergeToolImage::onMount(%this,%obj,%slot)
{
	Parent::onMount(%this, %obj, %slot);
	%obj.mountImage(MergeToolImage, 0);
	MTShowStatus(%obj.client);
}

function MTShowStatus(%client)
{
	if (%client.MTMode $= "")
		%client.MTMode = 0;
	if (%client.MTSubMode $= "")
		%client.MTSubMode = 0;

	switch (%client.MTMode)
	{
		case 0:
			switch (%client.MTSubMode)
			{
				case 0:
					%status = "<font:Arial:14>Mode: Merge. Fire the tool at two pieces. If possible, they will merge. Tolerance: " @ $ElecMod::MergeTool::Tolerance @ " meters.";
				case 1:
					%status = "<font:Arial:14>Mode: Merge. Fire the tool at two pieces. If possible, they will merge. Tolerance: " @ $ElecMod::MergeTool::HighTolerance @ " meters.";
			}
		case 1:
			switch (%client.MTSubMode)
			{
				case 0:
					%status = "<spop><font:Arial:14>Mode: Isometric. Fire at a piece. It will be rotated isometrically.";
				case 1:
					%status = "<spop><font:Arial:14>Mode: Isometric Z-axis Reversal. Fire at a piece. It's Z Axis will be reversed.";
			}
		case 2:
			switch (%client.MTSubMode)
			{
				case 0:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it in half. Axis: Automatic.";
				case 1:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it on crosshair. Axis: Automatic.";
				case 2:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it in half. Axis: X.";
				case 3:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it in half. Axis: Y.";
				case 4:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it in half. Axis: Z.";
				case 5:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it on crosshair. Axis: X.";
				case 6:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it on crosshair. Axis: Y.";
				case 7:
					%status = "<font:Arial:14>Mode: Split. Fire at a piece to split it on crosshair. Axis: Z.";
			}
	}
	CommandToClient(%client, 'BottomPrint', "<font:Sui Generis:14>>>>M/I/S Tool<<<\n<font:Arial:14>" @ %status @ "\nCoded by Electricutioner.", 3, 3 );
}

//Split code begins here.
//The goal of this is to be a semi-inverse of the merge...
//The tool will be set to split mode, and aimed at an object. The object axies are checked, and if there is one that is
//disproportionally larger then the rest, it will be split on that axis. If two or more axies are similar, it does
//a check to determine the face where the raycast hits (reducing split possibilities by one axis) and either
//spliting on the remaining axis or using position points to find out in which quadrant of the face, the raycast hit.
//Once the axis is determined, the split axis has the difference halved, a "dominant" piece rescaled and repositioned
//in steps similar to the merge, and a new (nearly-identical) piece is created in the resulting void.

//startup function, the calling client, and the raycasted piece. Note: %piece contains all raycast operations.
function MTSplit(%client, %piece, %axis)
{
	if(!MTSplitValidate(%client, %piece, %axis)) //validates the client selected piece as valid
		return;

	if (!%piece.isForcefield())
		getWord(%piece, 0).setCloaked(true);

	MTSplitScaleShift(%client, %piece, %axis); //split it up
}

//makes sure that the object can be split
function MTSplitValidate(%client, %piece, %axis)
{
	if (!isObject(getWord(%piece, 0)))
	{
		messageClient(%client, 'MsgClient', "\c2ST: The piece to split is missing. You should not see this error.");
		return;
	}

	//restricting to cubics and forcefields.
	if (!isCubic(%piece) && !%piece.isForceField())
	{
		messageClient(%client, 'MsgClient', "\c2ST: That object is not cubic and it cannot be split.");
		return;
	}

	%size = %piece.getRealSize();
	%volume = 2 * getWord(%size, 0) * 2 * getWord(%size, 1) * 2 * getWord(%size, 2);
	if (%client.MTSplitMode == 0) //half split
	{
		if ((%volume / 2) < ($ElecMod::MergeTool::MinimumPieceVolume))
		{
			messageClient(%client, 'MsgClient', "\c2ST: That piece is too small to split.");
			return;
		}
	}
	else
	{
		%hitPos = getWord(%piece, 1) SPC getWord(%piece, 2) SPC getWord(%piece, 3);
		%edge = PointToEdge(getWord(%piece, 0), %hitPos);

		//auto-axis determiner
		if (%axis $= "a")
			%axis = CalculateSplitAxis(PointToEdge(%piece, %hitPos));

		switch$ (%axis)
		{
			case "x":
				%ratio = getWord(%edge, 0);
				%ratio = (%ratio + 1) / 2;
			case "y":
				%ratio = getWord(%edge, 1);
				%ratio = (%ratio + 1) / 2;
			case "z":
				%ratio = getWord(%edge, 2);
				%ratio = (%ratio + 1) / 2;
		}

		%masterSize = %volume * %ratio;
		%slaveSize = %volume * (1 - %ratio);

		//echo(%ratio SPC %axis SPC %masterSize SPC %slaveSize);

		if (%masterSize < $ElecMod::MergeTool::MinimumPieceVolume || %slaveSize < $ElecMod::MergeTool::MinimumPieceVolume)
		{
			messageClient(%client, 'MsgClient', "\c2ST: A resultant piece from that split is too small. Aborting.");
			return;
		}
	}

	return 1; //we survived, thus we continue
}

//does the actual splitting
function MTSplitScaleShift(%client, %cast, %axis)
{
	%piece = getWord(%cast, 0);
	%copy = MTCarbonCopy(%piece); //Merge Tool Support functions

	if (!%piece.isForcefield())
	{
		%piece.setCloaked(true);
		%copy.setCloaked(true);
	}

	%hitPos = getWord(%cast, 1) SPC getWord(%cast, 2) SPC getWord(%cast, 3);

	%size = %piece.getRealSize();

	//auto axis determiner
	if (%axis $= "a")
	{
		%axis = CalculateSplitAxis(PointToEdge(%piece, %hitPos));
		//echo(%hitPos);
	}

	if (%client.MTSplitMode == 0) //split in half
	{
		%center = %piece.getWorldBoxCenter();
		%sizeFactorMaster = 2;
		%sizeFactorSlave = 2;

		switch$ (%axis)
		{
			case "x":
				%piece.setRealSize((getWord(%size, 0) / %sizeFactorMaster) SPC getWords(%size, 1, 2));
				%copy.setRealSize((getWord(%size, 0) / %sizeFactorSlave) SPC getWords(%size, 1, 2));
				%piece.setEdge(%center, "1 0 0");
				%copy.setEdge(%center, "-1 0 0");
			case "y":
				%piece.setRealSize(getWord(%size, 0) SPC getWord(%size, 1) / %sizeFactorMaster SPC getWord(%size, 2));
				%copy.setRealSize(getWord(%size, 0) SPC getWord(%size, 1) / %sizeFactorSlave SPC getWord(%size, 2));
				%piece.setEdge(%center, "0 1 0");
				%copy.setEdge(%center, "0 -1 0");
			case "z":
				%piece.setRealSize(getWords(%size, 0, 1) SPC getWord(%size, 2) / %sizeFactorMaster);
				%copy.setRealSize(getWords(%size, 0, 1) SPC getWord(%size, 2) / %sizeFactorSlave);
				%piece.setEdge(%center, "0 0 1");
				%copy.setEdge(%center, "0 0 -1");
		}
	}
	else
	{
		%edge = PointToEdge(%piece, %hitPos); //PointToEdge is in the Merge Tool support functions

		switch$ (%axis)
		{
			case "x":
				%ratio = getWord(%edge, 0);
				%ratio = (%ratio + 1) / 2;
				%center = %piece.getEdge("-1 0 0");
				%piece.setRealSize(getWord(%size, 0) * %ratio SPC getWords(%size, 1, 2));
				%copy.setRealSize(getWord(%size, 0) * (1 - %ratio) SPC getWords(%size, 1, 2));
				%piece.setEdge(%center, "-1 0 0");
				%copy.setEdge(%piece.getEdge("1 0 0"), "-1 0 0");
			case "y":
				%ratio = getWord(%edge, 1);
				%ratio = (%ratio + 1) / 2;
				%center = %piece.getEdge("0 -1 0");
				%piece.setRealSize(getWord(%size, 0) SPC getWord(%size, 1) * %ratio SPC getWord(%size, 2));
				%copy.setRealSize(getWord(%size, 0) SPC getWord(%size, 1) * (1 - %ratio) SPC getWord(%size, 2));
				%piece.setEdge(%center, "0 -1 0");
				%copy.setEdge(%piece.getEdge("0 1 0"), "0 -1 0");
			case "z":
				%ratio = getWord(%edge, 2);
				%ratio = (%ratio + 1) / 2;
				%center = %piece.getEdge("0 0 -1");
				%piece.setRealSize(getWords(%size, 0, 1) SPC getWord(%size, 2) * %ratio);
				%copy.setRealSize(getWords(%size, 0, 1) SPC getWord(%size, 2) * (1 - %ratio));
				%piece.setEdge(%center, "0 0 -1");
				%copy.setEdge(%piece.getEdge("0 0 1"), "0 0 -1");
		}
	}

	if (isObject(%piece.pzone))
	{
		%piece.pzone.setScale(%piece.getScale());
		%piece.pzone.setPosition(%piece.getPosition());
	}
	if (isObject(%copy.pzone))
	{
		%copy.pzone.setScale(%copy.getScale());
		%copy.pzone.setPosition(%copy.getPosition());
	}

	if (!%piece.isForcefield())
	{
		%piece.schedule(290, "setCloaked", false);
		%copy.schedule(290, "setCloaked", false);
	}
}

function CalculateSplitAxis(%edge)
{
	//echo("Calculating split axis from edge: " @ %edge);
	%edge = mAbs(getWord(%edge, 0)) SPC mAbs(getWord(%edge, 1)) SPC mAbs(getWord(%edge, 2));
	if (getWord(%edge, 0) < getWord(%edge, 1) && getWord(%edge, 0) < getWord(%edge, 2))
		return "x";
	if (getWord(%edge, 1) < getWord(%edge, 0) && getWord(%edge, 1) < getWord(%edge, 2))
		return "y";
	if (getWord(%edge, 2) < getWord(%edge, 0) && getWord(%edge, 2) < getWord(%edge, 1))
		return "z";
}

exec("scripts/do_not_delete/MergeToolSupport.cs");
