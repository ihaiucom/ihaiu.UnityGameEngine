-- =============================
-- 服务器状态
-- -----------------------------
SeverState =
{
	-- 正常
	Normal 	= 1,

	-- 关闭
	Close 	= 0,

	-- 未知
	None	= 90,
}

-- =============================
-- 服务器数据结构
-- -----------------------------
ServerItemData = class("ServerItemData", {
	id 		= 0,
	name	= "本地",
	ip 		= "127.0.0.1",
	port	= 1009,
	state   = 0,
})

ServerItemData.stateTextDict = {}
ServerItemData.stateTextDict[SeverState.Normal] = Lang.SERVER_STATE_NORMAL
ServerItemData.stateTextDict[SeverState.Close] 	= Lang.SERVER_STATE_CLOSE
ServerItemData.stateTextDict[SeverState.None] 	= Lang.SERVER_STATE_NONE


function ServerItemData:ctor( id, name, ip, port, state )
	self.id 	= tonumber(id)
	self.name 	= name
	self.ip 	= ip
	self.port	= port
	self.state  = tonumber(state)
end

function ServerItemData:GetStateText( )
	if ServerItemData.stateTextDict[self.state] then
		return ServerItemData.stateTextDict[self.state]
	end

	return Lang.SERVER_STATE_NONE
end

function ServerItemData:ToString(  )
	return string.format("{name:%s,  ip:%s,  port:%s, state:%d}", self.name, self.ip, self.port, self.state)
end

-- =============================
-- 服务器列表数据
-- -----------------------------
ServerListData = {

	-- 服务器列表 ServerItemData
	list = {}
}

local M = ServerListData

-- 解析Shinezone Json
function M.ParseShinezoneJson( result )

	local json = rapidjson.decode(result)
	local list = json["server_list"]

	ServerListData.list = {}
	for k, v in pairs(list) do
		local item = ServerItemData.New( k,  v["name"], v["ip"], v["port"], v["state"])
		item.name = string.format(item.name, k, "")
		table.insert( ServerListData.list,  item)
	end

	ServerListData.SortList()
end

-- 排序
function M.SortList(  )
	table.sort(ServerListData.list, ServerListData.SortComp)	
end


-- 排序方法
function M.SortComp( a, b )
	return a.id < b.id
end		