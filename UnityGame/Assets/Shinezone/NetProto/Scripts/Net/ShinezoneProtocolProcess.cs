using System;
using System.Collections.Generic;
using MessageProtocol;
using UnityEngine;

public class ShinezoneProtocolProcess : ProtocolInterface
{
	public ShinezoneNet 	 net;

	public ShinezoneProtocolProcess(ShinezoneNet netEvent)
	{
		this.net = net;
	}


	/**
	 * 服务器：提示一则信息
	 * @param {int16} id 提示信息id
	 * */
	public void on_hint_message(Int16 id)
	{
		string msg = ShinezoneHintMsgID.GetMsg (id);


		Loger.Log("hit msg, msg id:" + id + ",  msg=" + msg);
		net.netCtl.CallHintMessage (id, msg);
	}


	/**
	 * 服务器：告知客户端角色列表
	 * @param {array} char_list 角色列表
	 * */
	public void on_char_list_to_client(List<CharInfo> char_list)
	{
		foreach (CharInfo info in char_list) {
			net.role.AddRoleDataToRoleList(info._dbid, info._sex, info._name, info._globaldata, info._sharedata);
		}
		net.netCtl.CallRecvCharlist ();
	}


	/**
	 * 服务器：告知客户端增加角色信息到角色列表
	 * @param {object} one_info 角色信息
	 * */
	public void on_add_char_to_charlist_client(CharInfo one_info)
	{
		net.role.AddRoleDataToRoleList(one_info._dbid, one_info._sex, one_info._name, 
											one_info._globaldata, one_info._sharedata);

		
		net.netCtl.CallCreateCharSucceed ();
	}


	/**
	 * 服务器：告知客户端移除指定的角色
	 * @param {int64} dbid 角色dbid
	 * */
	public void on_tell_delete_char(Int64 dbid)
	{
		net.role.DeleteRoleDataByID(dbid);
		net.netCtl.CallDeleteCharSucceed (dbid);
	}


	/**
	 * 服务器：告知客户端当前账号存在正在游戏的角色，目前只能使用此正在角色的游戏进行游戏
	 * @param {int64} dbid 角色dbid
	 * */
	public void on_account_has_gameing_char_only_use_it(Int64 dbid)
	{
		Loger.Log("on_account_has_gameing_char_only_use_it:" + dbid);
		net.netCtl.CallCccountHasGameingCharOnlyUseIt (dbid);
	}


	/**
	 * 服务器：告知客户端加载必须数据，等待服务器加载角色详细数据
	 * */
	public void on_tell_client_load_data()
	{
		// 此时，选择角色成功，可以先加载一部分客户端所需的资源，同时等待服务器加载角色详细信息
		net.netCtl.CallTellClientLoadData();
	}


	/**
	 * 服务器：告知客户端角色详细数据
	 * @param {int64} dbid 角色dbid
	 * @param {int64} gold 角色元宝
	 * @param {int64} money 角色金钱
	 * @param {object} dataobj 角色详细数据
	 * */
	public void on_tell_char_data(Int64 dbid, Int64 gold, Int64 money, CharDataObj dataobj)
	{
		net.role.SetRoleDataByID(dbid, gold, money, dataobj);
		net.netCtl.CallTellCcharData ();
	}


	/**
	 * 服务器：告知客户端准备加载指定地图以进入(客户端此时加载与详细数据相关的资源，当客户端加载完毕时，向服务器请求进入游戏)
	 * @param {int32} map_id 地图id
	 * @param {int32} pos_x 坐标x
	 * @param {int32} pos_y 坐标y
	 * */
	public void on_tell_client_load_map(Int32 map_id, Int32 pos_x, Int32 pos_y)
	{
		// 记录要加载的地图信息
		// todo:
		Loger.Log("on_let_load_map, mapid:" + map_id + ", pos_x:" + pos_x + ", pos_y:" + pos_y);

		// 开始加载相关资源，为进入游戏做准备
//		EventHandler.on_need_load_map_for_entergame();
	}


