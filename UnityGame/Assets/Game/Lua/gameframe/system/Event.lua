Event = class("Event", {
	-- 事件名称
	eventName="Event",
	-- 监听列表
	list = {},
})

EventItem = class("EventItem", {tab=nil, fun=nil})

local M = Event

function M:ctor( eventName )
	self.eventName = eventName
	self.list = {}
end

-- 获取有多少个监听
function M:GetCount( ... )
	return #self.list
end

-- 查找
function M:Find(tab, fun )
	for i, item in ipairs(self.list) do
		if item.tab == tab and item.fun == fun then
			return i, item
		end
	end

	return -1, nil
end

-- 是否存在
function M:Concat(tab, fun )
	local i, item = self:Find(tab, fun)
	return i > 0
end



-- 添加监听
function M:Add(tab, fun )
	if self:Concat(tab, fun) then
		return
	end

	table.insert(self.list, {tab = tab, fun = fun})
end

-- 移除监听
function M:Remove( tab, fun )
	local i, item = self:Find(tab, fun)
	if i > 0 then
		table.remove(self.list, i)
	end
end

-- 移除所有监听
function M:RemoveAll(  )
	self.list = {}
end


-- 调
function M:Call( ... )
	for i, item in ipairs(self.list) do
		item.fun(item.tab, ...)
	end
end