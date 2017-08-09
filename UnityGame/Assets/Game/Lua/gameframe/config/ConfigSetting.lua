ConfigSetting = {}
-- Action<string path, string content> callback
function ConfigSetting.Load( path, callback )
	Game.asset:LoadConfig(path, callback)
end