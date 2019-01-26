using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject itemObject;

    public virtual void Use()
    {
        // How to use the item?
    }

    public void SpawnItem()
    {
        itemObject.transform.position = GameObject.Find("Player").transform.position;
        itemObject.SetActive(true);
    }
}
