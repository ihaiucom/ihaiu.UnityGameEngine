AssetManager = class("AssetManager", {})

local M = AssetManager

-- 加载配置
function M:LoadConfig(path, tab, fun )
	Game.csAsset:LoadConfig(path, function ( path, txt )
		fun(tab, path, txt)
	end)
end

-- 加载
function M:Load( path, tab, fun )
	Game.csAsset:Load(path, function ( path, obj )
		fun(tab, path, obj)
	end)
end

-- 尝试获取资源 
function M:TryGet( path )
	return Game.csAsset:TryGetAsset(path)
end