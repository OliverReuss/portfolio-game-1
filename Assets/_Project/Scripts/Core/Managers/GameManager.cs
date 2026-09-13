using UnityEngine;
using UnityEngine.SceneManagement;

// Class for central game coordination across all scenes
// References other managers and controlls global game states
public class GameManager : MonoBehaviour
{
    // Singleton Access
    public static GameManager Instance { get; private set; }
    public GameState currentState { get; private set; }

    // Reference SubManagers
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private UIManager uiManager;

    // Reference Scenes
    [SerializeField] private string sceneName;

    private void Awake()
    {
        // Enforce Singleton Pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Persist GameManger and SubMangers across all scenes
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        FetchSubManagerReferences();
    }

    private void Start()
    {
        ChangeState(GameState.Boot);
    }

    public void ChangeState(GameState newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;

        switch (newState)
        {
            case GameState.Boot:
                levelManager.LoadInitialSceneAsync(sceneName);
                break;
            case GameState.Gameplay:
                Time.timeScale = 1f;
                break;
            case GameState.Paused:
                Time.timeScale = 0f;
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                break;
        }

        // Broadcast State Change
        GameEvents.TriggerGameStateChanged(newState);
    }

    public void FetchSubManagerReferences()
    {
        if (levelManager == null)
        {
            levelManager = GetComponentInChildren<LevelManager>();
        }
        if (uiManager == null)
        {
            uiManager = GetComponentInChildren<UIManager>();
        }
    }
}