//
// terSupport.cs
// Server support functions

$terSupport::Version = 0.98;


// ========================================================================== //
// |                                                                        | //
// |  CONSOLE MESSAGE HANDLERS                                              | //
// |                                                                        | //
// ========================================================================== //

//
// TS_DEBUG()
// If in debug mode, print a message to the console

function TS_DEBUG( %text )
{
  %output = "Debug: " @ %text;

  if ( $terSupport::Debug )
    echo( %output );
}

//
// TS_INFO()
// Show a message in the console

function TS_INFO( %text )
{
  echo( %text );
}

//
// TS_ERROR()
// Print an error message to the console
// If in debug mode also show the message ingame

function TS_ERROR( %text )
{
  %output = "ERROR: " @ %text;

  echo( %output );

  if ( $terSupport::Debug && $ServerGroup !$= "" )
    messageAll( 0, %output );
}


//
// tsCopyTextFile()
// Copy a text file (file copy isn't built in?)

function tsCopyTextFile( %srcFilename, %destFilename )
{
  %srcFile = new FileObject();
  %destFile = new FileObject();

  if ( %srcFile.openForRead( %srcFilename )
       && %destFile.openForWrite( %destFilename ) )
  {
    while ( !%srcFile.isEOF() )
      %destFile.writeLine( %srcFile.readLine() );

    %srcFile.close();
    %destFile.close();
  }
  else
    return false;
    
  return true;
}



// ========================================================================== //
// |                                                                        | //
// |  TEAM SUPPORT FUNCTIONS                                                | //
// |                                                                        | //
// ========================================================================== //

//
// tsTeamCount()
// Return the number of teams, not including observer (zero)

function tsTeamCount()
{
  return Game.numTeams;
}


//
// tsPlayerCount()
// Return the total number of players

function tsPlayerCount()
{
  return ClientGroup.getCount();
}

//
// tsPlayerCountTeam()
// Return the number of players on a team

function tsPlayerCountTeam( %teamindex )
{
  %count = 0;

  %lim = ClientGroup.getCount();

  for ( %i = 0; %i < %lim; %i++ )
  {
    %client = ClientGroup.getObject( %i );

    if ( %client.team == %teamindex )
      %count++;
  }

  return %count;
}

//
// tsPlayerCountExceptTeam()
// Return the number of players except those on team %teamindex
// ( usually %teamindex = 0 )

function tsPlayerCountExceptTeam( %teamindex )
{
  %count = 0;

  %lim = ClientGroup.getCount();

  for ( %i = 0; %i < %lim; %i++ )
  {
    %client = ClientGroup.getObject( %i );

    if ( %client.team != %teamindex )
      %count++;
  }

  return %count;
}

//
// tsGetLargestTeamPlayerCount()
// Return the number of players on the largest team

function tsGetLargestTeamPlayerCount()
{
  %largestCount = 0;

  for( %i = 1; %i < (Game.numTeams + 1); %i++ )
  {
    %thisCount = tsPlayerCountTeam( %i );

    if ( %thisCount > %largestCount )
      %largestCount = %thisCount;
  }

  //TS_DEBUG( "largest team player count = "@%largestCount );
  return %largestCount;
}



// ========================================================================== //
// |                                                                        | //
// |  SERVER COMMAND SUPPORT                                                | //
// |                                                                        | //
// ========================================================================== //

//
// tsCheckCommandSpam()
// Return true if client is blocked from issuing a command because
//  they have executed one too recently - else return false

function tsCheckCommandSpam( %client, %time )
{
  if ( %time $= "" )
    %time = 5;

  // If the client executed a command in the last %time seconds they can't run another
  if ( getSimTime() - %client.tsLastCommandTime < %time * 1000 )
    return true;

  // Record the time of this command
  %client.tsLastCommandTime = getSimTime();
}

//
// serverCmdSetJoinPassword()
// Changes the password required to join the server

function serverCmdSetJoinPassword( %client, %newPassword )
{
  if ( %client.isSuperAdmin )
  {
    messageAll( 0, "\c2"@%client.nameBase@" changed the server join password." );
    TS_INFO( %client.nameBase@" changed the server join password to "@%newPassword );

    $Host::Password = %newPassword;
  }
  else
    messageClient( %client, 0, "\c2You must be a super admin to use that command." );
}

