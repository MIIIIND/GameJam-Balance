using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UtilsClass;

public class spawn : MonoBehaviour
{
    [SerializeField] private Transform pfBlock;

    void Update()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        if(Input.GetKeyDown("e"))
        {
            Instantiate(pfBlock,mousePosition,Quaternion.identity);
        }
    }
}
