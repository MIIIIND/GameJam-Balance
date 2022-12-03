using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{

    void Start() {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.localScale += new Vector3(0.001F, 0.001F, 0.001F);
    }
}
