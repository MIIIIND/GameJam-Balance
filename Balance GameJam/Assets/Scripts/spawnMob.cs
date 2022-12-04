using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public Transform target;
    public Transform location;
    private float rate = 1;
    private bool lockEarth = false;
    private bool lockFire = false;
    private bool lockWater = false;
    private bool lockWind = false;
    private bool lockEmptiness = false;

    [SerializeField] private Transform pfMob;
    void Start () {
        InvokeRepeating("OutputTime", rate, rate);  
    }

    void Update(){
        if(GameObject.Find("Earth") == null && lockEarth == false){
            rate +=1;
            lockEarth = true;
        }
        else if(GameObject.Find("Fire") == null && lockFire == false){
            rate +=1;
            lockFire = true;
        }
        else if(GameObject.Find("Water") == null && lockWater == false){
            rate +=1;
            lockWater = true;
        }
        else if(GameObject.Find("Wind") == null && lockWind == false){
            rate +=1;
            lockWind = true;
        }
        else if(GameObject.Find("Emptiness") == null && lockEmptiness == false){
            rate +=1;
            lockEmptiness = true;
        }
    }

    void OutputTime() {
        for(int i = 0;i<rate;i++){
            Transform mob = Instantiate(pfMob,location.position,Quaternion.identity);
            mob.GetComponent<followPlayer>().Setup(target);
        }
    }
}
