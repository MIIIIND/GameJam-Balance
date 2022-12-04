using System;
using UnityEngine;

public class pickFire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && GameObject.Find("OffrandeFire") == null){
            Destroy(gameObject);
        }
    }
}
