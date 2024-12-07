using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionText;

    public void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}
