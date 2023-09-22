using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{

    [SerializeField] ToolbarController toolbarController;
    int currentSelectedtool;

    private void Start()
    {
        Init();
        toolbarController.onChange += highlight;
        highlight(0);
    }

    public override void OnClick(int id)
    {
        toolbarController.set(id);
        highlight(id);
    }

    public void highlight(int id)
    {
        buttons[currentSelectedtool].highlightSlot(false);
        currentSelectedtool = id;
        buttons[currentSelectedtool].highlightSlot(true);
    }
}
