using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 500.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    private float petRange = 3.0f;

    public new Camera camera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        if (Input.GetMouseButtonDown(0))
        {
            PetHandler();
        }
        
    }

    private void Move()
    {
        rb.velocity = moveDirection * speed * Time.deltaTime;
    }

    private void PetHandler()
    {
        RaycastHit hit;
        Vector3 cameraPos = camera.transform.position;
        Vector3 cameraForward = camera.transform.forward;
        Debug.DrawRay(cameraPos, cameraForward * petRange);
        bool isRaycastHit = Physics.Raycast(cameraPos, cameraForward, out hit, petRange);
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
