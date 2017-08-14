ServerPanel = class("ServerPanel", BasePanel)
local M = ServerPanel

-- 初始化
function M:Init( transform, window )
	self.super.Init(self, transform, window)

	self:AddButtonClickEvent("Content/Button-EnterServer", self.OnClickEnterButton, self)

end

-- 销毁事件
function M:OnDestory(  )
	self:RemoveButtonClickEvent("Content/Button-EnterServer", self.OnClickEnterButton, self)
end


-- 点击进入服务器按钮
function M:OnClickEnterButton(  )
	self.window:OpenLoginPanel()
end
