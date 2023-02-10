using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public TextMeshProUGUI versionText;

    [HideInInspector]
    public bool canReturn;

    private void Awake()
    {
        Instance = this; 
    }

    public void Update()
    {
        versionText.text = Application.version;

        if (canReturn)
        {
            ReturnFromQuiting();
        }
    }
    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void Play()
    {
        StartCoroutine(waitForAnim(2)); 
    }

    public void ReturnFromQuiting()
    {
        Debug.Log("Returned");
        GameObject.Find("QuitMenu").SetActive(false);
        canReturn = false;
    }

    IEnumerator waitForAnim(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
