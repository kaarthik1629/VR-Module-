using UnityEngine;

public class MoveUISpline : MonoBehaviour
{
    public float speed = 5f; // Speed of movement in the UI space
    public float scaleFactor = 0.1f; // Factor for scaling the spline as it moves towards the camera

    private RectTransform splineRectTransform; // The RectTransform of the spline
    private Vector2 initialPosition; // Initial position of the spline
    private float initialScale; // Initial scale to start from

    void Start()
    {
        splineRectTransform = GetComponent<RectTransform>();
        initialPosition = splineRectTransform.anchoredPosition;

        // Starting scale (we assume it's 1 at the start)
        initialScale = splineRectTransform.localScale.x;
    }

    void Update()
    {
        // Simulate the spline moving towards the camera by moving in the screen space
        Vector2 direction = new Vector2(0, 1); // Move vertically in screen space
        splineRectTransform.anchoredPosition = initialPosition + direction * speed * Time.deltaTime;

        // Increase scale to simulate moving towards the user
        float newScale = initialScale + scaleFactor * Time.deltaTime;
        splineRectTransform.localScale = new Vector3(newScale, newScale, 1); // Adjust the scale in X and Y
    }
}
