//------------------------------------------------------------------------------
// ACCM Death Messages - By Blnukem.
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// %1 = Victim's name
// %2 = Victim's gender (value will be either "him" or "her")
// %3 = Victim's possessive gender	(value will be either "his" or "her")
// %4 = Killer's name
// %5 = Killer's gender (value will be either "him" or "her")
// %6 = Killer's possessive gender (value will be either "his" or "her")
// %7 = implement that killed the victim (value is the object number of the bullet, disc, etc)
//------------------------------------------------------------------------------

$DeathMessageCampingCount = 1;
$DeathMessageCamping[0] = '\c0%1 was killed for camping near the Nexus.';

$DeathMessageOOBCount = 1;
$DeathMessageOOB[0] = '\c0%1 was killed for leaving the battlefield.';

$DeathMessageLavaCount = 1;
$DeathMessageLava[0] = '\c0%1 fell in lava.';

$DeathMessageLightningCount = 1;
$DeathMessageLightning[0] = '\c0%1 was killed by lightning!';

$DeathMessageSuicideCount = 1;
$DeathMessageSuicide[0] = '\c0%1 committed suicide.';

$DeathMessageVehPadCount = 1;
$DeathMessageVehPad[0] = '\c0%1 got caught in a vehicle spawn field.';

$DeathMessageFFPowerupCount = 3;
$DeathMessageFFPowerup[0] = '\c0%1 got caught up in a forcefield during power up.';
$DeathMessageFFPowerup[1] = '\c0%1 was vaporized by a forcefield.';
$DeathMessageFFPowerup[2] = '\c0%1 gets %2self fried in a forcefield.';

$DeathMessageRogueMineCount = 1;
$DeathMessageRogueMine[$DamageType::Mine, 0] = '\c0%1 goes dancing in the minefield!';

//------------------------------------------------------------------------------
// These are used when a player kills themself with a weapon or by other means.
//------------------------------------------------------------------------------

$DeathMessageSelfKillCount = 5;
$DeathMessageSelfKill[$DamageType::Plasma, 0] = '\c0%1 suffers 3rd degree burns.';
$DeathMessageSelfKill[$DamageType::Plasma, 1] = '\c0%1 thought being a marshmellow would be fun, but was sadly mistaken.';
$DeathMessageSelfKill[$DamageType::Plasma, 2] = '\c0%1 barbecued %2self.';
$DeathMessageSelfKill[$DamageType::Plasma, 3] = '\c0%1 ends up a charred corpse.';
$DeathMessageSelfKill[$DamageType::Plasma, 4] = '\c0%1 fries %2self to a crisp.';

$DeathMessageSelfKill[$DamageType::Grenade, 0] = '\c0%1 threw the pin, not the grenade.';
$DeathMessageSelfKill[$DamageType::Grenade, 1] = '\c0%1 held the grenade a second too long.';
$DeathMessageSelfKill[$DamageType::Grenade, 2] = '\c0%1 pulled the pin a shade early.';
$DeathMessageSelfKill[$DamageType::Grenade, 3] = '\c0%1 took a bad bounce from %3 own grenade!';
$DeathMessageSelfKill[$DamageType::Grenade, 4] = '\c0%1 destroyed %2self with a grenade!';

$DeathMessageSelfKill[$DamageType::Missile, 0] = '\c0%1 kills %2self with a missile!';
$DeathMessageSelfKill[$DamageType::Missile, 1] = '\c0%1 runs a missile up %3 own tailpipe.';
$DeathMessageSelfKill[$DamageType::Missile, 2] = '\c0%1 tests the missile\'s shaped charge on %2self.';
$DeathMessageSelfKill[$DamageType::Missile, 3] = '\c0%1 achieved missile lock on %2self.';
$DeathMessageSelfKill[$DamageType::Missile, 4] = '\c0%1 gracefully smoked %2self with a missile!';

$DeathMessageSelfKill[$DamageType::Mine, 0] = '\c0%1 is killed by %3 own mine.';
$DeathMessageSelfKill[$DamageType::Mine, 1] = '\c0%1\'s mine violently reminds %2 of its existence.';
$DeathMessageSelfKill[$DamageType::Mine, 2] = '\c0%1 scatters his remains to the wind.';
$DeathMessageSelfKill[$DamageType::Mine, 3] = '\c0%1 was blown quite a distance by %3 own mine.';
$DeathMessageSelfKill[$DamageType::Mine, 4] = '\c0%1 now knows where he hid %3 mines!';

$DeathMessageSelfKill[$DamageType::SatchelCharge, 0] = '\c0%1 goes out with a bang!';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 1] = '\c0%1 blows %2self up with explosives.';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 2] = '\c0%1 adds a nice red tint to the surrounding environment.';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 3] = '\c0It is now raining little bits of %1.';
$DeathMessageSelfKill[$DamageType::SatchelCharge, 4] = '\c0%1 splashes all over the map.';

$DeathMessageSelfKill[$DamageType::Ground, 0] = '\c0%1 lands too hard.';
$DeathMessageSelfKill[$DamageType::Ground, 1] = '\c0%1 finds gravity unforgiving.';
$DeathMessageSelfKill[$DamageType::Ground, 2] = '\c0%1 painfully discovered gravity.';
$DeathMessageSelfKill[$DamageType::Ground, 3] = '\c0%1 forgot %3 parachute.';
$DeathMessageSelfKill[$DamageType::Ground, 4] = '\c0%1 loses a game of chicken with the ground.';

$DeathMessageSelfKill[$DamageType::Bazooka, 0] = '\c0Dont worry %1, you\'re not the first dumbass to kill %2self with explosives.';
$DeathMessageSelfKill[$DamageType::Bazooka, 1] = '\c0%1 blows %2self up with a bazooka.';
$DeathMessageSelfKill[$DamageType::Bazooka, 2] = '\c0%1 is dumb enough to fire a bazooka at close range.';
$DeathMessageSelfKill[$DamageType::Bazooka, 3] = '\c0%1 aimed %3 bazooka at his feet, fired, and then magically disapeared into smoke...';
$DeathMessageSelfKill[$DamageType::Bazooka, 4] = '\c0%1 squeezes %3 bazooka shell tightly...';

