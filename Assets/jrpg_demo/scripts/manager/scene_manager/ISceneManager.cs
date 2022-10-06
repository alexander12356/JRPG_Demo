using System.Threading.Tasks;

using JRPG.Data.Scene;

namespace JRPG.Manager.Scene
{
	public interface ISceneManager
	{
		Task<SceneEnumData> LoadScene(SceneEnumData loading);
	}
}