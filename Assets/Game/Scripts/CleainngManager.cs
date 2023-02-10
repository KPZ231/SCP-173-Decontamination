using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CleainngManager : MonoBehaviour
{
    [Header("Booleans")]
    public bool isCleaning;
    public bool canClean;
    public bool canShowTimer = false;

    [Header("UI")]
    public Slider delaySlider;

    [Header("Camera")]
    public Camera _mainCamera;

    [Header("Parameters")]
    public float delay = 2f;
    public float seableDelay = 2f;

    private void Update()
    {
        delaySlider.value = seableDelay;
        if (canShowTimer == true)
        {
            seableDelay -= Time.deltaTime;
            delaySlider.value = seableDelay;
            delaySlider.gameObject.SetActive(true);
        }
        else
        {
            delaySlider.gameObject.SetActive(false);
            seableDelay = 2;
        }

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
                            canShowTimer = true;
                            
                            GameObject hitted = hit.transform.gameObject;
                            Destroy(hitted);
                            GameManager.instance.decals -= 1;
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
        canShowTimer = true;
        canClean = false;
        isCleaning = false;
      //PlayerMovement
        FindObjectOfType<Player_Movement>().canMove = false;

        //Second Section
        //Waiting...
        yield return new WaitForSeconds(delay);
        canShowTimer = false;
        //Bool
        isCleaning = false;
        canClean = true;
        //PlayerMovement
        FindObjectOfType<Player_Movement>().canMove = true;
    }
}
