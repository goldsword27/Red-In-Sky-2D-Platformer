using UnityEngine;
using System.Collections;

public class FireBoost : MonoBehaviour
{
    public float boostedFireRate = 0.9f;
    public float boostedBulletSpeed = 800f;
    public float boostedSpeed = 11f; // Artırılmış karakter hızı
    public AudioClip boostSFX;
    public float growDuration = 0.65f; // Büyüme süresi

    private SpriteRenderer spriteRenderer;
    private bool isGrowing = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isGrowing)
        {
            isGrowing = true;

            BulletManager bulletManager = other.GetComponent<BulletManager>();
            CharacControl characControl = other.GetComponent<CharacControl>();
            atamaAnim atamaAnim = other.GetComponent<atamaAnim>();
            
            if (bulletManager != null)
            {
                bulletManager.fireRate = boostedFireRate;
                bulletManager.bulletSpeed = boostedBulletSpeed;
            }

            if (characControl != null)
            {
                atamaAnim.SetSpeed(boostedSpeed);
                characControl.SetSpeed(boostedSpeed);
            }

            // Ses efektini çal
            AudioSource playerAudioSource = other.GetComponent<AudioSource>();
            if (playerAudioSource != null && boostSFX != null)
            {
                playerAudioSource.PlayOneShot(boostSFX);
            }

            // Büyüme animasyonunu başlat
            StartCoroutine(Grow());
        }
    }

    private IEnumerator Grow()
    {
        float elapsedTime = 0f;

        // Başlangıç boyutu ve opaklık
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 2f; // Hedef boyut (2 katına çıkacak)
        Color originalColor = spriteRenderer.color;

        while (elapsedTime < growDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / growDuration;

            // Opaklığı artır
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, t));

            // Boyutu büyüt
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

            yield return null;
        }

        // FireBoost objesini yok et
        Destroy(gameObject);
    }
}
