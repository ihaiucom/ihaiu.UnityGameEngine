AssetManager = class("AssetManager", {})

local M = AssetManager
M.csAsset = CS.Game.asset



-- 加载配置
function M:LoadConfig(path, tab, fun )
	self.csAsset:LoadConfig(path, function ( path, txt )
		fun(tab, path, txt)
	end)
end

-- [回调]加载
function M:Load( path, tab, fun )
	self.csAsset:Load(path, function ( path, obj )
		fun(tab, path, obj)
	end)
end

-- [同步]加载
function M:LoadAsset( path )
	return self.csAsset:LoadAsset(path)
end

-- 尝试获取资源 
function M:TryGet( path )
	return self.csAsset:TryGetAsset(path)
end