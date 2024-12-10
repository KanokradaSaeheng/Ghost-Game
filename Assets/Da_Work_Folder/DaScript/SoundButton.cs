using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundButton : MonoBehaviour
{
    public Button soundButton;            // The button to click
    public Image buttonImage;             // The button's image component
    public Sprite[] soundSprites;         // Sprites for sound levels (No Sound, Low, Middle, High)
    private int soundLevel;               // Current sound level
    private readonly float[] soundVolumes = { 0f, 0.2f, 0.5f, 1f }; // Volume levels: No, Low, Middle, High (Normal)

    private const string SoundLevelKey = "SoundLevel"; // Key for saving sound level in PlayerPrefs

    void Start()
    {
        // Load the saved sound level or set to default if not set
        soundLevel = PlayerPrefs.GetInt(SoundLevelKey, 3); // Default is 3 (High)

        UpdateSoundButton(); // Initialize the button's image and sound level
        soundButton.onClick.AddListener(ChangeSoundLevel); // Add button click listener

        // Ensure sound persists across scenes
        DontDestroyOnLoad(gameObject);

        // Listen to scene changes
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void ChangeSoundLevel()
    {
        // Cycle through sound levels (3 -> 0 -> 1 -> 2 -> 3)
        soundLevel = (soundLevel + 1) % soundSprites.Length;

        // Save the new sound level
        PlayerPrefs.SetInt(SoundLevelKey, soundLevel);
        PlayerPrefs.Save();

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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update the sound button in each scene if necessary
        UpdateSoundButton();
    }

    void OnDestroy()
    {
        // Remove the listener to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
