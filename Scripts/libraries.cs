//Contain basic data libraries.
//Soon to be updated with more usefull stuff.

// NOTE - any changes here must be considered in expertlibraries.cs !!!

//** New format of information ** 

$packSettings["spine"] = 7;
$packSetting["spine",0] = "0.5 0.5 1.5 1.5 meters in height";
$packSetting["spine",1] = "0.5 0.5 4 4 meters in height";
$packSetting["spine",2] = "0.5 0.5 8 8 meters in height";
$packSetting["spine",3] = "0.5 0.5 40 40 meters in height";
$packSetting["spine",4] = "0.5 0.5 160 160 meters in height";
$packSetting["spine",5] = "0.5 6 160 auto adjusting";
$packSetting["spine",6] = "0.5 8 160 pad";
$packSetting["spine",7] = "0.5 8 160 wooden pad";

$packSettings["mspine"] = 7;
$packSetting["mspine",0] = "1 1 1 2 2 0.5 1 meters in height";
$packSetting["mspine",1] = "1 1 4 2 2 0.5 4 meters in height";
$packSetting["mspine",2] = "1 1 8 2 2 0.5 8 meters in height";
$packSetting["mspine",3] = "1 1 40 2 2 0.5 40 meters in height";
$packSetting["mspine",4] = "1 1 160 2 2 0.5 160 meters in height";
$packSetting["mspine",5] = "1 8 160 2 2 0.5 auto adjusting";
$packSetting["mspine",6] = "1 6 160 2 2 0.5 normal rings";
$packSetting["mspine",7] = "1 8 160 8 8 0.5 platform rings";

$expertSettings["mspine"] = 1;
$expertSetting["mspine",0] = "Rings disabled";
$expertSetting["mspine",1] = "Rings enabled";

$packSettings["floor"] = 5;
$packSetting["floor",0] = "10 10 20 10 10 10 10 meters wide";
$packSetting["floor",1] = "20 20 20 20 20 20 20 meters wide";
$packSetting["floor",2] = "30 30 20 30 30 30 30 meters wide";
$packSetting["floor",3] = "40 40 20 40 40 40 40 meters wide";
$packSetting["floor",4] = "50 50 20 50 50 50 50 meters wide";
$packSetting["floor",5] = "60 60 20 60 60 60 60 meters wide";

$expertSettings["floor"] = 4;
$expertSetting["floor",0] = "1.5 meters in height";
$expertSetting["floor",1] = "5 meters in height";
$expertSetting["floor",2] = "10 meters in height";
$expertSetting["floor",3] = "20 meters in height";
$expertSetting["floor",4] = "40 meters in height";

$packSettings["walk"] = 12;
$packSetting["walk",0] = "0 flat";
$packSetting["walk",1] = "5 Sloped 5 degrees up";
$packSetting["walk",2] = "10 Sloped 10 degrees up";
$packSetting["walk",3] = "20 Sloped 20 degrees up";
$packSetting["walk",4] = "45 Sloped 45 degrees up";
$packSetting["walk",5] = "60 Sloped 60 degrees up";
$packSetting["walk",6] = "90 Sloped 90 degrees up";
$packSetting["walk",7] = "-5 Sloped 5 degrees down";
$packSetting["walk",8] = "-10 Sloped 10 degrees down";
$packSetting["walk",9] = "-20 Sloped 20 degrees down";
$packSetting["walk",10] = "-45 Sloped 45 degrees down";
$packSetting["walk",11] = "-60 Sloped 60 degrees down";
$packSetting["walk",12] = "-90 Sloped 90 degrees down";

$expertSettings["walk"] = 3;
$expertSetting["walk",0] = "Normal walkway";
$expertSetting["walk",1] = "No-flicker walkway";
$expertSetting["walk",2] = "Double width walkway";
$expertSetting["walk",3] = "Double height walkway";

$packSettings["blast"] = 3;
$packSetting["blast",0] = "deploy from inside";
$packSetting["blast",1] = "deploy in frame";
$packSetting["blast",2] = "deploy from outside";
$packSetting["blast",3] = "deploy full thickness";

