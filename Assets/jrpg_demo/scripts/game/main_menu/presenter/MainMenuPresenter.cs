using JRPG.Controller.Scene;
using JRPG.Data.Scene;
using JRPG.Game.MainMenu.View;

using UnityEngine;

using Zenject;

namespace JRPG.Game.MainMenu.Presenter
{
	public class MainMenuPresenter : MonoBehaviour, IMainMenuPresenter
	{
		[Inject] private IMainMenuView _mainMenuView = null;
		[Inject] private ISceneController _sceneController = null;

		public void Awake()
		{
			_mainMenuView.OnStartButtonPress += StartButtonPressHandler;
			_mainMenuView.OnExitButtonPress += ExitButtonPressHandler;
		}

		public void OnDestroy()
		{
			_mainMenuView.OnStartButtonPress -= StartButtonPressHandler;
			_mainMenuView.OnExitButtonPress -= ExitButtonPressHandler;
		}

		public void StartButtonPressHandler()
		{
			_sceneController.LoadScene(SceneEnumData.select_profile);
		}

		public void ExitButtonPressHandler()
		{
			Close();
		}

		public virtual void Close()
		{
			Application.Quit();
		}
	}
}