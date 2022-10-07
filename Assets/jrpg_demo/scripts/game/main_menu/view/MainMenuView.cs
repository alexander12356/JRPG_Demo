using System;

using UnityEngine;

namespace JRPG.Game.MainMenu.View
{
	public class MainMenuView : MonoBehaviour, IMainMenuView
	{
		public event Action OnStartButtonPress;
		public event Action OnExitButtonPress;

		public void StartButtonPress()
		{
			OnStartButtonPress?.Invoke();
		}

		public void ExitButtonPress()
		{
			OnExitButtonPress?.Invoke();
		}
	}
}