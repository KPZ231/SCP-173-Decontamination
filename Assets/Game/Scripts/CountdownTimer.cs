using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;

    public float nowTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {     
        int t = (int)(Time.time - startTime);
        int minutes = t / 60;
        int seconds = t % 60;

        nowTime = t;
        timerText.text = minutes + ":" + seconds.ToString("D2");
    }
}
