-- ======================================
-- 该文件只会第一次生成，存在就不再生成。你可以在这扩展功能
-- MsgConfig 读取器
-- 默认Menu: Game/Tool/xlsx->lua
-- http://blog.ihaiu.com
-- --------------------------------------			

MsgConfigReader = class("MsgConfigReader", ConfigReaderLua )
local M = MsgConfigReader 



-- 结构体
M.StructClass = MsgConfig

-- 属性(配置文件, 是否有属性表头)
M.attribute = ConfigAttribute.New( Msg, false ) 


-- 导入数据
require "gen/configreaders/MsgConfigReader_Data"
