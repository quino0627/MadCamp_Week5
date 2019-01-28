using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public AudioClip audioClip;

    public override void Interact()
    {
        OnClick();
    }

    public void OnClick()
    {
        Debug.Log("click!");
        Cursor.visible = true;
        Debug.Log("Door closed");
        
        AudioSource.PlayClipAtPoint(audioClip, transform.position,0.7f);
        // 여기에 if문으로 열쇠합
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
