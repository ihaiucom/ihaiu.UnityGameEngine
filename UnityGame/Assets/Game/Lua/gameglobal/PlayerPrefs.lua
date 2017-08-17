require "gameglobal/PlayerPrefsKey"

PlayerPrefs = {}
local M = PlayerPrefs


-- 设置应用前缀
function M.SetAppPrefix( AppPrefix )
	PlayerPrefsUtil.SetAppPrefix(AppPrefix)
end


-- 设置玩家前缀
function M.SetUserKey( UserKey )
	PlayerPrefsUtil.SetUserKey(UserKey)
end


-----------------------
-- login
-----------------------

-- Username
function M.SetUsername( username )
	PlayerPrefsUtil.SetString( PlayerPrefsKey.Login_Username, username, false)
	PlayerPrefs.SetUserKey(username)
end


function M.GetUsername(  )
	return PlayerPrefsUtil.GetString( PlayerPrefsKey.Login_Username, false)
end

-- Password
function M.SetPassword( password )
	PlayerPrefsUtil.SetString( PlayerPrefsKey.Login_Password, password, false)
end


function M.GetPassword(  )
	return PlayerPrefsUtil.GetString( PlayerPrefsKey.Login_Password, false)
end

-- Server IP
function M.SetServerIP( ip )
	PlayerPrefsUtil.SetString( PlayerPrefsKey.Login_ServerIP, ip)
end


function M.GetServerIP(  )
	return PlayerPrefsUtil.GetString( PlayerPrefsKey.Login_ServerIP)
end


-- Server Port
function M.SetServerPort( port )
	PlayerPrefsUtil.SetInt( PlayerPrefsKey.Login_ServerPort, port)
end


function M.GetServerPort(  )
	return PlayerPrefsUtil.GetInt( PlayerPrefsKey.Login_ServerPort)
end