using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public AudioClip audioClip;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public GameObject overPanel;

    public override void Interact()
    {
        OnClick();
    }

    public void OnClick()
    {
        
        // 여기에 if문으로 열쇠합
        if(Inventory.masterkey == true)
        {

            AudioSource.PlayClipAtPoint(audioClip2, transform.position);
            Invoke("SoundPlay", 2);
           
            Debug.Log("Open");
            overPanel.SetActive(true);
            
        }
        else
        {
            Debug.Log("click!");
            Cursor.visible = true;
            Debug.Log("Door closed");

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.7f);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SoundPlay()
    {
        AudioSource.PlayClipAtPoint(audioClip3, transform.position);
    }

 
}
