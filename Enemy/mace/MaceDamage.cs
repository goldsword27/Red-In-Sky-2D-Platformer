using UnityEngine;

public class MaceCollision : MonoBehaviour
{
    public int damageAmount = 1; // Mace çarptığında vereceği hasar miktarı
    public float hitForce = 5f; // Mace çarptığında uygulanacak geriye doğru kuvvet miktarı

    private Rigidbody2D rb; // Oyuncunun Rigidbody2D component'ine erişim

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Oyuncunun Rigidbody2D component'ine erişimi başlat
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpışan nesnenin tag'ini kontrol et
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncuya hasar vermek için PlayerHealth bileşenine erişin ve TakeDamage fonksiyonunu çağırın
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Oyuncuya hasar ver
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found on player object!"); // PlayerHealth bileşeni bulunamadı
            }
            
            // Hit işlemini gerçekleştirin
         //   Debug.Log("Player hit by Mace");

            // Oyuncuya geri doğru bir kuvvet uygula
            float direction = transform.position.x - collision.transform.position.x;
            rb.velocity = new Vector2(direction > 0 ? hitForce : -hitForce, rb.velocity.y);
        }
    }
}
