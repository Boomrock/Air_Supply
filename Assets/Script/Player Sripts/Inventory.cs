using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Класс отвечающий за инвентарь
public class Inventory : MonoBehaviour
{

    public int[] CountResources = new int[5];

    void Start()
    {
        for (int i = 0; i < CountResources.Length; i++)
        {
            CountResources[i] = 0;
        }

    }
}
