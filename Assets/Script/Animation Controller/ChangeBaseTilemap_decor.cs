using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeBaseTilemap_decor : MonoBehaviour
{
    public List<Tile> Tile1 = new List<Tile>();
    public List<Tile> Tile2 = new List<Tile>();
    private Tilemap map;
    private Vector3Int location;
    public Inventory inventory;
    public OxygenRegulation regulation;
    public ChangeBaseGround change;

    void Start()
    {
        map = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.CountResources[0] != 0 && inventory.CountResources[1] != 0 && inventory.CountResources[2] != 0 && inventory.CountResources[3] != 0 && regulation.PlayerInZone)
            {

                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                location = map.WorldToCell(mp);

                var Tile = map.GetTile(location);
                if (Tile == null)
                {
                    return;
                }
                int N = Tile1.FindIndex(i => Tile.Equals(i));
                map.SetTile(location, Tile2[N]);
                for(int i = 0; i < 3; i++)
                {
                    inventory.CountResources[i]--;
                }
                change.CountToWin++;
            }
        }
    }

}

