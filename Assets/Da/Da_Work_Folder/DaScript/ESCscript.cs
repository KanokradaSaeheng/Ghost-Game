using UnityEngine;

public class ESCscript : MonoBehaviour
{
    public GameObject settingsUI; // Assign the Settings UI panel in the Inspector
    private bool isPaused = false;

    void Update()
    {
        // Toggle pause state when pressing Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Show the settings UI and freeze time
        settingsUI.SetActive(true);
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        // Hide the settings UI and resume time
        settingsUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    // This function is linked to the "Continue" button in the Settings UI
    public void OnContinueButton()
    {
        ResumeGame();
    }
}
