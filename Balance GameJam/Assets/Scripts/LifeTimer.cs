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
    }

    public void RemoveTime(object sender, EventArgs e)
    {
        currentTime = currentTime - 1;
        print("Remove Time activated");
    }


    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0) 
        {
            currentTime= 0;

            // insert Lose screen  
            
        }
        
    }
}
