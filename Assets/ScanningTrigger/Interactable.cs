using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionText;
    public bool isInteracted;

    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}
