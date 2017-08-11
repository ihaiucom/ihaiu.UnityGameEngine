using UnityEngine;
using System.Collections;
using com.ihaiu;
using System.Security.Cryptography;
using System.Text;

namespace Games
{
    public class GameLaunch : MonoBehaviour 
	{
		private static bool 	LOG_OPEN 	= true;
		private static string 	LOG_TAG 	= "GameLaunch";
		void Awake()
		{
			StartCoroutine(Install());
		}


		IEnumerator Install()
		{
			Loger.Log (LOG_OPEN, LOG_TAG, "GameLaunch.Install Begin");

			yield return StartCoroutine ( Game.Install (gameObject) );
			//Game.cricle.Show ();

			Game.InitLuaEnvVersion ();


			Loger.Log (LOG_OPEN, LOG_TAG, "GameLaunch.Install End");
			yield return null;
		}

		void Update()
		{
			Game.Update ();
		}
		
		void OnDestroy()
		{
			Game.OnDestroy ();
		}
		
		
	}
}