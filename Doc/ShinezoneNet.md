# ShinezoneNet
Shinezone网络模块

[TOC]


## NetworkMgr
* Socket的外层
* 创建Socket


| 方法名					| 描述																		|
| ---------------------	| ------------------------------------------------------------------------ 	|
| RegisterProtocol 		| 注册消息监听																	| 
| SendMsgToServer 		| 发送消息																	|
| Run 					| 每帧调用；每3帧调用一次Http Run；每200帧调用一次LXNetDLL Run;每帧调socket RunOnce	| 
| Opause  				| 挂起Socket,实际没处理														|
| OnResume 				| 恢复Socket; Socket创建连接后才有效，并会发送一次ping								| 
| OnExit  				| 释放Socket 																| 
| Reconnect  			| 重连，会重新创建Socket 														| 
| Disconnect  			| 断开连接，销毁Socket 														| 
| SetAuthInfo  			| 认证账号信息；需要账号ID、session 												| 
| SetPingInterval  		| 设置ping的间隔时间 															| 
| GetPingDeay  			| 获取ping的延迟时间 															| 
| init_msg_handler  	| 默认注册监听协议,默认服务器时间 													| 
| on_server_update_time	| 处理服务器时间消息 															| 
| on_send_msg  			| 发送协议时，如果没有注册RPC Request，就会打一条log 								| 
| on_process_msg  		| 接收协议时，如果没有注册改消息，就会打一条log 										| 



## SocketNet
#### * 状态

| 状态名词 					| 描述 				| 设置时机												| 
| ------------------------- | ----------------- | ----------------------------------------------------- |
| enum_state_nil 			| 没有创建socket	 	| 默认、Disconnect (断开连接) 								| 
| enum_state_create 		| 已经创建socket	 	| reset_connect (重新创建socket)  						| 
| enum_state_connecting 	| 正在连接中			| try_connect (尝试连接，连接没报错并且发送ping成功)  			| 
| enum_state_connected 		| 连接成功			| on_rand_factor (收到服务器随机因子) 						| 
| enum_state_authing 		| 正在认证 			| on_rand_factor（收到服务器随机因子消息， 发送认证）			| 
| enum_state_authsucceed 	| 认证成功 			| on_auth_result (收到服务器认证结果消息并且认证成功)		 	| 



#### * 创建session的地方
1. req_first_auth; 请求进行首次认证
``` csharp
string session = lxnet_manager.Md5Sum (_auth_obj.from_web_M + _auth_obj.now_server_S);
```


2. req_short_link_auth; 请求进行短链接认证
``` csharp
string session = lxnet_manager.Md5Sum(_auth_obj.now_server_S + _auth_obj.prev_server_S + _auth_obj.first_auth_string + _auth_obj.prev_auth_string);

```

### * 验证流程

```flow
st=>start: Start:>http://blog.ihaiu.com
SetAuthInfo=>operation: SetAuthInfo(accountId, session)设置账号信息
Connect=>operation: Connect(ip, prot)连接服务器,设置状态为Create
S2C_RandFactor=>condition: S2C 随机因子，并设置状态为Connected
C2S_FirstAuth=>operation: C2S 第一次验证
C2S_ReAuth=>operation: C2S 断线重连验证
S2C_AuthResult=>condition: S2C 验证结果
Disconnect=>operation: 断开连接
Run=>operation: 设置状态为AuthSuccessed
e=>end

st->SetAuthInfo->Connect->S2C_RandFactor
S2C_RandFactor(yes)->C2S_FirstAuth->S2C_AuthResult
S2C_RandFactor(no)->C2S_ReAuth->S2C_AuthResult
S2C_AuthResult(yes)->Run
S2C_AuthResult(no)->Disconnect->e

```

