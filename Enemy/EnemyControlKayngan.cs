using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockbackForce = 20f; // Geri itme kuvveti

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Sürtünme kuvvetini artırarak düşmanın kaymasını önleyin
        if (rb.velocity.x != 0)
        {
            Vector2 velocity = rb.velocity;
            velocity.x *= 0.9f; // X yönündeki hızı azaltarak kaymayı önleyin
            rb.velocity = velocity;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Geri itme yönü
                Vector2 knockbackDirection = (playerRb.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}
