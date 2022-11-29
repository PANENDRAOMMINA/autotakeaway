using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Human : MonoBehaviour
{
    public enum Direction  {left,right,forward,backward} 
    //private direction _direction=direction.backward;

    [SerializeField]private Sensor sensor;
    private const float offsetZ=16f;
    [SerializeField] private float speed=3f,directionTime,price;
    private const int reverseDirection = -1;
    [SerializeField]private  int left,right,forward,backward;  
   
  
   private void Awake()
   {
        // slider_Energy_Constant=Hunger_Food.value/Hunger;
        ChangeDir(Direction.backward);
       
        
   }


    // energy decreases per time 
    private void Update()
    {   
        if (!sensor.letHimStop)
        {
            Move();
        }
    }

    private void ChangeDir(Direction dir)
    {
        if (dir == Direction.left) transform.rotation = Quaternion.Euler(0, left, 0);
        else if (dir == Direction.right) transform.rotation = Quaternion.Euler(0, right, 0);
        else if (dir == Direction.forward) transform.rotation = Quaternion.Euler(0, forward, 0);
        else if (dir == Direction.backward) transform.rotation = Quaternion.Euler(0, backward, 0);
       
    }

    public void Move()
    {
        Vector3 v = transform.position;
        v += transform.forward * Time.deltaTime*speed;
        transform.position = v;
        if(transform.position.z>offsetZ)
        {
            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("burger"))
        {
            GameManager.numberOfCustomers--;
            FindObjectOfType<GameManager>().IncreaseCash(5);
            collision.gameObject.SetActive(false);
            sensor.letHimStop = false;
            sensor.eaten = true;
            StartCoroutine(ChangeDirection(directionTime));
        }
    }

 
    IEnumerator ChangeDirection(float time)
    {
        speed = 5f;
        ChangeDir(Direction.right);
        yield return new WaitForSecondsRealtime(time);
        ChangeDir(Direction.forward);
    }
   
}
