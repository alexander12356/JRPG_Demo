using System;

namespace JRPG.Game.MainMenu.View
{
	public interface IMainMenuView
	{
		event Action OnStartButtonPress;
		event Action OnExitButtonPress;
	}
}