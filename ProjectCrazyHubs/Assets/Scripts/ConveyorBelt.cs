using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField]private float speed = 1f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position -= transform.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);
        
    }
}
