@protoc -I./../../../Gidea-MT-Proto ./../../../Gidea-MT-Proto/*.proto -oPackets.bin 
cd clientgen
protogen.exe -i:../Packets.bin -o:./../../../Game/Assets/Plugins/Libs/ProtoPacket.cs -ns:Games.PB -p:detectMissing
cd ../
::@handlegen ..\Packets.cs .. S ..\ProtoMap.cs
::@typemapgen ..\Packets.cs C ..\PacketTypeMap.cs
