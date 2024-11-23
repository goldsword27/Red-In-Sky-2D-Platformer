using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;

    void Start()
    {
        // Kaydedilmiş ses seviyesini yükle
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // SettingsPanel'i başlangıçta devre dışı bırak
        settingsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        // Ses seviyesini ayarla
        AudioManager.instance.SetVolume(volume);
    }

    public void OpenTelegram()
    {
        // Telegram bağlantısını aç
        Application.OpenURL("https://t.me/RemotePhoneRepair");
    }
}
