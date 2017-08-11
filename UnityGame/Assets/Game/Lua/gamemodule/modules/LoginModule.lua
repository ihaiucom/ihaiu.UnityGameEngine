LoginModule = class("LoginModule", AbstractModule)
local M = LoginModule

-- 菜单ID
M.menuId 		= MenuId.Login
-- 视图Class
M.ViewClass 	= LoginWindow

print("AAAAAAAAAAAAAAAAAAAAA", LoginWindow)