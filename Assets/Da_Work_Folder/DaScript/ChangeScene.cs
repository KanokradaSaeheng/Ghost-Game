using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // This variable can be set in the Unity Inspector
    [SerializeField]
    private int sceneIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClicktoChange()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
