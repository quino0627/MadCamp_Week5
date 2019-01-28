using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> items = new List<Item>();
    
    public delegate void OnItemChanged();
    public static OnItemChanged onItemChangedCallback;

    public static bool Glue = false;
    public static bool Key1 = false;
    public static bool Key2 = false;

  
    public static void Add(Item item)
    {
        items.Add(item);
        if (item.name == "Glue")
        {
            Glue = true;
            Debug.Log("글루 쭈움");
        }
        if (item.name == "Key")
        {
            Key1 = true;
            Debug.Log("꺼뜬키 쭈움");
        }
        if (item.name == "key2")
        {
            Key2 = true;
            Debug.Log("께임끼 쭈움");
        }


        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public static void Remove(Item item)
    {
        items.Remove(item);

        if (item.name == "Glue")
        {
            Glue = false;
            Debug.Log("글루 찌움");
        }
        if (item.name == "Key")
        {
           Key1 = false;
            Debug.Log("꺼뜬키 찌움");
        }
        if (item.name == "key2")
        {
            Key2 =false;
            Debug.Log("께임끼 뻐림");
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
