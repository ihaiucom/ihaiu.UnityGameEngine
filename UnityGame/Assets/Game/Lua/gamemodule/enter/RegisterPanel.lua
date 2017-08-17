RegisterPanel = class("RegisterPanel", BasePanel)
local M = RegisterPanel


-- 初始化
function M:Init( transform, window )
	self.super.Init(self, transform, window)


	self.usernameInputField 		= self:GetInputField("Content/Username/InputField")
	self.passwordInputField 		= self:GetInputField("Content/Password/InputField")
	self.verifyPasswordInputField 	= self:GetInputField("Content/VerifyPassword/InputField")


	self:AddButtonClickEvent("Content/Button-CreateAccount", self.OnClickCreateAccountButton, self)
	self:AddButtonClickEvent("Button-Back", self.OnClickBackButton, self)

end

-- 销毁事件
function M:OnDestory(  )
	self:RemoveButtonClickEvent("Content/Button-CreateAccount", self.OnClickCreateAccountButton, self)
	self:RemoveButtonClickEvent("Button-Back", self.OnClickBackButton, self)
end


-- 保存本地缓存的玩家名和密码
function M:SaveLocalData( ... )
	PlayerPrefs.SetUsername( self:GetUsername() )
	PlayerPrefs.SetPassword( self:GetPassword() )
end


-- [get/set] Username
function M:GetUsername(  )
	return self.usernameInputField.text
end

function M:SetUsername( username )
	self.usernameInputField.text = username
end


-- [get/set] Password
function M:GetPassword(  )
	return self.passwordInputField.text
end

function M:SetPassword( password )
	self.passwordInputField.text = password
end

function M:GetVerifyPassword(  )
	return self.passwordInputField.verifyPasswordInputField
end




-- 点击创建按钮
function M:OnClickCreateAccountButton(  )
	if self:GetUsername() ~= self:GetPassword() then
		Game.sysmsg:ToastText(Lang.LOGIN_VerifyPassword_Error)
		return
	end

	Game.csShinezoneNet.loginCtl:Register ( self:GetUsername(), self:GetPassword() )

	self:SaveLocalData()
end

-- 点击取消按钮
function M:OnClickBackButton(  )
	self.window:OpenLoginPanel()
end