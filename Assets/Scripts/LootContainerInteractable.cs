using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteractable : Interactable
{

    [SerializeField] GameObject openedChest;
    [SerializeField] GameObject closedChest;
    [SerializeField] bool opened;
    public override void Interact(Character character)
    {
        if (opened == false)
        {
            opened = true;
            closedChest.SetActive(false);
            openedChest.SetActive(true);
        }
    }
}
