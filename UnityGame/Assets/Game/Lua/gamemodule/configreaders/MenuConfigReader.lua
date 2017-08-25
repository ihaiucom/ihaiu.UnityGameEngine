MenuConfigReader = class("MenuConfigReader", ConfigReaderCsv)

local M = MenuConfigReader

setmetatable(M, {__index = _G})
setfenv(1, M)

attribute 	= ConfigAttribute.New("Config/Client/Menu", true, false)
Struct 		= MenuConfig