$expertSettings["blast"] = 1;
$expertSetting["blast",0] = "Normal Blast Wall";
$expertSetting["blast",1] = "Multiple Blast Walls";

$packSettings["forcefield"] = 50;
$packSetting["forcefield",0] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <Color:ffffff>White";
$packSetting["forcefield",1] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:ff4444>Red";
$packSetting["forcefield",2] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:44ff44>Green";
$packSetting["forcefield",3] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:4444ff>Blue";
$packSetting["forcefield",4] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:44ffff>Cyan";
$packSetting["forcefield",5] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:ff44ff>Magenta";
$packSetting["forcefield",6] = "0.5 8 160 Force Field set to: <color:4444ff>[Solid] <color:ffff44>Yellow";
$packSetting["forcefield",7] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:ffffff>White";
$packSetting["forcefield",8] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:ff4444>Red";
$packSetting["forcefield",9] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:44ff44>Green";
$packSetting["forcefield",10] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:4444ff>Blue";
$packSetting["forcefield",11] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:44ffff>Cyan";
$packSetting["forcefield",12] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:ff44ff>Magenta";
$packSetting["forcefield",13] = "0.5 8 160 Force Field set to: <color:44ff44>[Team-Pass] <color:ffff44>Yellow";
$packSetting["forcefield",14] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:ffffff>White";
$packSetting["forcefield",15] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:ff4444>Red";
$packSetting["forcefield",16] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:44ff44>Green";
$packSetting["forcefield",17] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:4444ff>Blue";
$packSetting["forcefield",18] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:44ffff>Cyan";
$packSetting["forcefield",19] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:ff44ff>Magenta";
$packSetting["forcefield",20] = "0.5 8 160 Force Field set to: <color:ff4444>[All-Pass] <color:ffff44>Yellow";
////more////
$packSetting["forcefield",21] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Lightning";
$packSetting["forcefield",22] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Scan Line";
$packSetting["forcefield",23] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Grid";
$packSetting["forcefield",24] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Fire Wall";
$packSetting["forcefield",25] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Energy Field";
$packSetting["forcefield",26] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Flashing";
$packSetting["forcefield",27] = "0.5 8 160 Force Field set to: <color:4444ff>[Special Solid] <color:ffffff>Dirty Window";
$packSetting["forcefield",28] = "0.5 8 160 Force Field set to: <color:44ff44>[Special Team-Pass] <color:ffffff>Scan Line";
$packSetting["forcefield",29] = "0.5 8 160 Force Field set to: <color:44ff44>[Special Team-Pass] <color:ffffff>Grid";
$packSetting["forcefield",30] = "0.5 8 160 Force Field set to: <color:44ff44>[Special Team-Pass] <color:ffffff>Energy Field ";
$packSetting["forcefield",31] = "0.5 8 160 Force Field set to: <color:44ff44>[Special Team-Pass] <color:ffffff>Flashing";
$packSetting["forcefield",32] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Scan Line";
$packSetting["forcefield",33] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Grid";
$packSetting["forcefield",34] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Energy Field";
$packSetting["forcefield",35] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Flashing";
$packSetting["forcefield",36] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Weird Firewall";
$packSetting["forcefield",37] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Lava";
$packSetting["forcefield",38] = "0.5 8 160 Force Field set to: <color:ff4444>[Special All-Pass] <color:ffffff>Water";

$packSetting["forcefield",39] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Flashing Crosshair";
$packSetting["forcefield",40] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Glass Tile";
$packSetting["forcefield",41] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Vehicle Icons";
$packSetting["forcefield",42] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Space 1";
$packSetting["forcefield",43] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Clouds 1";
$packSetting["forcefield",44] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Fuzzy Scanlines";
$packSetting["forcefield",45] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Space 2";
$packSetting["forcefield",46] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Signs";
$packSetting["forcefield",47] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Clouds 2";
$packSetting["forcefield",48] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Computer Screen";
$packSetting["forcefield",49] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Console";
$packSetting["forcefield",50] = "0.5 8 160 Force Field set to: <Color:888888>[Special] <color:ffffff>Standard Force Field";

