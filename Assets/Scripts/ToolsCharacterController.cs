using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapReadController tileMapReadController;
    Vector3Int selectedTile;
    bool selectable;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] CropsManager cropsManager;
    [SerializeField] TileData plowableTiles;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        selectTile();
        canSelecCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            useToolGrid();
        }
    }

    private void selectTile()
    {
        selectedTile = tileMapReadController.getGridPositions(Input.mousePosition, true);
    }

    private void canSelecCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.show(selectable);

    }

    public void Marker()
    {
        markerManager.markedCell = selectedTile;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rigidbody2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                return true; ;
            }
        }
        return false;
    }

    private void useToolGrid()
    {

        if(selectable == true)
        {
            TileBase tileBase = tileMapReadController.getTileBase(selectedTile);
            TileData tileData = tileMapReadController.getTileData(tileBase);

            if (tileData != plowableTiles){return;}

            if (cropsManager.check(selectedTile))
            {
                cropsManager.seed(selectedTile);
            } else
            {
                cropsManager.plow(selectedTile);
            }

        }
    }
}
