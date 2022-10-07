using JRPG.Controller.Scene;
using JRPG.Data.Scene;
using JRPG.Game.MainMenu.Presenter;
using JRPG.Game.MainMenu.View;

using NSubstitute;

using NUnit.Framework;

using Zenject;

namespace JRPG.Game.MainMenu
{
	[TestFixture]
	public class MainMenuTest : ZenjectUnitTestFixture
	{
		private MainMenuPresenter _mainMenuPresenter = null;
		private IMainMenuView _mainMenuView = null;
		private ISceneController _sceneController = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_mainMenuView = Substitute.For<IMainMenuView>();
			_sceneController = Substitute.For<ISceneController>();

			Container.Bind<IMainMenuView>().FromInstance(_mainMenuView);
			Container.Bind<ISceneController>().FromInstance(_sceneController);

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
			_sceneController.Received().LoadScene(SceneEnumData.select_profile);
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