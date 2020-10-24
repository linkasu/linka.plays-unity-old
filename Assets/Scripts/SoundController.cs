using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayClip(string name)
    {
        if (source == null) return;
        source.Stop();
        source.clip = FindClipByName(name);
        source.Play();
    }
    AudioClip FindClipByName(string name)
    {
        foreach (var item in clips)
        {
            if (item.name == name) return item;
        }
        return null;
    }

    public static SoundController ControllerInScene
    {
        get
        {
            return GameObject.Find("Sounder").GetComponent<SoundController>();
        }
    }

    internal void PlayAnswerEffect(bool v)
    {
        PlayClip(v ? "good" : "bad");
    }
}
