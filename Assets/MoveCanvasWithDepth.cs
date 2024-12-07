using UnityEngine;

public class MoveCanvasWithDepth : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private Vector3 initialPosition; // The initial position of the canvas

    void Start()
    {
        // Store the initial position of the canvas
        initialPosition = transform.position;
    }

    void Update()
    {
        // Define the direction: move slightly forward and to the left
        Vector3 direction = new Vector3(0, 0, -1).normalized;

        // Move the canvas in the specified direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
