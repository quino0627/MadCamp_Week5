using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkClick : Interactable
{
    public GameObject water;
    public GameObject key2;
    public static bool result=false;

    public override void Interact()
    {
        OnClick();
    }

    void OnClick()
    {
        // MiniGameController.minigame.GameOver();

        if (result)
        {
            Debug.Log("click!");
            Cursor.visible = true;
            water.SetActive(true);
            Invoke("keyappear", 1.5f);
        }

        else
        {
            Debug.Log("click!");
            Cursor.visible = true;
            water.SetActive(false);
        }
        
    }

    void keyappear()
    {
        key2.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //:P
}
