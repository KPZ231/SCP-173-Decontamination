using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundFromArray : MonoBehaviour
{

    public AudioClip[] stepSound;
    public AudioClip[] runSound;
    public AudioSource source;

    public void RandomStepSound()
    {
        source.PlayOneShot(stepSound[Random.Range(0, stepSound.Length)]);
    }
    public void RandomRunSound()
    {
        source.PlayOneShot(runSound[Random.Range(0, runSound.Length)]);
    }
}
