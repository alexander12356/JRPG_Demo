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

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_mainMenuView = Substitute.For<IMainMenuView>();

			Container.Bind<IMainMenuView>().FromInstance(_mainMenuView);

			_mainMenuPresenter = Substitute.ForPartsOf<MainMenuPresenter>();
			Container.Inject(_mainMenuPresenter);
		}
	}
}