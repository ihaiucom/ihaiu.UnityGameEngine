ItemConfig = class("ItemConfig", {

	-- id
	id = 0,

	-- 名称
	name = "",

	-- 图标路径
    icon = "",

    -- 品质
    quality = 0.

    -- 说明
    tip = "",


})

local M = ItemConfig

function M:GetKey( )
	return self.id
end



function M:ctor(id, name, icon, quality, tip)
	self.id = id
	self.name = name
	self.icon = icon
	self.quality = quality
	self.tip = tip
end
