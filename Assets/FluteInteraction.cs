using UnityEngine;

public class FluteInteraction : MonoBehaviour
{
    public Transform fluteTransform;  // The flute's transform
    public Transform mouthTransform;  // The mouth's transform
    public float proximityThreshold = 0.3f;  // The distance threshold for "near the mouth"
    public float movementThreshold = 0.1f;  // The threshold for detecting significant left-right movement

    private Vector3 lastFlutePosition;  // Store the last position of the flute

    void Start()
    {
        // Initialize the flute's last position
        lastFlutePosition = fluteTransform.position;
    }

    void Update()
    {
        // Check if the flute is near the mouth
        float distanceToMouth = Vector3.Distance(fluteTransform.position, mouthTransform.position);

        if (distanceToMouth < proximityThreshold)
        {
            // Detect left-right movement of the flute
            if (Mathf.Abs(fluteTransform.position.x - lastFlutePosition.x) > movementThreshold)
            {
                // If flute moves significantly left or right, print the message
                Debug.Log("Music playing");

                // Optionally, you can add more logic here for sound/music playing, etc.
            }
        }

        // Update last flute position for next frame
        lastFlutePosition = fluteTransform.position;
    }
}
