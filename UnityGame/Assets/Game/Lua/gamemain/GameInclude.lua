-- =================================
-- gameframe
-- ---------------------------------

-- System
require "gameframe/system/define"
require "gameframe/system/class"
require "gameframe/system/typename"
require "gameframe/system/coroutine"
require "gameframe/system/StringUtil"
require "gameframe/system/NumberUtil"
require "gameframe/system/TableUtil"
require "gameframe/system/Event"

-- Unity
require "gameframe/unity/MainThreadManager"
require "gameframe/module/BaseView"

-- Asset
require "gameframe/asset/AssetManager"




-- Loader
require "gameframe/loader/LoaderId"
require "gameframe/loader/LoaderCtl"
require "gameframe/loader/LoaderPanel"
require "gameframe/loader/LoaderManager"

-- Config
require "gameframe/config/ConfigSetting"
require "gameframe/config/ConfigType"
require "gameframe/config/ConfigCsvAttribute"
require "gameframe/config/IParseCsv"
require "gameframe/config/IConfigReader"
require "gameframe/config/AbstractParseCsv"
require "gameframe/config/ConfigReaderLua"
require "gameframe/config/ConfigReaderCsv"
require "gameframe/config/ConfigReaderJson"



-- Menu
require "gameframe/menu/MenuId"
require "gameframe/menu/MenuType"
require "gameframe/menu/MenuLayout"
require "gameframe/menu/MenuCloseOtherType"
require "gameframe/menu/MenuCtlStateType"
require "gameframe/menu/MenuCtlPreloadStateType"
require "gameframe/menu/MenuCtl"
require "gameframe/menu/MenuCtlForPanel"
require "gameframe/menu/MenuCtlForScene"
require "gameframe/menu/MenuManager"

-- Module
require "gameframe/module/AbstractModule"
require "gameframe/module/AbstractView"
require "gameframe/module/ModuleManager"







-- =================================
-- gamemain
-- ---------------------------------

-- Game
require "gamemain/GameDefine"
require "gamemain/core/Lang"
require "gamemain/Game"


-- =================================
-- gamemodule
-- ---------------------------------

-- Config
require "gamemodule/configreaders/ConfigManager"

-- Module
require "gamemodule/modules/LoginModule"
require "gamemodule/modules/HomeModule"


-- enter
require "gamemodule/enter/LoginPanel"
require "gamemodule/enter/RegisterPanel"
require "gamemodule/enter/ServerPanel"
require "gamemodule/enter/LoginWindow"

