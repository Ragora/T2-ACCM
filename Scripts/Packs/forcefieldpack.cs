//---------------------------------------------------------
// Deployable Force Field
//---------------------------------------------------------
//modified by Captn Power
// Translucencies
%noPassTrans = 1.0;
%teamPassTrans = 0.6;
%allPassTrans = 0.2;

%dimDiv = 4;

// RGB
%colourOn = 0.3;
%colourOff = 0.0;

datablock ForceFieldBareData(DeployedForceField) {
	className = "forcefield";
	fadeMS = 200;
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "1.0 1.0 1.0";
	powerOffColor = "0.0 0.0 0.0";
	targetNameTag = 'Force Field';
	targetTypeTag = 'ForceField';
	texture[0] = "skins/forcef1";
	texture[1] = "skins/forcef2";
	texture[2] = "skins/forcef3";
	texture[3] = "skins/forcef4";
	texture[4] = "skins/forcef5";
	framesPerSec = 1; // 10
	numFrames = 5;
	scrollSpeed = 15;
	umapping = 0.01; // 1.0
	vmapping = 0.01; // 0.15
	deployedFrom = ForceFieldDeployable;
	needsPower = true;
};

// No pass
datablock ForceFieldBareData(DeployedForceField0) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOn SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField1) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOn SPC %colourOff SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField2) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOff SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField3) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOff SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField4) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOff SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField5) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOn SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField6) : DeployedForceField {
	baseTranslucency = %noPassTrans;
	powerOffTranslucency = %noPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = %colourOn SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

// Team pass
datablock ForceFieldBareData(DeployedForceField7) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOn SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField8) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOn SPC %colourOff SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField9) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOff SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField10) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOff SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField11) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOff SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField12) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOn SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField13) : DeployedForceField {
	baseTranslucency = %teamPassTrans;
	powerOffTranslucency = %teamPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = %colourOn SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

// All pass
datablock ForceFieldBareData(DeployedForceField14) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField15) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOff SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField16) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOff SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField17) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOff SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField18) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOff SPC %colourOn SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField19) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOff SPC %colourOn;
	powerOffColor = "0.0 0.0 0.0";
};

datablock ForceFieldBareData(DeployedForceField20) : DeployedForceField {
	baseTranslucency = %allPassTrans;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = %colourOn SPC %colourOn SPC %colourOff;
	powerOffColor = "0.0 0.0 0.0";
};

