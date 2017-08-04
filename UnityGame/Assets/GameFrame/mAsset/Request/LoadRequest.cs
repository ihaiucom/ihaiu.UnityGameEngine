using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ihaiu
{
	public abstract class AssetRequest : IEnumerator 
	{
		public object Current 
		{
			get 
			{
				return null;
			}
		}

		public bool MoveNext ()
		{
			return !IsDone ();
		}

		public void Reset ()
		{
		}

		abstract public bool Update ();
		abstract public bool IsDone ();


	}
}
