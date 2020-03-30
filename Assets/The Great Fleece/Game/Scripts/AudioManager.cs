﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance
    {
        get => instance;
    }


    public AudioSource voiceOver;
    public AudioSource music;

    private void Awake()
    {
        instance = this;
    }

    public void PlayVoiceOver(AudioClip audioClip)
    {
        voiceOver.clip = audioClip;
        voiceOver.Play();
    }

    public void PlayMusic()
    {
        music.Play();
    }
    
}
