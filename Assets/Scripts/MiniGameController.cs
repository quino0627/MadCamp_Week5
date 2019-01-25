using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameController : MonoBehaviour
{
    public Button[] buttonList;

    public GameObject gameOverPanel;
    public Text gameOverText;
    
  

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i< buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return "?";
    }



    public void EndGame()//ENDTURN과 같음
        
        //TODO: 타임 제한 추가하기 -> Game over에 parameter추가하여 실패성공여부 전달
    {
        bool isWin;
        Debug.Log(buttonList[0].transform.localEulerAngles.z);
        if(buttonList[0].transform.localEulerAngles.z == 270)
        {
            isWin = true;
            Debug.Log("in the IF");
            //TODO
            GameOver(isWin);
        }
    }


    public void GameOver(bool isWin)
    {
        gameOverPanel.SetActive(true);
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].interactable = false;
        }
        if (isWin)
        {

            gameOverText.text = "SUCCESS!!";
        }
        
    }

    void ChangeSides()
    {
  //      playerSide = (GetPlayerSide == "X") ? "O" : "X";
    }


}
