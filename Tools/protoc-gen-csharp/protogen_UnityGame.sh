#!/bin/sh
cd `dirname $0`

@protoc -I./../../svn/proto ./../../svn/proto/*.proto -oPackets.bin 
mono ./clientgen/protogen.exe -i:Packets.bin -o:./../../UnityGame/Assets/Plugins/Libs/Proto/ProtoPacket.cs -ns:Games.PB -p:detectMissing