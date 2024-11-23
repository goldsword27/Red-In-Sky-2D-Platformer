using UnityEngine;
using System.Collections;

public class CanFulleyici : MonoBehaviour
{
    public AudioClip healSFX; // Ses efekti için AudioClip
    public float disappearDuration = 0.25f; // Yok olma süresi

    private SpriteRenderer spriteRenderer;
    private bool isDisappearing = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer çarpışan obje "Player" tag'ine sahipse
        if (other.CompareTag("Player") && !isDisappearing)
        {
            isDisappearing = true;

            // PlayerHealth scriptini al ve canı maksimuma çıkar
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.HealToMax();

                // Oyuncunun AudioSource bileşenini alın
                AudioSource playerAudioSource = other.GetComponent<AudioSource>();
                if (playerAudioSource != null && healSFX != null)
                {
                    // Ses efektini oyuncunun AudioSource bileşeninden çal
                    playerAudioSource.PlayOneShot(healSFX);
                }

                // Yok olma animasyonunu başlat
                StartCoroutine(Disappear());
            }
        }
    }

    private IEnumerator Disappear()
    {
        float elapsedTime = 0f;

        // Başlangıç boyutu ve opaklık
        Vector3 originalScale = transform.localScale;
        Color originalColor = spriteRenderer.color;

        while (elapsedTime < disappearDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / disappearDuration;

            // Opaklığı azalt
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, t));

            // Boyutu küçült
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, t);

            yield return null;
        }

        // Can fulleyiciyi yok et
        Destroy(gameObject);
    }
}
