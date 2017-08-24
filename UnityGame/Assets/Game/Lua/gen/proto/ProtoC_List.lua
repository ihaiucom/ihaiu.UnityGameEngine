


-- ====================
-- authorization
-- --------------------

-- 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
-- [mapping] S_FirstAuthorization_10002,  authorization_pb, 登录认证结果
-- [mapping] S_AccountDuplicateLogin_10004,  authorization_pb, 账号重复登录
C_FirstAuthorization_10000 = authorization_pb.CMSG_FirstAuthorization_Req

-- 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
C_ReconnectOnLossandAuthorization_10001 = authorization_pb.CMSG_ReconnectOnLossandAuthorization_Req




-- ====================
-- hero
-- --------------------

-- 请求选择初始英雄
C_SelectInitializedHero_12003 = hero_pb.CMSG_SelectInitializedHero_Req





function ProtoC:AddItems( )



 	-- ====================
 	-- authorization
 	-- --------------------

 	-- 请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要
 	ProtoC:AddItem(ProtoItem.New(10000, "CMSG_FirstAuthorization_Req", "C_FirstAuthorization_10000", C_FirstAuthorization_10000,  "authorization_pb", {10002,10004}, "请求首次登录认证，收到随机因子后根据协议里的是否需要短链接,不需要", false))

 	-- 客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要
 	ProtoC:AddItem(ProtoItem.New(10001, "CMSG_ReconnectOnLossandAuthorization_Req", "C_ReconnectOnLossandAuthorization_10001", C_ReconnectOnLossandAuthorization_10001,  "authorization_pb", {}, "客户端断线重连认证，收到随机因子后根据协议里的是否需要短链接,需要", false))




 	-- ====================
 	-- hero
 	-- --------------------

 	-- 请求选择初始英雄
 	ProtoC:AddItem(ProtoItem.New(12003, "CMSG_SelectInitializedHero_Req", "C_SelectInitializedHero_12003", C_SelectInitializedHero_12003,  "hero_pb", {}, "请求选择初始英雄", false))

end

