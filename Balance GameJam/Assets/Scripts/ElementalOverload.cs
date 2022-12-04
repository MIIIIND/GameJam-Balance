using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class ElementalOverload : MonoBehaviour
{
    public float fireGauge;   
    public float waterGauge;   
    public float windGauge;   
    public float earthGauge;   

    public Transform globalLight;

    private float fireGaugeBalance;   
    private float waterGaugeBalance;   
    private float windGaugeBalance;   
    private float earthGaugeBalance; 

    private bool lockFire;
    private bool lockWater;
    private bool lockWind;
    private bool lockEarth;

    void Start(){
        //InvokeRepeating("TimerScreen", 0.1f, 0.1f);  
        InvokeRepeating("TimerIncrease", 1f, 1f); 
        GetComponent<Move>().OnUsedWind += decreaseWind;
        GetComponent<Aim>().OnShootBubble += decreaseWater;
        GetComponent<Aim>().OnShoot += decreaseFire;
        GetComponent<spawn>().OnUsedEarth += decreaseEarth;

        fireGaugeBalance = fireGauge;
        waterGaugeBalance = waterGauge;
        windGaugeBalance = windGauge;
        earthGaugeBalance = earthGauge;
    }

    void decreaseWind(object sender, EventArgs e){    
        windGaugeBalance -= 1;
    }

    void decreaseFire(object sender, Aim.OnShootEventArgs e){
        fireGaugeBalance -= 1;
    }

    void decreaseWater(object sender, Aim.OnShootBubbleEventArgs e){
        waterGaugeBalance -= 1;
    }

    void decreaseEarth(object sender, EventArgs e){
        earthGaugeBalance -= 1;
    }

    void Update()
    {
        if(fireGaugeBalance<=0 || waterGaugeBalance<=0 || windGaugeBalance<=0 || earthGaugeBalance<=0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void TimerScreen() {
        double pFire = ((double)fireGaugeBalance/(double)fireGauge) * (long)100;
        double pWater = ((double)waterGaugeBalance/(double)waterGauge) * (long)100;
        double pEarth = ((double)earthGaugeBalance/(double)earthGauge) * (long)100;
        double pWind = ((double)windGaugeBalance/(double)windGauge) * (long)100;
        if(pFire <= 10){
            Color colorValue = new Color(0, 1, 1);
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue/50;
            print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
        }
        if(pWater <= 10){
            Color colorValue = new Color(1, 1, 0);
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue/50;
            print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
        }
        if(pEarth <= 10){
            Color colorValue = new Color(1, 1, 0);
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue/50;
            print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
        }
        if(pWind <= 10){
            Color colorValue = new Color(1, 0, 1);
            globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue/50;
            print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
        }
    }

    void TimerIncrease() {
        if(windGaugeBalance<windGauge){
            windGaugeBalance += 1;
        }
        if(fireGaugeBalance<fireGauge){
            fireGaugeBalance += 1;
        }
        if(waterGaugeBalance<waterGauge){
            waterGaugeBalance += 1;
        }
        if(earthGaugeBalance<earthGauge){
            earthGaugeBalance += 1;
        }
    }
}
