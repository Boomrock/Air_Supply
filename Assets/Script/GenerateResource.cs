using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GenerateResource : MonoBehaviour
{
    // Start is called before the first frame update
    public int[,] Map;
    public Vector3 sizeMoonBase;
    public Transform CenterMoonBase;
    public Tile[] Tiles;
    public Tilemap tilemap;
    public int SizeX = 10, SizeY = 10;
    void Start()
    {
        GenerateResources();

    }
    void GenerateResources()
    {
        Map = new int[SizeX, SizeY];
        int r = Random.Range(0, 10000);
        transform.position = new Vector3( - SizeX/2 ,  - SizeY / 2,0);
        tilemap.ClearAllTiles();
        tilemap.size = new Vector3Int(SizeX, SizeY, 0);
        Vector3 top = CenterMoonBase.position + sizeMoonBase/2;
        Vector3 down = CenterMoonBase.position - sizeMoonBase/2;
        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                Vector3 cellToWorld = tilemap.CellToWorld(new Vector3Int(x, y, 0));
                if (!((top.x > cellToWorld.x && down.x < cellToWorld.x)&&
                    (top.y > cellToWorld.y && down.y < cellToWorld.y)))
                {

                    float value = Random.Range(0f, 1f);
                    SpawnResource(y, x, value);
                }

            }
        }

        
    }

    private void SpawnResource(int y, int x, float value)
    {

        Map[x, y] = -1;

        if (value > 0.9f)
        {
            var element = Random.Range(0, 5);
            tilemap.SetTile(new Vector3Int(x, y, 0), Tiles[element]);
            
            Map[x, y] = element;

        }
    }

}
enum Resorсes
{
    Stone, 
    Glass,
    Organic,
    Oxigen,
    Metal

}
