using System.Collections.Generic;
using System.Threading.Tasks;

using JRPG.Data.Profile;

using UnityEngine;

namespace JRPG.System.Profile
{
	public class ProfileSystem : MonoBehaviour, IProfileSystem
	{
		public async Task<List<IProfileMarkData>> LoadProfileList()
		{
			return null;
		}

		public void LoadProfile(int i)
		{
		}
	}
}