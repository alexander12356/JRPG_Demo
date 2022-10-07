using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;

namespace JRPG.System.Profile
{
	public interface IProfileSystem
	{
		Task<List<IProfileMarkData>> LoadProfileList();
		void LoadProfile(int i);
	}
}
