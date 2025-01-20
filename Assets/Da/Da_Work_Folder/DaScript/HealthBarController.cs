using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
    [Header("Health Settings")]
    [Range(0, 5)] public int health = 5;  // Health value from 5 (full) to 0 (empty)
    public int damageAmount = 1;          // Damage dealt by enemies

    [Header("UI Elements")]
    public Image healthBarImage;          // Reference to the health bar Image

    [Header("Animation")]
    public Animator playerAnimator;       // Reference to the player's Animator
    public float deathDelay = 1.5f;       // Time to wait before switching scenes

    private bool isDead = false;          // Prevent repeated death logic

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
        healthBarImage.fillAmount = Mathf.Clamp01(health / 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy") && !isDead)
        {
            TakeDamage(damageAmount);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0); // Prevent health from going below 0
        UpdateHealthBar();

        if (health <= 0 && !isDead)
        {
            TriggerDeath();
        }
    }

    private void TriggerDeath()
    {
        isDead = true; // Ensure this logic runs only once
        Debug.Log("Player is dead!");

        // Trigger the death animation
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isdead", true);
        }

        // Delay the scene change to allow the death animation to play
        Invoke(nameof(ChangeToDeathScene), deathDelay);
    }

    private void ChangeToDeathScene()
    {
        SceneManager.LoadScene(9); // Load Scene 9
    }
}