	/**
	 * 服务器：告知客户端进入游戏
	 * */
	public void on_tell_client_enter_game()
	{
//		EventHandler.on_enter_in_game();
	}


	/**
	 * 服务器：告知客户端充值成功，充值了X元宝
	 * @param {int64} recharge_gold 充值的元宝数量
	 * */
	public void on_recharge_succeed_add_gold(Int64 recharge_gold)
	{
		Loger.Log("on_recharge_succeed_add_gold:" + recharge_gold);
	}


	/**
	 * 服务器：告知客户端增加角色元宝
	 * @param {int64} add_gold 增加的角色元宝
	 * */
	public void on_tell_client_add_gold(Int64 add_gold)
	{
		ShinezoneRoleData pl = net.role.GetRoleData();
		pl.set_gold(pl.get_gold() + add_gold);
		net.netCtl.CallTellClientAddGold (add_gold);
	}


	/**
	 * 服务器：告知客户端减少角色元宝
	 * @param {int64} dec_gold 减少的角色元宝
	 * */
	public void on_tell_client_dec_gold(Int64 dec_gold)
	{
		ShinezoneRoleData pl = net.role.GetRoleData();
		pl.set_gold(pl.get_gold() - dec_gold);
		
		net.netCtl.CallTellClientDecGold (dec_gold);
	}


	/**
	 * 服务器：告知客户端增加角色金钱
	 * @param {int64} add_money 增加的角色金钱
	 * */
	public void on_tell_client_add_money(Int64 add_money)
	{
		ShinezoneRoleData pl = net.role.GetRoleData();
		pl.set_money(pl.get_money() + add_money);

		net.netCtl.CallTellClientAddMoney (add_money);
	}


	/**
	 * 服务器：告知客户端减少角色金钱
	 * @param {int64} dec_money 减少的角色金钱
	 * */
	public void on_tell_client_dec_money(Int64 dec_money)
	{
		ShinezoneRoleData pl = net.role.GetRoleData();
		pl.set_money(pl.get_money() - dec_money);
		
		net.netCtl.CallTellClientDecMoney (dec_money);
	}

    /**
		 * 进入战斗返回包
		 * @param {int32} Ret 1 成功，-1：失败
		 * */
    public void on_rsp_room_start_battle(Int32 Ret)
    {
    }

    public void on_rsp_start_match(Int32 RetCode, string Des)
    {
        
    }

    public void on_notify_add_player(Int32 Option, Int32 Ret, RoomPlayerInfo Player)
    {
    }

    public void on_notify_match_success(Int32 TimeOut)
    {
    }
    
    public void on_rsp_tell_ready(Int32 RetCode, string Des)
    {
    } 

	public void on_notify_start_battle()
    {
    }

    public void on_rsp_tell_start_battle_ready(Int32 RetCode, string Des)
    {
        Debug.Log("ready to fight ack!");
    }

    public void on_notify_enter_battle(string BattleID)
    {
        Debug.Log("Battle started! " + BattleID);
    }

    public void on_notify_frame_update(UInt32 PlayerID, UInt32 CmdID, string Cmd, UInt32 FrameID, Int64 ClientSentTime, Int64 ClientRecvTime, Int64 ServerSentTime, Int64 ServerRecvTime)
    {
        if (CmdID != 0)
        {
            Debug.LogError("frame update!" + PlayerID + ":" + Cmd + ":RecevieTime:" + (uint)(Time.realtimeSinceStartup * 1000) + ":" + FrameID);
            Debug.LogError("ClientSentTime:" + ClientSentTime + "ClientReceive:" + ClientRecvTime);
            Debug.LogError("ServerSentTime:" + ServerSentTime + "ServerReveive:" + ServerRecvTime);
        } 

    }

    public void on_rsp_end_battle(Int32 RetCode, string Des)
    {

    }


    /**
     * 战斗结束通知
     * @param {string} BattleID 战斗ID
     * @param {int32} Group 胜利方,<0 表示出错，改场战斗无效
     * */
    public void on_notify_battle_result(string BattleID, Int32 Group)
    {
        Debug.Log("Game Over");
    }
}