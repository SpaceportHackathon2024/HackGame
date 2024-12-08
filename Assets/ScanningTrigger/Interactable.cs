using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactionText;

    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);
    }
}
