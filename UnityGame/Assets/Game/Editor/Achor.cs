using UnityEngine;
using System.Collections;
using UnityEditor;

namespace com.ihaiu
{
	public class Achor 
	{

		[MenuItem("Game/Tool UI AchorSelf")]
		[CanEditMultipleObjects]
		public static void AchorSelf()
		{
			Transform[] list =  Selection.transforms;
			foreach(Transform transform in list)
			{
				if(transform is RectTransform)
				{
					UIUtil.AchorSelf((RectTransform) transform);
				}
			}
		}
	}
}