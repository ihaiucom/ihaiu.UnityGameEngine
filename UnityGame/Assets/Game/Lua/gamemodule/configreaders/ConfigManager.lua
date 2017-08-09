ConfigManager = class("ConfigManager", {
	list = {}
})


local M = ConfigManager
setmetatable(M, {__index = _G})
setfenv(1, M)


-- 加载配置
function Load(  )
	local count = #list
	for i = 1, count do
		list[i]:Load()
	end
end

-- 重新加载配置
function Reload(  )
	Load()
end

-- 初始化
function Install( ... )
	require "gamemodule/configreaders/ConfigManager_List"

end
