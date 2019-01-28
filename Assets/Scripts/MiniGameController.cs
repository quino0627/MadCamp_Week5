using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{
    public Button[] buttonList;

    public static MiniGameController minigame;

    public GameObject gameOverPanel;
    public Text gameOverText;
    public int ran;
    Sprite IL, GA;

    public static bool result;
    
    /*FULLHP = Resources.Load<Sprite>("suit_life_meter_2");      //FULL
        LESSHP = Resources.Load<Sprite>("suit_life_meter_0");    //-1
        LESSERHP = Resources.Load<Sprite>("suit_life_meter_3");  //-2
        NOHP = Resources.Load<Sprite>("suit_life_meter_1");*/   

    private void Awake()
    {
        IL = Resources.Load<Sprite>("il");
        GA = Resources.Load<Sprite>("ga");
        Debug.Log(IL);
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        ran = UnityEngine.Random.Range(0, 3);
        switch (ran)
        {
            case 0:
                caseOneSetting();
                break;
            case 1:
                caseTwoSetting();
                break;
            case 2:
                caseThreeSetting();
                break;
            default:
                Debug.Log("CANT COME HERE");
                break;
        }
        Debug.Log("랜덤값은 "+ran);
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
        /*
        if (buttonList[0].transform.localEulerAngles.z == 270)
        {
            isWin = true;
            Debug.Log("in the IF");
            //TODO
            GameOver(isWin);
        }
        */
        switch (ran)
        {
            case 0:
                if (caseOneEnd())
                {
                    isWin = true;
                    GameOver(isWin);
                }
                break;
            case 1:
                if (caseTwoEnd())
                {
                    isWin = true;
                    GameOver(isWin);
                }
                break;
            case 2:
                if (caseThreeEnd())
                {
                    isWin = true;
                    GameOver(isWin);
                }
                break;
            default:
                Debug.Log("CANT COME HERE");
                break;
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

        if (isWin == true)
            SinkClick.result = true;
        else
            SinkClick.result = false;

        GameManager.gamemanage.ResumeGame();

    }

    void ChangeSides()
    {
  //      playerSide = (GetPlayerSide == "X") ? "O" : "X";
    }

    void caseOneSetting()
    {
        Debug.Log("ASDF");
        buttonList[0].GetComponent<Image>().sprite = GA;
        buttonList[1].GetComponent<Image>().sprite = IL;
        buttonList[2].GetComponent<Image>().sprite = GA;
        buttonList[3].GetComponent<Image>().sprite = GA;
        buttonList[4].GetComponent<Image>().sprite = IL;
        buttonList[5].GetComponent<Image>().sprite = GA;
        buttonList[6].GetComponent<Image>().sprite = GA;
        buttonList[7].GetComponent<Image>().sprite = IL;
        buttonList[8].GetComponent<Image>().sprite = IL;

    }

    void caseTwoSetting()
    {
        Debug.Log("ASDF");
        buttonList[0].GetComponent<Image>().sprite = IL;
        buttonList[1].GetComponent<Image>().sprite = GA;
        buttonList[2].GetComponent<Image>().sprite = IL;
        buttonList[3].GetComponent<Image>().sprite = GA;
        buttonList[4].GetComponent<Image>().sprite = IL;
        buttonList[5].GetComponent<Image>().sprite = GA;
        buttonList[6].GetComponent<Image>().sprite = IL;
        buttonList[7].GetComponent<Image>().sprite = GA;
        buttonList[8].GetComponent<Image>().sprite = GA;
    }

    void caseThreeSetting()
    {

        buttonList[0].GetComponent<Image>().sprite = GA;
        buttonList[1].GetComponent<Image>().sprite = GA;
        buttonList[2].GetComponent<Image>().sprite = IL;
        buttonList[3].GetComponent<Image>().sprite = GA;
        buttonList[4].GetComponent<Image>().sprite = GA;
        buttonList[5].GetComponent<Image>().sprite = GA;
        buttonList[6].GetComponent<Image>().sprite = GA;
        buttonList[7].GetComponent<Image>().sprite = IL;
        buttonList[8].GetComponent<Image>().sprite = IL;
    }

    bool caseOneEnd()
    {
        if (buttonList[0].transform.localEulerAngles.z == 90 &&

            (buttonList[1].transform.localEulerAngles.z == 0 ||
            buttonList[1].transform.localEulerAngles.z == 180)

            &&

            buttonList[2].transform.localEulerAngles.z == 270 &&
            (buttonList[3].transform.localEulerAngles.z == 0 ||
            buttonList[3].transform.localEulerAngles.z == 180) 
            &&
            (buttonList[4].transform.localEulerAngles.z == 0 ||
            buttonList[4].transform.localEulerAngles.z == 180) 
            &&
            buttonList[5].transform.localEulerAngles.z == 180 &&
            buttonList[6].transform.localEulerAngles.z == 90 &&

            (buttonList[7].transform.localEulerAngles.z == 0 ||
            buttonList[7].transform.localEulerAngles.z == 180)

            &&
            (buttonList[8].transform.localEulerAngles.z == 0 ||
            buttonList[8].transform.localEulerAngles.z == 180)
            ) { return true; }
        return false;

    }

    bool caseTwoEnd()
    {
        if ((buttonList[0].transform.localEulerAngles.z == 90 ||
            buttonList[0].transform.localEulerAngles.z == 270) &&
           buttonList[3].transform.localEulerAngles.z == 90 &&
            (buttonList[4].transform.localEulerAngles.z == 0 ||
            buttonList[4].transform.localEulerAngles.z == 180)
            &&
            buttonList[5].transform.localEulerAngles.z == 270 &&
            buttonList[8].transform.localEulerAngles.z == 90 
            
            ) { return true; }
        return false;
    }

    bool caseThreeEnd()
    {
        if (buttonList[0].transform.localEulerAngles.z == 90 &&

  
            buttonList[1].transform.localEulerAngles.z == 270

            &&

         
            (buttonList[3].transform.localEulerAngles.z == 0 ||
            buttonList[3].transform.localEulerAngles.z == 180)
            &&
            buttonList[4].transform.localEulerAngles.z == 180 
          
            &&
         


            buttonList[6].transform.localEulerAngles.z == 90 &&



            (buttonList[7].transform.localEulerAngles.z == 0 ||
            buttonList[7].transform.localEulerAngles.z == 180)

            &&
            (buttonList[8].transform.localEulerAngles.z == 0 ||
            buttonList[8].transform.localEulerAngles.z == 180)
            ) { return true; }
        return false;
    }

}
