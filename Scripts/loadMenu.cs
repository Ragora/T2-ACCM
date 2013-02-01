//==============================================================================
// ACCM Load Menu.
//==============================================================================

package loadmodinfo
{
   function sendLoadInfoToClient( %client )
   {
      Parent::sendLoadInfoToClient(%client);
      schedule(15000, 0, "ConInfoLoad", %client);
   }

   function ConInfoLoad(%client)
   {
      %count = ClientGroup.getCount();
      for(%cl = 0; %cl < %count; %cl++)
      {
	     %client = ClientGroup.getObject( %cl );
	     if (!%client.isAIControlled())
	     sendConInfoToClient(%client);
         }
      }

   function sendConInfoToClient(%client)
   {
      %on = "On";
	  %off = "Off";
	  %yes = "Yes";
	  %no = "No";
	  messageClient( %client, 'MsgLoadInfo', "", $CurrentMission, $MissionDisplayName, $Host::GameName );

	  // Send mod details:
	  %ModLine = "<Color:ffffff><font:Broadway Bt:21>Advanced Combat Construction Mod 1.4.0" @
	  "\n<font:Broadway Bt:15>ACCM Dev Team: <Color:888888>Blnukem, Eolk and Dark Dragon DX." @
	  "\n<Color:ffffff>Website: <a:www.freewebs.com/advancedccm>www.freewebs.com/advancedccm";
	  messageClient( %client, 'MsgLoadQuoteLine', "", %ModLine );

	  %ServerText = "<color:ffffff><font:Broadway Bt:21>Server Info:<font:Broadway Bt:15>" @
	  "\nMax Players: " @ $Host::MaxPlayers @
      "\nTime limit: " @ $Host::TimeLimit @
	  "\nFriendly Fire: " @ ($Host::TeamDamageOn ? %on : %off) @
	  "\nPure Build: " @ ($Host::Purebuild ? %on : %off) @
	  "\nClient Saves: " @ ($Host::ClientSaving ? %on : %off) @
	  "\nFlood Protection: " @ ($Host::FloodProtectionEnabled ? %on : %off) @
	  "\nZombie Keeper Votes: " @ ($Host::AllowKeeperPlayerVotes ? %on : %off);
	  messageClient( %client, 'MsgLoadRulesLine', "", %ServerText );
	  messageClient( %client, 'MsgLoadInfoDone' );
   }

//------------------------------------------------------------------------------
// Made by Blnukem.

   function debriefLoad(%client)
   {
      if (isObject(Game))
         %game = Game.getId();
      else
         return;
         
   %sentinelcount = SentinelGroup.GetCount();
   %zombiecount = ZombieGroup.GetCount();

   messageClient( %client, 'MsgDebriefResult', "", "<Just:Center><font:Broadway Bt:21><Color:FFFFFF>"@$Host::GameName@"\n<font:Broadway Bt:14>Advanced Combat Construction Mod - Version 1.3.2");
   messageClient( %client, 'MsgDebriefAddLine', "", "<Just:Center><Color:FFFFFF><font:Broadway Bt:15>ACCM Development Team:\ <Color:888888>Blnukem, Eolk and Dark Dragon DX." );
   messageClient( %client, 'MsgDebriefAddLine', "", "<Just:Center><Color:FFFFFF><font:Broadway Bt:14>Website: <a:www.freewebs.com/advancedccm>www.freewebs.com/advancedccm</a>" );
   messageClient( %client, 'MsgDebriefAddLine', "", "" );
   if ($Host::MOTD !$= "")
   {
      messageClient( %client, 'MsgDebriefAddLine', "", " Message of the Day: \n "@$Host::MOTD@" \n ");
   } else {
   }

   messageClient( %client, 'MsgDebriefAddLine', "", $ACCMTip[mFloor(getRandom() * $ACCMTipCount)]);
   messageClient( %client, 'MsgDebriefAddLine', "", "_____________________________________________ \n " );
   messageClient( %client, 'MsgDebriefAddLine', "", "<Just:Left>  <a:Underline>Top Players:</a> <Just:Right> <a:Underline>Scores:</a>  ");

   if ($Rank::numplayers < 1)
   {
      messageClient( %client, 'MsgDebriefAddLine', "", "<Just:Left>  None <Just:Right> None  ");
      messageClient( %client, 'MsgGameOver', "" );
      return;
   } else if ($Rank::numplayers >= 5)
   {
      %num = 5;
   } else {
      %num = $Rank::numplayers;
      }

   for (%i = 1; %i <= %num; %i++)
   {
      FindTopRanks();
      messageClient( %client, 'MsgDebriefAddLine', "", "<Just:Left>  "@%i@". "@$Rank::Top[%i]@" <Just:Right> "@$Rank::TopScore[%i]@"  ");
      messageClient( %client, 'MsgGameOver', "" );
      }
   }
};

activatepackage(loadmodinfo);
