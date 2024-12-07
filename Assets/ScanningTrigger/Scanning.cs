using UnityEngine;

public class Scanning : Interactable
{
    public GameObject scanningLevelComponent;
    public int Level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        ScanningLevelManager scanningLevelManager = scanningLevelComponent.GetComponent<ScanningLevelManager>();
        Debug.Log(2);
        scanningLevelManager.StartLevel(Level);
    }
}
