using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettableObjectController : MonoBehaviour
{
    private AudioClip petSound;

    private void Start()
    {
        GameController gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        AudioClip[] petSoundsArr = gameController.petSounds;
        int randomIndex = Mathf.FloorToInt(Random.Range(0, petSoundsArr.Length));
        Debug.Log(randomIndex);
        petSound = petSoundsArr[randomIndex];
    }

    public void PlayPetSound()
    {
        AudioSource.PlayClipAtPoint(petSound, transform.position);
    }
}