$expertSettings["forcefield"] = 3;
$expertSetting["forcefield",0] = "Force Field Setting: [1] Normal Force Field";
$expertSetting["forcefield",1] = "Force Field Setting: [2] Cubic-Replace Force Field";
$expertSetting["forcefield",2] = "Force Field Setting: [3] Normal Force Field - No Slowdown";
$expertSetting["forcefield",3] = "Force Field Setting: [4] Cubic-Replace Force Field - No Slowdown";

$packSettings["gravfield"] = 4;
$packSetting["gravfield",0] = "4.25 8 500 normal slow";
$packSetting["gravfield",1] = "4.25 8 500 normal fast";
$packSetting["gravfield",2] = "4.25 8 500 reverse slow";
$packSetting["gravfield",3] = "4.25 8 500 reverse fast";
$packSetting["gravfield",4] = "4.25 8 500 zero gravity";
//
$packSetting["gravfield",5] = "4.25 8 500 fastfield";
$packSetting["gravfield",6] = "4.25 8 500 super fastfield";

$expertSettings["gravfield"] = 2;
$expertSetting["gravfield",0] = "Normal gravity field";
$expertSetting["gravfield",1] = "Cubic-replace gravity field (player's orientation)";
$expertSetting["gravfield",2] = "Cubic-replace gravity field (object's orientation)";

$packSettings["jumpad"] = 3;
$packSetting["jumpad",0] = "1000 10 boost";
$packSetting["jumpad",1] = "2500 25 boost";
$packSetting["jumpad",2] = "5000 50 boost";
$packSetting["jumpad",3] = "10000 100 boost";

$packSettings["tree"] = 13;
$packSetting["tree",0] = "normal 1";
$packSetting["tree",1] = "normal 2";
$packSetting["tree",2] = "normal 3";
$packSetting["tree",3] = "normal 4";
$packSetting["tree",4] = "greywood 1";
$packSetting["tree",5] = "greywood 2";
$packSetting["tree",6] = "greywood 3";
$packSetting["tree",7] = "greywood 4";
$packSetting["tree",8] = "greywood 5";
$packSetting["tree",9] = "cactus 1";
$packSetting["tree",10] = "cactus 2";
$packSetting["tree",11] = "misc 1";
$packSetting["tree",12] = "misc 2";
$packSetting["tree",13] = "pod 1";

$expertSettings["tree"] = 14;
$expertSetting["tree",0] = "0.0625";
$expertSetting["tree",1] = "0.125";
$expertSetting["tree",2] = "0.25";
$expertSetting["tree",3] = "0.5";
$expertSetting["tree",4] = "0.75";
$expertSetting["tree",5] = "1";
$expertSetting["tree",6] = "2";
$expertSetting["tree",7] = "3";
$expertSetting["tree",8] = "4";
$expertSetting["tree",9] = "5";
$expertSetting["tree",10] = "6";
$expertSetting["tree",11] = "7";
$expertSetting["tree",12] = "8";
$expertSetting["tree",13] = "9";
$expertSetting["tree",14] = "10";

$packSettings["crate"] = 12;
$packSetting["crate",0] = "(1) back pack";
$packSetting["crate",1] = "(2) small containment";
$packSetting["crate",2] = "(3) large containment";
$packSetting["crate",3] = "(4) compressor";
$packSetting["crate",4] = "(5) tubes";
$packSetting["crate",5] = "(6) quantum battery";
$packSetting["crate",6] = "(7) proton accelerator";
$packSetting["crate",7] = "(8) cargo crate";
$packSetting["crate",8] = "(9) magnetic cooler";
$packSetting["crate",9] = "(10) recycle unit";
$packSetting["crate",10] = "(11) fuel cannister";
$packSetting["crate",11] = "(12) wooden T2 box";
$packSetting["crate",12] = "(13) plasma router";