$DeathMessageSelfKill[$DamageType::RPG, 0] = '\c0%1 succesfully RPGs %2self.';
$DeathMessageSelfKill[$DamageType::RPG, 1] = '\c0%1 runs an RPG up %3 own tailpipe!';
$DeathMessageSelfKill[$DamageType::RPG, 2] = '\c0%1 is such a dumbass, he kills %2self with an RPG.';
$DeathMessageSelfKill[$DamageType::RPG, 3] = '\c0Um... Wow... %1 succesfully earned the medal of total dumbass by destroying %2self with an RPG.';
$DeathMessageSelfKill[$DamageType::RPG, 4] = '\c0%1 fall down go boom... from %3 own RPG...';

$DeathMessageSelfKill[$DamageType::Laser, 0] = '\c0%1 destroyed himeself.';
$DeathMessageSelfKill[$DamageType::Laser, 1] = '\c0%1 is dumb enough to shoot the Gauss Cannon at his feet.';
$DeathMessageSelfKill[$DamageType::Laser, 2] = '\c0%1 fired the Gauss Cannon a little too close.';
$DeathMessageSelfKill[$DamageType::Laser, 3] = '\c0%1 thought he was the enemy, so he killed %2self.';
$DeathMessageSelfKill[$DamageType::Laser, 4] = '\c0%1 makes short work of %2self.';

$DeathMessageSelfKill[$DamageType::MedPackVaccine, 0] = '\c0%1 injected %2self with too much antidote vaccine.';
$DeathMessageSelfKill[$DamageType::MedPackVaccine, 1] = '\c0%1 should\'ve paid more attention to the medpack instruction manual.';
$DeathMessageSelfKill[$DamageType::MedPackVaccine, 2] = '\c0%1 overdosed %2self with zombie vaccine drugs.';
$DeathMessageSelfKill[$DamageType::MedPackVaccine, 3] = '\c0%1 thought that the zombie vaccine would feel just as good as the heroin back home.';
$DeathMessageSelfKill[$DamageType::MedPackVaccine, 4] = '\c0%1 will be sleeping with the zombies tonight.';

//------------------------------------------------------------------------------
// These are used when a teamate kills another teamate with a weapon or other means.
//------------------------------------------------------------------------------

$DeathMessageTeamKillCount = 1;
$DeathMessageTeamKill[$DamageType::Blaster, 0] = '\c0%4 TEAMKILLED %1 with a blaster!';
$DeathMessageTeamKill[$DamageType::Plasma, 0] = '\c0%4 TEAMKILLED %1 with fire!';
$DeathMessageTeamKill[$DamageType::Bullet, 0] = '\c0%4 TEAMKILLED %1 with a chaingun!';
$DeathMessageTeamKill[$DamageType::Disc, 0] = '\c0%4 TEAMKILLED %1 with a spinfusor!';
$DeathMessageTeamKill[$DamageType::Grenade, 0] = '\c0%4 TEAMKILLED %1 with a grenade!';
$DeathMessageTeamKill[$DamageType::Laser, 0] = '\c0%4 TEAMKILLED %1 with a gauss cannon!';
$DeathMessageTeamKill[$DamageType::Elf, 0] = '\c0%4 TEAMKILLED %1 with an ELF projector!';
$DeathMessageTeamKill[$DamageType::Missile, 0] = '\c0%4 TEAMKILLED %1 with a missile!';
$DeathMessageTeamKill[$DamageType::Shocklance, 0] = '\c0%4 TEAMKILLED %1 with a shocklance!';
$DeathMessageTeamKill[$DamageType::Mine, 0] = '\c0%4 TEAMKILLED %1 with a mine!';
$DeathMessageTeamKill[$DamageType::SatchelCharge, 0] = '\c0%4 blew up TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::Impact, 0] = '\c0%4 runs down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::SuperChaingun, 0] = '\c0%4 TEAMKILLED %1 with a super chaingun!';
$DeathMessageTeamKill[$DamageType::Sniper, 0] = '\c0%4 TEAMKILLED %1 by using a sniper rifle!';
$DeathMessageTeamKill[$DamageType::MG, 0] = '\c0%4 TEAMKILLED %1 with an M32!';
$DeathMessageTeamKill[$DamageType::Bazooka, 0] = '\c0%4 TEAMKILLED %1 with a bazooka!';
$DeathMessageTeamKill[$DamageType::MG42, 0] = '\c0%4 TEAMKILLED %1 with a SAW!';
$DeathMessageTeamKill[$DamageType::rifle, 0] = '\c0%4 TEAMKILLED %1 with a rifle!';
$DeathMessageTeamKill[$DamageType::shotgun, 0] = '\c0%4 TEAMKILLED %1 with a shotgun!';
$DeathMessageTeamKill[$DamageType::AT4, 0] = '\c0%4 TEAMKILLED %1 with an AT6 rocket launcher!';
$DeathMessageTeamKill[$DamageType::RPG, 0] = '\c0%4 TEAMKILLED %1 with an RPG!';
$DeathMessageTeamKill[$DamageType::Shotdown, 0] = '\c0%4 shot down TEAMMATE %1!';
$DeathMessageTeamKill[$DamageType::MP5, 0] = '\c0%4 TEAMKILLED %1 with a SMG!';
$DeathMessageTeamKill[$DamageType::PBC, 0] = '\c0%4 TEAMKILLED %1 with a PBC!';
$DeathMessageTeamKill[$DamageType::MedPackVaccine, 0] = '\c0%4 TEAMKILLED %1 by injecting too much antidote vaccine into %3.';

//------------------------------------------------------------------------------
// These are used when a player kills an enemy with a weapon or other means.
//------------------------------------------------------------------------------

