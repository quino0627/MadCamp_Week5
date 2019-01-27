using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public Camera cam;
    public LayerMask movementMask;

    public GameObject player;

    public FirstPersonController fpsController;
    private bool currentState = true;

    public GameObject curtainKey;

    /* For curtain mission. */
    public static bool curtainActivated;
    public static int curtainCount;

    // Start is called before the first frame update
    void Start()
    {
        fpsController = GameObject.Find("Player").GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If Mouse Clicks interactable, then interact.
        if (currentState && Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 10, movementMask))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = !currentState;
            ChangeFPS(currentState);
        }

        if (!curtainActivated && curtainCount >= 5)
        {
            curtainActivated = true;
            curtainKey.SetActive(true);
        }
    }

    public void ChangeFPS(bool enable)
    {
        fpsController.m_MouseLook.SetCursorLock(enable);
    }
}
