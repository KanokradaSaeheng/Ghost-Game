using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    public int maxHP = 100; // Player's maximum HP
    private int currentHP;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = maxHP; // Initialize HP
    }

    void Update()
    {
        HandleMovement();
        HandleAttack();
        HandleDeath();
    }

    void HandleMovement()
    {
        // Walking animation
        bool isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
        animator.SetBool("isWalking", isWalking);
    }

    void HandleAttack()
    {
        // Left-click to fire bullet
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            animator.SetTrigger("isAttacking");
            // Call your existing bullet firing logic here if it's not already integrated
        }
    }

    void HandleDeath()
    {
        if (currentHP <= 0)
        {
            animator.SetBool("isDead", true);
            // Optional: Disable player controls or trigger game over
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0); // Ensure HP doesn't go below 0
    }
}
