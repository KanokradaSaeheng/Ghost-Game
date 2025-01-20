using UnityEngine;
using UnityEngine.UI;

public class TextBoxHandler : MonoBehaviour
{
    // Reference to the object that needs to be clicked
    public GameObject clickableObject;

    // Reference to the UI Panel (Text Box)
    public GameObject textBox;

    // Reference to the Close Button
    public Button closeButton;

    void Start()
    {
        // Initially hide the text box
        textBox.SetActive(false);

        // Add a listener to the close button to call the ClosePanel method when clicked
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
    }

    void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // If the object clicked is the specified clickable object, show the text box
                if (hit.collider.gameObject == clickableObject)
                {
                    ShowPanel();
                }
            }
        }
    }

    void ShowPanel()
    {
        if (textBox != null)
        {
            textBox.SetActive(true);
        }
    }

    void ClosePanel()
    {
        if (textBox != null)
        {
            textBox.SetActive(false);
        }
    }
}
