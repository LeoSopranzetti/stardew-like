using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update()
    {
        if (itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;
                    ItemSpawnManager.instance.spawnItem(worldPosition, itemSlot.item, itemSlot.count);
                    itemSlot.clear();
                    itemIcon.SetActive(false);
                }
            }

        }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if (this.itemSlot.item == null)
        {
            this.itemSlot.copy(itemSlot);
            itemSlot.clear();
        } else
        {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.copy(this.itemSlot);
            this.itemSlot.set(item, count);
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
