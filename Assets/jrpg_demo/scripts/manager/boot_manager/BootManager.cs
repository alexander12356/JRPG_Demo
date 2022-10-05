using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;
using JRPG.System.Profile;

using UnityEngine;

using Zenject;

namespace JRPG.Manager.Boot
{
	public class BootManager : MonoBehaviour, IBootManager
	{
		[Inject] private IProfileSystem _profileSystem = null;

		public async void Boot()
		{
			ShowLoading();
			await LoadProfile();
			LoadZenject();
			LoadMainMenu();
			HideLoading();
		}

		public virtual async Task<List<IProfileMarkData>> LoadProfile()
		{
			return await _profileSystem.LoadProfileList();
		}

		public virtual async void ShowLoading()
		{
		}

		public virtual async void HideLoading()
		{
		}

		public virtual async void LoadZenject()
		{
		}

		public virtual async void LoadMainMenu()
		{
		}
	}
}