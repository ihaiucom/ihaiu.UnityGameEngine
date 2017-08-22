using UnityEngine;
using System.Collections;

public class ReporterGUI : MonoBehaviour {

	public Reporter reporter ;
	void Awake()
	{
		reporter = gameObject.GetComponent<Reporter>();
	}

	void OnGUI()
	{
		reporter.OnGUIDraw();
	}
}
