RegisterPanel = class("RegisterPanel", BasePanel)
local M = RegisterPanel


-- 初始化
function M:Init( transform, window )
	self.super.Init(self, transform, window)

	self:AddButtonClickEvent("Content/Button-CreateAccount", self.OnClickCreateAccountButton, self)
	self:AddButtonClickEvent("Button-Back", self.OnClickBackButton, self)

end

-- 销毁事件
function M:OnDestory(  )
	self:RemoveButtonClickEvent("Content/Button-CreateAccount", self.OnClickCreateAccountButton, self)
	self:RemoveButtonClickEvent("Button-Back", self.OnClickBackButton, self)
end


-- 点击创建按钮
function M:OnClickCreateAccountButton(  )
	self.window:OpenLoginPanel()
end

-- 点击取消按钮
function M:OnClickBackButton(  )
	self.window:OpenLoginPanel()
end