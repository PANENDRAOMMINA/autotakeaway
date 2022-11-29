using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSensor : MonoBehaviour
{
    public List<Rigidbody> burgers;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("burger"))
        {
            burgers.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("burger"))
        {
            burgers.Remove(other.gameObject.GetComponent<Rigidbody>());
        }
    }
}
