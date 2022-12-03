using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public Transform target;
    public Transform location;

    [SerializeField] private Transform pfMob;
    void Start () {
        InvokeRepeating("OutputTime", 1f, 1f);  
    }
    void OutputTime() {
        Transform mob = Instantiate(pfMob,location.position,Quaternion.identity);
        mob.GetComponent<followPlayer>().Setup(target);
    }
}
