SystemMessage = class("SystemMessage", {

	-- 资源路径
	ASSET_PATH_TOAST = "PrefabUI/GameSystem/SystemToastMessage",
	ASSET_PATH_STATE = "PrefabUI/GameSystem/SystemStateMessage",
	ASSET_PATH_ALERT = "PrefabUI/GameSystem/SystemAlertMessage",

	-- 资源预设
	toastPrefab = nil,
	statePrefab = nil,
	alertPrefab = nil,

})

local M = SystemMessage

-- 初始化
function M:Init(  )
	
end

-- 加载资源预设
function M:LoadPrefab( )
	-- 因为这可能和gameversion公用所以这里这样调用。默认要调Game.asset
	self.toastPrefab = AssetManager:LoadAsset(self.ASSET_PATH_TOAST)
	self.statePrefab = AssetManager:LoadAsset(self.ASSET_PATH_STATE)
	self.alertPrefab = AssetManager:LoadAsset(self.ASSET_PATH_ALERT)
end


-- 浮动消息
function M:ToastText( txt )
	
end

function M:ToastMsg( msgId )
	
end

-- 状态消息
function M:StateShowText( txt )
	
end

function M:StateShowMsg( msgId )
	
end


function M:StateHide( txt )
	
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

