using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickEarth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && GameObject.Find("OffrandeEarth") == null){
            Destroy(gameObject);
        }
    }
}
