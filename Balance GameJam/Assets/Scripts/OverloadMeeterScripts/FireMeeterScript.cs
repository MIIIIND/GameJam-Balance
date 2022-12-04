using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMeeterScript : MonoBehaviour
{
    public ElementalOverload fireValue;
    private Slider slider;
    float sliderValueLocal;
    void Start()
    {
    
        slider = GetComponent<Slider>();
     
        
    }

    // Update is called once per frame
    void Update()
    {
       
        slider.value = fireValue.GetComponent<ElementalOverload>().pFire;
        
    }
}
