AbstractParseCsv = class("AbstractParseCsv", IParseCsv)

local M = AbstractParseCsv
setmetatable(M, {__index = _G})
setfenv(1, M)

-- 表头 中文 <int index, string cnName>
headKeyCns = {}
-- 表头 英文 <int index, string key>
headKeyEns = {}
-- 表头 英文 <string key, int index>
headKeyIndexs = {}
-- 表头 属性 <int index, int propId >
headPropIds = {}


-- 解析表头行 中文
function ParseHeadKeyCN(self, csv )
	local key = "";
	for i, v in ipairs(csv) do
		key = string.trim(csv[i])
		if string.IsNullOrEmpty(key) == false then
			self.headKeyCns[i] = key
		end
	end
end



-- 解析表头行 英文
function ParseHeadKeyEN(self, csv )
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
function ParseHeadPropId(self, csv )
	for i, v in ipairs(csv) do
		if string.IsNullOrEmpty(csv[i]) == false then
			self.headPropIds[i] = toInt(csv[i])
		end
	end
end





-- 根据英文Key获取列Index
function GetHeadIndex(self, enName )
	if self.headKeyIndexs[enName] then
		return self.headKeyIndexs[enName]
	end	
	error(string.format("[%s] 不存在 headKeyIndexs[%s]", self.__cname, enName) )
	return  -1
end



-- 根据列Index获取英文Key
function GetHeadKey(self, index )
	if self.headKeyEns[index] then
		return self.headKeyEns[index]
	end	
	print(string.format("[%s] 不存在 headKeyEns[%d]", self.__cname, index) )
	return  -1
end

-- 根据列获取属性ID
function GetHeadPropId(self, index )
	if self.headPropIds[index] then
		return self.headPropIds[index]
	end

	error(string.format("[%s] 不存在 headPropIds[%d]", self.__cname, index) )
	return -1
end