$packSettings["decoration"] = 16;
$packSetting["decoration",0] = "[1] Banner Unity";
$packSetting["decoration",1] = "[2] Banner Strength";
$packSetting["decoration",2] = "[3] Banner Honor";
$packSetting["decoration",3] = "[4] Dead Light Armor";
$packSetting["decoration",4] = "[5] Dead Medium Armor";
$packSetting["decoration",5] = "[6] Dead Heavy Armor";
$packSetting["decoration",6] = "[7] Statue Base";
$packSetting["decoration",7] = "[8] Light Male statue";
$packSetting["decoration",8] = "[9] Light Female statue";
$packSetting["decoration",9] = "[10] Heavy Male statue";
$packSetting["decoration",10] = "[11] Beowulf Wreck";
$packSetting["decoration",11] = "[12] Shrike Wreck";
$packSetting["decoration",12] = "[13] Billboard 1";
$packSetting["decoration",13] = "[14] Billboard 2";
$packSetting["decoration",14] = "[15] Billboard 3";
$packSetting["decoration",15] = "[16] Billboard 4";
$packSetting["decoration",16] = "[17] Blue Pad";

$packSettings["logoprojector"] = 7;
$packSetting["logoprojector",0] = "your teams logo";
$packSetting["logoprojector",1] = "Storm";
$packSetting["logoprojector",2] = "Inferno";
$packSetting["logoprojector",3] = "Starwolf";
$packSetting["logoprojector",4] = "Diamond Sword";
$packSetting["logoprojector",5] = "Blood Eagle";
$packSetting["logoprojector",6] = "Phoenix";
$packSetting["logoprojector",7] = "Bioderm";

$packSettings["switch"] = 6;
$packSetting["switch",0] = "5";
$packSetting["switch",1] = "10";
$packSetting["switch",2] = "25";
$packSetting["switch",3] = "50";
$packSetting["switch",4] = "100";
$packSetting["switch",5] = "150";
$packSetting["switch",6] = "200";

$expertSettings["switch"] = 2;
$expertSetting["switch",0] = "Normal switch";
$expertSetting["switch",1] = "Timed switch on";
$expertSetting["switch",2] = "Timed switch off";

$packSettings["light"] = 13;
$packSetting["light",0] = "(7) <color:ffffff>white";
$packSetting["light",1] = "(6) <color:ff4444>red";
$packSetting["light",2] = "(5) <color:44ff44>green";
$packSetting["light",3] = "(4) <color:4444ff>blue";
$packSetting["light",4] = "(3) <color:44ffff>cyan";
$packSetting["light",5] = "(2) <color:ff44ff>magenta";
$packSetting["light",6] = "(1) <color:ffff44>yellow";
$packSetting["light",7] = "(7) strobe <color:ffffff>white";
$packSetting["light",8] = "(6) strobe <color:ff4444>red";
$packSetting["light",9] = "(5) strobe <color:44ff44>green";
$packSetting["light",10] = "(4) strobe <color:4444ff>blue";
$packSetting["light",11] = "(3) strobe <color:44ffff>cyan";
$packSetting["light",12] = "(2) strobe <color:ff44ff>magenta";
$packSetting["light",13] = "(1) strobe <color:ffff44>yellow";

$expertSettings["light"] = 1;
$expertSetting["light",0] = "On when powered";
$expertSetting["light",1] = "Off when powered";

$packSettings["Door"] = 7;
$packSetting["Door",0] = "Normal Door";
$packSetting["Door",1] = "Toggle Door";
$packSetting["Door",2] = "Power Change Door (Open When Powered)";
$packSetting["Door",3] = "Power Change Door (Closed When Powered)";
$packSetting["Door",4] = "Collision Door (All Access)";
$packSetting["Door",5] = "Collision Door (Permission Access)";
$packSetting["Door",6] = "Collision Door (Owner-only Access)";
$packSetting["Door",7] = "Collision Door (Admin-only Access)";

$expertSettings["Door"] = 5;
$expertSetting["Door",0] = "0 Seconds";
$expertSetting["Door",1] = "0.5 Seconds";
$expertSetting["Door",2] = "1 Second";
$expertSetting["Door",3] = "2 Seconds";
$expertSetting["Door",4] = "3 Seconds";
$expertSetting["Door",5] = "4 Seconds";

$expertSettings[TripwireDeployableImage] = "3 -1";
$expertSetting[TripwireDeployableImage,0] = "select range";
$expertSetting[TripwireDeployableImage,1] = "select power logic";
$expertSetting[TripwireDeployableImage,2] = "select field type";
$expertSetting[TripwireDeployableImage,3] = "select field mode";

