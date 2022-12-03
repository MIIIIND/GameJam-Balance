using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UtilsClass;


public class HPTimeScript : MonoBehaviour
{
    public Slider slider;
    public float startTime = 10f;
    float currentTime;
    public Transform player; 



    void Start()
    {

        currentTime = startTime;
        slider = GetComponent<Slider>();
        player.GetComponent<Scoring>().OnEnnemyHit += RemoveTime;
        
    }

    

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        float sliderValueFloat = currentTime/startTime;
        float sliderValueFloat2 = sliderValueFloat*17;
        int sliderValueInt = (int)sliderValueFloat2;
        slider.value = sliderValueInt;
        
    

        if (currentTime <= 0) 
        {
            currentTime= 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("Scene reset");

        }
    }



    public void addTime()
    {

    }

    public void RemoveTime(object sender, EventArgs e)
    {
        currentTime = currentTime - 1;
       
    }
}
