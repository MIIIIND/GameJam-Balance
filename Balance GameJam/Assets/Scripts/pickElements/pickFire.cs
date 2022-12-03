using System;
using UnityEngine;

public class pickFire : MonoBehaviour
{
    public event EventHandler pickedFire;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            pickedFire?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