// thx to quantium mod for idea but those are diferent i made shure of it
//lightning   no pass
datablock ForceFieldBareData(DeployedForceField21) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	texture[0] = "special/shockLightning01";
    texture[1] = "special/shockLightning02";
    texture[2] = "special/shockLightning03";
	color         = "0.1 0.6 0.2";
	powerOffColor = "0.0 0.0 0.0";
  framesPerSec = 12;
  numFrames = 3;
  scrollSpeed = 0.1;
  umapping = 0.35;//0.45;
  vmapping = 5;
};
//scan line  no pass
datablock ForceFieldBareData(DeployedForceField22) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.1 0.5 0.1";
	powerOffColor = "0.0 0.0 0.0";
    texture[0] = "special/sniper00";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 0.3;
  umapping = 1;
  vmapping = 0.05;

};
//grid    no pass
datablock ForceFieldBareData(DeployedForceField23) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.7 0.5 0.5";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "special/shocklance_effect01";//"desert/CP_itec01";//"liquidTiles/Modulation03";      // pack_rep05
   texture[1] = "special/shocklance_effect02";
  framesPerSec = 10;                    // plrec04
  numFrames = 2;                       // beampulse
  scrollSpeed = 1;
  umapping = 1.3;
  vmapping = 1.3;
};
//  fire wall  special    no pass
datablock ForceFieldBareData(DeployedForceField24) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.7 0.3 0";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/redbump2";
  texture[1] = "special/ELFBeam";
  framesPerSec = 5;
  numFrames = 2;
  scrollSpeed = 5;
  umapping = 0.5;
  vmapping = 0.6;
};
//energy feild   no pass
datablock ForceFieldBareData(DeployedForceField25) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color[0]         = "0.6 0.6 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/jammermap";
  framesPerSec = 2;
  numFrames = 1;
  scrollSpeed = 1;
  umapping = 0.3;
  vmapping = 0.3;
};
//flashing   no pass
datablock ForceFieldBareData(DeployedForceField26) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.4 0.4 0.9";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/stationglow";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 1.5;
  umapping = 0.01;
  vmapping = 0.01;
};
//dirty window     no pass
datablock ForceFieldBareData(DeployedForceField27) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "1 1 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "skins/tribes1.plaque";//"skins/tribes1.plaque";//"liquidtiles/icebound_water";

  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 0;
  umapping = 0.4;
  vmapping = 0.4;
};
////////////////////////////////////////////////////////////
// scan line team pass
datablock ForceFieldBareData(DeployedForceField28) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = "0.1 0.5 0.1";
	powerOffColor = "0.0 0.0 0.0";
    texture[0] = "special/sniper00";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 0.3;
  umapping = 1;
  vmapping = 0.05;

};
//grid    team pass
datablock ForceFieldBareData(DeployedForceField29) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = "0.5 0.7 0.5";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "special/shocklance_effect01";//"desert/CP_itec01";//"liquidTiles/Modulation03";      // pack_rep05
   texture[1] = "special/shocklance_effect02";
  framesPerSec = 10;                    // plrec04
  numFrames = 2;                       // beampulse
  scrollSpeed = 1;
  umapping = 1.3;
  vmapping = 1.3;
};
//energy feild   team pass
datablock ForceFieldBareData(DeployedForceField30) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color[0]         = "0.6 0.6 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/jammermap";
  framesPerSec = 2;
  numFrames = 1;
  scrollSpeed = 1;
  umapping = 0.3;
  vmapping = 0.3;
};
//flashing   team pass
datablock ForceFieldBareData(DeployedForceField31) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = false;
	color         = "0.4 0.4 0.9";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/stationglow";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 1.5;
  umapping = 0.01;
  vmapping = 0.01;
};
///////////////////////////////////////////////////////////////////////////
// scan line all pass
datablock ForceFieldBareData(DeployedForceField32) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.1 0.5 0.1";
	powerOffColor = "0.0 0.0 0.0";
    texture[0] = "special/sniper00";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 0.3;
  umapping = 1;
  vmapping = 0.05;

};
//grid    team pass
datablock ForceFieldBareData(DeployedForceField33) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.5 0.5 0.7";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "special/shocklance_effect01";//"desert/CP_itec01";//"liquidTiles/Modulation03";      // pack_rep05
   texture[1] = "special/shocklance_effect02";
  framesPerSec = 10;                    // plrec04
  numFrames = 2;                       // beampulse
  scrollSpeed = 1;
  umapping = 1.3;
  vmapping = 1.3;
};
//energy feild   all pass
datablock ForceFieldBareData(DeployedForceField34) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color[0]         = "0.6 0.6 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/jammermap";
  framesPerSec = 2;
  numFrames = 1;
  scrollSpeed = 1;
  umapping = 0.3;
  vmapping = 0.3;
};
//flashing   all pass
datablock ForceFieldBareData(DeployedForceField35) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.4 0.4 0.9";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "special/stationglow";
  framesPerSec = 10;
  numFrames = 1;
  scrollSpeed = 1.5;
  umapping = 0.01;
  vmapping = 0.01;
};
/////////////////////////////////////////////////////

//weird firewall   all pass
datablock ForceFieldBareData(DeployedForceField36) : DeployedForceField {
	baseTranslucency =1; //0.8;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "1 0.3 0.1";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "special/water2";//"desert/CP_itec01";//"liquidTiles/Modulation03";      // pack_rep05
  framesPerSec = 1;                    // plrec04
  numFrames = 1;                       // beampulse
  scrollSpeed = 2.5;
  umapping = 0.05;
  vmapping = 0.05;
};

