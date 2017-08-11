
local co = coroutine.create(function()
    print('coroutine start!')
    for i = 1, 10 do
        yield_return(CS.UnityEngine.WaitForEndOfFrame())
        print(Time.frameCount)
    end

    local s = os.time()
    yield_return(CS.UnityEngine.WaitForSeconds(3))
    print('wait interval:', os.time() - s)
    
    local www = CS.UnityEngine.WWW('http://www.qq.com')
    yield_return(www)
	if not www.error then
        print(www.bytes)
	else
	    print('error:', www.error)
	end
end)

-- coroutine.resume(co)


local TestA = {}
function TestA:Run( begin, endv )
    print("============", "TestA:Run", self, begin, endv)
    for i = begin, endv do
        yield_return(CS.UnityEngine.WaitForEndOfFrame())
        print("TestA, Run", i, Time.frameCount)
    end
end


local co2 = coroutine.create(TestA.Run)
coroutine.resume(co2, TestA, 1, 5)

