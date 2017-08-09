ConfigSetting = {}
-- Action<string path, string content> callback
function ConfigSetting.Load( path, tab, fun )
	Game.asset:LoadConfig(path, function ( path, txt )
		fun(tab, path, txt)
	end)
end