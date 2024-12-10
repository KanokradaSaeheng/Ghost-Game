using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    [Tooltip("Drag and drop the scenes where you want the music to persist.")]
    [SerializeField] private List<SceneAsset> allowedScenes = new List<SceneAsset>();

    private HashSet<string> allowedSceneNames = new HashSet<string>();

    void Awake()
    {
        // Ensure only one instance of the MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PopulateAllowedSceneNames();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Subscribe to the scene change event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void PopulateAllowedSceneNames()
    {
        allowedSceneNames.Clear();
        foreach (var sceneAsset in allowedScenes)
        {
            if (sceneAsset != null)
            {
                allowedSceneNames.Add(sceneAsset.name);
            }
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is not in the allowed scenes list
        if (!allowedSceneNames.Contains(scene.name))
        {
            Destroy(gameObject); // Destroy music if not in allowed scenes
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Clean up event subscription
    }
}
