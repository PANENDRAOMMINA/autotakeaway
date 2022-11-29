using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Sensor : MonoBehaviour
{
    private const float _maxDistance=1f;
    public bool letHimStop,eaten;
    public void FixedUpdate()
    {
        if(Physics.Raycast(transform.position,transform.forward,_maxDistance)&&!eaten)
        {
            letHimStop = true;
        }
        else
        {
            letHimStop = false;
        }
    }

    public void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position,transform.forward * _maxDistance,Color.red);
    }


}
