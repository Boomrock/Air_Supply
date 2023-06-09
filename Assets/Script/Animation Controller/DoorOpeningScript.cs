﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningScript : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Animator DoorAnimator;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player"){  
            DoorAnimator.SetBool("isDoorOpen", false);
            audio.Play();
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player"){
            audio.Play();
            DoorAnimator.SetBool("isDoorOpen", true);
        }
    }
}
