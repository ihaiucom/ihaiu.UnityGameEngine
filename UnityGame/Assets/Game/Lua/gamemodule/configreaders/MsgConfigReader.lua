MsgConfigReader = class("MsgConfigReader", ConfigReaderCsv)

local M = MsgConfigReader

setmetatable(M, {__index = _G})
setfenv(1, M)

attribute 	= ConfigAttribute.New("Config/Client/Msg", false)
Struct 		= MsgConfig