$DeathMessageCount = 5;
$DeathMessage[$DamageType::Plasma, 0] = '\c0%4 ignites %1 with some napalm.';
$DeathMessage[$DamageType::Plasma, 1] = '\c0%4 entices %1 to try a faceful of fire.';
$DeathMessage[$DamageType::Plasma, 2] = '\c0%4 sterilizes %1 with fire.';
$DeathMessage[$DamageType::Plasma, 3] = '\c0%4 turns %1 into a smoldering corpse.';
$DeathMessage[$DamageType::Plasma, 4] = '\c0%1 now needs a lot of skin grafts, thanks to %4.';

$DeathMessage[$DamageType::Bullet, 0] = '\c0%4 shreds up %1 with the chaingun.';
$DeathMessage[$DamageType::Bullet, 1] = '\c0%4 happily chews %1 into pieces with %6 chaingun.';
$DeathMessage[$DamageType::Bullet, 2] = '\c0%4 rips up %1 with a chaingun.';
$DeathMessage[$DamageType::Bullet, 3] = '\c0%1 suffers a serious hosing from %4\'s chaingun.';
$DeathMessage[$DamageType::Bullet, 4] = '\c0%4 bestows the blessings of %6 chaingun on %1.';

$DeathMessage[$DamageType::Grenade, 0] = '\c0%1 caught %4\'s grenade!';
$DeathMessage[$DamageType::Grenade, 1] = '\c0%4 thought a grenade would be a nice "easter egg" for %1.';
$DeathMessage[$DamageType::Grenade, 2] = '\c0%1 gets annihilated by %4\'s grenade.';
$DeathMessage[$DamageType::Grenade, 3] = '\c0%4 eliminates %1 with a grenade.';
$DeathMessage[$DamageType::Grenade, 4] = '\c0%4 gives %1 some grenade shrapnel.';

$DeathMessage[$DamageType::Missile, 0] = '\c0%4 intercepts %1 with a missile.';
$DeathMessage[$DamageType::Missile, 1] = '\c0%4 watches %6 missile touch %1 and go boom.';
$DeathMessage[$DamageType::Missile, 2] = '\c0%4 got sweet tone on %1.';
$DeathMessage[$DamageType::Missile, 3] = '\c0By now, %1 has realized %4\'s missile killed %2.';
$DeathMessage[$DamageType::Missile, 4] = '\c0%4\'s missile rains little pieces of %1 all over the terrain.';

$DeathMessage[$DamageType::Mine, 0] = '\c0%4 kills %1 with a mine.';
$DeathMessage[$DamageType::Mine, 1] = '\c0%1 doesn\'t see %4\'s mine in time.';
$DeathMessage[$DamageType::Mine, 2] = '\c0%4 gets a sapper kill on %1.';
$DeathMessage[$DamageType::Mine, 3] = '\c0%1 puts his foot on %4\'s mine.';
$DeathMessage[$DamageType::Mine, 4] = '\c0One small step for %1, one giant mine kill for %4.';

$DeathMessage[$DamageType::SatchelCharge, 0] = '\c0%4 buys %1 a ticket to the moon.';
$DeathMessage[$DamageType::SatchelCharge, 1] = '\c0%4 blows %1 into low orbit.';
$DeathMessage[$DamageType::SatchelCharge, 2] = '\c0%4 makes %1 a hugely explosive offer.';
$DeathMessage[$DamageType::SatchelCharge, 3] = '\c0%4 turns %1 into a cloud of satchel-vaporized armor.';
$DeathMessage[$DamageType::SatchelCharge, 4] = '\c0%4\'s satchel charge leaves %1 nothin\' but smokin\' boots.';

$DeathMessage[$DamageType::MG, 0] = '\c0%4 mows down %1 with an assault rifle.';
$DeathMessage[$DamageType::MG, 1] = '\c0%4 destroyed %1 with an assault rifle.';
$DeathMessage[$DamageType::MG, 2] = '\c0%4 quickly guns down %1 with an assault rifle.';
$DeathMessage[$DamageType::MG, 3] = '\c0%4 puts nice new holes in %1 armor.';
$DeathMessage[$DamageType::MG, 4] = '\c0%4 killed %1 with an assault rifle.';

$DeathMessage[$DamageType::Bazooka, 0] = '\c0%4 blasts %1 with a bazooka.';
$DeathMessage[$DamageType::Bazooka, 1] = '\c0%4 blows %1 apart with a bazooka.';
$DeathMessage[$DamageType::Bazooka, 2] = '\c0%4 destroyed %1 with a bazooka.';
$DeathMessage[$DamageType::Bazooka, 3] = '\c0%4 leaves a big, gaping hole in %1\'s armor.';
$DeathMessage[$DamageType::Bazooka, 4] = '\c0%4 makes %1 explode on impact.';

$DeathMessage[$DamageType::Sniper, 0] = '\c0%4 sniped %1.';
$DeathMessage[$DamageType::Sniper, 1] = '\c0%4 assassinated %1 with a sniper rifle.';
$DeathMessage[$DamageType::Sniper, 2] = '\c0%4 smiles as he snipes %1.';
$DeathMessage[$DamageType::Sniper, 3] = '\c0%4 caught %1 in his sniper scope.';
$DeathMessage[$DamageType::Sniper, 4] = '\c0%4 pops %1\'s head with a sniper rifle.';

$DeathMessage[$DamageType::MG42, 0] = '\c0%4 gunned down %1 with a SAW.';
$DeathMessage[$DamageType::MG42, 1] = '\c0%4 destroys %1 with a SAW.';
$DeathMessage[$DamageType::MG42, 2] = '\c0%4 unleashes a hail of bullets upon %1.';
$DeathMessage[$DamageType::MG42, 3] = '\c0%4 mows down %1 with a SAW.';
$DeathMessage[$DamageType::MG42, 4] = '\c0%4 lays it out on %1.';

