using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public float hitForce = 10f; // Saw'a çarptığında oyuncuya uygulanacak kuvvet miktarı.
    private PlayerHealth playerHealth; // Oyuncunun sağlık scriptine erişim.
    private Rigidbody2D rb; // Oyuncunun Rigidbody2D component'ine erişim.

    void Start()
    {
        // Oyuncunun sağlık ve Rigidbody2D scriptlerine referans alın.
        playerHealth = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Saw"))
        {
            // Saw'a çarptığında canı azalt.
            playerHealth.TakeDamage(1);


            if (other.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-hitForce, rb.velocity.y); // Sağa çarpınca sola itme
            }
            else
            {
                rb.velocity = new Vector2(hitForce, rb.velocity.y); // Sola çarpınca sağa itme
            }
        }
    }
}
