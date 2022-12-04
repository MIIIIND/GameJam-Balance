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

    public event EventHandler<OnShootBubbleEventArgs> OnShootBubble;
    public class OnShootBubbleEventArgs : EventArgs{
        public Vector3 tracker;
        public Vector3 shootPosition;
        public float angle;
    }

    public Transform aimTracker;
    public Transform aimPosition;
    public Transform fire;
    private float angle;

    private bool spawned = false;
    private float decay;

    private bool spawnedB = false;
    private float decayB;

    private bool canFire = false;
    private bool canWater = false;

    void Start(){
        GetComponent<Scoring>().OnPickedFire += enableFire;
        GetComponent<Scoring>().OnPickedWater += enableWater;
    }

    void enableFire(object sender, EventArgs e){
        canFire=true;
    }
    void enableWater(object sender, EventArgs e){
        canWater=true;
    }

    void FixedUpdate()
    {
        Aiming();
        if(canFire){
           Shooting(); 
        }
        if(canWater){
           ShootingBubble(); 
        }
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
            decay = 0.09f;
            spawned = true;
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShoot?.Invoke(this,new OnShootEventArgs{
                tracker = aimPosition.position,
                shootPosition = mousePosition,
                angle = this.angle
            });
        }
    }

    private void ShootingBubble(){
        Reset();
        if(Input.GetMouseButton(1) && !spawnedB){
            decayB = 0.005f;
            spawnedB = true;
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            OnShootBubble?.Invoke(this,new OnShootBubbleEventArgs{
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

        if(spawnedB && decayB > 0)
        {
            decayB -= Time.deltaTime;
        }
        if(decayB < 0)
        {
            decayB = 0;
            spawnedB = false;
        }
    }
}
