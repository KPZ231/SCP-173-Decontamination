using UnityEngine;

public class Footsteps : MonoBehaviour
{
    CharacterController cc;
    AudioSource audioS;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        audioS = GetComponent<AudioSource>();
    }



    void Update()
    {
        if (cc.isGrounded == true && cc.velocity.magnitude > 2f && audioS.isPlaying == false)
        {
            if (cc.isGrounded && audioS.isPlaying == false)

            {
                if(FindObjectOfType<Player_Movement>().isRunning == true)
                {
                    FindObjectOfType<RandomSoundFromArray>().RandomRunSound();
                }

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                {
                    FindObjectOfType<RandomSoundFromArray>().RandomStepSound();
                }
                    

                //audioS.volume = Random.Range(0.8f, 1);
                //audioS.pitch = Random.Range(0.8f, 1.1f);
            }
        }
    }
}
