// TruPhysics engine v0.6 - physics engine by DynaBlade
// Mainly used for vehicles but can be expanded.

// String Table
$TruPhysics::Enabled = true;
$TruPhysics::maxVelocity = 1500; // 1500 m/s or about 5400 KPH, T2's universal speed limit

function capVelocity(%vel)
{
   if(velToSingle(%vel) > $TruPhysics::maxVelocity)
      return $TruPhysics::maxVelocity;
   else
      return mFloor(%vel);
}

function VehicleData::onCollision(%data,%obj,%col,%mod,%pos,%normal)
{

    if(%data.disablePhysics || !$TruPhysics::Enabled) // !enabled = default vehicle physics, local or global scope
        return;

    %className = %data.className;

    if(%col.isPlayer()) // player is dead and wants to be run over / annihilated.
    {
       %mass = -0.25 * %col.getMass();
       %vec = vectorScale(vectorScale(%col.getVelocity(), 0.25), %mass);
       %obj.applyImpulse(%col.getPosition(), %vec);
    }
    else if(%col.isVehicle())                                       // phreakynasty!
    {
         if(%col.getDamageState() $= "Destroyed")                          // nothing to collide with here, get back to movement!
             return;

         %AMass = %obj.getMass();
         %AiVec = vectorScale(%obj.getVelocity(), %mass);
         %APos = vectorNormalize(%obj.getForwardVector());

         %BMass = %obj.getMass();
         %BiVec = vectorScale(%obj.getVelocity(), %mass);
         %BPos = vectorNormalize(%obj.getForwardVector());

         %obj.applyImpulse(%BPos, %BiVec);
         %col.applyImpulse(%APos, %AiVec);
    }
}


function checkWaterPhysics(%obj)
{

    if(%obj.isWet)
    {
        // water absorbs about 75% of your velocity when you hit it.
        %mass = %obj.getMass() * 0.75;
        %iVec = vectorScale(%obj.getVelocity(), %mass);
        %obj.applyImpulse(%obj.getTransform(), %iVec);

        // speed tolerance checking (in KPH)
        %mass = %obj.getMass();
        %pct = %obj.getDamagePct() / 4;
        %max = %pct * (%data.minDrag * 10);
        %maxSpeed = %max - (%mass / getRandom(10, 12));
        %vel = msToKPH(velToSingle(%obj.getVelocity()));

        if(%maxSpeed > %vel)
            %obj.getDatablock().damageObject(%obj, 0, "0 0 0", %maxSpeed - %vel, $DamageType::Default);

        schedule(100, %obj, "checkWaterPhysics", %obj);
    }
}

function VehicleData::onEnterLiquid(%data, %obj, %coverage, %type)
{
    if(!%data.disableWaterPhysics && $TruPhysics::Enabled)
    {
        %obj.isWet = true;
        checkWaterPhysics(%obj);
    }

   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(0.0);
      case 1:
         //Ocean Water
         %obj.setHeat(0.0);
      case 2:
         //River Water
         %obj.setHeat(0.0);
      case 3:
         //Stagnant Water
         %obj.setHeat(0.0);
      case 4:
         //Lava
         %obj.liquidDamage(%data, $VehicleDamageLava, $DamageType::Lava);
      case 5:
         //Hot Lava
         %obj.liquidDamage(%data, $VehicleDamageHotLava, $DamageType::Lava);
      case 6:
         //Crusty Lava
         %obj.liquidDamage(%data, $VehicleDamageCrustyLava, $DamageType::Lava);
      case 7:
         //Quick Sand
   }
}

function VehicleData::onLeaveLiquid(%data, %obj, %type)
{
    %obj.isWet = false;
    // exiting from the water becomes easier if your engines are on... speed doubles?
    if(!%data.disableWaterPhysics && $TruPhysics::Enabled)
    {
        %mass = %obj.getMass() * 0.375;
        %iVec = capVel(vectorScale(%obj.getVelocity(), %mass));
        %obj.applyImpulse(%obj.getTransform(), %iVec);
    }

   switch(%type)
   {
      case 0:
         //Water
         %obj.setHeat(1.0);
      case 1:
         //Ocean Water
         %obj.setHeat(1.0);
      case 2:
         //River Water
         %obj.setHeat(1.0);
      case 3:
         //Stagnant Water
         %obj.setHeat(1.0);
      case 4:
         //Lava
      case 5:
         //Hot Lava
      case 6:
         //Crusty Lava
      case 7:
         //Quick Sand
   }

   if(%obj.lDamageSchedule !$= "")
   {
      cancel(%obj.lDamageSchedule);
      %obj.lDamageSchedule = "";
   }
}

datablock AudioProfile(EngineAlertSound)
{
   filename    = "gui/vote_nopass.WAV";
   description = AudioExplosion3d;
   preload = true;
};

function VDUndo(%obj)
{
   %obj.vdOverride = false;
   %obj.dmgApplyImp = false;
}

function vDmgApplyImpulse(%obj)
{
   if(%obj.getDatablock().forceSensitive)
      return;

    %obj.dmgApplyImp = true;
    %lastPct = %obj.lastDmgPct;
    %pct = %obj.getDamagePct();

    if(%lastPct > %pct)
    {
       %obj.vdOverride = true;
       schedule(1000, 0, "VDUndo", %obj);
    }

    %obj.tp_sndCnt++;

    if(((%pct >= 0.5 && %pct < 1) && (%obj.vdOverride == false || %obj.vdOverride == "")) && %obj.augType !$= "Auto Repair Bot")
    {
        %force = (%pct * 500) * getRandom(1);
        if(%force)
        {
            %va = getRandom(1) ? getRandom() * -1 : getRandom();
            %vb = getRandom(1) ? getRandom() * -1 : getRandom();
            %vc = getRandom(1) ? getRandom() * -1 : getRandom();
            %vec = %va SPC %vb SPC %vc;
            %nVec = vectorScale(%vec, %force);

            %seed = getRandom(100);
            if(%seed > 60 && %seed < 90)
                %obj.playThread(0, "maintainback");
            else if(%seed > 90)
                %obj.playThread(0, "maintainbot");
            else
                %obj.playThread(0, "activateback");

            %obj.applyImpulse(%obj.getTransform(), %nVec);
        }
        %obj.lastDmgPct = %pct;
        schedule(250, %obj, "vDmgApplyImpulse", %obj);

        if(%obj.tp_sndCnt >= 4)
        {
            %obj.tp_sndCnt = 0;
            %obj.play3D(EngineAlertSound);
        }
    }
    else
        %obj.stopThread(0);
}

function VehicleData::onDamage(%this,%obj)
{

   %damage = %obj.getDamageLevel();
   if (%damage >= %this.destroyedLevel)
   {
      if(%obj.getDamageState() !$= "Destroyed")
      {
         if(%obj.respawnTime !$= "")
            %obj.marker.schedule = %obj.marker.data.schedule(%obj.respawnTime, "respawn", %obj.marker);
         %obj.setDamageState(Destroyed);
      }
   }
   else
   {
      if(%obj.getDamageState() !$= "Enabled")
         %obj.setDamageState(Enabled);

        %pct = %obj.getDamagePct();

        if(%pct >= 0.6 && !%obj.dmgApplyImp)
            vDmgApplyImpulse(%obj);
   }
}
