using UnityEngine;

public class GhostMode : MonoBehaviour
{
    [SerializeField] private float transparencyLevel = 0.5f; // Transparency level when in ghost mode (0 = fully transparent, 1 = fully opaque)
    [SerializeField] private LayerMask enemyLayer; // Set the layer for enemies
    [SerializeField] private Collider2D playerCollider; // Player's main collider
    [SerializeField] private SpriteRenderer spriteRenderer; // Player's sprite renderer for transparency
    private Color originalColor; // Original color of the sprite
    private bool isGhost = false; // Is the player in ghost mode?

    private void Start()
    {
        // Get original color
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            EnterGhostMode();
        }
        else
        {
            ExitGhostMode();
        }
    }

    private void EnterGhostMode()
    {
        if (isGhost) return; // Already in ghost mode

        isGhost = true;

        // Set transparency
        Color ghostColor = originalColor;
        ghostColor.a = transparencyLevel;
        spriteRenderer.color = ghostColor;

        // Ignore collisions with enemies
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

        // Disable enemy detection of the player
        DisableEnemyDetection();
    }

    private void ExitGhostMode()
    {
        if (!isGhost) return; // Already in normal mode

        isGhost = false;

        // Revert transparency
        spriteRenderer.color = originalColor;

        // Re-enable collisions with enemies
        Physics2D.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);

        // Enable enemy detection of the player
        EnableEnemyDetection();
    }

    private void DisableEnemyDetection()
    {
        // Use FindObjectsByType instead of the deprecated FindObjectsOfType
        var enemies = Object.FindObjectsByType<Enemy_Movement>(FindObjectsSortMode.None);

        foreach (Enemy_Movement enemy in enemies)
        {
            enemy.DisableDetection(); // You need to implement this in the Enemy script
        }
    }

    private void EnableEnemyDetection()
    {
        // Use FindObjectsByType instead of the deprecated FindObjectsOfType
        var enemies = Object.FindObjectsByType<Enemy_Movement>(FindObjectsSortMode.None);

        foreach (Enemy_Movement enemy in enemies)
        {
            enemy.EnableDetection(); // You need to implement this in the Enemy script
        }
    }
}
