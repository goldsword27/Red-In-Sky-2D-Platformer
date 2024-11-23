using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioClip keyPickupSFX; // Ses efekti için AudioClip

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Oyuncunun AudioSource bileşenini alın
            AudioSource playerAudioSource = other.gameObject.GetComponent<AudioSource>();
            if (playerAudioSource != null && keyPickupSFX != null)
            {
                // Ses efektini oyuncunun AudioSource bileşeninden çal
                playerAudioSource.PlayOneShot(keyPickupSFX);
            }

            // Anahtarı yok et
            Destroy(gameObject);

            // Anahtar sayacını artır
            KeyCounter.instance.AddKey();
        }
    }
}
