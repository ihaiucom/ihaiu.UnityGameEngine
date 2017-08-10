LoaderPanel = class("LoaderPanel", BaseView)

local M = LoaderPanel

-- 设置布局
function M:SetLayout(  )
	local transform = self.transform
	transform:SetParent(Game.uiLayer.loader, false)
	transform.localScale 		= CS.UnityEngine.Vector3.one
	transform.anchoredPosition 	= CS.UnityEngine.Vector2.zero
	transform:SetAsLastSibling()
end



-- 设置进度
function M:SetProgerss(progress )
	
end