$DeathMessage[$DamageType::Rifle, 0] = '\c0%4 shot %1 with a rifle.';
$DeathMessage[$DamageType::Rifle, 1] = '\c0%4\'s accuracy causes the death of %1.';
$DeathMessage[$DamageType::Rifle, 2] = '\c0%4 outright shot %1 with a rifle.';
$DeathMessage[$DamageType::Rifle, 3] = '\c0%4 called out the Krieg and went after %1.';
$DeathMessage[$DamageType::Rifle, 4] = '\c0%4 got %5self some accuracy marks, thanks to %1..';

$DeathMessage[$DamageType::Shotgun, 0] = '\c0%4 killed %1 in close range with a shotgun.';
$DeathMessage[$DamageType::Shotgun, 1] = '\c0%4 blows %1 in half with a shotgun.';
$DeathMessage[$DamageType::Shotgun, 2] = '\c0%4 pumped %1 full of lead.';
$DeathMessage[$DamageType::Shotgun, 3] = '\c0%1 catches a chestful of shells from %4\'s shotgun.';
$DeathMessage[$DamageType::Shotgun, 4] = '\c0%4 tears %1 quite a few new ones with a shotgun.';

$DeathMessage[$DamageType::AT4, 0] = '\c0%4 blows %1 up with a rocket launcher.';
$DeathMessage[$DamageType::AT4, 1] = '\c0%4 destroyed %1 with an AT4 rocket launcher.';
$DeathMessage[$DamageType::AT4, 2] = '\c0%4 gives %1 a few little FATAL burns.';
$DeathMessage[$DamageType::AT4, 3] = '\c04\'s AT6 Rocket hits %1\'s armor and goes BOOM.';
$DeathMessage[$DamageType::AT4, 4] = '\c0%4 shot a volley of rockets at %1.';

$DeathMessage[$DamageType::RPG, 0] = '\c0%4 gives a little package of explosive joy to %1.';
$DeathMessage[$DamageType::RPG, 1] = '\c0%4 eliminated %1 with a RPG.';
$DeathMessage[$DamageType::RPG, 2] = '\c0%4 kills %1 with a RPG.';
$DeathMessage[$DamageType::RPG, 3] = '\c0%4\'s RPG sends %1 flying.';
$DeathMessage[$DamageType::RPG, 4] = '\c0%4 shows %1 what "RPG" stands for.';

$DeathMessage[$DamageType::MP5, 0] = '\c0%4 fires a hail of bullets upon %1.';
$DeathMessage[$DamageType::MP5, 1] = '\c0%4 guns down %1 with a SMG.';
$DeathMessage[$DamageType::MP5, 2] = '\c0%4 rapidly, as in very rapidly guns down %1.';
$DeathMessage[$DamageType::MP5, 3] = '\c0%4 rips up %1 with %5 SMG.';
$DeathMessage[$DamageType::MP5, 4] = '\c0%4 puts nice new holes in %1 armor.';

$DeathMessage[$DamageType::PBC, 0] = '\c0%4 electricutes %1 with a PBC.';
$DeathMessage[$DamageType::PBC, 1] = '\c0%4 bug-zapped %1 with a PBC.';
$DeathMessage[$DamageType::PBC, 2] = '\c0%4 shocked %1 with a PBC.';
$DeathMessage[$DamageType::PBC, 3] = '\c0%4 reminds %1 that green lasers can be quite harmful.';
$DeathMessage[$DamageType::PBC, 4] = '\c0%4 leaves %1 a smoking corpse from %5 PBC.';

$DeathMessage[$DamageType::Laser, 0] = '\c0%4 blasts %1 with a gauss cannon.';
$DeathMessage[$DamageType::Laser, 1] = '\c0%4 totally destroyed %1 with a 250mm projectile.';
$DeathMessage[$DamageType::Laser, 2] = '\c0%4 watches %1 explode on impact.';
$DeathMessage[$DamageType::Laser, 3] = '\c0%4 blew %1 apart with a .500mm gauss projectile.';
$DeathMessage[$DamageType::Laser, 4] = '\c0%4 destroyed %1 with a gauss cannon.';

//------------------------------------------------------------------------------
// These are used when a player is run over by a vehicle
//------------------------------------------------------------------------------

$DeathMessageVehicleCount = 5;
$DeathMessageVehicle[0] = '\c0%4 turns %1 into roadkill.';
$DeathMessageVehicle[1] = '\c0%1 gets flattened under %4\'s vehicle.';
$DeathMessageVehicle[2] = '\c0%4 got some of %1\'s blood all over his vehicle finish.';
$DeathMessageVehicle[3] = '\c0%1 never saw %4\'s vehicle coming...';
$DeathMessageVehicle[4] = '\c0%1 causes a dent in the armor of %4\'s vehicle."';

$DeathMessageVehicleCrashCount = 5;
$DeathMessageVehicleCrash[ $DamageType::Crash, 0 ] = '\c0%1 fails to eject in time.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 1 ] = '\c0%1 becomes one with his vehicle dashboard.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 2 ] = '\c0%1 drives under the influence of death.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 3 ] = '\c0%1 makes a perfect three hundred point landing.';
$DeathMessageVehicleCrash[ $DamageType::Crash, 4 ] = '\c0%1 heroically pilots his vehicle into something really, really hard.';

$DeathMessageVehicleUnmannedCount = 3;
$DeathMessageVehicleUnmanned[0] = '\c0%1 gets in the way of a runaway vehicle.';
$DeathMessageVehicleUnmanned[1] = '\c0An unmanned vehicle kills the pathetic %1.';
$DeathMessageVehicleUnmanned[2] = '\c0%1 is pathetically struck down by an empty vehicle.';

//------------------------------------------------------------------------------
// These are used when a player is killed by a nearby equipment explosion
//------------------------------------------------------------------------------

$DeathMessageExplosionCount = 1;
$DeathMessageExplosion[0] = '\c0Exploding equipment killed %1!';

//------------------------------------------------------------------------------
// These are used when an automated turret kills an enemy player
//------------------------------------------------------------------------------

