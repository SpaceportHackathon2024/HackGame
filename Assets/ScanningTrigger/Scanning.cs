using UnityEngine;

public class Scanning : Interactable
{
    //public GameObject scanningLevelComponent;
    public int Level;
    public string taskId;
    private GameManager gameManager;


    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        gameManager.CompleteTask(taskId);
    }
}
