using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject objectToDisable; // The GameObject to disable after 5 seconds
    public GameObject objectToActivateFor10Sec; // The GameObject to activate for 10 seconds

    private void Start()
    {
        // Ensure the objectToDisable is active at the start
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(true); // Assuming it should start active
        }

        // Ensure the objectToActivateFor10Sec is inactive at the start
        if (objectToActivateFor10Sec != null)
        {
            objectToActivateFor10Sec.SetActive(false); // Ensure it's inactive initially
        }

        // Start the sequence of actions
        Invoke("DeactivateObjectToDisable", 5f); // Disable objectToDisable after 5 seconds
        Invoke("ActivateFor10Seconds", 5f); // Activate objectToActivateFor10Sec after 5 seconds
    }

    private void DeactivateObjectToDisable()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
            Debug.Log($"Object {objectToDisable.name} is now inactive.");
        }
    }

    private void ActivateFor10Seconds()
    {
        if (objectToActivateFor10Sec != null)
        {
            objectToActivateFor10Sec.SetActive(true);
            Debug.Log($"Object {objectToActivateFor10Sec.name} is now active for 10 seconds.");

            // Use Invoke to deactivate it after 10 seconds
            Invoke("DeactivateObjectToActivateFor10Sec", 10f);
        }
    }

    private void DeactivateObjectToActivateFor10Sec()
    {
        if (objectToActivateFor10Sec != null)
        {
            objectToActivateFor10Sec.SetActive(false);
            Debug.Log($"Object {objectToActivateFor10Sec.name} is now inactive after 10 seconds.");
        }
    }
}
