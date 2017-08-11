MenuConfig = class("MenuConfig", {

		-- id 
		id = 0,

		-- 名称 
		name = "",

		-- 预设路径 或者 场景名称 
        path = "",

		-- 类型 
 		-- MenuType
        menuType = 0,

		-- UI层级 
 		-- UILayer.Layer
        layer = 0,

		-- 布局方式 
 		-- MenuLayout
        layout = 0,

		-- 关闭其他面板包含哪些 
 		--MenuCloseOtherType
        closeOtherType = 0,
        
		-- 关闭面板后缓存多长时间销毁（-1永久不销毁 0下一帧销毁 大于0会缓存时间秒） 
        cacheTime = -1,

        -- 加载面板类型
        -- LoaderId
        loaderType = 0,

})