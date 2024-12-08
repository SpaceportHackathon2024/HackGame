using UnityEngine;

public class RoverOrientation : MonoBehaviour
{
    public bool isUpsideDown; // Tracks if the car is currently upside down
    public float detectionThreshold = -0.9f; // Threshold for detecting upside-down state
    public float upsideDownTime = 0f; // Time the car has been upside down
    public float requiredUpsideDownTime = 5f; // Time required to trigger an action
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void Update()
    {
        // Check the dot product between the car's up vector and the world's up vector
        float alignment = Vector3.Dot(transform.up, Vector3.up);

        // Determine if the car is upside down
        bool currentlyUpsideDown = alignment < detectionThreshold;

        if (currentlyUpsideDown)
        {
            // Increment the timer if the car is upside down
            upsideDownTime += Time.deltaTime;

            // Check if the required time has passed
            if (upsideDownTime >= requiredUpsideDownTime && !isUpsideDown)
            {
                isUpsideDown = true; // Trigger the upside-down state
                gameManager.RoverUpsideDown();
            }
        }
        else
        {
            // Reset the timer and state if the car is not upside down
            upsideDownTime = 0f;
            isUpsideDown = false;
        }
    }
}
