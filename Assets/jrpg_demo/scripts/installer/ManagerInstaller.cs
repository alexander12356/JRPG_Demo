using JRPG.Manager.Scene;

using UnityEngine;

using Zenject;

namespace JRPG.Installer.Manager
{
	public class ManagerInstaller : MonoInstaller
	{
		[SerializeField] private SceneManager _sceneManager = null;
		
		public override void InstallBindings()
		{
			Container.Bind<ISceneManager>().FromInstance(_sceneManager);
		}
	}
}