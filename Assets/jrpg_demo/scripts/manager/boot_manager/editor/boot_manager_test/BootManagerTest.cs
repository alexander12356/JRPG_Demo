using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;
using JRPG.Data.Scene;
using JRPG.Manager.Scene;
using JRPG.System.Profile;

using NSubstitute;

using NUnit.Framework;

using Zenject;

namespace JRPG.Manager.Boot.Test
{
	[TestFixture]
	public class BootManagerTest : ZenjectUnitTestFixture
	{
		private BootManager _bootManager = null;
		private IProfileSystem _profileSystem = null;
		private ISceneManager _sceneManager = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_profileSystem = Substitute.For<IProfileSystem>();
			_sceneManager = Substitute.For<ISceneManager>();

			Container.Bind<IProfileSystem>().FromInstance(_profileSystem);
			Container.Bind<ISceneManager>().FromInstance(_sceneManager);

			_bootManager = Substitute.ForPartsOf<BootManager>();
			Container.Inject(_bootManager);
			
		}

		[Test]
		public void Should_CallWithCorrectOrder_When_Boot()
		{
			_bootManager.Boot();
			Received.InOrder(() =>
			{
				_bootManager.ShowLoading();
				_bootManager.LoadProfile();
				_bootManager.LoadMainMenu();
				_bootManager.HideLoading();
			});
		}

		[Test]
		public void Should_ReturnProfileList_When_LoadProfile()
		{
			var profileList = new List<IProfileMarkData>();
			_profileSystem.LoadProfileList().Returns(Task.FromResult(profileList));

			Assert.AreEqual(profileList, _bootManager.LoadProfile().Result);
		}

		[Test]
		public void Should_LoadLoadingScene_When_ShowLoading()
		{
			_bootManager.ShowLoading();
			_sceneManager.Received().LoadScene(SceneEnumData.loading);
		}

		[Test]
		public void Should_LoadMainMenuScene_When_LoadMainMenu()
		{
			_bootManager.LoadMainMenu();
			_sceneManager.Received().LoadScene(SceneEnumData.main_menu);
		}

		[Test]
		public void Should_HideLoadingScene_When_HideLoading()
		{
			_bootManager.HideLoading();
			_sceneManager.Received().HideScene(SceneEnumData.loading);
		}
	}
}