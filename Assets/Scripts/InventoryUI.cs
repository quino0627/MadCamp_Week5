using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;
    public bool Glue = false;

    public GameObject seObject;

    public AudioSource tickSource;
    // Start is called before the first frame update



    // Start is called before the first frame update
    void Start()
    {
        //
        Inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        //슬롯들에 본드 , 열쇠 2가 있으면 다 없애고 마스터 키 생성

    }

    // Update is called once per frame
    void Update()
    {
        
            if (Inventory.Glue && Inventory.Key1 && Inventory.Key2)
            {
                //TODO
                Debug.Log("따주었어요");
                for (int i = 0; i < slots.Length; i++)
            {
              

                slots[i].ClearSlot();
                Inventory.Glue = false;
                Inventory.Key1 = false;
                Inventory.Key2 = false;
                
            }
            Instantiate(seObject);

        }
        
        


    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.items.Count)
            {
                slots[i].AddItem(Inventory.items[i]);
                Debug.Log("ASSSDDS"+slots[i].item + Inventory.items[i]);
                if(slots[i].item.name == "Glue")
                {
                    Glue = true;
                    Debug.Log("글루 쭈움");
                }
            }
            else //가지고 있는 
            {
               
                slots[i].ClearSlot();
                
            }
        }
    }
}
