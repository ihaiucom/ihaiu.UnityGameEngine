ChannelConfig = class("ChannelConfig", {
	id 		= 0,
	name 	= "",
	cnname 	= "",
	gate	= "",
})

function ChannelConfig:ctor(id, name, cnname, gate )
	self.id 		= id
	self.name 		= name
	self.cnname 	= cnname
	self.gate		= gate or "http://106.14.8.84/game_operating_platform/index.php"
end


require "gameframe/channel/ChannelId"

-- 渠道配置列表
ChannelConfigs = class("ChannelConfigs", {
	dict = {},
	dictByName = {},
})

-- 添加配置
function ChannelConfigs:Add( config )
	self.dict[config.id] 			= config
	self.dictByName[config.name] 	= config
end

-- 获取指定渠道ID的配置
function ChannelConfigs:GetConfig( channelId )
	return self.dict[channelId]
end

-- 根据名称查找配置
function ChannelConfigs:FindConfig( channelName )
	if  self.dictByName[channelName] then
		return self.dictByName[channelName]
	end

	error(string.format("没有找到配置 ChannelConfigs.FindConfig channelName=%s", channelName))

	return  self.dict[ChannelId.Test]
end


ChannelConfigs:Add( ChannelConfig.New( ChannelId.Test			, "Test"			, "测试" ) )
ChannelConfigs:Add( ChannelConfig.New( ChannelId.Official		, "Official"		, "官方" ) )
ChannelConfigs:Add( ChannelConfig.New( ChannelId.Shinezone		, "Shinezone"		, "炫踪" ) )