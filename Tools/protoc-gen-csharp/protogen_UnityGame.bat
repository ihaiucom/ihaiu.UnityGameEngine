@protoc -I./../LuaProtoGen/protocol ../LuaProtoGen/protocol/hall.proto -oPackets.bin 
clientgen\protogen.exe -i:Packets.bin -o:./../../UnityGame/Assets/Game/Scripts/GameGlobal/ProtoPacket.cs -ns:Games.PB -p:detectMissing
::@handlegen ..\Packets.cs .. S ..\ProtoMap.cs
::@typemapgen ..\Packets.cs C ..\PacketTypeMap.cs