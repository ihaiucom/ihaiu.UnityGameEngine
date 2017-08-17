-- 渠道管理器
ChannelManager = class("ChannelManager", {
	-- 当前渠道ID
	id 		= 0,

	-- 当前配置
	config 	= nil,

	-- 当前渠道控制器
	ctl 	= nil,
})


local M = ChannelManager


-- 初始化
function M:Install( )
	print(Setting.version.centerName)
	self.config = ChannelConfigs:FindConfig( Setting.version.centerName )
	self.id 	= self.config.id
	self.ctl 	= self:CreateCtl()
	self.ctl:Init()
end

-- 创建渠道控制器
function M:CreateCtl( )


	-- 配置控制器
	local dict = {}
	dict[ChannelId.Test] 		= ChannelCtl
	dict[ChannelId.Official] 	= ChannelCtl
	dict[ChannelId.Shinezone] 	= ChannelCtl



	if dict[self.channelId] then
		-- 创建指定控制器
		return dict[self.channelId].New(self.config, self)
	else
		-- 创建默认控制器
		return  ChannelCtl.New(self.config, self)
	end
	
end

-- 登录
function M:Login( )
	self.ctl:Login()
end

-- 退出
function M:Logout( )
	self.ctl:Logout()
end


-- 获取账号信息
function M:GetAccountInfo( )
	return self.ctl:GetAccountInfo()
end

-- 进入游戏
function M:EnterGame( id, ip, port )
	self.ctl:EnterGame( id, ip, port )
	
end


-- ------------------------------------------

-- 登录成功
function M:OnLoginSuccess( )

	print("===========ChannelManager.OnLoginSuccess");
	Game.menu:Open(MenuId.Login, LoginWindow.Tab.Server)
end
