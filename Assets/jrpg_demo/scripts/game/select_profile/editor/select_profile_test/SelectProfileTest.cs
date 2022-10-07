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
		
		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_selectProfileView = Substitute.For<ISelectProfileView>();

			Container.Bind<ISelectProfileView>().FromInstance(_selectProfileView);

			_selectProfilePresenter = Substitute.ForPartsOf<SelectProfilePresenter>();
			Container.Inject(_selectProfilePresenter);
		}
	}
}