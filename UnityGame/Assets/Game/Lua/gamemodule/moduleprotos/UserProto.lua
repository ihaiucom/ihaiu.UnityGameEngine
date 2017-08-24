-- 玩家账号相关的协议处理器
UserProto = class("UserProto", AbstractModuleProto)

local M = UserProto

-- 添加协议监听
function M:AddS2C(  )
	-- 同步角色信息
	Game.proto:AddCallback(S_SyncRoleInfo_12001, self.S_SyncRoleInfo_12001, self )

	-- 同步英雄列表
	Game.proto:AddCallback(S_SyncHeroList_12002, self.S_SyncHeroList_12002, self )

	-- 选择初始英雄结果
	Game.proto:AddCallback(S_SelectInitializedHero_12004, self.S_SelectInitializedHero_12004, self )


	-- 新增新英雄
	Game.proto:AddCallback(S_AddHero_12005, self.S_AddHero_12005, self )
	
end

-- S2C ------------------------------------------------------------

-- 同步角色信息
function M:S_SyncRoleInfo_12001( msg )
	self:C_RequestSelectInitializedHero_12003_(1)
end

-- 同步英雄列表
function M:S_SyncHeroList_12002( msg )

end


-- 选择初始英雄结果
-- [mapping] C_SelectInitializedHero_12003, hero_pb, 请求选择初始英雄
function M:S_SelectInitializedHero_12004( msg )

end


-- 新增新英雄
-- [mapping] C_SelectInitializedHero_12003, hero_pb, 请求选择初始英雄
function M:S_AddHero_12005( msg )

end




-- C2S ------------------------------------------------------------

-- 请求选择初始英雄
function M:C_RequestSelectInitializedHero_12003_(heroId)
	local msg = hero_pb.CMSG_SelectInitializedHero_Req()
	msg.id = heroId
	print(msg.id)
	Game.proto:SendMsg(msg)
end