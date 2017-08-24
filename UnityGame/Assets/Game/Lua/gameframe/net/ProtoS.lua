ProtoS = class("ProtoS", {
	-- <opcode, ProtoItem>
	opcodeDict 	= {},

	-- <name, ProtoItem>
	nameDict 	= {},

	-- <Struct, ProtoItem>
	structDict 	= {},
})
local M = ProtoS



-- 添加 ProtoItem
function M:AddItem( protoItem )
	self.opcodeDict	[protoItem.opcode] 				= protoItem
	self.nameDict	[protoItem.protoStructName] 	= protoItem
	self.structDict	[protoItem.protoStruct] 		= protoItem
end


-- 获取 ProtoItem, 用 opcode
function M:GetItemByOpcode( opcode )
	return self.opcodeDict[opcode]
end

-- 获取 ProtoItem, 用 protoStructName
function M:GetItemByName( protoStructName )
	return self.nameDict[opcode]
end

-- 获取 ProtoItem, 用 protoStruct
function M:GetItemByStruct( protoStruct )
	return self.structDict[protoStruct]
end



-- 获取 ProtoItem, 用 msg
function M:GetItemByMsg( msg )
	local name = getmetatable(msg)._descriptor.name
	return self.nameDict[name]
end



-- 获取 opcode, 用 msg
function M:GetOpcodeByMsg( msg )
	local item = self:GetItemByMsg(msg)
	return item.opcode
end

