using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 500.0f;
    private Rigidbody rb;
    private Vector3 moveDirection;

    private float petRange = 3.0f;
    private bool isPetting = false;
    public bool isArmExtending = false;
    public bool isArmRetracting = false;
    private float armSpeed = 1.5f;

    public new Camera camera;
    public GameObject arms;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isPetting)
        {
            Move();
        }
    }

    private void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        if (Input.GetMouseButtonDown(0) && !isPetting)
        {
            isPetting = true;
            isArmExtending = true;
            PetHandler();
        }

        if (isPetting)
        {
            PetAnimation();
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
                // TODO gate this behind a coroutine to sync up with pet animation
                PettableObjectController pettableObjectController = hit.collider.GetComponentInParent<PettableObjectController>();
                pettableObjectController.PlayPetSound();
            }
        }
    }

    private void PetAnimation()
    {
        Vector3 armPos = arms.transform.localPosition;
        Vector3 extendedArmPos = new Vector3(0.25f, -0.7f, 0.15f);
        Vector3 retractedArmPos = new Vector3(0.25f, -0.7f, -0.5f);

        if (isArmRetracting)
        {
            arms.transform.localPosition = Vector3.MoveTowards(armPos, retractedArmPos, armSpeed * Time.deltaTime);
            if (arms.transform.localPosition == retractedArmPos)
            {
                isArmRetracting = false;
                isArmExtending = false;
                isPetting = false;
            }
        }
        else if (isArmExtending)
        {
            arms.transform.localPosition = Vector3.MoveTowards(armPos, extendedArmPos, armSpeed * Time.deltaTime);
            if (arms.transform.localPosition == extendedArmPos)
            {
                isArmExtending = false;
                isArmRetracting = true;
            }
        }
    }
}
