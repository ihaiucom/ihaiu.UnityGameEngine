Game = {}

Game.__index = function ( t, k )
	return CS.Game[k]
end

setmetatable(Game, Game)





-- 初始化
function Game:Install( ... )
	print("Game:Install")
	Game.csMainThread	= CS.Game.mainThread
	Game.csAsset		= CS.Game.asset

	Game.mainThread		= MainThreadManager
	Game.asset			= AssetManager
	Game.loader			= LoaderManager
	Game.config 		= ConfigManager
	Game.modules 		= ModuleManager
	Game.menu 			= MenuManager

	Game.mainThread:Install()
	Game.config:Install()
	Game.modules:Install("gamemodule/modules/ModuleManager_List")
	Game.menu:Install()


	-- 加载配置
	Game.config.Load()

	Game.menu:Open(MenuId.Login)
	-- Game.Test()

end

-- 测试代码
function Game:Test(  )
	
	require "test/TestCoroutine"
end