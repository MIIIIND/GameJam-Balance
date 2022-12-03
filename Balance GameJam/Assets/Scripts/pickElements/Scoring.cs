using System;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public event EventHandler OnPickedFire;
    public event EventHandler OnPickedWater;
    public event EventHandler OnPickedEmptiness;
    public event EventHandler OnPickedWind;
    public event EventHandler OnPickedEarth;
    public event EventHandler OnEnnemyHit;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Fire")){
            OnPickedFire?.Invoke(this,EventArgs.Empty);
        }
        else if(collision.CompareTag("Water")){
            OnPickedWater?.Invoke(this,EventArgs.Empty);
        }
        else if(collision.CompareTag("Emptiness")){
            OnPickedEmptiness?.Invoke(this,EventArgs.Empty);
        }
        else if(collision.CompareTag("Wind")){
            OnPickedWind?.Invoke(this,EventArgs.Empty);
        }
        else if(collision.CompareTag("Earth")){
            OnPickedEarth?.Invoke(this,EventArgs.Empty);
        }
        else if (collision.CompareTag("Enemi"))
        {
            OnEnnemyHit?.Invoke(this,EventArgs.Empty);
        }
    }
}