$DeathMessageTurretKillCount = 3;
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 0] = '\c0A chaingun turret ripped %1 apart.';
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 1] = '\c0A chaingun turret gunned down %1.';
$DeathMessageTurretKill[$DamageType::PlasmaTurret, 2] = '\c0A chaingun turret killed %1.';

$DeathMessageTurretKill[$DamageType::AATurret, 0] = '\c0A flak turret flanked %1.';
$DeathMessageTurretKill[$DamageType::AATurret, 1] = '\c0A flak turret destroyed %1.';
$DeathMessageTurretKill[$DamageType::AATurret, 2] = '\c0A flak turret blasted %1.';

$DeathMessageTurretKill[$DamageType::Plasma, 0] = '\c0A flame turret makes %1 to the 3rd degree.';
$DeathMessageTurretKill[$DamageType::Plasma, 1] = '\c0A flame turret turns %1 into a charred corpse.';
$DeathMessageTurretKill[$DamageType::Plasma, 2] = '\c0A flame turret cooks %1.';

$DeathMessageTurretKill[$DamageType::PBC, 0] = '\c0A PBC turret vaporized %1.';
$DeathMessageTurretKill[$DamageType::PBC, 1] = '\c0A PBC turret bug-zapped %1.';
$DeathMessageTurretKill[$DamageType::PBC, 2] = '\c0A PBC turret electricutes %1.';

$DeathMessageTurretKill[$DamageType::MissileTurret, 0] = '\c0A missile turret gently places a missile into %1\'s face.';
$DeathMessageTurretKill[$DamageType::MissileTurret, 1] = '\c0A missile turret pops %1.';
$DeathMessageTurretKill[$DamageType::MissileTurret, 2] = '\c0A missile turret lights up %1\'s, uh, ex-life.';

$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 0] = '\c0An emplacement turret mows down %1.';
$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 1] = '\c0An emplacement turret unleashes a hail of bullets upon %1.';
$DeathMessageTurretKill[$DamageType::IndoorDepTurret, 2] = '\c0An emplacement turret turret kills %1.';

$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 0] = '\c0An anti-infantry turret pumbled %1 with some mortars.';
$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 1] = '\c0An anti-infantry turret flanked %1.';
$DeathMessageTurretKill[$DamageType::OutdoorDepTurret, 2] = '\c0An anti-infantry turret blew apart %1';

$DeathMessageTurretKill[$DamageType::SentryTurret, 0] = '\c0A sentry turret killed %1.';
$DeathMessageTurretKill[$DamageType::SentryTurret, 1] = '\c0A sentry turret drills %1 queit nicely.';
$DeathMessageTurretKill[$DamageType::SentryTurret, 2] = '\c0A sentry turret pops %1\'s skull open.';

$DeathMessageTurretKill[$DamageType::Flak, 0] = '\c0Flak killed %1.';
$DeathMessageTurretKill[$DamageType::Flak, 1] = '\c0Flak killed %1.';
$DeathMessageTurretKill[$DamageType::Flak, 2] = '\c0Flak killed %1.';

$DeathMessageTurretKill[$DamageType::Artillery, 0] = '\c0An artillery turret destroyed %1.';
$DeathMessageTurretKill[$DamageType::Artillery, 1] = '\c0An artillery turret blew away %1.';
$DeathMessageTurretKill[$DamageType::Artillery, 2] = '\c0An artillery turret turns %1 into kibble.';

$DeathMessageTurretKill[$DamageType::ShotDown, 0] = '\c0%4 shoots down %1 with a turret.';
$DeathMessageTurretKill[$DamageType::ShotDown, 1] = '\c0%1 crashes and burns because %4\'s turret.';
$DeathMessageTurretKill[$DamageType::ShotDown, 2] = '\c0%4\'s turret gains %6 some anti vehicle points thanks to %1.';

//------------------------------------------------------------------------------
// These are used when a player is killed by a teammate controlling a turret.
//------------------------------------------------------------------------------

$DeathMessageCTurretTeamKillCount = 1;
$DeathMessageCTurretTeamKill[$DamageType::PlasmaTurret, 0] = '\c0%4 TEAMKILLED %1 with a chaingun turret!';

$DeathMessageCTurretTeamKill[$DamageType::AATurret, 0] = '\c0%4 TEAMKILLED %1 with an flak turret!';

$DeathMessageCTurretTeamKill[$DamageType::ELFTurret, 0] = '\c0%4 TEAMKILLED %1 with an ELF turret!';

$DeathMessageCTurretTeamKill[$DamageType::PBC, 0] = '\c0%4 TEAMKILLED %1 with a PBC turret!';

$DeathMessageCTurretTeamKill[$DamageType::MissileTurret, 0] = '\c0%4 TEAMKILLED %1 with a missile turret!';

$DeathMessageCTurretTeamKill[$DamageType::IndoorDepTurret, 0] = '\c0%4 TEAMKILLED %1 with a clamp turret!';

$DeathMessageCTurretTeamKill[$DamageType::OutdoorDepTurret, 0] = '\c0%4 TEAMKILLED %1 with a spike turret!';

$DeathMessageCTurretTeamKill[$DamageType::SentryTurret, 0] = '\c0%4 TEAMKILLED %1 with a sentry turret!';

$DeathMessageCTurretTeamKill[$DamageType::BomberBombs, 0] = '\c0%4 TEAMKILLED %1 in a bombastic explosion of raining death.';

$DeathMessageCTurretTeamKill[$DamageType::BellyTurret, 0] = '\c0%4 TEAMKILLED %1 by annihilating him from a belly turret.';

$DeathMessageCTurretTeamKill[$DamageType::TankChainGun, 0] = '\c0%4 TEAMKILLED %1 with his tank\'s chaingun.';

$DeathMessageCTurretTeamKill[$DamageType::TankChainGunH, 0] = '\c0%4 TEAMKILLED %1 with his tank\'s heavy chaingun.';

$DeathMessageCTurretTeamKill[$DamageType::TankMortar, 0] = '\c0%4 TEAMKILLED %1 by lobbing the BIG green death from a tank.';

