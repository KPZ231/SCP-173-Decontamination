using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    [HideInInspector]
    public bool blinked;

    public bool canBlink = true;

    [Header("UI")]
    public GameObject BlinkImg;
    public Slider BlinkSlider;

    [Header("Parameters")]
    public float blinkTime;

    private void Update()
    {
        blinkTime -= Time.deltaTime;

        BlinkSlider.value = blinkTime;

        if (blinkTime <= 0)
        {
            StartCoroutine("Blinking");   
        }
        if (canBlink)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {               
                blinkTime = 7;
                blinked = true;
                Blink();
            }
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                blinkTime = 7;
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
  
    IEnumerator Blinking()
    {
        blinked = true;
        Blink();
        blinkTime = 7;
        yield return new WaitForSeconds(0.12f);
        blinked = false;
        Blink();
    }

}
