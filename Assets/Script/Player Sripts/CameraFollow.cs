using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Speed;
    public GameObject Player;
    public GameObject Camera;

    void FixedUpdate()
    {
        Vector3 target = new Vector3()
        {
            x = Player.transform.position.x,
            y = Player.transform.position.y,
            z = -10,
        };
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, target, Speed * Time.fixedDeltaTime);
    }
}
