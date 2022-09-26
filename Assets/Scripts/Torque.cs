using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public float turn;
    public Rigidbody rb;
    void FixedUpdate()
    {
        rb.AddTorque(0, 1 * Time.deltaTime * turn, 0, ForceMode.Force);
        
    }
}
