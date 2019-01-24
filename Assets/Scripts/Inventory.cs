using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> items = new List<Item>();
    
    public delegate void OnItemChanged();
    public static OnItemChanged onItemChangedCallback;

    public static void Add(Item item)
    {
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public static void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
