using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed;
    private Vector3 Dir;
    public void Setup(Vector3 Dir,float angle){
        this.Dir = Dir;
        transform.eulerAngles = new Vector3(0,0,angle);
        Destroy(gameObject, 5f);
    }

    private void Update(){
        transform.position += Dir * speed * Time.deltaTime;
    }
}
