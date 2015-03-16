//------------------------------------------------------------------------------
// ACCM Super Admin Commands
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Command by Eolk
function ccSA(%sender, %args)
{
   if(!%sender.isSuperAdmin)
      return;

   for(%i = 0; %i < ClientGroup.getCount(); %i++)
   {
      %cl = ClientGroup.getObject(%i);
      if(%cl.isSuperAdmin)
         messageClient(%cl, 'MsgYes', "\c3[SA]\c2"@%sender.nameBase@": "@%args);
   }
   logEcho("[SUPERADMIN CHAT]: "@%sender.nameBase@": "@%args);
}

// Command by Blnukem
function ccDeadmin(%sender, %args)
{
   if(!%sender.isSuperAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Unable to find target.");
      return;
   }

   if(%target.isSuperAdmin || !%target.isAdmin)
   {
      messageClient(%sender, "", "\c2Target has incorrect status of adminship.");
      return;
   }

   %target.isAdmin = false;
   %target.isSuperAdmin = false;
   messageAll( 'MsgStripAdminPlayer', '\c3%1 \c2has de-admined\c3 %2\c2.', %sender.name, %target.name, %target );
   %target.player.setInventory("SuperChaingun", 0);
   %target.player.setInventory("SuperChaingunAmmo", 0);
   logEcho(%sender.nameBase@" ("@%sender@") de-admin'd "@%target.nameBase@" ("@%target@")");
}

// Command by Blnukem
function ccAdmin(%sender, %args)
{
   if(!%sender.isSuperAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Unable to find target.");
      return;
   }

   if(%target.isAdmin)
   {
      messageClient(%sender, "", "\c2Target has incorrect status of adminship.");
      return;
   }

   Game.voteAdminPlayer(%sender, %target);
   %target.player.setInventory("SuperChaingun", 1);
   %target.player.setInventory("SuperChaingunAmmo", 999);
   logEcho(%sender.nameBase@" ("@%sender@") gave admin to "@%target.nameBase@" ("@%target@")");
}

// Command by Blnukem
function ccSuperAdmin(%sender, %args)
{
   if(!%sender.isSuperAdmin)
      return;

   %target = plnametocid(%args);
   if(!isObject(%target))
   {
      messageClient(%sender, "", "\c2Unable to find target.");
      return;
   }

   if(%target.isSuperAdmin)
   {
      messageClient(%sender, "", "\c2Target has incorrect status of adminship.");
      return;
   }

   %target.isAdmin = true;
   %target.isSuperAdmin = true;
   %name = getTaggedString(%target.name);
   messageAll( 'MsgSuperAdminPlayer', '\c3%3 \c2has made\c3 %2 \c2a super admin.', %target, %name, %sender.nameBase );
   %target.player.setInventory("SuperChaingun", 1);
   %target.player.setInventory("SuperChaingunAmmo", 999);
   logEcho(%sender.nameBase@" ("@%sender@") gave super admin to "@%target.nameBase@" ("@%target@")");
}
