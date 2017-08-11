AbstractView = class("AbstractView", BaseView)
AbstractView.module = nil -- 继承自AbstractModule


local M = AbstractView

-- 设置Layout
function AbstractView:SetLayout( layer, layout )

print("设置Layout", layer, layout)
print(UILayerId.__CastFrom(layer))
print(Game.uiLayer:GetLayer( UILayerId.__CastFrom(layer) ))

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




