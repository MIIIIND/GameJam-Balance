using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HPTimeScript : MonoBehaviour
{
    Slider slider;
    public float startTime = 10f;
    float currentTime; 



    void Start()
    {
        currentTime = startTime;
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        slider.value = currentTime;
        
    

        if (currentTime <= 0) 
        {
            currentTime= 0;
            print("pierdolsie");
            // END GAME

        }
    }

    public void addTime()
    {

    }

    public void removeTime()
    {

    }
}
