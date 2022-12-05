using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class pickFire : MonoBehaviour
{
  // public TilemapRenderer layerChange;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && GameObject.Find("OffrandeFire") == null){
            Destroy(gameObject);

           // layerChange = GetComponent<TilemapRenderer>();
           // layerChange.sortingLayerID= -1;
          //  print("on a change de layer");
          //  layerChange.GetComponent<TilemapRenderer>().sortingLayerID = -9;
        }
    }
}
