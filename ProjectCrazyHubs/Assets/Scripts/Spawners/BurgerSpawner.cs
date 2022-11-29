using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerSpawner : MonoBehaviour
{
    [SerializeField]private GameObject burger;
    [SerializeField] private int numberOfBurgersNeedToInstantiate;
    public List<GameObject> poolObjects;
    [SerializeField] private int startTime, spawningRate;
    // Start is called before the first frame update
    public void OnEnable()
    {
        GameManager.GameOver += StopInvoke;
        GameManager.GameWin += StopInvoke;
    }

    void Awake()
    {
        InvokeRepeating("SpawnBurgers", startTime, spawningRate);
       
        GameManager.numberOfBurgersOnLoad = numberOfBurgersNeedToInstantiate;
    }

    public void SpawnBurgers()
    {
        if (numberOfBurgersNeedToInstantiate > 0)
        {
            GetBurger();
            
            GameManager.numberOfBurgersOnLoad = --numberOfBurgersNeedToInstantiate;
        }
    }
    private GameObject GetBurger()//this method can be used in getting the pipe 
    {
        // Go through the list and find out which pipe is inactive.
        for (int i = 0; i < poolObjects.Count; i++)
        {

            if (!poolObjects[i].activeSelf)
            {
                poolObjects[i].SetActive(true);
                poolObjects[i].transform.position = this.gameObject.transform.position;
                return poolObjects[i];
            }
        }

        // if there are no pipes inactive in the pool then create a new one.
        GameObject newBurger = Instantiate(burger, this.transform.position, Quaternion.identity);
        newBurger.transform.SetParent(this.transform);
        poolObjects.Add(newBurger);

        return newBurger;
    }
    private void StopInvoke()
    {
        
    }

    public void OnDisable()
    {
        GameManager.GameOver -= StopInvoke;
        GameManager.GameWin -= StopInvoke;
    }
}
