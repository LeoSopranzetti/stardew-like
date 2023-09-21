using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] float timeToLive = 10f;
    public int count = 1;
    public Item item;


    private void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {

        timeToLive -= Time.deltaTime;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }

        float distance = Vector3.Distance(transform.position, player.position);
         
        if(distance > pickupDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed  * Time.deltaTime);

        if (distance < 0.1f)
        {
            if (GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.add(item, count);
            } else
            {
                Debug.LogWarning("no inventory containter attached to the game manager");
            }
            Destroy(gameObject);
        }
    }
}
