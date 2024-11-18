using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    public Transform Player;        // Reference to the player's transform
    public float moveSpeed = 5f;    // Speed at which the enemy moves
    public float stoppingDistance = 2f; // Distance at which enemy stops following the player

    private void Update()
    {
        if (Player == null) return; // If player is not assigned, return

        float distance = Vector3.Distance(transform.position, Player.position);

        // Check if the enemy should move towards the player
        if (distance > stoppingDistance)
        {
            // Calculate direction towards the player
            Vector3 direction = (Player.position - transform.position).normalized;

            // Move the enemy in that direction
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Make the enemy face the player
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
        }
    }
}
