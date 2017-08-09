Game = {}

Game.__index = function ( t, k )
	return CS.Game[k]
end

setmetatable(Game, Game)





-- 初始化
function Game:Install( ... )
	print("Game:Install")
	Game.config 	= ConfigManager
	Game.module 	= ModuleManager
	Game.menu 		= MenuManager

	Game.config:Install()
	Game.module:Install("gamemodule/modules/ModuleManager_List")
	Game.menu:Install()


	-- 加载配置
	Game.config.Load()


end