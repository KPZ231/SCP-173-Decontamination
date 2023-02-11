using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = 1;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound =>sound.name == name);
        s.source.Play();
       
        if(s == null)
        {
            Debug.LogWarning("didn't found the sound");
        }
    }    
}
