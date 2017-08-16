unpack = unpack or table.unpack

function table.getn(tab)
	return #tab
end

function table.removeItem( tab, item )
	for i = 1, #tab do
		if tab[i] == item then
			table.remove(tab, i)
			break
		end
	end
end