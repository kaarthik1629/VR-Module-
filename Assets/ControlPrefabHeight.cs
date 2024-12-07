using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlPrefabHeight : MonoBehaviour
{
    public float lowerHeight = 0f; // The lower position of the prefab
    public float upperHeight = 5f; // The height the prefab will move to when the button is pressed
    public float speed = 2f; // The speed at which the prefab moves

    private bool isMovingUp = false; // Flag to check if the prefab is moving up
    private Vector3 targetPosition; // The target position the prefab is moving towards

    private InputDevice leftController;  // Left controller
    private InputDevice rightController; // Right controller

    void Start()
    {
        // Set the initial position to the lower height
        targetPosition = new Vector3(transform.position.x, lowerHeight, transform.position.z);

        // Get the input devices for left and right controllers
        InitializeControllers();
    }

    void Update()
    {
        // Check if the controllers are valid
        if (!leftController.isValid && !rightController.isValid)
        {
            Debug.Log("Controllers are not valid. Reinitializing...");
            InitializeControllers();
        }

        // Check if the user is pressing the grip button on either controller
        if (IsButtonPressed(leftController, InputHelpers.Button.Grip) || IsButtonPressed(rightController, InputHelpers.Button.Grip))
        {
            if (!isMovingUp)
            {
                Debug.Log("Grip button pressed, moving up");
                isMovingUp = true;
                targetPosition = new Vector3(transform.position.x, upperHeight, transform.position.z);
            }
        }
        else
        {
            if (isMovingUp)
            {
                Debug.Log("Grip button released, moving down");
                isMovingUp = false;
                targetPosition = new Vector3(transform.position.x, lowerHeight, transform.position.z);
            }
        }

        // Smoothly move the prefab towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void InitializeControllers()
    {
        // Attempt to get the left and right controllers
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        var rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (leftHand.isValid)
        {
            leftController = leftHand;
            Debug.Log("Left controller initialized.");
        }

        if (rightHand.isValid)
        {
            rightController = rightHand;
            Debug.Log("Right controller initialized.");
        }
    }

    // Check if a specific button is pressed on a given controller
    private bool IsButtonPressed(InputDevice device, InputHelpers.Button button)
    {
        if (device.isValid)
        {
            bool isPressed;
            if (device.TryGetFeatureValue(CommonUsages.gripButton, out isPressed))
            {
                return isPressed;
            }
        }
        return false;
    }
}
