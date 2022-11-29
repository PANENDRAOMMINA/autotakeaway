using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedControl : MonoBehaviour
{
    [SerializeField]private Animator Animatoranimator;
    [SerializeField] private Sensor _sensor;

   

    void Update()
    {
        if (_sensor.letHimStop == true) Animatoranimator.SetBool("Move", true);
        else Animatoranimator.SetBool("Move", false);
    }

   
}
