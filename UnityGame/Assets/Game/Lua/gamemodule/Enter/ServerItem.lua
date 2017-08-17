ServerItem = class("ServerItem", BasePanel)
local M = ServerItem
-- 服务器列表面板 ServerPanel
M.serverPanel 		= nil
-- 数据 ServerItemData
M.serverItemData 	= nil

-- 初始化
function M:Init( prefab, serverPanel )
	self.serverPanel = serverPanel
	self.gameObject = GameObject.Instantiate(prefab)
	self.transform 	= self.gameObject.transform
	self.transform:SetParent(serverPanel.listContainer, false)

	self.super.Init(self, self.transform, nil)

	self.nameLabel 		=  self:GetText("NameLabel")
	self.ipLabel 		=  self:GetText("IPLabel")
	self.stateLabel 	=  self:GetText("StateLabel")

	self.toggle			= self:GetToggle()
	self.toggle.isOn	= false

	self.x = self.rectTransform.anchoredPosition.x;
	self.toggle.onValueChanged:AddListener(function ( ... ) self:OnToggleChange() end)


end

-- 设置数据 ServerItemData
function M:SetData( serverItemData )
	self.serverItemData 	= serverItemData
	self.nameLabel.text 	= serverItemData.name
	self.ipLabel.text 		= serverItemData.ip .. ":" .. serverItemData.port
	self.stateLabel.text 	= serverItemData:GetStateText()
end

-- 设置位置Y
function M:SetY( y )
	self.rectTransform.anchoredPosition = Vector2(self.x, y)
end

-- 设置选中
function M:SetSelected( )
	self.toggle.isOn = true
end

-- 是否选中
function M:IsSelected( )
	return self.toggle.isOn
end


-- 是否选中
function M:OnToggleChange( )
	if self:IsSelected() then
		self.serverPanel:SetSelect(self)
	end
end


