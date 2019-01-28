using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        //
        Inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        //슬롯들에 본드 , 열쇠 2가 있으면 다 없애고 마스터 키 생성

    }


    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
            }
            else //가지고 있는 
            {
                slots[i].ClearSlot();
            }
        }
    }
}
