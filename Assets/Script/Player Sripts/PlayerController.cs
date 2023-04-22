using Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, Controller.ICharacterController
{
    public Animator animator;
    public OxygenRegulation oxygenRegulation;
    public Inventory inventory;
    private State currentState;
    [SerializeField]
    public State CurrentState
    {
        get => currentState;
        set
        {
            if (currentState != State.Death)
                currentState = value;
        }
    }
#region ICharacterController
    private Action<Transform, Vector2> _move;
    public Action<Transform, Vector2> MoveAlgoritm { get => _move; set => _move = value; }
    public void SetMove(Action<Transform, Vector2> move) => MoveAlgoritm = move;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = State.Idle;
    }
    //void FixedUpdate()
    //{
    //    if (playerController.CurrentState == State.Death)
    //    {
    //        horisontalInput = 0;
    //        verticalInput = 0;
    //        rigidbody.velocity = new Vector2(0, 0);


    //        return;
    //    }

    //    horisontalInput = Input.GetAxis("Horizontal");
    //    verticalInput = Input.GetAxis("Vertical");
    //    rigidbody.velocity = new Vector2(horisontalInput * speed, verticalInput * speed);
    //    if (horisontalInput > 0)
    //    {
    //        Quaternion rot = transform.rotation;
    //        rot.y = 0;
    //        transform.rotation = rot;
    //    }

    //    if (horisontalInput < 0)
    //    {
    //        Quaternion rot = transform.rotation;
    //        rot.y = 180;
    //        transform.rotation = rot;
    //    }

    //}

    private bool CourutineIsStart = false;// не позваляет запускать корутину пока не закончиься прошлая 
    // Update is called once per frame
    void Update()
    {
        if (oxygenRegulation.CurOxygen <= 0 || CurrentState == State.Death)
        {
            CurrentState = State.Death;
            animator.SetBool("isDead", true);
            animator.SetFloat("horizontalMovement", 0);
            animator.SetFloat("verticalMovement", 0);
            return;
        }
        if (Input.GetKey(KeyCode.E) && !CourutineIsStart && inventory.CountResources[(int)Resorсes.Oxygen] > 0)
        {
            StartCoroutine(UseOxygen());
        }

        animator.SetFloat("horizontalMovement", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("verticalMovement", Input.GetAxis("Vertical"));
    }


    private IEnumerator UseOxygen()
    {
        CourutineIsStart = true;
        inventory.CountResources[(int)Resorсes.Oxygen]--;
        oxygenRegulation.CurOxygen = oxygenRegulation.MaxOxygen / 2 + 2;
        yield return new WaitForSeconds(1);
        CourutineIsStart = false;

    }



}
public enum State
{
    Idle,
    Run,
    Death
}
