using System;

public static class GameEvents
{
    // System & Game Loop Events
    public static event Action<GameState> OnGameStateChanged;

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
}