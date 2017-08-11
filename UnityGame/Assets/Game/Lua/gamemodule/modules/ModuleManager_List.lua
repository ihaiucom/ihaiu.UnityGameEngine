function ModuleManager:GenerateList( ... )

	print("===ModuleManager:GenerateList")

	self.list = 
	{
		LoginModule,
		HomeModule,
	}

	print("LoginModule=", LoginModule)
	print("HomeModule=", HomeModule)

	print("self.list", self, self.list, #self.list)

end