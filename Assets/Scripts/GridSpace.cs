using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{

    public Button button;
    public Text buttonText;
    public string playerSide;

    private MiniGameController gameController;

    public void SetSpace()
    {
        //buttonText.text = gameController.GetPlayerSide();
        //button.interactable = false;
        // Rotate the object around its local X axis at 1 degree per second
        
        this.transform.Rotate(0, 0, 90);

        gameController.EndGame();

    }
    
    public void SetGameControllerReference(MiniGameController controller)
    {
        gameController = controller;
    }

}
