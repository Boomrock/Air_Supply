using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenRegulation : MonoBehaviour
{

    public int MaxOxygen = 10;
    public int CurOxygen = 10;
    public bool PlayerInZone = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if(collision.transform.tag == "OxygenZone")
        {
            PlayerInZone = true;
            StartCoroutine(CoroutineInZone());
        }               
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "OxygenZone")
        {
            PlayerInZone = false;

            StartCoroutine(CoroutineOutZone());
        }
    }

    IEnumerator CoroutineInZone()
    {
        for (; CurOxygen < MaxOxygen && PlayerInZone; CurOxygen++) 
        {
            yield return new WaitForSeconds(0.3f);
        }
 
    }

    IEnumerator CoroutineOutZone()
    {
        for (; CurOxygen > 0 && !PlayerInZone; CurOxygen--)
        {
            yield return new WaitForSeconds(1f);

        }
    }
}
