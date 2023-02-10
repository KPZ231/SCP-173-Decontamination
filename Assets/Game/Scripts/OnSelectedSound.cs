using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class OnSelectedSound : MonoBehaviour, IPointerEnterHandler
{     
    public AudioClip selectedSound;
    private AudioSource mainSource;

    void Start()
    {
        mainSource = GameObject.Find("MainSource").GetComponent<AudioSource>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        mainSource.PlayOneShot(selectedSound);
    }
}
