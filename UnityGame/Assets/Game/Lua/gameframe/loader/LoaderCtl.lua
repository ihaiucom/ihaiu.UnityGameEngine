LoaderCtl = class("LoaderCtl", {
	loaderId 		= 0, 
	loaderConfig 	= nil,
	loaderPanel	 	= nil,
	isOpen			= false,
})

local M = LoaderCtl


-- 打开
function M:Open(  )
	self.isOpen = true

	if self.loaderConfig == nil or string.IsNullOrEmpty(self.loaderConfig.path) then
		Game.cricle:Show()
	else
		if self.loaderPanel then
			self.loaderPanel:Show()
		else	
			self:LoadPanelAsset()
		end
	end
end



-- 关闭
function M:Close(  )
	self.isOpen = false
	if self.loaderPanel then
		self.loaderPanel:Hide()
	end

	if string.IsNullOrEmpty(self.loaderConfig.path) then
		Game.cricle:Hide()
	end
end


-- 设置进度
function M:SetProgerss(progress )
	if self.loaderPanel  then
		self.loaderPanel:SetProgerss(progress)
	end
end


-- 加载加载条面板
function M:LoadPanelAsset(  )
	if self.loaderConfig.isShowCircle then
		Game.cricle:Show()
	end

	Game.asset:Load(self.loaderConfig.path, self, self.OnLoadPanelAsset)
end


function M:OnLoadPanelAsset( path, obj )


	if self.loaderConfig.isShowCircle then
		Game.cricle:Hide()
	end

	if obj == nil then
		error(string.format("加载加载条面板 %s OnLoadPanelAsset obj=nil path=%s", self.__cname, path))
		return
	end


	local go = GameObject.Instantiate(obj)

	self.loaderPanel = Game.loader:GetLoaderPanelClass(self.loaderId).New()
	self.loaderPanel:BindGameObject(go)
	self.loaderPanel:SetLayout()
	self.loaderPanel:Show()

end
