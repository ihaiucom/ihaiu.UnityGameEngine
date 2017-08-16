using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour {

	public Toggle toggle;
	public Text nameLabel;
	public Text ipLabel;
	public Text portLabel;
	public Text stateLabel;
	
	public int index;
	public string name;
	public string ip;
	public int port;
	public int state;



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetData(int index, string name, string ip, int port, int state)
	{
		this.index = index;
		this.name = name;
		this.ip = ip;
		this.port = port;
		this.state = state;

		nameLabel.text = index +  name.Replace ("%s", "");
		ipLabel.text = ip + ":" + port;
		stateLabel.text = state == 1 ? "正常" : "关闭";

	}
}