$DeathMessageCTurretTeamKill[$DamageType::ShrikeBlaster, 0] = '\c0%4 TEAMKILLED %1 by strafing from a Shrike.';

$DeathMessageCTurretTeamKill[$DamageType::MPBMissile, 0] = '\c0%4 TEAMKILLED %1 when the MPB locked onto him.';

$DeathMessageCTurretTeamKill[$DamageType::Flak, 0] = '\c0%4 TEAMKILLS %1 with a extra friendly flak explosion.';

$DeathMessageCTurretTeamKill[$DamageType::Artillery, 0] = '\c0%4 TEAMKILLED %1 with an artillery turret.';

$DeathMessageCTurretTeamKill[$DamageType::Shotdown, 0] = '\c0%4 shot down TEAMMATE %1.';

$DeathMessageCTurretTeamKill[$DamageType::ACCG, 0] = '\c0%4 TEAMKILLED %1 with an explosive chaingun!';

$DeathMessageCTurretTeamKill[$DamageType::Bullet, 0] = '\c0%4 CGs down TEAMMATE %1 ... vehically.';

$DeathMessageCTurretTeamKill[$DamageType::MG, 0] = '\c0%4 CGs down TEAMMATE %1 ... vehically.';

$DeathMessageCTurretTeamKill[$DamageType::Plasma, 0] = '\c0%4 cooks TEAMMATE %1 with fire.';

$DeathMessageCTurretTeamKill[$DamageType::Missile, 0] = '\c0%4 TEAMKILLED %1 with a missile!';

//------------------------------------------------------------------------------
// These are used when a player is killed by an uncontrolled, friendly turret.
//------------------------------------------------------------------------------

$DeathMessageCTurretAccdtlKillCount = 1;
$DeathMessageCTurretAccdtlKill[$DamageType::PlasmaTurret, 0] = '\c0%1 got in the way of a chaingun turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::AATurret, 0] = '\c0%1 got in the way of an flak turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::ELFTurret, 0] = '\c0%1 got in the way of an ELF turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::Plasma, 0] = '\c0%1 got in the way of a flame turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::PBC, 0] = '\c0%1 got in the way of a PBC turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::MissileTurret, 0] = '\c0%1 got in the way of a missile turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::IndoorDepTurret, 0] = '\c0%1 got in the way of a clamp turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::OutdoorDepTurret, 0] = '\c0%1 got in the way of a spike turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::SentryTurret, 0] = '\c0%1 got in the way of a Sentry turret!';

$DeathMessageCTurretAccdtlKill[$DamageType::Flak, 0] = '\c0%1 got in the way of some flak!';

$DeathMessageCTurretAccdtlKill[$DamageType::Artillery, 0] = '\c0%1 got in the way of an artillery turret!';

//------------------------------------------------------------------------------
// These are messages for owned or controlled turrets.
//------------------------------------------------------------------------------

$DeathMessageCTurretKillCount = 3;
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 0] = '\c0%4\'s chaingun turret turns %1 into swiss cheese.';
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 1] = '\c0%4\'s chaingun turret shreds up %1.';
$DeathMessageCTurretKill[$DamageType::PlasmaTurret, 2] = '\c0%4\'s chaingun turret destroys %1.';

$DeathMessageCTurretKill[$DamageType::AATurret, 0] = '\c0%4\'s flak turret shot down %1.';
$DeathMessageCTurretKill[$DamageType::AATurret, 1] = '\c0%4\'s flak turret flanks %1.';
$DeathMessageCTurretKill[$DamageType::AATurret, 2] = '\c0%4\'s flak turret takes out %1.';

$DeathMessageCTurretKill[$DamageType::Plasma, 0] = '\c0%4\'s flame turret turns %1 into a charred corpse.';
$DeathMessageCTurretKill[$DamageType::Plasma, 1] = '\c0%4\'s flame turret cooks %1.';
$DeathMessageCTurretKill[$DamageType::Plasma, 2] = '\c0%4\'s flame turret gave %1 some 3rd degree burns.';

$DeathMessageCTurretKill[$DamageType::PBC, 0] = '\c0%4\'s PBC turret turns %1 into a charred corpse.';
$DeathMessageCTurretKill[$DamageType::PBC, 1] = '\c0%4\'s PBC turret caught %1 off guard.';
$DeathMessageCTurretKill[$DamageType::PBC, 2] = '\c0%4\'s PBC turret zapped %1.';

$DeathMessageCTurretKill[$DamageType::MissileTurret, 0] = '\c0%4\'s missile turret gently places a missile into %1\'s face.';
$DeathMessageCTurretKill[$DamageType::MissileTurret, 1] = '\c0%4\'s missile turret pops %1.';
$DeathMessageCTurretKill[$DamageType::MissileTurret, 2] = '\c0%4\'s missile turret lights up %1\'s, uh, ex-life.';

$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 0] = '\c0%4\'s emplacement turret rips up %1.';
$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 1] = '\c0%4\'s emplacement turret kills %1.';
$DeathMessageCTurretKill[$DamageType::IndoorDepTurret, 2] = '\c0%4\'s emplacement drills %1 nicely.';

$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 0] = '\c0%4\'s anti-infantry mortar turret flanked %1.';
$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 1] = '\c0%4\'s anti-infantry turret blows %1 away.';
$DeathMessageCTurretKill[$DamageType::OutdoorDepTurret, 2] = '\c0%4\'s anti-infantry mortar turret pummels %1 into the ground.';

$DeathMessageCTurretKill[$DamageType::SentryTurret, 0] = '\c0%4 caught %1 by surprise with a sentry turret.';
$DeathMessageCTurretKill[$DamageType::SentryTurret, 1] = '\c0%4\'s sentry turret took out %1.';
$DeathMessageCTurretKill[$DamageType::SentryTurret, 2] = '\c0%4 blasted %1 with a sentry turret.';

