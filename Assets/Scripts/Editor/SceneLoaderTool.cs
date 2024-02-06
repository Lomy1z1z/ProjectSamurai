using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneLoaderTool
{
    [MenuItem("Tools/Load and Play First Scene")]
    private static void LoadAndPlayFirstScene()
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            string scenePath = "Assets/Scenes/Loader.unity";
            EditorSceneManager.OpenScene(scenePath);
            EditorApplication.isPlaying = true;
        }
    }
}
