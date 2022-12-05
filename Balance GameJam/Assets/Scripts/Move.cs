using System.Collections;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    public float moveSpeed; 
    public Rigidbody2D rb;

    private float keyMoveX = 0;
    private float keyMoveY = 0;
    private Vector3 velocity = Vector3.zero;

    public bool canDash = false;
    public float dashingPower;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    // [SerializeField] private TrailRenderer tr;

    public event EventHandler OnUsedWind;

    void Start(){
        GetComponent<Scoring>().OnPickedWind += enableWind;
    }

    void enableWind(object sender, EventArgs e){
        canDash=true;
    }

    private void Update()
    {


        keyMoveX = 0;
        keyMoveY = 0;
        keyMoveX = Input.GetAxis("Horizontal");
        keyMoveY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canDash) 
        {
            StartCoroutine(Dash());
        }
    }
    
    private void FixedUpdate()
    {
        
        //if (Input.GetButtonDown("Jump"))
        //{
        // MovePlayer(keyMoveX * speedboost * Time.deltaTime, keyMoveY * speedboost * Time.deltaTime);
        //    print("boos");
        //}
        //else
        //{
         MovePlayer(keyMoveX * moveSpeed * Time.deltaTime, keyMoveY * moveSpeed * Time.deltaTime);
          
        //}
    }

    private void MovePlayer(float Xmove, float Ymove)
    {
        Vector3 targetVelocity = new Vector2(Xmove,Ymove);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity, ref velocity, .05f);
    }


    private IEnumerator Dash()
    {
        OnUsedWind?.Invoke(this,EventArgs.Empty);
        canDash = false;


        if(keyMoveX > 0 && keyMoveY > 0) 
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * dashingPower);
        }
        else if(keyMoveX > 0 && keyMoveY < 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * -dashingPower);
        }
        else if (keyMoveX < 0 && keyMoveY > 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, transform.localScale.y * dashingPower);
        }
        else if (keyMoveX < 0 && keyMoveY < 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, transform.localScale.y * -dashingPower);
        }
        else if (keyMoveX == 0 && keyMoveY < 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * 0, transform.localScale.y * -dashingPower);
        }
        else if (keyMoveX == 0 && keyMoveY > 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * 0, transform.localScale.y * dashingPower);
        }
        else if (keyMoveX < 0 && keyMoveY == 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * -dashingPower, transform.localScale.y * 0);
        }
        else if (keyMoveX > 0 && keyMoveY == 0)
        {
            rb.velocity = new Vector2(transform.localScale.x * dashingPower, transform.localScale.y * 0);
        }


        //  tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
    //    tr.emitting = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
