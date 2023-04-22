using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GatheringResorces : MonoBehaviour
{
    public GameObject _Resource;
    public Inventory _Inventory;
    private GameObject player;
    private Tilemap tilemap;
    private int[,] map;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = _Resource.GetComponent<Tilemap>();
        player = transform.gameObject;
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D( Collider2D collider)
    {
        map = _Resource.GetComponent<GenerateResource>().Map;

        if (collider.transform.tag == "Resource")
        {
            GrabTileOnDirection(rigidbody.velocity.normalized);
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        map = _Resource.GetComponent<GenerateResource>().Map;

        if (collider.transform.tag == "Resource")
        {
            GrabTile(rigidbody.velocity.normalized);
        }

    }
    void GrabTile(Vector3 direction)
    {

        float absY = Mathf.Abs(direction.y);
        float absX = Mathf.Abs(direction.x);

        for (float x = -absY; x <= absY; x++)
        {
            for (float y = -absX; y <= absX; y++)
            {

                GrabTileOnDirection(new Vector3(x, y , 0) + direction);
            }
        }
    }
    void GrabTileOnDirection(Vector3 direction)
    {

        Vector3 offsetPos = player.transform.position + direction;
        Vector3Int position = tilemap.WorldToCell(offsetPos);
        if (tilemap.GetTile(position) == null)
            return;
        _Inventory.CountResources[map[position.x, position.y]]++;
        tilemap.SetTile(position, null);
    }
}
