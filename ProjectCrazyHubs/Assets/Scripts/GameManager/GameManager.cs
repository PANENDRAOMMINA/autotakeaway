using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static int numberOfBurgersInActive;
    public static int numberOfCustomers;
    public static int numberOfBurgersOnLoad;

    private bool visited = false;
    public float cash;
    public TMP_Text cashAmount;
    [SerializeField] private TMP_Text numberOfCustomerstext;
    [SerializeField] private TMP_Text numberOfBurgersText;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject debugPanel;
    [SerializeField] private GameObject winPanel;

    public delegate void GameInitiator();
    public static event GameInitiator GameOver;
    public static event GameInitiator GameWin;
    public static event GameInitiator GameStart;
    

    
    public void OnEnable()
    {
        
        GameOver += SetGameOver;
        GameWin += SetWinMenu;
        
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        numberOfCustomerstext.text = numberOfCustomers.ToString();
        numberOfBurgersText.text = numberOfBurgersOnLoad.ToString();
        if(SceneManager.GetActiveScene().buildIndex!=0&&visited==false)
        {
            if (numberOfBurgersInActive == 0 && numberOfCustomers > 0 && numberOfBurgersOnLoad == 0)
            {
                GameOver.Invoke();
                Debug.Log("win");
                Time.timeScale = 0f;
                visited = true;
            }
            if (numberOfCustomers == 0)
            {
                GameWin.Invoke();
                Debug.Log("win");
                Time.timeScale = 0f;
                visited = true;
            }
        }
        
    }

    public void IncreaseCash(float x)
    {
        cash+=x;
        cashAmount.text = cash.ToString();
    }

    public void SetGameOver()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void SetDebugMenu()
    {
        debugPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void DisableDebugMenu()
    {
        debugPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void SetWinMenu()
    {
       
        winPanel.SetActive(true);
        int levelReached = PlayerPrefs.GetInt("Level", 1);
        levelReached++;
        PlayerPrefs.SetInt("Level", levelReached);
    }

    public void OnDisable()
    {

        GameOver -= SetGameOver;
        GameWin -= SetWinMenu;
    }

}
