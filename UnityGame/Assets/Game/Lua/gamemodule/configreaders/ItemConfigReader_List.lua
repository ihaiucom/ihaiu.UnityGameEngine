function ItemConfigReader:ReadConfigs(  )
	self:ParseHeadType()
	self:ParseHeadKeyCN()
	self:ParseHeadKeyEN()
	self:ParseHeadPropId()

	self:AddConfigArgs()
end