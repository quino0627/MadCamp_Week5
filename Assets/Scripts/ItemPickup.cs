using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    private void Start()
    {
        item.itemObject = gameObject;
    }

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.Add(item);
        gameObject.SetActive(false);
    }
}
