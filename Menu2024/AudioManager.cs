using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource; // Müzik çalmak için kullanılan AudioSource
    public AudioClip defaultMusic; // Ana menü, ayarlar ve diğer seviyeler için sabit müzik
    public AudioClip level1Music; // Level 1 için özel müzik
    public AudioClip level2Music; // Level 2 için özel müzik

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahneler arasında bu nesnenin yok olmamasını sağlar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Varsayılan olarak sabit müziği çal
        PlayMusic(defaultMusic);
        LoadVolume();
        SceneManager.sceneLoaded += OnSceneLoaded; // Sahne yüklendiğinde tetiklenir
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("sahne yüklendi = " + scene.name);
        // Sahneye göre müziği değiştir
        if (scene.name == "Level_1")
        {
            PlayMusic(level1Music);
        }
        else if (scene.name == "Level_2")
        {
            PlayMusic(level2Music);
        }
        else if (scene.name.StartsWith("Level_"))
        {
            PlayMusic(level2Music); // Level 2 müziği ile aynı müziği çal
        }
        else if (scene.name == "MainMenu")
        {
            PlayMusic(defaultMusic);
        }
        else
        {
            PlayMusic(defaultMusic);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
