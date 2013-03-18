function stopBlock(%client,%size,%type) {
	%plyr = %client.player;
	%pos = pos(%plyr);
	%maxRange = 500;

	%className = "ForceFieldBare";

	if (!%type)
		%type = 8;
	if (!%size)
		%size = 500;

	%planeSize = %size * 2;

	%pieces = mCeil(%planeSize / %maxRange);
	%pieceSize = %planeSize / %pieces ;

	%point1 = vectorAdd(%pos, %size SPC %size SPC %size);
	%point2 = vectorAdd(%pos, vectorScale(%size SPC %size SPC %size,-1));
//	echo(%pos);
//	echo(%point1);
//	echo(%point2);

	for (%x =0; %x < %pieces;%x++) {
		for (%y =0; %y < %pieces; %y++) {
			%topWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = %pieceSize SPC %pieceSize SPC 0.5;
			};
			%bottomWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = %pieceSize SPC %pieceSize SPC 0.5;
			};
			%eastWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = %pieceSize SPC 0.5 SPC %pieceSize;
			};
			%westWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = %pieceSize SPC 0.5 SPC %pieceSize;
			};
			%northWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = 0.5 SPC %pieceSize SPC %pieceSize;
			};
			%southWall = new (%className)() {
				dataBlock = DeployedForceField @ %type;
				scale = 0.5 SPC %pieceSize SPC %pieceSize;
			};
			%topWall.setTransform(vectorAdd(%point1,-1 * %x * %pieceSize SPC -1 * %y * %pieceSize SPC "0") SPC "0 0 1 3.14");
			%eastWall.setTransform(vectorAdd(%point1,-1 * %x * %pieceSize SPC "0" SPC  -1 * %y * %pieceSize) SPC "0 1 0 3.14");
			%northWall.setTransform(vectorAdd(%point1,"0" SPC -1 * %x * %pieceSize SPC -1 * %y * %pieceSize) SPC "1 0 0 3.14");
			%bottomWall.setTransform(vectorAdd(%point2,%x * %pieceSize SPC %y * %pieceSize SPC "0") SPC "0 0 1 0");
			%westWall.setTransform(vectorAdd(%point2,%x * %pieceSize SPC "0" SPC  %y * %pieceSize) SPC "0 1 0 0");
			%southWall.setTransform(vectorAdd(%point2,"0" SPC %x * %pieceSize SPC %y * %pieceSize) SPC "1 0 0 0");

			%topWall.team = %plyr.client.team;
			%topWall.setOwner(%plyr);
			%topWall.pzone.delete();
			%topWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;

			%eastWall.team = %plyr.client.team;
			%eastWall.setOwner(%plyr);
			%eastWall.pzone.delete();
			%eastWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;

			%northWall.team = %plyr.client.team;
			%northWall.setOwner(%plyr);
			%northWall.pzone.delete();
			%northWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;

			%bottomWall.team = %plyr.client.team;
			%bottomWall.setOwner(%plyr);
			%bottomWall.pzone.delete();
			%bottomWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;

			%westWall.team = %plyr.client.team;
			%westWall.setOwner(%plyr);
			%westWall.pzone.delete();
			%westWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;

			%southWall.team = %plyr.client.team;
			%southWall.setOwner(%plyr);
			%southWall.pzone.delete();
			%southWall.addToBlockGroup();
			$TeamDeployedCount[%plyr.team,ForceFieldDeployable]++;
		}
	}
}

function ForceFieldBare::addToBlockGroup(%obj) {
	%group = nameToID("MissionCleanup/BlockGroup");
	if (%group <= 0) {
		%group = new SimGroup("BlockGroup");
		MissionCleanup.add(%group);
	}
	%group.add(%obj);
}

function removeBlock() {
	%group = nameToID("MissionCleanup/BlockGroup");
	if (!(%group <= 0)) {
		%count = %group.getCount();
		for(%i=0;%i<%count;%i++) {
			%obj = %group.getObject(%i);
			if (%obj) {
				$TeamDeployedCount[%obj.team,ForceFieldDeployable]--;
			}
		}
		%group.delete();
	}
}
