using UnityEngine;

public class KeyDoorHandler : MonoBehaviour
{
    public GameObject door; // Reference to the door object on another floor
    public AudioSource doorOpenAudio; // AudioSource component for the door open sound

    private void OnMouseDown()
    {
        // Check if the player clicks the key object
        if (doorOpenAudio != null)
        {
            doorOpenAudio.Play(); // Play the door open sound
        }

        // Destroy the key object
        Destroy(gameObject);

        // Destroy the door object
        if (door != null)
        {
            Destroy(door);
        }
    }
}