//my lava    all pass
datablock ForceFieldBareData(DeployedForceField37) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.8 0.8 0.8";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "liquidTiles/lavapool01";
   texture[1] = "liquidTiles/lavapool02";
   texture[2] = "liquidTiles/lavapool03";
   texture[3] = "liquidTiles/lavapool04";
  framesPerSec = 0.1;                    // plrec04
  numFrames = 4;                       // beampulse
  scrollSpeed = 0.01;
  umapping = 0.1;
  vmapping = 0.2;
};
//water   all pass
datablock ForceFieldBareData(DeployedForceField38) : DeployedForceField {
	baseTranslucency = 0.8;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.1 0.4 0.7";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "liquidTiles/Modulation03";      // pack_rep05
  framesPerSec = 10;                    // plrec04
  numFrames = 1;                       // beampulse
  scrollSpeed = 0.6;
  umapping = 0.4;
  vmapping = 0.4;
};

//Flashing Crosshair
datablock ForceFieldBareData(DeployedForceField39) : DeployedForceField {
	baseTranslucency =1;//1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
   color = "1 0.5 0";
  powerOffColor = "0.0 0 0";
 texture[0] = "commander/icons/com_waypoint_6";
 texture[1] = "commander/icons/com_waypoint_5";
 texture[2] = "commander/icons/com_waypoint_4";
 texture[3] = "commander/icons/com_waypoint_3";
 texture[4] = "commander/icons/com_waypoint_2";
  framesPerSec = 5;
  numFrames = 5;
  scrollSpeed = 0;
  umapping = 0.6;//0.1;
  vmapping = 0.6;//0.1;
};
//Glass Tile
datablock ForceFieldBareData(DeployedForceField40) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color[0]         = "0.5 0.5 0.5";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "skins/silvercube";//"special/jammermap";
  framesPerSec = 1;
  numFrames = 1;
  scrollSpeed = 0;
  umapping = 1;
  vmapping = 1;
};
//Vehicle Icons
datablock ForceFieldBareData(DeployedForceField41) : DeployedForceField {
	baseTranslucency =1;//3;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         ="1 1 1";//"0.4 0.4 0.9";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "gui/hud_veh_icon_assault";//"special/stationglow";
  texture[1] = "gui/hud_veh_icon_bomber";
  texture[2] = "gui/hud_veh_icon_hapc";
  texture[3] = "gui/hud_veh_icon_mpb";
  texture[4] = "gui/hud_veh_icon_shrike";
  framesPerSec = 1;//10;
  numFrames = 5;
  scrollSpeed = 0;//1.5;
  umapping = 0.3;//0.01;
  vmapping = 0.3;//0.01;
};
// Space 1
datablock ForceFieldBareData(DeployedForceField42) : DeployedForceField {
	baseTranslucency =1;//3;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         ="1 1 1";// "0.1 0.5 0.1";
	powerOffColor = "0.0 0.0 0.0";
    texture[0] = "redplanet_1";
    texture[1] = "redplanet_2";
    texture[2] = "redplanet_3";
    texture[3] = "redplanet_4";
    texture[4] = "redplanet_5";
  framesPerSec = 1;
  numFrames = 5;
  scrollSpeed = 0;
  umapping = 0.1;
  vmapping = 0.1;

};
//clouds 1
datablock ForceFieldBareData(DeployedForceField43) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = true;
	otherPermiable = true;
	color         = "0.8 0.8 0.8";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "desert/skies/desertmove2";
  framesPerSec = 1;                    // plrec04
  numFrames = 1;                       // beampulse
  scrollSpeed = 1;
  umapping = 0.01;
  vmapping = 0.01;
};
//Fuzzy Scanlines
datablock ForceFieldBareData(DeployedForceField44) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color[0]         ="1 0.1 1";// "0.6 0.6 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "skins/scanline2";
  texture[1] = "skins/scanline3";
  texture[2] = "skins/scanline4";
  texture[3] = "skins/scanline5";
  texture[4] = "skins/scanline6";
  framesPerSec = 8;
  numFrames = 5;
  scrollSpeed = 0;
  umapping = 0.05;
  vmapping = 0.2;
};
//Space 2
datablock ForceFieldBareData(DeployedForceField45) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "1 1 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "badlands/skies/starrynite_v2_fr";//nef_tr2_red_1";
  texture[1] = "ice/skies/starrynite_v1_bk";//nef_tr2_red_2";
  texture[2] = "lava/skies/starrynite_v5_lf";//nef_tr2_red_3";
  texture[3] = "lush/skies/starrynite_v6_rt";//nef_tr2_red_7";
  texture[4] = "lush/skies/starrynite_v4_fr";//nef_tr2_red_5";
  framesPerSec = 1;
  numFrames = 5;
  scrollSpeed = 0;
  umapping = 0.1;
  vmapping = 0.1;
};
//Signs
datablock ForceFieldBareData(DeployedForceField46) : DeployedForceField {
	baseTranslucency =1;//1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "1 1 1";
	powerOffColor = "0.0 0.0 0.0";
  texture[0] = "skins/billboard_1";
  texture[1] = "skins/billboard_2";
  texture[2] = "skins/billboard_3";
  texture[3] = "skins/billboard_4";
  framesPerSec = 2;
  numFrames = 4;
  scrollSpeed = 0;
  umapping = 0.1;
  vmapping = 0.1;
};

