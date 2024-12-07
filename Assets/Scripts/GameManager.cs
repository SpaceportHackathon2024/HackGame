using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;          // Reference to the player object
    public GameObject pauseMenu;


    public TextMeshProUGUI XText;
    public TextMeshProUGUI YText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI PowerText;

    InputAction pauseAction;

    public int playerScore = 0;       // Player's score
    public int currentLevel = 1;      // Current level number
    public bool isPaused = false;     // Game pause state

    private void Awake()
    {
        pauseMenu.SetActive(false);
        pauseAction = InputSystem.actions.FindAction("PauseMenu");
    }

    /// <summary>
    /// Updates the TextMeshPro component with the player's data.
    /// </summary>
    private void UpdatePlayerData()
    {
        float sciencePower = 80f;
        float drivingPower = 200f;
        float communicationPower = 20f;
        float thermalPower = 10f;

        // Get player position
        Vector3 position = player.transform.position;

        var component = player.GetComponent<SCC_Drivetrain>();

        XText.text = $"X: {position.x:F2}";
        YText.text = $"Y: {position.y:F2}";
        SpeedText.text = $"Speed: {component.speed:F2} KM/S";

        int power = (int)(sciencePower + drivingPower + communicationPower + thermalPower + component.speed * 5);
        PowerText.text = $"Power: {power} W";
    }

    private void Update()
    {
        if (player != null)
        {
            UpdatePlayerData();
        }

        // Check for pause/resume
        if (pauseAction!=null && pauseAction.IsPressed())
        {
            TogglePause();
            pauseAction.Reset();
        }
    }

    /// <summary>
    /// Loads a new scene by name.
    /// </summary>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Reloads the current scene.
    /// </summary>
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
    public void LoadNextLevel()
    {
        currentLevel++;
        string nextSceneName = "Level" + currentLevel; // Assumes scenes are named Level1, Level2, etc.
        SceneManager.LoadScene(nextSceneName);
    }

    /// <summary>
    /// Toggles the game's pause state.
    /// </summary>
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1; // 0 = Paused, 1 = Normal Speed
        pauseMenu.SetActive(isPaused);
    }

    /// <summary>
    /// Increments the player's score.
    /// </summary>
    public void AddScore(int points)
    {
        playerScore += points;
    }

    /// <summary>
    /// Resets the game state.
    /// </summary>
    public void ResetGame()
    {
        playerScore = 0;
        currentLevel = 1;
        LoadScene("MainMenu"); // Replace with your main menu scene name
    }
}
