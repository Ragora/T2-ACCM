// -------------------------------------------
//	player.cs
//	ACCM Player-bound commands
// ===========================================

function Player::setSkin(%self, %skin)
{
	freeTarget(%self.getTarget());

	%self.skin = %skin;
	// Zombitch
	if (!isObject(%self.client))
	{
		%self.target = createTarget(%self, %self.name, %skin, "Derm3", '', 6, PlayerSensor);
		setTargetSensorGroup(%self.target, 6);
	}
	else
	{
		%self.target = createTarget(%self, %self.client.name, %skin, %self.client.voice, '', 0, PlayerSensor);
		setTargetSensorGroup(%self.target, %self.client.team);
		setTargetName(%obj.target, %self.client.name);
		%self.client.skin = addTaggedString(%skin);
		%self.client.target = %self.target;
	}
	setTargetSkin(%self.target, addTaggedString(%skin));
	setTargetDataBlock(%self.target, %self.getDatablock());
	setTargetSensorData(%self.target, PlayerSensor);
	%self.setTarget(%self.target);
	return true;
}

function Player::setName(%self, %name)
{

	%self.name = %name;
	if (!isObject(%self.client))
	{
		freeTarget(%self.getTarget());
		%self.target = createTarget(%self, %self.name, %skin, "Derm3", '', 6, PlayerSensor);
		setTargetSensorGroup(%self.target, 6);
	}
	else
	{
		%ptarget = %self.target;
		%skin = getTaggedString(getTargetSkin(%self.getTarget()));
		%self.target = createTarget(%self, %name, %skin, %self.client.voice, '', 0, PlayerSensor);
		freeTarget(%ptarget);
		setTargetSensorGroup(%self.target, %self.client.team);
		setTargetName(%self.target, %name);
		%self.client.target = %self.target;
	}
	setTargetSkin(%self.target, addTaggedString(%self.skin));
	setTargetDataBlock(%self.target, %self.getDatablock());
	setTargetSensorData(%self.target, PlayerSensor);
	%self.setTarget(%self.target);
	return true;
}

