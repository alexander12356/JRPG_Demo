using JRPG.Data.Scene;
using JRPG.Game.MainMenu.Presenter;
using JRPG.Game.MainMenu.View;
using JRPG.Manager.Scene;

using NSubstitute;

using NUnit.Framework;

using UnityEngine;

using Zenject;

namespace JRPG.Game.MainMenu
{
	[TestFixture]
	public class MainMenuTest : ZenjectUnitTestFixture
	{
		private MainMenuPresenter _mainMenuPresenter = null;
		private IMainMenuView _mainMenuView = null;
		private ISceneManager _sceneManager = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_mainMenuView = Substitute.For<IMainMenuView>();
			_sceneManager = Substitute.For<ISceneManager>();

			Container.Bind<IMainMenuView>().FromInstance(_mainMenuView);
			Container.Bind<ISceneManager>().FromInstance(_sceneManager);

			_mainMenuPresenter = Substitute.ForPartsOf<MainMenuPresenter>();
			Container.Inject(_mainMenuPresenter);
		}

		[Test]
		public void Should_SubscribeToStartButton_When_Create()
		{
			_mainMenuPresenter.Awake();
			_mainMenuView.Received().OnStartButtonPress += _mainMenuPresenter.StartButtonPressHandler;
		}

		[Test]
		public void Should_UnsubscribeFromStartButton_When_Destroy()
		{
			_mainMenuPresenter.OnDestroy();
			_mainMenuView.Received().OnStartButtonPress -= _mainMenuPresenter.StartButtonPressHandler;
		}

		[Test]
		public void Should_LoadSelectProfileWindow_When_StartButtonPress()
		{
			_mainMenuPresenter.StartButtonPressHandler();
			_sceneManager.Received().LoadScene(SceneEnumData.select_profile);
		}

		[Test]
		public void Should_SubscribeToExitButton_When_Create()
		{
			_mainMenuPresenter.Awake();
			_mainMenuView.Received().OnExitButtonPress += _mainMenuPresenter.ExitButtonPressHandler;
		}

		[Test]
		public void Should_UnsubscribeFromExitButton_When_Create()
		{
			_mainMenuPresenter.OnDestroy();
			_mainMenuView.Received().OnExitButtonPress -= _mainMenuPresenter.ExitButtonPressHandler;
		}

		[Test]
		public void Should_CloseApplication_When_ExitButtonPress()
		{
			_mainMenuPresenter.ExitButtonPressHandler();
			_mainMenuPresenter.Received().Close();
		}
	}
}