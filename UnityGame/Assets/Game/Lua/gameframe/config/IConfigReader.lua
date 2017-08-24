require "gameframe/config/ConfigType"

IConfigRender = class("IConfigRender", {configType = ConfigType.LUA}) 

local M = IConfigRender

-- 加载
function M:Load( )
	
end

-- 重新加载
function M:Reload( )
	
end


-- 根据ID获取配置
function M:GetConfig(id)

end
