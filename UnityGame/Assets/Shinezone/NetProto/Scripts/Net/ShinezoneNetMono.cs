using UnityEngine;
using System.Collections;

public class ShinezoneNetMono : MonoBehaviour 
{
	public ShinezoneNet net;

	void Start () 
	{
	
	}

	void Update () 
	{
		net.Run ();
	}
}
