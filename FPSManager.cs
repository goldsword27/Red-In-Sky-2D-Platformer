using UnityEngine;

// En sevdiğim scriptttttttttttttt   
public class FPSManager : MonoBehaviour
{
    public int vSyncAcikmi = 1;

    void Awake()
    {
        double screenRefreshRateDouble = Screen.currentResolution.refreshRateRatio.value;
        int screenRefreshRate = (int)screenRefreshRateDouble;

        // Ekran yenileme hızının geçerli bir değer olup olmadığını kontrol et
        if (screenRefreshRate > 0)
        {
            // Hedef FPS'i ekran yenileme hızına göre ayarla
            Application.targetFrameRate = screenRefreshRate;
            Debug.Log("FPS = " + screenRefreshRate);
        }
        else
        {
            Application.targetFrameRate = 60;
            Debug.Log("FPS varsayılan = 60");
        }

        // vSync'i ayarla
        QualitySettings.vSyncCount = vSyncAcikmi;
    }
}
/*
using System.Collections;
using System.Threading;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("Frame Settings")]
    int MaxRate = 9999; // Maksimum kare hızını 9999 olarak ayarlar.
    public float TargetFrameRate = 60.0f; // Hedeflenen kare hızını ayarlar.
    float currentFrameTime; // Geçerli kare zamanını tutar.

    void Awake()
    {
        QualitySettings.vSyncCount = 0; // V-Sync'i kapatır.
        Application.targetFrameRate = MaxRate; // Uygulama için maksimum kare hızını ayarlar.
        currentFrameTime = Time.realtimeSinceStartup; // Başlangıç zamanını alır.
        StartCoroutine("WaitForNextFrame"); // Yeni kareyi beklemek için coroutine başlatır.
    }

    IEnumerator WaitForNextFrame()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame(); // Kare sonunu bekler.
            currentFrameTime += 1.0f / TargetFrameRate; // Geçerli kare zamanını hedef kare hızına göre günceller.
            var t = Time.realtimeSinceStartup; // Geçerli gerçek zamanlı süreyi alır.
            var sleepTime = currentFrameTime - t - 0.01f; // Uyuma süresini hesaplar.
            if (sleepTime > 0)
                Thread.Sleep((int)(sleepTime * 1000)); // Uyuma süresi pozitif ise, belirtilen süre kadar uyur.
            while (t < currentFrameTime)
                t = Time.realtimeSinceStartup; // Geçerli zaman hedef kare zamanına ulaşana kadar bekler.
        }
    }
}*/