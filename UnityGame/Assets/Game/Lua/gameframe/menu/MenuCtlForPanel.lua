MenuCtlForPanel = class("MenuCtlForPanel",MenuCtl)


local M = MenuCtlForPanel

-- 模块视图
M.moduleView 	= nil
-- 是否是预安装
M.isPreinstall 	= false


-- [实现抽象] 打开
function M:Open( ... )

	print("====打开模块", self, self.moduleView)
	if self.moduleView then
		self:SetModuleViewShow()
	else
		self:Load()
	end
end


-- [实现抽象] 关闭
function M:Close(  )

	if self.moduleView then
		self:SetModuleViewShow()
	end

	self.state 		= MenuCtlStateType.Closed
	self.cacheTime 	= 0

end


-- [实现抽象] 销毁
function M:OnDestory( )

	if self.moduleView then 
		self.moduleView:Destory()
	end

	self.moduleView = nil
end



-- [重写]获取模块资源列表
function M:GetLoadAssets( )
	if self.config.path == nil then
		return self.super.GetLoadAssets(self)
	end

	local list = self.super.GetLoadAssets(self)
	list = list or {}

	table.insert(list, self.config.path)

	return list
end



-- [实现抽象] 预加载资源加载完成
function M:OnLoadAssetsComplete(  )

	print("==========[实现抽象] 预加载资源加载完成 OnLoadAssetsComplete")
	if self.config.path == nil then
		return
	end

	local obj = Game.asset:TryGet(self.config.path)

	print("===obj", obj)

	if obj == nil then
		error(string.format("没有加载到面板预设资源 %s menuId=%d, path=%s", self.__cname, self.menuId, self.config.path))
	end

	local go = GameObject.Instantiate(obj)

	print("===go", go)


	print("===self.moduleCtl.ViewClass", self.moduleCtl.ViewClass)

	self.moduleView 				= self.moduleCtl.ViewClass.New()

	print("===self.moduleView ", self.moduleView )

	self.moduleView.gameObject 		= go
	self.moduleView.transform 		= go.transform
	self.moduleView.module 			= self.moduleCtl
	self.moduleView:SetLayout(self.config.layer, self.config.layout)
	self.moduleView:BindGameObject(go)
	self:SetModuleViewShow()
end



-- 设置模块视图显示
function M:SetModuleViewShow( ... )
	self.moduleView.transform:SetAsLastSibling()
	self.moduleView:Show()
	self.state 		= MenuCtlStateType.Opened
	self:CloseOther()
end



-- [实现抽象] 进度条打开
function M:LoaderOpen( )

	print("====进度条打开 LoaderOpen", self)
	self.loaderCtl = Game.loader:Open(LoaderId.Circle)
end


-- [实现抽象] 进度条关闭
function M:LoaderClose( )
	print("====进度条关闭 LoaderClose")

	if self.loaderCtl then
		self.loaderCtl:Close()
	end
end



-- [实现抽象] 设置进度
function M:SetLoaderProgress( progress )

	print("====设置进度 SetLoaderProgress", self.__cname, progress)

	if self.loaderCtl then
		self.loaderCtl:SetProgerss(progress)
	end
end