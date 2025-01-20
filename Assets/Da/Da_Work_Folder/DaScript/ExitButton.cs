using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void ExitGame()
    {
        // Closes the game if it's a built application
        Application.Quit();

        // Logs to the console for testing in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
