using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Class for loading scenes
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    public void LoadInitialSceneAsync(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    public IEnumerator LoadLevelAsync(string sceneName)
    {
        // Start coroutine for loading scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            // Loading porgress
            yield return null;
        }

        // Scene loaded
        GameManager.Instance.ChangeState(GameState.Gameplay);

        // Broadcast scene change to GameEvents
        GameEvents.TriggerLevelLoaded();
    }

    public void ReloadCurrentLevel()
    {
        // Reaload current scene
    }
}
