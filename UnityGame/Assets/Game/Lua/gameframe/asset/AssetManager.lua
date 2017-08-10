AssetManager = class("AssetManager", {})

local M = AssetManager

-- 加载配置
function M:LoadConfig(path, tab, fun )
	Game.csAsset:LoadConfig(path, function ( path, txt )
		fun(tab, path, txt)
	end)
end

-- 加载
function M:Load( path, tabl, fun )
	Game.csAsset:Load(path, function ( path, obj )
		fun(tab, path, obj)
	end)
end