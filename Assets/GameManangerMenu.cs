using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManagerMenu : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2f;
    public GameObject menu;
    public InputActionProperty showButton;

    public XRRayInteractor rayInteractor; // Reference to the XRRayInteractor
    public XRDirectInteractor directInteractor; // Reference to the XRDirectInteractor

    void Start()
    {
        menu.SetActive(false);

        if (rayInteractor != null)
        {
            rayInteractor.enabled = false; // Disable ray interaction initially
        }

        if (directInteractor != null)
        {
            directInteractor.enabled = true; // Direct interaction enabled initially
        }
    }

    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

            if (menu.activeSelf)
            {
                // Position the menu in front of the player
                menu.transform.position = head.position +
                    new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;

                menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
                menu.transform.forward *= -1;

                if (rayInteractor != null)
                {
                    rayInteractor.enabled = true; // Enable ray interaction
                }

                if (directInteractor != null)
                {
                    directInteractor.enabled = false; // Disable direct interaction
                }
            }
            else
            {
                if (rayInteractor != null)
                {
                    rayInteractor.enabled = false; // Disable ray interaction
                }

                if (directInteractor != null)
                {
                    directInteractor.enabled = true; // Enable direct interaction
                }
            }
        }
    }
}
