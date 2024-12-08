using MeetAndTalk;
using System.Collections;
using UnityEngine;

public class RouterPathManager : MonoBehaviour
{
    [SerializeField] private Transform routerTransform; // The router object
    [SerializeField] private DialogueManager dialogueManager; // Reference to DialogueManager
    [SerializeField] private DialogueContainerSO nextDialogue; // The next dialogue to start after 30 meters

    private Vector3 startPosition;
    private float traveledDistance;

    private void Start()
    {
        // Initialize starting position and distance
        startPosition = routerTransform.position;
        traveledDistance = 0;

        // Start monitoring the router's path
        StartCoroutine(MonitorRouterDistance());
    }

    private IEnumerator MonitorRouterDistance()
    {
        while (traveledDistance < 30f)
        {
            // Calculate traveled distance
            traveledDistance = Vector3.Distance(startPosition, routerTransform.position);

            // Wait for a short interval before checking again
            yield return new WaitForSeconds(0.1f);
        }

        // Trigger the next dialogue once 30 meters is reached
        if (dialogueManager != null && nextDialogue != null)
        {
            dialogueManager.StartDialogue(nextDialogue);
        }
    }
}
