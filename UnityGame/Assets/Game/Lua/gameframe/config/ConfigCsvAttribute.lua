ConfigCsvAttribute = class("ConfigCsvAttribute", {assetName="", hasHeadPropId=false})

function ConfigCsvAttribute:ctor(assetName, hasHeadPropId)
	self.assetName 		= assetName
	self.hasHeadPropId 	= hasHeadPropId
end

function ConfigCsvAttribute:ToString(  )
	return string.format("[ConfigCsvAttribute] {assetName=%s, hasHeadPropId=%s}", self.assetName, tostring(self.hasHeadPropId)) 
end