using TMPro;
using UnityEngine;

public class TaskDisplay : MonoBehaviour
{
    public TextMeshProUGUI taskListText;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        UpdateTaskList();
    }

    void Update()
    {
        UpdateTaskList();
    }

    /// <summary>
    /// Updates the UI with the task list.
    /// </summary>
    private void UpdateTaskList()
    {
        if (gameManager == null || taskListText == null) return;

        string taskList = "";
        for(int i = 0; i < gameManager.tasks.Count; i++)
        {
            if (!gameManager.tasks[i].isCompleted)
            {
                taskList += $"{i+1}: {gameManager.tasks[i].taskName}\n";
            }
         
        }

        taskListText.text = taskList;
    }
}
