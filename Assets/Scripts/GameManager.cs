using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanage;

    public Camera cam;
    public LayerMask movementMask;

    public FirstPersonController fpsController;
    private bool currentState = true;

    /* For curtain mission. */
    public GameObject curtainKey;
    public static bool curtainActivated;
    public static int curtainCount;

    // Start is called before the first frame update
    void Start()
    {
        gamemanage = this;
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
}