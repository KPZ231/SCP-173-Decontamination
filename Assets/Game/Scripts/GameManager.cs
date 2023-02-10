using System.Collections;
using TMPro;
using UnityEngine;
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
        decals = FindObjectOfType<RandomPointInBox>().decals.Count;
        instance = this;
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
    }
    public void TimeEnded()
    {
        _TimeEndedUI.SetActive(true);
        GameObject.Find("DirtCleaned").GetComponent<TextMeshProUGUI>().text = "Dirt Cleaned: " + decals;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerOffLogic();
        FindObjectOfType<PauseManager>().canPause = false;
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
        Time.timeScale = 0;
    }

    public void KilledUI()
    {
        _KilledUI.SetActive(true);        
        CountdownTimer _timer = FindObjectOfType<CountdownTimer>();
        GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>().text = "You're Time Is: " + _timer.timerText.text;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
