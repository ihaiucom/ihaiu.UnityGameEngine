BasePanel = class("BasePanel", 
{
	gameObject 		= nil,
	transform		= nil,
	rectTransform	= nil,
	window 			= nil,
	moduleCtl 		= nil,
	moduleView 		= nil,
})

local M = BasePanel

function M:SetGameObject( gameObject )
	self.gameObject = gameObject
end


function M:SetTransform( transform )
	self.transform 			= transform
	self.rectTransform 		= transform
	-- self.rectTransform 	=  CS.UnityEngine.RectTransform.__CastFrom(transform)
end


-- 初始化
function M:Init( transform, window )
	self:SetTransform(transform)
	self:SetGameObject(transform.gameObject)
	self.window = window
end




-- 显示
function M:Show(  )
	if self.gameObject then
		self.gameObject:SetActive(true)
	end
end


-- 隐藏
function M:Hide(  )
	if self.gameObject then
		self.gameObject:SetActive(false)
	end
end

-- 销毁事件
function M:OnDestory( ... )
	
end


-- ==============================================
-- 设置Layout
-- UILayerId 			= CS.Games.UILayer.Layer
-- layout               MenuLayout.ScreenSize 屏幕大小, MenuLayout.PositionZero 居中
-- ----------------------------------------------
function M:SetLayout( layer, layout )

	-- UILayerId.__CastFrom(layer)
	self.transform:SetParent(   Game.uiLayer:GetLayer( layer ), false   )
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



-- ==============================================
-- 扩展方法，方便调用
-- ----------------------------------------------

-- 查找子节点
function M:FindChild( childName )
	return self.transform:FindChild(childName)
end

-- 获取节点
function M:GetNode( childPath )
	local node = self.transform

	if string.IsNullOrEmpty(childPath) == false then
		node = self:FindChild(childPath)
	end

	if node == nil then
		error(string.format("GetNode 没有找到节点 %s, childPath=%s", self.__cname, childPath))
	end

	return node
end



-- 获取Image
function M:GetImage( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("Image")
end

-- 获取InputField
function M:GetInputField( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("InputField")
end


-- 获取Text
function M:GetText( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("Text")
end


-- 获取Slider
function M:GetSolider( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("Slider")
end

-- 获取Toggle
function M:GetToggle( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("Toggle")
end



-- 获取CanvasGroup
function M:GetCanvasGroup( childPath )
	local node = self:GetNode(childPath)
	return node:GetComponent("CanvasGroup")
end




-- [private] 事件字典
M.eventDict = {}

-- 清除所有事件
function M:ClearAllEvent( ... )
	for k, event in pairs() do
		event:RemoveAll()
	end
	self.eventDict = {}
end



-- 添加按钮点击事件
function M:AddButtonClickEvent( childPath, fun, tab, tran, argsTab )
	if tab == nil then
		tab = self
	end

	if tran == nil then
		tran = self.transform
	end

	local node = tran

	if string.IsNullOrEmpty(childPath) == false then
		node = tran:FindChild(childPath)
	end

	local event = self.eventDict[node]
	if event == nil then
		event = Event.New("ButtonClickEvent")
		event.onClick = function ( ... )
			event:Call()
		end
		node:GetComponent("Button").onClick:AddListener(event.onClick)
	end

	event:Add(tab, fun, argsTab)
end

-- 移除按钮点击事件
function M:RemoveButtonClickEvent( childPath, fun, tab, tran )
	if tab == nil then
		tab = self
	end

	if tran == nil then
		tran = self.transform
	end

	local node = tran

	if string.IsNullOrEmpty(childPath) == false then
		node = tran:FindChild(childPath)
	end

	local event = self.eventDict[node]
	if event then
		event:Remove(tab, fun)

		if event:GetCount() == 0 then
			self.eventDict[node] = nil
		end
	end
end
