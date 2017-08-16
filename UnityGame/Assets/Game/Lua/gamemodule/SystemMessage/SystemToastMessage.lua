-- 浮动消息管理器
SystemToastMessage = class("SystemToastMessage", 
{
	-- 所有的
	list = {},

	-- 可以使用的池
	pools = {},

	-- 正在工作中的
	works = {},
})

local M = SystemToastMessage
M.systemMessage = nil



-- 构造函数
function M:ctor( systemMessage )
	self.systemMessage = systemMessage
end


-- 播放消息
function M:Play( txt )
	local item = nil
	if #self.pools > 0 then
		item = self.pools[1]
		table.remove( self.pools, 1 )
	else
		item = SystemToastMessageView.New(self, self.systemMessage.toastPrefab)
		table.insert( self.list, item )
	end

	table.insert( self.works, item )
	item:SetText(txt)
	item:Begin()
end

-- 播放结束 
-- SystemToastMessageView item
function M:OnEnd( item )
	table.insert( self.pools, item )
	table.removeItem( self.works, item )
end