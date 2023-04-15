using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GenerateResource : MonoBehaviour
{
    // Start is called before the first frame update
    public Tile[] Tiles;
    public Tilemap tilemap;
    public int SizeX = 10, SizeY = 10;
    private int[,] map;
    void Start()
    {
        map = new int[SizeX, SizeY];
        
        GenerateResources();

    }
    void GenerateResources()
    {
        int r = Random.Range(0, 10000);
        transform.position = new Vector3( - SizeX/2 ,  - SizeY / 2,0);
        tilemap.ClearAllTiles();
        tilemap.size = new Vector3Int(10, 10, 0);
        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                var value = Random.Range(0f, 1f);
                SpawnResource(y, x, value);
            }
        }

        
    }

    private void SpawnResource(int y, int x, float value)
    {
        Debug.Log(value);
        if (value > 0.9f)
        {
            tilemap.SetTile(new Vector3Int(x, y, 0), Tiles[0]);

        }
    }
}
