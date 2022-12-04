using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifeTimer : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentTime;
    public float startingTime = 10f;
    public Transform player;


    [SerializeField] TextMeshProUGUI countdownText;


    void Start()
    {
        currentTime = startingTime;
        player.GetComponent<Scoring>().OnEnnemyHit += RemoveTime;
        player.GetComponent<Scoring>().OnHealthItem += AddTime;
    }

    public void RemoveTime(object sender, EventArgs e)
    {
        currentTime = currentTime - 1;
    }

    public void AddTime(object sender, EventArgs e)
    {   
        if(currentTime + 10 <= startingTime){
            currentTime += 10;
        }
    }


    // Update is called once per frame
    void Update()
    {
        string seconds = (currentTime % 60).ToString("00");
        string minutes = (Math.Floor(currentTime / 60) % 60).ToString("00");


        currentTime -= 1 * Time.deltaTime;
        countdownText.text = minutes + ":" + seconds;

        if (currentTime <= 0) 
        {
            currentTime= 0;
            
            // insert Lose screen  
            
        }
        
    }
}
