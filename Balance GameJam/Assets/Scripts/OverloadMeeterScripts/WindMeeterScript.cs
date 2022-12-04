using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMeeterScript : MonoBehaviour
{
    public ElementalOverload windValue;
    private Slider slider;
    float sliderValueLocal;
    void Start()
    {

        slider = GetComponent<Slider>();


    }

    // Update is called once per frame
    void Update()
    {

        slider.value = windValue.GetComponent<ElementalOverload>().pWind;

    }
}
