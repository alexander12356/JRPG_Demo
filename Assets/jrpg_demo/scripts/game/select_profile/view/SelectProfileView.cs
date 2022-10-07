using System;

using UnityEngine;

namespace JRPG.Game.SelectProfile.View
{
	public class SelectProfileView : MonoBehaviour, ISelectProfileView
	{
		public event Action OnReturnButtonPress;

		public void ReturnButtonPress()
		{
			OnReturnButtonPress?.Invoke();
		}
	}
}