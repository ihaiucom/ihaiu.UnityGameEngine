
--类型转换--
function toInt(number)
    return math.floor(tonumber(number) or 0)
end

function toBool(str)
	if str == "true" then
		return true
	else
		return false
	end
end