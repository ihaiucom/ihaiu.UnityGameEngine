ConfigAttribute = class("ConfigAttribute", {assetName="", hasHeadPropId=false})

function ConfigAttribute:ctor(assetName, hasHeadPropId)
	self.assetName 		= assetName
	self.hasHeadPropId 	= hasHeadPropId
end

function ConfigAttribute:ToString(  )
	return string.format("[ConfigAttribute] {assetName=%s, hasHeadPropId=%s}", self.assetName, tostring(self.hasHeadPropId)) 
end