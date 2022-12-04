using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterMeeterScript : MonoBehaviour
{
    public ElementalOverload waterValue;
    private Slider slider;
    float sliderValueLocal;
    void Start()
    {

        slider = GetComponent<Slider>();


    }

    // Update is called once per frame
    void Update()
    {

        slider.value = waterValue.GetComponent<ElementalOverload>().pWater;

    }
}