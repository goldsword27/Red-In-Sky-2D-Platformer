using UnityEngine;
using UnityEngine.UI; // Standart Unity UI kullanmak için gerekli

public class MainMenuUI : MonoBehaviour
{
    public Text coinsText; // Text bileşeni
    public Text keysText; // Text bileşeni

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        int totalKeys = PlayerPrefs.GetInt("TotalKeys", 0);

        coinsText.text = totalCoins.ToString();
        keysText.text = totalKeys.ToString();
    }
}
