using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenRegulation : MonoBehaviour
{
    public Slider slider;
    public int MaxOxigen = 10;
    public int CurOxygen = 10;
    public bool PlayerInZone = true;

    void Update()
    {
        slider.value = (float)CurOxygen / MaxOxigen;
    }
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
        for (; CurOxygen < MaxOxigen && PlayerInZone; CurOxygen++) 
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
        if (CurOxygen <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
