using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip petSound;
    private Vector3 extendedArmPos = new Vector3(0.25f, -0.7f, 0.2f);
    private Vector3 retractedArmPos = new Vector3(0.25f, -0.7f, -0.1f);
    private int score = 0;
    private string nextLevel;
    private int winningScore;

    public new Camera camera;
    public GameObject arms;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        arms.transform.localPosition = retractedArmPos;
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level 1")
        {
            winningScore = 10;
            nextLevel = "1-2 Transition";
        } else if (sceneName == "Level 2")
        {
            winningScore = 24;
            nextLevel = "2-3 Transition";
        } else if (sceneName == "Level 3")
        {
            winningScore = 45;
            nextLevel = "3-4 Transition";
        } else if (sceneName == "Level 4")
        {
            winningScore = 15;
            nextLevel = "Game Over";
        }
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
                if (hit.collider.GetComponent<PettableObjectController>().hp == 1)
                {
                    score++;
                    if (score >= winningScore)
                    {
                        SceneManager.LoadScene(nextLevel);
                    }
                }

                AudioSource.PlayClipAtPoint(petSound, transform.position);
                PettableObjectController pettableObjectController = hit.collider.GetComponentInParent<PettableObjectController>();
                pettableObjectController.GetTickled();
            }
        }
    }

    private void PetAnimation()
    {
        Vector3 armPos = arms.transform.localPosition;

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
