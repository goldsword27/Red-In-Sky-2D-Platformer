
/*using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int damageAmount = 1; // Düşmanın oyuncuya verdiği hasar miktarı
    private int hitCount = 0; // Düşmana çarpan "bullet" sayısını takip eder






public Slider slider;
            void Start()
    {
        slider.maxValue = hitCount;
        slider.value = hitCount;
    }










    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpışma, düşmanın oyuncuyla olduğunda çalışır
        if (collision.CompareTag("Player"))
        {
            // Oyuncunun canını azalt
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
           Destroy(collision.gameObject);
            // Çarpan nesne "bullet" tag'ına sahipse, hitCount'ı arttır
            hitCount++;

            // Eğer hitCount 3 ise, düşmanı yok et
            if (hitCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }




}


*/

using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int dusmancani = 3;
    public int damageAmount = 1; // Düşmanın oyuncuya verdiği hasar miktarı
    private int hitCount = 0; // Düşmana çarpan "bullet" sayısını takip eder

    public Slider slider;

    void Start()
    {
        // Slider'ın başlangıç değerlerini ayarla
        slider.maxValue =dusmancani; // Varsayılan olarak maksimum 3 vuruş kabul edilecek gibi görünüyor
        slider.value = hitCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpışma, düşmanın oyuncuyla olduğunda çalışır
        if (collision.CompareTag("Player"))
        {
            // Oyuncunun canını azalt
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
        else if (collision.CompareTag("Bullet"))
        {
            // Çarpan nesne "bullet" tag'ına sahipse, hitCount'ı arttır
            hitCount++;

            // Eğer hitCount 3 ise, düşmanı yok et
            if (hitCount >= dusmancani)
            {
                Destroy(gameObject);
            }

            // Çarpışan nesneyi yok et
            Destroy(collision.gameObject);

            // Slider'ı güncelle
            slider.value = hitCount;
        }
    }
}
