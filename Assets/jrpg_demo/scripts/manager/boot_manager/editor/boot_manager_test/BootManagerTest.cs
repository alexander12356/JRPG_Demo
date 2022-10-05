using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;
using JRPG.System.Profile;

using NSubstitute;
using NSubstitute.Extensions;

using NUnit.Framework;

using Zenject;

namespace JRPG.Manager.Boot.Test
{
	[TestFixture]
	public class BootManagerTest : ZenjectUnitTestFixture
	{
		private BootManager _bootManager = null;
		private IProfileSystem _profileSystem = null;

		[SetUp]
		public override void Setup()
		{
			base.Setup();

			_profileSystem = Substitute.For<IProfileSystem>();
			Container.Bind<IProfileSystem>().FromInstance(_profileSystem);

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
				_bootManager.LoadZenject();
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
	}
}