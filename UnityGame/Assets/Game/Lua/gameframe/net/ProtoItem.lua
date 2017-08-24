ProtoItem = class("ProtoItem", {
	-- 协议号
	opcode 					= 0,
	-- 结构体名称
	protoStructName 		= nil,
	-- 结构体名称
	protoStructName 		= nil,
	-- 结构体别名
	protoStructAliasName 	= nil,
	-- 结构体
	protoStruct 			= nil,
	-- 协议文件
	filename 				= nil,
	-- 对应协议编号
	opcodeMapping 			= {},
	-- 描述
	note 					= nil,

	-- 监听列表
	listens					= nil,
})


local M = ProtoItem

-- 构造函数
function M:ctor( opcode, protoStructName, protoStructAliasName, protoStruct, filename, opcodeMapping, note, isS )
	self.opcode 					= opcode
	self.protoStructName 			= protoStructName
	self.protoStructAliasName 		= protoStructAliasName
	self.protoStruct 				= protoStruct
	self.filename 					= filename
	self.opcodeMapping 				= opcodeMapping
	self.note 						= note

	if protoStruct == nil then
		error(string.format("ProtoItem.New 协议结构体不存在 %s,%s.%s, protoStructAliasName, %s", opcode, filename, protoStructName, protoStructAliasName, note))
	end

	if isS then
		self.listens = {}
	end

end

function M:ToString( ... )
	return string.format("ProtoItem %d, %s.%s, %s, %s", self.opcode, self.filename, self.protoStructName, self.protoStructAliasName, self.note)
end



-- 查找
function M:Find(fun, tab )
	if self.listens == nil then
		return -1, nil
	end

	for i, item in ipairs(self.listens) do
		if item.tab == tab and item.fun == fun then
			return i, item
		end
	end

	return -1, nil
end

-- 是否已经监听
function M:Concat(fun, tab )
	local i, item = self:Find(tab, fun)
	return i > 0
end


-- 添加监听
function M:AddListen( fun, tab )
	if self:Concat(fun, tab) then
		return
	end

	table.insert(self.listens, {tab = tab, fun = fun})
end

-- 移除监听
function M:RemoveListen( fun, tab )

	local i, item = self:Find(fun, tab)
	if i > 0 then
		table.remove(self.listens, i)
	end

end




-- 移除所有监听
function M:RemoveAllListen(  )
	self.listens = {}
end


-- 调
function M:DistchMsg( msg )
	for i, item in ipairs(self.listens) do
		item.fun(item.tab, msg)
	end
end


-- 收到消息数据
function M:OnRecevie( bytes )
	local msg = self.protoStruct()
	msg:ParseFromString(bytes)
	self:DistchMsg(bytes)
end