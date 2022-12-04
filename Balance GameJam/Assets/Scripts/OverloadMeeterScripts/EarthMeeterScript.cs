using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthMeeterScript : MonoBehaviour
{
    public ElementalOverload earthValue;
    private Slider slider;
    float sliderValueLocal;
    void Start()
    {

        slider = GetComponent<Slider>();


    }

    // Update is called once per frame
    void Update()
    {

        slider.value = earthValue.GetComponent<ElementalOverload>().pEarth;

    }
}