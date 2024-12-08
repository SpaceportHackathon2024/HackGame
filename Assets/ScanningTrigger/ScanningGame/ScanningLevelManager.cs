using System.Collections.Generic;
using UnityEngine;

public class ScanningLevelManager : MonoBehaviour
{
    public GameObject minigameCanvas;   // Reference to the Minigame Canvas
    public int currentLevel = 1;  // The current level
    public AtomicElementManager elementManager;  // Reference to the ElementManager to manage the grid
    void Start()
    {
        minigameCanvas.SetActive(false);
        //StartLevel(currentLevel);
    }

    public void StartLevel(int level)
    {
        Debug.Log(2);
        // Adjust the available elements based on the level
        if (level == 1)
        {
            // For level 1, only H and He are available
            elementManager.maxElement = 2;
        }
        else if (level == 2)
        {
            // Add more complex elements for level 2
            elementManager.maxElement = 4;
        }
        minigameCanvas.SetActive(true);
        elementManager.PopulateGrid();
    }
}
