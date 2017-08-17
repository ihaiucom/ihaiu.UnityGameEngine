LoginPanel = class("LoginWindow", BasePanel)
local M = LoginPanel



-- 初始化
function M:Init( transform, window )
	self.super.Init(self, transform, window)

	self.usernameInputField = self:GetInputField("Content/Username/InputField")
	self.passwordInputField = self:GetInputField("Content/Password/InputField")

	self:AddButtonClickEvent("Content/Button-SignUp", self.OnClickRegisterButton, self)
	self:AddButtonClickEvent("Content/Button-SignIn", self.OnClickLoginButton, self)

	self:ReadLocalData()

end


-- 显示
function M:Show(  )
	if self.gameObject then
		self.gameObject:SetActive(true)
	end
	
	self:ReadLocalData()
end

-- 销毁事件
function M:OnDestory(  )
	self:RemoveButtonClickEvent("Content/Button-SignUp", self.OnClickRegisterButton, self)
	self:RemoveButtonClickEvent("Content/Button-SignIn", self.OnClickLoginButton, self)
end

-- 读取本地缓存的玩家名和密码
function M:ReadLocalData( ... )
	self:SetUsername( PlayerPrefs.GetUsername() )
	self:SetPassword( PlayerPrefs.GetPassword() )
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




-- 点击登录按钮
function M:OnClickLoginButton(  )
	Game.csShinezoneNet.loginCtl:Login ( self:GetUsername(), self:GetPassword() )
	self:SaveLocalData()
end

-- 点击注册按钮
function M:OnClickRegisterButton(  )
	self.window:OpenRegisterPanel()
end

