using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [Header("Health Settings")]
    [Range(0, 5)] public int health = 5;  // Health value from 5 (full) to 0 (empty)

    [Header("UI Elements")]
    public Image healthBarImage;          // Reference to the health bar Image

    void Start()
    {
        UpdateHealthBar();
    }

    void OnValidate()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Convert health (0 to 5) to fill amount (0 to 1)
        healthBarImage.fillAmount = health / 5f;
    }
}
