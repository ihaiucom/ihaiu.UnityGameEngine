require "gamemain/GameInclude"

GameLaunch = {}
local this = GameLaunch

-- 初始化
function this.Install( ... )
	print("GameLaunch:Install")
	Game:Install()
end


GameLaunch.Install()
