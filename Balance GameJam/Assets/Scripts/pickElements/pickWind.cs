using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickWind : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && GameObject.Find("OffrandeWind") == null){
            Destroy(gameObject);
        }
    }
}
