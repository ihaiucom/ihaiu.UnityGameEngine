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

-- ------------------------------------------

-- SystemMessage error
function M.ErrorMsg( id, error )
	Game.sysmsg:ToastText(id .. " " .. error)
end


-- SystemMessage state Show
function M.StateShow( stateId, txt )
	Game.sysmsg:StateShowText(txt)
end

-- SystemMessage state
function M.StateHide( )
	Game.sysmsg:StateHide()
end

-- 打开面板
function M.OnOpenPanel( panelId )
	if panelId ~= LoginWindow.Tab.Server then
		Game.menu:Open(MenuId.Login, panelId)
	end	
end

-- 需要重新登录
function M.Relogin(  )
	Game.menu:Open(MenuId.Login)
end



-- ------------------------------------------


-- 初始化
function M:Init( )
	Game.csShinezoneNet:Init(self.config.gate, self.config.isTcp)

	Game.csShinezoneNet.netCtl:errorEvent		('+', self.ErrorMsg)
	Game.csShinezoneNet.netCtl:stateShowEvent	('+', self.StateShow)
	Game.csShinezoneNet.netCtl:stateHideEvent	('+', self.StateHide)
	
	Game.csShinezoneNet.loginCtl:errorEvent		('+', self.ErrorMsg)
	Game.csShinezoneNet.loginCtl:stateShowEvent	('+', self.StateShow)
	Game.csShinezoneNet.loginCtl:stateHideEvent	('+', self.StateHide)
	Game.csShinezoneNet.loginCtl:openPanelEvent	('+', self.OnOpenPanel)
	Game.csShinezoneNet.loginCtl:reloginEvent	('+', self.Relogin)



	Game.csShinezoneNet.loginCtl:loginSuccessEvent	('+', function ( json ) 		self:OnLoginSuccess(json)  		end)
	Game.csShinezoneNet.loginCtl:loginFailEvent		('+', function ( err ) 			self:OnLoginFail( err )  	end)

	 
	self:OnInit(true)
end


-- 登录
function M:Login( )
	Game.menu:Open(MenuId.Login, LoginWindow.Tab.Login)
end

-- 退出
function M:Logout( )

end


-- 获取账号信息
function M:GetAccountInfo( )

end


-- 进入游戏
function M:EnterGame( id, ip, port )
	print( string.format("进入游戏 ChannelCtl.EnterGame id=%s, ip=%s, port=%s",id, ip, port) )
	Game.csShinezoneNet.loginCtl:EnterGame(id, ip, port)
end


-- ------------------------------------------

-- 初始化事件
function M:OnInit(isScussess, err )
	if isScussess then
		self:Login()
	end
end


-- 登录成功
function M:OnLoginSuccess( json )
	print("============登录成功 ChannelCtl OnLoginSuccess")

	ServerListData.ParseShinezoneJson(json)
	self.channelManager:OnLoginSuccess()
end

-- 登录失败
function M:OnLoginFail( err )
	print("============登录失败 ChannelCtl OnLoginFail" , err)
end
