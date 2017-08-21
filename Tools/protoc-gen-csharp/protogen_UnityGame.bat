@protoc -I./../../svn/proto ./../../svn/proto/*.proto -oPackets.bin 
clientgen/protogen.exe -i:Packets.bin -o:./../../UnityGame/Assets/Plugins/Libs/ProtoPacket.cs -ns:Games.PB -p:detectMissing
::@handlegen ..\Packets.cs .. S ..\ProtoMap.cs
::@typemapgen ..\Packets.cs C ..\PacketTypeMap.cs
