


-- ====================
-- authorization
-- --------------------

-- 登录认证结果
-- [mapping] C_FirstAuthorization_10000, authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
-- [mapping] C_ReconnectOnLossandAuthorization_10001, authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
S_FirstAuthorization_10002 = authorization_pb.SMSG_FirstAuthorization_Resp

-- 通知客户端重新连接到新网关
S_ConnectToNewGateway_10003 = authorization_pb.SMSG_ConnectToNewGateway_Ntf

-- 账号重复登录
-- [mapping] C_FirstAuthorization_10000, authorization_pb, 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
-- [mapping] C_ReconnectOnLossandAuthorization_10001, authorization_pb, 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
S_AccountDuplicateLogin_10004 = authorization_pb.SMSG_AccountDuplicateLogin_Ntf

-- 同步服务器时间
S_SyncServerTimestamp_15001 = authorization_pb.SMSG_SyncServerTimestamp_Ntf

-- 同步随机因子，链接上socket时服务器发
S_SyncRandomFactor_15002 = authorization_pb.SMSG_SyncRandomFactor_Ntf




-- ====================
-- character
-- --------------------

-- 同步角色信息
S_SyncRoleInfo_12001 = character_pb.SMSG_SyncRoleInfo_Ntf




-- ====================
-- hero
-- --------------------

-- 同步英雄列表
S_SyncHeroList_12002 = hero_pb.SMSG_SyncHeroList_Ntf

-- 选择初始英雄结果
-- [mapping] C_SelectInitializedHero_12003, hero_pb, 请求选择初始英雄
S_SelectInitializedHero_12004 = hero_pb.SMSG_SelectInitializedHero_Resp

-- 获得新英雄
-- [mapping] C_SelectInitializedHero_12003, hero_pb, 请求选择初始英雄
S_AddHero_12005 = hero_pb.SMSG_AddHero_Ntf





function ProtoS:AddItems( )



 	-- ====================
 	-- authorization
 	-- --------------------

 	-- 登录认证结果
 	ProtoS:AddItem(ProtoItem.New(10002, "SMSG_FirstAuthorization_Resp", "S_FirstAuthorization_10002", S_FirstAuthorization_10002, "authorization_pb", {10000,10001}, "登录认证结果", true))

 	-- 通知客户端重新连接到新网关
 	ProtoS:AddItem(ProtoItem.New(10003, "SMSG_ConnectToNewGateway_Ntf", "S_ConnectToNewGateway_10003", S_ConnectToNewGateway_10003, "authorization_pb", {}, "通知客户端重新连接到新网关", true))

 	-- 账号重复登录
 	ProtoS:AddItem(ProtoItem.New(10004, "SMSG_AccountDuplicateLogin_Ntf", "S_AccountDuplicateLogin_10004", S_AccountDuplicateLogin_10004, "authorization_pb", {10000,10001}, "账号重复登录", true))

 	-- 同步服务器时间
 	ProtoS:AddItem(ProtoItem.New(15001, "SMSG_SyncServerTimestamp_Ntf", "S_SyncServerTimestamp_15001", S_SyncServerTimestamp_15001, "authorization_pb", {}, "同步服务器时间", true))

 	-- 同步随机因子，链接上socket时服务器发
 	ProtoS:AddItem(ProtoItem.New(15002, "SMSG_SyncRandomFactor_Ntf", "S_SyncRandomFactor_15002", S_SyncRandomFactor_15002, "authorization_pb", {}, "同步随机因子，链接上socket时服务器发", true))




 	-- ====================
 	-- character
 	-- --------------------

 	-- 同步角色信息
 	ProtoS:AddItem(ProtoItem.New(12001, "SMSG_SyncRoleInfo_Ntf", "S_SyncRoleInfo_12001", S_SyncRoleInfo_12001, "character_pb", {}, "同步角色信息", true))




 	-- ====================
 	-- hero
 	-- --------------------

 	-- 同步英雄列表
 	ProtoS:AddItem(ProtoItem.New(12002, "SMSG_SyncHeroList_Ntf", "S_SyncHeroList_12002", S_SyncHeroList_12002, "hero_pb", {}, "同步英雄列表", true))

 	-- 选择初始英雄结果
 	ProtoS:AddItem(ProtoItem.New(12004, "SMSG_SelectInitializedHero_Resp", "S_SelectInitializedHero_12004", S_SelectInitializedHero_12004, "hero_pb", {12003}, "选择初始英雄结果", true))

 	-- 获得新英雄
 	ProtoS:AddItem(ProtoItem.New(12005, "SMSG_AddHero_Ntf", "S_AddHero_12005", S_AddHero_12005, "hero_pb", {12003}, "获得新英雄", true))

end

