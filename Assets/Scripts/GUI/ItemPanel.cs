using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPanel : MonoBehaviour
{
    public ItemContainer inventory;
    public List<InventoryButton> buttons;

    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        setIndex();
        show();
    }

    private void OnEnable()
    {
        show();
    }

    private void FixedUpdate()
    {
        show();
    }


    public void show()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            if (inventory.slots[i].item == null)
            {
                buttons[i].clean();
            }
            else
            {
                buttons[i].Set(inventory.slots[i]);
            }
        }
    }

    private void setIndex()
    {
        for (int i = 0; i < inventory.slots.Count && i < buttons.Count; i++)
        {
            buttons[i].SetIndex(i);
        }
    }

    public virtual void OnClick(int id)
    {

    }
}
