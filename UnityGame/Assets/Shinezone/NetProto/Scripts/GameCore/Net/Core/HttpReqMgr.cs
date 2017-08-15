namespace lxnet
{
	using System;
	using System.Text;
	using System.Collections;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using UnityEngine;

	public class HttpReqMgr
	{

		/** http对象列 */
		private static List<HttpObj> _list = new List<HttpObj>();


		class HttpObj
		{
			private bool _is_done = false;

			public string url;
			public NetworkMgr.HttpSucceedFunc finishfunc;
			public NetworkMgr.HttpFailedFunc loaderrorfunc;
			public string cookie;

			public WWW wobj;

			~HttpObj()
			{
				// 释放www类对象
				if (this.wobj != null)
					this.wobj.Dispose();
			}


			public void do_get(string url, 
								NetworkMgr.HttpSucceedFunc finishfunc, 
								NetworkMgr.HttpFailedFunc loaderrorfunc, 
								string cookie)
			{
				Dictionary<string, string> tmp = new Dictionary<string, string> ();

				if (cookie != string.Empty)
					tmp.Add ("Cookie", parse_netscape_format_cookie(cookie));

				this.url = url;
				this.finishfunc = finishfunc;
				this.loaderrorfunc = loaderrorfunc;
				this.cookie = cookie;
				this.wobj = new WWW(url, null, tmp);
			}

			public void do_post(string url, string fields,
								NetworkMgr.HttpSucceedFunc finishfunc, 
								NetworkMgr.HttpFailedFunc loaderrorfunc, 
								string cookie)
			{
				Dictionary<string, string> tmp = new Dictionary<string, string> ();

				if (cookie != string.Empty)
					tmp.Add ("Cookie", parse_netscape_format_cookie(cookie));

				this.url = url;
				this.finishfunc = finishfunc;
				this.loaderrorfunc = loaderrorfunc;
				this.cookie = cookie;
				this.wobj = new WWW (url, Encoding.UTF8.GetBytes (fields), tmp);
			}

			public void check_done()
			{
				if (this.wobj.isDone)
				{
					this._is_done = true;

					if (this.wobj.error == null)
					{
						if (this.finishfunc != null)
						{
							string rc = get_cookie(this.wobj.responseHeaders);
							string root = get_root_url(this.url);

							string newcookie = make_cookie_by_netscape_format(root, rc);
							if (newcookie != string.Empty)
								this.cookie = newcookie;

							this.finishfunc(this.url, this.wobj.bytes, this.cookie);
						}
					}
					else
					{
						if (this.loaderrorfunc != null)
						{
							this.loaderrorfunc(url, -1);
						}
					}
				}
			}

			public bool is_done()
			{
				return this._is_done;
			}
		}

		/**
		 * 执行get任务
		 * @param {string} url 需要执行的url
		 * @param {function} finishfunc 执行成功时的回调函数【此函数接受url、userdata、cookie 三个参数】
		 * @param {function} loaderrorfunc 执行失败时的回调函数【此函数接受url、http错误码 两个参数】
		 * @param {string} cookie 可选，默认为空字符串
		 * */
		public static void DoGet(string url, 
								NetworkMgr.HttpSucceedFunc finishfunc, 
								NetworkMgr.HttpFailedFunc loaderrorfunc, 
								string cookie = "")
		{
			HttpObj hobj = new HttpObj ();
			_list.Add (hobj);
			hobj.do_get(url, finishfunc, loaderrorfunc, cookie);
		}

		/**
		 * 执行post任务
		 * @param {string} url 需要执行的路径
		 * @param {string} fields 执行httppost时附带的数据域
		 * @param {function} finishfunc 执行成功时的回调函数【此函数接受url、userdata、cookie 三个参数】
		 * @param {function} loaderrorfunc 执行失败时的回调函数【此函数接受url、http错误码 两个参数】
		 * @param {string} cookie 可选，默认为空字符串
		 * */
		public static void DoPost(string url, string fields, 
									NetworkMgr.HttpSucceedFunc finishfunc, 
									NetworkMgr.HttpFailedFunc loaderrorfunc, 
									string cookie = "")
		{
			HttpObj hobj = new HttpObj ();
			_list.Add (hobj);
			hobj.do_post(url, fields, finishfunc, loaderrorfunc, cookie);
		}

		public static void Run()
		{
			for (int i = _list.Count - 1; i >= 0; i--)
			{
				HttpObj tmp = _list[i];

				if (tmp.is_done())
				{
					_list.RemoveAt(i);
				}
				else
				{
					tmp.check_done();
				}
			}
		}

		////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////////
		/**
		 * 获取cookie
		 * */
		private static string get_cookie(Dictionary<string, string> tmp)
		{
			foreach (string key in tmp.Keys)
			{
				if (key.ToLower() == "set-cookie")
					return tmp[key];
			}

			return string.Empty;
		}

		/**
		 * 获取根url
		 * */
		private static string get_root_url(string url)
		{
			Regex reg = new Regex ("://(?<root>([^/]*))");
			Match m = reg.Match (url);
			if (m.Length == 0)
			{
				reg = new Regex ("^(?<root>([^/]*))");
				m = reg.Match (url);
			}

			string root = m.Groups ["root"].ToString();
			return root;
		}

		/**
		 * 生成netscape格式的cookie
		 * @param {string} domain
		 * @param {string} cookie
		 * @return {string}
		 * */
		private static string make_cookie_by_netscape_format(string domain, string cookie)
		{
			if (cookie == string.Empty)
				return string.Empty;

			/**
			 * 对要提取的部分起名字。这样取起来方便。
			 * c#中，+?就是尽量少取的意思。。。lua中是-
			 * */
			Regex reg = new Regex ("(?<key>(.+?))=(?<value>([^;]+))");
			Match m = reg.Match (cookie);

			string name = m.Groups ["key"].ToString ();
			string value = m.Groups ["value"].ToString();

			/// httponly domain tailmatch path secure expires name value
			return String.Format ("{0}{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", "", domain, "FALSE", "/", "FALSE", "0", name, value);
		}

		/**
		 * 解析netscape格式的cookie为http头格式的cookie
		 * @param {string} cookie_netscape
		 * @return {string}
		 * */
		private static string parse_netscape_format_cookie(string cookie_netscape)
		{
			string[] ret = cookie_netscape.Split ('\t');
			if (ret.Length <= 5)
				return string.Empty;

			return ret[5] + "=" + ret[6];
		}

	}
}

