using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Games;

public class TestJson : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[ContextMenu("TestToJson")]
	public void TestToJson()
	{
		SettingConfig obj = new SettingConfig ();
		string json = Newtonsoft.Json.JsonConvert.SerializeObject (obj, Newtonsoft.Json.Formatting.Indented);
		Debug.Log (json);

	}
}
