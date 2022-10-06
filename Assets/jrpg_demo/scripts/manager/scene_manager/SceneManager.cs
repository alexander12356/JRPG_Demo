using System.Threading.Tasks;

using JRPG.Data.Scene;

using UnityEngine;

namespace JRPG.Manager.Scene
{
	public class SceneManager : MonoBehaviour, ISceneManager
	{
		public async Task<SceneEnumData> LoadScene(SceneEnumData scene)
		{
			var op =  UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneEnumData.Loading.ToString().ToLower());

			while (!op.isDone)
			{
				await Task.Yield();
			}

			return scene;
		}
	}
}