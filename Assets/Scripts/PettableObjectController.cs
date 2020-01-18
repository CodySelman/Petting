using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PettableObjectController : MonoBehaviour
{
    public AudioClip petSound;

    public void PlayPetSound()
    {
        AudioSource.PlayClipAtPoint(petSound, transform.position);
    }
}
