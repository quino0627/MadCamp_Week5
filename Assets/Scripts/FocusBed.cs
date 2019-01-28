using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FocusBed : Interactable
{
    private Camera bedCamera;

    // Start is called before the first frame update
    void Start()
    {
        bedCamera = GetComponentInChildren<Camera>();
    }

    public override void Interact()
    {
        GameManager.gamemanage.ChangeCamera(bedCamera);
    }
}
