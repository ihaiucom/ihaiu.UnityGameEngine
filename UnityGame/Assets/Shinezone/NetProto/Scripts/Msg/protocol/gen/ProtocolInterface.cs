using System;
using System.Collections.Generic;


// 此代码自动生成，请勿修改！
namespace MessageProtocol
{
	public interface ProtocolInterface
	{

		/**
		 * 服务器：提示一则信息
		 * @param {int16} id 提示信息id
		 * */
		void on_hint_message(Int16 id);


		/**
		 * 服务器：告知客户端角色列表
		 * @param {array} char_list 角色列表
		 * */
		void on_char_list_to_client(List<CharInfo> char_list);


		/**
		 * 服务器：告知客户端增加角色信息到角色列表
		 * @param {object} one_info 角色信息
		 * */
		void on_add_char_to_charlist_client(CharInfo one_info);


		/**
		 * 服务器：告知客户端移除指定的角色
		 * @param {int64} dbid 角色dbid
		 * */
		void on_tell_delete_char(Int64 dbid);


		/**
		 * 服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
		 * @param {int64} dbid 角色dbid
		 * */
		void on_account_has_gameing_char_only_use_it(Int64 dbid);


		/**
		 * 服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
		 * */
		void on_tell_client_load_data();


		/**
		 * 服务器：告知客户端角色详细数据
		 * @param {int64} dbid 角色dbid
		 * @param {int64} gold 角色元宝
		 * @param {int64} money 角色金钱
		 * @param {object} dataobj 角色详细数据
		 * */
		void on_tell_char_data(Int64 dbid, Int64 gold, Int64 money, CharDataObj dataobj);


		/**
		 * 服务器：告知客户端准备加载指定地图以进入(客户端此时加载与详细数据相关的资源，当客户端加载完毕时，向服务器请求进入游戏)
		 * @param {int32} map_id 地图id
		 * @param {int32} pos_x 坐标x
		 * @param {int32} pos_y 坐标y
		 * */
		void on_tell_client_load_map(Int32 map_id, Int32 pos_x, Int32 pos_y);


		/**
		 * 服务器：告知客户端进入游戏
		 * */
		void on_tell_client_enter_game();


		/**
		 * 服务器：告知客户端充值成功，充值了X元宝
		 * @param {int64} recharge_gold 充值的元宝数量
		 * */
		void on_recharge_succeed_add_gold(Int64 recharge_gold);


		/**
		 * 申请匹配
		 * @param {int32} RetCode 返回码
		 * @param {string} Des 描述
		 * */
		void on_rsp_start_match(Int32 RetCode, string Des);


		/**
		 * 申请匹配
		 * @param {int32} Option 匹配类型
		 * @param {int32} Ret 1 表示加入，0 表示退出
		 * @param {object} Player 玩家角色信息
		 * */
		void on_notify_add_player(Int32 Option, Int32 Ret, RoomPlayerInfo Player);


		/**
		 * 匹配成功
		 * @param {int32} TimeOut 剩余时间，单位秒
		 * */
		void on_notify_match_success(Int32 TimeOut);


		/**
		 * 玩家通知服务器准备就绪
		 * @param {int32} RetCode 返回码
		 * @param {string} Des 描述
		 * */
		void on_rsp_tell_ready(Int32 RetCode, string Des);


		/**
		 * 准备战斗
		 * */
		void on_notify_start_battle();


		/**
		 * 玩家通知服务器准备战斗
		 * @param {int32} RetCode 返回码
		 * @param {string} Des 描述
		 * */
		void on_rsp_tell_start_battle_ready(Int32 RetCode, string Des);


		/**
		 * 匹配成功
		 * @param {string} BattleID 战场ID
		 * */
		void on_notify_enter_battle(string BattleID);


		/**
		 * 服务器：告知客户端增加角色元宝
		 * @param {int64} add_gold 增加的角色元宝
		 * */
		void on_tell_client_add_gold(Int64 add_gold);


		/**
		 * 服务器：告知客户端减少角色元宝
		 * @param {int64} dec_gold 减少的角色元宝
		 * */
		void on_tell_client_dec_gold(Int64 dec_gold);


		/**
		 * 服务器：告知客户端增加角色金钱
		 * @param {int64} add_money 增加的角色金钱
		 * */
		void on_tell_client_add_money(Int64 add_money);


		/**
		 * 服务器：告知客户端减少角色金钱
		 * @param {int64} dec_money 减少的角色金钱
		 * */
		void on_tell_client_dec_money(Int64 dec_money);


		/**
		 * 转发事件帧
		 * @param {uint32} PlayerID 单位ID
		 * @param {uint32} CmdID 指令ID
		 * @param {string} Cmd 帧内容
		 * @param {uint32} FrameID 帧序列
		 * @param {int64} ClientSentTime 客户端发送时刻
		 * @param {int64} ClientRecvTime 客户端接受时刻
		 * @param {int64} ServerSentTime 服务器发送时刻
		 * @param {int64} ServerRecvTime 服务器接受时刻
		 * */
		void on_notify_frame_update(UInt32 PlayerID, UInt32 CmdID, string Cmd, UInt32 FrameID, Int64 ClientSentTime, Int64 ClientRecvTime, Int64 ServerSentTime, Int64 ServerRecvTime);


		/**
		 * 战斗结束返回包
		 * @param {int32} RetCode 返回码
		 * @param {string} Des 描述
		 * */
		void on_rsp_end_battle(Int32 RetCode, string Des);


		/**
		 * 战斗结束通知
		 * @param {string} BattleID 战斗ID
		 * @param {int32} Group 胜利方,<0 表示出错，改场战斗无效
		 * */
		void on_notify_battle_result(string BattleID, Int32 Group);

	}
}