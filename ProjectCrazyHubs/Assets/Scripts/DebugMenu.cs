using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

public class DebugMenu : MonoBehaviour
{

    public Toggle cameraType;
    public Toggle customerType;

    
    [SerializeField]private Vector3 position1,rotation1;
    [SerializeField]private Vector3 position2, rotation2;

    public static DebugMenu _instance;
    [SerializeField] private CustomerSpawner _spawner;

    public GameObject car, human;

   

    public void ChangeCameraType()
    {
        if(cameraType.isOn)
        {
            Camera.main.transform.SetPositionAndRotation(position2, Quaternion.Euler(rotation2));
            Camera.main.orthographic = true;
            Camera.main.orthographicSize = 10;

        }
        else
        {
            Camera.main.transform.SetPositionAndRotation(position1, Quaternion.Euler(rotation1));
            Camera.main.orthographic = false;
           
        }
    }

    public void ChangeCustomerType()
    {
        if (customerType.isOn) _spawner.customer = car;
        else _spawner.customer = human;
    }

    
}
