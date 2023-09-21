﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour

{
    [SerializeField]  ItemContainer inventory;
    [SerializeField]  List<InventoryButton> buttons;

    // Start is called before the first frame update
    private void Start()
    {
        setIndex();
        show();
    }

    private void OnEnable()
    {
        show();
    }


    private void show()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].clean();
            }else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    private void setIndex()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

}
