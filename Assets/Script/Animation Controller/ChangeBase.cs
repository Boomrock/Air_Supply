using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeBase : MonoBehaviour
{
    public List<Tile> Tile1 = new List<Tile>();
    public List<Tile> Tile2 = new List<Tile>();
    private Tilemap map;
    public Tile tile;
    public Vector3Int location;

    void Start()
    {
        map = GetComponent<Tilemap>();

        Random rnd = new Random();
        //int index = Random.Range(0, 3);
        int index = 1;
        

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            location = map.WorldToCell(mp);

            var Tile = map.GetTile(location);
            Debug.Log(Tile);
            int N = Tile1.FindIndex(i => Tile.Equals(i));
            print(N);
            map.SetTile(location, Tile2[N]);

            if (map.GetTile(location))
            {
                Debug.Log("Tile");
                print(location);
            }
            else
            {
                Debug.Log("No Tile");
            }
        }
    }
        
}

