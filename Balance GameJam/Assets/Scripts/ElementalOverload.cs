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

    public float pFire;
    public float pWater;
    public float pEarth;
    public float pWind;

    void Start() {
        //InvokeRepeating("TimerScreen", 0.1f, 0.1f);  
        InvokeRepeating("TimerIncrease", 1f, 1f);
        GetComponent<Move>().OnUsedWind += decreaseWind;
        GetComponent<Aim>().OnShootBubble += decreaseWater;
        GetComponent<Aim>().OnShoot += decreaseFire;
        GetComponent<spawn>().OnUsedEarth += decreaseEarth;

        fireGaugeBalance = 0;
        waterGaugeBalance = 0;
        windGaugeBalance = 0;
        earthGaugeBalance = 0;
    }

    void decreaseWind(object sender, EventArgs e) {
        windGaugeBalance += 1;
    }

    void decreaseFire(object sender, Aim.OnShootEventArgs e) {
        fireGaugeBalance += 1;
    }

    void decreaseWater(object sender, Aim.OnShootBubbleEventArgs e) {
        waterGaugeBalance += 1;
    }

    void decreaseEarth(object sender, EventArgs e) {
        earthGaugeBalance += 1;
    }

    void Update()
    {
        if (fireGaugeBalance > fireGauge || waterGaugeBalance > waterGauge || windGaugeBalance > waterGauge || earthGaugeBalance > earthGauge) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        pFire = ((float)fireGaugeBalance / (float)fireGauge) * (long)100;
        pWater = ((float)waterGaugeBalance / (float)waterGauge) * (long)100;
        pEarth = ((float)earthGaugeBalance / (float)earthGauge) * (long)100;
        pWind = ((float)windGaugeBalance / (float)windGauge) * (long)100;
    }

    //void TimerScreen() {

    //    if (pFire <= 10) {
    //        Color colorValue = new Color(0, 1, 1);
    //        globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue / 50;
    //        print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
    //    }
    //    if (pWater <= 10) {
    //        Color colorValue = new Color(1, 1, 0);
    //        globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue / 50;
    //        print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
    //    }
    //    if (pEarth <= 10) {
    //        Color colorValue = new Color(1, 1, 0);
    //        globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue / 50;
    //        print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
    //    }
    //    if (pWind <= 10) {
    //        Color colorValue = new Color(1, 0, 1);
    //        globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color -= colorValue / 50;
    //        print(globalLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color);
    //    }
    //}



    void TimerIncrease() {
        if(windGaugeBalance > 0 ){
            windGaugeBalance -= 0.5f;
            print(windGaugeBalance);
        }
        if(fireGaugeBalance>0){
            fireGaugeBalance -= 0.5f;
        }
        if(waterGaugeBalance > 0){
            waterGaugeBalance -= 0.5f;
        }
        if(earthGaugeBalance > 0){
            earthGaugeBalance -= 0.5f;
        }
    }
}
