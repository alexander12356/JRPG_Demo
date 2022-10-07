using System.Threading.Tasks;

using JRPG.Data.Scene;

namespace JRPG.Controller.Scene
{
	public interface ISceneController
	{
		Task<SceneEnumData> LoadScene(SceneEnumData loading);
		Task<SceneEnumData> HideScene(SceneEnumData loading);
	}
}