//clouds 2
datablock ForceFieldBareData(DeployedForceField47) : DeployedForceField {
	baseTranslucency =0.2;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.2 0.2 0.2";
	powerOffColor = "0.0 0.0 0.0";
   texture[0] = "desert/skies/desertmove1";
  framesPerSec = 1;                    // plrec04
  numFrames = 1;                       // beampulse
  scrollSpeed = 0;
  umapping = 0.01;
  vmapping = 0.01;
};
////////////////////////////////////////////////////////////
//computer screen
datablock ForceFieldBareData(DeployedForceField48) : DeployedForceField {
	baseTranslucency =1;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.7 0.7 0.7";
	powerOffColor = "0.0 0.0 0.0";
    texture[0] = "lava/ds_mriveted2";//"ice/sw_ewal02a";//"desert/cp_icomp01f";
  framesPerSec = 1;//10;
  numFrames = 1;
  scrollSpeed = 0;//0.3;
  umapping = 0.67;//1;
  vmapping = 0.495;//0.05;

};
//Orb Symbol
datablock ForceFieldBareData(DeployedForceField49) : DeployedForceField {
	baseTranslucency =1; //0.8;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "0.7 0.7 0.7";
	powerOffColor = "0.0 0.0 0.0";
texture[0] = "badlands/bd_itec02"; //3.5 6.5 0.1 for pad size
  framesPerSec = 1;
  numFrames = 1;
  scrollSpeed = 0;
umapping = 0.6;
vmapping = 0.3;
};
//esp ff
datablock ForceFieldBareData(DeployedForceField50) : DeployedForceField {
	baseTranslucency =1; //0.8;
	powerOffTranslucency = %allPassTrans / %dimDiv;
	teamPermiable = false;
	otherPermiable = false;
	color         = "1 0.2 1";
	powerOffColor = "0.0 0.0 0.0";
   //texture[0] = "gui/trn_1charybdis";//texture[0] = "precipitation/snowflake017";
   //texture[1] = "gui/trn_2sehrganda";//texture[1] = "precipitation/snowflake016";
   //texture[2] = "gui/trn_3ymir";
   //texture[3] = "gui/trn_4bloodjewel";
   //texture[4] = "gui/trn_5draconis";
   texture[0] = "skins/noise";
  framesPerSec = 1;                    // plrec04
  numFrames = 1;                       // beampulse
  scrollSpeed = 7;
  umapping = 3;
  vmapping = 1;
};


datablock ShapeBaseImageData(ForceFieldDeployableImage) {
	mass = 20;
	emap = true;
	shapeFile = "ammo_chaingun.dts";
	item = ForceFieldDeployable;
	mountPoint = 1;
	offset = "-0.2 -0.125 0";
	rotation = "0 -1 0 90";
	deployed = DeployedForceField;
	heatSignature = 0;

	stateName[0] = "Idle";
	stateTransitionOnTriggerDown[0] = "Activate";

	stateName[1] = "Activate";
	stateScript[1] = "onActivate";
	stateTransitionOnTriggerUp[1] = "Idle";

	maxDepSlope = 360;
	deploySound = ItemPickupSound;

	minDeployDis = 0.1;
	maxDeployDis = 50.0;
};

