-- 是否为空字符窜
function string.IsNullOrEmpty(str)
	return str == nil or str == ""
end

--剔除字符串前后的空白符--
function string.trim (s)
	return (string.gsub(s, "^%s*(.-)%s*$", "%1"))
end



--字符串分割函数: 传入字符串和分隔符，返回分割后的table--
function string.split(str, delimiter)
	if str==nil or str=='' or delimiter==nil then
		return nil
	end

	local last = delimiter
	if string.match(last, "%%") then
		last = string.gsub(last, "%%", "")
	end
	
    local result = {}
    for match in (str..last):gmatch("(.-)"..delimiter) do
        table.insert(result, match)
    end
	
    return result
end