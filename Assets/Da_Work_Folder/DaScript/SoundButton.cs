using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Button soundButton;         // The button to click
    public Image buttonImage;          // The button's image component
    public Sprite[] soundSprites;      // Sprites for sound levels (No Sound, Low, Middle, High)
    private int soundLevel = 3;        // Start at the loudest sound level (3 = High/Normal)
    private readonly float[] soundVolumes = { 0f, 0.2f, 0.5f, 1f }; // Volume levels: No, Low, Middle, High (Normal)

    void Start()
    {
        UpdateSoundButton(); // Initialize the button's image and sound level
        soundButton.onClick.AddListener(ChangeSoundLevel); // Add button click listener
    }

    void ChangeSoundLevel()
    {
        // Cycle through sound levels (3 -> 0 -> 1 -> 2 -> 3)
        soundLevel = (soundLevel + 1) % soundSprites.Length;

        // Update the game's volume and the button's image
        UpdateSoundButton();
    }

    void UpdateSoundButton()
    {
        // Set the volume based on the current sound level
        AudioListener.volume = soundVolumes[soundLevel];

        // Change the button's image to match the sound level
        if (buttonImage != null && soundSprites.Length > 0)
        {
            buttonImage.sprite = soundSprites[soundLevel];
        }
    }
}
