using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public bool blinked;

    public bool canBlink = true;

    [Header("UI")]
    public GameObject BlinkImg;


    private void Update()
    {
        if (canBlink)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                blinked = true;
                Blink();
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                blinked = false;
                Blink();
            }
        }
        if (!canBlink)
        {
            BlinkImg.SetActive(false);
        }

    }
    void Blink()
    {       
        if (blinked == true)
        {
            BlinkImg.SetActive(true);          
        }
        
        if(blinked == false)
        {
            BlinkImg.SetActive(false);          
        }
    }

  
}
