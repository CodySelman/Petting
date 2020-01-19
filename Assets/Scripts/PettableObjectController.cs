using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettableObjectController : MonoBehaviour
{
    private AudioClip petSound;
    private AudioSource audioSource;

    public int hp;
    private bool isDead = false;
    private int speed;

    private void Start()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        AudioClip[] petSoundsArr = gameController.petSounds;
        int randomIndex = Mathf.FloorToInt(Random.Range(0, petSoundsArr.Length));
        petSound = petSoundsArr[randomIndex];

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = petSound;

        speed = Mathf.FloorToInt(Random.Range(5, 10));
    }

    private void Update()
    {
        if (isDead)
        {
            Vector3 deathPos = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, deathPos, speed * Time.deltaTime);
        }
        if (transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    public void GetTickled()
    {
        audioSource.Play();
        hp--;
        if (hp <= 0)
        {
            isDead = true;
        }
    }
}
