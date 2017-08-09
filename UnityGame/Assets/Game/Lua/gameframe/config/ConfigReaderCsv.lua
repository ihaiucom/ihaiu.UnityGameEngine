ConfigReaderCsv = class("ConfigReaderCsv", AbstractParseCsv)

local M = ConfigReaderCsv



setmetatable(M, {__index = _G})
setfenv(1, M)


-- 配置类型
configType = ConfigType.CSV

-- 属性(配置路径， 是否有属性表头)
attribute 	= ConfigCsvAttribute.New("", false)
-- 配置的结构体
Struct 		= class("ConfigStruct", {id=0})
-- 配置的结构体信息
structInfo 	= { id = "number" }
-- 配置字典 <int id, Struct ConfigData>
configs 	= {}




-- 加载
function Load(self )
	ConfigSetting.Load(self.attribute.assetName, self, self.ParseAsset)
end

-- 重新加载
function Reload(self)
	self.configs.configs = {}
	self:Load()
end


-- 根据ID获取配置
function GetConfig(self, id)
	return self.configs[id]
end

-- 获取所有配置
function GetAllConfigs(self )
	return self.configs
end


-- 解析配置文件
function ParseAsset(self, assetName, txt)
	if txt == nil then
		error("加载配置文件出错", self.__cname, assetName)
	end


	txt = string.gsub(txt, "\r\n", "\n")
	local lines = string.split(txt, '\n')


	-- 解析表头行 中文
	local csv = string.split(lines[1], ";")
	self:ParseHeadKeyCN(csv)

	-- 解析表头行 英文
	csv = string.split(lines[2], ";")
	self:ParseHeadKeyEN(csv)


	local bodyBeginIndex = 3
	-- 解析表头行 属性ID
	if attribute.hasHeadPropId then
		bodyBeginIndex = 4
		csv = string.split(lines[3], ";")
		self:ParseHeadPropId(csv)
	end

	-- 解析Struct
	self:ParseStruct()


	-- 解析内容行
	for i = bodyBeginIndex,table.getn(lines) do
		if string.IsNullOrEmpty(lines[i]) == false then
			csv = string.split(lines[i], ';')
			self:ParseCsv(csv)
		end
	end


end

-- 解析Struct
function ParseStruct(self  )

	for k, v in pairs(self.Struct) do
		if self.structInfo[k] == nil and  v ~= nil then
			self.structInfo[k] = type(v)
		end
	end
end

function GetStructValType(self, key )
	if self.structInfo[key] then
		return self.structInfo[key]
	end

	return TYPE_STRING
end



-- 解析内容行
function ParseCsv(self, csv )
	local o = self.Struct.New()


	for i,v in ipairs(csv) do
		local key = self:GetHeadKey(i)
		if key then

			local valType = self:GetStructValType(key)

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

		end -- if key

		

	end

	self.configs[o.id] = o;

end
