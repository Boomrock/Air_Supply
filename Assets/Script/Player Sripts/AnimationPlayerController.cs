using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("horizontalMovement", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("verticalMovement", Input.GetAxis("Vertical"));
    }
}
