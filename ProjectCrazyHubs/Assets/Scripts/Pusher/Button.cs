using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ForceSensor sensors;
    [SerializeField] private float force;
    [SerializeField] private ParticleSystem _system;

    public void OnMouseUpAsButton()
    {
        
        if (sensors != null)
        {
            List<Rigidbody> rigidBodies = sensors.burgers;
            foreach (Rigidbody rb in rigidBodies)
            {
                rb.AddForce(Vector3.forward * 300);
            }
            _system.Play();

        }
    }
}
