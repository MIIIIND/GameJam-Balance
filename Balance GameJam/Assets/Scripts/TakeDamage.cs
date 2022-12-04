using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    float timer = 0;

    //bool changecolor= false;
    void Start()
    {

        GetComponent<Scoring>().OnEnnemyHit += damageColorChange;
 

    }

    void damageColorChange(object sender, EventArgs e)
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
 
        timer = 0;
        

    }        

        

    void Update()
    {
       timer += 1 * Time.deltaTime;
    
       
        if (timer > 0.2f)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        }

    }
    }
