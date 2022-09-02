using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public float turn;
    public Rigidbody rb;
    // Start is called before the first frame update
    // void Start()
    // {
    //     rb = GetComponentInChildren<Rigidbody>();
    // }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(0, 1 * Time.deltaTime * turn, 0, ForceMode.Force);
    }
}
