//------------------------------------------------
// Examples of item specific disassemble.
//================================================
// ----------------
//  1. ONE
// ================
function TelePadDeployedBase::disassemble(%data, %plyr, %hTgt)
{
	%teleteam = %hTgt.team;
	if(%obj.Hacked) // is it hacked currently?
	{
		%teleteam = %hTgt.OldTeam;
		echo("hacked!");
	}

	// dising a telepad makes it yours, remove from the other teams list
   if($TeamDeployedCount[%teleteam, TelePadPack] > 0) // this wasnt the last
   {
   	if($firstPad[%teleteam] == %hTgt) // the first was disassembled
	   {
	   	echo("first pad disassembled");
	   	$firstPad[%teleteam] = %ohTgtbj.nextPad; // make the second one the first
	   	%hTgt.prevPad = -1;
	   	%hTgt.nextPad = %obj;
	   }
		else
		{
			%lastPad = $firstPad[%teleteam];
		   %hTgt.prevPad.nextPad = %hTgt.nextPad;
		   %hTgt.nextPad.prevPad = %hTgt.prevPad;
		}

   }
   else // last one
   {
   	$firstPad[%teleteam] = ""; // remove it
	}

	%hTgt.shield.delete();
}

// --------------
// 2. Two
// ==============

function MobileBaseVehicle::disassemble(%data, %plyr, %hTgt)
{
 %mpbpos = %hTgt.gettransform();
 %hTgt.delete();
 teleporteffect(posfromtransform(%mpbpos));
}
