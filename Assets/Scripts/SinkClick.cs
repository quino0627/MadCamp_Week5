using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkClick : Interactable
{
    public GameObject water;
    

    public override void Interact()
    {
        OnClick();
    }

    void OnClick()
    {
        Debug.Log("click!");
        Cursor.visible = true;
        water.SetActive(true);

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
