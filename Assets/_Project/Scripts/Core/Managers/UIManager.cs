using UnityEngine;


// Class for managing the ui by listening for game state changes
public class UIManager : MonoBehaviour
{
    // Reference UI elements here

    public void OnEnable()
    {
        // Subscribe
        GameEvents.OnGameStateChanged += HandleGameStateChanged;
    }

    public void OnDisable()
    {
        // Unsubscribe
        GameEvents.OnGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Gameplay:
                // Show HUD, hide menu etc.
                break;
            case GameState.Paused:
                // Hide HUD, show menu etc.
                break;
            case GameState.GameOver:
                // Hide HUD, show game over screen
                break;
        }
    }
}