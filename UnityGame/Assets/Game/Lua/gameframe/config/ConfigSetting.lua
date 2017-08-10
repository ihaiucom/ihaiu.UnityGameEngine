ConfigSetting = {}
-- Action<string path, string content> callback
function ConfigSetting.Load( path, tab, fun )
	Game.asset:LoadConfig(path, tab, fun)
end