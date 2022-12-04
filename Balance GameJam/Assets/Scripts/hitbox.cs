using UnityEngine;

public class hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Ball")){
            Destroy(transform.parent.parent.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
