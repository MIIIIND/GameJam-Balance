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
        player.GetComponent<Scoring>().OnHealthItem += AddTime;
        Screen.SetResolution(1980, 1080, true);
    }



    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        float sliderValueFloat = currentTime/startTime;
        float sliderValueFloat2 = sliderValueFloat*20;
        int sliderValueInt = (int)sliderValueFloat2;
        slider.value = sliderValueInt;
        
    

        if (currentTime <= 0) 
        {
            currentTime= 0;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            print("Scene reset");

        }
    }

    public void RemoveTime(object sender, EventArgs e)
    {
        currentTime = currentTime - 1;
       
    }

    public void AddTime(object sender, EventArgs e)
    {   
        if(currentTime + 10 <= startTime){
            currentTime += 10;
        }
        else{
            currentTime = startTime;
        }
    }
}
