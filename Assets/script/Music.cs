using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    private AudioSource game_musis;
    private AudioSource menu_music;

    void Start()
    {
        instance = this;
        menu_music = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        game_musis = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        PlayMenuMusic();
    }

    public static Music GetInstance()
    {
        return instance;
    }

    public void PlayMenuMusic()
    {
        game_musis.Stop();
        menu_music.Play();
    }

    public void PlayGameMusic()
    {
        menu_music.Stop();
        game_musis.Play();
    }
}