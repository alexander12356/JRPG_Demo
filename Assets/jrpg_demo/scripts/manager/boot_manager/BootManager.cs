using JRPG.System.Profile;

using UnityEngine;

using Zenject;

namespace JRPG.Manager.Boot
{
	public class BootManager : MonoBehaviour
	{
		[Inject] private IProfileSystem _profileSystem = null;

		private void Start()
		{
			_profileSystem.LoadProfileList();
		}
	}
}