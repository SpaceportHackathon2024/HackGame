using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRadius = 3f; // Interaction range
    public Transform player;            // Player's position
    public GameObject interactionUI;    // UI to display "E" and interaction text
    public TextMeshProUGUI interactionTextUI;      // Text component for interaction text

    private Interactable currentInteractable;

    void Update()
    {
        DetectInteractable();
        HandleInteraction();
    }

    void DetectInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(player.position, interactionRadius);
        currentInteractable = null;
        Debug.Log(colliders.Count());

        foreach (var collider in colliders)
        {
            Interactable interactable = collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                break; // Stop after finding the first interactable
            }
        }

        if (currentInteractable != null)
        {
            Debug.Log("Interactable found: " + currentInteractable.gameObject.name);
            interactionUI.SetActive(true); // Show the UI
            interactionTextUI.text = currentInteractable.interactionText; // Set the unique text
        }
        else
        {
            interactionUI.SetActive(false); // Hide the UI
        }
    }

    void HandleInteraction()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }
}
