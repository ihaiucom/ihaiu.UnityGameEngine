require "gameversion/GameVersionInclude"

GameVersionManager = {}
local this = GameVersionManager

-- 初始化
function this.Install( ... )
	print("GameVersionManager.Install")

	this.Finish()
end

-- 结束
function this.Finish( ... )
	-- 初始化，主LuaEnv
	Game.InitLuaEnv()

	-- 销毁，版本检测LuaEnv
	Game.DestoryLuaEnvVersion()
end


GameVersionManager.Install()