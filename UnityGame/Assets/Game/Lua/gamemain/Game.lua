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
	Game.csShinezoneNet	= CS.Game.shinezoneNet

	Game.mainThread		= MainThreadManager
	Game.asset			= AssetManager
	Game.loader			= LoaderManager
	Game.config 		= ConfigManager
	Game.modules 		= ModuleManager
	Game.menu 			= MenuManager
	Game.channel		= ChannelManager
	Game.sysmsg			= SystemMessage
	Game.channel 		= ChannelManager

	PlayerPrefs.SetAppPrefix(Setting.app.appPrefix)

	Game.mainThread:Install()
	Game.config:Install()
	Game.modules:Install("gamemodule/modules/ModuleManager_List")
	Game.menu:Install()
	Game.sysmsg:Install()


	-- 加载配置
	Game.config.Load()

	-- 渠道初始化和登录
	Game.channel:Install()
	Game.channel:Login()

	-- Game.menu:Open(MenuId.Login)


	-- 测试
	Game.Test()



end

-- 测试代码
function Game:Test(  )
	
	-- 测试状态消息
	-- Game.sysmsg:StateShowText("Watting... ")

	-- 测试浮动消息
	-- Game.sysmsg:ToastText("AAA")

	-- 测试协程
	-- require "test/TestCoroutine"



	-- 测试 proto
	require "test/TestProto"
end