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