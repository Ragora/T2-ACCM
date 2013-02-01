//----------------------------------------------------------------------------

datablock EffectProfile(TurretPackActivateEffect)
{
   effectname = "packs/generic_deploy";
    minDistance = 2.5;
	maxDistance = 2.5;
};

datablock AudioProfile(TurretPackActivateSound)
{
	filename = "fx/packs/turret_place.wav";
	description = AudioClose3D;
   preload = true;
   effect = TurretPackActivateEffect;
};


//----------------------------------------------------------------------------

function Pack::onCollision(%data, %obj, %col)
{
   // Don't pick up a new pack if you have a satchel charge deployed:
   if ( %col.thrownChargeId > 0 )
      return;
      
   ItemData::onCollision(%data, %obj, %col);
}

function Pack::onUse(%data,%obj)
{
   if (%obj.getMountedImage($BackpackSlot) != %data.image.getId())
      %obj.mountImage(%data.image,$BackpackSlot);
   else
   {
      // Toggle the image trigger.
      %obj.setImageTrigger($BackpackSlot,
         !%obj.getImageTrigger($BackpackSlot));
   }
}

function Pack::onInventory(%data,%obj,%amount)
{
	//only do this for players
	if(%obj.getClassName() !$= "Player")
		return;

   // Auto-mount the packs on players
   if((%oldPack = %obj.getMountedImage($BackpackSlot)) != 0)
      %obj.setInventory(%oldPack.item, 0);
   if (%amount && %obj.getDatablock().className $= Armor)
   {
		// if you picked up another pack after you placed a satchel charge but
		// before you detonated it, delete the charge
		if(%obj.thrownChargeId > 0)
		{
			%obj.thrownChargeId.delete();
			%obj.thrownChargeId = 0;
		}
      %obj.mountImage(%data.image,$BackpackSlot);
	   %obj.client.setBackpackHudItem(%data.getName(), 1);   
	}
	if(%amount == 0 )
   {
      if ( %data.getName() $= "SatchelCharge" )
         %obj.client.setBackpackHudItem( "SatchelUnarmed", 1 );
      else   
	      %obj.client.setBackpackHudItem(%data.getName(), 0);
   }   
   ItemData::onInventory(%data,%obj,%amount);
}   

//----------------------------------------------------------------------------

// --- Upgrade packs
exec("scripts/packs/ammopack.cs");
exec("scripts/packs/repairpack.cs");
exec("scripts/packs/jetbooster.cs");
exec("scripts/packs/satchelCharge.cs");
exec("scripts/packs/FlamerAmmopack.cs");
exec("scripts/packs/parachutepack.cs");

exec("scripts/packs/largeInventory.cs");
exec("scripts/packs/spine.cs");
exec("scripts/packs/blastwall.cs");
exec("scripts/packs/blastfloor.cs");
exec("scripts/packs/blastwwall.cs");
exec("scripts/packs/jumpad.cs");
exec("scripts/packs/mspine.cs");
exec("scripts/packs/treepack.cs");
exec("scripts/packs/cratepack.cs");
exec("scripts/packs/decorationpack.cs");
exec("scripts/packs/logoprojectorpack.cs");
exec("scripts/packs/lightpack.cs");
exec("scripts/packs/ZSpawnpack.cs");
exec("scripts/packs/SentinelPack.cs");
exec("scripts/packs/forcefieldpack.cs");
exec("scripts/packs/gravityfieldpack.cs");
exec("scripts/packs/telepadpack.cs");
exec("scripts/packs/turretpack.cs");
exec("scripts/packs/sentryturretpack.cs"); 
//exec("scripts/packs/discturret.cs"); 
exec("scripts/packs/laserturret.cs"); 
exec("scripts/packs/missilerackturret.cs"); 
exec("scripts/packs/mediumSensor.cs");
exec("scripts/packs/largeSensor.cs");
exec("scripts/packs/tripwire.cs");
exec("scripts/packs/vehiclepad.cs");
exec("scripts/packs/vehiclerepairpad.cs");
exec("scripts/packs/Effectpacks.cs");
//exec("scripts/packs/CommandSatelite.cs");
exec("scripts/packs/door.cs");
exec("scripts/packs/ArtilleryLoadoutPack.cs");
exec("scripts/packs/Medpack.cs");
exec("scripts/packs/DeployableWaypoint.cs");
exec("scripts/packs/SpawnPointPack.cs");
exec("scripts/packs/waypointpack.cs");
exec("scripts/packs/PurgeGenerator.cs");

// --- Turret barrel packs
exec("scripts/packs/aabarrelpack.cs");
exec("scripts/packs/missilebarrelpack.cs");
exec("scripts/packs/mortarbarrelpack.cs");
exec("scripts/packs/plasmabarrelpack.cs");
exec("scripts/packs/ELFbarrelpack.cs");
exec("scripts/packs/artillerybarrelpack.cs");

// --- power
exec("scripts/packs/generator.cs");
exec("scripts/packs/solarpanel.cs");
exec("scripts/packs/switch.cs");
