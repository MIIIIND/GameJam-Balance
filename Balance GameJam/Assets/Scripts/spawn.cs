using System;
using UnityEngine;
using static UtilsClass;

public class spawn : MonoBehaviour
{
    private bool canEarth=false;

    public event EventHandler OnUsedEarth;

    [SerializeField] private Transform pfBlock;
    void Start(){
        GetComponent<Scoring>().OnPickedEarth += enableEarth;
    }

    void enableEarth(object sender, EventArgs e){
        canEarth=true;
    }

    void Update()
    {   
        if(canEarth){
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            if(Input.GetKeyDown("e"))
            {
                OnUsedEarth?.Invoke(this,EventArgs.Empty);
                Instantiate(pfBlock,mousePosition,Quaternion.identity);
            }
        }
    }
}