$packSettings[TripwireDeployableImage] = "6 -1 Tripwire range set to:";
$packSetting[TripwireDeployableImage,0,0] = "5 meters";
$packSetting[TripwireDeployableImage,1,0] = "10 meters";
$packSetting[TripwireDeployableImage,2,0] = "25 meters";
$packSetting[TripwireDeployableImage,3,0] = "50 meters";
$packSetting[TripwireDeployableImage,4,0] = "100 meters";
$packSetting[TripwireDeployableImage,5,0] = "150 meters";
$packSetting[TripwireDeployableImage,6,0] = "200 meters";

$packSettings[TripwireDeployableImage,1] = "5 -1 Tripwire power logic set to:";
$packSetting[TripwireDeployableImage,0,1] = "Normal Toggle On";
$packSetting[TripwireDeployableImage,1,1] = "Normal Toggle Off";
$packSetting[TripwireDeployableImage,2,1] = "Only Turn On";
$packSetting[TripwireDeployableImage,3,1] = "Only Turn Off";
$packSetting[TripwireDeployableImage,4,1] = "Timed Turn Off";
$packSetting[TripwireDeployableImage,5,1] = "Timed Turn On";

$packSettings[TripwireDeployableImage,2] = "1 -1 Tripwire field type set to:";
$packSetting[TripwireDeployableImage,0,2] = "Beam";
$packSetting[TripwireDeployableImage,1,2] = "Field";

$packSettings[TripwireDeployableImage,3] = "1 -1 Tripwire field mode set to:";
$packSetting[TripwireDeployableImage,0,3] = "Field invisible until touched";
$packSetting[TripwireDeployableImage,1,3] = "No field";

$packSettings["escapepod"] = 7;
$packSetting["escapepod",0] = "1875";  //  12.25%
$packSetting["escapepod",1] = "3750";  //  25%
$packSetting["escapepod",2] = "5625";  //  37.5%
$packSetting["escapepod",3] = "7500";  //  50%
$packSetting["escapepod",4] = "9375";  //  62.5%
$packSetting["escapepod",5] = "11250"; //  75%
$packSetting["escapepod",6] = "13125"; //  87.5%
$packSetting["escapepod",7] = "15000"; // 100%

$expertSettings["telepad"] = 3;
$expertSetting["telepad",0] = "team only";
$expertSetting["telepad",1] = "any team";
$expertSetting["telepad",2] = "only transmit";
$expertSetting["telepad",3] = "only receive";

$packSettings["missilerack"] = 1;
$packSetting["missilerack",0] = "dumbfire missiles";
$packSetting["missilerack",1] = "seeking missiles";

$packSettings["VehiclePadPack"] = 1;
$packSetting["VehiclePadPack",0] = "Standard Vehicle Pad";
$packSetting["VehiclePadPack",1] = "Water Vehicle Pad";

$packSettings["ZSpawn"] = 5;
$packSetting["ZSpawn",0] = "Normal Zombie";
$packSetting["ZSpawn",1] = "Ravanger Zombie";
$packSetting["ZSpawn",2] = "Zombie Lord";
$packSetting["ZSpawn",3] = "Demon Zombie";
$packSetting["ZSpawn",4] = "Air-Rapier Zombie";
$packSetting["ZSpawn",5] = "Demon Mother";

$expertsettings["Zspawn"] = 1;
$expertsetting["Zspawn",0] = "continual spawn";
$expertsetting["Zspawn",1] = "spawn once";

$packSettings["ArtPack"] = 1;
$packSetting["ArtPack",0] = "Normal Shells 12 Ammo";
$packSetting["ArtPack",1] = "Cluster Shells 6 Ammo";

$WeaponSettings["modifier0"] = 0;

