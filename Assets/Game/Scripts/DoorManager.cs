using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class DoorManager : MonoBehaviour
{
    [Header("Booleans")]
    public bool canOpen = true;
    public bool opened;

    [Header("Animation Parameters")]
    [Range(0.5f, 3f)]
    public float animTime = 1f;

    [Header("Keycard")]
    public Item keycard;

    [Header("Door Audio Clips")]
    public AudioClip open;
    public AudioClip close;

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

            #region Door_Button_2

            if (hit.collider.CompareTag("Door_Button_2"))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (canOpen)
                    {
                        FindObjectOfType<AudioManager>().Play("Button_Click_1");
                        StartCoroutine("Opening");
                        opened = true;

                        if (opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Door_Open_1");
                            hit.transform.gameObject.GetComponentInParent<Animator>().Play("Door_Close");
                            opened = false;
                        }

                        if (!opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Door_Close_1");
                            opened = false;
                            hit.transform.gameObject.GetComponentInParent<Animator>().Play("Door_Open");
                        }
                    }
                }
            }

            #endregion

            #region Door
            if (hit.collider.CompareTag("Door"))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (canOpen)
                    {
                        FindObjectOfType<AudioManager>().Play("Button_Click_1");
                        StartCoroutine("Opening");
                        opened = true;

                        if (opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Door_Open_1");
                            hit.transform.gameObject.GetComponent<Animator>().Play("Door_Close");
                            opened = false;
                        }

                        if (!opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Door_Close_1");
                            opened = false;
                            hit.transform.gameObject.GetComponent<Animator>().Play("Door_Open");
                        }
                    }
                }
            }
            #endregion

            #region Keycard_Lvl_1_Door

            if (hit.collider.CompareTag("Keycard_Lvl_1_Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (FindObjectOfType<InventoryManager>().items.Contains(keycard))
                    {
                        if (canOpen)
                        {
                            FindObjectOfType<AudioManager>().Play("Card_Accept");
                            StartCoroutine("Opening");
                            opened = true;

                            if (opened)
                            {
                                FindObjectOfType<AudioManager>().Play("Door_Open_1");
                                hit.transform.gameObject.GetComponent<Animator>().Play("Door_Close");
                                opened = false;
                            }

                            if (!opened)
                            {
                                FindObjectOfType<AudioManager>().Play("Door_Close_1");
                                opened = false;
                                hit.transform.gameObject.GetComponent<Animator>().Play("Door_Open");
                            }
                        }
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("Card_Null");

                        StartCoroutine(TextShow());
                    }
                }
            }

            #endregion

            #region Cont_Door
            if (hit.collider.CompareTag("Cont_Door"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (canOpen)
                    {
                        StartCoroutine("Opening");
                        opened = true;

                        if (opened)
                        {
                            GameObject.Find("BigdoorFrame").GetComponent<AudioSource>().PlayOneShot(close, 0.5f);
                            FindObjectOfType<AudioManager>().Play("Lever_Switch");
                            FindObjectOfType<SCP_173_Behaviour>().behaviourActive = false;
                            GameObject.Find("FabConvert.com_leverhandle").GetComponent<Animator>().Play("Lever_Off");
                            hit.transform.gameObject.GetComponent<Animator>().Play("Door_Close");
                            opened = false;
                        }

                        if (!opened)
                        {
                            GameObject.Find("BigdoorFrame").GetComponent<AudioSource>().PlayOneShot(open, 0.5f);
                            FindObjectOfType<AudioManager>().Play("Lever_Switch");
                            FindObjectOfType<SCP_173_Behaviour>().behaviourActive = true;
                            GameObject.Find("FabConvert.com_leverhandle").GetComponent<Animator>().Play("Lever_On");
                            opened = false;
                            hit.transform.gameObject.GetComponent<Animator>().Play("Door_Open");
                        }
                    }
                }
            }
            #endregion

            #region Shutters
            if (hit.collider.CompareTag("Shutters"))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (canOpen)
                    {
                        FindObjectOfType<AudioManager>().Play("Button_Click_1");
                        StartCoroutine("Opening");
                        opened = true;

                        if (opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Shutter_Open");
                            GameObject.Find("Shutters_Main_OBJ").GetComponent<Animator>().Play("Shutters_Close");
                            opened = false;
                        }

                        if (!opened)
                        {
                            FindObjectOfType<AudioManager>().Play("Shutter_Close");
                            opened = false;
                            GameObject.Find("Shutters_Main_OBJ").GetComponent<Animator>().Play("Shutters_Open");
                        }
                    }
                }
            }

            #endregion
        }
    }


    IEnumerator TextShow()
    {
        GameObject.Find("InformationText").GetComponent<TextMeshProUGUI>().text = "For This Door You Need A Card";
        GameObject.Find("InformationText").GetComponent<Animator>().Play("Draw_In_Text");
        yield return new WaitForSeconds(2f);

        GameObject.Find("InformationText").GetComponent<Animator>().Play("Draw_Out_Text");
        yield return new WaitForSeconds(.40f);
        GameObject.Find("InformationText").GetComponent<TextMeshProUGUI>().text = "";
    }
    IEnumerator Opening()
    {
        canOpen = false;
        yield return new WaitForSeconds(animTime);
        canOpen = true;
    }
}