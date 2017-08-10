LoaderManager = class("LoaderManager", {
	dict = {}, --<int loadId, LoadCtl>
})

local M = LoaderManager

-- 获取加载面板ID对应的LoaderPanel Class
function M:GetLoaderPanelClass( loaderId )
	
	-- 默认是LoaderPanel
	return LoaderPanel
end



-- 获取加载进度面板控制器
function M:GetLoaderCtl(loaderId )
	return self.dict[loaderId]
end


-- 打开加载进度面板控制器
function M:Open( loaderId )
	local loaderCtl = self:GetLoaderCtl(loaderId)
	if loaderCtl == nil then
		local loaderConfig = Game.config.loader:GetConfig(loaderId)
		if loaderConfig == nil then
			error(string.format("不存在加载进度面板配置LoadManager Open loadConfig=null loaderId=%d", loaderId))
		end

		loaderCtl = LoaderCtl.New()
		loaderCtl.loaderId = loaderId
		loaderCtl.loaderConfig = loaderConfig
		self.dict[loaderId] = loaderCtl
	end

	loaderCtl:Open()
	return loaderCtl
end

-- 关闭加载进度控制器
function M:Close( loaderId )
	local loaderCtl = self:GetLoaderCtl(loaderId)
	if loaderCtl then
		loaderCtl:Close()
	end
end


-- 关闭所有
function M:CloseAll(  )
	for k, v in pairs(self.dict) do
		v:Close()
	end
end