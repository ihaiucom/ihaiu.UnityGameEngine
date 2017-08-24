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



-- [同步]加载并创建 预设
function M:GetInstallPrefab( path )
	local prefab = self.csAsset:LoadAsset(path)
	local go = GameObject.Instantiate(prefab)
	return go
end


-- [同步] 加载并返回资源 非预设
function M:GetAsset( path )
	return self.csAsset:LoadAsset(path)
end

