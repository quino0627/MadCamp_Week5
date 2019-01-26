using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCurtain : Interactable
{
    public GameObject otherCurtain;
    public AudioClip audioClip;

    private void Start()
    {
    }

    public override void Interact()
    {
        GameManager.curtainCount += 1;
        Invoke("ResetCount", 3);

        gameObject.SetActive(false);
        otherCurtain.SetActive(true);
        
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    void ResetCount()
    {
        GameManager.curtainCount = 0;
    }
}
