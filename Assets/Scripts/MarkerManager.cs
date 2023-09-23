using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTileMap;
    [SerializeField] TileBase tile;
    public Vector3Int markedCell;
    private Vector3Int oldCellPosition;
    bool showBool;

    private void Update()
    {
        if(showBool == false) { return; }
        targetTileMap.SetTile(oldCellPosition, null);
        targetTileMap.SetTile(markedCell, tile);
        oldCellPosition = markedCell;

    }

    internal void show(bool selectable)
    {
        showBool = selectable;
        targetTileMap.gameObject.SetActive(showBool);


    }
}
