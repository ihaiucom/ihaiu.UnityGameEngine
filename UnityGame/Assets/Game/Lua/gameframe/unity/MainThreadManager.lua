MainThreadManager = class("MainThreadManager", {
	-- 闭包监听C#事件
	call_Update 	= nil,
	call_Destory 	= nil,

	-- 监听列表-每帧回调
	updateEvent = nil,

})

local M = MainThreadManager

-- 初始化
function M:Install( )
	self.call_Update = function(  )
		self:Uninstall()
	end


	self.call_Destory = function(  )
		self:OnUpdate()
	end

	self.updateEvent = Event.New("UpdateEvent")

	Game.csMainThread:unityUpdate	("+", self.call_Update)
	Game.csMainThread:unityDestory	("+", self.call_Destory)

end

-- 卸载
function M:Uninstall(  )

	if self.updateEvent then
		self.updateEvent:RemoveAll()
		self.updateEvent = nil
	end

	Game.csMainThread:unityUpdate("-", self.call_Update)
	Game.csMainThread:unityDestory("-", self.call_Destory)
end


-- 更新
function M:OnUpdate(  )
	self.updateEvent:Call()
end


-- 添加Update监听
function M:AddUpdateListen(tab, fun)
	self.updateEvent:Add(tab, fun)
end

-- 移除Update监听
function M:RemoveUpdateListen(tab, fun)
	self.updateEvent:Remove(tab, fun)
end


-- 移除Update监听
function M:RemoveAllUpdateListen()
	if self.updateEvent then
		self.updateEvent:RemoveAll()
	end
end