using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGameScene : MonoBehaviour
{
    public GameObject InGameScreen, PauseScreen;

    public GameObject joystick;
    public GameObject joystickHandle;
    public GameObject shotButton;
    public GameObject jumpButton;

    void Start()
    {
        // Joystick ve diğer buton referanslarını kontrol et
        if (joystick == null)
        {
            joystick = GameObject.FindWithTag("Joystick");
        }

        if (joystick != null && joystickHandle == null)
        {
            joystickHandle = joystick.transform.Find("Handle")?.gameObject;
        }

        if (shotButton == null)
        {
            shotButton = GameObject.FindWithTag("ShotButton");
        }

        if (jumpButton == null)
        {
            jumpButton = GameObject.FindWithTag("JumpButton");
        }
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        InGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
        SetActiveAllControls(false);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        InGameScreen.SetActive(true);
        SetActiveAllControls(true);
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LevelCompleted()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Time.timeScale = 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tebrikler! Tüm seviyeleri tamamladınız!");
            SceneManager.LoadScene("MainMenu");
        }
    }

    void SetActiveAllControls(bool isActive)
    {
        if (joystick != null)
        {
            joystick.SetActive(isActive);
        }

        if (joystickHandle != null)
        {
            joystickHandle.SetActive(isActive);
        }

        if (shotButton != null)
        {
            shotButton.SetActive(isActive);
        }

        if (jumpButton != null)
        {
            jumpButton.SetActive(isActive);
        }
    }
}
