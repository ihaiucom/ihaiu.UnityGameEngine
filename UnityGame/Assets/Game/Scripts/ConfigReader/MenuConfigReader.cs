using UnityEngine;
using System.Collections;
using com.ihaiu;

namespace Games
{
	[ConfigCsv("Config/Client/Menu", true, false)]
	public class MenuConfigReader : ConfigReader<MenuConfig>
	{
		public override void ParseCsv (string[] csv)
		{
			MenuConfig config = new MenuConfig();
			config.id		= csv.GetInt32(GetHeadIndex("id"));
			config.name		= csv.GetString(GetHeadIndex("name"));
			config.path		= csv.GetString(GetHeadIndex("path"));
			config.menuType		= (MenuType) 		csv.GetInt32(GetHeadIndex("menuType"));
			config.layer	= (UILayer.Layer)	csv.GetInt32(GetHeadIndex("layer"));
			config.layout	= (MenuLayout)		csv.GetInt32(GetHeadIndex("layout"));
			config.closeOtherType	= (MenuCloseOtherType)	csv.GetInt32(GetHeadIndex("closeOtherType"));
			config.cacheTime		= csv.GetSingle(GetHeadIndex("cacheTime"));

			configs.Add(config.id, config);
		}
	}
}