$WeaponSettings["modifier1"] = 18;
$WeaponSetting["modifier1",0] = "DeployedSpine lsb";//0.125 0.166666 1
$WeaponSetting["modifier1",1] = "DeployedMSpine msb";//0.125 0.166666 1
$WeaponSetting["modifier1",2] = "DeployedwWall WalkWay";//0.125 0.166666 1
$WeaponSetting["modifier1",3] = "DeployedWall Bwall";//0.125 0.166666 1
$WeaponSetting["modifier1",4] = "DeployedSpine2 Dark Pad";//0.125 0.166666 1
$WeaponSetting["modifier1",5] = "DeployedCrate0 (crate1) back pack";//0.5 1 0.925
$WeaponSetting["modifier1",6] = "DeployedCrate1 (crate2) small containment";//0.16 0.5 0.488
$WeaponSetting["modifier1",7] = "DeployedCrate2 (crate3) large containment";//0.1 0.25 0.25
$WeaponSetting["modifier1",8] = "DeployedCrate3 (crate4) compressor";//1 1 1
$WeaponSetting["modifier1",9] = "DeployedCrate4 (crate5) tubes";//0.5 0.5 0.48
$WeaponSetting["modifier1",10] = "DeployedCrate5 (crate6) quantum battery";//0.25 0.25 0.25
$WeaponSetting["modifier1",11] = "DeployedCrate6 (crate7) proton accelerator";//0.25 0.5 0.5
$WeaponSetting["modifier1",12] = "DeployedCrate7 (crate8) cargo crate";//0.1255 0.249 0.246
$WeaponSetting["modifier1",13] = "DeployedCrate8 (crate9) magnetic cooler";//0.0835 0.167 0.1666
$WeaponSetting["modifier1",14] = "DeployedCrate9 (crate10) recycle unit";//1.25 1.25 0.48;
$WeaponSetting["modifier1",15] = "DeployedCrate10 (crate11) fuel cannister";//0.834 0.834 0.336
$WeaponSetting["modifier1",16] = "DeployedCrate11 (crate12) wooden T2 box";
$WeaponSetting["modifier1",17] = "DeployedCrate12 (crate13) plasma router";
$WeaponSetting["modifier1",18] = "DeployedDecoration6 (deco1) statue base";

$WeaponSettings["modifier2"] = 7;
$WeaponSetting["modifier2",0] = "+whole scale";
$WeaponSetting["modifier2",1] = "+x axis scale";
$WeaponSetting["modifier2",2] = "+y axis scale";
$WeaponSetting["modifier2",3] = "+z axis scale";
$WeaponSetting["modifier2",4] = "-whole scale";
$WeaponSetting["modifier2",5] = "-x axis scale";
$WeaponSetting["modifier2",6] = "-y axis scale";
$WeaponSetting["modifier2",7] = "-z axis scale";

$WeaponSettings["modifier3"] = 7;
$WeaponSetting["modifier3",0] = "move up";
$WeaponSetting["modifier3",1] = "move down";
$WeaponSetting["modifier3",2] = "+x axis move";
$WeaponSetting["modifier3",3] = "-x axis move";
$WeaponSetting["modifier3",4] = "+y axis move";
$WeaponSetting["modifier3",5] = "-y axis move";
$WeaponSetting["modifier3",6] = "+z axis move";
$WeaponSetting["modifier3",7] = "-z axis move";

$WeaponSettings["modifier4"] = 3;
$WeaponSetting["modifier4",0] = "0.1";
$WeaponSetting["modifier4",1] = "0.01";
$WeaponSetting["modifier4",2] = "0.001";
$WeaponSetting["modifier4",3] = "1";

//list of smaller list
$WeaponSettings2["modifier"] = 5;//format :max  mode
$WeaponSetting2["modifier",0] = $WeaponSettings["modifier0"] SPC"Merge Pieces";
$WeaponSetting2["modifier",1] = $WeaponSettings["modifier1"] SPC"Swap Pad Texture";
$WeaponSetting2["modifier",2] = $packSettings["forcefield"]  SPC"Swap Force Field Texture";
$WeaponSetting2["modifier",3] = $WeaponSettings["modifier2"] SPC"Scale Pieces";
$WeaponSetting2["modifier",4] = $WeaponSettings["modifier3"] SPC"Nudge Pieces";
$WeaponSetting2["modifier",5] = $WeaponSettings["modifier4"] SPC"Modifier Scaler";
