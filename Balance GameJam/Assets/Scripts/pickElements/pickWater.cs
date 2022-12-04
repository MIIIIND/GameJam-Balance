using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && GameObject.Find("OffrandeWater") == null){
            Destroy(gameObject);
        }
    }
}
