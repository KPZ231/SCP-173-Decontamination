using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.AI;
using System.Collections;
public class SCP_173_Behaviour : MonoBehaviour
{
    [Header("Behaviour")]
    public bool behaviourActive;

    [Header("Booleans")]
    public bool canMove;
    public bool canKill;
    private bool soundPlay = true;

    [Header("AI")]
    public NavMeshAgent _Scp_173_Brain;
    public Renderer cameraRenderer;

    [Header("Distance")]
    public float distance;
    public float killingDistance = 4f;


    Vector3 playerPos;


    private void Update()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;


        distance = Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, this.transform.position);
       

        #region Logika SCP-173
        ///Logika SCP    
        if (behaviourActive)
        {
            if(distance <= 1.8f)
            {
                Kill();
            }


            if (!cameraRenderer.isVisible)
            {
               
                transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                _Scp_173_Brain.isStopped = false;
                canMove = true;
                if (distance <= killingDistance)
                {
                    canKill = true;
                    if (canKill)
                    {
                        if (FindObjectOfType<PlayerManager>().blinked || !cameraRenderer.isVisible)
                        {
                            Kill();
                        }

                        if (FindObjectOfType<PlayerManager>().blinked == false || !cameraRenderer.isVisible)
                        {
                            return;
                        }
                    }
                }
                if (distance >= killingDistance)
                {
                   
                    canKill = false;
                    if (canMove)
                    {
                        GameObject.FindGameObjectWithTag("SCP").transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                        _Scp_173_Brain.SetDestination(playerPos);
                    }
                }
            }
            if (cameraRenderer.isVisible)
            {

                if (soundPlay)
                {
                    FindObjectOfType<AudioManager>().Play("Horror_1");
                    soundPlay = false;
                }

                _Scp_173_Brain.isStopped = true;

                canMove = false;

                if (FindObjectOfType<PlayerManager>().blinked == true)
                {
                    if (FindObjectOfType<PlayerManager>().blinked == true && distance <= killingDistance)
                    {
                        Kill();
                    }

                    transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
                    _Scp_173_Brain.isStopped = false;
                    canMove = true;
                    _Scp_173_Brain.SetDestination(playerPos);
                }
            }
        }
        #endregion

    }

    private void VisualsForKilling()
    {
        if (visualsForKilling)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Rigidbody>().AddForce(Vector3.left * 1f, ForceMode.Impulse);
        }
    }

    bool visualsForKilling = true;
    void Kill()
    {
        GameManager.instance.KilledUI();
        _Scp_173_Brain.Warp(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position);
        VisualsForKilling();

        //Camera
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BoxCollider>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Rigidbody>().useGravity = true;

        //Player
        GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>().enabled = false;
        FindObjectOfType<Player_Movement>().canMove = false;
        FindObjectOfType<PlayerManager>().canBlink = false;
        FindObjectOfType<PlayerManager>().blinked = false;
        FindObjectOfType<CleainngManager>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").transform.DetachChildren();

        //Broom
        GameObject.FindGameObjectWithTag("Broom").SetActive(false);

        //SCP
        behaviourActive = false;

        //Boolean
        visualsForKilling = false;
        

        
        
    }

}
