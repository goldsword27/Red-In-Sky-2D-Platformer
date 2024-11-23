using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSec : MonoBehaviour
{
    public void Level1()
    {
        LoadLevel(1);
    }
    public void Level2()
    {
        LoadLevel(2);
    }
    public void Level3()
    {
        LoadLevel(3);
    }
    public void Level4()
    {
        LoadLevel(4);
    }
    public void Level5()
    {
        LoadLevel(5);
    }
    public void Level6()
    {
        LoadLevel(6);
    }
    public void LeAnaMenuyeDon()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadLevel(int level)
    {
        if (PlayerPrefs.GetInt("Level" + level, 0) == 1)
        {
            SceneManager.LoadScene(level + 1); // Level scenes are assumed to be sequentially indexed
        }
        else
        {
            Debug.Log("Level " + level + " is locked.");
        }
    }
}
