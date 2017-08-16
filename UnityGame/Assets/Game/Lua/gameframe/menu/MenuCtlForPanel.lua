MenuCtlForPanel = class("MenuCtlForPanel",MenuCtl)


local M = MenuCtlForPanel

-- 模块视图
M.moduleView 	= nil
-- 是否是预安装
M.isPreinstall 	= false
-- 参数
M.args			= nil


-- [实现抽象] 打开
function M:Open( ... )
	self.args	= {...}

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

	if self.config.path == nil then
		return
	end

	local obj = Game.asset:TryGet(self.config.path)


	if obj == nil then
		error(string.format("没有加载到面板预设资源 %s menuId=%d, path=%s", self.__cname, self.menuId, self.config.path))
	end

	local go = GameObject.Instantiate(obj)


	self.moduleView 				= self.moduleCtl.ViewClass.New()


	self.moduleView.gameObject 		= go
	self.moduleView.transform 		= go.transform
	self.moduleView.module 			= self.moduleCtl
	self.moduleView:SetLayout(self.config.layer, self.config.layout)
	self.moduleView:BindGameObject(go)
	self:SetModuleViewShow()
end



-- 设置模块视图显示
function M:SetModuleViewShow(  )
	self.moduleView.transform:SetAsLastSibling()
	self.moduleView:Show()
	self.state 		= MenuCtlStateType.Opened
	self:CloseOther()

	self.moduleView:MenuCallOnOpen(unpack(self.args))
end



-- [实现抽象] 进度条打开
function M:LoaderOpen( )
	self.loaderCtl = Game.loader:Open(LoaderId.Circle)
end


-- [实现抽象] 进度条关闭
function M:LoaderClose( )
	if self.loaderCtl then
		self.loaderCtl:Close()
	end
end



-- [实现抽象] 设置进度
function M:SetLoaderProgress( progress )
	if self.loaderCtl then
		self.loaderCtl:SetProgerss(progress)
	end
end