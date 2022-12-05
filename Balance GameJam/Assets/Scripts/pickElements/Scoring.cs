using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Scoring : MonoBehaviour
{
    public event EventHandler OnPickedFire;
    public event EventHandler OnPickedWater;
    public event EventHandler OnPickedEmptiness;
    public event EventHandler OnPickedWind;
    public event EventHandler OnPickedEarth;
    public event EventHandler OnEnnemyHit;
    public event EventHandler OnHealthItem;

    public TilemapRenderer fireColorActivation;
    public TilemapRenderer waterColorActivation;
    public TilemapRenderer earthColorActivation;
    public TilemapRenderer windColorActivation;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Fire") && GameObject.Find("OffrandeFire") == null)
        {
            OnPickedFire?.Invoke(this,EventArgs.Empty);
            fireColorActivation.GetComponent<TilemapRenderer>().sortingOrder = -25;
        }
        else if(collision.CompareTag("Water") && GameObject.Find("OffrandeWater") == null)
        {
            OnPickedWater?.Invoke(this,EventArgs.Empty);
            waterColorActivation.GetComponent<TilemapRenderer>().sortingOrder = -25;
        }
        else if(collision.CompareTag("Emptiness") && GameObject.Find("OffrandeEmptiness") == null)
        {
            OnPickedEmptiness?.Invoke(this,EventArgs.Empty);
        }
        else if(collision.CompareTag("Wind") && GameObject.Find("OffrandeWind") == null)
        {
            OnPickedWind?.Invoke(this, EventArgs.Empty);
            windColorActivation.GetComponent<TilemapRenderer>().sortingOrder = -25;
        }
        else if(collision.CompareTag("Earth") && GameObject.Find("OffrandeEarth") == null)
        {
            OnPickedEarth?.Invoke(this,EventArgs.Empty);
            earthColorActivation.GetComponent<TilemapRenderer>().sortingOrder = -25;
        }
        else if (collision.CompareTag("Enemi"))
        {
            OnEnnemyHit?.Invoke(this, EventArgs.Empty);
        }
        else if (collision.CompareTag("Health"))
        {
            OnHealthItem?.Invoke(this, EventArgs.Empty);
        }
    }
}
