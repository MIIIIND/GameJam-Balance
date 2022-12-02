using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float startTime = 10f;
    float currentTime;
    public Slider slider;
 

    void Start()
    {
        currentTime = startTime;
        slider = GetComponent<Slider>();
    }

  
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        slider.value = currentTime;
    }
}
