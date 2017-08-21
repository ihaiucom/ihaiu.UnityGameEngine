-- Generated By protoc-gen-lua Do not Edit
local protobuf = require "protobuf.protobuf"
local login_pb = {}

local LOGINREQUEST = protobuf.Descriptor();
login_pb.LOGINREQUEST = LOGINREQUEST
local LOGINREQUEST_ID_FIELD = protobuf.FieldDescriptor();
local LOGINREQUEST_NAME_FIELD = protobuf.FieldDescriptor();
local LOGINREQUEST_EMAIL_FIELD = protobuf.FieldDescriptor();
local LOGINRESPONSE = protobuf.Descriptor();
login_pb.LOGINRESPONSE = LOGINRESPONSE
local LOGINRESPONSE_ID_FIELD = protobuf.FieldDescriptor();

LOGINREQUEST_ID_FIELD.name = "id"
LOGINREQUEST_ID_FIELD.full_name = ".LoginRequest.id"
LOGINREQUEST_ID_FIELD.number = 1
LOGINREQUEST_ID_FIELD.index = 0
LOGINREQUEST_ID_FIELD.label = 2
LOGINREQUEST_ID_FIELD.has_default_value = false
LOGINREQUEST_ID_FIELD.default_value = 0
LOGINREQUEST_ID_FIELD.type = 5
LOGINREQUEST_ID_FIELD.cpp_type = 1

LOGINREQUEST_NAME_FIELD.name = "name"
LOGINREQUEST_NAME_FIELD.full_name = ".LoginRequest.name"
LOGINREQUEST_NAME_FIELD.number = 2
LOGINREQUEST_NAME_FIELD.index = 1
LOGINREQUEST_NAME_FIELD.label = 2
LOGINREQUEST_NAME_FIELD.has_default_value = false
LOGINREQUEST_NAME_FIELD.default_value = ""
LOGINREQUEST_NAME_FIELD.type = 9
LOGINREQUEST_NAME_FIELD.cpp_type = 9

LOGINREQUEST_EMAIL_FIELD.name = "email"
LOGINREQUEST_EMAIL_FIELD.full_name = ".LoginRequest.email"
LOGINREQUEST_EMAIL_FIELD.number = 3
LOGINREQUEST_EMAIL_FIELD.index = 2
LOGINREQUEST_EMAIL_FIELD.label = 1
LOGINREQUEST_EMAIL_FIELD.has_default_value = false
LOGINREQUEST_EMAIL_FIELD.default_value = ""
LOGINREQUEST_EMAIL_FIELD.type = 9
LOGINREQUEST_EMAIL_FIELD.cpp_type = 9

LOGINREQUEST.name = "LoginRequest"
LOGINREQUEST.full_name = ".LoginRequest"
LOGINREQUEST.nested_types = {}
LOGINREQUEST.enum_types = {}
LOGINREQUEST.fields = {LOGINREQUEST_ID_FIELD, LOGINREQUEST_NAME_FIELD, LOGINREQUEST_EMAIL_FIELD}
LOGINREQUEST.is_extendable = false
LOGINREQUEST.extensions = {}
LOGINRESPONSE_ID_FIELD.name = "id"
LOGINRESPONSE_ID_FIELD.full_name = ".LoginResponse.id"
LOGINRESPONSE_ID_FIELD.number = 1
LOGINRESPONSE_ID_FIELD.index = 0
LOGINRESPONSE_ID_FIELD.label = 2
LOGINRESPONSE_ID_FIELD.has_default_value = false
LOGINRESPONSE_ID_FIELD.default_value = 0
LOGINRESPONSE_ID_FIELD.type = 5
LOGINRESPONSE_ID_FIELD.cpp_type = 1

LOGINRESPONSE.name = "LoginResponse"
LOGINRESPONSE.full_name = ".LoginResponse"
LOGINRESPONSE.nested_types = {}
LOGINRESPONSE.enum_types = {}
LOGINRESPONSE.fields = {LOGINRESPONSE_ID_FIELD}
LOGINRESPONSE.is_extendable = false
LOGINRESPONSE.extensions = {}

login_pb.LoginRequest = protobuf.Message(LOGINREQUEST)
login_pb.LoginResponse = protobuf.Message(LOGINRESPONSE)

return login_pb
