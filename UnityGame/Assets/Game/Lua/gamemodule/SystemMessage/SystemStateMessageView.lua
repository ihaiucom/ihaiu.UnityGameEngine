SystemStateMessageView = class("SystemStateMessageView", BasePanel)
local M = SystemStateMessageView


-- 	Text
M.textLabel 	= nil

-- 构造函数
function M:ctor(  prefab )
	
	self.gameObject 	= GameObject.Instantiate(prefab)
	self.transform 		= self.gameObject.transform

	self.super.Init(self, self.transform, nil)



	self.textLabel 		= self:GetText("Text")

	self:SetLayout(UILayerId.Layer_Msg, MenuLayout.ScreenSize)
	self:Hide()
end





-- 设置文本消息
function M:SetText( txt )
	self.textLabel.text = txt
end


-- 显示
function M:SetShow( txt )
	self:SetText(txt)
	self:Show()
end

