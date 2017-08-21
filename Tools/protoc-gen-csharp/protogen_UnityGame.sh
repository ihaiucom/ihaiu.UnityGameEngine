@protoc -I./../../svn/proto ./../../svn/proto/*.proto -oPackets.bin 
mono ./clientgen/protogen.exe -i:Packets.bin -o:./../../UnityGame/Assets/Plugins/Libs/ProtoPacket.cs -ns:Games.PB -p:detectMissing