using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject levelCompleteCanvas; // Deaktif Canvas
    public Button[] levelButtons; // Level butonları
    public GameObject lockIconPrefab; // Kilit ikonu prefabı
    private int totalLevels = 6;

    void Start()
    {
        // Canvas başlangıçta deaktif olmalı
        if (levelCompleteCanvas != null)
            levelCompleteCanvas.SetActive(false);

        // Eğer PlayerPrefs'de level kilit durumu yoksa, başlat
        if (!PlayerPrefs.HasKey("Level1"))
        {
            PlayerPrefs.SetInt("Level1", 1); // 1: Kilitsiz, 0: Kilitli
            for (int i = 2; i <= totalLevels; i++)
            {
                PlayerPrefs.SetInt("Level" + i, 0);
            }
        }

        // Level butonlarını ayarla
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = i + 1;
            if (PlayerPrefs.GetInt("Level" + level) == 1)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
                GameObject lockIcon = Instantiate(lockIconPrefab, levelButtons[i].transform);
                lockIcon.transform.SetParent(levelButtons[i].transform, false);
            }
            int levelIndex = i + 1; // Yerel değişkeni kullan
            levelButtons[i].onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    public void LoadLevel(int level)
    {
        // Mevcut karakter bileşenlerini sıfırlayın
        CharacControl characControl = FindObjectOfType<CharacControl>();
        BulletManager bulletManager = FindObjectOfType<BulletManager>();

        if (characControl != null)
        {
            characControl.ResetSpeed();
        }

        if (bulletManager != null)
        {
            bulletManager.ResetBulletStats();
        }

        // Time.timeScale'ı varsayılan değere döndür
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("Level" + level) == 1)
        {
            SceneManager.LoadScene("Level" + level);
        }
        else
        {
            Debug.Log("Level " + level + " is locked.");
        }
    }

    public void CompleteLevel(int level)
    {
        if (level < totalLevels)
        {
            PlayerPrefs.SetInt("Level" + (level + 1), 1);
            PlayerPrefs.Save();
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        Start(); // Başlangıç seviyesine geri dön
    }
}
