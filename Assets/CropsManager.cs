using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Crops
{

}

public class CropsManager : MonoBehaviour
{
    [SerializeField] TileBase plowed;
    [SerializeField] TileBase seeded;
    [SerializeField] Tilemap targetTileMap;
    Dictionary<Vector2Int, Crops> crops;

    private void Start()
    {
        crops = new Dictionary<Vector2Int, Crops>();
    }

    public bool check(Vector3Int position)
    {
        return crops.ContainsKey((Vector2Int)position);
    }

    public void plow(Vector3Int position)
    {
        if (crops.ContainsKey((Vector2Int)position))
        {
            return;
        }
        createPlowedTile(position);
    }

    public void seed(Vector3Int position)
    {
        targetTileMap.SetTile(position, seeded);
    }

    private void createPlowedTile(Vector3Int position)
    {
        Crops crop = new Crops();
        crops.Add((Vector2Int)position, crop);

        targetTileMap.SetTile(position, plowed);
    }
}