$DeathMessageCTurretKill[$DamageType::BomberBombs, 0] = '\c0%4 bombs %1 to hell and back.';
$DeathMessageCTurretKill[$DamageType::BomberBombs, 1] = '\c0%4 leaves %1 a smoking bomb crater.';
$DeathMessageCTurretKill[$DamageType::BomberBombs, 2] = '\c0%4 bombs %1 back to the 20th century.';

$DeathMessageCTurretKill[$DamageType::BellyTurret, 0] = '\c0%1 eats a big helping of %4\'s belly turret bolt.';
$DeathMessageCTurretKill[$DamageType::BellyTurret, 1] = '\c0%4 plants a belly turret bolt in %1\'s belly.';
$DeathMessageCTurretKill[$DamageType::BellyTurret, 2] = '\c0%1 fails to evade %4\'s deft bomber strafing.';

$DeathMessageCTurretKill[$DamageType::TankChainGun, 0] = '\c0%4 gets a direct flak hit on %1.';
$DeathMessageCTurretKill[$DamageType::TankChainGun, 1] = '\c0%4\'s tank flak hits %1 "dead" on.';
$DeathMessageCTurretKill[$DamageType::TankChainGun, 2] = '\c0%4 pierces %1 with flak.';

$DeathMessageCTurretKill[$DamageType::TankChainGunH, 0] = '\c0%4 gets %1 with a light tank explosive chaingun.';
$DeathMessageCTurretKill[$DamageType::TankChainGunH, 1] = '\c0%4 tears %1 apart with a light tank chaingun.';
$DeathMessageCTurretKill[$DamageType::TankChainGunH, 2] = '\c0%4 opens a can of whoop ass on %1 with his tank slug.';

$DeathMessageCTurretKill[$DamageType::TankMortar, 0] = '\c0Whoops! %1 + %4\'s tank mortar = Dead %1.';
$DeathMessageCTurretKill[$DamageType::TankMortar, 1] = '\c0%4 eliminates %1 with a tank mortar.';
$DeathMessageCTurretKill[$DamageType::TankMortar, 2] = '\c0%4\'s tank mortar has a blast with %1.';

$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 0] = '\c0%1 dines on a Shrike blaster sandwich, courtesy of %4.';
$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 1] = '\c0The blaster of %4\'s Shrike turns %1 into finely shredded meat.';
$DeathMessageCTurretKill[$DamageType::ShrikeBlaster, 2] = '\c0%1 gets drilled big-time by the blaster of %4\'s Shrike.';

$DeathMessageCTurretKill[$DamageType::MPBMissile, 0] = '\c0%1 intersects nicely with %4\'s MPB Missile.';
$DeathMessageCTurretKill[$DamageType::MPBMissile, 1] = '\c0%4\'s MPB Missile makes armored chowder out of %1.';
$DeathMessageCTurretKill[$DamageType::MPBMissile, 2] = '\c0%1 has a brief, explosive fling with %4\'s MPB Missile.';

$DeathMessageCTurretKill[$DamageType::Flak, 0] = '\c0%4 rips %1 apart with some flak.';
$DeathMessageCTurretKill[$DamageType::Flak, 1] = '\c0%4 shoots down %1 with some flak.';
$DeathMessageCTurretKill[$DamageType::Flak, 2] = '\c0%4 blasts %1 with some flak.';

$DeathMessageCTurretKill[$DamageType::Artillery, 0] = '\c0%4 lands some artillery right on %1.';
$DeathMessageCTurretKill[$DamageType::Artillery, 1] = '\c0%4 fired a big, smoking artillery shell on %1.';
$DeathMessageCTurretKill[$DamageType::Artillery, 2] = '\c0%4 blows %1 to kibble using artillery.';

$DeathMessageCTurretKill[$DamageType::ShotDown, 0] = '\c0%4 shoots down %1.';
$DeathMessageCTurretKill[$DamageType::ShotDown, 1] = '\c0%1 crashes and burns because %4.';
$DeathMessageCTurretKill[$DamageType::ShotDown, 2] = '\c0%4 gains some anti vehicle points thanks to %1.';

$DeathMessageCTurretKill[$DamageType::ACCG, 0] = '\c0%4 gets %1 with an explosive chaingun.';
$DeathMessageCTurretKill[$DamageType::ACCG, 1] = '\c0%4 unleashes a storm of explosive chaingun bullets on %1.';
$DeathMessageCTurretKill[$DamageType::ACCG, 2] = '\c0%4 blasts %1.';

$DeathMessageCTurretKill[$DamageType::bullet, 0] = '\c0%4 kills %1 with %6 rapid-firing chaingun.';
$DeathMessageCTurretKill[$DamageType::bullet, 1] = '\c0%4 gives %1 quite a few fatal wounds.';
$DeathMessageCTurretKill[$DamageType::bullet, 2] = '\c0%4 makes %1 a very "holy" person.';

$DeathMessageCTurretKill[$DamageType::MG, 0] = '\c0%4 gives %1 a big helping of chaingun bullets.';
$DeathMessageCTurretKill[$DamageType::MG, 1] = '\c0%4 gives %1 quite a few fatal wounds.';
$DeathMessageCTurretKill[$DamageType::MG, 2] = '\c0%4 makes %1 a "holey" person.';

$DeathMessageCTurretKill[$DamageType::plasma, 0] = '\c0%4 drops a napalm bomb on %1.';
$DeathMessageCTurretKill[$DamageType::plasma, 1] = '\c0%4 engulfs %1 in a rain of napalm fire.';
$DeathMessageCTurretKill[$DamageType::plasma, 2] = '\c0%4 shows %1 that the worst way to die is through napalm burns.';

$DeathMessageCTurretKill[$DamageType::Missile, 0] = '\c0%4 gently places a missile into %1\'s face.';
$DeathMessageCTurretKill[$DamageType::Missile, 1] = '\c0%4 pops %1 with a missile.';
$DeathMessageCTurretKill[$DamageType::Missile, 2] = '\c0%4\'s missile lights up %1\'s, uh, ex-life.';

