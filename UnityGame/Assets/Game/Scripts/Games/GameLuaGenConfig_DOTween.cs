/*
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
using DG.Tweening;

//配置的详细介绍请看Doc下《XLua的配置.doc》
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Core.Easing;
using DG.Tweening.Plugins;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;


public static class GameLuaGenConfig_DOTween
{
    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    [LuaCallCSharp]
    public static List<Type> LuaCallCSharp = new List<Type>() {
		typeof(DOTween),
		typeof(Tweener),
		typeof(Tween),


		typeof(AutoPlay),
		typeof(AxisConstraint),
		typeof(LogBehaviour),
		typeof(PathMode),
		typeof(PathType),
		typeof(RotateMode),
		typeof(ScrambleMode),
		typeof(TweenType),
		typeof(UpdateType),
		typeof(UpdateType),
		typeof(Ease),
		typeof(LoopType),

		
		typeof(Color2),
		typeof(DOVirtual),
		typeof(EaseFactory),
		typeof(EaseFunction),
		typeof(IDOTweenInit),
		typeof(Sequence),
		typeof(ShortcutExtensions),
		typeof(Tween),
		typeof(TweenCallback),
		typeof(Tweener),
		typeof(TweenExtensions),
		typeof(TweenParams),
		typeof(TweenSettingsExtensions),

		
		typeof(DOTweenComponent),
		typeof(DOTweenSettings),

		typeof(Bounce),
		typeof(EaseCurve),
		typeof(EaseManager),
		typeof(Flash),
		
		typeof(AnimationCurve),
		
		typeof(UpdateNotice),

		typeof(ColorPlugin),
		typeof(DoublePlugin),
		typeof(FloatPlugin),
		typeof(IntPlugin),
		typeof(LongPlugin),
		typeof(PathPlugin),
		typeof(QuaternionPlugin),
		typeof(RectOffsetPlugin),
		typeof(RectPlugin),
		typeof(StringPlugin),
		typeof(UintPlugin),
		typeof(UlongPlugin),
		typeof(Vector2Plugin),
		typeof(Vector3ArrayPlugin),
		typeof(Vector3Plugin),
		typeof(Vector4Plugin),

		typeof(ControlPoint),
		typeof(Path),

		typeof(ColorOptions),
		typeof(FloatOptions),
		typeof(OrientType),
		typeof(PathOptions),
		typeof(QuaternionOptions),
		typeof(RectOptions),
		typeof(StringOptions),
		typeof(Vector3ArrayOptions),
		typeof(VectorOptions),

		
		typeof(ShortcutExtensions46),
		typeof(DOTweenUtils46),
		typeof(ShortcutExtensions46),



	};

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    [CSharpCallLua]
    public static List<Type> CSharpCallLua = new List<Type>() {
		typeof(TweenCallback),
		typeof(TweenCallback<object>),
	};
	
	//黑名单
    [BlackList]
    public static List<List<string>> BlackList = new List<List<string>>()  {
               
            };
}
