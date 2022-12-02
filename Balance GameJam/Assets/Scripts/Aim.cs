using System;
using UnityEngine;
using static UtilsClass;

public class Aim : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs{
        public Vector3 tracker;
        public Vector3 shootPosition;
        public float angle;
    }

    public Transform aimTracker;
    public Transform aimPosition;
    private float angle;

    private bool spawned = false;
    private float decay;

    void Update()
    {
        Aiming();
        Shooting();
    }

    private void Aiming(){
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        aimTracker.eulerAngles = new Vector3(0,0,angle);
    }

    private void Shooting(){
        Reset();
        if(Input.GetMouseButton(0) && !spawned){
            decay = 0.1f;
            spawned = true;
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShoot?.Invoke(this,new OnShootEventArgs{
                tracker = aimPosition.position,
                shootPosition = mousePosition,
                angle = this.angle
            });
        }
    }

    private void Reset()
    {
        if(spawned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if(decay < 0)
        {
            decay = 0;
            spawned = false;
        }
    }
}
