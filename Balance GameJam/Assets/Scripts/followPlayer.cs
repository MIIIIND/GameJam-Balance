using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class followPlayer : MonoBehaviour
{
    public float speed;
    public SpriteRenderer graphics;
    public Transform target;

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(dir.x < 0)
        {
            graphics.flipX = true;
        }
        else
        {
            graphics.flipX = false;
        }
    }

    public void Setup(Transform target){
        this.target = target;
    }
}
