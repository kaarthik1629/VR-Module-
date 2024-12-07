using UnityEngine;

public class MouthDetection : MonoBehaviour
{
    public Transform mouthTransform;  // The transform of the mouth region
    public float radius = 0.3f;       // The radius of the mouth region for visualization
    public string fluteTag = "Flute"; // Tag for the flute object (ensure the flute has this tag)

    public AudioClip[] musicClips;    // Array of AudioClips to be played
    private AudioSource audioSource;   // AudioSource to play the clips

    private void Start()
    {
        // Optionally add a SphereCollider if not already added
        SphereCollider collider = gameObject.GetComponent<SphereCollider>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
        }

        // Set the collider as a trigger
        collider.isTrigger = true;
        collider.radius = radius;  // Set the radius of the collider to match the Gizmo

        // Add an AudioSource component if it's not already attached
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // This method is used to visualize the mouth region in the Scene view using Gizmos
    void OnDrawGizmos()
    {
        // Check if the mouthTransform is assigned
        if (mouthTransform != null)
        {
            // Set the color for the Gizmo (you can change the color)
            Gizmos.color = Color.green;

            // Draw a sphere at the mouth position with the given radius
            Gizmos.DrawSphere(mouthTransform.position, radius);
        }
    }

    // Detect when the flute enters the mouth region
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with the mouth region is the flute
        if (other.CompareTag(fluteTag))
        {
            // Print and play a random audio clip from the list
            if (musicClips.Length > 0)
            {
                int randomIndex = Random.Range(0, musicClips.Length); // Randomly select a clip
                audioSource.clip = musicClips[randomIndex];           // Set the selected clip to the AudioSource
                audioSource.Play();                                   // Play the audio clip

                Debug.Log("Music Play");
            }
        }
    }

    // Detect when the flute exits the mouth region
    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the mouth region is the flute
        if (other.CompareTag(fluteTag))
        {
            // Stop the music when the flute exits the mouth region
            audioSource.Stop();
            Debug.Log("Music Stopped");
        }
    }
}