datablock ItemData(ForceFieldDeployable) {
	className = Pack;
	catagory = "Deployables";
	shapeFile = "stackable1s.dts";
	mass = 5.0;
	elasticity = 0.2;
	friction = 0.6;
	pickupRadius = 1;
	rotate = true;
	image = "ForceFieldDeployableImage";
	pickUpName = "a force field pack";
	heatSignature = 0;
	emap = true;
};
function ForceFieldDeployableImage::testObjectTooClose(%item) {
	return;
}

function ForceFieldDeployableImage::testNoTerrainFound(%item) {
	// don't check this for non-Landspike turret deployables
}

function ForceFieldDeployable::onPickup(%this, %obj, %shape, %amount) {
	// created to prevent console errors
}

function ForceFieldDeployableImage::onDeploy(%item, %plyr, %slot) {
	//Object
	%className = "ForceFieldBare";

	%grounded = 0;
	if (%item.surface.getClassName() $= TerrainBlock)
		%grounded = 1;

	%playerVector = vectorNormalize(-1 * getWord(%plyr.getEyeVector(),1) SPC getWord(%plyr.getEyeVector(),0) SPC "0");

	if (%item.surfaceinher == 0) {
		if (vAbs(floorVec(%item.surfaceNrm,100)) $= "0 0 1")
			%item.surfaceNrm2 = %playerVector;
		else
			%item.surfaceNrm2 = vectorNormalize(vectorCross(%item.surfaceNrm,"0 0 1"));
	}

	%rot = fullRot(%item.surfaceNrm,%item.surfaceNrm2);
	%scale = getWords($packSetting["forcefield",%plyr.packSet],0,2);
	%mCenter = "-0.5 -0.5 -0.5";
	%pad = pad(%item.surfacePt SPC %item.surfaceNrm SPC %item.surfaceNrm2,%scale,%mCenter);
	%scale = getWords(%pad,0,2);
	%item.surfacePt = getWords(%pad,3,5);
	%rot = getWords(%pad,6,9);

	// Add padding
	%padSize = 0.01;
	%scale = vectorAdd(%scale,%padSize * 2 SPC %padSize * 2 SPC -%padSize * 2);
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm),%padSize));
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(%item.surfaceNrm2),%padSize));
	%item.surfacePt = vectorSub(%item.surfacePt,vectorScale(vectorNormalize(vectorCross(%item.surfaceNrm,%item.surfaceNrm2)),-%padSize));

    if (%item.squaresize !$="")
       %test = buddychek(%item.surface.getOwner(),%plyr.client.guid);
    else
        %test=1;

	if ($Host::ExpertMode == 1) {
		if (isCubic(%item.surface) && (%plyr.expertSet == 1 || %plyr.expertSet == 3 || %plyr.expertSet == 4) && %plyr.team == %item.surface.team
		&& %item.surface.getType() & $TypeMasks::StaticShapeObjectType
		&& ((($Host::OnlyOwnerCubicReplace == 0) || (%plyr.client == %item.surface.getOwner()))
        || %test ==1 )) {
			%scale = vectorAdd(realSize(%item.surface),%padSize * 2 SPC %padSize * 2 SPC %padSize * 2);
			%center = realVec(%item.surface,vectorScale(getWords(%scale,0,1) SPC "0",-0.5));
			%item.surfacePt = vectorAdd(pos(%item.surface),%center);
			%rot = rot(%item.surface);
			%mod = vectorScale(matrixMulVector("0 0 0" SPC %rot ,"0 0 1"),-%padSize);
			%item.surfacePt = vectorAdd(%item.surfacePt,%mod);
			%item.surface.getDataBlock().disassemble(%plyr, %item.surface);
                 if( %plyr.expertSet == 4){
                 %deplObj.disarm = 1;
                 }
		}
	}

	// TODO - temporary test fix - remove?
	%scale = vectorAdd(%scale,"0 0 0");
	%x = getWord(%scale,0);
	%y = getWord(%scale,1);
	%z = getWord(%scale,2);
	if (%x <= 0)
		%x = 0.001;
	if (%y <= 0)
		%y = 0.001;
	if (%z <= 0)
		%z = 0.001;
	%scale = %x SPC %y SPC %z;

	%deplObj = new (%className)() {
		dataBlock = %item.deployed @ %plyr.packSet;
		scale = %scale;
	};

	// Take the deployable off the player's back and out of inventory
	//if ($Host::ExpertMode == 0) {
	//	%plyr.unMountImage(%slot);
	//	%plyr.decInventory(%item.item,1);
	//}

