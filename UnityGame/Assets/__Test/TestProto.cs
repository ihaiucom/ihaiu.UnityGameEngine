using UnityEngine;
using System.Collections;
using System.IO;

public class TestProto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Games.PB.Person person = new Games.PB.Person();
		person.email = "zengfeng75@qq.com";
		person.name = "zengfeng";
		person.id = 1;

		MemoryStream stream = new MemoryStream();
		ProtoBuf.Serializer.Serialize<Games.PB.Person>(stream, person);

		Debug.Log(stream.Length);
		stream.Position = 0;
		person = ProtoBuf.Serializer.Deserialize<Games.PB.Person>(stream);

		Debug.Log(person.email);
		Debug.Log(person.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
