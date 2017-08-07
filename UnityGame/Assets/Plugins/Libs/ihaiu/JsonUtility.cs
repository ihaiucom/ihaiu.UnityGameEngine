#if UNITY_4_7
using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class JsonUtility : MonoBehaviour 
{
	public static string ToJson(object obj, bool isFormat)
	{
		return JsonConvert.SerializeObject (obj, isFormat ? Formatting.Indented : Formatting.None);
	}

	public static T FromJson<T>(string json)
	{
		return JsonConvert.DeserializeObject<T> (json);
	}
}
#endif
