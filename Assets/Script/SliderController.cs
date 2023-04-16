using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public OxygenRegulation oxygenRegulation;

    // Update is called once per frame
    void Update()
    {
        slider.value = (float)oxygenRegulation.MaxOxigen / oxygenRegulation.CurOxygen;
    }
}
