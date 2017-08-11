require "gamemodule/configreaders/MsgConfig"
require "gamemodule/configreaders/MenuConfig"
require "gamemodule/configreaders/LoaderConfig"

require "gamemodule/configreaders/MsgConfigReader"
require "gamemodule/configreaders/MenuConfigReader"
require "gamemodule/configreaders/LoaderConfigReader"



setfenv(1, ConfigManager)

msg 	= MsgConfigReader.New()
menu 	= MenuConfigReader.New()
loader 	= LoaderConfigReader.New()

table.insert(list, msg)
table.insert(list, menu)
table.insert(list, loader)