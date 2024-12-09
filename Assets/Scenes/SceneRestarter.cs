using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestarter : MonoBehaviour
{
    private static bool hasRestarted = false; // Static variable to persist across scene loads

    void Start()
    {
        if (!hasRestarted)
        {
            hasRestarted = true; // Mark that we have restarted
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
        }
    }
}
