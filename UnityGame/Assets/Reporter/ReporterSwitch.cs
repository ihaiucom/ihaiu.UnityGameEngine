using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ReporterSwitch : MonoBehaviour {

	void Start () 
	{
		DontDestroyOnLoad(gameObject);
	}

	public bool	isSimulationMobile		= false;
	public float touchTime 				= 0;
	public float touchVisiableTime 		= 0;
	public bool needValidation 			= false;
	private string PLAYERPREFS_REPORTER = "PLAYERPREFS_REPORTER";

	void Update () 
	{
		if(Application.isMobilePlatform || isSimulationMobile)
        {
            
			if ((Input.touchCount >= 4 || (isSimulationMobile && Input.GetKey(KeyCode.F1) ) ) && Time.time >= touchTime)
            { 
                touchVisiableTime += Time.deltaTime;
                if (touchVisiableTime >= 1)
                {
                    touchTime = Time.time + 1F;
                    touchVisiableTime = 0;

					if (needValidation) 
					{
						if (PlayerPrefs.GetInt (PLAYERPREFS_REPORTER) == 1)
						{
							CheckVisiable ();
						} 
						else 
						{
							passwordTime = 5;
						}

					} 
					else 
					{
						CheckVisiable ();
					}
                }
            }
            else
            {
                touchVisiableTime = 0;
            }
		}
		else
		{
                if (Input.GetKeyDown(KeyCode.F1))
                {
					CheckVisiable ();
                }
 		}
	}

	public 	string password 			= "mtmt";
	private string passwordText 		= "";
	private float passwordTime 			= 0;
	void OnGUI()
	{
		if (passwordTime > 0) 
		{
			passwordText = GUI.TextField (new Rect (0, 0, 100, 50), passwordText);
			if (passwordText == password)
			{
				PlayerPrefs.SetInt (PLAYERPREFS_REPORTER, 1);
				passwordText = "通过";
				Show ();
			}
		}
		passwordTime -= Time.deltaTime;
	}



	private void CheckVisiable()
	{
		if (Visiable)
			Hide ();
		else
			Show ();
	}

	public bool Visiable
	{
		get 
		{
			if(reporterGUI != null)
				return reporterGUI.enabled ;

			return false;
		}
	}

	Reporter 		reporter ;
	ReporterGUI 	reporterGUI ;
	public void Show()
	{
		reporter = gameObject.GetComponent<Reporter>();
		if (reporter == null)
		{
			reporter = gameObject.AddComponent<Reporter> ();
		}


		reporterGUI = gameObject.GetComponent<ReporterGUI>();
		if (reporterGUI == null)
		{
			reporterGUI = gameObject.AddComponent<ReporterGUI> ();
		}
		reporterGUI.reporter = reporter;

		reporter.enabled 	= true;
		reporterGUI.enabled = true;
		reporter.show = true;
	}

	public void Hide()
	{
		if(reporterGUI != null)
			reporterGUI.enabled = false;
	}
}