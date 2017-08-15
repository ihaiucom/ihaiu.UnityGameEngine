using System;
using MessageProtocol;

public class ShinezoneRoleData
{
	/// 角色dbid
	long _dbid = 0;

	/// 性别，0：女性，1：男性
	int _sex = 0;

	/// 角色名
	string _name = "";

	/// 元宝
	long _gold = 0;

	/// 金钱
	long _money = 0;

	/// 全局数据对象
	GlobalData _globaldata = null;

	/// 数据对象
	CharDataObj _dataobj = null;

	/// 共享数据
	ShareData _sharedata = null;


	////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////


	public ShinezoneRoleData(long dbid)
	{
		_dbid = dbid;
	}


	/**
	 * 初始化信息
	 * @param {int8} sex 性别
	 * @param {string} name 名字
	 * @param {GlobalData} globaldata 全局数据
	 * @param {ShareData} sharedata 共享数据
	 * */
	public void init_info(int sex, string name, GlobalData globaldata, ShareData sharedata)
	{
		_sex = sex;
		_name = name;
		_globaldata = globaldata;
		_sharedata = sharedata;
	}

	/**
	 * 获取角色dbid
	 * @return {int64}
	 * */
	public long get_dbid()
	{
		return _dbid;
	}

	/**
	 * 获取性别
	 * @return {int8}
	 * */
	public int get_sex()
	{
		return _sex;
	}

	/**
	 * 设置性别
	 * @param {int8} sex 性别
	 * */
	public void set_sex(int sex)
	{
		_sex = sex;
	}

	/**
	 * 获取角色名
	 * @return {string}
	 * */
	public string get_name()
	{
		return _name;
	}

	/**
	 * 设置角色名
	 * @param {string} name 角色名
	 * */
	public void set_name(string name)
	{
		_name = name;
	}

	/**
	 * 获取元宝
	 * @return {int64}
	 * */
	public long get_gold()
	{
		return _gold;
	}

	/**
	 * 设置元宝
	 * @param {int64} gold 元宝
	 * */
	public void set_gold(long gold)
	{
		_gold = gold;
	}

	/**
	 * 获取金钱
	 * @return {int64}
	 * */
	public long get_money()
	{
		return _money;
	}

	/**
	 * 设置金钱
	 * @param {int64} money 金钱
	 * */
	public void set_money(long money)
	{
		_money = money;
	}

	/**
	 * 获取全局数据对象
	 * @return {GlobalData}
	 * */
	public GlobalData get_globaldata()
	{
		return _globaldata;
	}

	/**
	 * 获取详细数据对象
	 * @return {CharDataObj}
	 * */
	public CharDataObj get_dataobj()
	{
		return _dataobj;
	}

	/**
	 * 获取共享数据对象
	 * @return {ShareData}
	 * */
	public ShareData get_sharedata()
	{
		return _sharedata;
	}

	/// 清除数据对象
	public void clear_dataobj()
	{
		_dataobj = null;
	}



	////////////////////////////////////////////////////////////////////////////////////////////////


	/**
	 * 设置详细数据对象
	 * @param {CharDataObj} dataobj 详细数据
	 * */
	public void set_dataobj(CharDataObj dataobj)
	{
		_dataobj = dataobj;
	}

}
