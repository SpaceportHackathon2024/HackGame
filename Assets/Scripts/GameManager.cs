using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;          // Reference to the player object
    public GameObject pauseMenu;
    public GameObject codexMenu;
    public GameObject tasksMenu;

    public TextMeshProUGUI XText;
    public TextMeshProUGUI YText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI PowerText;

    InputAction pauseAction;
    InputAction codexAction;

    public int playerScore = 0;       // Player's score
    public int currentLevel = 1;      // Current level number
    public bool isPaused = false;     // Game pause state

    public List<GameTask> tasks;

    private void Awake()
    {
        pauseMenu.SetActive(false);
        codexMenu.SetActive(false);
        tasksMenu.SetActive(true);
        pauseAction = InputSystem.actions.FindAction("PauseMenu");
        codexAction = InputSystem.actions.FindAction("CodexMenu");
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
        if(codexAction!=null && codexAction.IsPressed())
        {
            OpenCodexMenu();
            codexAction.Reset();
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
        tasksMenu.SetActive(!isPaused);
        codexMenu.SetActive(false);
    }

    public void OpenCodexMenu()
    {
        if (pauseMenu == null || codexMenu == null) return;
        pauseMenu.SetActive(false);
        codexMenu.SetActive(true);
        tasksMenu.SetActive(false);
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

    /// <summary>
    /// Mark a task as completed by its name.
    /// </summary>
    public void CompleteTask(string taskName)
    {
        foreach (var task in tasks)
        {
            if (task.taskName == taskName && !task.isCompleted)
            {
                task.isCompleted = true;
                //Debug.Log($"Task '{taskName}' completed!");
                CheckLevelCompletion();
                return;
            }
        }
        //Debug.Log($"Task '{taskName}' not found or already completed.");
    }

    public void RoverUpsideDown()
    {
        Debug.Log("Car is now upside down!");
    }

    /// <summary>
    /// Check if all tasks are completed.
    /// </summary>
    private void CheckLevelCompletion()
    {
        foreach (var task in tasks)
        {
            if (!task.isCompleted) return; // Exit if any task is incomplete
        }

        // All tasks are completed
        LevelWon();
    }

    /// <summary>
    /// Handle winning the level.
    /// </summary>
    private void LevelWon()
    {
        //Debug.Log("All tasks completed! Level Won!");
        // Implement level win logic (e.g., transition to next level)
    }
}
