person_pb = require "gen/pblua/person_pb"


-- Serialize Example
local msg = person_pb.Person()
msg.id = 100
msg.name = "foo"
msg.email = "bar"
local pb_data = msg:SerializeToString()
print(pb_data)

-- Parse Example
local msg = person_pb.Person()
msg:ParseFromString(pb_data)
print(msg.id, msg.name, msg.email)