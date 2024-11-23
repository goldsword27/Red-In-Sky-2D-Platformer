using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Deaktif Canvas
    public AudioClip levelCompleteMusic;   // Seviye tamamlama müziği
    public float levelCompleteMusicVolume = 1.0f; // Sabit müzik ses seviyesi
    public GameObject joystick; // Joystick referansı
    public GameObject joystickHandle; // Joystick Handle referansı
    public GameObject shotButton; // ShotButton referansı
    public GameObject jumpButton; // JumpButton referansı

    private AudioSource winMusicSource; // Bağımsız AudioSource

    void Start()
    {
        // Canvas başlangıçta deaktif olmalı
        levelCompleteCanvas.SetActive(false);

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

        // Yeni bir AudioSource ekle ve ayarla
        winMusicSource = gameObject.AddComponent<AudioSource>();
        winMusicSource.volume = levelCompleteMusicVolume;
        winMusicSource.loop = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            // Canvas'ı aktif hale getir
            levelCompleteCanvas.SetActive(true);

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

            // Oyun içi müziği durdur
            AudioManager.instance.StopMusic();

            // Yeni müziği sabit ses seviyesiyle çal
            if (levelCompleteMusic != null)
            {
                winMusicSource.clip = levelCompleteMusic;
                winMusicSource.Play();
            }

            // Mevcut level numarasını al
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 1; // Level indexiyle eşleşmesi için
            // Bir sonraki seviyenin kilidini aç
            if (currentLevel < 6)
            {
                PlayerPrefs.SetInt("Level" + (currentLevel + 1), 1);
                PlayerPrefs.Save();
            }
        }
    }
}
