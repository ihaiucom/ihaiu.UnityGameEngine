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
function ParseHeadKeyCN( csv )
	local key = "";
	for i, v in ipairs(csv) do
		key = string.trim(csv[i])
		if ~ string.IsNullOrEmpty(key) then
			headKeyCns[i] = key
		end
	end
end



-- 解析表头行 英文
function ParseHeadKeyEN( csv )
	local key = "";
	for i, v in ipairs(csv) do
		key = string.trim(csv[i])
		if ~ string.IsNullOrEmpty(key) then
			headKeyEns[i] 		= key
			headKeyIndexs[key] 	= i
		end
	end
end


-- 解析表头行 属性ID
function ParseHeadPropId( csv )
	for i, v in ipairs(csv) do
		if ~ string.IsNullOrEmpty(csv[i]) then
			headPropIds[i] = toInt(csv[i])
		end
	end
end





-- 根据英文Key获取列Index
function GetHeadIndex( enName )
	if headKeyIndexs[enName] then
		return headKeyIndexs[enName]
	end	
	error(tostring(self) .. "headKeyIndexs[" .. enName .. "] = nil")
	return  -1
end



-- 根据列Index获取英文Key
function GetHeadKey( index )
	if headKeyEns[index] then
		return headKeyEns[index]
	end	
	error(tostring(self) .. "headKeyEns[" .. index .. "] = nil")
	return  -1
end

-- 根据列获取属性ID
function GetHeadPropId( index )
	if headPropIds[index] then
		return headPropIds[index]
	end

	error(tostring(self) .. "headPropIds[" .. index .. "] = nil")
	return -1
end


