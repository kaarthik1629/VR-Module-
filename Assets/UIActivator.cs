using UnityEngine;

public class UIActivator : MonoBehaviour
{
    public GameObject uiElement; // The UI element to activate
    public bool activateOnAwake = true; // Condition to control activation

    void Awake()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(activateOnAwake);
        }
        else
        {
            Debug.LogWarning("UI Element is not assigned in " + gameObject.name);
        }
    }
}
