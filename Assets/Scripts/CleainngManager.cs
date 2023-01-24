using System.Collections;
using UnityEngine;
using UnityEngine.Polybrush;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class CleainngManager : MonoBehaviour
{
    [Header("Booleans")]
    public bool isCleaning;
    public bool canClean;


    [Header("Camera")]
    public Camera _mainCamera;

    [Header("Parameters")]
    public float delay = 2f;

    

    private void Update()
    {
        if (canClean)
        {
            Vector3 mousePos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            Debug.DrawRay(ray.origin, ray.direction * 3.5f, Color.green);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3.5f))
            {
                if (hit.collider.CompareTag("Clenable"))
                {
                    if (canClean == true)
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            GameObject hitted = hit.transform.gameObject;
                            Destroy(hitted);
                            Clean();
                        }
                    }
                }
                

            }

        }
    }


    void Clean()
    {  
        if(canClean == true)
        {
            StartCoroutine("Cleaning");
        }            
    }

    IEnumerator Cleaning()
    {      
    //First Section
        //Bool
        canClean = false;
        isCleaning = false;
      //PlayerMovement
        FindObjectOfType<Player_Movement>().canMove = false;

        //Second Section
        //Waiting...
        yield return new WaitForSeconds(delay);
        //Bool
        isCleaning = false;
        canClean = true;
        //PlayerMovement
        FindObjectOfType<Player_Movement>().canMove = true;
    }
}
