ChannelCtl = class("ChannelCtl", {
	-- 渠道ID
	id 		= 0,

	-- 渠道配置
	config 	= nil,

	-- 渠道管理器
	channelManager = nil,
})

local M = ChannelCtl

function M:ctor(config, channelManager)
	self.id 				= config.id
	self.config 			= config
	self.channelManager 	= channelManager
end



-- 登录
function M:Login( )
	Game.menu:Open(MenuId.Login)
end

-- 退出
function M:Logout( )
end

-- 注册
function M:Register(  )
end

-- 获取账号信息
function M:GetAccountInfo( )
end

-- 进入游戏
function M:EnterGame(  )
end


-- ------------------------------------------


-- 登录成功
function M.OnLoginSuccess( )
	
end

-- 登录失败
function M.OnLoginFail( )
	
end