//
// serverCmdTogglePlayerMute()
// Called to mute or unmute another client
//
// Changes from base:
//   Now notifies the target that they're being muted or unmuted
//   Has flood protection

function serverCmdTogglePlayerMute( %client, %who )
{
  %notifyTarget = true;

  if ( tsCheckCommandSpam( %client, 12 ) )
    %notifyTarget = false;

   if (%client.muted[%who])
   {
      %client.muted[%who] = false;
      messageClient(%client, 'MsgPlayerMuted', '%1 has been unmuted.', %who.name, %who, false);

      if ( %notifyTarget )
        messageClient( %who, 'MsgTSYouWereMuted', %client.nameBase@" has unmuted you.", %client.name, %client, false );
   }
   else
   {
      %client.muted[%who] = true;
      messageClient(%client, 'MsgPlayerMuted', '%1 has been muted.', %who.name, %who, true);

      if ( %notifyTarget )
        messageClient( %who, 'MsgTSYouWereMuted', %client.nameBase@" has muted you.", %client.name, %client, true );
   }
}



// ========================================================================== //
// |                                                                        | //
// |  MESSAGING SUPPORT                                                     | //
// |                                                                        | //
// ========================================================================== //

//
// New center and bottom print routines

function tsCenterPrintTeam( %team, %message, %time, %lines )
{
  if ( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
    %lines = 1;

  %clCount = ClientGroup.getCount();

  for ( %i = 0; %i < %clCount; %i++ )
  {
    %client = ClientGroup.getObject( %i );

    if ( !%client.isAIControlled() && %client.team == %team )
      commandToClient( %client, 'centerPrint', %message, %time, %lines );
  }
}

function tsCenterPrintExceptTeam( %excludeTeam, %message, %time, %lines )
{
  if ( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
    %lines = 1;

  %clCount = ClientGroup.getCount();

  for ( %i = 0; %i < %clCount; %i++ )
  {
    %client = ClientGroup.getObject( %i );

    if ( !%client.isAIControlled() && %client.team != %excludeTeam )
      commandToClient( %client, 'centerPrint', %message, %time, %lines );
  }
}

function tsBottomPrintTeam( %team, %message, %time, %lines )
{
   if( %lines $= "" || ((%lines > 3) || (%lines < 1)) )
      %lines = 1;

   %count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() && %cl.team == %team )
         commandToClient( %cl, 'bottomPrint', %message, %time, %lines );
   }
}

function tsClearCenterPrintTeam( %team )
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() && %cl.team == %team )
         commandToClient( %cl, 'ClearCenterPrint');
   }
}

function tsClearBottomPrintTeam( %team )
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() && %cl.team == %team )
         commandToClient( %cl, 'ClearBottomPrint');
   }
}

function tsClearAllPrintsAll()
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() )
      {
         commandToClient( %cl, 'ClearCenterPrint');
         commandToClient( %cl, 'ClearBottomPrint');
      }
   }
}

function tsClearAllPrintsTeam( %team )
{
	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%cl = ClientGroup.getObject(%i);
      if( !%cl.isAIControlled() && %cl.team == %team )
      {
         commandToClient( %cl, 'ClearCenterPrint');
         commandToClient( %cl, 'ClearBottomPrint');
      }
   }
}


//
// New chat message routines

function tsMessageExceptTeam( %excludeTeam, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13 )
{
  %clCount = ClientGroup.getCount();

  for ( %i= 0; %i < %clCount; %i++ )
  {
    %recipient = ClientGroup.getObject( %i );

    if ( %recipient.team != %excludeTeam )
      messageClient( %recipient, %msgType, %msgString, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11, %a12, %a13 );
  }
}


//
// tsMOTD()
// Show a message of the day

function tsMOTD( %client, %MOTDtext, %MOTDlines, %MOTDtime )
{
  if ( %client.tsMOTD $= "" )
  {
    centerPrint( %client, %MOTDtext, %MOTDtime, %MOTDlines );
    %client.tsMOTD = true;
  }
}
