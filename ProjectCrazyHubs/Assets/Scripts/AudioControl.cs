using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class AudioControl : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private SettingsData _settingsData = new();


    public static AudioControl _instance;

    public Toggle musicToggle;


    private void Awake()
    {
        _instance = this;
        GameManager.GameStart += LoadSettingsData;
        GameManager.GameStart += CheckToggle;
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            AudioManager._instance.Play("BackgroundMusic");
            _settingsData.musicActivated = true;
        }
        else
        {
            AudioManager._instance.Stop("BackgroundMusic");
            _settingsData.musicActivated = false;
        }
    }

    public void LoadSettingsData()
    {
        string path = Application.persistentDataPath + "/settingsData.json";
        if (File.Exists(path))
        {
            string _fromJson = File.ReadAllText(path);
            _settingsData = JsonUtility.FromJson<SettingsData>(_fromJson);

        }
    }

    public void CheckToggle()
    {

        if (_settingsData.musicActivated)
        {
            musicToggle.isOn = true;

        }

    }
    public void DisableDebugMenu()
    {


        AudioManager._instance.Play("ClickSound");
        string _sendJson = JsonUtility.ToJson(_settingsData);
        File.WriteAllText(Application.persistentDataPath + "/settingsData.json", _sendJson);
        Debug.Log(_sendJson);

        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
