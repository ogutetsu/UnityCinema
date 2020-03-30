using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get => instance;
    }

    public bool HasCard
    {
        get;
        set;
    }

    public PlayableDirector introCutScene; 
    

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutScene.time = 60.0f;
            AudioManager.Instance.PlayMusic();
        }
    }
}
