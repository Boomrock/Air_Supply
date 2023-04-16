using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;

public class GatheringResorces : MonoBehaviour
{
    public GameObject Resource;
    private GameObject player;
    private Tilemap tilemap;
    private int[,] map;
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = Resource.GetComponent<Tilemap>();
        player = transform.gameObject;
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        if (collision.transform.tag == "Resource")
        {
            Debug.Log("Enter in if ");
            Vector3Int pos = tilemap.WorldToCell(collision.transform.position);
            tilemap.SetTile(pos, new Tile());
        }
    }
    private void OnTriggerStay2D( Collider2D collider)
    {
        map = Resource.GetComponent<GenerateResource>().Map;

        Debug.Log(collider.transform.tag == "Resource");
        if (collider.transform.tag == "Resource")
        {


            GrabTileOnDirection(rigidbody.velocity.normalized);

        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        map = Resource.GetComponent<GenerateResource>().Map;

        Debug.Log(collider.transform.tag == "Resource");
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
        tilemap.SetTile(position, null);
        tilemap.RefreshTile(position);
        Debug.Log(map[position.x, position.y]);

    }
}
