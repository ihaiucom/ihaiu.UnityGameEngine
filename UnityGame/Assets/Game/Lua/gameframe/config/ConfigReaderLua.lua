ConfigReaderLua = class("ConfigReaderLua", IConfigRender)

local M = ConfigReaderLua

-- 配置类型
M.configType = ConfigType.LUA

-- 属性(配置路径， 是否有属性表头)
M.attribute 	= ConfigAttribute.New("", false)

-- 结构体 比如:ItemConfig
M.StructClass 	= nil


-- 表头 Type <int index, string type>
headKeyTypes = {}
-- 表头 中文 <int index, string cnName>
headKeyCns = {}
-- 表头 英文 <int index, string key>
headKeyEns = {}
-- 表头 英文 <string key, int index>
headKeyIndexs = {}
-- 表头 属性 <int index, int propId >
headPropIds = {}

-- 配置字典 <int id, Struct ConfigData>
M.configs 	= {}


-- 加载
function M:Load( )
	self:ReadConfigs()
end

-- 重新加载
function M:Reload( )
	
end


-- 根据ID获取配置
function M:GetConfig(key)
	return self:configs[key]
end


-- ===============================================

-- 解析表头行 Type
function M:ParseHeadType(... )
	self.headKeyTypes = {...}
end


-- 解析表头行 中文
function M:ParseHeadKeyCN(... )
	self.headKeyCns = {...}
end



-- 解析表头行 英文
function M:ParseHeadKeyEN(...)
	local csv = {...}
	local key = "";
	for i, v in ipairs(csv) do
		key = string.trim(csv[i])
		if string.IsNullOrEmpty(key) == false then
			self.headKeyEns[i] 			= key
			self.headKeyIndexs[key] 	= i
		end
	end
end


-- 解析表头行 属性ID
function M:ParseHeadPropId(... )
	self.headPropIds = {...}
end





-- 根据英文Key获取列Index
function M:GetHeadIndex( enName )
	if self.headKeyIndexs[enName] then
		return self.headKeyIndexs[enName]
	end	
	error(string.format("[%s] 不存在 headKeyIndexs[%s]", self.__cname, enName) )
	return  -1
end



-- 根据列Index获取英文Key
function M:GetHeadKey(index )
	if self.headKeyEns[index] then
		return self.headKeyEns[index]
	end	
	print(string.format("[%s] 不存在 headKeyEns[%d]", self.__cname, index) )
	return  -1
end

-- 根据列获取属性ID
function M:GetHeadPropId(index )
	if self.headPropIds[index] then
		return self.headPropIds[index]
	end

	error(string.format("[%s] 不存在 headPropIds[%d]", self.__cname, index) )
	return -1
end

function M:ParseLine(i, ... )
	if i > 4 then
		self:AddConfigArgs(...)
	elseif i == 1 then
		self:ParseHeadType(...)
	elseif i == 2 then
		self:ParseHeadKeyCN(...)
	elseif i == 3 then
		self:ParseHeadKeyEN(...)
	elseif i == 4 and self.attribute ~= nil and self.attribute.hasHeadPropId  then
		self:ParseHeadPropId(...)
	else
		self:AddConfigArgs(...)
	end

end


-- ===============================================



-- 读取数据
function M:ReadConfigs( )
	
end

-- 添加
function M:AddItem(item )
	self.configs[item:GetKey()] = item
end

-- 添加配置参数
function M:AddConfigArgs( ... )
	if self.StructClass then
		local item = self.StructClass.New(...)
		self:AddItem(item)
	else
		error(string.format("读取Lua配置，请设置结构体 %s", self.__cname))
	end
end
