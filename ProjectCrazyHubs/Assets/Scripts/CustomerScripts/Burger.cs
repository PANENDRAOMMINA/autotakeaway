using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
    public void OnEnable()
    {
        GameManager.numberOfBurgersInActive++;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {

            gameObject.SetActive(false);
            
        }
    }

    public void OnDisable()
    {
        GameManager.numberOfBurgersInActive--;
    }
}
