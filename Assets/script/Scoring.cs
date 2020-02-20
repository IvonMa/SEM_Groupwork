using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private static Scoring instance;

    private int score = 0;

    System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

    private bool playing = false;

    void Awake()
    {
        instance = this;
    }

    public static Scoring getInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        //score = (int)Time.realtimeSinceStartup;
        if (playing) score = (int)(timer.ElapsedMilliseconds / 1000);
        else score = 0;
    }

    public int getCurrentScore()
    {
        return score;
    }

    public void SetPlayState(bool state)
    {
        playing = state;
        if (state) timer.Start();
        else
        {
            timer.Stop();
            timer.Reset();
        }
    }
}