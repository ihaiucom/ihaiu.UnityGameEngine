require "gamemodule/moduleprotos/UserProto"

-- 模块协议管理器(负责初始化的时候添加监听)
ModuleProtoManager = class("ModuleProtoManager", {
	list = {}
})


local M = ModuleProtoManager
M.user = UserProto.New()

function M:Install(  )
	self.user:AddS2C()
end