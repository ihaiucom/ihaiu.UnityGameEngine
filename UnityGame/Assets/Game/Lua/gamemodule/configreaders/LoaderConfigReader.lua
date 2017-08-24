LoaderConfigReader = class("LoaderConfigReader", ConfigReaderCsv)

local M = LoaderConfigReader

setmetatable(M, {__index = _G})
setfenv(1, M)

attribute 	= ConfigCsvAttribute.New("Config/Client/Loader", false)
Struct 		= LoaderConfig
