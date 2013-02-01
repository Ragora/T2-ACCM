//------------------------------------------------------------------------------
// ACCM AI Commands
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Drone Commands:
//------------------------------------------------------------------------------
// Made by Blnukem (edited by Eolk)
function ccDroneBattle(%sender, %args)
{
   if(!%sender.isAdmin)
      return;

   %x = getword(%sender.player.position, 0);
   %y = getword(%sender.player.position, 1);
   %z = getword(%sender.player.position, 2) + 1200;
   %newpos = %x SPC %y SPC %z;
   %base = strlwr(getword(%args, 0));
   %difficulty = getword(%args, 1);
   if(%base $= "Battle")
      %base = 1;
   else if(%base $= "Single")
      %base = 2;
   else
   {
      messageClient(%sender, "", "\c2Invalid variable. Valid variables are:\c3 battle\c2 and \c3single\c2.");
      return;
   }

   if(%difficulty $= "Easy")
      %d = 1;
   else if(%difficulty $= "Medium")
      %d = 5;
   else if(%difficulty $= "Hard")
      %d = 10;
   else if(%difficulty $= "Ace")
      %d = "ace";
   else
   {
      messageClient(%sender, "", "\c2Invalid difficulty. Difficulties are:\c3 Light\c2,\c3 Medium\c2,\c3 Hard\c2, and\c3 Ace\c2.");
      return;
   }

   if(%base == 1)
      DroneBattle(%newpos, 1000, 10, 10, 15, %d);
   else if(%base == 2)
      StartDrone(%newpos, "0 0 1 0", 5, %d);

   messageAll("", "\c3"@%sender.nameBase@" \c2spawned a "@%difficulty@" "@(%base == 1 ? "drone battle" : "drone")@".~wgui/objective_Notification.wav");
}

function ccCreateSentinel(%sender, %args)
{
	CreateSentinel("0 0 310", 1, 1);
}
