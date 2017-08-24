person_pb = require "gen/pblua/person_pb"


-- Serialize Example
-- local msg = person_pb.Person()
-- msg.id = 100
-- msg.name = "foo"
-- msg.email = "bar"
-- local pb_data = msg:SerializeToString()
-- print(pb_data)

-- Parse Example
-- local msg = person_pb.Person()
-- msg:ParseFromString(pb_data)
-- print(msg.id, msg.name, msg.email)

-- Serialize Example
local msg = C_RequestFirstAuthorization_10000()
msg.account_id = 1000
msg.token = "21356145646"
msg.version = "1.0.0"
msg.channel = "ihaiu"
local pb_data = msg:SerializeToString()
print(pb_data)


-- Parse Example
local msg = C_RequestFirstAuthorization_10000()
msg:ParseFromString(pb_data)
print(msg.account_id, msg.token, msg.version, msg.channel)
print(rawget(msg, "descriptor"), rawget(msg, "full_name") )
print(getmetatable(msg), getmetatable(C_RequestFirstAuthorization_10000) )

local tab =  getmetatable(C_RequestFirstAuthorization_10000)
for k, v in pairs(tab) do
	print(k, v)

	if type(v) == "table" then
		for tk, tv in pairs(v) do
			print("----", tk, tv)

			if type(tv) == "table" then
				for tk2, tv2 in pairs(tv) do
					print("------------", tk2, tv2)
				end
			end
		end
	end
end	

print("========")

-- local tab =  getmetatable(msg)
-- for k, v in pairs(tab) do
-- 	print(k, v)
-- 	if type(v) == "table" then
-- 		for tk, tv in pairs(v) do
-- 			print("----", tk, tv)
-- 		end
-- 	end
-- end	

print(getmetatable(msg)._descriptor.name)

local msg = C_RequestFirstAuthorization_10000()
local item = ProtoC:GetItemByMsg(msg)
print(item:ToString())