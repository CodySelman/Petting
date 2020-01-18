using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettingRaycast : MonoBehaviour
{
    private float petRange = 3.0f;
    private bool inRange;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * petRange);
            bool isRaycastHit = Physics.Raycast(transform.position, transform.forward, out hit, petRange);
            if (isRaycastHit)
            {
                if (hit.collider.tag == "Pettable")
                {
                    // handle pet here
                    Debug.Log("pet");
                }
            }
        } 
        
    }
}
