using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using JRPG.Data.Profile;

using UnityEngine;

namespace JRPG.System.Profile
{
	public class ProfileSystem : MonoBehaviour, IProfileSystem
	{
		public async Task<List<IProfileMarkData>> LoadProfileList()
		{
			if (!File.Exists(Application.persistentDataPath + "/profileList.json"))
			{
				return null;
			}

			var profileListString = await File.ReadAllTextAsync($"{Application.persistentDataPath}/profileList.json");
			var profileList = JsonUtility.FromJson<List<IProfileMarkData>>(profileListString);

			return profileList;
		}

		public void LoadProfile(int i)
		{
		}
	}
}