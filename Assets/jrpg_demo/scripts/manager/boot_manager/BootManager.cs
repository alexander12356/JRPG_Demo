using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;
using JRPG.Data.Scene;
using JRPG.Manager.Scene;
using JRPG.System.Profile;

using UnityEngine;

using Zenject;

namespace JRPG.Manager.Boot
{
	public class BootManager : MonoBehaviour, IBootManager
	{
		[Inject] private IProfileSystem _profileSystem = null;
		[Inject] private ISceneManager _sceneManager = null;

		private void Start()
		{
			Boot();
		}

		public async void Boot()
		{
			Log("Start");

			var loadLoadingScene = ShowLoading();
			var loadingProfile = LoadProfile();
			Log("Start load profile, loading scene");
			await Task.WhenAll(loadLoadingScene, loadingProfile);
			Log("Complete load profile, loading scene");
			var mainMenuLoading = LoadMainMenu();
			Log("Start load main menu");
			await mainMenuLoading;
			Log("Complete load main menu");
			var hideLoadingScene = HideLoading();
			Log("Start hide loading scene");
			await hideLoadingScene;
			Log("Complete hide loading scene");

			Log("Complete");
		}

		public virtual async Task<List<IProfileMarkData>> LoadProfile()
		{
			return await _profileSystem.LoadProfileList();
		}

		public virtual async Task<SceneEnumData> ShowLoading()
		{
			await _sceneManager.LoadScene(SceneEnumData.loading);
			return SceneEnumData.loading;
		}

		public virtual async Task<SceneEnumData> HideLoading()
		{
			await _sceneManager.HideScene(SceneEnumData.loading);
			return SceneEnumData.loading;
		}

		public virtual async Task<SceneEnumData> LoadMainMenu()
		{
			await _sceneManager.LoadScene(SceneEnumData.main_menu);
			return SceneEnumData.main_menu;
		}

		private void Log(string text)
		{
			Debug.Log($"<color=green>[Boot] {text}</color>");
		}
	}
}