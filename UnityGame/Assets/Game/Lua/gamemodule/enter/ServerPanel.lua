ServerPanel = class("ServerPanel", BasePanel)
local M = ServerPanel
-- 列表List<ServerItem>
M.list = {}
-- 选中的 ServerItem
M.selectItem = nil


-- 初始化
function M:Init( transform, window )
	self.super.Init(self, transform, window)
	self.selectTextLabel 	= self:GetText("Content/Select/Text")
	self.listContainer 		= self:FindChild("Content/List/Group")
	self.itemPrefab			= self:FindChild("Content/List/Group/Toggle").gameObject
	self.itemPrefab:SetActive(false)

	self:AddButtonClickEvent("Content/Button-EnterServer", self.OnClickEnterButton, self)

end

-- 销毁事件
function M:OnDestory(  )
	self:RemoveButtonClickEvent("Content/Button-EnterServer", self.OnClickEnterButton, self)
end


-- 显示
function M:Show(  )
	if self.gameObject then
		self.gameObject:SetActive(true)
	end
	
	self:SetData()
end

-- 设置数据
function M:SetData(  )
	self:SetList()
end

-- 设置列表
function M:SetList( )
	local dataList = ServerListData.list;

	local y0 		= -20
	local hegiht 	= 80
	local gap 		= 10
	local y 		= y0
	for i, itemData in ipairs(dataList) do
		local item = ServerItem.New()
		item:Init(self.itemPrefab, self)
		item:SetData(itemData)
		item:SetY(y)
		item:Show()

		y = y0 + i * -1 * (hegiht + gap)

		table.insert(self.list, item)
	end

	self:ReadSelect()
end

-- 读取之前选中的服务器
function M:ReadSelect(  )
	local ip 	= PlayerPrefs.GetServerIP()
	local port 	= PlayerPrefs.GetServerPort()

	local selectIpItem = nil
	local selectItem = nil
	for i, item in ipairs(self.list) do
		if item.serverItemData.ip ==  ip then
			selectIpItem = item

			if item.serverItemData.port ==  port then
				selectItem = item
			end
		end
	end

	if selectItem then
		self:SetSelect(selectItem)
	elseif selectIpItem then
		self:SetSelect(selectIpItem)
	elseif #self.list > 0 then
		self:SetSelect(self.list[1])
	end
end

-- 保存选中的服务器
function M:SaveSelect( )
	if self.selectItem then
		PlayerPrefs.SetServerIP( self.selectItem.serverItemData.ip )
		PlayerPrefs.SetServerPort( self.selectItem.serverItemData.port )
	end
end

-- 获取选中的
function M:GetSelect( )
	for i, item in ipairs(self.list) do
		if item:IsSelected() then
			return item
		end
	end

	return self.selectItem
end

-- 设置选中的
function M:SetSelect( item )
	self.selectItem = item
	if self.selectItem:IsSelected() == false then
		self.selectItem:SetSelected()
	end

	if item then
		self.selectTextLabel.text = item.serverItemData.name
	end


end



-- 点击进入服务器按钮
function M:OnClickEnterButton(  )
	local item = self:GetSelect()
	if item then
		Game.channel:EnterGame(item.serverItemData.id, item.serverItemData.ip, item.serverItemData.port)
	else
		Game.sysmsg:StateShowText(Lang.SERVER_NoSelect)
	end
end
