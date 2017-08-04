using UnityEngine;
using System.Collections;

public class TestLoger : MonoBehaviour {

	void Start () 
	{
		Loger.Log ("Hello");

		
		Loger.LogFormat ("Hello{0}", 11);
	}

	void Update ()
	{
	
	}
}
