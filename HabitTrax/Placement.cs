using UnityEngine;
using UnityEngine.Tilemaps;

public class Placement : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    [SerializeField]
    Tilemap mainTilemap;
    [SerializeField]
    GameObject player;

    public string activeItem = "";

    public void RenderTick()
    {
        Vector3 cursorPos = Input.mousePosition;
        Vector3Int tilePos = TilePos(cam.ScreenToWorldPoint(cursorPos));

        if (Input.GetMouseButtonDown(0))
        {
            if (activeItem != "" && mainTilemap.GetTile(tilePos) == null)
            {
                Tile tile = StringToTile(activeItem);
                mainTilemap.SetTile(tilePos, tile);
                Player.inventory[activeItem] = 2;
                activeItem = "";
                GetComponent<InventoryMenu>().UpdateButtons();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (activeItem == "" && mainTilemap.GetTile(tilePos) != null)
            {
                string item = TileToString(mainTilemap.GetTile<Tile>(tilePos));
                mainTilemap.SetTile(tilePos, null);
                Player.inventory[item] = 1;
                GetComponent<InventoryMenu>().UpdateButtons();
            }
        }
    }


    Vector3Int TilePos(Vector3 vec)
    {
        return new Vector3Int(Mathf.FloorToInt(vec.x), Mathf.FloorToInt(vec.y), 0);
    }


    public void SetActive(string item)
    {
        activeItem = item;
    }

    public Tile StringToTile(string str)
    {
        Tiles tiles = GetComponent<Tiles>();
        switch (str)
        {
            case "crate":
                return tiles.crate;
            case "bed":
                return tiles.bed;
            case "shelf":
                return tiles.shelf;
            case "petBed":
                return tiles.petBed;
            case "table":
                return tiles.table;
            case "rug":
                return tiles.rug;
            case "nightstand":
                return tiles.nightstand;
            case "bookshelf":
                return tiles.bookshelf;
            default:
                return null;
        }
    }

    public string TileToString(Tile tile)
    {
        Tiles tiles = GetComponent<Tiles>();

        if  (tile = tiles.crate)
        {
            return "crate";
        }
        if (tile = tiles.bed)
        {
            return "bed";
        }
        if (tile = tiles.shelf)
        {
            return "shelf";
        }
        if (tile = tiles.petBed)
        {
            return "petBed";
        }
        if (tile = tiles.table)
        {
            return "table";
        }
        if (tile = tiles.rug)
        {
            return "rug";
        }
        if (tile = tiles.nightstand)
        {
            return "nightstand";
        }
        if (tile = tiles.bookshelf)
        {
            return "bookshelf";
        }

        return "";
    }
}