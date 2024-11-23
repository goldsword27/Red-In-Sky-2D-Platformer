using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform player; // Oyuncu karakteri
    public Transform endPoint; // Bölüm sonu noktası
    public Slider progressBar; // UI slider'ı

    private float startDistance;

    void Start()
    {
        // Başlangıç mesafesini hesapla
        startDistance = Vector3.Distance(player.position, endPoint.position);
    }

    void Update()
    {
        // Mevcut mesafeyi hesapla
        float currentDistance = Vector3.Distance(player.position, endPoint.position);

        // Mesafe oranını hesapla (0 ile 1 arasında)
        float distanceRatio = Mathf.Clamp01(1 - (currentDistance / startDistance));

        // Progress bar'ı güncelle
        progressBar.value = distanceRatio;
    }
}
