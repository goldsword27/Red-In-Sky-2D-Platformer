using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public Text coinText;
    private int coinCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        coinCount = 0; // Oyun başlatıldığında coin sayacını sıfırla
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++;
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0) + 1; // Toplam coin sayısını artır
        PlayerPrefs.SetInt("TotalCoins", totalCoins); // PlayerPrefs'e yeni değeri kaydet
        PlayerPrefs.Save();
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = coinCount.ToString();
    }
}
