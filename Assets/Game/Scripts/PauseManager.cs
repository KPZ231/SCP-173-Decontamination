using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    public GameObject Pause_Panel;

    public bool Paused = false;

    public bool canPause;


    private void Start()
    {
        canPause = true;
    }

    private void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Paused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        
    }

    public void Pause()
    {
        Pause_Panel.SetActive(true);
        FindObjectOfType<Player_Movement>().canMove = false;
        FindObjectOfType<SCP_173_Behaviour>().behaviourActive = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        Paused = true;
    }
    public void Resume()
    {
        Pause_Panel.SetActive(false);
        FindObjectOfType<Player_Movement>().canMove = true;
        FindObjectOfType<SCP_173_Behaviour>().behaviourActive = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        Paused = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
