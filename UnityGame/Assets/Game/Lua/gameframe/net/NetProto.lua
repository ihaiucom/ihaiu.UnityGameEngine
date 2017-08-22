-- 网络协议(接收，发送)
NetProto = class("NetProto", {})

local M = NetProto

-- 初始化
function M:Install(  )
	self.CSProto = CS.ShinezoneNetProtoLua
	self.CSProto.receiveEvent		('+', self.OnRecevie)
end

-- 添加监听协议
function M:AddProtoId( protoId )
	self.CSProto.AddProtoId( protoId )
end



-- 移除监听协议
function M:RemoveProtoId( protoId )
	self.CSProto.RemoveProtoId( protoId )
end

-- 发送消息
function M:Send(protoId, bytes )
	self.CSProto.SendMsg(protoId, bytes)
end

-- 收到消息
function M.OnRecevie(protoId, bytes )
	
end