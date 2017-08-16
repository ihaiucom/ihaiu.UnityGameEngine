SystemMessage = class("SystemMessage", {

	-- 资源路径
	ASSET_PATH_TOAST = "PrefabUI/GameSystem/SystemToastMessage",
	ASSET_PATH_STATE = "PrefabUI/GameSystem/SystemStateMessage",
	ASSET_PATH_ALERT = "PrefabUI/GameSystem/SystemAlertMessage",

	-- 资源预设
	toastPrefab = nil,
	statePrefab = nil,
	alertPrefab = nil,

	-- 浮动消息管理器
	toastMessage = nil,

	-- 状态消息
	stateMessageView = nil,

})

local M = SystemMessage

-- 初始化
function M:Install(  )
	self:LoadPrefab()
	self.toastMessage 		= SystemToastMessage.New(self)
	self.stateMessageView 	= SystemStateMessageView.New(self.statePrefab)

end

-- 加载资源预设
function M:LoadPrefab( )
	-- 因为这可能和gameversion公用所以这里这样调用。默认要调Game.asset
	self.toastPrefab = AssetManager:LoadAsset(self.ASSET_PATH_TOAST)
	self.statePrefab = AssetManager:LoadAsset(self.ASSET_PATH_STATE)
	self.alertPrefab = AssetManager:LoadAsset(self.ASSET_PATH_ALERT)
end

-- 获取配置消息内容
function M:GetMsgText( msgId )
	local msgConfig = Game.config.msg:GetConfig(msgId)
	if msgConfig then
		return msgConfig.content
	else
		return string.format("没找到消息配置 msgId=%d", msgId)
	end
end


-- 浮动消息
function M:ToastText( txt )
	self.toastMessage:Play( txt )
end

function M:ToastMsg( msgId )
	self:ToastText(self:GetMsgText(msgId))
end

-- 状态消息
function M:StateShowText( txt )
	self.stateMessageView:SetShow(txt)
end

function M:StateShowMsg( msgId )
	self:StateShowMsg(self:GetMsgText(msgId))
end


function M:StateHide(  )
	self.stateMessageView:Hide()
end


-- 对话框消息,一个按钮
function M:AlrtText(txt, callbackFun, callbackTab, buttonTxt)

end

function M:AlrtMsg(msgId, callbackFun, callbackTab, buttonTxt)

end


-- 对话框消息,两个按钮
function M:ConfirmText(txt, callbackFun, callbackTab, yesTxt, noTxt )
	
end

function M:ConfirmMsg(msgId, callbackFun, callbackTab, yesTxt, noTxt )
	
end

