using System;
using System.Collections.Generic;
using MessageProtocol;


public class ShinezoneRole
{
	/// 主角数据
	private ShinezoneRoleData _role_data = null;

	/// 玩家所拥有的角色列
	private Dictionary<long, ShinezoneRoleData> _role_data_list = new Dictionary<long, ShinezoneRoleData>();



	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////


	/**
	 * 获取主角数量
	 * @return {number}
	 * */
	public int GetRoleDataNum()
	{
		return _role_data_list.Count;
	}

	/**
	 * 增加主角信息到主角列表
	 * @param {long} dbid
	 * @param {int} sex
	 * @param {string} name
	 * @param {GlobalData} globaldata
	 * @param {ShareData} sharedata
	 * */
	public void AddRoleDataToRoleList(long dbid, int sex, string name, GlobalData globaldata, ShareData sharedata)
	{
		ShinezoneRoleData rd = null;
		if (_role_data_list.ContainsKey (dbid)) {
			rd = _role_data_list [dbid];
		} else {
			rd = new ShinezoneRoleData (dbid);
			_role_data_list [dbid] = rd;
		}

		rd.clear_dataobj ();
		rd.init_info (sex, name, globaldata, sharedata);
	}

	/**
	 * 获取主角数据列表
	 * @return {table}
	 * */
	public Dictionary<long, ShinezoneRoleData> GetRoleDataList()
	{
		return _role_data_list;
	}

	/**
	 * 删除指定主角数据
	 * @param {long} dbid
	 * */
	public void DeleteRoleDataByID(long dbid)
	{
		_role_data_list.Remove (dbid);
		if (_role_data != null)
		{
			if (_role_data.get_dbid () == dbid)
			{
				_role_data = null;
			}
		}
	}

	/**
	 * 设置当前主角，以及其详细数据
	 * @param {long} dbid 主角dbid
	 * @param {long} gold 元宝
	 * @param {long} money 金钱
	 * @param {CharDataObj} roledata 主角详细数据
	 * */
	public void SetRoleDataByID(long dbid, long gold, long money, CharDataObj roledata)
	{
		if (!_role_data_list.ContainsKey (dbid))
			return;

		ShinezoneRoleData rd = _role_data_list [dbid];
		rd.set_gold (gold);
		rd.set_money (money);
		rd.set_dataobj (roledata);

		_role_data = rd;
	}

	/**
	 * 获取当前主角数据对象
	 * @return {RoleData}
	 * */
	public ShinezoneRoleData GetRoleData()
	{
		return _role_data;
	}
}
