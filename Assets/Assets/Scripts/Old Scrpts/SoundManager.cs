using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] sounds;

    private void Awake()
    {
        if (SoundManager.Instance == null)
            SoundManager.Instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        foreach (var sound in sounds)
        {
            sound.audioSource = this.gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
            if (sound.playOnAwake)
                sound.audioSource.Play();
        }
    }

    public void PlaySound(string soundName)
    {
        Sound s = Array.Find(sounds, x => x.name == soundName);
        if (s != null)
        {
            s.audioSource.pitch = s.pitch + UnityEngine.Random.Range(-0.5f, 0.5f);
            s.audioSource.PlayOneShot(s.clip);
        }
        else
            Debug.LogError("No sound with name: " + soundName);
    }
}