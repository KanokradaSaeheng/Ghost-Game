using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TMP_Text displayText;        // Reference to the TextMeshPro component
    public float typingSpeed = 0.05f;   // Time delay between each character
    public AudioSource typingSound;     // AudioSource to play sound for each character

    private string fullText;            // Full text to be displayed

    private void Start()
    {
        // Get the initial text from the TextMeshPro component
        fullText = displayText.text;
        displayText.text = "";
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        foreach (char letter in fullText)
        {
            displayText.text += letter;

            // Play the typing sound if assigned
            if (typingSound)
            {
                typingSound.Play();
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
