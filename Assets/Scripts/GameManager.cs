using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanage;
    
    private Camera mainCam;
    private Camera currentCam;
    private bool isMainCamActivated;
    public LayerMask movementMask;
    
    public FirstPersonController fpsController;
    private bool currentState = true;

    /* For curtain mission. */
    public GameObject curtainKey;
    public static bool curtainActivated;
    public static int curtainCount;

    public GameObject masterKey;
    public GameObject seObject;

    // Start is called before the first frame update
    void Start()
    {
        gamemanage = this;
        fpsController = GameObject.Find("Player").GetComponent<FirstPersonController>();
        mainCam = GameObject.Find("Player").GetComponentInChildren<Camera>();
        isMainCamActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Inventory.Glue && Inventory.Key1 && Inventory.Key2)
        {
            //TODO
            Debug.Log("따주었어요");
            for (int i = Inventory.items.Count - 1; i >= 0; i--)
            {
                Inventory.Remove(Inventory.items[i]);
            }

            Instantiate(seObject);

            masterKey.SetActive(true);

            Inventory.Glue = false;
            Inventory.Key1 = false;
            Inventory.Key2 = false;
        }

        // If Bed Camera is activated, then click to return to main camera.
        if (!isMainCamActivated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetMainCamera();
            }

            return;
        }

        // If Mouse Clicks interactable, then interact.
        if (currentState && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

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
        fpsController.halt = !enable;
        fpsController.m_MouseLook.SetCursorLock(enable);
    }

    public void PauseGame()
    {
        // SceneManager.LoadScene("MiniGameScene");
        currentState = false;
        // 상호작용
        ChangeFPS(false);
        // 마우스 푸는거
        SceneManager.LoadScene("MiniGameScene", LoadSceneMode.Additive);

    }

    public void ResumeGame()
    {
        Invoke("ResumeGameBody", 2.0f);
        // 몇초 후에 저 함수를 실행하는 거
    }

    void ResumeGameBody()
    {
        SceneManager.UnloadSceneAsync("MiniGameScene");
        currentState = true;
        ChangeFPS(true);
    }

    public void ChangeCamera(Camera cam)
    {
        mainCam.enabled = false;
        ChangeFPS(false);
        cam.enabled = true;
        isMainCamActivated = false;
        currentCam = cam;
    }

    void SetMainCamera()
    {
        if (currentCam == null)
            throw new System.Exception("Current camera is missing");

        currentCam.enabled = false;
        ChangeFPS(true);
        mainCam.enabled = true;
        isMainCamActivated = true;
        currentCam = null;
    }
}