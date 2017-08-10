MenuCtl = class("MenuCtl",{
	-- 模块ID
	menuId = 0,

	-- MenuConfig
	config = nil,

	-- 模块接口,继承自AbstractModule
	moduleCtl = nil,

	-- 缓存时间
	cacheTime = 0,
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

-- [抽象]
function M:OnDestory( )
	
end



-- 获取模块资源列表
function M:GetLoadAssets( )
	if self.moduleCtl then
		return moduleCtl:GetLoadAssets()
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