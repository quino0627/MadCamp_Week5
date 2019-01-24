using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.Add(item);
        DestroyImmediate(gameObject);
    }
}