////////////////////////Apply settings//////////////////////////////

	// [[Location]]:

	// exact:
	%deplObj.setTransform(%item.surfacePt SPC %rot);
	%deplObj.pzone.setTransform(%item.surfacePt SPC %rot);

	if ($Host::ExpertMode == 1) {
		if (%plyr.expertSet == 2 || %plyr.expertSet == 3){
			%deplObj.noSlow = true;
			%deplObj.pzone.delete();
			%deplObj.pzone = "";
		}
	}

	// misc info
	addDSurface(%item.surface,%deplObj);

	// [[Settings]]:

	%deplObj.grounded = %grounded;
	%deplObj.needsFit = 1;

	// [[Normal Stuff]]:

	// set team, owner, and handle
	%deplObj.team = %plyr.client.team;
	%deplObj.setOwner(%plyr);

	// set power frequency
	%deplObj.powerFreq = %plyr.powerFreq;
    %deplObj.notogle=0;
	// set the sensor group if it needs one
	if (%deplObj.getTarget() != -1)
		setTargetSensorGroup(%deplObj.getTarget(), %plyr.client.team);

	// place the deployable in the MissionCleanup/Deployables group (AI reasons)
	addToDeployGroup(%deplObj);

	//let the AI know as well...
	AIDeployObject(%plyr.client, %deplObj);

	// play the deploy sound
	serverPlay3D(%item.deploySound, %deplObj.getTransform());

	// increment the team count for this deployed object
	$TeamDeployedCount[%plyr.team, %item.item]++;

	// Power object
	checkPowerObject(%deplObj);

	if (!%deplObj.powerCount > 0) {
		%deplObj.getDataBlock().disassemble(0,%deplObj); // Run Item Specific code.
		messageClient(%plyr.client,'MsgDeployFailed','\c2Force field lost - no power source found!%1','~wfx/misc/misc.error.wav');
	}

	return %deplObj;
}
//////////////////////////////////////////////////////////////////
function ForceFieldDeployableImage::onMount(%data, %obj, %node) {
	%obj.hasForceField = true; // set for forcefieldcheck
	%obj.packSet = 0;
	%obj.expertSet = 0;
	displayPowerFreq(%obj);
}

function ForceFieldDeployableImage::onUnmount(%data, %obj, %node) {
	%obj.hasForceField = "";
	%obj.packSet = 0;
	%obj.expertSet = 0;
}
function DeployedForceField::disassemble(%data,%plyr,%obj) {
	if (isObject(%obj.pzone))
		%obj.pzone.delete();
	disassemble(%data,%plyr,%obj);
}

function DeployedForceField0::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField1::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField2::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField3::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField4::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField5::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField6::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField7::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField8::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField9::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField10::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField11::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField12::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField13::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField14::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField15::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField16::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField17::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField18::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField19::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField20::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}





///////////////


function DeployedForceField21::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField22::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField23::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField24::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField25::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField26::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField27::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField28::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField29::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField30::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}


//////////


function DeployedForceField31::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField32::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField33::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField34::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField35::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField36::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

//

function DeployedForceField37::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField38::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField39::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

/////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////
function DeployedForceField40::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField41::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField42::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField43::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField44::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField45::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField46::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField47::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField48::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}

function DeployedForceField49::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}
function DeployedForceField50::disassemble(%data,%plyr,%obj) {
	DeployedForceField::disassemble(%data,%plyr,%obj);
}
