using TMPro;
using UnityEngine;

public class ReadRecord : MonoBehaviour
{

    public TextMeshProUGUI recordText;

    public string time;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Time"))
        {
            recordText.gameObject.SetActive(true);
            time = PlayerPrefs.GetString("Time");
        }
        else
        {
            recordText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (recordText.gameObject.activeSelf == true)
        {
            recordText.text = "Previous Record Is: " + time.ToString();
        }
        else
        {
            return;
        }     
    }

}
