using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    private AudioSource game_music;
    private AudioSource menu_music;

    void Start()
    {
        instance = this;
        menu_music = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
        game_music = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        PlayMenuMusic();
    }

    public static Music GetInstance()
    {
        return instance;
    }

    public void PlayMenuMusic()
    {
        // // Unit Test Start
        // Debug.Log("PlayMenuMusic");
        // if (game_music == null)
        // {
        //     Debug.Log("Require audio file: Game music");
        // }
        // if (menu_music == null)
        // {
        //     Debug.Log("Require audio file: Menu music");
        // }
        // // Unit Test End
        game_music.Stop();
        menu_music.Play();
    }

    public void PlayGameMusic()
    {
        // // Unit Test Start
        // Debug.Log("PlayMenuMusic");
        // if (game_music == null)
        // {
        //     Debug.Log("Require audio file: Game music");
        // }
        // if (menu_music == null)
        // {
        //     Debug.Log("Require audio file: Menu music");
        // }
        // // Unit Test End
        menu_music.Stop();
        game_music.Play();
    }
}