using System.Threading.Tasks;

using JRPG.Data.Scene;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace JRPG.Controller.Scene
{
	public class SceneController : MonoBehaviour, ISceneController
	{
		public async Task<SceneEnumData> LoadScene(SceneEnumData scene)
		{
			var op =  UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene.ToString().ToLower(), LoadSceneMode.Additive);

			while (!op.isDone)
			{
				await Task.Yield();
			}

			return scene;
		}

		public async Task<SceneEnumData> HideScene(SceneEnumData scene)
		{
			var op = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene.ToString().ToLower());

			while (!op.isDone)
			{
				await Task.Yield();
			}

			return scene;
		}
	}
}