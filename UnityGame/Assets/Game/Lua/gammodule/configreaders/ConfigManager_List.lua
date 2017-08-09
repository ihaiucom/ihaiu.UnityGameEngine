require "gamemodule/configreaders/MsgConfig"
require "gamemodule/configreaders/MenuConfig"

require "gamemodule/configreaders/MsgConfigReader"
require "gamemodule/configreaders/MenuConfigReader"



setfenv(1, ConfigManager)

msg 	= MsgConfigReader.New()
menu 	= MenuConfigReader.New()

table.insert(list, msg)
table.insert(list, menu)