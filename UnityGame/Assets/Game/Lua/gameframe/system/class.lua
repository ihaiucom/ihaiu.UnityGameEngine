
function clone(object)
    local lookup_table = {}
    local function _copy(object)
        if type(object) ~= "table" then
            return object
        elseif lookup_table[object] then
            return lookup_table[object]
        end
        local new_table = {}
        lookup_table[object] = new_table
        for key, value in pairs(object) do
            new_table[_copy(key)] = _copy(value)
        end
        return setmetatable(new_table, getmetatable(object))
    end
    return _copy(object)
end

--Create an class.
function class(classname, super)
    local superType = type(super)
    local cls

    if superType ~= "function" and superType ~= "table" then
        superType = nil
        super = nil
    end

    if superType == "function" or (super and super.__ctype == 1) then
        -- inherited from native C++ Object
        cls = {}

        if superType == "table" then
            -- copy fields from super
            for k,v in pairs(super) do cls[k] = v end
            cls.__create = super.__create
            cls.super    = super
        else
            cls.__create = super
        end

        cls.ctor    = function() end
        cls.__cname = classname
        cls.__ctype = 1

        function cls.New(...)
            local instance = cls.__create(...)
            -- copy fields from class to native object
            for k,v in pairs(cls) do instance[k] = v end
            instance.class = cls
            if instance.ctor then
                instance:ctor(...)
            end
            return instance
        end

    else
        -- inherited from Lua Object
        if super then
            cls = clone(super)
            cls.super = super
        else
            cls = {
                    ctor = function() end
                  }
        end


        cls.__cname = classname
        cls.__ctype = 2 -- lua
        cls.__index = cls
        cls.__tostring = function( obj )
            local str = "[" .. obj.__cname  .. "] {"
            for k, v in pairs(obj) do
                str = str .. tostring(k) .. " = " .. tostring(v) .. ", "
            end

            str = str .. "}"
            return str
        end


        function cls.New(...)

            local instance = setmetatable({}, cls)
            instance.class = cls
            if instance.ctor then
                instance:ctor(...)
            end
            return instance
        end
    end

    return cls
end



-- 在多个父类中查找字段k
function search(k, pParentList)
    for i = 1, #pParentList do
        local v = pParentList[i][k]
        if v then
            return v
        end
    end
end


function classmulti(classname ,...)
    local c = {} -- 新类
    local parents = {...}

    -- 类在其元表中搜索方法
    setmetatable(c, {__index = function (t, k) return search(k, parents) end})

    -- 将c作为其实例的元表
    c.__index = c
    c.__cname = classname
    c.super = {}
    setmetatable(c.super, {__index = function (t, k) return search(k, parents) end})


    -- 为这个新类建立一个新的构造函数
    function c:New(...)
        local o =  {}
        setmetatable(o, self)
        o.class = cls
        if o.ctor then
            o:ctor(...)
        end

        -- self.__index = self 这里不用设置了，在上面已经设置了c.__index = c
        return o
    end

    -- 返回新的类（原型）
    return c
end