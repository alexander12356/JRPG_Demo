using JRPG.Controller.Scene;
using JRPG.Data.Scene;
using JRPG.Game.SelectProfile.View;

using UnityEngine;

using Zenject;

namespace JRPG.Game.SelectProfile.Presenter
{
	public class SelectProfilePresenter : MonoBehaviour, ISelectProfilePresenter
	{
		[Inject] private ISelectProfileView _selectProfileView = null;
		[Inject] private ISceneController _sceneController = null;

		public void Awake()
		{
			_selectProfileView.OnReturnButtonPress += ReturnButtonPressHandler;
		}

		public void OnDestroy()
		{
			_selectProfileView.OnReturnButtonPress -= ReturnButtonPressHandler;
		}

		public void ReturnButtonPressHandler()
		{
			_sceneController.HideScene(SceneEnumData.select_profile);
		}
	}
}