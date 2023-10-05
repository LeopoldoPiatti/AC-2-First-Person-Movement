using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded;

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1))
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        { 
            grounded = true;
        }
    }
}
