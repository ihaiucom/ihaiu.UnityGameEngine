MsgConfigReader = class("MsgConfigReader", ConfigReaderCsv)

local M = MsgConfigReader

setmetatable(M, {__index = _G})
setfenv(1, M)

attribute 	= ConfigCsvAttribute.New("Config/Client/Msg", false)
Struct 		= MsgConfig
