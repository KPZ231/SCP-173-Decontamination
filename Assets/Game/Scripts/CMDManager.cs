using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class CMDManager : MonoBehaviour
{
    [Header("Strings")]
    public string command;   

    [Header("UI")]
    public TMP_InputField inputField;

    [Header("Easter Eggs")]
    public Sprite franeksosna;

    private bool commandAccepted;
    private bool canRender;
    private float timeElaped;
    void Rendering_()
    {
        GameObject _Podkreslenie = GameObject.Find("_Podkreslenie");

        if (timeElaped <= 0)
        {           
            _Podkreslenie.SetActive(false);
            timeElaped = 0.2f;
        }
        else
        {
            _Podkreslenie.SetActive(true);           
        }
    }

    private void Update()
    {
        command = inputField.text;  

        if (canRender)
        {
            timeElaped -= Time.deltaTime;
        }

        if(command == "franeksosna.exe")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                commandAccepted = true;
            }
            if (commandAccepted)
            {
                GameObject.Find("Panel").GetComponent<Image>().sprite = franeksosna;
                GameObject.Find("Panel").GetComponent<Image>().color = Color.white;
            }
        }

        if(command == "y" || command == "exit")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                commandAccepted = true;
            }
            if (commandAccepted)
            {
                MenuManager.Instance.Quit();
                inputField.text = null;
            }            
        }
        if(command == "n")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                commandAccepted = true;
            }
            if(commandAccepted)
            {
                MenuManager.Instance.canReturn = true;
                commandAccepted = false;
                inputField.text = null;
            }
        }
    }  
}
