Game = {}

Game.__index = function ( t, k )
	return CS.Game[k]
end

setmetatable(Game, Game)


-- 初始化
function Game:Intall( ... )
	
end