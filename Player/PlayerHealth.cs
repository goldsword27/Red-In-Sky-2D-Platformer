using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 7; // Oyuncunun maksimum can miktarı
    public int currentHealth; // Oyuncunun mevcut can miktarı
    public Text healthText; // Can miktarını gösterecek UI metni
    public Slider slider;
    public GameObject deathScreen;
    public AudioClip deathSFX; // Ölüm ses efekti için AudioClip
    public AudioClip damageSFX; // Hasar ses efekti için AudioClip
    private AudioSource audioSource; // Ses çalma için AudioSource
    private CharacControl characControl; // CharacControl sınıfına erişim

    public GameObject joystick; // Joystick referansı
    public GameObject joystickHandle; // Joystick Handle referansı
    public GameObject shotButton; // ShotButton referansı
    public GameObject jumpButton; // JumpButton referansı

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        characControl = GetComponent<CharacControl>(); // CharacControl bileşenine erişim

        // AudioSource bileşenini ekleyin veya mevcut olanı alın
        audioSource = gameObject.AddComponent<AudioSource>();

        // Joystick referanslarını kontrol et
        if (joystick == null)
        {
            joystick = GameObject.FindWithTag("Joystick");
        }

        // Joystick'in altındaki Handle'ı bul
        if (joystick != null && joystickHandle == null)
        {
            joystickHandle = joystick.transform.Find("Handle").gameObject;
        }

        // ShotButton referansını kontrol et
        if (shotButton == null)
        {
            shotButton = GameObject.FindWithTag("ShotButton");
        }

        // JumpButton referansını kontrol et
        if (jumpButton == null)
        {
            jumpButton = GameObject.FindWithTag("JumpButton");
        }
    }

    public void TakeDamage(int amount)
    {
        // Oyuncunun canını azalt
        currentHealth -= amount;
        UpdateHealthText();
        slider.value = currentHealth;

        // Hasar ses efektini çal
        if (damageSFX != null)
        {
            audioSource.pitch = 0.8f; // Sesin hızını düşürerek kalınlaştır
            audioSource.volume = 0.2f; // Ses seviyesini 0.4 yap
            audioSource.PlayOneShot(damageSFX);
        }

        // Oyuncunun canı sıfırın altına düştüğünde öldüğünü kontrol et
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Ölüm ses efektini çal
        if (deathSFX != null)
        {
            audioSource.pitch = 1.0f; // Ölüm ses efekti için normal hıza geri dön
            audioSource.volume = 1.0f; // Ses seviyesini maksimum yap
            audioSource.PlayOneShot(deathSFX);
        }

        // Oyuncunun ölümüyle ilgili gerekli işlemler buraya yazılabilir
        if (deathScreen != null)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true); // Ölüm ekranını görünür yap
        }
        Debug.Log("Adam öldü!");

        // InGameScreen'i deaktif hale getir
        GameObject inGameScreen = GameObject.Find("InGameScreen");
        if (inGameScreen != null)
        {
            inGameScreen.SetActive(false);
        }

        // Joystick ve Handle'ı deaktif hale getir
        if (joystick != null)
        {
            joystick.SetActive(false);
        }

        if (joystickHandle != null)
        {
            joystickHandle.SetActive(false);
        }

        // ShotButton'ı deaktif hale getir
        if (shotButton != null)
        {
            shotButton.SetActive(false);
        }

        // JumpButton'ı deaktif hale getir
        if (jumpButton != null)
        {
            jumpButton.SetActive(false);
        }

        // CharacControl sınıfının Die metodunu çağırarak oyuncunun hareketini durdur
        if (characControl != null)
        {
            characControl.Die();
        }
    }

    public void HealToMax()
    {
        currentHealth = maxHealth; // Canı maksimum seviyeye çıkar
        UpdateHealthText();
        slider.value = currentHealth;
        Debug.Log("can fullendi yegen!");
    }

    void UpdateHealthText()
    {
        // Can miktarını UI metnine güncelle
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }
}
