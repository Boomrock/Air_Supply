using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public OxygenRegulation oxygenRegulation;
    public Inventory inventory;
    public State CurrentState;
    private bool CourutineIsStart = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = State.Idle;
    }

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
            StartCoroutine( UseOxygen());
        }

        animator.SetFloat("horizontalMovement", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("verticalMovement", Input.GetAxis("Vertical"));
    }

    private IEnumerator UseOxygen()
    {
        CourutineIsStart = true;
        inventory.CountResources[(int)Resorсes.Oxygen]--;
        oxygenRegulation.CurOxygen = oxygenRegulation.MaxOxygen / 2 + 2;
        yield return new  WaitForSeconds(1);
        CourutineIsStart = false;

    }
}
public enum State
{
    Idle,
    Run,
    Death
}
