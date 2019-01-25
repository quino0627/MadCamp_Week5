using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownScript : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    public GameObject gameControllerObject;
    private MiniGameController gameController;


    private void Start()
    {
        Debug.Log("gameController is " + gameController);
        Debug.Log("mainTimer is " + mainTimer);
        timer = mainTimer;

        gameController = gameControllerObject.GetComponent<MiniGameController>();
    }

    private void Update()
    {
        

        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
            if (gameController.gameOverPanel.active == true)
            {
                canCount = false;
            }

        }
        
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            gameController.gameOverText.text = "FAILED!!";
            gameController.GameOver(false);
        }
    }


}
