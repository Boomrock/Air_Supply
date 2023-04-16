using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeBaseGround : MonoBehaviour
{
    public List<Tile> Tile1 = new List<Tile>();
    public List<Tile> Tile2 = new List<Tile>();
    private Tilemap map;
    private Vector3Int location;
    public int CountResources = 5;

    void Start()
    {
        map = GetComponent<Tilemap>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (CountResources != 0) 
            {
            
                Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                location = map.WorldToCell(mp);

                var Tile = map.GetTile(location);
                if(Tile == null)
                {
                    return;
                }
                int N = Tile1.FindIndex(i => Tile.Equals(i));
                map.SetTile(location, Tile2[N]);
                CountResources--;
            }
        }
    }
        
}

