using JRPG.Controller.Scene;
using JRPG.Data.Scene;
using JRPG.Game.SelectProfile.Presenter;
using JRPG.Game.SelectProfile.View;

using NSubstitute;

using NUnit.Framework;

using Zenject;

namespace JRPG.Game.SelectProfile
{
	[TestFixture]
	public class SelectProfileTest : ZenjectUnitTestFixture
	{
		private SelectProfilePresenter _selectProfilePresenter = null;
		private ISelectProfileView _selectProfileView = null;
		private ISceneController _sceneController = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_selectProfileView = Substitute.For<ISelectProfileView>();
			_sceneController = Substitute.For<ISceneController>();

			Container.Bind<ISelectProfileView>().FromInstance(_selectProfileView);
			Container.Bind<ISceneController>().FromInstance(_sceneController);

			_selectProfilePresenter = Substitute.ForPartsOf<SelectProfilePresenter>();
			Container.Inject(_selectProfilePresenter);
		}

		[Test]
		public void Should_SubscribeToReturnButtonPress_When_Created()
		{
			_selectProfilePresenter.Awake();
			_selectProfileView.Received().OnReturnButtonPress += _selectProfilePresenter.ReturnButtonPressHandler;
		}

		[Test]
		public void Should_UnsubscribeFromReturnButtonPress_When_Destroy()
		{
			_selectProfilePresenter.OnDestroy();
			_selectProfileView.Received().OnReturnButtonPress -= _selectProfilePresenter.ReturnButtonPressHandler;
		}

		[Test]
		public void Should_CloseSelectProfile_When_ReturnButtonPress()
		{
			_selectProfilePresenter.ReturnButtonPressHandler();
			_sceneController.Received().HideScene(SceneEnumData.select_profile);
		}
	}
}