using JRPG.Controller.Scene;

using UnityEngine;

using Zenject;

namespace JRPG.Installer.Manager
{
	public class ManagerInstaller : MonoInstaller
	{
		[SerializeField] private SceneController _sceneController = null;
		
		public override void InstallBindings()
		{
			Container.Bind<ISceneController>().FromInstance(_sceneController);
		}
	}
}