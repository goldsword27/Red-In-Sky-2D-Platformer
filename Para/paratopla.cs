using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioClip coinPickupSFX; // Ses efekti için AudioClip

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Oyuncunun AudioSource bileşenini alın
            AudioSource playerAudioSource = other.gameObject.GetComponent<AudioSource>();
            if (playerAudioSource != null && coinPickupSFX != null)
            {
                // Ses efektini oyuncunun AudioSource bileşeninden çal
                playerAudioSource.PlayOneShot(coinPickupSFX);
            }

            // Coin'i yok et
            Destroy(gameObject);

            // Coin sayacını artır
            CoinCounter.instance.AddCoin();
        }
    }
}
