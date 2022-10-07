using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;
using JRPG.Data.Scene;
using JRPG.Controller.Scene;
using JRPG.System.Profile;

using NSubstitute;

using NUnit.Framework;

using Zenject;

namespace JRPG.Controller.Boot
{
	[TestFixture]
	public class BootControllerTest : ZenjectUnitTestFixture
	{
		private BootController _bootController = null;
		private IProfileSystem _profileSystem = null;
		private ISceneController _sceneController = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_profileSystem = Substitute.For<IProfileSystem>();
			_sceneController = Substitute.For<ISceneController>();

			Container.Bind<IProfileSystem>().FromInstance(_profileSystem);
			Container.Bind<ISceneController>().FromInstance(_sceneController);

			_bootController = Substitute.ForPartsOf<BootController>();
			Container.Inject(_bootController);
			
		}

		[Test]
		public void Should_CallWithCorrectOrder_When_Boot()
		{
			_bootController.Boot();
			Received.InOrder(() =>
			{
				_bootController.ShowLoading();
				_bootController.LoadProfile();
				_bootController.LoadMainMenu();
				_bootController.HideLoading();
			});
		}

		[Test]
		public void Should_ReturnProfileList_When_LoadProfile()
		{
			var profileList = new List<IProfileMarkData>();
			_profileSystem.LoadProfileList().Returns(Task.FromResult(profileList));

			Assert.AreEqual(profileList, _bootController.LoadProfile().Result);
		}

		[Test]
		public void Should_LoadLoadingScene_When_ShowLoading()
		{
			_bootController.ShowLoading();
			_sceneController.Received().LoadScene(SceneEnumData.loading);
		}

		[Test]
		public void Should_LoadMainMenuScene_When_LoadMainMenu()
		{
			_bootController.LoadMainMenu();
			_sceneController.Received().LoadScene(SceneEnumData.main_menu);
		}

		[Test]
		public void Should_HideLoadingScene_When_HideLoading()
		{
			_bootController.HideLoading();
			_sceneController.Received().HideScene(SceneEnumData.loading);
		}
	}
}