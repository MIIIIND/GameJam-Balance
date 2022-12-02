using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMob : MonoBehaviour
{
    public Transform target;
    public Transform location;

    [SerializeField] private Transform pfMob;
    void Start () {
        InvokeRepeating("OutputTime", 1f, 1f);  //1s delay, repeat every 1s
    }
    void OutputTime() {
        Transform mob = Instantiate(pfMob,location.position,Quaternion.identity);
        mob.GetComponent<followPlayer>().Setup(target);
    }
}
