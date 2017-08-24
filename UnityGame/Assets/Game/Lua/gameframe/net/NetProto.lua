-- 网络协议(接收，发送)
NetProto = class("NetProto", {})


local M = NetProto

-- 初始化
function M:Install(  )
	self.CSProto = CS.ShinezoneNetProtoLua
	self.CSProto.receiveEvent		('+', self.OnRecevie)
	ProtoC:AddItems()
	ProtoS:AddItems()
end

-- 添加监听协议
function M:AddProtoId( protoId )
	self.CSProto.AddProtoId( protoId )
end



-- 移除监听协议
function M:RemoveProtoId( protoId )
	self.CSProto.RemoveProtoId( protoId )
end



-- 添加监听
function M:AddCallback( protoStruct, fun, tab )
	local item = ProtoS:GetItemByStruct(protoStruct)
	item:AddListen(fun, tab)
	self:AddProtoId(item.opcode)
end

-- 移除监听
function M:RemoveCallback( protoStruct, fun, tab )
	local item = ProtoS:GetItemByStruct(protoStruct)
	item:RemoveListen(fun, tab)
	self:RemoveProtoId(item.opcode)
end


-- 发送消息
function M:SendMsg( msg )
	print("SocketNetLua ->", ProtoC:GetItemByMsg(msg):ToString() )
	self:SendBytes(ProtoC:GetOpcodeByMsg(msg), msg:SerializeToString() )
end


-- 发送消息
function M:SendBytes(protoId, bytes )
	self.CSProto.SendMsg(protoId, bytes)
end

-- 收到消息
function M.OnRecevie(protoId, bytes )
	local item = ProtoS:GetItemByOpcode(protoId)
	print("SocketNetLua <-", item:ToString() )
	item:OnRecevie(bytes)
end