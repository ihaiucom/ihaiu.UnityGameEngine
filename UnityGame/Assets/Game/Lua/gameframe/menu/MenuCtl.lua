MenuCtl = class("MenuCtl",{
	-- 模块ID
	menuId 		= 0,

	-- MenuConfig
	config 		= nil,

	-- 模块接口,继承自AbstractModule
	moduleCtl 	= nil,

	-- 状态
	-- MenuCtlStateType
	state 		= MenuCtlStateType.Closed ,

	-- 缓存时间
	cacheTime 	= 0,

	-- 加载进度面板控制器
	loaderCtl 	= nil,

	-- 预加载资源
	_preloadAssets 		= {},
	_preloadState 		= MenuCtlPreloadStateType.None, 
	_preloadCount 		= 0,
	_preloadNum 		= 0,
	_preloadIsStop		= false,

})

local M = MenuCtl


-- [抽象]打开
function M:Open( ... )
	
end


-- [抽象]关闭
function M:Close(  )
	
end

-- 销毁
function M:Destory( )
	if self.moduleCtl then

	end

	self:OnDestory()
end

-- [抽象]销毁
function M:OnDestory( )
	
end



-- 获取模块资源列表
function M:GetLoadAssets( )
	if self.moduleCtl then
		return self.moduleCtl:GetLoadAssets()
	end

	return nil
end


-- 关闭其他模块
function M:CloseOther(  )
	-- 不关闭任何面板
	if self.config.closeOtherType == MenuCloseOtherType.None then
		return
	end

	local dict = Game.menu:GetMenuCtlDic()

	-- 除自己外的所有
	if self.config.closeOtherType == MenuCloseOtherType.ExceptSelf_All then
		for id, ctl in pairs(dict) do
			if ctl ~= self then
				ctl:Close()
			end
		end

	-- 除自己外的所有模块层级面板
	elseif self.config.closeOtherType == MenuCloseOtherType.ExceptSelf_Module then
		for id, ctl in pairs(dict) do
			if ctl ~= self and UILayerId.__CastFrom(ctl.config.layer) == UILayerId.Layer_Module then
				ctl:Close()
			end
		end


	-- 相同层级的其他面板
	elseif self.config.closeOtherType == MenuCloseOtherType.ExceptSelf_SameLayer then
		for id, ctl in pairs(dict) do
			if ctl ~= self and ctl.config.layer == self.config.layer then
				ctl:Close()
			end
		end
	end

end


-- 加载资源
function M:Load(  )
	self.state = MenuCtlStateType.Loading
	self._preloadAssets = self:GetLoadAssets()
	if self._preloadAssets then
		self:StartLoadAssets()
	else
		self:OnLoadAssetsComplete()
	end
end


function M:StartLoadAssets( )


    self._preloadIsStop = false
    if self._preloadState == MenuCtlPreloadStateType.None then
		local co = coroutine.create(self.LoadAssets)
		coroutine.resume(co, self)
	end
end


function M:StopLoadAssets( )
	self._preloadIsStop = true
end

function M:LoadAssets( )

	self:LoaderOpen()
	self._preloadState 		= MenuCtlPreloadStateType.Loading 
	self._preloadCount 		= table.getn(self._preloadAssets)
	self._preloadNum		= 0


    self:SetLoaderProgress(0)


	for i, path in ipairs(self._preloadAssets) do

		if self._preloadIsStop then
			break
		end

		Game.asset:Load(path, self, self.OnLoadAsset)
		self._preloadNum = self._preloadNum + 1
        yield_return(CS.UnityEngine.WaitForEndOfFrame())
        self:SetLoaderProgress(self._preloadNum / self._preloadCount)
    end

	self._preloadState 		= MenuCtlPreloadStateType.None 

    if self._preloadIsStop == false then
    	self.__preloadComplete = true


    	self:OnLoadAssetsComplete()
    end


    self._preloadIsStop 	= false
	self:LoaderClose()
end

-- [抽象] 当预加载资源被加载
function M:OnLoadAsset( path, obj )
	
end




-- [抽象] 预加载资源加载完成
function M:OnLoadAssetsComplete(  )
	
end




-- [抽象] 进度条打开
function M:LoaderOpen( )
	
end


-- [抽象] 进度条关闭
function M:LoaderClose( )
	
end


-- [抽象] 设置进度
function M:SetLoaderProgress( progress )
	
end