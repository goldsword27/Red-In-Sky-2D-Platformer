using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
    public static KeyCounter instance;

    public Text keyText;
    private int keyCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        keyCount = 0; // Oyun başlatıldığında anahtar sayacını sıfırla
        UpdateKeyText();
    }

    public void AddKey()
    {
        keyCount++;
        int totalKeys = PlayerPrefs.GetInt("TotalKeys", 0) + 1; // Toplam anahtar sayısını artır
        PlayerPrefs.SetInt("TotalKeys", totalKeys); // PlayerPrefs'e yeni değeri kaydet
        PlayerPrefs.Save();
        UpdateKeyText();
    }

    private void UpdateKeyText()
    {
        keyText.text = keyCount.ToString();
    }
}