<div class="flow-diagram theme theme-white" title="点击查看大图" data-anchor-id="d55y"><svg height="1384.2312860488892" version="1.1" width="992.8500366210938" xmlns="http://www.w3.org/2000/svg" style="overflow: hidden; position: relative;" viewBox="0 0 992.8500366210938 1384.2312860488892" preserveAspectRatio="xMidYMid meet"><desc>Created with Raphaël 2.1.2</desc><defs><path stroke-linecap="round" d="M5,0 0,2.5 5,5z" id="raphael-marker-block-obj9"></path><marker id="raphael-marker-endblock33-obj10" markerHeight="3" markerWidth="3" orient="auto" refX="1.5" refY="1.5"><use xlink:href="#raphael-marker-block-obj9" transform="rotate(180 1.5 1.5) scale(0.6,0.6)" stroke-width="1.6667" fill="black" stroke="none"></use></marker></defs><a xlink:href="http://blog.ihaiu.com" target="_blank"></a><a xlink:href="http://blog.ihaiu.com" target="_blank"><rect x="0" y="0" width="52.68333435058594" height="37.5" r="20" rx="20" ry="20" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="st" transform="matrix(1,0,0,1,204.1208,98.4813)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="18.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="stt" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,204.1208,98.4813)" stroke-width="1"><tspan dy="5.25">Start</tspan></text></a><rect x="0" y="0" width="323.7166748046875" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="SetAuthInfo" transform="matrix(1,0,0,1,68.6042,282.4625)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="SetAuthInfot" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,68.6042,282.4625)" stroke-width="1"><tspan dy="5.25">SetAuthInfo(accountId, session)设置账号信息</tspan></text><rect x="0" y="0" width="332" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="Connect" transform="matrix(1,0,0,1,64.4625,470.4438)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="Connectt" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,64.4625,470.4438)" stroke-width="1"><tspan dy="5.25">Connect(ip, prot)连接服务器,设置状态为Create</tspan></text><path style="" fill="#ffffff" stroke="#000000" d="M113.23125457763672,56.61562728881836L0,113.23125457763672L226.46250915527344,226.46250915527344L452.9250183105469,113.23125457763672L226.46250915527344,0L0,113.23125457763672" stroke-width="2" id="S2C_RandFactor" class="flowchart" transform="matrix(1,0,0,1,4,565.9438)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="118.23125457763672" y="113.23125457763672" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="S2C_RandFactort" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,4,565.9438)" stroke-width="1"><tspan dy="5.25">S2C 随机因子，并设置状态为Connected</tspan></text><rect x="0" y="0" width="129.3499984741211" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="C2S_FirstAuth" transform="matrix(1,0,0,1,165.7875,938.8875)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="C2S_FirstAutht" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,165.7875,938.8875)" stroke-width="1"><tspan dy="5.25">C2S 第一次验证</tspan></text><path style="" fill="#ffffff" stroke="#000000" d="M46.63124942779541,23.315624713897705L0,46.63124942779541L93.26249885559082,93.26249885559082L186.52499771118164,46.63124942779541L93.26249885559082,0L0,46.63124942779541" stroke-width="2" id="S2C_AuthResult" class="flowchart" transform="matrix(1,0,0,1,137.2,1100.9875)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="51.63124942779541" y="46.63124942779541" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="S2C_AuthResultt" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,137.2,1100.9875)" stroke-width="1"><tspan dy="5.250000953674316">S2C 验证结果</tspan></text><rect x="0" y="0" width="200.26666259765625" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="Run" transform="matrix(1,0,0,1,130.3292,1340.7313)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="Runt" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,130.3292,1340.7313)" stroke-width="1"><tspan dy="5.25">设置状态为AuthSuccessed</tspan></text><rect x="0" y="0" width="81" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="Disconnect" transform="matrix(1,0,0,1,563.6875,1126.8688)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="Disconnectt" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,563.6875,1126.8688)" stroke-width="1"><tspan dy="5.25">断开连接</tspan></text><rect x="0" y="0" width="47.70000076293945" height="37.5" r="20" rx="20" ry="20" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="e" transform="matrix(1,0,0,1,580.3375,1316.85)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="18.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="et" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,580.3375,1316.85)" stroke-width="1"><tspan dy="5.25">End</tspan></text><rect x="0" y="0" width="144.3499984741211" height="41.5" r="0" rx="0" ry="0" fill="#ffffff" stroke="#000000" style="" stroke-width="2" class="flowchart" id="C2S_ReAuth" transform="matrix(1,0,0,1,665.2125,658.425)"></rect><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="10" y="20.75" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" id="C2S_ReAutht" class="flowchartt" font-size="15px" transform="matrix(1,0,0,1,665.2125,658.425)" stroke-width="1"><tspan dy="5.25">C2S 断线重连验证</tspan></text><path style="" fill="none" stroke="#000000" d="M230.46250915527344,135.98125457763672C230.46250915527344,135.98125457763672,230.46250915527344,258.629494285844,230.46250915527344,279.470113142512" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><path style="" fill="none" stroke="#000000" d="M230.46250915527344,323.96250915527344C230.46250915527344,323.96250915527344,230.46250915527344,446.6107488634807,230.46250915527344,467.4513677201487" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><path style="" fill="none" stroke="#000000" d="M230.46250915527344,511.94376373291016C230.46250915527344,511.94376373291016,230.46250915527344,551.5978636741638,230.46250915527344,562.9442028175108" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><path style="" fill="none" stroke="#000000" d="M230.46250915527344,792.4062728881836C230.46250915527344,792.4062728881836,230.46250915527344,915.0545125963909,230.46250915527344,935.8951314530589" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="235.46250915527344" y="802.4062728881836" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" font-size="15px" stroke-width="1"><tspan dy="5.250022888183594">yes</tspan></text><path style="" fill="none" stroke="#000000" d="M456.9250183105469,679.1750183105469C456.9250183105469,679.1750183105469,636.6682948937198,679.1750183105469,662.2079889785359,679.1750183105469" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="461.9250183105469" y="669.1750183105469" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" font-size="15px" stroke-width="1"><tspan dy="5.249969482421875">no</tspan></text><path style="" fill="none" stroke="#000000" d="M230.46250915527344,980.3875274658203C230.46250915527344,980.3875274658203,230.46250915527344,1079.3816337300032,230.46250915527344,1097.9913656204867" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><path style="" fill="none" stroke="#000000" d="M230.46250915527344,1194.2500314712524C230.46250915527344,1194.2500314712524,230.46250915527344,1316.8982711794597,230.46250915527344,1337.7388900361277" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="235.46250915527344" y="1204.2500314712524" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" font-size="15px" stroke-width="1"><tspan dy="5.250031471252441">yes</tspan></text><path style="" fill="none" stroke="#000000" d="M323.72500801086426,1147.618782043457C323.72500801086426,1147.618782043457,533.0945147673738,1147.618782043457,560.6969399745308,1147.618782043457" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><text style="text-anchor: start; font: 15px &quot;Arial&quot;;" x="328.72500801086426" y="1137.618782043457" text-anchor="start" font="10px &quot;Arial&quot;" stroke="none" fill="#000000" font-size="15px" stroke-width="1"><tspan dy="5.250007629394531">no</tspan></text><path style="" fill="none" stroke="#000000" d="M604.1875171661377,1168.368782043457C604.1875171661377,1168.368782043457,604.1875171661377,1292.8243319092999,604.1875171661377,1313.850513673744" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path><path style="" fill="none" stroke="#000000" d="M737.3875274658203,699.9250183105469C737.3875274658203,699.9250183105469,737.3875274658203,1075.9875326156616,737.3875274658203,1075.9875326156616C737.3875274658203,1075.9875326156616,230.46250915527344,1075.9875326156616,230.46250915527344,1075.9875326156616C230.46250915527344,1075.9875326156616,230.46250915527344,1091.3609771728516,230.46250915527344,1097.9967803899199" stroke-width="2" marker-end="url(#raphael-marker-endblock33-obj10)"></path></svg></div>

