using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnPlayerHealthChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerHealthChanged -= UpdateUI;
    }

    private void UpdateUI(int current, int max)
    {
        // Update slider or UI elements based on current / max health
    }
}