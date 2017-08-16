SystemToastMessageView = class("SystemToastMessageView", BasePanel)
local M = SystemToastMessageView

-- 浮动消息管理器 SystemToastMessage
M.toastManager 	= nil

-- 	Text
M.textLabel 	= nil
M.canvasGroup   = nil

-- 位置配置，起始
M.configBeginY  = -30

-- 位置配置，停留
M.configWaitY  	= 30

-- 位置配置，消失
M.configEndY  	= 150

-- 构造函数
function M:ctor( toastManager, prefab )
	
	self.toastManager 	= toastManager
	self.gameObject 	= GameObject.Instantiate(prefab)
	self.transform 		= self.gameObject.transform

	self.super.Init(self, self.transform, nil)



	self.textLabel 		= self:GetText("Text")
	self.canvasGroup 	= self:GetCanvasGroup()

	self:SetLayout(UILayerId.Layer_Msg, MenuLayout.PositionZero)
	self:Hide()
end


-- 设置文本消息
function M:SetText( txt )
	self.textLabel.text = txt
end

-- 开始显示播放
function M:Begin(  )
	self.transform:DOKill()
	self.canvasGroup:DOKill()

	-- self.canvasGroup.alpha 				= 0
	self.rectTransform.anchoredPosition 	= Vector2(0, self.configBeginY)

	self:Show()
	self.rectTransform:SetAsLastSibling()

	self.canvasGroup:DOFade(1, 0.5)
	self.canvasGroup:DOFade(0, 1.5):SetDelay(2)

	self.rectTransform:DOAnchorPosY(self.configWaitY, 0.8, false)
	self.rectTransform:DOAnchorPosY(self.configEndY, 1.5, false):SetDelay(2):OnComplete(function(  )
		self:OnEnd()
	end)

end

-- 播放结束
function M:OnEnd(  )
	self:Hide()
	self.toastManager:OnEnd(self)
end

