BaseView = class("BaseView", 
{
	instance 	= nil,
	gameObject 	= nil,
	transform	= nil,
	csView 		= nil,
})

-- 设置实例对象为自己
function BaseView:SetInstall( )
	self.instance = self
end

-- 绑定GameObject
function BaseView:BindGameObject(gameObject)
	self.gameObject = gameObject
	self.transform 	= gameObject.transform
	self:SetInstall()
	cs.LuaView.AddView(self, gameObject)
end


-- ==============================================
-- C#调用
-- ----------------------------------------------
function BaseView:CsStart( gameObject, csView  )
	self.gameObject = gameObject
	self.transform 	= gameObject.transform
	self.csView 	= csView
	self:OnStart()
end



function BaseView:CsUpdate( )
	self:OnUpdate()
end


function BaseView:CsGUI( )
	self:OnGUI()
end



-- C#在 Start前调用的OnEnable是不会调这个方法的
function BaseView:CsEnable( )
	self:OnEnable()
end


function BaseView:CsDisable( )
	self:OnDisable()
end


function BaseView:CsDestroy( )
	self:OnDestroy()

	self.gameObject = nil
	self.transform = nil
	self.csView		= nil
end




-- ==============================================
-- Lua 生命周期方法
-- ----------------------------------------------

function BaseView:OnStart(  )
end


function BaseView:OnUpdate(  )

end

function BaseView:OnGUI(  )
	
end



function BaseView:OnEnable(  )
	
end



function BaseView:OnDisable(  )
	
end


function BaseView:OnDestroy(  )
end



-- ==============================================
-- Lua 操作GameObject方法
-- ----------------------------------------------

-- 显示
function BaseView:Show(  )
	if self.gameObject then
		self.gameObject:SetActive(true)
	end
end


-- 隐藏
function BaseView:Hide(  )
	if self.gameObject then
		self.gameObject:SetActive(false)
	end
end



-- 销毁
function BaseView:Destroy(  )
	if self.gameObject then
		GameObject.Destroy(self.gameObject)
	end
end