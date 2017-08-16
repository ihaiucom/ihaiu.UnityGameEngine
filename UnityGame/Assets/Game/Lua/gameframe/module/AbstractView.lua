AbstractView = class("AbstractView", BaseView)

-- 继承自AbstractModule
AbstractView.module 	= nil 	

-- 打开参数
AbstractView.openargs	= {} 	
-- Menu 调的 OnOpen
AbstractView.isMenuCallOpened = false


local M = AbstractView

-- 设置Layout
function M:SetLayout( layer, layout )

	self.transform:SetParent(   Game.uiLayer:GetLayer( UILayerId.__CastFrom(layer) ), false   )
	self.transform.localScale = CS.UnityEngine.Vector3.one

	-- 屏幕大小
	if layer == MenuLayout.ScreenSize then
		self.transform.offsetMin = CS.UnityEngine.Vector2.zero
		self.transform.offsetMax = CS.UnityEngine.Vector2.zero

    -- 位置为0
	else
		self.transform.anchoredPosition = CS.UnityEngine.Vector2.zero

	end	
end

-- C#调的 Start
function M:CsStart( gameObject, csView  )
	BaseView.CsStart(self, gameObject, csView)
	self.isCsharpStart = true
	self:CheckOpen()
end

-- Menu 调的 OnOpen
function M:MenuCallOnOpen( ... )

	
	self.openargs = {...}
	self.isMenuCallOpened = true
	self:CheckOpen()
end

-- 检测打开视图回调
function M:CheckOpen( )
	if self.isCsharpStart and self.isMenuCallOpened  then
		self:OnOpen(unpack(self.openargs))
	end
end

-- [抽象] 打开视图回调
function M:OnOpen( ... )
	
end




