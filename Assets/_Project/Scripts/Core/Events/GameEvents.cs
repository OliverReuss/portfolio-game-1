using System;

// Class for managing events and triggering them so subscribed elements can react
public static class GameEvents
{
    // System & Game Loop Events
    public static event Action<GameState> OnGameStateChanged;
    public static event Action OnLevelLoaded;

    // Player Stats Events
    public static event Action OnPlayerDied;
    public static event Action<int, int> OnPlayerHealthChanged; // (currentHealth, maxHealth)

    // Trigger Methods (Safe Invocation)
    public static void TriggerGameStateChanged(GameState newState)
    {
        OnGameStateChanged?.Invoke(newState);
    }

    public static void TriggerPlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public static void TriggerPlayerHealthChanged(int current, int max)
    {
        OnPlayerHealthChanged?.Invoke(current, max);
    }

    public static void TriggerLevelLoaded()
    {
        OnLevelLoaded?.Invoke();
    }
}