$DeathMessageTurretSelfKillCount = 3;
$DeathMessageTurretSelfKill[0] = '\c0%1 was dumb enough to shoot %2self with a turret.';
$DeathMessageTurretSelfKill[1] = '\c0%1 got drunk and played with a turret.';
$DeathMessageTurretSelfKill[2] = '\c0%1 somehow managed to kill %2self with a turret.';

$DeathMessageMeteorCount = 6;
$DeathMessageMeteor[0] = '\c0%1 was killed by a meteor!';
$DeathMessageMeteor[1] = '\c0%1 caught a meteor!';
$DeathMessageMeteor[2] = '\c0%1 gets a facefull of molten meteor.';
$DeathMessageMeteor[3] = '\c0%1 gets smeared by a red hot meteor.';
$DeathMessageMeteor[4] = '\c0%1 is left a smoking crater by a meteor.';
$DeathMessageMeteor[5] = '\c0%1 learns to seek shelter when there\'s hot rock falling from the sky.';

$DeathMessageIdiocyCount = 2;
$DeathMessageIdiocy[0] = '\c0%1 was killed for being dumb.';
$DeathMessageIdiocy[1] = '\c0%1\'s own stupidity stops %2 cold in %3 tracks.';

$DeathMessageKillerFogCount = 1;
$DeathMessageKillerFog[0] = '\c0The fog has claimed another victim.';

$DeathMessage[$DamageType::Drown, 0] = '\c0%1 goes to Davy Jones\' locker.';
$DeathMessage[$DamageType::Drown, 1] = '\c0%1 drowns.';
$DeathMessage[$DamageType::Drown, 2] = '\c0%1 lands %2self in a watery grave.';
$DeathMessage[$DamageType::Drown, 3] = '\c0%1\'s corpse is now floating on water.';
$DeathMessage[$DamageType::Drown, 4] = '\c0%1 will be sleeping with the fish tonight.';

$DeathMessage[$DamageType::Zombie, 0] = '\c0%1 now is in the ranks of the undead.';
$DeathMessage[$DamageType::Zombie, 1] = '\c0%1 became part of the living dead.';
$DeathMessage[$DamageType::Zombie, 2] = '\c0%1 becomes another victim of the zombie horde.';
$DeathMessage[$DamageType::Zombie, 3] = '\c0%1 is slaughtered by a zombie.';
$DeathMessage[$DamageType::Zombie, 4] = '\c0%1 is killed by a zombie.';

$DeathMessage[$DamageType::Artillery, 0] = '\c0Artillery has killed %1.';
$DeathMessage[$DamageType::Artillery, 1] = '\c0Artillery bombardments destroy %1.';
$DeathMessage[$DamageType::Artillery, 2] = '\c0A bombardment signals the end of %1.';
$DeathMessage[$DamageType::Artillery, 3] = '\c0Explosions from an Artillery Strike leave %1 nothing more than a crater.';
$DeathMessage[$DamageType::Artillery, 4] = '\c0Artillery shells turn %1 into kibble.';

$DeathMessage[$DamageType::ZombieL, 0] = '\c0%1 got crushed by a Zombie Lord.';
$DeathMessage[$DamageType::ZombieL, 1] = '\c0%1 is killed by a Zombie Lord.';
$DeathMessage[$DamageType::ZombieL, 2] = '\c0%1 could not outrun the Zombie Lord closing in on %2.';
$DeathMessage[$DamageType::ZombieL, 3] = '\c0%1 is pummeled by a Zombie Lord.';
$DeathMessage[$DamageType::ZombieL, 4] = '\c0%1 got plain out pulverised by a Zombie Lord.';

$DeathMessage[$DamageType::ZAcid, 0] = '\c0%1 is killed by Zombie Lord acid.';
$DeathMessage[$DamageType::ZAcid, 1] = '\c0%1 had %3 head melted off %3 shoulders by Zombie Lord acid.';
$DeathMessage[$DamageType::ZAcid, 2] = '\c0%1 got burned by Zombie Lord acid.';
$DeathMessage[$DamageType::ZAcid, 3] = '\c0%1\'s life was ended prematurely by Zombie Lord acid.';
$DeathMessage[$DamageType::ZAcid, 4] = '\c0%1 is turned into a puddle of mush by Zombie Lord acid.';

$DeathMessage[$DamageType::Burn, 0] = '\c0%1 is now well-done.';
$DeathMessage[$DamageType::Burn, 1] = '\c0%1 got burned.';
$DeathMessage[$DamageType::Burn, 2] = '\c0%1 is now a smoldering corpse.';
$DeathMessage[$DamageType::Burn, 3] = '\c0%1, if you were planning on being cremated, there\'s no need now.';
$DeathMessage[$DamageType::Burn, 4] = '\c0%1 burned to death.';

$DeathMessage[$DamageType::SuperChaingun, 0] = '\c0%4 rips %1 up with the super chaingun.';
$DeathMessage[$DamageType::SuperChaingun, 1] = '\c0%4 happily chews %1 into pieces with %6 super chaingun.';
$DeathMessage[$DamageType::SuperChaingun, 2] = '\c0%4 administers a dose of Admin Lead to %1.';
$DeathMessage[$DamageType::SuperChaingun, 3] = '\c0%4 destroys %1 with a SCG.';
$DeathMessage[$DamageType::SuperChaingun, 4] = '\c0%4 bestows the blessings of %6 super chaingun on %1.';

$DeathMessageSelfKill[$DamageType::SuperChaingun, 0] = '\c0%1 kills %2self with a super chaingun.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 1] = '\c0%1 catches the blast of %3 own super chaingun bullet.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 2] = '\c0%1 is a dumbass and shoots %2self with a super chaingun.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 3] = '\c0%1 catches the blast of %3 own super chaingun bullet - retard.';
$DeathMessageSelfKill[$DamageType::SuperChaingun, 4] = '\c0%1 thinks an SCG can\'t kill you.';
