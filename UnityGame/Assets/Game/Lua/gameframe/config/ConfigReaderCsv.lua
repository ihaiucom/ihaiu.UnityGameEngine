ConfigReaderCsv = classmulti("ConfigReaderCsv", AbstractParseCsv, IConfigRender)

local M = ConfigReaderCsv



setmetatable(M, {__index = _G})
setfenv(1, M)

-- 类型 常量
TYPE_STRING 		= "string"
TYPE_NUMBER 		= "number"
TYPE_ARRAY_STRING 	= "array_string"
TYPE_ARRAY_NUMBER 	= "array_number"
TYPE_Other 			= "other"


-- 属性(配置路径， 是否有属性表头)
attribute 	= ConfigCsvAttribute.New("", false)
-- 配置的结构体
Struct 		= class("ConfigStruct", {id=0})
-- 配置的结构体信息
structInfo 	= { id = "number" }
-- 配置字典 <int id, Struct ConfigData>
configs 	= {}




-- 加载
function Load( )
	ConfigSetting.Load(attribute.assetName, ParseAsset)
end

-- 重新加载
function Reload( )
	configs.configs = {}
	Load()
end


-- 根据ID获取配置
function GetConfig(id)
	return configs[id]
end

-- 获取所有配置
function GetAllConfigs( )
	return configs
end


-- 解析配置文件
function ParseAsset(assetName, txt)
	if txt == nil then
		error("加载配置文件出错", self.__cname, assetName)
	end


	obj = string.gsub(obj, "\r\n", "\n")
	local lines = string.split(obj, '\n')


	-- 解析表头行 中文
	local csv = string.split(lines[1], ";")
	ParseHeadKeyCN(csv)

	-- 解析表头行 英文
	csv = string.split(lines[2], ";")
	ParseHeadKeyEN(csv)


	-- 解析表头行 属性ID
	if attribute.hasHeadPropId then
		csv = string.split(lines[3], ";")
		ParseHeadPropId(csv)
	end

	-- 解析Struct
	ParseStruct()


	-- 解析内容行
	for i = 4,table.getn(lines) do
		csv = string.split(lines[i], ';')
		if table.getn(csv) == 0 or string.IsNullOrEmpty(csv[1]) then
			ParseCsv(csv)
		end
	end


end

-- 解析Struct
function ParseStruct(  )

	for k, v in pairs(Struct) do
		if structInfo[k] == nil and  v ~= nil then
			structInfo[k] = type(v)
		end
	end
end

function GetStructValType( key )
	if structInfo[key] then
		return structInfo[key]
	end

	return TYPE_STRING
end



-- 解析内容行
function ParseCsv( csv )
	local o = Struct.New()

	for i,v in ipairs(csv) do
		local key = GetHeadKey(i)
		local valType = GetStructValType(key)

		if valType == TYPE_STRING then
			o[key] = v
		elseif valType == TYPE_NUMBER then
			o[key] = tonumber(v)
		elseif valType == TYPE_ARRAY_STRING then
			o[key] = string.split(v, ",")
		elseif valType == TYPE_ARRAY_NUMBER then
			o[key] = string.split(v, ",")
			for ik, iv in ipairs(o[key]) do
				o[key][ik] = tonumber(iv)
			end
		elseif o.Parse then
			o.Parse(key, v)
		end

	end
end
