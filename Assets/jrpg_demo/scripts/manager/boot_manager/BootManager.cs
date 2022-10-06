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
			var loadingTask = ShowLoading();
			Log("Start show loading");
			await LoadProfile();
			Log("Profile loaded");
			await loadingTask;
			Log("Complete show loading");
			LoadMainMenu();
			Log("Start load main menu");
			HideLoading();
			Log("Hide load main menu");
		}

		public virtual async Task<List<IProfileMarkData>> LoadProfile()
		{
			return await _profileSystem.LoadProfileList();
		}

		public virtual async Task<SceneEnumData> ShowLoading()
		{
			await _sceneManager.LoadScene(SceneEnumData.Loading);
			return SceneEnumData.Loading;
		}

		public virtual async void HideLoading()
		{
		}

		public virtual async void LoadMainMenu()
		{
		}

		private void Log(string text)
		{
			Debug.Log($"<color=green>[Boot] {text}</color>");
		}
	}
}