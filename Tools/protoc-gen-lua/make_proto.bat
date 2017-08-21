cd ../../../Gidea-MT-Proto
for %%i in (*.proto) do (  
     ..\Gidea-MT-Client\Tools\protoc-gen-lua\protoc.exe --plugin=protoc-gen-lua="..\Gidea-MT-Client\Tools\protoc-gen-lua\plugin\build.bat" --lua_out=C:\zengfeng\game_mt\Gidea-MT-Client\Game\Assets\Game\Lua\gen\pblua %%i      
) 
