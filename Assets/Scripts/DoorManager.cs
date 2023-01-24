using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [Header("Booleans")]
    public bool canOpen = true;
    public bool opened;

    [Header("Objects")]
    public GameObject _door;

    [Header("Animation Parameters")]
    [Range(0.5f, 3f)]
    public float animTime = 1f;

    private void Start()
    {
        canOpen = true;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        Debug.DrawRay(ray.origin, ray.direction * 5, Color.green);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
            if (hit.collider.CompareTag("Door"))
            {        
                if (Input.GetKeyDown(KeyCode.E))
                {                    
                    if (canOpen)
                    {
                        StartCoroutine("Opening");
                        opened = true;

                        if (opened)
                        {
                            _door.GetComponent<Animator>().Play("Door_Close");
                            opened = false;
                        }                     
                        
                        if(!opened)
                        {
                            opened = false;
                            _door.GetComponent<Animator>().Play("Door_Open");
                        }                     
                    }     
                }
            }
        }
    }
    IEnumerator Opening()
    {
        canOpen = false;
        yield return new WaitForSeconds(animTime);
        canOpen = true;
    }
}