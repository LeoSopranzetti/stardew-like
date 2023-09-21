using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    public static ItemSpawnManager instance;

    [SerializeField] GameObject pickUpItemPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void spawnItem(Vector3 position, Item item, int count)
    {
        GameObject o = Instantiate(pickUpItemPrefab, position, Quaternion.identity);
        o.GetComponent<PickupItem>().set(item, count);

    }

}
