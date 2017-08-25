
local M = ItemConfigReader

-- 读取数据
function M:ReadConfigs(  )
	self:ParseHeadType()
	self:ParseHeadKeyCN()
	self:ParseHeadKeyEN()
	self:ParseHeadPropId()

	self:AddConfigArgs()
end