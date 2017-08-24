@protoc -I./../../svn/proto ./../../svn/proto/*.proto -oPackets.bin 
cd clientgen
protogen.exe -i:../Packets.bin -o:./../../../UnityGame/Assets/Plugins/Libs/Proto/ProtoPacket.cs -ns:Games.PB -p:detectMissing
cd ../
::@handlegen ..\Packets.cs .. S ..\ProtoMap.cs
::@typemapgen ..\Packets.cs C ..\PacketTypeMap.cs
