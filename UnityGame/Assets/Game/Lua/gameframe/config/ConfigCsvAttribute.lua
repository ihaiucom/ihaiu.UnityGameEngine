ConfigCsvAttribute = class("ConfigCsvAttribute", {assetName="", hasHeadPropId=false})

function ConfigCsvAttribute:ctor(assetName, hasHeadPropId)
	self.assetName 		= assetName
	self.hasHeadPropId 	= hasHeadPropId
end