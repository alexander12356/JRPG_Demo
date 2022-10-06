using JRPG.System.Profile;

using UnityEngine;

using Zenject;

namespace JRPG.Installer.System
{
	public class SystemInstaller : MonoInstaller
	{
		[SerializeField] private ProfileSystem _profileSystem = null;
		
		public override void InstallBindings()
		{
			Container.Bind<IProfileSystem>().FromInstance(_profileSystem);
		}
	}
}