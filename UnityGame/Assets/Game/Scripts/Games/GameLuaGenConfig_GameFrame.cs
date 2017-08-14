﻿/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using System.Collections.Generic;
using System;
using UnityEngine;
using XLua;

//配置的详细介绍请看Doc下《XLua的配置.doc》
public static class GameLuaGenConfig_GameFrame
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
		typeof(Game),
		typeof(Games.MainThreadManager),
		typeof(Games.UILayer),
		typeof(Games.UILayer.Layer),
		typeof(com.ihaiu.AssetManager),
		typeof(PlayerPrefsUtil),
		typeof(Games.Setting),
		typeof(Games.LocalSettingConfig),
		typeof(Games.AppSettingConfig),
		typeof(Games.VersionSettingConfig),
		typeof(Games.UrlSettingConfig),
	};

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
		typeof(Games.MainThreadManager.UpdateEvent),
	};
	
	//黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
               
            };
}
