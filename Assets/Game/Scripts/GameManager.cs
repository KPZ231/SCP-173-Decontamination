using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int decals;

    private bool canPlaySound = true;

    [Header("UI")]
    public GameObject _EndGameUI;
    public GameObject _KilledUI;
    public GameObject _TimeEndedUI;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(StartFun());
        decals = FindObjectOfType<RandomPointInBox>().decals.Count;
        instance = this;
    }

    IEnumerator StartFun()
    {
        FindObjectOfType<Player_Movement>().canMove = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FindObjectOfType<PauseManager>().canPause = false;

        yield return new WaitForSeconds(8);

        OkClicked();
    }

    public void RestartLevel()
    {
        FindObjectOfType<Player_Movement>().canMove = true;
        FindObjectOfType<PauseManager>().Paused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
        Debug.Log("Restarted...");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }

    private void Update()
    {
        if(PlayerPrefs.HasKey("Allowed Post_Processing"))
        {           
            Camera.main.gameObject.GetComponent<PostProcessLayer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            RestartLevel();
        }

        if(FindObjectOfType<CountdownTimer>().nowTime > 300)
        {
            TimeEnded();
        }

        if(decals <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            OkClicked();
        }
    }

    public void OkClicked()
    {
        FindObjectOfType<CountdownTimer>().start = true;
        FindObjectOfType<Player_Movement>().canMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<PauseManager>().canPause = true;
        Destroy(GameObject.Find("Idea"));
    }

    public void TimeEnded()
    {
        _TimeEndedUI.SetActive(true);
        GameObject.Find("DirtCleaned").GetComponent<TextMeshProUGUI>().text = "Dirt Cleaned: " + decals;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerOffLogic();
        FindObjectOfType<PauseManager>().canPause = false;
        PlayerPrefs.SetString("Time", FindObjectOfType<CountdownTimer>().timerText.text);
        Time.timeScale = 0;
    }

    public void EndGame()
    {
        _EndGameUI.SetActive(true);
        GameObject.Find("DirtCleaned").GetComponent<TextMeshProUGUI>().text = "Dirt Cleaned: " + decals;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerOffLogic();
        FindObjectOfType<PauseManager>().canPause = false;
        PlayerPrefs.SetString("Time", FindObjectOfType<CountdownTimer>().timerText.text);
        Time.timeScale = 0;
    }

    public void KilledUI()
    {
        _KilledUI.SetActive(true);        
        CountdownTimer _timer = FindObjectOfType<CountdownTimer>();
        GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>().text = "You're Time Is: " + _timer.timerText.text;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerPrefs.SetString("Time", FindObjectOfType<CountdownTimer>().timerText.text);
        PlayerOffLogic();
        StartCoroutine(killing());
        if (canPlaySound)
        {
            FindObjectOfType<AudioManager>().Play("Player_Kill_1");
            canPlaySound = false;
        }      
        FindObjectOfType<PauseManager>().canPause = false;
    }


    IEnumerator killing()
    {
        yield return new WaitForSeconds(0.2f);

        Time.timeScale = 0;
    }


    public void PlayerOffLogic()
    {
        FindObjectOfType<Player_Movement>().canMove = false;
        FindObjectOfType<PlayerManager>().canBlink = false;
        FindObjectOfType<PlayerManager>().blinked = false;
        FindObjectOfType<CleainngManager>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").transform.DetachChildren();
    }


}
