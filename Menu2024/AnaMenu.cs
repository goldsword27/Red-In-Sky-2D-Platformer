using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    public AudioClip buttonClickSound;
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource bileşenini al veya ekle
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void AnaMenuOynaButonu()
    {
        // Butona basılınca ses çal
        PlayButtonClickSound();

        // Ses çalındıktan sonra sahneyi yükle
        SceneManager.LoadScene(1);
    }

    void PlayButtonClickSound()
    {
        if (buttonClickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
