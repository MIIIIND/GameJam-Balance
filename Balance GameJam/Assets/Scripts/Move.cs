using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private float keyMoveX = 0;
    private float keyMoveY = 0;
    private Vector3 velocity = Vector3.zero;


    private void Update()
    {
        keyMoveX = 0;
        keyMoveY = 0;
        keyMoveX = Input.GetAxis("Horizontal");
        keyMoveY = Input.GetAxis("Vertical");
    }
    
    private void FixedUpdate()
    {
        MovePlayer(keyMoveX * moveSpeed * Time.deltaTime, keyMoveY * moveSpeed * Time.deltaTime);
    }

    private void MovePlayer(float Xmove, float Ymove)
    {
        Vector3 targetVelocity = new Vector2(Xmove,Ymove);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity, ref velocity, .05f);
    }
}
