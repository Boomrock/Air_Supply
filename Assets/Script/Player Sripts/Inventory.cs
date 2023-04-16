using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] CountResources = new int[5]; 
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CountResources.Length; i++)
        {
            CountResources[i] = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
