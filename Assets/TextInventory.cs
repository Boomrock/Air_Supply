using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextInventory : MonoBehaviour
{
    public Inventory inventory;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = inventory.CountResources[((int)Resorсes.Stone)] + " :Stone \n" +
                    inventory.CountResources[((int)Resorсes.Glass)] + " :Glass \n" +
                    inventory.CountResources[((int)Resorсes.Organic)] + " :Organic \n" +
                    inventory.CountResources[((int)Resorсes.Metal)] + " :Metal \n" +
                    inventory.CountResources[((int)Resorсes.Oxygen)] + " :Oxygen bottle \n";

    }
}
