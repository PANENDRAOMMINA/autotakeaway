using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject AboutPanel;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

   public void Play()
    {
        int levelSelected=PlayerPrefs.GetInt("Level",1);
        
       
        SceneManager.LoadScene(levelSelected);
    }
    public void NextLevel()
    {
        Time.timeScale=1f;
        int levelReached = PlayerPrefs.GetInt("Level");
        
        if (levelReached <= 3)
            SceneManager.LoadScene(levelReached);
        else
        {
            SceneManager.LoadScene(0);
            PlayerPrefs.DeleteKey("Level");
        }
    }

    public void EnableAboutPanel()
    {
        AboutPanel.SetActive(true);
    }
    public void DisableAboutPanel()
    {
        AboutPanel.SetActive(false);
    }
}
