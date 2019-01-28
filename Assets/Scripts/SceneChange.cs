using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Interactable
{
    public GameObject mini;
    public SceneChange sc;

    public override void Interact()
    {
        Debug.Log("Hi Se");
        Cursor.visible = true;
        GameManager.gamemanage.PauseGame();
    }

    void OnClick()
    {
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
