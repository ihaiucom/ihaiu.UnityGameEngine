LoginWindow = class("LoginWindow", AbstractView)
local M = LoginWindow

M.Tab = {Login = 1, Register = 2, Server = 3}

M.panels 			= nil
M.loginPanel 		= nil
M.registerPanel 	= nil
M.serverPanel 		= nil
M.currentPanel		= nil

-- 初始化
function M:OnStart( ... )
	local loginPanelView 		= self:FindChild("LoginPanel")
	local registerPanelView 	= self:FindChild("RegisterPanel")
	local serverPanelView		 = self:FindChild("ServerPanel")

	self.loginPanel 	= LoginPanel.New()
	self.registerPanel 	= RegisterPanel.New()
	self.serverPanel 	= ServerPanel.New()


	self.loginPanel:Init		(loginPanelView, self)
	self.registerPanel:Init		(registerPanelView, self)
	self.serverPanel:Init		(serverPanelView, self)

	self.currentPanel 	= self.loginPanel
	self.panels 		= {self.loginPanel, self.registerPanel, self.serverPanel}


end


-- [实现] 打开视图回调
function M:OnOpen(tabIndex )
	print("打开视图回调",tabIndex )
	tabIndex = tabIndex or LoginWindow.Tab.Login
	self:SetTab(tabIndex)
end


-- 切换面板
function M:SetTab( index )
	local panel = self.panels[index]

	if self.currentPanel == panel then
		-- return
	end

	if self.currentPanel then
		self.currentPanel:Hide()
	end

	for i, item in ipairs(self.panels) do
		item:Hide()
	end

	self.currentPanel = panel
	self.currentPanel:Show()
end


-- 打开登录面板
function M:OpenLoginPanel(  )
	self:SetTab(LoginWindow.Tab.Login)
end


-- 打开注册面板
function M:OpenRegisterPanel(  )
	self:SetTab(LoginWindow.Tab.Register)
end



-- 打开服务器列表面板
function M:OpenServerPanel(  )
	self:SetTab(LoginWindow.Tab.Server)
end

