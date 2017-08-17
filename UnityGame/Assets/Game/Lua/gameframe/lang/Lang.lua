-----------------------
--  LangeTypeStruct
-----------------------

LangeTypeStruct = class("LangeTypeStruct",
{
	id 		= 0,
	name 	= "EN_US",
})

function LangeTypeStruct:ctor(id, name)
	self.id 	= id
	self.name	= name
end

function LangeTypeStruct:toString()
	return self.name .. "-" .. self.id
end

LangeTypeStruct.__tostring = LangeTypeStruct.toString



-----------------------
--  LangTypes
-----------------------
LangTypes = class("LangTypes",
{
	EN_US = LangeTypeStruct.New(0, "EN_US"),
	ZH_CN = LangeTypeStruct.New(1, "ZH_CN"),
	ZH_TW = LangeTypeStruct.New(2, "ZH_TW"),
})

function LangTypes.GetLocalName()
	return LangTypes.GetName(0)
end

function LangTypes.GetName(langId)
	for k, v in pairs(LangTypes) do
		if type(v) == 'table' and langId == v.id then
			return v.name
		end
	end

	return LangTypes.EN_US.name;
end


-- 简体中文
ZH_CN = class("ZH_CN",
{
	SETTING 					= "设置",
	LOGIN_VerifyPassword_Error	= "密码不一致",
	SERVER_STATE_NORMAL			= "正常",
	SERVER_STATE_CLOSE			= "关闭",
	SERVER_STATE_NONE			= "未知",
	SERVER_NoSelect				= "请选中服务器",
})


-- 英文
EN_US = class("EN_US",
{
	SETTING 					= "Setting",
	LOGIN_VerifyPassword_Error	= "Password inconsistency",
	SERVER_STATE_NORMAL			= "Normal",
	SERVER_STATE_CLOSE			= "Close",
	SERVER_STATE_NONE			= "Unknown",
	SERVER_NoSelect				= "please check the server",
})


-----------------------
--  Lang
-----------------------
Lang = class("Lang", _G[LangTypes.GetLocalName()])