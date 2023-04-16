﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float horisontalInput, verticalInput;
    private Rigidbody2D rigidbody;
    public float speed;
    public AudioSource AudioStep;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.CurrentState == State.Death)
        {
            horisontalInput = 0;
            verticalInput = 0;
            rigidbody.velocity = new Vector2(0,0);


            return;
        }
            
        horisontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector2(horisontalInput * speed , verticalInput * speed);
        if (horisontalInput > 0)
        {
            Quaternion rot = transform.rotation;
            rot.y = 0;
            transform.rotation = rot;
        }

        if (horisontalInput < 0)
        {
            Quaternion rot = transform.rotation;
            rot.y = 180;
            transform.rotation = rot;
        }

    }
    public void StepAudio()
    {


        AudioStep.Play();
    }
}
