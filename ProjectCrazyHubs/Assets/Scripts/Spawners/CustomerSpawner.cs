using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] spawnZones;
    public GameObject customer;
    [SerializeField]private int numberOfCustomers;
    public List<GameObject> poolObjects;
    public int amountToPool;
    [SerializeField] private int startTime, spawningRate;

    private void OnEnable()
    {
        GameManager.GameOver += StopInvoke;
        GameManager.GameWin += StopInvoke;
    }
    private void Awake()
    {
        GameManager.numberOfCustomers = numberOfCustomers;
        
        InvokeRepeating("SpawnCustomers",startTime,spawningRate);
      
    }

   
    public void SpawnCustomers()
    {
        if (numberOfCustomers > 0)
        {
            int randomZone = Random.Range(0, spawnZones.Length);
            GetCustomer(randomZone);
            numberOfCustomers--;
            
        }
    }
    private GameObject GetCustomer(int zoneNumber)//this method can be used in getting the pipe 
    {
        // Go through the list and find out which pipe is inactive.
        for (int i = 0; i < poolObjects.Count; i++)
        {

            if (!poolObjects[i].activeSelf)
            {
                poolObjects[i].SetActive(true);
                return poolObjects[i];
            }
        }

        // if there are no pipes inactive in the pool then create a new one.
        GameObject newCustomer = Instantiate(customer, spawnZones[zoneNumber].position, Quaternion.identity);
        newCustomer.transform.SetParent(transform);
        poolObjects.Add(newCustomer);

        return newCustomer;
    }


    private void StopInvoke()
    {
       
    }
    private void OnDisable()
    {
        GameManager.GameOver -= StopInvoke;
        GameManager.GameWin -= StopInvoke;
    }
}
